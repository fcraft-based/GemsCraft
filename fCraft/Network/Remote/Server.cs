using System;
using System.Net;
using System.Text;
using System.Threading;
using GemsCraft.Commands;
using GemsCraft.fSystem;
using Newtonsoft.Json;

namespace GemsCraft.Network.Remote
{
    public class Server
    {
        private static readonly HttpListener HttpListener = new HttpListener();
        public static bool Start()
        {
            try
            {
                Logger.Log(LogType.SystemActivity, "Starting remote control server...");
                HttpListener.Prefixes.Add($"http://localhost:{ConfigKey.RemoteControlPort.GetInt()}/");
                HttpListener.Start();
                Thread responseThread = new Thread(ResponseThread);
                responseThread.Start();
                return true;
            }
            catch (Exception e)
            {
                Logger.Log(LogType.Error, $"Unable to start control remote server (Reason: {e.Message}");
                return false;
            }
        }

        private static void ReceiveInput(HttpListenerRequest request)
        {
            var x = request.QueryString;

            int loopCount = 0;
            foreach (var item in x)
            {
                string param = item.ToString();
                string value = x.GetValues(loopCount)?[0];
                ExecuteUserCommand(param.ToLower(), value);
                loopCount++;
            }
        }

        private static void ExecuteUserCommand(string param, string value)
        {
            if (param.Equals("shutdown"))
            {
                Actions.ShutdownServer(value);
            }
            else if (param.Equals("restart"))
            {
                Actions.RestartServer();
            }
            else // Assume it's the name of a command/alias, and the value is the arguments (args in json array)
            {
                string command = param;
                string[] args = JsonConvert.DeserializeObject<string[]>(value);
                Actions.RunCommand(command, args);
            }
        }

        private static void ResponseThread()
        {
            while (true)
            {
                HttpListenerContext context = HttpListener.GetContext();
                byte[] responseArray = Encoding.UTF8.GetBytes($"<html><head><title>GemsCraft Remote Control Server -- Port {ConfigKey.RemoteControlPort.GetInt()}</title></head>" +
                                                               $"<body>Welcome to the <strong>Localhost server</strong> -- <em>port {ConfigKey.RemoteControlPort.GetInt()}!</em></body></html>"); // get the bytes to response
                context.Response.OutputStream.Write(responseArray, 0, responseArray.Length); // write bytes to the output stream
                ReceiveInput(context.Request);
                context.Response.KeepAlive = false; // set the KeepAlive bool to false
                context.Response.Close(); // close the connection
            }
        }
    }
}
