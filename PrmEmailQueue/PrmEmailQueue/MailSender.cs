/*
 * CODE OWNERS: Ben Wyatt
 * OBJECTIVE:Queueing system for outgoing email
 * DEVELOPER NOTES: 
 */

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Concurrent;
using Serilog;
using System.Linq;

namespace Prm.EmailQueue
{
    public class MailSender
    {
        private static ConcurrentQueue<MailItem> Messages = new ConcurrentQueue<MailItem>();
        private static Task WorkerTask = null;
        private static int InstanceCount = 0;
        private static object ThreadSafetyLock = new object();
        private static SmtpConfig smtpConfig = null;
        private static EmailBackEndSelector _backEndSelector
        {
            get
            {
                return string.IsNullOrEmpty(smtpConfig.SendGridApiKey)
                    ? EmailBackEndSelector.Smtp
                    : EmailBackEndSelector.SendGrid;
            }
        }

        /// <summary>
        /// Stores the provided configuration object to govern internal behavior of the api
        /// </summary>
        /// <param name="config">Iff the SendGridApiKey property has null/empty value then SMTP implementation will be chosen</param>
        public static void ConfigureMailSender(SmtpConfig config)
        {
            lock (ThreadSafetyLock)
            {
                smtpConfig = config;
            }
        }

        /// <summary>
        /// This constructor is deprecated and may be removed in the future
        /// </summary>
        /// <param name="loggerArg">Not used</param>
        public MailSender(ILogger loggerArg)
            : this()
        { }

        public MailSender()
        {
            lock (ThreadSafetyLock)
            {
                if (smtpConfig == null)
                {
                    throw new Exception("Attempt to instantiate MailSender before initializing!");
                }

                InstanceCount++;

                if (WorkerTask == null || (WorkerTask.Status != TaskStatus.Running && WorkerTask.Status != TaskStatus.WaitingToRun))
                {
                    WorkerTask = Task.Run(() => ProcessQueueEvents());
                    while (WorkerTask.Status != TaskStatus.Running)
                    {
                        Thread.Sleep(1);
                    }
                }
            }
        }

        public bool QueueMessage(IEnumerable<string> recipients, IEnumerable<string> cc, IEnumerable<string> bcc, string subject, string message, string senderAddress, string senderName, string disclaimer = null)
        {
            // SendGrid fails to send if any email address is provided in more than one of the lists: recipients, cc, bcc
            if (recipients.Union(cc ?? new List<string>(), StringComparer.InvariantCultureIgnoreCase).Union(bcc ?? new List<string>(), StringComparer.InvariantCultureIgnoreCase).Count() 
                != recipients.Count() + (cc ?? new List<string>()).Count() + (bcc ?? new List<string>()).Count())
            {
                throw new ApplicationException("Attempt to queue email message with at least one email address duplicated in recipient, cc, and bcc lists");
            }

            if (string.IsNullOrWhiteSpace(disclaimer))
            {
                disclaimer = smtpConfig.EmailDisclaimer;
            }

            try
            {
                if (String.IsNullOrEmpty(senderAddress))
                {
                    senderAddress = smtpConfig.SmtpFromAddress;
                }
                if (String.IsNullOrEmpty(senderName))
                {
                    senderName = smtpConfig.SmtpFromName;
                }

                MailItem mailItem = new MailItem
                {
                    subject = subject,
                    messageBody = message,
                    recipients = new List<string>(recipients),
                    senderAddress = senderAddress,
                    senderName = senderName
                };
                if (cc != null)
                {
                    mailItem.ccRecipients = new List<string>(cc);
                }
                if (bcc != null)
                {
                    mailItem.bccRecipients = new List<string>(bcc);
                }

                // Add the configured disclaimer if any recipient or cc or bcc is not in the DisclaimerExemptDomainList
                if (!string.IsNullOrWhiteSpace(disclaimer) &&
                    (mailItem.recipients.Any(r => !smtpConfig.DisclaimerExemptDomainList.Any(d => r.EndsWith(d)) ) ||
                     mailItem.ccRecipients.Any(c => !smtpConfig.DisclaimerExemptDomainList.Any(d => c.EndsWith(d))) ||
                     mailItem.bccRecipients.Any(b => !smtpConfig.DisclaimerExemptDomainList.Any(d => b.EndsWith(d)))))
                {
                    mailItem.messageBody += Environment.NewLine +
                                            Environment.NewLine +
                                            disclaimer;
                }

                Messages.Enqueue(mailItem);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool QueueMessage(IEnumerable<string> recipients, string subject, string message, string senderAddress, string senderName, string disclaimer = null)
        {
            return QueueMessage(recipients, null, null, subject, message, senderAddress, senderName, disclaimer);
        }

        ~MailSender()
        {
            lock (ThreadSafetyLock)
            {
                InstanceCount--;
                if (InstanceCount == 0 && WaitForWorkerThreadEnd(1000))  // Not the best stategy
                {
                    WorkerTask = null;
                }
            }
        }

        /// <summary>
        /// Waits for the worker thread to end (if running)
        /// </summary>
        /// <param name="MaxWaitMs">Time limit to wait (in ms)</param>
        /// <returns>true if thread is not running at time of return</returns>
        public bool WaitForWorkerThreadEnd(int MaxWaitMs = 0)
        {
            if (WorkerTask != null && WorkerTask.Status == TaskStatus.Running)
            {
                WorkerTask = Task.Run(() => ProcessQueueEvents());
                return WorkerTask.Wait(MaxWaitMs);
            }
            return true;
        }

        /// <summary>
        /// Process and send messages in the queue
        /// </summary>
        /// <param name="Arg"></param>
        private static void ProcessQueueEvents()
        {
            while (InstanceCount > 0)
            {
                if (Messages.Count > 0)
                {
                    MailItem nextMessage;
                    while (Messages.TryDequeue(out nextMessage))
                    {
                        SendEmail(nextMessage);
                    }
                }
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// Send mail
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private static bool SendEmail(MailItem message)
        {
            message.sendAttempts++;

            lock (ThreadSafetyLock)
            {
                try
                {
                    EmailBackEndBase backEnd = EmailBackEndBase.Instance(_backEndSelector);
                    backEnd.SendEmail(message, smtpConfig);
                }
                catch (Exception ex)
                {
                    if (message.sendAttempts > smtpConfig.MaximumSendAttempts)
                    {
                        Log.Error(ex, $"Failed to send email on attempt #{message.sendAttempts}, limit exceed, message discarded.");
                        return false;
                    }

                    Log.Warning(ex, $"Failed to send email on attempt #{message.sendAttempts}");
                    Messages.Enqueue(message);
                }
            }

            return true;
        }
    }
}
