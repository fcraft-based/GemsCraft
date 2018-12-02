namespace fCraft.GUI.ConfigGUI.GUI.Sections
{
    partial class IRCConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gIRCAdv = new System.Windows.Forms.GroupBox();
            this.tServPass = new System.Windows.Forms.TextBox();
            this.xServPass = new System.Windows.Forms.CheckBox();
            this.tChanPass = new System.Windows.Forms.TextBox();
            this.xChanPass = new System.Windows.Forms.CheckBox();
            this.xIRCListShowNonEnglish = new System.Windows.Forms.CheckBox();
            this.gIRCOptions = new System.Windows.Forms.GroupBox();
            this.xIRCBotAnnounceServerEvents = new System.Windows.Forms.CheckBox();
            this.xIRCUseColor = new System.Windows.Forms.CheckBox();
            this.lIRCNoForwardingMessage = new System.Windows.Forms.Label();
            this.xIRCBotAnnounceIRCJoins = new System.Windows.Forms.CheckBox();
            this.bColorIRC = new System.Windows.Forms.Button();
            this.lColorIRC = new System.Windows.Forms.Label();
            this.xIRCBotForwardFromIRC = new System.Windows.Forms.CheckBox();
            this.xIRCBotAnnounceServerJoins = new System.Windows.Forms.CheckBox();
            this.xIRCBotForwardFromServer = new System.Windows.Forms.CheckBox();
            this.gIRCNetwork = new System.Windows.Forms.GroupBox();
            this.lIRCDelayUnits = new System.Windows.Forms.Label();
            this.xIRCRegisteredNick = new System.Windows.Forms.CheckBox();
            this.tIRCNickServMessage = new System.Windows.Forms.TextBox();
            this.lIRCNickServMessage = new System.Windows.Forms.Label();
            this.tIRCNickServ = new System.Windows.Forms.TextBox();
            this.lIRCNickServ = new System.Windows.Forms.Label();
            this.nIRCDelay = new System.Windows.Forms.NumericUpDown();
            this.lIRCDelay = new System.Windows.Forms.Label();
            this.lIRCBotChannels2 = new System.Windows.Forms.Label();
            this.lIRCBotChannels3 = new System.Windows.Forms.Label();
            this.tIRCBotChannels = new System.Windows.Forms.TextBox();
            this.lIRCBotChannels = new System.Windows.Forms.Label();
            this.nIRCBotPort = new System.Windows.Forms.NumericUpDown();
            this.lIRCBotPort = new System.Windows.Forms.Label();
            this.tIRCBotNetwork = new System.Windows.Forms.TextBox();
            this.lIRCBotNetwork = new System.Windows.Forms.Label();
            this.lIRCBotNick = new System.Windows.Forms.Label();
            this.tIRCBotNick = new System.Windows.Forms.TextBox();
            this.lIRCList = new System.Windows.Forms.Label();
            this.xIRCBotEnabled = new System.Windows.Forms.CheckBox();
            this.cIRCList = new System.Windows.Forms.ComboBox();
            this.bResetTab = new MetroFramework.Controls.MetroButton();
            this.gIRCAdv.SuspendLayout();
            this.gIRCOptions.SuspendLayout();
            this.gIRCNetwork.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nIRCDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nIRCBotPort)).BeginInit();
            this.SuspendLayout();
            // 
            // gIRCAdv
            // 
            this.gIRCAdv.Controls.Add(this.tServPass);
            this.gIRCAdv.Controls.Add(this.xServPass);
            this.gIRCAdv.Controls.Add(this.tChanPass);
            this.gIRCAdv.Controls.Add(this.xChanPass);
            this.gIRCAdv.Location = new System.Drawing.Point(18, 643);
            this.gIRCAdv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gIRCAdv.Name = "gIRCAdv";
            this.gIRCAdv.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gIRCAdv.Size = new System.Drawing.Size(628, 146);
            this.gIRCAdv.TabIndex = 13;
            this.gIRCAdv.TabStop = false;
            this.gIRCAdv.Text = "Advanced";
            // 
            // tServPass
            // 
            this.tServPass.Enabled = false;
            this.tServPass.Location = new System.Drawing.Point(328, 74);
            this.tServPass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tServPass.Name = "tServPass";
            this.tServPass.Size = new System.Drawing.Size(229, 26);
            this.tServPass.TabIndex = 3;
            // 
            // xServPass
            // 
            this.xServPass.AutoSize = true;
            this.xServPass.Location = new System.Drawing.Point(328, 35);
            this.xServPass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xServPass.Name = "xServPass";
            this.xServPass.Size = new System.Drawing.Size(187, 24);
            this.xServPass.TabIndex = 2;
            this.xServPass.Text = "Use Server Password";
            this.xServPass.UseVisualStyleBackColor = true;
            // 
            // tChanPass
            // 
            this.tChanPass.Enabled = false;
            this.tChanPass.Location = new System.Drawing.Point(24, 74);
            this.tChanPass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tChanPass.Name = "tChanPass";
            this.tChanPass.Size = new System.Drawing.Size(229, 26);
            this.tChanPass.TabIndex = 1;
            // 
            // xChanPass
            // 
            this.xChanPass.AutoSize = true;
            this.xChanPass.Location = new System.Drawing.Point(24, 35);
            this.xChanPass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xChanPass.Name = "xChanPass";
            this.xChanPass.Size = new System.Drawing.Size(200, 24);
            this.xChanPass.TabIndex = 0;
            this.xChanPass.Text = "Use Channel Password";
            this.xChanPass.UseVisualStyleBackColor = true;
            // 
            // xIRCListShowNonEnglish
            // 
            this.xIRCListShowNonEnglish.AutoSize = true;
            this.xIRCListShowNonEnglish.Enabled = false;
            this.xIRCListShowNonEnglish.Location = new System.Drawing.Point(672, 95);
            this.xIRCListShowNonEnglish.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xIRCListShowNonEnglish.Name = "xIRCListShowNonEnglish";
            this.xIRCListShowNonEnglish.Size = new System.Drawing.Size(231, 24);
            this.xIRCListShowNonEnglish.TabIndex = 10;
            this.xIRCListShowNonEnglish.Text = "Show non-English networks";
            this.xIRCListShowNonEnglish.UseVisualStyleBackColor = true;
            // 
            // gIRCOptions
            // 
            this.gIRCOptions.Controls.Add(this.xIRCBotAnnounceServerEvents);
            this.gIRCOptions.Controls.Add(this.xIRCUseColor);
            this.gIRCOptions.Controls.Add(this.lIRCNoForwardingMessage);
            this.gIRCOptions.Controls.Add(this.xIRCBotAnnounceIRCJoins);
            this.gIRCOptions.Controls.Add(this.bColorIRC);
            this.gIRCOptions.Controls.Add(this.lColorIRC);
            this.gIRCOptions.Controls.Add(this.xIRCBotForwardFromIRC);
            this.gIRCOptions.Controls.Add(this.xIRCBotAnnounceServerJoins);
            this.gIRCOptions.Controls.Add(this.xIRCBotForwardFromServer);
            this.gIRCOptions.Location = new System.Drawing.Point(15, 385);
            this.gIRCOptions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gIRCOptions.Name = "gIRCOptions";
            this.gIRCOptions.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gIRCOptions.Size = new System.Drawing.Size(954, 249);
            this.gIRCOptions.TabIndex = 12;
            this.gIRCOptions.TabStop = false;
            this.gIRCOptions.Text = "Options";
            // 
            // xIRCBotAnnounceServerEvents
            // 
            this.xIRCBotAnnounceServerEvents.AutoSize = true;
            this.xIRCBotAnnounceServerEvents.Location = new System.Drawing.Point(57, 168);
            this.xIRCBotAnnounceServerEvents.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xIRCBotAnnounceServerEvents.Name = "xIRCBotAnnounceServerEvents";
            this.xIRCBotAnnounceServerEvents.Size = new System.Drawing.Size(550, 24);
            this.xIRCBotAnnounceServerEvents.TabIndex = 7;
            this.xIRCBotAnnounceServerEvents.Text = "Announce SERVER events (kicks, bans, promotions, demotions) on IRC.";
            this.xIRCBotAnnounceServerEvents.UseVisualStyleBackColor = true;
            // 
            // xIRCUseColor
            // 
            this.xIRCUseColor.AutoSize = true;
            this.xIRCUseColor.Location = new System.Drawing.Point(488, 52);
            this.xIRCUseColor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xIRCUseColor.Name = "xIRCUseColor";
            this.xIRCUseColor.Size = new System.Drawing.Size(198, 24);
            this.xIRCUseColor.TabIndex = 2;
            this.xIRCUseColor.Text = "Use text colors on IRC.";
            this.xIRCUseColor.UseVisualStyleBackColor = true;
            // 
            // lIRCNoForwardingMessage
            // 
            this.lIRCNoForwardingMessage.AutoSize = true;
            this.lIRCNoForwardingMessage.Location = new System.Drawing.Point(52, 211);
            this.lIRCNoForwardingMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lIRCNoForwardingMessage.Name = "lIRCNoForwardingMessage";
            this.lIRCNoForwardingMessage.Size = new System.Drawing.Size(729, 20);
            this.lIRCNoForwardingMessage.TabIndex = 8;
            this.lIRCNoForwardingMessage.Text = "NOTE: If forwarding all messages is not enabled, only messages starting with a ha" +
    "sh (#) will be relayed.";
            // 
            // xIRCBotAnnounceIRCJoins
            // 
            this.xIRCBotAnnounceIRCJoins.AutoSize = true;
            this.xIRCBotAnnounceIRCJoins.Location = new System.Drawing.Point(488, 129);
            this.xIRCBotAnnounceIRCJoins.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xIRCBotAnnounceIRCJoins.Name = "xIRCBotAnnounceIRCJoins";
            this.xIRCBotAnnounceIRCJoins.Size = new System.Drawing.Size(393, 24);
            this.xIRCBotAnnounceIRCJoins.TabIndex = 6;
            this.xIRCBotAnnounceIRCJoins.Text = "Announce people joining/leaving the IRC channels.";
            this.xIRCBotAnnounceIRCJoins.UseVisualStyleBackColor = true;
            // 
            // bColorIRC
            // 
            this.bColorIRC.BackColor = System.Drawing.Color.White;
            this.bColorIRC.Location = new System.Drawing.Point(228, 31);
            this.bColorIRC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bColorIRC.Name = "bColorIRC";
            this.bColorIRC.Size = new System.Drawing.Size(150, 35);
            this.bColorIRC.TabIndex = 1;
            this.bColorIRC.UseVisualStyleBackColor = false;
            // 
            // lColorIRC
            // 
            this.lColorIRC.AutoSize = true;
            this.lColorIRC.Location = new System.Drawing.Point(52, 37);
            this.lColorIRC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lColorIRC.Name = "lColorIRC";
            this.lColorIRC.Size = new System.Drawing.Size(144, 20);
            this.lColorIRC.TabIndex = 0;
            this.lColorIRC.Text = "IRC message color";
            // 
            // xIRCBotForwardFromIRC
            // 
            this.xIRCBotForwardFromIRC.AutoSize = true;
            this.xIRCBotForwardFromIRC.Location = new System.Drawing.Point(57, 129);
            this.xIRCBotForwardFromIRC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xIRCBotForwardFromIRC.Name = "xIRCBotForwardFromIRC";
            this.xIRCBotForwardFromIRC.Size = new System.Drawing.Size(323, 24);
            this.xIRCBotForwardFromIRC.TabIndex = 4;
            this.xIRCBotForwardFromIRC.Text = "Forward ALL chat from IRC to SERVER.";
            this.xIRCBotForwardFromIRC.UseVisualStyleBackColor = true;
            // 
            // xIRCBotAnnounceServerJoins
            // 
            this.xIRCBotAnnounceServerJoins.AutoSize = true;
            this.xIRCBotAnnounceServerJoins.Location = new System.Drawing.Point(488, 91);
            this.xIRCBotAnnounceServerJoins.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xIRCBotAnnounceServerJoins.Name = "xIRCBotAnnounceServerJoins";
            this.xIRCBotAnnounceServerJoins.Size = new System.Drawing.Size(365, 24);
            this.xIRCBotAnnounceServerJoins.TabIndex = 5;
            this.xIRCBotAnnounceServerJoins.Text = "Announce people joining/leaving the SERVER.";
            this.xIRCBotAnnounceServerJoins.UseVisualStyleBackColor = true;
            // 
            // xIRCBotForwardFromServer
            // 
            this.xIRCBotForwardFromServer.AutoSize = true;
            this.xIRCBotForwardFromServer.Location = new System.Drawing.Point(57, 91);
            this.xIRCBotForwardFromServer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xIRCBotForwardFromServer.Name = "xIRCBotForwardFromServer";
            this.xIRCBotForwardFromServer.Size = new System.Drawing.Size(323, 24);
            this.xIRCBotForwardFromServer.TabIndex = 3;
            this.xIRCBotForwardFromServer.Text = "Forward ALL chat from SERVER to IRC.";
            this.xIRCBotForwardFromServer.UseVisualStyleBackColor = true;
            // 
            // gIRCNetwork
            // 
            this.gIRCNetwork.Controls.Add(this.lIRCDelayUnits);
            this.gIRCNetwork.Controls.Add(this.xIRCRegisteredNick);
            this.gIRCNetwork.Controls.Add(this.tIRCNickServMessage);
            this.gIRCNetwork.Controls.Add(this.lIRCNickServMessage);
            this.gIRCNetwork.Controls.Add(this.tIRCNickServ);
            this.gIRCNetwork.Controls.Add(this.lIRCNickServ);
            this.gIRCNetwork.Controls.Add(this.nIRCDelay);
            this.gIRCNetwork.Controls.Add(this.lIRCDelay);
            this.gIRCNetwork.Controls.Add(this.lIRCBotChannels2);
            this.gIRCNetwork.Controls.Add(this.lIRCBotChannels3);
            this.gIRCNetwork.Controls.Add(this.tIRCBotChannels);
            this.gIRCNetwork.Controls.Add(this.lIRCBotChannels);
            this.gIRCNetwork.Controls.Add(this.nIRCBotPort);
            this.gIRCNetwork.Controls.Add(this.lIRCBotPort);
            this.gIRCNetwork.Controls.Add(this.tIRCBotNetwork);
            this.gIRCNetwork.Controls.Add(this.lIRCBotNetwork);
            this.gIRCNetwork.Controls.Add(this.lIRCBotNick);
            this.gIRCNetwork.Controls.Add(this.tIRCBotNick);
            this.gIRCNetwork.Location = new System.Drawing.Point(15, 130);
            this.gIRCNetwork.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gIRCNetwork.Name = "gIRCNetwork";
            this.gIRCNetwork.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gIRCNetwork.Size = new System.Drawing.Size(954, 246);
            this.gIRCNetwork.TabIndex = 11;
            this.gIRCNetwork.TabStop = false;
            this.gIRCNetwork.Text = "Network";
            // 
            // lIRCDelayUnits
            // 
            this.lIRCDelayUnits.AutoSize = true;
            this.lIRCDelayUnits.Location = new System.Drawing.Point(897, 34);
            this.lIRCDelayUnits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lIRCDelayUnits.Name = "lIRCDelayUnits";
            this.lIRCDelayUnits.Size = new System.Drawing.Size(30, 20);
            this.lIRCDelayUnits.TabIndex = 6;
            this.lIRCDelayUnits.Text = "ms";
            // 
            // xIRCRegisteredNick
            // 
            this.xIRCRegisteredNick.AutoSize = true;
            this.xIRCRegisteredNick.Location = new System.Drawing.Point(398, 155);
            this.xIRCRegisteredNick.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xIRCRegisteredNick.Name = "xIRCRegisteredNick";
            this.xIRCRegisteredNick.Size = new System.Drawing.Size(113, 24);
            this.xIRCRegisteredNick.TabIndex = 13;
            this.xIRCRegisteredNick.Text = "Registered";
            this.xIRCRegisteredNick.UseVisualStyleBackColor = true;
            // 
            // tIRCNickServMessage
            // 
            this.tIRCNickServMessage.Enabled = false;
            this.tIRCNickServMessage.Location = new System.Drawing.Point(582, 194);
            this.tIRCNickServMessage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tIRCNickServMessage.Name = "tIRCNickServMessage";
            this.tIRCNickServMessage.Size = new System.Drawing.Size(349, 26);
            this.tIRCNickServMessage.TabIndex = 17;
            // 
            // lIRCNickServMessage
            // 
            this.lIRCNickServMessage.AutoSize = true;
            this.lIRCNickServMessage.Enabled = false;
            this.lIRCNickServMessage.Location = new System.Drawing.Point(398, 198);
            this.lIRCNickServMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lIRCNickServMessage.Name = "lIRCNickServMessage";
            this.lIRCNickServMessage.Size = new System.Drawing.Size(155, 20);
            this.lIRCNickServMessage.TabIndex = 16;
            this.lIRCNickServMessage.Text = "Authentication string";
            // 
            // tIRCNickServ
            // 
            this.tIRCNickServ.Enabled = false;
            this.tIRCNickServ.Location = new System.Drawing.Point(182, 194);
            this.tIRCNickServ.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tIRCNickServ.MaxLength = 32;
            this.tIRCNickServ.Name = "tIRCNickServ";
            this.tIRCNickServ.Size = new System.Drawing.Size(205, 26);
            this.tIRCNickServ.TabIndex = 15;
            // 
            // lIRCNickServ
            // 
            this.lIRCNickServ.AutoSize = true;
            this.lIRCNickServ.Enabled = false;
            this.lIRCNickServ.Location = new System.Drawing.Point(52, 198);
            this.lIRCNickServ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lIRCNickServ.Name = "lIRCNickServ";
            this.lIRCNickServ.Size = new System.Drawing.Size(103, 20);
            this.lIRCNickServ.TabIndex = 14;
            this.lIRCNickServ.Text = "NickServ nick";
            // 
            // nIRCDelay
            // 
            this.nIRCDelay.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nIRCDelay.Location = new System.Drawing.Point(804, 31);
            this.nIRCDelay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nIRCDelay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nIRCDelay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nIRCDelay.Name = "nIRCDelay";
            this.nIRCDelay.Size = new System.Drawing.Size(84, 26);
            this.nIRCDelay.TabIndex = 5;
            this.nIRCDelay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lIRCDelay
            // 
            this.lIRCDelay.AutoSize = true;
            this.lIRCDelay.Location = new System.Drawing.Point(624, 34);
            this.lIRCDelay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lIRCDelay.Name = "lIRCDelay";
            this.lIRCDelay.Size = new System.Drawing.Size(144, 20);
            this.lIRCDelay.TabIndex = 4;
            this.lIRCDelay.Text = "Min message delay";
            // 
            // lIRCBotChannels2
            // 
            this.lIRCBotChannels2.AutoSize = true;
            this.lIRCBotChannels2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lIRCBotChannels2.Location = new System.Drawing.Point(22, 100);
            this.lIRCBotChannels2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lIRCBotChannels2.Name = "lIRCBotChannels2";
            this.lIRCBotChannels2.Size = new System.Drawing.Size(147, 20);
            this.lIRCBotChannels2.TabIndex = 9;
            this.lIRCBotChannels2.Text = "(comma seperated)";
            // 
            // lIRCBotChannels3
            // 
            this.lIRCBotChannels3.AutoSize = true;
            this.lIRCBotChannels3.Location = new System.Drawing.Point(177, 109);
            this.lIRCBotChannels3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lIRCBotChannels3.Name = "lIRCBotChannels3";
            this.lIRCBotChannels3.Size = new System.Drawing.Size(439, 20);
            this.lIRCBotChannels3.TabIndex = 10;
            this.lIRCBotChannels3.Text = "NOTE: Channel names are case-sensitive on some networks!";
            // 
            // tIRCBotChannels
            // 
            this.tIRCBotChannels.Location = new System.Drawing.Point(182, 72);
            this.tIRCBotChannels.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tIRCBotChannels.MaxLength = 1000;
            this.tIRCBotChannels.Name = "tIRCBotChannels";
            this.tIRCBotChannels.Size = new System.Drawing.Size(750, 26);
            this.tIRCBotChannels.TabIndex = 8;
            // 
            // lIRCBotChannels
            // 
            this.lIRCBotChannels.AutoSize = true;
            this.lIRCBotChannels.Location = new System.Drawing.Point(30, 77);
            this.lIRCBotChannels.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lIRCBotChannels.Name = "lIRCBotChannels";
            this.lIRCBotChannels.Size = new System.Drawing.Size(122, 20);
            this.lIRCBotChannels.TabIndex = 7;
            this.lIRCBotChannels.Text = "Channels to join";
            // 
            // nIRCBotPort
            // 
            this.nIRCBotPort.Location = new System.Drawing.Point(450, 31);
            this.nIRCBotPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nIRCBotPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nIRCBotPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nIRCBotPort.Name = "nIRCBotPort";
            this.nIRCBotPort.Size = new System.Drawing.Size(96, 26);
            this.nIRCBotPort.TabIndex = 3;
            this.nIRCBotPort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lIRCBotPort
            // 
            this.lIRCBotPort.AutoSize = true;
            this.lIRCBotPort.Location = new System.Drawing.Point(398, 34);
            this.lIRCBotPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lIRCBotPort.Name = "lIRCBotPort";
            this.lIRCBotPort.Size = new System.Drawing.Size(38, 20);
            this.lIRCBotPort.TabIndex = 2;
            this.lIRCBotPort.Text = "Port";
            // 
            // tIRCBotNetwork
            // 
            this.tIRCBotNetwork.Location = new System.Drawing.Point(182, 29);
            this.tIRCBotNetwork.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tIRCBotNetwork.MaxLength = 512;
            this.tIRCBotNetwork.Name = "tIRCBotNetwork";
            this.tIRCBotNetwork.Size = new System.Drawing.Size(205, 26);
            this.tIRCBotNetwork.TabIndex = 1;
            // 
            // lIRCBotNetwork
            // 
            this.lIRCBotNetwork.AutoSize = true;
            this.lIRCBotNetwork.Location = new System.Drawing.Point(39, 34);
            this.lIRCBotNetwork.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lIRCBotNetwork.Name = "lIRCBotNetwork";
            this.lIRCBotNetwork.Size = new System.Drawing.Size(125, 20);
            this.lIRCBotNetwork.TabIndex = 0;
            this.lIRCBotNetwork.Text = "IRC Server Host";
            // 
            // lIRCBotNick
            // 
            this.lIRCBotNick.AutoSize = true;
            this.lIRCBotNick.Location = new System.Drawing.Point(98, 157);
            this.lIRCBotNick.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lIRCBotNick.Name = "lIRCBotNick";
            this.lIRCBotNick.Size = new System.Drawing.Size(66, 20);
            this.lIRCBotNick.TabIndex = 11;
            this.lIRCBotNick.Text = "Bot nick";
            // 
            // tIRCBotNick
            // 
            this.tIRCBotNick.Location = new System.Drawing.Point(182, 152);
            this.tIRCBotNick.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tIRCBotNick.MaxLength = 32;
            this.tIRCBotNick.Name = "tIRCBotNick";
            this.tIRCBotNick.Size = new System.Drawing.Size(205, 26);
            this.tIRCBotNick.TabIndex = 12;
            // 
            // lIRCList
            // 
            this.lIRCList.AutoSize = true;
            this.lIRCList.Enabled = false;
            this.lIRCList.Location = new System.Drawing.Point(316, 96);
            this.lIRCList.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lIRCList.Name = "lIRCList";
            this.lIRCList.Size = new System.Drawing.Size(135, 20);
            this.lIRCList.TabIndex = 8;
            this.lIRCList.Text = "Popular networks:";
            // 
            // xIRCBotEnabled
            // 
            this.xIRCBotEnabled.AutoSize = true;
            this.xIRCBotEnabled.Location = new System.Drawing.Point(24, 96);
            this.xIRCBotEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xIRCBotEnabled.Name = "xIRCBotEnabled";
            this.xIRCBotEnabled.Size = new System.Drawing.Size(196, 24);
            this.xIRCBotEnabled.TabIndex = 7;
            this.xIRCBotEnabled.Text = "Enable IRC integration";
            this.xIRCBotEnabled.UseVisualStyleBackColor = true;
            // 
            // cIRCList
            // 
            this.cIRCList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cIRCList.Enabled = false;
            this.cIRCList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cIRCList.FormattingEnabled = true;
            this.cIRCList.Location = new System.Drawing.Point(456, 92);
            this.cIRCList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cIRCList.Name = "cIRCList";
            this.cIRCList.Size = new System.Drawing.Size(205, 28);
            this.cIRCList.TabIndex = 9;
            // 
            // bResetTab
            // 
            this.bResetTab.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.bResetTab.Location = new System.Drawing.Point(827, 752);
            this.bResetTab.Name = "bResetTab";
            this.bResetTab.Size = new System.Drawing.Size(142, 37);
            this.bResetTab.TabIndex = 14;
            this.bResetTab.Text = "Reset";
            this.bResetTab.UseSelectable = true;
            // 
            // IRCConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 799);
            this.Controls.Add(this.bResetTab);
            this.Controls.Add(this.gIRCAdv);
            this.Controls.Add(this.xIRCListShowNonEnglish);
            this.Controls.Add(this.gIRCOptions);
            this.Controls.Add(this.gIRCNetwork);
            this.Controls.Add(this.lIRCList);
            this.Controls.Add(this.xIRCBotEnabled);
            this.Controls.Add(this.cIRCList);
            this.Name = "IRCConfig";
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "GemsCraft Configuration - IRC";
            this.gIRCAdv.ResumeLayout(false);
            this.gIRCAdv.PerformLayout();
            this.gIRCOptions.ResumeLayout(false);
            this.gIRCOptions.PerformLayout();
            this.gIRCNetwork.ResumeLayout(false);
            this.gIRCNetwork.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nIRCDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nIRCBotPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox gIRCAdv;
        internal System.Windows.Forms.TextBox tServPass;
        internal System.Windows.Forms.CheckBox xServPass;
        internal System.Windows.Forms.TextBox tChanPass;
        internal System.Windows.Forms.CheckBox xChanPass;
        internal System.Windows.Forms.CheckBox xIRCListShowNonEnglish;
        internal System.Windows.Forms.GroupBox gIRCOptions;
        internal System.Windows.Forms.CheckBox xIRCBotAnnounceServerEvents;
        internal System.Windows.Forms.CheckBox xIRCUseColor;
        internal System.Windows.Forms.Label lIRCNoForwardingMessage;
        internal System.Windows.Forms.CheckBox xIRCBotAnnounceIRCJoins;
        internal System.Windows.Forms.Button bColorIRC;
        internal System.Windows.Forms.Label lColorIRC;
        internal System.Windows.Forms.CheckBox xIRCBotForwardFromIRC;
        internal System.Windows.Forms.CheckBox xIRCBotAnnounceServerJoins;
        internal System.Windows.Forms.CheckBox xIRCBotForwardFromServer;
        internal System.Windows.Forms.GroupBox gIRCNetwork;
        internal System.Windows.Forms.Label lIRCDelayUnits;
        internal System.Windows.Forms.CheckBox xIRCRegisteredNick;
        internal System.Windows.Forms.TextBox tIRCNickServMessage;
        internal System.Windows.Forms.Label lIRCNickServMessage;
        internal System.Windows.Forms.TextBox tIRCNickServ;
        internal System.Windows.Forms.Label lIRCNickServ;
        internal System.Windows.Forms.NumericUpDown nIRCDelay;
        internal System.Windows.Forms.Label lIRCDelay;
        internal System.Windows.Forms.Label lIRCBotChannels2;
        internal System.Windows.Forms.Label lIRCBotChannels3;
        internal System.Windows.Forms.TextBox tIRCBotChannels;
        internal System.Windows.Forms.Label lIRCBotChannels;
        internal System.Windows.Forms.NumericUpDown nIRCBotPort;
        internal System.Windows.Forms.Label lIRCBotPort;
        internal System.Windows.Forms.TextBox tIRCBotNetwork;
        internal System.Windows.Forms.Label lIRCBotNetwork;
        internal System.Windows.Forms.Label lIRCBotNick;
        internal System.Windows.Forms.TextBox tIRCBotNick;
        internal System.Windows.Forms.Label lIRCList;
        internal System.Windows.Forms.CheckBox xIRCBotEnabled;
        internal System.Windows.Forms.ComboBox cIRCList;
        internal MetroFramework.Controls.MetroButton bResetTab;
    }
}