// InstalledPlugin.cs in bukkitgui2/bukkitgui2
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
using Net.Bertware.Bukkitgui2.AddOn.Plugins.Bukget.api3;
using Net.Bertware.Bukkitgui2.Core.FileLocation;
using Net.Bertware.Bukkitgui2.Core.Logging;
using Net.Bertware.Bukkitgui2.Core.Util;
using Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler;
using Yaml.Grammar;

namespace Net.Bertware.Bukkitgui2.AddOn.Plugins.InstalledPlugins
{
	public class InstalledPlugin
	{
		public Boolean OnlySimpleFields { get; private set; }

		/// <summary>
		///     The name of the plugin
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		///     The description of the plugin
		/// </summary>
		public string Description { get; private set; }

		/// <summary>
		///     The authors of the plugin
		/// </summary>
		public string[] Authors { get; private set; }

		/// <summary>
		///     The mainspace of the plugin
		/// </summary>
		public string Mainspace { get; private set; }

		/// <summary>
		///     The version of the plugin
		/// </summary>
		public string Version { get; private set; }

		/// <summary>
		///     The creation date of the plugin
		/// </summary>
		public DateTime FileCreationDate { get; private set; }

		/// <summary>
		///     The last write date of the plugin, date it was last edited
		/// </summary>
		public DateTime FileLastWriteDate { get; private set; }

		/// <summary>
		///     The filename of the plugin
		/// </summary>
		public string FileName { get; private set; }

		/// <summary>
		///     The full path of the plugin
		/// </summary>
		public string Path { get; private set; }

		/// <summary>
		///     Commands registered by this plugin
		/// </summary>
		/// <remarks>optional</remarks>
		public List<PluginCommand> Commands;

		/// <summary>
		///     Permissions registered by this pluing
		/// </summary>
		/// <remarks>optional</remarks>
		public List<PluginPermission> Permissions;

		/// <summary>
		///     Soft depends on the following plugins
		/// </summary>
		/// <remarks>optional</remarks>
		public string[] Softdepend;

		/// <summary>
		///     Get the online equivalent for this locally installed plugin
		/// </summary>
		public BukgetPlugin BukgetEquivalentPlugin
		{
			get
			{
				if (BukgetPlugin.LastParsedPlugin.Main.Equals(Mainspace)) return BukgetPlugin.LastParsedPlugin;
				return BukgetPlugin.CreateFromNamespace(Mainspace);
			}
		}

		/// <summary>
		///     Remove (Delete) this plugin
		/// </summary>
		public void Remove()
		{
			if (!ProcessHandler.RequestServerStop()) return;
			File.Delete(Path);
			InstalledPluginManager.RefreshAllInstalledPluginsAsync();
		}

		/// <summary>
		///     Quickly parse the basic fields for a plugin
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public InstalledPlugin ParseSimpleFields(string path)
		{
			OnlySimpleFields = true;
			FileInfo fi = new FileInfo(path);
			FileName = fi.Name;
			Name = FileName.Split('.')[0];
			FileLastWriteDate = fi.LastWriteTime;
			FileCreationDate = fi.CreationTime;
			Path = fi.FullName;
			return this;
		}

		/// <summary>
		///     Parse all info for a plugin, using the plugin.yml field
		/// </summary>
		/// <param name="path">the plugin location</param>
		/// <param name="useCache">is use of cached info allowed?</param>
		/// <returns></returns>
		public InstalledPlugin ParseAllFields(string path, Boolean useCache = true)
		{
			OnlySimpleFields = false;
			ParseSimpleFields(path); // load the simple fields first
			Loadplugin(Path, useCache); // this.path is already loaded in parseSimpleFields
			return this;
		}


