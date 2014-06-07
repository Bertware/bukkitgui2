// PlayerActionBan.cs in bukkitgui2/bukkitgui2
// Created 2014/02/02
// Last edited at 2014/06/07 20:24
// ©Bertware, visit http://bertware.net

using System;

namespace Net.Bertware.Bukkitgui2.MinecraftInterop.OutputHandler.PlayerActions
{
	public class PlayerActionBan : IPlayerAction
	{
		public string PlayerName { get; set; }
		public string Details { get; set; }
		public DateTime Time { get; set; }
	}
}