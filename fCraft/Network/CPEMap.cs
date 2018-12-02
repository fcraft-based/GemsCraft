using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fCraft.Worlds
{
    public sealed partial class Map
    {
        public const Block MaxCustomBlockType = Block.StoneBrick;
        public readonly static Block[] FallbackBlocks = new Block[256];

        //fallback for all blocks, blocks 49 (obsidian) and under (non cpe blocks) fallback to themselves
        public static void DefineFallbackBlocks()
        {
            for (int i = 0; i <= (int)Block.Obsidian; i++)
            {
                FallbackBlocks[i] = (Block)i;
            }
            FallbackBlocks[(int)Block.CobbleSlab] = Block.Stair;
            FallbackBlocks[(int)Block.Rope] = Block.BrownMushroom;
            FallbackBlocks[(int)Block.Sandstone] = Block.Sand;
            FallbackBlocks[(int)Block.Snow] = Block.Air;
            FallbackBlocks[(int)Block.Fire] = Block.Lava;
            FallbackBlocks[(int)Block.LightPink] = Block.Pink;
            FallbackBlocks[(int)Block.DarkGreen] = Block.Green;
            FallbackBlocks[(int)Block.Brown] = Block.Dirt;
            FallbackBlocks[(int)Block.DarkBlue] = Block.Blue;
            FallbackBlocks[(int)Block.Turquoise] = Block.Cyan;
            FallbackBlocks[(int)Block.Ice] = Block.Glass;
            FallbackBlocks[(int)Block.Tile] = Block.Iron;
            FallbackBlocks[(int)Block.Magma] = Block.Obsidian;
            FallbackBlocks[(int)Block.Pillar] = Block.White;
            FallbackBlocks[(int)Block.Crate] = Block.Wood;
            FallbackBlocks[(int)Block.StoneBrick] = Block.Stone;
        }


        public static Block GetFallbackBlock(Block block)
        {
            return FallbackBlocks[(int)block];
        }

        public const Block MaxLegalBlockType = Block.Obsidian;
        public unsafe byte[] GetFallbackMap()
        {
            byte[] translatedBlocks = (byte[])Blocks.Clone();
            int volume = translatedBlocks.Length;
            fixed (byte* ptr = translatedBlocks)
            {
                for (int i = 0; i < volume; i++)
                {
                    byte block = ptr[i];
                    if (block > (byte)MaxLegalBlockType)
                    {
                        ptr[i] = (byte)FallbackBlocks[block];
                    }
                }
            }
            return translatedBlocks;
        }
    }
}
