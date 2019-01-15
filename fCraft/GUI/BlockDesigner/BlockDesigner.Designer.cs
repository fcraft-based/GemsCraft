namespace GemsCraft.GUI.BlockDesigner
{
    partial class BlockDesigner
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
            this.lblDesigner = new System.Windows.Forms.Label();
            this.picCube = new System.Windows.Forms.PictureBox();
            this.gboSettings = new System.Windows.Forms.GroupBox();
            this.chkFullBright = new System.Windows.Forms.CheckBox();
            this.chkTransmitsLight = new System.Windows.Forms.CheckBox();
            this.btnSide = new System.Windows.Forms.Button();
            this.btnTop = new System.Windows.Forms.Button();
            this.btnBottom = new System.Windows.Forms.Button();
            this.btnFogColor = new System.Windows.Forms.Button();
            this.lblFogDensity = new System.Windows.Forms.Label();
            this.numFogDensity = new System.Windows.Forms.NumericUpDown();
            this.lblBlockDraw = new System.Windows.Forms.Label();
            this.cboTransparency = new System.Windows.Forms.ComboBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.numSize = new System.Windows.Forms.NumericUpDown();
            this.lblWalkSound = new System.Windows.Forms.Label();
            this.cboWalkSound = new System.Windows.Forms.ComboBox();
            this.lblMovementSpeed = new System.Windows.Forms.Label();
            this.numMovementSpeed = new System.Windows.Forms.NumericUpDown();
            this.lblSolidity = new System.Windows.Forms.Label();
            this.cboSolidity = new System.Windows.Forms.ComboBox();
            this.numID = new System.Windows.Forms.NumericUpDown();
            this.lblID = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.imageChooser = new System.Windows.Forms.OpenFileDialog();
            this.colorChooser = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picCube)).BeginInit();
            this.gboSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFogDensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMovementSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numID)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDesigner
            // 
            this.lblDesigner.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesigner.Location = new System.Drawing.Point(144, 12);
            this.lblDesigner.Name = "lblDesigner";
            this.lblDesigner.Size = new System.Drawing.Size(169, 92);
            this.lblDesigner.TabIndex = 1;
            this.lblDesigner.Text = "Block Designer";
            this.lblDesigner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picCube
            // 
            this.picCube.Image = global::GemsCraft.Properties.Resources.green_154264_960_720;
            this.picCube.Location = new System.Drawing.Point(12, 12);
            this.picCube.Name = "picCube";
            this.picCube.Size = new System.Drawing.Size(126, 92);
            this.picCube.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCube.TabIndex = 0;
            this.picCube.TabStop = false;
            // 
            // gboSettings
            // 
            this.gboSettings.Controls.Add(this.chkFullBright);
            this.gboSettings.Controls.Add(this.chkTransmitsLight);
            this.gboSettings.Controls.Add(this.btnSide);
            this.gboSettings.Controls.Add(this.btnTop);
            this.gboSettings.Controls.Add(this.btnBottom);
            this.gboSettings.Controls.Add(this.btnFogColor);
            this.gboSettings.Controls.Add(this.lblFogDensity);
            this.gboSettings.Controls.Add(this.numFogDensity);
            this.gboSettings.Controls.Add(this.lblBlockDraw);
            this.gboSettings.Controls.Add(this.cboTransparency);
            this.gboSettings.Controls.Add(this.lblSize);
            this.gboSettings.Controls.Add(this.numSize);
            this.gboSettings.Controls.Add(this.lblWalkSound);
            this.gboSettings.Controls.Add(this.cboWalkSound);
            this.gboSettings.Controls.Add(this.lblMovementSpeed);
            this.gboSettings.Controls.Add(this.numMovementSpeed);
            this.gboSettings.Controls.Add(this.lblSolidity);
            this.gboSettings.Controls.Add(this.cboSolidity);
            this.gboSettings.Controls.Add(this.numID);
            this.gboSettings.Controls.Add(this.lblID);
            this.gboSettings.Controls.Add(this.txtName);
            this.gboSettings.Controls.Add(this.lblName);
            this.gboSettings.Location = new System.Drawing.Point(12, 110);
            this.gboSettings.Name = "gboSettings";
            this.gboSettings.Size = new System.Drawing.Size(301, 328);
            this.gboSettings.TabIndex = 3;
            this.gboSettings.TabStop = false;
            this.gboSettings.Text = "Settings";
            this.gboSettings.Enter += new System.EventHandler(this.gboSettings_Enter);
            // 
            // chkFullBright
            // 
            this.chkFullBright.AutoSize = true;
            this.chkFullBright.Location = new System.Drawing.Point(43, 251);
            this.chkFullBright.Name = "chkFullBright";
            this.chkFullBright.Size = new System.Drawing.Size(72, 17);
            this.chkFullBright.TabIndex = 21;
            this.chkFullBright.Text = "Full Bright";
            this.chkFullBright.UseVisualStyleBackColor = true;
            // 
            // chkTransmitsLight
            // 
            this.chkTransmitsLight.AutoSize = true;
            this.chkTransmitsLight.Location = new System.Drawing.Point(43, 228);
            this.chkTransmitsLight.Name = "chkTransmitsLight";
            this.chkTransmitsLight.Size = new System.Drawing.Size(97, 17);
            this.chkTransmitsLight.TabIndex = 20;
            this.chkTransmitsLight.Text = "Transmits Light";
            this.chkTransmitsLight.UseVisualStyleBackColor = true;
            // 
            // btnSide
            // 
            this.btnSide.Location = new System.Drawing.Point(164, 286);
            this.btnSide.Name = "btnSide";
            this.btnSide.Size = new System.Drawing.Size(131, 23);
            this.btnSide.TabIndex = 19;
            this.btnSide.Text = "Select Side Texture";
            this.btnSide.UseVisualStyleBackColor = true;
            this.btnSide.Click += new System.EventHandler(this.btnSide_Click);
            // 
            // btnTop
            // 
            this.btnTop.Location = new System.Drawing.Point(164, 257);
            this.btnTop.Name = "btnTop";
            this.btnTop.Size = new System.Drawing.Size(131, 23);
            this.btnTop.TabIndex = 18;
            this.btnTop.Text = "Select Top Texture";
            this.btnTop.UseVisualStyleBackColor = true;
            this.btnTop.Click += new System.EventHandler(this.btnTop_Click);
            // 
            // btnBottom
            // 
            this.btnBottom.Location = new System.Drawing.Point(164, 228);
            this.btnBottom.Name = "btnBottom";
            this.btnBottom.Size = new System.Drawing.Size(131, 23);
            this.btnBottom.TabIndex = 17;
            this.btnBottom.Text = "Select Bottom Texture";
            this.btnBottom.UseVisualStyleBackColor = true;
            this.btnBottom.Click += new System.EventHandler(this.btnBottom_Click);
            // 
            // btnFogColor
            // 
            this.btnFogColor.BackColor = System.Drawing.Color.White;
            this.btnFogColor.Location = new System.Drawing.Point(209, 199);
            this.btnFogColor.Name = "btnFogColor";
            this.btnFogColor.Size = new System.Drawing.Size(86, 23);
            this.btnFogColor.TabIndex = 16;
            this.btnFogColor.Text = "Pick Fog Color";
            this.btnFogColor.UseVisualStyleBackColor = false;
            this.btnFogColor.Click += new System.EventHandler(this.btnFogColor_Click);
            // 
            // lblFogDensity
            // 
            this.lblFogDensity.AutoSize = true;
            this.lblFogDensity.Location = new System.Drawing.Point(40, 204);
            this.lblFogDensity.Name = "lblFogDensity";
            this.lblFogDensity.Size = new System.Drawing.Size(63, 13);
            this.lblFogDensity.TabIndex = 15;
            this.lblFogDensity.Text = "Fog Density";
            // 
            // numFogDensity
            // 
            this.numFogDensity.Location = new System.Drawing.Point(108, 202);
            this.numFogDensity.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numFogDensity.Name = "numFogDensity";
            this.numFogDensity.Size = new System.Drawing.Size(95, 20);
            this.numFogDensity.TabIndex = 14;
            this.numFogDensity.ValueChanged += new System.EventHandler(this.numFogDensity_ValueChanged);
            // 
            // lblBlockDraw
            // 
            this.lblBlockDraw.AutoSize = true;
            this.lblBlockDraw.Location = new System.Drawing.Point(40, 178);
            this.lblBlockDraw.Name = "lblBlockDraw";
            this.lblBlockDraw.Size = new System.Drawing.Size(62, 13);
            this.lblBlockDraw.TabIndex = 13;
            this.lblBlockDraw.Text = "Block Draw";
            // 
            // cboTransparency
            // 
            this.cboTransparency.FormattingEnabled = true;
            this.cboTransparency.Items.AddRange(new object[] {
            "Fully Opaque",
            "Transparent Like Glass",
            "Transparent Like Leaves",
            "Translucent",
            "Gas"});
            this.cboTransparency.Location = new System.Drawing.Point(108, 175);
            this.cboTransparency.Name = "cboTransparency";
            this.cboTransparency.Size = new System.Drawing.Size(187, 21);
            this.cboTransparency.TabIndex = 12;
            this.cboTransparency.SelectedIndexChanged += new System.EventHandler(this.cboTransparency_SelectedIndexChanged);
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(75, 151);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(27, 13);
            this.lblSize.TabIndex = 11;
            this.lblSize.Text = "Size";
            // 
            // numSize
            // 
            this.numSize.Location = new System.Drawing.Point(108, 149);
            this.numSize.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numSize.Name = "numSize";
            this.numSize.Size = new System.Drawing.Size(187, 20);
            this.numSize.TabIndex = 10;
            this.numSize.ValueChanged += new System.EventHandler(this.numSize_ValueChanged);
            // 
            // lblWalkSound
            // 
            this.lblWalkSound.AutoSize = true;
            this.lblWalkSound.Location = new System.Drawing.Point(36, 125);
            this.lblWalkSound.Name = "lblWalkSound";
            this.lblWalkSound.Size = new System.Drawing.Size(66, 13);
            this.lblWalkSound.TabIndex = 9;
            this.lblWalkSound.Text = "Walk Sound";
            // 
            // cboWalkSound
            // 
            this.cboWalkSound.FormattingEnabled = true;
            this.cboWalkSound.Items.AddRange(new object[] {
            "No sound",
            "Wood",
            "Gravel",
            "Grass",
            "Stone",
            "Metal",
            "Glass",
            "Wool",
            "Sand",
            "Snow"});
            this.cboWalkSound.Location = new System.Drawing.Point(108, 122);
            this.cboWalkSound.Name = "cboWalkSound";
            this.cboWalkSound.Size = new System.Drawing.Size(187, 21);
            this.cboWalkSound.TabIndex = 8;
            // 
            // lblMovementSpeed
            // 
            this.lblMovementSpeed.AutoSize = true;
            this.lblMovementSpeed.Location = new System.Drawing.Point(11, 98);
            this.lblMovementSpeed.Name = "lblMovementSpeed";
            this.lblMovementSpeed.Size = new System.Drawing.Size(91, 13);
            this.lblMovementSpeed.TabIndex = 7;
            this.lblMovementSpeed.Text = "Movement Speed";
            // 
            // numMovementSpeed
            // 
            this.numMovementSpeed.Location = new System.Drawing.Point(108, 96);
            this.numMovementSpeed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numMovementSpeed.Name = "numMovementSpeed";
            this.numMovementSpeed.Size = new System.Drawing.Size(187, 20);
            this.numMovementSpeed.TabIndex = 6;
            // 
            // lblSolidity
            // 
            this.lblSolidity.AutoSize = true;
            this.lblSolidity.Location = new System.Drawing.Point(62, 72);
            this.lblSolidity.Name = "lblSolidity";
            this.lblSolidity.Size = new System.Drawing.Size(40, 13);
            this.lblSolidity.TabIndex = 5;
            this.lblSolidity.Text = "Solidity";
            // 
            // cboSolidity
            // 
            this.cboSolidity.FormattingEnabled = true;
            this.cboSolidity.Items.AddRange(new object[] {
            "Walk through",
            "Swim through",
            "Solid"});
            this.cboSolidity.Location = new System.Drawing.Point(108, 69);
            this.cboSolidity.Name = "cboSolidity";
            this.cboSolidity.Size = new System.Drawing.Size(187, 21);
            this.cboSolidity.TabIndex = 4;
            // 
            // numID
            // 
            this.numID.Location = new System.Drawing.Point(108, 43);
            this.numID.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numID.Name = "numID";
            this.numID.Size = new System.Drawing.Size(187, 20);
            this.numID.TabIndex = 3;
            this.numID.ValueChanged += new System.EventHandler(this.numID_ValueChanged);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(84, 45);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 2;
            this.lblID.Text = "ID";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(108, 17);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(187, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(67, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 444);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(301, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save and Add";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // imageChooser
            // 
            this.imageChooser.DefaultExt = "png";
            this.imageChooser.FileName = "image";
            this.imageChooser.Filter = "*.png|";
            this.imageChooser.RestoreDirectory = true;
            this.imageChooser.ShowHelp = true;
            this.imageChooser.SupportMultiDottedExtensions = true;
            this.imageChooser.Title = "Select Texture";
            // 
            // BlockDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 478);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gboSettings);
            this.Controls.Add(this.lblDesigner);
            this.Controls.Add(this.picCube);
            this.Name = "BlockDesigner";
            this.Text = "GemsCraft Block Designer";
            ((System.ComponentModel.ISupportInitialize)(this.picCube)).EndInit();
            this.gboSettings.ResumeLayout(false);
            this.gboSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFogDensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMovementSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCube;
        private System.Windows.Forms.Label lblDesigner;
        private System.Windows.Forms.GroupBox gboSettings;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.NumericUpDown numID;
        private System.Windows.Forms.Label lblSolidity;
        private System.Windows.Forms.ComboBox cboSolidity;
        private System.Windows.Forms.Label lblMovementSpeed;
        private System.Windows.Forms.NumericUpDown numMovementSpeed;
        private System.Windows.Forms.OpenFileDialog imageChooser;
        private System.Windows.Forms.ComboBox cboWalkSound;
        private System.Windows.Forms.Label lblWalkSound;
        private System.Windows.Forms.NumericUpDown numSize;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.ComboBox cboTransparency;
        private System.Windows.Forms.Label lblBlockDraw;
        private System.Windows.Forms.Label lblFogDensity;
        private System.Windows.Forms.NumericUpDown numFogDensity;
        private System.Windows.Forms.ColorDialog colorChooser;
        private System.Windows.Forms.Button btnFogColor;
        private System.Windows.Forms.Button btnSide;
        private System.Windows.Forms.Button btnTop;
        private System.Windows.Forms.Button btnBottom;
        private System.Windows.Forms.CheckBox chkTransmitsLight;
        private System.Windows.Forms.CheckBox chkFullBright;
    }
}