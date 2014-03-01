using System.Collections.Generic;
using Bukkitgui2.MinecraftInterop.OutputHandler.PlayerActions;
using Bukkitgui2.MinecraftServers;

namespace Bukkitgui2.MinecraftInterop.OutputHandler
{
	/// <summary>
	/// All output is handled through here. Even during server restarts event subscriptions are remembered, this class will handle the output through the correct server
	/// </summary>
	internal static class MinecraftOutputHandler
	{

		public delegate void OutputReceivedEventHandler(string text);
		/// <summary>
		/// Raised when any output is received
		/// </summary>
		public static event OutputReceivedEventHandler OutputReceived;
		private static void RaiseOutputReceivedEvent(string text)
		{
			OutputReceivedEventHandler handler = OutputReceived;
			if (handler != null)
			{
				handler(text);
			}
		}


		public delegate void OutputParsedEventHandler(string text, OutputParseResult outputParseResult);
		/// <summary>
		/// Raised when any output is parsed
		/// </summary>
		public static event OutputParsedEventHandler OutputParsed;
		private static void RaiseOutputParsedEvent(string text, OutputParseResult outputParseResult)
		{
			OutputParsedEventHandler handler = OutputParsed;
			if (handler != null)
			{
				handler(text,outputParseResult);
			}
		}

		/// <summary>
		/// Raised when an info message is received
		/// </summary>
		public static event OutputParsedEventHandler InfoMessageReceived;
		private static void RaiseInfoMessageReceivedEvent(string text, OutputParseResult outputParseResult)
		{
			OutputParsedEventHandler handler = InfoMessageReceived;
			if (handler != null)
			{
				handler(text,outputParseResult);
			}
		}

		
		/// <summary>
		/// Raised when a warning message is received
		/// </summary>
		public static event OutputParsedEventHandler WarningMessageReceived;
		private static void RaiseWarningMessageReceivedEvent(string text, OutputParseResult outputParseResult)
		{
			OutputParsedEventHandler handler = WarningMessageReceived;
			if (handler != null)
			{
				handler(text, outputParseResult);
			}
		}

		
		/// <summary>
		/// Raised when a severe message is received
		/// </summary>
		public static event OutputParsedEventHandler SevereMessageReceived;
		private static void RaiseSevereMessageReceivedEvent(string text, OutputParseResult outputParseResult)
		{
			OutputParsedEventHandler handler = SevereMessageReceived;
			if (handler != null)
			{
				handler(text, outputParseResult);
			}
		}

		
		/// <summary>
		/// Raised when a Java status/error message is received
		/// </summary>
		public static event OutputParsedEventHandler JavaStatusMessageReceived;
		private static void RaiseJavaStatusMessageReceivedEvent(string text, OutputParseResult outputParseResult)
		{
			OutputParsedEventHandler handler = JavaStatusMessageReceived;
			if (handler != null)
			{
				handler(text, outputParseResult);
			}
		}

		
		/// <summary>
		/// Raised when a Java stacktrace message is received
		/// </summary>
		public static event OutputParsedEventHandler JavaStackStraceMessageReceived;
		private static void RaiseJavaStackStraceMessageReceivedEvent(string text, OutputParseResult outputParseResult)
		{
			OutputParsedEventHandler handler = JavaStackStraceMessageReceived;
			if (handler != null)
			{
				handler(text, outputParseResult);
			}
		}

		
		/// <summary>
		/// Raised when an unknown message is received
		/// </summary>
		public static event OutputParsedEventHandler UnknownMessageReceived;
		private static void RaiseUnknownMessageReceivedEvent(string text, OutputParseResult outputParseResult)
		{
			OutputParsedEventHandler handler = UnknownMessageReceived;
			if (handler != null)
			{
				handler(text, outputParseResult);
			}
		}

		public delegate void PlayerEventHandler(string text, OutputParseResult outputParseResult, IPlayerAction playerAction);

