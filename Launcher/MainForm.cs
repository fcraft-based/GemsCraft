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
using MetroFramework.Forms;
using ConfigForm = GemsCraft.GUI.ConfigGUI.GUI.MainForm;
using ServerForm = GemsCraft.GUI.ServerGUI.MainForm;

namespace Launcher
{
    public partial class MainForm : MetroForm
    {
        private ConfigForm _form;
        private ServerForm _server;
        
        public MainForm()
        {
            InitializeComponent();
        }
        private const string CliExe = "ServerCli.exe";
        private void btnConfig_Click(object sender, EventArgs e)
        {
            _form = new ConfigForm();
            _form.ShowDialog();
        }

        private void btnServerCli_Click(object sender, EventArgs e)
        {
            Process.Start(CliExe);
        }

        private void btnServerGui_Click(object sender, EventArgs e)
        {
            _server = new ServerForm(true); // true to let the form know it's the GUI
            _server.ShowDialog();
        }
    }
}
