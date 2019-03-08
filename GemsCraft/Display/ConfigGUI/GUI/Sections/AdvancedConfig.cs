using System;
using System.ComponentModel;
using MetroFramework.Forms;

namespace GemsCraft.Display.ConfigGUI.GUI.Sections
{
    public partial class AdvancedConfig : MetroForm
    {
        public AdvancedConfig()
        {
            this.InitializeComponent();
            this.InputHandlers();
            this.Closing += Exit;
        }

        private void Exit(object sender, CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void InputHandlers()
        {
            tIP.Validating += MainForm._instance.tIP_Validating;
            xIP.CheckedChanged += MainForm._instance.xIP_CheckedChanged;
            nMaxUndo.ValueChanged += MainForm._instance.nMaxUndo_ValueChanged;
            xMaxUndo.CheckedChanged += MainForm._instance.xMaxUndo_CheckedChanged;
            
        }

        private void bResetTab_Click(object sender, EventArgs e)
        {

        }
    }
}
