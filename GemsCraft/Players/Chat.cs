﻿// Copyright 2009-2012 Matvei Stefarov <me@matvei.org>
using System;
using System.Collections.Generic;
using System.Linq;
using GemsCraft.Events;
using JetBrains.Annotations;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.Remoting.Channels;
using GemsCraft.fSystem;
using GemsCraft.Configuration;
using GemsCraft.Network.Remote;
using GemsCraft.Players;
using GemsCraft.Utils;
using GemsCraft.Worlds;
using Server = GemsCraft.fSystem.Server;

namespace GemsCraft.Players
{
    /// <summary> Helper class for handling player-generated chat. </summary>
    public static class Chat
    {
        public static List<string> Swears = new List<string>();
        public static IEnumerable<Regex> badWordMatchers;

        /// <summary> Conversion for code page 437 characters from index 0 to 31 to unicode. </summary>
        public const string ControlCharReplacements = "\0☺☻♥♦♣♠•◘○◙♂♀♪♫☼►◄↕‼¶§▬↨↑↓→←∟↔▲▼";

        /// <summary> Conversion for code page 437 characters from index 127 to 255 to unicode. </summary>
        public const string ExtendedCharReplacements = "⌂ÇüéâäàåçêëèïîìÄÅÉæÆôöòûùÿÖÜ¢£¥₧ƒáíóúñÑªº¿⌐¬½¼¡«»" +
            "░▒▓│┤╡╢╖╕╣║╗╝╜╛┐└┴┬├─┼╞╟╚╔╩╦╠═╬╧╨╤╥╙╘╒╓╫╪┘┌" +
            "█▄▌▐▀αßΓπΣσµτΦΘΩδ∞φε∩≡±≥≤⌠⌡÷≈°∙·√ⁿ²■\u00a0";

