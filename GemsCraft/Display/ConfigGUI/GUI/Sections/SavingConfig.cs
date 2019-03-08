using System.ComponentModel;
using MetroFramework.Forms;

namespace GemsCraft.Display.ConfigGUI.GUI.Sections
{
    public partial class SavingConfig : MetroForm
    {
        public SavingConfig()
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
            xSaveInterval.CheckedChanged += MainForm._instance.xSaveAtInterval_CheckedChanged;
            xBackupInterval.CheckedChanged += MainForm._instance.xBackupAtInterval_CheckedChanged;
            xMaxBackups.CheckedChanged += MainForm._instance.xMaxBackups_CheckedChanged;
            xMaxBackupSize.CheckedChanged += MainForm._instance.xMaxBackupSize_CheckedChanged;
        }
    }
}
