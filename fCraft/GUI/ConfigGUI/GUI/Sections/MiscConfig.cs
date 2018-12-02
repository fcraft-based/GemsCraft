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
    public partial class MiscConfig : MetroForm
    {
        public MiscConfig()
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
            CustomColor.Click += _instance.button1_Click;
            SwearEditor.Click += _instance.SwearEditor_Click;
            ReqsEditor.Click += _instance.ReqsEditor_Click;
            websiteURL.TextChanged += _instance.websiteURL_TextChanged;

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
