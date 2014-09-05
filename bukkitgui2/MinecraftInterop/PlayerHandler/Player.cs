// Player.cs in bukkitgui2/bukkitgui2
// Created 2014/04/27
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Threading;
using Microsoft.VisualBasic.Devices;
using Net.Bertware.Bukkitgui2.Core.Logging;
using Net.Bertware.Bukkitgui2.Core.Util.Web;
using Net.Bertware.Bukkitgui2.Properties;

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
		public string Name { get; private set; }

		/// <summary>
		///     the IP address of this player
		/// </summary>
		public string Ip { get; private set; }

		/// <summary>
		///     The in-game display name of this player
		/// </summary>
		public string DisplayName { get; set; }

		/// <summary>
		///     Time of join
		/// </summary>
		public DateTime JoinTime { get; private set; }

		/// <summary>
		///     The player's face
		/// </summary>
		public Image Minotar { get; private set; }

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
			DisplayName = name;
			Location = "locating...";
			JoinTime = DateTime.Now;
		}

		public Player(string name, string ip, string displayName)
		{
			Name = name;
			Ip = ip;
			DisplayName = displayName;
			Location = "locating...";
			JoinTime = DateTime.Now;
			new Thread(GetDetails).Start();
		}

		private void GetDetails(object obj)
		{
			GetMinotar();
			GetLocation();
			OnDetailsLoaded();
		}

		/// <summary>
		///     Get the location (country) for this player.
		/// </summary>
		private void GetLocation()
		{
			Location = WebUtil.GetGeoLocation(Ip);
		}

		/// <summary>
		///     Gets the player face for this player
		/// </summary>
		private void GetMinotar()
		{
			Image img = Resources.player_face;

			if (new Computer().Network.IsAvailable == false)
			{
				//use default
				Minotar = img;
				return;
			}

			try
			{
				string url = "http://minotar.net/helm/" + Name + "/96.png";
				HttpWebRequest webreq = (HttpWebRequest) WebRequest.Create(new Uri(url));
				//set useragent - currently only for statistics
				webreq.UserAgent = WebUtil.UserAgent;
				webreq.CachePolicy = new RequestCachePolicy(RequestCacheLevel.CacheIfAvailable);
				WebResponse resp = webreq.GetResponse();

				Stream imgstream = resp.GetResponseStream();
				if (imgstream == null || imgstream.Equals(Stream.Null))
				{
					//use default
					Minotar = img;
					return;
				}
				img = Image.FromStream(imgstream);
				//Get image from file
			}
			catch (Exception ex)
			{
				Minotar = img;
				//use default
				Logger.Log(LogLevel.Warning, "Player", "Exception while retrieving minotar", ex.Message);
			}

			Minotar = img;
		}

		/// <summary>
		///     Kick a this.Name
		/// </summary>
		public void Kick()
		{
			PlayerActions.KickPlayer(Name);
		}

		/// <summary>
		///     Ban a this.Name
		/// </summary>
		public void Ban()
		{
			PlayerActions.BanPlayer(Name);
		}

		/// <summary>
		///     Ban an ip
		/// </summary>
		public void BanIp()
		{
			PlayerActions.BanIp(Ip);
		}

		/// <summary>
		///     Pardon a banned this.Name
		/// </summary>
		public void Pardon()
		{
			PlayerActions.PardonPlayer(Name);
		}

		/// <summary>
		///     Pardon a banned ip
		/// </summary>
		/// <param name="ip">the ip to pardon</param>
		public void PardonIp(string ip)
		{
			PlayerActions.PardonIp(Ip);
		}

		/// <summary>
		///     Set the gamemode for a given this.Name
		/// </summary>
		/// <param name="mode">The gamemode to set</param>
		public void SetGameMode(MinecraftGameMode mode)
		{
			PlayerActions.SetGameMode(mode, Name);
		}


		/// <summary>
		///     Add or remove a this.Name from the op
		/// </summary>
		/// <param name="whitelist">True to op the this.Name, false to remove him from the op</param>
		public void SetWhitelist(bool whitelist)
		{
			PlayerActions.SetPlayerWhitelist(Name, whitelist);
		}

		/// <summary>
		///     Add or remove a this.Name from the OP list
		/// </summary>
		/// <param name="op">True to OP the this.Name, false to de-OP him</param>
		public void SetOp(bool op)
		{
			PlayerActions.SetPlayerOp(Name, op);
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