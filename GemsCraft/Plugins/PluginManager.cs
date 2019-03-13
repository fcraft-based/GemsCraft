//Copyright (C) <2012>  <Jon Baker, Glenn Mariën and Lao Tszy>

//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with this program.  If not, see <http://www.gnu.org/licenses/>.

//Copyright (C) <2012> Glenn Mariën (http://project-vanilla.com)

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using GemsCraft.Configuration;
using GemsCraft.fSystem;
using GemsCraft.Utils;
using Newtonsoft.Json;
using Version = GemsCraft.Utils.Version;

namespace GemsCraft.Plugins
{
    class PluginManager
    {
        private static PluginManager _instance;
        public static List<IPlugin> Plugins = new List<IPlugin>();

        private PluginManager()
        {
            // Empty
        }

        public static PluginManager GetInstance()
        {
            if (!ConfigKey.EnablePlugins.Enabled())
            {
                Logger.Log(LogType.SystemActivity,
                    "Plugin loading is disabled by the config. Plugins will not be loaded.");
                return new PluginManager();
            }
            if (_instance != null) return _instance;
            _instance = new PluginManager();
            _instance.Initialize();

            return _instance;
        }

        private void Initialize()
        {
            try
            {
                if (!Directory.Exists("plugins"))
                {
                    Directory.CreateDirectory("plugins");
                }
            }
            catch (Exception ex)
            {
                Logger.Log(LogType.Error, "PluginManager.Initialize: " + ex);
                return;
            }

            // Load plugins
            string[] plugins = Directory.GetFiles("plugins", "*.dll");
            
            
            if (plugins.Length == 0)
            {
                Logger.Log(LogType.ConsoleOutput, "PluginManager: No plugins found");
            }
            else
            {
                Logger.Log(LogType.ConsoleOutput, "PluginManager: Loading " + plugins.Length + " plugins");

                foreach (string plugin in plugins)
                {
                    try
                    {
                        Type pluginType = null;
                        string args = plugin.Substring(plugin.LastIndexOf("\\") + 1, plugin.IndexOf(".dll") - plugin.LastIndexOf("\\") - 1);
                        string file = Path.GetFullPath(plugin);
                        if (Path.GetExtension(file) != ".dll") continue; // Continue to next file
                        Assembly assembly = Assembly.LoadFile(file);
                        pluginType = assembly.GetType(args + ".Init");
                        if (pluginType == null) continue; // Ignore dll's that are not comptatible, including plugins made for other fCraft forks
                        // Uses a temp variable so we can load the defaults of the plugin later
                        // This prevents the user from modifiying key elements important to the plugin in the config file
                        IPlugin pluginObj = null;
                        IPlugin temp = (IPlugin) Activator.CreateInstance(pluginType);
                        // Checks to make sure the plugin is updated - this is crucial!
                        if (Version.Compare(temp.SoftwareVersion, Updater.LatestStable) != -1)
                        {
                            throw new Exception(
                                $"Plugin {temp.Name} uses an outdated version of GemsCraft. Check with the plugin developer to have it updated.");
                        }
                        // Checks to see if a property file exists for the plugin.
                        string propertyName = $"plugins/{temp.Name}.json";
                        if (!File.Exists(propertyName))
                        {
                            Logger.Log(LogType.Warning,
                                $"Property file does not exist for plugin {temp.Name}. Assuming defaults.");
                        }
                        else
                        {
                            pluginObj = JsonConvert.DeserializeObject<IPlugin>(propertyName);
                        }

                        if (pluginObj == null)
                        {
                            pluginObj = temp;
                        }
                        else
                        {
                            // Reinstates the key items as they should be, in case the user modified them in the config
                            pluginObj.Name = temp.Name;
                            pluginObj.Version = temp.Version;
                            pluginObj.FileName = temp.FileName;
                            pluginObj.Author = temp.Author;
                            pluginObj.ReleaseDate = temp.ReleaseDate;
                        }
                        // Adds the plugin to the list.
                        Plugins.Add(pluginObj);
                    }
                    catch (Exception ex)
                    {
                        Logger.Log(LogType.Error, "PluginManager: Unable to load plugin at location " + plugin + ": " + ex);
                    }
                }

                LoadPlugins();
            }
        }

        private bool secondFail = false;
        private void LoadPlugins()
        {
            if (Plugins.Count > 0)
            {
                int loopCount = 0;
                foreach (IPlugin plugin in Plugins)
                {
                    Logger.Log(LogType.ConsoleOutput, "PluginManager: Loading plugin " + plugin.Name);

                    try
                    {
                        plugin.Initialize();
                    }
                    catch (Exception ex)
                    {
                        Logger.Log(LogType.Error, "PluginManager: Failed loading plugin " + plugin.Name + ": " + ex);
                    }

                    loopCount++;
                }
            }
        }
    }
}
