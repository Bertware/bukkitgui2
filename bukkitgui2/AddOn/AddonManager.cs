// AddonManager.cs in bukkitgui2/bukkitgui2
// Created 2014/05/17
// Last edited at 2014/05/24 12:16
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.Core.Configuration;
using Net.Bertware.Bukkitgui2.Core.Logging;
using Net.Bertware.Bukkitgui2.Core.Util;

namespace Net.Bertware.Bukkitgui2.AddOn
{
	public static class AddonManager
	{
		private const string CfgIdent = "addons";

		/// <summary>
		///     Boolean to keep the loaded state of the addons
		/// </summary>
		public static Boolean AddonsLoaded { get; private set; }

		/// <summary>
		///     Dictionary to store all loaded addons, by [Name, IAddon]
		/// </summary>
		public static Dictionary<string, IAddon> AddonsDictionary { get; private set; }

		/// <summary>
		///     Dictionary to store all loaded tabs, by [Name, UserControl]
		/// </summary>
		public static Dictionary<IAddon, UserControl> TabsDictionary { get; private set; }

		/// <summary>
		///     Dictionary to store all loaded settings pages, by [Name, UserControl]
		/// </summary>
		public static Dictionary<IAddon, UserControl> SettingsDictionary { get; private set; }

		/// <summary>
		///     Get the instance of a loaded addon
		/// </summary>
		/// <param name="name">The name of the addon</param>
		/// <returns>Returns the addon if possible, null if the addon isn't loaded</returns>
		public static IAddon GetAddon(string name)
		{
			return AddonsDictionary.ContainsKey(name) ? AddonsDictionary[name] : null;
		}

		/// <summary>
		///     Get the instance of a loaded core addon
		/// </summary>
		/// <param name="addon">The addon to load</param>
		/// <returns>Returns the addon if possible, null if the addon isn't loaded</returns>
		public static IAddon GetRequiredAddon(RequiredAddon addon)
		{
			return AddonsDictionary.ContainsKey(addon.ToString())
				? AddonsDictionary[addon.ToString()]
				: null;
		}

		/// <summary>
		///     Load all tabpages to the mainform
		/// </summary>
		public static void LoadAddons()
		{
			if (AddonsLoaded) return;

			// construct the dictionary that we'll use to store addons during runtime
			AddonsDictionary = new Dictionary<string, IAddon>();
			TabsDictionary = new Dictionary<IAddon, UserControl>();
			SettingsDictionary = new Dictionary<IAddon, UserControl>();
			// Create and store a list with the loaded tabs, then load them to the UI.
			// max 16 addons for now

			Dictionary<string, Type> addonsToLoad = GetAvailableAddons();

			foreach (Type T in addonsToLoad.Values)
			{
				if (String.IsNullOrEmpty(T.Name)) continue;
				if ((T.Name != "Console" && T.Name != "Settings" && T.Name != "Starter") &&
				    Config.ReadInt(CfgIdent, "enable_" + T.Name, 1) == 0) continue;

				IAddon addon = (IAddon) Activator.CreateInstance(Assembly.GetExecutingAssembly().GetType(T.FullName));
				// initialize
				addon.Initialize();

				// add
				AddonsDictionary.Add(addon.Name, addon);

				// if this addon has a tab, add it 
				if (addon.HasTab)
				{
					TabsDictionary.Add(addon, addon.TabPage);
				}
				// if this addon has a settings page, add it 
				if (addon.HasConfig)
				{
					SettingsDictionary.Add(addon, addon.ConfigPage);
				}
			}

			AddonsLoaded = true;
		}

		/// <summary>
		///     Get a list of all available server types
		/// </summary>
		/// <returns></returns>
		private static Dictionary<string, Type> GetAvailableAddons()
		{
			Dictionary<string, Type> addons = new Dictionary<string, Type>();
			foreach (Type addon in DynamicModuleLoader.ListClassesRecursiveOfType<IAddon>("Net.Bertware.Bukkitgui2.AddOn"))
			{
				if (!addons.ContainsKey(addon.Name)) addons.Add(addon.Name, addon);
			}
			Logger.Log(LogLevel.Info, "AddonManager", "Found " + addons.Count + " available addons");
			return addons;
		}
	}
}