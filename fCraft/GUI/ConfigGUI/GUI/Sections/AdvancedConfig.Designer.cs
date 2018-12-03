namespace GemsCraft.GUI.ConfigGUI.GUI.Sections
{
    partial class AdvancedConfig
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
            this.gPerformance = new System.Windows.Forms.GroupBox();
            this.lAdvancedWarning = new System.Windows.Forms.Label();
            this.xLowLatencyMode = new System.Windows.Forms.CheckBox();
            this.lProcessPriority = new System.Windows.Forms.Label();
            this.cProcessPriority = new System.Windows.Forms.ComboBox();
            this.nTickInterval = new System.Windows.Forms.NumericUpDown();
            this.lTickIntervalUnits = new System.Windows.Forms.Label();
            this.lTickInterval = new System.Windows.Forms.Label();
            this.nThrottling = new System.Windows.Forms.NumericUpDown();
            this.lThrottling = new System.Windows.Forms.Label();
            this.lThrottlingUnits = new System.Windows.Forms.Label();
            this.gAdvancedMisc = new System.Windows.Forms.GroupBox();
            this.xAutoRank = new System.Windows.Forms.CheckBox();
            this.nMaxUndoStates = new System.Windows.Forms.NumericUpDown();
            this.lMaxUndoStates = new System.Windows.Forms.Label();
            this.lIPWarning = new System.Windows.Forms.Label();
            this.tIP = new System.Windows.Forms.TextBox();
            this.xIP = new System.Windows.Forms.CheckBox();
            this.lConsoleName = new System.Windows.Forms.Label();
            this.tConsoleName = new System.Windows.Forms.TextBox();
            this.nMaxUndo = new System.Windows.Forms.NumericUpDown();
            this.lMaxUndoUnits = new System.Windows.Forms.Label();
            this.xMaxUndo = new System.Windows.Forms.CheckBox();
            this.xRelayAllBlockUpdates = new System.Windows.Forms.CheckBox();
            this.xNoPartialPositionUpdates = new System.Windows.Forms.CheckBox();
            this.gCrashReport = new System.Windows.Forms.GroupBox();
            this.xCrash = new System.Windows.Forms.CheckBox();
            this.lCrashReportDisclaimer = new System.Windows.Forms.Label();
            this.bResetTab = new MetroFramework.Controls.MetroButton();
            this.gPerformance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nTickInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nThrottling)).BeginInit();
            this.gAdvancedMisc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxUndoStates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxUndo)).BeginInit();
            this.gCrashReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // gPerformance
            // 
            this.gPerformance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gPerformance.Controls.Add(this.lAdvancedWarning);
            this.gPerformance.Controls.Add(this.xLowLatencyMode);
            this.gPerformance.Controls.Add(this.lProcessPriority);
            this.gPerformance.Controls.Add(this.cProcessPriority);
            this.gPerformance.Controls.Add(this.nTickInterval);
            this.gPerformance.Controls.Add(this.lTickIntervalUnits);
            this.gPerformance.Controls.Add(this.lTickInterval);
            this.gPerformance.Controls.Add(this.nThrottling);
            this.gPerformance.Controls.Add(this.lThrottling);
            this.gPerformance.Controls.Add(this.lThrottlingUnits);
            this.gPerformance.Location = new System.Drawing.Point(26, 568);
            this.gPerformance.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gPerformance.Name = "gPerformance";
            this.gPerformance.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gPerformance.Size = new System.Drawing.Size(954, 224);
            this.gPerformance.TabIndex = 5;
            this.gPerformance.TabStop = false;
            this.gPerformance.Text = "Performance";
            // 
            // lAdvancedWarning
            // 
            this.lAdvancedWarning.AutoSize = true;
            this.lAdvancedWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAdvancedWarning.Location = new System.Drawing.Point(22, 32);
            this.lAdvancedWarning.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lAdvancedWarning.Name = "lAdvancedWarning";
            this.lAdvancedWarning.Size = new System.Drawing.Size(785, 44);
            this.lAdvancedWarning.TabIndex = 0;
            this.lAdvancedWarning.Text = "Warning: Altering these settings may decrease your server\'s stability and perform" +
    "ance.\r\nIf you\'re not sure what these settings do, you probably shouldn\'t change " +
    "them...";
            // 
            // xLowLatencyMode
            // 
            this.xLowLatencyMode.AutoSize = true;
            this.xLowLatencyMode.Location = new System.Drawing.Point(9, 98);
            this.xLowLatencyMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xLowLatencyMode.Name = "xLowLatencyMode";
            this.xLowLatencyMode.Size = new System.Drawing.Size(697, 24);
            this.xLowLatencyMode.TabIndex = 3;
            this.xLowLatencyMode.Text = "Low-latency mode (disables Nagle\'s algorithm, reducing latency but increasing ban" +
    "dwidth use).";
            this.xLowLatencyMode.UseVisualStyleBackColor = true;
            // 
            // lProcessPriority
            // 
            this.lProcessPriority.AutoSize = true;
            this.lProcessPriority.Location = new System.Drawing.Point(28, 145);
            this.lProcessPriority.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lProcessPriority.Name = "lProcessPriority";
            this.lProcessPriority.Size = new System.Drawing.Size(116, 20);
            this.lProcessPriority.TabIndex = 10;
            this.lProcessPriority.Text = "Process priority";
            // 
            // cProcessPriority
            // 
            this.cProcessPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cProcessPriority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cProcessPriority.Items.AddRange(new object[] {
            "(system default)",
            "High",
            "Above Normal",
            "Normal",
            "Below Normal",
            "Low"});
            this.cProcessPriority.Location = new System.Drawing.Point(172, 140);
            this.cProcessPriority.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cProcessPriority.Name = "cProcessPriority";
            this.cProcessPriority.Size = new System.Drawing.Size(162, 28);
            this.cProcessPriority.TabIndex = 11;
            // 
            // nTickInterval
            // 
            this.nTickInterval.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nTickInterval.Location = new System.Drawing.Point(644, 142);
            this.nTickInterval.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nTickInterval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nTickInterval.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nTickInterval.Name = "nTickInterval";
            this.nTickInterval.Size = new System.Drawing.Size(105, 26);
            this.nTickInterval.TabIndex = 13;
            this.nTickInterval.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lTickIntervalUnits
            // 
            this.lTickIntervalUnits.AutoSize = true;
            this.lTickIntervalUnits.Location = new System.Drawing.Point(758, 145);
            this.lTickIntervalUnits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lTickIntervalUnits.Name = "lTickIntervalUnits";
            this.lTickIntervalUnits.Size = new System.Drawing.Size(30, 20);
            this.lTickIntervalUnits.TabIndex = 14;
            this.lTickIntervalUnits.Text = "ms";
            // 
            // lTickInterval
            // 
            this.lTickInterval.AutoSize = true;
            this.lTickInterval.Location = new System.Drawing.Point(528, 145);
            this.lTickInterval.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lTickInterval.Name = "lTickInterval";
            this.lTickInterval.Size = new System.Drawing.Size(91, 20);
            this.lTickInterval.TabIndex = 12;
            this.lTickInterval.Text = "Tick interval";
            // 
            // nThrottling
            // 
            this.nThrottling.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nThrottling.Location = new System.Drawing.Point(172, 185);
            this.nThrottling.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nThrottling.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nThrottling.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nThrottling.Name = "nThrottling";
            this.nThrottling.Size = new System.Drawing.Size(105, 26);
            this.nThrottling.TabIndex = 16;
            this.nThrottling.Value = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            // 
            // lThrottling
            // 
            this.lThrottling.AutoSize = true;
            this.lThrottling.Location = new System.Drawing.Point(33, 188);
            this.lThrottling.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lThrottling.Name = "lThrottling";
            this.lThrottling.Size = new System.Drawing.Size(114, 20);
            this.lThrottling.TabIndex = 15;
            this.lThrottling.Text = "Block throttling";
            // 
            // lThrottlingUnits
            // 
            this.lThrottlingUnits.AutoSize = true;
            this.lThrottlingUnits.Location = new System.Drawing.Point(286, 188);
            this.lThrottlingUnits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lThrottlingUnits.Name = "lThrottlingUnits";
            this.lThrottlingUnits.Size = new System.Drawing.Size(167, 20);
            this.lThrottlingUnits.TabIndex = 17;
            this.lThrottlingUnits.Text = "blocks / second / client";
            // 
            // gAdvancedMisc
            // 
            this.gAdvancedMisc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gAdvancedMisc.Controls.Add(this.xAutoRank);
            this.gAdvancedMisc.Controls.Add(this.nMaxUndoStates);
            this.gAdvancedMisc.Controls.Add(this.lMaxUndoStates);
            this.gAdvancedMisc.Controls.Add(this.lIPWarning);
            this.gAdvancedMisc.Controls.Add(this.tIP);
            this.gAdvancedMisc.Controls.Add(this.xIP);
            this.gAdvancedMisc.Controls.Add(this.lConsoleName);
            this.gAdvancedMisc.Controls.Add(this.tConsoleName);
            this.gAdvancedMisc.Controls.Add(this.nMaxUndo);
            this.gAdvancedMisc.Controls.Add(this.lMaxUndoUnits);
            this.gAdvancedMisc.Controls.Add(this.xMaxUndo);
            this.gAdvancedMisc.Controls.Add(this.xRelayAllBlockUpdates);
            this.gAdvancedMisc.Controls.Add(this.xNoPartialPositionUpdates);
            this.gAdvancedMisc.Location = new System.Drawing.Point(27, 229);
            this.gAdvancedMisc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gAdvancedMisc.Name = "gAdvancedMisc";
            this.gAdvancedMisc.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gAdvancedMisc.Size = new System.Drawing.Size(954, 328);
            this.gAdvancedMisc.TabIndex = 4;
            this.gAdvancedMisc.TabStop = false;
            this.gAdvancedMisc.Text = "Miscellaneous";
            // 
            // xAutoRank
            // 
            this.xAutoRank.AutoSize = true;
            this.xAutoRank.Location = new System.Drawing.Point(14, 289);
            this.xAutoRank.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xAutoRank.Name = "xAutoRank";
            this.xAutoRank.Size = new System.Drawing.Size(161, 24);
            this.xAutoRank.TabIndex = 24;
            this.xAutoRank.Text = "Enable AutoRank";
            this.xAutoRank.UseVisualStyleBackColor = true;
            // 
            // nMaxUndoStates
            // 
            this.nMaxUndoStates.Location = new System.Drawing.Point(172, 109);
            this.nMaxUndoStates.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nMaxUndoStates.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nMaxUndoStates.Name = "nMaxUndoStates";
            this.nMaxUndoStates.Size = new System.Drawing.Size(87, 26);
            this.nMaxUndoStates.TabIndex = 23;
            this.nMaxUndoStates.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lMaxUndoStates
            // 
            this.lMaxUndoStates.AutoSize = true;
            this.lMaxUndoStates.Location = new System.Drawing.Point(268, 112);
            this.lMaxUndoStates.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lMaxUndoStates.Name = "lMaxUndoStates";
            this.lMaxUndoStates.Size = new System.Drawing.Size(97, 20);
            this.lMaxUndoStates.TabIndex = 22;
            this.lMaxUndoStates.Text = "states, up to";
            // 
            // lIPWarning
            // 
            this.lIPWarning.AutoSize = true;
            this.lIPWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lIPWarning.Location = new System.Drawing.Point(168, 202);
            this.lIPWarning.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lIPWarning.Name = "lIPWarning";
            this.lIPWarning.Size = new System.Drawing.Size(642, 20);
            this.lIPWarning.TabIndex = 20;
            this.lIPWarning.Text = "Note: You do not need to specify an IP address unless you have multiple NICs or I" +
    "Ps.";
            // 
            // tIP
            // 
            this.tIP.Location = new System.Drawing.Point(172, 165);
            this.tIP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tIP.MaxLength = 15;
            this.tIP.Name = "tIP";
            this.tIP.Size = new System.Drawing.Size(144, 26);
            this.tIP.TabIndex = 19;
            // 
            // xIP
            // 
            this.xIP.AutoSize = true;
            this.xIP.Location = new System.Drawing.Point(9, 168);
            this.xIP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xIP.Name = "xIP";
            this.xIP.Size = new System.Drawing.Size(136, 24);
            this.xIP.TabIndex = 18;
            this.xIP.Text = "Designated IP";
            this.xIP.UseVisualStyleBackColor = true;
            // 
            // lConsoleName
            // 
            this.lConsoleName.AutoSize = true;
            this.lConsoleName.Location = new System.Drawing.Point(9, 248);
            this.lConsoleName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lConsoleName.Name = "lConsoleName";
            this.lConsoleName.Size = new System.Drawing.Size(111, 20);
            this.lConsoleName.TabIndex = 7;
            this.lConsoleName.Text = "Console name";
            // 
            // tConsoleName
            // 
            this.tConsoleName.Location = new System.Drawing.Point(172, 243);
            this.tConsoleName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tConsoleName.Name = "tConsoleName";
            this.tConsoleName.Size = new System.Drawing.Size(248, 26);
            this.tConsoleName.TabIndex = 8;
            // 
            // nMaxUndo
            // 
            this.nMaxUndo.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nMaxUndo.Location = new System.Drawing.Point(386, 109);
            this.nMaxUndo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nMaxUndo.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nMaxUndo.Name = "nMaxUndo";
            this.nMaxUndo.Size = new System.Drawing.Size(129, 26);
            this.nMaxUndo.TabIndex = 5;
            this.nMaxUndo.Value = new decimal(new int[] {
            2000000,
            0,
            0,
            0});
            // 
            // lMaxUndoUnits
            // 
            this.lMaxUndoUnits.AutoSize = true;
            this.lMaxUndoUnits.Location = new System.Drawing.Point(524, 112);
            this.lMaxUndoUnits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lMaxUndoUnits.Name = "lMaxUndoUnits";
            this.lMaxUndoUnits.Size = new System.Drawing.Size(337, 20);
            this.lMaxUndoUnits.TabIndex = 6;
            this.lMaxUndoUnits.Text = "blocks each (up to 16.0 MB of RAM per player)";
            // 
            // xMaxUndo
            // 
            this.xMaxUndo.AutoSize = true;
            this.xMaxUndo.Checked = true;
            this.xMaxUndo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.xMaxUndo.Location = new System.Drawing.Point(9, 111);
            this.xMaxUndo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xMaxUndo.Name = "xMaxUndo";
            this.xMaxUndo.Size = new System.Drawing.Size(130, 24);
            this.xMaxUndo.TabIndex = 4;
            this.xMaxUndo.Text = "Limit /undo to";
            this.xMaxUndo.UseVisualStyleBackColor = true;
            // 
            // xRelayAllBlockUpdates
            // 
            this.xRelayAllBlockUpdates.AutoSize = true;
            this.xRelayAllBlockUpdates.Location = new System.Drawing.Point(9, 32);
            this.xRelayAllBlockUpdates.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xRelayAllBlockUpdates.Name = "xRelayAllBlockUpdates";
            this.xRelayAllBlockUpdates.Size = new System.Drawing.Size(725, 24);
            this.xRelayAllBlockUpdates.TabIndex = 1;
            this.xRelayAllBlockUpdates.Text = "When a player changes a block, send him the redundant update packet anyway (origi" +
    "nal behavior).";
            this.xRelayAllBlockUpdates.UseVisualStyleBackColor = true;
            // 
            // xNoPartialPositionUpdates
            // 
            this.xNoPartialPositionUpdates.AutoSize = true;
            this.xNoPartialPositionUpdates.Location = new System.Drawing.Point(9, 71);
            this.xNoPartialPositionUpdates.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xNoPartialPositionUpdates.Name = "xNoPartialPositionUpdates";
            this.xNoPartialPositionUpdates.Size = new System.Drawing.Size(425, 24);
            this.xNoPartialPositionUpdates.TabIndex = 2;
            this.xNoPartialPositionUpdates.Text = "Do not use partial position updates (opcodes 9, 10, 11).";
            this.xNoPartialPositionUpdates.UseVisualStyleBackColor = true;
            // 
            // gCrashReport
            // 
            this.gCrashReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gCrashReport.Controls.Add(this.xCrash);
            this.gCrashReport.Controls.Add(this.lCrashReportDisclaimer);
            this.gCrashReport.Location = new System.Drawing.Point(27, 96);
            this.gCrashReport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gCrashReport.Name = "gCrashReport";
            this.gCrashReport.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gCrashReport.Size = new System.Drawing.Size(954, 123);
            this.gCrashReport.TabIndex = 3;
            this.gCrashReport.TabStop = false;
            this.gCrashReport.Text = "Crash Reporting";
            // 
            // xCrash
            // 
            this.xCrash.AutoSize = true;
            this.xCrash.Location = new System.Drawing.Point(38, 38);
            this.xCrash.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xCrash.Name = "xCrash";
            this.xCrash.Size = new System.Drawing.Size(22, 21);
            this.xCrash.TabIndex = 2;
            this.xCrash.UseVisualStyleBackColor = true;
            // 
            // lCrashReportDisclaimer
            // 
            this.lCrashReportDisclaimer.AutoSize = true;
            this.lCrashReportDisclaimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCrashReportDisclaimer.Location = new System.Drawing.Point(68, 40);
            this.lCrashReportDisclaimer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lCrashReportDisclaimer.Name = "lCrashReportDisclaimer";
            this.lCrashReportDisclaimer.Size = new System.Drawing.Size(748, 60);
            this.lCrashReportDisclaimer.TabIndex = 1;
            this.lCrashReportDisclaimer.Text = "Send all Crash Reports To The Developer\r\nCrash reports are when serious unexpecte" +
    "d errors occur. Being able to receive crash reports helps\r\nidentify bugs and imp" +
    "rove GemsCraft!";
            // 
            // bResetTab
            // 
            this.bResetTab.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.bResetTab.Location = new System.Drawing.Point(840, 800);
            this.bResetTab.Name = "bResetTab";
            this.bResetTab.Size = new System.Drawing.Size(141, 37);
            this.bResetTab.TabIndex = 6;
            this.bResetTab.Text = "Reset";
            this.bResetTab.UseSelectable = true;
            // 
            // AdvancedConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 854);
            this.Controls.Add(this.bResetTab);
            this.Controls.Add(this.gPerformance);
            this.Controls.Add(this.gAdvancedMisc);
            this.Controls.Add(this.gCrashReport);
            this.Name = "AdvancedConfig";
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Text = "GemsCraft Configuration - Advanced";
            this.gPerformance.ResumeLayout(false);
            this.gPerformance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nTickInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nThrottling)).EndInit();
            this.gAdvancedMisc.ResumeLayout(false);
            this.gAdvancedMisc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxUndoStates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxUndo)).EndInit();
            this.gCrashReport.ResumeLayout(false);
            this.gCrashReport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox gPerformance;
        internal System.Windows.Forms.Label lAdvancedWarning;
        internal System.Windows.Forms.CheckBox xLowLatencyMode;
        internal System.Windows.Forms.Label lProcessPriority;
        internal System.Windows.Forms.ComboBox cProcessPriority;
        internal System.Windows.Forms.NumericUpDown nTickInterval;
        internal System.Windows.Forms.Label lTickIntervalUnits;
        internal System.Windows.Forms.Label lTickInterval;
        internal System.Windows.Forms.NumericUpDown nThrottling;
        internal System.Windows.Forms.Label lThrottling;
        internal System.Windows.Forms.Label lThrottlingUnits;
        internal System.Windows.Forms.GroupBox gAdvancedMisc;
        internal System.Windows.Forms.CheckBox xAutoRank;
        internal System.Windows.Forms.NumericUpDown nMaxUndoStates;
        internal System.Windows.Forms.Label lMaxUndoStates;
        internal System.Windows.Forms.Label lIPWarning;
        internal System.Windows.Forms.TextBox tIP;
        internal System.Windows.Forms.CheckBox xIP;
        internal System.Windows.Forms.Label lConsoleName;
        internal System.Windows.Forms.TextBox tConsoleName;
        internal System.Windows.Forms.NumericUpDown nMaxUndo;
        internal System.Windows.Forms.Label lMaxUndoUnits;
        internal System.Windows.Forms.CheckBox xMaxUndo;
        internal System.Windows.Forms.CheckBox xRelayAllBlockUpdates;
        internal System.Windows.Forms.CheckBox xNoPartialPositionUpdates;
        internal System.Windows.Forms.GroupBox gCrashReport;
        internal System.Windows.Forms.CheckBox xCrash;
        internal System.Windows.Forms.Label lCrashReportDisclaimer;
        internal MetroFramework.Controls.MetroButton bResetTab;
    }
}