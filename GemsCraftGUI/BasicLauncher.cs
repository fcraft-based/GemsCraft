using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConfigForm = GemsCraft.Display.ConfigGUI.GUI.BasicConfig.MainForm;
using ServerForm = GemsCraft.Display.ServerGUI.BasicForm;

namespace Launcher
{
    public partial class BasicLauncher : Form
    {
        private ConfigForm _form;
        private ServerForm _server;

        public BasicLauncher()
        {
            InitializeComponent();
            if (File.Exists("GemsCraftGUI.exe")) File.Delete("GemsCraftGUI.exe"); // Delete the legacy GUI
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
            _server = new ServerForm();
            _server.ShowDialog();
        }
    }
}
