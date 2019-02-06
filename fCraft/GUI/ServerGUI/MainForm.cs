// Copyright 2009-2012 Matvei Stefarov <me@matvei.org>
//Modified LegendCraft Team

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using GemsCraft.Events;
using GemsCraft.fSystem;
using GemsCraft.Configuration;
using GemsCraft.Network;
using GemsCraft.Players;
using GemsCraft.Utils;
using MetroFramework.Forms;

namespace GemsCraft.GUI.ServerGUI
{
    public sealed partial class MainForm : MetroForm
    {
        internal static MainForm Instance;
        private volatile bool _shutdownPending, _startupComplete, _shutdownComplete;

        private const int MaxLinesInLog = 2000,
                  LinesToTrimWhenExceeded = 50;

        private bool _listening;

        public bool IsLauncher;
        public MainForm(bool isLauncher)
        {
            Instance = this;
            IsLauncher = isLauncher;
            Init();
        }

        public MainForm()
        {
            Instance = this;
            IsLauncher = false;
            Init();
        }

        private void Init()
        {
            InitializeComponent();
            Shown += StartUp;
            console.OnCommand += console_Enter;
            logBox.LinkClicked += Link_Clicked;
            MenuItem[] menuItems = { new MenuItem("Copy", CopyMenuOnClickHandler) };
            logBox.ContextMenu = new ContextMenu(menuItems);
            logBox.ContextMenu.Popup += CopyMenuPopupHandler;
            playerList.MouseDoubleClick += playerList_MouseDoubleClick;
            lblGemVersion.Text = "Version: " + Updater.LatestStable;
            SetDefTheme();
        }

        public string Title
        {
            get
            {
                try
                {
                    return lblTitle.Text;
                }
                catch
                {
                    return "Server is Offline D:";
                }
            }
            set => lblTitle.Text = value;
        }
       
        #region Startup
        private Thread _startupThread;

        private void StartUp(object sender, EventArgs a)
        {
            /*tabChat.SelectedIndexChanged += tabChat_tabSelected;*/
            Logger.Logged += OnLogged;
            Heartbeat.UriChanged += OnHeartbeatUriChanged;
            Server.PlayerListChanged += OnPlayerListChanged;
            Server.ShutdownEnded += OnServerShutdownEnded;
            Title = "v" + Updater.LatestStable + " - starting...";
            _startupThread = new Thread(StartupThread) {Name = "GemsCraft ServerGUI Startup"};
            _startupThread.Start();
        }

        private void StartupThread()
        {
#if !DEBUG
            try
            {
#endif
               
                Server.InitLibrary(Environment.GetCommandLineArgs(), IsLauncher);
                if (_shutdownPending) return;

                Server.InitServer(IsLauncher);
                if (_shutdownPending) return;

                BeginInvoke((Action)OnInitSuccess);
                if (ConfigKey.CheckForUpdates.GetString() == "True")
                {
                    UpdateCheck();
                }


                // set process priority
                if (!ConfigKey.ProcessPriority.IsBlank())
                {
                    try
                    {
                        Process.GetCurrentProcess().PriorityClass = ConfigKey.ProcessPriority.GetEnum<ProcessPriorityClass>();
                    }
                    catch (Exception)
                    {
                        Logger.Log(LogType.Warning,
                                    "MainForm.StartServer: Could not set process priority, using defaults.");
                    }
                }

                if (_shutdownPending) return;
                if (Server.StartServer())
                {
                    _startupComplete = true;
                    BeginInvoke((Action)OnStartupSuccess);
                }
                else
                {
                    BeginInvoke((Action)OnStartupFailure);
                }
#if !DEBUG
            }
            catch (Exception ex)
            {
                Logger.LogAndReportCrash("Unhandled exception in ServerGUI.StartUp", "ServerGUI", ex, true);
                Shutdown(ShutdownReason.Crashed, Server.HasArg(ArgKey.ExitOnCrash));
            }
#endif
        }


        private void OnInitSuccess()
        {
            Title = ConfigKey.ServerName.GetString();
        }

