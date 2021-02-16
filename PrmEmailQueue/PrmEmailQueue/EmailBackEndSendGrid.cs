/*
 * CODE OWNERS: Tom PUckett
 * OBJECTIVE: <Back end implementation using SendGrid
 * DEVELOPER NOTES: <What future developers need to know.>
 */

using SendGrid;
using SendGrid.Helpers.Mail;
using Serilog;
using System;
using System.Threading.Tasks;
using System.Text.Json;

namespace Prm.EmailQueue
{
    internal class EmailBackEndSendGrid : EmailBackEndBase
    {
        internal async override Task<bool> SendEmailAsync(MailItem item, SmtpConfig config)
        {
            var client = new SendGridClient(config.SendGridApiKey);
            var msg = PrepareSendGridMessageEmail(item, config);

            var response = await client.SendEmailAsync(msg);

            if (response.StatusCode != System.Net.HttpStatusCode.Accepted)
            {
                string body = response.Body.ReadAsStringAsync().Result;
                Log.Error($"Failed to send email via SendGrid.{Environment.NewLine}Response status: {response.StatusCode.ToString()}{Environment.NewLine}Response body: {body}{Environment.NewLine}Response headers: {JsonSerializer.Serialize(response.Headers)}");
                return false;
            }

            return true;
        }

        internal override bool SendEmail(MailItem item, SmtpConfig config)
        {
            var client = new SendGridClient(config.SendGridApiKey);
            var msg = PrepareSendGridMessageEmail(item, config);

            var task = Task.Run(() => client.SendEmailAsync(msg));
            while (!task.IsCompleted) System.Threading.Thread.Sleep(50);

            var response = task.Result;
            if (response.StatusCode != System.Net.HttpStatusCode.Accepted)
            {
                string body = response.Body.ReadAsStringAsync().Result;
                Log.Error($"Failed to send email via SendGrid.{Environment.NewLine}Response status: {response.StatusCode.ToString()}{Environment.NewLine}Response body: {body}{Environment.NewLine}Response headers: {JsonSerializer.Serialize(response.Headers)}");
                return false;
            }

            return true;
        }

        private SendGridMessage PrepareSendGridMessageEmail(MailItem item, SmtpConfig config)
        {
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(item.senderAddress, item.senderName),
                Subject = item.subject,
                PlainTextContent = item.messageBody,
                //HtmlContent = "some html"
            };
            if (item.recipients != null) item.recipients.ForEach(r => msg.AddTo(new EmailAddress(r)));
            if (item.ccRecipients != null) item.ccRecipients.ForEach(c => msg.AddCc(c));
            if (item.bccRecipients != null) item.bccRecipients.ForEach(b => msg.AddBcc(b));

            return msg;
        }
    }
}
