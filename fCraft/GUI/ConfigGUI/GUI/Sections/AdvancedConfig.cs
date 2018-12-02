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
    public partial class AdvancedConfig : MetroForm
    {
        public AdvancedConfig()
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
            tIP.Validating += _instance.tIP_Validating;
            xIP.CheckedChanged += _instance.xIP_CheckedChanged;
            nMaxUndo.ValueChanged += _instance.nMaxUndo_ValueChanged;
            xMaxUndo.CheckedChanged += _instance.xMaxUndo_CheckedChanged;
            
        }
    }
}
