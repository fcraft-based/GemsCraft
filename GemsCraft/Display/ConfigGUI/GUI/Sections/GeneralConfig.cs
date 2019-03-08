using System;
using System.ComponentModel;
using MetroFramework.Forms;

namespace GemsCraft.Display.ConfigGUI.GUI.Sections
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
            xAnnouncements.CheckedChanged += MainForm._instance.xAnnouncements_CheckedChanged;
            bMeasure.Click += MainForm._instance.bMeasure_Click;
            bAnnouncements.Click += MainForm._instance.bAnnouncements_Click;
            bCredits.Click += MainForm._instance.bCredits_Click;
            nMaxPlayers.ValueChanged += MainForm._instance.nMaxPlayers_ValueChanged;
            bGreeting.Click += MainForm._instance.bGreeting_Click;
            bRules.Click += MainForm._instance.bRules_Click;
            cDefaultRank.SelectedIndexChanged += MainForm._instance.cDefaultRank_SelectedIndexChanged;
            bWeb.Click += MainForm._instance.bWeb_Click;
            bWiki.Click += MainForm._instance.bWiki_Click;
            bReadme.Click += MainForm._instance.bReadme_Click;
            bChangelog.Click += MainForm._instance.bChangelog_Click;
        }

        private void picLogo_Click(object sender, EventArgs e)
        {

        }
    }
}
