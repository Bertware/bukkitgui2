
using System;

namespace bukkitgui2.MinecraftInterop.OutputHandler.PlayerActions
{
	public interface IPlayerAction
	{
		/// <summary>
		/// The name of the player who was subject to the action
		/// </summary>
		string PlayerName { get; set; }

		/// <summary>
		/// Details on the action
		/// </summary>
		string Details { get; set; }

		/// <summary>
		/// Time the action was registered
		/// </summary>
		DateTime Time { get; set; }
	}
}
