using System;
using System.Collections.Generic;
using  Net.Bertware.Bukkitgui2.MinecraftInterop.OutputHandler;
using  Net.Bertware.Bukkitgui2.MinecraftInterop.OutputHandler.PlayerActions;

namespace Net.Bertware.Bukkitgui2.MinecraftInterop.PlayerHandler
{
	/// <summary>
	/// Handles player connects and disconnects and keep a dictionary of all logged in players. Raises events when a player is added or removed from the list, and can sync with ingame player lists.
	/// </summary>
	public static class PlayerHandler
	{
		/// <summary>
		///     Delegate for the PlayerListAddition event
		/// </summary>
		/// <param name="player">The new player</param>
		public delegate void PlayerListAdditionEventHandler(Player player);

		/// <summary>
		///     Raised when a player had been added to the player list
		/// </summary>
		public static event PlayerListAdditionEventHandler PlayerListAddition;

		/// <summary>
		///     Raise a PlayerListAddition event
		/// </summary>
		/// <param name="player">the player that has been added</param>
		private static void RaisePlayerListAdditionEvent(Player player)
		{
			PlayerListAdditionEventHandler handler = PlayerListAddition;
			if (handler != null)
			{
				handler(player);
			}
		}

		/// <summary>
		///     Delegate for the PlayerListDeletion event
		/// </summary>
		/// <param name="player">The removed player</param>
		public delegate void PlayerListDeletionEventHandler(Player player);

		/// <summary>
		///     Raised when a player has been removed from the player list
		/// </summary>
		public static event PlayerListDeletionEventHandler PlayerListDeletion;

		/// <summary>
		///     Raise a PlayerListDeletion event
		/// </summary>
		/// <param name="player">the player that has been removed</param>
		private static void RaisePlayerListDeletionEvent(Player player)
		{
			PlayerListDeletionEventHandler handler = PlayerListDeletion;
			if (handler != null)
			{
				handler(player);
			}
		}

		/// <summary>
		///     Delegate for the PlayerListChanged event
		/// </summary>
		public delegate void PlayerListChangedEventHandler();

		/// <summary>
		///     Raised when the player list has been altered
		/// </summary>
		public static event PlayerListChangedEventHandler PlayerListChanged;

		private static void RaisePlayerListChangedEvent()
		{
			PlayerListChangedEventHandler handler = PlayerListChanged;
			if (handler != null)
			{
				handler();
			}
		}


		/// <summary>
		///     List of the current online players, identified by their login name in lowercase
		/// </summary>
		private static Dictionary<string, Player> OnlinePlayers { get; set; }

		public static Boolean IsInitialized { get; private set; }

		/// <summary>
		///     Initialize the PlayerHandler class
		/// </summary>
		public static void Initialize()
		{
			if (IsInitialized) return;
			OnlinePlayers = new Dictionary<string, Player>();
			MinecraftOutputHandler.PlayerJoin += HandlePlayerJoin;
			MinecraftOutputHandler.PlayerLeave += HandlePlayerDisconnect;
			IsInitialized = true;
		}

		/// <summary>
		/// Add a player to the online players list and raise the according events
		/// </summary>
		/// <param name="player">The player to add</param>
		public static void AddPlayer(Player player)
		{
			if (OnlinePlayers.ContainsKey(player.Name)) return;

			OnlinePlayers.Add(player.Name.ToLower(), player);
			RaisePlayerListAdditionEvent(player);
			RaisePlayerListChangedEvent();
		}

		/// <summary>
		/// Remove a player from the online players list and raise the according events
		/// </summary>
		/// <param name="player">The player to remove</param>
		public static void RemovePlayer(Player player)

		{
			if (!OnlinePlayers.ContainsKey(player.Name)) return;
			OnlinePlayers.Remove(player.Name);
			RaisePlayerListChangedEvent();
			RaisePlayerListDeletionEvent(player);
		}

	    public static IEnumerable<Player> GetOnlinePlayers()
	    {
	        Player[] result = new Player[OnlinePlayers.Count];
	        OnlinePlayers.Values.CopyTo(result,0);
	        return result;
	    } 

		/// <summary>
		///     Get an online player by their name
		/// </summary>
		/// <param name="name"></param>
		/// <returns>Returns the player object if the player is found. Returns null if the player isn't found</returns>
		public static Player GetOnlinePlayerByName(String name)
		{
			if (IsPlayerListed(name)) return OnlinePlayers[name];
			return null;
		}
		/// <summary>
		/// Check if a player is listed in the dictionarry of online players
		/// </summary>
		/// <param name="name">The name of the player to check</param>
		/// <returns>Returns true if the player is listed, false if the player isn't found</returns>
		public static Boolean IsPlayerListed(String name)
		{
			return OnlinePlayers.ContainsKey(name.ToLower());
		}

		/// <summary>
		///     Handle a player disconnect event
		/// </summary>
		private static void HandlePlayerDisconnect(string text, OutputParseResult outputparseresult,
			IPlayerAction playeraction)
		{
			RemovePlayer(GetOnlinePlayerByName(playeraction.PlayerName));
		}

		/// <summary>
		///     Handle a player join event
		/// </summary>
		private static void HandlePlayerJoin(
			string text,
			OutputParseResult outputparseresult,
			IPlayerAction playeraction)
		{
			PlayerActionJoin join = (PlayerActionJoin) playeraction;

			Player player = new Player(join.PlayerName, join.Ip, join.PlayerName) {JoinTime = @join.Time};

			AddPlayer(player);
		}

		//TODO: sync with ingame playerlist (/list command)
	}
}