using System;
using System.ComponentModel;
using MetroFramework.Forms;

namespace GemsCraft.Display.ConfigGUI.GUI.Sections
{
    public partial class ChatConfig : MetroForm
    {
        public ChatConfig()
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
            bColorSys.Click += MainForm._instance.bColorSys_Click;
            bColorHelp.Click += MainForm._instance.bColorHelp_Click;
            bColorSay.Click += MainForm._instance.bColorSay_Click;
            bColorAnnouncement.Click += MainForm._instance.bColorAnnouncement_Click;
            bColorPM.Click += MainForm._instance.bColorPM_Click;
            bColorWarning.Click += MainForm._instance.bColorWarning_Click;
            bColorMe.Click += MainForm._instance.bColorMe_Click;
            bColorGlobal.Click += MainForm._instance.bColorGlobal_Click;
            xRankPrefixesInChat.CheckedChanged += MainForm._instance.xRankPrefixesInChat_CheckedChanged;
        }

        internal bool isPressed = false;
        private void bResetTab_Click(object sender, EventArgs e)
        {
            isPressed = true;
        }
    }
}
