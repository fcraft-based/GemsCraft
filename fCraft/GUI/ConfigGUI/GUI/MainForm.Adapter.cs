// Copyright 2009-2012 Matvei Stefarov <me@matvei.org>

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using fCraft.fSystem;
using fCraft.Players;
using fCraft.Utils;
using JetBrains.Annotations;

namespace fCraft.GUI.ConfigGUI.GUI
{
    // This section handles transfer of settings from Config to the specific UI controls, and vice versa.
    // Effectively, it's an adapter between Config's and ConfigUI's representations of the settings
    partial class MainForm
    {
        #region Loading & Applying Config

        private void LoadConfig()
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

            AddChangeHandler(SectionClasses.GeneralConfig, SomethingChanged);
            AddChangeHandler(SectionClasses.ChatConfig, SomethingChanged);
            AddChangeHandler(SectionClasses.WorldConfig, SomethingChanged);
            AddChangeHandler(SectionClasses.RankConfig, SomethingChanged);
            AddChangeHandler(SectionClasses.SecurityConfig, SomethingChanged);
            AddChangeHandler(SectionClasses.SavingConfig, SomethingChanged);
            AddChangeHandler(SectionClasses.LoggingConfig, SomethingChanged);
            AddChangeHandler(SectionClasses.IRCConfig, SomethingChanged);
            AddChangeHandler(SectionClasses.AdvancedConfig, SomethingChanged);
            AddChangeHandler(SectionClasses.MiscConfig, SomethingChanged);

            AddChangeHandler(SectionClasses.GeneralConfig.bResetTab, SomethingChanged);
            AddChangeHandler(SectionClasses.WorldConfig.bResetTab, SomethingChanged);
            AddChangeHandler(SectionClasses.RankConfig.bResetTab, SomethingChanged);
            AddChangeHandler(SectionClasses.SecurityConfig.bResetTab, SomethingChanged);
            AddChangeHandler(SectionClasses.SavingConfig.bResetTab, SomethingChanged);
            AddChangeHandler(SectionClasses.LoggingConfig.bResetTab, SomethingChanged);
            AddChangeHandler(SectionClasses.IRCConfig.bResetTab, SomethingChanged);
            AddChangeHandler(SectionClasses.AdvancedConfig.bResetTab, SomethingChanged);
            AddChangeHandler(SectionClasses.MiscConfig.bResetTab, SomethingChanged);

            SectionClasses.GeneralConfig.bResetTab.Click += bResetTab_Click;
            SectionClasses.WorldConfig.bResetTab.Click += bResetTab_Click;
            SectionClasses.RankConfig.bResetTab.Click += bResetTab_Click;
            SectionClasses.SecurityConfig.bResetTab.Click += bResetTab_Click;
            SectionClasses.SavingConfig.bResetTab.Click += bResetTab_Click;
            SectionClasses.LoggingConfig.bResetTab.Click += bResetTab_Click;
            SectionClasses.IRCConfig.bResetTab.Click += bResetTab_Click;
            SectionClasses.AdvancedConfig.bResetTab.Click += bResetTab_Click;
            SectionClasses.MiscConfig.bResetTab.Click += bResetTab_Click;
            AddChangeHandler(bResetAll, SomethingChanged);
            SectionClasses.WorldConfig.dgvWorlds.CellValueChanged += delegate
            {
                SomethingChanged(null, null);
            };

            AddChangeHandler(SectionClasses.ChatConfig, HandleTabChatChange);
            bApply.Enabled = false;
        }


