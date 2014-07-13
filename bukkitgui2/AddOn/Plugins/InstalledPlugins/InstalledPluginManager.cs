// InstalledPluginManager.cs in bukkitgui2/bukkitgui2
// Created 2014/07/13
// Last edited at 2014/07/13 14:01
// ©Bertware, visit http://bertware.net

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
		public delegate void PluginListEventHandler();

		public static event PluginListEventHandler InstalledPluginListLoadedSimpleList;
		public static event PluginListEventHandler InstalledPluginListLoadedFullList;

		private static void RaiseInstalledPluginListLoadedSimpleList()
		{
			PluginListEventHandler handler = InstalledPluginListLoadedSimpleList;
			if (handler != null) handler.Invoke();
		}

		private static void RaiseInstalledPluginListLoadedFullList()
		{
			PluginListEventHandler handler = InstalledPluginListLoadedFullList;
			if (handler != null) handler.Invoke();
		}

		/// <summary>
		///     List of the currently parsed plugins in a Filename, Installedplugin dictionary
		/// </summary>
		public static Dictionary<string, InstalledPlugin> Plugins;

		public static void Initialize()
		{
			RefreshAllInstalledPluginsAsync();
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
		///     Create a simple list of the plugin in the plugin folder. Fast, but lacks details.
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

			//create dictionary
			Plugins = new Dictionary<string, InstalledPlugin>();

			//load all the Plugins in the dictionary
			foreach (FileInfo pluginfile in pluginfiles)
			{
				try
				{
					if (pluginfile.Extension == ".jar")
						Plugins.Add(pluginfile.Name,
							new InstalledPlugin().ParseSimpleFields(pluginfile.FullName));
				}
				catch (Exception ex)
				{
					if (pluginfile != null)
						Logger.Log(LogLevel.Warning, "InstalledPlugins",
							"Couldn't add plugin to plugin list:" + pluginfile.Name, ex.Message);
					else
						Logger.Log(LogLevel.Warning, "InstalledPlugins", "Couldn't add plugin to plugin list",
							ex.Message);
				}
			}

			//we got the first list now
			RaiseInstalledPluginListLoadedSimpleList();
		}

		/// <summary>
		///     Create a plugin list based upon the plugin.yml files, might take a while. Recommended to run async.
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
				int i = 0;
				//create dictionary
				Dictionary<string, InstalledPlugin> updatedPlugins = new Dictionary<string, InstalledPlugin>();

				foreach (string pluginname in Plugins.Keys)
				{
					try
					{
						Logger.Log(LogLevel.Info, "InstalledPlugins",
							"Loading plugin " + i + 1 + " of " + Plugins.Count + " : " + pluginname);
						InstalledPlugin plugin = new InstalledPlugin().ParseAllFields(pluginname);

// ReSharper disable once AssignNullToNotNullAttribute
						if (plugin != null) updatedPlugins.Add(plugin.FileName, plugin);
						Logger.Log(LogLevel.Info, "InstalledPlugins",
							"Loaded plugin " + (i + 1) + " of " + Plugins.Count + " : " + pluginname);
					}
					catch (Exception ex)
					{
						if (pluginname != null)
							Logger.Log(LogLevel.Warning, "InstalledPlugins", "Plugin not loaded:" + pluginname,
								ex.Message);
						else
							Logger.Log(LogLevel.Warning, "InstalledPlugins", "Plugin not loaded: " + i, ex.Message);
					}
					i++;
				}
				Plugins = updatedPlugins; // move new dictionary to plugins
			}
			catch (Exception ex)
			{
				Logger.Log(LogLevel.Severe, "InstalledPlugins", "Couldn't create detailled list", ex.Message);
			}
			finally
			{
				RaiseInstalledPluginListLoadedFullList();
			}
		}

		/// <summary>
		///     Clear the cache of plugin.yml files
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