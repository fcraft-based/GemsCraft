using System;
using System.ComponentModel;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Microsoft.VisualBasic;
using static GemsCraft.GUI.ConfigGUI.GUI.MainForm;
using static Microsoft.VisualBasic.Interaction;

namespace GemsCraft.GUI.ConfigGUI.GUI.Sections
{
    public partial class CpeConfig : MetroForm
    {
        public CpeConfig()
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

        }

        private void bResetTab_Click(object sender, EventArgs e)
        {

        }

        private void chkEnableMessageTypes_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control c in gboMessageType.Controls)
            {
                if (c.Name == chkEnableMessageTypes.Name) continue;
                if (c.GetType().ToString() == "MetroCheckBox")
                {
                    MetroCheckBox cx = (MetroCheckBox) c;
                    cx.Checked = false;
                }
                c.Enabled = chkEnableMessageTypes.Checked;
            }
        }

        private void chkStatus3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnDefineNewBlock_Click(object sender, EventArgs e)
        {
            new BlockDesigner.BlockDesigner().ShowDialog();
        }

        private void gboCustomBlocks_Enter(object sender, EventArgs e)
        {

        }

        private void numMinDistance_ValueChanged(object sender, EventArgs e)
        {
            if (numMinDistance.Value >= numMaxDistance.Value)
            {
                numMinDistance.Value = numMaxDistance.Value - 1;
            }
        }

        private void numMaxDistance_ValueChanged(object sender, EventArgs e)
        {
            if (numMaxDistance.Value <= numMinDistance.Value)
            {
                numMaxDistance.Value = numMinDistance.Value + 1;
            }
        }

        private void chkEnableClickDistance_CheckedChanged(object sender, EventArgs e)
        {
            numMinDistance.Enabled = chkEnableClickDistance.Checked;
            numMaxDistance.Enabled = chkEnableClickDistance.Checked;
        }
    }
}