namespace fCraft.GUI.ConfigGUI.GUI.Sections
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
            this.gBasic.Location = new System.Drawing.Point(24, 96);
            this.gBasic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gBasic.Name = "gBasic";
            this.gBasic.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gBasic.Size = new System.Drawing.Size(954, 292);
            this.gBasic.TabIndex = 1;
            this.gBasic.TabStop = false;
            this.gBasic.Text = "Basic Settings";
            // 
            // nMaxPlayersPerWorld
            // 
            this.nMaxPlayersPerWorld.Location = new System.Drawing.Point(660, 114);
            this.nMaxPlayersPerWorld.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.nMaxPlayersPerWorld.Size = new System.Drawing.Size(112, 26);
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
            this.lMaxPlayersPerWorld.Location = new System.Drawing.Point(448, 117);
            this.lMaxPlayersPerWorld.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lMaxPlayersPerWorld.Name = "lMaxPlayersPerWorld";
            this.lMaxPlayersPerWorld.Size = new System.Drawing.Size(170, 20);
            this.lMaxPlayersPerWorld.TabIndex = 11;
            this.lMaxPlayersPerWorld.Text = "Max players (per world)";
            // 
            // lPort
            // 
            this.lPort.AutoSize = true;
            this.lPort.Location = new System.Drawing.Point(63, 158);
            this.lPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lPort.Name = "lPort";
            this.lPort.Size = new System.Drawing.Size(96, 20);
            this.lPort.TabIndex = 6;
            this.lPort.Text = "Port number";
            // 
            // nPort
            // 
            this.nPort.Location = new System.Drawing.Point(184, 155);
            this.nPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.nPort.Size = new System.Drawing.Size(112, 26);
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
            this.cDefaultRank.Location = new System.Drawing.Point(660, 197);
            this.cDefaultRank.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cDefaultRank.Name = "cDefaultRank";
            this.cDefaultRank.Size = new System.Drawing.Size(253, 28);
            this.cDefaultRank.TabIndex = 18;
            // 
            // lDefaultRank
            // 
            this.lDefaultRank.AutoSize = true;
            this.lDefaultRank.Location = new System.Drawing.Point(542, 202);
            this.lDefaultRank.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lDefaultRank.Name = "lDefaultRank";
            this.lDefaultRank.Size = new System.Drawing.Size(96, 20);
            this.lDefaultRank.TabIndex = 17;
            this.lDefaultRank.Text = "Default rank";
            // 
            // lUploadBandwidth
            // 
            this.lUploadBandwidth.AutoSize = true;
            this.lUploadBandwidth.Location = new System.Drawing.Point(490, 158);
            this.lUploadBandwidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lUploadBandwidth.Name = "lUploadBandwidth";
            this.lUploadBandwidth.Size = new System.Drawing.Size(137, 20);
            this.lUploadBandwidth.TabIndex = 13;
            this.lUploadBandwidth.Text = "Upload bandwidth";
            // 
            // bMeasure
            // 
            this.bMeasure.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bMeasure.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bMeasure.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.bMeasure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bMeasure.Location = new System.Drawing.Point(838, 152);
            this.bMeasure.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bMeasure.Name = "bMeasure";
            this.bMeasure.Size = new System.Drawing.Size(106, 35);
            this.bMeasure.TabIndex = 16;
            this.bMeasure.Text = "Measure";
            this.bMeasure.UseVisualStyleBackColor = false;
            // 
            // tServerName
            // 
            this.tServerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tServerName.HideSelection = false;
            this.tServerName.Location = new System.Drawing.Point(184, 31);
            this.tServerName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tServerName.MaxLength = 64;
            this.tServerName.Name = "tServerName";
            this.tServerName.Size = new System.Drawing.Size(758, 26);
            this.tServerName.TabIndex = 1;
            // 
            // lUploadBandwidthUnits
            // 
            this.lUploadBandwidthUnits.AutoSize = true;
            this.lUploadBandwidthUnits.Location = new System.Drawing.Point(782, 158);
            this.lUploadBandwidthUnits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lUploadBandwidthUnits.Name = "lUploadBandwidthUnits";
            this.lUploadBandwidthUnits.Size = new System.Drawing.Size(42, 20);
            this.lUploadBandwidthUnits.TabIndex = 15;
            this.lUploadBandwidthUnits.Text = "KB/s";
            // 
            // lServerName
            // 
            this.lServerName.AutoSize = true;
            this.lServerName.Location = new System.Drawing.Point(60, 35);
            this.lServerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lServerName.Name = "lServerName";
            this.lServerName.Size = new System.Drawing.Size(99, 20);
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
            this.nUploadBandwidth.Location = new System.Drawing.Point(660, 155);
            this.nUploadBandwidth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.nUploadBandwidth.Size = new System.Drawing.Size(112, 26);
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
            this.tMOTD.Location = new System.Drawing.Point(184, 72);
            this.tMOTD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tMOTD.MaxLength = 64;
            this.tMOTD.Name = "tMOTD";
            this.tMOTD.Size = new System.Drawing.Size(758, 26);
            this.tMOTD.TabIndex = 3;
            // 
            // lMOTD
            // 
            this.lMOTD.AutoSize = true;
            this.lMOTD.Location = new System.Drawing.Point(111, 77);
            this.lMOTD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lMOTD.Name = "lMOTD";
            this.lMOTD.Size = new System.Drawing.Size(55, 20);
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
            this.cPublic.Location = new System.Drawing.Point(184, 197);
            this.cPublic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cPublic.Name = "cPublic";
            this.cPublic.Size = new System.Drawing.Size(110, 30);
            this.cPublic.TabIndex = 10;
            // 
            // nMaxPlayers
            // 
            this.nMaxPlayers.Location = new System.Drawing.Point(184, 114);
            this.nMaxPlayers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.nMaxPlayers.Size = new System.Drawing.Size(112, 26);
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
            this.lPublic.Location = new System.Drawing.Point(21, 202);
            this.lPublic.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lPublic.Name = "lPublic";
            this.lPublic.Size = new System.Drawing.Size(147, 22);
            this.lPublic.TabIndex = 9;
            this.lPublic.Text = "Server visibility";
            // 
            // lMaxPlayers
            // 
            this.lMaxPlayers.AutoSize = true;
            this.lMaxPlayers.Location = new System.Drawing.Point(15, 117);
            this.lMaxPlayers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lMaxPlayers.Name = "lMaxPlayers";
            this.lMaxPlayers.Size = new System.Drawing.Size(137, 20);
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
            this.gInformation.Location = new System.Drawing.Point(24, 398);
            this.gInformation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gInformation.Name = "gInformation";
            this.gInformation.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gInformation.Size = new System.Drawing.Size(954, 88);
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
            this.bGreeting.Location = new System.Drawing.Point(807, 31);
            this.bGreeting.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bGreeting.Name = "bGreeting";
            this.bGreeting.Size = new System.Drawing.Size(138, 43);
            this.bGreeting.TabIndex = 5;
            this.bGreeting.Text = "Edit Greeting";
            this.bGreeting.UseVisualStyleBackColor = false;
            // 
            // lAnnouncementsUnits
            // 
            this.lAnnouncementsUnits.AutoSize = true;
            this.lAnnouncementsUnits.Location = new System.Drawing.Point(399, 42);
            this.lAnnouncementsUnits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lAnnouncementsUnits.Name = "lAnnouncementsUnits";
            this.lAnnouncementsUnits.Size = new System.Drawing.Size(34, 20);
            this.lAnnouncementsUnits.TabIndex = 2;
            this.lAnnouncementsUnits.Text = "min";
            // 
            // nAnnouncements
            // 
            this.nAnnouncements.Enabled = false;
            this.nAnnouncements.Location = new System.Drawing.Point(315, 38);
            this.nAnnouncements.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.nAnnouncements.Size = new System.Drawing.Size(75, 26);
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
            this.xAnnouncements.Location = new System.Drawing.Point(36, 40);
            this.xAnnouncements.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xAnnouncements.Name = "xAnnouncements";
            this.xAnnouncements.Size = new System.Drawing.Size(234, 25);
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
            this.bRules.Location = new System.Drawing.Point(668, 31);
            this.bRules.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bRules.Name = "bRules";
            this.bRules.Size = new System.Drawing.Size(130, 43);
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
            this.bAnnouncements.Location = new System.Drawing.Point(452, 31);
            this.bAnnouncements.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bAnnouncements.Name = "bAnnouncements";
            this.bAnnouncements.Size = new System.Drawing.Size(207, 43);
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
            this.groupBox2.Location = new System.Drawing.Point(24, 496);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(184, 208);
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
            this.bChangelog.Location = new System.Drawing.Point(10, 137);
            this.bChangelog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bChangelog.Name = "bChangelog";
            this.bChangelog.Size = new System.Drawing.Size(165, 35);
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
            this.bCredits.Location = new System.Drawing.Point(9, 48);
            this.bCredits.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bCredits.Name = "bCredits";
            this.bCredits.Size = new System.Drawing.Size(166, 35);
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
            this.bReadme.Location = new System.Drawing.Point(10, 92);
            this.bReadme.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bReadme.Name = "bReadme";
            this.bReadme.Size = new System.Drawing.Size(165, 35);
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
            this.groupBox4.Location = new System.Drawing.Point(216, 496);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Size = new System.Drawing.Size(189, 208);
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
            this.bWiki.Location = new System.Drawing.Point(12, 92);
            this.bWiki.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bWiki.Name = "bWiki";
            this.bWiki.Size = new System.Drawing.Size(165, 35);
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
            this.bWeb.Location = new System.Drawing.Point(12, 48);
            this.bWeb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bWeb.Name = "bWeb";
            this.bWeb.Size = new System.Drawing.Size(165, 35);
            this.bWeb.TabIndex = 1;
            this.bWeb.Text = "Website";
            this.bWeb.UseVisualStyleBackColor = false;
            // 
            // picLogo
            // 
            this.picLogo.Image = global::fCraft.Properties.Resources.main;
            this.picLogo.Location = new System.Drawing.Point(413, 496);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(565, 127);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 7;
            this.picLogo.TabStop = false;
            // 
            // bResetTab
            // 
            this.bResetTab.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.bResetTab.Location = new System.Drawing.Point(836, 667);
            this.bResetTab.Name = "bResetTab";
            this.bResetTab.Size = new System.Drawing.Size(142, 37);
            this.bResetTab.TabIndex = 8;
            this.bResetTab.Text = "Reset";
            this.bResetTab.UseSelectable = true;
            // 
            // GeneralConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 715);
            this.Controls.Add(this.bResetTab);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gInformation);
            this.Controls.Add(this.gBasic);
            this.Name = "GeneralConfig";
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