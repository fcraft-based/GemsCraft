using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GemsCraft;
using GemsCraft.Commands;
using GemsCraft.fSystem;
using GemsCraft.Players;
using GemsCraft.Plugins;
using GemsCraft.Utils;
using Version = GemsCraft.Utils.Version;

namespace TrollPlugin
{
    public class Init : IPlugin
    {
        public string FileName { get; set; }
        public Version SoftwareVersion { get; set; }
        public bool Enabled { get; set; }

        public void Initialize()
        {
            Logger.Log(LogType.ConsoleOutput, Name + "(v " + Version + "): Registering TrollPlugin");
            CommandManager.RegisterCustomCommand(CdTroll);
        }

        static CommandDescriptor CdTroll = new CommandDescriptor
        {
            Name = "Troll",
            Category = CommandCategory.Chat | CommandCategory.Fun,
            Permissions = new[] { Permission.Troll },
            IsConsoleSafe = true,
            NotRepeatable = false,
            Usage = "/troll player option [Message]",
            Help = "Does a little somthin'-somethin'.\n" +
            " Available options: st, ac, pm, message or leave",
            Handler = TrollHandler
        };

        //your plugin name
        public string Name
        {
            get => "TrollPlugin";
            set => throw new NotImplementedException();
        }

        //your plugin version
        public string Version
        {
            get => "1.0";
            set => throw new NotImplementedException();
        }

        public string Author
        {
            get => "Unknown";
            set => throw new NotImplementedException();
        }

        public DateTime ReleaseDate { get; set; }

        static void TrollHandler(Player player, Command cmd)
        {
            string name = cmd.Next();
            if (name == null)
            {
                player.Message("Player not found. Please specify valid name.");
                return;
            }
            if (!Player.IsValidName(name))
                return;
            Player target = Server.FindPlayerOrPrintMatches(player, name, true, true);
            if (target == null)
                return;
            string options = cmd.Next();
            if (options == null)
            {
                CdTroll.PrintUsage(player);
                return;
            }
            string Message = cmd.NextAll();
            if (Message.Length < 1 && options.ToLower() != "leave")
            {
                player.Message("&WError: Please enter a message for {0}.", target.ClassyName);
                return;
            }
            switch (options.ToLower())
            {
                case "pm":
                    if (player.Can(Permission.UseColorCodes) && Message.Contains("%"))
                    {
                        Message = Color.ReplacePercentCodes(Message);
                    }
                    Server.Players.Message("&Pfrom {0}: {1}", MessageType.Chat,
                        target.Name, Message);
                    break;
                case "ac":
                    Chat.SendAdmin(target, Message);
                    break;
                case "st":
                case "staff":
                    Chat.SendStaff(target, Message);
                    break;
                case "i":
                case "impersonate":
                case "msg":
                case "message":
                case "m":
                    Server.Message("{0}&S&F: {1}",
                                      target.ClassyName, Message);
                    break;
                case "leave":
                case "disconnect":
                case "gtfo":
                    Server.Players.Message("&SPlayer {0}&S left the server.", MessageType.Chat,
                        target.ClassyName);
                    break;
                default: player.Message("Invalid option. Please choose st, ac, pm, message or leave");
                    break;
            }
        }
    }
}
