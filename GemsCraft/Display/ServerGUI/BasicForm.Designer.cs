﻿
namespace GemsCraft.Display.ServerGUI
{
    partial class BasicForm
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
            this.components = new System.ComponentModel.Container();
            this.uriDisplay = new System.Windows.Forms.TextBox();
            this.playerList = new System.Windows.Forms.ListBox();
            this.playerListLabel = new System.Windows.Forms.Label();
            this.bPlay = new System.Windows.Forms.Button();
            this.SizeBox = new System.Windows.Forms.ComboBox();
            this.ThemeBox = new System.Windows.Forms.ComboBox();
            this.PlayerOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Ban = new System.Windows.Forms.ToolStripMenuItem();
            this.Kick = new System.Windows.Forms.ToolStripMenuItem();
            this.Rank = new System.Windows.Forms.ToolStripMenuItem();
            this.PM = new System.Windows.Forms.ToolStripMenuItem();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.bVoice = new System.Windows.Forms.Button();
            this.URLLabel = new System.Windows.Forms.Label();
            this.console = new GemsCraft.Display.ServerGUI.ConsoleBox();
            this.PlayerOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // uriDisplay
            // 
            this.uriDisplay.Location = new System.Drawing.Point(46, 11);
            this.uriDisplay.Name = "uriDisplay";
            this.uriDisplay.Size = new System.Drawing.Size(476, 20);
            this.uriDisplay.TabIndex = 7;
            // 
            // playerList
            // 
            this.playerList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playerList.BackColor = System.Drawing.Color.White;
            this.playerList.FormattingEnabled = true;
            this.playerList.IntegralHeight = false;
            this.playerList.Location = new System.Drawing.Point(628, 58);
            this.playerList.Name = "playerList";
            this.playerList.Size = new System.Drawing.Size(144, 368);
            this.playerList.TabIndex = 4;
            // 
            // playerListLabel
            // 
            this.playerListLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.playerListLabel.AutoSize = true;
            this.playerListLabel.BackColor = System.Drawing.Color.Green;
            this.playerListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerListLabel.ForeColor = System.Drawing.Color.Black;
            this.playerListLabel.Location = new System.Drawing.Point(628, 42);
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
            this.bPlay.Location = new System.Drawing.Point(528, 9);
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
            this.SizeBox.Location = new System.Drawing.Point(628, 10);
            this.SizeBox.Name = "SizeBox";
            this.SizeBox.Size = new System.Drawing.Size(56, 21);
            this.SizeBox.TabIndex = 8;
            this.SizeBox.Text = "Size";
            this.SizeBox.Visible = false;
            this.SizeBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // ThemeBox
            // 
            this.ThemeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ThemeBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ThemeBox.FormattingEnabled = true;
            this.ThemeBox.Items.AddRange(new object[] {
            "Default LC",
            "Alternate LC",
            "Pink",
            "Yellow",
            "Green",
            "Purple",
            "Grey"});
            this.ThemeBox.Location = new System.Drawing.Point(690, 10);
            this.ThemeBox.Name = "ThemeBox";
            this.ThemeBox.Size = new System.Drawing.Size(82, 21);
            this.ThemeBox.TabIndex = 9;
            this.ThemeBox.Text = "Theme";
            this.ThemeBox.Visible = false;
            this.ThemeBox.SelectedIndexChanged += new System.EventHandler(this.ThemeBox_SelectedIndexChanged);
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
            this.logBox.Location = new System.Drawing.Point(12, 39);
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.Size = new System.Drawing.Size(610, 387);
            this.logBox.TabIndex = 7;
            this.logBox.Text = "";
            this.logBox.TextChanged += new System.EventHandler(this.logBox_TextChanged);
            // 
            // bVoice
            // 
            this.bVoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bVoice.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bVoice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bVoice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.bVoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bVoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bVoice.Location = new System.Drawing.Point(735, 429);
            this.bVoice.Name = "bVoice";
            this.bVoice.Size = new System.Drawing.Size(37, 29);
            this.bVoice.TabIndex = 10;
            this.bVoice.UseVisualStyleBackColor = false;
            this.bVoice.Click += new System.EventHandler(this.bVoice_Click);
            // 
            // URLLabel
            // 
            this.URLLabel.AutoSize = true;
            this.URLLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.URLLabel.ForeColor = System.Drawing.Color.Black;
            this.URLLabel.Location = new System.Drawing.Point(9, 15);
            this.URLLabel.Name = "URLLabel";
            this.URLLabel.Size = new System.Drawing.Size(36, 13);
            this.URLLabel.TabIndex = 5;
            this.URLLabel.Text = "URL:";
            // 
            // console
            // 
            this.console.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.console.Enabled = false;
            this.console.Location = new System.Drawing.Point(13, 433);
            this.console.Name = "console";
            this.console.Size = new System.Drawing.Size(716, 20);
            this.console.TabIndex = 0;
            this.console.Text = "Server Loading...";
            // 
            // BasicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(784, 464);
            this.Controls.Add(this.URLLabel);
            this.Controls.Add(this.bVoice);
            this.Controls.Add(this.ThemeBox);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.SizeBox);
            this.Controls.Add(this.bPlay);
            this.Controls.Add(this.console);
            this.Controls.Add(this.playerListLabel);
            this.Controls.Add(this.playerList);
            this.Controls.Add(this.uriDisplay);
            this.MinimumSize = new System.Drawing.Size(500, 150);
            this.Name = "BasicForm";
            this.Text = "GemsCraft";
            this.PlayerOptions.ResumeLayout(false);
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
        private System.Windows.Forms.ComboBox ThemeBox;
        private System.Windows.Forms.ContextMenuStrip PlayerOptions;
        private System.Windows.Forms.ToolStripMenuItem Ban;
        private System.Windows.Forms.ToolStripMenuItem Kick;
        private System.Windows.Forms.ToolStripMenuItem Rank;
        private System.Windows.Forms.ToolStripMenuItem PM;
        private System.Windows.Forms.Button bVoice;
        private System.Windows.Forms.Label URLLabel;
        /*private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabGlobal;
        private System.Windows.Forms.RichTextBox logGlobal;
        private System.Windows.Forms.TabPage tabServer;
        private System.Windows.Forms.RichTextBox logBox;
        private System.Windows.Forms.TabControl tabChat;*/
    }
}

