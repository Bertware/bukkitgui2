// LogEntry.cs in bukkitgui2/bukkitgui2
// Created 2014/08/31
// ©Bertware, visit http://bertware.net

namespace Net.Bertware.Bukkitgui2.Core.Logging
{
	internal class LogEntry
	{
		private readonly string _timestamp;
		private readonly LogLevel _level;
		private readonly string _origin;
		private readonly string _message;
		private readonly string _details = "";

		public LogEntry(LogLevel level, string origin, string message, string details, string timestamp)
		{
			_level = level;
			_origin = origin;
			_message = message;
			_details = details;
			_timestamp = timestamp;
		}

		public override string ToString()
		{
			return _timestamp + "\t[" + _level + "]\t[" + _origin + "]\t" + _message +
			       ((string.IsNullOrEmpty(_details)) ? "" : " (" + _details + ");");
		}
	}
}