// Copyright 2009-2012 Matvei Stefarov <me@matvei.org>
//Modified LegendCraft Team

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using GemsCraft.Commands;
using GemsCraft.Commands.Command_Handlers;
using GemsCraft.Drawing;
using GemsCraft.Events;
using GemsCraft.Configuration;
using GemsCraft.Network;
using GemsCraft.Players;
using GemsCraft.Plugins;
using GemsCraft.Portals;
using GemsCraft.Utils;
using GemsCraft.Worlds;
using GemsCraft.Worlds.CustomBlocks;
using JetBrains.Annotations;
using Map = GemsCraft.Worlds.Map;
using ThreadState = System.Threading.ThreadState;

namespace GemsCraft.fSystem {
    /// <summary> Core of an fCraft server. Manages startup/shutdown, online player
    /// sessions, and global events and scheduled tasks. </summary>
    public static partial class Server {

        /// <summary> Time when the server started (UTC). Used to check uptime. </summary>
        public static DateTime StartTime { get; private set; }

        internal static int MaxUploadSpeed,   // set by Config.ApplyConfig
                            BlockUpdateThrottling; // used when there are no players in a world

        internal const int MaxSessionPacketsPerTick = 128, // used when there are no players in a world
                           MaxBlockUpdatesPerTick = 100000; // used when there are no players in a world
        internal static float TicksPerSecond;

        public static List<Bot> Bots = new List<Bot>();

        //order: highlight name, id, first position, second position, color, percent opaque
        public static Dictionary<string, Tuple<int, Vector3I, Vector3I, System.Drawing.Color, int>> Highlights = new Dictionary<string, Tuple<int, Vector3I, Vector3I, System.Drawing.Color, int>>();

        public static bool AutoRankEnabled = false;

        public static bool IsRestarting = false;
        public static bool HSaverOn = false;

        public static bool Moderation = false;

        public static List<Player> VoicedPlayers = new List<Player>();

        public static List<Player> TempBans = new List<Player>();

        public static List<string> Entities = new List<string>();
        public static List<int> EntityIDs = new List<int>();

        // networking
        static TcpListener listener;
        public static IPAddress InternalIP { get; private set; }
        public static IPAddress ExternalIP { get; private set; }
        public static string VerifiedUser = "";

        public static int Port { get; private set; }      

        public static Uri Uri { get; internal set; }

        public static string BaseDirectory { get; private set; }

        public static TexturePack TexturePack { get; internal set; }

        #region Command-line args

        static readonly Dictionary<ArgKey, string> Args = new Dictionary<ArgKey, string>();

        /// <summary> Returns value of a given command-line argument (if present). Use HasArg to check flag arguments. </summary>
        /// <param name="key"> Command-line argument name (enumerated) </param>
        /// <returns> Value of the command-line argument, or null if this argument was not set or argument is a flag. </returns>
        [CanBeNull]
        public static string GetArg( ArgKey key ) {
            if( Args.ContainsKey( key ) ) {
                return Args[key];
            } else {
                return null;
            }
        }

        /// <summary> Checks whether a command-line argument was set. </summary>
        /// <param name="key"> Command-line argument name (enumerated) </param>
        /// <returns> True if given argument was given. Otherwise false. </returns>
        public static bool HasArg( ArgKey key ) {
            return Args.ContainsKey( key );
        }


        /// <summary> Produces a string containing all recognized arguments that wereset/passed to this instance of GemsCraft. </summary>
        /// <returns> A string containing all given arguments, or an empty string if none were set. </returns>
        public static string GetArgString() {
            return String.Join( " ", GetArgList() );
        }


        /// <summary> Produces a list of arguments that were passed to this instance of GemsCraft. </summary>
        /// <returns> An array of strings, formatted as --key="value" (or, for flag arguments, --key).
        /// Returns an empty string array if no arguments were set. </returns>
        public static string[] GetArgList() {
            List<string> argList = new List<string>();
            foreach( var pair in Args )
            {
                argList.Add(pair.Value != null
                    ? $"--{pair.Key.ToString().ToLower()}=\"{pair.Value}\""
                    : $"--{pair.Key.ToString().ToLower()}");
            }
            return argList.ToArray();
        }

        #endregion


        #region Initialization and Startup        

        // flags used to ensure proper initialization order
        static bool libraryInitialized,
                    serverInitialized;
        public static bool IsRunning { get; private set; }

        /// <summary> Reads command-line switches and sets up paths and logging.
        /// This should be called before any other library function.
        /// Note to frontend devs: Subscribe to log-related events before calling this.
        /// Does not raise any events besides Logger.Logged.
        /// Throws exceptions on failure. </summary>
        /// <param name="rawArgs"> string arguments passed to the frontend (if any). </param>
        /// <exception cref="System.InvalidOperationException"> If library is already initialized. </exception>
        /// <exception cref="System.IO.IOException"> Working path, log path, or map path could not be set. </exception>
        public static void InitLibrary([NotNull] IEnumerable<string> rawArgs, bool isLauncher)
        {
            BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if (rawArgs == null) throw new ArgumentNullException("rawArgs");
            if (libraryInitialized && !isLauncher)
            {
                throw new InvalidOperationException("GemsCraft library is already initialized");
            }
            ServicePointManager.Expect100Continue = false;

            // try to parse arguments
            foreach (string arg in rawArgs)
            {
                if (arg.StartsWith("--"))
                {
                    string argKeyName, argValue;
                    if (arg.Contains('='))
                    {
                        argKeyName = arg.Substring(2, arg.IndexOf('=') - 2).ToLower().Trim();
                        argValue = arg.Substring(arg.IndexOf('=') + 1).Trim();
                        if (argValue.StartsWith("\"") && argValue.EndsWith("\""))
                        {
                            argValue = argValue.Substring(1, argValue.Length - 2);
                        }

                    }
                    else
                    {
                        argKeyName = arg.Substring(2);
                        argValue = null;
                    }

                    if (EnumUtil.TryParse(argKeyName, out ArgKey key, true))
                    {
                        Args.Add(key, argValue);
                    }
                    else
                    {
                        Console.Error.WriteLine("Unknown argument: {0}", arg);
                    }
                }
                else
                {
                    Console.Error.WriteLine("Unknown argument: {0}", arg);
                }
            }

            // before we do anything, set path to the default location
            Directory.SetCurrentDirectory(Paths.WorkingPath);

            // set custom working path (if specified)
            string path = GetArg(ArgKey.Path);
            if (path != null && Paths.TestDirectory("WorkingPath", path, true))
            {
                Paths.WorkingPath = Path.GetFullPath(path);
                Directory.SetCurrentDirectory(Paths.WorkingPath);
            }
            else if (Paths.TestDirectory("WorkingPath", Paths.WorkingPathDefault, true))
            {
                Paths.WorkingPath = Path.GetFullPath(Paths.WorkingPathDefault);
                Directory.SetCurrentDirectory(Paths.WorkingPath);
            }
            else
            {
                throw new IOException("Could not set the working path.");
            }

            // set log path
            string logPath = GetArg(ArgKey.LogPath);
            if (logPath != null && Paths.TestDirectory("LogPath", logPath, true))
            {
                Paths.LogPath = Path.GetFullPath(logPath);
            }
            else if (Paths.TestDirectory("LogPath", Paths.LogPathDefault, true))
            {
                Paths.LogPath = Path.GetFullPath(Paths.LogPathDefault);
            }
            else
            {
                throw new IOException("Could not set the log path.");
            }

            if (HasArg(ArgKey.NoLog))
            {
                Logger.Enabled = false;
            }
            else
            {
                Logger.MarkLogStart();
            }

            // set map path
            string mapPath = GetArg(ArgKey.MapPath);
            if (mapPath != null && Paths.TestDirectory("MapPath", mapPath, true))
            {
                Paths.MapPath = Path.GetFullPath(mapPath);
                Paths.IgnoreMapPathConfigKey = true;
            }
            else if (Paths.TestDirectory("MapPath", Paths.MapPathDefault, true))
            {
                Paths.MapPath = Path.GetFullPath(Paths.MapPathDefault);
            }
            else
            {
                throw new IOException("Could not set the map path.");
            }

            // set config path
            Paths.ConfigFileName = Paths.ConfigFileNameDefault;
            string configFile = GetArg(ArgKey.Config);
            if (configFile != null)
            {
                if (Paths.TestFile("config.json", configFile, false, FileAccess.Read))
                {
                    Paths.ConfigFileName = new FileInfo(configFile).FullName;
                }
            }

            if (MonoCompat.IsMono)
            {
                Logger.Log(LogType.Debug, "Running on Mono {0}", MonoCompat.MonoVersion);
            }

#if DEBUG_EVENTS
            Logger.PrepareEventTracing();
#endif

            Logger.Log(LogType.Debug, "Working directory: {0}", Directory.GetCurrentDirectory());
            Logger.Log(LogType.Debug, "Log path: {0}", Path.GetFullPath(Paths.LogPath));
            Logger.Log(LogType.Debug, "Map path: {0}", Path.GetFullPath(Paths.MapPath));
            Logger.Log(LogType.Debug, "Config path: {0}", Path.GetFullPath(Paths.ConfigFileName));

            libraryInitialized = true;
        }


