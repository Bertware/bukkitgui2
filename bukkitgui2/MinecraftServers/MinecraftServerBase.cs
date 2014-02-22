using System;
using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Bukkitgui2.MinecraftInterop.OutputHandler;
using Bukkitgui2.MinecraftInterop.OutputHandler.PlayerActions;

namespace Bukkitgui2.MinecraftServers
{
	/// <summary>
	///     The base for a minecraft server. This should contain all parsing code for a vanilla server.
	/// </summary>
	internal class MinecraftServerBase : IMinecraftServer
	{
		private const string Outputprefix172 = "((.*)thread(.*)/|)";

		private const string InfoTagRegex = "^\\[" + Outputprefix172 + "info\\]";
		private const string WarningTagRegex = "^\\[" + Outputprefix172 + "(warning|warn)\\]";
		private const string SevereTagRegex = "^\\[" + Outputprefix172 + "(severe|error)\\]";

		private const string IpRegex = "\\[\\d{1,3}:\\d{1,3}:\\d{1,3}:\\d{1,3}(:\\d{2,5}|)\\]";
		private const string PlayerRegex = "\\w{2,16}";
		private const string SpaceRegex = "\\{0,1}";
		private const string ForcedSpaceRegex = "\\s";

		public virtual string Name
		{
			get { return "Default Minecraft Server"; }
		}

		public virtual string Site
		{
			get { return "http://www.minecraft.net"; }
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

		public void PrepareLaunch()
		{
		}

		public bool HasCustomAssembly
		{
			get { return false; }
		}

		public Assembly CustomAssembly
		{
			get { return null; }
		}

		public string GetLaunchParameters(string defaultParameters = "")
		{
			return defaultParameters;
		}

		public string GetLaunchFlags(string defaultFlags = "")
		{
			return defaultFlags;
		}

		public bool HasCustomSettingsControl
		{
			get { return false; }
		}

		public UserControl CustomSettingsControl
		{
			get { return null; }
		}

		public virtual MessageParseResult ParseOutput(string text)
		{
			string originalText = text;
			MessageType type = ParseMessageType(text);

			return new MessageParseResult(originalText, text, type);
		}

		public virtual MessageType ParseMessageType(string text)
		{
			text = RemoveTimeStamp(text); // We need to know the type, so we'll continue without the timestamp

			text = FilterText(text);

			MessageType type = MessageType.Unknown;


			//[WARNING]...
			if (Regex.IsMatch(text, WarningTagRegex))
			{
				type = MessageType.Warning;
			}
				//[SEVERE] ...
			else if (Regex.IsMatch(text, SevereTagRegex))
			{
				type = MessageType.Severe;
			}
				//[INFO] Bertware[/127.0.0.1:58189] logged in with entity id 27 at ([world] -1001.0479985318618, 2.0, 1409.300000011921)
				//[INFO] Bertware[/127.0.0.1:58260] logged in with entity id 0 at (-1001.0479985318618, 2.0, 1409.300000011921)
			else if (Regex.IsMatch(text,
				InfoTagRegex + SpaceRegex + PlayerRegex + IpRegex + ForcedSpaceRegex + "logged in with entity id"))
			{
			}

			return type;
		}

		public virtual string RemoveTimeStamp(string text)
		{
			return text;
		}

		public virtual string FilterText(string text)
		{
			text = Regex.Replace(text, "\\[minecraft(-server|)\\]", "", RegexOptions.IgnoreCase);
				// remove [minecraft] or [minecraft-server] tags, for better parsing

			return text;
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