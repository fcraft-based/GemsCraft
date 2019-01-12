using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public static Point GetPoint(int spot)
        {
            int x = spot / 16; // Divided int gives x value
            int y = spot % 16; // Modulus int gives y value
            return new Point(x, y);
        }
        /// <summary>
        /// Saves image to output_terrain.png, uploads to GemsCraft webserver
        /// And then can be retrieved from there to be used by the client
        /// </summary>
        public static void Generate(IEnumerable<ImageGeneratorData> data)
        {
            Image baseImage = Resources.terrain;
            using (Graphics g = Graphics.FromImage(baseImage))
            {
                foreach (ImageGeneratorData d in data)
                {
                    g.DrawImage(d.Image, GetPoint(d.Spot));
                }
            }

            baseImage.Save("output_terrain.png");
        }
    }
}
