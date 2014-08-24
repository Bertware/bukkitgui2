// Player.cs in bukkitgui2/bukkitgui2
// Created 2014/04/27
// Last edited at 2014/08/24 14:55
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
			EventHandler handler = DetailsLoaded;
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
			Location = WebUtil.GetGeoLocation(Ip);
			OnDetailsLoaded();
		}

		/// <summary>
		///     Kick a this.Name
		/// </summary>
		public void Kick()
		{
			if (ProcessHandler.ProcessHandler.IsRunning)
			{
				ProcessHandler.ProcessHandler.SendInput("kick " + Name);
			}
		}

		/// <summary>
		///     Ban a this.Name
		/// </summary>
		public void Ban()
		{
			if (ProcessHandler.ProcessHandler.IsRunning)
			{
				ProcessHandler.ProcessHandler.SendInput("ban " + Name);
			}
		}

		/// <summary>
		///     Ban an ip
		/// </summary>
		public void BanIp()
		{
			if (ProcessHandler.ProcessHandler.IsRunning)
			{
				ProcessHandler.ProcessHandler.SendInput("ban-ip " + Ip);
			}
		}

		/// <summary>
		///     Pardon a banned this.Name
		/// </summary>
		public void Pardon()
		{
			if (ProcessHandler.ProcessHandler.IsRunning)
			{
				ProcessHandler.ProcessHandler.SendInput("pardon " + Name);
			}
		}

		/// <summary>
		///     Pardon a banned ip
		/// </summary>
		/// <param name="ip">the ip to pardon</param>
		public void PardonIp(string ip)
		{
			if (ProcessHandler.ProcessHandler.IsRunning)
			{
				ProcessHandler.ProcessHandler.SendInput("pardon-ip " + ip);
			}
		}

		/// <summary>
		///     Set the gamemode for a given this.Name
		/// </summary>
		/// <param name="mode">The gamemode to set</param>
		public void SetGameMode(MinecraftGameMode mode)
		{
			if (ProcessHandler.ProcessHandler.IsRunning)
			{
				ProcessHandler.ProcessHandler.SendInput("gamemode " + (int) mode + " " + Name);
			}
		}


		/// <summary>
		///     Add or remove a this.Name from the op
		/// </summary>
		/// <param name="whitelist">True to op the this.Name, false to remove him from the op</param>
		public void SetWhitelist(bool whitelist)
		{
			if (ProcessHandler.ProcessHandler.IsRunning)
			{
				ProcessHandler.ProcessHandler.SendInput("op " + (whitelist ? "add" : "remove") + " " + Name);
			}
		}

		/// <summary>
		///     Add or remove a this.Name from the OP list
		/// </summary>
		/// <param name="op">True to OP the this.Name, false to de-OP him</param>
		public void SetOp(bool op)
		{
			if (ProcessHandler.ProcessHandler.IsRunning)
			{
				ProcessHandler.ProcessHandler.SendInput((op ? "op" : "de-op") + " " + Name);
			}
		}

		/// <summary>
		///     Give a this.Name a certain item
		/// </summary>
		/// <param name="item">The item to give</param>
		/// <param name="amount">The amount of the item to give</param>
		/// <param name="data">Data for damage</param>
		public void Give(string item, int amount, int data)
		{
			if (ProcessHandler.ProcessHandler.IsRunning)
			{
				ProcessHandler.ProcessHandler.SendInput("give " + Name + " " + item + " " + amount + " " + data);
			}
		}

		/// <summary>
		///     Give a this.Name a certain item
		/// </summary>
		/// <param name="item">The item to give</param>
		/// <param name="amount">The amount of the item to give</param>
		/// <param name="data">Data for damage</param>
		public void Give(int item, int amount = 1, int data = 0)
		{
			if (ProcessHandler.ProcessHandler.IsRunning)
			{
				ProcessHandler.ProcessHandler.SendInput("give " + Name + " " + item + " " + amount + " " + data);
			}
		}

		/// <summary>
		///     Teleport a this.Name to another this.Name
		/// </summary>
		/// <param name="targetplayer">The this.Name to teleport the first this.Name to</param>
		public void Teleport(string targetplayer)
		{
			if (ProcessHandler.ProcessHandler.IsRunning)
			{
				ProcessHandler.ProcessHandler.SendInput("tp " + Name + " " + targetplayer);
			}
		}

		/// <summary>
		///     Teleport a this.Name to a place in the world
		/// </summary>
		/// <param name="x">x-coordinate</param>
		/// <param name="y">y-coordinate</param>
		/// <param name="z">z-coordinate</param>
		public void Teleport(int x, int y, int z)
		{
			if (ProcessHandler.ProcessHandler.IsRunning)
			{
				ProcessHandler.ProcessHandler.SendInput("tp " + Name + " " + x + " " + y + " " + z);
			}
		}
	}
}