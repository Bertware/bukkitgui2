using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace bukkitgui2.Core.Logging
{
	class FileLogger : ILogger
	{

        private bool _isInitialized = false;

        /// <summary>
        /// Indicates wether this component is initialized and can be used
        /// </summary>
        bool ILogger.isInitialized
        {
            get { return _isInitialized; }
        }

        /// <summary>
        /// Create or open needed files, create streams if needed, do everything what's needed before a Log() call can be made
        /// </summary>
        void ILogger.Initialize()
        { 
        }

        /// <summary>
        /// Stop the logger, dispose used sources
        /// </summary>      
        void ILogger.Dispose()
        { 
        }

        /// <summary>
        /// Log a message to the logger
        /// </summary>
        /// <param name="level">Indicates how severe the message is. </param>
        /// <param name="origin">The class that called the log() command</param>
        /// <param name="message">The message to log</param>
        /// <param name="details">optional details, for example the message of an exception</param>
        void ILogger.Log(LogLevel level, string origin, string message, string details)
        {
           ///Always log to console, there are no dependencies for this
            string debug_line= this.TimeStamp() + " " +  this.FormatLevel(level) + " " +  origin + " : " + message + " ("+ details +")" + ";";
            Debug.WriteLine(debug_line);

            /// if initialized, also log to file
            if (_isInitialized)
            {
            
            }

        }

        /// <summary>
        /// Save the log file to a given location
        /// </summary>
        /// <param name="savelocation">The location to save the log file. If empty default location will be used</param>
        void ILogger.SaveFile(string savelocation)
        {
        }

        private string TimeStamp()
        {
            return "[" + DateTime.Now.ToLongTimeString() + "]";
        }

        private string FormatLevel(LogLevel level)
        {
            return "[" + level.ToString() + "]";
        }


	}
}
