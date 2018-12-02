using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fCraft.fSystem;
using fCraft.GUI.ConfigGUI.GUI.Sections;
using fCraft.Players;
using fCraft.Utils;
using JetBrains.Annotations;
using MetroFramework.Forms;
using Color = fCraft.Utils.Color;

namespace fCraft.GUI.ConfigGUI.GUI
{
    
    public partial class MainForm : MetroForm
    {
        internal int _selectedTab = -1;
        internal void btnGeneral_Click(object sender, EventArgs e)
        {
            _selectedTab = 0;
            SectionClasses.GeneralConfig.ShowDialog();
        }

        internal void btnChat_Click(object sender, EventArgs e)
        {
            _selectedTab = 1;
            SectionClasses.ChatConfig.ShowDialog();
        }

        internal void btnWorlds_Click(object sender, EventArgs e)
        {
            _selectedTab = 2;
            SectionClasses.WorldConfig.ShowDialog();
        }

        internal void btnRanks_Click(object sender, EventArgs e)
        {
            _selectedTab = 3;
            SectionClasses.WorldConfig.ShowDialog();
        }

        internal void btnSecurity_Click(object sender, EventArgs e)
        {
            _selectedTab = 4;
            SectionClasses.SecurityConfig.ShowDialog();
        }

        internal void btnSavingAndBackup_Click(object sender, EventArgs e)
        {
            _selectedTab = 5;
            SectionClasses.SavingConfig.ShowDialog();
        }

        internal void btnLogging_Click(object sender, EventArgs e)
        {
            _selectedTab = 6;
            SectionClasses.LoggingConfig.ShowDialog();
        }

        internal void btnIRC_Click(object sender, EventArgs e)
        {
            _selectedTab = 7;
            SectionClasses.IRCConfig.ShowDialog();
        }

        internal void btnAdvanced_Click(object sender, EventArgs e)
        {
            _selectedTab = 8;
            SectionClasses.AdvancedConfig.ShowDialog();
        }

        internal void btnMisc_Click(object sender, EventArgs e)
        {
            _selectedTab = 9;
            SectionClasses.MiscConfig.ShowDialog();
        }

        internal void btnCPE_Click(object sender, EventArgs e)
        {
            _selectedTab = 10;
            MessageBox.Show("Coming Soon!");
        }

        internal static MainForm _instance;
        internal readonly Font _bold;
        internal Rank _selectedRank;
        internal readonly UpdaterSettingsPopup _updaterWindow = new UpdaterSettingsPopup();
        internal static readonly SortableBindingList<WorldListEntry> Worlds = new SortableBindingList<WorldListEntry>();

        #region Initalization

        public MainForm()
        {
            InitializeComponent();
            toolTip = new ToolTip();
            _instance = this;
            // Setting up the UI's for the Config Sections
            SectionClasses.GeneralConfig = new GeneralConfig();
            SectionClasses.ChatConfig = new ChatConfig();
            SectionClasses.WorldConfig = new WorldConfig();
            SectionClasses.RankConfig = new RankConfig();
            SectionClasses.SecurityConfig = new SecurityConfig();
            SectionClasses.SavingConfig = new SavingConfig();
            SectionClasses.LoggingConfig = new LoggingConfig();
            SectionClasses.IRCConfig = new IRCConfig();
            SectionClasses.AdvancedConfig = new AdvancedConfig();
            SectionClasses.MiscConfig = new MiscConfig();

            SectionClasses.WorldConfig.dgvcBlockDB.TrueValue = YesNoAuto.Yes;
            SectionClasses.WorldConfig.dgvcBlockDB.FalseValue = YesNoAuto.No;
            SectionClasses.WorldConfig.dgvcBlockDB.IndeterminateValue = YesNoAuto.Auto;
            _bold = new Font(Font, FontStyle.Bold);
            Shown += Init;
            Text = "GemsCraft Configuration " + Updater.LatestStable;
        }

        internal void Init(object sender, EventArgs e)
        {
            FillEnumLists(); // fills permission and LogType lists
            FillPermissionLimitBoxes(); // create hidden boxes for permission limits

            // fill out all the tool tips
            FillToolTipsGeneral();
            FillToolTipsChat();
            FillToolTipsWorlds();
            FillToolTipsWorlds();
            FillToolTipsRanks();
            FillToolTipsSecurity();
            FillToolTipsSavingAndBackup();
            FillToolTipsLogging();
            FillToolTipsIRC();
            FillToolTipsAdvanced();
            FillToolTipsMisc();

            FillIrcNetworkList(false);

            // Initialize GemsCraft's args, paths, and logging backend
            Server.InitLibrary(Environment.GetCommandLineArgs());

            SectionClasses.WorldConfig.dgvWorlds.DataError += WorldListErrorHandler;

            LoadConfig();

            // Redraw chat preview when re-entering the tab.
            // This ensured that changed to rank colors/prefixes are applied.
            SectionClasses.ChatConfig.Enter += (o, e2) => UpdateChatPreview();
        }

        internal void FillEnumLists()
        {
            foreach (Permission permission in Enum.GetValues(typeof(Permission)))
            {
                ListViewItem item = new ListViewItem(permission.ToString()) { Tag = permission };
                SectionClasses.RankConfig.vPermissions.Items.Add(item);
            }

            foreach (LogType type in Enum.GetValues(typeof(LogType)))
            {
                if (type == LogType.Trace) continue;
                ListViewItem item = new ListViewItem(type.ToString()) { Tag = type };
                SectionClasses.LoggingConfig.vLogFileOptions.Items.Add(item);
                SectionClasses.LoggingConfig.vConsoleOptions.Items.Add((ListViewItem)item.Clone());
            }
        }

        internal void FillWorldList()
        {
            SectionClasses.WorldConfig.cMainWorld.Items.Clear();
            foreach (WorldListEntry world in Worlds)
            {
                SectionClasses.WorldConfig.cMainWorld.Items.Add(world.Name);
            }
        }

        #endregion

        #region Input Handlers

        #region General

        internal void xAnnouncements_CheckedChanged(object sender, EventArgs e)
        {
            SectionClasses.GeneralConfig.nAnnouncements.Enabled = 
                SectionClasses.GeneralConfig.xAnnouncements.Checked;
            SectionClasses.GeneralConfig.bAnnouncements.Enabled = 
                SectionClasses.GeneralConfig.xAnnouncements.Checked;
        }

        internal void CheckMaxPlayersPerWorldValue()
        {
            if (SectionClasses.GeneralConfig.nMaxPlayersPerWorld.Value > SectionClasses.GeneralConfig.nMaxPlayers.Value)
            {
                SectionClasses.GeneralConfig.nMaxPlayersPerWorld.Value = SectionClasses.GeneralConfig.nMaxPlayers.Value;
            }
            SectionClasses.GeneralConfig.nMaxPlayersPerWorld.Maximum = Math.Min(128, SectionClasses.GeneralConfig.nMaxPlayers.Value);
        }

        internal void bMeasure_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.speedtest.net/");
        }

        internal void bAnnouncements_Click(object sender, EventArgs e)
        {
            TextEditorPopup popup = new TextEditorPopup(Paths.AnnouncementsFileName, "");
            popup.ShowDialog();
        }
        

        internal void bCredits_Click(object sender, EventArgs e)
        {
            new AboutWindow().Show();
        }

        internal void nMaxPlayers_ValueChanged(object sender, EventArgs e)
        {
            CheckMaxPlayersPerWorldValue();
        }

        internal void bGreeting_Click(object sender, EventArgs e)
        {
            TextEditorPopup popup = new TextEditorPopup(Paths.GreetingFileName,
                @"Welcome to {SERVER_NAME}
Your rank is {RANK}&S. Type &H/Help&S for help.");
            popup.ShowDialog();
        }

        internal void tIP_Validating(object sender, CancelEventArgs e)
        {
            if (Server.IsIP(SectionClasses.AdvancedConfig.tIP.Text) && IPAddress.TryParse(SectionClasses.AdvancedConfig.tIP.Text, out IPAddress IP))
            {
                SectionClasses.AdvancedConfig.tIP.ForeColor = SystemColors.ControlText;
            }
            else
            {
                SectionClasses.AdvancedConfig.tIP.ForeColor = System.Drawing.Color.Red;
                e.Cancel = true;
            }
        }

        internal void xIP_CheckedChanged(object sender, EventArgs e)
        {
            SectionClasses.AdvancedConfig.tIP.Enabled = SectionClasses.AdvancedConfig.xIP.Checked;
        }
        
        #endregion


        #region Worlds

        internal void WorldListErrorHandler(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception is FormatException)
            {
                string columnName = SectionClasses.WorldConfig.dgvWorlds.Columns[e.ColumnIndex].HeaderText;
                MessageBox.Show(e.Exception.Message, "Error editing " + columnName);
            }
            else
            {
                MessageBox.Show(e.Exception.ToString(), "An error occured in the world list");
            }
        }

        internal void bAddWorld_Click(object sender, EventArgs e)
        {
            AddWorldPopup popup = new AddWorldPopup(null);
            if (popup.ShowDialog() == DialogResult.OK)
            {
                Worlds.Add(popup.World);
                popup.World.LoadedBy = WorldListEntry.WorldInfoSignature;
                popup.World.LoadedOn = DateTime.UtcNow;
            }
            if (SectionClasses.WorldConfig.cMainWorld.SelectedItem == null)
            {
                FillWorldList();
                if (SectionClasses.WorldConfig.cMainWorld.Items.Count > 0)
                {
                    SectionClasses.WorldConfig.cMainWorld.SelectedIndex = 0;
                }
            }
            else
            {
                string mainWorldName = SectionClasses.WorldConfig.cMainWorld.SelectedItem.ToString();
                FillWorldList();
                SectionClasses.WorldConfig.cMainWorld.SelectedItem = mainWorldName;
            }
        }

