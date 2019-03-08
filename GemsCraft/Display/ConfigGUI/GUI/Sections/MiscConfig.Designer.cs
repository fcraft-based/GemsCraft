namespace GemsCraft.Display.ConfigGUI.GUI.Sections
{
    partial class MiscConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiscConfig));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.websiteURL = new System.Windows.Forms.TextBox();
            this.ReqsEditor = new System.Windows.Forms.Button();
            this.SwearEditor = new System.Windows.Forms.Button();
            this.MaxCapsValue = new System.Windows.Forms.NumericUpDown();
            this.MaxCaps = new System.Windows.Forms.Label();
            this.SwearBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CustomColor = new System.Windows.Forms.Button();
            this.CustomText = new System.Windows.Forms.Label();
            this.CustomName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CustomAliases = new System.Windows.Forms.TextBox();
            this.bResetTab = new MetroFramework.Controls.MetroButton();
            this.gboRemoteControl = new System.Windows.Forms.GroupBox();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.lblRemotePort = new System.Windows.Forms.Label();
            this.btnSetLogin = new System.Windows.Forms.Button();
            this.chkRequireLogin = new System.Windows.Forms.CheckBox();
            this.chkEnableRemoteControl = new System.Windows.Forms.CheckBox();
            this.picBackground = new System.Windows.Forms.PictureBox();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxCapsValue)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gboRemoteControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.websiteURL);
            this.groupBox3.Controls.Add(this.ReqsEditor);
            this.groupBox3.Controls.Add(this.SwearEditor);
            this.groupBox3.Controls.Add(this.MaxCapsValue);
            this.groupBox3.Controls.Add(this.MaxCaps);
            this.groupBox3.Controls.Add(this.SwearBox);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(16, 215);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(638, 141);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Other Configurations";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "WebsiteURL";
            // 
            // websiteURL
            // 
            this.websiteURL.Location = new System.Drawing.Point(110, 67);
            this.websiteURL.Name = "websiteURL";
            this.websiteURL.Size = new System.Drawing.Size(212, 20);
            this.websiteURL.TabIndex = 28;
            // 
            // ReqsEditor
            // 
            this.ReqsEditor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ReqsEditor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.ReqsEditor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.ReqsEditor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReqsEditor.Location = new System.Drawing.Point(442, 94);
            this.ReqsEditor.Name = "ReqsEditor";
            this.ReqsEditor.Size = new System.Drawing.Size(125, 23);
            this.ReqsEditor.TabIndex = 26;
            this.ReqsEditor.Text = "Edit Requirements";
            this.ReqsEditor.UseVisualStyleBackColor = false;
            // 
            // SwearEditor
            // 
            this.SwearEditor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SwearEditor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.SwearEditor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.SwearEditor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SwearEditor.Location = new System.Drawing.Point(442, 65);
            this.SwearEditor.Name = "SwearEditor";
            this.SwearEditor.Size = new System.Drawing.Size(125, 23);
            this.SwearEditor.TabIndex = 25;
            this.SwearEditor.Text = "Edit Profanity List";
            this.SwearEditor.UseVisualStyleBackColor = false;
            // 
            // MaxCapsValue
            // 
            this.MaxCapsValue.Location = new System.Drawing.Point(110, 32);
            this.MaxCapsValue.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.MaxCapsValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxCapsValue.Name = "MaxCapsValue";
            this.MaxCapsValue.Size = new System.Drawing.Size(75, 20);
            this.MaxCapsValue.TabIndex = 21;
            this.MaxCapsValue.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // MaxCaps
            // 
            this.MaxCaps.AutoSize = true;
            this.MaxCaps.Location = new System.Drawing.Point(10, 34);
            this.MaxCaps.Name = "MaxCaps";
            this.MaxCaps.Size = new System.Drawing.Size(78, 13);
            this.MaxCaps.TabIndex = 20;
            this.MaxCaps.Text = "Maximum Caps";
            // 
            // SwearBox
            // 
            this.SwearBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SwearBox.HideSelection = false;
            this.SwearBox.Location = new System.Drawing.Point(442, 34);
            this.SwearBox.MaxLength = 64;
            this.SwearBox.Name = "SwearBox";
            this.SwearBox.Size = new System.Drawing.Size(168, 20);
            this.SwearBox.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Word for swears to be replaced with: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.CustomColor);
            this.groupBox1.Controls.Add(this.CustomText);
            this.groupBox1.Controls.Add(this.CustomName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CustomAliases);
            this.groupBox1.Location = new System.Drawing.Point(16, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(638, 146);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Custom Chat Channel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Custom Chat Channel Command Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Help;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(450, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 52);
            this.label4.TabIndex = 25;
            this.label4.Text = "The name should be \r\nin this format: \r\n\'staffchat\'. No spaces or \r\nsymbols (inclu" +
    "ding \"/\")";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CustomColor
            // 
            this.CustomColor.BackColor = System.Drawing.Color.White;
            this.CustomColor.Location = new System.Drawing.Point(244, 62);
            this.CustomColor.Name = "CustomColor";
            this.CustomColor.Size = new System.Drawing.Size(100, 23);
            this.CustomColor.TabIndex = 15;
            this.CustomColor.UseVisualStyleBackColor = false;
            // 
            // CustomText
            // 
            this.CustomText.AutoSize = true;
            this.CustomText.Location = new System.Drawing.Point(82, 70);
            this.CustomText.Name = "CustomText";
            this.CustomText.Size = new System.Drawing.Size(136, 13);
            this.CustomText.TabIndex = 14;
            this.CustomText.Text = "Custom Chat Channel Color";
            // 
            // CustomName
            // 
            this.CustomName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomName.HideSelection = false;
            this.CustomName.Location = new System.Drawing.Point(246, 20);
            this.CustomName.MaxLength = 64;
            this.CustomName.Name = "CustomName";
            this.CustomName.Size = new System.Drawing.Size(212, 20);
            this.CustomName.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Custom Chat Channel Aliases";
            // 
            // CustomAliases
            // 
            this.CustomAliases.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomAliases.HideSelection = false;
            this.CustomAliases.Location = new System.Drawing.Point(244, 109);
            this.CustomAliases.MaxLength = 64;
            this.CustomAliases.Name = "CustomAliases";
            this.CustomAliases.Size = new System.Drawing.Size(212, 20);
            this.CustomAliases.TabIndex = 19;
            // 
            // bResetTab
            // 
            this.bResetTab.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.bResetTab.Location = new System.Drawing.Point(16, 455);
            this.bResetTab.Margin = new System.Windows.Forms.Padding(2);
            this.bResetTab.Name = "bResetTab";
            this.bResetTab.Size = new System.Drawing.Size(94, 24);
            this.bResetTab.TabIndex = 30;
            this.bResetTab.Text = "Reset";
            this.bResetTab.UseSelectable = true;
            this.bResetTab.Click += new System.EventHandler(this.bResetTab_Click);
            // 
            // gboRemoteControl
            // 
            this.gboRemoteControl.Controls.Add(this.numPort);
            this.gboRemoteControl.Controls.Add(this.lblRemotePort);
            this.gboRemoteControl.Controls.Add(this.btnSetLogin);
            this.gboRemoteControl.Controls.Add(this.chkRequireLogin);
            this.gboRemoteControl.Controls.Add(this.chkEnableRemoteControl);
            this.gboRemoteControl.Location = new System.Drawing.Point(16, 362);
            this.gboRemoteControl.Margin = new System.Windows.Forms.Padding(2);
            this.gboRemoteControl.Name = "gboRemoteControl";
            this.gboRemoteControl.Padding = new System.Windows.Forms.Padding(2);
            this.gboRemoteControl.Size = new System.Drawing.Size(321, 89);
            this.gboRemoteControl.TabIndex = 31;
            this.gboRemoteControl.TabStop = false;
            this.gboRemoteControl.Text = "Remote Control (Mobile)";
            this.gboRemoteControl.Visible = false;
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(35, 61);
            this.numPort.Margin = new System.Windows.Forms.Padding(2);
            this.numPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(90, 20);
            this.numPort.TabIndex = 35;
            this.numPort.ValueChanged += new System.EventHandler(this.numPort_ValueChanged);
            // 
            // lblRemotePort
            // 
            this.lblRemotePort.AutoSize = true;
            this.lblRemotePort.Location = new System.Drawing.Point(5, 63);
            this.lblRemotePort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRemotePort.Name = "lblRemotePort";
            this.lblRemotePort.Size = new System.Drawing.Size(26, 13);
            this.lblRemotePort.TabIndex = 34;
            this.lblRemotePort.Text = "Port";
            this.lblRemotePort.Click += new System.EventHandler(this.lblRemotePort_Click);
            // 
            // btnSetLogin
            // 
            this.btnSetLogin.Location = new System.Drawing.Point(166, 38);
            this.btnSetLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetLogin.Name = "btnSetLogin";
            this.btnSetLogin.Size = new System.Drawing.Size(79, 19);
            this.btnSetLogin.TabIndex = 33;
            this.btnSetLogin.Text = "Set Login";
            this.btnSetLogin.UseVisualStyleBackColor = true;
            this.btnSetLogin.Click += new System.EventHandler(this.btnSetLogin_Click);
            // 
            // chkRequireLogin
            // 
            this.chkRequireLogin.AutoSize = true;
            this.chkRequireLogin.Location = new System.Drawing.Point(5, 40);
            this.chkRequireLogin.Margin = new System.Windows.Forms.Padding(2);
            this.chkRequireLogin.Name = "chkRequireLogin";
            this.chkRequireLogin.Size = new System.Drawing.Size(158, 17);
            this.chkRequireLogin.TabIndex = 32;
            this.chkRequireLogin.Text = "Require Server Admin Login";
            this.chkRequireLogin.UseVisualStyleBackColor = true;
            this.chkRequireLogin.CheckedChanged += new System.EventHandler(this.chkRequireLogin_CheckedChanged);
            // 
            // chkEnableRemoteControl
            // 
            this.chkEnableRemoteControl.AutoSize = true;
            this.chkEnableRemoteControl.Location = new System.Drawing.Point(5, 18);
            this.chkEnableRemoteControl.Margin = new System.Windows.Forms.Padding(2);
            this.chkEnableRemoteControl.Name = "chkEnableRemoteControl";
            this.chkEnableRemoteControl.Size = new System.Drawing.Size(161, 17);
            this.chkEnableRemoteControl.TabIndex = 0;
            this.chkEnableRemoteControl.Text = "Enable remote server control";
            this.chkEnableRemoteControl.UseVisualStyleBackColor = true;
            this.chkEnableRemoteControl.CheckedChanged += new System.EventHandler(this.chkEnableRemoteControl_CheckedChanged);
            // 
            // picBackground
            // 
            this.picBackground.BackgroundImage = global::GemsCraft.Properties.Resources.Purple;
            this.picBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBackground.Location = new System.Drawing.Point(0, 55);
            this.picBackground.Name = "picBackground";
            this.picBackground.Size = new System.Drawing.Size(670, 433);
            this.picBackground.TabIndex = 32;
            this.picBackground.TabStop = false;
            // 
            // MiscConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 487);
            this.Controls.Add(this.gboRemoteControl);
            this.Controls.Add(this.bResetTab);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.picBackground);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MiscConfig";
            this.Padding = new System.Windows.Forms.Padding(14, 60, 14, 13);
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "GemsCraft Configuration - Misc";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxCapsValue)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gboRemoteControl.ResumeLayout(false);
            this.gboRemoteControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox websiteURL;
        internal System.Windows.Forms.Button ReqsEditor;
        internal System.Windows.Forms.Button SwearEditor;
        internal System.Windows.Forms.NumericUpDown MaxCapsValue;
        internal System.Windows.Forms.Label MaxCaps;
        internal System.Windows.Forms.TextBox SwearBox;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Button CustomColor;
        internal System.Windows.Forms.Label CustomText;
        internal System.Windows.Forms.TextBox CustomName;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox CustomAliases;
        internal MetroFramework.Controls.MetroButton bResetTab;
        private System.Windows.Forms.GroupBox gboRemoteControl;
        internal System.Windows.Forms.CheckBox chkRequireLogin;
        internal System.Windows.Forms.CheckBox chkEnableRemoteControl;
        internal System.Windows.Forms.Button btnSetLogin;
        internal System.Windows.Forms.NumericUpDown numPort;
        internal System.Windows.Forms.Label lblRemotePort;
        private System.Windows.Forms.PictureBox picBackground;
    }
}