        private static string FormatMessage(string rawMessage, Player player)
        {
            rawMessage = EmoteHandler.Process(rawMessage);
            rawMessage = rawMessage.Replace("$name", player.ClassyName + "&f");
            rawMessage = rawMessage.Replace("$kicks", player.Info.TimesKickedOthers.ToString());
            rawMessage = rawMessage.Replace("$bans", player.Info.TimesBannedOthers.ToString());
            rawMessage = rawMessage.Replace("$awesome", "It is my professional opinion, that " + ConfigKey.ServerName.GetString() + " is the best server on ClassiCube");
            rawMessage = rawMessage.Replace("$server", ConfigKey.ServerName.GetString());
            rawMessage = rawMessage.Replace("$motd", ConfigKey.MOTD.GetString());
            rawMessage = rawMessage.Replace("$date", DateTime.UtcNow.ToShortDateString());
            rawMessage = rawMessage.Replace("$time", DateTime.Now.ToString());
            rawMessage = rawMessage.Replace("$money", player.Info.Money.ToString());
            rawMessage = rawMessage.Replace("$mad", "U &cmad&f, bro?");
            rawMessage = rawMessage.Replace("$welcome", "Welcome to " + ConfigKey.ServerName.GetString());
            rawMessage = rawMessage.Replace("$clap", "A round of applause might be appropriate, *claps*");
            rawMessage = rawMessage.Replace("$website", ConfigKey.WebsiteURL.GetString());
            rawMessage = rawMessage.Replace("$ws", ConfigKey.WebsiteURL.GetString());

            Player[] active = Server.Players.Where(p => p.IsOnline).ToArray();
            if (Server.Players.Length > 0)
            {
                int rndPlayer = new Random().Next(0, active.Length - 1);
                string dis = active[rndPlayer].Info.DisplayedName ?? active[rndPlayer].Name;
                rawMessage = rawMessage.Replace("$moron", dis + "&r is a complete and total moron.");
            }

            rawMessage = rawMessage.Replace("$irc", ConfigKey.IRCBotEnabled.Enabled() ? ConfigKey.IRCBotChannels.GetString() : "No IRC");

            if (player.Can(Permission.UseColorCodes))
            {
                rawMessage = rawMessage.Replace("$lime", "&a");     //alternate color codes for ease if you can't remember the codes
                rawMessage = rawMessage.Replace("$aqua", "&b");
                rawMessage = rawMessage.Replace("$cyan", "&b");
                rawMessage = rawMessage.Replace("$red", "&c");
                rawMessage = rawMessage.Replace("$magenta", "&d");
                rawMessage = rawMessage.Replace("$pink", "&d");
                rawMessage = rawMessage.Replace("$yellow", "&e");
                rawMessage = rawMessage.Replace("$white", "&f");
                rawMessage = rawMessage.Replace("$navy", "&1");
                rawMessage = rawMessage.Replace("$darkblue", "&1");
                rawMessage = rawMessage.Replace("$green", "&2");
                rawMessage = rawMessage.Replace("$teal", "&3");
                rawMessage = rawMessage.Replace("$maroon", "&4");
                rawMessage = rawMessage.Replace("$purple", "&5");
                rawMessage = rawMessage.Replace("$olive", "&6");
                rawMessage = rawMessage.Replace("$gold", "&6");
                rawMessage = rawMessage.Replace("$silver", "&7");
                rawMessage = rawMessage.Replace("$grey", "&8");
                rawMessage = rawMessage.Replace("$gray", "&8");
                rawMessage = rawMessage.Replace("$blue", "&9");
                rawMessage = rawMessage.Replace("$black", "&0");
            }
            if (!player.Can(Permission.ChatWithCaps))
            {
                int caps = 0;
                for (int i = 0; i < rawMessage.Length; i++)
                {
                    if (!char.IsUpper(rawMessage[i])) continue;
                    caps++;
                    if (caps <= ConfigKey.MaxCaps.GetInt()) continue;
                    rawMessage = rawMessage.ToLower();
                    player.Message("Your message was changed to lowercase as it exceeded the maximum amount of capital letters.");
                }
            }

            if (!player.Can(Permission.Swear))
            {
                if (!File.Exists("SwearWords.txt"))
                {
                    StringBuilder sb = new StringBuilder();
                    string[] words = new Uri("http://gemz.christplay.x10host.com/download/swears.txt").GetUrlSourceAsList().ToArray();
                    foreach (string word in words)
                    {
                        sb.Append(word);
                    }
                    File.WriteAllText("SwearWords.txt", sb.ToString());
                }
                string CensoredText = Color.ReplacePercentCodes(ConfigKey.SwearName.GetString()) + Color.White;
                if (ConfigKey.SwearName.GetString() == null)
                {
                    CensoredText = "&CBlock&F";
                }

                const string PatternTemplate = @"\b({0})(s?)\b";
                const RegexOptions Options = RegexOptions.IgnoreCase;

                if (Swears.Count == 0)
                {
                    Swears.AddRange(File.ReadAllLines("SwearWords.txt").
                        Where(line => line.StartsWith("#") == false || line.Trim().Equals(string.Empty)));
                }

                if (badWordMatchers == null)
                {
                    badWordMatchers = Swears.
                        Select(x => new Regex(string.Format(PatternTemplate, x), Options));
                }

                string output = badWordMatchers.
                    Aggregate(rawMessage, (current, matcher) => matcher.Replace(current, CensoredText));
                rawMessage = output;
            }

            return rawMessage;
        }
        /// <summary> Sends a global (white) chat as a normal message (MessageType.Chat)</summary>
        /// <param name="player"> Player writing the message. </param>
        /// <param name="rawMessage"> Message text. </param>
        /// <returns> True if message was sent, false if it was cancelled by an event callback. </returns>
        public static bool SendGlobal([NotNull] Player player, [NotNull] string rawMessage)
        {
            return SendGlobal(player, rawMessage, MessageType.Chat);
        }
        /// <summary> Sends a global (white) chat as specified message type</summary>
        /// <param name="player"> Player writing the message. </param>
        /// <param name="rawMessage"> Message text. </param>
        /// <param name="type">MessageType</param>
        /// <returns> True if message was sent, false if it was cancelled by an event callback. </returns>
        public static bool SendGlobal([NotNull] Player player, [NotNull] string rawMessage, MessageType type)
        {
            if (player == null) throw new ArgumentNullException("player");
            if (rawMessage == null) throw new ArgumentNullException("rawMessage");
            if (!MessageTypeUtil.Enabled() || rawMessage.Length >= 64) type = MessageType.Chat;
            string OriginalMessage = rawMessage;
            if (Server.Moderation && !Server.VoicedPlayers.Contains(player) && player.World != null)
            {
                player.Message("&WError: Server Moderation is activated. Message failed to send");
                return false;
            }

            rawMessage = FormatMessage(rawMessage, player); 
            var recepientList = Server.Players.NotIgnoring(player); //if (player.World.WorldOnlyChat) recepientList = player.World.Players.NotIgnoring(player);


            string formattedMessage = $"{player.ClassyName}&F: {rawMessage}";
            if (!MessageTypeUtil.Enabled() || rawMessage.Length >= 64) type = MessageType.Chat;
            var e = new ChatSendingEventArgs(player,
                                              rawMessage,
                                              formattedMessage,
                                              ChatMessageType.Global,
                                              recepientList,
                                              type);

            if (!SendInternal(e)) return false;
            Network.Remote.Server.Chats.Add(
                new ServerLog
                {
                    Sender = player.Name,
                    Message = OriginalMessage,
                    ChatMode = ""
                }
            );

            Logger.Log(LogType.GlobalChat,
                        "{0}: {1}", player.Name, OriginalMessage);
            return true;
        }
        
