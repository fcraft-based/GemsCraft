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
    public partial class LoggingConfig : MetroForm
    {
        public LoggingConfig()
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
            vConsoleOptions.ItemChecked += _instance.vConsoleOptions_ItemChecked;
            vLogFileOptions.ItemChecked += _instance.vLogFileOptions_ItemChecked;
            xLogLimit.CheckedChanged += _instance.xLogLimit_CheckedChanged;
        }
    }
}
