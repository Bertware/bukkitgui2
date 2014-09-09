// MinecraftServerBase.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.Core.Logging;
using Net.Bertware.Bukkitgui2.MinecraftInterop.OutputHandler;
using Net.Bertware.Bukkitgui2.MinecraftInterop.OutputHandler.PlayerActions;

namespace Net.Bertware.Bukkitgui2.MinecraftServers
{
	/// <summary>
	///     The base for a minecraft server. This should contain all parsing code for a vanilla server.
	/// </summary>
	public class MinecraftServerBase : IMinecraftServer
	{
		//new prefixes in output tags since 1.7.2
		/// <summary>
		///     Prefix since minecraft 1.7.2 inside the message tag
		/// </summary>
		public const string RG_PRE172 = "((.*)thread(.*)/)?";

		// message tags
		/// <summary>
		///     Info message tag at line start
		/// </summary>
		public const string RG_INFO = "^\\[" + RG_PRE172 + "info\\]";

		/// <summary>
		///     Warning message tag at line start
		/// </summary>
		public const string RG_WARN = "^\\[" + RG_PRE172 + "(warning|warn)\\]";

		/// <summary>
		///     Severe/Error message tag at line start
		/// </summary>
		public const string RG_SEV = "^\\[" + RG_PRE172 + "(severe|error)\\]";

		// ip's and player names
		/// <summary>
		///     Ipv4 Ip address, without any extra's
		/// </summary>
		public const string RG_IP_NOPORT = "\\d{1,3}.\\d{1,3}.\\d{1,3}.\\d{1,3}";

		/// <summary>
		///     Ipv4 Ip address, with optional port. this is the typical ip for a minecraft login
		/// </summary>
		public const string RG_IP = RG_IP_NOPORT + "(:\\d{2,5}|)";

		/// <summary>
		///     Ipv4 Ip with optional port, between right brackets
		/// </summary>
		public const string RG_IP_BRACKET = "\\[/" + RG_IP + "\\]";

		/// <summary>
		///     Player name
		/// </summary>
		public const string RG_PLAYER = "\\w{2,16}";

		// other regexes
		/// <summary>
		///     Possible space
		/// </summary>
		public const string RG_SPACE = "\\s{0,}";

		/// <summary>
		///     At least one space
		/// </summary>
		public const string RG_FSPACE = "\\s+";

		/// <summary>
		///     Anything
		/// </summary>
		public const string RG_WILDCARD = "(.*)";

		/// <summary>
		///     Stacktrace, like "at net.minecraft.server ...
		/// </summary>
		public const string RG_STACKTRACE = "at (\\w+\\.){2}\\w+\\s";

		/// <summary>
		///     End of line
		/// </summary>
		public const string RG_EOL = "$";

		public string Name { get; protected set; }

		public string Site { get; protected set; }

		public Image Logo { get; protected set; }

		public bool SupportsPlugins { get; protected set; }

		public bool IsLocal { get; protected set; }


		public virtual void PrepareLaunch()
		{
		}

		public bool HasCustomAssembly { get; protected set; }

		public string CustomAssembly { get; protected set; }

		public virtual string GetLaunchParameters(string defaultParameters = "")
		{
			return defaultParameters;
		}

		public virtual string GetLaunchFlags(string defaultFlags = "")
		{
			return defaultFlags;
		}

		public bool HasCustomSettingsControl { get; protected set; }

		public UserControl CustomSettingsControl { get; protected set; }