        /// <summary> Initialized various server subsystems. This should be called after InitLibrary and before StartServer.
        /// Loads config, PlayerDB, IP bans, AutoRank settings, builds a list of commands, and prepares the IRC bot.
        /// Raises Server.Initializing and Server.Initialized events, and possibly Logger.Logged events.
        /// Throws exceptions on failure. </summary>
        /// <exception cref="System.InvalidOperationException"> Library is not initialized, or server is already initialzied. </exception>
        public static void InitServer(bool fromGui) {
            if( serverInitialized) {
                if (!fromGui) throw new InvalidOperationException( "Server is already initialized" );
            }
            if( !libraryInitialized ) {
                throw new InvalidOperationException( "Server.InitLibrary must be called before Server.InitServer" );
            }
            GemsCraft.fSystem.Server.RaiseEvent( GemsCraft.fSystem.Server.Initializing );

            // Load Texture Pack
            string textPath = ConfigKey.TexturePath.GetString();
            if (textPath != "")
            {
                if (!File.Exists(textPath))
                {
                    Logger.Log(LogType.Warning,
                        "Texture Pack does not exist or has been moved. Server will ignore texture pack");
                    Config.UsesCustomTexturePack = false;
                }
                else
                {
                    TexturePack = new TexturePack(textPath);
                }
            }
            // Instantiate DeflateStream to make sure that libMonoPosix is present.
            // This allows catching misconfigured Mono installs early, and stopping the server.
            using( var testMemStream = new MemoryStream() ) {
                using( new DeflateStream( testMemStream, CompressionMode.Compress ) ) {
                }
            }

            // warnings/disclaimers
            if( Updater.CheckUpdates() == VersionResult.Developer) {
                Logger.Log( LogType.Warning,
                            "You are using an unreleased developer version of GemsCraft. " +
                            "Do not use this version unless you are ready to deal with bugs and potential data loss. " +
                            "Consider using the latest stable version instead, available from http://github.com/apotter96/GemsCraft/releases" );
            }
            

            if( MonoCompat.IsMono && !MonoCompat.IsSGenCapable ) {
                Logger.Log( LogType.Warning,
                            "You are using a relatively old version of the Mono runtime ({0}). " +
                            "It is recommended that you upgrade to at least 2.8+",
                            MonoCompat.MonoVersion );
            }

#if DEBUG
            Config.RunSelfTest();
#else
            // delete the old updater, if exists
            File.Delete( Paths.UpdaterFileName );
            File.Delete( "fCraftUpdater.exe" ); // pre-0.600 (supar legacy)
#endif

            // try to load the config
            if( !Config.Load( false, false ) ) {
                throw new Exception( "GemsCraft Config failed to initialize" );
            }

            if( ConfigKey.VerifyNames.GetEnum<NameVerificationMode>() == NameVerificationMode.Never ) {
                Logger.Log( LogType.Warning,
                            "Name verification is currently OFF. Your server is at risk of being hacked. " +
                            "Enable name verification as soon as possible." );
            }

            // Load Default Ranks in Config Doesn't exist
            if (!File.Exists("config.json"))
            {
                Config.LoadRankList(Config.DefaultRanks);
            }

            // load player DB
            PlayerDB.Load();
            IPBanList.Load();

            //define fallbacks
            Map.DefineFallbackBlocks();

            // prepare the list of commands
            CommandManager.Init();
            PluginManager.GetInstance(); //2nd means plugins crash and not 800Craft
            // prepare the brushes
            BrushManager.Init();

            // Init IRC
            IRC.Init();
            GunClass.Init();
            Physics.Physics.Load();
            HeartbeatSaverUtil.Init();
            Network.Remote.Server.Start(); // Starting the remote control server
            fSystem.Server.RaiseEvent( fSystem.Server.Initialized );
            
            serverInitialized = true;
        }


