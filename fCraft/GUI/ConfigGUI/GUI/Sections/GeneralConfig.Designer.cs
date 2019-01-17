namespace GemsCraft.GUI.ConfigGUI.GUI.Sections
{
    partial class GeneralConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralConfig));
            this.gBasic = new System.Windows.Forms.GroupBox();
            this.nMaxPlayersPerWorld = new System.Windows.Forms.NumericUpDown();
            this.lMaxPlayersPerWorld = new System.Windows.Forms.Label();
            this.lPort = new System.Windows.Forms.Label();
            this.nPort = new System.Windows.Forms.NumericUpDown();
            this.cDefaultRank = new System.Windows.Forms.ComboBox();
            this.lDefaultRank = new System.Windows.Forms.Label();
            this.lUploadBandwidth = new System.Windows.Forms.Label();
            this.bMeasure = new System.Windows.Forms.Button();
            this.tServerName = new System.Windows.Forms.TextBox();
            this.lUploadBandwidthUnits = new System.Windows.Forms.Label();
            this.lServerName = new System.Windows.Forms.Label();
            this.nUploadBandwidth = new System.Windows.Forms.NumericUpDown();
            this.tMOTD = new System.Windows.Forms.TextBox();
            this.lMOTD = new System.Windows.Forms.Label();
            this.cPublic = new System.Windows.Forms.ComboBox();
            this.nMaxPlayers = new System.Windows.Forms.NumericUpDown();
            this.lPublic = new System.Windows.Forms.Label();
            this.lMaxPlayers = new System.Windows.Forms.Label();
            this.gInformation = new System.Windows.Forms.GroupBox();
            this.bGreeting = new System.Windows.Forms.Button();
            this.lAnnouncementsUnits = new System.Windows.Forms.Label();
            this.nAnnouncements = new System.Windows.Forms.NumericUpDown();
            this.xAnnouncements = new System.Windows.Forms.CheckBox();
            this.bRules = new System.Windows.Forms.Button();
            this.bAnnouncements = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bChangelog = new System.Windows.Forms.Button();
            this.bCredits = new System.Windows.Forms.Button();
            this.bReadme = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.bWiki = new System.Windows.Forms.Button();
            this.bWeb = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.bResetTab = new MetroFramework.Controls.MetroButton();
            this.gBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxPlayersPerWorld)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUploadBandwidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxPlayers)).BeginInit();
            this.gInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nAnnouncements)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // gBasic
            // 
            this.gBasic.Controls.Add(this.nMaxPlayersPerWorld);
            this.gBasic.Controls.Add(this.lMaxPlayersPerWorld);
            this.gBasic.Controls.Add(this.lPort);
            this.gBasic.Controls.Add(this.nPort);
            this.gBasic.Controls.Add(this.cDefaultRank);
            this.gBasic.Controls.Add(this.lDefaultRank);
            this.gBasic.Controls.Add(this.lUploadBandwidth);
            this.gBasic.Controls.Add(this.bMeasure);
            this.gBasic.Controls.Add(this.tServerName);
            this.gBasic.Controls.Add(this.lUploadBandwidthUnits);
            this.gBasic.Controls.Add(this.lServerName);
            this.gBasic.Controls.Add(this.nUploadBandwidth);
            this.gBasic.Controls.Add(this.tMOTD);
            this.gBasic.Controls.Add(this.lMOTD);
            this.gBasic.Controls.Add(this.cPublic);
            this.gBasic.Controls.Add(this.nMaxPlayers);
            this.gBasic.Controls.Add(this.lPublic);
            this.gBasic.Controls.Add(this.lMaxPlayers);
            this.gBasic.Location = new System.Drawing.Point(16, 62);
            this.gBasic.Name = "gBasic";
            this.gBasic.Size = new System.Drawing.Size(636, 190);
            this.gBasic.TabIndex = 1;
            this.gBasic.TabStop = false;
            this.gBasic.Text = "Basic Settings";
            // 
            // nMaxPlayersPerWorld
            // 
            this.nMaxPlayersPerWorld.Location = new System.Drawing.Point(440, 74);
            this.nMaxPlayersPerWorld.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.nMaxPlayersPerWorld.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nMaxPlayersPerWorld.Name = "nMaxPlayersPerWorld";
            this.nMaxPlayersPerWorld.Size = new System.Drawing.Size(75, 20);
            this.nMaxPlayersPerWorld.TabIndex = 12;
            this.nMaxPlayersPerWorld.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lMaxPlayersPerWorld
            // 
            this.lMaxPlayersPerWorld.AutoSize = true;
            this.lMaxPlayersPerWorld.Location = new System.Drawing.Point(299, 76);
            this.lMaxPlayersPerWorld.Name = "lMaxPlayersPerWorld";
            this.lMaxPlayersPerWorld.Size = new System.Drawing.Size(115, 13);
            this.lMaxPlayersPerWorld.TabIndex = 11;
            this.lMaxPlayersPerWorld.Text = "Max players (per world)";
            // 
            // lPort
            // 
            this.lPort.AutoSize = true;
            this.lPort.Location = new System.Drawing.Point(42, 103);
            this.lPort.Name = "lPort";
            this.lPort.Size = new System.Drawing.Size(64, 13);
            this.lPort.TabIndex = 6;
            this.lPort.Text = "Port number";
            // 
            // nPort
            // 
            this.nPort.Location = new System.Drawing.Point(123, 101);
            this.nPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nPort.Name = "nPort";
            this.nPort.Size = new System.Drawing.Size(75, 20);
            this.nPort.TabIndex = 7;
            this.nPort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cDefaultRank
            // 
            this.cDefaultRank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cDefaultRank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cDefaultRank.FormattingEnabled = true;
            this.cDefaultRank.Location = new System.Drawing.Point(440, 128);
            this.cDefaultRank.Name = "cDefaultRank";
            this.cDefaultRank.Size = new System.Drawing.Size(170, 21);
            this.cDefaultRank.TabIndex = 18;
            // 
            // lDefaultRank
            // 
            this.lDefaultRank.AutoSize = true;
            this.lDefaultRank.Location = new System.Drawing.Point(361, 131);
            this.lDefaultRank.Name = "lDefaultRank";
            this.lDefaultRank.Size = new System.Drawing.Size(65, 13);
            this.lDefaultRank.TabIndex = 17;
            this.lDefaultRank.Text = "Default rank";
            // 
            // lUploadBandwidth
            // 
            this.lUploadBandwidth.AutoSize = true;
            this.lUploadBandwidth.Location = new System.Drawing.Point(327, 103);
            this.lUploadBandwidth.Name = "lUploadBandwidth";
            this.lUploadBandwidth.Size = new System.Drawing.Size(93, 13);
            this.lUploadBandwidth.TabIndex = 13;
            this.lUploadBandwidth.Text = "Upload bandwidth";
            // 
            // bMeasure
            // 
            this.bMeasure.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bMeasure.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bMeasure.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.bMeasure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bMeasure.Location = new System.Drawing.Point(559, 99);
            this.bMeasure.Name = "bMeasure";
            this.bMeasure.Size = new System.Drawing.Size(71, 23);
            this.bMeasure.TabIndex = 16;
            this.bMeasure.Text = "Measure";
            this.bMeasure.UseVisualStyleBackColor = false;
            // 
            // tServerName
            // 
            this.tServerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tServerName.HideSelection = false;
            this.tServerName.Location = new System.Drawing.Point(123, 20);
            this.tServerName.MaxLength = 64;
            this.tServerName.Name = "tServerName";
            this.tServerName.Size = new System.Drawing.Size(507, 20);
            this.tServerName.TabIndex = 1;
            // 
            // lUploadBandwidthUnits
            // 
            this.lUploadBandwidthUnits.AutoSize = true;
            this.lUploadBandwidthUnits.Location = new System.Drawing.Point(521, 103);
            this.lUploadBandwidthUnits.Name = "lUploadBandwidthUnits";
            this.lUploadBandwidthUnits.Size = new System.Drawing.Size(31, 13);
            this.lUploadBandwidthUnits.TabIndex = 15;
            this.lUploadBandwidthUnits.Text = "KB/s";
            // 
            // lServerName
            // 
            this.lServerName.AutoSize = true;
            this.lServerName.Location = new System.Drawing.Point(40, 23);
            this.lServerName.Name = "lServerName";
            this.lServerName.Size = new System.Drawing.Size(67, 13);
            this.lServerName.TabIndex = 0;
            this.lServerName.Text = "Server name";
            // 
            // nUploadBandwidth
            // 
            this.nUploadBandwidth.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUploadBandwidth.Location = new System.Drawing.Point(440, 101);
            this.nUploadBandwidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUploadBandwidth.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUploadBandwidth.Name = "nUploadBandwidth";
            this.nUploadBandwidth.Size = new System.Drawing.Size(75, 20);
            this.nUploadBandwidth.TabIndex = 14;
            this.nUploadBandwidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // tMOTD
            // 
            this.tMOTD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tMOTD.Location = new System.Drawing.Point(123, 47);
            this.tMOTD.MaxLength = 64;
            this.tMOTD.Name = "tMOTD";
            this.tMOTD.Size = new System.Drawing.Size(507, 20);
            this.tMOTD.TabIndex = 3;
            // 
            // lMOTD
            // 
            this.lMOTD.AutoSize = true;
            this.lMOTD.Location = new System.Drawing.Point(74, 50);
            this.lMOTD.Name = "lMOTD";
            this.lMOTD.Size = new System.Drawing.Size(39, 13);
            this.lMOTD.TabIndex = 2;
            this.lMOTD.Text = "MOTD";
            // 
            // cPublic
            // 
            this.cPublic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cPublic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cPublic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cPublic.FormattingEnabled = true;
            this.cPublic.Items.AddRange(new object[] {
            "Public",
            "Private"});
            this.cPublic.Location = new System.Drawing.Point(123, 128);
            this.cPublic.Name = "cPublic";
            this.cPublic.Size = new System.Drawing.Size(75, 23);
            this.cPublic.TabIndex = 10;
            // 
            // nMaxPlayers
            // 
            this.nMaxPlayers.Location = new System.Drawing.Point(123, 74);
            this.nMaxPlayers.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nMaxPlayers.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nMaxPlayers.Name = "nMaxPlayers";
            this.nMaxPlayers.Size = new System.Drawing.Size(75, 20);
            this.nMaxPlayers.TabIndex = 5;
            this.nMaxPlayers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lPublic
            // 
            this.lPublic.AutoSize = true;
            this.lPublic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPublic.Location = new System.Drawing.Point(14, 131);
            this.lPublic.Name = "lPublic";
            this.lPublic.Size = new System.Drawing.Size(103, 15);
            this.lPublic.TabIndex = 9;
            this.lPublic.Text = "Server visibility";
            // 
            // lMaxPlayers
            // 
            this.lMaxPlayers.AutoSize = true;
            this.lMaxPlayers.Location = new System.Drawing.Point(10, 76);
            this.lMaxPlayers.Name = "lMaxPlayers";
            this.lMaxPlayers.Size = new System.Drawing.Size(92, 13);
            this.lMaxPlayers.TabIndex = 4;
            this.lMaxPlayers.Text = "Max players (total)";
            // 
            // gInformation
            // 
            this.gInformation.Controls.Add(this.bGreeting);
            this.gInformation.Controls.Add(this.lAnnouncementsUnits);
            this.gInformation.Controls.Add(this.nAnnouncements);
            this.gInformation.Controls.Add(this.xAnnouncements);
            this.gInformation.Controls.Add(this.bRules);
            this.gInformation.Controls.Add(this.bAnnouncements);
            this.gInformation.Location = new System.Drawing.Point(16, 259);
            this.gInformation.Name = "gInformation";
            this.gInformation.Size = new System.Drawing.Size(636, 57);
            this.gInformation.TabIndex = 2;
            this.gInformation.TabStop = false;
            this.gInformation.Text = "Information";
            // 
            // bGreeting
            // 
            this.bGreeting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bGreeting.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bGreeting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bGreeting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.bGreeting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bGreeting.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bGreeting.Location = new System.Drawing.Point(538, 20);
            this.bGreeting.Name = "bGreeting";
            this.bGreeting.Size = new System.Drawing.Size(92, 28);
            this.bGreeting.TabIndex = 5;
            this.bGreeting.Text = "Edit Greeting";
            this.bGreeting.UseVisualStyleBackColor = false;
            // 
            // lAnnouncementsUnits
            // 
            this.lAnnouncementsUnits.AutoSize = true;
            this.lAnnouncementsUnits.Location = new System.Drawing.Point(266, 27);
            this.lAnnouncementsUnits.Name = "lAnnouncementsUnits";
            this.lAnnouncementsUnits.Size = new System.Drawing.Size(23, 13);
            this.lAnnouncementsUnits.TabIndex = 2;
            this.lAnnouncementsUnits.Text = "min";
            // 
            // nAnnouncements
            // 
            this.nAnnouncements.Enabled = false;
            this.nAnnouncements.Location = new System.Drawing.Point(210, 25);
            this.nAnnouncements.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nAnnouncements.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nAnnouncements.Name = "nAnnouncements";
            this.nAnnouncements.Size = new System.Drawing.Size(50, 20);
            this.nAnnouncements.TabIndex = 1;
            this.nAnnouncements.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // xAnnouncements
            // 
            this.xAnnouncements.AutoSize = true;
            this.xAnnouncements.BackColor = System.Drawing.Color.Firebrick;
            this.xAnnouncements.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.xAnnouncements.Location = new System.Drawing.Point(24, 26);
            this.xAnnouncements.Name = "xAnnouncements";
            this.xAnnouncements.Size = new System.Drawing.Size(167, 18);
            this.xAnnouncements.TabIndex = 0;
            this.xAnnouncements.Text = "Show announcements every";
            this.xAnnouncements.UseVisualStyleBackColor = false;
            // 
            // bRules
            // 
            this.bRules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bRules.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bRules.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bRules.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.bRules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bRules.Location = new System.Drawing.Point(445, 20);
            this.bRules.Name = "bRules";
            this.bRules.Size = new System.Drawing.Size(87, 28);
            this.bRules.TabIndex = 4;
            this.bRules.Text = "Edit Rules";
            this.bRules.UseVisualStyleBackColor = false;
            // 
            // bAnnouncements
            // 
            this.bAnnouncements.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bAnnouncements.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bAnnouncements.Enabled = false;
            this.bAnnouncements.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bAnnouncements.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.bAnnouncements.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAnnouncements.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAnnouncements.Location = new System.Drawing.Point(301, 20);
            this.bAnnouncements.Name = "bAnnouncements";
            this.bAnnouncements.Size = new System.Drawing.Size(138, 28);
            this.bAnnouncements.TabIndex = 3;
            this.bAnnouncements.Text = "Edit Announcements";
            this.bAnnouncements.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.bChangelog);
            this.groupBox2.Controls.Add(this.bCredits);
            this.groupBox2.Controls.Add(this.bReadme);
            this.groupBox2.Location = new System.Drawing.Point(16, 322);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(123, 135);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "About";
            // 
            // bChangelog
            // 
            this.bChangelog.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bChangelog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bChangelog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.bChangelog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bChangelog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bChangelog.Location = new System.Drawing.Point(7, 89);
            this.bChangelog.Name = "bChangelog";
            this.bChangelog.Size = new System.Drawing.Size(110, 23);
            this.bChangelog.TabIndex = 2;
            this.bChangelog.Text = "Changelog";
            this.bChangelog.UseVisualStyleBackColor = false;
            // 
            // bCredits
            // 
            this.bCredits.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bCredits.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bCredits.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.bCredits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCredits.Location = new System.Drawing.Point(6, 31);
            this.bCredits.Name = "bCredits";
            this.bCredits.Size = new System.Drawing.Size(111, 23);
            this.bCredits.TabIndex = 1;
            this.bCredits.Text = "Credits";
            this.bCredits.UseVisualStyleBackColor = false;
            // 
            // bReadme
            // 
            this.bReadme.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bReadme.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bReadme.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.bReadme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bReadme.Location = new System.Drawing.Point(7, 60);
            this.bReadme.Name = "bReadme";
            this.bReadme.Size = new System.Drawing.Size(110, 23);
            this.bReadme.TabIndex = 1;
            this.bReadme.Text = "Readme";
            this.bReadme.UseVisualStyleBackColor = false;
            // 
            // groupBox4
            // 
            this.groupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.bWiki);
            this.groupBox4.Controls.Add(this.bWeb);
            this.groupBox4.Location = new System.Drawing.Point(144, 322);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(126, 135);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Contact Us";
            // 
            // bWiki
            // 
            this.bWiki.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bWiki.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bWiki.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.bWiki.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bWiki.Location = new System.Drawing.Point(8, 60);
            this.bWiki.Name = "bWiki";
            this.bWiki.Size = new System.Drawing.Size(110, 23);
            this.bWiki.TabIndex = 1;
            this.bWiki.Text = "Wiki";
            this.bWiki.UseVisualStyleBackColor = false;
            // 
            // bWeb
            // 
            this.bWeb.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bWeb.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bWeb.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.bWeb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bWeb.Location = new System.Drawing.Point(8, 31);
            this.bWeb.Name = "bWeb";
            this.bWeb.Size = new System.Drawing.Size(110, 23);
            this.bWeb.TabIndex = 1;
            this.bWeb.Text = "Website";
            this.bWeb.UseVisualStyleBackColor = false;
            // 
            // picLogo
            // 
            this.picLogo.Image = global::GemsCraft.Properties.Resources.main;
            this.picLogo.Location = new System.Drawing.Point(275, 322);
            this.picLogo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(377, 83);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 7;
            this.picLogo.TabStop = false;
            // 
            // bResetTab
            // 
            this.bResetTab.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.bResetTab.Location = new System.Drawing.Point(557, 434);
            this.bResetTab.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bResetTab.Name = "bResetTab";
            this.bResetTab.Size = new System.Drawing.Size(95, 24);
            this.bResetTab.TabIndex = 8;
            this.bResetTab.Text = "Reset";
            this.bResetTab.UseSelectable = true;
            // 
            // GeneralConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 465);
            this.Controls.Add(this.bResetTab);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gInformation);
            this.Controls.Add(this.gBasic);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "GeneralConfig";
            this.Padding = new System.Windows.Forms.Padding(13, 39, 13, 13);
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "GemsCraft Configuration - General";
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.gBasic.ResumeLayout(false);
            this.gBasic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxPlayersPerWorld)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUploadBandwidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxPlayers)).EndInit();
            this.gInformation.ResumeLayout(false);
            this.gInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nAnnouncements)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox gBasic;
        internal System.Windows.Forms.NumericUpDown nMaxPlayersPerWorld;
        internal System.Windows.Forms.Label lMaxPlayersPerWorld;
        internal System.Windows.Forms.Label lPort;
        internal System.Windows.Forms.NumericUpDown nPort;
        internal System.Windows.Forms.ComboBox cDefaultRank;
        internal System.Windows.Forms.Label lDefaultRank;
        internal System.Windows.Forms.Label lUploadBandwidth;
        internal System.Windows.Forms.Button bMeasure;
        internal System.Windows.Forms.TextBox tServerName;
        internal System.Windows.Forms.Label lUploadBandwidthUnits;
        internal System.Windows.Forms.Label lServerName;
        internal System.Windows.Forms.NumericUpDown nUploadBandwidth;
        internal System.Windows.Forms.TextBox tMOTD;
        internal System.Windows.Forms.Label lMOTD;
        internal System.Windows.Forms.ComboBox cPublic;
        internal System.Windows.Forms.NumericUpDown nMaxPlayers;
        internal System.Windows.Forms.Label lPublic;
        internal System.Windows.Forms.Label lMaxPlayers;
        internal System.Windows.Forms.GroupBox gInformation;
        internal System.Windows.Forms.Button bGreeting;
        internal System.Windows.Forms.Label lAnnouncementsUnits;
        internal System.Windows.Forms.NumericUpDown nAnnouncements;
        internal System.Windows.Forms.CheckBox xAnnouncements;
        internal System.Windows.Forms.Button bRules;
        internal System.Windows.Forms.Button bAnnouncements;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Button bChangelog;
        internal System.Windows.Forms.Button bCredits;
        internal System.Windows.Forms.Button bReadme;
        internal System.Windows.Forms.GroupBox groupBox4;
        internal System.Windows.Forms.Button bWiki;
        internal System.Windows.Forms.Button bWeb;
        internal System.Windows.Forms.PictureBox picLogo;
        internal MetroFramework.Controls.MetroButton bResetTab;
    }
}