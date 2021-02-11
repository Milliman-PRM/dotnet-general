using Prm.EmailQueue;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailQueueCoreTestGui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            SmtpConfig config = new SmtpConfig
            {
                SmtpServer = textSmtpServer.Text,
                SmtpPort = int.Parse(textSmtpPort.Text),
                SmtpFromName = textFromName.Text,
                SmtpFromAddress = textFromAddress.Text,
                SmtpUsername = textSmtpUserName.Text,
                SmtpPassword = textPassword.Text,
                MaximumSendAttempts = int.Parse(textMaximumSendAttempts.Text),
                SendGridApiKey = comboSenGridApiKey.Text,
            };

            MailSender.ConfigureMailSender(config);
            MailSender mailSender = new MailSender();
            bool success = mailSender.QueueMessage(listToAddresses.Items.Cast<string>(), lstCcAddresses.Items.Cast<string>(), lstBccAddresses.Items.Cast<string>(), textSubject.Text, textMessageText.Text, config.SmtpFromAddress, config.SmtpFromName);

            if (!success)
            {
                MessageBox.Show(text: "False return value from MailSender.QueueMessage", caption: "", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }
    }
}
