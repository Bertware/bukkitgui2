// MinecraftOutputHandler.cs in bukkitgui2/bukkitgui2
// Created 2014/02/05
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MetroFramework;
using Net.Bertware.Bukkitgui2.AddOn.Starter;
using Net.Bertware.Bukkitgui2.Core.Translation;
using Net.Bertware.Bukkitgui2.MinecraftInterop.OutputHandler.PlayerActions;
using Net.Bertware.Bukkitgui2.MinecraftServers;
using Net.Bertware.Bukkitgui2.UI;

namespace Net.Bertware.Bukkitgui2.MinecraftInterop.OutputHandler
{
	/// <summary>
	///     All output is handled through here. Even during server restarts event subscriptions are remembered, this class will
	///     handle the output through the correct server
	/// </summary>
	internal static class MinecraftOutputHandler
	{
		public delegate void OutputReceivedEventHandler(string text);

		/// <summary>
		///     Raised when any output is received
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
		///     Raised when any output is parsed
		/// </summary>
		public static event OutputParsedEventHandler OutputParsed;

		private static void RaiseOutputParsedEvent(string text, OutputParseResult outputParseResult)
		{
			OutputParsedEventHandler handler = OutputParsed;
			if (handler != null)
			{
				handler(text, outputParseResult);
			}
		}

		/// <summary>
		///     Raised when an info message is received
		/// </summary>
		public static event OutputParsedEventHandler InfoMessageReceived;

		private static void RaiseInfoMessageReceivedEvent(string text, OutputParseResult outputParseResult)
		{
			OutputParsedEventHandler handler = InfoMessageReceived;
			if (handler != null)
			{
				handler(text, outputParseResult);
			}
		}


		/// <summary>
		///     Raised when a warning message is received
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
		///     Raised when a severe message is received
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
		///     Raised when a Java status/error message is received
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
		///     Raised when a Java stacktrace message is received
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
		///     Raised when an unknown message is received
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

		public delegate void PlayerEventHandler(
			string text, OutputParseResult outputParseResult, IPlayerAction playerAction);

		/// <summary>
		///     Raised when a player joins
		/// </summary>
		public static event PlayerEventHandler PlayerJoin;

		private static void RaisePlayerJoinEvent(string text, OutputParseResult outputParseResult,
			IPlayerAction playerAction)
		{
			PlayerEventHandler handler = PlayerJoin;
			if (handler != null)
			{
				handler(text, outputParseResult, playerAction);
			}
		}

		/// <summary>
		///     Raised when a player leaves or disconnects
		/// </summary>
		public static event PlayerEventHandler PlayerLeave;

		private static void RaisePlayerLeaveEvent(string text, OutputParseResult outputParseResult,
			IPlayerAction playerAction)
		{
			PlayerEventHandler handler = PlayerLeave;
			if (handler != null)
			{
				handler(text, outputParseResult, playerAction);
			}
		}

		/// <summary>
		///     Raised when a player is kicked
		/// </summary>
		public static event PlayerEventHandler PlayerKick;

		private static void RaisePlayerKickEvent(string text, OutputParseResult outputParseResult,
			IPlayerAction playerAction)
		{
			PlayerEventHandler handler = PlayerKick;
			if (handler != null)
			{
				handler(text, outputParseResult, playerAction);
			}
		}

		/// <summary>
		///     Raised when a player is banned
		/// </summary>
		public static event PlayerEventHandler PlayerBan;

		private static void RaisePlayerBanEvent(string text, OutputParseResult outputParseResult,
			IPlayerAction playerAction)
		{
			PlayerEventHandler handler = PlayerBan;
			if (handler != null)
			{
				handler(text, outputParseResult, playerAction);
			}
		}

		/// <summary>
		///     Raised when an ip is banned
		/// </summary>
		public static event PlayerEventHandler PlayerIpBan;

		private static void RaisePlayerIpBanEvent(string text, OutputParseResult outputParseResult,
			IPlayerAction playerAction)
		{
			PlayerEventHandler handler = PlayerIpBan;
			if (handler != null)
			{
				handler(text, outputParseResult, playerAction);
			}
		}