        /// <summary> Starts the server:
        /// Creates Console pseudoplayer, loads the world list, starts listening for incoming connections,
        /// sets up scheduled tasks and starts the scheduler, starts the heartbeat, and connects to IRC.
        /// Raises Server.Starting and Server.Started events.
        /// May throw an exception on hard failure. </summary>
        /// <returns> True if server started normally, false on soft failure. </returns>
        /// <exception cref="System.InvalidOperationException"> Server is already running, or server/library have not been initailized. </exception>
        public static bool StartServer() 
        {
            
            if( IsRunning ) {
                throw new InvalidOperationException( "Server is already running" );
            }
            if( !libraryInitialized || !serverInitialized ) {
                throw new InvalidOperationException( "Server.InitLibrary and Server.InitServer must be called before Server.StartServer" );
            }

            StartTime = DateTime.UtcNow;
            cpuUsageStartingOffset = Process.GetCurrentProcess().TotalProcessorTime;
            Players = new Player[0];

            RaiseEvent(Starting);

            if( ConfigKey.BackupDataOnStartup.Enabled() ) {
                BackupData();
            }
            //Logger.Log(LogType.Discord, "Attempting to connect to Discord"); // For a later time
            Player.Console = new Player(ConfigKey.ConsoleName.GetString()) {Info = {Rank = RankManager.HighestRank}};
            Player.AutoRank = new Player( "(AutoRank)" );
            
            if( ConfigKey.BlockDBEnabled.Enabled() ) BlockDB.Init();

            // try to load the world list
            if( !WorldManager.LoadWorldList() ) return false;
            WorldManager.SaveWorldList();

            // open the port
            Port = ConfigKey.Port.GetInt();
            InternalIP = IPAddress.Parse( ConfigKey.IP.GetString() );

            try {
                listener = new TcpListener( InternalIP, Port );
                listener.Start();

            } catch( Exception ex ) {
                // if the port is unavailable, try next one
                Logger.Log( LogType.Error,
                            $"Could not start listening on port {Port}, stopping. ({ex.Message})");
                if( !ConfigKey.IP.IsDefault() ) {
                    Logger.Log( LogType.Warning,
                                "Do not use the \"Designated IP\" setting unless you have multiple NICs or IPs." );
                }
                return false;
            }

            InternalIP = ((IPEndPoint)listener.LocalEndpoint).Address;
            ExternalIP = CheckExternalIP();

            if( ExternalIP == null ) {
                Logger.Log( LogType.SystemActivity,
                            "Server.Run: now accepting connections on port {0}", Port );
            } else {
                Logger.Log( LogType.SystemActivity,
                            "Server.Run: now accepting connections at {0}:{1}",
                            ExternalIP, Port );
            }

            if (Config.UsesCustomTexturePack)
            {
                Logger.Log(LogType.SystemActivity, "Custom Texture pack has been discovered. " +
                                                   "Please note that not all players may opt in to use this pack.");
                Logger.Log(LogType.SystemActivity, "Custom Blocks will now add to this texture pack");
            }

            Server.PlayerListChanged += Network.Remote.Server.UpdateServer;
            CustomBlock.Blocks = CustomBlock.LoadBlocks();
            Server.PlayerListChanged += DeployCustomBlocks;
            Server.ShutdownEnded += Network.Remote.Server.RemoveServer;

            
            // list loaded worlds
            WorldManager.UpdateWorldList();
            Logger.Log( LogType.SystemActivity,
                        "All available worlds: {0}",
                        WorldManager.Worlds.JoinToString( ", ", w => w.Name ) );

            Logger.Log(LogType.SystemActivity,
                RankManager.DefaultRank == null
                    ? $"Main World: {WorldManager.MainWorld.Name}"
                    : $"Main world: {WorldManager.MainWorld.Name}; default rank: {RankManager.DefaultRank.Name}");


            // Check for incoming connections (every 250ms)
            _checkConnectionsTask = Scheduler.NewTask( CheckConnections ).RunForever( CheckConnectionsInterval );

            // Check for idles (every 30s)
            checkIdlesTask = Scheduler.NewTask( CheckIdles ).RunForever( CheckIdlesInterval );

            //Check for tempranks (every 10s)
            checkTempRanksTask = Scheduler.NewTask(CheckTempRanks).RunForever(CheckTempRanksInterval);

            // Monitor CPU usage (every 30s)
            try {
                MonitorProcessorUsage( null );
                Scheduler.NewTask( MonitorProcessorUsage ).RunForever( MonitorProcessorUsageInterval,
                                                                       MonitorProcessorUsageInterval );
            } catch( Exception ex ) {
                Logger.Log( LogType.Error,
                            "Server.StartServer: Could not start monitoring CPU use: {0}", ex );
            }


            PlayerDB.StartSaveTask();

            // Announcements
            if( ConfigKey.AnnouncementInterval.GetInt() > 0 ) {
                TimeSpan announcementInterval = TimeSpan.FromMinutes( ConfigKey.AnnouncementInterval.GetInt() );
                Scheduler.NewTask( ShowRandomAnnouncement ).RunForever( announcementInterval );
            }

            // garbage collection
            gcTask = Scheduler.NewTask(DoGC).RunForever(GCInterval, TimeSpan.FromSeconds(45));
            Heartbeat.Start();



            if( ConfigKey.RestartInterval.GetInt() > 0 ) {
                TimeSpan restartIn = TimeSpan.FromSeconds( ConfigKey.RestartInterval.GetInt() );
                Shutdown( new ShutdownParams( ShutdownReason.Restarting, restartIn, true, true ), false );
                ChatTimer.Start( restartIn, "Automatic Server Restart", Player.Console.Name );
            }

            if( ConfigKey.IRCBotEnabled.Enabled() ) IRC.Start();

            // start the main loop - server is now connectible
            Scheduler.Start();
            PortalHandler.GetInstance();
            PortalDB.Load();

            //enable autorank
            Server.AutoRankEnabled = ConfigKey.AutoRankEnabled.Enabled();

            //enable global chat
            GlobalChat.Init();
            GlobalChat.Start();

            IsRunning = true;
            fSystem.Server.RaiseEvent( fSystem.Server.Started );
            return true;
        }

        private static void DeployCustomBlocks(object sender, EventArgs e)
        {
            for (int i = 0; i <= Players.Length - 1; i++)
            {
                try
                {
                    if (Players[i].CustomBlocksLoaded) continue;
                    Players[i].Send(PacketWriter.SetMapEnvUrl(TexturePack.URL)); // Also send texture pack url
                    foreach (CustomBlock block in CustomBlock.Blocks)
                    {
                        Players[i].Send(PacketWriter.MakeDefineBlock(block));
                        Players[i].CustomBlocksLoaded = true; 
                    }
                }
                catch (NullReferenceException)
                {
                    Logger.Log(LogType.SystemActivity, "No Custom Blocks Found.");
                }
            }
        }
        
        #endregion


        #region Shutdown

        static readonly object ShutdownLock = new object();
        public static bool IsShuttingDown;
        static readonly AutoResetEvent ShutdownWaiter = new AutoResetEvent( false );
        static Thread shutdownThread;
        static ChatTimer shutdownTimer;


