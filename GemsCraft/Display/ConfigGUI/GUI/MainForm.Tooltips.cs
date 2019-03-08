// Copyright 2009-2012 Matvei Stefarov <me@matvei.org>

using System.Windows.Forms;
using GemsCraft.Configuration;
using GemsCraft.fSystem;
using GemsCraft.Players;

namespace GemsCraft.Display.ConfigGUI.GUI
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
            toolTip.SetToolTip(SectionClasses.GeneralConfig.lServerName, ConfigKey.ServerName.GetDescription());
            toolTip.SetToolTip(SectionClasses.GeneralConfig.tServerName, ConfigKey.ServerName.GetDescription());
            

            toolTip.SetToolTip(SectionClasses.GeneralConfig.lMOTD, ConfigKey.MOTD.GetDescription());
            toolTip.SetToolTip(SectionClasses.GeneralConfig.tMOTD, ConfigKey.MOTD.GetDescription());

            toolTip.SetToolTip(SectionClasses.GeneralConfig.lMaxPlayers, ConfigKey.MaxPlayers.GetDescription());
            toolTip.SetToolTip(SectionClasses.GeneralConfig.nMaxPlayers, ConfigKey.MaxPlayers.GetDescription());

            toolTip.SetToolTip(SectionClasses.GeneralConfig.lMaxPlayersPerWorld, ConfigKey.MaxPlayersPerWorld.GetDescription());
            toolTip.SetToolTip(SectionClasses.GeneralConfig.nMaxPlayersPerWorld, ConfigKey.MaxPlayersPerWorld.GetDescription());

            toolTip.SetToolTip(SectionClasses.GeneralConfig.lDefaultRank, ConfigKey.DefaultRank.GetDescription());
            toolTip.SetToolTip(SectionClasses.GeneralConfig.cDefaultRank, ConfigKey.DefaultRank.GetDescription());

            toolTip.SetToolTip(SectionClasses.GeneralConfig.lPublic, ConfigKey.IsPublic.GetDescription());
            toolTip.SetToolTip(SectionClasses.GeneralConfig.cPublic, ConfigKey.IsPublic.GetDescription());

            toolTip.SetToolTip(SectionClasses.GeneralConfig.nPort, ConfigKey.Port.GetDescription());
            toolTip.SetToolTip(SectionClasses.GeneralConfig.lPort, ConfigKey.Port.GetDescription());

            toolTip.SetToolTip(SectionClasses.GeneralConfig.nUploadBandwidth, ConfigKey.UploadBandwidth.GetDescription());
            toolTip.SetToolTip(SectionClasses.GeneralConfig.lUploadBandwidth, ConfigKey.UploadBandwidth.GetDescription());

            toolTip.SetToolTip(SectionClasses.GeneralConfig.bMeasure,
@"Test your connection's upload speed with speedtest.net
Note: to convert from megabits to kilobytes, multiply the
number by 128");

            toolTip.SetToolTip(SectionClasses.GeneralConfig.bRules,
@"Edit the list of rules displayed by the ""/Rules"" command.
This list is stored in rules.txt, and can also be edited with any text editor.
If rules.txt is missing or empty, ""/Rules"" shows this message:
""Use common sense!""");

            const string tipAnnouncements =
@"Show a random announcement every once in a while.
Announcements are shown to all players, one line at a time, in random order.";
            toolTip.SetToolTip(SectionClasses.GeneralConfig.xAnnouncements, tipAnnouncements);

            toolTip.SetToolTip(SectionClasses.GeneralConfig.nAnnouncements, ConfigKey.AnnouncementInterval.GetDescription());
            toolTip.SetToolTip(SectionClasses.GeneralConfig.lAnnouncementsUnits, ConfigKey.AnnouncementInterval.GetDescription());

            toolTip.SetToolTip(SectionClasses.GeneralConfig.bAnnouncements,
@"Edit the list of announcements (announcements.txt).
One line is shown at a time, in random order.
You can include any color codes in the announcements.
You can also edit announcements.txt with any text editor.");

            toolTip.SetToolTip(SectionClasses.GeneralConfig.bGreeting,
@"Edit a custom greeting that's shown to connecting players.
You can use any color codes, and these special variables:
    {SERVER_NAME} = server name (as defined in config)
    {RANK} = connecting player's rank");

            

        }


        void FillToolTipsChat()
        {

            toolTip.SetToolTip(SectionClasses.ChatConfig.xRankColorsInChat, ConfigKey.RankColorsInChat.GetDescription());

            toolTip.SetToolTip(SectionClasses.ChatConfig.xRankColorsInWorldNames, ConfigKey.RankColorsInWorldNames.GetDescription());

            toolTip.SetToolTip(SectionClasses.ChatConfig.xRankPrefixesInChat, ConfigKey.RankPrefixesInChat.GetDescription());

            toolTip.SetToolTip(SectionClasses.ChatConfig.xRankPrefixesInList, ConfigKey.RankPrefixesInList.GetDescription());

            toolTip.SetToolTip(SectionClasses.ChatConfig.xShowConnectionMessages, ConfigKey.ShowConnectionMessages.GetDescription());

            toolTip.SetToolTip(SectionClasses.ChatConfig.xShowJoinedWorldMessages, ConfigKey.ShowJoinedWorldMessages.GetDescription());

            toolTip.SetToolTip(SectionClasses.ChatConfig.bColorSys, ConfigKey.SystemMessageColor.GetDescription());
            toolTip.SetToolTip(SectionClasses.ChatConfig.lColorSys, ConfigKey.SystemMessageColor.GetDescription());

            toolTip.SetToolTip(SectionClasses.ChatConfig.bColorHelp, ConfigKey.HelpColor.GetDescription());
            toolTip.SetToolTip(SectionClasses.ChatConfig.lColorHelp, ConfigKey.HelpColor.GetDescription());

            toolTip.SetToolTip(SectionClasses.ChatConfig.bColorSay, ConfigKey.SayColor.GetDescription());
            toolTip.SetToolTip(SectionClasses.ChatConfig.lColorSay, ConfigKey.SayColor.GetDescription());

            toolTip.SetToolTip(SectionClasses.ChatConfig.bColorAnnouncement, ConfigKey.AnnouncementColor.GetDescription());
            toolTip.SetToolTip(SectionClasses.ChatConfig.lColorAnnouncement, ConfigKey.AnnouncementColor.GetDescription());

            toolTip.SetToolTip(SectionClasses.ChatConfig.bColorPM, ConfigKey.PrivateMessageColor.GetDescription());
            toolTip.SetToolTip(SectionClasses.ChatConfig.lColorPM, ConfigKey.PrivateMessageColor.GetDescription());

            toolTip.SetToolTip(SectionClasses.ChatConfig.bColorMe, ConfigKey.MeColor.GetDescription());
            toolTip.SetToolTip(SectionClasses.ChatConfig.lColorMe, ConfigKey.MeColor.GetDescription());

            toolTip.SetToolTip(SectionClasses.ChatConfig.bColorWarning, ConfigKey.WarningColor.GetDescription());
            toolTip.SetToolTip(SectionClasses.ChatConfig.lColorWarning, ConfigKey.WarningColor.GetDescription());
        }


        void FillToolTipsWorlds()
        {
            toolTip.SetToolTip(SectionClasses.WorldConfig.bAddWorld, "Add a new world to the list.");
            toolTip.SetToolTip(SectionClasses.WorldConfig.bWorldEdit, "Edit or replace an existing world.");
            toolTip.SetToolTip(SectionClasses.WorldConfig.cMainWorld, "Main world is the first world that players see when they join the server.");
            toolTip.SetToolTip(SectionClasses.WorldConfig.bWorldDelete, "Delete a world from the list.");

            toolTip.SetToolTip(SectionClasses.WorldConfig.lDefaultBuildRank, ConfigKey.DefaultBuildRank.GetDescription());
            toolTip.SetToolTip(SectionClasses.WorldConfig.cDefaultBuildRank, ConfigKey.DefaultBuildRank.GetDescription());

            toolTip.SetToolTip(SectionClasses.WorldConfig.tMapPath, ConfigKey.MapPath.GetDescription());
            toolTip.SetToolTip(SectionClasses.WorldConfig.xMapPath, ConfigKey.MapPath.GetDescription());

            toolTip.SetToolTip(SectionClasses.WorldConfig.xWoMEnableEnvExtensions, ConfigKey.WoMEnableEnvExtensions.GetDescription());
        }


        void FillToolTipsRanks()
        {

            toolTip.SetToolTip(SectionClasses.RankConfig.xAllowSecurityCircumvention,
@"Allows players to manupulate whitelists/blacklists or rank requirements
in order to join restricted worlds, or to build in worlds/zones. Normally
players with ManageWorlds and ManageZones permissions are not allowed to do this.
Affected commands:
    /WAccess
    /WBuild
    /WMain
    /ZEdit");

            toolTip.SetToolTip(SectionClasses.RankConfig.bAddRank, "Add a new rank to the list.");
            toolTip.SetToolTip(SectionClasses.RankConfig.bDeleteRank,
@"Delete a rank from the list. You will be prompted to specify a replacement
rank - to be able to convert old references to the deleted rank.");
            toolTip.SetToolTip(SectionClasses.RankConfig.bRaiseRank,
@"Raise a rank (and all players of the rank) on the hierarchy.
The hierarchy is used for all permission checks.");
            toolTip.SetToolTip(SectionClasses.RankConfig.bLowerRank,
@"Lower a rank (and all players of the rank) on the hierarchy.
The hierarchy is used for all permission checks.");

            const string tipRankName =
"Name of the rank - between 2 and 16 alphanumeric characters.";
            toolTip.SetToolTip(SectionClasses.RankConfig.lRankName, tipRankName);
            toolTip.SetToolTip(SectionClasses.RankConfig.tRankName, tipRankName);

            const string tipRankColor =
@"Color associated with this rank.
Rank colors may be applied to player and world names.";
            toolTip.SetToolTip(SectionClasses.RankConfig.lRankColor, tipRankColor);
            toolTip.SetToolTip(SectionClasses.RankConfig.bColorRank, tipRankColor);

            const string tipPrefix =
@"1-character prefix that may be shown above player names.
The option to show prefixes in chat is on ""General"" tab.";
            toolTip.SetToolTip(SectionClasses.RankConfig.lPrefix, tipPrefix);
            toolTip.SetToolTip(SectionClasses.RankConfig.tPrefix, tipPrefix);



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



            toolTip.SetToolTip(SectionClasses.RankConfig.xReserveSlot,
@"Allows players of this rank to join the server
even if it reached the maximum number of players.");

            const string tipKickIdle = "Allows kicking players who have been inactive/AFK for some time.";
            toolTip.SetToolTip(SectionClasses.RankConfig.xKickIdle, tipKickIdle);
            toolTip.SetToolTip(SectionClasses.RankConfig.nKickIdle, tipKickIdle);
            toolTip.SetToolTip(SectionClasses.RankConfig.lKickIdleUnits, tipKickIdle);

            toolTip.SetToolTip(SectionClasses.RankConfig.xAntiGrief,
@"Antigrief is an automated system for kicking players who build
or delete at abnormally high rates. This helps stop certain kinds
of malicious software (like MCTunnel) from doing large-scale damage
to server maps. False positives can sometimes occur if server or
player connection is very laggy.");

            toolTip.SetToolTip(SectionClasses.RankConfig.nAntiGriefBlocks,
@"Maximum number of blocks that players of this rank are
allowed to build in a specified time period.");

            toolTip.SetToolTip(SectionClasses.RankConfig.nAntiGriefBlocks,
@"Minimum time interval that players of this rank are
expected to spent to build a specified number of blocks.");

            const string tipDrawLimit =
@"Limit on the number of blocks that a player is
allowed to affect with drawing or copy/paste commands
at one time. If unchecked, there is no limit.";
            toolTip.SetToolTip(SectionClasses.RankConfig.xDrawLimit, tipDrawLimit);
            toolTip.SetToolTip(SectionClasses.RankConfig.nDrawLimit, tipDrawLimit);
            toolTip.SetToolTip(SectionClasses.RankConfig.lDrawLimitUnits, tipDrawLimit);




            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Ban].ToolTipText =
@"Ability to ban/unban other players from the server.
Affected commands:
    /Ban
    /Banx
    /Unban";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.BanAll].ToolTipText =
@"Ability to ban/unban a player account, his IP, and all other accounts that used the IP.
BanAll/UnbanAll commands can be used on players who keep evading bans.
Required permissions: Ban & BanIP
Affected commands:
    /BanAll
    /UnbanAll";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.BanIP].ToolTipText =
@"Ability to ban/unban players by IP.
Required permission: Ban
Affected commands:
    /BanIP
    /UnbanIP";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Basscannon].ToolTipText =
@"Ability to kick a player with stlye.
Affected command:
    /Basscannon";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Bring].ToolTipText =
@"Ability to bring/summon other players to your location.
This works a bit like reverse-teleport - other player is sent to you.
Affected commands:
    /Bring
    /BringAll";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.BringAll].ToolTipText =
@"Ability to bring/summon many players at a time to your location.
Affected command:
    /BringAll";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.BroMode].ToolTipText =
@"Ability to activate BroMode.
Affected command:
    /BroMode";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Build].ToolTipText =
@"Ability to place blocks on maps. This is a baseline permission
that can be overridden by world-specific and zone-specific permissions.";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Chat].ToolTipText =
@"Ability to chat and PM players. Note that players without this
permission can still type in commands, receive PMs, and read chat.
Affected commands:
    /Say
    @ (pm)
    @@ (rank chat)";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.ChatWithCaps].ToolTipText =
@"Ability to chat with caps without restrictions.";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.CopyAndPaste].ToolTipText =
@"Ability to copy (or cut) and paste blocks. The total number of
blocks that can be copied or pasted at a time is affected by
the draw limit.
Affected commands:
    /Copy
    /Cut
    /Mirror
    /Paste, /PasteNot
    /Rotate";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Delete].ToolTipText =
@"Ability to delete or replace blocks on maps. This is a baseline permission
that can be overridden by world-specific and zone-specific permissions.";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.DeleteAdmincrete].ToolTipText =
@"Ability to delete admincrete (aka adminium) blocks. Even if someone
has this permission, it can be overridden by world-specific and
zone-specific permissions.
Required permission: Delete";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Demote].ToolTipText =
@"Ability to demote other players to a lower rank.
Affected commands:
    /Rank
    /MassRank";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Draw].ToolTipText =
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

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.DrawAdvanced].ToolTipText =
@"Ability to use advanced drawing tools, such as brushes.
Required permission: Build, Delete, Draw
Affected commands:
    /Brush
    /ReplaceBrush
    /Restore
    /Sphere and /SphereH
    /Torus";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.EditPlayerDB].ToolTipText =
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

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Fireworks].ToolTipText =
@"Ability to create fireworks.
Affected command:
    /Firework";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Freeze].ToolTipText =
@"Ability to freeze/unfreeze players. Frozen players cannot
move or build/delete.
Affected commands:
    /Freeze
    /Unfreeze";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Gtfo].ToolTipText =
@"Ability to kick a player without saving it to the DB.
Affected command:
    /Gtfo";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Gun].ToolTipText =
@"Ability to use a gun.
Affected command:
    /Gun";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Hide].ToolTipText =
@"Ability to appear hidden from other players. You can still chat,
build/delete blocks, use all commands, and join worlds while hidden.
Hidden players are completely invisible to other players.
Affected commands:
    /Hide
    /Unhide";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.HideRanks].ToolTipText =
@"Ability to hide ranks from the /ranks list.
Affected command:
    /RankHide";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.HighFive].ToolTipText =
@"Ability to give a player a HighFive.
Affected command:
    /High5";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Import].ToolTipText =
@"Ability to import rank and ban lists from files. Useful if you
are switching from another server software.
Affected commands:
    /Import";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Immortal].ToolTipText =
@"Ability to become immortal.
Affected command:
    /Immortal";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Kick].ToolTipText =
@"Ability to kick players from the server.
Affected commands:
    /Kick";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Kill].ToolTipText =
@"Ability to kill players.
Affected command:
    /Kill";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Lock].ToolTipText =
@"Ability to lock/unlock maps (locking puts a world into read-only state.)
Affected commands:
    /WLock
    /WUnlock";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.MakeVoteKicks].ToolTipText =
@"Ability to vote to kick a player.
Affected command:
    /Vote";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.MakeVotes].ToolTipText =
@"Ability to create votes.
Affected command:
    /Vote";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.ManageWorlds].ToolTipText =
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


            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.ManageBlockDB].ToolTipText =
@"Ability to enable/disable, clear, and configure BlockDB.
Affected command:
    /BlockDB";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.ManagePortal].ToolTipText =
@"Ability to create, edit, and delete portals.
Affected command:
    /Portal";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.ManageZones].ToolTipText =
@"Ability to manipulate zones: adding, editing, renaming, and removing zones.
Affected commands:
    /ZAdd
    /ZEdit
    /ZRemove
    /ZRename";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Moderation].ToolTipText =
@"Ability to mute everyone in the server, useful for announcements.
Affected command:
    /Moderate";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Mute].ToolTipText =
@"Ability to temporarily mute players. Muted players cannot write chat or 
send PMs, but they can still type in commands, receive PMs, and read chat.
Affected commands:
    /Mute
    /Unmute";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Patrol].ToolTipText =
@"Ability to patrol lower-ranked players. ""Patrolling"" means teleporting
to other players to check on them, usually while hidden.
Required permission: Teleport
Affected commands:
    /Patrol
    /SpecPatrol";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Physics].ToolTipText =
@"Ability to activate Physics on a world.
Affected command:
    /Physics";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.PlaceAdmincrete].ToolTipText =
@"Ability to place admincrete/adminium. This also affects draw commands.
Required permission: Build
Affected commands:
    /Solid
    /Bind";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.PlaceGrass].ToolTipText =
@"Ability to place grass blocks. This also affects draw commands.
Required permission: Build
Affected commands:
    /Grass
    /Bind";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.PlaceLava].ToolTipText =
@"Ability to place lava blocks. This also affects draw commands.
Required permission: Build
Affected commands:
    /Lava
    /Bind";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.PlaceWater].ToolTipText =
@"Ability to place water blocks. This also affects draw commands.
Required permission: Build
Affected commands:
    /Water
    /Bind";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Possess].ToolTipText =
        @"Ability to possess a player.
Affected commands:
    /Possess
    /unpossess";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Promote].ToolTipText =
@"Ability to promote players to a higher rank.
Affected commands:
    /Rank";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.RageQuit].ToolTipText =
@"Ability to ragequit from the server.
Affected command:
    /Ragequit";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.ReadAdminChat].ToolTipText =
@"Ability to read Admin chat.";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.ReadCustomChat].ToolTipText =
@"Ability to read Custom chat.";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.ReadStaffChat].ToolTipText =
@"Ability to read staff chat.";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Realm].ToolTipText =
@"Ability to create realms.
Affected command:
    /Realm";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.ReloadConfig].ToolTipText =
@"Ability to reload the configuration file without restarting.
Affected commands:
    /Reload";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Say].ToolTipText =
@"Ability to use /Say command.
Required permission: Chat
Affected commands:
    /Say";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.SetSpawn].ToolTipText =
@"Ability to change the spawn point of a world or a player.
Affected commands:
    /SetSpawn";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.ShutdownServer].ToolTipText =
@"Ability to shut down or restart the server remotely.
Useful for servers that run on dedicated machines.
Affected commands:
    /Shutdown
    /Restart";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Slap].ToolTipText =
@"Ability to slap players.
Affected command:
    /Slap";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Spectate].ToolTipText =
@"Ability to spectate/follow other players in first-person view.
Affected commands:
    /Spectate";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Swear].ToolTipText =
@"Ability to use swear words without restrictions";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Teleport].ToolTipText =
@"Ability to teleport to other players.
Affected commands:
    /TP";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.TempBan].ToolTipText =
@"Ability to temporarily ban a player.
Affected command:
    /Tempban";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Tower].ToolTipText =
@"Ability to create a Tower.
Affected command:
    /Tower";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Tree].ToolTipText =
@"Ability to create a tree.
Affected command:
    /Tree";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Troll].ToolTipText =
@"Ability to troll players.
Affected command:
    /Troll";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.UndoOthersActions].ToolTipText =
@"Ability to undo actions of other players, using the BlockDB.
Affected commands:
    /UndoArea
    /UndoPlayer";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.UseColorCodes].ToolTipText =
@"Ability to use color codes in chat messages.";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.UsePortal].ToolTipText =
@"Ability to use portals (not be confused with ManagePortal).";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.UseSpeedHack].ToolTipText =
@"Ability to move at a faster-than-normal rate (using hacks).
WARNING: Speedhack detection is often inaccurate, and may produce many
false positives - especially on laggy servers.";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.Warn].ToolTipText =
@"Ability to warn a player.
Affected command:
    /Warn";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.ViewOthersInfo].ToolTipText =
@"Ability to view extended information about other players.
Affected commands:
    /Info
    /BanInfo
    /Where";

            SectionClasses.RankConfig.vPermissions.Items[(int)Permission.ViewPlayerIPs].ToolTipText =
@"Ability to view players' IP addresses.
Affected commands:
    /Info
    /BanInfo
    /BanIP, /BanAll, /UnbanIP, /UnbanAll";
        }


        void FillToolTipsSecurity()
        {
            toolTip.SetToolTip(SectionClasses.SecurityConfig.lVerifyNames, ConfigKey.VerifyNames.GetDescription());
            toolTip.SetToolTip(SectionClasses.SecurityConfig.cVerifyNames, ConfigKey.VerifyNames.GetDescription());

            toolTip.SetToolTip(SectionClasses.SecurityConfig.xMaxConnectionsPerIP, ConfigKey.MaxConnectionsPerIP.GetDescription());
            toolTip.SetToolTip(SectionClasses.SecurityConfig.nMaxConnectionsPerIP, ConfigKey.MaxConnectionsPerIP.GetDescription());

            toolTip.SetToolTip(SectionClasses.SecurityConfig.xAllowUnverifiedLAN, ConfigKey.AllowUnverifiedLAN.GetDescription());

            toolTip.SetToolTip(SectionClasses.SecurityConfig.xRequireBanReason, ConfigKey.RequireBanReason.GetDescription());
            toolTip.SetToolTip(SectionClasses.SecurityConfig.xRequireKickReason, ConfigKey.RequireKickReason.GetDescription());
            toolTip.SetToolTip(SectionClasses.SecurityConfig.xRequireRankChangeReason, ConfigKey.RequireRankChangeReason.GetDescription());

            toolTip.SetToolTip(SectionClasses.SecurityConfig.xAnnounceKickAndBanReasons, ConfigKey.AnnounceKickAndBanReasons.GetDescription());
            toolTip.SetToolTip(SectionClasses.SecurityConfig.xAnnounceRankChanges, ConfigKey.AnnounceRankChanges.GetDescription());
            toolTip.SetToolTip(SectionClasses.SecurityConfig.xAnnounceRankChangeReasons, ConfigKey.AnnounceRankChanges.GetDescription());
            
            toolTip.SetToolTip(SectionClasses.SecurityConfig.lPatrolledRank, ConfigKey.PatrolledRank.GetDescription());
            toolTip.SetToolTip(SectionClasses.SecurityConfig.cPatrolledRank, ConfigKey.PatrolledRank.GetDescription());
            toolTip.SetToolTip(SectionClasses.SecurityConfig.lPatrolledRankAndBelow, ConfigKey.PatrolledRank.GetDescription());

            toolTip.SetToolTip(SectionClasses.SecurityConfig.nAntispamMessageCount, ConfigKey.AntispamMessageCount.GetDescription());
            toolTip.SetToolTip(SectionClasses.SecurityConfig.lAntispamMessageCount, ConfigKey.AntispamMessageCount.GetDescription());
            toolTip.SetToolTip(SectionClasses.SecurityConfig.nAntispamInterval, ConfigKey.AntispamInterval.GetDescription());
            toolTip.SetToolTip(SectionClasses.SecurityConfig.lAntispamInterval, ConfigKey.AntispamInterval.GetDescription());

            toolTip.SetToolTip(SectionClasses.SecurityConfig.xAntispamKicks, "Kick players who repeatedly trigger antispam warnings.");
            toolTip.SetToolTip(SectionClasses.SecurityConfig.nAntispamMaxWarnings, ConfigKey.AntispamMaxWarnings.GetDescription());
            toolTip.SetToolTip(SectionClasses.SecurityConfig.lAntispamMaxWarnings, ConfigKey.AntispamMaxWarnings.GetDescription());

            toolTip.SetToolTip(SectionClasses.SecurityConfig.xBlockDBEnabled, ConfigKey.BlockDBEnabled.GetDescription());
            toolTip.SetToolTip(SectionClasses.SecurityConfig.xBlockDBAutoEnable, ConfigKey.BlockDBAutoEnable.GetDescription());
            toolTip.SetToolTip(SectionClasses.SecurityConfig.cBlockDBAutoEnableRank, ConfigKey.BlockDBAutoEnableRank.GetDescription());
        }


        void FillToolTipsSavingAndBackup()
        {

            toolTip.SetToolTip(SectionClasses.SavingConfig.xSaveInterval, ConfigKey.SaveInterval.GetDescription());
            toolTip.SetToolTip(SectionClasses.SavingConfig.nSaveInterval, ConfigKey.SaveInterval.GetDescription());
            toolTip.SetToolTip(SectionClasses.SavingConfig.lSaveIntervalUnits, ConfigKey.SaveInterval.GetDescription());

            toolTip.SetToolTip(SectionClasses.SavingConfig.xBackupOnStartup, ConfigKey.BackupOnStartup.GetDescription());

            toolTip.SetToolTip(SectionClasses.SavingConfig.xBackupOnJoin, ConfigKey.BackupOnJoin.GetDescription());

            toolTip.SetToolTip(SectionClasses.SavingConfig.xBackupInterval, ConfigKey.DefaultBackupInterval.GetDescription());
            toolTip.SetToolTip(SectionClasses.SavingConfig.nBackupInterval, ConfigKey.DefaultBackupInterval.GetDescription());
            toolTip.SetToolTip(SectionClasses.SavingConfig.lBackupIntervalUnits, ConfigKey.DefaultBackupInterval.GetDescription());

            toolTip.SetToolTip(SectionClasses.SavingConfig.xBackupOnlyWhenChanged, ConfigKey.DefaultBackupInterval.GetDescription());

            toolTip.SetToolTip(SectionClasses.SavingConfig.xMaxBackups, ConfigKey.MaxBackups.GetDescription());
            toolTip.SetToolTip(SectionClasses.SavingConfig.nMaxBackups, ConfigKey.MaxBackups.GetDescription());
            toolTip.SetToolTip(SectionClasses.SavingConfig.lMaxBackups, ConfigKey.MaxBackups.GetDescription());

            toolTip.SetToolTip(SectionClasses.SavingConfig.xMaxBackupSize, ConfigKey.MaxBackupSize.GetDescription());
            toolTip.SetToolTip(SectionClasses.SavingConfig.nMaxBackupSize, ConfigKey.MaxBackupSize.GetDescription());
            toolTip.SetToolTip(SectionClasses.SavingConfig.lMaxBackupSize, ConfigKey.MaxBackupSize.GetDescription());
        }


        void FillToolTipsLogging()
        {
            toolTip.SetToolTip(SectionClasses.LoggingConfig.lLogMode, ConfigKey.LogMode.GetDescription());
            toolTip.SetToolTip(SectionClasses.LoggingConfig.cLogMode, ConfigKey.LogMode.GetDescription());

            toolTip.SetToolTip(SectionClasses.LoggingConfig.xLogLimit, ConfigKey.MaxLogs.GetDescription());
            toolTip.SetToolTip(SectionClasses.LoggingConfig.nLogLimit, ConfigKey.MaxLogs.GetDescription());
            toolTip.SetToolTip(SectionClasses.LoggingConfig.lLogLimitUnits, ConfigKey.MaxLogs.GetDescription());

            SectionClasses.LoggingConfig.vLogFileOptions.Items[(int)LogType.ConsoleInput].ToolTipText = "Commands typed in from the server console.";
            SectionClasses.LoggingConfig.vLogFileOptions.Items[(int)LogType.ConsoleOutput].ToolTipText =
@"Things sent directly in response to console input,
e.g. output of commands called from console.";
            SectionClasses.LoggingConfig.vLogFileOptions.Items[(int)LogType.Debug].ToolTipText = "Technical information that may be useful to find bugs.";
            SectionClasses.LoggingConfig.vLogFileOptions.Items[(int)LogType.Error].ToolTipText = "Major errors and problems.";
            SectionClasses.LoggingConfig.vLogFileOptions.Items[(int)LogType.SeriousError].ToolTipText = "Errors that prevent server from starting or result in crashes.";
            SectionClasses.LoggingConfig.vLogFileOptions.Items[(int)LogType.GlobalChat].ToolTipText = "Normal chat messages written by players.";
            SectionClasses.LoggingConfig.vLogFileOptions.Items[(int)LogType.IRC].ToolTipText =
@"IRC-related status and error messages.
Does not include IRC chatter (see IRCChat).";
            SectionClasses.LoggingConfig.vLogFileOptions.Items[(int)LogType.PrivateChat].ToolTipText = "PMs (Private Messages) exchanged between players (@player message).";
            SectionClasses.LoggingConfig.vLogFileOptions.Items[(int)LogType.RankChat].ToolTipText = "Rank-wide messages (@@rank message).";
            SectionClasses.LoggingConfig.vLogFileOptions.Items[(int)LogType.SuspiciousActivity].ToolTipText = "Suspicious activity - hack attempts, failed logins, unverified names.";
            SectionClasses.LoggingConfig.vLogFileOptions.Items[(int)LogType.SystemActivity].ToolTipText = "Status messages regarding normal system activity.";
            SectionClasses.LoggingConfig.vLogFileOptions.Items[(int)LogType.UserActivity].ToolTipText = "Status messages regarding players' actions.";
            SectionClasses.LoggingConfig.vLogFileOptions.Items[(int)LogType.UserCommand].ToolTipText = "Commands types in by players.";
            SectionClasses.LoggingConfig.vLogFileOptions.Items[(int)LogType.Warning].ToolTipText = "Minor, recoverable errors and problems.";
            SectionClasses.LoggingConfig.vLogFileOptions.Items[(int)LogType.ChangedWorld].ToolTipText = "Logs when a player changes world.";

            for (int i = 0; i < SectionClasses.LoggingConfig.vConsoleOptions.Items.Count; i++)
            {
                SectionClasses.LoggingConfig.vConsoleOptions.Items[i].ToolTipText = SectionClasses.LoggingConfig.vLogFileOptions.Items[i].ToolTipText;
            }
        }


        void FillToolTipsIRC()
        {
            toolTip.SetToolTip(SectionClasses.IRCConfig.xIRCBotEnabled, ConfigKey.IRCBotEnabled.GetDescription());

            const string tipIRCList =
@"Choose one of these popular IRC networks,
or type in address/port manually below.";
            toolTip.SetToolTip(SectionClasses.IRCConfig.lIRCList, tipIRCList);
            toolTip.SetToolTip(SectionClasses.IRCConfig.cIRCList, tipIRCList);

            toolTip.SetToolTip(SectionClasses.IRCConfig.lIRCBotNick, ConfigKey.IRCBotNick.GetDescription());
            toolTip.SetToolTip(SectionClasses.IRCConfig.tIRCBotNick, ConfigKey.IRCBotNick.GetDescription());

            toolTip.SetToolTip(SectionClasses.IRCConfig.lIRCBotNetwork, ConfigKey.IRCBotNetwork.GetDescription());
            toolTip.SetToolTip(SectionClasses.IRCConfig.tIRCBotNetwork, ConfigKey.IRCBotNetwork.GetDescription());

            toolTip.SetToolTip(SectionClasses.IRCConfig.lIRCBotPort, ConfigKey.IRCBotPort.GetDescription());
            toolTip.SetToolTip(SectionClasses.IRCConfig.nIRCBotPort, ConfigKey.IRCBotPort.GetDescription());

            toolTip.SetToolTip(SectionClasses.IRCConfig.lIRCDelay, ConfigKey.IRCDelay.GetDescription());
            toolTip.SetToolTip(SectionClasses.IRCConfig.nIRCDelay, ConfigKey.IRCDelay.GetDescription());
            toolTip.SetToolTip(SectionClasses.IRCConfig.lIRCDelayUnits, ConfigKey.IRCDelay.GetDescription());

            toolTip.SetToolTip(SectionClasses.IRCConfig.tIRCBotChannels, ConfigKey.IRCBotChannels.GetDescription());

            toolTip.SetToolTip(SectionClasses.IRCConfig.xIRCRegisteredNick, ConfigKey.IRCRegisteredNick.GetDescription());

            toolTip.SetToolTip(SectionClasses.IRCConfig.lIRCNickServ, ConfigKey.IRCNickServ.GetDescription());
            toolTip.SetToolTip(SectionClasses.IRCConfig.tIRCNickServ, ConfigKey.IRCNickServ.GetDescription());

            toolTip.SetToolTip(SectionClasses.IRCConfig.lIRCNickServMessage, ConfigKey.IRCNickServMessage.GetDescription());
            toolTip.SetToolTip(SectionClasses.IRCConfig.tIRCNickServMessage, ConfigKey.IRCNickServMessage.GetDescription());

            toolTip.SetToolTip(SectionClasses.IRCConfig.lColorIRC, ConfigKey.IRCMessageColor.GetDescription());
            toolTip.SetToolTip(SectionClasses.IRCConfig.bColorIRC, ConfigKey.IRCMessageColor.GetDescription());

            toolTip.SetToolTip(SectionClasses.IRCConfig.xIRCBotForwardFromIRC, ConfigKey.IRCBotForwardFromIRC.GetDescription());
            toolTip.SetToolTip(SectionClasses.IRCConfig.xIRCBotAnnounceIRCJoins, ConfigKey.IRCBotAnnounceIRCJoins.GetDescription());

            toolTip.SetToolTip(SectionClasses.IRCConfig.xIRCBotForwardFromServer, ConfigKey.IRCBotForwardFromServer.GetDescription());
            toolTip.SetToolTip(SectionClasses.IRCConfig.xIRCBotAnnounceServerJoins, ConfigKey.IRCBotAnnounceServerJoins.GetDescription());
            toolTip.SetToolTip(SectionClasses.IRCConfig.xIRCBotAnnounceServerEvents, ConfigKey.IRCBotAnnounceServerEvents.GetDescription());

            // TODO: IRCThreads

            toolTip.SetToolTip(SectionClasses.IRCConfig.xIRCUseColor, ConfigKey.IRCUseColor.GetDescription());
        }


        void FillToolTipsAdvanced()
        {
            toolTip.SetToolTip(SectionClasses.AdvancedConfig.xRelayAllBlockUpdates, ConfigKey.RelayAllBlockUpdates.GetDescription());

            toolTip.SetToolTip(SectionClasses.AdvancedConfig.xNoPartialPositionUpdates, ConfigKey.NoPartialPositionUpdates.GetDescription());

            toolTip.SetToolTip(SectionClasses.AdvancedConfig.xLowLatencyMode, ConfigKey.LowLatencyMode.GetDescription());

            toolTip.SetToolTip(SectionClasses.AdvancedConfig.lProcessPriority, ConfigKey.ProcessPriority.GetDescription());
            toolTip.SetToolTip(SectionClasses.AdvancedConfig.cProcessPriority, ConfigKey.ProcessPriority.GetDescription());


            toolTip.SetToolTip(SectionClasses.AdvancedConfig.lThrottling, ConfigKey.BlockUpdateThrottling.GetDescription());
            toolTip.SetToolTip(SectionClasses.AdvancedConfig.nThrottling, ConfigKey.BlockUpdateThrottling.GetDescription());
            toolTip.SetToolTip(SectionClasses.AdvancedConfig.lThrottlingUnits, ConfigKey.BlockUpdateThrottling.GetDescription());

            toolTip.SetToolTip(SectionClasses.AdvancedConfig.lTickInterval, ConfigKey.TickInterval.GetDescription());
            toolTip.SetToolTip(SectionClasses.AdvancedConfig.nTickInterval, ConfigKey.TickInterval.GetDescription());
            toolTip.SetToolTip(SectionClasses.AdvancedConfig.lTickIntervalUnits, ConfigKey.TickInterval.GetDescription());

            toolTip.SetToolTip(SectionClasses.AdvancedConfig.xMaxUndo, ConfigKey.MaxUndo.GetDescription());
            toolTip.SetToolTip(SectionClasses.AdvancedConfig.nMaxUndo, ConfigKey.MaxUndo.GetDescription());
            toolTip.SetToolTip(SectionClasses.AdvancedConfig.lMaxUndoUnits, ConfigKey.MaxUndo.GetDescription());

            toolTip.SetToolTip(SectionClasses.AdvancedConfig.xIP, ConfigKey.IP.GetDescription());
            toolTip.SetToolTip(SectionClasses.AdvancedConfig.tIP, ConfigKey.IP.GetDescription());

        }
    }
}