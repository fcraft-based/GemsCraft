using System.ComponentModel;
using MetroFramework.Forms;

namespace GemsCraft.Display.ConfigGUI.GUI.Sections
{
    public partial class IRCConfig : MetroForm
    {
        public IRCConfig()
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
            xIRCBotEnabled.CheckedChanged += MainForm._instance.xIRC_CheckedChanged;
            cIRCList.SelectedIndexChanged += MainForm._instance.cIRCList_SelectedIndexChanged;
            xIRCListShowNonEnglish.CheckedChanged += MainForm._instance.xIRCListShowNonEnglish_CheckedChanged;
            xIRCRegisteredNick.CheckedChanged += MainForm._instance.xIRCRegisteredNick_CheckedChanged;
            bColorIRC.Click += MainForm._instance.bColorIRC_Click;
            xChanPass.CheckedChanged += MainForm._instance.xChanPass_CheckedChanged;
            xServPass.CheckedChanged += MainForm._instance.xServPass_CheckedChanged;
        }
    }
}
