namespace GemsCraft.GUI.ConfigGUI.GUI.Sections
{
    partial class WorldConfig
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorldConfig));
            this.xWoMEnableEnvExtensions = new System.Windows.Forms.CheckBox();
            this.bMapPath = new System.Windows.Forms.Button();
            this.xMapPath = new System.Windows.Forms.CheckBox();
            this.tMapPath = new System.Windows.Forms.TextBox();
            this.lDefaultBuildRank = new System.Windows.Forms.Label();
            this.cDefaultBuildRank = new System.Windows.Forms.ComboBox();
            this.cMainWorld = new System.Windows.Forms.ComboBox();
            this.lMainWorld = new System.Windows.Forms.Label();
            this.bWorldEdit = new System.Windows.Forms.Button();
            this.bAddWorld = new System.Windows.Forms.Button();
            this.bWorldDelete = new System.Windows.Forms.Button();
            this.dgvWorlds = new System.Windows.Forms.DataGridView();
            this.dgvcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcAccess = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvcBuild = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvcBackup = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvcHidden = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvcBlockDB = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bResetTab = new MetroFramework.Controls.MetroButton();
            this.picBackground = new System.Windows.Forms.PictureBox();
            this.chkTexturePack = new System.Windows.Forms.CheckBox();
            this.txtTextureMapPath = new System.Windows.Forms.TextBox();
            this.btnBrowsePack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorlds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // xWoMEnableEnvExtensions
            // 
            this.xWoMEnableEnvExtensions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.xWoMEnableEnvExtensions.AutoSize = true;
            this.xWoMEnableEnvExtensions.BackColor = System.Drawing.Color.Transparent;
            this.xWoMEnableEnvExtensions.Location = new System.Drawing.Point(442, 447);
            this.xWoMEnableEnvExtensions.Name = "xWoMEnableEnvExtensions";
            this.xWoMEnableEnvExtensions.Size = new System.Drawing.Size(168, 17);
            this.xWoMEnableEnvExtensions.TabIndex = 34;
            this.xWoMEnableEnvExtensions.Text = "Enable Env Extensions (/Env)";
            this.xWoMEnableEnvExtensions.UseVisualStyleBackColor = false;
            // 
            // bMapPath
            // 
            this.bMapPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bMapPath.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bMapPath.Enabled = false;
            this.bMapPath.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bMapPath.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.bMapPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bMapPath.Location = new System.Drawing.Point(595, 470);
            this.bMapPath.Name = "bMapPath";
            this.bMapPath.Size = new System.Drawing.Size(62, 23);
            this.bMapPath.TabIndex = 33;
            this.bMapPath.Text = "Browse";
            this.bMapPath.UseVisualStyleBackColor = false;
            // 
            // xMapPath
            // 
            this.xMapPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.xMapPath.AutoSize = true;
            this.xMapPath.BackColor = System.Drawing.Color.Transparent;
            this.xMapPath.Location = new System.Drawing.Point(16, 474);
            this.xMapPath.Name = "xMapPath";
            this.xMapPath.Size = new System.Drawing.Size(165, 17);
            this.xMapPath.TabIndex = 31;
            this.xMapPath.Text = "Custom path for storing maps:";
            this.xMapPath.UseVisualStyleBackColor = false;
            this.xMapPath.CheckedChanged += new System.EventHandler(this.xMapPath_CheckedChanged);
            // 
            // tMapPath
            // 
            this.tMapPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tMapPath.Enabled = false;
            this.tMapPath.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tMapPath.Location = new System.Drawing.Point(211, 474);
            this.tMapPath.Name = "tMapPath";
            this.tMapPath.Size = new System.Drawing.Size(378, 19);
            this.tMapPath.TabIndex = 32;
            // 
            // lDefaultBuildRank
            // 
            this.lDefaultBuildRank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lDefaultBuildRank.AutoSize = true;
            this.lDefaultBuildRank.BackColor = System.Drawing.Color.Transparent;
            this.lDefaultBuildRank.Location = new System.Drawing.Point(16, 447);
            this.lDefaultBuildRank.Name = "lDefaultBuildRank";
            this.lDefaultBuildRank.Size = new System.Drawing.Size(293, 13);
            this.lDefaultBuildRank.TabIndex = 29;
            this.lDefaultBuildRank.Text = "Default rank requirement for building on newly-loaded worlds:";
            // 
            // cDefaultBuildRank
            // 
            this.cDefaultBuildRank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cDefaultBuildRank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cDefaultBuildRank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cDefaultBuildRank.FormattingEnabled = true;
            this.cDefaultBuildRank.Location = new System.Drawing.Point(315, 447);
            this.cDefaultBuildRank.Name = "cDefaultBuildRank";
            this.cDefaultBuildRank.Size = new System.Drawing.Size(121, 21);
            this.cDefaultBuildRank.TabIndex = 30;
            // 
            // cMainWorld
            // 
            this.cMainWorld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cMainWorld.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cMainWorld.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cMainWorld.Location = new System.Drawing.Point(551, 68);
            this.cMainWorld.Name = "cMainWorld";
            this.cMainWorld.Size = new System.Drawing.Size(102, 21);
            this.cMainWorld.TabIndex = 28;
            // 
            // lMainWorld
            // 
            this.lMainWorld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lMainWorld.AutoSize = true;
            this.lMainWorld.Location = new System.Drawing.Point(475, 71);
            this.lMainWorld.Name = "lMainWorld";
            this.lMainWorld.Size = new System.Drawing.Size(61, 13);
            this.lMainWorld.TabIndex = 27;
            this.lMainWorld.Text = "Main world:";
            // 
            // bWorldEdit
            // 
            this.bWorldEdit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bWorldEdit.Enabled = false;
            this.bWorldEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bWorldEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.bWorldEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bWorldEdit.Location = new System.Drawing.Point(121, 62);
            this.bWorldEdit.Name = "bWorldEdit";
            this.bWorldEdit.Size = new System.Drawing.Size(100, 28);
            this.bWorldEdit.TabIndex = 25;
            this.bWorldEdit.Text = "Edit";
            this.bWorldEdit.UseVisualStyleBackColor = false;
            // 
            // bAddWorld
            // 
            this.bAddWorld.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bAddWorld.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bAddWorld.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.bAddWorld.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAddWorld.Location = new System.Drawing.Point(16, 62);
            this.bAddWorld.Name = "bAddWorld";
            this.bAddWorld.Size = new System.Drawing.Size(100, 28);
            this.bAddWorld.TabIndex = 24;
            this.bAddWorld.Text = "Add World";
            this.bAddWorld.UseVisualStyleBackColor = false;
            // 
            // bWorldDelete
            // 
            this.bWorldDelete.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bWorldDelete.Enabled = false;
            this.bWorldDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bWorldDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.bWorldDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bWorldDelete.Location = new System.Drawing.Point(227, 62);
            this.bWorldDelete.Name = "bWorldDelete";
            this.bWorldDelete.Size = new System.Drawing.Size(100, 28);
            this.bWorldDelete.TabIndex = 26;
            this.bWorldDelete.Text = "Delete World";
            this.bWorldDelete.UseVisualStyleBackColor = false;
            // 
            // dgvWorlds
            // 
            this.dgvWorlds.AllowUserToAddRows = false;
            this.dgvWorlds.AllowUserToDeleteRows = false;
            this.dgvWorlds.AllowUserToOrderColumns = true;
            this.dgvWorlds.AllowUserToResizeRows = false;
            this.dgvWorlds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvWorlds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorlds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcName,
            this.dgvcDescription,
            this.dgvcAccess,
            this.dgvcBuild,
            this.dgvcBackup,
            this.dgvcHidden,
            this.dgvcBlockDB});
            this.dgvWorlds.Location = new System.Drawing.Point(16, 97);
            this.dgvWorlds.MultiSelect = false;
            this.dgvWorlds.Name = "dgvWorlds";
            this.dgvWorlds.RowHeadersVisible = false;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.dgvWorlds.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvWorlds.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWorlds.Size = new System.Drawing.Size(636, 343);
            this.dgvWorlds.TabIndex = 23;
            // 
            // dgvcName
            // 
            this.dgvcName.DataPropertyName = "Name";
            this.dgvcName.HeaderText = "World Name";
            this.dgvcName.Name = "dgvcName";
            this.dgvcName.Width = 110;
            // 
            // dgvcDescription
            // 
            this.dgvcDescription.DataPropertyName = "Description";
            this.dgvcDescription.HeaderText = "";
            this.dgvcDescription.Name = "dgvcDescription";
            this.dgvcDescription.ReadOnly = true;
            this.dgvcDescription.Width = 130;
            // 
            // dgvcAccess
            // 
            this.dgvcAccess.DataPropertyName = "AccessPermission";
            this.dgvcAccess.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.dgvcAccess.HeaderText = "Access";
            this.dgvcAccess.Name = "dgvcAccess";
            this.dgvcAccess.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgvcBuild
            // 
            this.dgvcBuild.DataPropertyName = "BuildPermission";
            this.dgvcBuild.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.dgvcBuild.HeaderText = "Build";
            this.dgvcBuild.Name = "dgvcBuild";
            this.dgvcBuild.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgvcBackup
            // 
            this.dgvcBackup.DataPropertyName = "Backup";
            this.dgvcBackup.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.dgvcBackup.HeaderText = "Backup";
            this.dgvcBackup.Name = "dgvcBackup";
            this.dgvcBackup.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvcBackup.Width = 90;
            // 
            // dgvcHidden
            // 
            this.dgvcHidden.DataPropertyName = "Hidden";
            this.dgvcHidden.HeaderText = "Hide";
            this.dgvcHidden.Name = "dgvcHidden";
            this.dgvcHidden.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvcHidden.Width = 40;
            // 
            // dgvcBlockDB
            // 
            this.dgvcBlockDB.DataPropertyName = "BlockDBEnabled";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvcBlockDB.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvcBlockDB.HeaderText = "BlockDB";
            this.dgvcBlockDB.Name = "dgvcBlockDB";
            this.dgvcBlockDB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvcBlockDB.ThreeState = true;
            this.dgvcBlockDB.Width = 60;
            // 
            // bResetTab
            // 
            this.bResetTab.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.bResetTab.Location = new System.Drawing.Point(331, 62);
            this.bResetTab.Margin = new System.Windows.Forms.Padding(2);
            this.bResetTab.Name = "bResetTab";
            this.bResetTab.Size = new System.Drawing.Size(95, 28);
            this.bResetTab.TabIndex = 35;
            this.bResetTab.Text = "Reset";
            this.bResetTab.UseSelectable = true;
            // 
            // picBackground
            // 
            this.picBackground.Image = global::GemsCraft.Properties.Resources.Pink;
            this.picBackground.Location = new System.Drawing.Point(0, 55);
            this.picBackground.Name = "picBackground";
            this.picBackground.Size = new System.Drawing.Size(671, 478);
            this.picBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBackground.TabIndex = 36;
            this.picBackground.TabStop = false;
            // 
            // chkTexturePack
            // 
            this.chkTexturePack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkTexturePack.AutoSize = true;
            this.chkTexturePack.BackColor = System.Drawing.Color.Transparent;
            this.chkTexturePack.Location = new System.Drawing.Point(16, 499);
            this.chkTexturePack.Name = "chkTexturePack";
            this.chkTexturePack.Size = new System.Drawing.Size(128, 17);
            this.chkTexturePack.TabIndex = 37;
            this.chkTexturePack.Text = "Custom Texture Pack";
            this.chkTexturePack.UseVisualStyleBackColor = false;
            // 
            // txtTextureMapPath
            // 
            this.txtTextureMapPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTextureMapPath.Enabled = false;
            this.txtTextureMapPath.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTextureMapPath.Location = new System.Drawing.Point(211, 499);
            this.txtTextureMapPath.Name = "txtTextureMapPath";
            this.txtTextureMapPath.Size = new System.Drawing.Size(378, 19);
            this.txtTextureMapPath.TabIndex = 38;
            // 
            // btnBrowsePack
            // 
            this.btnBrowsePack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowsePack.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBrowsePack.Enabled = false;
            this.btnBrowsePack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnBrowsePack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnBrowsePack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowsePack.Location = new System.Drawing.Point(595, 495);
            this.btnBrowsePack.Name = "btnBrowsePack";
            this.btnBrowsePack.Size = new System.Drawing.Size(62, 23);
            this.btnBrowsePack.TabIndex = 39;
            this.btnBrowsePack.Text = "Browse";
            this.btnBrowsePack.UseVisualStyleBackColor = false;
            // 
            // WorldConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 528);
            this.Controls.Add(this.btnBrowsePack);
            this.Controls.Add(this.chkTexturePack);
            this.Controls.Add(this.txtTextureMapPath);
            this.Controls.Add(this.bResetTab);
            this.Controls.Add(this.xWoMEnableEnvExtensions);
            this.Controls.Add(this.bMapPath);
            this.Controls.Add(this.xMapPath);
            this.Controls.Add(this.tMapPath);
            this.Controls.Add(this.lDefaultBuildRank);
            this.Controls.Add(this.cDefaultBuildRank);
            this.Controls.Add(this.cMainWorld);
            this.Controls.Add(this.lMainWorld);
            this.Controls.Add(this.bWorldEdit);
            this.Controls.Add(this.bAddWorld);
            this.Controls.Add(this.bWorldDelete);
            this.Controls.Add(this.dgvWorlds);
            this.Controls.Add(this.picBackground);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "WorldConfig";
            this.Padding = new System.Windows.Forms.Padding(13, 60, 13, 13);
            this.Style = MetroFramework.MetroColorStyle.Magenta;
            this.Text = "GemsCraft Configuration - Worlds";
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorlds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.CheckBox xWoMEnableEnvExtensions;
        internal System.Windows.Forms.Button bMapPath;
        internal System.Windows.Forms.CheckBox xMapPath;
        internal System.Windows.Forms.TextBox tMapPath;
        internal System.Windows.Forms.Label lDefaultBuildRank;
        internal System.Windows.Forms.ComboBox cDefaultBuildRank;
        internal System.Windows.Forms.ComboBox cMainWorld;
        internal System.Windows.Forms.Label lMainWorld;
        internal System.Windows.Forms.Button bWorldEdit;
        internal System.Windows.Forms.Button bAddWorld;
        internal System.Windows.Forms.Button bWorldDelete;
        internal System.Windows.Forms.DataGridView dgvWorlds;
        internal System.Windows.Forms.DataGridViewTextBoxColumn dgvcName;
        internal System.Windows.Forms.DataGridViewTextBoxColumn dgvcDescription;
        internal System.Windows.Forms.DataGridViewComboBoxColumn dgvcAccess;
        internal System.Windows.Forms.DataGridViewComboBoxColumn dgvcBuild;
        internal System.Windows.Forms.DataGridViewComboBoxColumn dgvcBackup;
        internal System.Windows.Forms.DataGridViewCheckBoxColumn dgvcHidden;
        internal System.Windows.Forms.DataGridViewCheckBoxColumn dgvcBlockDB;
        internal MetroFramework.Controls.MetroButton bResetTab;
        private System.Windows.Forms.PictureBox picBackground;
        internal System.Windows.Forms.CheckBox chkTexturePack;
        internal System.Windows.Forms.TextBox txtTextureMapPath;
        internal System.Windows.Forms.Button btnBrowsePack;
    }
}