using System;
using System.IO;
using GemsCraft.Commands;
using GemsCraft.fSystem;
using GemsCraft.Players;
using GemsCraft.Plugins;
using GemsCraft.Utils;
using GemsCraft.Worlds;
using Version = GemsCraft.Utils.Version;
namespace WritePlugin
{
    public class Init : IPlugin
    {
        public string Name { get; set; } = "WritePlugin";
        public string Version { get; set; } = "2.0";
        public string Author { get; set; } = "apotter96";
        public DateTime ReleaseDate { get; set; } = DateTime.Parse("03/13/2019");
        public string FileName { get; set; } = "WritePlugin.dll";
        public bool Enabled { get; set; }

        public Version SoftwareVersion { get; set; } = new Version("Alpha", 0, 3, -1, -1, true);
        private static CommandDescriptor _cdWrite;
        public void Initialize()
        {
            Logger.Log(LogType.ConsoleInput,
                $"{Name}(v {Version}): Registering /Write");
            _cdWrite = new CommandDescriptor
            {
                Name = "Write",
                Category = CommandCategory.Building,
                Permissions = new[] { Permission.DrawAdvanced },
                RepeatableSelection = true,
                IsConsoleSafe = false,
                Help = "/Write message then click 2 blocks. The first is the starting point, the second is the direction",
                Usage = "&a/write sentence",
                Handler = WriteHandler
            };
            CommandManager.RegisterCustomCommand(_cdWrite);
        }

        private static void WriteHandler(Player player, Command cmd)
        {
            string str = cmd.NextAll();
            if (str.Length < 1) _cdWrite.PrintUsage(player);
            else if (!File.Exists("plugins/font.png"))
            {
                player.Message("&4The font file could not be found.");
            }
            else
            {
                FontHandler.Init("plugins/font.png");
                player.Message("Write: Click 2 blocks or use &h/Mark&s to set direction.");
                player.SelectionStart(2, WriteCallback, str, Permission.DrawAdvanced);
            }
        }

        private static void WriteCallback(Player player, Vector3I[] marks, object tag)
        {
            Block textColor = player.LastUsedBlockType != (Block)byte.MaxValue
                ? player.LastUsedBlockType
                : (Block)1;
            string text = (string)tag;
            FontHandler fontHandler = new FontHandler(textColor, marks, player.World, player);
            fontHandler.Render(text);
            if (fontHandler.blockCount > 0)
                player.Message("/Write: Writing '{0}' using {1} blocks of {2}", new object[3]
                {
                    (object) text,
                    (object) fontHandler.blockCount,
                    (object) ((object) textColor).ToString()
                });
            else player.Message("&WNo direction was set");
        }
    }
}

