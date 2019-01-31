namespace GemsCraft.GUI {
    sealed partial class AboutWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if( disposing && (components != null) ) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutWindow));
            this.lSubheader = new System.Windows.Forms.Label();
            this.lfCraft = new System.Windows.Forms.LinkLabel();
            this.l800Craft = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.lThank = new System.Windows.Forms.Label();
            this.lLegendCraft = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lSubheader
            // 
            this.lSubheader.AutoSize = true;
            this.lSubheader.BackColor = System.Drawing.Color.Transparent;
            this.lSubheader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSubheader.ForeColor = System.Drawing.Color.Black;
            this.lSubheader.Location = new System.Drawing.Point(13, 160);
            this.lSubheader.Name = "lSubheader";
            this.lSubheader.Size = new System.Drawing.Size(262, 104);
            this.lSubheader.TabIndex = 2;
            this.lSubheader.Text = "Free, open-source ClassiCube game software\r\nBased on fCraft, 800Craft, and Legend" +
    "Craft\r\nDeveloped by apotter96\r\n\r\n800Craft:\r\nfCraft:\r\nLegendCraft:\r\nGemsCraft:\r\n";
            // 
            // lfCraft
            // 
            this.lfCraft.AutoSize = true;
            this.lfCraft.BackColor = System.Drawing.Color.Transparent;
            this.lfCraft.Location = new System.Drawing.Point(98, 225);
            this.lfCraft.Name = "lfCraft";
            this.lfCraft.Size = new System.Drawing.Size(32, 13);
            this.lfCraft.TabIndex = 3;
            this.lfCraft.TabStop = true;
            this.lfCraft.Text = "fCraft";
            // 
            // l800Craft
            // 
            this.l800Craft.AutoSize = true;
            this.l800Craft.BackColor = System.Drawing.Color.Transparent;
            this.l800Craft.Location = new System.Drawing.Point(98, 212);
            this.l800Craft.Name = "l800Craft";
            this.l800Craft.Size = new System.Drawing.Size(47, 13);
            this.l800Craft.TabIndex = 4;
            this.l800Craft.TabStop = true;
            this.l800Craft.Text = "800Craft";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "A ClassiCube Server Software\r\nDeveloped by apotter96";
            // 
            // lThank
            // 
            this.lThank.AutoSize = true;
            this.lThank.BackColor = System.Drawing.Color.Transparent;
            this.lThank.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lThank.ForeColor = System.Drawing.Color.Black;
            this.lThank.Location = new System.Drawing.Point(13, 284);
            this.lThank.Name = "lThank";
            this.lThank.Size = new System.Drawing.Size(190, 13);
            this.lThank.TabIndex = 8;
            this.lThank.Text = "Copyright (c) 2018 by apotter96.";
            this.lThank.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lLegendCraft
            // 
            this.lLegendCraft.AutoSize = true;
            this.lLegendCraft.BackColor = System.Drawing.Color.Transparent;
            this.lLegendCraft.Location = new System.Drawing.Point(98, 238);
            this.lLegendCraft.Name = "lLegendCraft";
            this.lLegendCraft.Size = new System.Drawing.Size(65, 13);
            this.lLegendCraft.TabIndex = 11;
            this.lLegendCraft.TabStop = true;
            this.lLegendCraft.Text = "LegendCraft";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.picLogo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lThank);
            this.groupBox1.Controls.Add(this.lLegendCraft);
            this.groupBox1.Controls.Add(this.l800Craft);
            this.groupBox1.Controls.Add(this.lfCraft);
            this.groupBox1.Controls.Add(this.lSubheader);
            this.groupBox1.Location = new System.Drawing.Point(12, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 314);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Image = global::GemsCraft.Properties.Resources.main;
            this.picLogo.Location = new System.Drawing.Point(9, 45);
            this.picLogo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(349, 104);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 12;
            this.picLogo.TabStop = false;
            // 
            // AboutWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::GemsCraft.Properties.Resources.Green;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(388, 359);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(198, 194);
            this.Name = "AboutWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About GemsCraft";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lSubheader;
        private System.Windows.Forms.LinkLabel lfCraft;
        private System.Windows.Forms.LinkLabel l800Craft;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lThank;
        private System.Windows.Forms.LinkLabel lLegendCraft;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox picLogo;
    }
}