        static void ShutdownNow( [NotNull] ShutdownParams shutdownParams ) {
            if( shutdownParams == null ) throw new ArgumentNullException( "shutdownParams" );
            if( IsShuttingDown ) return; // to avoid starting shutdown twice
            IsShuttingDown = true;
#if !DEBUG
            try {
#endif
                Heartbeat.HbSave();
                fSystem.Server.RaiseShutdownBeganEvent( shutdownParams );

                Scheduler.BeginShutdown();

                Logger.Log( LogType.SystemActivity,
                            "Server shutting down ({0})",
                            shutdownParams.ReasonString );

                // stop accepting new players
                if( listener != null ) {
                    listener.Stop();
                    listener = null;
                }

                // kick all players
                lock( SessionLock ) {
                    if( Sessions.Count > 0 ) {
                        foreach( Player p in Sessions ) {
                            // NOTE: kick packet delivery here is not currently guaranteed
                            p.Kick( "Server shutting down (" + shutdownParams.ReasonString + Color.White + ")", LeaveReason.ServerShutdown );
                        }
                        // increase the chances of kick packets being delivered
                        Thread.Sleep( 1000 );
                    }
                }

                // kill IRC bot
                IRC.Disconnect();

                if (TempBans.Any())
                {
                    foreach (Player p in Server.TempBans)
                    {
                        if (!p.Info.IsBanned) continue;
                        p.Info.Unban(Player.Console, "Shutdown: Tempban cancelled", false, true);
                        Logger.Log(LogType.SystemActivity, "Unbanning {0}: Was tempbanned", p.Name);
                    }
                }
                
                if( WorldManager.Worlds != null ) {
                    lock( WorldManager.SyncRoot ) {
                        // unload all worlds (includes saving)
                        foreach( World world in WorldManager.Worlds ) {
                        	 if( world.BlockDB.IsEnabled ) world.BlockDB.Flush( false );
                             world.SaveMap();
                         }
                     }
                 }

                //Sends data to serverlist with a 0 uptime and playercount
                //Scheduler.NewTask(t => Network.ServerList.sendLastData()).RunOnce();

                if( PlayerDB.IsLoaded ) PlayerDB.Save();
                if( IPBanList.IsLoaded ) IPBanList.Save();

                fSystem.Server.RaiseShutdownEndedEvent( shutdownParams );
#if !DEBUG
            } catch( Exception ex ) {
                Logger.LogAndReportCrash( "Error in Server.Shutdown", "800Craft", ex, true );
            }
#endif
        }


        /// <summary> Initiates the server shutdown with given parameters. </summary>
        /// <param name="shutdownParams"> Shutdown parameters </param>
        /// <param name="waitForShutdown"> If true, blocks the calling thread until shutdown is complete or cancelled. </param>
        public static void Shutdown( [NotNull] ShutdownParams shutdownParams, bool waitForShutdown ) {
            if( shutdownParams == null ) throw new ArgumentNullException( "shutdownParams" );
            lock( ShutdownLock ) {
                if( !CancelShutdown() ) return;
                shutdownThread = new Thread( ShutdownThread ) {
                    Name = "GemsCraft.Shutdown"
                };
                if( shutdownParams.Delay >= ChatTimer.MinDuration ) {
                    string timerMsg = String.Format( "Server {0} ({1})",
                                                     shutdownParams.Restart ? "restart" : "shutdown",
                                                     shutdownParams.ReasonString );
                    string nameOnTimer;
                    if( shutdownParams.InitiatedBy == null ) {
                        nameOnTimer = Player.Console.Name;
                    } else {
                        nameOnTimer = shutdownParams.InitiatedBy.Name;
                    }
                    shutdownTimer = ChatTimer.Start( shutdownParams.Delay, timerMsg, nameOnTimer );
                }
                shutdownThread.Start( shutdownParams );
            }
            if( waitForShutdown ) {
                ShutdownWaiter.WaitOne();
            }
        }


        /// <summary> Attempts to cancel the shutdown timer. </summary>
        /// <returns> True if a shutdown timer was cancelled, false if no shutdown is in progress.
        /// Also returns false if it's too late to cancel (shutdown has begun). </returns>
        public static bool CancelShutdown() {
            lock( ShutdownLock ) {
                if( shutdownThread != null ) {
                    if( IsShuttingDown || shutdownThread.ThreadState != ThreadState.WaitSleepJoin ) {
                        return false;
                    }
                    if( shutdownTimer != null ) {
                        shutdownTimer.Stop();
                        shutdownTimer = null;
                    }
                    ShutdownWaiter.Set();
                    shutdownThread.Abort();
                    shutdownThread = null;
                }
            }
            return true;
        }


        static void ShutdownThread( [NotNull] object obj ) {
            if( obj == null ) throw new ArgumentNullException( "obj" );
            ShutdownParams param = (ShutdownParams)obj;
            Thread.Sleep( param.Delay );
            ShutdownNow( param );
            ShutdownWaiter.Set();

            bool doRestart = (param.Restart && !HasArg( ArgKey.NoRestart ));
            string assemblyExecutable = Assembly.GetEntryAssembly().Location;

            if(doRestart) {
                if (MonoCompat.IsMono)
                {
                    ProcessStartInfo proc = new ProcessStartInfo("mono")
                    {
                        Arguments = assemblyExecutable, UseShellExecute = false, CreateNoWindow = true
                    };
                    Process.Start(proc);
                }
                else
                {
                    string args = $"--restart=\"{MonoCompat.PrependMono(assemblyExecutable)}\" {GetArgString()}";

                    MonoCompat.StartDotNetProcess(Paths.UpdaterFileName, args, true);
                }
            } else if( doRestart ) {

                if (MonoCompat.IsMono)
                {
                    ProcessStartInfo proc = new ProcessStartInfo("mono");
                    proc.Arguments = assemblyExecutable;
                    proc.UseShellExecute = false;
                    proc.CreateNoWindow = true;
                    Process.Start(proc);
                }
                else
                {
                    MonoCompat.StartDotNetProcess(assemblyExecutable, GetArgString(), true);
                }
            }

            if( param.KillProcess ) {
                Process.GetCurrentProcess().Kill();
            }
        }

        #endregion


        #region Messaging / Packet Sending
        /// <summary> Broadcasts a message to all online players.
        /// Shorthand for Server.Players.Message </summary>
        public static void Message([NotNull] string message)
        {
            Message(message, 0);
        }

        /// <summary> Broadcasts a message to all online players.
        /// Shorthand for Server.Players.Message </summary>
        public static void Message( [NotNull] string message, MessageType type) {
            if( message == null ) throw new ArgumentNullException( "message" );
            if (!MessageTypeUtil.Enabled() || message.Length >= 64) type = MessageType.Chat;
            Players.Message( message, type);
        }

        /// <summary> Broadcasts a message to all online players.
        /// Shorthand for Server.Players.Message </summary>
        [StringFormatMethod("message")]
        public static void Message([NotNull] string message, [NotNull] params object[] formatArgs)
        {
            Message(message, 0, formatArgs);
        }

        /// <summary> Broadcasts a message to all online players.
        /// Shorthand for Server.Players.Message </summary>
        [StringFormatMethod("message")]
        public static void Message( [NotNull] string message, MessageType type, [NotNull] params object[] formatArgs)
        {
            if(message == null) throw new ArgumentNullException("message");
            if(formatArgs == null) throw new ArgumentNullException("formatArgs");
            if (!MessageTypeUtil.Enabled() || message.Length >= 64) type = MessageType.Chat;
            Players.Message(message, type, formatArgs);
        }

