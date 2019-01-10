using System;
using System.ComponentModel;
using System.Windows.Forms;
using MetroFramework.Forms;
using Microsoft.VisualBasic;
using static GemsCraft.GUI.ConfigGUI.GUI.MainForm;
using static Microsoft.VisualBasic.Interaction;

namespace GemsCraft.GUI.ConfigGUI.GUI.Sections
{
    public partial class MiscConfig : MetroForm
    {
        public MiscConfig()
        {
            InitializeComponent();
            InputHandlers();
            this.Closing += Exit;
        }

        private void Exit(object sender, CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void InputHandlers()
        {
            CustomColor.Click += _instance.button1_Click;
            SwearEditor.Click += _instance.SwearEditor_Click;
            ReqsEditor.Click += _instance.ReqsEditor_Click;
            websiteURL.TextChanged += _instance.websiteURL_TextChanged;

        }
        
        private void chkEnableRemoteControl_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control control in gboRemoteControl.Controls)
            {
                if (control.Name != chkEnableRemoteControl.Name)
                {
                    control.Enabled = chkEnableRemoteControl.Checked;
                }
            }
        }

        private void chkRequireLogin_CheckedChanged(object sender, EventArgs e)
        {
            btnSetLogin.Enabled = chkRequireLogin.Checked && chkRequireLogin.Enabled;
        }

        internal string setPassword;
        private void btnSetLogin_Click(object sender, EventArgs e)
        {
            string result = InputBox("Set a password for admin login", "Admin Password", "password");
            if (CheckResult(result, out string response))
            {
                setPassword = result;
            }
            else
            {
                btnSetLogin_Click(sender, e); // Redo
            }
        }

        private bool CheckResult(string checking, out string message)
        {
            if (checking == null)
            {
                message = "Password cannot be empty";
                return false;
            }

            if (checking.Length < 6)
            {
                message = "Password must at least be 6 characters long";
                return false;
            }

            message = "";
            return true;
        }
        private void lblRemotePort_Click(object sender, EventArgs e)
        {

        }

        private void numPort_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bResetTab_Click(object sender, EventArgs e)
        {

        }
    }
}
