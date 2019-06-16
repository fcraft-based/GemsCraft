﻿using System;
using System.IO;
using GemsCraft.Drawing.nbt;
using GemsCraft.Drawing.nbt.Tags;
using GemsCraft.Physics;
using GemsCraft.Players;
using GemsCraft.Utils;
using GemsCraft.Worlds;

namespace GemsCraft.Commands
{
    static class DevCommands {

        public static void Init()
        {
            //CommandManager.RegisterCommand(CdDrawScheme);

            //CommandManager.RegisterCommand(CdSpell);
        }


      

        static readonly CommandDescriptor CdSpell = new CommandDescriptor
        {
            Name = "Spell",
            Category = CommandCategory.Fun,
            Permissions = new[] { Permission.Chat },
            IsConsoleSafe = false,
            NotRepeatable = true,
            Usage = "/Spell",
            Help = "Penis",
            UsableByFrozenPlayers = false,
            Handler = SpellHandler,
        };
        public static SpellStartBehavior particleBehavior = new SpellStartBehavior();
        internal static void SpellHandler(Player player, Command cmd)
        {
            World world = player.World;
            Vector3I pos1 = player.Position.ToBlockCoords();
            Random _r = new Random();
            int n = _r.Next(8, 12);
            for (int i = 0; i < n; ++i)
            {
                double phi = -_r.NextDouble() + -player.Position.L * 2 * Math.PI;
                double ksi = -_r.NextDouble() + player.Position.R * Math.PI - Math.PI / 2.0;

                Vector3F direction = (new Vector3F((float)(Math.Cos(phi) * Math.Cos(ksi)), (float)(Math.Sin(phi) * Math.Cos(ksi)), (float)Math.Sin(ksi))).Normalize();
                world.AddPhysicsTask(new Particle(world, (pos1 + 2 * direction).Round(), direction, player, Block.Obsidian, particleBehavior), 0);
            }
        }

        static readonly CommandDescriptor CdDrawScheme = new CommandDescriptor
        {
            Name = "DrawScheme",
            Aliases = new[] { "drs" },
            Category = CommandCategory.Building,
            Permissions = new[] { Permission.PlaceAdmincrete },
            Help = "Toggles the admincrete placement mode. When enabled, any stone block you place is replaced with admincrete.",
            Handler = test
        };
        public static void test(Player player, Command cmd)
        {
            if (!File.Exists("C:/users/jb509/desktop/1.schematic"))
            {
                player.Message("Nop"); return;
            }
            NbtFile file = new NbtFile("C:/users/jb509/desktop/1.schematic");
            file.RootTag = new NbtCompound("Schematic");
            file.LoadFile();
            bool notClassic = false;
            short width = file.RootTag.Query<NbtShort>("/Schematic/Width").Value;
            short height = file.RootTag.Query<NbtShort>("/Schematic/Height").Value;
            short length = file.RootTag.Query<NbtShort>("/Schematic/Length").Value;
            Byte[] blocks = file.RootTag.Query<NbtByteArray>("/Schematic/Blocks").Value;

            Vector3I pos = player.Position.ToBlockCoords();
            int i = 0;
            player.Message("&SDrawing Schematic ({0}x{1}x{2})", length, width, height);
            for (int x = pos.X; x < width + pos.X; x++)
            {
                for (int y = pos.Y; y < length + pos.Y; y++)
                {
                    for (int z = pos.Z; z < height + pos.Z; z++)
                    {
                        if (Enum.Parse(typeof(Block), ((Block)blocks[i]).ToString(), true) != null)
                        {
                            if (!notClassic && blocks[i] > 49)
                            {
                                notClassic = true;
                                player.Message("&WSchematic used is not designed for Minecraft Classic;" +
                                                " Converting all unsupported blocks with air");
                            }
                            if (blocks[i] < 50)
                            {
                                player.WorldMap.QueueUpdate(new BlockUpdate(null, (short)x, (short)y, (short)z, (Block)blocks[i]));
                            }
                        }
                        i++;
                    }
                }
            }
            file.Dispose();
        }
    }
}
