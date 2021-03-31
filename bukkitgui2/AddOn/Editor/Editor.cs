// Editor.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using MetroFramework.Controls;

namespace Net.Bertware.Bukkitgui2.AddOn.Editor
{
	internal class Editor : IAddon
	{
		/// <summary>
		///     The addon name, ideally this name is the same as used in the tabpage
		/// </summary>
		public string Name
		{
			get { return "Editor"; }
		}

		/// <summary>
		///     The addon priority. Default: 0
		/// </summary>
		public int Priority
		{
			get { return 0; }
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

		/// <summary>
		///     Initialize all functions and the tabcontrol
		/// </summary>
		public void Initialize()
		{
			TabPage = new EditorTab {Text = Name, ParentAddon = this};
	        ConfigPage = null;
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
	}
}
