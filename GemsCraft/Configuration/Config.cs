﻿// Copyright 2009-2012 Matvei Stefarov <me@matvei.org>
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using GemsCraft.Commands;
using GemsCraft.Configuration;
using GemsCraft.Events;
using GemsCraft.fSystem;
using GemsCraft.Network;
using GemsCraft.Players;
using GemsCraft.Utils;
using GemsCraft.Worlds;
using JetBrains.Annotations;
using Newtonsoft.Json;
using ServiceStack.Text;

namespace GemsCraft.Configuration {

    // ReSharper disable CommentTypo
    /*
     * j0 - Stopped using xml format for the configuration, instead using json
     */
    // ReSharper restore CommentTypo

    /// <summary> Static class that handles loading/saving configuration, contains config defaults,
    /// and various configuration-related utilities. </summary>
    public static class Config {
        /// <summary>  Supported version of the Minecraft classic protocol. </summary>
        public const int ProtocolVersion = 7;

        /// <summary> Latest version of config.xml available at the time of building this copy of GemsCraft.
        /// Config.xml files saved with this build will have this version number embedded. </summary>
        public const int CurrentVersion = 156;

        public const int CurrentVersionJson = 1;
        private const int LowestSupportedJson = 1;

        private const int LowestSupportedVersion = 111,
                  FirstVersionWithMaxPlayersKey = 134, // LEGACY
                  FirstVersionWithSectionTags = 139, // LEGACY
                  FirstVersionWithSettingsTag = 152; // LEGACY

        private const string ConfigXmlRootName = "fCraftConfig";

        // Mapping of keys to their values
        public static bool ProtocolExtension = true;
        private static readonly string[] Settings;
        private static readonly bool[] SettingsEnabledCache; // cached .Enabled() calls
        private static readonly bool[] SettingsUseEnabledCache; // cached .Enabled() calls

        public static bool UsesCustomTexturePack = false;
        // Mapping of keys to their metadata containers.
        private static readonly ConfigKeyAttribute[] KeyMetadata;

        // Keys organized by sectionses
        private static readonly Dictionary<ConfigSection, ConfigKey[]> KeySections = new Dictionary<ConfigSection, ConfigKey[]>();

        // List of renamed/remapped keys.
        private static readonly Dictionary<string, ConfigKey> LegacyConfigKeys = new Dictionary<string, ConfigKey>(); // LEGACY

        // List of renamed/remapped key values.
        private static readonly Dictionary<ConfigKey, KeyValuePair<string, string>> LegacyConfigValues =
                    new Dictionary<ConfigKey, KeyValuePair<string, string>>(); // LEGACY


        public static ConfigKey[] AllKeys()
        {
            ConfigSection[] sectionses =
            {
                ConfigSection.Advanced, ConfigSection.Chat, ConfigSection.General,
                ConfigSection.IRC, ConfigSection.Logging, ConfigSection.SavingAndBackup,
                ConfigSection.Worlds, ConfigSection.Security, ConfigSection.Worlds, ConfigSection.CPE
            };
            return sectionses.SelectMany(GetKeys).ToArray();
        }

        static Config() {
            int keyCount = Enum.GetValues( typeof( ConfigKey ) ).Length;
            Settings = new string[keyCount];
            SettingsEnabledCache = new bool[keyCount];
            SettingsUseEnabledCache = new bool[keyCount];
            KeyMetadata = new ConfigKeyAttribute[keyCount];

            // gather metadata for ConfigKeys
            foreach( var keyField in typeof( ConfigKey ).GetFields() ) {
                foreach( var attribute in (ConfigKeyAttribute[])keyField.GetCustomAttributes( typeof( ConfigKeyAttribute ), false ) ) {
                    // ReSharper disable AssignNullToNotNullAttribute
                    ConfigKey key = (ConfigKey)keyField.GetValue( null );
                    // ReSharper restore AssignNullToNotNullAttribute
                    attribute.Key = key;
                    KeyMetadata[(int)key] = attribute;
                }
            }

            // organize ConfigKeys into categories, based on metadata
            foreach( ConfigSection section in Enum.GetValues( typeof( ConfigSection ) ) ) {
                ConfigSection sec = section;
                KeySections.Add( section, KeyMetadata.Where( meta => (meta.Section == sec) )
                                                     .Select( meta => meta.Key )
                                                     .ToArray() );
            }

            LoadDefaults();

            // These keys were renamed at some point. LEGACY
            LegacyConfigKeys.Add( "SendRedundantBlockUpdates".ToLower(), ConfigKey.RelayAllBlockUpdates );
            LegacyConfigKeys.Add( "IRCBot".ToLower(), ConfigKey.IRCBotEnabled );
            LegacyConfigKeys.Add( "BackupInterval".ToLower(), ConfigKey.DefaultBackupInterval );
            LegacyConfigKeys.Add( "EnableBlockDB".ToLower(), ConfigKey.BlockDBEnabled );

            // These values have been renamed at some point. LEGACY
            LegacyConfigValues.Add( ConfigKey.ProcessPriority,
                                    new KeyValuePair<string, string>( "Low", ProcessPriorityClass.Idle.ToString() ) );
        }


#if DEBUG
        // Makes sure that defaults and metadata containers are set.
        // This is invoked by Server.InitServer() if built with DEBUG flag.
        internal static void RunSelfTest() {
            foreach( ConfigKey key in Enum.GetValues( typeof( ConfigKey ) ) ) {
                if( Settings[(int)key] == null ) {
                    throw new Exception( "One of the ConfigKey keys is null: " + key );
                }

                if( KeyMetadata[(int)key] == null ) {
                    throw new Exception( "One of the ConfigKey keys does not have metadata set: " + key );
                }
            }
        }
#endif


        #region Defaults

        /// <summary> Overwrites current settings with defaults. </summary>
        public static void LoadDefaults() {
            for( int i = 0; i < KeyMetadata.Length; i++ ) {
                SetValue( (ConfigKey)i, KeyMetadata[i].DefaultValue );
            }
        }


        /// <summary> Loads defaults for keys in a given ConfigSection. </summary>
        public static void LoadDefaults( ConfigSection section ) {
            foreach( var key in KeySections[section] ) {
                SetValue( key, KeyMetadata[(int)key].DefaultValue );
            }
        }


        /// <summary> Checks whether given ConfigKey still has its default value. </summary>
        public static bool IsDefault( this ConfigKey key ) {
            return (KeyMetadata[(int)key].DefaultValue.ToString() == Settings[(int)key]);
        }


        /// <summary> Provides the default value for a given ConfigKey. </summary>
        public static object GetDefault( this ConfigKey key ) {
            return KeyMetadata[(int)key].DefaultValue;
        }


        public static void ResetLogOptions() {
            for( int i = 0; i < Logger.ConsoleOptions.Length; i++ ) {
                Logger.ConsoleOptions[i] = true;
                Logger.LogFileOptions[i] = true;
            }
            Logger.ConsoleOptions[(int)LogType.ConsoleInput] = false;
            Logger.ConsoleOptions[(int)LogType.Debug] = false;
        }

        #endregion