		/// <summary>
		/// Raised when a player joins
		/// </summary>
		public static event PlayerEventHandler PlayerJoin;
		private static void RaisePlayerJoinEvent(string text, OutputParseResult outputParseResult, IPlayerAction playerAction)
		{
			PlayerEventHandler handler = PlayerJoin;
			if (handler != null)
			{
				handler(text, outputParseResult,playerAction);
			}
		}

		/// <summary>
		/// Raised when a player leaves or disconnects
		/// </summary>
		public static event PlayerEventHandler PlayerLeave;
		private static void RaisePlayerLeaveEvent(string text, OutputParseResult outputParseResult, IPlayerAction playerAction)
		{
			PlayerEventHandler handler = PlayerLeave;
			if (handler != null)
			{
				handler(text, outputParseResult, playerAction);
			}
		}

		/// <summary>
		/// Raised when a player is kicked
		/// </summary>
		public static event PlayerEventHandler PlayerKick;
		private static void RaisePlayerKickEvent(string text, OutputParseResult outputParseResult, IPlayerAction playerAction)
		{
			PlayerEventHandler handler = PlayerKick;
			if (handler != null)
			{
				handler(text, outputParseResult, playerAction);
			}
		}

		/// <summary>
		/// Raised when a player is banned
		/// </summary>
		public static event PlayerEventHandler PlayerBan;
		private static void RaisePlayerBanEvent(string text, OutputParseResult outputParseResult, IPlayerAction playerAction)
		{
			PlayerEventHandler handler = PlayerBan;
			if (handler != null)
			{
				handler(text, outputParseResult, playerAction);
			}
		}

		/// <summary>
		/// Raised when an ip is banned
		/// </summary>
		public static event PlayerEventHandler PlayerIpBan;
		private static void RaisePlayerIpBanEvent(string text, OutputParseResult outputParseResult, IPlayerAction playerAction)
		{
			PlayerEventHandler handler = PlayerIpBan;
			if (handler != null)
			{
				handler(text, outputParseResult, playerAction);
			}
		}

		/// <summary>
		/// Handle the output from a /list command
		/// </summary>
		/// <param name="text">The text that was received</param>
		/// <param name="outputParseResult">The parse result</param>
		/// <param name="playersDictionary">Dictionary containing the player names as key, the names with their prefixes as value</param>
		public delegate void PlayerListReceivedEventHandler(string text, OutputParseResult outputParseResult, Dictionary<string, string> playersDictionary );
		public static event PlayerListReceivedEventHandler PlayerListReceived;

		/// <summary>
		/// Handle server output, raise all events that should be raised
		/// </summary>
		/// <param name="text">output text to handle</param>
		/// <param name="server">the server that should handle the output</param>
		public static void HandleOutput(IMinecraftServer server, string text)
		{
			RaiseOutputReceivedEvent(text);

			OutputParseResult result = server.ParseOutput(text);

			RaiseOutputParsedEvent(text, result);

			switch (result.Type)
			{
				case MessageType.Info:
					RaiseInfoMessageReceivedEvent(text, result);
					break;

				case MessageType.Warning:
					RaiseWarningMessageReceivedEvent(text, result);
					break;

				case MessageType.Severe:
					RaiseSevereMessageReceivedEvent(text, result);
					break;

				case MessageType.JavaStackTrace:
					RaiseJavaStackStraceMessageReceivedEvent(text, result);
					break;
				case MessageType.JavaStatus:
					RaiseJavaStatusMessageReceivedEvent(text, result);
					break;
				case MessageType.PlayerJoin:
					RaisePlayerJoinEvent(text, result, result.Action);
					break;
				case MessageType.PlayerLeave:
					RaisePlayerLeaveEvent(text,result, result.Action );
					break;
				case MessageType.PlayerKick:
					RaisePlayerKickEvent(text, result, result.Action);
					break;
				case MessageType.PlayerBan:
					RaisePlayerBanEvent(text, result, result.Action);
					break;
				case MessageType.PlayerIpBan:
					RaisePlayerIpBanEvent(text, result, result.Action);
					break;
				case MessageType.PlayerList:
					PlayerListReceived(text, result, new Dictionary<string, string>());
					break;
				default:
					RaiseUnknownMessageReceivedEvent(text, result);
					break;
			}
		}
	}
}