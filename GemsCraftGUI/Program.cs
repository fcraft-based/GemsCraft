using System;
using System.Diagnostics;
using System.Windows.Forms;
using GemsCraft.Network.Remote;
using GemsCraft.Utils;
using Server = GemsCraft.fSystem.Server;

namespace Launcher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                DialogResult result = DialogResult.None;
                if (Updater.CheckUpdates(false) == VersionResult.Developer)
                {
                    result = MessageBox.Show("You are using an unreleased developer version of GemsCraft. " +
                                    "Would you like to download the current version?", "Unreleased Version", MessageBoxButtons.YesNo);
                    
                }
                else if (Updater.CheckUpdates(false) == VersionResult.Outdated)
                {
                    result = MessageBox.Show("You are using an outdated version of GemsCraft. " +
                                             "Would you like to download the current version?", "Outdated Version", MessageBoxButtons.YesNo);
                }

                if (result == DialogResult.Yes)
                {
                    Updater.CheckUpdaters(); // Moves updater downloaded if it hasn't been done yet
                    Process.Start("Updater.exe");

                }

                Form form = Server.IsUsingMono ? (Form) new BasicLauncher() : new MainForm(); 
                Application.Run(form);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
           
        }
    }
}
