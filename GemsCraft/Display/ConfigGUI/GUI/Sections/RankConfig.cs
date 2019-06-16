using System.ComponentModel;
using MetroFramework.Forms;

namespace GemsCraft.Display.ConfigGUI.GUI.Sections
{
    public partial class RankConfig : MetroForm
    {
        public RankConfig()
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
            bAddRank.Click += MainForm._instance.bAddRank_Click;
            bDeleteRank.Click += MainForm._instance.bDeleteRank_Click;
            tPrefix.Validating += MainForm._instance.tPrefix_Validating;
            xReserveSlot.CheckedChanged += MainForm._instance.xReserveSlot_CheckedChanged;
            nKickIdle.ValueChanged += MainForm._instance.nKickIdle_ValueChanged;
            nAntiGriefBlocks.ValueChanged += MainForm._instance.nAntiGriefBlocks_ValueChanged;
            nAntiGriefSeconds.ValueChanged += MainForm._instance.nAntiGriefSeconds_ValueChanged;
            nDrawLimit.ValueChanged += MainForm._instance.nDrawLimit_ValueChanged;
            nCopyPasteSlots.ValueChanged += MainForm._instance.nCopyPasteSlots_ValueChanged;
            xAllowSecurityCircumvention.CheckedChanged += MainForm._instance.xAllowSecurityCircumvention_CheckedChanged;
            vRanks.SelectedIndexChanged += MainForm._instance.vRanks_SelectedIndexChanged;
            xKickIdle.CheckedChanged += MainForm._instance.xKickIdle_CheckedChanged;
            xAntiGrief.CheckedChanged += MainForm._instance.xAntiGrief_CheckedChanged;
            xDrawLimit.CheckedChanged += MainForm._instance.xDrawLimit_CheckedChanged;
            vPermissions.ItemChecked += MainForm._instance.vPermissions_ItemChecked;
            tRankName.Validating += MainForm._instance.tRankName_Validating;
            bRaiseRank.Click += MainForm._instance.bRaiseRank_Click;
            bLowerRank.Click += MainForm._instance.bLowerRank_Click;
            bColorRank.Click += MainForm._instance.bColorRank_Click;
            nFillLimit.ValueChanged += MainForm._instance.nFillLimit_ValueChanged;
        }
    }
}
