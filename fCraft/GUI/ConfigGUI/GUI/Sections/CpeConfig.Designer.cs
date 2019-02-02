namespace GemsCraft.GUI.ConfigGUI.GUI.Sections
{
    partial class CpeConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CpeConfig));
            this.bResetTab = new MetroFramework.Controls.MetroButton();
            this.gboMessageType = new System.Windows.Forms.GroupBox();
            this.txtStatus1 = new MetroFramework.Controls.MetroTextBox();
            this.txtStatus2 = new MetroFramework.Controls.MetroTextBox();
            this.txtStatus3 = new MetroFramework.Controls.MetroTextBox();
            this.txtBR3 = new MetroFramework.Controls.MetroTextBox();
            this.txtBR2 = new MetroFramework.Controls.MetroTextBox();
            this.txtBR1 = new MetroFramework.Controls.MetroTextBox();
            this.chkBR1 = new MetroFramework.Controls.MetroCheckBox();
            this.chkBR2 = new MetroFramework.Controls.MetroCheckBox();
            this.chkBR3 = new MetroFramework.Controls.MetroCheckBox();
            this.chkStatus3 = new MetroFramework.Controls.MetroCheckBox();
            this.chkStatus2 = new MetroFramework.Controls.MetroCheckBox();
            this.chkStatus1 = new MetroFramework.Controls.MetroCheckBox();
            this.chkShowAnnouncements = new MetroFramework.Controls.MetroCheckBox();
            this.chkEnableMessageTypes = new MetroFramework.Controls.MetroCheckBox();
            this.lblMTInformation = new MetroFramework.Controls.MetroLabel();
            this.gboCustomBlocks = new System.Windows.Forms.GroupBox();
            this.btnDefineNewBlock = new System.Windows.Forms.Button();
            this.picBackground = new System.Windows.Forms.PictureBox();
            this.gboClickDistance = new System.Windows.Forms.GroupBox();
            this.numMaxDistance = new System.Windows.Forms.NumericUpDown();
            this.lblMaxDistance = new MetroFramework.Controls.MetroLabel();
            this.numMinDistance = new System.Windows.Forms.NumericUpDown();
            this.lblMinDistance = new MetroFramework.Controls.MetroLabel();
            this.chkEnableClickDistance = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.gboHeldBlock = new System.Windows.Forms.GroupBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.chkEnableHeldBlock = new MetroFramework.Controls.MetroCheckBox();
            this.gboMessageType.SuspendLayout();
            this.gboCustomBlocks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).BeginInit();
            this.gboClickDistance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinDistance)).BeginInit();
            this.gboHeldBlock.SuspendLayout();
            this.SuspendLayout();
            // 
            // bResetTab
            // 
            this.bResetTab.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.bResetTab.Location = new System.Drawing.Point(559, 363);
            this.bResetTab.Margin = new System.Windows.Forms.Padding(2);
            this.bResetTab.Name = "bResetTab";
            this.bResetTab.Size = new System.Drawing.Size(94, 24);
            this.bResetTab.TabIndex = 30;
            this.bResetTab.Text = "Reset";
            this.bResetTab.UseSelectable = true;
            this.bResetTab.Click += new System.EventHandler(this.bResetTab_Click);
            // 
            // gboMessageType
            // 
            this.gboMessageType.Controls.Add(this.txtStatus1);
            this.gboMessageType.Controls.Add(this.txtStatus2);
            this.gboMessageType.Controls.Add(this.txtStatus3);
            this.gboMessageType.Controls.Add(this.txtBR3);
            this.gboMessageType.Controls.Add(this.txtBR2);
            this.gboMessageType.Controls.Add(this.txtBR1);
            this.gboMessageType.Controls.Add(this.chkBR1);
            this.gboMessageType.Controls.Add(this.chkBR2);
            this.gboMessageType.Controls.Add(this.chkBR3);
            this.gboMessageType.Controls.Add(this.chkStatus3);
            this.gboMessageType.Controls.Add(this.chkStatus2);
            this.gboMessageType.Controls.Add(this.chkStatus1);
            this.gboMessageType.Controls.Add(this.chkShowAnnouncements);
            this.gboMessageType.Controls.Add(this.chkEnableMessageTypes);
            this.gboMessageType.Controls.Add(this.lblMTInformation);
            this.gboMessageType.Location = new System.Drawing.Point(16, 63);
            this.gboMessageType.Name = "gboMessageType";
            this.gboMessageType.Size = new System.Drawing.Size(354, 314);
            this.gboMessageType.TabIndex = 28;
            this.gboMessageType.TabStop = false;
            this.gboMessageType.Text = "Message Types";
            // 
            // txtStatus1
            // 
            // 
            // 
            // 
            this.txtStatus1.CustomButton.Image = null;
            this.txtStatus1.CustomButton.Location = new System.Drawing.Point(117, 1);
            this.txtStatus1.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtStatus1.CustomButton.Name = "";
            this.txtStatus1.CustomButton.Size = new System.Drawing.Size(17, 17);
            this.txtStatus1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtStatus1.CustomButton.TabIndex = 1;
            this.txtStatus1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtStatus1.CustomButton.UseSelectable = true;
            this.txtStatus1.CustomButton.Visible = false;
            this.txtStatus1.Lines = new string[] {
        "metroTextBox6"};
            this.txtStatus1.Location = new System.Drawing.Point(207, 158);
            this.txtStatus1.Margin = new System.Windows.Forms.Padding(2);
            this.txtStatus1.MaxLength = 32767;
            this.txtStatus1.Name = "txtStatus1";
            this.txtStatus1.PasswordChar = '\0';
            this.txtStatus1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtStatus1.SelectedText = "";
            this.txtStatus1.SelectionLength = 0;
            this.txtStatus1.SelectionStart = 0;
            this.txtStatus1.ShortcutsEnabled = true;
            this.txtStatus1.Size = new System.Drawing.Size(135, 19);
            this.txtStatus1.TabIndex = 45;
            this.txtStatus1.Text = "metroTextBox6";
            this.txtStatus1.UseSelectable = true;
            this.txtStatus1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtStatus1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtStatus2
            // 
            // 
            // 
            // 
            this.txtStatus2.CustomButton.Image = null;
            this.txtStatus2.CustomButton.Location = new System.Drawing.Point(117, 1);
            this.txtStatus2.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtStatus2.CustomButton.Name = "";
            this.txtStatus2.CustomButton.Size = new System.Drawing.Size(17, 17);
            this.txtStatus2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtStatus2.CustomButton.TabIndex = 1;
            this.txtStatus2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtStatus2.CustomButton.UseSelectable = true;
            this.txtStatus2.CustomButton.Visible = false;
            this.txtStatus2.Lines = new string[] {
        "metroTextBox5"};
            this.txtStatus2.Location = new System.Drawing.Point(207, 182);
            this.txtStatus2.Margin = new System.Windows.Forms.Padding(2);
            this.txtStatus2.MaxLength = 32767;
            this.txtStatus2.Name = "txtStatus2";
            this.txtStatus2.PasswordChar = '\0';
            this.txtStatus2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtStatus2.SelectedText = "";
            this.txtStatus2.SelectionLength = 0;
            this.txtStatus2.SelectionStart = 0;
            this.txtStatus2.ShortcutsEnabled = true;
            this.txtStatus2.Size = new System.Drawing.Size(135, 19);
            this.txtStatus2.TabIndex = 44;
            this.txtStatus2.Text = "metroTextBox5";
            this.txtStatus2.UseSelectable = true;
            this.txtStatus2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtStatus2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtStatus3
            // 
            // 
            // 
            // 
            this.txtStatus3.CustomButton.Image = null;
            this.txtStatus3.CustomButton.Location = new System.Drawing.Point(117, 1);
            this.txtStatus3.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtStatus3.CustomButton.Name = "";
            this.txtStatus3.CustomButton.Size = new System.Drawing.Size(17, 17);
            this.txtStatus3.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtStatus3.CustomButton.TabIndex = 1;
            this.txtStatus3.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtStatus3.CustomButton.UseSelectable = true;
            this.txtStatus3.CustomButton.Visible = false;
            this.txtStatus3.Lines = new string[] {
        "metroTextBox4"};
            this.txtStatus3.Location = new System.Drawing.Point(207, 205);
            this.txtStatus3.Margin = new System.Windows.Forms.Padding(2);
            this.txtStatus3.MaxLength = 32767;
            this.txtStatus3.Name = "txtStatus3";
            this.txtStatus3.PasswordChar = '\0';
            this.txtStatus3.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtStatus3.SelectedText = "";
            this.txtStatus3.SelectionLength = 0;
            this.txtStatus3.SelectionStart = 0;
            this.txtStatus3.ShortcutsEnabled = true;
            this.txtStatus3.Size = new System.Drawing.Size(135, 19);
            this.txtStatus3.TabIndex = 43;
            this.txtStatus3.Text = "metroTextBox4";
            this.txtStatus3.UseSelectable = true;
            this.txtStatus3.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtStatus3.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtBR3
            // 
            // 
            // 
            // 
            this.txtBR3.CustomButton.Image = null;
            this.txtBR3.CustomButton.Location = new System.Drawing.Point(117, 1);
            this.txtBR3.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtBR3.CustomButton.Name = "";
            this.txtBR3.CustomButton.Size = new System.Drawing.Size(17, 17);
            this.txtBR3.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBR3.CustomButton.TabIndex = 1;
            this.txtBR3.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBR3.CustomButton.UseSelectable = true;
            this.txtBR3.CustomButton.Visible = false;
            this.txtBR3.Lines = new string[] {
        "metroTextBox3"};
            this.txtBR3.Location = new System.Drawing.Point(207, 236);
            this.txtBR3.Margin = new System.Windows.Forms.Padding(2);
            this.txtBR3.MaxLength = 32767;
            this.txtBR3.Name = "txtBR3";
            this.txtBR3.PasswordChar = '\0';
            this.txtBR3.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBR3.SelectedText = "";
            this.txtBR3.SelectionLength = 0;
            this.txtBR3.SelectionStart = 0;
            this.txtBR3.ShortcutsEnabled = true;
            this.txtBR3.Size = new System.Drawing.Size(135, 19);
            this.txtBR3.TabIndex = 42;
            this.txtBR3.Text = "metroTextBox3";
            this.txtBR3.UseSelectable = true;
            this.txtBR3.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBR3.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtBR2
            // 
            // 
            // 
            // 
            this.txtBR2.CustomButton.Image = null;
            this.txtBR2.CustomButton.Location = new System.Drawing.Point(117, 1);
            this.txtBR2.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtBR2.CustomButton.Name = "";
            this.txtBR2.CustomButton.Size = new System.Drawing.Size(17, 17);
            this.txtBR2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBR2.CustomButton.TabIndex = 1;
            this.txtBR2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBR2.CustomButton.UseSelectable = true;
            this.txtBR2.CustomButton.Visible = false;
            this.txtBR2.Lines = new string[] {
        "metroTextBox2"};
            this.txtBR2.Location = new System.Drawing.Point(207, 260);
            this.txtBR2.Margin = new System.Windows.Forms.Padding(2);
            this.txtBR2.MaxLength = 32767;
            this.txtBR2.Name = "txtBR2";
            this.txtBR2.PasswordChar = '\0';
            this.txtBR2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBR2.SelectedText = "";
            this.txtBR2.SelectionLength = 0;
            this.txtBR2.SelectionStart = 0;
            this.txtBR2.ShortcutsEnabled = true;
            this.txtBR2.Size = new System.Drawing.Size(135, 19);
            this.txtBR2.TabIndex = 41;
            this.txtBR2.Text = "metroTextBox2";
            this.txtBR2.UseSelectable = true;
            this.txtBR2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBR2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtBR1
            // 
            // 
            // 
            // 
            this.txtBR1.CustomButton.Image = null;
            this.txtBR1.CustomButton.Location = new System.Drawing.Point(117, 1);
            this.txtBR1.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtBR1.CustomButton.Name = "";
            this.txtBR1.CustomButton.Size = new System.Drawing.Size(17, 17);
            this.txtBR1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBR1.CustomButton.TabIndex = 1;
            this.txtBR1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBR1.CustomButton.UseSelectable = true;
            this.txtBR1.CustomButton.Visible = false;
            this.txtBR1.Lines = new string[] {
        "metroTextBox1"};
            this.txtBR1.Location = new System.Drawing.Point(207, 283);
            this.txtBR1.Margin = new System.Windows.Forms.Padding(2);
            this.txtBR1.MaxLength = 32767;
            this.txtBR1.Name = "txtBR1";
            this.txtBR1.PasswordChar = '\0';
            this.txtBR1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBR1.SelectedText = "";
            this.txtBR1.SelectionLength = 0;
            this.txtBR1.SelectionStart = 0;
            this.txtBR1.ShortcutsEnabled = true;
            this.txtBR1.Size = new System.Drawing.Size(135, 19);
            this.txtBR1.TabIndex = 40;
            this.txtBR1.Text = "metroTextBox1";
            this.txtBR1.UseSelectable = true;
            this.txtBR1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBR1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // chkBR1
            // 
            this.chkBR1.AutoSize = true;
            this.chkBR1.Location = new System.Drawing.Point(6, 288);
            this.chkBR1.Margin = new System.Windows.Forms.Padding(2);
            this.chkBR1.Name = "chkBR1";
            this.chkBR1.Size = new System.Drawing.Size(202, 15);
            this.chkBR1.TabIndex = 39;
            this.chkBR1.Text = "Enable Bottom Right #1 Messages";
            this.chkBR1.UseSelectable = true;
            // 
            // chkBR2
            // 
            this.chkBR2.AutoSize = true;
            this.chkBR2.Location = new System.Drawing.Point(6, 265);
            this.chkBR2.Margin = new System.Windows.Forms.Padding(2);
            this.chkBR2.Name = "chkBR2";
            this.chkBR2.Size = new System.Drawing.Size(202, 15);
            this.chkBR2.TabIndex = 38;
            this.chkBR2.Text = "Enable Bottom Right #2 Messages";
            this.chkBR2.UseSelectable = true;
            // 
            // chkBR3
            // 
            this.chkBR3.AutoSize = true;
            this.chkBR3.Location = new System.Drawing.Point(6, 241);
            this.chkBR3.Margin = new System.Windows.Forms.Padding(2);
            this.chkBR3.Name = "chkBR3";
            this.chkBR3.Size = new System.Drawing.Size(202, 15);
            this.chkBR3.TabIndex = 37;
            this.chkBR3.Text = "Enable Bottom Right #3 Messages";
            this.chkBR3.UseSelectable = true;
            // 
            // chkStatus3
            // 
            this.chkStatus3.AutoSize = true;
            this.chkStatus3.Location = new System.Drawing.Point(6, 209);
            this.chkStatus3.Margin = new System.Windows.Forms.Padding(2);
            this.chkStatus3.Name = "chkStatus3";
            this.chkStatus3.Size = new System.Drawing.Size(182, 15);
            this.chkStatus3.TabIndex = 36;
            this.chkStatus3.Text = "Enable Top Right #3 Messages";
            this.chkStatus3.UseSelectable = true;
            this.chkStatus3.CheckedChanged += new System.EventHandler(this.chkStatus3_CheckedChanged);
            // 
            // chkStatus2
            // 
            this.chkStatus2.AutoSize = true;
            this.chkStatus2.Location = new System.Drawing.Point(6, 186);
            this.chkStatus2.Margin = new System.Windows.Forms.Padding(2);
            this.chkStatus2.Name = "chkStatus2";
            this.chkStatus2.Size = new System.Drawing.Size(182, 15);
            this.chkStatus2.TabIndex = 35;
            this.chkStatus2.Text = "Enable Top Right #2 Messages";
            this.chkStatus2.UseSelectable = true;
            // 
            // chkStatus1
            // 
            this.chkStatus1.AutoSize = true;
            this.chkStatus1.Location = new System.Drawing.Point(6, 162);
            this.chkStatus1.Margin = new System.Windows.Forms.Padding(2);
            this.chkStatus1.Name = "chkStatus1";
            this.chkStatus1.Size = new System.Drawing.Size(182, 15);
            this.chkStatus1.TabIndex = 34;
            this.chkStatus1.Text = "Enable Top Right #1 Messages";
            this.chkStatus1.UseSelectable = true;
            // 
            // chkShowAnnouncements
            // 
            this.chkShowAnnouncements.AutoSize = true;
            this.chkShowAnnouncements.Location = new System.Drawing.Point(6, 93);
            this.chkShowAnnouncements.Margin = new System.Windows.Forms.Padding(2);
            this.chkShowAnnouncements.Name = "chkShowAnnouncements";
            this.chkShowAnnouncements.Size = new System.Drawing.Size(283, 15);
            this.chkShowAnnouncements.TabIndex = 33;
            this.chkShowAnnouncements.Text = "Show Server Announcements with MessageTypes";
            this.chkShowAnnouncements.UseSelectable = true;
            // 
            // chkEnableMessageTypes
            // 
            this.chkEnableMessageTypes.AutoSize = true;
            this.chkEnableMessageTypes.Location = new System.Drawing.Point(6, 75);
            this.chkEnableMessageTypes.Margin = new System.Windows.Forms.Padding(2);
            this.chkEnableMessageTypes.Name = "chkEnableMessageTypes";
            this.chkEnableMessageTypes.Size = new System.Drawing.Size(140, 15);
            this.chkEnableMessageTypes.TabIndex = 32;
            this.chkEnableMessageTypes.Text = "Enable Message Types";
            this.chkEnableMessageTypes.UseSelectable = true;
            this.chkEnableMessageTypes.CheckedChanged += new System.EventHandler(this.chkEnableMessageTypes_CheckedChanged);
            // 
            // lblMTInformation
            // 
            this.lblMTInformation.Location = new System.Drawing.Point(5, 15);
            this.lblMTInformation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMTInformation.Name = "lblMTInformation";
            this.lblMTInformation.Size = new System.Drawing.Size(337, 58);
            this.lblMTInformation.TabIndex = 31;
            this.lblMTInformation.Text = "Message Types displays messages in different areas of the client\'s screen. Here y" +
    "ou can configure all but announcements and chat.";
            this.lblMTInformation.WrapToLine = true;
            // 
            // gboCustomBlocks
            // 
            this.gboCustomBlocks.Controls.Add(this.btnDefineNewBlock);
            this.gboCustomBlocks.Location = new System.Drawing.Point(377, 63);
            this.gboCustomBlocks.Name = "gboCustomBlocks";
            this.gboCustomBlocks.Size = new System.Drawing.Size(276, 50);
            this.gboCustomBlocks.TabIndex = 31;
            this.gboCustomBlocks.TabStop = false;
            this.gboCustomBlocks.Text = "Custom Blocks";
            this.gboCustomBlocks.Enter += new System.EventHandler(this.gboCustomBlocks_Enter);
            // 
            // btnDefineNewBlock
            // 
            this.btnDefineNewBlock.Location = new System.Drawing.Point(6, 19);
            this.btnDefineNewBlock.Name = "btnDefineNewBlock";
            this.btnDefineNewBlock.Size = new System.Drawing.Size(264, 23);
            this.btnDefineNewBlock.TabIndex = 0;
            this.btnDefineNewBlock.Text = "Define New Block";
            this.btnDefineNewBlock.UseVisualStyleBackColor = true;
            this.btnDefineNewBlock.Click += new System.EventHandler(this.btnDefineNewBlock_Click);
            // 
            // picBackground
            // 
            this.picBackground.BackgroundImage = global::GemsCraft.Properties.Resources.Brown;
            this.picBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBackground.Location = new System.Drawing.Point(0, 55);
            this.picBackground.Name = "picBackground";
            this.picBackground.Size = new System.Drawing.Size(669, 343);
            this.picBackground.TabIndex = 32;
            this.picBackground.TabStop = false;
            // 
            // gboClickDistance
            // 
            this.gboClickDistance.Controls.Add(this.numMaxDistance);
            this.gboClickDistance.Controls.Add(this.lblMaxDistance);
            this.gboClickDistance.Controls.Add(this.numMinDistance);
            this.gboClickDistance.Controls.Add(this.lblMinDistance);
            this.gboClickDistance.Controls.Add(this.chkEnableClickDistance);
            this.gboClickDistance.Controls.Add(this.metroLabel1);
            this.gboClickDistance.Location = new System.Drawing.Point(377, 119);
            this.gboClickDistance.Name = "gboClickDistance";
            this.gboClickDistance.Size = new System.Drawing.Size(276, 150);
            this.gboClickDistance.TabIndex = 33;
            this.gboClickDistance.TabStop = false;
            this.gboClickDistance.Text = "Click Distance";
            // 
            // numMaxDistance
            // 
            this.numMaxDistance.Location = new System.Drawing.Point(86, 123);
            this.numMaxDistance.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numMaxDistance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxDistance.Name = "numMaxDistance";
            this.numMaxDistance.Size = new System.Drawing.Size(55, 20);
            this.numMaxDistance.TabIndex = 37;
            this.numMaxDistance.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numMaxDistance.ValueChanged += new System.EventHandler(this.numMaxDistance_ValueChanged);
            // 
            // lblMaxDistance
            // 
            this.lblMaxDistance.AutoSize = true;
            this.lblMaxDistance.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblMaxDistance.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblMaxDistance.Location = new System.Drawing.Point(6, 128);
            this.lblMaxDistance.Name = "lblMaxDistance";
            this.lblMaxDistance.Size = new System.Drawing.Size(80, 15);
            this.lblMaxDistance.TabIndex = 36;
            this.lblMaxDistance.Text = "Max. Distance";
            // 
            // numMinDistance
            // 
            this.numMinDistance.Location = new System.Drawing.Point(86, 97);
            this.numMinDistance.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numMinDistance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMinDistance.Name = "numMinDistance";
            this.numMinDistance.Size = new System.Drawing.Size(55, 20);
            this.numMinDistance.TabIndex = 35;
            this.numMinDistance.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMinDistance.ValueChanged += new System.EventHandler(this.numMinDistance_ValueChanged);
            // 
            // lblMinDistance
            // 
            this.lblMinDistance.AutoSize = true;
            this.lblMinDistance.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblMinDistance.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblMinDistance.Location = new System.Drawing.Point(6, 102);
            this.lblMinDistance.Name = "lblMinDistance";
            this.lblMinDistance.Size = new System.Drawing.Size(79, 15);
            this.lblMinDistance.TabIndex = 34;
            this.lblMinDistance.Text = "Min. Distance";
            // 
            // chkEnableClickDistance
            // 
            this.chkEnableClickDistance.AutoSize = true;
            this.chkEnableClickDistance.Location = new System.Drawing.Point(6, 80);
            this.chkEnableClickDistance.Margin = new System.Windows.Forms.Padding(2);
            this.chkEnableClickDistance.Name = "chkEnableClickDistance";
            this.chkEnableClickDistance.Size = new System.Drawing.Size(135, 15);
            this.chkEnableClickDistance.TabIndex = 33;
            this.chkEnableClickDistance.Text = "Enable Click Distance";
            this.chkEnableClickDistance.UseSelectable = true;
            this.chkEnableClickDistance.CheckedChanged += new System.EventHandler(this.chkEnableClickDistance_CheckedChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.Location = new System.Drawing.Point(6, 19);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(264, 58);
            this.metroLabel1.TabIndex = 32;
            this.metroLabel1.Text = "How far and how short player\'s click distance can be set. Determines how many blo" +
    "cks away a player can click.";
            this.metroLabel1.WrapToLine = true;
            // 
            // gboHeldBlock
            // 
            this.gboHeldBlock.Controls.Add(this.chkEnableHeldBlock);
            this.gboHeldBlock.Controls.Add(this.metroLabel2);
            this.gboHeldBlock.Location = new System.Drawing.Point(377, 273);
            this.gboHeldBlock.Name = "gboHeldBlock";
            this.gboHeldBlock.Size = new System.Drawing.Size(276, 85);
            this.gboHeldBlock.TabIndex = 34;
            this.gboHeldBlock.TabStop = false;
            this.gboHeldBlock.Text = "Held Block";
            // 
            // metroLabel2
            // 
            this.metroLabel2.Location = new System.Drawing.Point(6, 16);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(264, 47);
            this.metroLabel2.TabIndex = 33;
            this.metroLabel2.Text = "The ability to change/get a player\'s block type in hand";
            this.metroLabel2.WrapToLine = true;
            // 
            // chkEnableHeldBlock
            // 
            this.chkEnableHeldBlock.AutoSize = true;
            this.chkEnableHeldBlock.Location = new System.Drawing.Point(6, 59);
            this.chkEnableHeldBlock.Margin = new System.Windows.Forms.Padding(2);
            this.chkEnableHeldBlock.Name = "chkEnableHeldBlock";
            this.chkEnableHeldBlock.Size = new System.Drawing.Size(118, 15);
            this.chkEnableHeldBlock.TabIndex = 34;
            this.chkEnableHeldBlock.Text = "Enable Held Block";
            this.chkEnableHeldBlock.UseSelectable = true;
            // 
            // CpeConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 393);
            this.Controls.Add(this.gboHeldBlock);
            this.Controls.Add(this.gboClickDistance);
            this.Controls.Add(this.gboCustomBlocks);
            this.Controls.Add(this.bResetTab);
            this.Controls.Add(this.gboMessageType);
            this.Controls.Add(this.picBackground);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CpeConfig";
            this.Padding = new System.Windows.Forms.Padding(14, 60, 14, 13);
            this.Style = MetroFramework.MetroColorStyle.Brown;
            this.Text = "GemsCraft Configuration - CPE";
            this.gboMessageType.ResumeLayout(false);
            this.gboMessageType.PerformLayout();
            this.gboCustomBlocks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).EndInit();
            this.gboClickDistance.ResumeLayout(false);
            this.gboClickDistance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinDistance)).EndInit();
            this.gboHeldBlock.ResumeLayout(false);
            this.gboHeldBlock.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal MetroFramework.Controls.MetroButton bResetTab;
        internal System.Windows.Forms.GroupBox gboMessageType;
        internal MetroFramework.Controls.MetroLabel lblMTInformation;
        internal MetroFramework.Controls.MetroCheckBox chkEnableMessageTypes;
        internal MetroFramework.Controls.MetroCheckBox chkShowAnnouncements;
        internal MetroFramework.Controls.MetroCheckBox chkBR3;
        internal MetroFramework.Controls.MetroCheckBox chkStatus3;
        internal MetroFramework.Controls.MetroCheckBox chkStatus2;
        internal MetroFramework.Controls.MetroCheckBox chkStatus1;
        internal MetroFramework.Controls.MetroCheckBox chkBR1;
        internal MetroFramework.Controls.MetroCheckBox chkBR2;
        internal MetroFramework.Controls.MetroTextBox txtStatus1;
        internal MetroFramework.Controls.MetroTextBox txtStatus2;
        internal MetroFramework.Controls.MetroTextBox txtStatus3;
        internal MetroFramework.Controls.MetroTextBox txtBR3;
        internal MetroFramework.Controls.MetroTextBox txtBR2;
        internal MetroFramework.Controls.MetroTextBox txtBR1;
        private System.Windows.Forms.GroupBox gboCustomBlocks;
        private System.Windows.Forms.Button btnDefineNewBlock;
        private System.Windows.Forms.PictureBox picBackground;
        private System.Windows.Forms.GroupBox gboClickDistance;
        internal MetroFramework.Controls.MetroLabel metroLabel1;
        internal MetroFramework.Controls.MetroCheckBox chkEnableClickDistance;
        private MetroFramework.Controls.MetroLabel lblMaxDistance;
        private MetroFramework.Controls.MetroLabel lblMinDistance;
        internal System.Windows.Forms.NumericUpDown numMaxDistance;
        internal System.Windows.Forms.NumericUpDown numMinDistance;
        private System.Windows.Forms.GroupBox gboHeldBlock;
        internal MetroFramework.Controls.MetroCheckBox chkEnableHeldBlock;
        internal MetroFramework.Controls.MetroLabel metroLabel2;
    }
}