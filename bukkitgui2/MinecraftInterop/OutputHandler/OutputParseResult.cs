// OutputParseResult.cs in bukkitgui2/bukkitgui2
// Created 2014/02/02
// Last edited at 2014/06/22 12:34
// ©Bertware, visit http://bertware.net

using System;
using Net.Bertware.Bukkitgui2.MinecraftInterop.OutputHandler.PlayerActions;

namespace Net.Bertware.Bukkitgui2.MinecraftInterop.OutputHandler
{
	public class OutputParseResult
	{
		/// <summary>
		///     The time the message was received
		/// </summary>
		public DateTime Time { get; private set; }

		/// <summary>
		///     The text in the message
		/// </summary>
		public string Text { get; private set; }

		/// <summary>
		///     The text in the message, without the timestamp and prefixes
		/// </summary>
		public string Message { get; private set; }

		/// <summary>
		///     The type of message
		/// </summary>
		public MessageType Type { get; private set; }

		/// <summary>
		///     If the message type was a player action, the action object
		/// </summary>
		public IPlayerAction Action { get; private set; }

		/// <summary>
		///     Create a new instance
		/// </summary>
		/// <param name="text">the output text</param>
		/// <param name="message">the output message, text without timestamp or tags</param>
		/// <param name="type">the message type</param>
		/// <param name="action">if any player action was described, the player action object</param>
		public OutputParseResult(string text, string message, MessageType type, IPlayerAction action = null)
		{
			Time = DateTime.Now;
			Text = text;
			Message = message;
			Type = type;
			Action = action;
		}
	}
}