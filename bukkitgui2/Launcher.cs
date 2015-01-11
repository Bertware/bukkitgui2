// Launcher.cs in bukkitgui2/bukkitgui2
// Created 2015/01/10
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.UI;

namespace Net.Bertware.Bukkitgui2
{
	public static class Launcher
	{
		// run the mainform, we need to proxy it through this class since we need to load embedded dll's first
		public static void Run()
		{
			Application.Run(new MainForm());
		}
	}
}