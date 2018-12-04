using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GemsCraft.Commands;
using GemsCraft.fSystem;
using GemsCraft.Players;
namespace GemsCraft.Network.Remote
{
    /// <summary>
    /// Several actions that can be performed by the mobile app
    /// </summary>
    public class Actions
    {
        public static void ShutdownServer(string reason)
        {
            ShutDown(Enum.TryParse(reason, true, out ShutdownReason result) ? result : ShutdownReason.Other);
        }

        private static void ShutDown(ShutdownReason downReason)
        {
            GemsCraft.fSystem.Server.Shutdown(new ShutdownParams(downReason, TimeSpan.Zero, true, false), true);
        }
        public static void RestartServer()
        {
            GemsCraft.fSystem.Server.Shutdown(new ShutdownParams(ShutdownReason.Restarting, TimeSpan.Zero, true, true), true );
        }

        public static string RunCommand(string command, string[] args)
        {
            try
            {
                CommandDescriptor cd = CommandManager.GetDescriptor(command, true);
                cd.Call(Player.Console, new Command(CommandString(command, args)), true);
                return "";
            }
            catch (Exception e)
            {
                return "Command does not exist";
            }
        }

        private static string CommandString(string command, IEnumerable<string> args)
        {
            string finalResult = $"/{command} ";
            finalResult = args.Aggregate(finalResult, (current, arg) => current + (arg + " "));
            return finalResult;
        }

        public static bool EditConfigKey(ConfigKey key, object value, out string response)
        {
            try
            {
                key.TrySetValue(value);
                Config.Save();
                response = "success";
                return true;
            }
            catch (FormatException e)
            {
                response = "Value was not in the correct format";;
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
