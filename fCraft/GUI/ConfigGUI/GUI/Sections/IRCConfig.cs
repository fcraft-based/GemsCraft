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
            xIRCBotEnabled.CheckedChanged += _instance.xIRC_CheckedChanged;
            cIRCList.SelectedIndexChanged += _instance.cIRCList_SelectedIndexChanged;
            xIRCListShowNonEnglish.CheckedChanged += _instance.xIRCListShowNonEnglish_CheckedChanged;
            xIRCRegisteredNick.CheckedChanged += _instance.xIRCRegisteredNick_CheckedChanged;
            bColorIRC.Click += _instance.bColorIRC_Click;
            xChanPass.CheckedChanged += _instance.xChanPass_CheckedChanged;
            xServPass.CheckedChanged += _instance.xServPass_CheckedChanged;
        }
    }
}