        private void LoadWorldList()
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
                        if (!string.Equals(world.Name, mainWorldAttr.Value, StringComparison.CurrentCultureIgnoreCase)) continue;
                        SectionClasses.WorldConfig.cMainWorld.SelectedItem = world.Name;
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured while loading the world list: " + Environment.NewLine + ex, "Warning");
            }

            MainForm.Worlds.ListChanged += SomethingChanged;
        }


        private void ApplyTabGeneral()
        {

            SectionClasses.GeneralConfig.tServerName.Text = ConfigKey.ServerName.GetString();
            SectionClasses.MiscConfig.CustomName.Text = ConfigKey.CustomChatName.GetString();
            SectionClasses.MiscConfig.SwearBox.Text = ConfigKey.SwearName.GetString();
            SectionClasses.MiscConfig.CustomAliases.Text = ConfigKey.CustomAliasName.GetString();
            SectionClasses.GeneralConfig.tMOTD.Text = ConfigKey.MOTD.GetString();
            SectionClasses.MiscConfig.websiteURL.Text = ConfigKey.WebsiteURL.GetString();

            SectionClasses.GeneralConfig.nMaxPlayers.Value = ConfigKey.MaxPlayers.GetInt();
            MainForm._instance.CheckMaxPlayersPerWorldValue();
            SectionClasses.GeneralConfig.nMaxPlayersPerWorld.Value = ConfigKey.MaxPlayersPerWorld.GetInt();

            SectionClasses.SavingConfig.checkUpdate.Checked = ConfigKey.CheckForUpdates.GetString() == "True";
            MainForm.FillRankList(SectionClasses.GeneralConfig.cDefaultRank, "(lowest rank)");
            if (ConfigKey.DefaultRank.IsBlank())
            {
                SectionClasses.GeneralConfig.cDefaultRank.SelectedIndex = 0;
            }
            else
            {
                RankManager.DefaultRank = Rank.Parse(ConfigKey.DefaultRank.GetString());
                SectionClasses.GeneralConfig.cDefaultRank.SelectedIndex = RankManager.GetIndex(RankManager.DefaultRank);
            }

            SectionClasses.GeneralConfig.cPublic.SelectedIndex = ConfigKey.IsPublic.Enabled() ? 0 : 1;
            SectionClasses.GeneralConfig.nPort.Value = ConfigKey.Port.GetInt();
            SectionClasses.MiscConfig.MaxCapsValue.Value = ConfigKey.MaxCaps.GetInt();
            SectionClasses.GeneralConfig.nUploadBandwidth.Value = ConfigKey.UploadBandwidth.GetInt();

            SectionClasses.GeneralConfig.xAnnouncements.Checked = ConfigKey.AnnouncementInterval.TryGetInt(out var interval) && interval > 0;

            SectionClasses.GeneralConfig.nAnnouncements.Value = SectionClasses.GeneralConfig.
                xAnnouncements.Checked ? ConfigKey.AnnouncementInterval.GetInt() : 1;

            // UpdaterSettingsWindow
            _updaterWindow.BackupBeforeUpdate = ConfigKey.BackupBeforeUpdate.Enabled();
            _updaterWindow.RunBeforeUpdate = ConfigKey.RunBeforeUpdate.GetString();
            _updaterWindow.RunAfterUpdate = ConfigKey.RunAfterUpdate.GetString();
            _updaterWindow.UpdaterMode = ConfigKey.UpdaterMode.GetEnum<UpdaterMode>();
        }


        private void ApplyTabChat()
        {
            SectionClasses.ChatConfig.xRankColorsInChat.Checked = ConfigKey.RankColorsInChat.Enabled();
            SectionClasses.ChatConfig.xRankPrefixesInChat.Checked = ConfigKey.RankPrefixesInChat.Enabled();
            SectionClasses.ChatConfig.xRankPrefixesInList.Checked = ConfigKey.RankPrefixesInList.Enabled();
            SectionClasses.ChatConfig.xRankColorsInWorldNames.Checked = ConfigKey.RankColorsInWorldNames.Enabled();
            SectionClasses.ChatConfig.xShowJoinedWorldMessages.Checked = ConfigKey.ShowJoinedWorldMessages.Enabled();
            SectionClasses.ChatConfig.xShowConnectionMessages.Checked = ConfigKey.ShowConnectionMessages.Enabled();

            _colorSys = Color.ParseToIndex(ConfigKey.SystemMessageColor.GetString());
            ApplyColor(SectionClasses.ChatConfig.bColorSys, _colorSys);
            Color.Sys = Color.Parse((int) _colorSys);

            _colorCustom = Color.ParseToIndex(ConfigKey.CustomChatColor.GetString());
            ApplyColor(SectionClasses.MiscConfig.CustomColor, _colorCustom);
            Color.Custom = Color.Parse((int) _colorCustom);

            _colorHelp = Color.ParseToIndex(ConfigKey.HelpColor.GetString());
            ApplyColor(SectionClasses.ChatConfig.bColorHelp, _colorHelp);
            Color.Help = Color.Parse((int) _colorHelp);

            _colorSay = Color.ParseToIndex(ConfigKey.SayColor.GetString());
            ApplyColor(SectionClasses.ChatConfig.bColorSay, _colorSay);
            Color.Say = Color.Parse((int) _colorSay);

            _colorAnnouncement = Color.ParseToIndex(ConfigKey.AnnouncementColor.GetString());
            ApplyColor(SectionClasses.ChatConfig.bColorAnnouncement, _colorAnnouncement);
            Color.Announcement = Color.Parse((int) _colorAnnouncement);

            _colorPm = Color.ParseToIndex(ConfigKey.PrivateMessageColor.GetString());
            ApplyColor(SectionClasses.ChatConfig.bColorPM, _colorPm);
            Color.PM = Color.Parse((int) _colorPm);

            _colorWarning = Color.ParseToIndex(ConfigKey.WarningColor.GetString());
            ApplyColor(SectionClasses.ChatConfig.bColorWarning, _colorWarning);
            Color.Warning = Color.Parse((int) _colorWarning);

            _colorMe = Color.ParseToIndex(ConfigKey.MeColor.GetString());
            ApplyColor(SectionClasses.ChatConfig.bColorMe, _colorMe);
            Color.Me = Color.Parse((int) _colorMe);

            _colorGlobal = Color.ParseToIndex(ConfigKey.GlobalColor.GetString());
            ApplyColor(SectionClasses.ChatConfig.bColorGlobal, _colorGlobal);
            Color.Global = Color.Parse((int) _colorGlobal);

            UpdateChatPreview();
        }


        private void ApplyTabWorlds()
        {
            if (_rankNameList == null)
            {
                _rankNameList = new BindingList<string> {
                    WorldListEntry.DefaultRankOption
                };
                foreach (Rank rank in RankManager.Ranks)
                {
                    _rankNameList.Add(MainForm.ToComboBoxOption(rank));
                }
                SectionClasses.WorldConfig.dgvcAccess.DataSource = _rankNameList;
                SectionClasses.WorldConfig.dgvcBuild.DataSource = _rankNameList;
                SectionClasses.WorldConfig.dgvcBackup.DataSource = WorldListEntry.BackupEnumNames;

                LoadWorldList();
                SectionClasses.WorldConfig.dgvWorlds.DataSource = MainForm.Worlds;

            }
            else
            {
                //dgvWorlds.DataSource = null;
                _rankNameList.Clear();
                _rankNameList.Add(WorldListEntry.DefaultRankOption);
                foreach (Rank rank in RankManager.Ranks)
                {
                    _rankNameList.Add(MainForm.ToComboBoxOption(rank));
                }
                foreach (WorldListEntry world in MainForm.Worlds)
                {
                    world.ReparseRanks();
                }
                MainForm.Worlds.ResetBindings();
                //dgvWorlds.DataSource = worlds;
            }

            MainForm.FillRankList(SectionClasses.WorldConfig.cDefaultBuildRank, "(default rank)");
            if (ConfigKey.DefaultBuildRank.IsBlank())
            {
                SectionClasses.WorldConfig.cDefaultBuildRank.SelectedIndex = 0;
            }
            else
            {
                RankManager.DefaultBuildRank = Rank.Parse(ConfigKey.DefaultBuildRank.GetString());
                SectionClasses.WorldConfig.cDefaultBuildRank.SelectedIndex = RankManager.GetIndex(RankManager.DefaultBuildRank);
            }

            if (Paths.IsDefaultMapPath(ConfigKey.MapPath.GetString()))
            {
                SectionClasses.WorldConfig.tMapPath.Text = Paths.MapPathDefault;
                SectionClasses.WorldConfig.xMapPath.Checked = false;
            }
            else
            {
                SectionClasses.WorldConfig.tMapPath.Text = ConfigKey.MapPath.GetString();
                SectionClasses.WorldConfig.xMapPath.Checked = true;
            }

            SectionClasses.WorldConfig.xWoMEnableEnvExtensions.Checked = ConfigKey.WoMEnableEnvExtensions.Enabled();
        }


        private void ApplyTabRanks()
        {
            _selectedRank = null;
            RebuildRankList();
            DisableRankOptions();
        }


        private void ApplyTabSecurity()
        {
            ApplyEnum(SectionClasses.SecurityConfig.cVerifyNames, ConfigKey.VerifyNames, NameVerificationMode.Balanced);

            SectionClasses.SecurityConfig.nMaxConnectionsPerIP.Value = ConfigKey.MaxConnectionsPerIP.GetInt();
            SectionClasses.SecurityConfig.xMaxConnectionsPerIP.Checked = 
                (SectionClasses.SecurityConfig.nMaxConnectionsPerIP.Value > 0);
            SectionClasses.SecurityConfig.xAllowUnverifiedLAN.Checked = ConfigKey.AllowUnverifiedLAN.Enabled();

            SectionClasses.SecurityConfig.nAntispamMessageCount.Value = ConfigKey.AntispamMessageCount.GetInt();
            SectionClasses.SecurityConfig.nAntispamInterval.Value = ConfigKey.AntispamInterval.GetInt();
            SectionClasses.SecurityConfig.nSpamMute.Value = ConfigKey.AntispamMuteDuration.GetInt();

            SectionClasses.SecurityConfig.xAntispamKicks.Checked = (ConfigKey.AntispamMaxWarnings.GetInt() > 0);
            SectionClasses.SecurityConfig.nAntispamMaxWarnings.Value = ConfigKey.AntispamMaxWarnings.GetInt();
            if (!SectionClasses.SecurityConfig.xAntispamKicks.Checked) SectionClasses.SecurityConfig.nAntispamMaxWarnings.Enabled = false;

            SectionClasses.SecurityConfig.xRequireKickReason.Checked = ConfigKey.RequireKickReason.Enabled();
            SectionClasses.SecurityConfig.xRequireBanReason.Checked = ConfigKey.RequireBanReason.Enabled();
            SectionClasses.SecurityConfig.xRequireRankChangeReason.Checked = ConfigKey.RequireRankChangeReason.Enabled();
            SectionClasses.SecurityConfig.xAnnounceKickAndBanReasons.Checked = ConfigKey.AnnounceKickAndBanReasons.Enabled();
            SectionClasses.SecurityConfig.xAnnounceRankChanges.Checked = ConfigKey.AnnounceRankChanges.Enabled();
            SectionClasses.SecurityConfig.xAnnounceRankChangeReasons.Checked = ConfigKey.AnnounceRankChangeReasons.Enabled();
            SectionClasses.SecurityConfig.xAnnounceRankChangeReasons.Enabled = SectionClasses.SecurityConfig.xAnnounceRankChanges.Checked;

            MainForm.FillRankList(SectionClasses.SecurityConfig.cPatrolledRank, "(default rank)");
            if (ConfigKey.PatrolledRank.IsBlank())
            {
                SectionClasses.SecurityConfig.cPatrolledRank.SelectedIndex = 0;
            }
            else
            {
                RankManager.PatrolledRank = Rank.Parse(ConfigKey.PatrolledRank.GetString());
                SectionClasses.SecurityConfig.cPatrolledRank.SelectedIndex = RankManager.GetIndex(RankManager.PatrolledRank);
            }


            SectionClasses.SecurityConfig.xBlockDBEnabled.Checked = ConfigKey.BlockDBEnabled.Enabled();
            SectionClasses.SecurityConfig.xBlockDBAutoEnable.Checked = ConfigKey.BlockDBAutoEnable.Enabled();

            MainForm.FillRankList(SectionClasses.SecurityConfig.cBlockDBAutoEnableRank, "(default rank)");
            if (ConfigKey.BlockDBAutoEnableRank.IsBlank())
            {
                SectionClasses.SecurityConfig.cBlockDBAutoEnableRank.SelectedIndex = 0;
            }
            else
            {
                RankManager.BlockDBAutoEnableRank = Rank.Parse(ConfigKey.BlockDBAutoEnableRank.GetString());
                SectionClasses.SecurityConfig.cBlockDBAutoEnableRank.SelectedIndex = RankManager.GetIndex(RankManager.BlockDBAutoEnableRank);
            }
        }


        private void ApplyTabSavingAndBackup()
        {
            SectionClasses.SavingConfig.xSaveInterval.Checked = (ConfigKey.SaveInterval.GetInt() > 0);
            SectionClasses.SavingConfig.nSaveInterval.Value = ConfigKey.SaveInterval.GetInt();
            if (!SectionClasses.SavingConfig.xSaveInterval.Checked) SectionClasses.SavingConfig.nSaveInterval.Enabled = false;

            SectionClasses.SavingConfig.xBackupOnStartup.Checked = ConfigKey.BackupOnStartup.Enabled();
            SectionClasses.SavingConfig.xBackupOnJoin.Checked = ConfigKey.BackupOnJoin.Enabled();
            SectionClasses.SavingConfig.xBackupOnlyWhenChanged.Checked = ConfigKey.BackupOnlyWhenChanged.Enabled();

            SectionClasses.SavingConfig.xBackupInterval.Checked = (ConfigKey.DefaultBackupInterval.GetInt() > 0);
            SectionClasses.SavingConfig.nBackupInterval.Value = ConfigKey.DefaultBackupInterval.GetInt();
            if (!SectionClasses.SavingConfig.xBackupInterval.Checked)
                SectionClasses.SavingConfig.nBackupInterval.Enabled = false;

            SectionClasses.SavingConfig.xMaxBackups.Checked = (ConfigKey.MaxBackups.GetInt() > 0);
            SectionClasses.SavingConfig.nMaxBackups.Value = ConfigKey.MaxBackups.GetInt();
            if (!SectionClasses.SavingConfig.xMaxBackups.Checked)
                SectionClasses.SavingConfig.nMaxBackups.Enabled = false;

            SectionClasses.SavingConfig.xMaxBackupSize.Checked = (ConfigKey.MaxBackupSize.GetInt() > 0);
            SectionClasses.SavingConfig.nMaxBackupSize.Value = ConfigKey.MaxBackupSize.GetInt();
            if (!SectionClasses.SavingConfig.xMaxBackupSize.Checked)
                SectionClasses.SavingConfig.nMaxBackupSize.Enabled = false;

            SectionClasses.SavingConfig.xBackupDataOnStartup.Checked = ConfigKey.BackupDataOnStartup.Enabled();
        }


        private void ApplyTabLogging()
        {
            foreach (ListViewItem item in SectionClasses.LoggingConfig.vConsoleOptions.Items)
            {
                item.Checked = Logger.ConsoleOptions[item.Index];
            }
            foreach (ListViewItem item in SectionClasses.LoggingConfig.vLogFileOptions.Items)
            {
                item.Checked = Logger.LogFileOptions[item.Index];
            }

            ApplyEnum(SectionClasses.LoggingConfig.cLogMode, ConfigKey.LogMode, LogSplittingType.OneFile);

            SectionClasses.LoggingConfig.xLogLimit.Checked = (ConfigKey.MaxLogs.GetInt() > 0);
            SectionClasses.LoggingConfig.nLogLimit.Value = ConfigKey.MaxLogs.GetInt();
            if (!SectionClasses.LoggingConfig.xLogLimit.Checked)
                SectionClasses.LoggingConfig.nLogLimit.Enabled = false;
        }


        // ReSharper disable once InconsistentNaming
        private void ApplyTabIRC()
        {
            SectionClasses.IRCConfig.xIRCBotEnabled.Checked = ConfigKey.IRCBotEnabled.Enabled();
            SectionClasses.IRCConfig.gIRCNetwork.Enabled = SectionClasses.IRCConfig.xIRCBotEnabled.Checked;
            SectionClasses.IRCConfig.gIRCOptions.Enabled = SectionClasses.IRCConfig.xIRCBotEnabled.Checked;

            SectionClasses.IRCConfig.tIRCBotNetwork.Text = ConfigKey.IRCBotNetwork.GetString();
            SectionClasses.IRCConfig.nIRCBotPort.Value = ConfigKey.IRCBotPort.GetInt();
            SectionClasses.IRCConfig.nIRCDelay.Value = ConfigKey.IRCDelay.GetInt();

            SectionClasses.IRCConfig.tIRCBotChannels.Text = ConfigKey.IRCBotChannels.GetString();

            SectionClasses.IRCConfig.tIRCBotNick.Text = ConfigKey.IRCBotNick.GetString();
            SectionClasses.IRCConfig.xIRCRegisteredNick.Checked = ConfigKey.IRCRegisteredNick.Enabled();

            SectionClasses.IRCConfig.tIRCNickServ.Text = ConfigKey.IRCNickServ.GetString();
            SectionClasses.IRCConfig.tIRCNickServMessage.Text = ConfigKey.IRCNickServMessage.GetString();

            SectionClasses.IRCConfig.xIRCBotAnnounceIRCJoins.Checked = ConfigKey.IRCBotAnnounceIRCJoins.Enabled();
            SectionClasses.IRCConfig.xIRCBotAnnounceServerJoins.Checked = ConfigKey.IRCBotAnnounceServerJoins.Enabled();
            SectionClasses.IRCConfig.xIRCBotForwardFromIRC.Checked = ConfigKey.IRCBotForwardFromIRC.Enabled();
            SectionClasses.IRCConfig.xIRCBotForwardFromServer.Checked = ConfigKey.IRCBotForwardFromServer.Enabled();


            _colorIrc = Color.ParseToIndex(ConfigKey.IRCMessageColor.GetString());
            ApplyColor(SectionClasses.IRCConfig.bColorIRC, _colorIrc);
            Color.IRC = Color.Parse((int) _colorIrc);

            SectionClasses.IRCConfig.xIRCUseColor.Checked = ConfigKey.IRCUseColor.Enabled();
            SectionClasses.IRCConfig.xIRCBotAnnounceServerEvents.Checked = ConfigKey.IRCBotAnnounceServerEvents.Enabled();

            //if server pass is in use
            if (ConfigKey.IRCBotNetworkPass.GetString() != "defaultPass")
            {
                SectionClasses.IRCConfig.xServPass.Checked = true;
            }

            //if chan pass is in use
            if (ConfigKey.IRCChannelPassword.GetString() != "password")
            {
                SectionClasses.IRCConfig.xChanPass.Checked = true;
            }

            SectionClasses.IRCConfig.tChanPass.Text = ConfigKey.IRCChannelPassword.GetString();
            SectionClasses.IRCConfig.tServPass.Text = ConfigKey.IRCBotNetworkPass.GetString();

        }


        private void ApplyTabAdvanced()
        {
            SectionClasses.AdvancedConfig.xRelayAllBlockUpdates.Checked = ConfigKey.RelayAllBlockUpdates.Enabled();
            SectionClasses.AdvancedConfig.xNoPartialPositionUpdates.Checked = ConfigKey.NoPartialPositionUpdates.Enabled();
            SectionClasses.AdvancedConfig.nTickInterval.Value = ConfigKey.TickInterval.GetInt();

            if (ConfigKey.ProcessPriority.IsBlank())
            {
                SectionClasses.AdvancedConfig.cProcessPriority.SelectedIndex = 0; // Default
            }
            else
            {
                if (ConfigKey.ProcessPriority.GetEnum<ProcessPriorityClass>() == ProcessPriorityClass.High)
                    SectionClasses.AdvancedConfig.cProcessPriority.SelectedIndex = 1;
                else if (ConfigKey.ProcessPriority.GetEnum<ProcessPriorityClass>() == ProcessPriorityClass.AboveNormal)
                    SectionClasses.AdvancedConfig.cProcessPriority.SelectedIndex = 2;
                else if (ConfigKey.ProcessPriority.GetEnum<ProcessPriorityClass>() == ProcessPriorityClass.Normal)
                    SectionClasses.AdvancedConfig.cProcessPriority.SelectedIndex = 3;
                else if (ConfigKey.ProcessPriority.GetEnum<ProcessPriorityClass>() == ProcessPriorityClass.BelowNormal)
                    SectionClasses.AdvancedConfig.cProcessPriority.SelectedIndex = 4;
                else if (ConfigKey.ProcessPriority.GetEnum<ProcessPriorityClass>() == ProcessPriorityClass.Idle)
                    SectionClasses.AdvancedConfig.cProcessPriority.SelectedIndex = 5;
            }



            SectionClasses.AdvancedConfig.nThrottling.Value = ConfigKey.BlockUpdateThrottling.GetInt();
            SectionClasses.AdvancedConfig.xLowLatencyMode.Checked = ConfigKey.LowLatencyMode.Enabled();
            SectionClasses.AdvancedConfig.xAutoRank.Checked = ConfigKey.AutoRankEnabled.Enabled();


            if (ConfigKey.MaxUndo.GetInt() > 0)
            {
                SectionClasses.AdvancedConfig.xMaxUndo.Checked = true;
                SectionClasses.AdvancedConfig.nMaxUndo.Value = ConfigKey.MaxUndo.GetInt();
            }
            else
            {
                SectionClasses.AdvancedConfig.xMaxUndo.Checked = false;
                SectionClasses.AdvancedConfig.nMaxUndo.Value = (int)ConfigKey.MaxUndo.GetDefault();
            }
            SectionClasses.AdvancedConfig.nMaxUndoStates.Value = ConfigKey.MaxUndoStates.GetInt();

            SectionClasses.AdvancedConfig.tConsoleName.Text = ConfigKey.ConsoleName.GetString();

            SectionClasses.AdvancedConfig.tIP.Text = ConfigKey.IP.GetString();
            SectionClasses.AdvancedConfig.xCrash.Checked = ConfigKey.SubmitCrashReports.Enabled();
            if (ConfigKey.IP.IsBlank() || ConfigKey.IP.IsDefault())
            {
                SectionClasses.AdvancedConfig.tIP.Enabled = false;
                SectionClasses.AdvancedConfig.xIP.Checked = false;
            }
            else
            {
                SectionClasses.AdvancedConfig.tIP.Enabled = true;
                SectionClasses.AdvancedConfig.xIP.Checked = true;
            }

        }


        private static void ApplyEnum<TEnum>([NotNull] ListControl box, ConfigKey key, TEnum def) where TEnum : struct
        {
            if (box == null) throw new ArgumentNullException(nameof(box));
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

        private void SaveConfig()
        {
            // General

            ConfigKey.ServerName.TrySetValue(SectionClasses.GeneralConfig.tServerName.Text);
            ConfigKey.CustomChatName.TrySetValue(SectionClasses.MiscConfig.CustomName.Text);
            ConfigKey.SwearName.TrySetValue(SectionClasses.MiscConfig.SwearBox.Text);
            ConfigKey.CheckForUpdates.TrySetValue(SectionClasses.SavingConfig.checkUpdate.Checked.ToString());
            ConfigKey.WebsiteURL.TrySetValue(SectionClasses.MiscConfig.websiteURL.Text);
            ConfigKey.CustomAliasName.TrySetValue(SectionClasses.MiscConfig.CustomAliases.Text);
            ConfigKey.MOTD.TrySetValue(SectionClasses.GeneralConfig.tMOTD.Text);
            ConfigKey.MaxPlayers.TrySetValue(SectionClasses.GeneralConfig.nMaxPlayers.Value);
            ConfigKey.MaxPlayersPerWorld.TrySetValue(SectionClasses.GeneralConfig.nMaxPlayersPerWorld.Value);
            ConfigKey.DefaultRank.TrySetValue(SectionClasses.GeneralConfig.cDefaultRank.SelectedIndex == 0 
                ? "" : RankManager.DefaultRank.FullName);
            ConfigKey.IsPublic.TrySetValue(SectionClasses.GeneralConfig.cPublic.SelectedIndex == 0);
            ConfigKey.Port.TrySetValue(SectionClasses.GeneralConfig.nPort.Value);
            ConfigKey.MaxCaps.TrySetValue(SectionClasses.MiscConfig.MaxCapsValue.Value);
            if (SectionClasses.AdvancedConfig.xIP.Checked)
            {
                ConfigKey.IP.TrySetValue(SectionClasses.AdvancedConfig.tIP.Text);
            }
            else
            {
                ConfigKey.IP.ResetValue();
            }

            ConfigKey.UploadBandwidth.TrySetValue(SectionClasses.GeneralConfig.nUploadBandwidth.Value);

            ConfigKey.AnnouncementInterval.TrySetValue(
                SectionClasses.GeneralConfig.xAnnouncements.Checked 
                    ? SectionClasses.GeneralConfig.nAnnouncements.Value : 0);

            // UpdaterSettingsWindow
            ConfigKey.UpdaterMode.TrySetValue(_updaterWindow.UpdaterMode);
            ConfigKey.BackupBeforeUpdate.TrySetValue(_updaterWindow.BackupBeforeUpdate);
            ConfigKey.RunBeforeUpdate.TrySetValue(_updaterWindow.RunBeforeUpdate);
            ConfigKey.RunAfterUpdate.TrySetValue(_updaterWindow.RunAfterUpdate);


            // Chat
            ConfigKey.SystemMessageColor.TrySetValue(Color.GetName((int) _colorSys));
            ConfigKey.CustomChatColor.TrySetValue(Color.GetName((int) _colorCustom));
            ConfigKey.HelpColor.TrySetValue(Color.GetName((int) _colorHelp));
            ConfigKey.SayColor.TrySetValue(Color.GetName((int) _colorSay));
            ConfigKey.AnnouncementColor.TrySetValue(Color.GetName((int) _colorAnnouncement));
            ConfigKey.PrivateMessageColor.TrySetValue(Color.GetName((int) _colorPm));
            ConfigKey.WarningColor.TrySetValue(Color.GetName((int) _colorWarning));
            ConfigKey.MeColor.TrySetValue(Color.GetName((int) _colorMe));
            ConfigKey.GlobalColor.TrySetValue(Color.GetName((int) _colorGlobal));
            ConfigKey.ShowJoinedWorldMessages.TrySetValue(SectionClasses.ChatConfig.xShowJoinedWorldMessages.Checked);
            ConfigKey.RankColorsInWorldNames.TrySetValue(SectionClasses.ChatConfig.xRankColorsInWorldNames.Checked);
            ConfigKey.RankColorsInChat.TrySetValue(SectionClasses.ChatConfig.xRankColorsInChat.Checked);
            ConfigKey.RankPrefixesInChat.TrySetValue(SectionClasses.ChatConfig.xRankPrefixesInChat.Checked);
            ConfigKey.RankPrefixesInList.TrySetValue(SectionClasses.ChatConfig.xRankPrefixesInList.Checked);
            ConfigKey.ShowConnectionMessages.TrySetValue(SectionClasses.ChatConfig.xShowConnectionMessages.Checked);


            // Worlds
            ConfigKey.DefaultBuildRank.TrySetValue(SectionClasses.WorldConfig.cDefaultBuildRank.SelectedIndex == 0
                ? ""
                : RankManager.DefaultBuildRank.FullName);

            ConfigKey.MapPath.TrySetValue(SectionClasses.WorldConfig.xMapPath.Checked 
                ? SectionClasses.WorldConfig.tMapPath.Text : ConfigKey.MapPath.GetDefault());

            ConfigKey.WoMEnableEnvExtensions.TrySetValue(SectionClasses.WorldConfig.xWoMEnableEnvExtensions.Checked);


            // Security
            WriteEnum<NameVerificationMode>(SectionClasses.SecurityConfig.cVerifyNames, ConfigKey.VerifyNames);

            ConfigKey.MaxConnectionsPerIP.TrySetValue(
                SectionClasses.SecurityConfig.xMaxConnectionsPerIP.Checked 
                ? SectionClasses.SecurityConfig.nMaxConnectionsPerIP.Value : 0);
            ConfigKey.AllowUnverifiedLAN.TrySetValue(SectionClasses.SecurityConfig.xAllowUnverifiedLAN.Checked);

            ConfigKey.AntispamMessageCount.TrySetValue(SectionClasses.SecurityConfig.nAntispamMessageCount.Value);
            ConfigKey.AntispamInterval.TrySetValue(SectionClasses.SecurityConfig.nAntispamInterval.Value);
            ConfigKey.AntispamMuteDuration.TrySetValue(SectionClasses.SecurityConfig.nSpamMute.Value);

            ConfigKey.AntispamMaxWarnings.TrySetValue(
                SectionClasses.SecurityConfig.xAntispamKicks.Checked 
                    ? SectionClasses.SecurityConfig.nAntispamMaxWarnings.Value : 0);

            ConfigKey.RequireKickReason.TrySetValue(SectionClasses.SecurityConfig.xRequireKickReason.Checked);
            ConfigKey.RequireBanReason.TrySetValue(SectionClasses.SecurityConfig.xRequireBanReason.Checked);
            ConfigKey.RequireRankChangeReason.TrySetValue(SectionClasses.SecurityConfig.xRequireRankChangeReason.Checked);
            ConfigKey.AnnounceKickAndBanReasons.TrySetValue(SectionClasses.SecurityConfig.xAnnounceKickAndBanReasons.Checked);
            ConfigKey.AnnounceRankChanges.TrySetValue(SectionClasses.SecurityConfig.xAnnounceRankChanges.Checked);
            ConfigKey.AnnounceRankChangeReasons.TrySetValue(SectionClasses.SecurityConfig.xAnnounceRankChangeReasons.Checked);

            ConfigKey.PatrolledRank.TrySetValue(SectionClasses.SecurityConfig.cPatrolledRank.SelectedIndex == 0
                ? ""
                : RankManager.PatrolledRank.FullName);

            ConfigKey.BlockDBEnabled.TrySetValue(SectionClasses.SecurityConfig.xBlockDBEnabled.Checked);
            ConfigKey.BlockDBAutoEnable.TrySetValue(SectionClasses.SecurityConfig.xBlockDBAutoEnable.Checked);
            ConfigKey.BlockDBAutoEnableRank.TrySetValue(SectionClasses.SecurityConfig.cBlockDBAutoEnableRank.SelectedIndex == 0
                ? ""
                : RankManager.BlockDBAutoEnableRank.FullName);


            // Saving & Backups
            ConfigKey.SaveInterval.TrySetValue(
                SectionClasses.SavingConfig.xSaveInterval.Checked 
                    ? SectionClasses.SavingConfig.nSaveInterval.Value : 0);
            ConfigKey.BackupOnStartup.TrySetValue(SectionClasses.SavingConfig.xBackupOnStartup.Checked);
            ConfigKey.BackupOnJoin.TrySetValue(SectionClasses.SavingConfig.xBackupOnJoin.Checked);
            ConfigKey.BackupOnlyWhenChanged.TrySetValue(SectionClasses.SavingConfig.xBackupOnlyWhenChanged.Checked);

            ConfigKey.DefaultBackupInterval.TrySetValue(
                SectionClasses.SavingConfig.xBackupInterval.Checked 
                    ? SectionClasses.SavingConfig.nBackupInterval.Value : 0);
            ConfigKey.MaxBackups.TrySetValue(
                SectionClasses.SavingConfig.xMaxBackups.Checked 
                    ? SectionClasses.SavingConfig.nMaxBackups.Value : 0);
            ConfigKey.MaxBackupSize.TrySetValue(
                SectionClasses.SavingConfig.xMaxBackupSize.Checked 
                    ? SectionClasses.SavingConfig.nMaxBackupSize.Value : 0);

            ConfigKey.BackupDataOnStartup.TrySetValue(SectionClasses.SavingConfig.xBackupDataOnStartup.Checked);


            // Logging
            WriteEnum<LogSplittingType>(SectionClasses.LoggingConfig.cLogMode, ConfigKey.LogMode);
            if (SectionClasses.LoggingConfig.xLogLimit.Checked)
                ConfigKey.MaxLogs.TrySetValue(SectionClasses.LoggingConfig.nLogLimit.Value);
            else ConfigKey.MaxLogs.TrySetValue("0");
            foreach (ListViewItem item in SectionClasses.LoggingConfig.vConsoleOptions.Items)
            {
                Logger.ConsoleOptions[item.Index] = item.Checked;
            }
            foreach (ListViewItem item in SectionClasses.LoggingConfig.vLogFileOptions.Items)
            {
                Logger.LogFileOptions[item.Index] = item.Checked;
            }


            // IRC
            ConfigKey.IRCBotEnabled.TrySetValue(SectionClasses.IRCConfig.xIRCBotEnabled.Checked);

            ConfigKey.IRCBotNetwork.TrySetValue(SectionClasses.IRCConfig.tIRCBotNetwork.Text);
            ConfigKey.IRCBotPort.TrySetValue(SectionClasses.IRCConfig.nIRCBotPort.Value);
            ConfigKey.IRCDelay.TrySetValue(SectionClasses.IRCConfig.nIRCDelay.Value);

            ConfigKey.IRCBotChannels.TrySetValue(SectionClasses.IRCConfig.tIRCBotChannels.Text);

            ConfigKey.IRCBotNick.TrySetValue(SectionClasses.IRCConfig.tIRCBotNick.Text);
            ConfigKey.IRCRegisteredNick.TrySetValue(SectionClasses.IRCConfig.xIRCRegisteredNick.Checked);
            ConfigKey.IRCNickServ.TrySetValue(SectionClasses.IRCConfig.tIRCNickServ.Text);
            ConfigKey.IRCNickServMessage.TrySetValue(SectionClasses.IRCConfig.tIRCNickServMessage.Text);

            ConfigKey.IRCBotAnnounceIRCJoins.TrySetValue(SectionClasses.IRCConfig.xIRCBotAnnounceIRCJoins.Checked);
            ConfigKey.IRCBotAnnounceServerJoins.TrySetValue(SectionClasses.IRCConfig.xIRCBotAnnounceServerJoins.Checked);
            ConfigKey.IRCBotAnnounceServerEvents.TrySetValue(SectionClasses.IRCConfig.xIRCBotAnnounceServerEvents.Checked);
            ConfigKey.IRCBotForwardFromIRC.TrySetValue(SectionClasses.IRCConfig.xIRCBotForwardFromIRC.Checked);
            ConfigKey.IRCBotForwardFromServer.TrySetValue(SectionClasses.IRCConfig.xIRCBotForwardFromServer.Checked);

            ConfigKey.IRCMessageColor.TrySetValue(Color.GetName((int) _colorIrc));
            ConfigKey.IRCUseColor.TrySetValue(SectionClasses.IRCConfig.xIRCUseColor.Checked);

            ConfigKey.IRCBotNetworkPass.TrySetValue(SectionClasses.IRCConfig.tServPass.Text);
            ConfigKey.IRCChannelPassword.TrySetValue(SectionClasses.IRCConfig.tChanPass.Text);


            // Advanced

            ConfigKey.SubmitCrashReports.TrySetValue(SectionClasses.AdvancedConfig.xCrash.Checked);
            ConfigKey.RelayAllBlockUpdates.TrySetValue(SectionClasses.AdvancedConfig.xRelayAllBlockUpdates.Checked);
            ConfigKey.NoPartialPositionUpdates.TrySetValue(SectionClasses.AdvancedConfig.xNoPartialPositionUpdates.Checked);
            ConfigKey.TickInterval.TrySetValue(Convert.ToInt32((decimal)SectionClasses.AdvancedConfig.nTickInterval.Value));

            if (SectionClasses.AdvancedConfig.cProcessPriority.SelectedIndex == 0)
                ConfigKey.ProcessPriority.ResetValue();
            else if (SectionClasses.AdvancedConfig.cProcessPriority.SelectedIndex == 1)
                ConfigKey.ProcessPriority.TrySetValue(ProcessPriorityClass.High);
            else if (SectionClasses.AdvancedConfig.cProcessPriority.SelectedIndex == 2)
                ConfigKey.ProcessPriority.TrySetValue(ProcessPriorityClass.AboveNormal);
            else if (SectionClasses.AdvancedConfig.cProcessPriority.SelectedIndex == 3)
                ConfigKey.ProcessPriority.TrySetValue(ProcessPriorityClass.Normal);
            else if (SectionClasses.AdvancedConfig.cProcessPriority.SelectedIndex == 4)
                ConfigKey.ProcessPriority.TrySetValue(ProcessPriorityClass.BelowNormal);
            else if (SectionClasses.AdvancedConfig.cProcessPriority.SelectedIndex == 5)
                ConfigKey.ProcessPriority.TrySetValue(ProcessPriorityClass.Idle);

            ConfigKey.BlockUpdateThrottling.TrySetValue(Convert.ToInt32((decimal)SectionClasses.AdvancedConfig.nThrottling.Value));

            ConfigKey.LowLatencyMode.TrySetValue(SectionClasses.AdvancedConfig.xLowLatencyMode.Checked);

            ConfigKey.AutoRankEnabled.TrySetValue(SectionClasses.AdvancedConfig.xAutoRank.Checked);

            ConfigKey.MaxUndo.TrySetValue(
                SectionClasses.AdvancedConfig.xMaxUndo.Checked 
                    ? Convert.ToInt32((decimal)SectionClasses.AdvancedConfig.nMaxUndo.Value) : 0);
            ConfigKey.MaxUndoStates.TrySetValue(Convert.ToInt32(
                (decimal)SectionClasses.AdvancedConfig.nMaxUndoStates.Value));

            ConfigKey.ConsoleName.TrySetValue(SectionClasses.AdvancedConfig.tConsoleName.Text);

            SaveWorldList();
        }


        private void SaveWorldList()
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
                if (SectionClasses.WorldConfig.cMainWorld.SelectedItem != null)
                {
                    root.Add(new XAttribute("main", SectionClasses.WorldConfig.cMainWorld.SelectedItem));
                }
                doc.Add(root);
                doc.Save(worldListTempFileName);
                Paths.MoveOrReplace(worldListTempFileName, Paths.WorldListFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"An error occured while trying to save world list ({Paths.WorldListFileName}): {Environment.NewLine}{ex}");
            }
        }


        private static void WriteEnum<TEnum>([NotNull] ListControl box, ConfigKey key) where TEnum : struct
        {
            if (box == null) throw new ArgumentNullException(nameof(box));
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

