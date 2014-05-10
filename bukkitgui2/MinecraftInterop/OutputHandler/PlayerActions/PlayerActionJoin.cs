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