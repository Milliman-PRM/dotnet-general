/*
 * CODE OWNERS: Tom Puckett
 * OBJECTIVE: <What and WHY.>
 * DEVELOPER NOTES: <What future developers need to know.>
 */

using MimeKit;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prm.EmailQueue
{
    internal class EmailBackEndSmtp : EmailBackEndBase
    {
        internal override bool SendEmail(MailItem item, SmtpConfig smtpConfig)
        {
            MimeEntity encodedBody = new TextPart("plain")
            {
                Text = item.messageBody
            };

            MailboxAddress sender = new MailboxAddress(item.senderName, item.senderAddress);
            List<InternetAddress> senderList = new List<InternetAddress>();
            senderList.Add(sender);

            List<InternetAddress> recipientList = new List<InternetAddress>();
            foreach (string recipient in item.recipients)
            {
                recipientList.Add(new MailboxAddress(recipient));
            }

            MimeMessage message = new MimeMessage(senderList, recipientList, item.subject, encodedBody);

            // Send mail
            using (var client = new SmtpClient())
            {
                // Attempt to authenticate if credentials are configured
                // Will throw an exception if authentication fails
                if (!string.IsNullOrWhiteSpace(smtpConfig.SmtpUsername) && !string.IsNullOrWhiteSpace(smtpConfig.SmtpPassword))
                {
                    client.Connect(smtpConfig.SmtpServer, smtpConfig.SmtpPort, MailKit.Security.SecureSocketOptions.StartTlsWhenAvailable);
                    client.Authenticate(smtpConfig.SmtpUsername, smtpConfig.SmtpPassword);
                }
                else
                {
                    client.Connect(smtpConfig.SmtpServer, smtpConfig.SmtpPort, MailKit.Security.SecureSocketOptions.None);
                }

                client.Send(message);
                client.Disconnect(true);
            }
            return true;

        }
    }
}