        #region Loading
        /*
         * Starting with GemsCraft Alpha 0.0 - Config now saved as JSON.
         * If a config.xml is present, user will be prompted if they would like to import it
         */
        /// <summary> Loads configuration from json. </summary>
        /// <param name="skipRankList"> If true, skips over rank definitions. </param>
        /// <param name="raiseReloadedEvent"> Whether ConfigReloaded event should be raised. </param>
        /// <returns> True if loading succeeded. </returns>
        public static bool Load(bool skipRankLIst, bool raiseReloadedEvent)
        {
            bool fromFile = false;
            // try to load json file
            ConfigJFile file = new ConfigJFile();
            ResetLogOptions();
            if (File.Exists(Paths.ConfigFileName))
            {
                try
                {
                    string json = File.ReadAllText(Paths.ConfigFileName);
                    file = JsonConvert.DeserializeObject<ConfigJFile>(json);
                    if (file.Equals(null))
                    {
                        Logger.Log(LogType.Warning,
                            "Config.Load: Malformed or incompatible config file {0}. Loading defaults.",
                            Paths.ConfigFileName);
                        LoadDefaults();
                    }
                    else
                    {
                        Logger.Log(LogType.Debug,
                            "Config.Load: Config file {0} loaded succesfully.",
                            Paths.ConfigFileName);
                            fromFile = true;
                    }
                }
                catch (Exception e)
                {
                    Logger.LogAndReportCrash("Config failed to load", "fCraft", e, true);
                    return false;
                }
            }
            else
            {
                // Creates a new one (with defaults) if no file exists
                LoadDefaults();
            }

            string version = "j0";
            if (file.Root == null)
            {
                LoadDefaults();
                return true;
            }
            foreach (ConfigJObject obj in file.Root)
            {
                string key = obj.Key.ToLower();
                string value = obj.Value.ToString();
                int ver = key == "version" ? int.Parse(value.Substring(1)) : -1;
                if (fromFile)
                {
                    switch (key)
                    {
                        case "version" when ver < LowestSupportedJson:
                            Logger.Log(LogType.Warning,
                                "Config.Load: Your copy of config.json is too old to be loaded properly. " +
                                "Some settings will be lost or replaced with defaults. " +
                                "Please open the Configuration to make sure that everything is in order.");
                            break;
                        case "version" when ver != CurrentVersionJson:
                            Logger.Log(LogType.Warning,
                                "Config.Load: Your config.json was made for a different version of GemsCraft. " +
                                "Some obsolete settings might be ignored, and some recently-added settings will be set to defaults. " +
                                "It is recommended that you open the Configuration to make sure that everything is in order.");
                            break;
                        case "version":
                            if (ver == CurrentVersionJson) break;
                            Logger.Log(LogType.Warning,
                                "Config.Load: Unknown version of config.json found. It might be corrupted. " +
                                "Please open the Configuration to make sure that everything is in order.");
                            break;
                        case "ranks":
                            bool usingDefaults = false;
                            if (value == "<Ranks></Ranks>")
                            {
                                value = DefaultRanks;
                                usingDefaults = true;
                            }
                            LoadRankList(value);
                            if (usingDefaults)
                            {
                                RankManager.DefaultRank = RankManager.LowestRank;
                            }
                            break;
                        default:
                        {
                            if (key.Contains("logfileoption"))
                            {
                                logOps.Add(int.Parse(key.Substring(13)));
                            }

                            if (key.Contains("consoleoption"))
                            {
                                conOps.Add(int.Parse(key.Substring(13)));
                            }

                            break;
                        }
                    }
                }
            }
            
            int counter = -1;
            foreach (ConfigJSection obj in file.Sections)
            {
                counter++;
                foreach (ConfigJObject item in obj.Keys)
                {
                    if (item.Key.ToLower() == "texturepath") // Letting server know that we are using a custom texture pack
                    {
                        if (item.Value.ToString() != "")
                        {
                            if (File.Exists(item.Value.ToString()))
                            {
                                UsesCustomTexturePack = true;
                            }
                        }
                    }
                    ParseKeyElement(item.Key, item.Value.ToString());
                }
            }
            

            if (counter == -1)
            {
                Logger.Log(LogType.Warning,
                    "Config.Load: No config sectionses found saved. " +
                    "Using default for everything.");
            }

            if (!fromFile)
            {
                Logger.Log(LogType.Warning, "Config.Load: Using default log file/console options.");
            }
            else
            {
                LoadLogOptions(Logger.LogFileOptions, false);
                LoadLogOptions(Logger.ConsoleOptions, true);
            }

            // Read the rest of the keys

            if (!skipRankLIst)
            {
                RankManager.DefaultRank = Rank.Parse(ConfigKey.DefaultRank.GetString());
                RankManager.DefaultBuildRank = Rank.Parse(ConfigKey.DefaultBuildRank.GetString());
                RankManager.PatrolledRank = Rank.Parse(ConfigKey.PatrolledRank.GetString());
                RankManager.BlockDBAutoEnableRank = Rank.Parse(ConfigKey.BlockDBAutoEnableRank.GetString());
            }

            int perWorld = ConfigKey.MaxPlayersPerWorld.GetInt();
            int max = ConfigKey.MaxPlayers.GetInt();
            if (perWorld > max)
            {
                Logger.Log(LogType.Warning,
                    $"Value of MaxPlayersPerWorld ({perWorld}) " +
                    "was lowered to match MaxPlayers " +
                    $"{max}.");
                ConfigKey.MaxPlayersPerWorld.TrySetValue(ConfigKey.MaxPlayers.GetInt());
            }

            if (raiseReloadedEvent) RaiseReloadedEvent();
            return true;
        }

        private static void ParseKeyElement(string keyName, string value)
        {
            if (keyName == null) throw new ArgumentNullException(nameof(keyName));
            if (value == null) throw new ArgumentNullException(nameof(value));
            ConfigKey key;
            if (EnumUtil.TryParse(keyName, out key, true))
            {
                // known key
                TrySetValue(key, value);
            }
            else if (LegacyConfigKeys.ContainsKey(keyName))
            {
                // renamed/legacy key
                TrySetValue(LegacyConfigKeys[keyName], value);
            }
            else
            {
                // unknown key
                Logger.Log(LogType.Warning,
                    "Config.Load: " +
                    $"Unrecognized entry ignored: {keyName} = {value}");
            }
        }
        private enum LogFileOptions
        {
            SystemActivity, ChangedWorld, Warning, Error, SeriousError, UserActivity,
            UserCommand, SuspiciousActivity, GlobalChat, PrivateChat, ConsoleInput,
            ConsoleOutput, IRC, Debug
        }

        public static List<int> logOps = new List<int>();
        public static List<int> conOps = new List<int>();

