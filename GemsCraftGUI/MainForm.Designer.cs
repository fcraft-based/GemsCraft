namespace Launcher
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnConfig = new MetroFramework.Controls.MetroButton();
            this.btnServerCli = new MetroFramework.Controls.MetroButton();
            this.btnServerGui = new MetroFramework.Controls.MetroButton();
            this.picBackground = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(34, 63);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(148, 127);
            this.btnConfig.TabIndex = 0;
            this.btnConfig.Text = "Configuration";
            this.btnConfig.UseSelectable = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnServerCli
            // 
            this.btnServerCli.Location = new System.Drawing.Point(203, 63);
            this.btnServerCli.Name = "btnServerCli";
            this.btnServerCli.Size = new System.Drawing.Size(148, 127);
            this.btnServerCli.TabIndex = 1;
            this.btnServerCli.Text = "Open Server (CLI)";
            this.btnServerCli.UseSelectable = true;
            this.btnServerCli.Click += new System.EventHandler(this.btnServerCli_Click);
            // 
            // btnServerGui
            // 
            this.btnServerGui.Location = new System.Drawing.Point(367, 63);
            this.btnServerGui.Name = "btnServerGui";
            this.btnServerGui.Size = new System.Drawing.Size(148, 127);
            this.btnServerGui.TabIndex = 2;
            this.btnServerGui.Text = "Open Server (GUI)";
            this.btnServerGui.UseSelectable = true;
            this.btnServerGui.Click += new System.EventHandler(this.btnServerGui_Click);
            // 
            // picBackground
            // 
            this.picBackground.Image = ((System.Drawing.Image)(resources.GetObject("picBackground.Image")));
            this.picBackground.Location = new System.Drawing.Point(0, 55);
            this.picBackground.Name = "picBackground";
            this.picBackground.Size = new System.Drawing.Size(552, 159);
            this.picBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBackground.TabIndex = 15;
            this.picBackground.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 213);
            this.Controls.Add(this.btnServerGui);
            this.Controls.Add(this.btnServerCli);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.picBackground);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "GemsCraft Launcher";
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton btnConfig;
        private MetroFramework.Controls.MetroButton btnServerCli;
        private MetroFramework.Controls.MetroButton btnServerGui;
        private System.Windows.Forms.PictureBox picBackground;
    }
}

