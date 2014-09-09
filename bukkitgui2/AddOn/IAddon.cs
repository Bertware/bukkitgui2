// IAddon.cs in bukkitgui2/bukkitgui2
// Created 2014/01/30
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace Net.Bertware.Bukkitgui2.AddOn
{
	public interface IAddon
	{
		/// <summary>
		///     The addon name, ideally this name is the same as used in the tabpage
		/// </summary>
		string Name { get; }

		/// <summary>
		///     True if this addon has a tabpage
		/// </summary>
		Boolean HasTab { get; }

		/// <summary>
		///     True if this addon has a config field
		/// </summary>
		Boolean HasConfig { get; }

		/// <summary>
		///     Initialize all functions and the tabcontrol
		/// </summary>
		void Initialize();

		/// <summary>
		///     Dispose all resources
		/// </summary>
		void Dispose();

		/// <summary>
		///     The tab control for this addon, if any
		/// </summary>
		/// <returns>Returns the tabpage</returns>
		MetroUserControl TabPage { get; }

		/// <summary>
		///     The config control for this addon, if any
		/// </summary>
		/// <returns>Returns the tabpage</returns>
		MetroUserControl ConfigPage { get; }
	}

	public enum RequiredAddon
	{
		Console,
		Starter,
		Settings
	}
}