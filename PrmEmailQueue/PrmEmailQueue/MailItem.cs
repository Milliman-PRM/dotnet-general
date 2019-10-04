/*
 * CODE OWNERS: Tom Puckett
 * OBJECTIVE: <What and WHY.>
 * DEVELOPER NOTES: <What future developers need to know.>
 */

using System.Collections.Generic;
using MimeKit;

namespace Prm.EmailQueue
{
    internal class MailItem
    {
        internal MimeMessage message { get; }
        internal int sendAttempts { get; set; } = 0;

        internal MailItem(string subject, string messageBody, IEnumerable<string> recipients, string senderAddress, string senderName)
        {
            // Configure required fields for message

            MimeEntity encodedBody = new TextPart("plain")
            {
                Text = messageBody
            };

            MailboxAddress sender = new MailboxAddress(senderName, senderAddress);
            List<InternetAddress> senderList = new List<InternetAddress>();
            senderList.Add(sender);

            List<InternetAddress> recipientList = new List<InternetAddress>();
            foreach (string recipient in recipients)
            {
                recipientList.Add(new MailboxAddress(recipient));
            }

            message = new MimeMessage(senderList, recipientList, subject, encodedBody);
        }
    }
}