        internal void bWorldEdit_Click(object sender, EventArgs e)
        {
            AddWorldPopup popup = new AddWorldPopup(Worlds[SectionClasses.WorldConfig.dgvWorlds.SelectedRows[0].Index]);
            if (popup.ShowDialog() != DialogResult.OK) return;
            string oldName = Worlds[SectionClasses.WorldConfig.dgvWorlds.SelectedRows[0].Index].Name;
            Worlds[SectionClasses.WorldConfig.dgvWorlds.SelectedRows[0].Index] = popup.World;
            HandleWorldRename(oldName, popup.World.Name);
        }

        internal void dgvWorlds_Click(object sender, EventArgs e)
        {
            bool oneRowSelected = (SectionClasses.WorldConfig.dgvWorlds.SelectedRows.Count == 1);
            SectionClasses.WorldConfig.bWorldDelete.Enabled = oneRowSelected;
            SectionClasses.WorldConfig.bWorldEdit.Enabled = oneRowSelected;
        }

        internal void bWorldDel_Click(object sender, EventArgs e)
        {
            if (SectionClasses.WorldConfig.dgvWorlds.SelectedRows.Count <= 0) return;
            WorldListEntry world = Worlds[SectionClasses.WorldConfig.dgvWorlds.SelectedRows[0].Index];

            // prompt to delete map file, if it exists
            if (File.Exists(world.FullFileName))
            {
                string promptMessage = $"Are you sure you want to delete world \"{world.Name}\"?";

                if (MessageBox.Show(promptMessage, "Deleting a world", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                string fileDeleteWarning = "Do you want to delete the map file (" + world.FileName + ") as well?";
                if (MessageBox.Show(fileDeleteWarning, "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        File.Delete(world.FullFileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("You have to delete the file (" + world.FileName + ") manually. " +
                                         "An error occured while trying to delete it automatically:" + Environment.NewLine + ex,
                            "Could not delete map file");
                    }
                }
            }

            Worlds.Remove(world);

            if (SectionClasses.WorldConfig.cMainWorld.SelectedItem == null)
            {
                // deleting non-main world
                FillWorldList();
                if (SectionClasses.WorldConfig.cMainWorld.Items.Count > 0)
                {
                    SectionClasses.WorldConfig.cMainWorld.SelectedIndex = 0;
                }

            }
            else
            {
                // deleting main world
                string mainWorldName = SectionClasses.WorldConfig.cMainWorld.SelectedItem.ToString();
                FillWorldList();
                if (mainWorldName == world.Name)
                {
                    MessageBox.Show("Main world has been reset.");
                    if (SectionClasses.WorldConfig.cMainWorld.Items.Count > 0)
                    {
                        SectionClasses.WorldConfig.cMainWorld.SelectedIndex = 0;
                    }
                }
                else
                {
                    SectionClasses.WorldConfig.cMainWorld.SelectedItem = mainWorldName;
                }
            }
        }

        internal void bMapPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog
            {
                SelectedPath = SectionClasses.WorldConfig.tMapPath.Text,
                Description = "Select a directory to save map files to"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SectionClasses.WorldConfig.tMapPath.Text = dialog.SelectedPath;
            }
        }

        #endregion


        #region Security

