// Issues.cs in bukkitgui2/bukkitgui2
// Created 2014/08/31
// Last edited at 2014/08/31 12:20
// ©Bertware, visit http://bertware.net

using System.Windows.Forms;

namespace Net.Bertware.Bukkitgui2.AddOn.Issues
{
	internal class Issues : IAddon
	{
		public Issues()
		{
			Name = "Issues";
			HasTab = true;
			TabPage = new IssuesTab();
			HasConfig = false;
			ConfigPage = null;
		}

		/// <summary>
		///     The addon name, ideally this name is the same as used in the tabpage
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		///     True if this addon has a tab page
		/// </summary>
		public bool HasTab { get; private set; }

		/// <summary>
		///     True if this addon has a config field
		/// </summary>
		public bool HasConfig { get; private set; }

		/// <summary>
		///     Initialize all functions and the tabcontrol
		/// </summary>
		public void Initialize()
		{
			// nothing to do
		}

		public void Dispose()
		{
			// nothing to do
		}

		/// <summary>
		///     The tab control for this addon
		/// </summary>
		/// <returns>Returns the tabpage</returns>
		public UserControl TabPage { get; private set; }

		public UserControl ConfigPage { get; private set; }
	}
}