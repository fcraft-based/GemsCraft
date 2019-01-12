using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GemsCraft.Properties;

namespace GemsCraft.Worlds.CustomBlocks
{
    /// <summary>
    /// Generates Terrain.png based on Custom Blocks loaded by server
    /// </summary>
    public class TerrainGenerator
    {
        /// <summary>
        /// Saves image to output_terrain.png, uploads to GemsCraft webserver
        /// And then can be retrieved from there to be used by the client
        /// </summary>
        public static void Generate()
        {
            Image baseImage = Resources.terrain;
            using (Graphics g = Graphics.FromImage(baseImage))
            {
                string cust = "Custom Blocks/image.png";
                Image im = Image.FromFile(cust);
                g.DrawImage(im, new Point(80, 80));
            }

            baseImage.Save("output_terrain.png");
        }
    }
}
