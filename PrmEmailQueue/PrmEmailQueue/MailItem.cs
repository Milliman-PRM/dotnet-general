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
        internal string subject;
        internal string messageBody;
        internal IEnumerable<string> recipients;
        internal string senderAddress;
        internal string senderName;

        internal int sendAttempts { get; set; } = 0;
    }
}

