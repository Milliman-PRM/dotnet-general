namespace EmailQueueCoreTestGui
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSend = new System.Windows.Forms.Button();
            this.groupConfiguration = new System.Windows.Forms.GroupBox();
            this.comboSenGridApiKey = new System.Windows.Forms.ComboBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.textSmtpUserName = new System.Windows.Forms.TextBox();
            this.textMaximumSendAttempts = new System.Windows.Forms.TextBox();
            this.textFromAddress = new System.Windows.Forms.TextBox();
            this.textFromName = new System.Windows.Forms.TextBox();
            this.textSmtpPort = new System.Windows.Forms.TextBox();
            this.textSmtpServer = new System.Windows.Forms.TextBox();
            this.labelSendGridApiKey = new System.Windows.Forms.Label();
            this.labelSmtpPassword = new System.Windows.Forms.Label();
            this.labelSmtpUserName = new System.Windows.Forms.Label();
            this.labelMaximumSendAttempts = new System.Windows.Forms.Label();
            this.labelFromAddress = new System.Windows.Forms.Label();
            this.labelFromName = new System.Windows.Forms.Label();
            this.labelSmtpServer = new System.Windows.Forms.Label();
            this.labelSmtpPort = new System.Windows.Forms.Label();
            this.groupMessage = new System.Windows.Forms.GroupBox();
            this.lstCcAddresses = new System.Windows.Forms.ListBox();
            this.lblCcAddresses = new System.Windows.Forms.Label();
            this.lstBccAddresses = new System.Windows.Forms.ListBox();
            this.lblBccAddresses = new System.Windows.Forms.Label();
            this.textSubject = new System.Windows.Forms.TextBox();
            this.labelSubject = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textMessageText = new System.Windows.Forms.TextBox();
            this.listToAddresses = new System.Windows.Forms.ListBox();
            this.labelRecipients = new System.Windows.Forms.Label();
            this.listToNames = new System.Windows.Forms.ListBox();
            this.labelRecipientNames = new System.Windows.Forms.Label();
            this.groupConfiguration.SuspendLayout();
            this.groupMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(12, 277);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 43);
            this.buttonSend.TabIndex = 0;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // groupConfiguration
            // 
            this.groupConfiguration.Controls.Add(this.comboSenGridApiKey);
            this.groupConfiguration.Controls.Add(this.textPassword);
            this.groupConfiguration.Controls.Add(this.textSmtpUserName);
            this.groupConfiguration.Controls.Add(this.textMaximumSendAttempts);
            this.groupConfiguration.Controls.Add(this.textFromAddress);
            this.groupConfiguration.Controls.Add(this.textFromName);
            this.groupConfiguration.Controls.Add(this.textSmtpPort);
            this.groupConfiguration.Controls.Add(this.textSmtpServer);
            this.groupConfiguration.Controls.Add(this.labelSendGridApiKey);
            this.groupConfiguration.Controls.Add(this.labelSmtpPassword);
            this.groupConfiguration.Controls.Add(this.labelSmtpUserName);
            this.groupConfiguration.Controls.Add(this.labelMaximumSendAttempts);
            this.groupConfiguration.Controls.Add(this.labelFromAddress);
            this.groupConfiguration.Controls.Add(this.labelFromName);
            this.groupConfiguration.Controls.Add(this.labelSmtpServer);
            this.groupConfiguration.Controls.Add(this.labelSmtpPort);
            this.groupConfiguration.Location = new System.Drawing.Point(12, 12);
            this.groupConfiguration.Name = "groupConfiguration";
            this.groupConfiguration.Size = new System.Drawing.Size(434, 259);
            this.groupConfiguration.TabIndex = 1;
            this.groupConfiguration.TabStop = false;
            this.groupConfiguration.Text = "Configuration";
            // 
            // comboSenGridApiKey
            // 
            this.comboSenGridApiKey.FormattingEnabled = true;
            this.comboSenGridApiKey.Items.AddRange(new object[] {
            "",
            "abc123"});
            this.comboSenGridApiKey.Location = new System.Drawing.Point(179, 230);
            this.comboSenGridApiKey.Name = "comboSenGridApiKey";
            this.comboSenGridApiKey.Size = new System.Drawing.Size(249, 23);
            this.comboSenGridApiKey.TabIndex = 2;
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(179, 200);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(249, 23);
            this.textPassword.TabIndex = 1;
            // 
            // textSmtpUserName
            // 
            this.textSmtpUserName.Location = new System.Drawing.Point(179, 170);
            this.textSmtpUserName.Name = "textSmtpUserName";
            this.textSmtpUserName.Size = new System.Drawing.Size(249, 23);
            this.textSmtpUserName.TabIndex = 1;
            // 
            // textMaximumSendAttempts
            // 
            this.textMaximumSendAttempts.Location = new System.Drawing.Point(179, 140);
            this.textMaximumSendAttempts.Name = "textMaximumSendAttempts";
            this.textMaximumSendAttempts.Size = new System.Drawing.Size(249, 23);
            this.textMaximumSendAttempts.TabIndex = 1;
            this.textMaximumSendAttempts.Text = "5";
            // 
            // textFromAddress
            // 
            this.textFromAddress.Location = new System.Drawing.Point(179, 110);
            this.textFromAddress.Name = "textFromAddress";
            this.textFromAddress.Size = new System.Drawing.Size(249, 23);
            this.textFromAddress.TabIndex = 1;
            this.textFromAddress.Text = "map.support@milliman.com";
            // 
            // textFromName
            // 
            this.textFromName.Location = new System.Drawing.Point(179, 80);
            this.textFromName.Name = "textFromName";
            this.textFromName.Size = new System.Drawing.Size(249, 23);
            this.textFromName.TabIndex = 1;
            this.textFromName.Text = "Support test";
            // 
            // textSmtpPort
            // 
            this.textSmtpPort.Location = new System.Drawing.Point(179, 50);
            this.textSmtpPort.Name = "textSmtpPort";
            this.textSmtpPort.Size = new System.Drawing.Size(249, 23);
            this.textSmtpPort.TabIndex = 1;
            this.textSmtpPort.Text = "25";
            // 
            // textSmtpServer
            // 
            this.textSmtpServer.Location = new System.Drawing.Point(179, 20);
            this.textSmtpServer.Name = "textSmtpServer";
            this.textSmtpServer.Size = new System.Drawing.Size(249, 23);
            this.textSmtpServer.TabIndex = 1;
            this.textSmtpServer.Text = "smtp.milliman.com";
            // 
            // labelSendGridApiKey
            // 
            this.labelSendGridApiKey.AutoSize = true;
            this.labelSendGridApiKey.Location = new System.Drawing.Point(17, 233);
            this.labelSendGridApiKey.Name = "labelSendGridApiKey";
            this.labelSendGridApiKey.Size = new System.Drawing.Size(98, 15);
            this.labelSendGridApiKey.TabIndex = 0;
            this.labelSendGridApiKey.Text = "SendGrid Api Key";
            // 
            // labelSmtpPassword
            // 
            this.labelSmtpPassword.AutoSize = true;
            this.labelSmtpPassword.Location = new System.Drawing.Point(17, 203);
            this.labelSmtpPassword.Name = "labelSmtpPassword";
            this.labelSmtpPassword.Size = new System.Drawing.Size(88, 15);
            this.labelSmtpPassword.TabIndex = 0;
            this.labelSmtpPassword.Text = "Smtp Password";
            // 
            // labelSmtpUserName
            // 
            this.labelSmtpUserName.AutoSize = true;
            this.labelSmtpUserName.Location = new System.Drawing.Point(17, 173);
            this.labelSmtpUserName.Name = "labelSmtpUserName";
            this.labelSmtpUserName.Size = new System.Drawing.Size(98, 15);
            this.labelSmtpUserName.TabIndex = 0;
            this.labelSmtpUserName.Text = "SMTP User Name";
            // 
            // labelMaximumSendAttempts
            // 
            this.labelMaximumSendAttempts.AutoSize = true;
            this.labelMaximumSendAttempts.Location = new System.Drawing.Point(17, 143);
            this.labelMaximumSendAttempts.Name = "labelMaximumSendAttempts";
            this.labelMaximumSendAttempts.Size = new System.Drawing.Size(143, 15);
            this.labelMaximumSendAttempts.TabIndex = 0;
            this.labelMaximumSendAttempts.Text = "Maximum Send Attempts";
            // 
            // labelFromAddress
            // 
            this.labelFromAddress.AutoSize = true;
            this.labelFromAddress.Location = new System.Drawing.Point(17, 113);
            this.labelFromAddress.Name = "labelFromAddress";
            this.labelFromAddress.Size = new System.Drawing.Size(80, 15);
            this.labelFromAddress.TabIndex = 0;
            this.labelFromAddress.Text = "From Address";
            // 
            // labelFromName
            // 
            this.labelFromName.AutoSize = true;
            this.labelFromName.Location = new System.Drawing.Point(17, 83);
            this.labelFromName.Name = "labelFromName";
            this.labelFromName.Size = new System.Drawing.Size(70, 15);
            this.labelFromName.TabIndex = 0;
            this.labelFromName.Text = "From Name";
            // 
            // labelSmtpServer
            // 
            this.labelSmtpServer.AutoSize = true;
            this.labelSmtpServer.Location = new System.Drawing.Point(17, 23);
            this.labelSmtpServer.Name = "labelSmtpServer";
            this.labelSmtpServer.Size = new System.Drawing.Size(70, 15);
            this.labelSmtpServer.TabIndex = 0;
            this.labelSmtpServer.Text = "Smtp Server";
            // 
            // labelSmtpPort
            // 
            this.labelSmtpPort.AutoSize = true;
            this.labelSmtpPort.Location = new System.Drawing.Point(17, 53);
            this.labelSmtpPort.Name = "labelSmtpPort";
            this.labelSmtpPort.Size = new System.Drawing.Size(60, 15);
            this.labelSmtpPort.TabIndex = 0;
            this.labelSmtpPort.Text = "Smtp Port";
            // 
            // groupMessage
            // 
            this.groupMessage.Controls.Add(this.lstCcAddresses);
            this.groupMessage.Controls.Add(this.lblCcAddresses);
            this.groupMessage.Controls.Add(this.lstBccAddresses);
            this.groupMessage.Controls.Add(this.lblBccAddresses);
            this.groupMessage.Controls.Add(this.textSubject);
            this.groupMessage.Controls.Add(this.labelSubject);
            this.groupMessage.Controls.Add(this.label1);
            this.groupMessage.Controls.Add(this.textMessageText);
            this.groupMessage.Controls.Add(this.listToAddresses);
            this.groupMessage.Controls.Add(this.labelRecipients);
            this.groupMessage.Controls.Add(this.listToNames);
            this.groupMessage.Controls.Add(this.labelRecipientNames);
            this.groupMessage.Location = new System.Drawing.Point(452, 13);
            this.groupMessage.Name = "groupMessage";
            this.groupMessage.Size = new System.Drawing.Size(492, 336);
            this.groupMessage.TabIndex = 2;
            this.groupMessage.TabStop = false;
            this.groupMessage.Text = "groupBox2";
            // 
            // lstCcAddresses
            // 
            this.lstCcAddresses.FormattingEnabled = true;
            this.lstCcAddresses.IntegralHeight = false;
            this.lstCcAddresses.ItemHeight = 15;
            this.lstCcAddresses.Items.AddRange(new object[] {
            "evan.klein@milliman.com"});
            this.lstCcAddresses.Location = new System.Drawing.Point(8, 128);
            this.lstCcAddresses.Name = "lstCcAddresses";
            this.lstCcAddresses.Size = new System.Drawing.Size(230, 59);
            this.lstCcAddresses.TabIndex = 3;
            // 
            // lblCcAddresses
            // 
            this.lblCcAddresses.AutoSize = true;
            this.lblCcAddresses.Location = new System.Drawing.Point(8, 109);
            this.lblCcAddresses.Name = "lblCcAddresses";
            this.lblCcAddresses.Size = new System.Drawing.Size(79, 15);
            this.lblCcAddresses.TabIndex = 4;
            this.lblCcAddresses.Text = "CC Addresses";
            // 
            // lstBccAddresses
            // 
            this.lstBccAddresses.FormattingEnabled = true;
            this.lstBccAddresses.IntegralHeight = false;
            this.lstBccAddresses.ItemHeight = 15;
            this.lstBccAddresses.Location = new System.Drawing.Point(244, 127);
            this.lstBccAddresses.Name = "lstBccAddresses";
            this.lstBccAddresses.Size = new System.Drawing.Size(242, 59);
            this.lstBccAddresses.TabIndex = 5;
            // 
            // lblBccAddresses
            // 
            this.lblBccAddresses.AutoSize = true;
            this.lblBccAddresses.Location = new System.Drawing.Point(245, 109);
            this.lblBccAddresses.Name = "lblBccAddresses";
            this.lblBccAddresses.Size = new System.Drawing.Size(86, 15);
            this.lblBccAddresses.TabIndex = 6;
            this.lblBccAddresses.Text = "BCC Addresses";
            // 
            // textSubject
            // 
            this.textSubject.Location = new System.Drawing.Point(91, 213);
            this.textSubject.Name = "textSubject";
            this.textSubject.Size = new System.Drawing.Size(395, 23);
            this.textSubject.TabIndex = 2;
            this.textSubject.Text = "Some email subject";
            // 
            // labelSubject
            // 
            this.labelSubject.AutoSize = true;
            this.labelSubject.Location = new System.Drawing.Point(8, 216);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(46, 15);
            this.labelSubject.TabIndex = 0;
            this.labelSubject.Text = "Subject";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Message Text";
            // 
            // textMessageText
            // 
            this.textMessageText.Location = new System.Drawing.Point(90, 243);
            this.textMessageText.Multiline = true;
            this.textMessageText.Name = "textMessageText";
            this.textMessageText.Size = new System.Drawing.Size(396, 78);
            this.textMessageText.TabIndex = 1;
            this.textMessageText.Text = "Here is message text";
            // 
            // listToAddresses
            // 
            this.listToAddresses.FormattingEnabled = true;
            this.listToAddresses.IntegralHeight = false;
            this.listToAddresses.ItemHeight = 15;
            this.listToAddresses.Items.AddRange(new object[] {
            "tom.puckett@milliman.com"});
            this.listToAddresses.Location = new System.Drawing.Point(7, 38);
            this.listToAddresses.Name = "listToAddresses";
            this.listToAddresses.Size = new System.Drawing.Size(230, 59);
            this.listToAddresses.TabIndex = 0;
            // 
            // labelRecipients
            // 
            this.labelRecipients.AutoSize = true;
            this.labelRecipients.Location = new System.Drawing.Point(7, 19);
            this.labelRecipients.Name = "labelRecipients";
            this.labelRecipients.Size = new System.Drawing.Size(75, 15);
            this.labelRecipients.TabIndex = 0;
            this.labelRecipients.Text = "To Addresses";
            // 
            // listToNames
            // 
            this.listToNames.FormattingEnabled = true;
            this.listToNames.IntegralHeight = false;
            this.listToNames.ItemHeight = 15;
            this.listToNames.Items.AddRange(new object[] {
            "Tom Puckett"});
            this.listToNames.Location = new System.Drawing.Point(243, 37);
            this.listToNames.Name = "listToNames";
            this.listToNames.Size = new System.Drawing.Size(242, 59);
            this.listToNames.TabIndex = 0;
            // 
            // labelRecipientNames
            // 
            this.labelRecipientNames.AutoSize = true;
            this.labelRecipientNames.Location = new System.Drawing.Point(244, 19);
            this.labelRecipientNames.Name = "labelRecipientNames";
            this.labelRecipientNames.Size = new System.Drawing.Size(59, 15);
            this.labelRecipientNames.TabIndex = 0;
            this.labelRecipientNames.Text = "To Names";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 365);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.groupMessage);
            this.Controls.Add(this.groupConfiguration);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupConfiguration.ResumeLayout(false);
            this.groupConfiguration.PerformLayout();
            this.groupMessage.ResumeLayout(false);
            this.groupMessage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.GroupBox groupConfiguration;
        private System.Windows.Forms.Label labelMaximumSendAttempts;
        private System.Windows.Forms.Label labelFromAddress;
        private System.Windows.Forms.Label labelFromName;
        private System.Windows.Forms.Label labelSmtpPort;
        private System.Windows.Forms.Label labelSmtpServer;
        private System.Windows.Forms.Label labelSendGridApiKey;
        private System.Windows.Forms.Label labelSmtpPassword;
        private System.Windows.Forms.Label labelSmtpUserName;
        private System.Windows.Forms.TextBox textSmtpUserName;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.TextBox textFromAddress;
        private System.Windows.Forms.TextBox textFromName;
        private System.Windows.Forms.TextBox textSmtpPort;
        private System.Windows.Forms.TextBox textSmtpServer;
        private System.Windows.Forms.TextBox textMaximumSendAttempts;
        private System.Windows.Forms.GroupBox groupMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listToAddresses;
        private System.Windows.Forms.Label labelRecipients;
        private System.Windows.Forms.ListBox listToNames;
        private System.Windows.Forms.Label labelRecipientNames;
        private System.Windows.Forms.TextBox textMessageText;
        private System.Windows.Forms.TextBox textSubject;
        private System.Windows.Forms.Label labelSubject;
        private System.Windows.Forms.ComboBox comboSenGridApiKey;
        private System.Windows.Forms.Label lblCcAddresses;
        private System.Windows.Forms.Label lblBccAddresses;
        private System.Windows.Forms.ListBox lstCcAddresses;
        private System.Windows.Forms.ListBox lstBccAddresses;
    }
}

