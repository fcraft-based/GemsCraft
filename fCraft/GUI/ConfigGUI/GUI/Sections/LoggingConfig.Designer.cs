namespace GemsCraft.GUI.ConfigGUI.GUI.Sections
{
    partial class LoggingConfig
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
            this.gLogFile = new System.Windows.Forms.GroupBox();
            this.lLogFileOptionsDescription = new System.Windows.Forms.Label();
            this.xLogLimit = new System.Windows.Forms.CheckBox();
            this.vLogFileOptions = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lLogLimitUnits = new System.Windows.Forms.Label();
            this.nLogLimit = new System.Windows.Forms.NumericUpDown();
            this.cLogMode = new System.Windows.Forms.ComboBox();
            this.lLogMode = new System.Windows.Forms.Label();
            this.gConsole = new System.Windows.Forms.GroupBox();
            this.lLogConsoleOptionsDescription = new System.Windows.Forms.Label();
            this.vConsoleOptions = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bResetTab = new MetroFramework.Controls.MetroButton();
            this.gLogFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nLogLimit)).BeginInit();
            this.gConsole.SuspendLayout();
            this.SuspendLayout();
            // 
            // gLogFile
            // 
            this.gLogFile.BackColor = System.Drawing.Color.Transparent;
            this.gLogFile.Controls.Add(this.lLogFileOptionsDescription);
            this.gLogFile.Controls.Add(this.xLogLimit);
            this.gLogFile.Controls.Add(this.vLogFileOptions);
            this.gLogFile.Controls.Add(this.lLogLimitUnits);
            this.gLogFile.Controls.Add(this.nLogLimit);
            this.gLogFile.Controls.Add(this.cLogMode);
            this.gLogFile.Controls.Add(this.lLogMode);
            this.gLogFile.Location = new System.Drawing.Point(508, 96);
            this.gLogFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gLogFile.Name = "gLogFile";
            this.gLogFile.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gLogFile.Size = new System.Drawing.Size(472, 651);
            this.gLogFile.TabIndex = 3;
            this.gLogFile.TabStop = false;
            this.gLogFile.Text = "Log File";
            // 
            // lLogFileOptionsDescription
            // 
            this.lLogFileOptionsDescription.AutoSize = true;
            this.lLogFileOptionsDescription.Location = new System.Drawing.Point(40, 34);
            this.lLogFileOptionsDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lLogFileOptionsDescription.Name = "lLogFileOptionsDescription";
            this.lLogFileOptionsDescription.Size = new System.Drawing.Size(275, 40);
            this.lLogFileOptionsDescription.TabIndex = 0;
            this.lLogFileOptionsDescription.Text = "Types of messages that will be written\r\nto the log file on disk.";
            // 
            // xLogLimit
            // 
            this.xLogLimit.AutoSize = true;
            this.xLogLimit.Enabled = false;
            this.xLogLimit.Location = new System.Drawing.Point(27, 600);
            this.xLogLimit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xLogLimit.Name = "xLogLimit";
            this.xLogLimit.Size = new System.Drawing.Size(105, 24);
            this.xLogLimit.TabIndex = 4;
            this.xLogLimit.Text = "Only keep";
            this.xLogLimit.UseVisualStyleBackColor = true;
            // 
            // vLogFileOptions
            // 
            this.vLogFileOptions.CheckBoxes = true;
            this.vLogFileOptions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.vLogFileOptions.GridLines = true;
            this.vLogFileOptions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.vLogFileOptions.Location = new System.Drawing.Point(117, 91);
            this.vLogFileOptions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.vLogFileOptions.Name = "vLogFileOptions";
            this.vLogFileOptions.ShowItemToolTips = true;
            this.vLogFileOptions.Size = new System.Drawing.Size(240, 450);
            this.vLogFileOptions.TabIndex = 1;
            this.vLogFileOptions.UseCompatibleStateImageBehavior = false;
            this.vLogFileOptions.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 157;
            // 
            // lLogLimitUnits
            // 
            this.lLogLimitUnits.AutoSize = true;
            this.lLogLimitUnits.Location = new System.Drawing.Point(249, 602);
            this.lLogLimitUnits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lLogLimitUnits.Name = "lLogLimitUnits";
            this.lLogLimitUnits.Size = new System.Drawing.Size(168, 20);
            this.lLogLimitUnits.TabIndex = 6;
            this.lLogLimitUnits.Text = "of most recent log files";
            // 
            // nLogLimit
            // 
            this.nLogLimit.Enabled = false;
            this.nLogLimit.Location = new System.Drawing.Point(156, 598);
            this.nLogLimit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nLogLimit.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nLogLimit.Name = "nLogLimit";
            this.nLogLimit.Size = new System.Drawing.Size(84, 26);
            this.nLogLimit.TabIndex = 5;
            // 
            // cLogMode
            // 
            this.cLogMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cLogMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cLogMode.FormattingEnabled = true;
            this.cLogMode.Items.AddRange(new object[] {
            "One long file",
            "Multiple files, split by session",
            "Multiple files, split by day"});
            this.cLogMode.Location = new System.Drawing.Point(156, 554);
            this.cLogMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cLogMode.Name = "cLogMode";
            this.cLogMode.Size = new System.Drawing.Size(276, 28);
            this.cLogMode.TabIndex = 3;
            // 
            // lLogMode
            // 
            this.lLogMode.AutoSize = true;
            this.lLogMode.Location = new System.Drawing.Point(52, 558);
            this.lLogMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lLogMode.Name = "lLogMode";
            this.lLogMode.Size = new System.Drawing.Size(80, 20);
            this.lLogMode.TabIndex = 2;
            this.lLogMode.Text = "Log mode";
            // 
            // gConsole
            // 
            this.gConsole.Controls.Add(this.lLogConsoleOptionsDescription);
            this.gConsole.Controls.Add(this.vConsoleOptions);
            this.gConsole.Location = new System.Drawing.Point(25, 96);
            this.gConsole.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gConsole.Name = "gConsole";
            this.gConsole.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gConsole.Size = new System.Drawing.Size(472, 651);
            this.gConsole.TabIndex = 2;
            this.gConsole.TabStop = false;
            this.gConsole.Text = "Console";
            // 
            // lLogConsoleOptionsDescription
            // 
            this.lLogConsoleOptionsDescription.AutoSize = true;
            this.lLogConsoleOptionsDescription.Location = new System.Drawing.Point(14, 32);
            this.lLogConsoleOptionsDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lLogConsoleOptionsDescription.Name = "lLogConsoleOptionsDescription";
            this.lLogConsoleOptionsDescription.Size = new System.Drawing.Size(275, 40);
            this.lLogConsoleOptionsDescription.TabIndex = 0;
            this.lLogConsoleOptionsDescription.Text = "Types of messages that will be written\r\ndirectly to console.";
            // 
            // vConsoleOptions
            // 
            this.vConsoleOptions.CheckBoxes = true;
            this.vConsoleOptions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.vConsoleOptions.GridLines = true;
            this.vConsoleOptions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.vConsoleOptions.Location = new System.Drawing.Point(114, 91);
            this.vConsoleOptions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.vConsoleOptions.Name = "vConsoleOptions";
            this.vConsoleOptions.ShowItemToolTips = true;
            this.vConsoleOptions.Size = new System.Drawing.Size(240, 450);
            this.vConsoleOptions.TabIndex = 1;
            this.vConsoleOptions.UseCompatibleStateImageBehavior = false;
            this.vConsoleOptions.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 157;
            // 
            // bResetTab
            // 
            this.bResetTab.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.bResetTab.Location = new System.Drawing.Point(838, 755);
            this.bResetTab.Name = "bResetTab";
            this.bResetTab.Size = new System.Drawing.Size(142, 37);
            this.bResetTab.TabIndex = 7;
            this.bResetTab.Text = "Reset";
            this.bResetTab.UseSelectable = true;
            // 
            // LoggingConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 803);
            this.Controls.Add(this.bResetTab);
            this.Controls.Add(this.gLogFile);
            this.Controls.Add(this.gConsole);
            this.Name = "LoggingConfig";
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "GemsCraft Configuration - Logging";
            this.gLogFile.ResumeLayout(false);
            this.gLogFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nLogLimit)).EndInit();
            this.gConsole.ResumeLayout(false);
            this.gConsole.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox gLogFile;
        internal System.Windows.Forms.Label lLogFileOptionsDescription;
        internal System.Windows.Forms.CheckBox xLogLimit;
        internal System.Windows.Forms.ListView vLogFileOptions;
        internal System.Windows.Forms.ColumnHeader columnHeader2;
        internal System.Windows.Forms.Label lLogLimitUnits;
        internal System.Windows.Forms.NumericUpDown nLogLimit;
        internal System.Windows.Forms.ComboBox cLogMode;
        internal System.Windows.Forms.Label lLogMode;
        internal System.Windows.Forms.GroupBox gConsole;
        internal System.Windows.Forms.Label lLogConsoleOptionsDescription;
        internal System.Windows.Forms.ListView vConsoleOptions;
        internal System.Windows.Forms.ColumnHeader columnHeader3;
        internal MetroFramework.Controls.MetroButton bResetTab;
    }
}