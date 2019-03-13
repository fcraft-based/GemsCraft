using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using GemsCraft.Players;
using GemsCraft.Utils;
using GemsCraft.Worlds;

namespace WritePlugin
{
    public class FontHandler
    {
        public static List<bool>[] chars = new List<bool>[94];
        public List<Block> last = new List<Block>();
        public const int spacebar = 4;
        public Player player;
        public int blockCount;
        public static World world;
        public Vector3I[] marks;

        public FontHandler(Block textColor, Vector3I[] Marks, World world_, Player p)
        {
            this.blockCount = 0;
            FontHandler.world = world_;
            this.marks = Marks;
            this.player = p;
            FontHandler.PixelPos.X = (int)this.marks[0].X;
            FontHandler.PixelPos.Y = (int)this.marks[0].Y;
            FontHandler.PixelPos.Z = (int)this.marks[0].Z;
            FontHandler.PixelPos.pixel = textColor;
            FontHandler.PixelPos.space = (Block)0;
        }

        public static void Init(string image)
        {
            List<List<bool>> boolListList = new List<List<bool>>();
            Bitmap bitmap = new Bitmap(image);
            for (int x = 0; x < bitmap.Width; ++x)
            {
                boolListList.Add(new List<bool>());
                for (int y = 0; y < bitmap.Height; ++y)
                    boolListList[x].Add((double)bitmap.GetPixel(x, y).GetBrightness() > 0.5);
            }
            for (int index1 = 33; index1 < 126; ++index1)
            {
                List<bool> boolList = new List<bool>();
                bool flag1 = true;
                int num1 = (index1 - 32) % 16 * 8;
                int num2 = (index1 - 32) / 16 * 8;
                for (int index2 = 7; index2 >= 0; --index2)
                {
                    for (int index3 = 0; index3 < 8; ++index3)
                    {
                        bool flag2 = boolListList[index2 + num1][index3 + num2];
                        if (flag1)
                        {
                            if (flag2)
                            {
                                index3 = -1;
                                flag1 = false;
                            }
                        }
                        else
                            boolList.Add(flag2);
                    }
                }
                boolList.Reverse();
                FontHandler.chars[index1 - 32] = boolList;
            }
            FontHandler.chars[0] = new List<bool>();
            for (int index = 0; index < 16; ++index)
                FontHandler.chars[0].Add(false);
        }

        public void Render(string text)
        {
            List<Block> blockList = new List<Block>();
            for (int index1 = 0; index1 < text.Length; ++index1)
            {
                char ch = text[index1];
                List<bool> boolList = FontHandler.chars[(int)ch - 32];
                for (int index2 = 0; index2 < boolList.Count; ++index2)
                {
                    if (boolList[index2])
                        blockList.Add(FontHandler.PixelPos.pixel);
                    else
                        blockList.Add(FontHandler.PixelPos.space);
                }
                if (index1 != text.Length - 1)
                {
                    for (int index2 = 0; index2 < 8; ++index2)
                        blockList.Add(FontHandler.PixelPos.space);
                }
            }
            for (int index = 0; index < blockList.Count; ++index)
            {
                if (index >= this.last.Count || this.last[index] != blockList[index] || this.getMapNextBlock(index) != blockList[index])
                    this.blockUpdate(index, blockList[index]);
            }
            this.last = blockList;
        }

        public void Render(string text, Block t)
        {
            Block pixel = FontHandler.PixelPos.pixel;
            FontHandler.PixelPos.pixel = t;
            this.Render(text);
            FontHandler.PixelPos.pixel = pixel;
        }

        public void blockUpdate(int index, Block type)
        {
            short num1;
            short num2;
            short num3;
            if (Math.Abs((int)(this.marks[1].X - this.marks[0].X)) > Math.Abs((int)(this.marks[1].Y - this.marks[0].Y)))
            {
                if (this.marks[0].X < this.marks[1].X)
                {
                    num1 = (short)(FontHandler.PixelPos.X + index / 8);
                    num2 = (short)FontHandler.PixelPos.Y;
                    num3 = (short)(FontHandler.PixelPos.Z + index % 8);
                }
                else
                {
                    num1 = (short)(FontHandler.PixelPos.X - index / 8);
                    num2 = (short)FontHandler.PixelPos.Y;
                    num3 = (short)(FontHandler.PixelPos.Z + index % 8);
                }
            }
            else
            {
                if (Math.Abs((int)(this.marks[1].X - this.marks[0].X)) >= Math.Abs((int)(this.marks[1].Y - this.marks[0].Y)))
                    return;
                if (this.marks[0].Y < this.marks[1].Y)
                {
                    num1 = (short)FontHandler.PixelPos.X;
                    num2 = (short)(FontHandler.PixelPos.Y + index / 8);
                    num3 = (short)(FontHandler.PixelPos.Z + index % 8);
                }
                else
                {
                    num1 = (short)FontHandler.PixelPos.X;
                    num2 = (short)(FontHandler.PixelPos.Y - index / 8);
                    num3 = (short)(FontHandler.PixelPos.Z + index % 8);
                }
            }
            if (type == 0)
                return;
            FontHandler.world.Map.QueueUpdate(new BlockUpdate((Player)null, num1, num2, (short)((int)num3 - 1), type));
            ++this.blockCount;
        }

        public Block getMapNextBlock(int index)
        {
            return FontHandler.world.Map.GetBlock(FontHandler.PixelPos.X + index / 8, FontHandler.PixelPos.Y, FontHandler.PixelPos.Z + index % 8);
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct PixelPos
        {
            public static int X;
            public static int Y;
            public static int Z;
            public static Block pixel;
            public static Block space;
        }
    }
}
