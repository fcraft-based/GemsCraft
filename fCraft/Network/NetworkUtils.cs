using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using GemsCraft.fSystem;

namespace GemsCraft.Network
{
    public class NetworkUtils
    {
        public static bool SendGet(string url, out string response, params string[] args)
        {
            string finalUrl = url;
            if (args.Length > 0) finalUrl += PreparePostData(args);
            HttpWebRequest webRequest = (HttpWebRequest) WebRequest.Create(finalUrl);
            webRequest.Method = "Get";
            webRequest.ContentLength = 0;
            webRequest.ContentType = "application/x-www-form-urlencoded";
            using (HttpWebResponse response1 = webRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response1.GetResponseStream());
                response = reader.ReadToEnd();
                return true;
            }
        }
         
        public static bool SendGet(string url, List<string[]> headers, out string response, params string[] args)
        {
            string finalUrl = url;
            if (args.Length > 0) finalUrl += PreparePostData(args);
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(finalUrl);
            webRequest.Method = "Get";
            webRequest.ContentLength = 0;
            foreach (string[] header in headers)
            {
                webRequest.Headers.Add(header[0], header[1]);
            }
            webRequest.ContentType = "application/x-www-form-urlencoded";
            using (HttpWebResponse response1 = webRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response1.GetResponseStream());
                response = reader.ReadToEnd();
                return true;
            }
        }

        public static bool SendPost(string url, out string response, params string[] args)
        {
            string postData = PreparePostData(args);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            Uri target = new Uri(url);
            WebRequest request = WebRequest.Create(target);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            using (var dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }
            
            using (var responseStr = (HttpWebResponse)request.GetResponse())
            {
                StreamReader reader = new StreamReader(responseStr.GetResponseStream());
                response = reader.ReadToEnd();
                return true;
            }
        }

        
        public static string PreparePostData(string[] args)
        {
            string value = "?";
            int last = args.Length - 1;
            for (int y = 0; y <= last; y++)
            {
                string x = Uri.EscapeDataString(args[y]);
                value += y == 0 ? x : "&" + x;
            }

            return value;
        }
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
