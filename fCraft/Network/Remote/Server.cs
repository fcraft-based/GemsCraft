using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using GemsCraft.Events;
using GemsCraft.fSystem;
using GemsCraft.Configuration;
using GemsCraft.Players;
using GemsCraft.Utils;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace GemsCraft.Network.Remote
{
    public struct ServerLog
    {
        public string Sender;
        public string Message;
        public string ChatMode;
    }
    public class Server
    {
        public static List<string> Logs = new List<string>();
        public static List<ServerLog> Chats = new List<ServerLog>();
        internal static TcpListener Listener;
        private static SchedulerTask _checkConnectionsTask;

        public static bool Start()
        {
            return true;
        }
        private static bool StartServer()
        {
            // string exIP = "http://www.classicube.net/api/myip".GetStringFromUrl();
            Listener = new TcpListener(IPAddress.Any, 12948);
            //TcpClient client = default(TcpClient);
            try
            {
                Logger.Log(LogType.SystemActivity, "Starting Remote Control Server...");
                Listener.Start();
                _checkConnectionsTask = Scheduler.NewTask(CheckConnections).RunForever(fSystem.Server.CheckConnectionsInterval);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            };
        }

        private static void CheckConnections(SchedulerTask param)
        {
            TcpListener listenerCache = Listener;
            if (listenerCache == null || !listenerCache.Pending()) return;
            try
            {
                Socket socket = listenerCache.AcceptSocket();
                byte[] b = new byte[100000];
                int k = socket.Receive(b);
                string response = "";
                for (int i = 0; i < k; i++)
                {
                    response += Convert.ToChar(b[i]);
                }
                Console.WriteLine($"Received: {response}");
                Input[] input = JsonConvert.DeserializeObject<Input[]>(response);
                ASCIIEncoding asen = new ASCIIEncoding();
                socket.Send(asen.GetBytes(GetResponse(input)));
            }
            catch (ArgumentException ex)
            {
                /*Logger.Log(LogType.Error,
                    "Server.CheckConnections: Could not accept incoming connection: {0}", ex);*/
                Console.WriteLine(ex);
            }
        }
        private struct Input
        {
#pragma warning disable 649
            public readonly string Type;
            public readonly string Value;
#pragma warning restore 649
        }
        private static string GetResponse(IReadOnlyCollection<Input> inputs)
        {
            foreach (Input input in inputs)
            {
                if (input.Type == null) break;
                if (input.Value == null) break;
                string type = input.Type.ToLower();
                string value = input.Value.ToLower();
                if (type != "player" && type != "sinfo")
                {
                    return "Need player auth first from client!";
                }
                switch (type)
                {
                    case "sinfo":
                    {
                        ServerInfo sInfo = new ServerInfo
                        {
                            Name = ConfigKey.ServerName.GetString(),
                            Version = Updater.LatestStable.ToString()
                        };
                        return JsonConvert.SerializeObject(sInfo);
                    }
                    case "player":
                    {
                        PlayerInfo[] players = PlayerDB.PlayerInfoList;
                        PlayerInfo pInfo = null;
                        foreach (PlayerInfo p in players)
                        {
                            if (p.Name != value) continue;
                            pInfo = p;
                        }

                        if (pInfo == null) return "Player not found";
                        if (inputs.Count == 1) // Client is requesting player info
                        {
                            return pInfo.ToString();
                        }
                        foreach (Input sInput in inputs)
                        {
                            string sType = sInput.Type.ToLower();
                            string sValue = sInput.Value.ToLower();
                            switch (sType)
                            {
                                case "shutdown":
                                {
                                    Actions.ShutdownServer(pInfo, sValue);
                                    return "success";
                                }
                                case "restart":
                                {
                                    Actions.RestartServer(pInfo);
                                    return "success";
                                }
                                case "getpermission":
                                {
                                    return pInfo.Can((Permission)int.Parse(value)) ? "true" : "false";
                                }
                                case "getchat":
                                {
                                    string json = JsonConvert.SerializeObject(Chats);
                                    return json;
                                }
                                case "getlogs":
                                {
                                    string json = JsonConvert.SerializeObject(Logs);
                                    return json;
                                }
                                case "player":
                                {
                                    break;
                                }
                                default: // Assume it is a command being executed
                                {
                                    // Player is already handled
                                    string command = sType;
                                    string[] args = JsonConvert.DeserializeObject<string[]>(sValue);
                                    Actions.RunCommand(pInfo, command, args);
                                    return "success";
                                }
                            }
                        }

                        break;
                    }
                }
            }

            return "Invalid input type";
        }
        

        private static bool _firstRun = true;
        public static void UpdateServer(object sender, EventArgs eventArgs)
        {
            UpdateServer();
        }

        public static void RemoveServer(object sender, ShutdownEventArgs shutdownEventArgs)
        {
            string url = $"http://gemz.christplay.x10host.com/serverlist/delete.php?id={ServerId}";
            new Uri(url).Execute(out _);
            File.Delete("db_connected");
        }

        internal static string ServerId;
        public static void UpdateServer()
        {
            _firstRun = !File.Exists("db_connected");
            string id = (ConfigKey.ServerName.GetString() + fSystem.Server.ExternalIP).HashMD5();
            ServerId = id;
            string method = _firstRun ? "connect" : "update";
            _firstRun = false;
            var x = File.CreateText("db_connected");
            x.Close();
            string url = $"http://gemz.christplay.x10host.com/serverlist/{method}.php?" +
                         $"id={id}&" +
                         $"name={ConfigKey.ServerName.GetString()}&" +
                         $"IP={fSystem.Server.ExternalIP}&" +
                         $"port={ConfigKey.RemoteControlPort.GetInt()}&" +
                         $"players={fSystem.Server.Players.Length}&" +
                         $"max={ConfigKey.MaxPlayers.GetInt()}&" +
                         $"version={Updater.LatestStable.ToString()}";
            new Uri(url).Execute(out _);
        }

        private struct ServerInfo
        {
            public string Name { [UsedImplicitly] get; set; }
            public string Version { [UsedImplicitly] get; set; }
        }
    }
}
