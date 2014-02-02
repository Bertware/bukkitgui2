using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bukkitgui2.MinecraftInterop.OutputHandler.PlayerActions;

namespace bukkitgui2.MinecraftInterop.OutputHandler
{
	class MessageParseResult
	{
		/// <summary>
		/// The time the message was received
		/// </summary>
		public DateTime Time { get; private set; }

		/// <summary>
		/// The text in the message
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// The text in the message, without the timestamp and prefixes
		/// </summary>
		public string Message { get; set; }
		
		/// <summary>
		/// The type of message
		/// </summary>
		public MessageType Type { get; set; }
		
		/// <summary>
		/// If the message type was a player action, the action object
		/// </summary>
		public IPlayerAction Action { get; set; }

	}
}
