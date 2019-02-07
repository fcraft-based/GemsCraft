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
using GemsCraft.fSystem;
using GemsCraft.Utils;
using MetroFramework.Forms;
using static GemsCraft.GUI.ConfigGUI.GUI.MainForm;

namespace GemsCraft.GUI.ConfigGUI.GUI.Sections
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
            bAddWorld.Click += _instance.bAddWorld_Click;
            bWorldEdit.Click += _instance.bWorldEdit_Click;
            dgvWorlds.Click += _instance.dgvWorlds_Click;
            bWorldDelete.Click += _instance.bWorldDel_Click;
            bMapPath.Click += _instance.bMapPath_Click;
            xMapPath.CheckedChanged += _instance.xMapPath_CheckedChanged;
            cDefaultBuildRank.SelectedIndexChanged += _instance.cDefaultBuildRank_SelectedIndexChanged;
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

