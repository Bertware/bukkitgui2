// PlayerActions.cs in bukkitgui2/bukkitgui2
// Created 2014/08/24
// Last edited at 2014/08/24 14:18
// ©Bertware, visit http://bertware.net

using System;

namespace Net.Bertware.Bukkitgui2.MinecraftInterop.PlayerHandler
{
	internal class PlayerActions
	{
		/// <summary>
		///     Kick a player
		/// </summary>
		/// <param name="name"></param>
		public static void KickPlayer(string name)
		{
			if (ProcessHandler.ProcessHandler.IsRunning)
			{
				ProcessHandler.ProcessHandler.SendInput("kick " + name);
			}
		}

		/// <summary>
		///     Ban a player
		/// </summary>
		/// <param name="name">the player to ban</param>
		public static void BanPlayer(string name)
		{
			if (ProcessHandler.ProcessHandler.IsRunning)
			{
				ProcessHandler.ProcessHandler.SendInput("ban " + name);
			}
		}

		/// <summary>
		///     Ban an ip
		/// </summary>
		/// <param name="ip">the ip to ban</param>
		public static void BanIp(string ip)
		{
			if (ProcessHandler.ProcessHandler.IsRunning)
			{
				ProcessHandler.ProcessHandler.SendInput("ban-ip " + ip);
			}
		}

		/// <summary>
		///     Pardon a banned player
		/// </summary>
		/// <param name="name">the player to pardon</param>
		public static void PardonPlayer(string name)
		{
			if (ProcessHandler.ProcessHandler.IsRunning)
			{
				ProcessHandler.ProcessHandler.SendInput("pardon " + name);
			}
		}

		/// <summary>
		///     Pardon a banned ip
		/// </summary>
		/// <param name="ip">the ip to pardon</param>
		public static void PardonIp(string ip)
		{
			if (ProcessHandler.ProcessHandler.IsRunning)
			{
				ProcessHandler.ProcessHandler.SendInput("pardon-ip " + ip);
			}
		}

		/// <summary>
		///     Set the gamemode for a given player
		/// </summary>
		/// <param name="mode">The gamemode to set</param>
		/// <param name="player">The player</param>
		public static void SetGameMode(MinecraftGameMode mode, string player)
		{
			if (ProcessHandler.ProcessHandler.IsRunning)
			{
				ProcessHandler.ProcessHandler.SendInput("gamemode " + (int) mode + " " + player);
			}
		}

		/// <summary>
		///     Set if the server should use a op
		/// </summary>
		/// <param name="useWhitelist">True to use a op</param>
		public static void UseWhitelist(Boolean useWhitelist)
		{
			if (ProcessHandler.ProcessHandler.IsRunning)
			{
				ProcessHandler.ProcessHandler.SendInput("op " + (useWhitelist ? "on" : "off"));
			}
		}

		/// <summary>
		///     Add or remove a player from the op
		/// </summary>
		/// <param name="name">Player to add/remove</param>
		/// <param name="whitelist">True to op the player, false to remove him from the op</param>
		public static void SetPlayerWhitelist(string name, bool whitelist)
		{
			if (ProcessHandler.ProcessHandler.IsRunning)
			{
				ProcessHandler.ProcessHandler.SendInput("op " + (whitelist ? "add" : "remove") + " " + name);
			}
		}

		/// <summary>
		///     Add or remove a player from the OP list
		/// </summary>
		/// <param name="name">Player to add/remove</param>
		/// <param name="op">True to OP the player, false to de-OP him</param>
		public static void SetPlayerOp(string name, bool op)
		{
			if (ProcessHandler.ProcessHandler.IsRunning)
			{
				ProcessHandler.ProcessHandler.SendInput((op ? "op" : "de-op") + " " + name);
			}
		}

		/// <summary>
		///     Give a player a certain item
		/// </summary>
		/// <param name="player">The player to give an item</param>
		/// <param name="item">The item to give</param>
		/// <param name="amount">The amount of the item to give</param>
		/// <param name="data">Data for damage</param>
		public static void Give(string player, string item, int amount, int data)
		{
			if (ProcessHandler.ProcessHandler.IsRunning)
			{
				ProcessHandler.ProcessHandler.SendInput("give " + player + " " + item + " " + amount + " " + data);
			}
		}

		/// <summary>
		///     Give a player a certain item
		/// </summary>
		/// <param name="player">The player to give an item</param>
		/// <param name="item">The item to give</param>
		/// <param name="amount">The amount of the item to give</param>
		/// <param name="data">Data for damage</param>
		public static void Give(string player, int item, int amount = 1, int data = 0)
		{
			if (ProcessHandler.ProcessHandler.IsRunning)
			{
				ProcessHandler.ProcessHandler.SendInput("give " + player + " " + item + " " + amount + " " + data);
			}
		}

		/// <summary>
		///     Teleport a player to another player
		/// </summary>
		/// <param name="player">The player to teleport</param>
		/// <param name="targetplayer">The player to teleport the first player to</param>
		public static void Teleport(string player, string targetplayer)
		{
			if (ProcessHandler.ProcessHandler.IsRunning)
			{
				ProcessHandler.ProcessHandler.SendInput("tp " + player + " " + targetplayer);
			}
		}

		/// <summary>
		///     Teleport a player to a place in the world
		/// </summary>
		/// <param name="player">The player to teleport</param>
		/// <param name="x">x-coordinate</param>
		/// <param name="y">y-coordinate</param>
		/// <param name="z">z-coordinate</param>
		public static void Teleport(string player, int x, int y, int z)
		{
			if (ProcessHandler.ProcessHandler.IsRunning)
			{
				ProcessHandler.ProcessHandler.SendInput("tp " + player + " " + x + " " + y + " " + z);
			}
		}
	}
}