		/// <summary>
		///     Loads the plugin.yml file of a .jar plugin
		/// </summary>
		/// <param name="path">the path of the plugin.jar file</param>
		/// <param name="readCache">if this plugin should be read from cache if possible</param>
		/// <returns>The InstalledPlugin (me)</returns>
		/// <remarks></remarks>
		public InstalledPlugin Loadplugin(string path, bool readCache = true)
		{
			try
			{
				// to reduce load times and CPU usage, plugin.yml files are cached
				// location: cache/plugins/plugin_name/plugin.yml

				// Detect reletive locations and prepend thise with the plugin dir

				if (path.Contains(":\\") == false)
					path = Fl.Location(RequestFile.Plugindir) + "\\" + path;

				// get a fileinfo object for the plugin
				FileInfo plugFileInfo = new FileInfo(path);

				// get a fileinfo object for the cache
				FileInfo cacheFileInfo =
					new FileInfo(Fl.Location(RequestFile.Cache) + "/plugins/" + plugFileInfo.Name + "/plugin.yml");

				Logger.Log(LogLevel.Info, "InstalledPlugin",
					"loading plugin (step 1/2): " + plugFileInfo.Name + " - cache allowed:" + readCache);

				//check if the cache exists, if not, create cache (we need this cache file, it will be read later on)
				if (cacheFileInfo.Exists & readCache)
				{
					// cache exists, ok
					Logger.Log(LogLevel.Info, "InstalledPlugin", "Reading plugin data from cache...");
				}
				else
				{
					// cache doesn't exist or is forcefully invalidated by parameter, create

					//safety check
					if (string.IsNullOrEmpty(path) || plugFileInfo.Exists == false)
					{
						return null;
					}

					Logger.Log(LogLevel.Info, "InstalledPlugin",
						"Plugin data not available in cache or cache not allowed. Building cache for plugin...");
					Compression.Decompress(Fl.Location(RequestFile.Temp) + "/plugin", path);

					// check if the plugin.yml file was decompressed
					if (!File.Exists(Fl.Location(RequestFile.Temp) + "/plugin/plugin.yml"))
					{
						return null;
					}

// ReSharper disable once PossibleNullReferenceException
					if (!cacheFileInfo.Directory.Exists) cacheFileInfo.Directory.Create();
					//copy the yml to cache
					File.Copy(Fl.Location(RequestFile.Temp) + "/plugin/plugin.yml", cacheFileInfo.FullName, true);
					if (Directory.Exists(Fl.Location(RequestFile.Temp) + "/plugin"))
						Directory.Delete(Fl.Location(RequestFile.Temp) + "/plugin", true);
				}
				// either way is cache now okay, it already existed or was created just now
				Logger.Log(LogLevel.Info, "InstalledPlugin",
					"loading plugin (step 2/2): " + plugFileInfo.Name + " - cache allowed:" + readCache);

				// load the yml file
				if (File.Exists(cacheFileInfo.FullName))
					Loadymlfile(cacheFileInfo.FullName);

				FileCreationDate = File.GetLastWriteTime(path);
				FileName = new FileInfo(path).Name;

				if (Name == null || string.IsNullOrEmpty(Name) && FileName.Contains("."))
					Name = FileName.Split('.')[0];
				//if name couldn't be read from yml, parse FileName

				Logger.Log(LogLevel.Info, "InstalledPlugin",
					"loaded plugin: " + plugFileInfo.Name + " - cache allowed:" + readCache);

				return this;
				//return this item
			}
			catch (Exception ex)
			{
				Logger.Log(LogLevel.Warning, "InstalledPlugin", "An exception occured when trying to load plugin",
					ex.Message);
				return null;
			}
		}

		/// <summary>
		///     Loads the contents of a plugin.yml file
		/// </summary>
		/// <param name="path">the path of the plugin.yml file</param>
		/// <returns>The InstalledPlugin (me)</returns>
		/// <remarks></remarks>
		public InstalledPlugin Loadymlfile(string path)
		{
			try
			{
				if (path == null || string.IsNullOrEmpty(path) || !File.Exists(path)) return null;

				using (StreamReader sr = new StreamReader(path))
				{
					string content = sr.ReadToEnd();
					LoadPluginYml(content);
				}
				return this;
			}
			catch (Exception ex)
			{
				Logger.Log(LogLevel.Severe, "InstalledPlugin", "An exception occured when trying to load yml file",
					ex.Message);
				return null;
			}
		}

