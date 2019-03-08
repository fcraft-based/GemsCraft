namespace Launcher
{
    partial class BasicLauncher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasicLauncher));
            this.btnServerGui = new MetroFramework.Controls.MetroButton();
            this.btnServerCli = new MetroFramework.Controls.MetroButton();
            this.btnConfig = new MetroFramework.Controls.MetroButton();
            this.picBackground = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // btnServerGui
            // 
            this.btnServerGui.Location = new System.Drawing.Point(363, 2);
            this.btnServerGui.Name = "btnServerGui";
            this.btnServerGui.Size = new System.Drawing.Size(148, 127);
            this.btnServerGui.TabIndex = 18;
            this.btnServerGui.Text = "Open Server (GUI)";
            this.btnServerGui.UseSelectable = true;
            this.btnServerGui.Click += new System.EventHandler(this.btnServerGui_Click);
            // 
            // btnServerCli
            // 
            this.btnServerCli.Location = new System.Drawing.Point(199, 2);
            this.btnServerCli.Name = "btnServerCli";
            this.btnServerCli.Size = new System.Drawing.Size(148, 127);
            this.btnServerCli.TabIndex = 17;
            this.btnServerCli.Text = "Open Server (CLI)";
            this.btnServerCli.UseSelectable = true;
            this.btnServerCli.Click += new System.EventHandler(this.btnServerCli_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(30, 2);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(148, 127);
            this.btnConfig.TabIndex = 16;
            this.btnConfig.Text = "Configuration";
            this.btnConfig.UseSelectable = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // picBackground
            // 
            this.picBackground.Image = ((System.Drawing.Image)(resources.GetObject("picBackground.Image")));
            this.picBackground.Location = new System.Drawing.Point(-4, -6);
            this.picBackground.Name = "picBackground";
            this.picBackground.Size = new System.Drawing.Size(552, 159);
            this.picBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBackground.TabIndex = 19;
            this.picBackground.TabStop = false;
            // 
            // BasicLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 141);
            this.Controls.Add(this.btnServerGui);
            this.Controls.Add(this.btnServerCli);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.picBackground);
            this.Name = "BasicLauncher";
            this.Text = "GemsCraft Launcher";
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton btnServerGui;
        private MetroFramework.Controls.MetroButton btnServerCli;
        private MetroFramework.Controls.MetroButton btnConfig;
        private System.Windows.Forms.PictureBox picBackground;
    }
}