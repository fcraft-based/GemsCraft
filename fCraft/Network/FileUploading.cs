using System;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace GemsCraft.Network
{
    internal class FileUploading
    {
        public static byte[] UploadFile(string address, string path)
        {
            try
            {
                WebClient client = new WebClient();
                string myFile = path;
                return client.UploadFile(address, "POST", myFile);
            }
            catch (Exception err)
            {
                throw new Exception("Exception in File Uploading", err);
            }
        }
    }
    
}
