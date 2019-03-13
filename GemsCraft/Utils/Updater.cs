// Copyright 2009-2012 Matvei Stefarov <me@matvei.org>

using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using GemsCraft.fSystem;
using GemsCraft.Network;

namespace GemsCraft.Utils
{
    public enum VersionResult
    {
        Outdated, Current, Developer
    }
    /// <summary> Checks for updates, and keeps track of current version/revision. </summary>
    public class Updater {
        public static bool UpdaterDisabled { get; internal set; }
        
        /// <summary>
        /// This installation's version of the software.
        /// </summary>
        public static Version LatestStable = new Version
        {
            Title = "Alpha",
            Major = 0,
            Minor = 3,
            Revision = -1,
            Build = -1,
            ShowTitle = true
        };

        private const string File1 = "GemsCraftUpdater.exe";
        private const string File2 = "Updater.exe";
        public static void CheckUpdaters()
        {
            if (File.Exists(File1))
            {
                if (File.Exists(File2)) File.Delete(File2);
                File.Copy(File1, File2);
                File.Delete(File1);
            }
        }

        private static bool _shown;
        public static VersionResult CheckUpdates(bool isConsole)
        {
            if (UpdaterDisabled)
            {
                if (!_shown) Logger.Log(LogType.Warning, "Updater is disabled. Will not check for updates. Continuing with current version");
                _shown = true;
                return VersionResult.Current;
            }
            else
            {
                try
                {
                    Version currentOnline = Version.ToVersion(
                        NetworkUtils.GetUrlSourceAsList("http://gemz.christplay.x10host.com/current_version.txt"));
                    int versionCompare = Version.Compare(LatestStable, currentOnline);
                    switch (versionCompare)
                    {
                        case -1:
                            return VersionResult.Current;
                        case 0:
                            return VersionResult.Developer;
                        case 1:
                            return VersionResult.Outdated;
                        default:
                            return VersionResult.Current;
                    }
                }
                catch
                {
                    const string message = "Unable to check for updates for GemsCraft. For this session (and maybe more) " +
                                           "you will not be able to update and further update checks will be disabled.";
                    Logger.Log(LogType.Warning, message);
                    if (!isConsole) MessageBox.Show(message);
                    UpdaterDisabled = true;
                    return VersionResult.Current;
                }
            }
        }
    }
    
}

