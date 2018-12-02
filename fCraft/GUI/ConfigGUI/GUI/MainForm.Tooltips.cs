// Copyright 2009-2012 Matvei Stefarov <me@matvei.org>

using System.Windows.Forms;
using fCraft.fSystem;
using fCraft.Players;
using static fCraft.GUI.ConfigGUI.GUI.SectionClasses;

namespace fCraft.GUI.ConfigGUI.GUI
{
    partial class MainForm
    {
        internal ToolTip toolTip;

        void FillToolTipsMisc()
        {
            toolTip.SetToolTip(SectionClasses.MiscConfig.CustomName, ConfigKey.CustomChatName.GetDescription());
            toolTip.SetToolTip(SectionClasses.MiscConfig.CustomAliases, ConfigKey.CustomAliasName.GetDescription());
            toolTip.SetToolTip(SectionClasses.MiscConfig.SwearBox, ConfigKey.SwearName.GetDescription());
            toolTip.SetToolTip(SectionClasses.MiscConfig.SwearEditor,
                @"Edit the list of Swearwords (swearwords.txt).
Each swearword should be on a seperate line.");

            toolTip.SetToolTip(SectionClasses.MiscConfig.ReqsEditor,
                @"Edit the list of requirements for the ranks
on your server.");
        }

        void FillToolTipsGeneral()
        {
            toolTip.SetToolTip(GeneralConfig.lServerName, ConfigKey.ServerName.GetDescription());
            toolTip.SetToolTip(GeneralConfig.tServerName, ConfigKey.ServerName.GetDescription());
            

            toolTip.SetToolTip(GeneralConfig.lMOTD, ConfigKey.MOTD.GetDescription());
            toolTip.SetToolTip(GeneralConfig.tMOTD, ConfigKey.MOTD.GetDescription());

            toolTip.SetToolTip(GeneralConfig.lMaxPlayers, ConfigKey.MaxPlayers.GetDescription());
            toolTip.SetToolTip(GeneralConfig.nMaxPlayers, ConfigKey.MaxPlayers.GetDescription());

            toolTip.SetToolTip(GeneralConfig.lMaxPlayersPerWorld, ConfigKey.MaxPlayersPerWorld.GetDescription());
            toolTip.SetToolTip(GeneralConfig.nMaxPlayersPerWorld, ConfigKey.MaxPlayersPerWorld.GetDescription());

            toolTip.SetToolTip(GeneralConfig.lDefaultRank, ConfigKey.DefaultRank.GetDescription());
            toolTip.SetToolTip(GeneralConfig.cDefaultRank, ConfigKey.DefaultRank.GetDescription());

            toolTip.SetToolTip(GeneralConfig.lPublic, ConfigKey.IsPublic.GetDescription());
            toolTip.SetToolTip(GeneralConfig.cPublic, ConfigKey.IsPublic.GetDescription());

            toolTip.SetToolTip(GeneralConfig.nPort, ConfigKey.Port.GetDescription());
            toolTip.SetToolTip(GeneralConfig.lPort, ConfigKey.Port.GetDescription());

            toolTip.SetToolTip(GeneralConfig.nUploadBandwidth, ConfigKey.UploadBandwidth.GetDescription());
            toolTip.SetToolTip(GeneralConfig.lUploadBandwidth, ConfigKey.UploadBandwidth.GetDescription());

            toolTip.SetToolTip(GeneralConfig.bMeasure,
@"Test your connection's upload speed with speedtest.net
Note: to convert from megabits to kilobytes, multiply the
number by 128");

            toolTip.SetToolTip(GeneralConfig.bRules,
@"Edit the list of rules displayed by the ""/Rules"" command.
This list is stored in rules.txt, and can also be edited with any text editor.
If rules.txt is missing or empty, ""/Rules"" shows this message:
""Use common sense!""");

            const string tipAnnouncements =
@"Show a random announcement every once in a while.
Announcements are shown to all players, one line at a time, in random order.";
            toolTip.SetToolTip(GeneralConfig.xAnnouncements, tipAnnouncements);

            toolTip.SetToolTip(GeneralConfig.nAnnouncements, ConfigKey.AnnouncementInterval.GetDescription());
            toolTip.SetToolTip(GeneralConfig.lAnnouncementsUnits, ConfigKey.AnnouncementInterval.GetDescription());

            toolTip.SetToolTip(GeneralConfig.bAnnouncements,
@"Edit the list of announcements (announcements.txt).
One line is shown at a time, in random order.
You can include any color codes in the announcements.
You can also edit announcements.txt with any text editor.");

            toolTip.SetToolTip(GeneralConfig.bGreeting,
@"Edit a custom greeting that's shown to connecting players.
You can use any color codes, and these special variables:
    {SERVER_NAME} = server name (as defined in config)
    {RANK} = connecting player's rank");

            

        }


        void FillToolTipsChat()
        {

            toolTip.SetToolTip(ChatConfig.xRankColorsInChat, ConfigKey.RankColorsInChat.GetDescription());

            toolTip.SetToolTip(ChatConfig.xRankColorsInWorldNames, ConfigKey.RankColorsInWorldNames.GetDescription());

            toolTip.SetToolTip(ChatConfig.xRankPrefixesInChat, ConfigKey.RankPrefixesInChat.GetDescription());

            toolTip.SetToolTip(ChatConfig.xRankPrefixesInList, ConfigKey.RankPrefixesInList.GetDescription());

            toolTip.SetToolTip(ChatConfig.xShowConnectionMessages, ConfigKey.ShowConnectionMessages.GetDescription());

            toolTip.SetToolTip(ChatConfig.xShowJoinedWorldMessages, ConfigKey.ShowJoinedWorldMessages.GetDescription());

            toolTip.SetToolTip(ChatConfig.bColorSys, ConfigKey.SystemMessageColor.GetDescription());
            toolTip.SetToolTip(ChatConfig.lColorSys, ConfigKey.SystemMessageColor.GetDescription());

            toolTip.SetToolTip(ChatConfig.bColorHelp, ConfigKey.HelpColor.GetDescription());
            toolTip.SetToolTip(ChatConfig.lColorHelp, ConfigKey.HelpColor.GetDescription());

            toolTip.SetToolTip(ChatConfig.bColorSay, ConfigKey.SayColor.GetDescription());
            toolTip.SetToolTip(ChatConfig.lColorSay, ConfigKey.SayColor.GetDescription());

            toolTip.SetToolTip(ChatConfig.bColorAnnouncement, ConfigKey.AnnouncementColor.GetDescription());
            toolTip.SetToolTip(ChatConfig.lColorAnnouncement, ConfigKey.AnnouncementColor.GetDescription());

            toolTip.SetToolTip(ChatConfig.bColorPM, ConfigKey.PrivateMessageColor.GetDescription());
            toolTip.SetToolTip(ChatConfig.lColorPM, ConfigKey.PrivateMessageColor.GetDescription());

            toolTip.SetToolTip(ChatConfig.bColorMe, ConfigKey.MeColor.GetDescription());
            toolTip.SetToolTip(ChatConfig.lColorMe, ConfigKey.MeColor.GetDescription());

            toolTip.SetToolTip(ChatConfig.bColorWarning, ConfigKey.WarningColor.GetDescription());
            toolTip.SetToolTip(ChatConfig.lColorWarning, ConfigKey.WarningColor.GetDescription());
        }


        void FillToolTipsWorlds()
        {
            toolTip.SetToolTip(WorldConfig.bAddWorld, "Add a new world to the list.");
            toolTip.SetToolTip(WorldConfig.bWorldEdit, "Edit or replace an existing world.");
            toolTip.SetToolTip(WorldConfig.cMainWorld, "Main world is the first world that players see when they join the server.");
            toolTip.SetToolTip(WorldConfig.bWorldDelete, "Delete a world from the list.");

            toolTip.SetToolTip(WorldConfig.lDefaultBuildRank, ConfigKey.DefaultBuildRank.GetDescription());
            toolTip.SetToolTip(WorldConfig.cDefaultBuildRank, ConfigKey.DefaultBuildRank.GetDescription());

            toolTip.SetToolTip(WorldConfig.tMapPath, ConfigKey.MapPath.GetDescription());
            toolTip.SetToolTip(WorldConfig.xMapPath, ConfigKey.MapPath.GetDescription());

            toolTip.SetToolTip(WorldConfig.xWoMEnableEnvExtensions, ConfigKey.WoMEnableEnvExtensions.GetDescription());
        }


        void FillToolTipsRanks()
        {

            toolTip.SetToolTip(RankConfig.xAllowSecurityCircumvention,
@"Allows players to manupulate whitelists/blacklists or rank requirements
in order to join restricted worlds, or to build in worlds/zones. Normally
players with ManageWorlds and ManageZones permissions are not allowed to do this.
Affected commands:
    /WAccess
    /WBuild
    /WMain
    /ZEdit");

            toolTip.SetToolTip(RankConfig.bAddRank, "Add a new rank to the list.");
            toolTip.SetToolTip(RankConfig.bDeleteRank,
@"Delete a rank from the list. You will be prompted to specify a replacement
rank - to be able to convert old references to the deleted rank.");
            toolTip.SetToolTip(RankConfig.bRaiseRank,
@"Raise a rank (and all players of the rank) on the hierarchy.
The hierarchy is used for all permission checks.");
            toolTip.SetToolTip(RankConfig.bLowerRank,
@"Lower a rank (and all players of the rank) on the hierarchy.
The hierarchy is used for all permission checks.");

            const string tipRankName =
"Name of the rank - between 2 and 16 alphanumeric characters.";
            toolTip.SetToolTip(RankConfig.lRankName, tipRankName);
            toolTip.SetToolTip(RankConfig.tRankName, tipRankName);

            const string tipRankColor =
@"Color associated with this rank.
Rank colors may be applied to player and world names.";
            toolTip.SetToolTip(RankConfig.lRankColor, tipRankColor);
            toolTip.SetToolTip(RankConfig.bColorRank, tipRankColor);

            const string tipPrefix =
@"1-character prefix that may be shown above player names.
The option to show prefixes in chat is on ""General"" tab.";
            toolTip.SetToolTip(RankConfig.lPrefix, tipPrefix);
            toolTip.SetToolTip(RankConfig.tPrefix, tipPrefix);



            toolTip.SetToolTip(_permissionLimitBoxes[Permission.Kick],
@"Limit on who can be kicked by players of this rank.
By default, players can only kick players of same or lower rank.");

            toolTip.SetToolTip(_permissionLimitBoxes[Permission.Ban],
@"Limit on who can be banned by players of this rank.
By default, players can only ban players of same or lower rank.");

            toolTip.SetToolTip(_permissionLimitBoxes[Permission.Promote],
@"Limit on how much can players of this rank promote others.
By default, players can only promote up to the same or lower rank.");

            toolTip.SetToolTip(_permissionLimitBoxes[Permission.Demote],
@"Limit on whom players of this rank can demote.
By default, players can only demote players of same or lower rank.");

            toolTip.SetToolTip(_permissionLimitBoxes[Permission.Hide],
@"Limit on whom can players of this rank hide from.
By default, players can only hide from players of same or lower rank.");

            toolTip.SetToolTip(_permissionLimitBoxes[Permission.Freeze],
@"Limit on who can be frozen by players of this rank.
By default, players can only freeze players of same or lower rank.");

            toolTip.SetToolTip(_permissionLimitBoxes[Permission.Mute],
@"Limit on who can be muted by players of this rank.
By default, players can only mute players of same or lower rank.");

            toolTip.SetToolTip(_permissionLimitBoxes[Permission.Bring],
@"Limit on who can be brought (forcibly teleported) by players of this rank.
By default, players can only bring players of same or lower rank.");

            toolTip.SetToolTip(_permissionLimitBoxes[Permission.Spectate],
@"Limit on who can be spectated by players of this rank.
By default, players can only bring players of same or lower rank.");

            toolTip.SetToolTip(_permissionLimitBoxes[Permission.UndoOthersActions],
@"Limit on whose actions players of this rank can undo.
By default, players can only undo actions of players of same or lower rank.");



            toolTip.SetToolTip(RankConfig.xReserveSlot,
@"Allows players of this rank to join the server
even if it reached the maximum number of players.");

            const string tipKickIdle = "Allows kicking players who have been inactive/AFK for some time.";
            toolTip.SetToolTip(RankConfig.xKickIdle, tipKickIdle);
            toolTip.SetToolTip(RankConfig.nKickIdle, tipKickIdle);
            toolTip.SetToolTip(RankConfig.lKickIdleUnits, tipKickIdle);

            toolTip.SetToolTip(RankConfig.xAntiGrief,
@"Antigrief is an automated system for kicking players who build
or delete at abnormally high rates. This helps stop certain kinds
of malicious software (like MCTunnel) from doing large-scale damage
to server maps. False positives can sometimes occur if server or
player connection is very laggy.");

            toolTip.SetToolTip(RankConfig.nAntiGriefBlocks,
@"Maximum number of blocks that players of this rank are
allowed to build in a specified time period.");

            toolTip.SetToolTip(RankConfig.nAntiGriefBlocks,
@"Minimum time interval that players of this rank are
expected to spent to build a specified number of blocks.");

            const string tipDrawLimit =
@"Limit on the number of blocks that a player is
allowed to affect with drawing or copy/paste commands
at one time. If unchecked, there is no limit.";
            toolTip.SetToolTip(RankConfig.xDrawLimit, tipDrawLimit);
            toolTip.SetToolTip(RankConfig.nDrawLimit, tipDrawLimit);
            toolTip.SetToolTip(RankConfig.lDrawLimitUnits, tipDrawLimit);




            RankConfig.vPermissions.Items[(int)Permission.Ban].ToolTipText =
@"Ability to ban/unban other players from the server.
Affected commands:
    /Ban
    /Banx
    /Unban";

            RankConfig.vPermissions.Items[(int)Permission.BanAll].ToolTipText =
@"Ability to ban/unban a player account, his IP, and all other accounts that used the IP.
BanAll/UnbanAll commands can be used on players who keep evading bans.
Required permissions: Ban & BanIP
Affected commands:
    /BanAll
    /UnbanAll";

            RankConfig.vPermissions.Items[(int)Permission.BanIP].ToolTipText =
@"Ability to ban/unban players by IP.
Required permission: Ban
Affected commands:
    /BanIP
    /UnbanIP";

            RankConfig.vPermissions.Items[(int)Permission.Basscannon].ToolTipText =
@"Ability to kick a player with stlye.
Affected command:
    /Basscannon";

            RankConfig.vPermissions.Items[(int)Permission.Bring].ToolTipText =
@"Ability to bring/summon other players to your location.
This works a bit like reverse-teleport - other player is sent to you.
Affected commands:
    /Bring
    /BringAll";

            RankConfig.vPermissions.Items[(int)Permission.BringAll].ToolTipText =
@"Ability to bring/summon many players at a time to your location.
Affected command:
    /BringAll";

            RankConfig.vPermissions.Items[(int)Permission.BroMode].ToolTipText =
@"Ability to activate BroMode.
Affected command:
    /BroMode";

            RankConfig.vPermissions.Items[(int)Permission.Build].ToolTipText =
@"Ability to place blocks on maps. This is a baseline permission
that can be overridden by world-specific and zone-specific permissions.";

            RankConfig.vPermissions.Items[(int)Permission.Chat].ToolTipText =
@"Ability to chat and PM players. Note that players without this
permission can still type in commands, receive PMs, and read chat.
Affected commands:
    /Say
    @ (pm)
    @@ (rank chat)";

            RankConfig.vPermissions.Items[(int)Permission.ChatWithCaps].ToolTipText =
@"Ability to chat with caps without restrictions.";

            RankConfig.vPermissions.Items[(int)Permission.CopyAndPaste].ToolTipText =
@"Ability to copy (or cut) and paste blocks. The total number of
blocks that can be copied or pasted at a time is affected by
the draw limit.
Affected commands:
    /Copy
    /Cut
    /Mirror
    /Paste, /PasteNot
    /Rotate";

            RankConfig.vPermissions.Items[(int)Permission.Delete].ToolTipText =
@"Ability to delete or replace blocks on maps. This is a baseline permission
that can be overridden by world-specific and zone-specific permissions.";

            RankConfig.vPermissions.Items[(int)Permission.DeleteAdmincrete].ToolTipText =
@"Ability to delete admincrete (aka adminium) blocks. Even if someone
has this permission, it can be overridden by world-specific and
zone-specific permissions.
Required permission: Delete";

            RankConfig.vPermissions.Items[(int)Permission.Demote].ToolTipText =
@"Ability to demote other players to a lower rank.
Affected commands:
    /Rank
    /MassRank";

            RankConfig.vPermissions.Items[(int)Permission.Draw].ToolTipText =
@"Ability to use drawing tools (commands capable of affecting many blocks
at once). This permission can be overridden by world-specific and
zone-specific permissions.
Required permission: Build, Delete
Affected commands:
    /Cuboid, /CuboidH, and /CuboidW
    /Ellipsoid and /EllipsoidH
    /Line
    /Replace and /ReplaceNot
    /Undo and /Redo";

            RankConfig.vPermissions.Items[(int)Permission.DrawAdvanced].ToolTipText =
@"Ability to use advanced drawing tools, such as brushes.
Required permission: Build, Delete, Draw
Affected commands:
    /Brush
    /ReplaceBrush
    /Restore
    /Sphere and /SphereH
    /Torus";

            RankConfig.vPermissions.Items[(int)Permission.EditPlayerDB].ToolTipText =
@"Ability to edit the player database directly. This also adds the ability to
promote/demote players by name, even if they have not visited the server yet.
Also allows to manipulate players' records, and to promote/demote players in batches.
Affected commands:
    /PruneDB
    /AutoRankAll
    /MassRank
    /SetInfo
    /Nick
    /InfoSwap
    /DumpStats";

            RankConfig.vPermissions.Items[(int)Permission.Fireworks].ToolTipText =
@"Ability to create fireworks.
Affected command:
    /Firework";

            RankConfig.vPermissions.Items[(int)Permission.Freeze].ToolTipText =
@"Ability to freeze/unfreeze players. Frozen players cannot
move or build/delete.
Affected commands:
    /Freeze
    /Unfreeze";

            RankConfig.vPermissions.Items[(int)Permission.Gtfo].ToolTipText =
@"Ability to kick a player without saving it to the DB.
Affected command:
    /Gtfo";

            RankConfig.vPermissions.Items[(int)Permission.Gun].ToolTipText =
@"Ability to use a gun.
Affected command:
    /Gun";

            RankConfig.vPermissions.Items[(int)Permission.Hide].ToolTipText =
@"Ability to appear hidden from other players. You can still chat,
build/delete blocks, use all commands, and join worlds while hidden.
Hidden players are completely invisible to other players.
Affected commands:
    /Hide
    /Unhide";

            RankConfig.vPermissions.Items[(int)Permission.HideRanks].ToolTipText =
@"Ability to hide ranks from the /ranks list.
Affected command:
    /RankHide";

            RankConfig.vPermissions.Items[(int)Permission.HighFive].ToolTipText =
@"Ability to give a player a HighFive.
Affected command:
    /High5";

            RankConfig.vPermissions.Items[(int)Permission.Import].ToolTipText =
@"Ability to import rank and ban lists from files. Useful if you
are switching from another server software.
Affected commands:
    /Import";

            RankConfig.vPermissions.Items[(int)Permission.Immortal].ToolTipText =
@"Ability to become immortal.
Affected command:
    /Immortal";

            RankConfig.vPermissions.Items[(int)Permission.Kick].ToolTipText =
@"Ability to kick players from the server.
Affected commands:
    /Kick";

            RankConfig.vPermissions.Items[(int)Permission.Kill].ToolTipText =
@"Ability to kill players.
Affected command:
    /Kill";

            RankConfig.vPermissions.Items[(int)Permission.Lock].ToolTipText =
@"Ability to lock/unlock maps (locking puts a world into read-only state.)
Affected commands:
    /WLock
    /WUnlock";

            RankConfig.vPermissions.Items[(int)Permission.MakeVoteKicks].ToolTipText =
@"Ability to vote to kick a player.
Affected command:
    /Vote";

            RankConfig.vPermissions.Items[(int)Permission.MakeVotes].ToolTipText =
@"Ability to create votes.
Affected command:
    /Vote";

            RankConfig.vPermissions.Items[(int)Permission.ManageWorlds].ToolTipText =
@"Ability to manipulate the world list: adding, renaming, and deleting worlds,
loading/saving maps, change per-world permissions, and using the map generator.
Affected commands:
    /WLoad
    /WUnload
    /WRename
    /WMain
    /WAccess and /WBuild
    /WFlush
    /Gen";


            RankConfig.vPermissions.Items[(int)Permission.ManageBlockDB].ToolTipText =
@"Ability to enable/disable, clear, and configure BlockDB.
Affected command:
    /BlockDB";

            RankConfig.vPermissions.Items[(int)Permission.ManagePortal].ToolTipText =
@"Ability to create, edit, and delete portals.
Affected command:
    /Portal";

            RankConfig.vPermissions.Items[(int)Permission.ManageZones].ToolTipText =
@"Ability to manipulate zones: adding, editing, renaming, and removing zones.
Affected commands:
    /ZAdd
    /ZEdit
    /ZRemove
    /ZRename";

            RankConfig.vPermissions.Items[(int)Permission.Moderation].ToolTipText =
@"Ability to mute everyone in the server, useful for announcements.
Affected command:
    /Moderate";

            RankConfig.vPermissions.Items[(int)Permission.Mute].ToolTipText =
@"Ability to temporarily mute players. Muted players cannot write chat or 
send PMs, but they can still type in commands, receive PMs, and read chat.
Affected commands:
    /Mute
    /Unmute";

            RankConfig.vPermissions.Items[(int)Permission.Patrol].ToolTipText =
@"Ability to patrol lower-ranked players. ""Patrolling"" means teleporting
to other players to check on them, usually while hidden.
Required permission: Teleport
Affected commands:
    /Patrol
    /SpecPatrol";

            RankConfig.vPermissions.Items[(int)Permission.Physics].ToolTipText =
@"Ability to activate Physics on a world.
Affected command:
    /Physics";

            RankConfig.vPermissions.Items[(int)Permission.PlaceAdmincrete].ToolTipText =
@"Ability to place admincrete/adminium. This also affects draw commands.
Required permission: Build
Affected commands:
    /Solid
    /Bind";

            RankConfig.vPermissions.Items[(int)Permission.PlaceGrass].ToolTipText =
@"Ability to place grass blocks. This also affects draw commands.
Required permission: Build
Affected commands:
    /Grass
    /Bind";

            RankConfig.vPermissions.Items[(int)Permission.PlaceLava].ToolTipText =
@"Ability to place lava blocks. This also affects draw commands.
Required permission: Build
Affected commands:
    /Lava
    /Bind";

            RankConfig.vPermissions.Items[(int)Permission.PlaceWater].ToolTipText =
@"Ability to place water blocks. This also affects draw commands.
Required permission: Build
Affected commands:
    /Water
    /Bind";

            RankConfig.vPermissions.Items[(int)Permission.Possess].ToolTipText =
        @"Ability to possess a player.
Affected commands:
    /Possess
    /unpossess";

            RankConfig.vPermissions.Items[(int)Permission.Promote].ToolTipText =
@"Ability to promote players to a higher rank.
Affected commands:
    /Rank";

            RankConfig.vPermissions.Items[(int)Permission.RageQuit].ToolTipText =
@"Ability to ragequit from the server.
Affected command:
    /Ragequit";

            RankConfig.vPermissions.Items[(int)Permission.ReadAdminChat].ToolTipText =
@"Ability to read Admin chat.";

            RankConfig.vPermissions.Items[(int)Permission.ReadCustomChat].ToolTipText =
@"Ability to read Custom chat.";

            RankConfig.vPermissions.Items[(int)Permission.ReadStaffChat].ToolTipText =
@"Ability to read staff chat.";

            RankConfig.vPermissions.Items[(int)Permission.Realm].ToolTipText =
@"Ability to create realms.
Affected command:
    /Realm";

            RankConfig.vPermissions.Items[(int)Permission.ReloadConfig].ToolTipText =
@"Ability to reload the configuration file without restarting.
Affected commands:
    /Reload";

            RankConfig.vPermissions.Items[(int)Permission.Say].ToolTipText =
@"Ability to use /Say command.
Required permission: Chat
Affected commands:
    /Say";

            RankConfig.vPermissions.Items[(int)Permission.SetSpawn].ToolTipText =
@"Ability to change the spawn point of a world or a player.
Affected commands:
    /SetSpawn";

            RankConfig.vPermissions.Items[(int)Permission.ShutdownServer].ToolTipText =
@"Ability to shut down or restart the server remotely.
Useful for servers that run on dedicated machines.
Affected commands:
    /Shutdown
    /Restart";

            RankConfig.vPermissions.Items[(int)Permission.Slap].ToolTipText =
@"Ability to slap players.
Affected command:
    /Slap";

            RankConfig.vPermissions.Items[(int)Permission.Spectate].ToolTipText =
@"Ability to spectate/follow other players in first-person view.
Affected commands:
    /Spectate";

            RankConfig.vPermissions.Items[(int)Permission.Swear].ToolTipText =
@"Ability to use swear words without restrictions";

            RankConfig.vPermissions.Items[(int)Permission.Teleport].ToolTipText =
@"Ability to teleport to other players.
Affected commands:
    /TP";

            RankConfig.vPermissions.Items[(int)Permission.TempBan].ToolTipText =
@"Ability to temporarily ban a player.
Affected command:
    /Tempban";

            RankConfig.vPermissions.Items[(int)Permission.Tower].ToolTipText =
@"Ability to create a Tower.
Affected command:
    /Tower";

            RankConfig.vPermissions.Items[(int)Permission.Tree].ToolTipText =
@"Ability to create a tree.
Affected command:
    /Tree";

            RankConfig.vPermissions.Items[(int)Permission.Troll].ToolTipText =
@"Ability to troll players.
Affected command:
    /Troll";

            RankConfig.vPermissions.Items[(int)Permission.UndoOthersActions].ToolTipText =
@"Ability to undo actions of other players, using the BlockDB.
Affected commands:
    /UndoArea
    /UndoPlayer";

            RankConfig.vPermissions.Items[(int)Permission.UseColorCodes].ToolTipText =
@"Ability to use color codes in chat messages.";

            RankConfig.vPermissions.Items[(int)Permission.UsePortal].ToolTipText =
@"Ability to use portals (not be confused with ManagePortal).";

            RankConfig.vPermissions.Items[(int)Permission.UseSpeedHack].ToolTipText =
@"Ability to move at a faster-than-normal rate (using hacks).
WARNING: Speedhack detection is often inaccurate, and may produce many
false positives - especially on laggy servers.";

            RankConfig.vPermissions.Items[(int)Permission.Warn].ToolTipText =
@"Ability to warn a player.
Affected command:
    /Warn";

            RankConfig.vPermissions.Items[(int)Permission.ViewOthersInfo].ToolTipText =
@"Ability to view extended information about other players.
Affected commands:
    /Info
    /BanInfo
    /Where";

            RankConfig.vPermissions.Items[(int)Permission.ViewPlayerIPs].ToolTipText =
@"Ability to view players' IP addresses.
Affected commands:
    /Info
    /BanInfo
    /BanIP, /BanAll, /UnbanIP, /UnbanAll";
        }


        void FillToolTipsSecurity()
        {
            toolTip.SetToolTip(SecurityConfig.lVerifyNames, ConfigKey.VerifyNames.GetDescription());
            toolTip.SetToolTip(SecurityConfig.cVerifyNames, ConfigKey.VerifyNames.GetDescription());

            toolTip.SetToolTip(SecurityConfig.xMaxConnectionsPerIP, ConfigKey.MaxConnectionsPerIP.GetDescription());
            toolTip.SetToolTip(SecurityConfig.nMaxConnectionsPerIP, ConfigKey.MaxConnectionsPerIP.GetDescription());

            toolTip.SetToolTip(SecurityConfig.xAllowUnverifiedLAN, ConfigKey.AllowUnverifiedLAN.GetDescription());

            toolTip.SetToolTip(SecurityConfig.xRequireBanReason, ConfigKey.RequireBanReason.GetDescription());
            toolTip.SetToolTip(SecurityConfig.xRequireKickReason, ConfigKey.RequireKickReason.GetDescription());
            toolTip.SetToolTip(SecurityConfig.xRequireRankChangeReason, ConfigKey.RequireRankChangeReason.GetDescription());

            toolTip.SetToolTip(SecurityConfig.xAnnounceKickAndBanReasons, ConfigKey.AnnounceKickAndBanReasons.GetDescription());
            toolTip.SetToolTip(SecurityConfig.xAnnounceRankChanges, ConfigKey.AnnounceRankChanges.GetDescription());
            toolTip.SetToolTip(SecurityConfig.xAnnounceRankChangeReasons, ConfigKey.AnnounceRankChanges.GetDescription());
            
            toolTip.SetToolTip(SecurityConfig.lPatrolledRank, ConfigKey.PatrolledRank.GetDescription());
            toolTip.SetToolTip(SecurityConfig.cPatrolledRank, ConfigKey.PatrolledRank.GetDescription());
            toolTip.SetToolTip(SecurityConfig.lPatrolledRankAndBelow, ConfigKey.PatrolledRank.GetDescription());

            toolTip.SetToolTip(SecurityConfig.nAntispamMessageCount, ConfigKey.AntispamMessageCount.GetDescription());
            toolTip.SetToolTip(SecurityConfig.lAntispamMessageCount, ConfigKey.AntispamMessageCount.GetDescription());
            toolTip.SetToolTip(SecurityConfig.nAntispamInterval, ConfigKey.AntispamInterval.GetDescription());
            toolTip.SetToolTip(SecurityConfig.lAntispamInterval, ConfigKey.AntispamInterval.GetDescription());

            toolTip.SetToolTip(SecurityConfig.xAntispamKicks, "Kick players who repeatedly trigger antispam warnings.");
            toolTip.SetToolTip(SecurityConfig.nAntispamMaxWarnings, ConfigKey.AntispamMaxWarnings.GetDescription());
            toolTip.SetToolTip(SecurityConfig.lAntispamMaxWarnings, ConfigKey.AntispamMaxWarnings.GetDescription());

            toolTip.SetToolTip(SecurityConfig.xBlockDBEnabled, ConfigKey.BlockDBEnabled.GetDescription());
            toolTip.SetToolTip(SecurityConfig.xBlockDBAutoEnable, ConfigKey.BlockDBAutoEnable.GetDescription());
            toolTip.SetToolTip(SecurityConfig.cBlockDBAutoEnableRank, ConfigKey.BlockDBAutoEnableRank.GetDescription());
        }


        void FillToolTipsSavingAndBackup()
        {

            toolTip.SetToolTip(SavingConfig.xSaveInterval, ConfigKey.SaveInterval.GetDescription());
            toolTip.SetToolTip(SavingConfig.nSaveInterval, ConfigKey.SaveInterval.GetDescription());
            toolTip.SetToolTip(SavingConfig.lSaveIntervalUnits, ConfigKey.SaveInterval.GetDescription());

            toolTip.SetToolTip(SavingConfig.xBackupOnStartup, ConfigKey.BackupOnStartup.GetDescription());

            toolTip.SetToolTip(SavingConfig.xBackupOnJoin, ConfigKey.BackupOnJoin.GetDescription());

            toolTip.SetToolTip(SavingConfig.xBackupInterval, ConfigKey.DefaultBackupInterval.GetDescription());
            toolTip.SetToolTip(SavingConfig.nBackupInterval, ConfigKey.DefaultBackupInterval.GetDescription());
            toolTip.SetToolTip(SavingConfig.lBackupIntervalUnits, ConfigKey.DefaultBackupInterval.GetDescription());

            toolTip.SetToolTip(SavingConfig.xBackupOnlyWhenChanged, ConfigKey.DefaultBackupInterval.GetDescription());

            toolTip.SetToolTip(SavingConfig.xMaxBackups, ConfigKey.MaxBackups.GetDescription());
            toolTip.SetToolTip(SavingConfig.nMaxBackups, ConfigKey.MaxBackups.GetDescription());
            toolTip.SetToolTip(SavingConfig.lMaxBackups, ConfigKey.MaxBackups.GetDescription());

            toolTip.SetToolTip(SavingConfig.xMaxBackupSize, ConfigKey.MaxBackupSize.GetDescription());
            toolTip.SetToolTip(SavingConfig.nMaxBackupSize, ConfigKey.MaxBackupSize.GetDescription());
            toolTip.SetToolTip(SavingConfig.lMaxBackupSize, ConfigKey.MaxBackupSize.GetDescription());
        }


        void FillToolTipsLogging()
        {
            toolTip.SetToolTip(LoggingConfig.lLogMode, ConfigKey.LogMode.GetDescription());
            toolTip.SetToolTip(LoggingConfig.cLogMode, ConfigKey.LogMode.GetDescription());

            toolTip.SetToolTip(LoggingConfig.xLogLimit, ConfigKey.MaxLogs.GetDescription());
            toolTip.SetToolTip(LoggingConfig.nLogLimit, ConfigKey.MaxLogs.GetDescription());
            toolTip.SetToolTip(LoggingConfig.lLogLimitUnits, ConfigKey.MaxLogs.GetDescription());

            LoggingConfig.vLogFileOptions.Items[(int)LogType.ConsoleInput].ToolTipText = "Commands typed in from the server console.";
            LoggingConfig.vLogFileOptions.Items[(int)LogType.ConsoleOutput].ToolTipText =
@"Things sent directly in response to console input,
e.g. output of commands called from console.";
            LoggingConfig.vLogFileOptions.Items[(int)LogType.Debug].ToolTipText = "Technical information that may be useful to find bugs.";
            LoggingConfig.vLogFileOptions.Items[(int)LogType.Error].ToolTipText = "Major errors and problems.";
            LoggingConfig.vLogFileOptions.Items[(int)LogType.SeriousError].ToolTipText = "Errors that prevent server from starting or result in crashes.";
            LoggingConfig.vLogFileOptions.Items[(int)LogType.GlobalChat].ToolTipText = "Normal chat messages written by players.";
            LoggingConfig.vLogFileOptions.Items[(int)LogType.IRC].ToolTipText =
@"IRC-related status and error messages.
Does not include IRC chatter (see IRCChat).";
            LoggingConfig.vLogFileOptions.Items[(int)LogType.PrivateChat].ToolTipText = "PMs (Private Messages) exchanged between players (@player message).";
            LoggingConfig.vLogFileOptions.Items[(int)LogType.RankChat].ToolTipText = "Rank-wide messages (@@rank message).";
            LoggingConfig.vLogFileOptions.Items[(int)LogType.SuspiciousActivity].ToolTipText = "Suspicious activity - hack attempts, failed logins, unverified names.";
            LoggingConfig.vLogFileOptions.Items[(int)LogType.SystemActivity].ToolTipText = "Status messages regarding normal system activity.";
            LoggingConfig.vLogFileOptions.Items[(int)LogType.UserActivity].ToolTipText = "Status messages regarding players' actions.";
            LoggingConfig.vLogFileOptions.Items[(int)LogType.UserCommand].ToolTipText = "Commands types in by players.";
            LoggingConfig.vLogFileOptions.Items[(int)LogType.Warning].ToolTipText = "Minor, recoverable errors and problems.";
            LoggingConfig.vLogFileOptions.Items[(int)LogType.ChangedWorld].ToolTipText = "Logs when a player changes world.";

            for (int i = 0; i < LoggingConfig.vConsoleOptions.Items.Count; i++)
            {
                LoggingConfig.vConsoleOptions.Items[i].ToolTipText = LoggingConfig.vLogFileOptions.Items[i].ToolTipText;
            }
        }


        void FillToolTipsIRC()
        {
            toolTip.SetToolTip(IRCConfig.xIRCBotEnabled, ConfigKey.IRCBotEnabled.GetDescription());

            const string tipIRCList =
@"Choose one of these popular IRC networks,
or type in address/port manually below.";
            toolTip.SetToolTip(IRCConfig.lIRCList, tipIRCList);
            toolTip.SetToolTip(IRCConfig.cIRCList, tipIRCList);

            toolTip.SetToolTip(IRCConfig.lIRCBotNick, ConfigKey.IRCBotNick.GetDescription());
            toolTip.SetToolTip(IRCConfig.tIRCBotNick, ConfigKey.IRCBotNick.GetDescription());

            toolTip.SetToolTip(IRCConfig.lIRCBotNetwork, ConfigKey.IRCBotNetwork.GetDescription());
            toolTip.SetToolTip(IRCConfig.tIRCBotNetwork, ConfigKey.IRCBotNetwork.GetDescription());

            toolTip.SetToolTip(IRCConfig.lIRCBotPort, ConfigKey.IRCBotPort.GetDescription());
            toolTip.SetToolTip(IRCConfig.nIRCBotPort, ConfigKey.IRCBotPort.GetDescription());

            toolTip.SetToolTip(IRCConfig.lIRCDelay, ConfigKey.IRCDelay.GetDescription());
            toolTip.SetToolTip(IRCConfig.nIRCDelay, ConfigKey.IRCDelay.GetDescription());
            toolTip.SetToolTip(IRCConfig.lIRCDelayUnits, ConfigKey.IRCDelay.GetDescription());

            toolTip.SetToolTip(IRCConfig.tIRCBotChannels, ConfigKey.IRCBotChannels.GetDescription());

            toolTip.SetToolTip(IRCConfig.xIRCRegisteredNick, ConfigKey.IRCRegisteredNick.GetDescription());

            toolTip.SetToolTip(IRCConfig.lIRCNickServ, ConfigKey.IRCNickServ.GetDescription());
            toolTip.SetToolTip(IRCConfig.tIRCNickServ, ConfigKey.IRCNickServ.GetDescription());

            toolTip.SetToolTip(IRCConfig.lIRCNickServMessage, ConfigKey.IRCNickServMessage.GetDescription());
            toolTip.SetToolTip(IRCConfig.tIRCNickServMessage, ConfigKey.IRCNickServMessage.GetDescription());

            toolTip.SetToolTip(IRCConfig.lColorIRC, ConfigKey.IRCMessageColor.GetDescription());
            toolTip.SetToolTip(IRCConfig.bColorIRC, ConfigKey.IRCMessageColor.GetDescription());

            toolTip.SetToolTip(IRCConfig.xIRCBotForwardFromIRC, ConfigKey.IRCBotForwardFromIRC.GetDescription());
            toolTip.SetToolTip(IRCConfig.xIRCBotAnnounceIRCJoins, ConfigKey.IRCBotAnnounceIRCJoins.GetDescription());

            toolTip.SetToolTip(IRCConfig.xIRCBotForwardFromServer, ConfigKey.IRCBotForwardFromServer.GetDescription());
            toolTip.SetToolTip(IRCConfig.xIRCBotAnnounceServerJoins, ConfigKey.IRCBotAnnounceServerJoins.GetDescription());
            toolTip.SetToolTip(IRCConfig.xIRCBotAnnounceServerEvents, ConfigKey.IRCBotAnnounceServerEvents.GetDescription());

            // TODO: IRCThreads

            toolTip.SetToolTip(IRCConfig.xIRCUseColor, ConfigKey.IRCUseColor.GetDescription());
        }


        void FillToolTipsAdvanced()
        {
            toolTip.SetToolTip(AdvancedConfig.xRelayAllBlockUpdates, ConfigKey.RelayAllBlockUpdates.GetDescription());

            toolTip.SetToolTip(AdvancedConfig.xNoPartialPositionUpdates, ConfigKey.NoPartialPositionUpdates.GetDescription());

            toolTip.SetToolTip(AdvancedConfig.xLowLatencyMode, ConfigKey.LowLatencyMode.GetDescription());

            toolTip.SetToolTip(AdvancedConfig.lProcessPriority, ConfigKey.ProcessPriority.GetDescription());
            toolTip.SetToolTip(AdvancedConfig.cProcessPriority, ConfigKey.ProcessPriority.GetDescription());


            toolTip.SetToolTip(AdvancedConfig.lThrottling, ConfigKey.BlockUpdateThrottling.GetDescription());
            toolTip.SetToolTip(AdvancedConfig.nThrottling, ConfigKey.BlockUpdateThrottling.GetDescription());
            toolTip.SetToolTip(AdvancedConfig.lThrottlingUnits, ConfigKey.BlockUpdateThrottling.GetDescription());

            toolTip.SetToolTip(AdvancedConfig.lTickInterval, ConfigKey.TickInterval.GetDescription());
            toolTip.SetToolTip(AdvancedConfig.nTickInterval, ConfigKey.TickInterval.GetDescription());
            toolTip.SetToolTip(AdvancedConfig.lTickIntervalUnits, ConfigKey.TickInterval.GetDescription());

            toolTip.SetToolTip(AdvancedConfig.xMaxUndo, ConfigKey.MaxUndo.GetDescription());
            toolTip.SetToolTip(AdvancedConfig.nMaxUndo, ConfigKey.MaxUndo.GetDescription());
            toolTip.SetToolTip(AdvancedConfig.lMaxUndoUnits, ConfigKey.MaxUndo.GetDescription());

            toolTip.SetToolTip(AdvancedConfig.xIP, ConfigKey.IP.GetDescription());
            toolTip.SetToolTip(AdvancedConfig.tIP, ConfigKey.IP.GetDescription());

        }
    }
}