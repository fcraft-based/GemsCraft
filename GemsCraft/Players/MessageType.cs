using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GemsCraft.fSystem;
using GemsCraft.Configuration;
using GemsCraft.Network.Remote;
using GemsCraft.Utils;
using GemsCraft.Worlds;

namespace GemsCraft.Players
{
    public enum MessageType // Comments from CPE suggested implementations
    {
        /// <summary>
        /// Normal message, shown in the chat area
        /// </summary>
        Chat = 0,
        /// <summary>
        /// Shown persistently in the top-right corner of the screen, in regular font
        /// </summary>
        Status1 = 1,
        /// <summary>
        /// Shown persistently just below Status 1
        /// </summary>
        Status2 = 2,
        /// <summary>
        /// Shown persistently just below Status 2
        /// </summary>
        Status3 = 3,
        /// <summary>
        /// Shown persistently in the bottom-right corner of the screen, in regular font
        /// </summary>
        BottomRight1 = 11,
        /// <summary>
        /// Shown persistently just above BottomRight1
        /// </summary>
        BottomRight2 = 12,
        /// <summary>
        /// Shown persistently just above BottomRight2
        /// </summary>
        BottomRight3 = 13,
        /// <summary>
        /// Pops up in a larger font near the top-center of the screen. Fades out after a few seconds
        /// </summary>
        Announcement = 100
    }

    public class MessageTypeUtil
    {
        public static bool Enabled()
        {
            ConfigKey.EnableMessageTypes.TryGetBool(out bool result);
            return result;
        }

        private static string GetKey(MessageType? type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            switch (type.Value)
            {
                case MessageType.Status1:
                    return ConfigKey.Status1.GetString();
                case MessageType.Status2:
                    return ConfigKey.Status2.GetString();
                case MessageType.Status3:
                    return ConfigKey.Status3.GetString();
                case MessageType.BottomRight3:
                    return ConfigKey.BR3.GetString();
                case MessageType.BottomRight2:
                    return ConfigKey.BR2.GetString();
                case MessageType.BottomRight1:
                    return ConfigKey.BR1.GetString();
                default:
                    throw new ArgumentException(nameof(type));
            }
        }
        public static string Status1()
        {
            return GetKey(MessageType.Status1);
        }

        public static string Status2()
        {
            return GetKey(MessageType.Status2);
        }

        public static string Status3()
        {
            return GetKey(MessageType.Status3);
        }

        public static string BottomRight3()
        {
            return GetKey(MessageType.BottomRight3);
        }

        public static string BottomRight2()
        {
            return GetKey(MessageType.BottomRight2);
        }

        public static string BottomRight1()
        {
            return GetKey(MessageType.BottomRight1);
        }

        public static string ParseMessages(string message, Player p)
        {
            message = message.Replace("{version}", Updater.LatestStable.ToString());
            message = message.Replace("{servername}", $"Server: {ConfigKey.ServerName.GetString()}");
            message = message.Replace("{displayedname}", $"Username: {p.Info.GetDisplayedName()}");
            message = message.Replace("{world}", p.World == null ? "N/A" : p.World.Name);
            message = message.Replace("{lastcommand}", p.UsedCommands.Count == 0 ? "N/A" : p.UsedCommands.Last());
            message = message.Replace("{block}", p.Info.HeldBlock.ToString());
            message = message.Replace("{time}", DateTime.Now.ToShortTimeString());
            message = message.Replace("{date}", DateTime.Now.ToShortDateString());
            message = message.Replace("{mainworld}", WorldManager.MainWorld.Name);
            message = message.Replace("{rank}", p.Info.Rank.Name);
            return message;
        }

        public static void MessageHandler(SchedulerTask task)
        {

            if (!Enabled()) return;
            Player p;
            try
            {
                p = (Player)task.UserState;
            }
            catch (Exception)
            {
                throw new ArgumentException(nameof(task));
            }

            if (ConfigKey.Status1Enabled.Enabled()) p.Message(ParseMessages(Status1(), p), MessageType.Status1);
            if (ConfigKey.Status2Enabled.Enabled()) p.Message(ParseMessages(Status2(), p), MessageType.Status2);
            if (ConfigKey.Status3Enabled.Enabled()) p.Message(ParseMessages(Status3(), p), MessageType.Status3);
            if (ConfigKey.BR3Enabled.Enabled()) p.Message(ParseMessages(BottomRight3(), p), MessageType.BottomRight3);
            if (ConfigKey.BR2Enabled.Enabled()) p.Message(ParseMessages(BottomRight2(), p), MessageType.BottomRight2);
            if (ConfigKey.BR1Enabled.Enabled()) p.Message(ParseMessages(BottomRight1(), p), MessageType.BottomRight1);
        }


    }
}
