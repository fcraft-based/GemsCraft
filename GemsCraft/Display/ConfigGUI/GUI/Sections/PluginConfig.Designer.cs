namespace GemsCraft.Display.ConfigGUI.GUI.Sections
{
    partial class PluginConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginConfig));
            this.bResetTab = new MetroFramework.Controls.MetroButton();
            this.picBackground = new System.Windows.Forms.PictureBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.propertyGrid3 = new System.Windows.Forms.PropertyGrid();
            this.listPlugins = new System.Windows.Forms.ListBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // bResetTab
            // 
            this.bResetTab.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.bResetTab.Location = new System.Drawing.Point(558, 538);
            this.bResetTab.Margin = new System.Windows.Forms.Padding(2);
            this.bResetTab.Name = "bResetTab";
            this.bResetTab.Size = new System.Drawing.Size(95, 24);
            this.bResetTab.TabIndex = 8;
            this.bResetTab.Text = "Reset";
            this.bResetTab.UseSelectable = true;
            // 
            // picBackground
            // 
            this.picBackground.Image = global::GemsCraft.Properties.Resources.Red;
            this.picBackground.Location = new System.Drawing.Point(0, 55);
            this.picBackground.Name = "picBackground";
            this.picBackground.Size = new System.Drawing.Size(671, 518);
            this.picBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBackground.TabIndex = 9;
            this.picBackground.TabStop = false;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.groupBox9);
            this.groupBox8.Controls.Add(this.listPlugins);
            this.groupBox8.Controls.Add(this.checkBox2);
            this.groupBox8.Location = new System.Drawing.Point(16, 63);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(637, 470);
            this.groupBox8.TabIndex = 10;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Plugins";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.propertyGrid3);
            this.groupBox9.Location = new System.Drawing.Point(284, 46);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(340, 418);
            this.groupBox9.TabIndex = 6;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Properties";
            // 
            // propertyGrid3
            // 
            this.propertyGrid3.Location = new System.Drawing.Point(6, 20);
            this.propertyGrid3.Name = "propertyGrid3";
            this.propertyGrid3.Size = new System.Drawing.Size(328, 392);
            this.propertyGrid3.TabIndex = 0;
            // 
            // listPlugins
            // 
            this.listPlugins.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listPlugins.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listPlugins.FormattingEnabled = true;
            this.listPlugins.IntegralHeight = false;
            this.listPlugins.ItemHeight = 11;
            this.listPlugins.Location = new System.Drawing.Point(7, 46);
            this.listPlugins.Name = "listPlugins";
            this.listPlugins.Size = new System.Drawing.Size(271, 418);
            this.listPlugins.TabIndex = 2;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(7, 21);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(96, 17);
            this.checkBox2.TabIndex = 0;
            this.checkBox2.Text = "Enable Plugins";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // PluginConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 570);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.bResetTab);
            this.Controls.Add(this.picBackground);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PluginConfig";
            this.Padding = new System.Windows.Forms.Padding(13, 60, 13, 13);
            this.Style = MetroFramework.MetroColorStyle.Brown;
            this.Text = "GemsCraft Configuration - Plugins";
            this.Load += new System.EventHandler(this.PluginConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        internal MetroFramework.Controls.MetroButton bResetTab;
        internal System.Windows.Forms.PictureBox picBackground;
        internal System.Windows.Forms.GroupBox groupBox8;
        internal System.Windows.Forms.GroupBox groupBox9;
        internal System.Windows.Forms.PropertyGrid propertyGrid3;
        internal System.Windows.Forms.ListBox listPlugins;
        internal System.Windows.Forms.CheckBox checkBox2;
    }
}