        /// <summary> Broadcasts a message to all online players except one.
        /// Shorthand for Server.Players.Except(except).Message </summary>
        public static void Message([CanBeNull] Player except, [NotNull] string message)
        {
            Message(except, message, 0);
        }

        /// <summary> Broadcasts a message to all online players except one.
        /// Shorthand for Server.Players.Except(except).Message </summary>
        public static void Message([CanBeNull] Player except, [NotNull] string message, MessageType type)
        {
            if (message == null) throw new ArgumentNullException("message");
            if (!MessageTypeUtil.Enabled() || message.Length >= 64) type = MessageType.Chat;
            Players.Except(except).Message(message, type);
        }


        /// <summary> Broadcasts a message to all online players except one.
        /// Shorthand for Server.Players.Except(except).Message </summary>
        [StringFormatMethod( "message" )]
        public static void Message( [CanBeNull] Player except, [NotNull] string message, [Optional] MessageType? type, [NotNull] params object[] formatArgs ) {
            if( message == null ) throw new ArgumentNullException( "message" );
            if( formatArgs == null ) throw new ArgumentNullException( "formatArgs" );
            if (type == null) type = 0;
            if (!MessageTypeUtil.Enabled() || message.Length >= 64) type = MessageType.Chat;
            Players.Except( except ).Message( message, type, formatArgs);
        }

        #endregion


        #region Scheduled Tasks

        // checks for incoming connections
        private static SchedulerTask _checkConnectionsTask;
        private static TimeSpan _checkConnectionsInterval = TimeSpan.FromMilliseconds(250);
        public static TimeSpan CheckConnectionsInterval {
            get => _checkConnectionsInterval;
            set {
                if( value.Ticks < 0 ) throw new ArgumentException("CheckConnectionsInterval may not be negative.");
                _checkConnectionsInterval = value;
                if( _checkConnectionsTask != null ) _checkConnectionsTask.Interval = value;
            }
        }

        private static void CheckConnections( SchedulerTask param ) {
            TcpListener listenerCache = listener;
            if (listenerCache == null || !listenerCache.Pending()) return;
            try {
                Player.StartSession( listenerCache.AcceptTcpClient() );
            } catch( Exception ex ) {
                Logger.Log( LogType.Error,
                    $"Server.CheckConnections: Could not accept incoming connection: {ex}");
            }
        }
        // checks for idle players
        static SchedulerTask checkIdlesTask;
        static TimeSpan checkIdlesInterval = TimeSpan.FromSeconds( 30 );
        public static TimeSpan CheckIdlesInterval {
            get => checkIdlesInterval;
            set {
                if( value.Ticks < 0 ) throw new ArgumentException( "CheckIdlesInterval may not be negative." );
                checkIdlesInterval = value;
                if( checkIdlesTask != null ) checkIdlesTask.Interval = checkIdlesInterval;
            }
        }

        static void CheckIdles( SchedulerTask task )
        {
            Player[] tempPlayerList = Players;
            foreach (var player in tempPlayerList)
            {
                if( player.Info.Rank.IdleKickTimer <= 0 ) continue;

                if( player.IdleTime.TotalMinutes >= player.Info.Rank.IdleKickTimer ) {
                    Message( "{0}&S was kicked for being idle for {1} min", 0,
                        player.ClassyName,
                        player.Info.Rank.IdleKickTimer );
                    string kickReason = "Idle for " + player.Info.Rank.IdleKickTimer + " minutes";
                    player.Kick( Player.Console, kickReason, LeaveReason.IdleKick, false, true, false );
                    player.ResetIdleTimer(); // to prevent kick from firing more than once
                }
            }
        }

        //checks to re-rank tempranked players
        static SchedulerTask checkTempRanksTask;
        static TimeSpan checkTempRanksInterval = TimeSpan.FromSeconds(10);
        public static TimeSpan CheckTempRanksInterval
        {
            get => checkTempRanksInterval;
            set
            {
                if (value.Ticks < 0) throw new ArgumentException("CheckTempRanksInterval may not be negative.");
                checkTempRanksInterval = value;
                if (checkTempRanksTask != null) checkTempRanksTask.Interval = checkTempRanksInterval;
            }
        }
        static void CheckTempRanks(SchedulerTask task)
        {
            foreach(PlayerInfo p in PlayerDB.PlayerInfoList)
            {
                if (p.isTempRanked)
                {
                    if (Convert.ToInt32((p.tempRankTime - p.TimeSinceRankChange).TotalSeconds) <= 0)
                    {
                        p.ChangeRank(Player.Console, p.PreviousRank, "TempRank Expired", true, true, false);
                        p.isTempRanked = false;
                        p.tempRankTime = TimeSpan.FromSeconds(0);//set timespan back to 0 for simplicity
                    }
                }
            }
        }

        // collects garbage (forced collection is necessary under Mono)
        static SchedulerTask gcTask;
        static TimeSpan gcInterval = TimeSpan.FromSeconds( 60 );
        public static TimeSpan GCInterval {
            get => gcInterval;
            set {
                if( value.Ticks < 0 ) throw new ArgumentException( "GCInterval may not be negative." );
                gcInterval = value;
                if( gcTask != null ) gcTask.Interval = gcInterval;
            }
        }

        static void DoGC( SchedulerTask task ) {
            if( !gcRequested ) return;
            gcRequested = false;

            Process proc = Process.GetCurrentProcess();
            proc.Refresh();
            long usageBefore = proc.PrivateMemorySize64 / (1024 * 1024);

            GC.Collect( GC.MaxGeneration, GCCollectionMode.Forced );

            proc.Refresh();
            long usageAfter = proc.PrivateMemorySize64 / (1024 * 1024);

            Logger.Log( LogType.Debug,
                        "Server.DoGC: Collected on schedule ({0}->{1} MB).",
                        usageBefore, usageAfter );
        }


        // shows announcements
        private static void ShowRandomAnnouncement( SchedulerTask task ) {
            if( !File.Exists( Paths.AnnouncementsFileName ) ) return;
            string[] lines = File.ReadAllLines( Paths.AnnouncementsFileName );
            if( lines.Length == 0 ) return;
            string line = lines[new Random().Next( 0, lines.Length )].Trim();
            if( line.Length == 0 ) return;
            foreach(Player player in Players.Where( player => player.World != null))
            {
                ConfigKey.EnableAnnouncements.TryGetBool(out var res);
                MessageType type = res ? MessageType.Announcement : MessageType.Chat;
                if (!MessageTypeUtil.Enabled() || line.Length >= 64) type = MessageType.Chat;
                player.Message("&R" + ReplaceTextKeywords(player, line), type);
            }
        }

        // measures CPU usage
        public static bool IsMonitoringCPUUsage { get; private set; }
        static TimeSpan cpuUsageStartingOffset;
        public static double CPUUsageTotal { get; private set; }
        public static double CPUUsageLastMinute { get; private set; }

        static TimeSpan oldCPUTime = new TimeSpan( 0 );
        static readonly TimeSpan MonitorProcessorUsageInterval = TimeSpan.FromSeconds( 30 );
        static DateTime lastMonitorTime = DateTime.UtcNow;