        public static bool SendAdmin(Player player, string rawMessage)
        {
            if (player == null) throw new ArgumentNullException("player");
            if (rawMessage == null) throw new ArgumentNullException("rawMessage");

            var recepientList = Server.Players.Can(Permission.ReadAdminChat)
                                              .NotIgnoring(player);
            rawMessage = FormatMessage(rawMessage, player);
            string formattedMessage = $"&9(Admin){player.ClassyName}&b: {rawMessage}";

            var e = new ChatSendingEventArgs(player,
                rawMessage,
                formattedMessage,
                ChatMessageType.Staff,
                recepientList,
                MessageType.Chat
            );

            if (!SendInternal(e)) return false;
            Network.Remote.Server.Chats.Add(
                new ServerLog
                {
                    Sender = player.Name,
                    Message = rawMessage,
                    ChatMode = "Admin"
                }
            );
            Logger.Log(LogType.GlobalChat, "(Admin){0}: {1}", player.Name, rawMessage);
            return true;
        }

        public static bool SendCustom(Player player, string rawMessage)
        {
            if (player == null) throw new ArgumentNullException("player");
            if (rawMessage == null) throw new ArgumentNullException("rawMessage");

            var recepientList = Server.Players.Can(Permission.ReadCustomChat)
                                              .NotIgnoring(player);
            rawMessage = FormatMessage(rawMessage, player);
            string formattedMessage = string.Format(Color.Custom + "({2}){0}&b: {1}",
                                                     player.ClassyName,
                                                     rawMessage, ConfigKey.CustomChatName.GetString());

            var e = new ChatSendingEventArgs(player,
                rawMessage,
                formattedMessage,
                ChatMessageType.Staff,
                recepientList,
                MessageType.Chat);

            if (!SendInternal(e)) return false;
            Network.Remote.Server.Chats.Add(
                new ServerLog
                {
                    Sender = player.Name,
                    Message = rawMessage,
                    ChatMode = "Custom"
                }
            );
            Logger.Log(LogType.GlobalChat, "({2}){0}: {1}", player.Name, rawMessage, ConfigKey.CustomChatName.GetString());
            return true;
        }


        /// <summary> Sends an action message (/Me). </summary>
        /// <param name="player"> Player writing the message. </param>
        /// <param name="rawMessage"> Message text. </param>
        /// <returns> True if message was sent, false if it was cancelled by an event callback. </returns>
        public static bool SendMe([NotNull] Player player, [NotNull] string rawMessage)
        {
            if (player == null) throw new ArgumentNullException("player");
            if (rawMessage == null) throw new ArgumentNullException("rawMessage");

            var recepientList = Server.Players.NotIgnoring(player);
            rawMessage = FormatMessage(rawMessage, player);
            string formattedMessage = $"&M*{player.Name} {rawMessage}";

            var e = new ChatSendingEventArgs(player,
                rawMessage,
                formattedMessage,
                ChatMessageType.Me,
                recepientList,
                MessageType.Chat);

            if (!SendInternal(e)) return false;
            Network.Remote.Server.Chats.Add(
                new ServerLog
                {
                    Sender = player.Name,
                    Message = rawMessage,
                    ChatMode = "Me"
                }
            );
            Logger.Log(LogType.GlobalChat,
                        "(me){0}: {1}", player.Name, rawMessage);
            return true;
        }


