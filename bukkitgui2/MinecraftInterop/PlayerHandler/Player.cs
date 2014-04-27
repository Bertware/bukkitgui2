using System;

namespace Net.Bertware.Bukkitgui2.MinecraftInterop.PlayerHandler
{
    public class Player
    {
        public string Name { get; set; }

        public string Ip { get; set; }

        public string DisplayName { get; set; }

        public DateTime JoinTime { get; set; }

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
