using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GemsCraftLauncher
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
                var startInfo = new ProcessStartInfo
                {
                    WorkingDirectory = "GemsCraft\\",
                    FileName = "GemsCraftLauncher.exe",
                };
                Process.Start(startInfo);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show("Could not open " + e.FileName);
                throw;
            }
            
        }
    }
}