		/// <summary>
		///     Loads the contents of a plugin.yml file
		/// </summary>
		/// <param name="ymltext">the yml formatted text</param>
		/// <returns>The InstalledPlugin (me)</returns>
		/// <remarks></remarks>
		public InstalledPlugin LoadPluginYml(string ymltext)
		{
			try
			{
				Scalar sc = new Scalar();
				Sequence seq = new Sequence();
				Mapping map = new Mapping();

				//References to check file types later on
				Type typeScalar = sc.GetType();
				Type typeSequence = seq.GetType();
				Type typeMapping = map.GetType();


				if (ymltext == null | string.IsNullOrEmpty(ymltext))
				{
					return null;
				}

				YamlStream yml = YamlParser.Load(ymltext);

				if (yml == null)
				{
					return null;
				}

				//if mapping start parsing
				if (yml.Documents[0].Root.GetType() == typeMapping)
				{
					foreach (MappingEntry item in ((Mapping) yml.Documents[0].Root).Enties)
					{
						//Check the type, check for possible keys and load the value
						if (item.Value.GetType() == typeScalar)
						{
							switch (((Scalar) item.Key).Text)
							{
								case "name":
									Name = ((Scalar) item.Value).Text;
									break;
								case "version":
									Version = ((Scalar) item.Value).Text;
									break;
								case "description":
									Description = ((Scalar) item.Value).Text;
									break;
								case "main":
									Mainspace = ((Scalar) item.Value).Text;
									break;
								case "author":
									Authors = new string[1];
									Authors[0] = ((Scalar) item.Value).Text;
									break;
								case "authors":
									Authors = new string[1];
									Authors[0] = ((Scalar) item.Value).Text;
									break;
							}
						}
						else if (item.Value.GetType() == typeSequence)
						{
							switch (((Scalar) item.Key).Text)
							{
								case "author":
									Authors = ArrayFromSequence((Sequence) item.Value);
									break;
								case "Authors":
									Authors = ArrayFromSequence((Sequence) item.Value);
									break;
								case "softdepend":
									Softdepend = ArrayFromSequence((Sequence) item.Value);
									break;
							}
						}
						else if (item.Value.GetType() == typeMapping)
						{
							switch (((Scalar) item.Key).Text)
							{
								case "commands":
									if (item.Value.GetType() == typeMapping)
										Commands = ParseCommands((Mapping) item.Value);
									else
										Commands = new List<PluginCommand>();
									break;
								case "permissions":
									if (item.Value.GetType() == typeMapping)
										Permissions = ParsePermissions((Mapping) item.Value);
									else
										Permissions = new List<PluginPermission>();
									break;
							}
						}
					}
				}
				return this;
			}
			catch (Exception ex)
			{
				Logger.Log(LogLevel.Warning, "InstalledPlugin", "An exception occured when trying to parse yml text",
					ex.Message);
				return null;
			}
		}

		/// <summary>
		///     Change nothing values to either empty lists or empty strings
		/// </summary>
		/// <returns></returns>
		/// <remarks></remarks>
		public InstalledPlugin ToSafeObject()
		{
			if (Name == null)
				Name = "";
			if (Version == null)
				Version = "";
			if (Authors == null)
			{
				Authors = new string[1];
				Authors[0] = "";
			}
			if (Description == null)
				Description = "";
			if (Mainspace == null)
				Mainspace = "";
			if (Commands == null)
				Commands = new List<PluginCommand>();
			if (Permissions == null)
				Permissions = new List<PluginPermission>();
			if (Softdepend == null)
			{
				Softdepend = new string[1];
				Softdepend[0] = "";
			}
			if (FileName == null)
				FileName = "";
			return this;
		}