        internal void cVerifyNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            SectionClasses.SecurityConfig.xAllowUnverifiedLAN.Enabled = (SectionClasses.SecurityConfig.cVerifyNames.SelectedIndex != 0);
            SectionClasses.SecurityConfig.xAllowUnverifiedLAN.Checked = !SectionClasses.SecurityConfig.xAllowUnverifiedLAN.Enabled;
        }

        internal void xMaxConnectionsPerIP_CheckedChanged(object sender, EventArgs e)
        {
            SectionClasses.SecurityConfig.nMaxConnectionsPerIP.Enabled = SectionClasses.SecurityConfig.xMaxConnectionsPerIP.Checked;
        }

        #endregion


        #region Logging

        internal void vConsoleOptions_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            e.Item.Font = e.Item.Checked ? _bold : SectionClasses.LoggingConfig.vConsoleOptions.Font;
        }

        internal void vLogFileOptions_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            e.Item.Font = e.Item.Checked ? _bold : SectionClasses.LoggingConfig.vLogFileOptions.Font;
        }

        internal void xLogLimit_CheckedChanged(object sender, EventArgs e)
        {
            SectionClasses.LoggingConfig.nLogLimit.Enabled = SectionClasses.LoggingConfig.xLogLimit.Checked;
        }

        #endregion


        #region Saving & Backup

        internal void xSaveAtInterval_CheckedChanged(object sender, EventArgs e)
        {
            SectionClasses.SavingConfig.nSaveInterval.Enabled = SectionClasses.SavingConfig.xSaveInterval.Checked;
        }

        internal void xBackupAtInterval_CheckedChanged(object sender, EventArgs e)
        {
            SectionClasses.SavingConfig.nBackupInterval.Enabled = SectionClasses.SavingConfig.xBackupInterval.Checked;
        }

        internal void xMaxBackups_CheckedChanged(object sender, EventArgs e)
        {
            SectionClasses.SavingConfig.nMaxBackups.Enabled = SectionClasses.SavingConfig.xMaxBackups.Checked;
        }

        internal void xMaxBackupSize_CheckedChanged(object sender, EventArgs e)
        {
            SectionClasses.SavingConfig.nMaxBackupSize.Enabled = SectionClasses.SavingConfig.xMaxBackupSize.Checked;
        }

        #endregion


        #region IRC

        internal void xIRC_CheckedChanged(object sender, EventArgs e)
        {
            SectionClasses.IRCConfig.gIRCNetwork.Enabled = SectionClasses.IRCConfig.xIRCBotEnabled.Checked;
            SectionClasses.IRCConfig.gIRCOptions.Enabled = SectionClasses.IRCConfig.xIRCBotEnabled.Checked;
            SectionClasses.IRCConfig.lIRCList.Enabled = SectionClasses.IRCConfig.xIRCBotEnabled.Checked;
            SectionClasses.IRCConfig.cIRCList.Enabled = SectionClasses.IRCConfig.xIRCBotEnabled.Checked;
            SectionClasses.IRCConfig.xIRCListShowNonEnglish.Enabled = SectionClasses.IRCConfig.xIRCBotEnabled.Checked;
        }


        internal struct IrcNetwork
        {
            internal const int DefaultIrcPort = 6667;

            public readonly string Name, Host;
            public readonly int Port;
            public readonly bool IsNonEnglish;

            public IrcNetwork(string name, string host, int port = DefaultIrcPort, bool isNonEnglish = false)
            {
                Name = name;
                Host = host;
                Port = port;
                IsNonEnglish = isNonEnglish;
            }
        }

        internal static readonly IrcNetwork[] IrcNetworks = new[]{
            new IrcNetwork("FreeNode", "chat.freenode.net"),
            new IrcNetwork("QuakeNet", "irc.quakenet.org"),
            new IrcNetwork("IRCnet", "irc.belwue.de"),
            new IrcNetwork("Undernet", "irc.undernet.org"),
            new IrcNetwork("EFNet", "irc.servercentral.net"),
            new IrcNetwork("Ustream", "c.ustream.tv"),
            new IrcNetwork("WebChat", "irc.webchat.org"),
            new IrcNetwork("DALnet", "irc.dal.net"),
            new IrcNetwork("Rizon","irc.rizon.net"),
            new IrcNetwork("IRC-Hispano [ES]", "irc.irc-hispano.org", 6667, true),
            new IrcNetwork("FCirc", "irc.friend.td.nu"),
            new IrcNetwork("GameSurge", "irc.gamesurge.net"),
            new IrcNetwork("LinkNet", "irc.link-net.org"),
            new IrcNetwork("OltreIrc [IT]", "irc.oltreirc.net", 6667,true),
            new IrcNetwork("AllNetwork", "irc.allnetwork.org"),
            new IrcNetwork("SwiftIRC", "irc.swiftirc.net"),
            new IrcNetwork("OpenJoke", "irc.openjoke.org"),
            new IrcNetwork("Abjects", "irc.abjects.net"),
            new IrcNetwork("OFTC", "irc.oftc.net"),
            new IrcNetwork("ChatZona [ES]", "irc.chatzona.org", 6667, true ),
            new IrcNetwork("synIRC", "irc.synirc.net"),
            new IrcNetwork("OnlineGamesNet", "irc.OnlineGamesNet.net"),
            new IrcNetwork("DarkSin [IT]", "irc.darksin.it", 6667,true),
            new IrcNetwork("RusNet", "irc.run.net", 6667,true),
            new IrcNetwork("ExplosionIRC", "irc.explosionirc.net"),
            new IrcNetwork("IrCQ-Net", "irc.icq.com"),
            new IrcNetwork("IRCHighWay", "irc.irchighway.net"),
            new IrcNetwork("EsperNet", "irc.esper.net"),
            new IrcNetwork("euIRC", "irc.euirc.net"),
            new IrcNetwork("P2P-NET", "irc.p2p-irc.net"),
            new IrcNetwork("Mibbit", "irc.mibbit.com"),
            new IrcNetwork("kiss0fdeath", "irc.kiss0fdeath.net"),
            new IrcNetwork("P2P-NET.EU", "titan.ca.p2p-net.eu"),
            new IrcNetwork("2ch [JP]", "irc.2ch.net", 6667,true),
            new IrcNetwork("SorceryNet", "irc.sorcery.net", 9000),
            new IrcNetwork("FurNet", "irc.furnet.org"),
            new IrcNetwork("GIMPnet", "irc.gimp.org"),
            new IrcNetwork("Coldfront", "irc.coldfront.net"),
            new IrcNetwork("MindForge", "irc.mindforge.org"),
            new IrcNetwork("Zurna.Net [TR]","irc.zurna.net",6667,true),
            new IrcNetwork("7-indonesia [ID]", "irc.7-indonesia.org", 6667,true),
            new IrcNetwork("EpiKnet", "irc.epiknet.org"),
            new IrcNetwork("EnterTheGame", "irc.enterthegame.com"),
            new IrcNetwork("DalNet(ru) [RU]", "irc.chatnet.ru", 6667,true),
            new IrcNetwork("GalaxyNet", "irc.galaxynet.org"),
            new IrcNetwork("Omerta", "irc.barafranca.com"),
            new IrcNetwork("SlashNET", "irc.slashnet.org"),
            new IrcNetwork("DarkMyst", "irc2.darkmyst.org"),
            new IrcNetwork("iZ-smart.net", "irc.iZ-smart.net"),
            new IrcNetwork("ItaLiaN-AmiCi [IT]", "irc.italian-amici.com", 6667,true),
            new IrcNetwork("Aitvaras [LT]", "irc.data.lt", 6667,true),
            new IrcNetwork("V-IRC [RU]", "irc.v-irc.ru", 6667,true),
            new IrcNetwork("ByroeNet [ID]", "irc.byroe.net", 6667,true),
            new IrcNetwork("Azzurra [IT]", "irc.azzurra.org", 6667,true),
            new IrcNetwork("Europa-IRC.DE [DE]", "irc.europa-irc.de", 6667,true),
            new IrcNetwork("ByNets [BY]", "irc.bynets.org", 6667,true),
            new IrcNetwork("GRNet [GR]", "global.irc.gr", 6667,true),
            new IrcNetwork("OceanIRC", "irc.oceanirc.net"),
            new IrcNetwork("UniBG [BG]", "irc.ITDNet.net", 6667,true),
            new IrcNetwork("KampungChat.Org [MY]", "irc.kampungchat.org", 6667,true),
            new IrcNetwork("WeNet [RU]", "ircworld.ru", 6667,true),
            new IrcNetwork("Stratics", "irc.stratics.com"),
            new IrcNetwork("Mozilla", "irc.mozilla.org"),
            new IrcNetwork("bondage.com", "irc.bondage.com"),
            new IrcNetwork("ShakeIT [BG]", "irc.index.bg", 6667,true),
            new IrcNetwork("NetGamers.Org", "firefly.no.eu.netgamers.org"),
            new IrcNetwork("FroZyn", "irc.Frozyn.us"),
            new IrcNetwork("PTnet", "irc.ptnet.org"),
            new IrcNetwork("Recycled-IRC", "yare.recycled-irc.net"),
            new IrcNetwork("Foonetic", "irc.foonetic.net"),
            new IrcNetwork("AlphaIRC", "irc.alphairc.com"),
            new IrcNetwork("KreyNet", "chat.be.krey.net"),
            new IrcNetwork("GeekShed", "irc.geekshed.net"),
            new IrcNetwork("VirtuaLife.com.br [BR]", "irc.virtualife.com.br", 6667,true),
            new IrcNetwork("IRCGate.it [IT]", "marte.ircgate.it", 6667,true),
            new IrcNetwork("Worldnet", "irc.worldnet.net"),
            new IrcNetwork("PIK [BA]", "irc.krstarica.com", 6667,true),
            new IrcNetwork("Friend4ever [IT]", "irc.friend4ever.it", 6667,true),
            new IrcNetwork("AustNet", "irc.austnet.org"),
            new IrcNetwork("GamesNET","irc.GamesNET.net")
        }.OrderBy(network => network.Name).ToArray();

        internal void cIRCList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SectionClasses.IRCConfig.cIRCList.SelectedIndex < 0) return;
            string selectedNetwork = (string)SectionClasses.IRCConfig.cIRCList.Items[SectionClasses.IRCConfig.cIRCList.SelectedIndex];
            IrcNetwork network = IrcNetworks.First(n => (n.Name == selectedNetwork));
            SectionClasses.IRCConfig.tIRCBotNetwork.Text = network.Host;
            SectionClasses.IRCConfig.nIRCBotPort.Value = network.Port;
        }

        internal void xIRCListShowNonEnglish_CheckedChanged(object sender, EventArgs e)
        {
            FillIrcNetworkList(SectionClasses.IRCConfig.xIRCListShowNonEnglish.Checked);
        }

        internal void FillIrcNetworkList(bool showNonEnglishNetworks)
        {
            SectionClasses.IRCConfig.cIRCList.Items.Clear();
            foreach (IrcNetwork network in IrcNetworks)
            {
                if (showNonEnglishNetworks || !network.IsNonEnglish)
                {
                    SectionClasses.IRCConfig.cIRCList.Items.Add(network.Name);
                }
            }
        }

        internal void xIRCRegisteredNick_CheckedChanged(object sender, EventArgs e)
        {
            SectionClasses.IRCConfig.tIRCNickServ.Enabled = SectionClasses.IRCConfig.xIRCRegisteredNick.Checked;
            SectionClasses.IRCConfig.tIRCNickServMessage.Enabled = SectionClasses.IRCConfig.xIRCRegisteredNick.Checked;
        }

        #endregion


        #region Advanced

        internal void nMaxUndo_ValueChanged(object sender, EventArgs e)
        {
            if (SectionClasses.AdvancedConfig.xMaxUndo.Checked)
            {
                decimal maxMemUsage = 
                    Math.Ceiling(
                        SectionClasses.AdvancedConfig.nMaxUndoStates.Value 
                        * (SectionClasses.AdvancedConfig.nMaxUndo.Value * 8) 
                        / (1024 * 1024));
                SectionClasses.AdvancedConfig.lMaxUndoUnits.Text = $"blocks each (up to {maxMemUsage} MB of RAM per player)";
            }
            else
            {
                SectionClasses.AdvancedConfig.lMaxUndoUnits.Text = "blocks each";
            }
        }

        internal void xMaxUndo_CheckedChanged(object sender, EventArgs e)
        {
            SectionClasses.AdvancedConfig.nMaxUndo.Enabled = SectionClasses.AdvancedConfig.xMaxUndo.Checked;
            SectionClasses.AdvancedConfig.lMaxUndoUnits.Enabled = SectionClasses.AdvancedConfig.xMaxUndo.Checked;
        }

        internal void xMapPath_CheckedChanged(object sender, EventArgs e)
        {
            SectionClasses.WorldConfig.tMapPath.Enabled = SectionClasses.WorldConfig.xMapPath.Checked;
            SectionClasses.WorldConfig.bMapPath.Enabled = SectionClasses.WorldConfig.xMapPath.Checked;
        }

        #endregion

        internal void xAnnounceRankChanges_CheckedChanged(object sender, EventArgs e)
        {
            SectionClasses.SecurityConfig.xAnnounceRankChangeReasons.Enabled = SectionClasses.SecurityConfig.xAnnounceRankChanges.Checked;
        }

        #endregion


        #region Ranks

        internal BindingList<string> _rankNameList;

        internal void SelectRank(Rank rank)
        {
            if (rank == null)
            {
                if (SectionClasses.RankConfig.vRanks.SelectedIndex != -1)
                {
                    SectionClasses.RankConfig.vRanks.ClearSelected();
                    return;
                }
                DisableRankOptions();
                return;
            }
            if (SectionClasses.RankConfig.vRanks.SelectedIndex != rank.Index)
            {
                SectionClasses.RankConfig.vRanks.SelectedIndex = rank.Index;
                return;
            }
            _selectedRank = rank;
            SectionClasses.RankConfig.tRankName.Text = rank.Name;

            ApplyColor(SectionClasses.RankConfig.bColorRank, Utils.Color.ParseToIndex(rank.Color));

            SectionClasses.RankConfig.tPrefix.Text = rank.Prefix;

            foreach (var box in _permissionLimitBoxes.Values)
            {
                box.SelectRank(rank);
            }

            SectionClasses.RankConfig.xReserveSlot.Checked = rank.ReservedSlot;
            SectionClasses.RankConfig.xKickIdle.Checked = rank.IdleKickTimer > 0;
            SectionClasses.RankConfig.nKickIdle.Value = rank.IdleKickTimer;
            SectionClasses.RankConfig.nKickIdle.Enabled = SectionClasses.RankConfig.xKickIdle.Checked;
            SectionClasses.RankConfig.xAntiGrief.Checked = (rank.AntiGriefBlocks > 0 && rank.AntiGriefSeconds > 0);
            SectionClasses.RankConfig.nAntiGriefBlocks.Value = rank.AntiGriefBlocks;
            SectionClasses.RankConfig.nAntiGriefBlocks.Enabled = SectionClasses.RankConfig.xAntiGrief.Checked;
            SectionClasses.RankConfig.nAntiGriefSeconds.Value = rank.AntiGriefSeconds;
            SectionClasses.RankConfig.nAntiGriefSeconds.Enabled = SectionClasses.RankConfig.xAntiGrief.Checked;
            SectionClasses.RankConfig.xDrawLimit.Checked = (rank.DrawLimit > 0);
            SectionClasses.RankConfig.nDrawLimit.Value = rank.DrawLimit;
            SectionClasses.RankConfig.nCopyPasteSlots.Value = rank.CopySlots;
            SectionClasses.RankConfig.nFillLimit.Value = rank.FillLimit;
            SectionClasses.RankConfig.xAllowSecurityCircumvention.Checked = rank.AllowSecurityCircumvention;

            foreach (ListViewItem item in SectionClasses.RankConfig.vPermissions.Items)
            {
                item.Checked = rank.Permissions[item.Index];
                item.Font = item.Checked ? _bold : SectionClasses.RankConfig.vPermissions.Font;
            }

            foreach (ListViewItem item in SectionClasses.RankConfig.vPermissions.Items)
            {
                CheckPermissionConsistency((Permission)item.Tag, item.Checked);
            }

            SectionClasses.RankConfig.xDrawLimit.Enabled = rank.Can(Permission.Draw) || rank.Can(Permission.CopyAndPaste);
            SectionClasses.RankConfig.nDrawLimit.Enabled = SectionClasses.RankConfig.xDrawLimit.Checked;
            SectionClasses.RankConfig.xAllowSecurityCircumvention.Enabled = rank.Can(Permission.ManageWorlds) || rank.Can(Permission.ManageZones);

            SectionClasses.RankConfig.gRankOptions.Enabled = true;
            SectionClasses.RankConfig.lPermissions.Enabled = true;
            SectionClasses.RankConfig.vPermissions.Enabled = true;

            SectionClasses.RankConfig.bDeleteRank.Enabled = true;
            SectionClasses.RankConfig.bRaiseRank.Enabled = (_selectedRank != RankManager.HighestRank);
            SectionClasses.RankConfig.bLowerRank.Enabled = (_selectedRank != RankManager.LowestRank);
        }


        internal void RebuildRankList()
        {
            SectionClasses.RankConfig.vRanks.Items.Clear();
            foreach (Rank rank in RankManager.Ranks)
            {
                SectionClasses.RankConfig.vRanks.Items.Add(ToComboBoxOption(rank));
            }

            FillRankList(SectionClasses.GeneralConfig.cDefaultRank, "(lowest rank)");
            SectionClasses.GeneralConfig.cDefaultRank.SelectedIndex = RankManager.GetIndex(RankManager.DefaultRank);
            FillRankList(SectionClasses.WorldConfig.cDefaultBuildRank, "(default rank)");
            SectionClasses.WorldConfig.cDefaultBuildRank.SelectedIndex = RankManager.GetIndex(RankManager.DefaultBuildRank);
            FillRankList(SectionClasses.SecurityConfig.cPatrolledRank, "(default rank)");
            SectionClasses.SecurityConfig.cPatrolledRank.SelectedIndex = RankManager.GetIndex(RankManager.PatrolledRank);
            FillRankList(SectionClasses.SecurityConfig.cBlockDBAutoEnableRank, "(default rank)");
            SectionClasses.SecurityConfig.cBlockDBAutoEnableRank.SelectedIndex = RankManager.GetIndex(RankManager.BlockDBAutoEnableRank);

            if (_selectedRank != null)
            {
                SectionClasses.RankConfig.vRanks.SelectedIndex = _selectedRank.Index;
            }
            SelectRank(_selectedRank);

            foreach (var box in _permissionLimitBoxes.Values)
            {
                box.RebuildList();
                box.SelectRank(_selectedRank);
            }
        }


        internal void DisableRankOptions()
        {
            _selectedRank = null;
            SectionClasses.RankConfig.bDeleteRank.Enabled = false;
            SectionClasses.RankConfig.bRaiseRank.Enabled = false;
            SectionClasses.RankConfig.bLowerRank.Enabled = false;
            SectionClasses.RankConfig.tRankName.Text = "";
            SectionClasses.RankConfig.bColorRank.Text = "";
            SectionClasses.RankConfig.tPrefix.Text = "";

            foreach (var box in _permissionLimitBoxes.Values)
            {
                box.SelectRank(null);
            }

            SectionClasses.RankConfig.xReserveSlot.Checked = false;
            SectionClasses.RankConfig.xKickIdle.Checked = false;
            SectionClasses.RankConfig.nKickIdle.Value = 0;
            SectionClasses.RankConfig.xAntiGrief.Checked = false;
            SectionClasses.RankConfig.nAntiGriefBlocks.Value = 0;
            SectionClasses.RankConfig.xDrawLimit.Checked = false;
            SectionClasses.RankConfig.nDrawLimit.Value = 0;
            SectionClasses.RankConfig.xAllowSecurityCircumvention.Checked = false;
            SectionClasses.RankConfig.nCopyPasteSlots.Value = 0;
            SectionClasses.RankConfig.nFillLimit.Value = 32;
            foreach (ListViewItem item in SectionClasses.RankConfig.vPermissions.Items)
            {
                item.Checked = false;
                item.Font = SectionClasses.RankConfig.vPermissions.Font;
            }
            SectionClasses.RankConfig.gRankOptions.Enabled = false;
            SectionClasses.RankConfig.lPermissions.Enabled = false;
            SectionClasses.RankConfig.vPermissions.Enabled = false;
        }


        internal static void FillRankList([NotNull] ComboBox box, string firstItem)
        {
            if (box == null) throw new ArgumentNullException(nameof(box));
            box.Items.Clear();
            box.Items.Add(firstItem);
            foreach (Rank rank in RankManager.Ranks)
            {
                box.Items.Add(ToComboBoxOption(rank));
            }
        }


        #region Ranks Input Handlers

        internal void bAddRank_Click(object sender, EventArgs e)
        {
            int number = 1;
            while (RankManager.RanksByName.ContainsKey("rank" + number)) number++;

            Rank rank = new Rank("rank" + number, RankManager.GenerateID());

            RankManager.AddRank(rank);
            _selectedRank = null;

            RebuildRankList();
            SelectRank(rank);

            _rankNameList.Insert(rank.Index + 1, ToComboBoxOption(rank));
        }

        internal void bDeleteRank_Click(object sender, EventArgs e)
        {
            if (SectionClasses.RankConfig.vRanks.SelectedItem == null) return;
            _selectedRank = null;
            int index = SectionClasses.RankConfig.vRanks.SelectedIndex;
            Rank deletedRank = RankManager.FindRank(index);
            if (deletedRank == null) return;

            string messages = "";

            // Ask for substitute rank
            DeleteRankPopup popup = new DeleteRankPopup(deletedRank);
            if (popup.ShowDialog() != DialogResult.OK) return;

            Rank replacementRank = popup.SubstituteRank;

            // Update default rank
            if (RankManager.DefaultRank == deletedRank)
            {
                RankManager.DefaultRank = replacementRank;
                messages += "DefaultRank has been changed to \"" + replacementRank.Name + "\"" + Environment.NewLine;
            }

            // Update default build rank
            if (RankManager.DefaultBuildRank == deletedRank)
            {
                RankManager.DefaultBuildRank = replacementRank;
                messages += "DefaultBuildRank has been changed to \"" + replacementRank.Name + "\"" + Environment.NewLine;
            }

            // Update patrolled rank
            if (RankManager.PatrolledRank == deletedRank)
            {
                RankManager.PatrolledRank = replacementRank;
                messages += "PatrolledRank has been changed to \"" + replacementRank.Name + "\"" + Environment.NewLine;
            }

            // Update patrolled rank
            if (RankManager.BlockDBAutoEnableRank == deletedRank)
            {
                RankManager.BlockDBAutoEnableRank = replacementRank;
                messages += "BlockDBAutoEnableRank has been changed to \"" + replacementRank.Name + "\"" + Environment.NewLine;
            }

            // Delete rank
            if (RankManager.DeleteRank(deletedRank, replacementRank))
            {
                messages += "Some of the rank limits for kick, ban, promote, and/or demote have been reset." + Environment.NewLine;
            }
            SectionClasses.RankConfig.vRanks.Items.RemoveAt(index);

            // Update world permissions
            string worldUpdates = "";
            foreach (WorldListEntry world in Worlds)
            {
                if (world.AccessPermission == ToComboBoxOption(deletedRank))
                {
                    world.AccessPermission = ToComboBoxOption(replacementRank);
                    worldUpdates += " - " + world.Name + ": access permission changed to " + replacementRank.Name + Environment.NewLine;
                }
                if (world.BuildPermission == ToComboBoxOption(deletedRank))
                {
                    world.BuildPermission = ToComboBoxOption(replacementRank);
                    worldUpdates += " - " + world.Name + ": build permission changed to " + replacementRank.Name + Environment.NewLine;
                }
            }

            _rankNameList.RemoveAt(index + 1);

            if (worldUpdates.Length > 0)
            {
                messages += "The following worlds were affected:" + Environment.NewLine + worldUpdates;
            }

            if (messages.Length > 0)
            {
                MessageBox.Show(messages, "Warning");
            }

            RebuildRankList();

            if (index < SectionClasses.RankConfig.vRanks.Items.Count)
            {
                SectionClasses.RankConfig.vRanks.SelectedIndex = index;
            }
        }


        internal void tPrefix_Validating(object sender, CancelEventArgs e)
        {
            if (_selectedRank == null) return;
            SectionClasses.RankConfig.tPrefix.Text = SectionClasses.RankConfig.tPrefix.Text.Trim();
            if (SectionClasses.RankConfig.tPrefix.Text.Length > 0 
                && !Rank.IsValidPrefix(SectionClasses.RankConfig.tPrefix.Text))
            {
                MessageBox.Show("Invalid prefix character!\n" +
                    "Prefixes may only contain characters that are allowed in chat (except space).", "Warning");
                SectionClasses.RankConfig.tPrefix.ForeColor = System.Drawing.Color.Red;
                e.Cancel = true;
            }
            else
            {
                SectionClasses.RankConfig.tPrefix.ForeColor = SystemColors.ControlText;
            }
            if (_selectedRank.Prefix == SectionClasses.RankConfig.tPrefix.Text) return;

            string oldName = ToComboBoxOption(_selectedRank);

            // To avoid DataErrors in World tab's DataGridView while renaming a rank,
            // the new name is first added to the list of options (without removing the old name)
            _rankNameList.Insert(_selectedRank.Index + 1, $"{SectionClasses.RankConfig.tPrefix.Text,1}{_selectedRank.Name}");

            _selectedRank.Prefix = SectionClasses.RankConfig.tPrefix.Text;

            // Remove the old name from the list of options
            _rankNameList.Remove(oldName);

            Worlds.ResetBindings();
            RebuildRankList();
        }

        internal void xReserveSlot_CheckedChanged(object sender, EventArgs e)
        {
            if (_selectedRank == null) return;
            _selectedRank.ReservedSlot = SectionClasses.RankConfig.xReserveSlot.Checked;
        }

        internal void nKickIdle_ValueChanged(object sender, EventArgs e)
        {
            if (_selectedRank == null || !SectionClasses.RankConfig.xKickIdle.Checked) return;
            _selectedRank.IdleKickTimer = Convert.ToInt32(SectionClasses.RankConfig.nKickIdle.Value);
        }

        internal void nAntiGriefBlocks_ValueChanged(object sender, EventArgs e)
        {
            if (_selectedRank == null || !SectionClasses.RankConfig.xAntiGrief.Checked) return;
            _selectedRank.AntiGriefBlocks = Convert.ToInt32(SectionClasses.RankConfig.nAntiGriefBlocks.Value);
        }

        internal void nAntiGriefSeconds_ValueChanged(object sender, EventArgs e)
        {
            if (_selectedRank == null || !SectionClasses.RankConfig.xAntiGrief.Checked) return;
            _selectedRank.AntiGriefSeconds = Convert.ToInt32(SectionClasses.RankConfig.nAntiGriefSeconds.Value);
        }

        internal void nDrawLimit_ValueChanged(object sender, EventArgs e)
        {
            if (_selectedRank == null || !SectionClasses.RankConfig.xDrawLimit.Checked) return;
            _selectedRank.DrawLimit = Convert.ToInt32(SectionClasses.RankConfig.nDrawLimit.Value);
            double cubed = Math.Pow(Convert.ToDouble(SectionClasses.RankConfig.nDrawLimit.Value), 1 / 3d);
            SectionClasses.RankConfig.lDrawLimitUnits.Text = $"blocks ({cubed:0}\u00B3)";
        }

        internal void nCopyPasteSlots_ValueChanged(object sender, EventArgs e)
        {
            if (_selectedRank == null) return;
            _selectedRank.CopySlots = Convert.ToInt32(SectionClasses.RankConfig.nCopyPasteSlots.Value);
        }

        internal void xAllowSecurityCircumvention_CheckedChanged(object sender, EventArgs e)
        {
            if (_selectedRank == null) return;
            _selectedRank.AllowSecurityCircumvention = SectionClasses.RankConfig.xAllowSecurityCircumvention.Checked;
        }

        internal void vRanks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SectionClasses.RankConfig.vRanks.SelectedIndex != -1)
            {
                SelectRank(RankManager.FindRank(SectionClasses.RankConfig.vRanks.SelectedIndex));
            }
            else
            {
                DisableRankOptions();
            }
        }

        internal void xKickIdle_CheckedChanged(object sender, EventArgs e)
        {
            if (_selectedRank == null) return;
            if (SectionClasses.RankConfig.xKickIdle.Checked)
            {
                SectionClasses.RankConfig.nKickIdle.Value = _selectedRank.IdleKickTimer;
            }
            else
            {
                SectionClasses.RankConfig.nKickIdle.Value = 0;
                _selectedRank.IdleKickTimer = 0;
            }
            SectionClasses.RankConfig.nKickIdle.Enabled = SectionClasses.RankConfig.xKickIdle.Checked;
        }

        internal void xAntiGrief_CheckedChanged(object sender, EventArgs e)
        {
            if (_selectedRank == null) return;
            if (SectionClasses.RankConfig.xAntiGrief.Checked)
            {
                SectionClasses.RankConfig.nAntiGriefBlocks.Value = _selectedRank.AntiGriefBlocks;
                SectionClasses.RankConfig.nAntiGriefSeconds.Value = _selectedRank.AntiGriefSeconds;
            }
            else
            {
                SectionClasses.RankConfig.nAntiGriefBlocks.Value = 0;
                _selectedRank.AntiGriefBlocks = 0;
                SectionClasses.RankConfig.nAntiGriefSeconds.Value = 0;
                _selectedRank.AntiGriefSeconds = 0;
            }
            SectionClasses.RankConfig.nAntiGriefBlocks.Enabled = SectionClasses.RankConfig.xAntiGrief.Checked;
            SectionClasses.RankConfig.nAntiGriefSeconds.Enabled = SectionClasses.RankConfig.xAntiGrief.Checked;
        }

        internal void xDrawLimit_CheckedChanged(object sender, EventArgs e)
        {
            if (_selectedRank == null) return;
            if (SectionClasses.RankConfig.xDrawLimit.Checked)
            {
                SectionClasses.RankConfig.nDrawLimit.Value = _selectedRank.DrawLimit;
                double cubed = Math.Pow(Convert.ToDouble(SectionClasses.RankConfig.nDrawLimit.Value), 1 / 3d);
                SectionClasses.RankConfig.lDrawLimitUnits.Text = $"blocks ({cubed:0}\u00B3)";
            }
            else
            {
                SectionClasses.RankConfig.nDrawLimit.Value = 0;
                _selectedRank.DrawLimit = 0;
                SectionClasses.RankConfig.lDrawLimitUnits.Text = "blocks";
            }
            SectionClasses.RankConfig.nDrawLimit.Enabled = SectionClasses.RankConfig.xDrawLimit.Checked;
        }

        internal void vPermissions_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            bool check = e.Item.Checked;
            e.Item.Font = check ? _bold : SectionClasses.RankConfig.vPermissions.Font;
            if (_selectedRank == null) return;

            Permission permission = (Permission)e.Item.Tag;
            CheckPermissionConsistency(permission, check);

            _selectedRank.Permissions[(int)e.Item.Tag] = e.Item.Checked;
        }

        internal void CheckPermissionConsistency(Permission permission, bool check)
        {
            switch (permission)
            {
                case Permission.Chat:
                    if (!check)
                    {
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Say].Checked = false;
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Say].ForeColor = SystemColors.GrayText;
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.UseColorCodes].Checked = false;
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.UseColorCodes].ForeColor = SystemColors.GrayText;
                    }
                    else
                    {
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Say].ForeColor = SystemColors.ControlText;
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.UseColorCodes].ForeColor = SystemColors.ControlText;
                    }
                    break;

                case Permission.Say:
                    if (check) SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Chat].Checked = true;
                    break;

                case Permission.UseColorCodes:
                    if (check) SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Chat].Checked = true;
                    break;

                case Permission.Ban:
                    if (!check)
                    {
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.BanIP].Checked = false;
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.BanIP].ForeColor = SystemColors.GrayText;
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.BanAll].Checked = false;
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.BanAll].ForeColor = SystemColors.GrayText;
                    }
                    else
                    {
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.BanIP].ForeColor = SystemColors.ControlText;
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.BanAll].ForeColor = SystemColors.ControlText;
                    }
                    break;

                case Permission.BanIP:
                    if (check)
                    {
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Ban].Checked = true;
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.BanAll].ForeColor = SystemColors.ControlText;
                    }
                    else
                    {
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.BanAll].Checked = false;
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.BanAll].ForeColor = SystemColors.GrayText;
                    }
                    break;

                case Permission.BanAll:
                    if (check)
                    {
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Ban].Checked = true;
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.BanIP].Checked = true;
                    }
                    break;

                case Permission.Draw:
                    SectionClasses.RankConfig.xDrawLimit.Enabled = SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Draw].Checked ||
                                         SectionClasses.RankConfig.vPermissions.Items[(int)Permission.CopyAndPaste].Checked;
                    if (check)
                    {
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.DrawAdvanced].ForeColor = SystemColors.ControlText;
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.CopyAndPaste].ForeColor = SystemColors.ControlText;
                    }
                    else
                    {
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.DrawAdvanced].Checked = false;
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.DrawAdvanced].ForeColor = SystemColors.GrayText;
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.CopyAndPaste].Checked = false;
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.CopyAndPaste].ForeColor = SystemColors.GrayText;
                    }
                    break;

                case Permission.DrawAdvanced:
                    SectionClasses.RankConfig.lFillLimit.Enabled = check;
                    SectionClasses.RankConfig.lFillLimitUnits.Enabled = check;
                    SectionClasses.RankConfig.nFillLimit.Enabled = check;
                    break;

                case Permission.CopyAndPaste:
                    SectionClasses.RankConfig.xDrawLimit.Enabled = 
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Draw].Checked ||
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.CopyAndPaste].Checked;
                    SectionClasses.RankConfig.lCopyPasteSlots.Enabled = check;
                    SectionClasses.RankConfig.nCopyPasteSlots.Enabled = check;
                    break;

                case Permission.ManageWorlds:
                case Permission.ManageZones:
                    SectionClasses.RankConfig.xAllowSecurityCircumvention.Enabled =
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.ManageWorlds].Checked ||
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.ManageZones].Checked;
                    break;

                case Permission.Teleport:
                    if (!check)
                    {
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Patrol].Checked = false;
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Patrol].ForeColor = SystemColors.GrayText;
                    }
                    else
                    {
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Patrol].ForeColor = SystemColors.ControlText;
                    }
                    break;

                case Permission.Patrol:
                    if (check) SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Teleport].Checked = true;
                    break;

                case Permission.Delete:
                    if (!check)
                    {
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.DeleteAdmincrete].Checked = false;
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.DeleteAdmincrete].ForeColor = SystemColors.GrayText;
                    }
                    else
                    {
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.DeleteAdmincrete].ForeColor = SystemColors.ControlText;
                    }
                    break;

                case Permission.DeleteAdmincrete:
                    if (check) SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Delete].Checked = true;
                    break;

                case Permission.Build:
                    if (!check)
                    {
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.PlaceAdmincrete].Checked = false;
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.PlaceAdmincrete].ForeColor = SystemColors.GrayText;
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.PlaceGrass].Checked = false;
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.PlaceGrass].ForeColor = SystemColors.GrayText;
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.PlaceLava].Checked = false;
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.PlaceLava].ForeColor = SystemColors.GrayText;
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.PlaceWater].Checked = false;
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.PlaceWater].ForeColor = SystemColors.GrayText;
                    }
                    else
                    {
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.PlaceAdmincrete].ForeColor = SystemColors.ControlText;
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.PlaceGrass].ForeColor = SystemColors.ControlText;
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.PlaceLava].ForeColor = SystemColors.ControlText;
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.PlaceWater].ForeColor = SystemColors.ControlText;
                    }
                    break;

                case Permission.PlaceAdmincrete:
                case Permission.PlaceGrass:
                case Permission.PlaceLava:
                case Permission.PlaceWater:
                    if (check) SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Build].Checked = true;
                    break;

                case Permission.Bring:
                    if (!check)
                    {
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.BringAll].Checked = false;
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.BringAll].ForeColor = SystemColors.GrayText;
                    }
                    else
                    {
                        SectionClasses.RankConfig.vPermissions.Items[(int)Permission.BringAll].ForeColor = SystemColors.ControlText;
                    }
                    break;

                case Permission.BringAll:
                    if (check) SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Bring].Checked = true;
                    break;

            }

            if (_permissionLimitBoxes.ContainsKey(permission))
            {
                _permissionLimitBoxes[permission].PermissionToggled(check);
            }
        }

        internal void tRankName_Validating(object sender, CancelEventArgs e)
        {
            SectionClasses.RankConfig.tRankName.ForeColor = SystemColors.ControlText;
            if (_selectedRank == null) return;

            string newName = SectionClasses.RankConfig.tRankName.Text.Trim();

            if (newName == _selectedRank.Name)
            {
                return;

            }

            if (newName.Length == 0)
            {
                MessageBox.Show("Rank name cannot be blank.");
                SectionClasses.RankConfig.tRankName.ForeColor = System.Drawing.Color.Red;
                e.Cancel = true;

            }
            else if (!Rank.IsValidRankName(newName))
            {
                MessageBox.Show("Rank name can only contain letters, digits, and underscores.");
                SectionClasses.RankConfig.tRankName.ForeColor = System.Drawing.Color.Red;
                e.Cancel = true;

            }
            else if (!RankManager.CanRenameRank(_selectedRank, newName))
            {
                MessageBox.Show("There is already another rank named \"" + newName + "\".\n" +
                                 "Duplicate rank names are not allowed.");
                SectionClasses.RankConfig.tRankName.ForeColor = System.Drawing.Color.Red;
                e.Cancel = true;

            }
            else
            {
                string oldName = ToComboBoxOption(_selectedRank);

                // To avoid DataErrors in World tab's DataGridView while renaming a rank,
                // the new name is first added to the list of options (without removing the old name)
                _rankNameList.Insert(_selectedRank.Index + 1, $"{_selectedRank.Prefix,1}{newName}");

                RankManager.RenameRank(_selectedRank, newName);

                // Remove the old name from the list of options
                _rankNameList.Remove(oldName);

                Worlds.ResetBindings();
                RebuildRankList();
            }
        }


        internal void bRaiseRank_Click(object sender, EventArgs e)
        {
            if (_selectedRank == null) return;
            if (!RankManager.RaiseRank(_selectedRank)) return;
            RebuildRankList();
            _rankNameList.Insert(_selectedRank.Index + 1, ToComboBoxOption(_selectedRank));
            _rankNameList.RemoveAt(_selectedRank.Index + 3);
        }

        internal void bLowerRank_Click(object sender, EventArgs e)
        {
            if (_selectedRank == null) return;
            if (!RankManager.LowerRank(_selectedRank)) return;
            RebuildRankList();
            _rankNameList.Insert(_selectedRank.Index + 2, ToComboBoxOption(_selectedRank));
            _rankNameList.RemoveAt(_selectedRank.Index);
        }

        #endregion

        #endregion


        #region Apply / Save / Cancel Buttons

        private void SaveButtonHandlers()
        {
            bApply.Click += bApply_Click;
            btnSave.Click += bSave_Click;
            bResetAll.Click += bResetAll_Click;
        }

        internal void bApply_Click(object sender, EventArgs e)
        {
            SaveEverything();
        }

        internal void bSave_Click(object sender, EventArgs e)
        {
            SaveEverything();
            Application.Exit();
        }

        internal void SaveEverything()
        {
            using (LogRecorder applyLogger = new LogRecorder())
            {
                SaveConfig();
                if (applyLogger.HasMessages)
                {
                    MessageBox.Show(applyLogger.MessageString, "Some problems were encountered with the selected values.");
                    return;
                }
            }
            using (LogRecorder saveLogger = new LogRecorder())
            {
                if (Config.Save())
                {
                    bApply.Enabled = false;
                }
                if (saveLogger.HasMessages)
                {
                    MessageBox.Show(saveLogger.MessageString, "Some problems were encountered while saving.");
                }
            }
        }

        /*internal void bCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }*/

        #endregion


        #region Reset

        internal void bResetAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset everything to defaults?", "Warning",
                                 MessageBoxButtons.OKCancel) != DialogResult.OK) return;
            Config.LoadDefaults();
            Config.ResetRanks();
            Config.ResetLogOptions();

            ApplyTabGeneral();
            ApplyTabChat();
            ApplyTabWorlds(); // also reloads world list
            ApplyTabRanks();
            ApplyTabSecurity();
            ApplyTabSavingAndBackup();
            ApplyTabLogging();
            ApplyTabIRC();
            ApplyTabAdvanced();
        }

        internal void bResetTab_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset this tab to defaults?", "Warning",
                                 MessageBoxButtons.OKCancel) != DialogResult.OK) return;
            switch (_selectedTab)
            {
                case 0:// General
                    Config.LoadDefaults(ConfigSection.General);
                    ApplyTabGeneral();
                    break;
                case 1: // Chat
                    Config.LoadDefaults(ConfigSection.Chat);
                    ApplyTabChat();
                    break;
                case 2:// Worlds
                    Config.LoadDefaults(ConfigSection.Worlds);
                    ApplyTabWorlds(); // also reloads world list
                    break;
                case 3:// Ranks
                    Config.ResetRanks();
                    ApplyTabWorlds();
                    ApplyTabRanks();
                    RebuildRankList();
                    break;
                case 4:// Security
                    Config.LoadDefaults(ConfigSection.Security);
                    ApplyTabSecurity();
                    break;
                case 5:// Saving and Backup
                    Config.LoadDefaults(ConfigSection.SavingAndBackup);
                    ApplyTabSavingAndBackup();
                    break;
                case 6:// Logging
                    Config.LoadDefaults(ConfigSection.Logging);
                    Config.ResetLogOptions();
                    ApplyTabLogging();
                    break;
                case 7:// IRC
                    Config.LoadDefaults(ConfigSection.IRC);
                    ApplyTabIRC();
                    break;
                case 8:// Advanced
                    Config.LoadDefaults(ConfigSection.Logging);
                    ApplyTabAdvanced();
                    break;
            }
        }

        #endregion


        #region Utils

        #region Change Detection

        internal void SomethingChanged(object sender, EventArgs args)
        {
            bApply.Enabled = true;
        }


        internal void AddChangeHandler(Control c, EventHandler handler)
        {
            switch (c)
            {
                case CheckBox box:
                    box.CheckedChanged += handler;
                    break;
                case ComboBox comboBox:
                    comboBox.SelectedIndexChanged += handler;
                    break;
                case ListView _:
                    ((ListView)c).ItemChecked += (o, e) => handler(o, e);
                    break;
                case NumericUpDown _:
                    ((NumericUpDown)c).ValueChanged += handler;
                    break;
                case ListBox _:
                    ((ListBox)c).SelectedIndexChanged += handler;
                    break;
                case TextBoxBase _:
                    c.TextChanged += handler;
                    break;
            }

            foreach (Control child in c.Controls)
            {
                AddChangeHandler(child, handler);
            }
        }

        #endregion


        #region Colors

        internal int _colorSys, _colorSay, _colorHelp, _colorAnnouncement, _colorPm, _colorIrc, _colorMe, _colorWarning, _colorCustom, _colorGlobal;

        internal void ApplyColor(Button button, int color)
        {
            button.Text = Color.GetName(color);
            button.BackColor = ColorPicker.ColorPairs[color].Background;
            button.ForeColor = ColorPicker.ColorPairs[color].Foreground;
            bApply.Enabled = true;
        }

        internal void bColorSys_Click(object sender, EventArgs e)
        {
            ColorPicker picker = new ColorPicker("System message color", _colorSys);
            picker.ShowDialog();
            _colorSys = picker.ColorIndex;
            ApplyColor(SectionClasses.ChatConfig.bColorSys, _colorSys);
            Color.Sys = Color.Parse(_colorSys);
        }

        internal void bColorHelp_Click(object sender, EventArgs e)
        {
            ColorPicker picker = new ColorPicker("Help message color", _colorHelp);
            picker.ShowDialog();
            _colorHelp = picker.ColorIndex;
            ApplyColor(SectionClasses.ChatConfig.bColorHelp, _colorHelp);
            Color.Help = Color.Parse(_colorHelp);
        }

        internal void bColorSay_Click(object sender, EventArgs e)
        {
            ColorPicker picker = new ColorPicker("/Say message color", _colorSay);
            picker.ShowDialog();
            _colorSay = picker.ColorIndex;
            ApplyColor(SectionClasses.ChatConfig.bColorSay, _colorSay);
            Color.Say = Color.Parse(_colorSay);
        }

        internal void bColorAnnouncement_Click(object sender, EventArgs e)
        {
            ColorPicker picker = new ColorPicker("Announcement color", _colorAnnouncement);
            picker.ShowDialog();
            _colorAnnouncement = picker.ColorIndex;
            ApplyColor(SectionClasses.ChatConfig.bColorAnnouncement, _colorAnnouncement);
            Color.Announcement = Color.Parse(_colorAnnouncement);
        }

        internal void bColorPM_Click(object sender, EventArgs e)
        {
            ColorPicker picker = new ColorPicker("internal / rank chat color", _colorPm);
            picker.ShowDialog();
            _colorPm = picker.ColorIndex;
            ApplyColor(SectionClasses.ChatConfig.bColorPM, _colorPm);
            Color.PM = Color.Parse(_colorPm);
        }

        internal void bColorWarning_Click(object sender, EventArgs e)
        {
            ColorPicker picker = new ColorPicker("Warning / Error message color", _colorWarning);
            picker.ShowDialog();
            _colorWarning = picker.ColorIndex;
            ApplyColor(SectionClasses.ChatConfig.bColorWarning, _colorWarning);
            Color.Warning = Color.Parse(_colorWarning);
        }

        internal void bColorMe_Click(object sender, EventArgs e)
        {
            ColorPicker picker = new ColorPicker("/Me command color", _colorMe);
            picker.ShowDialog();
            _colorMe = picker.ColorIndex;
            ApplyColor(SectionClasses.ChatConfig.bColorMe, _colorMe);
            Color.Me = Color.Parse(_colorMe);
        }

        internal void bColorIRC_Click(object sender, EventArgs e)
        {
            ColorPicker picker = new ColorPicker("IRC message color", _colorIrc);
            picker.ShowDialog();
            _colorIrc = picker.ColorIndex;
            ApplyColor(SectionClasses.IRCConfig.bColorIRC, _colorIrc);
            Color.IRC = Color.Parse(_colorIrc);
        }

        internal void bColorGlobal_Click(object sender, EventArgs e)
        {
            ColorPicker picker = new ColorPicker("Global message color", _colorGlobal);
            picker.ShowDialog();
            _colorGlobal = picker.ColorIndex;
            ApplyColor(SectionClasses.ChatConfig.bColorGlobal, _colorGlobal);
            Color.Global = Color.Parse(_colorGlobal);
        }

        internal void bColorRank_Click(object sender, EventArgs e)
        {
            ColorPicker picker = new ColorPicker("Rank color for \"" + _selectedRank.Name + "\"", Color.ParseToIndex(_selectedRank.Color));
            picker.ShowDialog();
            ApplyColor(SectionClasses.RankConfig.bColorRank, picker.ColorIndex);
            _selectedRank.Color = Color.Parse(picker.ColorIndex) ?? throw new InvalidOperationException();
        }


        internal void HandleTabChatChange(object sender, EventArgs args)
        {
            UpdateChatPreview();
        }

        [SuppressMessage("ReSharper", "UseStringInterpolation")]
        internal void UpdateChatPreview()
        {
            List<string> lines = new List<string>();
            if (SectionClasses.ChatConfig.xShowConnectionMessages.Checked)
            {
                lines.Add(string.Format("&SPlayer {0}{1}apotter96&S connected, joined {2}{3}main",
                    SectionClasses.ChatConfig.xRankColorsInChat.Checked ? RankManager.HighestRank.Color : "",
                    SectionClasses.ChatConfig.xRankPrefixesInChat.Checked ? RankManager.HighestRank.Prefix : "",
                    SectionClasses.ChatConfig.xRankColorsInWorldNames.Checked ? RankManager.LowestRank.Color : "",
                    SectionClasses.ChatConfig.xRankPrefixesInChat.Checked ? RankManager.LowestRank.Prefix : ""));
            }
            lines.Add("&R<*- This is an announcement -*>");
            lines.Add("&YThis is a /say announcement");
            lines.Add(string.Format("{0}{1}DingusBungus&F: This is a normal chat message",
                SectionClasses.ChatConfig.xRankColorsInChat.Checked ? RankManager.HighestRank.Color : "",
                SectionClasses.ChatConfig.xRankPrefixesInChat.Checked ? RankManager.HighestRank.Prefix : ""));
            lines.Add("&Pfrom f: This is a internal message /whisper");
            lines.Add("&M*LeChosenOne is using /Me to write this");
            if (SectionClasses.ChatConfig.xShowJoinedWorldMessages.Checked)
            {
                Rank midRank = RankManager.LowestRank;
                if (RankManager.LowestRank.NextRankUp != null)
                {
                    midRank = RankManager.LowestRank.NextRankUp;
                }

                lines.Add(string.Format("&SPlayer {0}{1}Dingus&S joined {2}{3}SomeOtherMap",
                    SectionClasses.ChatConfig.xRankColorsInChat.Checked ? RankManager.HighestRank.Color : "",
                    SectionClasses.ChatConfig.xRankPrefixesInChat.Checked ? RankManager.HighestRank.Prefix : "",
                    SectionClasses.ChatConfig.xRankColorsInWorldNames.Checked ? midRank.Color : "",
                    SectionClasses.ChatConfig.xRankPrefixesInChat.Checked ? midRank.Prefix : ""));
            }
            lines.Add("&SUnknown command \"kikc\", see &H/Commands");
            if (SectionClasses.SecurityConfig.xAnnounceKickAndBanReasons.Checked)
            {
                lines.Add(string.Format("&W{0}{1}LeChosenOne&W was kicked by {0}{1}Dingus&W: Reason goes here",
                    SectionClasses.ChatConfig.xRankColorsInChat.Checked ? RankManager.HighestRank.Color : "",
                    SectionClasses.ChatConfig.xRankPrefixesInChat.Checked ? RankManager.HighestRank.Prefix : ""));
            }
            else
            {
                lines.Add(string.Format("&W{0}{1}LeChosenOne&W was kicked by {0}{1}gamer1",
                    SectionClasses.ChatConfig.xRankColorsInChat.Checked ? RankManager.HighestRank.Color : "",
                    SectionClasses.ChatConfig.xRankPrefixesInChat.Checked ? RankManager.HighestRank.Prefix : ""));
            }

            if (SectionClasses.ChatConfig.xShowConnectionMessages.Checked)
            {
                lines.Add(string.Format("&S{0}{1}Dingus&S left the server.",
                    SectionClasses.ChatConfig.xRankColorsInChat.Checked ? RankManager.HighestRank.Color : "",
                    SectionClasses.ChatConfig.xRankPrefixesInChat.Checked ? RankManager.HighestRank.Prefix : ""));
            }

            SectionClasses.ChatConfig.chatPreview.SetText(lines.ToArray());
        }

        #endregion


        internal void bRules_Click(object sender, EventArgs e)
        {
            TextEditorPopup popup = new TextEditorPopup(Paths.RulesFileName, "Use common sense!");
            popup.ShowDialog();
        }


        internal static bool IsWorldNameTaken(string name)
        {
            return Worlds.Any(world => world.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }





        internal static void HandleWorldRename(string from, string to)
        {
            if (SectionClasses.WorldConfig.cMainWorld.Items.Count == 0) return;
            if (SectionClasses.WorldConfig.cMainWorld.SelectedItem == null)
            {
                SectionClasses.WorldConfig.cMainWorld.SelectedIndex = 0;
            }
            else
            {
                string mainWorldName = SectionClasses.WorldConfig.cMainWorld.SelectedItem.ToString();
                _instance.FillWorldList();
                SectionClasses.WorldConfig.cMainWorld.SelectedItem = mainWorldName == from ? to : mainWorldName;
            }
        }

        #endregion


        internal void ConfigUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!bApply.Enabled) return;
            switch (MessageBox.Show("Would you like to save the changes before exiting?", "Warning", MessageBoxButtons.YesNoCancel))
            {
                case DialogResult.Yes:
                    SaveEverything();
                    return;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    return;
            }
        }


        internal readonly Dictionary<Permission, PermissionLimitBox> _permissionLimitBoxes = new Dictionary<Permission, PermissionLimitBox>();

        internal const string DefaultPermissionLimitString = "(own rank)";
        internal void FillPermissionLimitBoxes()
        {

            _permissionLimitBoxes[Permission.Kick] = new PermissionLimitBox("Kick limit", Permission.Kick, DefaultPermissionLimitString);
            _permissionLimitBoxes[Permission.Ban] = new PermissionLimitBox("Ban limit", Permission.Ban, DefaultPermissionLimitString);
            _permissionLimitBoxes[Permission.Promote] = new PermissionLimitBox("Promote limit", Permission.Promote, DefaultPermissionLimitString);
            _permissionLimitBoxes[Permission.Demote] = new PermissionLimitBox("Demote limit", Permission.Demote, DefaultPermissionLimitString);
            _permissionLimitBoxes[Permission.Hide] = new PermissionLimitBox("Can hide from", Permission.Hide, DefaultPermissionLimitString);
            _permissionLimitBoxes[Permission.Freeze] = new PermissionLimitBox("Freeze limit", Permission.Freeze, DefaultPermissionLimitString);
            _permissionLimitBoxes[Permission.Mute] = new PermissionLimitBox("Mute limit", Permission.Mute, DefaultPermissionLimitString);
            _permissionLimitBoxes[Permission.Bring] = new PermissionLimitBox("Bring limit", Permission.Bring, DefaultPermissionLimitString);
            _permissionLimitBoxes[Permission.Spectate] = new PermissionLimitBox("Spectate limit", Permission.Spectate, DefaultPermissionLimitString);
            _permissionLimitBoxes[Permission.UndoOthersActions] = new PermissionLimitBox("Undo limit", Permission.UndoOthersActions, DefaultPermissionLimitString);
            _permissionLimitBoxes[Permission.Slap] = new PermissionLimitBox("Slap limit", Permission.Slap, DefaultPermissionLimitString);
            _permissionLimitBoxes[Permission.Kill] = new PermissionLimitBox("Kill limit", Permission.Kill, DefaultPermissionLimitString);
            _permissionLimitBoxes[Permission.Possess] = new PermissionLimitBox("Possess limit", Permission.Possess, DefaultPermissionLimitString);
            _permissionLimitBoxes[Permission.Warn] = new PermissionLimitBox("Warn limit", Permission.Warn, DefaultPermissionLimitString);
            _permissionLimitBoxes[Permission.Gtfo] = new PermissionLimitBox("Gtfo limit", Permission.Gtfo, DefaultPermissionLimitString);

            foreach (var box in _permissionLimitBoxes.Values)
            {
                SectionClasses.RankConfig.permissionLimitBoxContainer.Controls.Add(box);
            }
        }


        internal void cDefaultRank_SelectedIndexChanged(object sender, EventArgs e)
        {
            RankManager.DefaultRank = RankManager.FindRank(SectionClasses.GeneralConfig.cDefaultRank.SelectedIndex - 1);
        }

        internal void cDefaultBuildRank_SelectedIndexChanged(object sender, EventArgs e)
        {
            RankManager.DefaultBuildRank = RankManager.FindRank(SectionClasses.WorldConfig.cDefaultBuildRank.SelectedIndex - 1);
        }

        internal void cPatrolledRank_SelectedIndexChanged(object sender, EventArgs e)
        {
            RankManager.PatrolledRank = RankManager.FindRank(SectionClasses.SecurityConfig.cPatrolledRank.SelectedIndex - 1);
        }

        internal void cBlockDBAutoEnableRank_SelectedIndexChanged(object sender, EventArgs e)
        {
            RankManager.BlockDBAutoEnableRank = RankManager.FindRank(SectionClasses.SecurityConfig.cBlockDBAutoEnableRank.SelectedIndex - 1);
        }

        internal void xBlockDBEnabled_CheckedChanged(object sender, EventArgs e)
        {
            SectionClasses.SecurityConfig.xBlockDBAutoEnable.Enabled = 
                SectionClasses.SecurityConfig.xBlockDBEnabled.Checked;
            SectionClasses.SecurityConfig.cBlockDBAutoEnableRank.Enabled =
                SectionClasses.SecurityConfig.xBlockDBEnabled.Checked 
                && SectionClasses.SecurityConfig.xBlockDBAutoEnable.Checked;
        }

        internal void xBlockDBAutoEnable_CheckedChanged(object sender, EventArgs e)
        {
            SectionClasses.SecurityConfig.cBlockDBAutoEnableRank.Enabled =
                SectionClasses.SecurityConfig.xBlockDBEnabled.Checked 
                && SectionClasses.SecurityConfig.xBlockDBAutoEnable.Checked;
        }

        internal void nFillLimit_ValueChanged(object sender, EventArgs e)
        {
            if (_selectedRank == null) return;
            _selectedRank.FillLimit = Convert.ToInt32(SectionClasses.RankConfig.nFillLimit.Value);
        }


        public static bool UsePrefixes;


        public static string ToComboBoxOption(Rank rank)
        {
            return UsePrefixes ? $"{rank.Prefix,1}{rank.Name}" : rank.Name;
        }

        internal void xRankPrefixesInChat_CheckedChanged(object sender, EventArgs e)
        {
            UsePrefixes = SectionClasses.ChatConfig.xRankPrefixesInChat.Checked;
            SectionClasses.RankConfig.tPrefix.Enabled = UsePrefixes;
            SectionClasses.RankConfig.lPrefix.Enabled = UsePrefixes;
            RebuildRankList();
        }

        internal void button1_Click(object sender, EventArgs e)
        {
            ColorPicker picker = new ColorPicker("Custom Chat command color", _colorCustom);
            picker.ShowDialog();
            _colorCustom = picker.ColorIndex;
            ApplyColor(SectionClasses.MiscConfig.CustomColor, _colorCustom);
            Color.Custom = Color.Parse(_colorCustom);
        }


        internal void SwearEditor_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Paths.SwearWordsFileName))
            {
                TextWriter tsw = new StreamWriter(Paths.SwearWordsFileName);
                tsw.Write("//This is where you edit the swearwords on your " +
                    "server, each word should be on a seperate line." +
                    "WARNING: Make sure to delete this line when you're " +
                    "finished reading it!");
                tsw.Close();
                Process.Start(Paths.SwearWordsFileName);
            }
            else Process.Start(Paths.SwearWordsFileName);
        }

        internal void ReqsEditor_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(Paths.ReqPath))
            {
                Directory.CreateDirectory(Paths.ReqPath);
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                Path.Combine(Paths.ReqPath, "requirements.txt");
                File.WriteAllText(Path.Combine(Paths.ReqPath, "requirements.txt"), "//" +
                    "This is the requirements file, here is where you list the requirements " +
                    "for your server's ranks. You can either list all of the requirements " +
                    "here or you can split it into sections by creating text documents in " +
                    "this same directory(requirements folder) (sections are the most preferable). Make sure " +
                    "the text documents are the same name of the rank you are listing " +
                    "the requirements for. If you wish to use color codes use & instead of %");
                Process.Start(Paths.ReqTextPath);

            }

            else if (!File.Exists(Paths.ReqTextPath))
            {
                Process.Start(Paths.ReqDirectory);
            }

            else if (File.Exists(Paths.ReqTextPath))
            {
                Process.Start(Paths.ReqTextPath);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SaveButtonHandlers();
            FormClosing += ConfigUI_FormClosing;
        }

        internal void websiteURL_TextChanged(object sender, EventArgs e)
        {
            SectionClasses.MiscConfig.websiteURL.Text = SectionClasses.MiscConfig.websiteURL.Text.Trim();
        }

        internal void bWeb_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://gemscraft.net/");
            }
            catch
            {
                // ignored
            }
        }

        internal void bWiki_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("http://www.minecraftwiki.net/wiki/Custom_servers/gemscraft");
            }
            catch
            {
                // ignored
            }
        }


        internal void bReadme_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://github.com/LeChosenOne/LegendCraft/blob/master/README.md");
            }
            catch
            {
                // ignored
            }
        }

        internal void bChangelog_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://github.com/LeChosenOne/LegendCraft/blob/master/zLegendCraft%20Changelog.txt");
            }
            catch
            {
                // ignored
            }
        }

        internal void bUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://raw.githubusercontent.com/LeChosenOne/LegendCraft/master/README.md");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode != HttpStatusCode.OK) return;
                using (Stream stream = response.GetResponseStream())
                {
                    if (stream == null) return;
                    StreamReader streamReader = new StreamReader(stream);
                    string version = streamReader.ReadLine();

                    //update is available, prompt for a download
                    if (version != null && version != Updater.LatestStable)
                    {

                        DialogResult answer = MessageBox.Show("A LegendCraft Update is available. Would you like to download the latest LegendCraft Version? (" + version + ")", "LegendCraft Updater", MessageBoxButtons.YesNo);
                        if (answer != DialogResult.Yes) return;
                        using (var client = new WebClient())
                        {
                            try
                            {
                                //download new zip in current directory
                                Process.Start("http://www.legend-craft.tk/download/latest");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Update error: " + ex);
                            }

                        }

                    }
                    else
                    {
                        MessageBox.Show("Your LegendCraft version is up to date!");
                    }
                }
            }

            catch (WebException error)
            {
                MessageBox.Show("There was an internet connection error. Server was unable to check for updates. Error: \n\r" + error);
            }
            catch (Exception error2)
            {
                MessageBox.Show("There was an error in trying to check for updates:\n\r " + error2);
            }

        }

        internal void xChanPass_CheckedChanged(object sender, EventArgs e)
        {
            if (SectionClasses.IRCConfig.xChanPass.Checked)
            {
                SectionClasses.IRCConfig.tChanPass.Enabled = true;
            }
            else
            {
                SectionClasses.IRCConfig.tChanPass.Enabled = false;
                SectionClasses.IRCConfig.tChanPass.Text = "password";
            }
        }

        internal void xServPass_CheckedChanged(object sender, EventArgs e)
        {
            if (SectionClasses.IRCConfig.xServPass.Checked)
            {
                SectionClasses.IRCConfig.tServPass.Enabled = true;
            }
            else
            {
                SectionClasses.IRCConfig.tServPass.Enabled = false;
                SectionClasses.IRCConfig.tServPass.Text = "defaultPass";
            }
        }


        internal void HeartBeatUrlComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    
}
