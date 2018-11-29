// Copyright 2009-2012 Matvei Stefarov <me@matvei.org>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using JetBrains.Annotations;

namespace fCraft.GUI.ConfigGUI {
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public sealed partial class MainForm : Form {
        private static MainForm _instance;
        private readonly Font _bold;
        private Rank _selectedRank;
        private readonly UpdaterSettingsPopup _updaterWindow = new UpdaterSettingsPopup();
        internal static readonly SortableBindingList<WorldListEntry> Worlds = new SortableBindingList<WorldListEntry>();

        #region Initialization

        public MainForm() {
            _instance = this;
            InitializeComponent();
            dgvcBlockDB.TrueValue = YesNoAuto.Yes;
            dgvcBlockDB.FalseValue = YesNoAuto.No;
            dgvcBlockDB.IndeterminateValue = YesNoAuto.Auto;
            _bold = new Font( Font, FontStyle.Bold );
            Shown += Init;
            Text = "LegendCraft Configuration " + Updater.LatestStable;
        }


        private void Init( object sender, EventArgs e ) {
            // fills Permission and LogType lists
            FillEnumLists();

            // create hidden boxes for permission limits
            FillPermissionLimitBoxes();

            // fill out all the tool tips
            FillToolTipsGeneral();
            FillToolTipsChat();
            FillToolTipsWorlds();
            FillToolTipsRanks();
            FillToolTipsSecurity();
            FillToolTipsSavingAndBackup();
            FillToolTipsLogging();
            FillToolTipsIRC();
            FillToolTipsAdvanced();

            FillIrcNetworkList( false );

            // Initialize fCraft's args, paths, and logging backend.
            Server.InitLibrary( Environment.GetCommandLineArgs() );

            dgvWorlds.DataError += WorldListErrorHandler;

            LoadConfig();

            // Redraw chat preview when re-entering the tab.
            // This ensured that changes to rank colors/prefixes are applied.
            tabChat.Enter += ( o, e2 ) => UpdateChatPreview();
        }


        private void FillEnumLists() {
            foreach( Permission permission in Enum.GetValues( typeof( Permission ) ) ) {
                ListViewItem item = new ListViewItem( permission.ToString() ) { Tag = permission };
                vPermissions.Items.Add( item );
            }

            foreach( LogType type in Enum.GetValues( typeof( LogType ) ) ) {
                if( type == LogType.Trace ) continue;
                ListViewItem item = new ListViewItem( type.ToString() ) { Tag = type };
                vLogFileOptions.Items.Add( item );
                vConsoleOptions.Items.Add( (ListViewItem)item.Clone() );
            }
        }


        private void FillWorldList() {
            cMainWorld.Items.Clear();
            foreach( WorldListEntry world in Worlds ) {
                cMainWorld.Items.Add( world.Name );
            }
        }

        #endregion


        #region Input Handlers

        #region General

        private void bMeasure_Click( object sender, EventArgs e ) {
            Process.Start( "http://www.speedtest.net/" );
        }

        private void bAnnouncements_Click( object sender, EventArgs e ) {
            TextEditorPopup popup = new TextEditorPopup( Paths.AnnouncementsFileName, "" );
            popup.ShowDialog();
        }

        private void xAnnouncements_CheckedChanged( object sender, EventArgs e ) {
            nAnnouncements.Enabled = xAnnouncements.Checked;
            bAnnouncements.Enabled = xAnnouncements.Checked;
        }

        private void tIP_Validating( object sender, CancelEventArgs e ) {
            if (Server.IsIP(tIP.Text) && IPAddress.TryParse(tIP.Text, out IPAddress IP))
            {
                tIP.ForeColor = SystemColors.ControlText;
            }
            else
            {
                tIP.ForeColor = System.Drawing.Color.Red;
                e.Cancel = true;
            }
        }

        private void xIP_CheckedChanged( object sender, EventArgs e ) {
            tIP.Enabled = xIP.Checked;
        }

        private void bGreeting_Click( object sender, EventArgs e ) {
            TextEditorPopup popup = new TextEditorPopup( Paths.GreetingFileName,
@"Welcome to {SERVER_NAME}
Your rank is {RANK}&S. Type &H/Help&S for help." );
            popup.ShowDialog();
        }

        private void bShowAdvancedUpdaterSettings_Click( object sender, EventArgs e ) {
            _updaterWindow.ShowDialog();
  
        }


        private void bOpenWiki_Click( object sender, EventArgs e ) {
            Process.Start("http://www.minecraftwiki.net/wiki/Custom_servers/800Craft");
        }

        private void bReportABug_Click( object sender, EventArgs e ) {
            Process.Start("http://LegendCraft.webuda.com");
        }

        private void nMaxPlayerPerWorld_Validating( object sender, CancelEventArgs e ) {
            CheckMaxPlayersPerWorldValue();
        }

        private void nMaxPlayers_ValueChanged( object sender, EventArgs e ) {
            CheckMaxPlayersPerWorldValue();
        }

        private void bCredits_Click( object sender, EventArgs e ) {
            new AboutWindow().Show();
        }

        #endregion


        #region Worlds

        private void WorldListErrorHandler( object sender, DataGridViewDataErrorEventArgs e ) {
            if( e.Exception is FormatException ) {
                string columnName = dgvWorlds.Columns[e.ColumnIndex].HeaderText;
                MessageBox.Show( e.Exception.Message, "Error editing " + columnName );
            } else {
                MessageBox.Show( e.Exception.ToString(), "An error occured in the world list" );
            }
        }

        private void bAddWorld_Click( object sender, EventArgs e ) {
            AddWorldPopup popup = new AddWorldPopup( null );
            if( popup.ShowDialog() == DialogResult.OK ) {
                Worlds.Add( popup.World );
                popup.World.LoadedBy = WorldListEntry.WorldInfoSignature;
                popup.World.LoadedOn = DateTime.UtcNow;
            }
            if( cMainWorld.SelectedItem == null ) {
                FillWorldList();
                if( cMainWorld.Items.Count > 0 ) {
                    cMainWorld.SelectedIndex = 0;
                }
            } else {
                string mainWorldName = cMainWorld.SelectedItem.ToString();
                FillWorldList();
                cMainWorld.SelectedItem = mainWorldName;
            }
        }

        private void bWorldEdit_Click( object sender, EventArgs e ) {
            AddWorldPopup popup = new AddWorldPopup( Worlds[dgvWorlds.SelectedRows[0].Index] );
            if (popup.ShowDialog() != DialogResult.OK) return;
            string oldName = Worlds[dgvWorlds.SelectedRows[0].Index].Name;
            Worlds[dgvWorlds.SelectedRows[0].Index] = popup.World;
            HandleWorldRename( oldName, popup.World.Name );
        }

        private void dgvWorlds_Click( object sender, EventArgs e ) {
            bool oneRowSelected = (dgvWorlds.SelectedRows.Count == 1);
            bWorldDelete.Enabled = oneRowSelected;
            bWorldEdit.Enabled = oneRowSelected;
        }

        private void bWorldDel_Click( object sender, EventArgs e ) {
            if (dgvWorlds.SelectedRows.Count <= 0) return;
            WorldListEntry world = Worlds[dgvWorlds.SelectedRows[0].Index];

            // prompt to delete map file, if it exists
            if( File.Exists( world.FullFileName ) ) {
                string promptMessage = $"Are you sure you want to delete world \"{world.Name}\"?";

                if( MessageBox.Show( promptMessage, "Deleting a world", MessageBoxButtons.YesNo ) == DialogResult.No ) {
                    return;
                }

                string fileDeleteWarning = "Do you want to delete the map file (" + world.FileName + ") as well?";
                if( MessageBox.Show( fileDeleteWarning, "Warning", MessageBoxButtons.YesNo ) == DialogResult.Yes ) {
                    try {
                        File.Delete( world.FullFileName );
                    } catch( Exception ex ) {
                        MessageBox.Show( "You have to delete the file (" + world.FileName + ") manually. " +
                                         "An error occured while trying to delete it automatically:" + Environment.NewLine + ex,
                            "Could not delete map file" );
                    }
                }
            }

            Worlds.Remove( world );

            if( cMainWorld.SelectedItem == null ) {
                // deleting non-main world
                FillWorldList();
                if( cMainWorld.Items.Count > 0 ) {
                    cMainWorld.SelectedIndex = 0;
                }

            } else {
                // deleting main world
                string mainWorldName = cMainWorld.SelectedItem.ToString();
                FillWorldList();
                if( mainWorldName == world.Name ) {
                    MessageBox.Show( "Main world has been reset." );
                    if( cMainWorld.Items.Count > 0 ) {
                        cMainWorld.SelectedIndex = 0;
                    }
                } else {
                    cMainWorld.SelectedItem = mainWorldName;
                }
            }
        }

        private void bMapPath_Click( object sender, EventArgs e ) {
            FolderBrowserDialog dialog = new FolderBrowserDialog {
                SelectedPath = tMapPath.Text,
                Description = "Select a directory to save map files to"
            };
            if( dialog.ShowDialog() == DialogResult.OK ) {
                tMapPath.Text = dialog.SelectedPath;
            }
        }

        #endregion


        #region Security

        private void cVerifyNames_SelectedIndexChanged( object sender, EventArgs e ) {
            xAllowUnverifiedLAN.Enabled = (cVerifyNames.SelectedIndex != 0);
            xAllowUnverifiedLAN.Checked = !xAllowUnverifiedLAN.Enabled;
        }

        private void xMaxConnectionsPerIP_CheckedChanged( object sender, EventArgs e ) {
            nMaxConnectionsPerIP.Enabled = xMaxConnectionsPerIP.Checked;
        }

        #endregion


        #region Logging

        private void vConsoleOptions_ItemChecked( object sender, ItemCheckedEventArgs e )
        {
            e.Item.Font = e.Item.Checked ? _bold : vConsoleOptions.Font;
        }

        private void vLogFileOptions_ItemChecked( object sender, ItemCheckedEventArgs e )
        {
            e.Item.Font = e.Item.Checked ? _bold : vLogFileOptions.Font;
        }

        private void xLogLimit_CheckedChanged( object sender, EventArgs e ) {
            nLogLimit.Enabled = xLogLimit.Checked;
        }

        #endregion


        #region Saving & Backup

        private void xSaveAtInterval_CheckedChanged( object sender, EventArgs e ) {
            nSaveInterval.Enabled = xSaveInterval.Checked;
        }

        private void xBackupAtInterval_CheckedChanged( object sender, EventArgs e ) {
            nBackupInterval.Enabled = xBackupInterval.Checked;
        }

        private void xMaxBackups_CheckedChanged( object sender, EventArgs e ) {
            nMaxBackups.Enabled = xMaxBackups.Checked;
        }

        private void xMaxBackupSize_CheckedChanged( object sender, EventArgs e ) {
            nMaxBackupSize.Enabled = xMaxBackupSize.Checked;
        }

        #endregion


        #region IRC

        private void xIRC_CheckedChanged( object sender, EventArgs e ) {
            gIRCNetwork.Enabled = xIRCBotEnabled.Checked;
            gIRCOptions.Enabled = xIRCBotEnabled.Checked;
            lIRCList.Enabled = xIRCBotEnabled.Checked;
            cIRCList.Enabled = xIRCBotEnabled.Checked;
            xIRCListShowNonEnglish.Enabled = xIRCBotEnabled.Checked;
        }


        private struct IrcNetwork {
            private const int DefaultIrcPort = 6667;

            public readonly string Name, Host;
            public readonly int Port;
            public readonly bool IsNonEnglish;

            public IrcNetwork( string name, string host, int port = DefaultIrcPort, bool isNonEnglish = false) {
                Name = name;
                Host = host;
                Port = port;
                IsNonEnglish = isNonEnglish;
            }
        }

        private static readonly IrcNetwork[] IrcNetworks = new[]{
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
        }.OrderBy( network => network.Name ).ToArray();

        private void cIRCList_SelectedIndexChanged( object sender, EventArgs e ) {
            if( cIRCList.SelectedIndex < 0 ) return;
            string selectedNetwork = (string)cIRCList.Items[cIRCList.SelectedIndex];
            IrcNetwork network = IrcNetworks.First( n => (n.Name == selectedNetwork) );
            tIRCBotNetwork.Text = network.Host;
            nIRCBotPort.Value = network.Port;
        }

        private void xIRCListShowNonEnglish_CheckedChanged( object sender, EventArgs e ) {
            FillIrcNetworkList( xIRCListShowNonEnglish.Checked );
        }

        private void FillIrcNetworkList( bool showNonEnglishNetworks ) {
            cIRCList.Items.Clear();
            foreach( IrcNetwork network in IrcNetworks ) {
                if( showNonEnglishNetworks || !network.IsNonEnglish ) {
                    cIRCList.Items.Add( network.Name );
                }
            }
        }

        private void xIRCRegisteredNick_CheckedChanged( object sender, EventArgs e ) {
            tIRCNickServ.Enabled = xIRCRegisteredNick.Checked;
            tIRCNickServMessage.Enabled = xIRCRegisteredNick.Checked;
        }

        #endregion


        #region Advanced

        private void nMaxUndo_ValueChanged( object sender, EventArgs e ) {
            if( xMaxUndo.Checked ) {
                decimal maxMemUsage = Math.Ceiling( nMaxUndoStates.Value * (nMaxUndo.Value * 8) / (1024 * 1024) );
                lMaxUndoUnits.Text = $"blocks each (up to {maxMemUsage} MB of RAM per player)";
            } else {
                lMaxUndoUnits.Text = "blocks each";
            }
        }

        private void xMaxUndo_CheckedChanged( object sender, EventArgs e ) {
            nMaxUndo.Enabled = xMaxUndo.Checked;
            lMaxUndoUnits.Enabled = xMaxUndo.Checked;
        }

        private void xMapPath_CheckedChanged( object sender, EventArgs e ) {
            tMapPath.Enabled = xMapPath.Checked;
            bMapPath.Enabled = xMapPath.Checked;
        }

        #endregion

        private void xAnnounceRankChanges_CheckedChanged( object sender, EventArgs e ) {
            xAnnounceRankChangeReasons.Enabled = xAnnounceRankChanges.Checked;
        }

        #endregion


        #region Ranks

        private BindingList<string> _rankNameList;

        private void SelectRank( Rank rank ) {
            if( rank == null ) {
                if( vRanks.SelectedIndex != -1 ) {
                    vRanks.ClearSelected();
                    return;
                }
                DisableRankOptions();
                return;
            }
            if( vRanks.SelectedIndex != rank.Index ) {
                vRanks.SelectedIndex = rank.Index;
                return;
            }
            _selectedRank = rank;
            tRankName.Text = rank.Name;

            ApplyColor( bColorRank, Color.ParseToIndex( rank.Color ) );

            tPrefix.Text = rank.Prefix;

            foreach( var box in _permissionLimitBoxes.Values ) {
                box.SelectRank( rank );
            }

            xReserveSlot.Checked = rank.ReservedSlot;
            xKickIdle.Checked = rank.IdleKickTimer > 0;
            nKickIdle.Value = rank.IdleKickTimer;
            nKickIdle.Enabled = xKickIdle.Checked;
            xAntiGrief.Checked = (rank.AntiGriefBlocks > 0 && rank.AntiGriefSeconds > 0);
            nAntiGriefBlocks.Value = rank.AntiGriefBlocks;
            nAntiGriefBlocks.Enabled = xAntiGrief.Checked;
            nAntiGriefSeconds.Value = rank.AntiGriefSeconds;
            nAntiGriefSeconds.Enabled = xAntiGrief.Checked;
            xDrawLimit.Checked = (rank.DrawLimit > 0);
            nDrawLimit.Value = rank.DrawLimit;
            nCopyPasteSlots.Value = rank.CopySlots;
            nFillLimit.Value = rank.FillLimit;
            xAllowSecurityCircumvention.Checked = rank.AllowSecurityCircumvention;

            foreach( ListViewItem item in vPermissions.Items )
            {
                item.Checked = rank.Permissions[item.Index];
                item.Font = item.Checked ? _bold : vPermissions.Font;
            }

            foreach( ListViewItem item in vPermissions.Items ) {
                CheckPermissionConsistency( (Permission)item.Tag, item.Checked );
            }

            xDrawLimit.Enabled = rank.Can( Permission.Draw ) || rank.Can( Permission.CopyAndPaste );
            nDrawLimit.Enabled = xDrawLimit.Checked;
            xAllowSecurityCircumvention.Enabled = rank.Can( Permission.ManageWorlds ) || rank.Can( Permission.ManageZones );

            gRankOptions.Enabled = true;
            lPermissions.Enabled = true;
            vPermissions.Enabled = true;

            bDeleteRank.Enabled = true;
            bRaiseRank.Enabled = (_selectedRank != RankManager.HighestRank);
            bLowerRank.Enabled = (_selectedRank != RankManager.LowestRank);
        }


        private void RebuildRankList() {
            vRanks.Items.Clear();
            foreach( Rank rank in RankManager.Ranks ) {
                vRanks.Items.Add( ToComboBoxOption( rank ) );
            }

            FillRankList( cDefaultRank, "(lowest rank)" );
            cDefaultRank.SelectedIndex = RankManager.GetIndex( RankManager.DefaultRank );
            FillRankList( cDefaultBuildRank, "(default rank)" );
            cDefaultBuildRank.SelectedIndex = RankManager.GetIndex( RankManager.DefaultBuildRank );
            FillRankList( cPatrolledRank, "(default rank)" );
            cPatrolledRank.SelectedIndex = RankManager.GetIndex( RankManager.PatrolledRank );
            FillRankList( cBlockDBAutoEnableRank, "(default rank)" );
            cBlockDBAutoEnableRank.SelectedIndex = RankManager.GetIndex( RankManager.BlockDBAutoEnableRank );

            if( _selectedRank != null ) {
                vRanks.SelectedIndex = _selectedRank.Index;
            }
            SelectRank( _selectedRank );

            foreach( var box in _permissionLimitBoxes.Values ) {
                box.RebuildList();
                box.SelectRank( _selectedRank );
            }
        }


        private void DisableRankOptions() {
            _selectedRank = null;
            bDeleteRank.Enabled = false;
            bRaiseRank.Enabled = false;
            bLowerRank.Enabled = false;
            tRankName.Text = "";
            bColorRank.Text = "";
            tPrefix.Text = "";

            foreach( var box in _permissionLimitBoxes.Values ) {
                box.SelectRank( null );
            }

            xReserveSlot.Checked = false;
            xKickIdle.Checked = false;
            nKickIdle.Value = 0;
            xAntiGrief.Checked = false;
            nAntiGriefBlocks.Value = 0;
            xDrawLimit.Checked = false;
            nDrawLimit.Value = 0;
            xAllowSecurityCircumvention.Checked = false;
            nCopyPasteSlots.Value = 0;
            nFillLimit.Value = 32;
            foreach( ListViewItem item in vPermissions.Items ) {
                item.Checked = false;
                item.Font = vPermissions.Font;
            }
            gRankOptions.Enabled = false;
            lPermissions.Enabled = false;
            vPermissions.Enabled = false;
        }


        private static void FillRankList( [NotNull] ComboBox box, string firstItem ) {
            if( box == null ) throw new ArgumentNullException( nameof(box) );
            box.Items.Clear();
            box.Items.Add( firstItem );
            foreach( Rank rank in RankManager.Ranks ) {
                box.Items.Add( ToComboBoxOption(rank) );
            }
        }


        #region Ranks Input Handlers

        private void bAddRank_Click( object sender, EventArgs e ) {
            int number = 1;
            while( RankManager.RanksByName.ContainsKey( "rank" + number ) ) number++;

            Rank rank = new Rank( "rank" + number, RankManager.GenerateID() );

            RankManager.AddRank( rank );
            _selectedRank = null;

            RebuildRankList();
            SelectRank( rank );

            _rankNameList.Insert( rank.Index + 1, ToComboBoxOption(rank) );
        }

        private void bDeleteRank_Click( object sender, EventArgs e ) {
            if (vRanks.SelectedItem == null) return;
            _selectedRank = null;
            int index = vRanks.SelectedIndex;
            Rank deletedRank = RankManager.FindRank( index );
            if( deletedRank == null ) return;

            string messages = "";

            // Ask for substitute rank
            DeleteRankPopup popup = new DeleteRankPopup( deletedRank );
            if( popup.ShowDialog() != DialogResult.OK ) return;

            Rank replacementRank = popup.SubstituteRank;

            // Update default rank
            if( RankManager.DefaultRank == deletedRank ) {
                RankManager.DefaultRank = replacementRank;
                messages += "DefaultRank has been changed to \"" + replacementRank.Name + "\"" + Environment.NewLine;
            }

            // Update default build rank
            if( RankManager.DefaultBuildRank == deletedRank ) {
                RankManager.DefaultBuildRank = replacementRank;
                messages += "DefaultBuildRank has been changed to \"" + replacementRank.Name + "\"" + Environment.NewLine;
            }

            // Update patrolled rank
            if( RankManager.PatrolledRank == deletedRank ) {
                RankManager.PatrolledRank = replacementRank;
                messages += "PatrolledRank has been changed to \"" + replacementRank.Name + "\"" + Environment.NewLine;
            }

            // Update patrolled rank
            if( RankManager.BlockDBAutoEnableRank == deletedRank ) {
                RankManager.BlockDBAutoEnableRank = replacementRank;
                messages += "BlockDBAutoEnableRank has been changed to \"" + replacementRank.Name + "\"" + Environment.NewLine;
            }

            // Delete rank
            if( RankManager.DeleteRank( deletedRank, replacementRank ) ) {
                messages += "Some of the rank limits for kick, ban, promote, and/or demote have been reset." + Environment.NewLine;
            }
            vRanks.Items.RemoveAt( index );

            // Update world permissions
            string worldUpdates = "";
            foreach( WorldListEntry world in Worlds ) {
                if( world.AccessPermission == ToComboBoxOption(deletedRank) ) {
                    world.AccessPermission = ToComboBoxOption(replacementRank);
                    worldUpdates += " - " + world.Name + ": access permission changed to " + replacementRank.Name + Environment.NewLine;
                }
                if( world.BuildPermission == ToComboBoxOption(deletedRank) ) {
                    world.BuildPermission = ToComboBoxOption(replacementRank);
                    worldUpdates += " - " + world.Name + ": build permission changed to " + replacementRank.Name + Environment.NewLine;
                }
            }

            _rankNameList.RemoveAt( index + 1 );

            if( worldUpdates.Length > 0 ) {
                messages += "The following worlds were affected:" + Environment.NewLine + worldUpdates;
            }

            if( messages.Length > 0 ) {
                MessageBox.Show( messages, "Warning" );
            }

            RebuildRankList();

            if( index < vRanks.Items.Count ) {
                vRanks.SelectedIndex = index;
            }
        }


        private void tPrefix_Validating( object sender, CancelEventArgs e ) {
            if( _selectedRank == null ) return;
            tPrefix.Text = tPrefix.Text.Trim();
            if( tPrefix.Text.Length > 0 && !Rank.IsValidPrefix( tPrefix.Text ) ) {
                MessageBox.Show( "Invalid prefix character!\n" +
                    "Prefixes may only contain characters that are allowed in chat (except space).", "Warning" );
                tPrefix.ForeColor = System.Drawing.Color.Red;
                e.Cancel = true;
            } else {
                tPrefix.ForeColor = SystemColors.ControlText;
            }
            if( _selectedRank.Prefix == tPrefix.Text ) return;

            string oldName = ToComboBoxOption(_selectedRank);

            // To avoid DataErrors in World tab's DataGridView while renaming a rank,
            // the new name is first added to the list of options (without removing the old name)
            _rankNameList.Insert( _selectedRank.Index + 1, $"{tPrefix.Text,1}{_selectedRank.Name}");

            _selectedRank.Prefix = tPrefix.Text;

            // Remove the old name from the list of options
            _rankNameList.Remove( oldName );

            Worlds.ResetBindings();
            RebuildRankList();
        }

        private void xReserveSlot_CheckedChanged( object sender, EventArgs e ) {
            if( _selectedRank == null ) return;
            _selectedRank.ReservedSlot = xReserveSlot.Checked;
        }

        private void nKickIdle_ValueChanged( object sender, EventArgs e ) {
            if( _selectedRank == null || !xKickIdle.Checked ) return;
            _selectedRank.IdleKickTimer = Convert.ToInt32( nKickIdle.Value );
        }

        private void nAntiGriefBlocks_ValueChanged( object sender, EventArgs e ) {
            if( _selectedRank == null || !xAntiGrief.Checked ) return;
            _selectedRank.AntiGriefBlocks = Convert.ToInt32( nAntiGriefBlocks.Value );
        }

        private void nAntiGriefSeconds_ValueChanged( object sender, EventArgs e ) {
            if( _selectedRank == null || !xAntiGrief.Checked ) return;
            _selectedRank.AntiGriefSeconds = Convert.ToInt32( nAntiGriefSeconds.Value );
        }

        private void nDrawLimit_ValueChanged( object sender, EventArgs e ) {
            if( _selectedRank == null || !xDrawLimit.Checked ) return;
            _selectedRank.DrawLimit = Convert.ToInt32( nDrawLimit.Value );
            double cubed = Math.Pow( Convert.ToDouble( nDrawLimit.Value ), 1 / 3d );
            lDrawLimitUnits.Text = $"blocks ({cubed:0}\u00B3)";
        }

        private void nCopyPasteSlots_ValueChanged( object sender, EventArgs e ) {
            if( _selectedRank == null ) return;
            _selectedRank.CopySlots = Convert.ToInt32( nCopyPasteSlots.Value );
        }

        private void xAllowSecurityCircumvention_CheckedChanged( object sender, EventArgs e ) {
            if( _selectedRank == null ) return;
            _selectedRank.AllowSecurityCircumvention = xAllowSecurityCircumvention.Checked;
        }


        private void xSpamChatKick_CheckedChanged( object sender, EventArgs e ) {
            nAntispamMaxWarnings.Enabled = xAntispamKicks.Checked;
        }

        private void vRanks_SelectedIndexChanged( object sender, EventArgs e ) {
            if( vRanks.SelectedIndex != -1 ) {
                SelectRank( RankManager.FindRank( vRanks.SelectedIndex ) );
            } else {
                DisableRankOptions();
            }
        }

        private void xKickIdle_CheckedChanged( object sender, EventArgs e ) {
            if( _selectedRank == null ) return;
            if( xKickIdle.Checked ) {
                nKickIdle.Value = _selectedRank.IdleKickTimer;
            } else {
                nKickIdle.Value = 0;
                _selectedRank.IdleKickTimer = 0;
            }
            nKickIdle.Enabled = xKickIdle.Checked;
        }

        private void xAntiGrief_CheckedChanged( object sender, EventArgs e ) {
            if( _selectedRank == null ) return;
            if( xAntiGrief.Checked ) {
                nAntiGriefBlocks.Value = _selectedRank.AntiGriefBlocks;
                nAntiGriefSeconds.Value = _selectedRank.AntiGriefSeconds;
            } else {
                nAntiGriefBlocks.Value = 0;
                _selectedRank.AntiGriefBlocks = 0;
                nAntiGriefSeconds.Value = 0;
                _selectedRank.AntiGriefSeconds = 0;
            }
            nAntiGriefBlocks.Enabled = xAntiGrief.Checked;
            nAntiGriefSeconds.Enabled = xAntiGrief.Checked;
        }

        private void xDrawLimit_CheckedChanged( object sender, EventArgs e ) {
            if( _selectedRank == null ) return;
            if( xDrawLimit.Checked ) {
                nDrawLimit.Value = _selectedRank.DrawLimit;
                double cubed = Math.Pow( Convert.ToDouble( nDrawLimit.Value ), 1 / 3d );
                lDrawLimitUnits.Text = $"blocks ({cubed:0}\u00B3)";
            } else {
                nDrawLimit.Value = 0;
                _selectedRank.DrawLimit = 0;
                lDrawLimitUnits.Text = "blocks";
            }
            nDrawLimit.Enabled = xDrawLimit.Checked;
        }

        private void vPermissions_ItemChecked( object sender, ItemCheckedEventArgs e ) {
            bool check = e.Item.Checked;
            e.Item.Font = check ? _bold : vPermissions.Font;
            if( _selectedRank == null ) return;

            Permission permission = (Permission)e.Item.Tag;
            CheckPermissionConsistency( permission, check );

            _selectedRank.Permissions[(int)e.Item.Tag] = e.Item.Checked;
        }

        private void CheckPermissionConsistency( Permission permission, bool check ) {
            switch( permission ) {
                case Permission.Chat:
                    if( !check ) {
                        vPermissions.Items[(int)Permission.Say].Checked = false;
                        vPermissions.Items[(int)Permission.Say].ForeColor = SystemColors.GrayText;
                        vPermissions.Items[(int)Permission.UseColorCodes].Checked = false;
                        vPermissions.Items[(int)Permission.UseColorCodes].ForeColor = SystemColors.GrayText;
                    } else {
                        vPermissions.Items[(int)Permission.Say].ForeColor = SystemColors.ControlText;
                        vPermissions.Items[(int)Permission.UseColorCodes].ForeColor = SystemColors.ControlText;
                    }
                    break;

                case Permission.Say:
                    if( check ) vPermissions.Items[(int)Permission.Chat].Checked = true;
                    break;

                case Permission.UseColorCodes:
                    if( check ) vPermissions.Items[(int)Permission.Chat].Checked = true;
                    break;

                case Permission.Ban:
                    if( !check ) {
                        vPermissions.Items[(int)Permission.BanIP].Checked = false;
                        vPermissions.Items[(int)Permission.BanIP].ForeColor = SystemColors.GrayText;
                        vPermissions.Items[(int)Permission.BanAll].Checked = false;
                        vPermissions.Items[(int)Permission.BanAll].ForeColor = SystemColors.GrayText;
                    } else {
                        vPermissions.Items[(int)Permission.BanIP].ForeColor = SystemColors.ControlText;
                        vPermissions.Items[(int)Permission.BanAll].ForeColor = SystemColors.ControlText;
                    }
                    break;

                case Permission.BanIP:
                    if( check ) {
                        vPermissions.Items[(int)Permission.Ban].Checked = true;
                        vPermissions.Items[(int)Permission.BanAll].ForeColor = SystemColors.ControlText;
                    } else {
                        vPermissions.Items[(int)Permission.BanAll].Checked = false;
                        vPermissions.Items[(int)Permission.BanAll].ForeColor = SystemColors.GrayText;
                    }
                    break;

                case Permission.BanAll:
                    if( check ) {
                        vPermissions.Items[(int)Permission.Ban].Checked = true;
                        vPermissions.Items[(int)Permission.BanIP].Checked = true;
                    }
                    break;

                case Permission.Draw:
                    xDrawLimit.Enabled = vPermissions.Items[(int)Permission.Draw].Checked ||
                                         vPermissions.Items[(int)Permission.CopyAndPaste].Checked;
                    if( check ) {
                        vPermissions.Items[(int)Permission.DrawAdvanced].ForeColor = SystemColors.ControlText;
                        vPermissions.Items[(int)Permission.CopyAndPaste].ForeColor = SystemColors.ControlText;
                    } else {
                        vPermissions.Items[(int)Permission.DrawAdvanced].Checked = false;
                        vPermissions.Items[(int)Permission.DrawAdvanced].ForeColor = SystemColors.GrayText;
                        vPermissions.Items[(int)Permission.CopyAndPaste].Checked = false;
                        vPermissions.Items[(int)Permission.CopyAndPaste].ForeColor = SystemColors.GrayText;
                    }
                    break;

                case Permission.DrawAdvanced:
                    lFillLimit.Enabled = check;
                    lFillLimitUnits.Enabled = check;
                    nFillLimit.Enabled = check;
                    break;

                case Permission.CopyAndPaste:
                    xDrawLimit.Enabled = vPermissions.Items[(int)Permission.Draw].Checked ||
                                         vPermissions.Items[(int)Permission.CopyAndPaste].Checked;
                    lCopyPasteSlots.Enabled = check;
                    nCopyPasteSlots.Enabled = check;
                    break;

                case Permission.ManageWorlds:
                case Permission.ManageZones:
                    xAllowSecurityCircumvention.Enabled = vPermissions.Items[(int)Permission.ManageWorlds].Checked ||
                                                          vPermissions.Items[(int)Permission.ManageZones].Checked;
                    break;

                case Permission.Teleport:
                    if( !check ) {
                        vPermissions.Items[(int)Permission.Patrol].Checked = false;
                        vPermissions.Items[(int)Permission.Patrol].ForeColor = SystemColors.GrayText;
                    } else {
                        vPermissions.Items[(int)Permission.Patrol].ForeColor = SystemColors.ControlText;
                    }
                    break;

                case Permission.Patrol:
                    if( check ) vPermissions.Items[(int)Permission.Teleport].Checked = true;
                    break;

                case Permission.Delete:
                    if( !check ) {
                        vPermissions.Items[(int)Permission.DeleteAdmincrete].Checked = false;
                        vPermissions.Items[(int)Permission.DeleteAdmincrete].ForeColor = SystemColors.GrayText;
                    } else {
                        vPermissions.Items[(int)Permission.DeleteAdmincrete].ForeColor = SystemColors.ControlText;
                    }
                    break;

                case Permission.DeleteAdmincrete:
                    if( check ) vPermissions.Items[(int)Permission.Delete].Checked = true;
                    break;

                case Permission.Build:
                    if( !check ) {
                        vPermissions.Items[(int)Permission.PlaceAdmincrete].Checked = false;
                        vPermissions.Items[(int)Permission.PlaceAdmincrete].ForeColor = SystemColors.GrayText;
                        vPermissions.Items[(int)Permission.PlaceGrass].Checked = false;
                        vPermissions.Items[(int)Permission.PlaceGrass].ForeColor = SystemColors.GrayText;
                        vPermissions.Items[(int)Permission.PlaceLava].Checked = false;
                        vPermissions.Items[(int)Permission.PlaceLava].ForeColor = SystemColors.GrayText;
                        vPermissions.Items[(int)Permission.PlaceWater].Checked = false;
                        vPermissions.Items[(int)Permission.PlaceWater].ForeColor = SystemColors.GrayText;
                    } else {
                        vPermissions.Items[(int)Permission.PlaceAdmincrete].ForeColor = SystemColors.ControlText;
                        vPermissions.Items[(int)Permission.PlaceGrass].ForeColor = SystemColors.ControlText;
                        vPermissions.Items[(int)Permission.PlaceLava].ForeColor = SystemColors.ControlText;
                        vPermissions.Items[(int)Permission.PlaceWater].ForeColor = SystemColors.ControlText;
                    }
                    break;

                case Permission.PlaceAdmincrete:
                case Permission.PlaceGrass:
                case Permission.PlaceLava:
                case Permission.PlaceWater:
                    if( check ) vPermissions.Items[(int)Permission.Build].Checked = true;
                    break;

                case Permission.Bring:
                    if( !check ) {
                        vPermissions.Items[(int)Permission.BringAll].Checked = false;
                        vPermissions.Items[(int)Permission.BringAll].ForeColor = SystemColors.GrayText;
                    } else {
                        vPermissions.Items[(int)Permission.BringAll].ForeColor = SystemColors.ControlText;
                    }
                    break;

                case Permission.BringAll:
                    if( check ) vPermissions.Items[(int)Permission.Bring].Checked = true;
                    break;

            }

            if( _permissionLimitBoxes.ContainsKey( permission ) ) {
                _permissionLimitBoxes[permission].PermissionToggled( check );
            }
        }

        private void tRankName_Validating( object sender, CancelEventArgs e ) {
            tRankName.ForeColor = SystemColors.ControlText;
            if( _selectedRank == null ) return;

            string newName = tRankName.Text.Trim();

            if( newName == _selectedRank.Name ) {
                return;

            }

            if( newName.Length == 0 ) {
                MessageBox.Show( "Rank name cannot be blank." );
                tRankName.ForeColor = System.Drawing.Color.Red;
                e.Cancel = true;

            } else if( !Rank.IsValidRankName( newName ) ) {
                MessageBox.Show( "Rank name can only contain letters, digits, and underscores." );
                tRankName.ForeColor = System.Drawing.Color.Red;
                e.Cancel = true;

            } else if( !RankManager.CanRenameRank( _selectedRank, newName ) ) {
                MessageBox.Show( "There is already another rank named \"" + newName + "\".\n" +
                                 "Duplicate rank names are not allowed." );
                tRankName.ForeColor = System.Drawing.Color.Red;
                e.Cancel = true;

            } else {
                string oldName = ToComboBoxOption(_selectedRank);

                // To avoid DataErrors in World tab's DataGridView while renaming a rank,
                // the new name is first added to the list of options (without removing the old name)
                _rankNameList.Insert( _selectedRank.Index + 1, $"{_selectedRank.Prefix,1}{newName}");

                RankManager.RenameRank( _selectedRank, newName );

                // Remove the old name from the list of options
                _rankNameList.Remove( oldName );

                Worlds.ResetBindings();
                RebuildRankList();
            }
        }


        private void bRaiseRank_Click( object sender, EventArgs e ) {
            if( _selectedRank == null ) return;
            if( RankManager.RaiseRank( _selectedRank ) ) {
                RebuildRankList();
                _rankNameList.Insert( _selectedRank.Index + 1, ToComboBoxOption(_selectedRank) );
                _rankNameList.RemoveAt( _selectedRank.Index + 3 );
            }
        }

        private void bLowerRank_Click( object sender, EventArgs e ) {
            if( _selectedRank == null ) return;
            if (!RankManager.LowerRank(_selectedRank)) return;
            RebuildRankList();
            _rankNameList.Insert( _selectedRank.Index + 2, ToComboBoxOption(_selectedRank) );
            _rankNameList.RemoveAt( _selectedRank.Index );
        }

        #endregion

        #endregion


        #region Apply / Save / Cancel Buttons

        private void bApply_Click( object sender, EventArgs e ) {
            SaveEverything();
        }

        private void bSave_Click( object sender, EventArgs e ) {
            SaveEverything();
            Application.Exit();
        }

        private void SaveEverything() {
            using( LogRecorder applyLogger = new LogRecorder() ) {
                SaveConfig();
                if( applyLogger.HasMessages ) {
                    MessageBox.Show( applyLogger.MessageString, "Some problems were encountered with the selected values." );
                    return;
                }
            }
            using( LogRecorder saveLogger = new LogRecorder() ) {
                if( Config.Save() ) {
                    bApply.Enabled = false;
                }
                if( saveLogger.HasMessages ) {
                    MessageBox.Show( saveLogger.MessageString, "Some problems were encountered while saving." );
                }
            }
        }

        private void bCancel_Click( object sender, EventArgs e ) {
            Application.Exit();
        }

        #endregion


        #region Reset

        private void bResetAll_Click( object sender, EventArgs e ) {
            if( MessageBox.Show( "Are you sure you want to reset everything to defaults?", "Warning",
                                 MessageBoxButtons.OKCancel ) != DialogResult.OK ) return;
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

        private void bResetTab_Click( object sender, EventArgs e ) {
            if( MessageBox.Show( "Are you sure you want to reset this tab to defaults?", "Warning",
                                 MessageBoxButtons.OKCancel ) != DialogResult.OK ) return;
            switch( tabs.SelectedIndex ) {
                case 0:// General
                    Config.LoadDefaults( ConfigSection.General );
                    ApplyTabGeneral();
                    break;
                case 1: // Chat
                    Config.LoadDefaults( ConfigSection.Chat );
                    ApplyTabChat();
                    break;
                case 2:// Worlds
                    Config.LoadDefaults( ConfigSection.Worlds );
                    ApplyTabWorlds(); // also reloads world list
                    break;
                case 3:// Ranks
                    Config.ResetRanks();
                    ApplyTabWorlds();
                    ApplyTabRanks();
                    RebuildRankList();
                    break;
                case 4:// Security
                    Config.LoadDefaults( ConfigSection.Security );
                    ApplyTabSecurity();
                    break;
                case 5:// Saving and Backup
                    Config.LoadDefaults( ConfigSection.SavingAndBackup );
                    ApplyTabSavingAndBackup();
                    break;
                case 6:// Logging
                    Config.LoadDefaults( ConfigSection.Logging );
                    Config.ResetLogOptions();
                    ApplyTabLogging();
                    break;
                case 7:// IRC
                    Config.LoadDefaults( ConfigSection.IRC );
                    ApplyTabIRC();
                    break;
                case 8:// Advanced
                    Config.LoadDefaults( ConfigSection.Logging );
                    ApplyTabAdvanced();
                    break;
            }
        }

        #endregion


        #region Utils

        #region Change Detection

        private void SomethingChanged( object sender, EventArgs args ) {
            bApply.Enabled = true;
        }


        private void AddChangeHandler( Control c, EventHandler handler )
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
                    ((ListView)c).ItemChecked += ( o, e ) => handler( o, e );
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

            foreach( Control child in c.Controls ) {
                AddChangeHandler( child, handler );
            }
        }

        #endregion


        #region Colors

        private int _colorSys, _colorSay, _colorHelp, _colorAnnouncement, _colorPm, _colorIrc, _colorMe, _colorWarning, _colorCustom, _colorGlobal;

        private void ApplyColor( Button button, int color ) {
            button.Text = Color.GetName( color );
            button.BackColor = ColorPicker.ColorPairs[color].Background;
            button.ForeColor = ColorPicker.ColorPairs[color].Foreground;
            bApply.Enabled = true;
        }

        private void bColorSys_Click( object sender, EventArgs e ) {
            ColorPicker picker = new ColorPicker( "System message color", _colorSys );
            picker.ShowDialog();
            _colorSys = picker.ColorIndex;
            ApplyColor( bColorSys, _colorSys );
            Color.Sys = Color.Parse( _colorSys );
        }

        private void bColorHelp_Click( object sender, EventArgs e ) {
            ColorPicker picker = new ColorPicker( "Help message color", _colorHelp );
            picker.ShowDialog();
            _colorHelp = picker.ColorIndex;
            ApplyColor( bColorHelp, _colorHelp );
            Color.Help = Color.Parse( _colorHelp );
        }

        private void bColorSay_Click( object sender, EventArgs e ) {
            ColorPicker picker = new ColorPicker( "/Say message color", _colorSay );
            picker.ShowDialog();
            _colorSay = picker.ColorIndex;
            ApplyColor( bColorSay, _colorSay );
            Color.Say = Color.Parse( _colorSay );
        }

        private void bColorAnnouncement_Click( object sender, EventArgs e ) {
            ColorPicker picker = new ColorPicker( "Announcement color", _colorAnnouncement );
            picker.ShowDialog();
            _colorAnnouncement = picker.ColorIndex;
            ApplyColor( bColorAnnouncement, _colorAnnouncement );
            Color.Announcement = Color.Parse( _colorAnnouncement );
        }

        private void bColorPM_Click( object sender, EventArgs e ) {
            ColorPicker picker = new ColorPicker( "Private / rank chat color", _colorPm );
            picker.ShowDialog();
            _colorPm = picker.ColorIndex;
            ApplyColor( bColorPM, _colorPm );
            Color.PM = Color.Parse( _colorPm );
        }

        private void bColorWarning_Click( object sender, EventArgs e ) {
            ColorPicker picker = new ColorPicker( "Warning / Error message color", _colorWarning );
            picker.ShowDialog();
            _colorWarning = picker.ColorIndex;
            ApplyColor( bColorWarning, _colorWarning );
            Color.Warning = Color.Parse( _colorWarning );
        }

        private void bColorMe_Click( object sender, EventArgs e ) {
            ColorPicker picker = new ColorPicker( "/Me command color", _colorMe );
            picker.ShowDialog();
            _colorMe = picker.ColorIndex;
            ApplyColor( bColorMe, _colorMe );
            Color.Me = Color.Parse( _colorMe );
        }

        private void bColorIRC_Click( object sender, EventArgs e ) {
            ColorPicker picker = new ColorPicker( "IRC message color", _colorIrc );
            picker.ShowDialog();
            _colorIrc = picker.ColorIndex;
            ApplyColor( bColorIRC, _colorIrc );
            Color.IRC = Color.Parse( _colorIrc );
        }

        private void bColorGlobal_Click(object sender, EventArgs e)
        {
            ColorPicker picker = new ColorPicker("Global message color", _colorGlobal);
            picker.ShowDialog();
            _colorGlobal = picker.ColorIndex;
            ApplyColor(bColorGlobal, _colorGlobal);
            Color.Global = Color.Parse(_colorGlobal);
        }

        private void bColorRank_Click( object sender, EventArgs e ) {
            ColorPicker picker = new ColorPicker( "Rank color for \"" + _selectedRank.Name + "\"", Color.ParseToIndex( _selectedRank.Color ) );
            picker.ShowDialog();
            ApplyColor( bColorRank, picker.ColorIndex );
            _selectedRank.Color = Color.Parse( picker.ColorIndex ) ?? throw new InvalidOperationException();
        }


        private void HandleTabChatChange( object sender, EventArgs args ) {
            UpdateChatPreview();
        }

        [SuppressMessage("ReSharper", "UseStringInterpolation")]
        private void UpdateChatPreview() {
            List<string> lines = new List<string>();
            if( xShowConnectionMessages.Checked ) {
                lines.Add( string.Format( "&SPlayer {0}{1}LeChosenOne&S connected, joined {2}{3}main",
                                          xRankColorsInChat.Checked ? RankManager.HighestRank.Color : "",
                                          xRankPrefixesInChat.Checked ? RankManager.HighestRank.Prefix : "",
                                          xRankColorsInWorldNames.Checked ? RankManager.LowestRank.Color : "",
                                          xRankPrefixesInChat.Checked ? RankManager.LowestRank.Prefix : "" ) );
            }
            lines.Add( "&R<*- This is an announcement -*>" );
            lines.Add( "&YThis is a /say announcement" );
            lines.Add( string.Format( "{0}{1}LeChosenOne&F: This is a normal chat message",
                                      xRankColorsInChat.Checked ? RankManager.HighestRank.Color : "",
                                      xRankPrefixesInChat.Checked ? RankManager.HighestRank.Prefix : "" ) );
            lines.Add( "&Pfrom Dingus: This is a private message /whisper" );
            lines.Add( "&M*LeChosenOne is using /Me to write this" );
            if( xShowJoinedWorldMessages.Checked ) {
                Rank midRank = RankManager.LowestRank;
                if( RankManager.LowestRank.NextRankUp != null ) {
                    midRank = RankManager.LowestRank.NextRankUp;
                }

                lines.Add( string.Format( "&SPlayer {0}{1}Dingus&S joined {2}{3}SomeOtherMap",
                                          xRankColorsInChat.Checked ? RankManager.HighestRank.Color : "",
                                          xRankPrefixesInChat.Checked ? RankManager.HighestRank.Prefix : "",
                                          xRankColorsInWorldNames.Checked ? midRank.Color : "",
                                          xRankPrefixesInChat.Checked ? midRank.Prefix : "" ) );
            }
            lines.Add( "&SUnknown command \"kikc\", see &H/Commands" );
            if( xAnnounceKickAndBanReasons.Checked ) {
                lines.Add( string.Format( "&W{0}{1}LeChosenOne&W was kicked by {0}{1}Dingus&W: Reason goes here",
                                          xRankColorsInChat.Checked ? RankManager.HighestRank.Color : "",
                                          xRankPrefixesInChat.Checked ? RankManager.HighestRank.Prefix : "" ) );
            } else {
                lines.Add( string.Format( "&W{0}{1}LeChosenOne&W was kicked by {0}{1}gamer1",
                                          xRankColorsInChat.Checked ? RankManager.HighestRank.Color : "",
                                          xRankPrefixesInChat.Checked ? RankManager.HighestRank.Prefix : "" ) );
            }

            if( xShowConnectionMessages.Checked ) {
                lines.Add( string.Format( "&S{0}{1}Dingus&S left the server.",
                                          xRankColorsInChat.Checked ? RankManager.HighestRank.Color : "",
                                          xRankPrefixesInChat.Checked ? RankManager.HighestRank.Prefix : "" ) );
            }

            chatPreview.SetText( lines.ToArray() );
        }

        #endregion


        private void bRules_Click( object sender, EventArgs e ) {
            TextEditorPopup popup = new TextEditorPopup( Paths.RulesFileName, "Use common sense!" );
            popup.ShowDialog();
        }


        internal static bool IsWorldNameTaken( string name ) {
            return Worlds.Any( world => world.Name.Equals( name, StringComparison.OrdinalIgnoreCase ) );
        }


        private void CheckMaxPlayersPerWorldValue() {
            if( nMaxPlayersPerWorld.Value > nMaxPlayers.Value ) {
                nMaxPlayersPerWorld.Value = nMaxPlayers.Value;
            }
            nMaxPlayersPerWorld.Maximum = Math.Min( 128, nMaxPlayers.Value );
        }


        internal static void HandleWorldRename( string from, string to ) {
            if( _instance.cMainWorld.Items.Count == 0 ) return;
            if( _instance.cMainWorld.SelectedItem == null ) {
                _instance.cMainWorld.SelectedIndex = 0;
            } else {
                string mainWorldName = _instance.cMainWorld.SelectedItem.ToString();
                _instance.FillWorldList();
                _instance.cMainWorld.SelectedItem = mainWorldName == from ? to : mainWorldName;
            }
        }

        #endregion


        private void ConfigUI_FormClosing( object sender, FormClosingEventArgs e ) {
            if( !bApply.Enabled ) return;
            switch( MessageBox.Show( "Would you like to save the changes before exiting?", "Warning", MessageBoxButtons.YesNoCancel ) ) {
                case DialogResult.Yes:
                    SaveEverything();
                    return;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    return;
            }
        }


        private readonly Dictionary<Permission, PermissionLimitBox> _permissionLimitBoxes = new Dictionary<Permission, PermissionLimitBox>();

        private const string DefaultPermissionLimitString = "(own rank)";
        private void FillPermissionLimitBoxes() {

            _permissionLimitBoxes[Permission.Kick] = new PermissionLimitBox( "Kick limit", Permission.Kick, DefaultPermissionLimitString );
            _permissionLimitBoxes[Permission.Ban] = new PermissionLimitBox( "Ban limit", Permission.Ban, DefaultPermissionLimitString );
            _permissionLimitBoxes[Permission.Promote] = new PermissionLimitBox( "Promote limit", Permission.Promote, DefaultPermissionLimitString );
            _permissionLimitBoxes[Permission.Demote] = new PermissionLimitBox( "Demote limit", Permission.Demote, DefaultPermissionLimitString );
            _permissionLimitBoxes[Permission.Hide] = new PermissionLimitBox( "Can hide from", Permission.Hide, DefaultPermissionLimitString );
            _permissionLimitBoxes[Permission.Freeze] = new PermissionLimitBox( "Freeze limit", Permission.Freeze, DefaultPermissionLimitString );
            _permissionLimitBoxes[Permission.Mute] = new PermissionLimitBox( "Mute limit", Permission.Mute, DefaultPermissionLimitString );
            _permissionLimitBoxes[Permission.Bring] = new PermissionLimitBox( "Bring limit", Permission.Bring, DefaultPermissionLimitString );
            _permissionLimitBoxes[Permission.Spectate] = new PermissionLimitBox( "Spectate limit", Permission.Spectate, DefaultPermissionLimitString );
            _permissionLimitBoxes[Permission.UndoOthersActions] = new PermissionLimitBox( "Undo limit", Permission.UndoOthersActions, DefaultPermissionLimitString );
            _permissionLimitBoxes[Permission.Slap] = new PermissionLimitBox("Slap limit", Permission.Slap, DefaultPermissionLimitString);
            _permissionLimitBoxes[Permission.Kill] = new PermissionLimitBox("Kill limit", Permission.Kill, DefaultPermissionLimitString);
            _permissionLimitBoxes[Permission.Possess] = new PermissionLimitBox("Possess limit", Permission.Possess, DefaultPermissionLimitString);
            _permissionLimitBoxes[Permission.Warn] = new PermissionLimitBox("Warn limit", Permission.Warn, DefaultPermissionLimitString);
            _permissionLimitBoxes[Permission.Gtfo] = new PermissionLimitBox("Gtfo limit", Permission.Gtfo, DefaultPermissionLimitString);

            foreach( var box in _permissionLimitBoxes.Values ) {
                permissionLimitBoxContainer.Controls.Add( box );
            }
        }


        private void cDefaultRank_SelectedIndexChanged( object sender, EventArgs e ) {
            RankManager.DefaultRank = RankManager.FindRank( cDefaultRank.SelectedIndex - 1 );
        }

        private void cDefaultBuildRank_SelectedIndexChanged( object sender, EventArgs e ) {
            RankManager.DefaultBuildRank = RankManager.FindRank( cDefaultBuildRank.SelectedIndex - 1 );
        }

        private void cPatrolledRank_SelectedIndexChanged( object sender, EventArgs e ) {
            RankManager.PatrolledRank = RankManager.FindRank( cPatrolledRank.SelectedIndex - 1 );
        }

        private void cBlockDBAutoEnableRank_SelectedIndexChanged( object sender, EventArgs e ) {
            RankManager.BlockDBAutoEnableRank = RankManager.FindRank( cBlockDBAutoEnableRank.SelectedIndex - 1 );
        }

        private void xBlockDBEnabled_CheckedChanged( object sender, EventArgs e ) {
            xBlockDBAutoEnable.Enabled = xBlockDBEnabled.Checked;
            cBlockDBAutoEnableRank.Enabled = xBlockDBEnabled.Checked && xBlockDBAutoEnable.Checked;
        }

        private void xBlockDBAutoEnable_CheckedChanged( object sender, EventArgs e ) {
            cBlockDBAutoEnableRank.Enabled = xBlockDBEnabled.Checked && xBlockDBAutoEnable.Checked;
        }

        private void nFillLimit_ValueChanged( object sender, EventArgs e ) {
            if( _selectedRank == null ) return;
            _selectedRank.FillLimit = Convert.ToInt32( nFillLimit.Value );
        }


        public static bool UsePrefixes;


        public static string ToComboBoxOption( Rank rank)
        {
            return UsePrefixes ? $"{rank.Prefix,1}{rank.Name}" : rank.Name;
        }

        private void xRankPrefixesInChat_CheckedChanged( object sender, EventArgs e ) {
            UsePrefixes = xRankPrefixesInChat.Checked;
            tPrefix.Enabled = UsePrefixes;
            lPrefix.Enabled = UsePrefixes;
            RebuildRankList();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorPicker picker = new ColorPicker("Custom Chat command color", _colorCustom);
            picker.ShowDialog();
            _colorCustom = picker.ColorIndex;
            ApplyColor(CustomColor, _colorCustom);
            Color.Custom = Color.Parse(_colorCustom);
        }


        private void SwearEditor_Click(object sender, EventArgs e)
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

        private void ReqsEditor_Click(object sender, EventArgs e)
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

        private void websiteURL_TextChanged(object sender, EventArgs e)
        {
            websiteURL.Text = websiteURL.Text.Trim();
        }

        private void bWeb_Click(object sender, EventArgs e)
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

        private void bWiki_Click(object sender, EventArgs e)
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


        private void bReadme_Click(object sender, EventArgs e)
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

        private void bChangelog_Click(object sender, EventArgs e)
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

        private void bUpdate_Click(object sender, EventArgs e)
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
                            catch(Exception ex)
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

        private void xChanPass_CheckedChanged(object sender, EventArgs e)
        {
            if (xChanPass.Checked)
            {
                tChanPass.Enabled = true;
            }
            else
            {
                tChanPass.Enabled = false;
                tChanPass.Text = "password";
            }
        }

        private void xServPass_CheckedChanged(object sender, EventArgs e)
        {
            if (xServPass.Checked)
            {
                tServPass.Enabled = true;
            }
            else
            {
                tServPass.Enabled = false;
                tServPass.Text = "defaultPass";
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void HeartBeatUrlComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}