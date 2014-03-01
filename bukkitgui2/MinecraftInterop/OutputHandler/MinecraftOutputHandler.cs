using System;
using System.Collections.Generic;
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


		public delegate void MessageParsedEventHandler(string text, MessageParseResult messageParseResult);
		/// <summary>
		/// Raised when any output is parsed
		/// </summary>
		public static event MessageParsedEventHandler MessageParsed;
		private static void RaiseMessageParsedEvent(string text, MessageParseResult messageParseResult)
		{
			MessageParsedEventHandler handler = MessageParsed;
			if (handler != null)
			{
				handler(text,messageParseResult);
			}
		}

		public delegate void MessageReceivedEventHandler(string text, MessageParseResult messageParseResult);
		/// <summary>
		/// Raised when an info message is received
		/// </summary>
		public static event MessageReceivedEventHandler InfoMessageReceived;
		private static void RaiseInfoMessageReceivedEvent(string text, MessageParseResult messageParseResult)
		{
			MessageReceivedEventHandler handler = InfoMessageReceived;
			if (handler != null)
			{
				handler(text,messageParseResult);
			}
		}

		
		/// <summary>
		/// Raised when a warning message is received
		/// </summary>
		public static event MessageReceivedEventHandler WarningMessageReceived;
		private static void RaiseWarningMessageReceivedEvent(string text, MessageParseResult messageParseResult)
		{
			MessageReceivedEventHandler handler = WarningMessageReceived;
			if (handler != null)
			{
				handler(text, messageParseResult);
			}
		}

		
		/// <summary>
		/// Raised when a severe message is received
		/// </summary>
		public static event MessageReceivedEventHandler SevereMessageReceived;
		private static void RaiseSevereMessageReceivedEvent(string text, MessageParseResult messageParseResult)
		{
			MessageReceivedEventHandler handler = SevereMessageReceived;
			if (handler != null)
			{
				handler(text, messageParseResult);
			}
		}

		
		/// <summary>
		/// Raised when a Java status/error message is received
		/// </summary>
		public static event MessageReceivedEventHandler JavaStatusMessageReceived;
		private static void RaiseJavaStatusMessageReceivedEvent(string text, MessageParseResult messageParseResult)
		{
			MessageReceivedEventHandler handler = JavaStatusMessageReceived;
			if (handler != null)
			{
				handler(text, messageParseResult);
			}
		}

		
		/// <summary>
		/// Raised when a Java stacktrace message is received
		/// </summary>
		public static event MessageReceivedEventHandler JavaStackStraceMessageReceived;
		private static void RaiseJavaStackStraceMessageReceivedEvent(string text, MessageParseResult messageParseResult)
		{
			MessageReceivedEventHandler handler = JavaStackStraceMessageReceived;
			if (handler != null)
			{
				handler(text, messageParseResult);
			}
		}

		
		/// <summary>
		/// Raised when an unknown message is received
		/// </summary>
		public static event MessageReceivedEventHandler UnknownMessageReceived;
		private static void RaiseUnknownMessageReceivedEvent(string text, MessageParseResult messageParseResult)
		{
			MessageReceivedEventHandler handler = UnknownMessageReceived;
			if (handler != null)
			{
				handler(text, messageParseResult);
			}
		}

		public delegate void PlayerJoinEventHandler(
			string text, PlayerActions.IPlayerAction playerAction, MessageParseResult messageParseResult);

		public static event PlayerJoinEventHandler PlayerJoin;

		public delegate void PlayerLeaveEventHandler(
			string text, PlayerActions.IPlayerAction playerAction, MessageParseResult messageParseResult);

		public static event PlayerLeaveEventHandler PlayerLeave;

		public delegate void PlayerKickEventHandler(
			string text, PlayerActions.IPlayerAction playerAction, MessageParseResult messageParseResult);

		public static event PlayerKickEventHandler PlayerKick;

		public delegate void PlayerBanEventHandler(
			string text, PlayerActions.IPlayerAction playerAction, MessageParseResult messageParseResult);

		public static event PlayerBanEventHandler PlayerBan;

		public delegate void PlayerIpBanEventHandler(
			string text, PlayerActions.IPlayerAction playerAction, MessageParseResult messageParseResult);

		public static event PlayerIpBanEventHandler PlayerIpBan;


		public delegate void PlayerListReceivedEventHandler(
			string text, MessageParseResult messageParseResult, Dictionary<string, string> onlinePlayerList);

		public static event PlayerListReceivedEventHandler PlayerListReceived;

		/// <summary>
		/// Handle server output, raise all events that should be raised
		/// </summary>
		/// <param name="text">output text to handle</param>
		/// <param name="server">the server that should handle the output</param>
		public static void HandleOutput(IMinecraftServer server, string text)
		{
			RaiseOutputReceivedEvent(text);

			MessageParseResult result = server.ParseOutput(text);

			RaiseMessageParsedEvent(text, result);

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
					PlayerJoin(text, result.Action, result);
					break;
				case MessageType.PlayerLeave:
					PlayerLeave(text, result.Action, result);
					break;
				case MessageType.PlayerKick:
					PlayerKick(text, result.Action, result);
					break;
				case MessageType.PlayerBan:
					PlayerBan(text, result.Action, result);
					break;
				case MessageType.PlayerIpBan:
					PlayerIpBan(text, result.Action, result);
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