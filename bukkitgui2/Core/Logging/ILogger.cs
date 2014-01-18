using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bukkitgui2.Core.Logging
{
	/// <summary>
	/// Logs debug info from the application
	/// </summary>
	interface ILogger 
	{

		/// <summary>
		/// Private isInitialized variable to store the value that will be returned on the public get request
		/// </summary>
		private bool _isInitialized;
		
		/// <summary>
		/// True if this component is initialized and can be used
		/// </summary>
		public readonly bool isInitialized
		{
			get { return _isInitialized }
		}

		/// <summary>
		/// Indicates how severe the message is. 
		/// Debug is only shown as debug output.
		/// Info is meant for updates on what the program is doing
		/// Warning are handled errors where the GUI uses an alternative method to work around the issue
		/// Severe are handled errors where the GUI can't continue. The user is likely to see an error dialog and the operation is probably to be aborted.
		/// Critical is only used for unhandled errors and crashes.
		/// </summary>
		public enum LogLevel { Debug, Info, Warning, Severe, Critical };

		/// <summary>
		/// Create or open needed files, create streams if needed, do everything what's needed before a Log() call can be made
		/// </summary>
		public void Initialize();

		/// <summary>
		/// Stop the logger, dispose used sources
		/// </summary>
		public void Dispose();

		/// <summary>
		/// Log a message to the logger
		/// </summary>
		/// <param name="level">Indicates how severe the message is. </param>
		/// <param name="origin">The class that called the log() command</param>
		/// <param name="message">The message to log</param>
		/// <param name="details">optional details, for example the message of an exception</param>
		public void Log(LogLevel level, string origin, string message, string details = "");

		/// <summary>
		/// Save the log file to a given location
		/// </summary>
		/// <param name="savelocation">The location to save the log file. If empty default location will be used</param>
		public void SaveFile(string savelocation = "");


	}
}