        static void MonitorProcessorUsage( SchedulerTask task ) {
            TimeSpan newCPUTime = Process.GetCurrentProcess().TotalProcessorTime - cpuUsageStartingOffset;
            CPUUsageLastMinute = (newCPUTime - oldCPUTime).TotalSeconds /
                                 (Environment.ProcessorCount * DateTime.UtcNow.Subtract( lastMonitorTime ).TotalSeconds);
            lastMonitorTime = DateTime.UtcNow;
            CPUUsageTotal = newCPUTime.TotalSeconds /
                            (Environment.ProcessorCount * DateTime.UtcNow.Subtract( StartTime ).TotalSeconds);
            oldCPUTime = newCPUTime;
            IsMonitoringCPUUsage = true;
        }

        #endregion


        #region Utilities

        static bool gcRequested;

        public static void RequestGC() {
            gcRequested = true;
        }

        /// <summary>
        /// Checks if the verification key from the player ID packet (client -> server) matches the server's salt
        /// </summary>
        public static bool VerifyName( [NotNull] string name, [NotNull] string hash, [NotNull] string salt ) 
        {
            if( name == null ) throw new ArgumentNullException( "name" );
            if( hash == null ) throw new ArgumentNullException( "hash" );
            if( salt == null ) throw new ArgumentNullException( "salt" );
            while( hash.Length < 32 ) {
                hash = "0" + hash;
            }
            MD5 hasher = MD5.Create();
            StringBuilder sb = new StringBuilder( 32 );
            foreach( byte b in hasher.ComputeHash( Encoding.ASCII.GetBytes( salt + name ) ) ) 
            {
                sb.AppendFormat( "{0:x2}", b );
            }
            return sb.ToString().Equals( hash, StringComparison.OrdinalIgnoreCase );
        }


        public static int CalculateMaxPacketsPerUpdate( [NotNull] World world ) {
            if( world == null ) throw new ArgumentNullException( "world" );
            int packetsPerTick = (int)(BlockUpdateThrottling / TicksPerSecond);
            int maxPacketsPerUpdate = (int)(MaxUploadSpeed / TicksPerSecond * 128);

            int playerCount = world.Players.Length;
            if( playerCount > 0 && !world.IsFlushing ) {
                maxPacketsPerUpdate /= playerCount;
                if( maxPacketsPerUpdate > packetsPerTick ) {
                    maxPacketsPerUpdate = packetsPerTick;
                }
            } else {
                maxPacketsPerUpdate = MaxBlockUpdatesPerTick;
            }

            return maxPacketsPerUpdate;
        }


        static readonly Regex RegexIP = new Regex( @"\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b",
                                                   RegexOptions.Compiled );

        public static bool IsIP( [NotNull] string ipString ) {
            if( ipString == null ) throw new ArgumentNullException( "ipString" );
            return RegexIP.IsMatch( ipString );
        }



        public static void BackupData()
        {
            if (!Paths.TestDirectory("DataBackup", Paths.DataBackupDirectory, true))
            {
                Logger.Log(LogType.Error, "Unable to create a data backup.");
                return;
            }
            string backupFileName = String.Format(Paths.DataBackupFileNameFormat, DateTime.Now); // localized
            backupFileName = Path.Combine(Paths.DataBackupDirectory, backupFileName);
            using (FileStream fs = File.Create(backupFileName))
            {
                try
                {
                    string fileComment =
                        $"Backup of 800Craft data for server \"{ConfigKey.ServerName.GetString()}\", saved on {DateTime.Now}";
                    using (ZipStorer backupZip = ZipStorer.Create(fs, fileComment))
                    {
                        foreach (string dataFileName in Paths.DataFilesToBackup)
                        {
                            if (File.Exists(dataFileName))
                            {
                                backupZip.AddFile(ZipStorer.Compression.Deflate,
                                                   dataFileName,
                                                   dataFileName,
                                                   "");
                            }
                        }
                    }
                }
                catch (IOException)
                {
                    Logger.Log(LogType.Error, "Unable to create a data backup.");
                    return;
                }
                finally
                {
                    if (fs != null)
                        fs.Close();
                }
                Logger.Log(LogType.SystemActivity,
                            "Backed up server data to \"{0}\"",
                            backupFileName);
            }
        }


        public static string ReplaceTextKeywords( [NotNull] Player player, [NotNull] string input ) {
            if( player == null ) throw new ArgumentNullException( "player" );
            if( input == null ) throw new ArgumentNullException( "input" );
            StringBuilder sb = new StringBuilder( input );
            sb.Replace( "{SERVER_NAME}", ConfigKey.ServerName.GetString() );
            sb.Replace( "{RANK}", player.Info.Rank.ClassyName );
            sb.Replace( "{PLAYER_NAME}", player.ClassyName );
            sb.Replace( "{TIME}", DateTime.Now.ToShortTimeString() ); // localized
            if( player.World == null ) {
                sb.Replace( "{WORLD}", "(No World)" );
            } else {
                sb.Replace( "{WORLD}", player.World.ClassyName );
            }
            sb.Replace( "{PLAYERS}", CountVisiblePlayers( player ).ToString() );
            sb.Replace( "{WORLDS}", WorldManager.Worlds.Length.ToString() );
            sb.Replace( "{MOTD}", ConfigKey.MOTD.GetString() );
            sb.Replace( "{VERSION}", Updater.LatestStable.ToString() );
            if (ConfigKey.IRCBotEnabled.Enabled())
            {
                sb.Replace("{IRC_CHANNEL}", ConfigKey.IRCBotChannels.GetString());
            }
            else
            {
                sb.Replace("{IRC_CHANNEL}", "(No IRC)");
            }
            sb.Replace("{WEBSITE}", ConfigKey.WebsiteURL.GetString());
            return sb.ToString();
        }



        public static string GetRandomString( int chars ) {
            RandomNumberGenerator prng = RandomNumberGenerator.Create();
            StringBuilder sb = new StringBuilder();
            byte[] oneChar = new byte[1];
            while( sb.Length < chars ) {
                prng.GetBytes( oneChar );
                if( oneChar[0] >= 48 && oneChar[0] <= 57 ||
                    oneChar[0] >= 65 && oneChar[0] <= 90 ||
                    oneChar[0] >= 97 && oneChar[0] <= 122 ) {
                    //if( oneChar[0] >= 33 && oneChar[0] <= 126 ) {
                    sb.Append( (char)oneChar[0] );
                }
            }
            return sb.ToString();
        }

        static readonly Uri IPCheckUri = new Uri( "http://checkip.dyndns.org/" );
        const int IPCheckTimeout = 30000;