        private static void LoadLogOptions([NotNull] IList<bool> list, bool isConsole)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            for (int i = 0; i <= 13; i++)
            {
                list[i] = isConsole ? conOps.Contains(i) : logOps.Contains(i);
            }
        }
        /// <summary> Loads configuration from xml file. </summary>
        /// <param name="skipRankList"> If true, skips over rank definitions. </param>
        /// <param name="raiseReloadedEvent"> Whether ConfigReloaded event should be raised. </param>
        /// <returns> True if loading succeeded. </returns>
        public static bool LoadXml( bool skipRankList, bool raiseReloadedEvent ) {
            bool fromFile = false;

            // try to load config file (XML)
            XDocument file;
            if( File.Exists( Paths.ConfigFileName ) ) {
                try {
                    file = XDocument.Load( Paths.ConfigFileName );
                    if( file.Root == null || file.Root.Name != ConfigXmlRootName ) {
                        Logger.Log( LogType.Warning,
                                    "Config.Load: Malformed or incompatible config file {0}. Loading defaults.",
                                    Paths.ConfigFileName );
                        file = new XDocument();
                        file.Add( new XElement( ConfigXmlRootName ) );
                    } else {
                        Logger.Log( LogType.Debug,
                                    "Config.Load: Config file {0} loaded succesfully.",
                                    Paths.ConfigFileName );
                        fromFile = true;
                    }
                } catch( Exception ex ) {
                    Logger.LogAndReportCrash( "Config failed to load", "fCraft", ex, true );
                    return false;
                }
            } else {
                // create a new one (with defaults) if no file exists
                file = new XDocument();
                file.Add( new XElement( ConfigXmlRootName ) );
            }

            XElement config = file.Root;
            if( config == null ) throw new Exception( "Config.xml has no root. Never happens." );

            int version = 0;
            if( fromFile ) {
                XAttribute attr = config.Attribute( "version" );
                if( attr != null && Int32.TryParse( attr.Value, out version ) ) {
                    if( version < LowestSupportedVersion ) {
                        Logger.Log( LogType.Warning,
                                    "Config.Load: Your copy of config.xml is too old to be loaded properly. " +
                                    "Some settings will be lost or replaced with defaults. " +
                                    "Please run ConfigGUI to make sure that everything is in order." );
                    } else if( version != CurrentVersion ) {
                        Logger.Log( LogType.Warning,
                                    "Config.Load: Your config.xml was made for a different version of 800Craft / GemsCraft. " +
                                    "Some obsolete settings might be ignored, and some recently-added settings will be set to defaults. " +
                                    "It is recommended that you run ConfigGUI to make sure that everything is in order." );
                    }
                } else {
                    Logger.Log( LogType.Warning,
                                "Config.Load: Unknown version of config.xml found. It might be corrupted. " +
                                "Please run ConfigGUI to make sure that everything is in order." );
                }
            }

            // read rank definitions
            if( !skipRankList ) {
                LoadRankList( config, fromFile );
            }
            
            ResetLogOptions();

            // read log options for console
            XElement consoleOptions = config.Element( "ConsoleOptions" );
            if( consoleOptions != null ){
                LoadXmlLogOptions( consoleOptions, Logger.ConsoleOptions );
            }else if(fromFile){
                Logger.Log( LogType.Warning, "Config.Load: using default console options." );
            }

            // read log options for logfiles
            XElement logFileOptions = config.Element( "LogFileOptions" );
            if( logFileOptions != null ){
                LoadXmlLogOptions( logFileOptions, Logger.LogFileOptions );
            }else if(fromFile){
                Logger.Log( LogType.Warning, "Config.Load: using default log file options." );
            }


            // read the rest of the keys
            if( version < FirstVersionWithSectionTags ) {
                foreach( XElement element in config.Elements() ) {
                    ParseXmlKeyElementPreSettings( element );
                }
            } else if( version < FirstVersionWithSettingsTag ) {
                foreach( XElement section in config.Elements( "Section" ) ) {
                    foreach( XElement keyElement in section.Elements() ) {
                        ParseXmlKeyElementPreSettings( keyElement );
                    }
                }
            } else {
                XElement settings = config.Element( "Settings" );
                if( settings != null ) {
                    foreach( XElement pair in settings.Elements( "ConfigKey" ) ) {
                        ParseXmlKeyElement( pair );
                    }
                } else {
                    Logger.Log( LogType.Warning,
                                "Config.Load: No <Settings> tag present. Using default for everything." );
                }
            }

            if( !skipRankList ) {
                RankManager.DefaultRank = Rank.Parse( ConfigKey.DefaultRank.GetString() );
                RankManager.DefaultBuildRank = Rank.Parse( ConfigKey.DefaultBuildRank.GetString() );
                RankManager.PatrolledRank = Rank.Parse( ConfigKey.PatrolledRank.GetString() );
                RankManager.BlockDBAutoEnableRank = Rank.Parse( ConfigKey.BlockDBAutoEnableRank.GetString() );
            }

            // key relation validation
            if( version < FirstVersionWithMaxPlayersKey ) {
                ConfigKey.MaxPlayersPerWorld.TrySetValue( ConfigKey.MaxPlayers.GetInt() );
            }
            if( ConfigKey.MaxPlayersPerWorld.GetInt() > ConfigKey.MaxPlayers.GetInt() ) {
                Logger.Log( LogType.Warning,
                            "Value of MaxPlayersPerWorld ({0}) was lowered to match MaxPlayers ({1}).",
                            ConfigKey.MaxPlayersPerWorld.GetInt(),
                            ConfigKey.MaxPlayers.GetInt() );
                ConfigKey.MaxPlayersPerWorld.TrySetValue( ConfigKey.MaxPlayers.GetInt() );
            }

            if( raiseReloadedEvent ) RaiseReloadedEvent();

            return true;
        }


        private static void ParseXmlKeyElementPreSettings( [NotNull] XElement element ) {
            if( element == null ) throw new ArgumentNullException( "element" );

            string keyName = element.Name.ToString().ToLower();
            ConfigKey key;
            if(EnumUtil.TryParse(keyName,out key,true)){
                // known key
                TrySetValue( key, element.Value );

            } else if( LegacyConfigKeys.ContainsKey( keyName ) ) { // LEGACY
                // renamed/legacy key
                TrySetValue( LegacyConfigKeys[keyName], element.Value );

            } else if( keyName == "limitoneconnectionperip" ) { // LEGACY
                Logger.Log( LogType.Warning,
                            "Config: LimitOneConnectionPerIP (bool) was replaced by MaxConnectionsPerIP (int). " +
                            "Adjust your configuration accordingly." );
                ConfigKey.MaxConnectionsPerIP.TrySetValue( 1 );

            } else if( keyName != "consoleoptions" &&
                       keyName != "logfileoptions" &&
                       keyName != "ranks" &&
                       keyName != "legacyrankmapping" ) {
                // unknown key
                Logger.Log( LogType.Warning,
                            "Config: Unrecognized entry ignored: {0} = {1}",
                            element.Name, element.Value );
            }
        }


        private static void ParseXmlKeyElement( [NotNull] XElement element ) {
            if( element == null ) throw new ArgumentNullException( "element" );

            string keyName = element.Attribute( "key" ).Value;
            string value = element.Attribute( "value" ).Value;
            ConfigKey key;
            if( EnumUtil.TryParse( keyName, out key, true ) ) {
                // known key
                TrySetValue( key, value );

            } else if( LegacyConfigKeys.ContainsKey( keyName ) ) { // LEGACY
                // renamed/legacy key
                TrySetValue( LegacyConfigKeys[keyName], value );

            } else {
                // unknown key
                Logger.Log( LogType.Warning,
                            "Config: Unrecognized entry ignored: {0} = {1}",
                            element.Name, element.Value );
            }
        }

        static void LoadXmlLogOptions( [NotNull] XContainer el, [NotNull] IList<bool> list ) {
            if( el == null ) throw new ArgumentNullException( "el" );
            if( list == null ) throw new ArgumentNullException( "list" );

            for( int i = 0; i < list.Count; i++ ) {
                if( el.Element( ((LogType)i).ToString() ) != null ) {
                    list[i] = true;
                } else {
                    list[i] = false;
                }
            }
        }


