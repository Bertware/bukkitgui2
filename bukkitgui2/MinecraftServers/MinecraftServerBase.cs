using System;
using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Bukkitgui2.Core.Logging;
using Bukkitgui2.MinecraftInterop.OutputHandler;
using Bukkitgui2.MinecraftInterop.OutputHandler.PlayerActions;

namespace Bukkitgui2.MinecraftServers
{
    using Bukkitgui2.Core.Util.Web;

    /// <summary>
	///     The base for a minecraft server. This should contain all parsing code for a vanilla server.
	/// </summary>
	internal class MinecraftServerBase : IMinecraftServer
	{
		//new prefixes in output tags since 1.7.2
		private const string Outputprefix172 = "((.*)thread(.*)/|)";

		// message tags
		private const string InfoTagRegex = "^\\[" + Outputprefix172 + "info\\]";
		private const string WarningTagRegex = "^\\[" + Outputprefix172 + "(warning|warn)\\]";
		private const string SevereTagRegex = "^\\[" + Outputprefix172 + "(severe|error)\\]";

		// ip's and player names
		private const string IpRegex = "\\[\\d{1,3}:\\d{1,3}:\\d{1,3}:\\d{1,3}(:\\d{2,5}|)\\]";
		private const string PlayerRegex = "\\w{2,16}";
		
		// other regexes
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

		public virtual void PrepareLaunch()
		{
		}

		public virtual bool HasCustomAssembly
		{
			get { return false; }
		}

		public virtual Assembly CustomAssembly
		{
			get { return null; }
		}

		public virtual string GetLaunchParameters(string defaultParameters = "")
		{
			return defaultParameters;
		}

		public virtual string GetLaunchFlags(string defaultFlags = "")
		{
			return defaultFlags;
		}

		public virtual bool HasCustomSettingsControl
		{
			get { return false; }
		}

		public virtual UserControl CustomSettingsControl
		{
			get { return null; }
		}

		public virtual OutputParseResult ParseOutput(string text)
		{
			string message = ParseMessage(text);

			MessageType type = ParseMessageType(message);

			return new OutputParseResult(text, message, type);
		}

		public string ParseMessage(string text)
		{
			Logger.Log(LogLevel.Debug, "MinecraftServerBase", "Parsing message for \"" + text + "\"");
			text = RemoveTimeStamp(text); // We need to know the type, so we'll continue without the timestamp
			Logger.Log(LogLevel.Debug, "MinecraftServerBase", "Removed timestamp: \"" + text + "\"");
			text = FilterText(text);
			Logger.Log(LogLevel.Debug, "MinecraftServerBase", "Filtered text: \"" + text + "\"");
			return text;
		}

		public virtual MessageType ParseMessageType(string text)
		{
			MessageType type = MessageType.Unknown;


			//[WARNING]...
			if (Regex.IsMatch(text, WarningTagRegex + ".*", RegexOptions.IgnoreCase))
			{
				type = MessageType.Warning;
			}
				//[SEVERE] ...
			else if (Regex.IsMatch(text, SevereTagRegex + ".*", RegexOptions.IgnoreCase))
			{
				type = MessageType.Severe;
			}
				//[INFO] Bertware[/127.0.0.1:58189] logged in with entity id 27 at ([world] -1001.0479985318618, 2.0, 1409.300000011921)
				//[INFO] Bertware[/127.0.0.1:58260] logged in with entity id 0 at (-1001.0479985318618, 2.0, 1409.300000011921)
			else if (Regex.IsMatch(text,
				InfoTagRegex + SpaceRegex + PlayerRegex + IpRegex + ForcedSpaceRegex + "logged in with entity id",
				RegexOptions.IgnoreCase))
			{
				type = MessageType.PlayerJoin;
			}
			else if (Regex.IsMatch(text, InfoTagRegex + ".*", RegexOptions.IgnoreCase))
			{
				type = MessageType.Info;
			}

			return type;
		}

		public virtual string RemoveTimeStamp(string text)
		{
			//2014-01-01 00:00:00,000
			text = Regex.Replace(text, "\\d{4}-\\d{2}-\\d{2} \\d{2}:\\d{2}:\\d{2}(,\\d{3}|)\\s*", "");
			//[11:36:21]
			text = Regex.Replace(text, "\\[\\d\\d:\\d\\d:\\d\\d\\]", "");
			//[11:36:21 INFO]
			text = Regex.Replace(text, "\\[\\d\\d:\\d\\d:\\d\\d ", "[");
			return text;
		}

		public virtual string FilterText(string text)
		{
			text = Regex.Replace(text, "\\[minecraft(-server|)\\]", "", RegexOptions.IgnoreCase);
			// remove [minecraft] or [minecraft-server] tags, for better parsing
			text = Regex.Replace(text, "\\]:", "] ");
			return text;
		}

		public virtual PlayerActionJoin ParsePlayerJoin(string text)
		{
			return new PlayerActionJoin();
		}

		public virtual PlayerActionLeave ParsePlayerLeave(string text)
		{
			return new PlayerActionLeave();
		}

		public virtual PlayerActionKick ParsePlayerActionKick(string text)
		{
			return new PlayerActionKick();
		}

		public virtual PlayerActionBan ParsePlayerActionBan(string text)
		{
			return new PlayerActionBan();
		}

		public virtual PlayerActionIpBan ParsePlayerActionIpBan(string text)
		{
			return new PlayerActionIpBan();
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
			get { return true; }
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
			FileDownloader fileDownloadDialog = new FileDownloader();
		    fileDownloadDialog.AddFile(
		        "https://s3.amazonaws.com/Minecraft.Download/versions/1.7.5/minecraft_server.1.7.5.jar",
		        targetfile);
		    fileDownloadDialog.Show();
            fileDownloadDialog.StartDownload();
            return true;
		}

		public virtual bool DownloadBetaVersion(string targetfile)
		{
		    return false;
		}

		public virtual bool DownloadDevVersion(string targetfile)
		{
            return false;
		}

		public virtual string GetCurrentVersion(string file)
		{
			throw new NotImplementedException();
		}
	}
}