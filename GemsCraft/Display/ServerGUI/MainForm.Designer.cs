namespace GemsCraft.Display.ServerGUI {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.uriDisplay = new System.Windows.Forms.TextBox();
            this.playerList = new System.Windows.Forms.ListBox();
            this.playerListLabel = new System.Windows.Forms.Label();
            this.bPlay = new System.Windows.Forms.Button();
            this.SizeBox = new System.Windows.Forms.ComboBox();
            this.PlayerOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Ban = new System.Windows.Forms.ToolStripMenuItem();
            this.Kick = new System.Windows.Forms.ToolStripMenuItem();
            this.Rank = new System.Windows.Forms.ToolStripMenuItem();
            this.PM = new System.Windows.Forms.ToolStripMenuItem();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.lblTitle = new MetroFramework.Controls.MetroLabel();
            this.lblGemVersion = new MetroFramework.Controls.MetroLabel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.bVoice = new System.Windows.Forms.Button();
            this.picBackground = new System.Windows.Forms.PictureBox();
            this.console = new ConsoleBox();
            this.PlayerOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // uriDisplay
            // 
            this.uriDisplay.Location = new System.Drawing.Point(317, 40);
            this.uriDisplay.Name = "uriDisplay";
            this.uriDisplay.Size = new System.Drawing.Size(390, 20);
            this.uriDisplay.TabIndex = 7;
            // 
            // playerList
            // 
            this.playerList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playerList.BackColor = System.Drawing.Color.White;
            this.playerList.FormattingEnabled = true;
            this.playerList.IntegralHeight = false;
            this.playerList.Location = new System.Drawing.Point(617, 79);
            this.playerList.Name = "playerList";
            this.playerList.Size = new System.Drawing.Size(144, 332);
            this.playerList.TabIndex = 4;
            // 
            // playerListLabel
            // 
            this.playerListLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.playerListLabel.AutoSize = true;
            this.playerListLabel.BackColor = System.Drawing.Color.White;
            this.playerListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerListLabel.ForeColor = System.Drawing.Color.Black;
            this.playerListLabel.Location = new System.Drawing.Point(614, 63);
            this.playerListLabel.Name = "playerListLabel";
            this.playerListLabel.Size = new System.Drawing.Size(62, 13);
            this.playerListLabel.TabIndex = 6;
            this.playerListLabel.Text = "Player list";
            // 
            // bPlay
            // 
            this.bPlay.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bPlay.Enabled = false;
            this.bPlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.bPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bPlay.Location = new System.Drawing.Point(713, 38);
            this.bPlay.Name = "bPlay";
            this.bPlay.Size = new System.Drawing.Size(48, 23);
            this.bPlay.TabIndex = 2;
            this.bPlay.Text = "Play";
            this.bPlay.UseVisualStyleBackColor = false;
            this.bPlay.Click += new System.EventHandler(this.bPlay_Click);
            // 
            // SizeBox
            // 
            this.SizeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SizeBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SizeBox.FormattingEnabled = true;
            this.SizeBox.Items.AddRange(new object[] {
            "Normal",
            "Big",
            "Large"});
            this.SizeBox.Location = new System.Drawing.Point(317, 63);
            this.SizeBox.Name = "SizeBox";
            this.SizeBox.Size = new System.Drawing.Size(56, 21);
            this.SizeBox.TabIndex = 8;
            this.SizeBox.Text = "Size";
            this.SizeBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // PlayerOptions
            // 
            this.PlayerOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Ban,
            this.Kick,
            this.Rank,
            this.PM});
            this.PlayerOptions.Name = "contextMenuStrip1";
            this.PlayerOptions.Size = new System.Drawing.Size(101, 92);
            this.PlayerOptions.Tag = "Player Options";
            this.PlayerOptions.Text = "Player Options";
            // 
            // Ban
            // 
            this.Ban.Name = "Ban";
            this.Ban.Size = new System.Drawing.Size(100, 22);
            this.Ban.Text = "Ban";
            this.Ban.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            // 
            // Kick
            // 
            this.Kick.Name = "Kick";
            this.Kick.Size = new System.Drawing.Size(100, 22);
            this.Kick.Text = "Kick";
            // 
            // Rank
            // 
            this.Rank.Name = "Rank";
            this.Rank.Size = new System.Drawing.Size(100, 22);
            this.Rank.Text = "Rank";
            // 
            // PM
            // 
            this.PM.Name = "PM";
            this.PM.Size = new System.Drawing.Size(100, 22);
            this.PM.Text = "PM";
            // 
            // logBox
            // 
            this.logBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logBox.BackColor = System.Drawing.Color.Black;
            this.logBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logBox.HideSelection = false;
            this.logBox.Location = new System.Drawing.Point(23, 132);
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.Size = new System.Drawing.Size(588, 279);
            this.logBox.TabIndex = 7;
            this.logBox.Text = "";
            this.logBox.TextChanged += new System.EventHandler(this.logBox_TextChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Location = new System.Drawing.Point(317, 107);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(118, 19);
            this.lblTitle.TabIndex = 12;
            this.lblTitle.Text = "Server is Offline D:";
            // 
            // lblGemVersion
            // 
            this.lblGemVersion.AutoSize = true;
            this.lblGemVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblGemVersion.Location = new System.Drawing.Point(317, 88);
            this.lblGemVersion.Name = "lblGemVersion";
            this.lblGemVersion.Size = new System.Drawing.Size(73, 19);
            this.lblGemVersion.TabIndex = 13;
            this.lblGemVersion.Text = "Version: {0}";
            // 
            // picLogo
            // 
            this.picLogo.Image = global::GemsCraft.Properties.Resources.cool_logo;
            this.picLogo.Location = new System.Drawing.Point(23, 12);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(288, 114);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 11;
            this.picLogo.TabStop = false;
            // 
            // bVoice
            // 
            this.bVoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bVoice.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bVoice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bVoice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.bVoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bVoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bVoice.Image = ((System.Drawing.Image)(resources.GetObject("bVoice.Image")));
            this.bVoice.Location = new System.Drawing.Point(724, 417);
            this.bVoice.Name = "bVoice";
            this.bVoice.Size = new System.Drawing.Size(37, 29);
            this.bVoice.TabIndex = 10;
            this.bVoice.UseVisualStyleBackColor = false;
            this.bVoice.Click += new System.EventHandler(this.bVoice_Click);
            // 
            // picBackground
            // 
            this.picBackground.Image = global::GemsCraft.Properties.Resources.Green;
            this.picBackground.Location = new System.Drawing.Point(0, 22);
            this.picBackground.Name = "picBackground";
            this.picBackground.Size = new System.Drawing.Size(787, 436);
            this.picBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBackground.TabIndex = 14;
            this.picBackground.TabStop = false;
            // 
            // console
            // 
            this.console.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.console.Enabled = false;
            this.console.Location = new System.Drawing.Point(23, 417);
            this.console.Name = "console";
            this.console.Size = new System.Drawing.Size(695, 20);
            this.console.TabIndex = 0;
            this.console.Text = "Server Loading...";
            // 
            // MainForm
            // 
            this.ApplyImageInvert = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 458);
            this.Controls.Add(this.lblGemVersion);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.bVoice);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.SizeBox);
            this.Controls.Add(this.bPlay);
            this.Controls.Add(this.console);
            this.Controls.Add(this.playerListLabel);
            this.Controls.Add(this.playerList);
            this.Controls.Add(this.uriDisplay);
            this.Controls.Add(this.picBackground);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 150);
            this.Name = "MainForm";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.PlayerOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /*private bool onGlobal = false;*/
        private System.Windows.Forms.RichTextBox logBox;
        private System.Windows.Forms.TextBox uriDisplay;
        private System.Windows.Forms.ListBox playerList;
        private System.Windows.Forms.Label playerListLabel;
        private ConsoleBox console;
        private System.Windows.Forms.Button bPlay;
        private System.Windows.Forms.ComboBox SizeBox;
        private System.Windows.Forms.ContextMenuStrip PlayerOptions;
        private System.Windows.Forms.ToolStripMenuItem Ban;
        private System.Windows.Forms.ToolStripMenuItem Kick;
        private System.Windows.Forms.ToolStripMenuItem Rank;
        private System.Windows.Forms.ToolStripMenuItem PM;
        private System.Windows.Forms.Button bVoice;
        private System.Windows.Forms.PictureBox picLogo;
        private MetroFramework.Controls.MetroLabel lblTitle;
        private MetroFramework.Controls.MetroLabel lblGemVersion;
        private System.Windows.Forms.PictureBox picBackground;
        /*private System.Windows.Forms.TabPage tabPage3;
private System.Windows.Forms.TabPage tabGlobal;
private System.Windows.Forms.RichTextBox logGlobal;
private System.Windows.Forms.TabPage tabServer;
private System.Windows.Forms.RichTextBox logBox;
private System.Windows.Forms.TabControl tabChat;*/
    }
}

