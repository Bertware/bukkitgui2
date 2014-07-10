using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Net.Bertware.Bukkitgui2.Core.FileLocation;
using Net.Bertware.Bukkitgui2.Core.Logging;

namespace Net.Bertware.Bukkitgui2.AddOn.Plugins.InstalledPlugins
{
    public static class InstalledPluginManager
    {
        /// <summary>
        /// List of the currently parsed plugins in a Filename, Installedplugin dictionary
        /// </summary>
        public static Dictionary<string, InstalledPlugin> Plugins;

        public static void Initialize()
        {
            LoadPlugins();
        }

        public static void LoadPlugins()
        {
            CreateSimpleList();
            Thread t = new Thread(CreateDetailledList) {Name = "InstalledPluginManager_LoadAsync", IsBackground = true};
            t.Start();
        }

        public static void RefreshAllInstalledPluginsAsync()
        {
            Thread t = new Thread(LoadPlugins) {Name = "InstalledPluginManager_LoadAsync", IsBackground = true};
            t.Start();
        }

        public static void ReloadInstalledPluginFile(string path)
        {
            FileInfo fi = new FileInfo(path);
            Logger.Log(LogLevel.Info, "InstalledPlugins", "updating plugin information:" + path);
            Plugins[fi.Name] = new InstalledPlugin().ParseAllFields(path, false);
            Logger.Log(LogLevel.Info, "InstalledPlugins", "updated plugin information:" + path);
            RefreshAllInstalledPluginsAsync();
        }


        /// <summary>
        /// Create a simple list of the plugin in the plugin folder. Fast, but lacks details.
        /// </summary>
        /// <remarks></remarks>
        private static void CreateSimpleList()
        {
            FileInfo[] pluginfiles = new DirectoryInfo(Fl.Location(RequestFile.Plugindir)).GetFiles();

            if (pluginfiles.Length < 1)
            {
                Logger.Log(LogLevel.Warning, "pluginmanager", "Cancelled simple list creation: no Plugins");
                Plugins = new Dictionary<string, InstalledPlugin>();
                //no Plugins, nothing to do here
                return;
            }
            Plugins = new Dictionary<string, InstalledPlugin>();
            //create dictionary

            //load all the Plugins in the dictionary
            for (UInt16 i = 0; i <= pluginfiles.Length - 1; i++)
            {
                try
                {
                    if (pluginfiles[i].Extension == ".jar")
                        Plugins.Add(pluginfiles[i].Name,
                            new InstalledPlugin().ParseSimpleFields(pluginfiles[i].FullName));
                }
                catch (Exception ex)
                {
                    if (pluginfiles[i] != null)
                        Logger.Log(LogLevel.Warning, "InstalledPlugins",
                            "Couldn't add plugin to plugin list:" + pluginfiles[i].Name, ex.Message);
                    else
                        Logger.Log(LogLevel.Warning, "InstalledPlugins", "Couldn't add plugin to plugin list",
                            ex.Message);
                }
            }

            //we got the first list now
        }

        /// <summary>
        /// Create a plugin list based upon the plugin.yml files, might take a while. Recommended to run async.
        /// </summary>
        /// <remarks></remarks>
        private static void CreateDetailledList()
        {
            Logger.Log(LogLevel.Info, "InstalledPlugins", "Loading full list",
                "Pluginmanager.InstalledPluginmanager.CreateDetailledList()");
            if (Plugins == null || Plugins.Count == 0)
                return;
            try
            {
                Dictionary<string, InstalledPlugin>.KeyCollection.Enumerator e = Plugins.Keys.GetEnumerator();

                for (UInt16 i = 0; i <= Plugins.Values.Count - 1; i++)
                {
                    try
                    {
                        Logger.Log(LogLevel.Info, "InstalledPlugins",
                            "Loading plugin " + i + 1 + " of " + Plugins.Count + " : " + e.Current);
                        InstalledPlugin plugin = new InstalledPlugin().ParseAllFields(e.Current);


// ReSharper disable once AssignNullToNotNullAttribute
                        if (plugin != null) Plugins[e.Current] = plugin;
                        Logger.Log(LogLevel.Info, "InstalledPlugins",
                            "Loaded plugin " + i + 1 + " of " + Plugins.Count + " : " + e.Current);
                    }
                    catch (Exception ex)
                    {
                        if (e.Current != null)
                            Logger.Log(LogLevel.Warning, "InstalledPlugins", "Plugin not loaded:" + e.Current,
                                ex.Message);
                        else
                            Logger.Log(LogLevel.Warning, "InstalledPlugins", "Plugin not loaded: " + i, ex.Message);
                    }
                    finally
                    {
                        e.MoveNext();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Severe, "InstalledPlugins", "Couldn't create detailled list", ex.Message);
            }
        }

        /// <summary>
        /// Clear the cache of plugin.yml files
        /// </summary>
        /// <remarks></remarks>
        //see InstalledPlugin for more cache code
        public static void ClearPluginCache()
        {
            if (Directory.Exists(Fl.Location(RequestFile.Cache) + "/Plugins/"))
                Directory.Delete(Fl.Location(RequestFile.Cache) + "/Plugins/", true);
        }
    }
}