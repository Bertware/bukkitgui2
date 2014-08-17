// PlayerActionKick.cs in bukkitgui2/bukkitgui2
// Created 2014/02/02
// Last edited at 2014/08/17 11:19
// ©Bertware, visit http://bertware.net

using System;

namespace Net.Bertware.Bukkitgui2.MinecraftInterop.OutputHandler.PlayerActions
{
	public class PlayerActionKick : IPlayerAction
	{
		public string PlayerName { get; set; }
		public string Details { get; set; }
		public DateTime Time { get; set; }
	}
}