using System;
using GemsCraft.Display.BlockDesigner;

namespace RemoteTest
{
    class Program
    {
        static void Main(string[] args)
        {
            new GemsCraft.Display.ConfigGUI.GUI.BasicConfig.MainForm().ShowDialog();
            Console.ReadLine();
        }
    }
}
