// EditorTab.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// ©Bertware, visit http://bertware.net

namespace Net.Bertware.Bukkitgui2.AddOn.Editor
{
	public partial class EditorTab : IAddonTab
	{
		public EditorTab()
		{
			InitializeComponent();
		}

		public IAddon ParentAddon { get; set; }
	}
}