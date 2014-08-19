// Player.cs in bukkitgui2/bukkitgui2
// Created 2014/04/27
// Last edited at 2014/08/17 11:19
// ©Bertware, visit http://bertware.net

using System;
using System.Threading;
using Net.Bertware.Bukkitgui2.Core.Util.Web;

namespace Net.Bertware.Bukkitgui2.MinecraftInterop.PlayerHandler
{
	public class Player
	{
		public event EventHandler DetailsLoaded; 

		protected virtual void OnDetailsLoaded()
		{
			var handler = DetailsLoaded;
			if (handler != null) handler(this, EventArgs.Empty);
		}



		/// <summary>
		///     The name of this player
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		///     the IP address of this player
		/// </summary>
		public string Ip { get; set; }

		/// <summary>
		///     The in-game display name of this player
		/// </summary>
		public string DisplayName { get; set; }

		/// <summary>
		///     Time of join
		/// </summary>
		public DateTime JoinTime { get; set; }

		/// <summary>
		///     The geographical location of this player (based on IP)
		/// </summary>
		/// <remarks>
		///     This field is populated async, so when passing the object on a player join event, it won't be populated yet
		/// </remarks>
		public string Location { get; set; }

		public Player(string name)
		{
			Name = name;
		}

		public Player(string name, string ip, string displayName)
		{
			Name = name;
			Ip = ip;
			DisplayName = displayName;
			new Thread(GetLocation).Start();
		}

		private void GetLocation()
		{
			this.Location = WebUtil.GetGeoLocation(Ip);
			OnDetailsLoaded();
		}
	}
}