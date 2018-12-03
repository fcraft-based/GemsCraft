namespace GemsCraft.GUI.ConfigGUI.GUI.Sections
{
    partial class RankConfig
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
            this.gPermissionLimits = new System.Windows.Forms.GroupBox();
            this.permissionLimitBoxContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.lRankList = new System.Windows.Forms.Label();
            this.bLowerRank = new System.Windows.Forms.Button();
            this.bRaiseRank = new System.Windows.Forms.Button();
            this.gRankOptions = new System.Windows.Forms.GroupBox();
            this.lFillLimitUnits = new System.Windows.Forms.Label();
            this.nFillLimit = new System.Windows.Forms.NumericUpDown();
            this.lFillLimit = new System.Windows.Forms.Label();
            this.nCopyPasteSlots = new System.Windows.Forms.NumericUpDown();
            this.lCopyPasteSlots = new System.Windows.Forms.Label();
            this.xAllowSecurityCircumvention = new System.Windows.Forms.CheckBox();
            this.lAntiGrief1 = new System.Windows.Forms.Label();
            this.lAntiGrief3 = new System.Windows.Forms.Label();
            this.nAntiGriefSeconds = new System.Windows.Forms.NumericUpDown();
            this.bColorRank = new System.Windows.Forms.Button();
            this.xDrawLimit = new System.Windows.Forms.CheckBox();
            this.lDrawLimitUnits = new System.Windows.Forms.Label();
            this.lKickIdleUnits = new System.Windows.Forms.Label();
            this.nDrawLimit = new System.Windows.Forms.NumericUpDown();
            this.nKickIdle = new System.Windows.Forms.NumericUpDown();
            this.xAntiGrief = new System.Windows.Forms.CheckBox();
            this.lAntiGrief2 = new System.Windows.Forms.Label();
            this.xKickIdle = new System.Windows.Forms.CheckBox();
            this.nAntiGriefBlocks = new System.Windows.Forms.NumericUpDown();
            this.xReserveSlot = new System.Windows.Forms.CheckBox();
            this.tPrefix = new System.Windows.Forms.TextBox();
            this.lPrefix = new System.Windows.Forms.Label();
            this.lRankColor = new System.Windows.Forms.Label();
            this.tRankName = new System.Windows.Forms.TextBox();
            this.lRankName = new System.Windows.Forms.Label();
            this.bDeleteRank = new System.Windows.Forms.Button();
            this.vPermissions = new System.Windows.Forms.ListView();
            this.chPermissions = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bAddRank = new System.Windows.Forms.Button();
            this.lPermissions = new System.Windows.Forms.Label();
            this.vRanks = new System.Windows.Forms.ListBox();
            this.bResetTab = new MetroFramework.Controls.MetroButton();
            this.gPermissionLimits.SuspendLayout();
            this.gRankOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nFillLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCopyPasteSlots)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nAntiGriefSeconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDrawLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nKickIdle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nAntiGriefBlocks)).BeginInit();
            this.SuspendLayout();
            // 
            // gPermissionLimits
            // 
            this.gPermissionLimits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gPermissionLimits.Controls.Add(this.permissionLimitBoxContainer);
            this.gPermissionLimits.Location = new System.Drawing.Point(254, 521);
            this.gPermissionLimits.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gPermissionLimits.Name = "gPermissionLimits";
            this.gPermissionLimits.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gPermissionLimits.Size = new System.Drawing.Size(460, 347);
            this.gPermissionLimits.TabIndex = 17;
            this.gPermissionLimits.TabStop = false;
            this.gPermissionLimits.Text = "Permission Limits";
            // 
            // permissionLimitBoxContainer
            // 
            this.permissionLimitBoxContainer.AutoScroll = true;
            this.permissionLimitBoxContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.permissionLimitBoxContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.permissionLimitBoxContainer.Location = new System.Drawing.Point(4, 24);
            this.permissionLimitBoxContainer.Margin = new System.Windows.Forms.Padding(0);
            this.permissionLimitBoxContainer.Name = "permissionLimitBoxContainer";
            this.permissionLimitBoxContainer.Size = new System.Drawing.Size(452, 318);
            this.permissionLimitBoxContainer.TabIndex = 0;
            this.permissionLimitBoxContainer.WrapContents = false;
            // 
            // lRankList
            // 
            this.lRankList.AutoSize = true;
            this.lRankList.Location = new System.Drawing.Point(26, 96);
            this.lRankList.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lRankList.Name = "lRankList";
            this.lRankList.Size = new System.Drawing.Size(76, 20);
            this.lRankList.TabIndex = 10;
            this.lRankList.Text = "Rank List";
            // 
            // bLowerRank
            // 
            this.bLowerRank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bLowerRank.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bLowerRank.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bLowerRank.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.bLowerRank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bLowerRank.Location = new System.Drawing.Point(140, 833);
            this.bLowerRank.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bLowerRank.Name = "bLowerRank";
            this.bLowerRank.Size = new System.Drawing.Size(105, 35);
            this.bLowerRank.TabIndex = 15;
            this.bLowerRank.Text = "▼ Lower";
            this.bLowerRank.UseVisualStyleBackColor = false;
            // 
            // bRaiseRank
            // 
            this.bRaiseRank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bRaiseRank.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bRaiseRank.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bRaiseRank.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.bRaiseRank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bRaiseRank.Location = new System.Drawing.Point(26, 833);
            this.bRaiseRank.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bRaiseRank.Name = "bRaiseRank";
            this.bRaiseRank.Size = new System.Drawing.Size(105, 35);
            this.bRaiseRank.TabIndex = 14;
            this.bRaiseRank.Text = "▲ Raise";
            this.bRaiseRank.UseVisualStyleBackColor = false;
            // 
            // gRankOptions
            // 
            this.gRankOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gRankOptions.Controls.Add(this.lFillLimitUnits);
            this.gRankOptions.Controls.Add(this.nFillLimit);
            this.gRankOptions.Controls.Add(this.lFillLimit);
            this.gRankOptions.Controls.Add(this.nCopyPasteSlots);
            this.gRankOptions.Controls.Add(this.lCopyPasteSlots);
            this.gRankOptions.Controls.Add(this.xAllowSecurityCircumvention);
            this.gRankOptions.Controls.Add(this.lAntiGrief1);
            this.gRankOptions.Controls.Add(this.lAntiGrief3);
            this.gRankOptions.Controls.Add(this.nAntiGriefSeconds);
            this.gRankOptions.Controls.Add(this.bColorRank);
            this.gRankOptions.Controls.Add(this.xDrawLimit);
            this.gRankOptions.Controls.Add(this.lDrawLimitUnits);
            this.gRankOptions.Controls.Add(this.lKickIdleUnits);
            this.gRankOptions.Controls.Add(this.nDrawLimit);
            this.gRankOptions.Controls.Add(this.nKickIdle);
            this.gRankOptions.Controls.Add(this.xAntiGrief);
            this.gRankOptions.Controls.Add(this.lAntiGrief2);
            this.gRankOptions.Controls.Add(this.xKickIdle);
            this.gRankOptions.Controls.Add(this.nAntiGriefBlocks);
            this.gRankOptions.Controls.Add(this.xReserveSlot);
            this.gRankOptions.Controls.Add(this.tPrefix);
            this.gRankOptions.Controls.Add(this.lPrefix);
            this.gRankOptions.Controls.Add(this.lRankColor);
            this.gRankOptions.Controls.Add(this.tRankName);
            this.gRankOptions.Controls.Add(this.lRankName);
            this.gRankOptions.Location = new System.Drawing.Point(256, 96);
            this.gRankOptions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gRankOptions.Name = "gRankOptions";
            this.gRankOptions.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gRankOptions.Size = new System.Drawing.Size(460, 420);
            this.gRankOptions.TabIndex = 16;
            this.gRankOptions.TabStop = false;
            this.gRankOptions.Text = "Rank Options";
            // 
            // lFillLimitUnits
            // 
            this.lFillLimitUnits.AutoSize = true;
            this.lFillLimitUnits.Location = new System.Drawing.Point(358, 377);
            this.lFillLimitUnits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lFillLimitUnits.Name = "lFillLimitUnits";
            this.lFillLimitUnits.Size = new System.Drawing.Size(54, 20);
            this.lFillLimitUnits.TabIndex = 24;
            this.lFillLimitUnits.Text = "blocks";
            // 
            // nFillLimit
            // 
            this.nFillLimit.Location = new System.Drawing.Point(261, 374);
            this.nFillLimit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nFillLimit.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.nFillLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nFillLimit.Name = "nFillLimit";
            this.nFillLimit.Size = new System.Drawing.Size(88, 26);
            this.nFillLimit.TabIndex = 23;
            this.nFillLimit.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // lFillLimit
            // 
            this.lFillLimit.AutoSize = true;
            this.lFillLimit.Location = new System.Drawing.Point(128, 377);
            this.lFillLimit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lFillLimit.Name = "lFillLimit";
            this.lFillLimit.Size = new System.Drawing.Size(103, 20);
            this.lFillLimit.TabIndex = 22;
            this.lFillLimit.Text = "Flood-fill limit:";
            // 
            // nCopyPasteSlots
            // 
            this.nCopyPasteSlots.Location = new System.Drawing.Point(261, 332);
            this.nCopyPasteSlots.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nCopyPasteSlots.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nCopyPasteSlots.Name = "nCopyPasteSlots";
            this.nCopyPasteSlots.Size = new System.Drawing.Size(88, 26);
            this.nCopyPasteSlots.TabIndex = 21;
            // 
            // lCopyPasteSlots
            // 
            this.lCopyPasteSlots.AutoSize = true;
            this.lCopyPasteSlots.Location = new System.Drawing.Point(75, 335);
            this.lCopyPasteSlots.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lCopyPasteSlots.Name = "lCopyPasteSlots";
            this.lCopyPasteSlots.Size = new System.Drawing.Size(153, 20);
            this.lCopyPasteSlots.TabIndex = 20;
            this.lCopyPasteSlots.Text = "Copy/paste slot limit:";
            // 
            // xAllowSecurityCircumvention
            // 
            this.xAllowSecurityCircumvention.AutoSize = true;
            this.xAllowSecurityCircumvention.Location = new System.Drawing.Point(18, 254);
            this.xAllowSecurityCircumvention.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xAllowSecurityCircumvention.Name = "xAllowSecurityCircumvention";
            this.xAllowSecurityCircumvention.Size = new System.Drawing.Size(349, 24);
            this.xAllowSecurityCircumvention.TabIndex = 16;
            this.xAllowSecurityCircumvention.Text = "Allow removing own access/build restrictions.";
            this.xAllowSecurityCircumvention.UseVisualStyleBackColor = true;
            // 
            // lAntiGrief1
            // 
            this.lAntiGrief1.AutoSize = true;
            this.lAntiGrief1.Location = new System.Drawing.Point(75, 208);
            this.lAntiGrief1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lAntiGrief1.Name = "lAntiGrief1";
            this.lAntiGrief1.Size = new System.Drawing.Size(60, 20);
            this.lAntiGrief1.TabIndex = 11;
            this.lAntiGrief1.Text = "Kick on";
            // 
            // lAntiGrief3
            // 
            this.lAntiGrief3.AutoSize = true;
            this.lAntiGrief3.Location = new System.Drawing.Point(412, 208);
            this.lAntiGrief3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lAntiGrief3.Name = "lAntiGrief3";
            this.lAntiGrief3.Size = new System.Drawing.Size(34, 20);
            this.lAntiGrief3.TabIndex = 15;
            this.lAntiGrief3.Text = "sec";
            // 
            // nAntiGriefSeconds
            // 
            this.nAntiGriefSeconds.Location = new System.Drawing.Point(344, 205);
            this.nAntiGriefSeconds.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nAntiGriefSeconds.Name = "nAntiGriefSeconds";
            this.nAntiGriefSeconds.Size = new System.Drawing.Size(60, 26);
            this.nAntiGriefSeconds.TabIndex = 14;
            // 
            // bColorRank
            // 
            this.bColorRank.BackColor = System.Drawing.Color.White;
            this.bColorRank.Location = new System.Drawing.Point(302, 72);
            this.bColorRank.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bColorRank.Name = "bColorRank";
            this.bColorRank.Size = new System.Drawing.Size(150, 37);
            this.bColorRank.TabIndex = 6;
            this.bColorRank.UseVisualStyleBackColor = false;
            // 
            // xDrawLimit
            // 
            this.xDrawLimit.AutoSize = true;
            this.xDrawLimit.Location = new System.Drawing.Point(18, 292);
            this.xDrawLimit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xDrawLimit.Name = "xDrawLimit";
            this.xDrawLimit.Size = new System.Drawing.Size(103, 24);
            this.xDrawLimit.TabIndex = 17;
            this.xDrawLimit.Text = "Draw limit";
            this.xDrawLimit.UseVisualStyleBackColor = true;
            // 
            // lDrawLimitUnits
            // 
            this.lDrawLimitUnits.AutoSize = true;
            this.lDrawLimitUnits.Location = new System.Drawing.Point(258, 294);
            this.lDrawLimitUnits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lDrawLimitUnits.Name = "lDrawLimitUnits";
            this.lDrawLimitUnits.Size = new System.Drawing.Size(54, 20);
            this.lDrawLimitUnits.TabIndex = 19;
            this.lDrawLimitUnits.Text = "blocks";
            // 
            // lKickIdleUnits
            // 
            this.lKickIdleUnits.AutoSize = true;
            this.lKickIdleUnits.Location = new System.Drawing.Point(272, 122);
            this.lKickIdleUnits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lKickIdleUnits.Name = "lKickIdleUnits";
            this.lKickIdleUnits.Size = new System.Drawing.Size(65, 20);
            this.lKickIdleUnits.TabIndex = 9;
            this.lKickIdleUnits.Text = "minutes";
            // 
            // nDrawLimit
            // 
            this.nDrawLimit.Increment = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.nDrawLimit.Location = new System.Drawing.Point(148, 291);
            this.nDrawLimit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nDrawLimit.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nDrawLimit.Name = "nDrawLimit";
            this.nDrawLimit.Size = new System.Drawing.Size(100, 26);
            this.nDrawLimit.TabIndex = 18;
            // 
            // nKickIdle
            // 
            this.nKickIdle.Location = new System.Drawing.Point(174, 118);
            this.nKickIdle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nKickIdle.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nKickIdle.Name = "nKickIdle";
            this.nKickIdle.Size = new System.Drawing.Size(88, 26);
            this.nKickIdle.TabIndex = 8;
            // 
            // xAntiGrief
            // 
            this.xAntiGrief.AutoSize = true;
            this.xAntiGrief.Location = new System.Drawing.Point(18, 166);
            this.xAntiGrief.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xAntiGrief.Name = "xAntiGrief";
            this.xAntiGrief.Size = new System.Drawing.Size(278, 24);
            this.xAntiGrief.TabIndex = 10;
            this.xAntiGrief.Text = "Enable grief / autoclicker detection";
            this.xAntiGrief.UseVisualStyleBackColor = true;
            // 
            // lAntiGrief2
            // 
            this.lAntiGrief2.AutoSize = true;
            this.lAntiGrief2.Location = new System.Drawing.Point(252, 208);
            this.lAntiGrief2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lAntiGrief2.Name = "lAntiGrief2";
            this.lAntiGrief2.Size = new System.Drawing.Size(70, 20);
            this.lAntiGrief2.TabIndex = 13;
            this.lAntiGrief2.Text = "blocks in";
            // 
            // xKickIdle
            // 
            this.xKickIdle.AutoSize = true;
            this.xKickIdle.Location = new System.Drawing.Point(18, 120);
            this.xKickIdle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xKickIdle.Name = "xKickIdle";
            this.xKickIdle.Size = new System.Drawing.Size(127, 24);
            this.xKickIdle.TabIndex = 7;
            this.xKickIdle.Text = "Kick if idle for";
            this.xKickIdle.UseVisualStyleBackColor = true;
            // 
            // nAntiGriefBlocks
            // 
            this.nAntiGriefBlocks.Location = new System.Drawing.Point(154, 205);
            this.nAntiGriefBlocks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nAntiGriefBlocks.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nAntiGriefBlocks.Name = "nAntiGriefBlocks";
            this.nAntiGriefBlocks.Size = new System.Drawing.Size(88, 26);
            this.nAntiGriefBlocks.TabIndex = 12;
            // 
            // xReserveSlot
            // 
            this.xReserveSlot.AutoSize = true;
            this.xReserveSlot.Location = new System.Drawing.Point(18, 78);
            this.xReserveSlot.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xReserveSlot.Name = "xReserveSlot";
            this.xReserveSlot.Size = new System.Drawing.Size(169, 24);
            this.xReserveSlot.TabIndex = 4;
            this.xReserveSlot.Text = "Reserve player slot";
            this.xReserveSlot.UseVisualStyleBackColor = true;
            // 
            // tPrefix
            // 
            this.tPrefix.Enabled = false;
            this.tPrefix.Location = new System.Drawing.Point(418, 31);
            this.tPrefix.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tPrefix.MaxLength = 1;
            this.tPrefix.Name = "tPrefix";
            this.tPrefix.Size = new System.Drawing.Size(31, 26);
            this.tPrefix.TabIndex = 3;
            // 
            // lPrefix
            // 
            this.lPrefix.AutoSize = true;
            this.lPrefix.Enabled = false;
            this.lPrefix.Location = new System.Drawing.Point(352, 35);
            this.lPrefix.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lPrefix.Name = "lPrefix";
            this.lPrefix.Size = new System.Drawing.Size(48, 20);
            this.lPrefix.TabIndex = 2;
            this.lPrefix.Text = "Prefix";
            // 
            // lRankColor
            // 
            this.lRankColor.AutoSize = true;
            this.lRankColor.Location = new System.Drawing.Point(238, 80);
            this.lRankColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lRankColor.Name = "lRankColor";
            this.lRankColor.Size = new System.Drawing.Size(46, 20);
            this.lRankColor.TabIndex = 5;
            this.lRankColor.Text = "Color";
            // 
            // tRankName
            // 
            this.tRankName.Location = new System.Drawing.Point(93, 31);
            this.tRankName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tRankName.MaxLength = 16;
            this.tRankName.Name = "tRankName";
            this.tRankName.Size = new System.Drawing.Size(212, 26);
            this.tRankName.TabIndex = 1;
            // 
            // lRankName
            // 
            this.lRankName.AutoSize = true;
            this.lRankName.Location = new System.Drawing.Point(22, 35);
            this.lRankName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lRankName.Name = "lRankName";
            this.lRankName.Size = new System.Drawing.Size(51, 20);
            this.lRankName.TabIndex = 0;
            this.lRankName.Text = "Name";
            // 
            // bDeleteRank
            // 
            this.bDeleteRank.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bDeleteRank.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bDeleteRank.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.bDeleteRank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bDeleteRank.Location = new System.Drawing.Point(137, 121);
            this.bDeleteRank.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bDeleteRank.Name = "bDeleteRank";
            this.bDeleteRank.Size = new System.Drawing.Size(105, 35);
            this.bDeleteRank.TabIndex = 13;
            this.bDeleteRank.Text = "Delete";
            this.bDeleteRank.UseVisualStyleBackColor = false;
            // 
            // vPermissions
            // 
            this.vPermissions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vPermissions.CheckBoxes = true;
            this.vPermissions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chPermissions});
            this.vPermissions.GridLines = true;
            this.vPermissions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.vPermissions.Location = new System.Drawing.Point(724, 121);
            this.vPermissions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.vPermissions.MultiSelect = false;
            this.vPermissions.Name = "vPermissions";
            this.vPermissions.ShowGroups = false;
            this.vPermissions.ShowItemToolTips = true;
            this.vPermissions.Size = new System.Drawing.Size(254, 704);
            this.vPermissions.TabIndex = 19;
            this.vPermissions.UseCompatibleStateImageBehavior = false;
            this.vPermissions.View = System.Windows.Forms.View.Details;
            // 
            // chPermissions
            // 
            this.chPermissions.Width = 150;
            // 
            // bAddRank
            // 
            this.bAddRank.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bAddRank.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bAddRank.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.bAddRank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAddRank.Location = new System.Drawing.Point(24, 121);
            this.bAddRank.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bAddRank.Name = "bAddRank";
            this.bAddRank.Size = new System.Drawing.Size(105, 35);
            this.bAddRank.TabIndex = 12;
            this.bAddRank.Text = "Add Rank";
            this.bAddRank.UseVisualStyleBackColor = false;
            // 
            // lPermissions
            // 
            this.lPermissions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lPermissions.AutoSize = true;
            this.lPermissions.Location = new System.Drawing.Point(720, 96);
            this.lPermissions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lPermissions.Name = "lPermissions";
            this.lPermissions.Size = new System.Drawing.Size(136, 20);
            this.lPermissions.TabIndex = 18;
            this.lPermissions.Text = "Rank Permissions";
            // 
            // vRanks
            // 
            this.vRanks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.vRanks.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vRanks.FormattingEnabled = true;
            this.vRanks.IntegralHeight = false;
            this.vRanks.ItemHeight = 23;
            this.vRanks.Location = new System.Drawing.Point(26, 166);
            this.vRanks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.vRanks.Name = "vRanks";
            this.vRanks.Size = new System.Drawing.Size(217, 659);
            this.vRanks.TabIndex = 11;
            // 
            // bResetTab
            // 
            this.bResetTab.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.bResetTab.Location = new System.Drawing.Point(836, 833);
            this.bResetTab.Name = "bResetTab";
            this.bResetTab.Size = new System.Drawing.Size(142, 37);
            this.bResetTab.TabIndex = 20;
            this.bResetTab.Text = "Reset";
            this.bResetTab.UseSelectable = true;
            // 
            // RankConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 881);
            this.Controls.Add(this.bResetTab);
            this.Controls.Add(this.gPermissionLimits);
            this.Controls.Add(this.lRankList);
            this.Controls.Add(this.bLowerRank);
            this.Controls.Add(this.bRaiseRank);
            this.Controls.Add(this.gRankOptions);
            this.Controls.Add(this.bDeleteRank);
            this.Controls.Add(this.vPermissions);
            this.Controls.Add(this.bAddRank);
            this.Controls.Add(this.lPermissions);
            this.Controls.Add(this.vRanks);
            this.Name = "RankConfig";
            this.Style = MetroFramework.MetroColorStyle.Yellow;
            this.Text = "GemsCraft Configuration - Ranks";
            this.gPermissionLimits.ResumeLayout(false);
            this.gRankOptions.ResumeLayout(false);
            this.gRankOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nFillLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCopyPasteSlots)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nAntiGriefSeconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDrawLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nKickIdle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nAntiGriefBlocks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox gPermissionLimits;
        internal System.Windows.Forms.FlowLayoutPanel permissionLimitBoxContainer;
        internal System.Windows.Forms.Label lRankList;
        internal System.Windows.Forms.Button bLowerRank;
        internal System.Windows.Forms.Button bRaiseRank;
        internal System.Windows.Forms.GroupBox gRankOptions;
        internal System.Windows.Forms.Label lFillLimitUnits;
        internal System.Windows.Forms.NumericUpDown nFillLimit;
        internal System.Windows.Forms.Label lFillLimit;
        internal System.Windows.Forms.NumericUpDown nCopyPasteSlots;
        internal System.Windows.Forms.Label lCopyPasteSlots;
        internal System.Windows.Forms.CheckBox xAllowSecurityCircumvention;
        internal System.Windows.Forms.Label lAntiGrief1;
        internal System.Windows.Forms.Label lAntiGrief3;
        internal System.Windows.Forms.NumericUpDown nAntiGriefSeconds;
        internal System.Windows.Forms.Button bColorRank;
        internal System.Windows.Forms.CheckBox xDrawLimit;
        internal System.Windows.Forms.Label lDrawLimitUnits;
        internal System.Windows.Forms.Label lKickIdleUnits;
        internal System.Windows.Forms.NumericUpDown nDrawLimit;
        internal System.Windows.Forms.NumericUpDown nKickIdle;
        internal System.Windows.Forms.CheckBox xAntiGrief;
        internal System.Windows.Forms.Label lAntiGrief2;
        internal System.Windows.Forms.CheckBox xKickIdle;
        internal System.Windows.Forms.NumericUpDown nAntiGriefBlocks;
        internal System.Windows.Forms.CheckBox xReserveSlot;
        internal System.Windows.Forms.TextBox tPrefix;
        internal System.Windows.Forms.Label lPrefix;
        internal System.Windows.Forms.Label lRankColor;
        internal System.Windows.Forms.TextBox tRankName;
        internal System.Windows.Forms.Label lRankName;
        internal System.Windows.Forms.Button bDeleteRank;
        internal System.Windows.Forms.ListView vPermissions;
        internal System.Windows.Forms.ColumnHeader chPermissions;
        internal System.Windows.Forms.Button bAddRank;
        internal System.Windows.Forms.Label lPermissions;
        internal System.Windows.Forms.ListBox vRanks;
        internal MetroFramework.Controls.MetroButton bResetTab;
    }
}