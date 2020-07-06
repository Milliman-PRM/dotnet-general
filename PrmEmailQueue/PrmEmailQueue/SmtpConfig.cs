/*
 * CODE OWNERS: Tom Puckett, Ben Wyatt
 * OBJECTIVE: Represents configuration data for this package, to be populated by a using application
 * DEVELOPER NOTES: 
 */

using System;
using System.Collections.Generic;

namespace Prm.EmailQueue
{
    public class SmtpConfig
    {
        public string SmtpServer { get; set; } = string.Empty;

        public int SmtpPort { get; set; } = 25;

        public string SmtpFromAddress { get; set; } = string.Empty;

        public string SmtpFromName { get; set; } = string.Empty;

        public int MaximumSendAttempts { get; set; } = 5;

        public string SmtpUsername { get; set; } = string.Empty;

        public string SmtpPassword { get; set; } = string.Empty;

        public string SendGridApiKey { get; set; } = null;

        public string EmailDisclaimer { get; set; } = null;

        public string DisclaimerExemptDomainString { get; set; } = string.Empty;

        public IEnumerable<string> DisclaimerExemptDomainList => DisclaimerExemptDomainString.Split(new[] { ';', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
    }
}
