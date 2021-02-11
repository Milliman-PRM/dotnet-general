/*
 * CODE OWNERS: Tom Puckett
 * OBJECTIVE: A base class for back end email sending implementations
 * DEVELOPER NOTES: <What future developers need to know.>
 */

using System;
using System.Threading.Tasks;

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

        internal virtual Task<bool> SendEmailAsync(MailItem item, SmtpConfig config)
        {
            // This code runs only if an override is not implemented in the derived class
            throw new NotImplementedException("Method SendEmailAsync is not implemented");
        }

        internal abstract bool SendEmail(MailItem item, SmtpConfig config);
    }
}
