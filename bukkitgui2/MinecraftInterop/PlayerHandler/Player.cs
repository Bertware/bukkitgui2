using System;

namespace Net.Bertware.Bukkitgui2.MinecraftInterop.PlayerHandler
{
    public class Player
    {
		/// <summary>
		/// The name of this player
		/// </summary>
        public string Name { get; set; }
		/// <summary>
		/// the IP address of this player
		/// </summary>
        public string Ip { get; set; }
		/// <summary>
		/// The in-game display name of this player
		/// </summary>
        public string DisplayName { get; set; }
		/// <summary>
		/// Time of join
		/// </summary>
        public DateTime JoinTime { get; set; }
		/// <summary>
		/// The geographical location of this player (based on IP)
		/// </summary>
		/// <remarks>
		/// This field is populated async, so when passing the object on a player join event, it won't be populated yet
		/// </remarks>
		public string Location { get; set; }

        public Player(string name)
        {
            this.Name = name;
        }

        public Player(string name, string ip, string displayName)
        {
            this.Name = name;
            this.Ip = ip;
            this.DisplayName = displayName;
        }
    }
}
