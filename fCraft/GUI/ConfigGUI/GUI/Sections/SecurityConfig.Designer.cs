namespace fCraft.GUI.ConfigGUI.GUI.Sections
{
    partial class SecurityConfig
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
            this.gBlockDB = new System.Windows.Forms.GroupBox();
            this.cBlockDBAutoEnableRank = new System.Windows.Forms.ComboBox();
            this.xBlockDBAutoEnable = new System.Windows.Forms.CheckBox();
            this.xBlockDBEnabled = new System.Windows.Forms.CheckBox();
            this.gSecurityMisc = new System.Windows.Forms.GroupBox();
            this.xAnnounceRankChangeReasons = new System.Windows.Forms.CheckBox();
            this.xRequireKickReason = new System.Windows.Forms.CheckBox();
            this.lPatrolledRankAndBelow = new System.Windows.Forms.Label();
            this.cPatrolledRank = new System.Windows.Forms.ComboBox();
            this.lPatrolledRank = new System.Windows.Forms.Label();
            this.xAnnounceRankChanges = new System.Windows.Forms.CheckBox();
            this.xAnnounceKickAndBanReasons = new System.Windows.Forms.CheckBox();
            this.xRequireRankChangeReason = new System.Windows.Forms.CheckBox();
            this.xRequireBanReason = new System.Windows.Forms.CheckBox();
            this.gSpamChat = new System.Windows.Forms.GroupBox();
            this.lAntispamMaxWarnings = new System.Windows.Forms.Label();
            this.nAntispamMaxWarnings = new System.Windows.Forms.NumericUpDown();
            this.xAntispamKicks = new System.Windows.Forms.CheckBox();
            this.lSpamMuteSeconds = new System.Windows.Forms.Label();
            this.lAntispamInterval = new System.Windows.Forms.Label();
            this.nSpamMute = new System.Windows.Forms.NumericUpDown();
            this.lSpamMute = new System.Windows.Forms.Label();
            this.nAntispamInterval = new System.Windows.Forms.NumericUpDown();
            this.lAntispamMessageCount = new System.Windows.Forms.Label();
            this.nAntispamMessageCount = new System.Windows.Forms.NumericUpDown();
            this.lSpamChat = new System.Windows.Forms.Label();
            this.gVerify = new System.Windows.Forms.GroupBox();
            this.nMaxConnectionsPerIP = new System.Windows.Forms.NumericUpDown();
            this.xAllowUnverifiedLAN = new System.Windows.Forms.CheckBox();
            this.xMaxConnectionsPerIP = new System.Windows.Forms.CheckBox();
            this.lVerifyNames = new System.Windows.Forms.Label();
            this.cVerifyNames = new System.Windows.Forms.ComboBox();
            this.bResetTab = new MetroFramework.Controls.MetroButton();
            this.gBlockDB.SuspendLayout();
            this.gSecurityMisc.SuspendLayout();
            this.gSpamChat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nAntispamMaxWarnings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSpamMute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nAntispamInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nAntispamMessageCount)).BeginInit();
            this.gVerify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxConnectionsPerIP)).BeginInit();
            this.SuspendLayout();
            // 
            // gBlockDB
            // 
            this.gBlockDB.Controls.Add(this.cBlockDBAutoEnableRank);
            this.gBlockDB.Controls.Add(this.xBlockDBAutoEnable);
            this.gBlockDB.Controls.Add(this.xBlockDBEnabled);
            this.gBlockDB.Location = new System.Drawing.Point(26, 231);
            this.gBlockDB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gBlockDB.Name = "gBlockDB";
            this.gBlockDB.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gBlockDB.Size = new System.Drawing.Size(954, 135);
            this.gBlockDB.TabIndex = 5;
            this.gBlockDB.TabStop = false;
            this.gBlockDB.Text = "BlockDB";
            // 
            // cBlockDBAutoEnableRank
            // 
            this.cBlockDBAutoEnableRank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBlockDBAutoEnableRank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cBlockDBAutoEnableRank.FormattingEnabled = true;
            this.cBlockDBAutoEnableRank.Location = new System.Drawing.Point(612, 85);
            this.cBlockDBAutoEnableRank.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cBlockDBAutoEnableRank.Name = "cBlockDBAutoEnableRank";
            this.cBlockDBAutoEnableRank.Size = new System.Drawing.Size(180, 28);
            this.cBlockDBAutoEnableRank.TabIndex = 2;
            this.cBlockDBAutoEnableRank.TabStop = false;
            // 
            // xBlockDBAutoEnable
            // 
            this.xBlockDBAutoEnable.AutoSize = true;
            this.xBlockDBAutoEnable.Enabled = false;
            this.xBlockDBAutoEnable.Location = new System.Drawing.Point(63, 85);
            this.xBlockDBAutoEnable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xBlockDBAutoEnable.Name = "xBlockDBAutoEnable";
            this.xBlockDBAutoEnable.Size = new System.Drawing.Size(470, 24);
            this.xBlockDBAutoEnable.TabIndex = 1;
            this.xBlockDBAutoEnable.TabStop = false;
            this.xBlockDBAutoEnable.Text = "Automatically enable BlockDB on worlds that can be edited by";
            this.xBlockDBAutoEnable.UseVisualStyleBackColor = true;
            // 
            // xBlockDBEnabled
            // 
            this.xBlockDBEnabled.AutoSize = true;
            this.xBlockDBEnabled.Location = new System.Drawing.Point(63, 46);
            this.xBlockDBEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xBlockDBEnabled.Name = "xBlockDBEnabled";
            this.xBlockDBEnabled.Size = new System.Drawing.Size(324, 24);
            this.xBlockDBEnabled.TabIndex = 0;
            this.xBlockDBEnabled.Text = "Enable BlockDB (per-block edit tracking).";
            this.xBlockDBEnabled.UseVisualStyleBackColor = true;
            // 
            // gSecurityMisc
            // 
            this.gSecurityMisc.Controls.Add(this.xAnnounceRankChangeReasons);
            this.gSecurityMisc.Controls.Add(this.xRequireKickReason);
            this.gSecurityMisc.Controls.Add(this.lPatrolledRankAndBelow);
            this.gSecurityMisc.Controls.Add(this.cPatrolledRank);
            this.gSecurityMisc.Controls.Add(this.lPatrolledRank);
            this.gSecurityMisc.Controls.Add(this.xAnnounceRankChanges);
            this.gSecurityMisc.Controls.Add(this.xAnnounceKickAndBanReasons);
            this.gSecurityMisc.Controls.Add(this.xRequireRankChangeReason);
            this.gSecurityMisc.Controls.Add(this.xRequireBanReason);
            this.gSecurityMisc.Location = new System.Drawing.Point(26, 531);
            this.gSecurityMisc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gSecurityMisc.Name = "gSecurityMisc";
            this.gSecurityMisc.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gSecurityMisc.Size = new System.Drawing.Size(954, 274);
            this.gSecurityMisc.TabIndex = 7;
            this.gSecurityMisc.TabStop = false;
            this.gSecurityMisc.Text = "Misc";
            // 
            // xAnnounceRankChangeReasons
            // 
            this.xAnnounceRankChangeReasons.AutoSize = true;
            this.xAnnounceRankChangeReasons.Location = new System.Drawing.Point(456, 168);
            this.xAnnounceRankChangeReasons.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xAnnounceRankChangeReasons.Name = "xAnnounceRankChangeReasons";
            this.xAnnounceRankChangeReasons.Size = new System.Drawing.Size(329, 24);
            this.xAnnounceRankChangeReasons.TabIndex = 6;
            this.xAnnounceRankChangeReasons.Text = "Announce promotion && demotion reasons";
            this.xAnnounceRankChangeReasons.UseVisualStyleBackColor = true;
            // 
            // xRequireKickReason
            // 
            this.xRequireKickReason.AutoSize = true;
            this.xRequireKickReason.Location = new System.Drawing.Point(63, 91);
            this.xRequireKickReason.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xRequireKickReason.Name = "xRequireKickReason";
            this.xRequireKickReason.Size = new System.Drawing.Size(175, 24);
            this.xRequireKickReason.TabIndex = 1;
            this.xRequireKickReason.Text = "Require kick reason";
            this.xRequireKickReason.UseVisualStyleBackColor = true;
            // 
            // lPatrolledRankAndBelow
            // 
            this.lPatrolledRankAndBelow.AutoSize = true;
            this.lPatrolledRankAndBelow.Location = new System.Drawing.Point(386, 220);
            this.lPatrolledRankAndBelow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lPatrolledRankAndBelow.Name = "lPatrolledRankAndBelow";
            this.lPatrolledRankAndBelow.Size = new System.Drawing.Size(91, 20);
            this.lPatrolledRankAndBelow.TabIndex = 9;
            this.lPatrolledRankAndBelow.Text = "(and below)";
            // 
            // cPatrolledRank
            // 
            this.cPatrolledRank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cPatrolledRank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cPatrolledRank.FormattingEnabled = true;
            this.cPatrolledRank.Location = new System.Drawing.Point(192, 215);
            this.cPatrolledRank.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cPatrolledRank.Name = "cPatrolledRank";
            this.cPatrolledRank.Size = new System.Drawing.Size(182, 28);
            this.cPatrolledRank.TabIndex = 8;
            // 
            // lPatrolledRank
            // 
            this.lPatrolledRank.AutoSize = true;
            this.lPatrolledRank.Location = new System.Drawing.Point(58, 220);
            this.lPatrolledRank.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lPatrolledRank.Name = "lPatrolledRank";
            this.lPatrolledRank.Size = new System.Drawing.Size(106, 20);
            this.lPatrolledRank.TabIndex = 7;
            this.lPatrolledRank.Text = "Patrolled rank";
            // 
            // xAnnounceRankChanges
            // 
            this.xAnnounceRankChanges.AutoSize = true;
            this.xAnnounceRankChanges.Location = new System.Drawing.Point(456, 129);
            this.xAnnounceRankChanges.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xAnnounceRankChanges.Name = "xAnnounceRankChanges";
            this.xAnnounceRankChanges.Size = new System.Drawing.Size(300, 24);
            this.xAnnounceRankChanges.TabIndex = 5;
            this.xAnnounceRankChanges.Text = "Announce promotions and demotions";
            this.xAnnounceRankChanges.UseVisualStyleBackColor = true;
            // 
            // xAnnounceKickAndBanReasons
            // 
            this.xAnnounceKickAndBanReasons.AutoSize = true;
            this.xAnnounceKickAndBanReasons.Location = new System.Drawing.Point(456, 91);
            this.xAnnounceKickAndBanReasons.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xAnnounceKickAndBanReasons.Name = "xAnnounceKickAndBanReasons";
            this.xAnnounceKickAndBanReasons.Size = new System.Drawing.Size(319, 24);
            this.xAnnounceKickAndBanReasons.TabIndex = 4;
            this.xAnnounceKickAndBanReasons.Text = "Announce kick, ban, and unban reasons";
            this.xAnnounceKickAndBanReasons.UseVisualStyleBackColor = true;
            // 
            // xRequireRankChangeReason
            // 
            this.xRequireRankChangeReason.AutoSize = true;
            this.xRequireRankChangeReason.Location = new System.Drawing.Point(63, 168);
            this.xRequireRankChangeReason.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xRequireRankChangeReason.Name = "xRequireRankChangeReason";
            this.xRequireRankChangeReason.Size = new System.Drawing.Size(304, 24);
            this.xRequireRankChangeReason.TabIndex = 3;
            this.xRequireRankChangeReason.Text = "Require promotion && demotion reason";
            this.xRequireRankChangeReason.UseVisualStyleBackColor = true;
            // 
            // xRequireBanReason
            // 
            this.xRequireBanReason.AutoSize = true;
            this.xRequireBanReason.Location = new System.Drawing.Point(63, 129);
            this.xRequireBanReason.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xRequireBanReason.Name = "xRequireBanReason";
            this.xRequireBanReason.Size = new System.Drawing.Size(239, 24);
            this.xRequireBanReason.TabIndex = 2;
            this.xRequireBanReason.Text = "Require ban && unban reason";
            this.xRequireBanReason.UseVisualStyleBackColor = true;
            // 
            // gSpamChat
            // 
            this.gSpamChat.Controls.Add(this.lAntispamMaxWarnings);
            this.gSpamChat.Controls.Add(this.nAntispamMaxWarnings);
            this.gSpamChat.Controls.Add(this.xAntispamKicks);
            this.gSpamChat.Controls.Add(this.lSpamMuteSeconds);
            this.gSpamChat.Controls.Add(this.lAntispamInterval);
            this.gSpamChat.Controls.Add(this.nSpamMute);
            this.gSpamChat.Controls.Add(this.lSpamMute);
            this.gSpamChat.Controls.Add(this.nAntispamInterval);
            this.gSpamChat.Controls.Add(this.lAntispamMessageCount);
            this.gSpamChat.Controls.Add(this.nAntispamMessageCount);
            this.gSpamChat.Controls.Add(this.lSpamChat);
            this.gSpamChat.Location = new System.Drawing.Point(26, 376);
            this.gSpamChat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gSpamChat.Name = "gSpamChat";
            this.gSpamChat.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gSpamChat.Size = new System.Drawing.Size(954, 145);
            this.gSpamChat.TabIndex = 6;
            this.gSpamChat.TabStop = false;
            this.gSpamChat.Text = "Chat Spam Prevention";
            // 
            // lAntispamMaxWarnings
            // 
            this.lAntispamMaxWarnings.AutoSize = true;
            this.lAntispamMaxWarnings.Location = new System.Drawing.Point(681, 95);
            this.lAntispamMaxWarnings.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lAntispamMaxWarnings.Name = "lAntispamMaxWarnings";
            this.lAntispamMaxWarnings.Size = new System.Drawing.Size(72, 20);
            this.lAntispamMaxWarnings.TabIndex = 10;
            this.lAntispamMaxWarnings.Text = "warnings";
            // 
            // nAntispamMaxWarnings
            // 
            this.nAntispamMaxWarnings.Location = new System.Drawing.Point(579, 92);
            this.nAntispamMaxWarnings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nAntispamMaxWarnings.Name = "nAntispamMaxWarnings";
            this.nAntispamMaxWarnings.Size = new System.Drawing.Size(93, 26);
            this.nAntispamMaxWarnings.TabIndex = 9;
            // 
            // xAntispamKicks
            // 
            this.xAntispamKicks.AutoSize = true;
            this.xAntispamKicks.Location = new System.Drawing.Point(456, 94);
            this.xAntispamKicks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xAntispamKicks.Name = "xAntispamKicks";
            this.xAntispamKicks.Size = new System.Drawing.Size(101, 24);
            this.xAntispamKicks.TabIndex = 8;
            this.xAntispamKicks.Text = "Kick after";
            this.xAntispamKicks.UseVisualStyleBackColor = true;
            // 
            // lSpamMuteSeconds
            // 
            this.lSpamMuteSeconds.AutoSize = true;
            this.lSpamMuteSeconds.Location = new System.Drawing.Point(332, 95);
            this.lSpamMuteSeconds.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lSpamMuteSeconds.Name = "lSpamMuteSeconds";
            this.lSpamMuteSeconds.Size = new System.Drawing.Size(69, 20);
            this.lSpamMuteSeconds.TabIndex = 7;
            this.lSpamMuteSeconds.Text = "seconds";
            // 
            // lAntispamInterval
            // 
            this.lAntispamInterval.AutoSize = true;
            this.lAntispamInterval.Location = new System.Drawing.Point(558, 42);
            this.lAntispamInterval.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lAntispamInterval.Name = "lAntispamInterval";
            this.lAntispamInterval.Size = new System.Drawing.Size(69, 20);
            this.lAntispamInterval.TabIndex = 4;
            this.lAntispamInterval.Text = "seconds";
            // 
            // nSpamMute
            // 
            this.nSpamMute.Location = new System.Drawing.Point(230, 91);
            this.nSpamMute.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nSpamMute.Name = "nSpamMute";
            this.nSpamMute.Size = new System.Drawing.Size(93, 26);
            this.nSpamMute.TabIndex = 6;
            // 
            // lSpamMute
            // 
            this.lSpamMute.AutoSize = true;
            this.lSpamMute.Location = new System.Drawing.Point(58, 95);
            this.lSpamMute.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lSpamMute.Name = "lSpamMute";
            this.lSpamMute.Size = new System.Drawing.Size(138, 20);
            this.lSpamMute.TabIndex = 5;
            this.lSpamMute.Text = "Mute spammer for";
            // 
            // nAntispamInterval
            // 
            this.nAntispamInterval.Location = new System.Drawing.Point(456, 38);
            this.nAntispamInterval.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nAntispamInterval.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nAntispamInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nAntispamInterval.Name = "nAntispamInterval";
            this.nAntispamInterval.Size = new System.Drawing.Size(93, 26);
            this.nAntispamInterval.TabIndex = 3;
            this.nAntispamInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lAntispamMessageCount
            // 
            this.lAntispamMessageCount.AutoSize = true;
            this.lAntispamMessageCount.Location = new System.Drawing.Point(328, 42);
            this.lAntispamMessageCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lAntispamMessageCount.Name = "lAntispamMessageCount";
            this.lAntispamMessageCount.Size = new System.Drawing.Size(98, 20);
            this.lAntispamMessageCount.TabIndex = 2;
            this.lAntispamMessageCount.Text = "messages in";
            // 
            // nAntispamMessageCount
            // 
            this.nAntispamMessageCount.Location = new System.Drawing.Point(230, 38);
            this.nAntispamMessageCount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nAntispamMessageCount.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nAntispamMessageCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nAntispamMessageCount.Name = "nAntispamMessageCount";
            this.nAntispamMessageCount.Size = new System.Drawing.Size(93, 26);
            this.nAntispamMessageCount.TabIndex = 1;
            this.nAntispamMessageCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lSpamChat
            // 
            this.lSpamChat.AutoSize = true;
            this.lSpamChat.Location = new System.Drawing.Point(58, 48);
            this.lSpamChat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lSpamChat.Name = "lSpamChat";
            this.lSpamChat.Size = new System.Drawing.Size(127, 20);
            this.lSpamChat.TabIndex = 0;
            this.lSpamChat.Text = "Limit chat rate to";
            // 
            // gVerify
            // 
            this.gVerify.BackColor = System.Drawing.Color.Transparent;
            this.gVerify.Controls.Add(this.nMaxConnectionsPerIP);
            this.gVerify.Controls.Add(this.xAllowUnverifiedLAN);
            this.gVerify.Controls.Add(this.xMaxConnectionsPerIP);
            this.gVerify.Controls.Add(this.lVerifyNames);
            this.gVerify.Controls.Add(this.cVerifyNames);
            this.gVerify.Location = new System.Drawing.Point(26, 96);
            this.gVerify.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gVerify.Name = "gVerify";
            this.gVerify.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gVerify.Size = new System.Drawing.Size(954, 125);
            this.gVerify.TabIndex = 4;
            this.gVerify.TabStop = false;
            this.gVerify.Text = "Connection";
            // 
            // nMaxConnectionsPerIP
            // 
            this.nMaxConnectionsPerIP.Location = new System.Drawing.Point(808, 32);
            this.nMaxConnectionsPerIP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nMaxConnectionsPerIP.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nMaxConnectionsPerIP.Name = "nMaxConnectionsPerIP";
            this.nMaxConnectionsPerIP.Size = new System.Drawing.Size(70, 26);
            this.nMaxConnectionsPerIP.TabIndex = 4;
            this.nMaxConnectionsPerIP.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // xAllowUnverifiedLAN
            // 
            this.xAllowUnverifiedLAN.AutoSize = true;
            this.xAllowUnverifiedLAN.Location = new System.Drawing.Point(63, 75);
            this.xAllowUnverifiedLAN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xAllowUnverifiedLAN.Name = "xAllowUnverifiedLAN";
            this.xAllowUnverifiedLAN.Size = new System.Drawing.Size(636, 24);
            this.xAllowUnverifiedLAN.TabIndex = 2;
            this.xAllowUnverifiedLAN.Text = "Allow connections from LAN without name verification (192.168.0.0/16 and 10.0.0.0" +
    "/8)";
            this.xAllowUnverifiedLAN.UseVisualStyleBackColor = true;
            // 
            // xMaxConnectionsPerIP
            // 
            this.xMaxConnectionsPerIP.AutoSize = true;
            this.xMaxConnectionsPerIP.Location = new System.Drawing.Point(456, 34);
            this.xMaxConnectionsPerIP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xMaxConnectionsPerIP.Name = "xMaxConnectionsPerIP";
            this.xMaxConnectionsPerIP.Size = new System.Drawing.Size(298, 24);
            this.xMaxConnectionsPerIP.TabIndex = 3;
            this.xMaxConnectionsPerIP.Text = "Limit number of connections per IP to";
            this.xMaxConnectionsPerIP.UseVisualStyleBackColor = true;
            // 
            // lVerifyNames
            // 
            this.lVerifyNames.AutoSize = true;
            this.lVerifyNames.Location = new System.Drawing.Point(68, 35);
            this.lVerifyNames.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lVerifyNames.Name = "lVerifyNames";
            this.lVerifyNames.Size = new System.Drawing.Size(130, 20);
            this.lVerifyNames.TabIndex = 0;
            this.lVerifyNames.Text = "Name verification";
            // 
            // cVerifyNames
            // 
            this.cVerifyNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cVerifyNames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cVerifyNames.FormattingEnabled = true;
            this.cVerifyNames.Items.AddRange(new object[] {
            "None (Unsafe)",
            "Normal",
            "Strict"});
            this.cVerifyNames.Location = new System.Drawing.Point(230, 31);
            this.cVerifyNames.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cVerifyNames.Name = "cVerifyNames";
            this.cVerifyNames.Size = new System.Drawing.Size(178, 28);
            this.cVerifyNames.TabIndex = 1;
            // 
            // bResetTab
            // 
            this.bResetTab.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.bResetTab.Location = new System.Drawing.Point(838, 813);
            this.bResetTab.Name = "bResetTab";
            this.bResetTab.Size = new System.Drawing.Size(142, 37);
            this.bResetTab.TabIndex = 8;
            this.bResetTab.Text = "Reset";
            this.bResetTab.UseSelectable = true;
            // 
            // SecurityConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 863);
            this.Controls.Add(this.bResetTab);
            this.Controls.Add(this.gBlockDB);
            this.Controls.Add(this.gSecurityMisc);
            this.Controls.Add(this.gSpamChat);
            this.Controls.Add(this.gVerify);
            this.Name = "SecurityConfig";
            this.Style = MetroFramework.MetroColorStyle.Brown;
            this.Text = "GemsCraft Configuration - Security";
            this.gBlockDB.ResumeLayout(false);
            this.gBlockDB.PerformLayout();
            this.gSecurityMisc.ResumeLayout(false);
            this.gSecurityMisc.PerformLayout();
            this.gSpamChat.ResumeLayout(false);
            this.gSpamChat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nAntispamMaxWarnings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSpamMute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nAntispamInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nAntispamMessageCount)).EndInit();
            this.gVerify.ResumeLayout(false);
            this.gVerify.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxConnectionsPerIP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox gBlockDB;
        internal System.Windows.Forms.ComboBox cBlockDBAutoEnableRank;
        internal System.Windows.Forms.CheckBox xBlockDBAutoEnable;
        internal System.Windows.Forms.CheckBox xBlockDBEnabled;
        internal System.Windows.Forms.GroupBox gSecurityMisc;
        internal System.Windows.Forms.CheckBox xAnnounceRankChangeReasons;
        internal System.Windows.Forms.CheckBox xRequireKickReason;
        internal System.Windows.Forms.Label lPatrolledRankAndBelow;
        internal System.Windows.Forms.ComboBox cPatrolledRank;
        internal System.Windows.Forms.Label lPatrolledRank;
        internal System.Windows.Forms.CheckBox xAnnounceRankChanges;
        internal System.Windows.Forms.CheckBox xAnnounceKickAndBanReasons;
        internal System.Windows.Forms.CheckBox xRequireRankChangeReason;
        internal System.Windows.Forms.CheckBox xRequireBanReason;
        internal System.Windows.Forms.GroupBox gSpamChat;
        internal System.Windows.Forms.Label lAntispamMaxWarnings;
        internal System.Windows.Forms.NumericUpDown nAntispamMaxWarnings;
        internal System.Windows.Forms.CheckBox xAntispamKicks;
        internal System.Windows.Forms.Label lSpamMuteSeconds;
        internal System.Windows.Forms.Label lAntispamInterval;
        internal System.Windows.Forms.NumericUpDown nSpamMute;
        internal System.Windows.Forms.Label lSpamMute;
        internal System.Windows.Forms.NumericUpDown nAntispamInterval;
        internal System.Windows.Forms.Label lAntispamMessageCount;
        internal System.Windows.Forms.NumericUpDown nAntispamMessageCount;
        internal System.Windows.Forms.Label lSpamChat;
        internal System.Windows.Forms.GroupBox gVerify;
        internal System.Windows.Forms.NumericUpDown nMaxConnectionsPerIP;
        internal System.Windows.Forms.CheckBox xAllowUnverifiedLAN;
        internal System.Windows.Forms.CheckBox xMaxConnectionsPerIP;
        internal System.Windows.Forms.Label lVerifyNames;
        internal System.Windows.Forms.ComboBox cVerifyNames;
        internal MetroFramework.Controls.MetroButton bResetTab;
    }
}