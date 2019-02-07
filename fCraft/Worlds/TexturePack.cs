using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GemsCraft.Drawing.DrawOps.RandomMaze;
using GemsCraft.fSystem;
using GemsCraft.Network;
using GemsCraft.Worlds.CustomBlocks;
using Ionic.Zip;
using Path = System.IO.Path;
using ZipFile = Ionic.Zip.ZipFile;

namespace GemsCraft.Worlds
{
    public class TexturePack
    {
        public bool IsTerrainPng;
        public Image Terrain { get; internal set; }

        public const string TerrainFile = "terrain.png";
        private readonly string _baseZip;
        // ReSharper disable once InconsistentNaming
        public string URL { get; private set; }

        public TexturePack(string file)
        {
            IsTerrainPng = Path.GetExtension(file) == ".png";
            try
            {
                if (IsTerrainPng)
                {
                    Terrain = Image.FromFile(file);
                }
                else
                {
                    _baseZip = file;
                    using (ZipFile zip = ZipFile.Read(file))
                    {
                        if (File.Exists(TerrainFile)) File.Delete(TerrainFile);
                        ZipEntry e = zip[TerrainFile];
                        e.Extract(Server.BaseDirectory);
                        Terrain = Image.FromFile(TerrainFile);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Logger.Log(LogType.Error, "Texture pack not found!");
            }
            catch (Exception ex)
            {
                Logger.Log(LogType.Error, "Unable to load texture pack!");
                Logger.Log(LogType.Error, ex.ToString());
            }
        }
        
        public bool Upload(out Exception e)
        {
            try
            {
                string fileToUpload = IsTerrainPng ? TerrainGenerator.Output : _baseZip;
                if (!IsTerrainPng)
                {
                    using (ZipFile zip = new ZipFile(fileToUpload))
                    {
                        zip.RemoveEntry("terrain.png");
                        zip.AddFile(TerrainGenerator.Output);
                        zip.Save();
                    }
                }
                int name = new Random().Next();
                string ext = IsTerrainPng ? ".png" : ".zip";
                URL = $"http://gemz.christplay.x10host.com/textures/{name}{ext}";
                byte[] res = FileUploading.UploadFile(
                    $"http://gemz.christplay.x10host.com/texture.php?new={name}{ext}",
                    fileToUpload);

                e = null;
                return true;
            }
            catch (Exception exception)
            {
                e = exception;
                return false;
            }
        }

    }
}
