/*
 * CODE OWNERS: Tom Puckett
 * OBJECTIVE: A base class for back end email sending implementations
 * DEVELOPER NOTES: <What future developers need to know.>
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace Prm.EmailQueue
{
    public enum EmailBackEndSelector
    {
        Smtp,
        SendGrid,
    }

    public abstract class EmailBackEndBase
    {
        public static EmailBackEndBase Instance(EmailBackEndSelector backEndSelector = EmailBackEndSelector.Smtp)
        {
            switch (backEndSelector)
            {
                case EmailBackEndSelector.Smtp:
                    return new EmailBackEndSmtp();

                case EmailBackEndSelector.SendGrid:
                    return new EmailBackEndSendGrid();

                default:
                    return null;
            }
        }

        internal abstract bool SendEmail(MailItem item, SmtpConfig config);
    }
}
