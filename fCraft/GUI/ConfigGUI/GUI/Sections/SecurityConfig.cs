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
    public partial class SecurityConfig : MetroForm
    {
        public SecurityConfig()
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
            cVerifyNames.SelectedIndexChanged += _instance.cVerifyNames_SelectedIndexChanged;
            xMaxConnectionsPerIP.CheckedChanged += _instance.xMaxConnectionsPerIP_CheckedChanged;
            xAnnounceRankChanges.CheckedChanged += _instance.xAnnounceRankChanges_CheckedChanged;
            cPatrolledRank.SelectedIndexChanged += _instance.cPatrolledRank_SelectedIndexChanged;
            cBlockDBAutoEnableRank.SelectedIndexChanged += _instance.cBlockDBAutoEnableRank_SelectedIndexChanged;
            xBlockDBEnabled.CheckedChanged += _instance.xBlockDBEnabled_CheckedChanged;
            xBlockDBAutoEnable.CheckedChanged += _instance.xBlockDBAutoEnable_CheckedChanged;
            
        }
        
    }
}
