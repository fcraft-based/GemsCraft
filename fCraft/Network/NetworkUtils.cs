using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GemsCraft.fSystem;

namespace GemsCraft.Network
{
    public class NetworkUtils
    {
        /// <summary>
        /// Obtain source of webpage
        /// </summary>
        /// <param name="urlF">The url needed</param>
        /// <returns>source of page</returns>
        public static List<string> GetUrlSourceAsList(string urlF)
        {
            var temp = "check_file.txt";
            var c = File.CreateText(temp);
            c.Close();
            using (var client = new WebClient())
            {
                try
                {
                    client.DownloadFile(urlF, temp);
                }
                catch (Exception e)
                {
                    Logger.LogToConsole(e.ToString());
                }

            }

            try
            {
                return File.ReadAllLines(temp).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<string>();
            }
            
        }
        /// <summary>
        /// Obtain source of webpage
        /// </summary>
        /// <param name="url">The url needed</param>
        /// <returns>source of page</returns>
        public static string GetUrlSource(string url)
        {
            using (var client = new WebClient())
            {
                var f = client.DownloadString(url);
                return f;
            }
        }
    }
}
