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
    public partial class SavingConfig : MetroForm
    {
        public SavingConfig()
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
            xSaveInterval.CheckedChanged += _instance.xSaveAtInterval_CheckedChanged;
            xBackupInterval.CheckedChanged += _instance.xBackupAtInterval_CheckedChanged;
            xMaxBackups.CheckedChanged += _instance.xMaxBackups_CheckedChanged;
            xMaxBackupSize.CheckedChanged += _instance.xMaxBackupSize_CheckedChanged;
        }
    }
}