        /// <summary> Sends a private message (PM). Does NOT send a copy of the message to the sender. </summary>
        /// <param name="from"> Sender player. </param>
        /// <param name="to"> Recepient player. </param>
        /// <param name="rawMessage"> Message text. </param>
        /// <returns> True if message was sent, false if it was cancelled by an event callback. </returns>
        public static bool SendPM([NotNull] Player from, [NotNull] Player to, [NotNull] string rawMessage)
        {
            if (from == null) throw new ArgumentNullException("from");
            if (to == null) throw new ArgumentNullException("to");
            if (rawMessage == null) throw new ArgumentNullException("rawMessage");
            var recepientList = new[] { to };

            string formattedMessage = $"&Pfrom {from.Name}: {rawMessage}";

            var e = new ChatSendingEventArgs(from,
                rawMessage,
                formattedMessage,
                ChatMessageType.PM,
                recepientList,
                MessageType.Chat);

            if (!SendInternal(e)) return false;

            Network.Remote.Server.Chats.Add(
                new ServerLog
                {
                    Sender = from.Name,
                    Message = rawMessage,
                    ChatMode = $"PM: {to.Name}"
                }
            );
            Logger.Log(LogType.PrivateChat,
                        "{0} to {1}: {2}",
                        from.Name, to.Name, rawMessage);
            return true;
        }


        /// <summary> Sends a rank-wide message (@@Rank message). </summary>
        /// <param name="player"> Player writing the message. </param>
        /// <param name="rank"> Target rank. </param>
        /// <param name="rawMessage"> Message text. </param>
        /// <returns> True if message was sent, false if it was cancelled by an event callback. </returns>
        public static bool SendRank([NotNull] Player player, [NotNull] Rank rank, [NotNull] string rawMessage)
        {
            if (player == null) throw new ArgumentNullException("player");
            if (rank == null) throw new ArgumentNullException("rank");
            if (rawMessage == null) throw new ArgumentNullException("rawMessage");

            var recepientList = rank.Players.NotIgnoring(player).Union(player);
            rawMessage = FormatMessage(rawMessage, player);
            string formattedMessage = $"&P({rank.ClassyName}&P){player.Name}: {rawMessage}";

            var e = new ChatSendingEventArgs(player,
                rawMessage,
                formattedMessage,
                ChatMessageType.Rank,
                recepientList,
                MessageType.Chat);

            if (!SendInternal(e)) return false;
            Network.Remote.Server.Chats.Add(
                new ServerLog
                {
                    Sender = player.Name,
                    Message = rawMessage,
                    ChatMode = $"Rank: {rank.Name}"
                }
            );
            Logger.Log(LogType.RankChat,
                        "(rank {0}){1}: {2}",
                        rank.Name, player.Name, rawMessage);
            return true;
        }


        /// <summary> Sends a world-specific message (!World message). </summary>
        /// <param name="player"> Player writing the message. </param>
        /// <param name="world"> Target world. </param>
        /// <param name="rawMessage"> Message text. </param>
        /// <returns> True if message was sent, false if it was cancelled by an event callback. </returns>
        public static bool SendWorld([NotNull] Player player, [NotNull] World world, [NotNull] string rawMessage)
        {
            if (player == null) throw new ArgumentNullException("player");
            if (world == null)
            {
                if (player.World == null)
                {
                    player.Message("Please specify a world name when using WorldChat from console.");
                    return false;
                }
            }
            if (rawMessage == null) throw new ArgumentNullException("rawMessage");

            var recepientList = world.Players.NotIgnoring(player).Union(player);
            rawMessage = FormatMessage(rawMessage, player);
            string formattedMessage = $"&P({world.ClassyName}&P){player.Name}: {rawMessage}";

            var e = new ChatSendingEventArgs(player,
                rawMessage,
                formattedMessage,
                ChatMessageType.World, recepientList,
                MessageType.Chat);

            if (!SendInternal(e)) return false;
            Network.Remote.Server.Chats.Add(
                new ServerLog
                {
                    Sender = player.Name,
                    Message = rawMessage,
                    ChatMode = $"World: {world.Name}"
                }
            );
            Logger.Log(LogType.GlobalChat, "({0}){1}: {2}", world.Name, player.Name, rawMessage);
            return true;
        }


        /// <summary> Sends a global announcement (/Say). </summary>
        /// <param name="player"> Player writing the message. </param>
        /// <param name="rawMessage"> Message text. </param>
        /// <returns> True if message was sent, false if it was cancelled by an event callback. </returns>
        public static bool SendSay([NotNull] Player player, [NotNull] string rawMessage, MessageType type)
        {
            if (player == null) throw new ArgumentNullException("player");
            if (rawMessage == null) throw new ArgumentNullException("rawMessage");
            if (!MessageTypeUtil.Enabled() || rawMessage.Length >= 64) type = MessageType.Chat;
            var recepientList = Server.Players.NotIgnoring(player);
            rawMessage = FormatMessage(rawMessage, player);
            string formattedMessage = Color.Say + rawMessage;

            var e = new ChatSendingEventArgs(player,
                rawMessage,
                formattedMessage,
                ChatMessageType.Say,
                recepientList,
                type);

            if (!SendInternal(e)) return false;
            Network.Remote.Server.Chats.Add(
                new ServerLog
                {
                    Sender = player.Name,
                    Message = rawMessage,
                    ChatMode = "Say"
                }
            );
            Logger.Log(LogType.GlobalChat,
                        "(say){0}: {1}", player.Name, rawMessage);
            return true;
        }


