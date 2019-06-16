using System.ComponentModel;
using MetroFramework.Forms;

namespace GemsCraft.Display.ConfigGUI.GUI.Sections
{
    public partial class LoggingConfig : MetroForm
    {
        public LoggingConfig()
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
            vConsoleOptions.ItemChecked += MainForm._instance.vConsoleOptions_ItemChecked;
            vLogFileOptions.ItemChecked += MainForm._instance.vLogFileOptions_ItemChecked;
            xLogLimit.CheckedChanged += MainForm._instance.xLogLimit_CheckedChanged;
        }
    }
}
