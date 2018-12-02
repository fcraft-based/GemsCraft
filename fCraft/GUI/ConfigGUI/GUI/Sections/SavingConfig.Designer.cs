namespace fCraft.GUI.ConfigGUI.GUI.Sections
{
    partial class SavingConfig
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.bUpdate = new System.Windows.Forms.Button();
            this.checkUpdate = new System.Windows.Forms.CheckBox();
            this.gDataBackup = new System.Windows.Forms.GroupBox();
            this.xBackupDataOnStartup = new System.Windows.Forms.CheckBox();
            this.gSaving = new System.Windows.Forms.GroupBox();
            this.nSaveInterval = new System.Windows.Forms.NumericUpDown();
            this.lSaveIntervalUnits = new System.Windows.Forms.Label();
            this.xSaveInterval = new System.Windows.Forms.CheckBox();
            this.gBackups = new System.Windows.Forms.GroupBox();
            this.xBackupOnlyWhenChanged = new System.Windows.Forms.CheckBox();
            this.lMaxBackupSize = new System.Windows.Forms.Label();
            this.xMaxBackupSize = new System.Windows.Forms.CheckBox();
            this.nMaxBackupSize = new System.Windows.Forms.NumericUpDown();
            this.xMaxBackups = new System.Windows.Forms.CheckBox();
            this.xBackupOnStartup = new System.Windows.Forms.CheckBox();
            this.lMaxBackups = new System.Windows.Forms.Label();
            this.nMaxBackups = new System.Windows.Forms.NumericUpDown();
            this.nBackupInterval = new System.Windows.Forms.NumericUpDown();
            this.lBackupIntervalUnits = new System.Windows.Forms.Label();
            this.xBackupInterval = new System.Windows.Forms.CheckBox();
            this.xBackupOnJoin = new System.Windows.Forms.CheckBox();
            this.bResetTab = new MetroFramework.Controls.MetroButton();
            this.groupBox5.SuspendLayout();
            this.gDataBackup.SuspendLayout();
            this.gSaving.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSaveInterval)).BeginInit();
            this.gBackups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxBackupSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxBackups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nBackupInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.bUpdate);
            this.groupBox5.Controls.Add(this.checkUpdate);
            this.groupBox5.Location = new System.Drawing.Point(26, 528);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Size = new System.Drawing.Size(952, 83);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Update";
            // 
            // bUpdate
            // 
            this.bUpdate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.bUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bUpdate.Location = new System.Drawing.Point(332, 22);
            this.bUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(308, 43);
            this.bUpdate.TabIndex = 23;
            this.bUpdate.Text = "Manual Update Check";
            this.bUpdate.UseVisualStyleBackColor = false;
            // 
            // checkUpdate
            // 
            this.checkUpdate.AutoSize = true;
            this.checkUpdate.Location = new System.Drawing.Point(16, 31);
            this.checkUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkUpdate.Name = "checkUpdate";
            this.checkUpdate.Size = new System.Drawing.Size(266, 24);
            this.checkUpdate.TabIndex = 22;
            this.checkUpdate.Text = "Automatically Check for Updates";
            this.checkUpdate.UseVisualStyleBackColor = true;
            // 
            // gDataBackup
            // 
            this.gDataBackup.Controls.Add(this.xBackupDataOnStartup);
            this.gDataBackup.Location = new System.Drawing.Point(26, 439);
            this.gDataBackup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gDataBackup.Name = "gDataBackup";
            this.gDataBackup.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gDataBackup.Size = new System.Drawing.Size(954, 80);
            this.gDataBackup.TabIndex = 6;
            this.gDataBackup.TabStop = false;
            this.gDataBackup.Text = "Data Backup";
            // 
            // xBackupDataOnStartup
            // 
            this.xBackupDataOnStartup.AutoSize = true;
            this.xBackupDataOnStartup.Location = new System.Drawing.Point(24, 31);
            this.xBackupDataOnStartup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xBackupDataOnStartup.Name = "xBackupDataOnStartup";
            this.xBackupDataOnStartup.Size = new System.Drawing.Size(343, 24);
            this.xBackupDataOnStartup.TabIndex = 0;
            this.xBackupDataOnStartup.Text = "Backup PlayerDB and IP ban list on startup.";
            this.xBackupDataOnStartup.UseVisualStyleBackColor = true;
            // 
            // gSaving
            // 
            this.gSaving.Controls.Add(this.nSaveInterval);
            this.gSaving.Controls.Add(this.lSaveIntervalUnits);
            this.gSaving.Controls.Add(this.xSaveInterval);
            this.gSaving.Location = new System.Drawing.Point(26, 96);
            this.gSaving.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gSaving.Name = "gSaving";
            this.gSaving.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gSaving.Size = new System.Drawing.Size(954, 80);
            this.gSaving.TabIndex = 4;
            this.gSaving.TabStop = false;
            this.gSaving.Text = "Map Saving";
            // 
            // nSaveInterval
            // 
            this.nSaveInterval.Location = new System.Drawing.Point(204, 31);
            this.nSaveInterval.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nSaveInterval.Name = "nSaveInterval";
            this.nSaveInterval.Size = new System.Drawing.Size(72, 26);
            this.nSaveInterval.TabIndex = 1;
            // 
            // lSaveIntervalUnits
            // 
            this.lSaveIntervalUnits.AutoSize = true;
            this.lSaveIntervalUnits.Location = new System.Drawing.Point(285, 34);
            this.lSaveIntervalUnits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lSaveIntervalUnits.Name = "lSaveIntervalUnits";
            this.lSaveIntervalUnits.Size = new System.Drawing.Size(69, 20);
            this.lSaveIntervalUnits.TabIndex = 2;
            this.lSaveIntervalUnits.Text = "seconds";
            // 
            // xSaveInterval
            // 
            this.xSaveInterval.AutoSize = true;
            this.xSaveInterval.Location = new System.Drawing.Point(18, 32);
            this.xSaveInterval.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xSaveInterval.Name = "xSaveInterval";
            this.xSaveInterval.Size = new System.Drawing.Size(155, 24);
            this.xSaveInterval.TabIndex = 0;
            this.xSaveInterval.Text = "Save maps every";
            this.xSaveInterval.UseVisualStyleBackColor = true;
            // 
            // gBackups
            // 
            this.gBackups.Controls.Add(this.xBackupOnlyWhenChanged);
            this.gBackups.Controls.Add(this.lMaxBackupSize);
            this.gBackups.Controls.Add(this.xMaxBackupSize);
            this.gBackups.Controls.Add(this.nMaxBackupSize);
            this.gBackups.Controls.Add(this.xMaxBackups);
            this.gBackups.Controls.Add(this.xBackupOnStartup);
            this.gBackups.Controls.Add(this.lMaxBackups);
            this.gBackups.Controls.Add(this.nMaxBackups);
            this.gBackups.Controls.Add(this.nBackupInterval);
            this.gBackups.Controls.Add(this.lBackupIntervalUnits);
            this.gBackups.Controls.Add(this.xBackupInterval);
            this.gBackups.Controls.Add(this.xBackupOnJoin);
            this.gBackups.Location = new System.Drawing.Point(26, 186);
            this.gBackups.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gBackups.Name = "gBackups";
            this.gBackups.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gBackups.Size = new System.Drawing.Size(954, 243);
            this.gBackups.TabIndex = 5;
            this.gBackups.TabStop = false;
            this.gBackups.Text = "Map Backups";
            // 
            // xBackupOnlyWhenChanged
            // 
            this.xBackupOnlyWhenChanged.AutoSize = true;
            this.xBackupOnlyWhenChanged.Location = new System.Drawing.Point(554, 71);
            this.xBackupOnlyWhenChanged.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xBackupOnlyWhenChanged.Name = "xBackupOnlyWhenChanged";
            this.xBackupOnlyWhenChanged.Size = new System.Drawing.Size(337, 24);
            this.xBackupOnlyWhenChanged.TabIndex = 4;
            this.xBackupOnlyWhenChanged.Text = "Skip timed backups if map hasn\'t changed.";
            this.xBackupOnlyWhenChanged.UseVisualStyleBackColor = true;
            // 
            // lMaxBackupSize
            // 
            this.lMaxBackupSize.AutoSize = true;
            this.lMaxBackupSize.Location = new System.Drawing.Point(627, 191);
            this.lMaxBackupSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lMaxBackupSize.Name = "lMaxBackupSize";
            this.lMaxBackupSize.Size = new System.Drawing.Size(134, 20);
            this.lMaxBackupSize.TabIndex = 11;
            this.lMaxBackupSize.Text = "MB of disk space.";
            // 
            // xMaxBackupSize
            // 
            this.xMaxBackupSize.AutoSize = true;
            this.xMaxBackupSize.Location = new System.Drawing.Point(24, 189);
            this.xMaxBackupSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xMaxBackupSize.Name = "xMaxBackupSize";
            this.xMaxBackupSize.Size = new System.Drawing.Size(415, 24);
            this.xMaxBackupSize.TabIndex = 9;
            this.xMaxBackupSize.Text = "Delete old backups if the directory takes up more than";
            this.xMaxBackupSize.UseVisualStyleBackColor = true;
            // 
            // nMaxBackupSize
            // 
            this.nMaxBackupSize.Location = new System.Drawing.Point(508, 188);
            this.nMaxBackupSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nMaxBackupSize.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nMaxBackupSize.Name = "nMaxBackupSize";
            this.nMaxBackupSize.Size = new System.Drawing.Size(110, 26);
            this.nMaxBackupSize.TabIndex = 10;
            // 
            // xMaxBackups
            // 
            this.xMaxBackups.AutoSize = true;
            this.xMaxBackups.Location = new System.Drawing.Point(24, 151);
            this.xMaxBackups.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xMaxBackups.Name = "xMaxBackups";
            this.xMaxBackups.Size = new System.Drawing.Size(327, 24);
            this.xMaxBackups.TabIndex = 6;
            this.xMaxBackups.Text = "Delete old backups if there are more than";
            this.xMaxBackups.UseVisualStyleBackColor = true;
            // 
            // xBackupOnStartup
            // 
            this.xBackupOnStartup.AutoSize = true;
            this.xBackupOnStartup.Enabled = false;
            this.xBackupOnStartup.Location = new System.Drawing.Point(24, 31);
            this.xBackupOnStartup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xBackupOnStartup.Name = "xBackupOnStartup";
            this.xBackupOnStartup.Size = new System.Drawing.Size(223, 24);
            this.xBackupOnStartup.TabIndex = 0;
            this.xBackupOnStartup.Text = "Create backups on startup";
            this.xBackupOnStartup.UseVisualStyleBackColor = true;
            // 
            // lMaxBackups
            // 
            this.lMaxBackups.AutoSize = true;
            this.lMaxBackups.Location = new System.Drawing.Point(504, 152);
            this.lMaxBackups.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lMaxBackups.Name = "lMaxBackups";
            this.lMaxBackups.Size = new System.Drawing.Size(204, 20);
            this.lMaxBackups.TabIndex = 8;
            this.lMaxBackups.Text = "files in the backup directory.";
            // 
            // nMaxBackups
            // 
            this.nMaxBackups.Location = new System.Drawing.Point(410, 149);
            this.nMaxBackups.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nMaxBackups.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nMaxBackups.Name = "nMaxBackups";
            this.nMaxBackups.Size = new System.Drawing.Size(86, 26);
            this.nMaxBackups.TabIndex = 7;
            // 
            // nBackupInterval
            // 
            this.nBackupInterval.Location = new System.Drawing.Point(246, 69);
            this.nBackupInterval.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nBackupInterval.Name = "nBackupInterval";
            this.nBackupInterval.Size = new System.Drawing.Size(72, 26);
            this.nBackupInterval.TabIndex = 2;
            // 
            // lBackupIntervalUnits
            // 
            this.lBackupIntervalUnits.AutoSize = true;
            this.lBackupIntervalUnits.Location = new System.Drawing.Point(327, 72);
            this.lBackupIntervalUnits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lBackupIntervalUnits.Name = "lBackupIntervalUnits";
            this.lBackupIntervalUnits.Size = new System.Drawing.Size(65, 20);
            this.lBackupIntervalUnits.TabIndex = 3;
            this.lBackupIntervalUnits.Text = "minutes";
            // 
            // xBackupInterval
            // 
            this.xBackupInterval.AutoSize = true;
            this.xBackupInterval.Location = new System.Drawing.Point(24, 71);
            this.xBackupInterval.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xBackupInterval.Name = "xBackupInterval";
            this.xBackupInterval.Size = new System.Drawing.Size(188, 24);
            this.xBackupInterval.TabIndex = 1;
            this.xBackupInterval.Text = "Create backups every";
            this.xBackupInterval.UseVisualStyleBackColor = true;
            // 
            // xBackupOnJoin
            // 
            this.xBackupOnJoin.AutoSize = true;
            this.xBackupOnJoin.Location = new System.Drawing.Point(24, 111);
            this.xBackupOnJoin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xBackupOnJoin.Name = "xBackupOnJoin";
            this.xBackupOnJoin.Size = new System.Drawing.Size(360, 24);
            this.xBackupOnJoin.TabIndex = 5;
            this.xBackupOnJoin.Text = "Create backup whenever a player joins a world";
            this.xBackupOnJoin.UseVisualStyleBackColor = true;
            // 
            // bResetTab
            // 
            this.bResetTab.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.bResetTab.Location = new System.Drawing.Point(836, 619);
            this.bResetTab.Name = "bResetTab";
            this.bResetTab.Size = new System.Drawing.Size(142, 37);
            this.bResetTab.TabIndex = 8;
            this.bResetTab.Text = "Reset";
            this.bResetTab.UseSelectable = true;
            // 
            // SavingConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 663);
            this.Controls.Add(this.bResetTab);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.gDataBackup);
            this.Controls.Add(this.gSaving);
            this.Controls.Add(this.gBackups);
            this.Name = "SavingConfig";
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Text = "GemsCraft Configuration - Saving and Backup";
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.gDataBackup.ResumeLayout(false);
            this.gDataBackup.PerformLayout();
            this.gSaving.ResumeLayout(false);
            this.gSaving.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSaveInterval)).EndInit();
            this.gBackups.ResumeLayout(false);
            this.gBackups.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxBackupSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxBackups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nBackupInterval)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox groupBox5;
        internal System.Windows.Forms.Button bUpdate;
        internal System.Windows.Forms.CheckBox checkUpdate;
        internal System.Windows.Forms.GroupBox gDataBackup;
        internal System.Windows.Forms.CheckBox xBackupDataOnStartup;
        internal System.Windows.Forms.GroupBox gSaving;
        internal System.Windows.Forms.NumericUpDown nSaveInterval;
        internal System.Windows.Forms.Label lSaveIntervalUnits;
        internal System.Windows.Forms.CheckBox xSaveInterval;
        internal System.Windows.Forms.GroupBox gBackups;
        internal System.Windows.Forms.CheckBox xBackupOnlyWhenChanged;
        internal System.Windows.Forms.Label lMaxBackupSize;
        internal System.Windows.Forms.CheckBox xMaxBackupSize;
        internal System.Windows.Forms.NumericUpDown nMaxBackupSize;
        internal System.Windows.Forms.CheckBox xMaxBackups;
        internal System.Windows.Forms.CheckBox xBackupOnStartup;
        internal System.Windows.Forms.Label lMaxBackups;
        internal System.Windows.Forms.NumericUpDown nMaxBackups;
        internal System.Windows.Forms.NumericUpDown nBackupInterval;
        internal System.Windows.Forms.Label lBackupIntervalUnits;
        internal System.Windows.Forms.CheckBox xBackupInterval;
        internal System.Windows.Forms.CheckBox xBackupOnJoin;
        internal MetroFramework.Controls.MetroButton bResetTab;
    }
}