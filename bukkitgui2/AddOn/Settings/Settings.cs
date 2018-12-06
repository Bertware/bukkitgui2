﻿// Settings.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using MetroFramework.Controls;

namespace Net.Bertware.Bukkitgui2.AddOn.Settings
{
    internal class Settings : IAddon
    {
        public Settings()
        {
            TabPage = null;
	        ConfigPage = null;
        }

        /// <summary>
        ///     True if this addon has a tab page
        /// </summary>
        public bool HasTab
        {
            get { return true; }
        }

        /// <summary>
        ///     True if this addon has a config field
        /// </summary>
        public bool HasConfig
        {
            get { return false; }
        }

        public void Dispose()
        {
            // nothing to do
        }

        /// <summary>
        ///     The tab control for this addon
        /// </summary>
        /// <returns>Returns the tabpage</returns>
        public MetroUserControl TabPage { get; private set; }

        public MetroUserControl ConfigPage { get; private set; }

        /// <summary>
        ///     The addon name, ideally this name is the same as used in the tabpage
        /// </summary>
        public string Name
        {
            get { return "Settings"; }
        }

        /// <summary>
        ///     The addon priority. Default: 0
        /// </summary>
        public int Priority
        {
            get { return -10; }
        }

        /// <summary>
        ///     Initialize all functions and the tabcontrol
        /// </summary>
        public void Initialize()
        {
            if (TabPage == null) TabPage = new SettingsTab {Text = Name, ParentAddon = this};
            ((SettingsTab) TabPage).Initialize();
        }

        /// <summary>
        ///     Remove the settings control for a given addon
        /// </summary>
        /// <param name="addon"></param>
        /// <remarks>Reloading addons is highly discouraged! Only use if no other way is possible</remarks>
        public void RemoveAddonSettings(IAddon addon)
        {
        }

        /// <summary>
        ///     Add the settings control for a given addon
        /// </summary>
        /// <param name="addon"></param>
        /// <remarks>Reloading addons is highly discouraged! Only use if no other way is possible</remarks>
        public void AddAddonSettings(IAddon addon)
        {
        }
    }
}