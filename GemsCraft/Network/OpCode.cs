﻿// Copyright 2009-2012 Matvei Stefarov <me@matvei.org>

namespace GemsCraft.Network {
    /// <summary> Minecraft/CPE protocol's opcodes. </summary>
    public enum OpCode {
        Handshake = 0,
        Ping = 1,
        MapBegin = 2,
        MapChunk = 3,
        MapEnd = 4,
        SetBlockClient = 5,
        SetBlockServer = 6,
        AddEntity = 7,
        Teleport = 8,
        MoveRotate = 9,
        Move = 10,
        Rotate = 11,
        RemoveEntity = 12,
        Message = 13,
        Kick = 14,
        SetPermission = 15,

        // CPE
        ExtInfo = 16,
        ExtEntry = 17,
        SetClickDistance = 18,
        CustomBlocks = 19,
        HoldThis = 20,
        SetTextHotKey = 21,
        ExtAddPlayerName = 22,
        ExtAddEntity = 23,
        ExtRemovePlayerName = 24,
        EnvSetColor = 25,
        SelectionCuboid = 26,
        RemoveSelectionCuboid = 27,
        SetBlockPermissions = 28,
        ChangeModel = 29,
        EnvSetMapAppearance = 30,
        EnvSetWeatherAppearance = 31,
        HackControl = 32,
        ExtAddEntity2 = 33,
        PlayerClicked = 34,
        DefineBlock = 35,
        RemoveBlockDefinition = 36,
        DefineBlockExt = 37,
        BulkBlockUpdate = 38,
        SetTextColor = 39,
        SetMapEnvUrl = 40,
        SetMapEnvProperty = 41,
        SetEntityProperty = 42,
        TwoWayPing = 43,
        SetInventoryOrder = 44
    }
}
