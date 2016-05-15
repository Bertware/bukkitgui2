// Bukget.cs in bukkitgui2/bukkitgui2
// Created 2014/05/03
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.Linq;
using Net.Bertware.Bukkitgui2.Core.Util.Web;

namespace Net.Bertware.Bukkitgui2.AddOn.Plugins.Bukget.api3
{
	public static class Bukget
	{
		public delegate void PluginsLoadedEventArgs(Dictionary<String, BukgetPlugin> currentlyLoadedPlugins);

		public static event PluginsLoadedEventArgs NewPluginsLoaded;
		private const int DEFAULT_COUNT = 64000;

		private static void RaiseNewPluginsLoaded()
		{
			PluginsLoadedEventArgs handler = NewPluginsLoaded;
			if (handler != null)
			{
				handler.Invoke(CurrentlyLoadedPlugins);
			}
		}


		private static Dictionary<String, BukgetPlugin> _currentlyLoadedPlugins;

		/// <summary>
		///     Dictionary with currently loaded plugins, key: namespace, value: plugin
		/// </summary>
		public static Dictionary<String, BukgetPlugin> CurrentlyLoadedPlugins
		{
			get
			{
				if (_currentlyLoadedPlugins != null) return _currentlyLoadedPlugins;
				_currentlyLoadedPlugins = GetMostPopularPlugins(20);
				return _currentlyLoadedPlugins;
			}
			private set { _currentlyLoadedPlugins = value; }
		}

		public static Dictionary<String, BukgetPlugin> GetMostPopularPlugins(int amount = DEFAULT_COUNT)
		{
			string url = BukgetUrlBuilder.ConstructUrl(BukgetUrlBuilder.FieldsSimple, PluginInfoField.Pop_Daily, true,
				amount);
			return RetrieveParseStore(url);
		}

		public static Dictionary<String, BukgetPlugin> GetPluginsByCategory(PluginCategory category, int amount = DEFAULT_COUNT)
		{
			string url = BukgetUrlBuilder.ConstructUrl(category, BukgetUrlBuilder.FieldsSimple, amount);
			return RetrieveParseStore(url);
		}

		public static Dictionary<String, BukgetPlugin> SearchPlugins(string searchtext,  int amount = DEFAULT_COUNT)
		{
			string url = BukgetUrlBuilder.ConstructUrl(PluginInfoField.Plugin_Name, SearchAction.Like, searchtext,
				amount);
			return RetrieveParseStore(url);
		}


		public static Dictionary<String, BukgetPlugin> GetPluginsByCategory(string category, int amount = DEFAULT_COUNT )
		{
			PluginCategory cat =
				(PluginCategory) Enum.Parse(typeof (PluginCategory), category.Replace(" ", "_").Replace("-", "__"));
			string url = BukgetUrlBuilder.ConstructUrl(cat, BukgetUrlBuilder.FieldsSimple, amount);
			return RetrieveParseStore(url);
		}

		/// <summary>
		///     Retrieve a list of plugins, parse it, store it in the currentlyLoadedPlugins variable and return it
		/// </summary>
		/// <param name="url"></param>
		/// <returns></returns>
		private static Dictionary<String, BukgetPlugin> RetrieveParseStore(String url)
		{
			string data = WebUtil.RetrieveString(url);
			CurrentlyLoadedPlugins = ListToDictionary(BukgetPlugin.ParsePluginList(data));
			RaiseNewPluginsLoaded();
			return CurrentlyLoadedPlugins;
		}

		/// <summary>
		///     Convert a list to a dictionary
		/// </summary>
		/// <param name="pluginList">List of plugins to convert</param>
		/// <returns></returns>
		public static Dictionary<String, BukgetPlugin> ListToDictionary(List<BukgetPlugin> pluginList)
		{
			Dictionary<string, BukgetPlugin> dictionary = new Dictionary<string, BukgetPlugin>();
			foreach (BukgetPlugin plugin in pluginList)
			{
				if (plugin == null || string.IsNullOrEmpty(plugin.Main)) continue;
				if (!dictionary.ContainsKey(plugin.Main)) dictionary.Add(plugin.Main, plugin);
			}
			return dictionary;
		}

		/// <summary>
		///     Convert a dictionary to a list
		/// </summary>
		/// <param name="pluginDict">List of plugins to convert</param>
		/// <returns></returns>
		public static List<BukgetPlugin> DictionaryToList(Dictionary<String, BukgetPlugin> pluginDict)
		{
			return pluginDict.Values.ToList();
		}
	}
}