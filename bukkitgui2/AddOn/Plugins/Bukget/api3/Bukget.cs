// Bukget.cs in bukkitgui2/bukkitgui2
// Created 2014/05/03
// Last edited at 2014/05/24 12:16
// ©Bertware, visit http://bertware.net

using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace Net.Bertware.Bukkitgui2.AddOn.Plugins.Bukget.api3
{
	public class Bukget
	{
		public static List<BukgetPlugin> GetMostPopularPlugins(int amount)
		{
			string url = BukgetUrlBuilder.ConstructUrl(BukgetUrlBuilder.FieldsSimple, PluginInfoField.Pop_Daily, true, amount);
			string data = Core.Util.Web.WebUtil.RetrieveString(url);
			return BukgetPlugin.ParsePluginList(data);
		}
	}
}