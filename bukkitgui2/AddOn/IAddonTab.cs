// IAddonTab.cs in bukkitgui2/bukkitgui2
// Created 2014/01/30
// Last edited at 2014/06/22 12:34
// ©Bertware, visit http://bertware.net

namespace Net.Bertware.Bukkitgui2.AddOn
{
	public interface IAddonTab
	{
		IAddon ParentAddon { get; set; }
	}
}