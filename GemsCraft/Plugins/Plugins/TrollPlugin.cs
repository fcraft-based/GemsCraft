using System;
using System.ComponentModel;
using GemsCraft.Commands;
using GemsCraft.fSystem;
using GemsCraft.Players;
using GemsCraft.Utils;
using Version = GemsCraft.Utils.Version; // Making sure we are using GemsCraft's Version class rather than the System's

namespace GemsCraft.Plugins.Plugins // This can be anything
{
    public class Init : IPlugin // Reference IPlugin!
    {
        public string Name { get; set; } = "TrollPlugin"; // Your plugin name
        public string Version { get; set; } = "1.0"; // Your plugin version
        public string Author { get; set; } = "Unknown"; // Your name goes here
        public DateTime ReleaseDate { get; set; } = DateTime.Parse("01/01/2019");
        public string FileName { get; set; } = "TrollPlugin.dll"; // Recommended that this is the same name
        public Version SoftwareVersion { get; set; } = new Version("Alpha", 0, 3, -1, -1, false); // The GemsCraft Version its available for
        public bool Enabled { get; set; } // Don't use, used by the software and the config

        internal static Init Instance { get; set; } // Used for getting/setting properties

        [Description("Tell me all about this"),
         Category("Some Random Name IDC")]
        public string CustomSetting { get; set; } = "Default Value";

        // Used to set the instance of the class so that the properties can be saved
        public void Save()
        {
            Instance = this;
        }

        // Used to get the instance of the clas so that the properties can be read
        public IPlugin Load()
        {
            return Instance;
        }

        /* This is where you'll tell the server host when you've initialized the plugin
            and where you'll do all your setting up, like you would in a constructor.
            Don't forget this is also where you will want to register any commands you
            may have for your plugin.
             */
        public void Initialize()
        {
            Logger.Log(LogType.ConsoleOutput, Name + "(v " + Version + "): Registering TrollPlugin");
            CommandManager.RegisterCustomCommand(CdTroll);
        }

        // A sample command descriptor
        private static readonly CommandDescriptor CdTroll = new CommandDescriptor
        {
            Name = "Troll", // What users will use to call your command i.e. /troll
            Aliases = new [] {"trll", "trollin", "jake"}, // Other ways to call your command rather than just the name, i.e. /trollin
            Category = CommandCategory.Chat | CommandCategory.Fun, // The categories your plugin will fit in
            Permissions = new[] { Permission.Troll }, // What permissions will your plugin have?
            IsConsoleSafe = true, // Can it be executed by console? Is it safe to? (For instance, you should allow world commands in console
            NotRepeatable = false, // Can your command be repeated? Will people be too immature with it?
            Usage = "/troll player option [Message]", // How should they use this command?
            Help = "Does a little somthin'-somethin'.\n" + // What they need to know
            " Available options: st, ac, pm, message or leave",
            Handler = TrollHandler // The method to handle the command
        };
        
        private static void TrollHandler(Player player, Command cmd)  // Command Handlers should always have these two arguments
        {
            string customSetting = Init.Instance.CustomSetting; // Calling the custom setting
            Logger.Log(LogType.SystemActivity, customSetting); // Save logs
            string name = cmd.Next(); // Calling the next command argument
            if (name == null) // name will be null if they did not specify an argument
            {
                player.Message("Player not found. Please specify valid name."); // Send the executing player a message
                return; // Prevent from going onward.
            }
            if (!Player.IsValidName(name))
                return;
            Player target = Server.FindPlayerOrPrintMatches(player, name, true, true); // Check to see if a player is real
            if (target == null)
                return;
            string options = cmd.Next();
            if (options == null)
            {
                CdTroll.PrintUsage(player);
                return;
            }
            string message = cmd.NextAll(); // Get the next and any following arguments. Good for message commands
            if (message.Length < 1 && options.ToLower() != "leave")
            {
                player.Message("&WError: Please enter a message for {0}.", target.ClassyName);
                return;
            }
            switch (options.ToLower())
            {
                case "pm":
                    if (player.Can(Permission.UseColorCodes) && message.Contains("%"))
                    {
                        message = Color.ReplacePercentCodes(message);
                    }
                    Server.Players.Message("&Pfrom {0}: {1}", MessageType.Chat,
                        target.Name, message);
                    break;
                case "ac":
                    Chat.SendAdmin(target, message);
                    break;
                case "st":
                case "staff":
                    Chat.SendStaff(target, message);
                    break;
                case "i":
                case "impersonate":
                case "msg":
                case "message":
                case "m":
                    Server.Message("{0}&S&F: {1}",
                                      target.ClassyName, message);
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
