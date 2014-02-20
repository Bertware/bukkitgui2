using System;
using System.Drawing;
using Bukkitgui2.MinecraftInterop.OutputHandler;
using Bukkitgui2.MinecraftInterop.OutputHandler.PlayerActions;

namespace Bukkitgui2.MinecraftServers
{
    using System.Reflection;

    /// <summary>
	/// The base for a minecraft server. This should contain all parsing code for a vanilla server.
	/// </summary>
	internal class MinecraftServerBase : IMinecraftServer
	{
		public virtual string Name
		{
			get { return "Default Minecraft Server"; }
		}

		public virtual string Site
		{
			get { return ""; }
		}

		public virtual Image Logo
		{
			get { return Properties.Resources.vanilla_logo; }
		}

		public virtual bool SupportsPlugins
		{
			get { return false; }
		}

		public virtual bool IsLocal
		{
			get { return true; }
		}

		public virtual MessageParseResult ParseOutput(string text)
		{
			throw new NotImplementedException();
		}

		public virtual MessageType ParseMessageType(string text)
		{
			throw new NotImplementedException();
		}

		public virtual PlayerActionJoin ParsePlayerJoin(string text)
		{
			throw new NotImplementedException();
		}

		public virtual PlayerActionLeave ParsePlayerLeave(string text)
		{
			throw new NotImplementedException();
		}

		public virtual PlayerActionKick ParsePlayerActionKick(string text)
		{
			throw new NotImplementedException();
		}

		public virtual PlayerActionBan ParsePlayerActionBan(string text)
		{
			throw new NotImplementedException();
		}

		public virtual PlayerActionIpBan ParsePlayerActionIpBan(string text)
		{
			throw new NotImplementedException();
		}

		public virtual string RemoveTimeStamp(string text)
		{
			throw new NotImplementedException();
		}

		public virtual string FilterText(string text)
		{
			throw new NotImplementedException();
		}

		public virtual bool CanFetchRecommendedVersion
		{
			get { return false; }
		}

		public virtual bool CanFetchBetaVersion
		{
			get { return false; }
		}

		public virtual bool CanFetchDevVersion
		{
			get { return false; }
		}

		public virtual bool CanDownloadRecommendedVersion
		{
			get { return false; }
		}

		public virtual bool CanDownloadBetaVersion
		{
			get { return false; }
		}

		public virtual bool CanDownloadDevVersion
		{
			get { return false; }
		}

		public virtual bool CanGetCurrentVersion
		{
			get { return false; }
		}

		public virtual string FetchRecommendedVersion
		{
			get { return null; }
		}

		public virtual string FetchBetaVersion
		{
			get { return null; }
		}

		public virtual string FetchDevVersion
		{
			get { return null; }
		}

		public virtual bool DownloadRecommendedVersion(string targetfile)
		{
			throw new NotImplementedException();
		}

		public virtual bool DownloadBetaVersion(string targetfile)
		{
			throw new NotImplementedException();
		}

		public virtual bool DownloadDevVersion(string targetfile)
		{
			throw new NotImplementedException();
		}

		public virtual string GetCurrentVersion(string file)
		{
			throw new NotImplementedException();
		}
	}
}