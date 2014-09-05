// Logger.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.Core.FileLocation;

namespace Net.Bertware.Bukkitgui2.Core.Logging
{
	public static class Logger
	{
		private static List<LogEntry> _entries;

		/// <summary>
		///     Indicates wether this component is initialized and can be used
		/// </summary>
		public static bool IsInitialized { get; private set; }

		/// <summary>
		///     Create or open needed files, create streams if needed, do everything what's needed before a Log() call can be made
		/// </summary>
		internal static void Initialize()
		{
			IsInitialized = true;
			_entries = new List<LogEntry>();
			Application.ApplicationExit += ((sender, e) => Dispose());
			AppDomain.CurrentDomain.UnhandledException += ((sender, e) => WriteUnhandledError(e));
		}


		/// <summary>
		///     Stop the logger, dispose used sources
		/// </summary>
		internal static void Dispose()
		{
			SaveFile();
		}

		/// <summary>
		///     Log a message to the logger
		/// </summary>
		/// <param name="level">Indicates how severe the message is. </param>
		/// <param name="origin">The class that called the log() command</param>
		/// <param name="message">The message to log</param>
		/// <param name="details">optional details, for example the message of an exception</param>
		public static void Log(LogLevel level, string origin, string message, string details = "")
		{
			LogEntry entry = new LogEntry(level, origin, message, details, TimeStamp());
			Debug.WriteLine(entry.ToString());

			//if initialized, also log to file
			if (IsInitialized)
			{
				_entries.Add(entry);
			}
		}

		/// <summary>
		///     Save the log file to the default location
		/// </summary>
		internal static void SaveFile()
		{
			SaveFile(Fl.SafeLocation(RequestFile.Log) + "bukkitgui.log");
		}

		/// <summary>
		///     Save the log file to a given location
		/// </summary>
		/// <param name="savelocation">The location to save the log file. If empty default location will be used</param>
		internal static void SaveFile(string savelocation)
		{
			using (StreamWriter sw = File.CreateText(savelocation))
			{
				foreach (LogEntry entry in _entries)
				{
					sw.WriteLine(entry.ToString());
				}
			}
		}

		private static string TimeStamp()
		{
			return "[" + DateTime.Now.ToLongTimeString() + "]";
		}

		/// <summary>
		///     Write an unhandled error to the log.
		/// </summary>
		/// <param name="e">The error object that should be logged.This contains all needed information.</param>
		/// <remarks>Livebug must be initialized before use</remarks>
		public static void WriteUnhandledError(UnhandledExceptionEventArgs e)
		{
			try
			{
				if (!IsInitialized)
					return;
				Log(LogLevel.Critical, "Logger", "Unhandled exception", e.ExceptionObject.ToString());
				//create the element
				if (e.ExceptionObject.ToString().Contains("System.Core"))
				{
					MessageBox.Show(".NET framework 3.5 is missing or corrupted. Please reinstall .NET 3.5", ".NET framework error",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				Trace.WriteLine("Severe error! could not write unhandled error to livebug!");
				Trace.WriteLine("exception:" + ex.Message);
				Trace.WriteLine("unhandled error:" + e.ExceptionObject);
			}
		}
	}

	/// <summary>
	///     Indicates how severe the message is.
	///     Debug is only shown as debug output.
	///     Info is meant for updates on what the program is doing
	///     Warning are handled errors where the GUI uses an alternative method to work around the issue
	///     Severe are handled errors where the GUI can't continue. The user is likely to see an error dialog and the operation
	///     is probably to be aborted.
	///     Critical is only used for unhandled errors and crashes.
	/// </summary>
	public enum LogLevel
	{
		Debug,
		Info,
		Warning,
		Severe,
		Critical
	};
}