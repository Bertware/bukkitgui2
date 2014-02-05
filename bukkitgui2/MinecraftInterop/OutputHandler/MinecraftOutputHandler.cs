using System.Collections.Generic;
using bukkitgui2.MinecraftServers;

namespace bukkitgui2.MinecraftInterop.OutputHandler
{
	/// <summary>
	/// All output is handled through here. Even during server restarts event subscriptions are remembered, this class will handle the output through the correct server
	/// </summary>
	internal static class MinecraftOutputHandler
	{

		public delegate void MessageReceivedEventHandler(string text);
		/// <summary>
		/// Raised when any output is received
		/// </summary>
		public static event MessageReceivedEventHandler MessageReceived;

		public delegate void MessageParsedEventHandler(string text, MessageParseResult messageParseResult);
		/// <summary>
		/// Raised when any output is parsed
		/// </summary>
		public static event MessageParsedEventHandler MessageParsed;

		public delegate void InfoMessageReceivedEventHandler(string text, MessageParseResult messageParseResult);
		/// <summary>
		/// Raised when an info message is received
		/// </summary>
		public static event InfoMessageReceivedEventHandler InfoMessageReceived;

		public delegate void WarningMessageReceivedEventHandler(string text, MessageParseResult messageParseResult);
		/// <summary>
		/// Raised when a warning message is received
		/// </summary>
		public static event WarningMessageReceivedEventHandler WarningMessageReceived;

		public delegate void SevereMessageReceivedEventHandler(string text, MessageParseResult messageParseResult);
		/// <summary>
		/// Raised when a severe message is received
		/// </summary>
		public static event SevereMessageReceivedEventHandler SevereMessageReceived;

		public delegate void JavaStatusMessageReceivedEventHandler(string text, MessageParseResult messageParseResult);
		/// <summary>
		/// Raised when a Java status/error message is received
		/// </summary>
		public static event JavaStatusMessageReceivedEventHandler JavaStatusMessageReceived;

		public delegate void JavaStackStraceMessageReceivedEventHandler(string text, MessageParseResult messageParseResult);
		/// <summary>
		/// Raised when a Java stacktrace message is received
		/// </summary>
		public static event JavaStackStraceMessageReceivedEventHandler JavaStackStraceMessageReceived;

		public delegate void UnknownMessageReceivedEventHandler(string text, MessageParseResult messageParseResult);
		/// <summary>
		/// Raised when an unknown message is received
		/// </summary>
		public static event UnknownMessageReceivedEventHandler UnknownMessageReceived;

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
			MessageReceived(text);

			MessageParseResult result = server.ParseOutput(text);

			MessageParsed(text, result);

			switch (result.Type)
			{
				case MessageType.Info:
					InfoMessageReceived(text, result);
					break;

				case MessageType.Warning:
					WarningMessageReceived(text, result);
					break;

				case MessageType.Severe:
					SevereMessageReceived(text, result);
					break;

				case MessageType.JavaStackTrace:
					JavaStackStraceMessageReceived(text, result);
					break;
				case MessageType.JavaStatus:
					JavaStatusMessageReceived(text, result);
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
					UnknownMessageReceived(text, result);
					break;
			}
		}
	}
}