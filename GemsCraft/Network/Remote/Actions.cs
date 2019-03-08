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
    /// Several actions that can be performed by the mobile app, or have information sent to the mobile app
    /// </summary>
    public class Actions
    {

        public static void ShutdownServer(PlayerInfo player, string reason)
        {
            ShutDown(Enum.TryParse(reason, true, out ShutdownReason result) ? result : ShutdownReason.Other);
        }

        private static void ShutDown(ShutdownReason downReason)
        {
            GemsCraft.fSystem.Server.Shutdown(new ShutdownParams(downReason, TimeSpan.Zero, true, false), true);
        }
        public static void RestartServer(PlayerInfo player)
        {
            GemsCraft.fSystem.Server.Shutdown(new ShutdownParams(ShutdownReason.Restarting, TimeSpan.Zero, true, true), true );
        }

        public static string RunCommand(PlayerInfo player, string command, string[] args)
        {
            try
            {
                if (command == null) return "";
                CommandDescriptor cd = CommandManager.GetDescriptor(command, true);
                if (cd != null && cd.Permissions.Any(p => !player.Can(p)))
                {
                    return "Player does not have this permission.";
                }

                cd?.Call(Player.Console, new Command(CommandString(command, args)), true);

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
        
    }
}
