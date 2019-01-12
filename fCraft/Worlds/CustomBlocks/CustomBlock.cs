using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GemsCraft.fSystem;
using GemsCraft.Network;
using GemsCraft.Players;
using Newtonsoft.Json;

namespace GemsCraft.Worlds.CustomBlocks
{
    public class CustomBlock
    {
        public static readonly string Dir = "Custom Blocks/";
        public static List<CustomBlock> Blocks = new List<CustomBlock>();
        public static List<CustomBlock> LoadBlocks()
        {
            Logger.Log(LogType.SystemActivity, "Loading Custom Blocks...");
            List<CustomBlock> blocks = new List<CustomBlock>();
            if (!Directory.Exists(Dir))
            {
                Logger.Log(LogType.Warning, "Custom Blocks Folder does not exist. Creating it...");
                Directory.CreateDirectory(Dir);
                return blocks;
            }

            string[] files = Directory.GetFiles(Dir);
            if (files.Length == 0) return blocks;
            foreach (string file in files)
            {
                if (!Path.HasExtension(file) || Path.GetExtension(file) != ".gcblock") continue;
                try
                {
                    string fileContents = File.ReadAllText(file);
                    CustomBlock block = JsonConvert.DeserializeObject<CustomBlock>(fileContents);

                    if (!CheckForClashes(blocks, block)) blocks.Add(block);
                    else throw new CustomBlockException("Duplicate block ID's", block);
                }
                catch (Exception e)
                {
                    Logger.Log(LogType.Error, $"Unable to load custom block file {file}");
                    Console.WriteLine(e);
                }
            }
            return blocks;
        }

        private static bool CheckForClashes(IEnumerable<CustomBlock> blocks, CustomBlock block)
        {
            if (blocks.Any(b => b.ID == block.ID))
            {
                return true;
            }

            return block.ID <= 84 || block.ID == 86 || block.ID == 103 ||
                   block.ID == 104 || block.ID == 119 || block.ID == 120 ||
                   block.ID == 135 || block.ID == 136 || block.ID == 148 ||
                   block.ID == 149 || block.ID == 164 || block.ID == 165 ||
                   (block.ID < 250 && block.ID > 239);
        }

        public static void InitTestBlock(Player p)
        {
            CustomBlock block = new CustomBlock
            {
                Name = "TestingBlock",
                ID = 233,
                Solidity = CustomBlockSolidity.Solid,
                MovementSpeed = 2,
                Texture = new CustomBlockTexture
                {
                    SideID = 1,
                    BottomID = 5,
                    TopID = 1
                },
                TransmitsLight = false,
                WalkSound = CustomBlocks.WalkSound.Stone,
                FullBright = true,
                Shape = 16,
                FogDensity = 0,
                FogB = 255,
                FogR = 255,
                FogG = 255
            };
            p.Message("Initing custom block " + block.Name);
            Packet pcket = PacketWriter.MakeDefineBlock(block);
            p.Send(pcket);
            var writer = File.CreateText("Test.gcblock");
            writer.Write(JsonConvert.SerializeObject(block, Formatting.Indented));
            writer.Flush();
            writer.Close();
        }
        /// <summary>
        /// Short, unique, player-friendly name for the block
        /// </summary>
        public string Name;
        /// <summary>
        /// Between 0 and 255
        /// </summary>
        public byte ID;
        /// <summary>
        /// Specified collision mode for this block type
        /// </summary>
        public CustomBlockSolidity Solidity;
        /// <summary>
        /// Player movement speed modifier, defined relative to regular
        /// walk speed.
        /// </summary>
        public byte MovementSpeed;
        /// <summary>
        /// The texture(s) of the block
        /// </summary>
        public CustomBlockTexture Texture;
        /// <summary>
        /// Whether this block allows the sunlight to go through, for level
        /// lighting purposes
        /// </summary>
        public bool TransmitsLight;
        /// <summary>
        /// A sound the client may play when player is walking or swimmming
        /// on a block
        /// </summary>
        public WalkSound WalkSound;
        /// <summary>
        /// Whether or not the block/liquid is affected by shadows (such as lava
        /// </summary>
        public bool FullBright;
        /// <summary>
        /// Shape of the block model
        /// Sprite = 0
        /// Cube with height = 1-16
        /// </summary>
        public byte Shape;
        public BlockDraw BlockDraw;
        /// <summary>
        /// Desnity of fog while client's camera is inside the block.
        /// Value of 0 means do not change fog - level's default settings are used
        /// </summary>
        public byte FogDensity;
        /// <summary>
        /// Red component of fog. Only applies if FogDensity is above 0.
        /// </summary>
        public byte FogR;
        /// <summary>
        /// Green component of fog. Only applies if FogDensity is above 0.
        /// </summary>
        public byte FogG;
        /// <summary>
        /// Blue component of fog. Only applies if FogDensity is above 0.
        /// </summary>
        public byte FogB;
    }

    public class CustomBlockException : Exception
    {
        public CustomBlock Block;
        public CustomBlockException(string message, CustomBlock block) : base(message)
        {
            Block = block;
        }

        public CustomBlockException(string message, Exception inner, CustomBlock block) : base(message, inner)
        {
            Block = block;
        }

        public CustomBlockException(string message) : base(message)
        {
        }

        public CustomBlockException(string message, Exception inner) : base(message, inner)
        {
        }

        public override string ToString()
        {
            return Block == null ? base.ToString() : base.ToString() + " " + Block.Name;
        }
    }
}