		public virtual OutputParseResult ParseOutput(string text)
		{
			string message = ParseMessage(text);
			if (string.IsNullOrEmpty(message)) return null;

			MessageType type = ParseMessageType(message);

			// In case of a player action, also provide the info 
			switch (type)
			{
				case MessageType.PlayerJoin:
					return new OutputParseResult(text, message, type, ParsePlayerJoin(message));
				case MessageType.PlayerLeave:
					return new OutputParseResult(text, message, type, ParsePlayerLeave(message));
				case MessageType.PlayerKick:
					return new OutputParseResult(text, message, type, ParsePlayerActionKick(message));
				case MessageType.PlayerBan:
					return new OutputParseResult(text, message, type, ParsePlayerActionBan(message));
				default:
					return new OutputParseResult(text, message, type);
			}
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
			if (Regex.IsMatch(text, RG_WARN + RG_WILDCARD, RegexOptions.IgnoreCase))
			{
				type = MessageType.Warning;
			}
				//[SEVERE] ...
			else if (Regex.IsMatch(text, RG_SEV + RG_WILDCARD, RegexOptions.IgnoreCase))
			{
				type = MessageType.Severe;
			}



				// LOGIN
				//[INFO] Bertware[/127.0.0.1:58189] logged in with entity id 27 at ([world] -1001.0479985318618, 2.0, 1409.300000011921)
				//[INFO] Bertware[/127.0.0.1:58260] logged in with entity id 0 at (-1001.0479985318618, 2.0, 1409.300000011921)
				//[INFO]  UUID of player Bertware is f0b27a3369394b25ab897aa4e4db83c1
				//[INFO]  Bertware[/127.0.0.1:51815] logged in with entity id 184 at ([world] 98.5, 64.0, 230.5)

			else if (Regex.IsMatch(
				text,
				RG_INFO + RG_SPACE + RG_PLAYER + RG_IP_BRACKET + " logged in with entity id",
				RegexOptions.IgnoreCase))
			{
				type = MessageType.PlayerJoin;
			}

				// Disconnect / leave
				//[INFO]  Bertware lost connection: Disconnected
				//[INFO]  Bertware left the game.
			else if (Regex.IsMatch(
				text,
				RG_INFO + RG_SPACE + RG_PLAYER + " lost connection: Disconnected",
				RegexOptions.IgnoreCase))
			{
				type = MessageType.PlayerLeave;
			}
				// Disconnect / kick
				//[INFO]  Bertware lost connection: test
				//[INFO]  Bertware left the game.
				//[INFO]  CONSOLE: Kicked player Bertware. With reason:
				//test
				//
				// [command sender]: Kicked player [player]. With reason: [newline] [Reason]
			else if (Regex.IsMatch(
				text,
				RG_INFO + RG_SPACE + RG_PLAYER + " lost connection: Kicked by",
				RegexOptions.IgnoreCase))
			{
				type = MessageType.PlayerKick;
			}
				//disconnect / ban
				//[INFO]  Bertware lost connection: Banned by admin.
				//[INFO]  Bertware left the game.
				//[INFO]  CONSOLE: Banned player bertware
			else if (Regex.IsMatch(
				text,
				RG_INFO + RG_SPACE + RG_PLAYER + " lost connection: Banned by",
				RegexOptions.IgnoreCase))
			{
				type = MessageType.PlayerBan;
			}
				// catch player left the game message
			else if (Regex.IsMatch(
				text,
				RG_INFO + RG_SPACE + RG_PLAYER + " left the game",
				RegexOptions.IgnoreCase))
			{
				type = MessageType.PlayerLeave;
			}

			else if (Regex.IsMatch(text, RG_INFO + RG_SPACE + "There are " + "\\d+" + "/" + "\\d+" + " players online:",
				RegexOptions.IgnoreCase))
			{
				type = MessageType.PlayerList;
			}

				// stacktraces
			else if (Regex.IsMatch(
				text,
				"^" + RG_SPACE + RG_STACKTRACE,
				RegexOptions.IgnoreCase))
			{
				type = MessageType.JavaStackTrace;
			}

				//TODO: Stacktraces (other formats) and java errors

				// all other text is info text
			else if (Regex.IsMatch(text, RG_INFO + ".*", RegexOptions.IgnoreCase))
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
			text = text.Trim();
			return text;
		}

		public virtual string FilterText(string text)
		{
			// fix harmless warning, users question this warning.
			text = Regex.Replace(text,
				"(.*)Unable to instantiate org\\.fusesource\\.jansi\\.WindowsAnsiOutputStream(.*)", "");


			// remove [minecraft] or [minecraft-server] tags, for better parsing
			text = Regex.Replace(text, "\\[minecraft(-server|)\\]", "", RegexOptions.IgnoreCase);

			// [User Authenticator #1/INFO] to [INFO]
			text = Regex.Replace(text, "User Authenticator #\\d/", "");
			// [Server thread/INFO] to [INFO]
			text = Regex.Replace(text, "Server (shutdown |)thread/", "");
			text = Regex.Replace(text, "\\]:", "]");
			text = text.Trim();
			return text;
		}

