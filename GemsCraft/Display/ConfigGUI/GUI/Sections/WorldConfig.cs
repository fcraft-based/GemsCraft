using System;
using System.ComponentModel;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace GemsCraft.Display.ConfigGUI.GUI.Sections
{
    public partial class WorldConfig : MetroForm
    {
        public WorldConfig()
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
            bAddWorld.Click += MainForm._instance.bAddWorld_Click;
            bWorldEdit.Click += MainForm._instance.bWorldEdit_Click;
            dgvWorlds.Click += MainForm._instance.dgvWorlds_Click;
            bWorldDelete.Click += MainForm._instance.bWorldDel_Click;
            bMapPath.Click += MainForm._instance.bMapPath_Click;
            xMapPath.CheckedChanged += MainForm._instance.xMapPath_CheckedChanged;
            cDefaultBuildRank.SelectedIndexChanged += MainForm._instance.cDefaultBuildRank_SelectedIndexChanged;
        }

        private void xMapPath_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void bMapPath_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowsePack_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog
            {
                SelectedPath = SectionClasses.WorldConfig.txtTextureMapPath.Text ?? "",
                Description = "Load a ClassiCube texture pack"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SectionClasses.WorldConfig.txtTextureMapPath.Text = dialog.SelectedPath;
            }
        }
    }
}

