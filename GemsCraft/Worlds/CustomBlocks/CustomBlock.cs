using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
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
                    int x = new Random().Next();
                    string dir = $"Custom Blocks/Temp{x}/";
                    if (!Unzip(file, x, out Exception ex)) throw new CustomBlockException("Failure to load gcblock", ex);
                    string tempOTemp = $"{dir}block.json";
                    if (!File.Exists(tempOTemp))
                        throw new CustomBlockException($"Malformed custom block file: {file}. JSON file does not exist.");

                    CustomBlock block = JsonConvert.DeserializeObject<CustomBlock>(File.ReadAllText(tempOTemp));
                    string bottomTexture = dir + block.Texture.BottomFilePath;
                    string sideTexture = dir + block.Texture.SideFilePath;
                    string topTexture = dir + block.Texture.TopFilePath;

                    if (!File.Exists(bottomTexture) || !File.Exists(sideTexture) || !File.Exists(topTexture))
                    {
                        throw new CustomBlockException(
                            $"Malformed custom block file: {file}. One ore more textures are missing.");
                    }
                    // Ensures there are not block ID clashes
                    if (CheckForClashes(blocks, block)) throw new CustomBlockException("Block with same id already exists", block);
                    // Loads the block texture images
                    Image bottomImg = Image.FromFile(bottomTexture);
                    Image sideImg = Image.FromFile(sideTexture);
                    Image topImg = Image.FromFile(topTexture);
                    
                    List<Image> imagesNeeded = new List<Image>();
                    int whichOne = -1;

                    // Compares images, chcks to see if they are the same
                    if (CompareImg(bottomImg, sideImg) && CompareImg(bottomImg, topImg))
                    {
                        imagesNeeded.Add(bottomImg);
                        whichOne = 4;
                    }
                    else if (CompareImg(bottomImg, sideImg))
                    {
                        imagesNeeded.Add(bottomImg);
                        imagesNeeded.Add(topImg);
                        whichOne = 0;
                    }
                    else if (CompareImg(sideImg, topImg))
                    {
                        imagesNeeded.Add(sideImg);
                        imagesNeeded.Add(bottomImg);
                        whichOne = 1;
                    }
                    else if (CompareImg(bottomImg, topImg))
                    {
                        imagesNeeded.Add(bottomImg);
                        imagesNeeded.Add(sideImg);
                        whichOne = 2;
                    }
                    else // All images are different
                    {
                        imagesNeeded.Add(bottomImg);
                        imagesNeeded.Add(sideImg);
                        imagesNeeded.Add(topImg);
                        whichOne = 3;
                    }

                    List<ImageGeneratorData> data = (from img in imagesNeeded
                        let spot = DetermineNextInt()
                        select new ImageGeneratorData
                        {
                            Spot = spot, Image = img
                        }).ToList();

                    switch (whichOne) // Sets terrain.png ID's of textures based on which images are the same and which are not
                    {
                        case 0: // Cases 0 through 2 only 2 of the images are the same
                            block.Texture.BottomID = (byte) data[0].Spot;
                            block.Texture.SideID = (byte) data[0].Spot;
                            block.Texture.TopID = (byte) data[1].Spot;
                            break;
                        case 1:
                            block.Texture.BottomID = (byte)data[1].Spot;
                            block.Texture.SideID = (byte)data[0].Spot;
                            block.Texture.TopID = (byte)data[0].Spot;
                            break;
                        case 2:
                            block.Texture.BottomID = (byte)data[0].Spot;
                            block.Texture.SideID = (byte)data[1].Spot;
                            block.Texture.TopID = (byte)data[0].Spot;
                            break;
                        case 3: // This case all images are different
                            block.Texture.BottomID = (byte)data[0].Spot;
                            block.Texture.SideID = (byte)data[1].Spot;
                            block.Texture.TopID = (byte)data[2].Spot;
                            break;
                        case 4: // This case all images are the same
                            block.Texture.BottomID = (byte)data[0].Spot;
                            block.Texture.SideID = (byte)data[0].Spot;
                            block.Texture.TopID = (byte)data[0].Spot;
                            break;
                    }
                    
                    TerrainGenerator.Generate(data); // Saves to output_terrain.png
                    Server.TexturePack.Terrain = Image.FromFile(TerrainGenerator.Output);
                    if (!Server.TexturePack.Upload(out Exception e)) // Sends to GemsCraft server and sends url to classicube
                    {
                        throw new CustomBlockException("Unable to upload texture pack with custom blocks added", e);
                    }

                    blocks.Add(block);
                }
                catch (JsonReaderException e)
                {
                    Logger.Log(LogType.Error, $"Malformed custom block file: {file}.");
                    Console.WriteLine(e);
                }
            }
            return blocks;
        }
        
        private static bool CompareImg(Image img1, Image img2)
        {
            bool equals = true;
            Rectangle rect = new Rectangle(0, 0, img1.Width, img1.Height);
            Bitmap bmp1 = (Bitmap) img1;
            Bitmap bmp2 = (Bitmap) img2;
            BitmapData bmpData1 = bmp1.LockBits(rect, ImageLockMode.ReadOnly, bmp1.PixelFormat);
            BitmapData bmpData2 = bmp2.LockBits(rect, ImageLockMode.ReadOnly, bmp2.PixelFormat);
            unsafe
            {
                byte* ptr1 = (byte*)bmpData1.Scan0.ToPointer();
                byte* ptr2 = (byte*)bmpData2.Scan0.ToPointer();
                int width = rect.Width * 3; // for 24bpp pixel data
                for (int y = 0; equals && y < rect.Height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (*ptr1 != *ptr2)
                        {
                            equals = false;
                            break;
                        }
                        ptr1++;
                        ptr2++;
                    }
                    ptr1 += bmpData1.Stride - width;
                    ptr2 += bmpData2.Stride - width;
                }
            }
            bmp1.UnlockBits(bmpData1);
            bmp2.UnlockBits(bmpData2);
            return equals;
        }
        /// <summary>
        /// Determines next spot on Terrain map that the software will render
        /// </summary>
        /// <returns></returns>
        private static int DetermineNextInt()
        {
            int lastInt = 0;
            if (!spotsTaken.Any()) return 85;
            lastInt = spotsTaken.Last();
            int selected = -1;
            if (lastInt == 85) selected = 87;
            if (lastInt > 86 && lastInt < 239) selected = lastInt + 1;
            if (lastInt == 239) selected = 250;
            selected = lastInt + 1;
            spotsTaken.Add(selected);
            return selected;
        }
        private static List<int> spotsTaken = new List<int>();
        private static bool Unzip(string file, int rnd, out Exception ex)
        {
            try
            {
                string dir = $"Custom Blocks/Temp{rnd}/";
                if (Directory.Exists(dir)) Directory.Delete(dir);
                ZipFile.ExtractToDirectory(file, $"Custom Blocks/Temp{rnd}/");
                ex = null;
                return true;
            }
            catch (Exception e)
            {
                ex = e;
                return false;
            }
        }
        private static bool CheckForClashes(IEnumerable<CustomBlock> blocks, CustomBlock block)
        {
            if (blocks.Any(b => b.ID == block.ID))
            {
                return true;
            }

            return block.ID <= 84 || block.ID == 86 || (block.ID >= 240 && block.ID <=249);
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

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
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
