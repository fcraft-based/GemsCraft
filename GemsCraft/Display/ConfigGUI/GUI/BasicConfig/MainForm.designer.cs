﻿using System.Windows.Forms;

namespace GemsCraft.Display.ConfigGUI.GUI.BasicConfig
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            bold.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.gBasic = new System.Windows.Forms.GroupBox();
            this.nMaxPlayersPerWorld = new System.Windows.Forms.NumericUpDown();
            this.lMaxPlayersPerWorld = new System.Windows.Forms.Label();
            this.lPort = new System.Windows.Forms.Label();
            this.nPort = new System.Windows.Forms.NumericUpDown();
            this.cDefaultRank = new System.Windows.Forms.ComboBox();
            this.lDefaultRank = new System.Windows.Forms.Label();
            this.lUploadBandwidth = new System.Windows.Forms.Label();
            this.bMeasure = new System.Windows.Forms.Button();
            this.tServerName = new System.Windows.Forms.TextBox();
            this.lUploadBandwidthUnits = new System.Windows.Forms.Label();
            this.lServerName = new System.Windows.Forms.Label();
            this.nUploadBandwidth = new System.Windows.Forms.NumericUpDown();
            this.tMOTD = new System.Windows.Forms.TextBox();
            this.lMOTD = new System.Windows.Forms.Label();
            this.cPublic = new System.Windows.Forms.ComboBox();
            this.nMaxPlayers = new System.Windows.Forms.NumericUpDown();
            this.lPublic = new System.Windows.Forms.Label();
            this.lMaxPlayers = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.bWiki = new System.Windows.Forms.Button();
            this.bWeb = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bChangelog = new System.Windows.Forms.Button();
            this.bCredits = new System.Windows.Forms.Button();
            this.bReadme = new System.Windows.Forms.Button();
            this.gInformation = new System.Windows.Forms.GroupBox();
            this.bGreeting = new System.Windows.Forms.Button();
            this.lAnnouncementsUnits = new System.Windows.Forms.Label();
            this.nAnnouncements = new System.Windows.Forms.NumericUpDown();
            this.xAnnouncements = new System.Windows.Forms.CheckBox();
            this.bRules = new System.Windows.Forms.Button();
            this.bAnnouncements = new System.Windows.Forms.Button();
            this.tabChat = new System.Windows.Forms.TabPage();
            this.chatPreview = new GemsCraft.Display.ConfigGUI.GUI.BasicConfig.ChatPreview();
            this.gAppearence = new System.Windows.Forms.GroupBox();
            this.xShowConnectionMessages = new System.Windows.Forms.CheckBox();
            this.xShowJoinedWorldMessages = new System.Windows.Forms.CheckBox();
            this.xRankColorsInWorldNames = new System.Windows.Forms.CheckBox();
            this.xRankPrefixesInList = new System.Windows.Forms.CheckBox();
            this.xRankPrefixesInChat = new System.Windows.Forms.CheckBox();
            this.xRankColorsInChat = new System.Windows.Forms.CheckBox();
            this.gChatColors = new System.Windows.Forms.GroupBox();
            this.lColorMe = new System.Windows.Forms.Label();
            this.bColorGlobal = new System.Windows.Forms.Button();
            this.bColorMe = new System.Windows.Forms.Button();
            this.lColorWarning = new System.Windows.Forms.Label();
            this.bColorWarning = new System.Windows.Forms.Button();
            this.bColorSys = new System.Windows.Forms.Button();
            this.lColorSys = new System.Windows.Forms.Label();
            this.bColorPM = new System.Windows.Forms.Button();
            this.lColorHelp = new System.Windows.Forms.Label();
            this.lColorPM = new System.Windows.Forms.Label();
            this.IColorGlobal = new System.Windows.Forms.Label();
            this.lColorSay = new System.Windows.Forms.Label();
            this.bColorAnnouncement = new System.Windows.Forms.Button();
            this.lColorAnnouncement = new System.Windows.Forms.Label();
            this.bColorHelp = new System.Windows.Forms.Button();
            this.bColorSay = new System.Windows.Forms.Button();
            this.tabWorlds = new System.Windows.Forms.TabPage();
            this.xWoMEnableEnvExtensions = new System.Windows.Forms.CheckBox();
            this.bMapPath = new System.Windows.Forms.Button();
            this.xMapPath = new System.Windows.Forms.CheckBox();
            this.tMapPath = new System.Windows.Forms.TextBox();
            this.lDefaultBuildRank = new System.Windows.Forms.Label();
            this.cDefaultBuildRank = new System.Windows.Forms.ComboBox();
            this.cMainWorld = new System.Windows.Forms.ComboBox();
            this.lMainWorld = new System.Windows.Forms.Label();
            this.bWorldEdit = new System.Windows.Forms.Button();
            this.bAddWorld = new System.Windows.Forms.Button();
            this.bWorldDelete = new System.Windows.Forms.Button();
            this.dgvWorlds = new System.Windows.Forms.DataGridView();
            this.dgvcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcAccess = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvcBuild = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvcBackup = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvcHidden = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvcBlockDB = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabRanks = new System.Windows.Forms.TabPage();
            this.gPermissionLimits = new System.Windows.Forms.GroupBox();
            this.permissionLimitBoxContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.lRankList = new System.Windows.Forms.Label();
            this.bLowerRank = new System.Windows.Forms.Button();
            this.bRaiseRank = new System.Windows.Forms.Button();
            this.gRankOptions = new System.Windows.Forms.GroupBox();
            this.lFillLimitUnits = new System.Windows.Forms.Label();
            this.nFillLimit = new System.Windows.Forms.NumericUpDown();
            this.lFillLimit = new System.Windows.Forms.Label();
            this.nCopyPasteSlots = new System.Windows.Forms.NumericUpDown();
            this.lCopyPasteSlots = new System.Windows.Forms.Label();
            this.xAllowSecurityCircumvention = new System.Windows.Forms.CheckBox();
            this.lAntiGrief1 = new System.Windows.Forms.Label();
            this.lAntiGrief3 = new System.Windows.Forms.Label();
            this.nAntiGriefSeconds = new System.Windows.Forms.NumericUpDown();
            this.bColorRank = new System.Windows.Forms.Button();
            this.xDrawLimit = new System.Windows.Forms.CheckBox();
            this.lDrawLimitUnits = new System.Windows.Forms.Label();
            this.lKickIdleUnits = new System.Windows.Forms.Label();
            this.nDrawLimit = new System.Windows.Forms.NumericUpDown();
            this.nKickIdle = new System.Windows.Forms.NumericUpDown();
            this.xAntiGrief = new System.Windows.Forms.CheckBox();
            this.lAntiGrief2 = new System.Windows.Forms.Label();
            this.xKickIdle = new System.Windows.Forms.CheckBox();
            this.nAntiGriefBlocks = new System.Windows.Forms.NumericUpDown();
            this.xReserveSlot = new System.Windows.Forms.CheckBox();
            this.tPrefix = new System.Windows.Forms.TextBox();
            this.lPrefix = new System.Windows.Forms.Label();
            this.lRankColor = new System.Windows.Forms.Label();
            this.tRankName = new System.Windows.Forms.TextBox();
            this.lRankName = new System.Windows.Forms.Label();
            this.bDeleteRank = new System.Windows.Forms.Button();
            this.vPermissions = new System.Windows.Forms.ListView();
            this.chPermissions = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bAddRank = new System.Windows.Forms.Button();
            this.lPermissions = new System.Windows.Forms.Label();
            this.vRanks = new System.Windows.Forms.ListBox();
            this.tabCPE = new System.Windows.Forms.TabPage();
            this.gboHeldBlock = new System.Windows.Forms.GroupBox();
            this.chkEnableHeldBlock = new System.Windows.Forms.CheckBox();
            this.metroLabel2 = new System.Windows.Forms.Label();
            this.gboClickDistance = new System.Windows.Forms.GroupBox();
            this.numMaxDistance = new System.Windows.Forms.NumericUpDown();
            this.lblMaxDistance = new System.Windows.Forms.Label();
            this.numMinDistance = new System.Windows.Forms.NumericUpDown();
            this.lblMinDistance = new System.Windows.Forms.Label();
            this.chkEnableClickDistance = new System.Windows.Forms.CheckBox();
            this.metroLabel1 = new System.Windows.Forms.Label();
            this.gboCustomBlocks = new System.Windows.Forms.GroupBox();
            this.btnDefineNewBlock = new System.Windows.Forms.Button();
            this.gboMessageType = new System.Windows.Forms.GroupBox();
            this.txtStatus1 = new System.Windows.Forms.TextBox();
            this.txtStatus2 = new System.Windows.Forms.TextBox();
            this.txtStatus3 = new System.Windows.Forms.TextBox();
            this.txtBR3 = new System.Windows.Forms.TextBox();
            this.txtBR2 = new System.Windows.Forms.TextBox();
            this.txtBR1 = new System.Windows.Forms.TextBox();
            this.chkBR1 = new System.Windows.Forms.CheckBox();
            this.chkBR2 = new System.Windows.Forms.CheckBox();
            this.chkBR3 = new System.Windows.Forms.CheckBox();
            this.chkStatus3 = new System.Windows.Forms.CheckBox();
            this.chkStatus2 = new System.Windows.Forms.CheckBox();
            this.chkStatus1 = new System.Windows.Forms.CheckBox();
            this.chkShowAnnouncements = new System.Windows.Forms.CheckBox();
            this.chkEnableMessageTypes = new System.Windows.Forms.CheckBox();
            this.lblMTInformation = new System.Windows.Forms.Label();
            this.tabSecurity = new System.Windows.Forms.TabPage();
            this.gBlockDB = new System.Windows.Forms.GroupBox();
            this.cBlockDBAutoEnableRank = new System.Windows.Forms.ComboBox();
            this.xBlockDBAutoEnable = new System.Windows.Forms.CheckBox();
            this.xBlockDBEnabled = new System.Windows.Forms.CheckBox();
            this.gSecurityMisc = new System.Windows.Forms.GroupBox();
            this.xAnnounceRankChangeReasons = new System.Windows.Forms.CheckBox();
            this.xRequireKickReason = new System.Windows.Forms.CheckBox();
            this.lPatrolledRankAndBelow = new System.Windows.Forms.Label();
            this.cPatrolledRank = new System.Windows.Forms.ComboBox();
            this.lPatrolledRank = new System.Windows.Forms.Label();
            this.xAnnounceRankChanges = new System.Windows.Forms.CheckBox();
            this.xAnnounceKickAndBanReasons = new System.Windows.Forms.CheckBox();
            this.xRequireRankChangeReason = new System.Windows.Forms.CheckBox();
            this.xRequireBanReason = new System.Windows.Forms.CheckBox();
            this.gSpamChat = new System.Windows.Forms.GroupBox();
            this.lAntispamMaxWarnings = new System.Windows.Forms.Label();
            this.nAntispamMaxWarnings = new System.Windows.Forms.NumericUpDown();
            this.xAntispamKicks = new System.Windows.Forms.CheckBox();
            this.lSpamMuteSeconds = new System.Windows.Forms.Label();
            this.lAntispamInterval = new System.Windows.Forms.Label();
            this.nSpamMute = new System.Windows.Forms.NumericUpDown();
            this.lSpamMute = new System.Windows.Forms.Label();
            this.nAntispamInterval = new System.Windows.Forms.NumericUpDown();
            this.lAntispamMessageCount = new System.Windows.Forms.Label();
            this.nAntispamMessageCount = new System.Windows.Forms.NumericUpDown();
            this.lSpamChat = new System.Windows.Forms.Label();
            this.gVerify = new System.Windows.Forms.GroupBox();
            this.nMaxConnectionsPerIP = new System.Windows.Forms.NumericUpDown();
            this.xAllowUnverifiedLAN = new System.Windows.Forms.CheckBox();
            this.xMaxConnectionsPerIP = new System.Windows.Forms.CheckBox();
            this.lVerifyNames = new System.Windows.Forms.Label();
            this.cVerifyNames = new System.Windows.Forms.ComboBox();
            this.tabSavingAndBackup = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.bUpdate = new System.Windows.Forms.Button();
            this.checkUpdate = new System.Windows.Forms.CheckBox();
            this.gDataBackup = new System.Windows.Forms.GroupBox();
            this.xBackupDataOnStartup = new System.Windows.Forms.CheckBox();
            this.gSaving = new System.Windows.Forms.GroupBox();
            this.nSaveInterval = new System.Windows.Forms.NumericUpDown();
            this.lSaveIntervalUnits = new System.Windows.Forms.Label();
            this.xSaveInterval = new System.Windows.Forms.CheckBox();
            this.gBackups = new System.Windows.Forms.GroupBox();
            this.xBackupOnlyWhenChanged = new System.Windows.Forms.CheckBox();
            this.lMaxBackupSize = new System.Windows.Forms.Label();
            this.xMaxBackupSize = new System.Windows.Forms.CheckBox();
            this.nMaxBackupSize = new System.Windows.Forms.NumericUpDown();
            this.xMaxBackups = new System.Windows.Forms.CheckBox();
            this.xBackupOnStartup = new System.Windows.Forms.CheckBox();
            this.lMaxBackups = new System.Windows.Forms.Label();
            this.nMaxBackups = new System.Windows.Forms.NumericUpDown();
            this.nBackupInterval = new System.Windows.Forms.NumericUpDown();
            this.lBackupIntervalUnits = new System.Windows.Forms.Label();
            this.xBackupInterval = new System.Windows.Forms.CheckBox();
            this.xBackupOnJoin = new System.Windows.Forms.CheckBox();
            this.tabLogging = new System.Windows.Forms.TabPage();
            this.gLogFile = new System.Windows.Forms.GroupBox();
            this.lLogFileOptionsDescription = new System.Windows.Forms.Label();
            this.xLogLimit = new System.Windows.Forms.CheckBox();
            this.vLogFileOptions = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lLogLimitUnits = new System.Windows.Forms.Label();
            this.nLogLimit = new System.Windows.Forms.NumericUpDown();
            this.cLogMode = new System.Windows.Forms.ComboBox();
            this.lLogMode = new System.Windows.Forms.Label();
            this.gConsole = new System.Windows.Forms.GroupBox();
            this.lLogConsoleOptionsDescription = new System.Windows.Forms.Label();
            this.vConsoleOptions = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabIRC = new System.Windows.Forms.TabPage();
            this.gIRCAdv = new System.Windows.Forms.GroupBox();
            this.tServPass = new System.Windows.Forms.TextBox();
            this.xServPass = new System.Windows.Forms.CheckBox();
            this.tChanPass = new System.Windows.Forms.TextBox();
            this.xChanPass = new System.Windows.Forms.CheckBox();
            this.xIRCListShowNonEnglish = new System.Windows.Forms.CheckBox();
            this.gIRCOptions = new System.Windows.Forms.GroupBox();
            this.xIRCBotAnnounceServerEvents = new System.Windows.Forms.CheckBox();
            this.xIRCUseColor = new System.Windows.Forms.CheckBox();
            this.lIRCNoForwardingMessage = new System.Windows.Forms.Label();
            this.xIRCBotAnnounceIRCJoins = new System.Windows.Forms.CheckBox();
            this.bColorIRC = new System.Windows.Forms.Button();
            this.lColorIRC = new System.Windows.Forms.Label();
            this.xIRCBotForwardFromIRC = new System.Windows.Forms.CheckBox();
            this.xIRCBotAnnounceServerJoins = new System.Windows.Forms.CheckBox();
            this.xIRCBotForwardFromServer = new System.Windows.Forms.CheckBox();
            this.gIRCNetwork = new System.Windows.Forms.GroupBox();
            this.lIRCDelayUnits = new System.Windows.Forms.Label();
            this.xIRCRegisteredNick = new System.Windows.Forms.CheckBox();
            this.tIRCNickServMessage = new System.Windows.Forms.TextBox();
            this.lIRCNickServMessage = new System.Windows.Forms.Label();
            this.tIRCNickServ = new System.Windows.Forms.TextBox();
            this.lIRCNickServ = new System.Windows.Forms.Label();
            this.nIRCDelay = new System.Windows.Forms.NumericUpDown();
            this.lIRCDelay = new System.Windows.Forms.Label();
            this.lIRCBotChannels2 = new System.Windows.Forms.Label();
            this.lIRCBotChannels3 = new System.Windows.Forms.Label();
            this.tIRCBotChannels = new System.Windows.Forms.TextBox();
            this.lIRCBotChannels = new System.Windows.Forms.Label();
            this.nIRCBotPort = new System.Windows.Forms.NumericUpDown();
            this.lIRCBotPort = new System.Windows.Forms.Label();
            this.tIRCBotNetwork = new System.Windows.Forms.TextBox();
            this.lIRCBotNetwork = new System.Windows.Forms.Label();
            this.lIRCBotNick = new System.Windows.Forms.Label();
            this.tIRCBotNick = new System.Windows.Forms.TextBox();
            this.lIRCList = new System.Windows.Forms.Label();
            this.xIRCBotEnabled = new System.Windows.Forms.CheckBox();
            this.cIRCList = new System.Windows.Forms.ComboBox();
            this.tabPlugins = new System.Windows.Forms.TabPage();
            this.gboPlugins = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.gboPluginInfo = new System.Windows.Forms.GroupBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.listPlugins = new System.Windows.Forms.ListBox();
            this.chkPlugins = new System.Windows.Forms.CheckBox();
            this.tabAdvanced = new System.Windows.Forms.TabPage();
            this.gPerformance = new System.Windows.Forms.GroupBox();
            this.lAdvancedWarning = new System.Windows.Forms.Label();
            this.xLowLatencyMode = new System.Windows.Forms.CheckBox();
            this.lProcessPriority = new System.Windows.Forms.Label();
            this.cProcessPriority = new System.Windows.Forms.ComboBox();
            this.nTickInterval = new System.Windows.Forms.NumericUpDown();
            this.lTickIntervalUnits = new System.Windows.Forms.Label();
            this.lTickInterval = new System.Windows.Forms.Label();
            this.nThrottling = new System.Windows.Forms.NumericUpDown();
            this.lThrottling = new System.Windows.Forms.Label();
            this.lThrottlingUnits = new System.Windows.Forms.Label();
            this.gAdvancedMisc = new System.Windows.Forms.GroupBox();
            this.xAutoRank = new System.Windows.Forms.CheckBox();
            this.nMaxUndoStates = new System.Windows.Forms.NumericUpDown();
            this.lMaxUndoStates = new System.Windows.Forms.Label();
            this.lIPWarning = new System.Windows.Forms.Label();
            this.tIP = new System.Windows.Forms.TextBox();
            this.xIP = new System.Windows.Forms.CheckBox();
            this.lConsoleName = new System.Windows.Forms.Label();
            this.tConsoleName = new System.Windows.Forms.TextBox();
            this.nMaxUndo = new System.Windows.Forms.NumericUpDown();
            this.lMaxUndoUnits = new System.Windows.Forms.Label();
            this.xMaxUndo = new System.Windows.Forms.CheckBox();
            this.xRelayAllBlockUpdates = new System.Windows.Forms.CheckBox();
            this.xNoPartialPositionUpdates = new System.Windows.Forms.CheckBox();
            this.gCrashReport = new System.Windows.Forms.GroupBox();
            this.xCrash = new System.Windows.Forms.CheckBox();
            this.lCrashReportDisclaimer = new System.Windows.Forms.Label();
            this.tabMisc = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.websiteURL = new System.Windows.Forms.TextBox();
            this.ReqsEditor = new System.Windows.Forms.Button();
            this.SwearEditor = new System.Windows.Forms.Button();
            this.MaxCapsValue = new System.Windows.Forms.NumericUpDown();
            this.MaxCaps = new System.Windows.Forms.Label();
            this.SwearBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CustomColor = new System.Windows.Forms.Button();
            this.CustomText = new System.Windows.Forms.Label();
            this.CustomName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CustomAliases = new System.Windows.Forms.TextBox();
            this.bOK = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.bResetTab = new System.Windows.Forms.Button();
            this.bResetAll = new System.Windows.Forms.Button();
            this.bApply = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.propertyGrid2 = new System.Windows.Forms.PropertyGrid();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.propertyGrid3 = new System.Windows.Forms.PropertyGrid();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.tabs.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.gBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxPlayersPerWorld)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUploadBandwidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxPlayers)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.gInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nAnnouncements)).BeginInit();
            this.tabChat.SuspendLayout();
            this.gAppearence.SuspendLayout();
            this.gChatColors.SuspendLayout();
            this.tabWorlds.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorlds)).BeginInit();
            this.tabRanks.SuspendLayout();
            this.gPermissionLimits.SuspendLayout();
            this.gRankOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nFillLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCopyPasteSlots)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nAntiGriefSeconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDrawLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nKickIdle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nAntiGriefBlocks)).BeginInit();
            this.tabCPE.SuspendLayout();
            this.gboHeldBlock.SuspendLayout();
            this.gboClickDistance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinDistance)).BeginInit();
            this.gboCustomBlocks.SuspendLayout();
            this.gboMessageType.SuspendLayout();
            this.tabSecurity.SuspendLayout();
            this.gBlockDB.SuspendLayout();
            this.gSecurityMisc.SuspendLayout();
            this.gSpamChat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nAntispamMaxWarnings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSpamMute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nAntispamInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nAntispamMessageCount)).BeginInit();
            this.gVerify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxConnectionsPerIP)).BeginInit();
            this.tabSavingAndBackup.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.gDataBackup.SuspendLayout();
            this.gSaving.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSaveInterval)).BeginInit();
            this.gBackups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxBackupSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxBackups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nBackupInterval)).BeginInit();
            this.tabLogging.SuspendLayout();
            this.gLogFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nLogLimit)).BeginInit();
            this.gConsole.SuspendLayout();
            this.tabIRC.SuspendLayout();
            this.gIRCAdv.SuspendLayout();
            this.gIRCOptions.SuspendLayout();
            this.gIRCNetwork.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nIRCDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nIRCBotPort)).BeginInit();
            this.tabPlugins.SuspendLayout();
            this.gboPlugins.SuspendLayout();
            this.gboPluginInfo.SuspendLayout();
            this.tabAdvanced.SuspendLayout();
            this.gPerformance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nTickInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nThrottling)).BeginInit();
            this.gAdvancedMisc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxUndoStates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxUndo)).BeginInit();
            this.gCrashReport.SuspendLayout();
            this.tabMisc.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxCapsValue)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.Controls.Add(this.tabGeneral);
            this.tabs.Controls.Add(this.tabChat);
            this.tabs.Controls.Add(this.tabWorlds);
            this.tabs.Controls.Add(this.tabRanks);
            this.tabs.Controls.Add(this.tabCPE);
            this.tabs.Controls.Add(this.tabSecurity);
            this.tabs.Controls.Add(this.tabSavingAndBackup);
            this.tabs.Controls.Add(this.tabLogging);
            this.tabs.Controls.Add(this.tabIRC);
            this.tabs.Controls.Add(this.tabPlugins);
            this.tabs.Controls.Add(this.tabAdvanced);
            this.tabs.Controls.Add(this.tabMisc);
            this.tabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabs.Location = new System.Drawing.Point(12, 12);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(660, 510);
            this.tabs.TabIndex = 0;
            // 
            // tabGeneral
            // 
            this.tabGeneral.BackColor = System.Drawing.Color.Green;
            this.tabGeneral.Controls.Add(this.gBasic);
            this.tabGeneral.Controls.Add(this.groupBox4);
            this.tabGeneral.Controls.Add(this.pictureBox1);
            this.tabGeneral.Controls.Add(this.groupBox2);
            this.tabGeneral.Controls.Add(this.gInformation);
            this.tabGeneral.Location = new System.Drawing.Point(4, 24);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.tabGeneral.Size = new System.Drawing.Size(652, 482);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            // 
            // gBasic
            // 
            this.gBasic.Controls.Add(this.nMaxPlayersPerWorld);
            this.gBasic.Controls.Add(this.lMaxPlayersPerWorld);
            this.gBasic.Controls.Add(this.lPort);
            this.gBasic.Controls.Add(this.nPort);
            this.gBasic.Controls.Add(this.cDefaultRank);
            this.gBasic.Controls.Add(this.lDefaultRank);
            this.gBasic.Controls.Add(this.lUploadBandwidth);
            this.gBasic.Controls.Add(this.bMeasure);
            this.gBasic.Controls.Add(this.tServerName);
            this.gBasic.Controls.Add(this.lUploadBandwidthUnits);
            this.gBasic.Controls.Add(this.lServerName);
            this.gBasic.Controls.Add(this.nUploadBandwidth);
            this.gBasic.Controls.Add(this.tMOTD);
            this.gBasic.Controls.Add(this.lMOTD);
            this.gBasic.Controls.Add(this.cPublic);
            this.gBasic.Controls.Add(this.nMaxPlayers);
            this.gBasic.Controls.Add(this.lPublic);
            this.gBasic.Controls.Add(this.lMaxPlayers);
            this.gBasic.Location = new System.Drawing.Point(8, 13);
            this.gBasic.Name = "gBasic";
            this.gBasic.Size = new System.Drawing.Size(636, 190);
            this.gBasic.TabIndex = 0;
            this.gBasic.TabStop = false;
            this.gBasic.Text = "Basic Settings";
            // 
            // nMaxPlayersPerWorld
            // 
            this.nMaxPlayersPerWorld.Location = new System.Drawing.Point(440, 74);
            this.nMaxPlayersPerWorld.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.nMaxPlayersPerWorld.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nMaxPlayersPerWorld.Name = "nMaxPlayersPerWorld";
            this.nMaxPlayersPerWorld.Size = new System.Drawing.Size(75, 21);
            this.nMaxPlayersPerWorld.TabIndex = 12;
            this.nMaxPlayersPerWorld.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nMaxPlayersPerWorld.Validating += new System.ComponentModel.CancelEventHandler(this.nMaxPlayerPerWorld_Validating);
            // 
            // lMaxPlayersPerWorld
            // 
            this.lMaxPlayersPerWorld.AutoSize = true;
            this.lMaxPlayersPerWorld.Location = new System.Drawing.Point(299, 76);
            this.lMaxPlayersPerWorld.Name = "lMaxPlayersPerWorld";
            this.lMaxPlayersPerWorld.Size = new System.Drawing.Size(135, 15);
            this.lMaxPlayersPerWorld.TabIndex = 11;
            this.lMaxPlayersPerWorld.Text = "Max players (per world)";
            // 
            // lPort
            // 
            this.lPort.AutoSize = true;
            this.lPort.Location = new System.Drawing.Point(42, 103);
            this.lPort.Name = "lPort";
            this.lPort.Size = new System.Drawing.Size(75, 15);
            this.lPort.TabIndex = 6;
            this.lPort.Text = "Port number";
            // 
            // nPort
            // 
            this.nPort.Location = new System.Drawing.Point(123, 101);
            this.nPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nPort.Name = "nPort";
            this.nPort.Size = new System.Drawing.Size(75, 21);
            this.nPort.TabIndex = 7;
            this.nPort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cDefaultRank
            // 
            this.cDefaultRank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cDefaultRank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cDefaultRank.FormattingEnabled = true;
            this.cDefaultRank.Location = new System.Drawing.Point(440, 128);
            this.cDefaultRank.Name = "cDefaultRank";
            this.cDefaultRank.Size = new System.Drawing.Size(170, 23);
            this.cDefaultRank.TabIndex = 18;
            this.cDefaultRank.SelectedIndexChanged += new System.EventHandler(this.cDefaultRank_SelectedIndexChanged);
            // 
            // lDefaultRank
            // 
            this.lDefaultRank.AutoSize = true;
            this.lDefaultRank.Location = new System.Drawing.Point(361, 131);
            this.lDefaultRank.Name = "lDefaultRank";
            this.lDefaultRank.Size = new System.Drawing.Size(73, 15);
            this.lDefaultRank.TabIndex = 17;
            this.lDefaultRank.Text = "Default rank";
            // 
            // lUploadBandwidth
            // 
            this.lUploadBandwidth.AutoSize = true;
            this.lUploadBandwidth.Location = new System.Drawing.Point(327, 103);
            this.lUploadBandwidth.Name = "lUploadBandwidth";
            this.lUploadBandwidth.Size = new System.Drawing.Size(107, 15);
            this.lUploadBandwidth.TabIndex = 13;
            this.lUploadBandwidth.Text = "Upload bandwidth";
            // 
            // bMeasure
            // 
            this.bMeasure.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bMeasure.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bMeasure.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.bMeasure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bMeasure.Location = new System.Drawing.Point(559, 99);
            this.bMeasure.Name = "bMeasure";
            this.bMeasure.Size = new System.Drawing.Size(71, 23);
            this.bMeasure.TabIndex = 16;
            this.bMeasure.Text = "Measure";
            this.bMeasure.UseVisualStyleBackColor = false;
            this.bMeasure.Click += new System.EventHandler(this.bMeasure_Click);
            // 
            // tServerName
            // 
            this.tServerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tServerName.HideSelection = false;
            this.tServerName.Location = new System.Drawing.Point(123, 20);
            this.tServerName.MaxLength = 64;
            this.tServerName.Name = "tServerName";
            this.tServerName.Size = new System.Drawing.Size(507, 21);
            this.tServerName.TabIndex = 1;
            // 
            // lUploadBandwidthUnits
            // 
            this.lUploadBandwidthUnits.AutoSize = true;
            this.lUploadBandwidthUnits.Location = new System.Drawing.Point(521, 103);
            this.lUploadBandwidthUnits.Name = "lUploadBandwidthUnits";
            this.lUploadBandwidthUnits.Size = new System.Drawing.Size(32, 15);
            this.lUploadBandwidthUnits.TabIndex = 15;
            this.lUploadBandwidthUnits.Text = "KB/s";
            // 
            // lServerName
            // 
            this.lServerName.AutoSize = true;
            this.lServerName.Location = new System.Drawing.Point(40, 23);
            this.lServerName.Name = "lServerName";
            this.lServerName.Size = new System.Drawing.Size(77, 15);
            this.lServerName.TabIndex = 0;
            this.lServerName.Text = "Server name";
            // 
            // nUploadBandwidth
            // 
            this.nUploadBandwidth.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUploadBandwidth.Location = new System.Drawing.Point(440, 101);
            this.nUploadBandwidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUploadBandwidth.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUploadBandwidth.Name = "nUploadBandwidth";
            this.nUploadBandwidth.Size = new System.Drawing.Size(75, 21);
            this.nUploadBandwidth.TabIndex = 14;
            this.nUploadBandwidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // tMOTD
            // 
            this.tMOTD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tMOTD.Location = new System.Drawing.Point(123, 47);
            this.tMOTD.MaxLength = 64;
            this.tMOTD.Name = "tMOTD";
            this.tMOTD.Size = new System.Drawing.Size(507, 21);
            this.tMOTD.TabIndex = 3;
            // 
            // lMOTD
            // 
            this.lMOTD.AutoSize = true;
            this.lMOTD.Location = new System.Drawing.Point(74, 50);
            this.lMOTD.Name = "lMOTD";
            this.lMOTD.Size = new System.Drawing.Size(43, 15);
            this.lMOTD.TabIndex = 2;
            this.lMOTD.Text = "MOTD";
            // 
            // cPublic
            // 
            this.cPublic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cPublic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cPublic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cPublic.FormattingEnabled = true;
            this.cPublic.Items.AddRange(new object[] {
            "Public",
            "Private"});
            this.cPublic.Location = new System.Drawing.Point(123, 128);
            this.cPublic.Name = "cPublic";
            this.cPublic.Size = new System.Drawing.Size(75, 23);
            this.cPublic.TabIndex = 10;
            // 
            // nMaxPlayers
            // 
            this.nMaxPlayers.Location = new System.Drawing.Point(123, 74);
            this.nMaxPlayers.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nMaxPlayers.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nMaxPlayers.Name = "nMaxPlayers";
            this.nMaxPlayers.Size = new System.Drawing.Size(75, 21);
            this.nMaxPlayers.TabIndex = 5;
            this.nMaxPlayers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nMaxPlayers.ValueChanged += new System.EventHandler(this.nMaxPlayers_ValueChanged);
            // 
            // lPublic
            // 
            this.lPublic.AutoSize = true;
            this.lPublic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPublic.Location = new System.Drawing.Point(14, 131);
            this.lPublic.Name = "lPublic";
            this.lPublic.Size = new System.Drawing.Size(103, 15);
            this.lPublic.TabIndex = 9;
            this.lPublic.Text = "Server visibility";
            // 
            // lMaxPlayers
            // 
            this.lMaxPlayers.AutoSize = true;
            this.lMaxPlayers.Location = new System.Drawing.Point(10, 76);
            this.lMaxPlayers.Name = "lMaxPlayers";
            this.lMaxPlayers.Size = new System.Drawing.Size(107, 15);
            this.lMaxPlayers.TabIndex = 4;
            this.lMaxPlayers.Text = "Max players (total)";
            // 
            // groupBox4
            // 
            this.groupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.bWiki);
            this.groupBox4.Controls.Add(this.bWeb);
            this.groupBox4.Location = new System.Drawing.Point(468, 306);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(126, 94);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Contact Us";
            // 
            // bWiki
            // 
            this.bWiki.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bWiki.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bWiki.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.bWiki.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bWiki.Location = new System.Drawing.Point(7, 60);
            this.bWiki.Name = "bWiki";
            this.bWiki.Size = new System.Drawing.Size(111, 23);
            this.bWiki.TabIndex = 1;
            this.bWiki.Text = "Wiki";
            this.bWiki.UseVisualStyleBackColor = false;
            // 
            // bWeb
            // 
            this.bWeb.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bWeb.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bWeb.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.bWeb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bWeb.Location = new System.Drawing.Point(8, 31);
            this.bWeb.Name = "bWeb";
            this.bWeb.Size = new System.Drawing.Size(110, 23);
            this.bWeb.TabIndex = 1;
            this.bWeb.Text = "Website";
            this.bWeb.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GemsCraft.Properties.Resources.cool_logo;
            this.pictureBox1.Location = new System.Drawing.Point(212, 294);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(213, 175);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.bChangelog);
            this.groupBox2.Controls.Add(this.bCredits);
            this.groupBox2.Controls.Add(this.bReadme);
            this.groupBox2.Location = new System.Drawing.Point(51, 306);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(123, 135);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "About";
            // 
            // bChangelog
            // 
            this.bChangelog.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bChangelog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bChangelog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.bChangelog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bChangelog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bChangelog.Location = new System.Drawing.Point(7, 89);
            this.bChangelog.Name = "bChangelog";
            this.bChangelog.Size = new System.Drawing.Size(110, 23);
            this.bChangelog.TabIndex = 2;
            this.bChangelog.Text = "Changelog";
            this.bChangelog.UseVisualStyleBackColor = false;
            this.bChangelog.Click += new System.EventHandler(this.bChangelog_Click);
            // 
            // bCredits
            // 
            this.bCredits.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bCredits.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bCredits.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.bCredits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCredits.Location = new System.Drawing.Point(6, 31);
            this.bCredits.Name = "bCredits";
            this.bCredits.Size = new System.Drawing.Size(111, 23);
            this.bCredits.TabIndex = 1;
            this.bCredits.Text = "Credits";
            this.bCredits.UseVisualStyleBackColor = false;
            this.bCredits.Click += new System.EventHandler(this.bCredits_Click);
            // 
            // bReadme
            // 
            this.bReadme.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bReadme.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bReadme.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.bReadme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bReadme.Location = new System.Drawing.Point(7, 60);
            this.bReadme.Name = "bReadme";
            this.bReadme.Size = new System.Drawing.Size(110, 23);
            this.bReadme.TabIndex = 1;
            this.bReadme.Text = "Readme";
            this.bReadme.UseVisualStyleBackColor = false;
            this.bReadme.Click += new System.EventHandler(this.bReadme_Click);
            // 
            // gInformation
            // 
            this.gInformation.Controls.Add(this.bGreeting);
            this.gInformation.Controls.Add(this.lAnnouncementsUnits);
            this.gInformation.Controls.Add(this.nAnnouncements);
            this.gInformation.Controls.Add(this.xAnnouncements);
            this.gInformation.Controls.Add(this.bRules);
            this.gInformation.Controls.Add(this.bAnnouncements);
            this.gInformation.Location = new System.Drawing.Point(8, 219);
            this.gInformation.Name = "gInformation";
            this.gInformation.Size = new System.Drawing.Size(636, 57);
            this.gInformation.TabIndex = 1;
            this.gInformation.TabStop = false;
            this.gInformation.Text = "Information";
            // 
            // bGreeting
            // 
            this.bGreeting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bGreeting.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bGreeting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bGreeting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.bGreeting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bGreeting.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bGreeting.Location = new System.Drawing.Point(538, 20);
            this.bGreeting.Name = "bGreeting";
            this.bGreeting.Size = new System.Drawing.Size(92, 28);
            this.bGreeting.TabIndex = 5;
            this.bGreeting.Text = "Edit Greeting";
            this.bGreeting.UseVisualStyleBackColor = false;
            this.bGreeting.Click += new System.EventHandler(this.bGreeting_Click);
            // 
            // lAnnouncementsUnits
            // 
            this.lAnnouncementsUnits.AutoSize = true;
            this.lAnnouncementsUnits.Location = new System.Drawing.Point(266, 27);
            this.lAnnouncementsUnits.Name = "lAnnouncementsUnits";
            this.lAnnouncementsUnits.Size = new System.Drawing.Size(28, 15);
            this.lAnnouncementsUnits.TabIndex = 2;
            this.lAnnouncementsUnits.Text = "min";
            // 
            // nAnnouncements
            // 
            this.nAnnouncements.Enabled = false;
            this.nAnnouncements.Location = new System.Drawing.Point(210, 25);
            this.nAnnouncements.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nAnnouncements.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nAnnouncements.Name = "nAnnouncements";
            this.nAnnouncements.Size = new System.Drawing.Size(50, 21);
            this.nAnnouncements.TabIndex = 1;
            this.nAnnouncements.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // xAnnouncements
            // 
            this.xAnnouncements.AutoSize = true;
            this.xAnnouncements.BackColor = System.Drawing.Color.Firebrick;
            this.xAnnouncements.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.xAnnouncements.Location = new System.Drawing.Point(24, 26);
            this.xAnnouncements.Name = "xAnnouncements";
            this.xAnnouncements.Size = new System.Drawing.Size(186, 20);
            this.xAnnouncements.TabIndex = 0;
            this.xAnnouncements.Text = "Show announcements every";
            this.xAnnouncements.UseVisualStyleBackColor = false;
            this.xAnnouncements.CheckedChanged += new System.EventHandler(this.xAnnouncements_CheckedChanged);
            // 
            // bRules
            // 
            this.bRules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bRules.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bRules.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bRules.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.bRules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bRules.Location = new System.Drawing.Point(445, 20);
            this.bRules.Name = "bRules";
            this.bRules.Size = new System.Drawing.Size(87, 28);
            this.bRules.TabIndex = 4;
            this.bRules.Text = "Edit Rules";
            this.bRules.UseVisualStyleBackColor = false;
            this.bRules.Click += new System.EventHandler(this.bRules_Click);
            // 
            // bAnnouncements
            // 
            this.bAnnouncements.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bAnnouncements.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bAnnouncements.Enabled = false;
            this.bAnnouncements.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bAnnouncements.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.bAnnouncements.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAnnouncements.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAnnouncements.Location = new System.Drawing.Point(301, 20);
            this.bAnnouncements.Name = "bAnnouncements";
            this.bAnnouncements.Size = new System.Drawing.Size(138, 28);
            this.bAnnouncements.TabIndex = 3;
            this.bAnnouncements.Text = "Edit Announcements";
            this.bAnnouncements.UseVisualStyleBackColor = false;
            this.bAnnouncements.Click += new System.EventHandler(this.bAnnouncements_Click);
            // 
            // tabChat
            // 
            this.tabChat.BackColor = System.Drawing.Color.RosyBrown;
            this.tabChat.Controls.Add(this.chatPreview);
            this.tabChat.Controls.Add(this.gAppearence);
            this.tabChat.Controls.Add(this.gChatColors);
            this.tabChat.Location = new System.Drawing.Point(4, 24);
            this.tabChat.Name = "tabChat";
            this.tabChat.Padding = new System.Windows.Forms.Padding(5, 5, 5, 10);
            this.tabChat.Size = new System.Drawing.Size(652, 482);
            this.tabChat.TabIndex = 10;
            this.tabChat.Text = "Chat";
            // 
            // chatPreview
            // 
            this.chatPreview.Location = new System.Drawing.Point(8, 256);
            this.chatPreview.Name = "chatPreview";
            this.chatPreview.Size = new System.Drawing.Size(636, 213);
            this.chatPreview.TabIndex = 2;
            // 
            // gAppearence
            // 
            this.gAppearence.Controls.Add(this.xShowConnectionMessages);
            this.gAppearence.Controls.Add(this.xShowJoinedWorldMessages);
            this.gAppearence.Controls.Add(this.xRankColorsInWorldNames);
            this.gAppearence.Controls.Add(this.xRankPrefixesInList);
            this.gAppearence.Controls.Add(this.xRankPrefixesInChat);
            this.gAppearence.Controls.Add(this.xRankColorsInChat);
            this.gAppearence.Location = new System.Drawing.Point(7, 153);
            this.gAppearence.Name = "gAppearence";
            this.gAppearence.Size = new System.Drawing.Size(637, 97);
            this.gAppearence.TabIndex = 1;
            this.gAppearence.TabStop = false;
            this.gAppearence.Text = "Appearence Tweaks";
            // 
            // xShowConnectionMessages
            // 
            this.xShowConnectionMessages.AutoSize = true;
            this.xShowConnectionMessages.Location = new System.Drawing.Point(325, 45);
            this.xShowConnectionMessages.Name = "xShowConnectionMessages";
            this.xShowConnectionMessages.Size = new System.Drawing.Size(306, 19);
            this.xShowConnectionMessages.TabIndex = 4;
            this.xShowConnectionMessages.Text = "Show a message when players join/leave SERVER.";
            this.xShowConnectionMessages.UseVisualStyleBackColor = true;
            // 
            // xShowJoinedWorldMessages
            // 
            this.xShowJoinedWorldMessages.AutoSize = true;
            this.xShowJoinedWorldMessages.Location = new System.Drawing.Point(325, 20);
            this.xShowJoinedWorldMessages.Name = "xShowJoinedWorldMessages";
            this.xShowJoinedWorldMessages.Size = new System.Drawing.Size(261, 19);
            this.xShowJoinedWorldMessages.TabIndex = 3;
            this.xShowJoinedWorldMessages.Text = "Show a message when players join worlds.";
            this.xShowJoinedWorldMessages.UseVisualStyleBackColor = true;
            // 
            // xRankColorsInWorldNames
            // 
            this.xRankColorsInWorldNames.AutoSize = true;
            this.xRankColorsInWorldNames.Location = new System.Drawing.Point(325, 70);
            this.xRankColorsInWorldNames.Name = "xRankColorsInWorldNames";
            this.xRankColorsInWorldNames.Size = new System.Drawing.Size(243, 19);
            this.xRankColorsInWorldNames.TabIndex = 5;
            this.xRankColorsInWorldNames.Text = "Color world names based on build rank.";
            this.xRankColorsInWorldNames.UseVisualStyleBackColor = true;
            // 
            // xRankPrefixesInList
            // 
            this.xRankPrefixesInList.AutoSize = true;
            this.xRankPrefixesInList.Location = new System.Drawing.Point(44, 70);
            this.xRankPrefixesInList.Name = "xRankPrefixesInList";
            this.xRankPrefixesInList.Size = new System.Drawing.Size(219, 19);
            this.xRankPrefixesInList.TabIndex = 2;
            this.xRankPrefixesInList.Text = "Prefixes in player list (breaks skins).";
            this.xRankPrefixesInList.UseVisualStyleBackColor = true;
            // 
            // xRankPrefixesInChat
            // 
            this.xRankPrefixesInChat.AutoSize = true;
            this.xRankPrefixesInChat.Location = new System.Drawing.Point(25, 45);
            this.xRankPrefixesInChat.Name = "xRankPrefixesInChat";
            this.xRankPrefixesInChat.Size = new System.Drawing.Size(133, 19);
            this.xRankPrefixesInChat.TabIndex = 1;
            this.xRankPrefixesInChat.Text = "Show rank prefixes.";
            this.xRankPrefixesInChat.UseVisualStyleBackColor = true;
            this.xRankPrefixesInChat.CheckedChanged += new System.EventHandler(this.xRankPrefixesInChat_CheckedChanged);
            // 
            // xRankColorsInChat
            // 
            this.xRankColorsInChat.AutoSize = true;
            this.xRankColorsInChat.Location = new System.Drawing.Point(25, 20);
            this.xRankColorsInChat.Name = "xRankColorsInChat";
            this.xRankColorsInChat.Size = new System.Drawing.Size(123, 19);
            this.xRankColorsInChat.TabIndex = 0;
            this.xRankColorsInChat.Text = "Show rank colors.";
            this.xRankColorsInChat.UseVisualStyleBackColor = true;
            // 
            // gChatColors
            // 
            this.gChatColors.BackColor = System.Drawing.Color.RosyBrown;
            this.gChatColors.Controls.Add(this.lColorMe);
            this.gChatColors.Controls.Add(this.bColorGlobal);
            this.gChatColors.Controls.Add(this.bColorMe);
            this.gChatColors.Controls.Add(this.lColorWarning);
            this.gChatColors.Controls.Add(this.bColorWarning);
            this.gChatColors.Controls.Add(this.bColorSys);
            this.gChatColors.Controls.Add(this.lColorSys);
            this.gChatColors.Controls.Add(this.bColorPM);
            this.gChatColors.Controls.Add(this.lColorHelp);
            this.gChatColors.Controls.Add(this.lColorPM);
            this.gChatColors.Controls.Add(this.IColorGlobal);
            this.gChatColors.Controls.Add(this.lColorSay);
            this.gChatColors.Controls.Add(this.bColorAnnouncement);
            this.gChatColors.Controls.Add(this.lColorAnnouncement);
            this.gChatColors.Controls.Add(this.bColorHelp);
            this.gChatColors.Controls.Add(this.bColorSay);
            this.gChatColors.Location = new System.Drawing.Point(8, 8);
            this.gChatColors.Name = "gChatColors";
            this.gChatColors.Size = new System.Drawing.Size(636, 139);
            this.gChatColors.TabIndex = 0;
            this.gChatColors.TabStop = false;
            this.gChatColors.Text = "Colors";
            // 
            // lColorMe
            // 
            this.lColorMe.AutoSize = true;
            this.lColorMe.Location = new System.Drawing.Point(402, 82);
            this.lColorMe.Name = "lColorMe";
            this.lColorMe.Size = new System.Drawing.Size(117, 15);
            this.lColorMe.TabIndex = 12;
            this.lColorMe.Text = "/Me command color";
            // 
            // bColorGlobal
            // 
            this.bColorGlobal.BackColor = System.Drawing.Color.White;
            this.bColorGlobal.Location = new System.Drawing.Point(525, 111);
            this.bColorGlobal.Name = "bColorGlobal";
            this.bColorGlobal.Size = new System.Drawing.Size(100, 23);
            this.bColorGlobal.TabIndex = 13;
            this.bColorGlobal.UseVisualStyleBackColor = false;
            this.bColorGlobal.Click += new System.EventHandler(this.bColorGlobal_Click);
            // 
            // bColorMe
            // 
            this.bColorMe.BackColor = System.Drawing.Color.White;
            this.bColorMe.Location = new System.Drawing.Point(525, 78);
            this.bColorMe.Name = "bColorMe";
            this.bColorMe.Size = new System.Drawing.Size(100, 23);
            this.bColorMe.TabIndex = 13;
            this.bColorMe.UseVisualStyleBackColor = false;
            this.bColorMe.Click += new System.EventHandler(this.bColorMe_Click);
            // 
            // lColorWarning
            // 
            this.lColorWarning.AutoSize = true;
            this.lColorWarning.Location = new System.Drawing.Point(69, 53);
            this.lColorWarning.Name = "lColorWarning";
            this.lColorWarning.Size = new System.Drawing.Size(118, 15);
            this.lColorWarning.TabIndex = 2;
            this.lColorWarning.Text = "Warning / error color";
            // 
            // bColorWarning
            // 
            this.bColorWarning.BackColor = System.Drawing.Color.White;
            this.bColorWarning.Location = new System.Drawing.Point(193, 49);
            this.bColorWarning.Name = "bColorWarning";
            this.bColorWarning.Size = new System.Drawing.Size(100, 23);
            this.bColorWarning.TabIndex = 3;
            this.bColorWarning.UseVisualStyleBackColor = false;
            this.bColorWarning.Click += new System.EventHandler(this.bColorWarning_Click);
            // 
            // bColorSys
            // 
            this.bColorSys.BackColor = System.Drawing.Color.White;
            this.bColorSys.Location = new System.Drawing.Point(193, 20);
            this.bColorSys.Name = "bColorSys";
            this.bColorSys.Size = new System.Drawing.Size(100, 23);
            this.bColorSys.TabIndex = 1;
            this.bColorSys.UseVisualStyleBackColor = false;
            this.bColorSys.Click += new System.EventHandler(this.bColorSys_Click);
            // 
            // lColorSys
            // 
            this.lColorSys.AutoSize = true;
            this.lColorSys.Location = new System.Drawing.Point(56, 24);
            this.lColorSys.Name = "lColorSys";
            this.lColorSys.Size = new System.Drawing.Size(131, 15);
            this.lColorSys.TabIndex = 0;
            this.lColorSys.Text = "System message color";
            // 
            // bColorPM
            // 
            this.bColorPM.BackColor = System.Drawing.Color.White;
            this.bColorPM.Location = new System.Drawing.Point(193, 78);
            this.bColorPM.Name = "bColorPM";
            this.bColorPM.Size = new System.Drawing.Size(100, 23);
            this.bColorPM.TabIndex = 5;
            this.bColorPM.UseVisualStyleBackColor = false;
            this.bColorPM.Click += new System.EventHandler(this.bColorPM_Click);
            // 
            // lColorHelp
            // 
            this.lColorHelp.AutoSize = true;
            this.lColorHelp.Location = new System.Drawing.Point(70, 111);
            this.lColorHelp.Name = "lColorHelp";
            this.lColorHelp.Size = new System.Drawing.Size(117, 15);
            this.lColorHelp.TabIndex = 6;
            this.lColorHelp.Text = "Help message color";
            // 
            // lColorPM
            // 
            this.lColorPM.AutoSize = true;
            this.lColorPM.Location = new System.Drawing.Point(26, 82);
            this.lColorPM.Name = "lColorPM";
            this.lColorPM.Size = new System.Drawing.Size(161, 15);
            this.lColorPM.TabIndex = 4;
            this.lColorPM.Text = "Private / rank message color";
            // 
            // IColorGlobal
            // 
            this.IColorGlobal.AutoSize = true;
            this.IColorGlobal.Location = new System.Drawing.Point(402, 111);
            this.IColorGlobal.Name = "IColorGlobal";
            this.IColorGlobal.Size = new System.Drawing.Size(103, 15);
            this.IColorGlobal.TabIndex = 10;
            this.IColorGlobal.Text = "Global Chat Color";
            // 
            // lColorSay
            // 
            this.lColorSay.AutoSize = true;
            this.lColorSay.Location = new System.Drawing.Point(407, 53);
            this.lColorSay.Name = "lColorSay";
            this.lColorSay.Size = new System.Drawing.Size(114, 15);
            this.lColorSay.TabIndex = 10;
            this.lColorSay.Text = "/Say message color";
            // 
            // bColorAnnouncement
            // 
            this.bColorAnnouncement.BackColor = System.Drawing.Color.White;
            this.bColorAnnouncement.Location = new System.Drawing.Point(525, 20);
            this.bColorAnnouncement.Name = "bColorAnnouncement";
            this.bColorAnnouncement.Size = new System.Drawing.Size(100, 23);
            this.bColorAnnouncement.TabIndex = 9;
            this.bColorAnnouncement.UseVisualStyleBackColor = false;
            this.bColorAnnouncement.Click += new System.EventHandler(this.bColorAnnouncement_Click);
            // 
            // lColorAnnouncement
            // 
            this.lColorAnnouncement.AutoSize = true;
            this.lColorAnnouncement.Location = new System.Drawing.Point(342, 24);
            this.lColorAnnouncement.Name = "lColorAnnouncement";
            this.lColorAnnouncement.Size = new System.Drawing.Size(182, 15);
            this.lColorAnnouncement.TabIndex = 8;
            this.lColorAnnouncement.Text = "Announcement and /Rules color";
            // 
            // bColorHelp
            // 
            this.bColorHelp.BackColor = System.Drawing.Color.White;
            this.bColorHelp.Location = new System.Drawing.Point(193, 107);
            this.bColorHelp.Name = "bColorHelp";
            this.bColorHelp.Size = new System.Drawing.Size(100, 23);
            this.bColorHelp.TabIndex = 7;
            this.bColorHelp.UseVisualStyleBackColor = false;
            this.bColorHelp.Click += new System.EventHandler(this.bColorHelp_Click);
            // 
            // bColorSay
            // 
            this.bColorSay.BackColor = System.Drawing.Color.White;
            this.bColorSay.Location = new System.Drawing.Point(525, 49);
            this.bColorSay.Name = "bColorSay";
            this.bColorSay.Size = new System.Drawing.Size(100, 23);
            this.bColorSay.TabIndex = 11;
            this.bColorSay.UseVisualStyleBackColor = false;
            this.bColorSay.Click += new System.EventHandler(this.bColorSay_Click);
            // 
            // tabWorlds
            // 
            this.tabWorlds.BackColor = System.Drawing.Color.Pink;
            this.tabWorlds.Controls.Add(this.xWoMEnableEnvExtensions);
            this.tabWorlds.Controls.Add(this.bMapPath);
            this.tabWorlds.Controls.Add(this.xMapPath);
            this.tabWorlds.Controls.Add(this.tMapPath);
            this.tabWorlds.Controls.Add(this.lDefaultBuildRank);
            this.tabWorlds.Controls.Add(this.cDefaultBuildRank);
            this.tabWorlds.Controls.Add(this.cMainWorld);
            this.tabWorlds.Controls.Add(this.lMainWorld);
            this.tabWorlds.Controls.Add(this.bWorldEdit);
            this.tabWorlds.Controls.Add(this.bAddWorld);
            this.tabWorlds.Controls.Add(this.bWorldDelete);
            this.tabWorlds.Controls.Add(this.dgvWorlds);
            this.tabWorlds.Location = new System.Drawing.Point(4, 24);
            this.tabWorlds.Name = "tabWorlds";
            this.tabWorlds.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.tabWorlds.Size = new System.Drawing.Size(652, 482);
            this.tabWorlds.TabIndex = 9;
            this.tabWorlds.Text = "Worlds";
            // 
            // xWoMEnableEnvExtensions
            // 
            this.xWoMEnableEnvExtensions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.xWoMEnableEnvExtensions.AutoSize = true;
            this.xWoMEnableEnvExtensions.Location = new System.Drawing.Point(8, 436);
            this.xWoMEnableEnvExtensions.Name = "xWoMEnableEnvExtensions";
            this.xWoMEnableEnvExtensions.Size = new System.Drawing.Size(185, 19);
            this.xWoMEnableEnvExtensions.TabIndex = 22;
            this.xWoMEnableEnvExtensions.Text = "Enable Env Extensions (/Env)";
            this.xWoMEnableEnvExtensions.UseVisualStyleBackColor = true;
            // 
            // bMapPath
            // 
            this.bMapPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bMapPath.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bMapPath.Enabled = false;
            this.bMapPath.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bMapPath.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.bMapPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bMapPath.Location = new System.Drawing.Point(587, 409);
            this.bMapPath.Name = "bMapPath";
            this.bMapPath.Size = new System.Drawing.Size(62, 23);
            this.bMapPath.TabIndex = 10;
            this.bMapPath.Text = "Browse";
            this.bMapPath.UseVisualStyleBackColor = false;
            this.bMapPath.Click += new System.EventHandler(this.bMapPath_Click);
            // 
            // xMapPath
            // 
            this.xMapPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.xMapPath.AutoSize = true;
            this.xMapPath.Location = new System.Drawing.Point(8, 409);
            this.xMapPath.Name = "xMapPath";
            this.xMapPath.Size = new System.Drawing.Size(189, 19);
            this.xMapPath.TabIndex = 8;
            this.xMapPath.Text = "Custom path for storing maps:";
            this.xMapPath.UseVisualStyleBackColor = true;
            this.xMapPath.CheckedChanged += new System.EventHandler(this.xMapPath_CheckedChanged);
            // 
            // tMapPath
            // 
            this.tMapPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tMapPath.Enabled = false;
            this.tMapPath.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tMapPath.Location = new System.Drawing.Point(203, 411);
            this.tMapPath.Name = "tMapPath";
            this.tMapPath.Size = new System.Drawing.Size(378, 19);
            this.tMapPath.TabIndex = 9;
            // 
            // lDefaultBuildRank
            // 
            this.lDefaultBuildRank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lDefaultBuildRank.AutoSize = true;
            this.lDefaultBuildRank.Location = new System.Drawing.Point(24, 381);
            this.lDefaultBuildRank.Name = "lDefaultBuildRank";
            this.lDefaultBuildRank.Size = new System.Drawing.Size(342, 15);
            this.lDefaultBuildRank.TabIndex = 6;
            this.lDefaultBuildRank.Text = "Default rank requirement for building on newly-loaded worlds:";
            // 
            // cDefaultBuildRank
            // 
            this.cDefaultBuildRank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cDefaultBuildRank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cDefaultBuildRank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cDefaultBuildRank.FormattingEnabled = true;
            this.cDefaultBuildRank.Location = new System.Drawing.Point(372, 378);
            this.cDefaultBuildRank.Name = "cDefaultBuildRank";
            this.cDefaultBuildRank.Size = new System.Drawing.Size(121, 23);
            this.cDefaultBuildRank.TabIndex = 7;
            this.cDefaultBuildRank.SelectedIndexChanged += new System.EventHandler(this.cDefaultBuildRank_SelectedIndexChanged);
            // 
            // cMainWorld
            // 
            this.cMainWorld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cMainWorld.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cMainWorld.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cMainWorld.Location = new System.Drawing.Point(542, 17);
            this.cMainWorld.Name = "cMainWorld";
            this.cMainWorld.Size = new System.Drawing.Size(102, 23);
            this.cMainWorld.TabIndex = 5;
            // 
            // lMainWorld
            // 
            this.lMainWorld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lMainWorld.AutoSize = true;
            this.lMainWorld.Location = new System.Drawing.Point(465, 20);
            this.lMainWorld.Name = "lMainWorld";
            this.lMainWorld.Size = new System.Drawing.Size(71, 15);
            this.lMainWorld.TabIndex = 4;
            this.lMainWorld.Text = "Main world:";
            // 
            // bWorldEdit
            // 
            this.bWorldEdit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bWorldEdit.Enabled = false;
            this.bWorldEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bWorldEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.bWorldEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bWorldEdit.Location = new System.Drawing.Point(114, 13);
            this.bWorldEdit.Name = "bWorldEdit";
            this.bWorldEdit.Size = new System.Drawing.Size(100, 28);
            this.bWorldEdit.TabIndex = 2;
            this.bWorldEdit.Text = "Edit";
            this.bWorldEdit.UseVisualStyleBackColor = false;
            this.bWorldEdit.Click += new System.EventHandler(this.bWorldEdit_Click);
            // 
            // bAddWorld
            // 
            this.bAddWorld.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bAddWorld.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bAddWorld.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.bAddWorld.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAddWorld.Location = new System.Drawing.Point(8, 13);
            this.bAddWorld.Name = "bAddWorld";
            this.bAddWorld.Size = new System.Drawing.Size(100, 28);
            this.bAddWorld.TabIndex = 1;
            this.bAddWorld.Text = "Add World";
            this.bAddWorld.UseVisualStyleBackColor = false;
            this.bAddWorld.Click += new System.EventHandler(this.bAddWorld_Click);
            // 
            // bWorldDelete
            // 
            this.bWorldDelete.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bWorldDelete.Enabled = false;
            this.bWorldDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bWorldDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.bWorldDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bWorldDelete.Location = new System.Drawing.Point(220, 13);
            this.bWorldDelete.Name = "bWorldDelete";
            this.bWorldDelete.Size = new System.Drawing.Size(100, 28);
            this.bWorldDelete.TabIndex = 3;
            this.bWorldDelete.Text = "Delete World";
            this.bWorldDelete.UseVisualStyleBackColor = false;
            this.bWorldDelete.Click += new System.EventHandler(this.bWorldDel_Click);
            // 
            // dgvWorlds
            // 
            this.dgvWorlds.AllowUserToAddRows = false;
            this.dgvWorlds.AllowUserToDeleteRows = false;
            this.dgvWorlds.AllowUserToOrderColumns = true;
            this.dgvWorlds.AllowUserToResizeRows = false;
            this.dgvWorlds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvWorlds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorlds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcName,
            this.dgvcDescription,
            this.dgvcAccess,
            this.dgvcBuild,
            this.dgvcBackup,
            this.dgvcHidden,
            this.dgvcBlockDB});
            this.dgvWorlds.Location = new System.Drawing.Point(8, 47);
            this.dgvWorlds.MultiSelect = false;
            this.dgvWorlds.Name = "dgvWorlds";
            this.dgvWorlds.RowHeadersVisible = false;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.dgvWorlds.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvWorlds.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWorlds.Size = new System.Drawing.Size(636, 325);
            this.dgvWorlds.TabIndex = 0;
            this.dgvWorlds.SelectionChanged += new System.EventHandler(this.dgvWorlds_Click);
            this.dgvWorlds.Click += new System.EventHandler(this.dgvWorlds_Click);
            // 
            // dgvcName
            // 
            this.dgvcName.DataPropertyName = "Name";
            this.dgvcName.HeaderText = "World Name";
            this.dgvcName.Name = "dgvcName";
            this.dgvcName.Width = 110;
            // 
            // dgvcDescription
            // 
            this.dgvcDescription.DataPropertyName = "Description";
            this.dgvcDescription.HeaderText = "";
            this.dgvcDescription.Name = "dgvcDescription";
            this.dgvcDescription.ReadOnly = true;
            this.dgvcDescription.Width = 130;
            // 
            // dgvcAccess
            // 
            this.dgvcAccess.DataPropertyName = "AccessPermission";
            this.dgvcAccess.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.dgvcAccess.HeaderText = "Access";
            this.dgvcAccess.Name = "dgvcAccess";
            this.dgvcAccess.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgvcBuild
            // 
            this.dgvcBuild.DataPropertyName = "BuildPermission";
            this.dgvcBuild.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.dgvcBuild.HeaderText = "Build";
            this.dgvcBuild.Name = "dgvcBuild";
            this.dgvcBuild.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgvcBackup
            // 
            this.dgvcBackup.DataPropertyName = "Backup";
            this.dgvcBackup.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.dgvcBackup.HeaderText = "Backup";
            this.dgvcBackup.Name = "dgvcBackup";
            this.dgvcBackup.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvcBackup.Width = 90;
            // 
            // dgvcHidden
            // 
            this.dgvcHidden.DataPropertyName = "Hidden";
            this.dgvcHidden.HeaderText = "Hide";
            this.dgvcHidden.Name = "dgvcHidden";
            this.dgvcHidden.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvcHidden.Width = 40;
            // 
            // dgvcBlockDB
            // 
            this.dgvcBlockDB.DataPropertyName = "BlockDBEnabled";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvcBlockDB.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvcBlockDB.HeaderText = "BlockDB";
            this.dgvcBlockDB.Name = "dgvcBlockDB";
            this.dgvcBlockDB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvcBlockDB.ThreeState = true;
            this.dgvcBlockDB.Width = 60;
            // 
            // tabRanks
            // 
            this.tabRanks.BackColor = System.Drawing.Color.Yellow;
            this.tabRanks.Controls.Add(this.gPermissionLimits);
            this.tabRanks.Controls.Add(this.lRankList);
            this.tabRanks.Controls.Add(this.bLowerRank);
            this.tabRanks.Controls.Add(this.bRaiseRank);
            this.tabRanks.Controls.Add(this.gRankOptions);
            this.tabRanks.Controls.Add(this.bDeleteRank);
            this.tabRanks.Controls.Add(this.vPermissions);
            this.tabRanks.Controls.Add(this.bAddRank);
            this.tabRanks.Controls.Add(this.lPermissions);
            this.tabRanks.Controls.Add(this.vRanks);
            this.tabRanks.Location = new System.Drawing.Point(4, 24);
            this.tabRanks.Name = "tabRanks";
            this.tabRanks.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.tabRanks.Size = new System.Drawing.Size(652, 482);
            this.tabRanks.TabIndex = 2;
            this.tabRanks.Text = "Ranks";
            // 
            // gPermissionLimits
            // 
            this.gPermissionLimits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gPermissionLimits.Controls.Add(this.permissionLimitBoxContainer);
            this.gPermissionLimits.Location = new System.Drawing.Point(160, 292);
            this.gPermissionLimits.Name = "gPermissionLimits";
            this.gPermissionLimits.Size = new System.Drawing.Size(307, 186);
            this.gPermissionLimits.TabIndex = 7;
            this.gPermissionLimits.TabStop = false;
            this.gPermissionLimits.Text = "Permission Limits";
            // 
            // permissionLimitBoxContainer
            // 
            this.permissionLimitBoxContainer.AutoScroll = true;
            this.permissionLimitBoxContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.permissionLimitBoxContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.permissionLimitBoxContainer.Location = new System.Drawing.Point(3, 17);
            this.permissionLimitBoxContainer.Margin = new System.Windows.Forms.Padding(0);
            this.permissionLimitBoxContainer.Name = "permissionLimitBoxContainer";
            this.permissionLimitBoxContainer.Size = new System.Drawing.Size(301, 166);
            this.permissionLimitBoxContainer.TabIndex = 0;
            this.permissionLimitBoxContainer.WrapContents = false;
            // 
            // lRankList
            // 
            this.lRankList.AutoSize = true;
            this.lRankList.Location = new System.Drawing.Point(8, 10);
            this.lRankList.Name = "lRankList";
            this.lRankList.Size = new System.Drawing.Size(58, 15);
            this.lRankList.TabIndex = 0;
            this.lRankList.Text = "Rank List";
            // 
            // bLowerRank
            // 
            this.bLowerRank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bLowerRank.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bLowerRank.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bLowerRank.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.bLowerRank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bLowerRank.Location = new System.Drawing.Point(84, 455);
            this.bLowerRank.Name = "bLowerRank";
            this.bLowerRank.Size = new System.Drawing.Size(70, 23);
            this.bLowerRank.TabIndex = 5;
            this.bLowerRank.Text = "▼ Lower";
            this.bLowerRank.UseVisualStyleBackColor = false;
            this.bLowerRank.Click += new System.EventHandler(this.bLowerRank_Click);
            // 
            // bRaiseRank
            // 
            this.bRaiseRank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bRaiseRank.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bRaiseRank.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bRaiseRank.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.bRaiseRank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bRaiseRank.Location = new System.Drawing.Point(8, 455);
            this.bRaiseRank.Name = "bRaiseRank";
            this.bRaiseRank.Size = new System.Drawing.Size(70, 23);
            this.bRaiseRank.TabIndex = 4;
            this.bRaiseRank.Text = "▲ Raise";
            this.bRaiseRank.UseVisualStyleBackColor = false;
            this.bRaiseRank.Click += new System.EventHandler(this.bRaiseRank_Click);
            // 
            // gRankOptions
            // 
            this.gRankOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gRankOptions.Controls.Add(this.lFillLimitUnits);
            this.gRankOptions.Controls.Add(this.nFillLimit);
            this.gRankOptions.Controls.Add(this.lFillLimit);
            this.gRankOptions.Controls.Add(this.nCopyPasteSlots);
            this.gRankOptions.Controls.Add(this.lCopyPasteSlots);
            this.gRankOptions.Controls.Add(this.xAllowSecurityCircumvention);
            this.gRankOptions.Controls.Add(this.lAntiGrief1);
            this.gRankOptions.Controls.Add(this.lAntiGrief3);
            this.gRankOptions.Controls.Add(this.nAntiGriefSeconds);
            this.gRankOptions.Controls.Add(this.bColorRank);
            this.gRankOptions.Controls.Add(this.xDrawLimit);
            this.gRankOptions.Controls.Add(this.lDrawLimitUnits);
            this.gRankOptions.Controls.Add(this.lKickIdleUnits);
            this.gRankOptions.Controls.Add(this.nDrawLimit);
            this.gRankOptions.Controls.Add(this.nKickIdle);
            this.gRankOptions.Controls.Add(this.xAntiGrief);
            this.gRankOptions.Controls.Add(this.lAntiGrief2);
            this.gRankOptions.Controls.Add(this.xKickIdle);
            this.gRankOptions.Controls.Add(this.nAntiGriefBlocks);
            this.gRankOptions.Controls.Add(this.xReserveSlot);
            this.gRankOptions.Controls.Add(this.tPrefix);
            this.gRankOptions.Controls.Add(this.lPrefix);
            this.gRankOptions.Controls.Add(this.lRankColor);
            this.gRankOptions.Controls.Add(this.tRankName);
            this.gRankOptions.Controls.Add(this.lRankName);
            this.gRankOptions.Location = new System.Drawing.Point(160, 13);
            this.gRankOptions.Name = "gRankOptions";
            this.gRankOptions.Size = new System.Drawing.Size(307, 273);
            this.gRankOptions.TabIndex = 6;
            this.gRankOptions.TabStop = false;
            this.gRankOptions.Text = "Rank Options";
            // 
            // lFillLimitUnits
            // 
            this.lFillLimitUnits.AutoSize = true;
            this.lFillLimitUnits.Location = new System.Drawing.Point(239, 245);
            this.lFillLimitUnits.Name = "lFillLimitUnits";
            this.lFillLimitUnits.Size = new System.Drawing.Size(42, 15);
            this.lFillLimitUnits.TabIndex = 24;
            this.lFillLimitUnits.Text = "blocks";
            // 
            // nFillLimit
            // 
            this.nFillLimit.Location = new System.Drawing.Point(174, 243);
            this.nFillLimit.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.nFillLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nFillLimit.Name = "nFillLimit";
            this.nFillLimit.Size = new System.Drawing.Size(59, 21);
            this.nFillLimit.TabIndex = 23;
            this.nFillLimit.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nFillLimit.ValueChanged += new System.EventHandler(this.nFillLimit_ValueChanged);
            // 
            // lFillLimit
            // 
            this.lFillLimit.AutoSize = true;
            this.lFillLimit.Location = new System.Drawing.Point(85, 245);
            this.lFillLimit.Name = "lFillLimit";
            this.lFillLimit.Size = new System.Drawing.Size(83, 15);
            this.lFillLimit.TabIndex = 22;
            this.lFillLimit.Text = "Flood-fill limit:";
            // 
            // nCopyPasteSlots
            // 
            this.nCopyPasteSlots.Location = new System.Drawing.Point(174, 216);
            this.nCopyPasteSlots.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nCopyPasteSlots.Name = "nCopyPasteSlots";
            this.nCopyPasteSlots.Size = new System.Drawing.Size(59, 21);
            this.nCopyPasteSlots.TabIndex = 21;
            this.nCopyPasteSlots.ValueChanged += new System.EventHandler(this.nCopyPasteSlots_ValueChanged);
            // 
            // lCopyPasteSlots
            // 
            this.lCopyPasteSlots.AutoSize = true;
            this.lCopyPasteSlots.Location = new System.Drawing.Point(50, 218);
            this.lCopyPasteSlots.Name = "lCopyPasteSlots";
            this.lCopyPasteSlots.Size = new System.Drawing.Size(118, 15);
            this.lCopyPasteSlots.TabIndex = 20;
            this.lCopyPasteSlots.Text = "Copy/paste slot limit:";
            // 
            // xAllowSecurityCircumvention
            // 
            this.xAllowSecurityCircumvention.AutoSize = true;
            this.xAllowSecurityCircumvention.Location = new System.Drawing.Point(12, 165);
            this.xAllowSecurityCircumvention.Name = "xAllowSecurityCircumvention";
            this.xAllowSecurityCircumvention.Size = new System.Drawing.Size(271, 19);
            this.xAllowSecurityCircumvention.TabIndex = 16;
            this.xAllowSecurityCircumvention.Text = "Allow removing own access/build restrictions.";
            this.xAllowSecurityCircumvention.UseVisualStyleBackColor = true;
            this.xAllowSecurityCircumvention.CheckedChanged += new System.EventHandler(this.xAllowSecurityCircumvention_CheckedChanged);
            // 
            // lAntiGrief1
            // 
            this.lAntiGrief1.AutoSize = true;
            this.lAntiGrief1.Location = new System.Drawing.Point(50, 135);
            this.lAntiGrief1.Name = "lAntiGrief1";
            this.lAntiGrief1.Size = new System.Drawing.Size(47, 15);
            this.lAntiGrief1.TabIndex = 11;
            this.lAntiGrief1.Text = "Kick on";
            // 
            // lAntiGrief3
            // 
            this.lAntiGrief3.AutoSize = true;
            this.lAntiGrief3.Location = new System.Drawing.Point(275, 135);
            this.lAntiGrief3.Name = "lAntiGrief3";
            this.lAntiGrief3.Size = new System.Drawing.Size(26, 15);
            this.lAntiGrief3.TabIndex = 15;
            this.lAntiGrief3.Text = "sec";
            // 
            // nAntiGriefSeconds
            // 
            this.nAntiGriefSeconds.Location = new System.Drawing.Point(229, 133);
            this.nAntiGriefSeconds.Name = "nAntiGriefSeconds";
            this.nAntiGriefSeconds.Size = new System.Drawing.Size(40, 21);
            this.nAntiGriefSeconds.TabIndex = 14;
            this.nAntiGriefSeconds.ValueChanged += new System.EventHandler(this.nAntiGriefSeconds_ValueChanged);
            // 
            // bColorRank
            // 
            this.bColorRank.BackColor = System.Drawing.Color.White;
            this.bColorRank.Location = new System.Drawing.Point(201, 47);
            this.bColorRank.Name = "bColorRank";
            this.bColorRank.Size = new System.Drawing.Size(100, 24);
            this.bColorRank.TabIndex = 6;
            this.bColorRank.UseVisualStyleBackColor = false;
            this.bColorRank.Click += new System.EventHandler(this.bColorRank_Click);
            // 
            // xDrawLimit
            // 
            this.xDrawLimit.AutoSize = true;
            this.xDrawLimit.Location = new System.Drawing.Point(12, 190);
            this.xDrawLimit.Name = "xDrawLimit";
            this.xDrawLimit.Size = new System.Drawing.Size(81, 19);
            this.xDrawLimit.TabIndex = 17;
            this.xDrawLimit.Text = "Draw limit";
            this.xDrawLimit.UseVisualStyleBackColor = true;
            this.xDrawLimit.CheckedChanged += new System.EventHandler(this.xDrawLimit_CheckedChanged);
            // 
            // lDrawLimitUnits
            // 
            this.lDrawLimitUnits.AutoSize = true;
            this.lDrawLimitUnits.Location = new System.Drawing.Point(172, 191);
            this.lDrawLimitUnits.Name = "lDrawLimitUnits";
            this.lDrawLimitUnits.Size = new System.Drawing.Size(42, 15);
            this.lDrawLimitUnits.TabIndex = 19;
            this.lDrawLimitUnits.Text = "blocks";
            // 
            // lKickIdleUnits
            // 
            this.lKickIdleUnits.AutoSize = true;
            this.lKickIdleUnits.Location = new System.Drawing.Point(181, 79);
            this.lKickIdleUnits.Name = "lKickIdleUnits";
            this.lKickIdleUnits.Size = new System.Drawing.Size(51, 15);
            this.lKickIdleUnits.TabIndex = 9;
            this.lKickIdleUnits.Text = "minutes";
            // 
            // nDrawLimit
            // 
            this.nDrawLimit.Increment = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.nDrawLimit.Location = new System.Drawing.Point(99, 189);
            this.nDrawLimit.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nDrawLimit.Name = "nDrawLimit";
            this.nDrawLimit.Size = new System.Drawing.Size(67, 21);
            this.nDrawLimit.TabIndex = 18;
            this.nDrawLimit.ValueChanged += new System.EventHandler(this.nDrawLimit_ValueChanged);
            // 
            // nKickIdle
            // 
            this.nKickIdle.Location = new System.Drawing.Point(116, 77);
            this.nKickIdle.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nKickIdle.Name = "nKickIdle";
            this.nKickIdle.Size = new System.Drawing.Size(59, 21);
            this.nKickIdle.TabIndex = 8;
            this.nKickIdle.ValueChanged += new System.EventHandler(this.nKickIdle_ValueChanged);
            // 
            // xAntiGrief
            // 
            this.xAntiGrief.AutoSize = true;
            this.xAntiGrief.Location = new System.Drawing.Point(12, 108);
            this.xAntiGrief.Name = "xAntiGrief";
            this.xAntiGrief.Size = new System.Drawing.Size(213, 19);
            this.xAntiGrief.TabIndex = 10;
            this.xAntiGrief.Text = "Enable grief / autoclicker detection";
            this.xAntiGrief.UseVisualStyleBackColor = true;
            this.xAntiGrief.CheckedChanged += new System.EventHandler(this.xAntiGrief_CheckedChanged);
            // 
            // lAntiGrief2
            // 
            this.lAntiGrief2.AutoSize = true;
            this.lAntiGrief2.Location = new System.Drawing.Point(168, 135);
            this.lAntiGrief2.Name = "lAntiGrief2";
            this.lAntiGrief2.Size = new System.Drawing.Size(55, 15);
            this.lAntiGrief2.TabIndex = 13;
            this.lAntiGrief2.Text = "blocks in";
            // 
            // xKickIdle
            // 
            this.xKickIdle.AutoSize = true;
            this.xKickIdle.Location = new System.Drawing.Point(12, 78);
            this.xKickIdle.Name = "xKickIdle";
            this.xKickIdle.Size = new System.Drawing.Size(98, 19);
            this.xKickIdle.TabIndex = 7;
            this.xKickIdle.Text = "Kick if idle for";
            this.xKickIdle.UseVisualStyleBackColor = true;
            this.xKickIdle.CheckedChanged += new System.EventHandler(this.xKickIdle_CheckedChanged);
            // 
            // nAntiGriefBlocks
            // 
            this.nAntiGriefBlocks.Location = new System.Drawing.Point(103, 133);
            this.nAntiGriefBlocks.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nAntiGriefBlocks.Name = "nAntiGriefBlocks";
            this.nAntiGriefBlocks.Size = new System.Drawing.Size(59, 21);
            this.nAntiGriefBlocks.TabIndex = 12;
            this.nAntiGriefBlocks.ValueChanged += new System.EventHandler(this.nAntiGriefBlocks_ValueChanged);
            // 
            // xReserveSlot
            // 
            this.xReserveSlot.AutoSize = true;
            this.xReserveSlot.Location = new System.Drawing.Point(12, 51);
            this.xReserveSlot.Name = "xReserveSlot";
            this.xReserveSlot.Size = new System.Drawing.Size(129, 19);
            this.xReserveSlot.TabIndex = 4;
            this.xReserveSlot.Text = "Reserve player slot";
            this.xReserveSlot.UseVisualStyleBackColor = true;
            this.xReserveSlot.CheckedChanged += new System.EventHandler(this.xReserveSlot_CheckedChanged);
            // 
            // tPrefix
            // 
            this.tPrefix.Enabled = false;
            this.tPrefix.Location = new System.Drawing.Point(279, 20);
            this.tPrefix.MaxLength = 1;
            this.tPrefix.Name = "tPrefix";
            this.tPrefix.Size = new System.Drawing.Size(22, 21);
            this.tPrefix.TabIndex = 3;
            this.tPrefix.Validating += new System.ComponentModel.CancelEventHandler(this.tPrefix_Validating);
            // 
            // lPrefix
            // 
            this.lPrefix.AutoSize = true;
            this.lPrefix.Enabled = false;
            this.lPrefix.Location = new System.Drawing.Point(235, 23);
            this.lPrefix.Name = "lPrefix";
            this.lPrefix.Size = new System.Drawing.Size(38, 15);
            this.lPrefix.TabIndex = 2;
            this.lPrefix.Text = "Prefix";
            // 
            // lRankColor
            // 
            this.lRankColor.AutoSize = true;
            this.lRankColor.Location = new System.Drawing.Point(159, 52);
            this.lRankColor.Name = "lRankColor";
            this.lRankColor.Size = new System.Drawing.Size(36, 15);
            this.lRankColor.TabIndex = 5;
            this.lRankColor.Text = "Color";
            // 
            // tRankName
            // 
            this.tRankName.Location = new System.Drawing.Point(62, 20);
            this.tRankName.MaxLength = 16;
            this.tRankName.Name = "tRankName";
            this.tRankName.Size = new System.Drawing.Size(143, 21);
            this.tRankName.TabIndex = 1;
            this.tRankName.Validating += new System.ComponentModel.CancelEventHandler(this.tRankName_Validating);
            // 
            // lRankName
            // 
            this.lRankName.AutoSize = true;
            this.lRankName.Location = new System.Drawing.Point(15, 23);
            this.lRankName.Name = "lRankName";
            this.lRankName.Size = new System.Drawing.Size(41, 15);
            this.lRankName.TabIndex = 0;
            this.lRankName.Text = "Name";
            // 
            // bDeleteRank
            // 
            this.bDeleteRank.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bDeleteRank.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bDeleteRank.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.bDeleteRank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bDeleteRank.Location = new System.Drawing.Point(84, 28);
            this.bDeleteRank.Name = "bDeleteRank";
            this.bDeleteRank.Size = new System.Drawing.Size(70, 23);
            this.bDeleteRank.TabIndex = 3;
            this.bDeleteRank.Text = "Delete";
            this.bDeleteRank.UseVisualStyleBackColor = false;
            this.bDeleteRank.Click += new System.EventHandler(this.bDeleteRank_Click);
            // 
            // vPermissions
            // 
            this.vPermissions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vPermissions.CheckBoxes = true;
            this.vPermissions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chPermissions});
            this.vPermissions.GridLines = true;
            this.vPermissions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.vPermissions.Location = new System.Drawing.Point(473, 28);
            this.vPermissions.MultiSelect = false;
            this.vPermissions.Name = "vPermissions";
            this.vPermissions.ShowGroups = false;
            this.vPermissions.ShowItemToolTips = true;
            this.vPermissions.Size = new System.Drawing.Size(171, 450);
            this.vPermissions.TabIndex = 9;
            this.vPermissions.UseCompatibleStateImageBehavior = false;
            this.vPermissions.View = System.Windows.Forms.View.Details;
            this.vPermissions.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.vPermissions_ItemChecked);
            // 
            // chPermissions
            // 
            this.chPermissions.Width = 150;
            // 
            // bAddRank
            // 
            this.bAddRank.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bAddRank.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bAddRank.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.bAddRank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAddRank.Location = new System.Drawing.Point(8, 28);
            this.bAddRank.Name = "bAddRank";
            this.bAddRank.Size = new System.Drawing.Size(70, 23);
            this.bAddRank.TabIndex = 2;
            this.bAddRank.Text = "Add Rank";
            this.bAddRank.UseVisualStyleBackColor = false;
            this.bAddRank.Click += new System.EventHandler(this.bAddRank_Click);
            // 
            // lPermissions
            // 
            this.lPermissions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lPermissions.AutoSize = true;
            this.lPermissions.Location = new System.Drawing.Point(473, 10);
            this.lPermissions.Name = "lPermissions";
            this.lPermissions.Size = new System.Drawing.Size(107, 15);
            this.lPermissions.TabIndex = 8;
            this.lPermissions.Text = "Rank Permissions";
            // 
            // vRanks
            // 
            this.vRanks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.vRanks.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vRanks.FormattingEnabled = true;
            this.vRanks.IntegralHeight = false;
            this.vRanks.ItemHeight = 15;
            this.vRanks.Location = new System.Drawing.Point(8, 57);
            this.vRanks.Name = "vRanks";
            this.vRanks.Size = new System.Drawing.Size(146, 392);
            this.vRanks.TabIndex = 1;
            this.vRanks.SelectedIndexChanged += new System.EventHandler(this.vRanks_SelectedIndexChanged);
            // 
            // tabCPE
            // 
            this.tabCPE.Controls.Add(this.gboHeldBlock);
            this.tabCPE.Controls.Add(this.gboClickDistance);
            this.tabCPE.Controls.Add(this.gboCustomBlocks);
            this.tabCPE.Controls.Add(this.gboMessageType);
            this.tabCPE.Location = new System.Drawing.Point(4, 24);
            this.tabCPE.Name = "tabCPE";
            this.tabCPE.Padding = new System.Windows.Forms.Padding(3);
            this.tabCPE.Size = new System.Drawing.Size(652, 482);
            this.tabCPE.TabIndex = 12;
            this.tabCPE.Text = "CPE";
            this.tabCPE.UseVisualStyleBackColor = true;
            // 
            // gboHeldBlock
            // 
            this.gboHeldBlock.Controls.Add(this.chkEnableHeldBlock);
            this.gboHeldBlock.Controls.Add(this.metroLabel2);
            this.gboHeldBlock.Location = new System.Drawing.Point(366, 215);
            this.gboHeldBlock.Name = "gboHeldBlock";
            this.gboHeldBlock.Size = new System.Drawing.Size(276, 85);
            this.gboHeldBlock.TabIndex = 35;
            this.gboHeldBlock.TabStop = false;
            this.gboHeldBlock.Text = "Held Block";
            // 
            // chkEnableHeldBlock
            // 
            this.chkEnableHeldBlock.AutoSize = true;
            this.chkEnableHeldBlock.Location = new System.Drawing.Point(6, 59);
            this.chkEnableHeldBlock.Margin = new System.Windows.Forms.Padding(2);
            this.chkEnableHeldBlock.Name = "chkEnableHeldBlock";
            this.chkEnableHeldBlock.Size = new System.Drawing.Size(127, 19);
            this.chkEnableHeldBlock.TabIndex = 34;
            this.chkEnableHeldBlock.Text = "Enable Held Block";
            // 
            // metroLabel2
            // 
            this.metroLabel2.Location = new System.Drawing.Point(6, 16);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(264, 47);
            this.metroLabel2.TabIndex = 33;
            this.metroLabel2.Text = "The ability to change/get a player\'s block type in hand";
            // 
            // gboClickDistance
            // 
            this.gboClickDistance.Controls.Add(this.numMaxDistance);
            this.gboClickDistance.Controls.Add(this.lblMaxDistance);
            this.gboClickDistance.Controls.Add(this.numMinDistance);
            this.gboClickDistance.Controls.Add(this.lblMinDistance);
            this.gboClickDistance.Controls.Add(this.chkEnableClickDistance);
            this.gboClickDistance.Controls.Add(this.metroLabel1);
            this.gboClickDistance.Location = new System.Drawing.Point(366, 59);
            this.gboClickDistance.Name = "gboClickDistance";
            this.gboClickDistance.Size = new System.Drawing.Size(276, 150);
            this.gboClickDistance.TabIndex = 34;
            this.gboClickDistance.TabStop = false;
            this.gboClickDistance.Text = "Click Distance";
            // 
            // numMaxDistance
            // 
            this.numMaxDistance.Location = new System.Drawing.Point(94, 123);
            this.numMaxDistance.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numMaxDistance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxDistance.Name = "numMaxDistance";
            this.numMaxDistance.Size = new System.Drawing.Size(55, 21);
            this.numMaxDistance.TabIndex = 37;
            this.numMaxDistance.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numMaxDistance.ValueChanged += new System.EventHandler(this.numMaxDistance_ValueChanged);
            // 
            // lblMaxDistance
            // 
            this.lblMaxDistance.AutoSize = true;
            this.lblMaxDistance.Location = new System.Drawing.Point(6, 128);
            this.lblMaxDistance.Name = "lblMaxDistance";
            this.lblMaxDistance.Size = new System.Drawing.Size(85, 15);
            this.lblMaxDistance.TabIndex = 36;
            this.lblMaxDistance.Text = "Max. Distance";
            // 
            // numMinDistance
            // 
            this.numMinDistance.Location = new System.Drawing.Point(94, 96);
            this.numMinDistance.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numMinDistance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMinDistance.Name = "numMinDistance";
            this.numMinDistance.Size = new System.Drawing.Size(55, 21);
            this.numMinDistance.TabIndex = 35;
            this.numMinDistance.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMinDistance.ValueChanged += new System.EventHandler(this.numMinDistance_ValueChanged);
            // 
            // lblMinDistance
            // 
            this.lblMinDistance.AutoSize = true;
            this.lblMinDistance.Location = new System.Drawing.Point(6, 102);
            this.lblMinDistance.Name = "lblMinDistance";
            this.lblMinDistance.Size = new System.Drawing.Size(82, 15);
            this.lblMinDistance.TabIndex = 34;
            this.lblMinDistance.Text = "Min. Distance";
            // 
            // chkEnableClickDistance
            // 
            this.chkEnableClickDistance.AutoSize = true;
            this.chkEnableClickDistance.Location = new System.Drawing.Point(6, 80);
            this.chkEnableClickDistance.Margin = new System.Windows.Forms.Padding(2);
            this.chkEnableClickDistance.Name = "chkEnableClickDistance";
            this.chkEnableClickDistance.Size = new System.Drawing.Size(145, 19);
            this.chkEnableClickDistance.TabIndex = 33;
            this.chkEnableClickDistance.Text = "Enable Click Distance";
            this.chkEnableClickDistance.CheckedChanged += new System.EventHandler(this.chkEnableClickDistance_CheckedChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.Location = new System.Drawing.Point(6, 19);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(264, 58);
            this.metroLabel1.TabIndex = 32;
            this.metroLabel1.Text = "How far and how short player\'s click distance can be set. Determines how many blo" +
    "cks away a player can click.";
            // 
            // gboCustomBlocks
            // 
            this.gboCustomBlocks.Controls.Add(this.btnDefineNewBlock);
            this.gboCustomBlocks.Location = new System.Drawing.Point(366, 6);
            this.gboCustomBlocks.Name = "gboCustomBlocks";
            this.gboCustomBlocks.Size = new System.Drawing.Size(276, 50);
            this.gboCustomBlocks.TabIndex = 32;
            this.gboCustomBlocks.TabStop = false;
            this.gboCustomBlocks.Text = "Custom Blocks";
            // 
            // btnDefineNewBlock
            // 
            this.btnDefineNewBlock.Location = new System.Drawing.Point(6, 19);
            this.btnDefineNewBlock.Name = "btnDefineNewBlock";
            this.btnDefineNewBlock.Size = new System.Drawing.Size(264, 23);
            this.btnDefineNewBlock.TabIndex = 0;
            this.btnDefineNewBlock.Text = "Define New Block";
            this.btnDefineNewBlock.UseVisualStyleBackColor = true;
            this.btnDefineNewBlock.Click += new System.EventHandler(this.btnDefineNewBlock_Click);
            // 
            // gboMessageType
            // 
            this.gboMessageType.Controls.Add(this.txtStatus1);
            this.gboMessageType.Controls.Add(this.txtStatus2);
            this.gboMessageType.Controls.Add(this.txtStatus3);
            this.gboMessageType.Controls.Add(this.txtBR3);
            this.gboMessageType.Controls.Add(this.txtBR2);
            this.gboMessageType.Controls.Add(this.txtBR1);
            this.gboMessageType.Controls.Add(this.chkBR1);
            this.gboMessageType.Controls.Add(this.chkBR2);
            this.gboMessageType.Controls.Add(this.chkBR3);
            this.gboMessageType.Controls.Add(this.chkStatus3);
            this.gboMessageType.Controls.Add(this.chkStatus2);
            this.gboMessageType.Controls.Add(this.chkStatus1);
            this.gboMessageType.Controls.Add(this.chkShowAnnouncements);
            this.gboMessageType.Controls.Add(this.chkEnableMessageTypes);
            this.gboMessageType.Controls.Add(this.lblMTInformation);
            this.gboMessageType.Location = new System.Drawing.Point(6, 6);
            this.gboMessageType.Name = "gboMessageType";
            this.gboMessageType.Size = new System.Drawing.Size(354, 314);
            this.gboMessageType.TabIndex = 29;
            this.gboMessageType.TabStop = false;
            this.gboMessageType.Text = "Message Types";
            // 
            // txtStatus1
            // 
            this.txtStatus1.Location = new System.Drawing.Point(207, 158);
            this.txtStatus1.Margin = new System.Windows.Forms.Padding(2);
            this.txtStatus1.Name = "txtStatus1";
            this.txtStatus1.Size = new System.Drawing.Size(135, 21);
            this.txtStatus1.TabIndex = 45;
            this.txtStatus1.Text = "metroTextBox6";
            this.txtStatus1.Visible = false;
            // 
            // txtStatus2
            // 
            this.txtStatus2.Location = new System.Drawing.Point(207, 182);
            this.txtStatus2.Margin = new System.Windows.Forms.Padding(2);
            this.txtStatus2.Name = "txtStatus2";
            this.txtStatus2.Size = new System.Drawing.Size(135, 21);
            this.txtStatus2.TabIndex = 44;
            this.txtStatus2.Text = "metroTextBox5";
            this.txtStatus2.Visible = false;
            // 
            // txtStatus3
            // 
            this.txtStatus3.Location = new System.Drawing.Point(207, 205);
            this.txtStatus3.Margin = new System.Windows.Forms.Padding(2);
            this.txtStatus3.Name = "txtStatus3";
            this.txtStatus3.Size = new System.Drawing.Size(135, 21);
            this.txtStatus3.TabIndex = 43;
            this.txtStatus3.Text = "metroTextBox4";
            this.txtStatus3.Visible = false;
            // 
            // txtBR3
            // 
            this.txtBR3.Location = new System.Drawing.Point(207, 236);
            this.txtBR3.Margin = new System.Windows.Forms.Padding(2);
            this.txtBR3.Name = "txtBR3";
            this.txtBR3.Size = new System.Drawing.Size(135, 21);
            this.txtBR3.TabIndex = 42;
            this.txtBR3.Text = "metroTextBox3";
            this.txtBR3.Visible = false;
            // 
            // txtBR2
            // 
            this.txtBR2.Location = new System.Drawing.Point(207, 260);
            this.txtBR2.Margin = new System.Windows.Forms.Padding(2);
            this.txtBR2.Name = "txtBR2";
            this.txtBR2.Size = new System.Drawing.Size(135, 21);
            this.txtBR2.TabIndex = 41;
            this.txtBR2.Text = "metroTextBox2";
            this.txtBR2.Visible = false;
            // 
            // txtBR1
            // 
            this.txtBR1.Location = new System.Drawing.Point(207, 283);
            this.txtBR1.Margin = new System.Windows.Forms.Padding(2);
            this.txtBR1.Name = "txtBR1";
            this.txtBR1.Size = new System.Drawing.Size(135, 21);
            this.txtBR1.TabIndex = 40;
            this.txtBR1.Text = "metroTextBox1";
            this.txtBR1.Visible = false;
            // 
            // chkBR1
            // 
            this.chkBR1.AutoSize = true;
            this.chkBR1.Location = new System.Drawing.Point(6, 288);
            this.chkBR1.Margin = new System.Windows.Forms.Padding(2);
            this.chkBR1.Name = "chkBR1";
            this.chkBR1.Size = new System.Drawing.Size(216, 19);
            this.chkBR1.TabIndex = 39;
            this.chkBR1.Text = "Enable Bottom Right #1 Messages";
            // 
            // chkBR2
            // 
            this.chkBR2.AutoSize = true;
            this.chkBR2.Location = new System.Drawing.Point(6, 265);
            this.chkBR2.Margin = new System.Windows.Forms.Padding(2);
            this.chkBR2.Name = "chkBR2";
            this.chkBR2.Size = new System.Drawing.Size(216, 19);
            this.chkBR2.TabIndex = 38;
            this.chkBR2.Text = "Enable Bottom Right #2 Messages";
            // 
            // chkBR3
            // 
            this.chkBR3.AutoSize = true;
            this.chkBR3.Location = new System.Drawing.Point(6, 241);
            this.chkBR3.Margin = new System.Windows.Forms.Padding(2);
            this.chkBR3.Name = "chkBR3";
            this.chkBR3.Size = new System.Drawing.Size(216, 19);
            this.chkBR3.TabIndex = 37;
            this.chkBR3.Text = "Enable Bottom Right #3 Messages";
            // 
            // chkStatus3
            // 
            this.chkStatus3.AutoSize = true;
            this.chkStatus3.Location = new System.Drawing.Point(6, 209);
            this.chkStatus3.Margin = new System.Windows.Forms.Padding(2);
            this.chkStatus3.Name = "chkStatus3";
            this.chkStatus3.Size = new System.Drawing.Size(198, 19);
            this.chkStatus3.TabIndex = 36;
            this.chkStatus3.Text = "Enable Top Right #3 Messages";
            // 
            // chkStatus2
            // 
            this.chkStatus2.AutoSize = true;
            this.chkStatus2.Location = new System.Drawing.Point(6, 186);
            this.chkStatus2.Margin = new System.Windows.Forms.Padding(2);
            this.chkStatus2.Name = "chkStatus2";
            this.chkStatus2.Size = new System.Drawing.Size(198, 19);
            this.chkStatus2.TabIndex = 35;
            this.chkStatus2.Text = "Enable Top Right #2 Messages";
            // 
            // chkStatus1
            // 
            this.chkStatus1.AutoSize = true;
            this.chkStatus1.Location = new System.Drawing.Point(6, 162);
            this.chkStatus1.Margin = new System.Windows.Forms.Padding(2);
            this.chkStatus1.Name = "chkStatus1";
            this.chkStatus1.Size = new System.Drawing.Size(198, 19);
            this.chkStatus1.TabIndex = 34;
            this.chkStatus1.Text = "Enable Top Right #1 Messages";
            // 
            // chkShowAnnouncements
            // 
            this.chkShowAnnouncements.AutoSize = true;
            this.chkShowAnnouncements.Location = new System.Drawing.Point(6, 93);
            this.chkShowAnnouncements.Margin = new System.Windows.Forms.Padding(2);
            this.chkShowAnnouncements.Name = "chkShowAnnouncements";
            this.chkShowAnnouncements.Size = new System.Drawing.Size(298, 19);
            this.chkShowAnnouncements.TabIndex = 33;
            this.chkShowAnnouncements.Text = "Show Server Announcements with MessageTypes";
            // 
            // chkEnableMessageTypes
            // 
            this.chkEnableMessageTypes.AutoSize = true;
            this.chkEnableMessageTypes.Location = new System.Drawing.Point(6, 75);
            this.chkEnableMessageTypes.Margin = new System.Windows.Forms.Padding(2);
            this.chkEnableMessageTypes.Name = "chkEnableMessageTypes";
            this.chkEnableMessageTypes.Size = new System.Drawing.Size(154, 19);
            this.chkEnableMessageTypes.TabIndex = 32;
            this.chkEnableMessageTypes.Text = "Enable Message Types";
            this.chkEnableMessageTypes.CheckedChanged += new System.EventHandler(this.chkEnableMessageTypes_CheckedChanged);
            // 
            // lblMTInformation
            // 
            this.lblMTInformation.Location = new System.Drawing.Point(5, 15);
            this.lblMTInformation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMTInformation.Name = "lblMTInformation";
            this.lblMTInformation.Size = new System.Drawing.Size(337, 58);
            this.lblMTInformation.TabIndex = 31;
            this.lblMTInformation.Text = "Message Types displays messages in different areas of the client\'s screen. Here y" +
    "ou can configure all but announcements and chat.";
            // 
            // tabSecurity
            // 
            this.tabSecurity.BackColor = System.Drawing.Color.Brown;
            this.tabSecurity.Controls.Add(this.gBlockDB);
            this.tabSecurity.Controls.Add(this.gSecurityMisc);
            this.tabSecurity.Controls.Add(this.gSpamChat);
            this.tabSecurity.Controls.Add(this.gVerify);
            this.tabSecurity.Location = new System.Drawing.Point(4, 24);
            this.tabSecurity.Name = "tabSecurity";
            this.tabSecurity.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.tabSecurity.Size = new System.Drawing.Size(652, 482);
            this.tabSecurity.TabIndex = 7;
            this.tabSecurity.Text = "Security";
            // 
            // gBlockDB
            // 
            this.gBlockDB.Controls.Add(this.cBlockDBAutoEnableRank);
            this.gBlockDB.Controls.Add(this.xBlockDBAutoEnable);
            this.gBlockDB.Controls.Add(this.xBlockDBEnabled);
            this.gBlockDB.Location = new System.Drawing.Point(8, 100);
            this.gBlockDB.Name = "gBlockDB";
            this.gBlockDB.Size = new System.Drawing.Size(636, 88);
            this.gBlockDB.TabIndex = 1;
            this.gBlockDB.TabStop = false;
            this.gBlockDB.Text = "BlockDB";
            // 
            // cBlockDBAutoEnableRank
            // 
            this.cBlockDBAutoEnableRank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBlockDBAutoEnableRank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cBlockDBAutoEnableRank.FormattingEnabled = true;
            this.cBlockDBAutoEnableRank.Location = new System.Drawing.Point(408, 55);
            this.cBlockDBAutoEnableRank.Name = "cBlockDBAutoEnableRank";
            this.cBlockDBAutoEnableRank.Size = new System.Drawing.Size(121, 23);
            this.cBlockDBAutoEnableRank.TabIndex = 2;
            this.cBlockDBAutoEnableRank.TabStop = false;
            this.cBlockDBAutoEnableRank.SelectedIndexChanged += new System.EventHandler(this.cBlockDBAutoEnableRank_SelectedIndexChanged);
            // 
            // xBlockDBAutoEnable
            // 
            this.xBlockDBAutoEnable.AutoSize = true;
            this.xBlockDBAutoEnable.Enabled = false;
            this.xBlockDBAutoEnable.Location = new System.Drawing.Point(42, 55);
            this.xBlockDBAutoEnable.Name = "xBlockDBAutoEnable";
            this.xBlockDBAutoEnable.Size = new System.Drawing.Size(360, 19);
            this.xBlockDBAutoEnable.TabIndex = 1;
            this.xBlockDBAutoEnable.TabStop = false;
            this.xBlockDBAutoEnable.Text = "Automatically enable BlockDB on worlds that can be edited by";
            this.xBlockDBAutoEnable.UseVisualStyleBackColor = true;
            this.xBlockDBAutoEnable.CheckedChanged += new System.EventHandler(this.xBlockDBAutoEnable_CheckedChanged);
            // 
            // xBlockDBEnabled
            // 
            this.xBlockDBEnabled.AutoSize = true;
            this.xBlockDBEnabled.Location = new System.Drawing.Point(42, 30);
            this.xBlockDBEnabled.Name = "xBlockDBEnabled";
            this.xBlockDBEnabled.Size = new System.Drawing.Size(249, 19);
            this.xBlockDBEnabled.TabIndex = 0;
            this.xBlockDBEnabled.Text = "Enable BlockDB (per-block edit tracking).";
            this.xBlockDBEnabled.UseVisualStyleBackColor = true;
            this.xBlockDBEnabled.CheckedChanged += new System.EventHandler(this.xBlockDBEnabled_CheckedChanged);
            // 
            // gSecurityMisc
            // 
            this.gSecurityMisc.Controls.Add(this.xAnnounceRankChangeReasons);
            this.gSecurityMisc.Controls.Add(this.xRequireKickReason);
            this.gSecurityMisc.Controls.Add(this.lPatrolledRankAndBelow);
            this.gSecurityMisc.Controls.Add(this.cPatrolledRank);
            this.gSecurityMisc.Controls.Add(this.lPatrolledRank);
            this.gSecurityMisc.Controls.Add(this.xAnnounceRankChanges);
            this.gSecurityMisc.Controls.Add(this.xAnnounceKickAndBanReasons);
            this.gSecurityMisc.Controls.Add(this.xRequireRankChangeReason);
            this.gSecurityMisc.Controls.Add(this.xRequireBanReason);
            this.gSecurityMisc.Location = new System.Drawing.Point(8, 294);
            this.gSecurityMisc.Name = "gSecurityMisc";
            this.gSecurityMisc.Size = new System.Drawing.Size(636, 178);
            this.gSecurityMisc.TabIndex = 3;
            this.gSecurityMisc.TabStop = false;
            this.gSecurityMisc.Text = "Misc";
            // 
            // xAnnounceRankChangeReasons
            // 
            this.xAnnounceRankChangeReasons.AutoSize = true;
            this.xAnnounceRankChangeReasons.Location = new System.Drawing.Point(304, 109);
            this.xAnnounceRankChangeReasons.Name = "xAnnounceRankChangeReasons";
            this.xAnnounceRankChangeReasons.Size = new System.Drawing.Size(253, 19);
            this.xAnnounceRankChangeReasons.TabIndex = 6;
            this.xAnnounceRankChangeReasons.Text = "Announce promotion && demotion reasons";
            this.xAnnounceRankChangeReasons.UseVisualStyleBackColor = true;
            // 
            // xRequireKickReason
            // 
            this.xRequireKickReason.AutoSize = true;
            this.xRequireKickReason.Location = new System.Drawing.Point(42, 59);
            this.xRequireKickReason.Name = "xRequireKickReason";
            this.xRequireKickReason.Size = new System.Drawing.Size(135, 19);
            this.xRequireKickReason.TabIndex = 1;
            this.xRequireKickReason.Text = "Require kick reason";
            this.xRequireKickReason.UseVisualStyleBackColor = true;
            // 
            // lPatrolledRankAndBelow
            // 
            this.lPatrolledRankAndBelow.AutoSize = true;
            this.lPatrolledRankAndBelow.Location = new System.Drawing.Point(257, 143);
            this.lPatrolledRankAndBelow.Name = "lPatrolledRankAndBelow";
            this.lPatrolledRankAndBelow.Size = new System.Drawing.Size(72, 15);
            this.lPatrolledRankAndBelow.TabIndex = 9;
            this.lPatrolledRankAndBelow.Text = "(and below)";
            // 
            // cPatrolledRank
            // 
            this.cPatrolledRank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cPatrolledRank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cPatrolledRank.FormattingEnabled = true;
            this.cPatrolledRank.Location = new System.Drawing.Point(128, 140);
            this.cPatrolledRank.Name = "cPatrolledRank";
            this.cPatrolledRank.Size = new System.Drawing.Size(123, 23);
            this.cPatrolledRank.TabIndex = 8;
            this.cPatrolledRank.SelectedIndexChanged += new System.EventHandler(this.cPatrolledRank_SelectedIndexChanged);
            // 
            // lPatrolledRank
            // 
            this.lPatrolledRank.AutoSize = true;
            this.lPatrolledRank.Location = new System.Drawing.Point(39, 143);
            this.lPatrolledRank.Name = "lPatrolledRank";
            this.lPatrolledRank.Size = new System.Drawing.Size(83, 15);
            this.lPatrolledRank.TabIndex = 7;
            this.lPatrolledRank.Text = "Patrolled rank";
            // 
            // xAnnounceRankChanges
            // 
            this.xAnnounceRankChanges.AutoSize = true;
            this.xAnnounceRankChanges.Location = new System.Drawing.Point(304, 84);
            this.xAnnounceRankChanges.Name = "xAnnounceRankChanges";
            this.xAnnounceRankChanges.Size = new System.Drawing.Size(231, 19);
            this.xAnnounceRankChanges.TabIndex = 5;
            this.xAnnounceRankChanges.Text = "Announce promotions and demotions";
            this.xAnnounceRankChanges.UseVisualStyleBackColor = true;
            this.xAnnounceRankChanges.CheckedChanged += new System.EventHandler(this.xAnnounceRankChanges_CheckedChanged);
            // 
            // xAnnounceKickAndBanReasons
            // 
            this.xAnnounceKickAndBanReasons.AutoSize = true;
            this.xAnnounceKickAndBanReasons.Location = new System.Drawing.Point(304, 59);
            this.xAnnounceKickAndBanReasons.Name = "xAnnounceKickAndBanReasons";
            this.xAnnounceKickAndBanReasons.Size = new System.Drawing.Size(244, 19);
            this.xAnnounceKickAndBanReasons.TabIndex = 4;
            this.xAnnounceKickAndBanReasons.Text = "Announce kick, ban, and unban reasons";
            this.xAnnounceKickAndBanReasons.UseVisualStyleBackColor = true;
            // 
            // xRequireRankChangeReason
            // 
            this.xRequireRankChangeReason.AutoSize = true;
            this.xRequireRankChangeReason.Location = new System.Drawing.Point(42, 109);
            this.xRequireRankChangeReason.Name = "xRequireRankChangeReason";
            this.xRequireRankChangeReason.Size = new System.Drawing.Size(236, 19);
            this.xRequireRankChangeReason.TabIndex = 3;
            this.xRequireRankChangeReason.Text = "Require promotion && demotion reason";
            this.xRequireRankChangeReason.UseVisualStyleBackColor = true;
            // 
            // xRequireBanReason
            // 
            this.xRequireBanReason.AutoSize = true;
            this.xRequireBanReason.Location = new System.Drawing.Point(42, 84);
            this.xRequireBanReason.Name = "xRequireBanReason";
            this.xRequireBanReason.Size = new System.Drawing.Size(184, 19);
            this.xRequireBanReason.TabIndex = 2;
            this.xRequireBanReason.Text = "Require ban && unban reason";
            this.xRequireBanReason.UseVisualStyleBackColor = true;
            // 
            // gSpamChat
            // 
            this.gSpamChat.Controls.Add(this.lAntispamMaxWarnings);
            this.gSpamChat.Controls.Add(this.nAntispamMaxWarnings);
            this.gSpamChat.Controls.Add(this.xAntispamKicks);
            this.gSpamChat.Controls.Add(this.lSpamMuteSeconds);
            this.gSpamChat.Controls.Add(this.lAntispamInterval);
            this.gSpamChat.Controls.Add(this.nSpamMute);
            this.gSpamChat.Controls.Add(this.lSpamMute);
            this.gSpamChat.Controls.Add(this.nAntispamInterval);
            this.gSpamChat.Controls.Add(this.lAntispamMessageCount);
            this.gSpamChat.Controls.Add(this.nAntispamMessageCount);
            this.gSpamChat.Controls.Add(this.lSpamChat);
            this.gSpamChat.Location = new System.Drawing.Point(8, 194);
            this.gSpamChat.Name = "gSpamChat";
            this.gSpamChat.Size = new System.Drawing.Size(636, 94);
            this.gSpamChat.TabIndex = 2;
            this.gSpamChat.TabStop = false;
            this.gSpamChat.Text = "Chat Spam Prevention";
            // 
            // lAntispamMaxWarnings
            // 
            this.lAntispamMaxWarnings.AutoSize = true;
            this.lAntispamMaxWarnings.Location = new System.Drawing.Point(454, 62);
            this.lAntispamMaxWarnings.Name = "lAntispamMaxWarnings";
            this.lAntispamMaxWarnings.Size = new System.Drawing.Size(57, 15);
            this.lAntispamMaxWarnings.TabIndex = 10;
            this.lAntispamMaxWarnings.Text = "warnings";
            // 
            // nAntispamMaxWarnings
            // 
            this.nAntispamMaxWarnings.Location = new System.Drawing.Point(386, 60);
            this.nAntispamMaxWarnings.Name = "nAntispamMaxWarnings";
            this.nAntispamMaxWarnings.Size = new System.Drawing.Size(62, 21);
            this.nAntispamMaxWarnings.TabIndex = 9;
            // 
            // xAntispamKicks
            // 
            this.xAntispamKicks.AutoSize = true;
            this.xAntispamKicks.Location = new System.Drawing.Point(304, 61);
            this.xAntispamKicks.Name = "xAntispamKicks";
            this.xAntispamKicks.Size = new System.Drawing.Size(76, 19);
            this.xAntispamKicks.TabIndex = 8;
            this.xAntispamKicks.Text = "Kick after";
            this.xAntispamKicks.UseVisualStyleBackColor = true;
            this.xAntispamKicks.CheckedChanged += new System.EventHandler(this.xSpamChatKick_CheckedChanged);
            // 
            // lSpamMuteSeconds
            // 
            this.lSpamMuteSeconds.AutoSize = true;
            this.lSpamMuteSeconds.Location = new System.Drawing.Point(221, 62);
            this.lSpamMuteSeconds.Name = "lSpamMuteSeconds";
            this.lSpamMuteSeconds.Size = new System.Drawing.Size(53, 15);
            this.lSpamMuteSeconds.TabIndex = 7;
            this.lSpamMuteSeconds.Text = "seconds";
            // 
            // lAntispamInterval
            // 
            this.lAntispamInterval.AutoSize = true;
            this.lAntispamInterval.Location = new System.Drawing.Point(372, 27);
            this.lAntispamInterval.Name = "lAntispamInterval";
            this.lAntispamInterval.Size = new System.Drawing.Size(53, 15);
            this.lAntispamInterval.TabIndex = 4;
            this.lAntispamInterval.Text = "seconds";
            // 
            // nSpamMute
            // 
            this.nSpamMute.Location = new System.Drawing.Point(153, 59);
            this.nSpamMute.Name = "nSpamMute";
            this.nSpamMute.Size = new System.Drawing.Size(62, 21);
            this.nSpamMute.TabIndex = 6;
            // 
            // lSpamMute
            // 
            this.lSpamMute.AutoSize = true;
            this.lSpamMute.Location = new System.Drawing.Point(39, 62);
            this.lSpamMute.Name = "lSpamMute";
            this.lSpamMute.Size = new System.Drawing.Size(108, 15);
            this.lSpamMute.TabIndex = 5;
            this.lSpamMute.Text = "Mute spammer for";
            // 
            // nAntispamInterval
            // 
            this.nAntispamInterval.Location = new System.Drawing.Point(304, 25);
            this.nAntispamInterval.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nAntispamInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nAntispamInterval.Name = "nAntispamInterval";
            this.nAntispamInterval.Size = new System.Drawing.Size(62, 21);
            this.nAntispamInterval.TabIndex = 3;
            this.nAntispamInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lAntispamMessageCount
            // 
            this.lAntispamMessageCount.AutoSize = true;
            this.lAntispamMessageCount.Location = new System.Drawing.Point(219, 27);
            this.lAntispamMessageCount.Name = "lAntispamMessageCount";
            this.lAntispamMessageCount.Size = new System.Drawing.Size(77, 15);
            this.lAntispamMessageCount.TabIndex = 2;
            this.lAntispamMessageCount.Text = "messages in";
            // 
            // nAntispamMessageCount
            // 
            this.nAntispamMessageCount.Location = new System.Drawing.Point(153, 25);
            this.nAntispamMessageCount.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nAntispamMessageCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nAntispamMessageCount.Name = "nAntispamMessageCount";
            this.nAntispamMessageCount.Size = new System.Drawing.Size(62, 21);
            this.nAntispamMessageCount.TabIndex = 1;
            this.nAntispamMessageCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lSpamChat
            // 
            this.lSpamChat.AutoSize = true;
            this.lSpamChat.Location = new System.Drawing.Point(39, 31);
            this.lSpamChat.Name = "lSpamChat";
            this.lSpamChat.Size = new System.Drawing.Size(97, 15);
            this.lSpamChat.TabIndex = 0;
            this.lSpamChat.Text = "Limit chat rate to";
            // 
            // gVerify
            // 
            this.gVerify.BackColor = System.Drawing.Color.Brown;
            this.gVerify.Controls.Add(this.nMaxConnectionsPerIP);
            this.gVerify.Controls.Add(this.xAllowUnverifiedLAN);
            this.gVerify.Controls.Add(this.xMaxConnectionsPerIP);
            this.gVerify.Controls.Add(this.lVerifyNames);
            this.gVerify.Controls.Add(this.cVerifyNames);
            this.gVerify.Location = new System.Drawing.Point(8, 13);
            this.gVerify.Name = "gVerify";
            this.gVerify.Size = new System.Drawing.Size(636, 81);
            this.gVerify.TabIndex = 0;
            this.gVerify.TabStop = false;
            this.gVerify.Text = "Connection";
            // 
            // nMaxConnectionsPerIP
            // 
            this.nMaxConnectionsPerIP.Location = new System.Drawing.Point(539, 21);
            this.nMaxConnectionsPerIP.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nMaxConnectionsPerIP.Name = "nMaxConnectionsPerIP";
            this.nMaxConnectionsPerIP.Size = new System.Drawing.Size(47, 21);
            this.nMaxConnectionsPerIP.TabIndex = 4;
            this.nMaxConnectionsPerIP.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // xAllowUnverifiedLAN
            // 
            this.xAllowUnverifiedLAN.AutoSize = true;
            this.xAllowUnverifiedLAN.Location = new System.Drawing.Point(42, 49);
            this.xAllowUnverifiedLAN.Name = "xAllowUnverifiedLAN";
            this.xAllowUnverifiedLAN.Size = new System.Drawing.Size(490, 19);
            this.xAllowUnverifiedLAN.TabIndex = 2;
            this.xAllowUnverifiedLAN.Text = "Allow connections from LAN without name verification (192.168.0.0/16 and 10.0.0.0" +
    "/8)";
            this.xAllowUnverifiedLAN.UseVisualStyleBackColor = true;
            // 
            // xMaxConnectionsPerIP
            // 
            this.xMaxConnectionsPerIP.AutoSize = true;
            this.xMaxConnectionsPerIP.Location = new System.Drawing.Point(304, 22);
            this.xMaxConnectionsPerIP.Name = "xMaxConnectionsPerIP";
            this.xMaxConnectionsPerIP.Size = new System.Drawing.Size(229, 19);
            this.xMaxConnectionsPerIP.TabIndex = 3;
            this.xMaxConnectionsPerIP.Text = "Limit number of connections per IP to";
            this.xMaxConnectionsPerIP.UseVisualStyleBackColor = true;
            this.xMaxConnectionsPerIP.CheckedChanged += new System.EventHandler(this.xMaxConnectionsPerIP_CheckedChanged);
            // 
            // lVerifyNames
            // 
            this.lVerifyNames.AutoSize = true;
            this.lVerifyNames.Location = new System.Drawing.Point(45, 23);
            this.lVerifyNames.Name = "lVerifyNames";
            this.lVerifyNames.Size = new System.Drawing.Size(102, 15);
            this.lVerifyNames.TabIndex = 0;
            this.lVerifyNames.Text = "Name verification";
            // 
            // cVerifyNames
            // 
            this.cVerifyNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cVerifyNames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cVerifyNames.FormattingEnabled = true;
            this.cVerifyNames.Items.AddRange(new object[] {
            "None (Unsafe)",
            "Normal",
            "Strict"});
            this.cVerifyNames.Location = new System.Drawing.Point(153, 20);
            this.cVerifyNames.Name = "cVerifyNames";
            this.cVerifyNames.Size = new System.Drawing.Size(120, 23);
            this.cVerifyNames.TabIndex = 1;
            this.cVerifyNames.SelectedIndexChanged += new System.EventHandler(this.cVerifyNames_SelectedIndexChanged);
            // 
            // tabSavingAndBackup
            // 
            this.tabSavingAndBackup.BackColor = System.Drawing.Color.Teal;
            this.tabSavingAndBackup.Controls.Add(this.groupBox5);
            this.tabSavingAndBackup.Controls.Add(this.gDataBackup);
            this.tabSavingAndBackup.Controls.Add(this.gSaving);
            this.tabSavingAndBackup.Controls.Add(this.gBackups);
            this.tabSavingAndBackup.Location = new System.Drawing.Point(4, 24);
            this.tabSavingAndBackup.Name = "tabSavingAndBackup";
            this.tabSavingAndBackup.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.tabSavingAndBackup.Size = new System.Drawing.Size(652, 482);
            this.tabSavingAndBackup.TabIndex = 4;
            this.tabSavingAndBackup.Text = "Saving and Backup";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.bUpdate);
            this.groupBox5.Controls.Add(this.checkUpdate);
            this.groupBox5.Location = new System.Drawing.Point(8, 293);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(635, 54);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Update";
            // 
            // bUpdate
            // 
            this.bUpdate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.bUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bUpdate.Location = new System.Drawing.Point(221, 14);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(205, 28);
            this.bUpdate.TabIndex = 23;
            this.bUpdate.Text = "Manual Update Check";
            this.bUpdate.UseVisualStyleBackColor = false;
            this.bUpdate.Click += new System.EventHandler(this.bUpdate_Click);
            // 
            // checkUpdate
            // 
            this.checkUpdate.AutoSize = true;
            this.checkUpdate.Location = new System.Drawing.Point(11, 20);
            this.checkUpdate.Name = "checkUpdate";
            this.checkUpdate.Size = new System.Drawing.Size(201, 19);
            this.checkUpdate.TabIndex = 22;
            this.checkUpdate.Text = "Automatically Check for Updates";
            this.checkUpdate.UseVisualStyleBackColor = true;
            // 
            // gDataBackup
            // 
            this.gDataBackup.Controls.Add(this.xBackupDataOnStartup);
            this.gDataBackup.Location = new System.Drawing.Point(8, 235);
            this.gDataBackup.Name = "gDataBackup";
            this.gDataBackup.Size = new System.Drawing.Size(636, 52);
            this.gDataBackup.TabIndex = 2;
            this.gDataBackup.TabStop = false;
            this.gDataBackup.Text = "Data Backup";
            // 
            // xBackupDataOnStartup
            // 
            this.xBackupDataOnStartup.AutoSize = true;
            this.xBackupDataOnStartup.Location = new System.Drawing.Point(16, 20);
            this.xBackupDataOnStartup.Name = "xBackupDataOnStartup";
            this.xBackupDataOnStartup.Size = new System.Drawing.Size(261, 19);
            this.xBackupDataOnStartup.TabIndex = 0;
            this.xBackupDataOnStartup.Text = "Backup PlayerDB and IP ban list on startup.";
            this.xBackupDataOnStartup.UseVisualStyleBackColor = true;
            // 
            // gSaving
            // 
            this.gSaving.Controls.Add(this.nSaveInterval);
            this.gSaving.Controls.Add(this.lSaveIntervalUnits);
            this.gSaving.Controls.Add(this.xSaveInterval);
            this.gSaving.Location = new System.Drawing.Point(8, 13);
            this.gSaving.Name = "gSaving";
            this.gSaving.Size = new System.Drawing.Size(636, 52);
            this.gSaving.TabIndex = 0;
            this.gSaving.TabStop = false;
            this.gSaving.Text = "Map Saving";
            // 
            // nSaveInterval
            // 
            this.nSaveInterval.Location = new System.Drawing.Point(136, 20);
            this.nSaveInterval.Name = "nSaveInterval";
            this.nSaveInterval.Size = new System.Drawing.Size(48, 21);
            this.nSaveInterval.TabIndex = 1;
            // 
            // lSaveIntervalUnits
            // 
            this.lSaveIntervalUnits.AutoSize = true;
            this.lSaveIntervalUnits.Location = new System.Drawing.Point(190, 22);
            this.lSaveIntervalUnits.Name = "lSaveIntervalUnits";
            this.lSaveIntervalUnits.Size = new System.Drawing.Size(53, 15);
            this.lSaveIntervalUnits.TabIndex = 2;
            this.lSaveIntervalUnits.Text = "seconds";
            // 
            // xSaveInterval
            // 
            this.xSaveInterval.AutoSize = true;
            this.xSaveInterval.Location = new System.Drawing.Point(12, 21);
            this.xSaveInterval.Name = "xSaveInterval";
            this.xSaveInterval.Size = new System.Drawing.Size(118, 19);
            this.xSaveInterval.TabIndex = 0;
            this.xSaveInterval.Text = "Save maps every";
            this.xSaveInterval.UseVisualStyleBackColor = true;
            this.xSaveInterval.CheckedChanged += new System.EventHandler(this.xSaveAtInterval_CheckedChanged);
            // 
            // gBackups
            // 
            this.gBackups.Controls.Add(this.xBackupOnlyWhenChanged);
            this.gBackups.Controls.Add(this.lMaxBackupSize);
            this.gBackups.Controls.Add(this.xMaxBackupSize);
            this.gBackups.Controls.Add(this.nMaxBackupSize);
            this.gBackups.Controls.Add(this.xMaxBackups);
            this.gBackups.Controls.Add(this.xBackupOnStartup);
            this.gBackups.Controls.Add(this.lMaxBackups);
            this.gBackups.Controls.Add(this.nMaxBackups);
            this.gBackups.Controls.Add(this.nBackupInterval);
            this.gBackups.Controls.Add(this.lBackupIntervalUnits);
            this.gBackups.Controls.Add(this.xBackupInterval);
            this.gBackups.Controls.Add(this.xBackupOnJoin);
            this.gBackups.Location = new System.Drawing.Point(8, 71);
            this.gBackups.Name = "gBackups";
            this.gBackups.Size = new System.Drawing.Size(636, 158);
            this.gBackups.TabIndex = 1;
            this.gBackups.TabStop = false;
            this.gBackups.Text = "Map Backups";
            // 
            // xBackupOnlyWhenChanged
            // 
            this.xBackupOnlyWhenChanged.AutoSize = true;
            this.xBackupOnlyWhenChanged.Location = new System.Drawing.Point(369, 46);
            this.xBackupOnlyWhenChanged.Name = "xBackupOnlyWhenChanged";
            this.xBackupOnlyWhenChanged.Size = new System.Drawing.Size(260, 19);
            this.xBackupOnlyWhenChanged.TabIndex = 4;
            this.xBackupOnlyWhenChanged.Text = "Skip timed backups if map hasn\'t changed.";
            this.xBackupOnlyWhenChanged.UseVisualStyleBackColor = true;
            // 
            // lMaxBackupSize
            // 
            this.lMaxBackupSize.AutoSize = true;
            this.lMaxBackupSize.Location = new System.Drawing.Point(418, 124);
            this.lMaxBackupSize.Name = "lMaxBackupSize";
            this.lMaxBackupSize.Size = new System.Drawing.Size(103, 15);
            this.lMaxBackupSize.TabIndex = 11;
            this.lMaxBackupSize.Text = "MB of disk space.";
            // 
            // xMaxBackupSize
            // 
            this.xMaxBackupSize.AutoSize = true;
            this.xMaxBackupSize.Location = new System.Drawing.Point(16, 123);
            this.xMaxBackupSize.Name = "xMaxBackupSize";
            this.xMaxBackupSize.Size = new System.Drawing.Size(317, 19);
            this.xMaxBackupSize.TabIndex = 9;
            this.xMaxBackupSize.Text = "Delete old backups if the directory takes up more than";
            this.xMaxBackupSize.UseVisualStyleBackColor = true;
            this.xMaxBackupSize.CheckedChanged += new System.EventHandler(this.xMaxBackupSize_CheckedChanged);
            // 
            // nMaxBackupSize
            // 
            this.nMaxBackupSize.Location = new System.Drawing.Point(339, 122);
            this.nMaxBackupSize.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nMaxBackupSize.Name = "nMaxBackupSize";
            this.nMaxBackupSize.Size = new System.Drawing.Size(73, 21);
            this.nMaxBackupSize.TabIndex = 10;
            // 
            // xMaxBackups
            // 
            this.xMaxBackups.AutoSize = true;
            this.xMaxBackups.Location = new System.Drawing.Point(16, 98);
            this.xMaxBackups.Name = "xMaxBackups";
            this.xMaxBackups.Size = new System.Drawing.Size(251, 19);
            this.xMaxBackups.TabIndex = 6;
            this.xMaxBackups.Text = "Delete old backups if there are more than";
            this.xMaxBackups.UseVisualStyleBackColor = true;
            this.xMaxBackups.CheckedChanged += new System.EventHandler(this.xMaxBackups_CheckedChanged);
            // 
            // xBackupOnStartup
            // 
            this.xBackupOnStartup.AutoSize = true;
            this.xBackupOnStartup.Enabled = false;
            this.xBackupOnStartup.Location = new System.Drawing.Point(16, 20);
            this.xBackupOnStartup.Name = "xBackupOnStartup";
            this.xBackupOnStartup.Size = new System.Drawing.Size(168, 19);
            this.xBackupOnStartup.TabIndex = 0;
            this.xBackupOnStartup.Text = "Create backups on startup";
            this.xBackupOnStartup.UseVisualStyleBackColor = true;
            // 
            // lMaxBackups
            // 
            this.lMaxBackups.AutoSize = true;
            this.lMaxBackups.Location = new System.Drawing.Point(336, 99);
            this.lMaxBackups.Name = "lMaxBackups";
            this.lMaxBackups.Size = new System.Drawing.Size(157, 15);
            this.lMaxBackups.TabIndex = 8;
            this.lMaxBackups.Text = "files in the backup directory.";
            // 
            // nMaxBackups
            // 
            this.nMaxBackups.Location = new System.Drawing.Point(273, 97);
            this.nMaxBackups.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nMaxBackups.Name = "nMaxBackups";
            this.nMaxBackups.Size = new System.Drawing.Size(57, 21);
            this.nMaxBackups.TabIndex = 7;
            // 
            // nBackupInterval
            // 
            this.nBackupInterval.Location = new System.Drawing.Point(164, 45);
            this.nBackupInterval.Name = "nBackupInterval";
            this.nBackupInterval.Size = new System.Drawing.Size(48, 21);
            this.nBackupInterval.TabIndex = 2;
            // 
            // lBackupIntervalUnits
            // 
            this.lBackupIntervalUnits.AutoSize = true;
            this.lBackupIntervalUnits.Location = new System.Drawing.Point(218, 47);
            this.lBackupIntervalUnits.Name = "lBackupIntervalUnits";
            this.lBackupIntervalUnits.Size = new System.Drawing.Size(51, 15);
            this.lBackupIntervalUnits.TabIndex = 3;
            this.lBackupIntervalUnits.Text = "minutes";
            // 
            // xBackupInterval
            // 
            this.xBackupInterval.AutoSize = true;
            this.xBackupInterval.Location = new System.Drawing.Point(16, 46);
            this.xBackupInterval.Name = "xBackupInterval";
            this.xBackupInterval.Size = new System.Drawing.Size(142, 19);
            this.xBackupInterval.TabIndex = 1;
            this.xBackupInterval.Text = "Create backups every";
            this.xBackupInterval.UseVisualStyleBackColor = true;
            this.xBackupInterval.CheckedChanged += new System.EventHandler(this.xBackupAtInterval_CheckedChanged);
            // 
            // xBackupOnJoin
            // 
            this.xBackupOnJoin.AutoSize = true;
            this.xBackupOnJoin.Location = new System.Drawing.Point(16, 72);
            this.xBackupOnJoin.Name = "xBackupOnJoin";
            this.xBackupOnJoin.Size = new System.Drawing.Size(279, 19);
            this.xBackupOnJoin.TabIndex = 5;
            this.xBackupOnJoin.Text = "Create backup whenever a player joins a world";
            this.xBackupOnJoin.UseVisualStyleBackColor = true;
            // 
            // tabLogging
            // 
            this.tabLogging.BackColor = System.Drawing.Color.IndianRed;
            this.tabLogging.Controls.Add(this.gLogFile);
            this.tabLogging.Controls.Add(this.gConsole);
            this.tabLogging.Location = new System.Drawing.Point(4, 24);
            this.tabLogging.Name = "tabLogging";
            this.tabLogging.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.tabLogging.Size = new System.Drawing.Size(652, 482);
            this.tabLogging.TabIndex = 5;
            this.tabLogging.Text = "Logging";
            // 
            // gLogFile
            // 
            this.gLogFile.BackColor = System.Drawing.Color.IndianRed;
            this.gLogFile.Controls.Add(this.lLogFileOptionsDescription);
            this.gLogFile.Controls.Add(this.xLogLimit);
            this.gLogFile.Controls.Add(this.vLogFileOptions);
            this.gLogFile.Controls.Add(this.lLogLimitUnits);
            this.gLogFile.Controls.Add(this.nLogLimit);
            this.gLogFile.Controls.Add(this.cLogMode);
            this.gLogFile.Controls.Add(this.lLogMode);
            this.gLogFile.Location = new System.Drawing.Point(329, 13);
            this.gLogFile.Name = "gLogFile";
            this.gLogFile.Size = new System.Drawing.Size(315, 423);
            this.gLogFile.TabIndex = 1;
            this.gLogFile.TabStop = false;
            this.gLogFile.Text = "Log File";
            // 
            // lLogFileOptionsDescription
            // 
            this.lLogFileOptionsDescription.AutoSize = true;
            this.lLogFileOptionsDescription.Location = new System.Drawing.Point(27, 22);
            this.lLogFileOptionsDescription.Name = "lLogFileOptionsDescription";
            this.lLogFileOptionsDescription.Size = new System.Drawing.Size(212, 30);
            this.lLogFileOptionsDescription.TabIndex = 0;
            this.lLogFileOptionsDescription.Text = "Types of messages that will be written\r\nto the log file on disk.";
            // 
            // xLogLimit
            // 
            this.xLogLimit.AutoSize = true;
            this.xLogLimit.Enabled = false;
            this.xLogLimit.Location = new System.Drawing.Point(18, 390);
            this.xLogLimit.Name = "xLogLimit";
            this.xLogLimit.Size = new System.Drawing.Size(80, 19);
            this.xLogLimit.TabIndex = 4;
            this.xLogLimit.Text = "Only keep";
            this.xLogLimit.UseVisualStyleBackColor = true;
            this.xLogLimit.CheckedChanged += new System.EventHandler(this.xLogLimit_CheckedChanged);
            // 
            // vLogFileOptions
            // 
            this.vLogFileOptions.CheckBoxes = true;
            this.vLogFileOptions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.vLogFileOptions.GridLines = true;
            this.vLogFileOptions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.vLogFileOptions.Location = new System.Drawing.Point(78, 59);
            this.vLogFileOptions.Name = "vLogFileOptions";
            this.vLogFileOptions.ShowItemToolTips = true;
            this.vLogFileOptions.Size = new System.Drawing.Size(161, 294);
            this.vLogFileOptions.TabIndex = 1;
            this.vLogFileOptions.UseCompatibleStateImageBehavior = false;
            this.vLogFileOptions.View = System.Windows.Forms.View.Details;
            this.vLogFileOptions.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.vLogFileOptions_ItemChecked);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 157;
            // 
            // lLogLimitUnits
            // 
            this.lLogLimitUnits.AutoSize = true;
            this.lLogLimitUnits.Location = new System.Drawing.Point(166, 391);
            this.lLogLimitUnits.Name = "lLogLimitUnits";
            this.lLogLimitUnits.Size = new System.Drawing.Size(129, 15);
            this.lLogLimitUnits.TabIndex = 6;
            this.lLogLimitUnits.Text = "of most recent log files";
            // 
            // nLogLimit
            // 
            this.nLogLimit.Enabled = false;
            this.nLogLimit.Location = new System.Drawing.Point(104, 389);
            this.nLogLimit.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nLogLimit.Name = "nLogLimit";
            this.nLogLimit.Size = new System.Drawing.Size(56, 21);
            this.nLogLimit.TabIndex = 5;
            // 
            // cLogMode
            // 
            this.cLogMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cLogMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cLogMode.FormattingEnabled = true;
            this.cLogMode.Items.AddRange(new object[] {
            "One long file",
            "Multiple files, split by session",
            "Multiple files, split by day"});
            this.cLogMode.Location = new System.Drawing.Point(104, 360);
            this.cLogMode.Name = "cLogMode";
            this.cLogMode.Size = new System.Drawing.Size(185, 23);
            this.cLogMode.TabIndex = 3;
            // 
            // lLogMode
            // 
            this.lLogMode.AutoSize = true;
            this.lLogMode.Location = new System.Drawing.Point(35, 363);
            this.lLogMode.Name = "lLogMode";
            this.lLogMode.Size = new System.Drawing.Size(63, 15);
            this.lLogMode.TabIndex = 2;
            this.lLogMode.Text = "Log mode";
            // 
            // gConsole
            // 
            this.gConsole.Controls.Add(this.lLogConsoleOptionsDescription);
            this.gConsole.Controls.Add(this.vConsoleOptions);
            this.gConsole.Location = new System.Drawing.Point(8, 13);
            this.gConsole.Name = "gConsole";
            this.gConsole.Size = new System.Drawing.Size(315, 423);
            this.gConsole.TabIndex = 0;
            this.gConsole.TabStop = false;
            this.gConsole.Text = "Console";
            // 
            // lLogConsoleOptionsDescription
            // 
            this.lLogConsoleOptionsDescription.AutoSize = true;
            this.lLogConsoleOptionsDescription.Location = new System.Drawing.Point(9, 21);
            this.lLogConsoleOptionsDescription.Name = "lLogConsoleOptionsDescription";
            this.lLogConsoleOptionsDescription.Size = new System.Drawing.Size(212, 30);
            this.lLogConsoleOptionsDescription.TabIndex = 0;
            this.lLogConsoleOptionsDescription.Text = "Types of messages that will be written\r\ndirectly to console.";
            // 
            // vConsoleOptions
            // 
            this.vConsoleOptions.CheckBoxes = true;
            this.vConsoleOptions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.vConsoleOptions.GridLines = true;
            this.vConsoleOptions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.vConsoleOptions.Location = new System.Drawing.Point(76, 59);
            this.vConsoleOptions.Name = "vConsoleOptions";
            this.vConsoleOptions.ShowItemToolTips = true;
            this.vConsoleOptions.Size = new System.Drawing.Size(161, 294);
            this.vConsoleOptions.TabIndex = 1;
            this.vConsoleOptions.UseCompatibleStateImageBehavior = false;
            this.vConsoleOptions.View = System.Windows.Forms.View.Details;
            this.vConsoleOptions.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.vConsoleOptions_ItemChecked);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 157;
            // 
            // tabIRC
            // 
            this.tabIRC.BackColor = System.Drawing.Color.Orange;
            this.tabIRC.Controls.Add(this.gIRCAdv);
            this.tabIRC.Controls.Add(this.xIRCListShowNonEnglish);
            this.tabIRC.Controls.Add(this.gIRCOptions);
            this.tabIRC.Controls.Add(this.gIRCNetwork);
            this.tabIRC.Controls.Add(this.lIRCList);
            this.tabIRC.Controls.Add(this.xIRCBotEnabled);
            this.tabIRC.Controls.Add(this.cIRCList);
            this.tabIRC.Location = new System.Drawing.Point(4, 24);
            this.tabIRC.Name = "tabIRC";
            this.tabIRC.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.tabIRC.Size = new System.Drawing.Size(652, 482);
            this.tabIRC.TabIndex = 8;
            this.tabIRC.Text = "IRC";
            // 
            // gIRCAdv
            // 
            this.gIRCAdv.Controls.Add(this.tServPass);
            this.gIRCAdv.Controls.Add(this.xServPass);
            this.gIRCAdv.Controls.Add(this.tChanPass);
            this.gIRCAdv.Controls.Add(this.xChanPass);
            this.gIRCAdv.Location = new System.Drawing.Point(10, 374);
            this.gIRCAdv.Name = "gIRCAdv";
            this.gIRCAdv.Size = new System.Drawing.Size(419, 95);
            this.gIRCAdv.TabIndex = 6;
            this.gIRCAdv.TabStop = false;
            this.gIRCAdv.Text = "Advanced";
            // 
            // tServPass
            // 
            this.tServPass.Enabled = false;
            this.tServPass.Location = new System.Drawing.Point(219, 48);
            this.tServPass.Name = "tServPass";
            this.tServPass.Size = new System.Drawing.Size(154, 21);
            this.tServPass.TabIndex = 3;
            // 
            // xServPass
            // 
            this.xServPass.AutoSize = true;
            this.xServPass.Location = new System.Drawing.Point(219, 23);
            this.xServPass.Name = "xServPass";
            this.xServPass.Size = new System.Drawing.Size(143, 19);
            this.xServPass.TabIndex = 2;
            this.xServPass.Text = "Use Server Password";
            this.xServPass.UseVisualStyleBackColor = true;
            this.xServPass.CheckedChanged += new System.EventHandler(this.xServPass_CheckedChanged);
            // 
            // tChanPass
            // 
            this.tChanPass.Enabled = false;
            this.tChanPass.Location = new System.Drawing.Point(16, 48);
            this.tChanPass.Name = "tChanPass";
            this.tChanPass.Size = new System.Drawing.Size(154, 21);
            this.tChanPass.TabIndex = 1;
            // 
            // xChanPass
            // 
            this.xChanPass.AutoSize = true;
            this.xChanPass.Location = new System.Drawing.Point(16, 23);
            this.xChanPass.Name = "xChanPass";
            this.xChanPass.Size = new System.Drawing.Size(154, 19);
            this.xChanPass.TabIndex = 0;
            this.xChanPass.Text = "Use Channel Password";
            this.xChanPass.UseVisualStyleBackColor = true;
            this.xChanPass.CheckedChanged += new System.EventHandler(this.xChanPass_CheckedChanged);
            // 
            // xIRCListShowNonEnglish
            // 
            this.xIRCListShowNonEnglish.AutoSize = true;
            this.xIRCListShowNonEnglish.Enabled = false;
            this.xIRCListShowNonEnglish.Location = new System.Drawing.Point(465, 13);
            this.xIRCListShowNonEnglish.Name = "xIRCListShowNonEnglish";
            this.xIRCListShowNonEnglish.Size = new System.Drawing.Size(178, 19);
            this.xIRCListShowNonEnglish.TabIndex = 3;
            this.xIRCListShowNonEnglish.Text = "Show non-English networks";
            this.xIRCListShowNonEnglish.UseVisualStyleBackColor = true;
            this.xIRCListShowNonEnglish.CheckedChanged += new System.EventHandler(this.xIRCListShowNonEnglish_CheckedChanged);
            // 
            // gIRCOptions
            // 
            this.gIRCOptions.Controls.Add(this.xIRCBotAnnounceServerEvents);
            this.gIRCOptions.Controls.Add(this.xIRCUseColor);
            this.gIRCOptions.Controls.Add(this.lIRCNoForwardingMessage);
            this.gIRCOptions.Controls.Add(this.xIRCBotAnnounceIRCJoins);
            this.gIRCOptions.Controls.Add(this.bColorIRC);
            this.gIRCOptions.Controls.Add(this.lColorIRC);
            this.gIRCOptions.Controls.Add(this.xIRCBotForwardFromIRC);
            this.gIRCOptions.Controls.Add(this.xIRCBotAnnounceServerJoins);
            this.gIRCOptions.Controls.Add(this.xIRCBotForwardFromServer);
            this.gIRCOptions.Location = new System.Drawing.Point(8, 206);
            this.gIRCOptions.Name = "gIRCOptions";
            this.gIRCOptions.Size = new System.Drawing.Size(636, 162);
            this.gIRCOptions.TabIndex = 5;
            this.gIRCOptions.TabStop = false;
            this.gIRCOptions.Text = "Options";
            // 
            // xIRCBotAnnounceServerEvents
            // 
            this.xIRCBotAnnounceServerEvents.AutoSize = true;
            this.xIRCBotAnnounceServerEvents.Location = new System.Drawing.Point(38, 109);
            this.xIRCBotAnnounceServerEvents.Name = "xIRCBotAnnounceServerEvents";
            this.xIRCBotAnnounceServerEvents.Size = new System.Drawing.Size(417, 19);
            this.xIRCBotAnnounceServerEvents.TabIndex = 7;
            this.xIRCBotAnnounceServerEvents.Text = "Announce SERVER events (kicks, bans, promotions, demotions) on IRC.";
            this.xIRCBotAnnounceServerEvents.UseVisualStyleBackColor = true;
            // 
            // xIRCUseColor
            // 
            this.xIRCUseColor.AutoSize = true;
            this.xIRCUseColor.Location = new System.Drawing.Point(325, 34);
            this.xIRCUseColor.Name = "xIRCUseColor";
            this.xIRCUseColor.Size = new System.Drawing.Size(149, 19);
            this.xIRCUseColor.TabIndex = 2;
            this.xIRCUseColor.Text = "Use text colors on IRC.";
            this.xIRCUseColor.UseVisualStyleBackColor = true;
            // 
            // lIRCNoForwardingMessage
            // 
            this.lIRCNoForwardingMessage.AutoSize = true;
            this.lIRCNoForwardingMessage.Location = new System.Drawing.Point(35, 137);
            this.lIRCNoForwardingMessage.Name = "lIRCNoForwardingMessage";
            this.lIRCNoForwardingMessage.Size = new System.Drawing.Size(567, 15);
            this.lIRCNoForwardingMessage.TabIndex = 8;
            this.lIRCNoForwardingMessage.Text = "NOTE: If forwarding all messages is not enabled, only messages starting with a ha" +
    "sh (#) will be relayed.";
            // 
            // xIRCBotAnnounceIRCJoins
            // 
            this.xIRCBotAnnounceIRCJoins.AutoSize = true;
            this.xIRCBotAnnounceIRCJoins.Location = new System.Drawing.Point(325, 84);
            this.xIRCBotAnnounceIRCJoins.Name = "xIRCBotAnnounceIRCJoins";
            this.xIRCBotAnnounceIRCJoins.Size = new System.Drawing.Size(303, 19);
            this.xIRCBotAnnounceIRCJoins.TabIndex = 6;
            this.xIRCBotAnnounceIRCJoins.Text = "Announce people joining/leaving the IRC channels.";
            this.xIRCBotAnnounceIRCJoins.UseVisualStyleBackColor = true;
            // 
            // bColorIRC
            // 
            this.bColorIRC.BackColor = System.Drawing.Color.White;
            this.bColorIRC.Location = new System.Drawing.Point(152, 20);
            this.bColorIRC.Name = "bColorIRC";
            this.bColorIRC.Size = new System.Drawing.Size(100, 23);
            this.bColorIRC.TabIndex = 1;
            this.bColorIRC.UseVisualStyleBackColor = false;
            this.bColorIRC.Click += new System.EventHandler(this.bColorIRC_Click);
            // 
            // lColorIRC
            // 
            this.lColorIRC.AutoSize = true;
            this.lColorIRC.Location = new System.Drawing.Point(35, 24);
            this.lColorIRC.Name = "lColorIRC";
            this.lColorIRC.Size = new System.Drawing.Size(111, 15);
            this.lColorIRC.TabIndex = 0;
            this.lColorIRC.Text = "IRC message color";
            // 
            // xIRCBotForwardFromIRC
            // 
            this.xIRCBotForwardFromIRC.AutoSize = true;
            this.xIRCBotForwardFromIRC.Location = new System.Drawing.Point(38, 84);
            this.xIRCBotForwardFromIRC.Name = "xIRCBotForwardFromIRC";
            this.xIRCBotForwardFromIRC.Size = new System.Drawing.Size(240, 19);
            this.xIRCBotForwardFromIRC.TabIndex = 4;
            this.xIRCBotForwardFromIRC.Text = "Forward ALL chat from IRC to SERVER.";
            this.xIRCBotForwardFromIRC.UseVisualStyleBackColor = true;
            // 
            // xIRCBotAnnounceServerJoins
            // 
            this.xIRCBotAnnounceServerJoins.AutoSize = true;
            this.xIRCBotAnnounceServerJoins.Location = new System.Drawing.Point(325, 59);
            this.xIRCBotAnnounceServerJoins.Name = "xIRCBotAnnounceServerJoins";
            this.xIRCBotAnnounceServerJoins.Size = new System.Drawing.Size(279, 19);
            this.xIRCBotAnnounceServerJoins.TabIndex = 5;
            this.xIRCBotAnnounceServerJoins.Text = "Announce people joining/leaving the SERVER.";
            this.xIRCBotAnnounceServerJoins.UseVisualStyleBackColor = true;
            // 
            // xIRCBotForwardFromServer
            // 
            this.xIRCBotForwardFromServer.AutoSize = true;
            this.xIRCBotForwardFromServer.Location = new System.Drawing.Point(38, 59);
            this.xIRCBotForwardFromServer.Name = "xIRCBotForwardFromServer";
            this.xIRCBotForwardFromServer.Size = new System.Drawing.Size(240, 19);
            this.xIRCBotForwardFromServer.TabIndex = 3;
            this.xIRCBotForwardFromServer.Text = "Forward ALL chat from SERVER to IRC.";
            this.xIRCBotForwardFromServer.UseVisualStyleBackColor = true;
            // 
            // gIRCNetwork
            // 
            this.gIRCNetwork.Controls.Add(this.lIRCDelayUnits);
            this.gIRCNetwork.Controls.Add(this.xIRCRegisteredNick);
            this.gIRCNetwork.Controls.Add(this.tIRCNickServMessage);
            this.gIRCNetwork.Controls.Add(this.lIRCNickServMessage);
            this.gIRCNetwork.Controls.Add(this.tIRCNickServ);
            this.gIRCNetwork.Controls.Add(this.lIRCNickServ);
            this.gIRCNetwork.Controls.Add(this.nIRCDelay);
            this.gIRCNetwork.Controls.Add(this.lIRCDelay);
            this.gIRCNetwork.Controls.Add(this.lIRCBotChannels2);
            this.gIRCNetwork.Controls.Add(this.lIRCBotChannels3);
            this.gIRCNetwork.Controls.Add(this.tIRCBotChannels);
            this.gIRCNetwork.Controls.Add(this.lIRCBotChannels);
            this.gIRCNetwork.Controls.Add(this.nIRCBotPort);
            this.gIRCNetwork.Controls.Add(this.lIRCBotPort);
            this.gIRCNetwork.Controls.Add(this.tIRCBotNetwork);
            this.gIRCNetwork.Controls.Add(this.lIRCBotNetwork);
            this.gIRCNetwork.Controls.Add(this.lIRCBotNick);
            this.gIRCNetwork.Controls.Add(this.tIRCBotNick);
            this.gIRCNetwork.Location = new System.Drawing.Point(8, 40);
            this.gIRCNetwork.Name = "gIRCNetwork";
            this.gIRCNetwork.Size = new System.Drawing.Size(636, 160);
            this.gIRCNetwork.TabIndex = 4;
            this.gIRCNetwork.TabStop = false;
            this.gIRCNetwork.Text = "Network";
            // 
            // lIRCDelayUnits
            // 
            this.lIRCDelayUnits.AutoSize = true;
            this.lIRCDelayUnits.Location = new System.Drawing.Point(598, 22);
            this.lIRCDelayUnits.Name = "lIRCDelayUnits";
            this.lIRCDelayUnits.Size = new System.Drawing.Size(24, 15);
            this.lIRCDelayUnits.TabIndex = 6;
            this.lIRCDelayUnits.Text = "ms";
            // 
            // xIRCRegisteredNick
            // 
            this.xIRCRegisteredNick.AutoSize = true;
            this.xIRCRegisteredNick.Location = new System.Drawing.Point(265, 101);
            this.xIRCRegisteredNick.Name = "xIRCRegisteredNick";
            this.xIRCRegisteredNick.Size = new System.Drawing.Size(86, 19);
            this.xIRCRegisteredNick.TabIndex = 13;
            this.xIRCRegisteredNick.Text = "Registered";
            this.xIRCRegisteredNick.UseVisualStyleBackColor = true;
            this.xIRCRegisteredNick.CheckedChanged += new System.EventHandler(this.xIRCRegisteredNick_CheckedChanged);
            // 
            // tIRCNickServMessage
            // 
            this.tIRCNickServMessage.Enabled = false;
            this.tIRCNickServMessage.Location = new System.Drawing.Point(388, 126);
            this.tIRCNickServMessage.Name = "tIRCNickServMessage";
            this.tIRCNickServMessage.Size = new System.Drawing.Size(234, 21);
            this.tIRCNickServMessage.TabIndex = 17;
            // 
            // lIRCNickServMessage
            // 
            this.lIRCNickServMessage.AutoSize = true;
            this.lIRCNickServMessage.Enabled = false;
            this.lIRCNickServMessage.Location = new System.Drawing.Point(265, 129);
            this.lIRCNickServMessage.Name = "lIRCNickServMessage";
            this.lIRCNickServMessage.Size = new System.Drawing.Size(117, 15);
            this.lIRCNickServMessage.TabIndex = 16;
            this.lIRCNickServMessage.Text = "Authentication string";
            // 
            // tIRCNickServ
            // 
            this.tIRCNickServ.Enabled = false;
            this.tIRCNickServ.Location = new System.Drawing.Point(121, 126);
            this.tIRCNickServ.MaxLength = 32;
            this.tIRCNickServ.Name = "tIRCNickServ";
            this.tIRCNickServ.Size = new System.Drawing.Size(138, 21);
            this.tIRCNickServ.TabIndex = 15;
            // 
            // lIRCNickServ
            // 
            this.lIRCNickServ.AutoSize = true;
            this.lIRCNickServ.Enabled = false;
            this.lIRCNickServ.Location = new System.Drawing.Point(35, 129);
            this.lIRCNickServ.Name = "lIRCNickServ";
            this.lIRCNickServ.Size = new System.Drawing.Size(80, 15);
            this.lIRCNickServ.TabIndex = 14;
            this.lIRCNickServ.Text = "NickServ nick";
            // 
            // nIRCDelay
            // 
            this.nIRCDelay.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nIRCDelay.Location = new System.Drawing.Point(536, 20);
            this.nIRCDelay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nIRCDelay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nIRCDelay.Name = "nIRCDelay";
            this.nIRCDelay.Size = new System.Drawing.Size(56, 21);
            this.nIRCDelay.TabIndex = 5;
            this.nIRCDelay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lIRCDelay
            // 
            this.lIRCDelay.AutoSize = true;
            this.lIRCDelay.Location = new System.Drawing.Point(416, 22);
            this.lIRCDelay.Name = "lIRCDelay";
            this.lIRCDelay.Size = new System.Drawing.Size(114, 15);
            this.lIRCDelay.TabIndex = 4;
            this.lIRCDelay.Text = "Min message delay";
            // 
            // lIRCBotChannels2
            // 
            this.lIRCBotChannels2.AutoSize = true;
            this.lIRCBotChannels2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lIRCBotChannels2.Location = new System.Drawing.Point(15, 65);
            this.lIRCBotChannels2.Name = "lIRCBotChannels2";
            this.lIRCBotChannels2.Size = new System.Drawing.Size(97, 13);
            this.lIRCBotChannels2.TabIndex = 9;
            this.lIRCBotChannels2.Text = "(comma seperated)";
            // 
            // lIRCBotChannels3
            // 
            this.lIRCBotChannels3.AutoSize = true;
            this.lIRCBotChannels3.Location = new System.Drawing.Point(118, 71);
            this.lIRCBotChannels3.Name = "lIRCBotChannels3";
            this.lIRCBotChannels3.Size = new System.Drawing.Size(340, 15);
            this.lIRCBotChannels3.TabIndex = 10;
            this.lIRCBotChannels3.Text = "NOTE: Channel names are case-sensitive on some networks!";
            // 
            // tIRCBotChannels
            // 
            this.tIRCBotChannels.Location = new System.Drawing.Point(121, 47);
            this.tIRCBotChannels.MaxLength = 1000;
            this.tIRCBotChannels.Name = "tIRCBotChannels";
            this.tIRCBotChannels.Size = new System.Drawing.Size(501, 21);
            this.tIRCBotChannels.TabIndex = 8;
            // 
            // lIRCBotChannels
            // 
            this.lIRCBotChannels.AutoSize = true;
            this.lIRCBotChannels.Location = new System.Drawing.Point(20, 50);
            this.lIRCBotChannels.Name = "lIRCBotChannels";
            this.lIRCBotChannels.Size = new System.Drawing.Size(95, 15);
            this.lIRCBotChannels.TabIndex = 7;
            this.lIRCBotChannels.Text = "Channels to join";
            // 
            // nIRCBotPort
            // 
            this.nIRCBotPort.Location = new System.Drawing.Point(300, 20);
            this.nIRCBotPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nIRCBotPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nIRCBotPort.Name = "nIRCBotPort";
            this.nIRCBotPort.Size = new System.Drawing.Size(64, 21);
            this.nIRCBotPort.TabIndex = 3;
            this.nIRCBotPort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lIRCBotPort
            // 
            this.lIRCBotPort.AutoSize = true;
            this.lIRCBotPort.Location = new System.Drawing.Point(265, 22);
            this.lIRCBotPort.Name = "lIRCBotPort";
            this.lIRCBotPort.Size = new System.Drawing.Size(29, 15);
            this.lIRCBotPort.TabIndex = 2;
            this.lIRCBotPort.Text = "Port";
            // 
            // tIRCBotNetwork
            // 
            this.tIRCBotNetwork.Location = new System.Drawing.Point(121, 19);
            this.tIRCBotNetwork.MaxLength = 512;
            this.tIRCBotNetwork.Name = "tIRCBotNetwork";
            this.tIRCBotNetwork.Size = new System.Drawing.Size(138, 21);
            this.tIRCBotNetwork.TabIndex = 1;
            // 
            // lIRCBotNetwork
            // 
            this.lIRCBotNetwork.AutoSize = true;
            this.lIRCBotNetwork.Location = new System.Drawing.Point(26, 22);
            this.lIRCBotNetwork.Name = "lIRCBotNetwork";
            this.lIRCBotNetwork.Size = new System.Drawing.Size(93, 15);
            this.lIRCBotNetwork.TabIndex = 0;
            this.lIRCBotNetwork.Text = "IRC Server Host";
            // 
            // lIRCBotNick
            // 
            this.lIRCBotNick.AutoSize = true;
            this.lIRCBotNick.Location = new System.Drawing.Point(65, 102);
            this.lIRCBotNick.Name = "lIRCBotNick";
            this.lIRCBotNick.Size = new System.Drawing.Size(50, 15);
            this.lIRCBotNick.TabIndex = 11;
            this.lIRCBotNick.Text = "Bot nick";
            // 
            // tIRCBotNick
            // 
            this.tIRCBotNick.Location = new System.Drawing.Point(121, 99);
            this.tIRCBotNick.MaxLength = 32;
            this.tIRCBotNick.Name = "tIRCBotNick";
            this.tIRCBotNick.Size = new System.Drawing.Size(138, 21);
            this.tIRCBotNick.TabIndex = 12;
            // 
            // lIRCList
            // 
            this.lIRCList.AutoSize = true;
            this.lIRCList.Enabled = false;
            this.lIRCList.Location = new System.Drawing.Point(213, 14);
            this.lIRCList.Name = "lIRCList";
            this.lIRCList.Size = new System.Drawing.Size(105, 15);
            this.lIRCList.TabIndex = 1;
            this.lIRCList.Text = "Popular networks:";
            // 
            // xIRCBotEnabled
            // 
            this.xIRCBotEnabled.AutoSize = true;
            this.xIRCBotEnabled.Location = new System.Drawing.Point(14, 13);
            this.xIRCBotEnabled.Name = "xIRCBotEnabled";
            this.xIRCBotEnabled.Size = new System.Drawing.Size(149, 19);
            this.xIRCBotEnabled.TabIndex = 0;
            this.xIRCBotEnabled.Text = "Enable IRC integration";
            this.xIRCBotEnabled.UseVisualStyleBackColor = true;
            this.xIRCBotEnabled.CheckedChanged += new System.EventHandler(this.xIRC_CheckedChanged);
            // 
            // cIRCList
            // 
            this.cIRCList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cIRCList.Enabled = false;
            this.cIRCList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cIRCList.FormattingEnabled = true;
            this.cIRCList.Location = new System.Drawing.Point(321, 11);
            this.cIRCList.Name = "cIRCList";
            this.cIRCList.Size = new System.Drawing.Size(138, 23);
            this.cIRCList.TabIndex = 2;
            this.cIRCList.SelectedIndexChanged += new System.EventHandler(this.cIRCList_SelectedIndexChanged);
            // 
            // tabPlugins
            // 
            this.tabPlugins.BackColor = System.Drawing.Color.Red;
            this.tabPlugins.Controls.Add(this.groupBox6);
            this.tabPlugins.Controls.Add(this.gboPlugins);
            this.tabPlugins.Location = new System.Drawing.Point(4, 24);
            this.tabPlugins.Name = "tabPlugins";
            this.tabPlugins.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlugins.Size = new System.Drawing.Size(652, 482);
            this.tabPlugins.TabIndex = 13;
            this.tabPlugins.Text = "Plugins";
            // 
            // gboPlugins
            // 
            this.gboPlugins.Controls.Add(this.groupBox8);
            this.gboPlugins.Controls.Add(this.button1);
            this.gboPlugins.Controls.Add(this.gboPluginInfo);
            this.gboPlugins.Controls.Add(this.listPlugins);
            this.gboPlugins.Controls.Add(this.chkPlugins);
            this.gboPlugins.Location = new System.Drawing.Point(11, 6);
            this.gboPlugins.Name = "gboPlugins";
            this.gboPlugins.Size = new System.Drawing.Size(630, 470);
            this.gboPlugins.TabIndex = 0;
            this.gboPlugins.TabStop = false;
            this.gboPlugins.Text = "Plugins";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(464, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // gboPluginInfo
            // 
            this.gboPluginInfo.Controls.Add(this.propertyGrid1);
            this.gboPluginInfo.Location = new System.Drawing.Point(284, 46);
            this.gboPluginInfo.Name = "gboPluginInfo";
            this.gboPluginInfo.Size = new System.Drawing.Size(340, 418);
            this.gboPluginInfo.TabIndex = 6;
            this.gboPluginInfo.TabStop = false;
            this.gboPluginInfo.Text = "Properties";
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(6, 20);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(453, 392);
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.Click += new System.EventHandler(this.propertyGrid1_Click);
            // 
            // listPlugins
            // 
            this.listPlugins.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listPlugins.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listPlugins.FormattingEnabled = true;
            this.listPlugins.IntegralHeight = false;
            this.listPlugins.ItemHeight = 11;
            this.listPlugins.Location = new System.Drawing.Point(7, 46);
            this.listPlugins.Name = "listPlugins";
            this.listPlugins.Size = new System.Drawing.Size(271, 418);
            this.listPlugins.TabIndex = 2;
            this.listPlugins.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // chkPlugins
            // 
            this.chkPlugins.AutoSize = true;
            this.chkPlugins.Location = new System.Drawing.Point(7, 21);
            this.chkPlugins.Name = "chkPlugins";
            this.chkPlugins.Size = new System.Drawing.Size(109, 19);
            this.chkPlugins.TabIndex = 0;
            this.chkPlugins.Text = "Enable Plugins";
            this.chkPlugins.UseVisualStyleBackColor = true;
            this.chkPlugins.CheckedChanged += new System.EventHandler(this.chkPlugins_CheckedChanged);
            // 
            // tabAdvanced
            // 
            this.tabAdvanced.BackColor = System.Drawing.Color.Gray;
            this.tabAdvanced.Controls.Add(this.gPerformance);
            this.tabAdvanced.Controls.Add(this.gAdvancedMisc);
            this.tabAdvanced.Controls.Add(this.gCrashReport);
            this.tabAdvanced.Location = new System.Drawing.Point(4, 24);
            this.tabAdvanced.Name = "tabAdvanced";
            this.tabAdvanced.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.tabAdvanced.Size = new System.Drawing.Size(652, 482);
            this.tabAdvanced.TabIndex = 6;
            this.tabAdvanced.Text = "Advanced";
            // 
            // gPerformance
            // 
            this.gPerformance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gPerformance.Controls.Add(this.lAdvancedWarning);
            this.gPerformance.Controls.Add(this.xLowLatencyMode);
            this.gPerformance.Controls.Add(this.lProcessPriority);
            this.gPerformance.Controls.Add(this.cProcessPriority);
            this.gPerformance.Controls.Add(this.nTickInterval);
            this.gPerformance.Controls.Add(this.lTickIntervalUnits);
            this.gPerformance.Controls.Add(this.lTickInterval);
            this.gPerformance.Controls.Add(this.nThrottling);
            this.gPerformance.Controls.Add(this.lThrottling);
            this.gPerformance.Controls.Add(this.lThrottlingUnits);
            this.gPerformance.Location = new System.Drawing.Point(8, 318);
            this.gPerformance.Name = "gPerformance";
            this.gPerformance.Size = new System.Drawing.Size(636, 151);
            this.gPerformance.TabIndex = 2;
            this.gPerformance.TabStop = false;
            this.gPerformance.Text = "Performance";
            // 
            // lAdvancedWarning
            // 
            this.lAdvancedWarning.AutoSize = true;
            this.lAdvancedWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAdvancedWarning.Location = new System.Drawing.Point(15, 21);
            this.lAdvancedWarning.Name = "lAdvancedWarning";
            this.lAdvancedWarning.Size = new System.Drawing.Size(558, 30);
            this.lAdvancedWarning.TabIndex = 0;
            this.lAdvancedWarning.Text = "Warning: Altering these settings may decrease your server\'s stability and perform" +
    "ance.\r\nIf you\'re not sure what these settings do, you probably shouldn\'t change " +
    "them...";
            // 
            // xLowLatencyMode
            // 
            this.xLowLatencyMode.AutoSize = true;
            this.xLowLatencyMode.Location = new System.Drawing.Point(6, 64);
            this.xLowLatencyMode.Name = "xLowLatencyMode";
            this.xLowLatencyMode.Size = new System.Drawing.Size(544, 19);
            this.xLowLatencyMode.TabIndex = 3;
            this.xLowLatencyMode.Text = "Low-latency mode (disables Nagle\'s algorithm, reducing latency but increasing ban" +
    "dwidth use).";
            this.xLowLatencyMode.UseVisualStyleBackColor = true;
            // 
            // lProcessPriority
            // 
            this.lProcessPriority.AutoSize = true;
            this.lProcessPriority.Location = new System.Drawing.Point(19, 94);
            this.lProcessPriority.Name = "lProcessPriority";
            this.lProcessPriority.Size = new System.Drawing.Size(90, 15);
            this.lProcessPriority.TabIndex = 10;
            this.lProcessPriority.Text = "Process priority";
            // 
            // cProcessPriority
            // 
            this.cProcessPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cProcessPriority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cProcessPriority.Items.AddRange(new object[] {
            "(system default)",
            "High",
            "Above Normal",
            "Normal",
            "Below Normal",
            "Low"});
            this.cProcessPriority.Location = new System.Drawing.Point(115, 91);
            this.cProcessPriority.Name = "cProcessPriority";
            this.cProcessPriority.Size = new System.Drawing.Size(109, 23);
            this.cProcessPriority.TabIndex = 11;
            // 
            // nTickInterval
            // 
            this.nTickInterval.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nTickInterval.Location = new System.Drawing.Point(429, 92);
            this.nTickInterval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nTickInterval.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nTickInterval.Name = "nTickInterval";
            this.nTickInterval.Size = new System.Drawing.Size(70, 21);
            this.nTickInterval.TabIndex = 13;
            this.nTickInterval.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lTickIntervalUnits
            // 
            this.lTickIntervalUnits.AutoSize = true;
            this.lTickIntervalUnits.Location = new System.Drawing.Point(505, 94);
            this.lTickIntervalUnits.Name = "lTickIntervalUnits";
            this.lTickIntervalUnits.Size = new System.Drawing.Size(24, 15);
            this.lTickIntervalUnits.TabIndex = 14;
            this.lTickIntervalUnits.Text = "ms";
            // 
            // lTickInterval
            // 
            this.lTickInterval.AutoSize = true;
            this.lTickInterval.Location = new System.Drawing.Point(352, 94);
            this.lTickInterval.Name = "lTickInterval";
            this.lTickInterval.Size = new System.Drawing.Size(71, 15);
            this.lTickInterval.TabIndex = 12;
            this.lTickInterval.Text = "Tick interval";
            // 
            // nThrottling
            // 
            this.nThrottling.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nThrottling.Location = new System.Drawing.Point(115, 120);
            this.nThrottling.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nThrottling.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nThrottling.Name = "nThrottling";
            this.nThrottling.Size = new System.Drawing.Size(70, 21);
            this.nThrottling.TabIndex = 16;
            this.nThrottling.Value = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            // 
            // lThrottling
            // 
            this.lThrottling.AutoSize = true;
            this.lThrottling.Location = new System.Drawing.Point(22, 122);
            this.lThrottling.Name = "lThrottling";
            this.lThrottling.Size = new System.Drawing.Size(87, 15);
            this.lThrottling.TabIndex = 15;
            this.lThrottling.Text = "Block throttling";
            // 
            // lThrottlingUnits
            // 
            this.lThrottlingUnits.AutoSize = true;
            this.lThrottlingUnits.Location = new System.Drawing.Point(191, 122);
            this.lThrottlingUnits.Name = "lThrottlingUnits";
            this.lThrottlingUnits.Size = new System.Drawing.Size(129, 15);
            this.lThrottlingUnits.TabIndex = 17;
            this.lThrottlingUnits.Text = "blocks / second / client";
            // 
            // gAdvancedMisc
            // 
            this.gAdvancedMisc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gAdvancedMisc.Controls.Add(this.xAutoRank);
            this.gAdvancedMisc.Controls.Add(this.nMaxUndoStates);
            this.gAdvancedMisc.Controls.Add(this.lMaxUndoStates);
            this.gAdvancedMisc.Controls.Add(this.lIPWarning);
            this.gAdvancedMisc.Controls.Add(this.tIP);
            this.gAdvancedMisc.Controls.Add(this.xIP);
            this.gAdvancedMisc.Controls.Add(this.lConsoleName);
            this.gAdvancedMisc.Controls.Add(this.tConsoleName);
            this.gAdvancedMisc.Controls.Add(this.nMaxUndo);
            this.gAdvancedMisc.Controls.Add(this.lMaxUndoUnits);
            this.gAdvancedMisc.Controls.Add(this.xMaxUndo);
            this.gAdvancedMisc.Controls.Add(this.xRelayAllBlockUpdates);
            this.gAdvancedMisc.Controls.Add(this.xNoPartialPositionUpdates);
            this.gAdvancedMisc.Location = new System.Drawing.Point(8, 99);
            this.gAdvancedMisc.Name = "gAdvancedMisc";
            this.gAdvancedMisc.Size = new System.Drawing.Size(636, 213);
            this.gAdvancedMisc.TabIndex = 1;
            this.gAdvancedMisc.TabStop = false;
            this.gAdvancedMisc.Text = "Miscellaneous";
            // 
            // xAutoRank
            // 
            this.xAutoRank.AutoSize = true;
            this.xAutoRank.Location = new System.Drawing.Point(9, 188);
            this.xAutoRank.Name = "xAutoRank";
            this.xAutoRank.Size = new System.Drawing.Size(121, 19);
            this.xAutoRank.TabIndex = 24;
            this.xAutoRank.Text = "Enable AutoRank";
            this.xAutoRank.UseVisualStyleBackColor = true;
            // 
            // nMaxUndoStates
            // 
            this.nMaxUndoStates.Location = new System.Drawing.Point(115, 71);
            this.nMaxUndoStates.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nMaxUndoStates.Name = "nMaxUndoStates";
            this.nMaxUndoStates.Size = new System.Drawing.Size(58, 21);
            this.nMaxUndoStates.TabIndex = 23;
            this.nMaxUndoStates.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nMaxUndoStates.ValueChanged += new System.EventHandler(this.nMaxUndo_ValueChanged);
            // 
            // lMaxUndoStates
            // 
            this.lMaxUndoStates.AutoSize = true;
            this.lMaxUndoStates.Location = new System.Drawing.Point(179, 73);
            this.lMaxUndoStates.Name = "lMaxUndoStates";
            this.lMaxUndoStates.Size = new System.Drawing.Size(72, 15);
            this.lMaxUndoStates.TabIndex = 22;
            this.lMaxUndoStates.Text = "states, up to";
            // 
            // lIPWarning
            // 
            this.lIPWarning.AutoSize = true;
            this.lIPWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lIPWarning.Location = new System.Drawing.Point(112, 131);
            this.lIPWarning.Name = "lIPWarning";
            this.lIPWarning.Size = new System.Drawing.Size(408, 13);
            this.lIPWarning.TabIndex = 20;
            this.lIPWarning.Text = "Note: You do not need to specify an IP address unless you have multiple NICs or I" +
    "Ps.";
            // 
            // tIP
            // 
            this.tIP.Location = new System.Drawing.Point(115, 107);
            this.tIP.MaxLength = 15;
            this.tIP.Name = "tIP";
            this.tIP.Size = new System.Drawing.Size(97, 21);
            this.tIP.TabIndex = 19;
            this.tIP.Validating += new System.ComponentModel.CancelEventHandler(this.tIP_Validating);
            // 
            // xIP
            // 
            this.xIP.AutoSize = true;
            this.xIP.Location = new System.Drawing.Point(6, 109);
            this.xIP.Name = "xIP";
            this.xIP.Size = new System.Drawing.Size(103, 19);
            this.xIP.TabIndex = 18;
            this.xIP.Text = "Designated IP";
            this.xIP.UseVisualStyleBackColor = true;
            this.xIP.CheckedChanged += new System.EventHandler(this.xIP_CheckedChanged);
            // 
            // lConsoleName
            // 
            this.lConsoleName.AutoSize = true;
            this.lConsoleName.Location = new System.Drawing.Point(6, 161);
            this.lConsoleName.Name = "lConsoleName";
            this.lConsoleName.Size = new System.Drawing.Size(87, 15);
            this.lConsoleName.TabIndex = 7;
            this.lConsoleName.Text = "Console name";
            // 
            // tConsoleName
            // 
            this.tConsoleName.Location = new System.Drawing.Point(115, 158);
            this.tConsoleName.Name = "tConsoleName";
            this.tConsoleName.Size = new System.Drawing.Size(167, 21);
            this.tConsoleName.TabIndex = 8;
            // 
            // nMaxUndo
            // 
            this.nMaxUndo.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nMaxUndo.Location = new System.Drawing.Point(257, 71);
            this.nMaxUndo.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nMaxUndo.Name = "nMaxUndo";
            this.nMaxUndo.Size = new System.Drawing.Size(86, 21);
            this.nMaxUndo.TabIndex = 5;
            this.nMaxUndo.Value = new decimal(new int[] {
            2000000,
            0,
            0,
            0});
            this.nMaxUndo.ValueChanged += new System.EventHandler(this.nMaxUndo_ValueChanged);
            // 
            // lMaxUndoUnits
            // 
            this.lMaxUndoUnits.AutoSize = true;
            this.lMaxUndoUnits.Location = new System.Drawing.Point(349, 73);
            this.lMaxUndoUnits.Name = "lMaxUndoUnits";
            this.lMaxUndoUnits.Size = new System.Drawing.Size(259, 15);
            this.lMaxUndoUnits.TabIndex = 6;
            this.lMaxUndoUnits.Text = "blocks each (up to 16.0 MB of RAM per player)";
            // 
            // xMaxUndo
            // 
            this.xMaxUndo.AutoSize = true;
            this.xMaxUndo.Checked = true;
            this.xMaxUndo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.xMaxUndo.Location = new System.Drawing.Point(6, 72);
            this.xMaxUndo.Name = "xMaxUndo";
            this.xMaxUndo.Size = new System.Drawing.Size(100, 19);
            this.xMaxUndo.TabIndex = 4;
            this.xMaxUndo.Text = "Limit /undo to";
            this.xMaxUndo.UseVisualStyleBackColor = true;
            this.xMaxUndo.CheckedChanged += new System.EventHandler(this.xMaxUndo_CheckedChanged);
            // 
            // xRelayAllBlockUpdates
            // 
            this.xRelayAllBlockUpdates.AutoSize = true;
            this.xRelayAllBlockUpdates.Location = new System.Drawing.Point(6, 21);
            this.xRelayAllBlockUpdates.Name = "xRelayAllBlockUpdates";
            this.xRelayAllBlockUpdates.Size = new System.Drawing.Size(560, 19);
            this.xRelayAllBlockUpdates.TabIndex = 1;
            this.xRelayAllBlockUpdates.Text = "When a player changes a block, send him the redundant update packet anyway (origi" +
    "nal behavior).";
            this.xRelayAllBlockUpdates.UseVisualStyleBackColor = true;
            // 
            // xNoPartialPositionUpdates
            // 
            this.xNoPartialPositionUpdates.AutoSize = true;
            this.xNoPartialPositionUpdates.Location = new System.Drawing.Point(6, 46);
            this.xNoPartialPositionUpdates.Name = "xNoPartialPositionUpdates";
            this.xNoPartialPositionUpdates.Size = new System.Drawing.Size(326, 19);
            this.xNoPartialPositionUpdates.TabIndex = 2;
            this.xNoPartialPositionUpdates.Text = "Do not use partial position updates (opcodes 9, 10, 11).";
            this.xNoPartialPositionUpdates.UseVisualStyleBackColor = true;
            // 
            // gCrashReport
            // 
            this.gCrashReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gCrashReport.Controls.Add(this.xCrash);
            this.gCrashReport.Controls.Add(this.lCrashReportDisclaimer);
            this.gCrashReport.Location = new System.Drawing.Point(8, 13);
            this.gCrashReport.Name = "gCrashReport";
            this.gCrashReport.Size = new System.Drawing.Size(636, 80);
            this.gCrashReport.TabIndex = 0;
            this.gCrashReport.TabStop = false;
            this.gCrashReport.Text = "Crash Reporting";
            // 
            // xCrash
            // 
            this.xCrash.AutoSize = true;
            this.xCrash.Location = new System.Drawing.Point(25, 25);
            this.xCrash.Name = "xCrash";
            this.xCrash.Size = new System.Drawing.Size(15, 14);
            this.xCrash.TabIndex = 2;
            this.xCrash.UseVisualStyleBackColor = true;
            // 
            // lCrashReportDisclaimer
            // 
            this.lCrashReportDisclaimer.AutoSize = true;
            this.lCrashReportDisclaimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCrashReportDisclaimer.Location = new System.Drawing.Point(45, 26);
            this.lCrashReportDisclaimer.Name = "lCrashReportDisclaimer";
            this.lCrashReportDisclaimer.Size = new System.Drawing.Size(468, 39);
            this.lCrashReportDisclaimer.TabIndex = 1;
            this.lCrashReportDisclaimer.Text = "Send all Crash Reports To The GemsCraft Dev Team\r\nCrash reports are when serious " +
    "unexpected errors occur. Being able to receive crash reports helps\r\nidentify bug" +
    "s and improve GemsCraft! ";
            // 
            // tabMisc
            // 
            this.tabMisc.BackColor = System.Drawing.Color.Indigo;
            this.tabMisc.Controls.Add(this.groupBox3);
            this.tabMisc.Controls.Add(this.groupBox1);
            this.tabMisc.Location = new System.Drawing.Point(4, 24);
            this.tabMisc.Name = "tabMisc";
            this.tabMisc.Padding = new System.Windows.Forms.Padding(3);
            this.tabMisc.Size = new System.Drawing.Size(652, 482);
            this.tabMisc.TabIndex = 11;
            this.tabMisc.Text = "Misc";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.websiteURL);
            this.groupBox3.Controls.Add(this.ReqsEditor);
            this.groupBox3.Controls.Add(this.SwearEditor);
            this.groupBox3.Controls.Add(this.MaxCapsValue);
            this.groupBox3.Controls.Add(this.MaxCaps);
            this.groupBox3.Controls.Add(this.SwearBox);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(31, 199);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(595, 142);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Other Configurations";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 15);
            this.label5.TabIndex = 28;
            this.label5.Text = "WebsiteURL";
            // 
            // websiteURL
            // 
            this.websiteURL.Location = new System.Drawing.Point(110, 67);
            this.websiteURL.Name = "websiteURL";
            this.websiteURL.Size = new System.Drawing.Size(212, 21);
            this.websiteURL.TabIndex = 28;
            this.websiteURL.TextChanged += new System.EventHandler(this.websiteURL_TextChanged);
            // 
            // ReqsEditor
            // 
            this.ReqsEditor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ReqsEditor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.ReqsEditor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.ReqsEditor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReqsEditor.Location = new System.Drawing.Point(442, 94);
            this.ReqsEditor.Name = "ReqsEditor";
            this.ReqsEditor.Size = new System.Drawing.Size(125, 23);
            this.ReqsEditor.TabIndex = 26;
            this.ReqsEditor.Text = "Edit Requirements";
            this.ReqsEditor.UseVisualStyleBackColor = false;
            this.ReqsEditor.Click += new System.EventHandler(this.ReqsEditor_Click);
            // 
            // SwearEditor
            // 
            this.SwearEditor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SwearEditor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.SwearEditor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.SwearEditor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SwearEditor.Location = new System.Drawing.Point(442, 65);
            this.SwearEditor.Name = "SwearEditor";
            this.SwearEditor.Size = new System.Drawing.Size(125, 23);
            this.SwearEditor.TabIndex = 25;
            this.SwearEditor.Text = "Edit Profanity List";
            this.SwearEditor.UseVisualStyleBackColor = false;
            this.SwearEditor.Click += new System.EventHandler(this.SwearEditor_Click);
            // 
            // MaxCapsValue
            // 
            this.MaxCapsValue.Location = new System.Drawing.Point(110, 32);
            this.MaxCapsValue.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.MaxCapsValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxCapsValue.Name = "MaxCapsValue";
            this.MaxCapsValue.Size = new System.Drawing.Size(75, 21);
            this.MaxCapsValue.TabIndex = 21;
            this.MaxCapsValue.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // MaxCaps
            // 
            this.MaxCaps.AutoSize = true;
            this.MaxCaps.Location = new System.Drawing.Point(10, 34);
            this.MaxCaps.Name = "MaxCaps";
            this.MaxCaps.Size = new System.Drawing.Size(94, 15);
            this.MaxCaps.TabIndex = 20;
            this.MaxCaps.Text = "Maximum Caps";
            // 
            // SwearBox
            // 
            this.SwearBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SwearBox.HideSelection = false;
            this.SwearBox.Location = new System.Drawing.Point(442, 34);
            this.SwearBox.MaxLength = 64;
            this.SwearBox.Name = "SwearBox";
            this.SwearBox.Size = new System.Drawing.Size(125, 21);
            this.SwearBox.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(229, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 15);
            this.label3.TabIndex = 23;
            this.label3.Text = "Word for swears to be replaced with: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.CustomColor);
            this.groupBox1.Controls.Add(this.CustomText);
            this.groupBox1.Controls.Add(this.CustomName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CustomAliases);
            this.groupBox1.Location = new System.Drawing.Point(31, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(595, 146);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Custom Chat Channel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "Custom Chat Channel Command Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Help;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(450, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 60);
            this.label4.TabIndex = 25;
            this.label4.Text = "The name should be \r\nin this format: \r\n\'staffchat\'. No spaces or \r\nsymbols (inclu" +
    "ding \"/\")";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CustomColor
            // 
            this.CustomColor.BackColor = System.Drawing.Color.White;
            this.CustomColor.Location = new System.Drawing.Point(244, 62);
            this.CustomColor.Name = "CustomColor";
            this.CustomColor.Size = new System.Drawing.Size(100, 23);
            this.CustomColor.TabIndex = 15;
            this.CustomColor.UseVisualStyleBackColor = false;
            this.CustomColor.Click += new System.EventHandler(this.button1_Click);
            // 
            // CustomText
            // 
            this.CustomText.AutoSize = true;
            this.CustomText.Location = new System.Drawing.Point(82, 70);
            this.CustomText.Name = "CustomText";
            this.CustomText.Size = new System.Drawing.Size(158, 15);
            this.CustomText.TabIndex = 14;
            this.CustomText.Text = "Custom Chat Channel Color";
            this.CustomText.Click += new System.EventHandler(this.label1_Click);
            // 
            // CustomName
            // 
            this.CustomName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomName.HideSelection = false;
            this.CustomName.Location = new System.Drawing.Point(246, 20);
            this.CustomName.MaxLength = 64;
            this.CustomName.Name = "CustomName";
            this.CustomName.Size = new System.Drawing.Size(169, 21);
            this.CustomName.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "Custom Chat Channel Aliases";
            // 
            // CustomAliases
            // 
            this.CustomAliases.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomAliases.HideSelection = false;
            this.CustomAliases.Location = new System.Drawing.Point(244, 109);
            this.CustomAliases.MaxLength = 64;
            this.CustomAliases.Name = "CustomAliases";
            this.CustomAliases.Size = new System.Drawing.Size(169, 21);
            this.CustomAliases.TabIndex = 19;
            // 
            // bOK
            // 
            this.bOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bOK.BackColor = System.Drawing.Color.Brown;
            this.bOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bOK.Location = new System.Drawing.Point(360, 528);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(100, 28);
            this.bOK.TabIndex = 1;
            this.bOK.Text = "OK";
            this.bOK.UseVisualStyleBackColor = false;
            this.bOK.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.BackColor = System.Drawing.Color.Brown;
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCancel.Location = new System.Drawing.Point(466, 528);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(100, 28);
            this.bCancel.TabIndex = 2;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = false;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bResetTab
            // 
            this.bResetTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bResetTab.BackColor = System.Drawing.Color.Gainsboro;
            this.bResetTab.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bResetTab.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.bResetTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bResetTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bResetTab.Location = new System.Drawing.Point(132, 528);
            this.bResetTab.Name = "bResetTab";
            this.bResetTab.Size = new System.Drawing.Size(100, 28);
            this.bResetTab.TabIndex = 5;
            this.bResetTab.Text = "Reset Tab";
            this.bResetTab.UseVisualStyleBackColor = false;
            this.bResetTab.Click += new System.EventHandler(this.bResetTab_Click);
            // 
            // bResetAll
            // 
            this.bResetAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bResetAll.BackColor = System.Drawing.Color.Gainsboro;
            this.bResetAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.bResetAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.bResetAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bResetAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bResetAll.Location = new System.Drawing.Point(12, 528);
            this.bResetAll.Name = "bResetAll";
            this.bResetAll.Size = new System.Drawing.Size(114, 28);
            this.bResetAll.TabIndex = 4;
            this.bResetAll.Text = "Reset All Defaults";
            this.bResetAll.UseVisualStyleBackColor = false;
            this.bResetAll.Click += new System.EventHandler(this.bResetAll_Click);
            // 
            // bApply
            // 
            this.bApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bApply.BackColor = System.Drawing.Color.Brown;
            this.bApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bApply.Location = new System.Drawing.Point(572, 528);
            this.bApply.Name = "bApply";
            this.bApply.Size = new System.Drawing.Size(100, 28);
            this.bApply.TabIndex = 3;
            this.bApply.Text = "Apply";
            this.bApply.UseVisualStyleBackColor = false;
            this.bApply.Click += new System.EventHandler(this.bApply_Click);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 11111;
            this.toolTip.InitialDelay = 500;
            this.toolTip.IsBalloon = true;
            this.toolTip.ReshowDelay = 100;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button2);
            this.groupBox6.Controls.Add(this.groupBox7);
            this.groupBox6.Controls.Add(this.listBox1);
            this.groupBox6.Controls.Add(this.checkBox1);
            this.groupBox6.Location = new System.Drawing.Point(11, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(630, 470);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Plugins";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(464, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "button1";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.propertyGrid2);
            this.groupBox7.Location = new System.Drawing.Point(284, 46);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(340, 418);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Properties";
            // 
            // propertyGrid2
            // 
            this.propertyGrid2.Location = new System.Drawing.Point(6, 20);
            this.propertyGrid2.Name = "propertyGrid2";
            this.propertyGrid2.Size = new System.Drawing.Size(328, 392);
            this.propertyGrid2.TabIndex = 0;
            this.propertyGrid2.Click += new System.EventHandler(this.propertyGrid1_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.IntegralHeight = false;
            this.listBox1.ItemHeight = 11;
            this.listBox1.Location = new System.Drawing.Point(7, 46);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(271, 418);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(7, 21);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(109, 19);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Enable Plugins";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.chkPlugins_CheckedChanged);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.button3);
            this.groupBox8.Controls.Add(this.groupBox9);
            this.groupBox8.Controls.Add(this.listBox2);
            this.groupBox8.Controls.Add(this.checkBox2);
            this.groupBox8.Location = new System.Drawing.Point(0, 0);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(630, 470);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Plugins";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(464, 21);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "button1";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.propertyGrid3);
            this.groupBox9.Location = new System.Drawing.Point(284, 46);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(340, 418);
            this.groupBox9.TabIndex = 6;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Properties";
            // 
            // propertyGrid3
            // 
            this.propertyGrid3.Location = new System.Drawing.Point(6, 20);
            this.propertyGrid3.Name = "propertyGrid3";
            this.propertyGrid3.Size = new System.Drawing.Size(328, 392);
            this.propertyGrid3.TabIndex = 0;
            this.propertyGrid3.Click += new System.EventHandler(this.propertyGrid1_Click);
            // 
            // listBox2
            // 
            this.listBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox2.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.IntegralHeight = false;
            this.listBox2.ItemHeight = 11;
            this.listBox2.Location = new System.Drawing.Point(7, 46);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(271, 418);
            this.listBox2.TabIndex = 2;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(7, 21);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(109, 19);
            this.checkBox2.TabIndex = 0;
            this.checkBox2.Text = "Enable Plugins";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.chkPlugins_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(684, 568);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.bApply);
            this.Controls.Add(this.bResetAll);
            this.Controls.Add(this.bResetTab);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 547);
            this.Name = "MainForm";
            this.Text = "GemsCraft Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigUI_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabs.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.gBasic.ResumeLayout(false);
            this.gBasic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxPlayersPerWorld)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUploadBandwidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxPlayers)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.gInformation.ResumeLayout(false);
            this.gInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nAnnouncements)).EndInit();
            this.tabChat.ResumeLayout(false);
            this.gAppearence.ResumeLayout(false);
            this.gAppearence.PerformLayout();
            this.gChatColors.ResumeLayout(false);
            this.gChatColors.PerformLayout();
            this.tabWorlds.ResumeLayout(false);
            this.tabWorlds.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorlds)).EndInit();
            this.tabRanks.ResumeLayout(false);
            this.tabRanks.PerformLayout();
            this.gPermissionLimits.ResumeLayout(false);
            this.gRankOptions.ResumeLayout(false);
            this.gRankOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nFillLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCopyPasteSlots)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nAntiGriefSeconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDrawLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nKickIdle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nAntiGriefBlocks)).EndInit();
            this.tabCPE.ResumeLayout(false);
            this.gboHeldBlock.ResumeLayout(false);
            this.gboHeldBlock.PerformLayout();
            this.gboClickDistance.ResumeLayout(false);
            this.gboClickDistance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinDistance)).EndInit();
            this.gboCustomBlocks.ResumeLayout(false);
            this.gboMessageType.ResumeLayout(false);
            this.gboMessageType.PerformLayout();
            this.tabSecurity.ResumeLayout(false);
            this.gBlockDB.ResumeLayout(false);
            this.gBlockDB.PerformLayout();
            this.gSecurityMisc.ResumeLayout(false);
            this.gSecurityMisc.PerformLayout();
            this.gSpamChat.ResumeLayout(false);
            this.gSpamChat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nAntispamMaxWarnings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSpamMute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nAntispamInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nAntispamMessageCount)).EndInit();
            this.gVerify.ResumeLayout(false);
            this.gVerify.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxConnectionsPerIP)).EndInit();
            this.tabSavingAndBackup.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.gDataBackup.ResumeLayout(false);
            this.gDataBackup.PerformLayout();
            this.gSaving.ResumeLayout(false);
            this.gSaving.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSaveInterval)).EndInit();
            this.gBackups.ResumeLayout(false);
            this.gBackups.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxBackupSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxBackups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nBackupInterval)).EndInit();
            this.tabLogging.ResumeLayout(false);
            this.gLogFile.ResumeLayout(false);
            this.gLogFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nLogLimit)).EndInit();
            this.gConsole.ResumeLayout(false);
            this.gConsole.PerformLayout();
            this.tabIRC.ResumeLayout(false);
            this.tabIRC.PerformLayout();
            this.gIRCAdv.ResumeLayout(false);
            this.gIRCAdv.PerformLayout();
            this.gIRCOptions.ResumeLayout(false);
            this.gIRCOptions.PerformLayout();
            this.gIRCNetwork.ResumeLayout(false);
            this.gIRCNetwork.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nIRCDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nIRCBotPort)).EndInit();
            this.tabPlugins.ResumeLayout(false);
            this.gboPlugins.ResumeLayout(false);
            this.gboPlugins.PerformLayout();
            this.gboPluginInfo.ResumeLayout(false);
            this.tabAdvanced.ResumeLayout(false);
            this.gPerformance.ResumeLayout(false);
            this.gPerformance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nTickInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nThrottling)).EndInit();
            this.gAdvancedMisc.ResumeLayout(false);
            this.gAdvancedMisc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxUndoStates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxUndo)).EndInit();
            this.gCrashReport.ResumeLayout(false);
            this.gCrashReport.PerformLayout();
            this.tabMisc.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxCapsValue)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bResetTab;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabRanks;
        private System.Windows.Forms.Label lServerName;
        private System.Windows.Forms.TextBox tServerName;
        private System.Windows.Forms.Label lMOTD;
        private System.Windows.Forms.TextBox tMOTD;
        private System.Windows.Forms.Label lMaxPlayers;
        private System.Windows.Forms.NumericUpDown nMaxPlayers;
        private System.Windows.Forms.TabPage tabSavingAndBackup;
        private System.Windows.Forms.ComboBox cPublic;
        private System.Windows.Forms.Label lPublic;
        private System.Windows.Forms.Button bMeasure;
        private System.Windows.Forms.Label lUploadBandwidthUnits;
        private System.Windows.Forms.NumericUpDown nUploadBandwidth;
        private System.Windows.Forms.Label lUploadBandwidth;
        private System.Windows.Forms.TabPage tabLogging;
        private System.Windows.Forms.TabPage tabAdvanced;
        private System.Windows.Forms.Label lTickIntervalUnits;
        private System.Windows.Forms.NumericUpDown nTickInterval;
        private System.Windows.Forms.Label lTickInterval;
        private System.Windows.Forms.Label lAdvancedWarning;
        private System.Windows.Forms.ListBox vRanks;
        private System.Windows.Forms.Button bAddRank;
        private System.Windows.Forms.Label lPermissions;
        private System.Windows.Forms.ListView vPermissions;
        private System.Windows.Forms.ColumnHeader chPermissions;
        private System.Windows.Forms.GroupBox gRankOptions;
        private System.Windows.Forms.Button bDeleteRank;
        private System.Windows.Forms.Label lRankColor;
        private System.Windows.Forms.TextBox tRankName;
        private System.Windows.Forms.Label lRankName;
        private System.Windows.Forms.TextBox tPrefix;
        private System.Windows.Forms.Label lPrefix;
        private System.Windows.Forms.Label lAntiGrief2;
        private System.Windows.Forms.NumericUpDown nAntiGriefBlocks;
        private System.Windows.Forms.CheckBox xDrawLimit;
        private System.Windows.Forms.Label lDrawLimitUnits;
        private System.Windows.Forms.GroupBox gBasic;
        private System.Windows.Forms.ComboBox cDefaultRank;
        private System.Windows.Forms.Label lDefaultRank;
        private System.Windows.Forms.GroupBox gSaving;
        private System.Windows.Forms.NumericUpDown nSaveInterval;
        private System.Windows.Forms.Label lSaveIntervalUnits;
        private System.Windows.Forms.CheckBox xSaveInterval;
        private System.Windows.Forms.GroupBox gBackups;
        private System.Windows.Forms.CheckBox xBackupOnStartup;
        private System.Windows.Forms.NumericUpDown nBackupInterval;
        private System.Windows.Forms.Label lBackupIntervalUnits;
        private System.Windows.Forms.CheckBox xBackupInterval;
        private System.Windows.Forms.CheckBox xBackupOnJoin;
        private System.Windows.Forms.CheckBox xRelayAllBlockUpdates;
        private System.Windows.Forms.ComboBox cProcessPriority;
        private System.Windows.Forms.Label lProcessPriority;
        private System.Windows.Forms.Button bResetAll;
        private System.Windows.Forms.GroupBox gLogFile;
        private System.Windows.Forms.ComboBox cLogMode;
        private System.Windows.Forms.Label lLogMode;
        private System.Windows.Forms.GroupBox gConsole;
        private System.Windows.Forms.ListView vLogFileOptions;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label lLogLimitUnits;
        private System.Windows.Forms.NumericUpDown nLogLimit;
        private System.Windows.Forms.ListView vConsoleOptions;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.CheckBox xLogLimit;
        private System.Windows.Forms.CheckBox xReserveSlot;
        private System.Windows.Forms.NumericUpDown nDrawLimit;
        private System.Windows.Forms.Label lKickIdleUnits;
        private System.Windows.Forms.NumericUpDown nKickIdle;
        private System.Windows.Forms.CheckBox xKickIdle;
        private System.Windows.Forms.CheckBox xNoPartialPositionUpdates;
        private System.Windows.Forms.Label lMaxBackups;
        private System.Windows.Forms.NumericUpDown nMaxBackups;
        private System.Windows.Forms.Label lMaxBackupSize;
        private System.Windows.Forms.NumericUpDown nMaxBackupSize;
        private System.Windows.Forms.CheckBox xMaxBackupSize;
        private System.Windows.Forms.CheckBox xMaxBackups;
        private System.Windows.Forms.Label lThrottlingUnits;
        private System.Windows.Forms.NumericUpDown nThrottling;
        private System.Windows.Forms.Label lThrottling;
        private System.Windows.Forms.Button bApply;
        private System.Windows.Forms.Button bColorRank;
        private System.Windows.Forms.TabPage tabSecurity;
        private System.Windows.Forms.GroupBox gVerify;
        private System.Windows.Forms.Label lVerifyNames;
        private System.Windows.Forms.ComboBox cVerifyNames;
        private System.Windows.Forms.GroupBox gSpamChat;
        private System.Windows.Forms.Label lAntispamInterval;
        private System.Windows.Forms.NumericUpDown nAntispamInterval;
        private System.Windows.Forms.Label lAntispamMessageCount;
        private System.Windows.Forms.NumericUpDown nAntispamMessageCount;
        private System.Windows.Forms.Label lSpamChat;
        private System.Windows.Forms.CheckBox xLowLatencyMode;
        private System.Windows.Forms.CheckBox xAntispamKicks;
        private System.Windows.Forms.Label lSpamMuteSeconds;
        private System.Windows.Forms.NumericUpDown nSpamMute;
        private System.Windows.Forms.Label lSpamMute;
        private System.Windows.Forms.Label lAntispamMaxWarnings;
        private System.Windows.Forms.NumericUpDown nAntispamMaxWarnings;
        private System.Windows.Forms.CheckBox xBackupOnlyWhenChanged;
        private System.Windows.Forms.Label lPort;
        private System.Windows.Forms.NumericUpDown nPort;
        private System.Windows.Forms.Button bRules;
        private System.Windows.Forms.TabPage tabIRC;
        private System.Windows.Forms.GroupBox gIRCNetwork;
        private System.Windows.Forms.CheckBox xIRCBotEnabled;
        private System.Windows.Forms.CheckBox xIRCBotAnnounceServerJoins;
        private System.Windows.Forms.Label lIRCBotChannels;
        private System.Windows.Forms.NumericUpDown nIRCBotPort;
        private System.Windows.Forms.Label lIRCBotPort;
        private System.Windows.Forms.TextBox tIRCBotNetwork;
        private System.Windows.Forms.Label lIRCBotNetwork;
        private System.Windows.Forms.Label lIRCBotNick;
        private System.Windows.Forms.TextBox tIRCBotNick;
        private System.Windows.Forms.CheckBox xIRCBotForwardFromServer;
        private System.Windows.Forms.GroupBox gIRCOptions;
        private System.Windows.Forms.TextBox tIRCBotChannels;
        private System.Windows.Forms.Label lIRCBotChannels3;
        private System.Windows.Forms.Label lIRCBotChannels2;
        private System.Windows.Forms.CheckBox xIRCBotForwardFromIRC;
        private System.Windows.Forms.CheckBox xMaxConnectionsPerIP;
        private System.Windows.Forms.TabPage tabWorlds;
        private System.Windows.Forms.DataGridView dgvWorlds;
        private System.Windows.Forms.Button bWorldDelete;
        private System.Windows.Forms.Button bAddWorld;
        private System.Windows.Forms.Button bWorldEdit;
        private System.Windows.Forms.ComboBox cMainWorld;
        private System.Windows.Forms.Label lMainWorld;
        private System.Windows.Forms.GroupBox gInformation;
        private System.Windows.Forms.CheckBox xAnnouncements;
        private System.Windows.Forms.Button bAnnouncements;
        private System.Windows.Forms.Label lAnnouncementsUnits;
        private System.Windows.Forms.NumericUpDown nAnnouncements;
        private System.Windows.Forms.Label lAntiGrief3;
        private System.Windows.Forms.NumericUpDown nAntiGriefSeconds;
        private System.Windows.Forms.CheckBox xAntiGrief;
        private System.Windows.Forms.Label lAntiGrief1;
        private System.Windows.Forms.GroupBox gSecurityMisc;
        private System.Windows.Forms.CheckBox xAnnounceKickAndBanReasons;
        private System.Windows.Forms.CheckBox xRequireRankChangeReason;
        private System.Windows.Forms.CheckBox xRequireBanReason;
        private System.Windows.Forms.CheckBox xAnnounceRankChanges;
        private System.Windows.Forms.Button bColorIRC;
        private System.Windows.Forms.Label lColorIRC;
        private System.Windows.Forms.CheckBox xIRCBotAnnounceIRCJoins;
        private System.Windows.Forms.GroupBox gCrashReport;
        private System.Windows.Forms.Label lCrashReportDisclaimer;
        private System.Windows.Forms.GroupBox gAdvancedMisc;
        private System.Windows.Forms.Label lIRCDelay;
        private System.Windows.Forms.NumericUpDown nIRCDelay;
        private System.Windows.Forms.ComboBox cPatrolledRank;
        private System.Windows.Forms.Label lPatrolledRank;
        private System.Windows.Forms.Label lPatrolledRankAndBelow;
        private System.Windows.Forms.Button bLowerRank;
        private System.Windows.Forms.Button bRaiseRank;
        private System.Windows.Forms.Label lRankList;
        private System.Windows.Forms.CheckBox xIRCRegisteredNick;
        private System.Windows.Forms.TextBox tIRCNickServMessage;
        private System.Windows.Forms.Label lIRCNickServMessage;
        private System.Windows.Forms.TextBox tIRCNickServ;
        private System.Windows.Forms.Label lIRCNickServ;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lIRCNoForwardingMessage;
        private System.Windows.Forms.Label lIRCDelayUnits;
        private System.Windows.Forms.NumericUpDown nMaxUndo;
        private System.Windows.Forms.Label lMaxUndoUnits;
        private System.Windows.Forms.CheckBox xMaxUndo;
        private System.Windows.Forms.Label lDefaultBuildRank;
        private System.Windows.Forms.ComboBox cDefaultBuildRank;
        private System.Windows.Forms.Button bGreeting;
        private System.Windows.Forms.ComboBox cIRCList;
        private System.Windows.Forms.Label lIRCList;
        private System.Windows.Forms.CheckBox xIRCListShowNonEnglish;
        private System.Windows.Forms.CheckBox xAllowUnverifiedLAN;
        private System.Windows.Forms.TabPage tabChat;
        private System.Windows.Forms.GroupBox gAppearence;
        private System.Windows.Forms.CheckBox xShowJoinedWorldMessages;
        private System.Windows.Forms.CheckBox xRankColorsInWorldNames;
        private System.Windows.Forms.Button bColorPM;
        private System.Windows.Forms.Label lColorPM;
        private System.Windows.Forms.Button bColorAnnouncement;
        private System.Windows.Forms.Label lColorAnnouncement;
        private System.Windows.Forms.Button bColorSay;
        private System.Windows.Forms.Button bColorHelp;
        private System.Windows.Forms.Button bColorSys;
        private System.Windows.Forms.CheckBox xRankPrefixesInList;
        private System.Windows.Forms.CheckBox xRankPrefixesInChat;
        private System.Windows.Forms.CheckBox xRankColorsInChat;
        private System.Windows.Forms.Label lColorSay;
        private System.Windows.Forms.Label lColorHelp;
        private System.Windows.Forms.Label lColorSys;
        private ChatPreview chatPreview;
        private System.Windows.Forms.GroupBox gChatColors;
        private System.Windows.Forms.Label lColorWarning;
        private System.Windows.Forms.Button bColorWarning;
        private System.Windows.Forms.Label lColorMe;
        private System.Windows.Forms.Button bColorMe;
        private System.Windows.Forms.Label lLogFileOptionsDescription;
        private System.Windows.Forms.Label lLogConsoleOptionsDescription;
        private System.Windows.Forms.CheckBox xIRCBotAnnounceServerEvents;
        private System.Windows.Forms.CheckBox xIRCUseColor;
        private System.Windows.Forms.Button bMapPath;
        private System.Windows.Forms.CheckBox xMapPath;
        private System.Windows.Forms.TextBox tMapPath;
        private System.Windows.Forms.CheckBox xAllowSecurityCircumvention;
        private System.Windows.Forms.Label lConsoleName;
        private System.Windows.Forms.TextBox tConsoleName;
        private System.Windows.Forms.CheckBox xShowConnectionMessages;
        private System.Windows.Forms.Button bReadme;
        private System.Windows.Forms.Button bCredits;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lIPWarning;
        private System.Windows.Forms.TextBox tIP;
        private System.Windows.Forms.CheckBox xIP;
        private System.Windows.Forms.NumericUpDown nMaxConnectionsPerIP;
        private System.Windows.Forms.NumericUpDown nMaxPlayersPerWorld;
        private System.Windows.Forms.Label lMaxPlayersPerWorld;
        private System.Windows.Forms.CheckBox xAnnounceRankChangeReasons;
        private System.Windows.Forms.CheckBox xRequireKickReason;
        private System.Windows.Forms.GroupBox gPermissionLimits;
        private System.Windows.Forms.FlowLayoutPanel permissionLimitBoxContainer;
        private System.Windows.Forms.GroupBox gDataBackup;
        private System.Windows.Forms.CheckBox xBackupDataOnStartup;
        private System.Windows.Forms.GroupBox gBlockDB;
        private System.Windows.Forms.ComboBox cBlockDBAutoEnableRank;
        private System.Windows.Forms.CheckBox xBlockDBAutoEnable;
        private System.Windows.Forms.CheckBox xBlockDBEnabled;
        private System.Windows.Forms.CheckBox xWoMEnableEnvExtensions;
        private System.Windows.Forms.NumericUpDown nCopyPasteSlots;
        private System.Windows.Forms.Label lCopyPasteSlots;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcDescription;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvcAccess;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvcBuild;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvcBackup;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvcHidden;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvcBlockDB;
        private System.Windows.Forms.Label lFillLimitUnits;
        private System.Windows.Forms.NumericUpDown nFillLimit;
        private System.Windows.Forms.Label lFillLimit;
        private System.Windows.Forms.NumericUpDown nMaxUndoStates;
        private System.Windows.Forms.Label lMaxUndoStates;
        private System.Windows.Forms.GroupBox gPerformance;
        private System.Windows.Forms.Button bChangelog;
        private System.Windows.Forms.TabPage tabMisc;
        private System.Windows.Forms.Label CustomText;
        private System.Windows.Forms.Button CustomColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CustomName;
        private System.Windows.Forms.TextBox CustomAliases;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label MaxCaps;
        private System.Windows.Forms.NumericUpDown MaxCapsValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SwearBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SwearEditor;
        private System.Windows.Forms.Button ReqsEditor;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox websiteURL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button bWiki;
        private System.Windows.Forms.Button bWeb;
        private System.Windows.Forms.CheckBox xCrash;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.CheckBox checkUpdate;
        private System.Windows.Forms.GroupBox gIRCAdv;
        private System.Windows.Forms.TextBox tServPass;
        private System.Windows.Forms.CheckBox xServPass;
        private System.Windows.Forms.TextBox tChanPass;
        private System.Windows.Forms.CheckBox xChanPass;
        private System.Windows.Forms.CheckBox xAutoRank;
        private System.Windows.Forms.Button bColorGlobal;
        private System.Windows.Forms.Label IColorGlobal;
        private System.Windows.Forms.TabPage tabCPE;
        internal System.Windows.Forms.GroupBox gboMessageType;
        internal TextBox txtStatus1;
        internal TextBox txtStatus2;
        internal TextBox txtStatus3;
        internal TextBox txtBR3;
        internal TextBox txtBR2;
        internal TextBox txtBR1;
        internal CheckBox chkBR1;
        internal CheckBox chkBR2;
        internal CheckBox chkBR3;
        internal CheckBox chkStatus3;
        internal CheckBox chkStatus2;
        internal CheckBox chkStatus1;
        internal CheckBox chkShowAnnouncements;
        internal CheckBox chkEnableMessageTypes;
        internal Label lblMTInformation;
        private GroupBox gboCustomBlocks;
        private Button btnDefineNewBlock;
        private GroupBox gboClickDistance;
        internal NumericUpDown numMaxDistance;
        private Label lblMaxDistance;
        internal NumericUpDown numMinDistance;
        private Label lblMinDistance;
        internal CheckBox chkEnableClickDistance;
        internal Label metroLabel1;
        private GroupBox gboHeldBlock;
        internal CheckBox chkEnableHeldBlock;
        internal Label metroLabel2;
        private TabPage tabPlugins;
        private GroupBox gboPlugins;
        private CheckBox chkPlugins;
        private ListBox listPlugins;
        private GroupBox gboPluginInfo;
        private PropertyGrid propertyGrid1;
        private Button button1;
        private GroupBox groupBox6;
        private Button button2;
        private GroupBox groupBox7;
        private PropertyGrid propertyGrid2;
        private ListBox listBox1;
        private CheckBox checkBox1;
        private GroupBox groupBox8;
        private Button button3;
        private GroupBox groupBox9;
        private PropertyGrid propertyGrid3;
        private ListBox listBox2;
        private CheckBox checkBox2;
    }
}