        private void UpdateCheck()
        {
            Logger.Log(LogType.SystemActivity, "Checking for GemsCraft updates...");
            string title = null;
            string message = null;
            if (Updater.CheckUpdates() == VersionResult.Outdated)
            {
                title = "Outdated";
                message = "A GemsCraft Update is available! Would you like to update now?";
            }
            else if (Updater.CheckUpdates() == VersionResult.Developer)
            {
                title = "Unreleased Version";
                message = "This GemsCraft version is not supported and it is not recommended to keep using it.\n" +
                          "Potential data loss could happen. Would you like to update to a more recent version?";
            }

            if (title == null)
            {
                Logger.Log(LogType.SystemActivity, "GemsCraft is up to date!");
                return;
            }

            DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes) return;

            // Starts the update process
            Process.Start("Updater.exe");
            Shutdown(ShutdownReason.Updating, true);
        }

        void OnStartupSuccess()
        {
            if (!ConfigKey.HeartbeatEnabled.Enabled())
            {
                uriDisplay.Text = null;
            }
            console.Enabled = true;
            console.Text = "";
        }


        void OnStartupFailure()
        {
            Shutdown(ShutdownReason.FailedToStart, Server.HasArg(ArgKey.ExitOnCrash));
        }

        #endregion


        #region Shutdown

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_startupThread != null && !_shutdownComplete)
            {
                Shutdown(ShutdownReason.ProcessClosing, true);
                e.Cancel = true;
            }
            else
            {
                base.OnFormClosing(e);
            }
        }


        void Shutdown(ShutdownReason reason, bool quit)
        {
            if (_shutdownPending) return;
            _shutdownPending = true;
            console.Enabled = false;
            console.Text = "Shutting down...";
            Title = "Shutting down...";
            uriDisplay.Enabled = false;
            if (!_startupComplete)
            {
                _startupThread.Join();
            }
            Server.Shutdown(new ShutdownParams(reason, TimeSpan.Zero, quit, false), false);
        }


        void OnServerShutdownEnded(object sender, ShutdownEventArgs e)
        {
            try
            {
                BeginInvoke((Action)delegate
                {
                    _shutdownComplete = true;
                    switch (e.ShutdownParams.Reason)
                    {
                        case ShutdownReason.FailedToInitialize:
                        case ShutdownReason.FailedToStart:
                        case ShutdownReason.Crashed:
                            if (Server.HasArg(ArgKey.ExitOnCrash))
                            {
                                Application.Exit();
                            }
                            break;
                        default:
                            Application.Exit();
                            break;
                    }
                });
            }
            catch (ObjectDisposedException)
            {
            }
            catch (InvalidOperationException) { }
        }

        #endregion


        public void OnLogged(object sender, LogEventArgs e)
        {
            if (!e.WriteToConsole) return;
            try
            {
                if (_shutdownComplete) return;
                if (logBox.InvokeRequired)
                {
                    BeginInvoke((EventHandler<LogEventArgs>)OnLogged, sender, e);
                }
                else
                {
                    // store user's selection
                    int userSelectionStart = logBox.SelectionStart;
                    int userSelectionLength = logBox.SelectionLength;
                    bool userSelecting = (logBox.SelectionStart != logBox.Text.Length && logBox.Focused ||
                                          logBox.SelectionLength > 0);

                    // insert and color a new message
                    int oldLength = logBox.Text.Length;
                    string msgToAppend = e.Message + Environment.NewLine;

                    /*if (e.MessageType == LogType.GlobalChat) //If Global Message, send to global and stop
                    {
                        logGlobal.SelectionColor = System.Drawing.Color.LightGray;
                        logGlobal.AppendText(msgToAppend);
                        return;
                    }
                    else*/
                    {
                        logBox.AppendText(msgToAppend);
                    }
                    logBox.Select(oldLength, msgToAppend.Length);

                    switch (e.MessageType)
                    {
                        case LogType.PrivateChat:
                            logBox.SelectionColor = System.Drawing.Color.Teal;
                            break;
                        case LogType.IRC:
                            logBox.SelectionColor = System.Drawing.Color.FromName(Color.GetName(Color.IRC) ?? "Purple");
                            break;
                        case LogType.ChangedWorld:
                            logBox.SelectionColor = System.Drawing.Color.Orange;
                            break;
                        case LogType.Warning:
                            logBox.SelectionColor = System.Drawing.Color.Yellow;
                            break;
                        case LogType.Debug:
                            logBox.SelectionColor = System.Drawing.Color.DarkGray;
                            break;
                        case LogType.Error:
                        case LogType.SeriousError:
                            logBox.SelectionColor = System.Drawing.Color.Red;
                            break;
                        case LogType.ConsoleInput:
                        case LogType.ConsoleOutput:
                            logBox.SelectionColor = System.Drawing.Color.White;
                            break;
                        default:
                            logBox.SelectionColor = System.Drawing.Color.LightGray;
                            break;
                    }
                    // cut off the log, if too long
                    if (logBox.Lines.Length > MaxLinesInLog)
                    {
                        logBox.SelectionStart = 0;
                        logBox.SelectionLength = logBox.GetFirstCharIndexFromLine(LinesToTrimWhenExceeded);
                        userSelectionStart -= logBox.SelectionLength;
                        if (userSelectionStart < 0) userSelecting = false;
                        string textToAdd = "----- cut off, see " + Logger.CurrentLogFileName + " for complete log -----" + Environment.NewLine;
                        logBox.Text = textToAdd;
                        userSelectionStart += textToAdd.Length;
                        logBox.SelectionColor = System.Drawing.Color.DarkGray;
                    }

                    // either restore user's selection, or scroll to end
                    if (userSelecting)
                    {
                        logBox.Select(userSelectionStart, userSelectionLength);
                    }
                    else
                    {
                        logBox.SelectionStart = logBox.Text.Length;
                        logBox.ScrollToCaret();
                    }
                }
            }
            catch (ObjectDisposedException)
            {
            }
            catch (InvalidOperationException) { }
        }


        public void OnHeartbeatUriChanged(object sender, UriChangedEventArgs e)
        {
            try
            {
                if (_shutdownPending) return;
                if (uriDisplay.InvokeRequired)
                {
                    BeginInvoke((EventHandler<UriChangedEventArgs>)OnHeartbeatUriChanged,
                            sender, e);
                }
                else
                {
                    uriDisplay.Text = e.NewUri.ToString();
                    uriDisplay.Enabled = true;
                    bPlay.Enabled = true;
                }
            }
            catch (ObjectDisposedException)
            {
            }
            catch (InvalidOperationException) { }
        }


        public void OnPlayerListChanged(object sender, EventArgs e)
        {
            try
            {
                if (_shutdownPending) return;
                if (playerList.InvokeRequired)
                {
                    BeginInvoke((EventHandler)OnPlayerListChanged, null, EventArgs.Empty);
                }
                else
                {
                    playerList.Items.Clear();
                    Player[] playerListCache = Server.Players.OrderBy(p => p.Info.Rank.Index).ToArray();
                    foreach (Player player in playerListCache)
                    {
                        playerList.Items.Add(player.Info.Rank.Name + " - " + player.Name);
                    }
                }
            }
            catch (ObjectDisposedException)
            {
            }
            catch (InvalidOperationException) { }
        }

        private void console_Enter()
        {
            string[] separator = { Environment.NewLine };
            string[] lines = console.Text.Trim().Split(separator, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
#if !DEBUG
                try
                {
#endif
                    if (line.Equals("/Clear", StringComparison.OrdinalIgnoreCase))
                    {
                        logBox.Clear();
                    }
                    else if (line.Equals("/credits", StringComparison.OrdinalIgnoreCase))
                    {
                        new AboutWindow().Show();
                    }
                    else
                    {
                       /* if (onGlobal)
                        {
                            GemsCraft.GlobalChat.GlobalThread.SendChannelMessage("[console]: " + line);
                            Logger.Log(LogType.GlobalChat, "[console]: " + line);
                            return;
                        }
                        else */
                        {
                            Player.Console.ParseMessage(line, true, true);
                        }
                    }
#if !DEBUG
                }
                catch (Exception ex)
                {
                    Logger.LogToConsole("Error occured while trying to execute last console command: ");
                    Logger.LogToConsole(ex.GetType().Name + ": " + ex.Message);
                    Logger.LogAndReportCrash("Exception executing command from console", "ServerGUI", ex, false);
                }
#endif
            }
            console.Text = "";
        }



        private void bPlay_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(uriDisplay.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Could not open server URL. Please copy/paste it manually.");
            }
        }

        private void logBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void Link_Clicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SizeBox.SelectedItem.ToString() == "Normal")
            {
                logBox.ZoomFactor = 1;
            }
            if (SizeBox.SelectedItem.ToString() == "Big")
            {
                logBox.ZoomFactor = (float)1.2;
            }
            if (SizeBox.SelectedItem.ToString() == "Large")
            {
                logBox.ZoomFactor = (float)1.5;
            }
        }

        private void CopyMenuOnClickHandler(object sender, EventArgs e)
        {
            if (logBox.SelectedText.Length > 0)
                Clipboard.SetText(logBox.SelectedText.ToString(), TextDataFormat.Text);
        }

        private void CopyMenuPopupHandler(object sender, EventArgs e)
        {
            if (sender is ContextMenu menu)
            {
                menu.MenuItems[0].Enabled = (logBox.SelectedText.Length > 0);
            }
        }

        public void SetDefTheme()
        {
            playerList.BackColor = System.Drawing.Color.White;
            logBox.BackColor = System.Drawing.Color.Black;
            logBox.SelectAll();
            logBox.SelectionColor = System.Drawing.Color.LightGray;
            logBox.SelectionStart = logBox.Text.Length;
            logBox.ScrollToCaret();
        }
        public void SetAltTheme()
        {
            BackColor = System.Drawing.Color.Black;
            playerList.BackColor = System.Drawing.Color.White;
            logBox.BackColor = System.Drawing.Color.Firebrick;

            logBox.SelectAll();
            logBox.SelectionColor = System.Drawing.Color.Black;
            logBox.SelectionStart = logBox.Text.Length;
            logBox.ScrollToCaret();

        }
        public void SetPinkTheme()
        {
            BackColor = System.Drawing.Color.Pink;
            playerList.BackColor = System.Drawing.Color.LightPink;
            logBox.BackColor = System.Drawing.Color.LightPink;

            logBox.SelectAll();
            logBox.SelectionColor = System.Drawing.Color.Black;
            logBox.SelectionStart = logBox.Text.Length;
            logBox.ScrollToCaret();

        }

        public void SetYellowTheme()
        {
            BackColor = System.Drawing.Color.LightGoldenrodYellow;
            playerList.BackColor = System.Drawing.Color.LightYellow;
            logBox.BackColor = System.Drawing.Color.LightYellow;

            logBox.SelectAll();
            logBox.SelectionColor = System.Drawing.Color.Black;
            logBox.SelectionStart = logBox.Text.Length;
            logBox.ScrollToCaret();

        }

        public void SetGreenTheme()
        {
            BackColor = System.Drawing.Color.SpringGreen;
            playerList.BackColor = System.Drawing.Color.LightGreen;
            logBox.BackColor = System.Drawing.Color.LightGreen;

            logBox.SelectAll();
            logBox.SelectionColor = System.Drawing.Color.Black;
            logBox.SelectionStart = logBox.Text.Length;
            logBox.ScrollToCaret();

        }

        public void SetPurpleTheme()
        {
            BackColor = System.Drawing.Color.MediumPurple;
            playerList.BackColor = System.Drawing.Color.Plum;
            logBox.BackColor = System.Drawing.Color.Plum;

            logBox.SelectAll();
            logBox.SelectionColor = System.Drawing.Color.Black;
            logBox.SelectionStart = logBox.Text.Length;
            logBox.ScrollToCaret();

        }

        public void SetGreyTheme()
        {
            BackColor = System.Drawing.SystemColors.Control;
            playerList.BackColor = System.Drawing.SystemColors.ControlLight;
            logBox.BackColor = System.Drawing.SystemColors.ControlLight;

            logBox.SelectAll();
            logBox.SelectionColor = System.Drawing.Color.Black;
            logBox.SelectionStart = logBox.Text.Length;
            logBox.ScrollToCaret();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        /*public void tabChat_tabSelected(object sender, EventArgs e)
          {
              if (tabChat.SelectedTab == tabServer)
              {
                  onGlobal = false;
                  return;
              }
              if (tabChat.SelectedTab == tabGlobal)
              {
                  onGlobal = true;
                  return;
              }
          }*/

        #region PlayerViewer

        private void playerList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                string s = (string)playerList.Items[playerList.SelectedIndex];
                s = s.Substring(s.IndexOf('-'),
                    s.Length - s.IndexOf('-'))
                    .Replace("-", "")
                    .Replace(" ", "")
                    .Trim();
                PlayerInfo player = PlayerDB.FindPlayerInfoExact(s);
                if (player == null) return;
                var v = new PlayerViewer(player);
                v.Show();
            }
            catch { } //do nothing at all
        }
        
        
        #endregion

        #region VoiceCommands

        private void bVoice_Click(object sender, EventArgs e)
        {
            if (MonoCompat.IsMono)
            {
                Logger.Log(LogType.Warning, "Voice commands are for windows operating systems only");
                return;
            }

            //if button was already clicked, cancel
            if (_listening)
            {
                _listening = false;
                bVoice.ForeColor = System.Drawing.Color.Black;
                return;
            }

                System.Speech.Recognition.SpeechRecognitionEngine engine = new System.Speech.Recognition.SpeechRecognitionEngine();
                bVoice.ForeColor = System.Drawing.Color.Aqua;
                System.Speech.Recognition.Choices commands = new System.Speech.Recognition.Choices();
                commands.Add(new string[] { "restart", "shutdown", "status report", "players", "help" });
                System.Speech.Recognition.Grammar gr = new System.Speech.Recognition.Grammar(new System.Speech.Recognition.GrammarBuilder(commands));
                try
                {
                    _listening = true;
                    engine.RequestRecognizerUpdate();
                    engine.LoadGrammar(gr);
                    engine.SpeechRecognized += engine_SpeechRecognized;
                    engine.SetInputToDefaultAudioDevice();
                    engine.RecognizeAsync(System.Speech.Recognition.RecognizeMode.Multiple);
                    engine.Recognize();
                }

                catch
                {
                    return;
                }
        }
        void engine_SpeechRecognized(object sender, System.Speech.Recognition.SpeechRecognizedEventArgs e)
        {
            System.Speech.Synthesis.SpeechSynthesizer reader = new System.Speech.Synthesis.SpeechSynthesizer();
            System.Speech.Recognition.SpeechRecognitionEngine engine = new System.Speech.Recognition.SpeechRecognitionEngine();
            try
            {
                engine = new System.Speech.Recognition.SpeechRecognitionEngine();
                String message = "";
                String results = e.Result.Text;
                if (!_listening)
                {
                    return;
                }
                switch (results)
                {
                    case "help":
                        reader.Speak("The available commands are restart, shutdown, status report, and players.");
                        Logger.Log(LogType.ConsoleOutput, "The available commands are restart, shutdown, status report, and a players.");
                        bVoice.ForeColor = System.Drawing.Color.Black;
                        results = "";
                        engine.RecognizeAsyncStop();
                        engine.Dispose();
                        _listening = false;
                        break;
                    case "restart":
                        reader.Speak("The server is now restarting.");
                        ShutdownParams param = new ShutdownParams(ShutdownReason.Restarting, TimeSpan.FromSeconds(5), true, true, "Restarting", Player.Console);
                        Server.Shutdown(param, true);
                        bVoice.ForeColor = System.Drawing.Color.Black;
                        results = "";
                        engine.RecognizeAsyncStop();
                        engine.Dispose();
                        _listening = false;
                        break;
                    case "shutdown":
                        reader.Speak("The server is now shutting down.");
                        Shutdown(ShutdownReason.ShuttingDown, true);
                        bVoice.ForeColor = System.Drawing.Color.Black;
                        results = "";
                        engine.RecognizeAsyncStop();
                        engine.Dispose();
                        _listening = false;
                        break;
                    case "status report":
                        reader.Speak("Server has been up for " + Math.Round(DateTime.UtcNow.Subtract(Server.StartTime).TotalHours, 1, MidpointRounding.AwayFromZero) + " hours.");
                        Player.Console.ParseMessage("/sinfo", true, false);
                        bVoice.ForeColor = System.Drawing.Color.Black;
                        results = "";
                        engine.RecognizeAsyncStop();
                        engine.Dispose();
                        _listening = false;
                        break;
                    case "players":
                        foreach (Player p in Server.Players)
                        {
                            message += p.Name;
                        }
                        reader.Speak(message);
                        Player.Console.ParseMessage("/players", true, false);
                        bVoice.ForeColor = System.Drawing.Color.Black;
                        results = "";
                        engine.RecognizeAsyncStop();
                        engine.Dispose();
                        _listening = false;
                        break;
                    default:
                        bVoice.ForeColor = System.Drawing.Color.Black;
                        results = "";
                        engine.RecognizeAsyncStop();
                        engine.Dispose();
                        _listening = false;
                        break;
                }
            }
            catch(Exception)
            {
                //Audio Device is either missing or damaged, actual Exception is System.Speech.Internal.Synthesis.AudioException
                engine.RecognizeAsyncStop();
                engine.Dispose();
                return;
            }
        }
        #endregion

    }
}