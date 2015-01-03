// InstalledPluginManager.cs in bukkitgui2/bukkitgui2
// Created 2014/07/13
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using MetroFramework;
using Net.Bertware.Bukkitgui2.Core.FileLocation;
using Net.Bertware.Bukkitgui2.Core.Logging;
using Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler;

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
			Thread t = new Thread(CreateDetailledList)
			{
				Name = "InstalledPluginManager_LoadAsync",
				IsBackground = true,
				Priority = ThreadPriority.BelowNormal
			};
			t.SetApartmentState(ApartmentState.MTA);
			t.Start();
		}

		public static void RefreshAllInstalledPluginsAsync()
		{
			Thread t = new Thread(LoadPlugins) {Name = "InstalledPluginManager_LoadAsync", IsBackground = true};
			t.SetApartmentState(ApartmentState.MTA);
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
			FileInfo[] pluginfiles = new DirectoryInfo(Fl.SafeLocation(RequestFile.Plugindir)).GetFiles();

			//create dictionary
			Plugins = new Dictionary<string, InstalledPlugin>();

			if (pluginfiles.Length < 1)
			{
				Logger.Log(LogLevel.Warning, "pluginmanager", "Cancelled simple list creation: no Plugins");
				//no Plugins, nothing to do here
				return;
			}


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

				foreach (KeyValuePair<string, InstalledPlugin> pair in Plugins)
				{
					string pluginname = pair.Key;
					InstalledPlugin value = pair.Value;
					try
					{
						Logger.Log(LogLevel.Info, "InstalledPlugins",
							"Loading plugin " + (i + 1) + " of " + Plugins.Count + " : " + pluginname);
						InstalledPlugin plugin = new InstalledPlugin().ParseAllFields(value.Path);

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

		public static void RemovePlugin(string filename)
		{
			if (string.IsNullOrEmpty(filename)) return;
			if (!ProcessHandler.RequestServerStop())
			{
				MetroMessageBox.Show(Application.OpenForms[0], "The server needs to be stopped to perform the operation. The server was not stopped succesfully.", "Plugin removal cancelled",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (Plugins.ContainsKey(filename))
			{
				Plugins[filename].Remove();
			}
			else
			{
				try
				{
					File.Delete(Fl.Location(RequestFile.Plugindir) + "/" + filename);
				}
				catch (Exception exception)
				{
					Logger.Log(LogLevel.Warning, "InstalledPluginManager", "Failed to remove plugin", exception.Message);
					MetroMessageBox.Show(Application.OpenForms[0], "Plugin removal failed", "Plugin removal failed",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					RefreshAllInstalledPluginsAsync();
					return;
				}
			}
			MetroMessageBox.Show(Application.OpenForms[0], filename + " was removed succesfully", "Plugin removed",MessageBoxButtons.OK, MessageBoxIcon.Information);
			RefreshAllInstalledPluginsAsync();
		}
	}
}