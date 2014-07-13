// Bukget.cs in bukkitgui2/bukkitgui2
// Created 2014/05/03
// Last edited at 2014/07/13 14:01
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.Linq;
using Net.Bertware.Bukkitgui2.Core.Util.Web;

namespace Net.Bertware.Bukkitgui2.AddOn.Plugins.Bukget.api3
{
	public static class Bukget
	{
		/// <summary>
		///     Dictionary with currently loaded plugins, key: namespace, value: plugin
		/// </summary>
		public static Dictionary<String, BukgetPlugin> CurrentlyLoadedPlugins;

		public static Dictionary<String, BukgetPlugin> GetMostPopularPlugins(int amount)
		{
			string url = BukgetUrlBuilder.ConstructUrl(BukgetUrlBuilder.FieldsSimple, PluginInfoField.Pop_Daily, true,
				amount);
			return RetrieveParseStore(url);
		}

		public static Dictionary<String, BukgetPlugin> GetPluginsByCategory(PluginCategory category, int amount)
		{
			string url = BukgetUrlBuilder.ConstructUrl(category, BukgetUrlBuilder.FieldsSimple, amount);
			return RetrieveParseStore(url);
		}

		public static Dictionary<String, BukgetPlugin> GetPluginsByCategory(string category, int amount)
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
			return CurrentlyLoadedPlugins;
		}

		/// <summary>
		///     Convert a list to a dictionary
		/// </summary>
		/// <param name="pluginList">List of plugins to convert</param>
		/// <returns></returns>
		public static Dictionary<String, BukgetPlugin> ListToDictionary(List<BukgetPlugin> pluginList)
		{
			return pluginList.ToDictionary(bukgetPlugin => bukgetPlugin.Main);
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