        private static void ApplyKeyChange( ConfigKey key ) {
            switch( key ) {
                case ConfigKey.AnnouncementColor:
                    Color.Announcement = Color.Parse( key.GetString() );
                    break;

                case ConfigKey.AntispamInterval:
                    Player.AntispamInterval = key.GetInt();
                    break;

                case ConfigKey.AntispamMessageCount:
                    Player.AntispamMessageCount = key.GetInt();
                    break;

                case ConfigKey.DefaultBuildRank:
                    RankManager.DefaultBuildRank = Rank.Parse( key.GetString() );
                    break;

                case ConfigKey.DefaultRank:
                    RankManager.DefaultRank = Rank.Parse( key.GetString() );
                    break;

                case ConfigKey.BandwidthUseMode:
                    Player[] playerListCache = Server.Players;
                    if( playerListCache != null ) {
                        foreach( Player p in playerListCache ) {
                            if( p.BandwidthUseMode == BandwidthUseMode.Default ) {
                                // resets the use tweaks
                                p.BandwidthUseMode = BandwidthUseMode.Default;
                            }
                        }
                    }
                    break;

                case ConfigKey.BlockDBAutoEnableRank:
                    RankManager.BlockDBAutoEnableRank = Rank.Parse( key.GetString() );
                    if( BlockDB.IsEnabledGlobally ) {
                        World[] worldListCache = WorldManager.Worlds;
                        foreach( World world in worldListCache ) {
                            if( world.BlockDB.AutoToggleIfNeeded() )
                            {
                                Logger.Log(LogType.SystemActivity,
                                    world.BlockDB.IsEnabled
                                        ? "BlockDB is now auto-enabled on world {0}"
                                        : "BlockDB is now auto-disabled on world {0}", world.Name);
                            }
                        }
                    }
                    break;

                case ConfigKey.BlockUpdateThrottling:
                    Server.BlockUpdateThrottling = key.GetInt();
                    break;

                case ConfigKey.ConsoleName:
                    if( Player.Console != null ) {
                        Player.Console.Info.Name = key.GetString();
                    }
                    break;

                case ConfigKey.DefaultBackupInterval:
                    // TODO: update SchedulerTasks
                    WorldManager.DefaultBackupInterval = new TimeSpan( TimeSpan.TicksPerSecond * key.GetInt() );
                    break;

                case ConfigKey.HelpColor:
                    Color.Help = Color.Parse( key.GetString() );
                    break;

                case ConfigKey.IRCDelay:
                    IRC.SendDelay = key.GetInt();
                    break;

                case ConfigKey.IRCMessageColor:
                    Color.IRC = Color.Parse( key.GetString() );
                    break;

                case ConfigKey.GlobalColor:
                    Color.Global = Color.Parse(key.GetString());
                    break;

                case ConfigKey.LogMode:
                    Logger.SplittingType = key.GetEnum<LogSplittingType>();
                    break;

                case ConfigKey.MapPath:
                    if( !Paths.IgnoreMapPathConfigKey && GetString( ConfigKey.MapPath ).Length > 0 ) {
                        if( Paths.TestDirectory( "MapPath", GetString( ConfigKey.MapPath ), true ) ) {
                            Paths.MapPath = Path.GetFullPath( GetString( ConfigKey.MapPath ) );
                        }
                    }
                    break;

                case ConfigKey.MaxUndo:
                    BuildingCommands.MaxUndoCount = key.GetInt();
                    break;

                case ConfigKey.MeColor:
                    Color.Me = Color.Parse( key.GetString() );
                    break;

                case ConfigKey.NoPartialPositionUpdates:
                    Player.FullPositionUpdateInterval = key.Enabled() ? 0 : Player.FullPositionUpdateIntervalDefault;
                    break;

                case ConfigKey.PatrolledRank:
                    RankManager.PatrolledRank = Rank.Parse( key.GetString() );
                    break;

                case ConfigKey.PrivateMessageColor:
                    Color.PM = Color.Parse( key.GetString() );
                    break;

                case ConfigKey.RelayAllBlockUpdates:
                    Player.RelayAllUpdates = key.Enabled();
                    break;

                case ConfigKey.SayColor:
                    Color.Say = Color.Parse( key.GetString() );
                    break;

                case ConfigKey.SystemMessageColor:
                    Color.Sys = Color.Parse( key.GetString() );
                    break;

                case ConfigKey.CustomChatColor:
                    Color.Custom = Color.Parse(key.GetString());
                    break;

                case ConfigKey.TickInterval:
                    Server.TicksPerSecond = 1000 / (float)key.GetInt();
                    break;

                case ConfigKey.UploadBandwidth:
                    Server.MaxUploadSpeed = key.GetInt();
                    break;

                case ConfigKey.WarningColor:
                    Color.Warning = Color.Parse( key.GetString() );
                    break;
            }
        }

        #endregion


        #region Saving

        private static readonly List<ConfigJSection> _jSections = new List<ConfigJSection>();
        public struct ConfigJObject
        {
            public string Key;
            public object Value;
            public object DefaultValue;

            public ConfigJObject(string key, object value, object def)
            {
                Key = key;
                Value = value;
                DefaultValue = def;
            }
        }

        public struct ConfigJSection
        {
            public int Section;
            public ConfigJObject[] Keys;

            public ConfigJSection(ConfigSection sec, ConfigJObject[] keys)
            {
                Section = (int) sec;
                Keys = keys;
            }
        }
        
        public struct ConfigJFile
        {
            public ConfigJObject[] Root;
            public ConfigJSection[] Sections;
            public ConfigJFile(ConfigJObject[] root, ConfigJSection[] sec)
            {
                Root = root;
                Sections = sec;
            }
        }

        public static void OldConfigHandling(bool inGui)
        {
            if (File.Exists("config.xml"))
            {
                if (inGui)
                {
                    DialogResult result = MessageBox.Show(
                        "The old xml version of the configuration file has been found." +
                        "Would you like GemsCraft to convert it to the new format?",
                        "Old Config Found",
                        MessageBoxButtons.YesNoCancel
                    );
                    if (result == DialogResult.Yes)
                    {
                        LoadXml(false, false);
                        Save();
                        File.Delete("config.xml");
                    }
                }
            }
        }
        public static bool Save()
        {
            List<ConfigJObject> objects = new List<ConfigJObject>
            {
                new ConfigJObject("version", "j" + CurrentVersionJson, "j" + CurrentVersionJson)
            };
            // Save general settings
            foreach (ConfigSection section in Enum.GetValues(typeof(ConfigSection)))
            {
                List<ConfigJObject> objs = new List<ConfigJObject>();
                for (var index = 0; index < KeySections[section].Length; index++)
                {
                    ConfigKey key = KeySections[section][index];
                    objs.Add(
                        new ConfigJObject(
                            key.ToString(),
                            Settings[(int) key],
                            key.GetDefault().ToString()));
                }

                _jSections.Add(new ConfigJSection(section, objs.ToArray()));
            }

            // Save console options
            for (int i = 0; i < Logger.ConsoleOptions.Length; i++)
            {
                if (Logger.ConsoleOptions[i])
                {
                    objects.Add(new ConfigJObject($"ConsoleOption{i}", ((LogType) i).ToString(), ""));
                }
            }
            
            // Save logfile options
            for (int i = 0; i < Logger.LogFileOptions.Length; i++)
            {
                if (Logger.LogFileOptions[i])
                {
                    objects.Add(new ConfigJObject($"LogFileOption{i}", ((LogType)i).ToString(), ""));
                }
            }

            // Save ranks - keeping as xml
            XElement ranksTag = new XElement("Ranks");
            string xml;
            foreach (Rank rank in RankManager.Ranks)
            {
                ranksTag.Add(rank.Serialize());
            }

            xml = ranksTag.IsEmpty ? DefaultRanks : ranksTag.ToXml();

            objects.Add(new ConfigJObject("Ranks", xml.Replace("\"", "'"), ""));

            ConfigJFile jFile = new ConfigJFile(objects.ToArray(), _jSections.ToArray());
            string json = JsonConvert.SerializeObject(jFile, Formatting.Indented);
            try
            {
                string tempFileName = Paths.ConfigFileName + ".temp";
                var writer = File.CreateText(tempFileName);
                writer.Write(json);
                writer.Flush();
                writer.Close();
                Paths.MoveOrReplace(tempFileName, Paths.ConfigFileName);
                return true;
            }
            catch (Exception e)
            {
                Logger.LogAndReportCrash("JSON Config failed to save", "fCraft", e, true);
                return false;
            }
        }

        #endregion


        #region Getters

        /// <summary> Checks whether any value has been set for a given key. </summary>
        public static bool IsBlank( this ConfigKey key ) {
            return (Settings[(int)key].Length == 0);
        }


        /// <summary> Returns raw value for the given key. </summary>
        public static string GetString( this ConfigKey key ) {
            return KeyMetadata[(int)key].Process( Settings[(int)key] );
        }


        /// <summary> Attempts to parse given key's value as an integer.
        /// Throws a FormatException on failure. </summary>
        public static int GetInt( this ConfigKey key ) {
            return int.Parse( GetString( key ) );
        }


