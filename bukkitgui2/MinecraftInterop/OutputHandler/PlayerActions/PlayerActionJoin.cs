// PlayerActionJoin.cs in bukkitgui2/bukkitgui2
// Created 2014/02/02
// ©Bertware, visit http://bertware.net

using System;

namespace Net.Bertware.Bukkitgui2.MinecraftInterop.OutputHandler.PlayerActions
{
	public class PlayerActionJoin : IPlayerAction
	{
		public string PlayerName { get; set; }
		public string Details { get; set; }
		public string Ip { get; set; }
		public DateTime Time { get; set; }
	}
}