        /// <summary> Sends a staff message (/Staff). </summary>
        /// <param name="player"> Player writing the message. </param>
        /// <param name="rawMessage"> Message text. </param>
        /// <returns> True if message was sent, false if it was cancelled by an event callback. </returns>
        public static bool SendStaff([NotNull] Player player, [NotNull] string rawMessage)
        {
            if (player == null) throw new ArgumentNullException("player");
            if (rawMessage == null) throw new ArgumentNullException("rawMessage");

            var recepientList = PlayerEnumerable.Can(Server.Players, Permission.ReadStaffChat)
                                              .NotIgnoring(player)
                                              .Union(player);
            rawMessage = FormatMessage(rawMessage, player);
            string formattedMessage = $"&P(staff){player.ClassyName}&P: {rawMessage}";

            var e = new ChatSendingEventArgs(player,
                rawMessage,
                formattedMessage,
                ChatMessageType.Staff,
                recepientList,
                MessageType.Chat);

            if (!SendInternal(e)) return false;

            Network.Remote.Server.Chats.Add(
                new ServerLog
                {
                    Sender = player.Name,
                    Message = rawMessage,
                    ChatMode = "Staff"
                }
            );
            Logger.Log(LogType.GlobalChat,
                        "(staff){0}: {1}", player.Name, rawMessage);
            return true;
        }


        private static bool SendInternal([NotNull] ChatSendingEventArgs e)
        {
            if (e == null) throw new ArgumentNullException(nameof(e));
            if (RaiseSendingEvent(e)) return false;

            int recepients = e.RecepientList.Message(e.FormattedMessage, e.MessageType);

            // Only increment the MessagesWritten count if someone other than
            // the player was on the recepient list.
            if (recepients > 1 || recepients == 1 && e.RecepientList.First() != e.Player)
            {
                e.Player.Info.ProcessMessageWritten();
            }

            RaiseSentEvent(e, recepients);
            return true;
        }


        /// <summary> Checks for unprintable or illegal characters in a message. </summary>
        /// <param name="message"> Message to check. </param>
        /// <returns> True if message contains invalid chars. False if message is clean. </returns>
        public static bool ContainsInvalidChars(string message)
        {
            return message.Any(t => t < ' ' || t == '&' || t > '~');
        }


        /// <summary> Determines the type of player-supplies message based on its syntax. </summary>
        internal static RawMessageType GetRawMessageType(string message)
        {
            if (string.IsNullOrEmpty(message)) return RawMessageType.Invalid;
            if (message == "/") return RawMessageType.RepeatCommand;
            if (message.Equals("/ok", StringComparison.OrdinalIgnoreCase)) return RawMessageType.Confirmation;
            if (message.EndsWith(" /")) return RawMessageType.PartialMessage;
            if (message.EndsWith(" //")) message = message.Substring(0, message.Length - 1);
            if (message.EndsWith("Ω")) return RawMessageType.LongerMessage;

            switch (message[0])
            {
                case '/':
                    if (message.Length < 2)
                    {
                        // message too short to be a command
                        return RawMessageType.Invalid;
                    }
                    if (message[1] == '/')
                    {
                        // escaped slash in the beginning: "//blah"
                        return RawMessageType.Chat;
                    }
                    if (message[1] != ' ')
                    {
                        // normal command: "/cmd"
                        return RawMessageType.Command;
                    }
                    return RawMessageType.Invalid;

                case '@':
                    if (message.Length < 4 || message.IndexOf(' ') == -1)
                    {
                        // message too short to be a PM or rank chat
                        return RawMessageType.Invalid;
                    }
                    if (message[1] == '@')
                    {
                        return RawMessageType.RankChat;
                    }
                    if (message[1] == '-' && message[2] == ' ')
                    {
                        // name shortcut: "@- blah"
                        return RawMessageType.PrivateChat;
                    }
                    if (message[1] == ' ' && message.IndexOf(' ', 2) != -1)
                    {
                        // alternative PM notation: "@ name blah"
                        return RawMessageType.PrivateChat;
                    }
                    if (message[1] != ' ')
                    {
                        // primary PM notation: "@name blah"
                        return RawMessageType.PrivateChat;
                    }
                    return RawMessageType.Invalid;

                case '!':
                    if (message.Length >= 2 && message[1] == '!')
                    {
                        // escaped exclamation mark in the beginning: "!!blah"
                        return RawMessageType.Chat;
                    }
                    if (message.Length < 2 || message.IndexOf(' ') == -1)
                    {
                        // message too short
                        return RawMessageType.Invalid;
                    }
                    if (message[1] == ' ')
                    {
                        // alternative WC notation: "! WorldName msg"
                        return RawMessageType.WorldChat;
                    }
                    if (message[1] == '-' && message[2] == ' ')
                    {
                        // name shortcut: "!- blah"
                        return RawMessageType.WorldChat;
                    }
                    if (message[1] != ' ')
                    {
                        // primary WC notation: "!WorldName msg"
                        return RawMessageType.WorldChat;
                    }
                    return RawMessageType.Invalid;
            }
            return RawMessageType.Chat;
        }


