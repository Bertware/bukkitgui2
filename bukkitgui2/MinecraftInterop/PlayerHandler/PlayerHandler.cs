namespace Bukkitgui2.MinecraftInterop.PlayerHandler
{
    using System;
    using System.Collections.Generic;

    using Bukkitgui2.MinecraftInterop.OutputHandler;
    using Bukkitgui2.MinecraftInterop.OutputHandler.PlayerActions;

    public static class PlayerHandler
    {

        public delegate void PlayerListChangedEventHandler();
        /// <summary>
        /// Raised when any output is received
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
        ///     List of the current online players, identified by their login name
        /// </summary>
        public static Dictionary<string, Player> OnlinePlayers { get; private set; }

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
        ///     Handle a player disconnect event
        /// </summary>
        private static void HandlePlayerDisconnect(string text, OutputParseResult outputparseresult, IPlayerAction playeraction)
        {
            if (OnlinePlayers.ContainsKey(playeraction.PlayerName)) OnlinePlayers.Remove(playeraction.PlayerName);
            RaisePlayerListChangedEvent();
        }

        /// <summary>
        ///     Handle a player join event
        /// </summary>
        private static void HandlePlayerJoin(
            string text,
            OutputParseResult outputparseresult,
            IPlayerAction playeraction)
        {
            PlayerActionJoin join = (PlayerActionJoin)playeraction;

            Player player = new Player(join.PlayerName, join.Ip, join.PlayerName) { JoinTime = @join.Time };

            if (!OnlinePlayers.ContainsKey(player.Name))
            {
                OnlinePlayers.Add(player.Name, player);
            }
            RaisePlayerListChangedEvent();
        }
    }
}