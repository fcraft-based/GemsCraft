using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GemsCraft.Configuration;
using GemsCraft.fSystem;
using GemsCraft.Properties;

namespace GemsCraft.Worlds.CustomBlocks
{
    public class ImageGeneratorData
    {
        public Image Image;
        public int Spot;
    }
    /// <summary>
    /// Generates Terrain.png based on Custom Blocks loaded by server
    /// </summary>
    public class TerrainGenerator
    {
        public const string Output = "output_terrain.png";
        public static Point GetPoint(int spot)
        {
            int x = (spot / 16) * 16; // Divided int gives x value
            int y = (spot % 16) * 16; // Modulus int gives y value
            return new Point(x, y);
        }
        /// <summary>
        /// Saves image to output_terrain.png, uploads to GemsCraft webserver
        /// And then can be retrieved from there to be used by the client
        /// </summary>
        public static void Generate(IEnumerable<ImageGeneratorData> data)
        {
            Image baseImage = Config.UsesCustomTexturePack 
                ? Server.TexturePack.Terrain 
                : Resources.terrain;
            using (Graphics g = Graphics.FromImage(baseImage))
            {
                foreach (ImageGeneratorData d in data)
                {
                    Point p = GetPoint(d.Spot);
                    g.DrawImage(d.Image, p);
                }
            }

            baseImage.Save(Output);
        }
    }
}