		public virtual PlayerActionJoin ParsePlayerJoin(string text)
		{
			//[INFO] Bertware[/127.0.0.1:58189] logged in with entity id 27 at ([world] -1001.0479985318618, 2.0, 1409.300000011921)
			//[INFO] Bertware[/127.0.0.1:58260] logged in with entity id 0 at (-1001.0479985318618, 2.0, 1409.300000011921)
			//[INFO]  UUID of player Bertware is f0b27a3369394b25ab897aa4e4db83c1
			//[INFO]  Bertware[/127.0.0.1:51815] logged in with entity id 184 at ([world] 98.5, 64.0, 230.5)
			PlayerActionJoin join = new PlayerActionJoin();
			text = Regex.Replace(text, RG_INFO, "", RegexOptions.IgnoreCase);
			join.PlayerName = Regex.Match(text, RG_PLAYER).Value.Trim();
			join.Ip = Regex.Match(text, RG_IP_NOPORT).Value;

			return join;
		}

		public virtual PlayerActionLeave ParsePlayerLeave(string text)
		{
			//[INFO]  Bertware lost connection: Disconnected
			//[INFO]  Bertware left the game.
			PlayerActionLeave leave = new PlayerActionLeave
			{
				PlayerName = Regex.Match(text, RG_FSPACE + RG_PLAYER).Value.Trim(),
				Details = Regex.Match(text, ":" + RG_WILDCARD + RG_EOL).Value.TrimStart(':').Trim()
			};
			return leave;
		}

		public virtual PlayerActionKick ParsePlayerActionKick(string text)
		{
			//[INFO]  Bertware lost connection: test
			//[INFO]  Bertware left the game.
			//[INFO]  CONSOLE: Kicked player Bertware. With reason:
			//test
			PlayerActionKick leave = new PlayerActionKick
			{
				PlayerName = Regex.Match(text, RG_FSPACE + RG_PLAYER).Value.Trim(),
				Details = Regex.Match(text, ":" + RG_WILDCARD + RG_EOL).Value.TrimStart(':').Trim()
			};
			return leave;
		}

		public virtual PlayerActionBan ParsePlayerActionBan(string text)
		{
			//[INFO]  Bertware lost connection: Banned by admin.
			//[INFO]  Bertware left the game.
			//[INFO]  CONSOLE: Banned player bertware
			PlayerActionBan leave = new PlayerActionBan
			{
				PlayerName = Regex.Match(text, RG_FSPACE + RG_PLAYER).Value.Trim(),
				Details = Regex.Match(text, ":" + RG_WILDCARD + RG_EOL).Value.TrimStart(':').Trim()
			};
			return leave;
		}

		public virtual PlayerActionIpBan ParsePlayerActionIpBan(string text)
		{
			return new PlayerActionIpBan();
		}

		public bool CanFetchRecommendedVersion { get; protected set; }

		public bool CanFetchBetaVersion { get; protected set; }
		public bool CanFetchDevVersion { get; protected set; }

		public bool CanDownloadRecommendedVersion { get; protected set; }

		public bool CanDownloadBetaVersion { get; protected set; }
		public bool CanDownloadDevVersion { get; protected set; }
		public bool CanGetCurrentVersion { get; protected set; }

		public virtual string FetchRecommendedVersion { get; protected set; }

		public virtual string FetchBetaVersion { get; protected set; }

		public virtual string FetchDevVersion { get; protected set; }

		public virtual string FetchRecommendedVersionUiString
		{
			get { return FetchRecommendedVersion; }
		}

		public virtual string FetchBetaVersionUiString
		{
			get { return FetchBetaVersion; }
		}

		public virtual string FetchDevVersionUiString
		{
			get { return FetchDevVersion; }
		}


		public virtual bool DownloadRecommendedVersion(string targetfile)
		{
			return false;
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
			return "unknown";
		}

		public virtual string GetCurrentVersionUiString(string file)
		{
			return GetCurrentVersion(file);
		}
	}
}