        #region Events

        static bool RaiseSendingEvent(ChatSendingEventArgs args)
        {
            var h = Sending;
            if (h == null) return false;
            h(null, args);
            return args.Cancel;
        }


        static void RaiseSentEvent(ChatSendingEventArgs args, int count)
        {
            var h = Sent;
            if (h != null) h(null, new ChatSentEventArgs(args.Player, args.Message, args.FormattedMessage,
                                                           args.ChatMessageType, args.RecepientList, count));
        }


        /// <summary> Occurs when a chat message is about to be sent. Cancellable. </summary>
        public static event EventHandler<ChatSendingEventArgs> Sending;

        /// <summary> Occurs after a chat message has been sent. </summary>
        public static event EventHandler<ChatSentEventArgs> Sent;

        #endregion
    }


    public enum ChatMessageType
    {
        Other,
        Global,
        IRC,
        Me,
        PM,
        Rank,
        Say,
        Staff,
        World
    }



    /// <summary> Type of message sent by the player. Determined by CommandManager.GetMessageType() </summary>
    public enum RawMessageType
    {
        /// <summary> Unparseable chat syntax (rare). </summary>
        Invalid,

        /// <summary> Normal (white) chat. </summary>
        Chat,

        /// <summary> Command. </summary>
        Command,

        /// <summary> Confirmation (/ok) for a previous command. </summary>
        Confirmation,

        /// <summary> Partial message (ends with " /"). </summary>
        PartialMessage,

        /// <summary> Private message. </summary>
        PrivateChat,

        /// <summary> Rank chat. </summary>
        RankChat,

        /// <summary> Repeat of the last command ("/"). </summary>
        RepeatCommand,

        /// <summary> Chat private to the world you are in. </summary>
        WorldChat,

        /// <summary> LongerMessages partial message. </summary>
        LongerMessage,
    }
}


namespace GemsCraft.Events
{
    public sealed class ChatSendingEventArgs : EventArgs, IPlayerEvent, ICancellableEvent
    {
        internal ChatSendingEventArgs(Player player, string message, string formattedMessage,
                                       ChatMessageType messageType, IEnumerable<Player> recepientList,
                                       MessageType type)
        {
            Player = player;
            Message = message;
            ChatMessageType = messageType;
            RecepientList = recepientList;
            FormattedMessage = formattedMessage;
            if (!MessageTypeUtil.Enabled() || message.Length >= 64) type = MessageType.Chat;
            MessageType = type;
        }

        public Player Player { get; }
        public string Message { get; }
        public string FormattedMessage { get; set; }
        public ChatMessageType ChatMessageType { get; }
        public MessageType MessageType { get; }
        public readonly IEnumerable<Player> RecepientList;
        public bool Cancel { get; set; }
    }


    public sealed class ChatSentEventArgs : EventArgs, IPlayerEvent
    {
        internal ChatSentEventArgs(Player player, string message, string formattedMessage,
                                    ChatMessageType messageType, IEnumerable<Player> recepientList, int recepientCount)
        {
            Player = player;
            Message = message;
            MessageType = messageType;
            RecepientList = recepientList;
            FormattedMessage = formattedMessage;
            RecepientCount = recepientCount;
        }

        public Player Player { get; }
        public string Message { get; }
        public string FormattedMessage { get; }
        public ChatMessageType MessageType { get; }
        public IEnumerable<Player> RecepientList { get; }
        public int RecepientCount { get; }
    }
}
