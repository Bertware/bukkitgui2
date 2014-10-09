// Updater.cs in bukkitgui2/bukkitgui2
// Created 2014/08/08
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System.Threading;
using MetroFramework.Controls;
using Net.Bertware.Get;

namespace Net.Bertware.Bukkitgui2.AddOn.Updater
{
    /// <summary>
    ///     Addon to show updater settings and info
    /// </summary>
    internal class Updater : IAddon
    {
        /// <summary>
        ///     The addon name, ideally this name is the same as used in the tabpage
        /// </summary>
        public string Name
        {
            get { return "Updater"; }
        }

        /// <summary>
        ///     True if this addon has a tab page
        /// </summary>
        public bool HasTab
        {
            get { return false; }
        }

        /// <summary>
        ///     True if this addon has a config field
        /// </summary>
        public bool HasConfig
        {
            get { return true; }
        }

        /// <summary>
        ///     Initialize all functions and the tabcontrol
        /// </summary>
        public void Initialize()
        {
            ConfigPage = new UpdaterSettings();
            CheckForUpdates();
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

        public bool CanDisable
        {
            get { return true; }
        }

        public static void CheckForUpdates()
        {
            Thread t = new Thread(() => api.RunUpdateCheck(true)) {Name = "RunUpdateCheck"};
            t.SetApartmentState(ApartmentState.MTA);
            
            t.Start();
        }
    }
}