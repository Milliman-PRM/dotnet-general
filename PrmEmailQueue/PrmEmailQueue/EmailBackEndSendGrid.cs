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
        internal override bool SendEmail(MailItem item, SmtpConfig config)
        {
            var client = new SendGridClient(config.SendGridApiKey);

            var msg = new SendGridMessage()
            {
                From = new EmailAddress(item.senderAddress, item.senderName),
                Subject = item.subject,
                PlainTextContent = item.messageBody,
                //HtmlContent = "<strong>Hello, Email!</strong>"
            };
            foreach (string recipient in item.recipients)
            {
                msg.AddTo(new EmailAddress(recipient));
            }
            var task = Task.Run(() => client.SendEmailAsync(msg));
            while (!task.IsCompleted) System.Threading.Thread.Sleep(50);

            var response = task.Result;
            if (response.StatusCode != System.Net.HttpStatusCode.Accepted)
            {
                string body = response.Body.ReadAsStringAsync().Result;
                Log.Error($"Failed to send email via SendGrid.{Environment.NewLine}Response status: {response.StatusCode.ToString()}{Environment.NewLine}Response body: {body}{Environment.NewLine}Response headers: {JsonSerializer.Serialize(response.Headers)}");
            }

            return true;
        }
    }
}
