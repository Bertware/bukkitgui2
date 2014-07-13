// IPlayerAction.cs in bukkitgui2/bukkitgui2
// Created 2014/02/02
// Last edited at 2014/07/13 14:01
// ©Bertware, visit http://bertware.net

using System;

namespace Net.Bertware.Bukkitgui2.MinecraftInterop.OutputHandler.PlayerActions
{
	public interface IPlayerAction
	{
		/// <summary>
		///     The name of the player who was subject to the action
		/// </summary>
		string PlayerName { get; set; }

		/// <summary>
		///     Details on the action
		/// </summary>
		string Details { get; set; }

		/// <summary>
		///     Time the action was registered
		/// </summary>
		DateTime Time { get; set; }
	}
}