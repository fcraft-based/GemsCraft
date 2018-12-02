using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fCraft.fSystem;
using fCraft.Utils;
using MetroFramework.Forms;
using static fCraft.GUI.ConfigGUI.GUI.MainForm;

namespace fCraft.GUI.ConfigGUI.GUI.Sections
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
            bColorSys.Click += _instance.bColorSys_Click;
            bColorHelp.Click += _instance.bColorHelp_Click;
            bColorSay.Click += _instance.bColorSay_Click;
            bColorAnnouncement.Click += _instance.bColorAnnouncement_Click;
            bColorPM.Click += _instance.bColorPM_Click;
            bColorWarning.Click += _instance.bColorWarning_Click;
            bColorMe.Click += _instance.bColorMe_Click;
            bColorGlobal.Click += _instance.bColorGlobal_Click;
            xRankPrefixesInChat.CheckedChanged += _instance.xRankPrefixesInChat_CheckedChanged;
        }

        internal bool isPressed = false;
        private void bResetTab_Click(object sender, EventArgs e)
        {
            isPressed = true;
        }
    }
}
