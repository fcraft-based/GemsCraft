// Copyright 2009-2012 Matvei Stefarov <me@matvei.org>

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using GemsCraft.Configuration;
using GemsCraft.fSystem;
using GemsCraft.Players;
using GemsCraft.Plugins;
using GemsCraft.Utils;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace GemsCraft.Display.ConfigGUI.GUI.BasicConfig
{
    // This section handles transfer of settings from Config to the specific UI controls, and vice versa.
    // Effectively, it's an adapter between Config's and ConfigUI's representations of the settings
    partial class MainForm
    {
        #region Loading & Applying Config

        void LoadConfig()
        {
            string missingFileMsg = null;
            if (!File.Exists(Paths.WorldListFileName) && !File.Exists(Paths.ConfigFileName))
            {
                missingFileMsg =
                    $"Configuration ({Paths.ConfigFileName}) and world list ({Paths.WorldListFileName}) were not found. Using defaults.";
            }
            else if (!File.Exists(Paths.ConfigFileName))
            {
                missingFileMsg = $"Configuration ({Paths.ConfigFileName}) was not found. Using defaults.";
            }
            else if (!File.Exists(Paths.WorldListFileName))
            {
                missingFileMsg = $"World list ({Paths.WorldListFileName}) was not found. Assuming 0 worlds.";
            }
            if (missingFileMsg != null)
            {
                MessageBox.Show(missingFileMsg);
            }

            using (LogRecorder loadLogger = new LogRecorder())
            {
                if (Config.Load(false, false))
                {
                    if (loadLogger.HasMessages)
                    {
                        MessageBox.Show(loadLogger.MessageString, "Config loading warnings");
                    }
                }
                else
                {
                    MessageBox.Show(loadLogger.MessageString, "Error occured while trying to load config");
                }
            }

            ApplyTabGeneral();
            ApplyTabChat();
            ApplyTabWorlds(); // also reloads world list
            ApplyTabRanks();
            ApplyTabSecurity();
            ApplyTabSavingAndBackup();
            ApplyTabLogging();
            ApplyTabIRC();
            ApplyTabAdvanced();
            ApplyTabCpe();
            ApplyTabPlugins();

            AddChangeHandler(tabs, SomethingChanged);
            AddChangeHandler(bResetTab, SomethingChanged);
            AddChangeHandler(bResetAll, SomethingChanged);
            dgvWorlds.CellValueChanged += delegate
            {
                SomethingChanged(null, null);
            };

            AddChangeHandler(tabChat, HandleTabChatChange);
            bApply.Enabled = false;
        }


        void LoadWorldList()
        {
            if (MainForm.Worlds.Count > 0) MainForm.Worlds.Clear();
            if (!File.Exists(Paths.WorldListFileName)) return;

            try
            {
                XDocument doc = XDocument.Load(Paths.WorldListFileName);
                XElement root = doc.Root;
                if (root == null)
                {
                    MessageBox.Show("Worlds.xml is empty or corrupted.");
                    return;
                }

                string errorLog = "";
                using (LogRecorder logRecorder = new LogRecorder())
                {
                    foreach (XElement el in root.Elements("World"))
                    {
                        try
                        {
                            MainForm.Worlds.Add(new WorldListEntry(el));
                        }
                        catch (Exception ex)
                        {
                            errorLog += ex + Environment.NewLine;
                        }
                    }
                    if (logRecorder.HasMessages)
                    {
                        MessageBox.Show(logRecorder.MessageString, "World list loading warnings.");
                    }
                }
                if (errorLog.Length > 0)
                {
                    MessageBox.Show("Some errors occured while loading the world list:" + Environment.NewLine + errorLog, "Warning");
                }

                FillWorldList();
                XAttribute mainWorldAttr = root.Attribute("main");
                if (mainWorldAttr != null)
                {
                    foreach (WorldListEntry world in MainForm.Worlds)
                    {
                        if (world.Name.ToLower() == mainWorldAttr.Value.ToLower())
                        {
                            cMainWorld.SelectedItem = world.Name;
                            break;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured while loading the world list: " + Environment.NewLine + ex, "Warning");
            }

            MainForm.Worlds.ListChanged += SomethingChanged;
        }


        void ApplyTabGeneral()
        {

            tServerName.Text = ConfigKey.ServerName.GetString();
            CustomName.Text = ConfigKey.CustomChatName.GetString();
            SwearBox.Text = ConfigKey.SwearName.GetString();
            CustomAliases.Text = ConfigKey.CustomAliasName.GetString();
            tMOTD.Text = ConfigKey.MOTD.GetString();
            websiteURL.Text = ConfigKey.WebsiteURL.GetString();

            nMaxPlayers.Value = ConfigKey.MaxPlayers.GetInt();
            CheckMaxPlayersPerWorldValue();
            nMaxPlayersPerWorld.Value = ConfigKey.MaxPlayersPerWorld.GetInt();

            checkUpdate.Checked = ConfigKey.CheckForUpdates.GetString() == "True";



            MainForm.FillRankList(cDefaultRank, "(lowest rank)");
            if (ConfigKey.DefaultRank.IsBlank())
            {
                cDefaultRank.SelectedIndex = 0;
            }
            else
            {
                RankManager.DefaultRank = Rank.Parse(ConfigKey.DefaultRank.GetString());
                cDefaultRank.SelectedIndex = RankManager.GetIndex(RankManager.DefaultRank);
            }

            cPublic.SelectedIndex = ConfigKey.IsPublic.Enabled() ? 0 : 1;
            nPort.Value = ConfigKey.Port.GetInt();
            MaxCapsValue.Value = ConfigKey.MaxCaps.GetInt();
            nUploadBandwidth.Value = ConfigKey.UploadBandwidth.GetInt();

            int interval = 0;
            xAnnouncements.Checked = ConfigKey.AnnouncementInterval.TryGetInt(out interval) && interval > 0;

            nAnnouncements.Value = xAnnouncements.Checked ? ConfigKey.AnnouncementInterval.GetInt() : 1;
            
        }


        void ApplyTabChat()
        {
            xRankColorsInChat.Checked = ConfigKey.RankColorsInChat.Enabled();
            xRankPrefixesInChat.Checked = ConfigKey.RankPrefixesInChat.Enabled();
            xRankPrefixesInList.Checked = ConfigKey.RankPrefixesInList.Enabled();
            xRankColorsInWorldNames.Checked = ConfigKey.RankColorsInWorldNames.Enabled();
            xShowJoinedWorldMessages.Checked = ConfigKey.ShowJoinedWorldMessages.Enabled();
            xShowConnectionMessages.Checked = ConfigKey.ShowConnectionMessages.Enabled();

            colorSys = Color.ParseToIndex(ConfigKey.SystemMessageColor.GetString());
            ApplyColor(bColorSys, colorSys);
            Color.Sys = Color.Parse(colorSys);

            colorCustom = Color.ParseToIndex(ConfigKey.CustomChatColor.GetString());
            ApplyColor(CustomColor, colorCustom);
            Color.Custom = Color.Parse(colorCustom);

            colorHelp = Color.ParseToIndex(ConfigKey.HelpColor.GetString());
            ApplyColor(bColorHelp, colorHelp);
            Color.Help = Color.Parse(colorHelp);

            colorSay = Color.ParseToIndex(ConfigKey.SayColor.GetString());
            ApplyColor(bColorSay, colorSay);
            Color.Say = Color.Parse(colorSay);

            colorAnnouncement = Color.ParseToIndex(ConfigKey.AnnouncementColor.GetString());
            ApplyColor(bColorAnnouncement, colorAnnouncement);
            Color.Announcement = Color.Parse(colorAnnouncement);

            colorPM = Color.ParseToIndex(ConfigKey.PrivateMessageColor.GetString());
            ApplyColor(bColorPM, colorPM);
            Color.PM = Color.Parse(colorPM);

            colorWarning = Color.ParseToIndex(ConfigKey.WarningColor.GetString());
            ApplyColor(bColorWarning, colorWarning);
            Color.Warning = Color.Parse(colorWarning);

            colorMe = Color.ParseToIndex(ConfigKey.MeColor.GetString());
            ApplyColor(bColorMe, colorMe);
            Color.Me = Color.Parse(colorMe);

            colorGlobal = Color.ParseToIndex(ConfigKey.GlobalColor.GetString());
            ApplyColor(bColorGlobal, colorGlobal);
            Color.Global = Color.Parse(colorGlobal);

            UpdateChatPreview();
        }


        void ApplyTabWorlds()
        {
            if (rankNameList == null)
            {
                rankNameList = new BindingList<string> {
                    WorldListEntry.DefaultRankOption
                };
                foreach (Rank rank in RankManager.Ranks)
                {
                    rankNameList.Add(MainForm.ToComboBoxOption(rank));
                }
                dgvcAccess.DataSource = rankNameList;
                dgvcBuild.DataSource = rankNameList;
                dgvcBackup.DataSource = WorldListEntry.BackupEnumNames;

                LoadWorldList();
                dgvWorlds.DataSource = MainForm.Worlds;

            }
            else
            {
                //dgvWorlds.DataSource = null;
                rankNameList.Clear();
                rankNameList.Add(WorldListEntry.DefaultRankOption);
                foreach (Rank rank in RankManager.Ranks)
                {
                    rankNameList.Add(MainForm.ToComboBoxOption(rank));
                }
                foreach (WorldListEntry world in MainForm.Worlds)
                {
                    world.ReparseRanks();
                }
                MainForm.Worlds.ResetBindings();
                //dgvWorlds.DataSource = worlds;
            }

            MainForm.FillRankList(cDefaultBuildRank, "(default rank)");
            if (ConfigKey.DefaultBuildRank.IsBlank())
            {
                cDefaultBuildRank.SelectedIndex = 0;
            }
            else
            {
                RankManager.DefaultBuildRank = Rank.Parse(ConfigKey.DefaultBuildRank.GetString());
                cDefaultBuildRank.SelectedIndex = RankManager.GetIndex(RankManager.DefaultBuildRank);
            }

            if (Paths.IsDefaultMapPath(ConfigKey.MapPath.GetString()))
            {
                tMapPath.Text = Paths.MapPathDefault;
                xMapPath.Checked = false;
            }
            else
            {
                tMapPath.Text = ConfigKey.MapPath.GetString();
                xMapPath.Checked = true;
            }

            xWoMEnableEnvExtensions.Checked = ConfigKey.WoMEnableEnvExtensions.Enabled();
        }


        void ApplyTabRanks()
        {
            selectedRank = null;
            RebuildRankList();
            DisableRankOptions();
        }


        void ApplyTabSecurity()
        {
            ApplyEnum(cVerifyNames, ConfigKey.VerifyNames, NameVerificationMode.Balanced);

            nMaxConnectionsPerIP.Value = ConfigKey.MaxConnectionsPerIP.GetInt();
            xMaxConnectionsPerIP.Checked = (nMaxConnectionsPerIP.Value > 0);
            xAllowUnverifiedLAN.Checked = ConfigKey.AllowUnverifiedLAN.Enabled();

            nAntispamMessageCount.Value = ConfigKey.AntispamMessageCount.GetInt();
            nAntispamInterval.Value = ConfigKey.AntispamInterval.GetInt();
            nSpamMute.Value = ConfigKey.AntispamMuteDuration.GetInt();

            xAntispamKicks.Checked = (ConfigKey.AntispamMaxWarnings.GetInt() > 0);
            nAntispamMaxWarnings.Value = ConfigKey.AntispamMaxWarnings.GetInt();
            if (!xAntispamKicks.Checked) nAntispamMaxWarnings.Enabled = false;

            xRequireKickReason.Checked = ConfigKey.RequireKickReason.Enabled();
            xRequireBanReason.Checked = ConfigKey.RequireBanReason.Enabled();
            xRequireRankChangeReason.Checked = ConfigKey.RequireRankChangeReason.Enabled();
            xAnnounceKickAndBanReasons.Checked = ConfigKey.AnnounceKickAndBanReasons.Enabled();
            xAnnounceRankChanges.Checked = ConfigKey.AnnounceRankChanges.Enabled();
            xAnnounceRankChangeReasons.Checked = ConfigKey.AnnounceRankChangeReasons.Enabled();
            xAnnounceRankChangeReasons.Enabled = xAnnounceRankChanges.Checked;

            MainForm.FillRankList(cPatrolledRank, "(default rank)");
            if (ConfigKey.PatrolledRank.IsBlank())
            {
                cPatrolledRank.SelectedIndex = 0;
            }
            else
            {
                RankManager.PatrolledRank = Rank.Parse(ConfigKey.PatrolledRank.GetString());
                cPatrolledRank.SelectedIndex = RankManager.GetIndex(RankManager.PatrolledRank);
            }


            xBlockDBEnabled.Checked = ConfigKey.BlockDBEnabled.Enabled();
            xBlockDBAutoEnable.Checked = ConfigKey.BlockDBAutoEnable.Enabled();

            MainForm.FillRankList(cBlockDBAutoEnableRank, "(default rank)");
            if (ConfigKey.BlockDBAutoEnableRank.IsBlank())
            {
                cBlockDBAutoEnableRank.SelectedIndex = 0;
            }
            else
            {
                RankManager.BlockDBAutoEnableRank = Rank.Parse(ConfigKey.BlockDBAutoEnableRank.GetString());
                cBlockDBAutoEnableRank.SelectedIndex = RankManager.GetIndex(RankManager.BlockDBAutoEnableRank);
            }
        }


        void ApplyTabSavingAndBackup()
        {
            xSaveInterval.Checked = (ConfigKey.SaveInterval.GetInt() > 0);
            nSaveInterval.Value = ConfigKey.SaveInterval.GetInt();
            if (!xSaveInterval.Checked) nSaveInterval.Enabled = false;

            xBackupOnStartup.Checked = ConfigKey.BackupOnStartup.Enabled();
            xBackupOnJoin.Checked = ConfigKey.BackupOnJoin.Enabled();
            xBackupOnlyWhenChanged.Checked = ConfigKey.BackupOnlyWhenChanged.Enabled();

            xBackupInterval.Checked = (ConfigKey.DefaultBackupInterval.GetInt() > 0);
            nBackupInterval.Value = ConfigKey.DefaultBackupInterval.GetInt();
            if (!xBackupInterval.Checked) nBackupInterval.Enabled = false;

            xMaxBackups.Checked = (ConfigKey.MaxBackups.GetInt() > 0);
            nMaxBackups.Value = ConfigKey.MaxBackups.GetInt();
            if (!xMaxBackups.Checked) nMaxBackups.Enabled = false;

            xMaxBackupSize.Checked = (ConfigKey.MaxBackupSize.GetInt() > 0);
            nMaxBackupSize.Value = ConfigKey.MaxBackupSize.GetInt();
            if (!xMaxBackupSize.Checked) nMaxBackupSize.Enabled = false;

            xBackupDataOnStartup.Checked = ConfigKey.BackupDataOnStartup.Enabled();
        }


        void ApplyTabLogging()
        {
            foreach (ListViewItem item in vConsoleOptions.Items)
            {
                item.Checked = Logger.ConsoleOptions[item.Index];
            }
            foreach (ListViewItem item in vLogFileOptions.Items)
            {
                item.Checked = Logger.LogFileOptions[item.Index];
            }

            ApplyEnum(cLogMode, ConfigKey.LogMode, LogSplittingType.OneFile);

            xLogLimit.Checked = (ConfigKey.MaxLogs.GetInt() > 0);
            nLogLimit.Value = ConfigKey.MaxLogs.GetInt();
            if (!xLogLimit.Checked) nLogLimit.Enabled = false;
        }


        void ApplyTabIRC()
        {
            xIRCBotEnabled.Checked = ConfigKey.IRCBotEnabled.Enabled();
            gIRCNetwork.Enabled = xIRCBotEnabled.Checked;
            gIRCOptions.Enabled = xIRCBotEnabled.Checked;

            tIRCBotNetwork.Text = ConfigKey.IRCBotNetwork.GetString();
            nIRCBotPort.Value = ConfigKey.IRCBotPort.GetInt();
            nIRCDelay.Value = ConfigKey.IRCDelay.GetInt();

            tIRCBotChannels.Text = ConfigKey.IRCBotChannels.GetString();

            tIRCBotNick.Text = ConfigKey.IRCBotNick.GetString();
            xIRCRegisteredNick.Checked = ConfigKey.IRCRegisteredNick.Enabled();

            tIRCNickServ.Text = ConfigKey.IRCNickServ.GetString();
            tIRCNickServMessage.Text = ConfigKey.IRCNickServMessage.GetString();

            xIRCBotAnnounceIRCJoins.Checked = ConfigKey.IRCBotAnnounceIRCJoins.Enabled();
            xIRCBotAnnounceServerJoins.Checked = ConfigKey.IRCBotAnnounceServerJoins.Enabled();
            xIRCBotForwardFromIRC.Checked = ConfigKey.IRCBotForwardFromIRC.Enabled();
            xIRCBotForwardFromServer.Checked = ConfigKey.IRCBotForwardFromServer.Enabled();


            colorIRC = Color.ParseToIndex(ConfigKey.IRCMessageColor.GetString());
            ApplyColor(bColorIRC, colorIRC);
            Color.IRC = Color.Parse(colorIRC);

            xIRCUseColor.Checked = ConfigKey.IRCUseColor.Enabled();
            xIRCBotAnnounceServerEvents.Checked = ConfigKey.IRCBotAnnounceServerEvents.Enabled();

            //if server pass is in use
            if (ConfigKey.IRCBotNetworkPass.GetString() != "defaultPass")
            {
                xServPass.Checked = true;
            }

            //if chan pass is in use
            if (ConfigKey.IRCChannelPassword.GetString() != "password")
            {
                xChanPass.Checked = true;
            }

            tChanPass.Text = ConfigKey.IRCChannelPassword.GetString();
            tServPass.Text = ConfigKey.IRCBotNetworkPass.GetString();
                
        }


        void ApplyTabAdvanced()
        {
            xRelayAllBlockUpdates.Checked = ConfigKey.RelayAllBlockUpdates.Enabled();
            xNoPartialPositionUpdates.Checked = ConfigKey.NoPartialPositionUpdates.Enabled();
            nTickInterval.Value = ConfigKey.TickInterval.GetInt();

            if (ConfigKey.ProcessPriority.IsBlank())
            {
                cProcessPriority.SelectedIndex = 0; // Default
            }
            else
            {
                switch (ConfigKey.ProcessPriority.GetEnum<ProcessPriorityClass>())
                {
                    case ProcessPriorityClass.High:
                        cProcessPriority.SelectedIndex = 1; break;
                    case ProcessPriorityClass.AboveNormal:
                        cProcessPriority.SelectedIndex = 2; break;
                    case ProcessPriorityClass.Normal:
                        cProcessPriority.SelectedIndex = 3; break;
                    case ProcessPriorityClass.BelowNormal:
                        cProcessPriority.SelectedIndex = 4; break;
                    case ProcessPriorityClass.Idle:
                        cProcessPriority.SelectedIndex = 5; break;
                }
            }



            nThrottling.Value = ConfigKey.BlockUpdateThrottling.GetInt();
            xLowLatencyMode.Checked = ConfigKey.LowLatencyMode.Enabled();
            xAutoRank.Checked = ConfigKey.AutoRankEnabled.Enabled();


            if (ConfigKey.MaxUndo.GetInt() > 0)
            {
                xMaxUndo.Checked = true;
                nMaxUndo.Value = ConfigKey.MaxUndo.GetInt();
            }
            else
            {
                xMaxUndo.Checked = false;
                nMaxUndo.Value = (int)ConfigKey.MaxUndo.GetDefault();
            }
            nMaxUndoStates.Value = ConfigKey.MaxUndoStates.GetInt();

            tConsoleName.Text = ConfigKey.ConsoleName.GetString();

            tIP.Text = ConfigKey.IP.GetString();
            xCrash.Checked = ConfigKey.SubmitCrashReports.Enabled();
            if (ConfigKey.IP.IsBlank() || ConfigKey.IP.IsDefault())
            {
                tIP.Enabled = false;
                xIP.Checked = false;
            }
            else
            {
                tIP.Enabled = true;
                xIP.Checked = true;
            }

        }

        private void ApplyTabCpe()
        {
            #region MessageTypes
            chkEnableMessageTypes.Checked = ConfigKey.EnableMessageTypes.Enabled();
            chkShowAnnouncements.Checked = ConfigKey.EnableAnnouncements.Enabled();

            chkStatus1.Checked = ConfigKey.Status1Enabled.Enabled();
            txtStatus1.Text = ConfigKey.Status1.GetString();

            chkStatus2.Checked = ConfigKey.Status2Enabled.Enabled();
            txtStatus2.Text = ConfigKey.Status2.GetString();

            chkStatus3.Checked = ConfigKey.Status3Enabled.Enabled();
            txtStatus3.Text = ConfigKey.Status3.GetString();

            chkBR3.Checked = ConfigKey.BR3Enabled.Enabled();
            txtBR3.Text = ConfigKey.BR3.GetString();

            chkBR2.Checked = ConfigKey.BR2Enabled.Enabled();
            txtBR2.Text = ConfigKey.BR2.GetString();

            chkBR1.Checked = ConfigKey.BR1Enabled.Enabled();
            txtBR1.Text = ConfigKey.BR1.GetString();
            #endregion

            #region ClickDistance

            bool cdEnabled = ConfigKey.ClickDistanceEnabled.Enabled();
            chkEnableClickDistance.Checked = cdEnabled;
            if (cdEnabled)
            {
                numMinDistance.Value =
                    ConfigKey.MinClickDistance.GetInt();
                numMaxDistance.Value =
                    ConfigKey.MaxClickDistance.GetInt();
            }
            else
            {
                numMinDistance.Value = 1;
                numMaxDistance.Value = 5;
            }

            #endregion

            #region HeldBlock

            chkEnableHeldBlock.Checked =
                ConfigKey.EnableHeldBlock.Enabled();

            #endregion
        }

        private void ApplyTabPlugins()
        {
            chkPlugins.Checked = ConfigKey.EnablePlugins.Enabled();
        }

        static void ApplyEnum<TEnum>([NotNull] ComboBox box, ConfigKey key, TEnum def) where TEnum : struct
        {
            if (box == null) throw new ArgumentNullException("box");
            if (!typeof(TEnum).IsEnum) throw new ArgumentException("Enum type required");
            try
            {
                if (key.IsBlank())
                {
                    box.SelectedIndex = (int)(object)def;
                }
                else
                {
                    box.SelectedIndex = (int)Enum.Parse(typeof(TEnum), key.GetString(), true);
                }
            }
            catch (ArgumentException)
            {
                box.SelectedIndex = (int)(object)def;
            }
        }

        #endregion


        #region Saving Config

        void SaveConfig()
        {
            // General

            ConfigKey.ServerName.TrySetValue(tServerName.Text);
            ConfigKey.CustomChatName.TrySetValue(CustomName.Text);
            ConfigKey.SwearName.TrySetValue(SwearBox.Text);
            ConfigKey.CheckForUpdates.TrySetValue(checkUpdate.Checked.ToString());
            ConfigKey.WebsiteURL.TrySetValue(websiteURL.Text);
            ConfigKey.CustomAliasName.TrySetValue(CustomAliases.Text);
            ConfigKey.MOTD.TrySetValue(tMOTD.Text);
            ConfigKey.MaxPlayers.TrySetValue(nMaxPlayers.Value);
            ConfigKey.MaxPlayersPerWorld.TrySetValue(nMaxPlayersPerWorld.Value);
            ConfigKey.DefaultRank.TrySetValue(cDefaultRank.SelectedIndex == 0 ? "" : RankManager.DefaultRank.FullName);
            ConfigKey.IsPublic.TrySetValue(cPublic.SelectedIndex == 0);
            ConfigKey.Port.TrySetValue(nPort.Value);
            ConfigKey.MaxCaps.TrySetValue(MaxCapsValue.Value);
            if (xIP.Checked)
            {
                ConfigKey.IP.TrySetValue(tIP.Text);
            }
            else
            {
                ConfigKey.IP.ResetValue();
            }

            ConfigKey.UploadBandwidth.TrySetValue(nUploadBandwidth.Value);

            ConfigKey.AnnouncementInterval.TrySetValue(xAnnouncements.Checked ? nAnnouncements.Value : 0);
            // Chat
            ConfigKey.SystemMessageColor.TrySetValue(Color.GetName(colorSys));
            ConfigKey.CustomChatColor.TrySetValue(Color.GetName(colorCustom));
            ConfigKey.HelpColor.TrySetValue(Color.GetName(colorHelp));
            ConfigKey.SayColor.TrySetValue(Color.GetName(colorSay));
            ConfigKey.AnnouncementColor.TrySetValue(Color.GetName(colorAnnouncement));
            ConfigKey.PrivateMessageColor.TrySetValue(Color.GetName(colorPM));
            ConfigKey.WarningColor.TrySetValue(Color.GetName(colorWarning));
            ConfigKey.MeColor.TrySetValue(Color.GetName(colorMe));
            ConfigKey.GlobalColor.TrySetValue(Color.GetName(colorGlobal));
            ConfigKey.ShowJoinedWorldMessages.TrySetValue(xShowJoinedWorldMessages.Checked);
            ConfigKey.RankColorsInWorldNames.TrySetValue(xRankColorsInWorldNames.Checked);
            ConfigKey.RankColorsInChat.TrySetValue(xRankColorsInChat.Checked);
            ConfigKey.RankPrefixesInChat.TrySetValue(xRankPrefixesInChat.Checked);
            ConfigKey.RankPrefixesInList.TrySetValue(xRankPrefixesInList.Checked);
            ConfigKey.ShowConnectionMessages.TrySetValue(xShowConnectionMessages.Checked);


            // Worlds
            ConfigKey.DefaultBuildRank.TrySetValue(cDefaultBuildRank.SelectedIndex == 0
                ? ""
                : RankManager.DefaultBuildRank.FullName);

            ConfigKey.MapPath.TrySetValue(xMapPath.Checked ? tMapPath.Text : ConfigKey.MapPath.GetDefault());

            ConfigKey.WoMEnableEnvExtensions.TrySetValue(xWoMEnableEnvExtensions.Checked);


            // Security
            WriteEnum<NameVerificationMode>(cVerifyNames, ConfigKey.VerifyNames);

            ConfigKey.MaxConnectionsPerIP.TrySetValue(xMaxConnectionsPerIP.Checked ? nMaxConnectionsPerIP.Value : 0);
            ConfigKey.AllowUnverifiedLAN.TrySetValue(xAllowUnverifiedLAN.Checked);

            ConfigKey.AntispamMessageCount.TrySetValue(nAntispamMessageCount.Value);
            ConfigKey.AntispamInterval.TrySetValue(nAntispamInterval.Value);
            ConfigKey.AntispamMuteDuration.TrySetValue(nSpamMute.Value);

            ConfigKey.AntispamMaxWarnings.TrySetValue(xAntispamKicks.Checked ? nAntispamMaxWarnings.Value : 0);

            ConfigKey.RequireKickReason.TrySetValue(xRequireKickReason.Checked);
            ConfigKey.RequireBanReason.TrySetValue(xRequireBanReason.Checked);
            ConfigKey.RequireRankChangeReason.TrySetValue(xRequireRankChangeReason.Checked);
            ConfigKey.AnnounceKickAndBanReasons.TrySetValue(xAnnounceKickAndBanReasons.Checked);
            ConfigKey.AnnounceRankChanges.TrySetValue(xAnnounceRankChanges.Checked);
            ConfigKey.AnnounceRankChangeReasons.TrySetValue(xAnnounceRankChangeReasons.Checked);

            ConfigKey.PatrolledRank.TrySetValue(cPatrolledRank.SelectedIndex == 0
                ? ""
                : RankManager.PatrolledRank.FullName);

            ConfigKey.BlockDBEnabled.TrySetValue(xBlockDBEnabled.Checked);
            ConfigKey.BlockDBAutoEnable.TrySetValue(xBlockDBAutoEnable.Checked);
            ConfigKey.BlockDBAutoEnableRank.TrySetValue(cBlockDBAutoEnableRank.SelectedIndex == 0
                ? ""
                : RankManager.BlockDBAutoEnableRank.FullName);


            // Saving & Backups
            ConfigKey.SaveInterval.TrySetValue(xSaveInterval.Checked ? nSaveInterval.Value : 0);
            ConfigKey.BackupOnStartup.TrySetValue(xBackupOnStartup.Checked);
            ConfigKey.BackupOnJoin.TrySetValue(xBackupOnJoin.Checked);
            ConfigKey.BackupOnlyWhenChanged.TrySetValue(xBackupOnlyWhenChanged.Checked);

            ConfigKey.DefaultBackupInterval.TrySetValue(xBackupInterval.Checked ? nBackupInterval.Value : 0);
            ConfigKey.MaxBackups.TrySetValue(xMaxBackups.Checked ? nMaxBackups.Value : 0);
            ConfigKey.MaxBackupSize.TrySetValue(xMaxBackupSize.Checked ? nMaxBackupSize.Value : 0);

            ConfigKey.BackupDataOnStartup.TrySetValue(xBackupDataOnStartup.Checked);


            // Logging
            WriteEnum<LogSplittingType>(cLogMode, ConfigKey.LogMode);
            if (xLogLimit.Checked) ConfigKey.MaxLogs.TrySetValue(nLogLimit.Value);
            else ConfigKey.MaxLogs.TrySetValue("0");
            foreach (ListViewItem item in vConsoleOptions.Items)
            {
                Logger.ConsoleOptions[item.Index] = item.Checked;
            }
            foreach (ListViewItem item in vLogFileOptions.Items)
            {
                Logger.LogFileOptions[item.Index] = item.Checked;
            }


            // IRC
            ConfigKey.IRCBotEnabled.TrySetValue(xIRCBotEnabled.Checked);

            ConfigKey.IRCBotNetwork.TrySetValue(tIRCBotNetwork.Text);
            ConfigKey.IRCBotPort.TrySetValue(nIRCBotPort.Value);
            ConfigKey.IRCDelay.TrySetValue(nIRCDelay.Value);

            ConfigKey.IRCBotChannels.TrySetValue(tIRCBotChannels.Text);

            ConfigKey.IRCBotNick.TrySetValue(tIRCBotNick.Text);
            ConfigKey.IRCRegisteredNick.TrySetValue(xIRCRegisteredNick.Checked);
            ConfigKey.IRCNickServ.TrySetValue(tIRCNickServ.Text);
            ConfigKey.IRCNickServMessage.TrySetValue(tIRCNickServMessage.Text);

            ConfigKey.IRCBotAnnounceIRCJoins.TrySetValue(xIRCBotAnnounceIRCJoins.Checked);
            ConfigKey.IRCBotAnnounceServerJoins.TrySetValue(xIRCBotAnnounceServerJoins.Checked);
            ConfigKey.IRCBotAnnounceServerEvents.TrySetValue(xIRCBotAnnounceServerEvents.Checked);
            ConfigKey.IRCBotForwardFromIRC.TrySetValue(xIRCBotForwardFromIRC.Checked);
            ConfigKey.IRCBotForwardFromServer.TrySetValue(xIRCBotForwardFromServer.Checked);

            ConfigKey.IRCMessageColor.TrySetValue(Color.GetName(colorIRC));
            ConfigKey.IRCUseColor.TrySetValue(xIRCUseColor.Checked);

            ConfigKey.IRCBotNetworkPass.TrySetValue(tServPass.Text);
            ConfigKey.IRCChannelPassword.TrySetValue(tChanPass.Text);


            // advanced

            ConfigKey.SubmitCrashReports.TrySetValue(xCrash.Checked);
            ConfigKey.RelayAllBlockUpdates.TrySetValue(xRelayAllBlockUpdates.Checked);
            ConfigKey.NoPartialPositionUpdates.TrySetValue(xNoPartialPositionUpdates.Checked);
            ConfigKey.TickInterval.TrySetValue(Convert.ToInt32((decimal) nTickInterval.Value));

            switch (cProcessPriority.SelectedIndex)
            {
                case 0:
                    ConfigKey.ProcessPriority.ResetValue(); break;
                case 1:
                    ConfigKey.ProcessPriority.TrySetValue(ProcessPriorityClass.High); break;
                case 2:
                    ConfigKey.ProcessPriority.TrySetValue(ProcessPriorityClass.AboveNormal); break;
                case 3:
                    ConfigKey.ProcessPriority.TrySetValue(ProcessPriorityClass.Normal); break;
                case 4:
                    ConfigKey.ProcessPriority.TrySetValue(ProcessPriorityClass.BelowNormal); break;
                case 5:
                    ConfigKey.ProcessPriority.TrySetValue(ProcessPriorityClass.Idle); break;
            }

            ConfigKey.BlockUpdateThrottling.TrySetValue(Convert.ToInt32((decimal) nThrottling.Value));

            ConfigKey.LowLatencyMode.TrySetValue(xLowLatencyMode.Checked);

            ConfigKey.AutoRankEnabled.TrySetValue(xAutoRank.Checked);

            ConfigKey.MaxUndo.TrySetValue(xMaxUndo.Checked ? Convert.ToInt32((decimal) nMaxUndo.Value) : 0);
            ConfigKey.MaxUndoStates.TrySetValue(Convert.ToInt32((decimal) nMaxUndoStates.Value));

            ConfigKey.ConsoleName.TrySetValue(tConsoleName.Text);


            // CPE
            #region MessageTypes
            ConfigKey.EnableMessageTypes.TrySetValue(chkEnableMessageTypes.Checked);
            ConfigKey.EnableAnnouncements.TrySetValue(chkShowAnnouncements.Checked);

            ConfigKey.Status1Enabled.TrySetValue(chkStatus1.Checked);
            ConfigKey.Status1.TrySetValue(txtStatus1.Text);

            ConfigKey.Status2Enabled.TrySetValue(chkStatus2.Checked);
            ConfigKey.Status2.TrySetValue(txtStatus2.Text);

            ConfigKey.Status3Enabled.TrySetValue(chkStatus3.Checked);
            ConfigKey.Status3.TrySetValue(txtStatus3.Text);

            ConfigKey.BR3Enabled.TrySetValue(chkBR3.Checked);
            ConfigKey.BR3.TrySetValue(txtBR3.Text);

            ConfigKey.BR2Enabled.TrySetValue(chkBR2.Checked);
            ConfigKey.BR2.TrySetValue(txtBR2.Text);

            ConfigKey.BR1Enabled.TrySetValue(chkBR1.Checked);
            ConfigKey.BR1.TrySetValue(txtBR1.Text);

            #endregion

            #region ClickDistance

            bool cdEnabled = chkEnableClickDistance.Checked;
            ConfigKey.ClickDistanceEnabled.TrySetValue(cdEnabled);
            ConfigKey.MinClickDistance.TrySetValue(
                cdEnabled ? numMinDistance.Value : 1);
            ConfigKey.MaxClickDistance.TrySetValue(
                cdEnabled ? numMaxDistance.Value : 5);

            #endregion

            #region HeldBlock

            ConfigKey.EnableHeldBlock.TrySetValue(chkEnableHeldBlock.Checked);

            #endregion

            // Plugins
            ConfigKey.EnablePlugins.SetValue(chkPlugins.Checked);

            for (int x = 0; x <= listPlugins.Items.Count - 1; x++)
            {
                IPlugin plugin = PluginManager.Plugins[x];
                string file = $"plugins/{plugin.Name}.json";
                var writer = File.CreateText(file);
                string json = JsonConvert.SerializeObject(writer, Formatting.Indented);
                writer.Write(json);
                writer.Flush();
                writer.Close();
            }

            // Save those worlds
            SaveWorldList();
        }


        void SaveWorldList()
        {
            const string worldListTempFileName = Paths.WorldListFileName + ".tmp";
            try
            {
                XDocument doc = new XDocument();
                XElement root = new XElement("fCraftWorldList");
                foreach (WorldListEntry world in MainForm.Worlds)
                {
                    root.Add(world.Serialize());
                }
                if (cMainWorld.SelectedItem != null)
                {
                    root.Add(new XAttribute("main", cMainWorld.SelectedItem));
                }
                doc.Add(root);
                doc.Save(worldListTempFileName);
                Paths.MoveOrReplace(worldListTempFileName, Paths.WorldListFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("An error occured while trying to save world list ({0}): {1}{2}",
                                                Paths.WorldListFileName,
                                                Environment.NewLine,
                                                ex));
            }
        }


        static void WriteEnum<TEnum>([NotNull] ComboBox box, ConfigKey key) where TEnum : struct
        {
            if (box == null) throw new ArgumentNullException("box");
            if (!typeof(TEnum).IsEnum) throw new ArgumentException("Enum type required");
            try
            {
                TEnum val = (TEnum)Enum.Parse(typeof(TEnum), box.SelectedIndex.ToString(), true);
                key.TrySetValue(val);
            }
            catch (ArgumentException)
            {
                Logger.Log(LogType.Error,
                            "ConfigUI.WriteEnum<{0}>: Could not parse value for {1}. Using default ({2}).",
                            typeof(TEnum).Name, key, key.GetString());
            }
        }

        #endregion
    }
}