		/// <summary>
		///     Handle the output from a /list command
		/// </summary>
		/// <param name="text">The text that was received</param>
		/// <param name="outputParseResult">The parse result</param>
		/// <param name="playersDictionary">Dictionary containing the player names as key, the names with their prefixes as value</param>
		public delegate void PlayerListReceivedEventHandler(
			string text, OutputParseResult outputParseResult, Dictionary<string, string> playersDictionary);

		public static event PlayerListReceivedEventHandler PlayerListReceived;

		/// <summary>
		///     Handle server output, raise all events that should be raised
		/// </summary>
		/// <param name="text">output text to handle</param>
		/// <param name="server">the server that should handle the output</param>
		/// <param name="fromStandardErrorOut">Is this message received on the error stream?</param>
		public static void HandleOutput(IMinecraftServer server, string text, Boolean fromStandardErrorOut = false)
		{
			RaiseOutputReceivedEvent(text);

			OutputParseResult result = server.ParseOutput(text);
			if (result == null) return;

			RaiseOutputParsedEvent(text, result);

			switch (result.Type)
			{
				case MessageType.Info:
					RaiseInfoMessageReceivedEvent(text, result);

					// detect an issued stop command (so the GUI knows this isn't a crash)
					if (result.Message == "[INFO] Stopping server" || result.Message == "[INFO] Stopping the server")
						ProcessHandler.ProcessHandler.MarkServerAsStopping();

					break;

				case MessageType.Warning:
					RaiseWarningMessageReceivedEvent(text, result);
					CheckErrorCause(result.Message);
					//failed to bind to port comes on standardout, so we need to check anyway
					break;

				case MessageType.Severe:
					RaiseSevereMessageReceivedEvent(text, result);
					CheckErrorCause(result.Message);
					break;

				case MessageType.JavaStackTrace:
					RaiseJavaStackStraceMessageReceivedEvent(text, result);
					if (fromStandardErrorOut) CheckErrorCause(result.Message);
					break;
				case MessageType.JavaStatus:
					RaiseJavaStatusMessageReceivedEvent(text, result);
					if (fromStandardErrorOut) CheckErrorCause(result.Message);
					break;
				case MessageType.PlayerJoin:
					RaisePlayerJoinEvent(text, result, result.Action);
					break;
				case MessageType.PlayerLeave:
					RaisePlayerLeaveEvent(text, result, result.Action);
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
					if (fromStandardErrorOut) CheckErrorCause(result.Message);
					break;
			}
		}

		/// <summary>
		///     Check for a bunch of common errors, like port already in use or failiure to start java
		/// </summary>
		/// <param name="text"></param>
		private static void CheckErrorCause(string text)
		{
			if (text.Equals("Error: Unable to access jarfile"))
			{
				MetroMessageBox.Show(MainForm.Reference,
					Translator.Tr(
						"Java couldn't open the .jar file you provided in the superstart tab. Make sure the path is correct and the file is valid. Try downloading the file again, and make sure the file is accessible."),
					Translator.Tr("Unable to access .jar file"), MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (!ProcessHandler.ProcessHandler.ServerProcess.HasExited &&
			    (Equals(text, "[WARN] Perhaps a server is already running on that port?") ||
			     Equals(text, "[WARN] The exception was: java.net.BindException: Address already in use: bind")))
			{
				MetroMessageBox.Show(MainForm.Reference,
					Translator.Tr(
						"The server could not be started, because the port is already in use. Make sure there are no other servers running on this port." +
						Environment.NewLine +
						"An incorrectly stopped server could cause this. Make sure you have your server-ip= blank (in server.properties)." +
						Environment.NewLine +
						"Otherwise rebooting or logging out will resolve this issue. ") + Environment.NewLine +
					Environment.NewLine + "The exception was: java.net.BindException: Address already in use: bind",
					Translator.Tr("Cannot bind to port"), MessageBoxButtons.OK, MessageBoxIcon.Error);
				Starter.KillServer();

				//if (MetroMessageBox.Show(MainForm.Reference,
				//	Translator.Tr("Do you want to kill all java processes, in an attempt to start the server?") +
				//	Environment.NewLine +
				//	Translator.Tr("WARNING! killing all java instances is on your own risk, and can lead to data corruption."),
				//	Translator.Tr("Kill all java instances?"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
				//	DialogResult.Yes)
				//{
				//	Starter.KillAllJava();
				//	Starter.StartServer();
				//}
			}
		}
	}
}