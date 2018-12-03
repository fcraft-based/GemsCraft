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
            bAddRank.Click += _instance.bAddRank_Click;
            bDeleteRank.Click += _instance.bDeleteRank_Click;
            tPrefix.Validating += _instance.tPrefix_Validating;
            xReserveSlot.CheckedChanged += _instance.xReserveSlot_CheckedChanged;
            nKickIdle.ValueChanged += _instance.nKickIdle_ValueChanged;
            nAntiGriefBlocks.ValueChanged += _instance.nAntiGriefBlocks_ValueChanged;
            nAntiGriefSeconds.ValueChanged += _instance.nAntiGriefSeconds_ValueChanged;
            nDrawLimit.ValueChanged += _instance.nDrawLimit_ValueChanged;
            nCopyPasteSlots.ValueChanged += _instance.nCopyPasteSlots_ValueChanged;
            xAllowSecurityCircumvention.CheckedChanged += _instance.xAllowSecurityCircumvention_CheckedChanged;
            vRanks.SelectedIndexChanged += _instance.vRanks_SelectedIndexChanged;
            xKickIdle.CheckedChanged += _instance.xKickIdle_CheckedChanged;
            xAntiGrief.CheckedChanged += _instance.xAntiGrief_CheckedChanged;
            xDrawLimit.CheckedChanged += _instance.xDrawLimit_CheckedChanged;
            vPermissions.ItemChecked += _instance.vPermissions_ItemChecked;
            tRankName.Validating += _instance.tRankName_Validating;
            bRaiseRank.Click += _instance.bRaiseRank_Click;
            bLowerRank.Click += _instance.bLowerRank_Click;
            bColorRank.Click += _instance.bColorRank_Click;
            nFillLimit.ValueChanged += _instance.nFillLimit_ValueChanged;
        }
    }
}
