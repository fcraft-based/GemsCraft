using System.ComponentModel;
using MetroFramework.Forms;

namespace GemsCraft.Display.ConfigGUI.GUI.Sections
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
            cVerifyNames.SelectedIndexChanged += MainForm._instance.cVerifyNames_SelectedIndexChanged;
            xMaxConnectionsPerIP.CheckedChanged += MainForm._instance.xMaxConnectionsPerIP_CheckedChanged;
            xAnnounceRankChanges.CheckedChanged += MainForm._instance.xAnnounceRankChanges_CheckedChanged;
            cPatrolledRank.SelectedIndexChanged += MainForm._instance.cPatrolledRank_SelectedIndexChanged;
            cBlockDBAutoEnableRank.SelectedIndexChanged += MainForm._instance.cBlockDBAutoEnableRank_SelectedIndexChanged;
            xBlockDBEnabled.CheckedChanged += MainForm._instance.xBlockDBEnabled_CheckedChanged;
            xBlockDBAutoEnable.CheckedChanged += MainForm._instance.xBlockDBAutoEnable_CheckedChanged;
            
        }
        
    }
}