        /// <summary> Checks server's external IP, as reported by checkip.dyndns.org. </summary>
        [CanBeNull]
        static IPAddress CheckExternalIP() {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create( IPCheckUri );
            request.ServicePoint.BindIPEndPointDelegate = new BindIPEndPoint( BindIPEndPointCallback );
            request.Timeout = IPCheckTimeout;
            request.CachePolicy = new RequestCachePolicy( RequestCacheLevel.NoCacheNoStore );

            try {
                using( WebResponse response = request.GetResponse() ) {
                    // ReSharper disable AssignNullToNotNullAttribute
                    using( StreamReader responseReader = new StreamReader( response.GetResponseStream() ) ) {
                        // ReSharper restore AssignNullToNotNullAttribute
                        string responseString = responseReader.ReadToEnd();
                        int startIndex = responseString.IndexOf( ":" ) + 2;
                        int endIndex = responseString.IndexOf( '<', startIndex ) - startIndex;
                        IPAddress result;
                        if( IPAddress.TryParse( responseString.Substring( startIndex, endIndex ), out result ) ) {
                            return result;
                        } else {
                            return null;
                        }
                    }
                }
            } catch( WebException ex ) {
                Logger.Log( LogType.Warning,
                            "Could not check external IP: {0}", ex );
                return null;
            }
        }

        // Callback for setting the local IP binding. Implements System.Net.BindIPEndPoint delegate.
        public static IPEndPoint BindIPEndPointCallback( ServicePoint servicePoint, IPEndPoint remoteEndPoint, int retryCount ) {
            return new IPEndPoint( InternalIP, 0 );
        }

        #endregion


        #region Player and Session Management

        // list of registered players
        static readonly SortedDictionary<string, Player> PlayerIndex = new SortedDictionary<string, Player>();
        public static Player[] Players { get; private set; }
        static readonly object PlayerListLock = new object();

        // list of all connected sessions
        static readonly List<Player> Sessions = new List<Player>();
        static readonly object SessionLock = new object();


        // Registers a new session, and checks the number of connections from this IP.
        // Returns true if the session was registered succesfully.
        // Returns false if the max number of connections was reached.
        internal static bool RegisterSession( [NotNull] Player session ) {
            if( session == null ) throw new ArgumentNullException( "session" );
            int maxSessions = ConfigKey.MaxConnectionsPerIP.GetInt();
            lock( SessionLock ) {
                if( !session.IP.Equals( IPAddress.Loopback ) && maxSessions > 0 )
                {
                    int sessionCount = 0;
                    foreach (var p in Sessions)
                    {
                        if (!p.IP.Equals(session.IP)) continue;
                        sessionCount++;
                        if( sessionCount >= maxSessions ) {
                            return false;
                        }
                    }
                }
                Sessions.Add( session );
            }
            return true;
        }


        // Registers a player and checks if the server is full.
        // Also kicks any existing connections for this player account.
        // Returns true if player was registered succesfully.
        // Returns false if the server was full.
        internal static bool RegisterPlayer( [NotNull] Player player )
        {
            if (player == null) throw new ArgumentNullException("player");
            // Kick other sessions with same player name
            List<Player> sessionsToKick = new List<Player>();
            lock( SessionLock ) {
                foreach( Player s in Sessions ) {
                    if( s == player ) continue;
                    if( s.Name.Equals( player.Name, StringComparison.OrdinalIgnoreCase ) ) {
                        sessionsToKick.Add( s );
                        Logger.Log( LogType.SuspiciousActivity,
                                    "Server.RegisterPlayer: Player {0} logged in twice. Ghost from {1} was kicked.",
                                    s.Name, s.IP );
                        s.Kick( "Connected from elsewhere!", LeaveReason.ClientReconnect );
                    }
                }
            }

            // Wait for other sessions to exit/unregister (if any)
            foreach( Player ses in sessionsToKick ) {
                ses.WaitForDisconnect();
            }

            // Add player to the list
            lock( PlayerListLock ) {
                if( PlayerIndex.Count >= ConfigKey.MaxPlayers.GetInt() && !player.Info.Rank.ReservedSlot ) {
                    return false;
                }
                PlayerIndex.Add( player.Name, player );
                player.HasRegistered = true;
                Scheduler.NewTask(MessageTypeUtil.MessageHandler, player)
                    .RunForever(TimeSpan.FromSeconds(1));
                

            }
            return true;
        }


        public static string MakePlayerConnectedMessage( [NotNull] Player player, bool firstTime, [NotNull] World world ) {
            if( player == null ) throw new ArgumentNullException( "player" );
            if( world == null ) throw new ArgumentNullException( "world" );
            if (firstTime){
                return $"&S{player.ClassyName} &Sconnected, joined {world.ClassyName}";
            }
            //use this if you want to show original names for people with displayednames
            if (!firstTime && player.Info.DisplayedName != null){

                return $"&S{player.ClassyName} &S({player.Name}&S) connected again, joined {world.ClassyName}";
            }else{
                return $"&S{player.ClassyName} &Sconnected again, joined {world.ClassyName}";
            }
        }


        // Removes player from the list, and announced them leaving
        public static void UnregisterPlayer( [NotNull] Player player ) {
            if( player == null ) throw new ArgumentNullException( "player" );

            lock( PlayerListLock ) {
                if( !player.HasRegistered ) return;
                player.Info.ProcessLogout( player );

                Logger.Log( LogType.UserActivity,
                            "{0} left the server ({1}).", player.Name, player.LeaveReason );
                if( player.HasRegistered && ConfigKey.ShowConnectionMessages.Enabled() ) {
                    Players.CanSee(player).Message("&SPlayer {0}&S {1}.", 0,
                                                      player.ClassyName, player.Info.LeaveMsg);
                    player.Info.LeaveMsg = "left the server";
                }

                player.World?.ReleasePlayer( player );
                PlayerIndex.Remove( player.Name );
                UpdatePlayerList();
            }
        }


        // Removes a session from the list
        internal static void UnregisterSession( [NotNull] Player player ) {
            if( player == null ) throw new ArgumentNullException( "player" );
            lock( SessionLock ) {
                Sessions.Remove( player );
            }
        }


        internal static void UpdatePlayerList() {
            lock( PlayerListLock ) {
                Players = PlayerIndex.Values.Where( p => p.IsOnline )
                                            .OrderBy( player => player.Name )
                                            .ToArray();
                fSystem.Server.RaiseEvent( fSystem.Server.PlayerListChanged );
            }
        }

        /// <summary>
        /// Find bot by name. Returns either the bot by exact name, or null.
        /// </summary>
        public static Bot FindBot(string name)
        {
            var bot =
               from b in Bots
               where string.Equals(b.Name, name, StringComparison.CurrentCultureIgnoreCase)
               select b;

            if (bot.Count() != 1)
            {
                return null;
            }

            return bot.First();
        }

        /// <summary>
        /// Find bot by ID. Returns either the bot by exact ID, or null.
        /// </summary>
        public static Bot FindBot(int ID)
        {
            var bot =
                from b in Bots
                where b.ID == ID
                select b;

            if (bot.Count() != 1)
            {
                return null;
            }

            return bot.First();
        }

