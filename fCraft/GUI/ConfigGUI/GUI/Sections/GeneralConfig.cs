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
    public partial class GeneralConfig : MetroForm
    {
        public GeneralConfig()
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
            xAnnouncements.CheckedChanged += _instance.xAnnouncements_CheckedChanged;
            bMeasure.Click += _instance.bMeasure_Click;
            bAnnouncements.Click += _instance.bAnnouncements_Click;
            bCredits.Click += _instance.bCredits_Click;
            nMaxPlayers.ValueChanged += _instance.nMaxPlayers_ValueChanged;
            bGreeting.Click += _instance.bGreeting_Click;
            bRules.Click += _instance.bRules_Click;
            cDefaultRank.SelectedIndexChanged += _instance.cDefaultRank_SelectedIndexChanged;
            bWeb.Click += _instance.bWeb_Click;
            bWiki.Click += _instance.bWiki_Click;
            bReadme.Click += _instance.bReadme_Click;
            bChangelog.Click += _instance.bChangelog_Click;
        }
    }
}