		/// <summary>
		///     Parse commands from plugin.yml
		/// </summary>
		/// <param name="map"></param>
		/// <returns></returns>
		/// <remarks></remarks>
		private static List<PluginCommand> ParseCommands(Mapping map)
		{
			try
			{
				List<PluginCommand> l = new List<PluginCommand>();

				Scalar sc = new Scalar();
				Sequence seq = new Sequence();
				Type typeScalar = sc.GetType();
				Type typeSequence = seq.GetType();
				Type typeMapping = map.GetType();
				if (map.GetType() != typeMapping) return l;

				foreach (MappingEntry entry in map.Enties)
				{
					PluginCommand pc = new PluginCommand {Name = ((Scalar) entry.Key).Text};

					if (entry.Value.GetType() == typeMapping)
					{
						foreach (MappingEntry secondlevel in ((Mapping) entry.Value).Enties)
						{
							if (secondlevel.Key.GetType() != typeScalar) continue;
							switch (((Scalar) secondlevel.Key).Text)
							{
								case "description":
									pc.Description = ((Scalar) secondlevel.Value).Text;
									break;
								case "usage":
									pc.Usage = ((Scalar) secondlevel.Value).Text;
									break;
								case "alias":
									if (entry.Value.GetType() == typeSequence)
									{
										pc.Aliases = ArrayFromSequence((Sequence) secondlevel.Value);
									}
									else if (entry.Value.GetType() == typeScalar)
									{
										pc.Aliases = new string[1];
										// ReSharper disable once PossibleInvalidCastException
										pc.Aliases[0] = ((Scalar) entry.Value).Text;
									}
									break;
								case "aliases":
									if (entry.Value.GetType() == typeSequence)
									{
										pc.Aliases = ArrayFromSequence((Sequence) secondlevel.Value);
									}
									else if (entry.Value.GetType() == typeScalar)
									{
										pc.Aliases = new string[1];
// ReSharper disable once PossibleInvalidCastException
										pc.Aliases[0] = ((Scalar) entry.Value).Text;
									}
									break;
							}
						}
					}

					l.Add(pc);
				}
				return l;
			}
			catch (Exception ex)
			{
				Logger.Log(LogLevel.Warning, "InstalledPlugin",
					"An exception occured when trying to load plugin commands", ex.Message);
				return new List<PluginCommand>();
			}
		}

		/// <summary>
		///     Parse permissions from plugin.yml
		/// </summary>
		/// <param name="map"></param>
		/// <returns></returns>
		/// <remarks></remarks>
		private List<PluginPermission> ParsePermissions(Mapping map)
		{
			try
			{
				List<PluginPermission> l = new List<PluginPermission>();

				Scalar sc = new Scalar();
				Type typeScalar = sc.GetType();
				Type typeMapping = map.GetType();
				if (map.GetType() != typeMapping) return l;
				foreach (MappingEntry entry in map.Enties)
				{
					PluginPermission pp = new PluginPermission {Name = ((Scalar) entry.Key).Text};
					if (entry.Value.GetType() != typeMapping) continue;
					foreach (MappingEntry secondlevel in ((Mapping) entry.Value).Enties)
					{
						if (secondlevel.Key.GetType() != typeScalar) continue;
						switch (((Scalar) secondlevel.Key).Text)
						{
							case "description":
								pp.Description = ((Scalar) secondlevel.Value).Text;
								break;
							case "default":

								break;
							case "children":
								pp.Children = new List<PluginPermissionChild>();
								foreach (MappingEntry thirdlevel in ((Mapping) secondlevel.Value).Enties)
								{
									PluginPermissionChild ppc = new PluginPermissionChild
									{
										Name = ((Scalar) thirdlevel.Key).Text
									};
									pp.Children.Add(ppc);
								}

								break;
						}
					}
					l.Add(pp);
				}
				return l;
			}
			catch (Exception ex)
			{
				Logger.Log(LogLevel.Warning, "InstalledPlugin",
					"An exception occured when trying to load plugin permissions", ex.Message);
				return new List<PluginPermission>();
			}
		}

		/// <summary>
		///     Convert a sequence to an array
		/// </summary>
		/// <param name="seq"></param>
		/// <returns></returns>
		/// <remarks></remarks>
		private static string[] ArrayFromSequence(Sequence seq)
		{
			try
			{
				Scalar sc = new Scalar();
				Type typeScalar = sc.GetType();
				string[] arr = new string[seq.Enties.Count];
				for (int i = 0; i <= seq.Enties.Count - 1; i++)
				{
					if (seq.Enties[i].GetType() == typeScalar)
					{
						arr[i] = (((Scalar) seq.Enties[i]).Text);
					}
				}
				return arr;
			}
			catch (Exception ex)
			{
				Logger.Log(LogLevel.Severe, "InstalledPlugin",
					"An exception occured when trying to convert array to sequence", ex.Message);
				return new string[1];
			}
		}
	}

	public class PluginCommand
	{
		public string Name;
		public string Description;
		public string Usage;
		public string[] Aliases;
	}

	public class PluginPermission
	{
		public enum Defaultmode
		{
			Yes,
			Op,
			No
		}

		public string Name;
		public string Description;
		public Defaultmode DefaultypePerm;
		public List<PluginPermissionChild> Children;
	}

	public class PluginPermissionChild
	{
		public string Name;
		public PluginPermission.Defaultmode DefaulTypePerm;
	}
}