        /// <summary> Finds a player by name, using autocompletion.
        /// Returns ALL matching players, including hidden ones. </summary>
        /// <returns> An array of matches. List length of 0 means "no matches";
        /// 1 is an exact match; over 1 for multiple matches. </returns>
        public static Player[] FindPlayers( [NotNull] string name, bool raiseEvent ) {
            if( name == null ) throw new ArgumentNullException( "name" );
            Player[] tempList = Players;
            List<Player> results = new List<Player>();
            foreach (var t in tempList)
            {
                if (t == null) continue;
                if (t.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    results.Clear();
                    results.Add(t);
                    break;
                }
                else if (t.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(t);
                }
            }

            if (!raiseEvent) return results.ToArray();
            var h = fSystem.Server.SearchingForPlayer;
            if (h == null) return results.ToArray();
            var e = new SearchingForPlayerEventArgs( null, name, results );
            h( null, e );
            return results.ToArray();
        }


        /// <summary> Finds a player by name, using autocompletion. Does not include hidden players. </summary>
        /// <param name="player"> Player who initiated the search.
        /// Used to determine whether others are hidden or not. </param>
        /// <param name="name"> Full or partial name of the search target. </param>
        /// <param name="raiseEvent"> Whether to raise Server.SearchingForPlayer event. </param>
        /// <returns> An array of matches. List length of 0 means "no matches";
        /// 1 is an exact match; over 1 for multiple matches. </returns>
        public static Player[] FindPlayers( [NotNull] Player player, [NotNull] string name, bool raiseEvent ) {
            if( player == null ) throw new ArgumentNullException( "player" );
            if( name == null ) throw new ArgumentNullException( "name" );
            if( name == "-" ) {
                if( player.LastUsedPlayerName != null ) {
                    name = player.LastUsedPlayerName;
                } else {
                    return new Player[0];
                }
            }
            player.LastUsedPlayerName = name;
            List<Player> results = new List<Player>();
            Player[] tempList = Players;
            foreach (var t in tempList)
            {
                if( t == null || !player.CanSee( t ) ) continue;
                if( t.Name.Equals( name, StringComparison.OrdinalIgnoreCase ) ) {
                    results.Clear();
                    results.Add( t );
                    break;
                }

                if( t.Name.StartsWith( name, StringComparison.OrdinalIgnoreCase ) ) {
                    results.Add( t );
                }
            }
            if( raiseEvent ) {
                var h = fSystem.Server.SearchingForPlayer;
                if( h != null ) {
                    var e = new SearchingForPlayerEventArgs( player, name, results );
                    h( null, e );
                }
            }
            if( results.Count == 1 ) {
                player.LastUsedPlayerName = results[0].Name;
            }
            return results.ToArray();
        }


        /// <summary> Find player by name using autocompletion.
        /// Returns null and prints message if none or multiple players matched.
        /// Raises Player.SearchingForPlayer event, which may modify search results. </summary>
        /// <param name="player"> Player who initiated the search. This is where messages are sent. </param>
        /// <param name="name"> Full or partial name of the search target. </param>
        /// <param name="includeHidden"> Whether to include hidden players in the search. </param>
        /// <param name="raiseEvent"> Whether to raise Server.SearchingForPlayer event. </param>
        /// <returns> Player object, or null if no player was found. </returns>
        [CanBeNull]
        public static Player FindPlayerOrPrintMatches( [NotNull] Player player, [NotNull] string name, bool includeHidden, bool raiseEvent ) {
            if( player == null ) throw new ArgumentNullException( "player" );
            if( name == null ) throw new ArgumentNullException( "name" );
            if( name == "-" ) {
                if( player.LastUsedPlayerName != null ) {
                    name = player.LastUsedPlayerName;
                } else {
                    player.Message( "Cannot repeat player name: you haven't used any names yet." );
                    return null;
                }
            }
            Player[] matches;
            if( includeHidden ) {
                matches = FindPlayers( name, raiseEvent );
            } else {
                matches = FindPlayers( player, name, raiseEvent );
            }

            if( matches.Length == 0 ) {
                player.MessageNoPlayer( name );
                return null;

            } else if( matches.Length > 1 ) {
                player.MessageManyMatches( "player", matches );
                return null;

            } else {
                player.LastUsedPlayerName = matches[0].Name;
                return matches[0];
            }
        }


        /// <summary> Counts online players, optionally including hidden ones. </summary>
        public static int CountPlayers( bool includeHiddenPlayers )
        {
            if( includeHiddenPlayers )
            {
                return Players.Length;
            }

            return Players.Count( player => !player.Info.IsHidden );
        }


        /// <summary> Counts online players whom the given observer can see. </summary>
        public static int CountVisiblePlayers( [NotNull] Player observer ) {
            if( observer == null ) throw new ArgumentNullException( "observer" );
            return Players.Count( observer.CanSee );
        }

        #endregion
    }


    /// <summary> Describes the circumstances of server shutdown. </summary>
    public sealed class ShutdownParams
    {
        public ShutdownParams( ShutdownReason reason, TimeSpan delay, bool killProcess, bool restart )
        {
            Reason = reason;
            Delay = delay;
            KillProcess = killProcess;
            Restart = restart;
        }

        public ShutdownParams( ShutdownReason reason, TimeSpan delay, bool killProcess,
                               bool restart, [CanBeNull] string customReason, [CanBeNull] Player initiatedBy ) :
            this( reason, delay, killProcess, restart )
        {
            customReasonString = customReason;
            InitiatedBy = initiatedBy;
        }

        public ShutdownReason Reason { get; private set; }

        private readonly string customReasonString;
        [NotNull]
        public string ReasonString => customReasonString ?? Reason.ToString();

        /// <summary> Delay before shutting down. </summary>
        public TimeSpan Delay { get; private set; }

        /// <summary> Whether 800Craft should try to forcefully kill the current process. </summary>
        public bool KillProcess { get; private set; }

        /// <summary> Whether the server is expected to restart itself after shutting down. </summary>
        public bool Restart { get; private set; }

        /// <summary> Player who initiated the shutdown. May be null or Console. </summary>
        [CanBeNull]
        public Player InitiatedBy { get; private set; }
    }


    /// <summary> Categorizes conditions that lead to server shutdowns. </summary>
    public enum ShutdownReason {
        Unknown,

        /// <summary> Use for mod- or plugin-triggered shutdowns. </summary>
        Other,

        /// <summary> InitLibrary or InitServer failed. </summary>
        FailedToInitialize,

        /// <summary> StartServer failed. </summary>
        FailedToStart,

        /// <summary> Server is restarting, usually because someone called /Restart. </summary>
        Restarting,

        /// <summary> Server has experienced a non-recoverable crash. </summary>
        Crashed,

        /// <summary> Server is shutting down, usually because someone called /Shutdown. </summary>
        ShuttingDown,

        /// <summary> Server process is being closed/killed. </summary>
        ProcessClosing,

        /// <summary>
        /// Server is shutting down to be updated
        /// </summary>
        Updating
    }
}