        /// <summary> Attempts to parse a given key's value as an integer. </summary>
        /// <param name="key"> ConfigKey to get value from. </param>
        /// <param name="result"> Will be set to the value on success, or to 0 on failure. </param>
        /// <returns> Whether parsing succeeded. </returns>
        public static bool TryGetInt( this ConfigKey key, out int result ) {
            return int.TryParse( GetString( key ), out result );
        }


        /// <summary> Attempts to parse a given key's value as an enumeration.
        /// An ArgumentException is thrown if value could not be parsed.
        /// Note the parsing is done in a case-insensitive way. </summary>
        /// <typeparam name="TEnum"> Enum to use for parsing.
        /// An ArgumentException will be thrown if this is not an enum. </typeparam>
        public static TEnum GetEnum<TEnum>(this ConfigKey key) where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum) throw new ArgumentException("Enum type required");
            return (TEnum)Enum.Parse(typeof(TEnum), GetString(key), true);
        }


        /// <summary> Attempts to parse given key's value as a boolean.
        /// Throws a FormatException on failure. </summary>
        public static bool Enabled( this ConfigKey key )
        {
            return SettingsUseEnabledCache[(int)key] ? SettingsEnabledCache[(int)key] : bool.Parse( GetString( key ) );
        }


        /// <summary> Attempts to parse a given key's value as a boolean. </summary>
        /// <param name="key"> ConfigKey to get value from. </param>
        /// <param name="result"> Will be set to the value on success, or to false on failure. </param>
        /// <returns> Whether parsing succeeded. </returns>
        public static bool TryGetBool( this ConfigKey key, out bool result ) {
            if( SettingsUseEnabledCache[(int)key] ) {
                result = SettingsEnabledCache[(int)key];
                return true;
            } else {
                result = false;
                return false;
            }
        }


        /// <summary> Returns the expected Type of the key's value, as specified in key metadata. </summary>
        public static Type GetValueType( this ConfigKey key ) {
            return KeyMetadata[(int)key].ValueType;
        }


        /// <summary> Returns the metadata container (ConfigKeyAttribute object) for a given key. </summary>
        public static ConfigKeyAttribute GetMetadata( this ConfigKey key ) {
            return KeyMetadata[(int)key];
        }


        /// <summary> Returns the ConfigSection that a given key is associated with. </summary>
        public static ConfigSection GetSection( this ConfigKey key ) {
            return KeyMetadata[(int)key].Section;
        }

        

        /// <summary> Returns the description text for a given config key. </summary>
        public static string GetDescription( this ConfigKey key ) {
            return KeyMetadata[(int)key].Description;
        }

        #endregion


        #region Setters

        /// <summary> Resets key value to its default setting. </summary>
        /// <param name="key"> Config key to reset. </param>
        /// <returns> True if value was reset. False if resetting was cancelled by an event handler/plugin. </returns>
        public static bool ResetValue( this ConfigKey key ) {
            return key.TrySetValue( key.GetDefault() );
        }


        /// <summary> Sets value of a given config key.
        /// Note that this method may throw exceptions if the given value is not acceptible.
        /// Use Config.TrySetValue() if you'd like to suppress exceptions in favor of a boolean return value. </summary>
        /// <param name="key"> Config key to set. </param>
        /// <param name="rawValue"> Value to assign to the key. If passed object is not a string, rawValue.ToString() is used. </param>
        /// <exception cref="T:System.ArgumentNullException" />
        /// <exception cref="T:System.FormatException" />
        /// <returns> True if value is valid and has been assigned.
        /// False if value is valid, but assignment was cancelled by an event handler/plugin. </returns>
        public static bool SetValue( this ConfigKey key, object rawValue ) {
            if( rawValue == null ) {
                throw new ArgumentNullException( "rawValue", key + ": ConfigKey values cannot be null. Use an empty string to indicate unset value." );
            }

            string value = (rawValue as string ?? rawValue.ToString());

            if( value == null ) {
                throw new NullReferenceException( key + ": rawValue.ToString() returned null." );
            }

            if( LegacyConfigValues.ContainsKey( key ) ) {
                foreach( var pair in LegacyConfigValues.Values ) {
                    if (!pair.Key.Equals(value, StringComparison.OrdinalIgnoreCase)) continue;
                    value = pair.Value;
                    break;
                }
            }

            // throws various exceptions (most commonly FormatException) if invalid
            KeyMetadata[(int)key].Validate( value );

            return DoSetValue( key, value );
        }


        /// <summary> Attempts to set the value of a given config key.
        /// Check the return value to make sure that the given value was acceptible. </summary>
        /// <param name="key"> Config key to set. </param>
        /// <param name="rawValue"> Value to assign to the key. If passed object is not a string, rawValue.ToString() is used. </param>
        /// <exception cref="T:System.ArgumentNullException" />
        /// <returns> True if value is valid and has been assigned.
        /// False if value was invalid, or if assignment was cancelled by an event handler/plugin. </returns>
        public static bool TrySetValue( this ConfigKey key, object rawValue ) {
            try {
                return SetValue( key, rawValue );
            } catch( FormatException ex ) {
                Logger.Log( LogType.Error,
                            "{0}.TrySetValue: {1}",
                            key, ex.Message );
                return false;
            }
        }


        private static bool DoSetValue( ConfigKey key, string newValue ) {
            string oldValue = Settings[(int)key];
            if (oldValue == newValue) return true;
            if( RaiseKeyChangingEvent( key, oldValue, ref newValue ) ) return false;
            Settings[(int)key] = newValue;

            if( bool.TryParse( newValue, out var enabledCache ) ) {
                SettingsUseEnabledCache[(int)key] = true;
                SettingsEnabledCache[(int)key] = enabledCache;
            } else {
                SettingsUseEnabledCache[(int)key] = false;
                SettingsEnabledCache[(int)key] = false;
            }

            ApplyKeyChange( key );
            RaiseKeyChangedEvent( key, oldValue, newValue );
            return true;
        }

        #endregion


        #region Ranks

        public static string DefaultRanks = @"<Ranks>
    <Rank name='owner' id='YDz1ZqWANf8B3Bj2' color='red' prefix='+' antiGriefBlocks='0' antiGriefSeconds='0' reserveSlot='true' allowSecurityCircumvention='true' copySlots='4' fillLimit='2048'>
      <Chat />
      <Build />
      <Delete />
      <PlaceGrass />
      <PlaceWater />
      <PlaceLava />
      <PlaceAdmincrete />
      <DeleteAdmincrete />
      <ViewOthersInfo />
      <ViewPlayerIPs />
      <EditPlayerDB />
      <Say />
      <ReadStaffChat />
      <UseColorCodes />
      <UseSpeedHack />
      <Kick max='owner#YDz1ZqWANf8B3Bj2' />
      <Ban max='owner#YDz1ZqWANf8B3Bj2' />
      <BanIP />
      <BanAll />
      <Promote max='owner#YDz1ZqWANf8B3Bj2' />
      <Demote max='owner#YDz1ZqWANf8B3Bj2' />
      <Hide />
      <Draw />
      <DrawAdvanced />
      <Tree />
      <CopyAndPaste />
      <UndoOthersActions />
      <Teleport />
      <Bring />
      <BringAll />
      <Patrol />
      <Spectate />
      <Freeze />
      <Mute />
      <SetSpawn />
      <Lock />
      <ManageZones />
      <ManageWorlds />
      <ManageBlockDB />
      <Import />
      <ReloadConfig />
      <ShutdownServer />
      <UsePortal />
      <ManagePortal />
      <HighFive />
      <ChatWithCaps />
      <Swear />
      <MakeVoteKicks />
      <BroMode />
      <Troll />
      <HideRanks />
      <ReadAdminChat />
      <ReadCustomChat />
      <Realm />
      <Possess />
      <Gtfo />
      <RageQuit />
      <Tower />
      <TempBan />
      <Warn />
      <Slap />
      <Kill />
      <Basscannon />
      <Physics />
      <Fireworks />
      <Gun />
      <Games />
      <Moderation />
      <Immortal />
      <Punch />
      <Brofist />
      <STFU />
      <MuteAll />
      <LeBot />
      <Economy />
      <ManageEconomy />
      <MakeVotes />
      <TPA />
    </Rank>
    <Rank name='op' id='kWqQb0PlPiIdfARv' color='aqua' prefix='-' antiGriefBlocks='0' antiGriefSeconds='0' copySlots='3' fillLimit='512'>
      <Chat />
      <Build />
      <Delete />
      <PlaceGrass />
      <PlaceWater />
      <PlaceLava />
      <PlaceAdmincrete />
      <DeleteAdmincrete />
      <ViewOthersInfo />
      <ViewPlayerIPs />
      <Say />
      <ReadStaffChat />
      <UseColorCodes />
      <UseSpeedHack />
      <Kick max='op#kWqQb0PlPiIdfARv' />
      <Ban max='builder#nacYSLJ5dQqAz9wa' />
      <BanIP />
      <Promote max='builder#nacYSLJ5dQqAz9wa' />
      <Demote max='builder#nacYSLJ5dQqAz9wa' />
      <Hide />
      <Draw />
      <DrawAdvanced />
      <CopyAndPaste />
      <UndoOthersActions />
      <Teleport />
      <Bring />
      <Patrol />
      <Spectate />
      <Freeze />
      <Mute />
      <SetSpawn />
      <Lock />
      <ManageZones />
      <Punch />
      <Brofist />
      <STFU />
      <LeBot />
      <Economy />
      <MakeVotes />
      <TPA />
    </Rank>
    <Rank name='builder' id='nacYSLJ5dQqAz9wa' color='white' antiGriefBlocks='47' antiGriefSeconds='6' drawLimit='8000' idleKickAfter='20' copySlots='2' fillLimit='32'>
      <Chat />
      <Build />
      <Delete />
      <PlaceGrass />
      <PlaceWater />
      <PlaceLava />
      <PlaceAdmincrete />
      <DeleteAdmincrete />
      <ViewOthersInfo />
      <UseSpeedHack />
      <Kick max='builder#nacYSLJ5dQqAz9wa' />
      <Draw />
      <Teleport />
      <Brofist />
      <Economy />
      <MakeVotes />
      <TPA />
    </Rank>
    <Rank name='guest' id='pgHRN37FrZpymUsC' color='silver' antiGriefBlocks='37' antiGriefSeconds='5' drawLimit='512' idleKickAfter='20' copySlots='2' fillLimit='32'>
      <Chat />
      <Build />
      <Delete />
      <UseSpeedHack />
    </Rank>
  </Ranks>";
        public static void LoadRankList(string xml)
        {
            XElement rankList = null;
            XElement[] rankDefinitionList;
            try
            {
                rankList = XElement.Parse(xml.Replace("\\r\\n", ""));
                rankDefinitionList = rankList.Elements("Rank").ToArray();
            }
            catch (Exception e)
            {
                Logger.Log(LogType.Warning,
                    "Config.Load: No rank definitions found. Using defaults. " + e);
                RankManager.Reset();
                return;
            }
            
            foreach (XElement rankDefinition in rankDefinitionList)
            {
                try
                {
                    RankManager.AddRank(new Rank(rankDefinition));
                }
                catch (RankDefinitionException e)
                {
                    Logger.Log(LogType.Error, e.Message);
                }
            }

            if (RankManager.RanksByName.Count == 0)
            {
                Logger.Log(LogType.Warning,
                    "Config.Load: No ranks were defined, or none were defined correctly." +
                    "Using default ranks (guest, builder, op, and owner).");
                rankList = XElement.Parse(DefaultRanks);
            }

            RankManager.ParsePermissionLimits();
        }

        private static void LoadRankList( [NotNull] XContainer el, bool fromFile ) {
            if( el == null ) throw new ArgumentNullException( "el" );

            XElement legacyRankMappingTag = el.Element( "LegacyRankMapping" );
            if( legacyRankMappingTag != null ) {
                foreach( XElement rankPair in legacyRankMappingTag.Elements( "LegacyRankPair" ) ) {
                    XAttribute fromRankID = rankPair.Attribute( "from" );
                    XAttribute toRankID = rankPair.Attribute( "to" );
                    if( fromRankID == null || String.IsNullOrEmpty( fromRankID.Value ) ||
                        toRankID == null || String.IsNullOrEmpty( toRankID.Value ) ) {
                        Logger.Log( LogType.Error,
                                    "Config.Load: Could not parse a LegacyRankMapping entry: {0}", rankPair );
                    } else {
                        RankManager.LegacyRankMapping.Add( fromRankID.Value, toRankID.Value );
                    }
                }
            }

            XElement rankList = el.Element( "Ranks" );

            if( rankList != null ) {
                XElement[] rankDefinitionList = rankList.Elements( "Rank" ).ToArray();

                foreach( XElement rankDefinition in rankDefinitionList ) {
                    try {
                        RankManager.AddRank( new Rank( rankDefinition ) );
                    } catch( RankDefinitionException ex ) {
                        Logger.Log( LogType.Error, ex.Message );
                    }
                }

                if( RankManager.RanksByName.Count == 0 ) {
                    Logger.Log( LogType.Warning,
                                "Config.Load: No ranks were defined, or none were defined correctly. "+
                                "Using default ranks (guest, builder, op, and owner)." );
                    rankList.Remove();
                    el.Add( DefineDefaultRanks() );
                }

            } else {
                if( fromFile ) Logger.Log( LogType.Warning, "Config.Load: using default player ranks." );
                el.Add( DefineDefaultRanks() );
            }

            // parse rank-limit permissions
            RankManager.ParsePermissionLimits();
        }


        /// <summary> Resets the list of ranks to defaults (guest/builder/op/owner).
        /// Warning: This method is not thread-safe, and should never be used on a live server. </summary>
        public static void ResetRanks() {
            RankManager.Reset();
            DefineDefaultRanks();
            RankManager.ParsePermissionLimits();
        }


        static XElement DefineDefaultRanks() {
            XElement permissions = new XElement( "Ranks" );

            XElement owner = new XElement( "Rank" );
            owner.Add( new XAttribute( "id", RankManager.GenerateID() ) );
            owner.Add( new XAttribute( "name", "owner" ) );
            owner.Add( new XAttribute( "rank", 100 ) );
            owner.Add( new XAttribute( "color", "red" ) );
            owner.Add( new XAttribute( "prefix", "+" ) );
            owner.Add( new XAttribute( "drawLimit", 0 ) );
            owner.Add( new XAttribute( "fillLimit", 2048 ) );
            owner.Add( new XAttribute( "copySlots", 4 ) );
            owner.Add( new XAttribute( "antiGriefBlocks", 0 ) );
            owner.Add( new XAttribute( "antiGriefSeconds", 0 ) );
            owner.Add( new XAttribute( "idleKickAfter", 0 ) );
            owner.Add( new XAttribute( "reserveSlot", true ) );
            owner.Add( new XAttribute( "allowSecurityCircumvention", true ) );

            owner.Add( new XElement( Permission.Chat.ToString() ) );
            owner.Add( new XElement( Permission.Build.ToString() ) );
            owner.Add( new XElement( Permission.Delete.ToString() ) );
            owner.Add( new XElement( Permission.UseSpeedHack.ToString() ) );
            owner.Add( new XElement( Permission.UseColorCodes.ToString() ) );

            owner.Add( new XElement( Permission.PlaceGrass.ToString() ) );
            owner.Add( new XElement( Permission.PlaceWater.ToString() ) );
            owner.Add( new XElement( Permission.PlaceLava.ToString() ) );
            owner.Add( new XElement( Permission.PlaceAdmincrete.ToString() ) );
            owner.Add( new XElement( Permission.DeleteAdmincrete.ToString() ) );

            owner.Add( new XElement( Permission.Say.ToString() ) );
            owner.Add( new XElement( Permission.ReadStaffChat.ToString() ) );
            XElement temp = new XElement( Permission.Kick.ToString() );
            temp.Add( new XAttribute( "max", "owner" ) );
            owner.Add( temp );
            temp = new XElement( Permission.Ban.ToString() );
            temp.Add( new XAttribute( "max", "owner" ) );
            owner.Add( temp );
            owner.Add( new XElement( Permission.BanIP.ToString() ) );
            owner.Add( new XElement( Permission.BanAll.ToString() ) );

            temp = new XElement( Permission.Promote.ToString() );
            temp.Add( new XAttribute( "max", "owner" ) );
            owner.Add( temp );
            temp = new XElement( Permission.Demote.ToString() );
            temp.Add( new XAttribute( "max", "owner" ) );
            owner.Add( temp );
            owner.Add( new XElement( Permission.Hide.ToString() ) );

            owner.Add( new XElement( Permission.ViewOthersInfo.ToString() ) );
            owner.Add( new XElement( Permission.ViewPlayerIPs.ToString() ) );
            owner.Add( new XElement( Permission.EditPlayerDB.ToString() ) );

            owner.Add( new XElement( Permission.Teleport.ToString() ) );
            owner.Add( new XElement( Permission.Bring.ToString() ) );
            owner.Add( new XElement( Permission.BringAll.ToString() ) );
            owner.Add( new XElement( Permission.Patrol.ToString() ) );
            owner.Add( new XElement( Permission.Spectate.ToString() ) );
            owner.Add( new XElement( Permission.Freeze.ToString() ) );
            owner.Add( new XElement( Permission.Mute.ToString() ) );
            owner.Add( new XElement( Permission.SetSpawn.ToString() ) );

            owner.Add( new XElement( Permission.Lock.ToString() ) );

            owner.Add( new XElement( Permission.ManageZones.ToString() ) );
            owner.Add( new XElement( Permission.ManageWorlds.ToString() ) );
            owner.Add( new XElement( Permission.ManageBlockDB.ToString() ) );
            owner.Add( new XElement( Permission.Import.ToString() ) );
            owner.Add( new XElement( Permission.Draw.ToString() ) );
            owner.Add( new XElement( Permission.DrawAdvanced.ToString() ) );
            owner.Add( new XElement( Permission.CopyAndPaste.ToString() ) );
            owner.Add( new XElement( Permission.UndoOthersActions.ToString() ) );

            owner.Add( new XElement( Permission.ReloadConfig.ToString() ) );
            owner.Add( new XElement( Permission.ShutdownServer.ToString() ) );
            owner.Add( new XElement(Permission.Basscannon.ToString() ) );
            owner.Add( new XElement(Permission.Tree.ToString() ) );
            owner.Add( new XElement(Permission.UsePortal.ToString() ) );
            owner.Add( new XElement(Permission.ManagePortal.ToString() ) );
            owner.Add( new XElement(Permission.HighFive.ToString() ) );
            owner.Add( new XElement(Permission.ChatWithCaps.ToString() ) );

            owner.Add( new XElement(Permission.Swear.ToString() ) );
            owner.Add( new XElement(Permission.MakeVotes.ToString() ) );
            owner.Add( new XElement(Permission.MakeVoteKicks.ToString() ) );
            owner.Add( new XElement(Permission.BroMode.ToString() ) );
            owner.Add( new XElement(Permission.Troll.ToString() ) );
            owner.Add( new XElement(Permission.HideRanks.ToString() ) );
            owner.Add( new XElement(Permission.ReadAdminChat.ToString() ) );

            owner.Add( new XElement(Permission.ReadCustomChat.ToString() ) );
            owner.Add( new XElement(Permission.Realm.ToString() ) );
            owner.Add( new XElement(Permission.Possess.ToString() ) );
            owner.Add( new XElement(Permission.Gtfo.ToString() ) );
            owner.Add( new XElement(Permission.RageQuit.ToString() ) );
            owner.Add( new XElement(Permission.Tower.ToString() ) );

            owner.Add( new XElement(Permission.TempBan.ToString() ) );
            owner.Add( new XElement(Permission.Warn.ToString() ) );
            owner.Add( new XElement(Permission.Slap.ToString() ) );
            owner.Add( new XElement(Permission.Kill.ToString() ) );
            owner.Add( new XElement(Permission.Physics.ToString() ) );

            owner.Add( new XElement(Permission.Fireworks.ToString() ) );
            owner.Add( new XElement(Permission.Gun.ToString() ) );
            owner.Add( new XElement(Permission.Games.ToString() ) );
            owner.Add( new XElement(Permission.Moderation.ToString() ) );
            owner.Add( new XElement(Permission.Immortal.ToString() ) );
            owner.Add(new XElement(Permission.Punch.ToString()));
            owner.Add(new XElement(Permission.Brofist.ToString()));
            owner.Add(new XElement(Permission.STFU.ToString()));
            owner.Add(new XElement(Permission.MuteAll.ToString()));
            owner.Add(new XElement(Permission.LeBot.ToString()));
            owner.Add(new XElement(Permission.Economy.ToString()));
            owner.Add(new XElement(Permission.ManageEconomy.ToString()));
            owner.Add(new XElement(Permission.MakeVotes.ToString()));
            owner.Add(new XElement(Permission.TPA.ToString()));

            permissions.Add( owner );
            try {
                RankManager.AddRank( new Rank( owner ) );
            } catch( RankDefinitionException ex ) {
                Logger.Log( LogType.Error, ex.Message );
            }


            XElement op = new XElement( "Rank" );
            op.Add( new XAttribute( "id", RankManager.GenerateID() ) );
            op.Add( new XAttribute( "name", "op" ) );
            op.Add( new XAttribute( "rank", 80 ) );
            op.Add( new XAttribute( "color", "aqua" ) );
            op.Add( new XAttribute( "prefix", "-" ) );
            op.Add( new XAttribute( "drawLimit", 0 ) );
            op.Add( new XAttribute( "fillLimit", 512 ) );
            op.Add( new XAttribute( "copySlots", 3 ) );
            op.Add( new XAttribute( "antiGriefBlocks", 0 ) );
            op.Add( new XAttribute( "antiGriefSeconds", 0 ) );
            op.Add( new XAttribute( "idleKickAfter", 0 ) );

            op.Add( new XElement( Permission.Chat.ToString() ) );
            op.Add( new XElement( Permission.Build.ToString() ) );
            op.Add( new XElement( Permission.Delete.ToString() ) );
            op.Add( new XElement( Permission.UseSpeedHack.ToString() ) );
            op.Add( new XElement( Permission.UseColorCodes.ToString() ) );

            op.Add( new XElement( Permission.PlaceGrass.ToString() ) );
            op.Add( new XElement( Permission.PlaceWater.ToString() ) );
            op.Add( new XElement( Permission.PlaceLava.ToString() ) );
            op.Add( new XElement( Permission.PlaceAdmincrete.ToString() ) );
            op.Add( new XElement( Permission.DeleteAdmincrete.ToString() ) );

            op.Add( new XElement( Permission.Say.ToString() ) );
            op.Add( new XElement( Permission.ReadStaffChat.ToString() ) );
            temp = new XElement( Permission.Kick.ToString() );
            temp.Add( new XAttribute( "max", "op" ) );
            op.Add( temp );
            temp = new XElement( Permission.Ban.ToString() );
            temp.Add( new XAttribute( "max", "builder" ) );
            op.Add( temp );
            op.Add( new XElement( Permission.BanIP.ToString() ) );

            temp = new XElement( Permission.Promote.ToString() );
            temp.Add( new XAttribute( "max", "builder" ) );
            op.Add( temp );
            temp = new XElement( Permission.Demote.ToString() );
            temp.Add( new XAttribute( "max", "builder" ) );
            op.Add( temp );
            op.Add( new XElement( Permission.Hide.ToString() ) );

            op.Add( new XElement( Permission.ViewOthersInfo.ToString() ) );
            op.Add( new XElement( Permission.ViewPlayerIPs.ToString() ) );

            op.Add( new XElement( Permission.Teleport.ToString() ) );
            op.Add( new XElement( Permission.Bring.ToString() ) );
            op.Add( new XElement( Permission.Patrol.ToString() ) );
            op.Add( new XElement( Permission.Spectate.ToString() ) );
            op.Add( new XElement( Permission.Freeze.ToString() ) );
            op.Add( new XElement( Permission.Mute.ToString() ) );
            op.Add( new XElement( Permission.SetSpawn.ToString() ) );

            op.Add( new XElement( Permission.ManageZones.ToString() ) );
            op.Add( new XElement( Permission.Lock.ToString() ) );
            op.Add( new XElement( Permission.Draw.ToString() ) );
            op.Add( new XElement( Permission.DrawAdvanced.ToString() ) );
            op.Add( new XElement( Permission.CopyAndPaste.ToString() ) );
            op.Add( new XElement( Permission.UndoOthersActions.ToString() ) );
            op.Add(new XElement(Permission.Punch.ToString()));
            op.Add(new XElement(Permission.Brofist.ToString()));
            op.Add(new XElement(Permission.STFU.ToString()));
            op.Add(new XElement(Permission.LeBot.ToString()));
            op.Add(new XElement(Permission.Economy.ToString()));
            op.Add(new XElement(Permission.MakeVotes.ToString()));
            op.Add(new XElement(Permission.TPA.ToString()));
            permissions.Add( op );
            try {
                RankManager.AddRank( new Rank( op ) );
            } catch( RankDefinitionException ex ) {
                Logger.Log( LogType.Error, ex.Message );
            }


            XElement builder = new XElement( "Rank" );
            builder.Add( new XAttribute( "id", RankManager.GenerateID() ) );
            builder.Add( new XAttribute( "name", "builder" ) );
            builder.Add( new XAttribute( "rank", 30 ) );
            builder.Add( new XAttribute( "color", "white" ) );
            builder.Add( new XAttribute( "prefix", "" ) );
            builder.Add( new XAttribute( "drawLimit", 8000 ) );
            builder.Add( new XAttribute( "antiGriefBlocks", 47 ) );
            builder.Add( new XAttribute( "antiGriefSeconds", 6 ) );
            builder.Add( new XAttribute( "idleKickAfter", 20 ) );

            builder.Add( new XElement( Permission.Chat.ToString() ) );
            builder.Add( new XElement( Permission.Build.ToString() ) );
            builder.Add( new XElement( Permission.Delete.ToString() ) );
            builder.Add( new XElement( Permission.UseSpeedHack.ToString() ) );

            builder.Add( new XElement( Permission.PlaceGrass.ToString() ) );
            builder.Add( new XElement( Permission.PlaceWater.ToString() ) );
            builder.Add( new XElement( Permission.PlaceLava.ToString() ) );
            builder.Add( new XElement( Permission.PlaceAdmincrete.ToString() ) );
            builder.Add( new XElement( Permission.DeleteAdmincrete.ToString() ) );

            temp = new XElement( Permission.Kick.ToString() );
            temp.Add( new XAttribute( "max", "builder" ) );
            builder.Add( temp );

            builder.Add( new XElement( Permission.ViewOthersInfo.ToString() ) );

            builder.Add( new XElement( Permission.Teleport.ToString() ) );

            builder.Add( new XElement( Permission.Draw.ToString() ) );
            builder.Add(new XElement(Permission.Brofist.ToString()));
            builder.Add(new XElement(Permission.Economy.ToString()));
            builder.Add(new XElement(Permission.MakeVotes.ToString()));
            builder.Add(new XElement(Permission.TPA.ToString()));
            permissions.Add( builder );
            try {
                RankManager.AddRank( new Rank( builder ) );
            } catch( RankDefinitionException ex ) {
                Logger.Log( LogType.Error, ex.Message );
            }


            XElement guest = new XElement( "Rank" );
            guest.Add( new XAttribute( "id", RankManager.GenerateID() ) );
            guest.Add( new XAttribute( "name", "guest" ) );
            guest.Add( new XAttribute( "rank", 0 ) );
            guest.Add( new XAttribute( "color", "silver" ) );
            guest.Add( new XAttribute( "prefix", "" ) );
            guest.Add( new XAttribute( "drawLimit", 512 ) );
            guest.Add( new XAttribute( "antiGriefBlocks", 37 ) );
            guest.Add( new XAttribute( "antiGriefSeconds", 5 ) );
            guest.Add( new XAttribute( "idleKickAfter", 20 ) );
            guest.Add( new XElement( Permission.Chat.ToString() ) );
            guest.Add( new XElement( Permission.Build.ToString() ) );
            guest.Add( new XElement( Permission.Delete.ToString() ) );
            guest.Add( new XElement( Permission.UseSpeedHack.ToString() ) );
            permissions.Add( guest );
            try {
                RankManager.AddRank( new Rank( guest ) );
            } catch( RankDefinitionException ex ) {
                Logger.Log( LogType.Error, ex.Message );
            }

            return permissions;
        }

        #endregion


        #region Events

        /// <summary> Occurs after the entire configuration has been reloaded from file. </summary>
        public static event EventHandler Reloaded;


        /// <summary> Occurs when a config key is about to be changed (cancellable).
        /// The new value may be replaced by the callback. </summary>
        public static event EventHandler<ConfigKeyChangingEventArgs> KeyChanging;


        /// <summary> Occurs after a config key has been changed. </summary>
        public static event EventHandler<ConfigKeyChangedEventArgs> KeyChanged;


        static void RaiseReloadedEvent() {
            var h = Reloaded;
            if( h != null ) h( null, EventArgs.Empty );
        }


        static bool RaiseKeyChangingEvent( ConfigKey key, string oldValue, ref string newValue ) {
            var h = KeyChanging;
            if( h == null ) return false;
            var e = new ConfigKeyChangingEventArgs( key, oldValue, newValue );
            h( null, e );
            newValue = e.NewValue;
            return e.Cancel;
        }


        static void RaiseKeyChangedEvent( ConfigKey key, string oldValue, string newValue ) {
            var h = KeyChanged;
            var args = new ConfigKeyChangedEventArgs( key, oldValue, newValue );
            if( h != null ) h( null, args );
        }

        #endregion


        /// <summary> Returns a list of all keys in a section. </summary>
        public static ConfigKey[] GetKeys( this ConfigSection section ) {
            return KeySections[section];
        }
    }
}


namespace GemsCraft.Events {

    public sealed class ConfigKeyChangingEventArgs : EventArgs, ICancellableEvent {
        public ConfigKey Key { get; private set; }
        public string OldValue { get; private set; }
        public string NewValue { get; set; }
        public bool Cancel { get; set; }

        public ConfigKeyChangingEventArgs( ConfigKey key, string oldValue, string newValue ) {
            Key = key;
            OldValue = oldValue;
            NewValue = newValue;
            Cancel = false;
        }
    }


    public sealed class ConfigKeyChangedEventArgs : EventArgs {
        public ConfigKey Key { get; private set; }
        public string OldValue { get; private set; }
        public string NewValue { get; private set; }

        public ConfigKeyChangedEventArgs( ConfigKey key, string oldValue, string newValue ) {
            Key = key;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }

}