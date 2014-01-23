using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bukkitgui2.Core.Configuration
{
    interface IConfig
    {
		/// <summary>
		/// Indicates wether this component is initialized and can be used
		/// </summary>
         bool isInitialized
        {
            get;
        }

		/// <summary>
		/// Create or open needed files, create streams if needed, do everything what's needed before a Log() call can be made
		/// </summary>
		 void Initialize();

		/// <summary>
		/// Stop the logger, dispose used sources
		/// </summary>
		 void Dispose();

		/// <summary>
		/// Load a config file
		/// </summary>
		/// <param name="location"></param>
		 void LoadFile(string location="");

		/// <summary>
		/// Save a config file
		/// </summary>
		/// <param name="location"></param>
		 void SaveFile(string location = "");
		
		/// <summary>
		/// Read a string value from config
		/// </summary>
		/// <param name="key">The config key</param>
		/// <param name="defaultValue">The default value if the element doesn't exist</param>
         /// <returns>Returns the requested value</returns>
		 string ReadString(string key, string defaultValue = "");

		/// <summary>
		/// Write a string value to config
		/// </summary>
		/// <param name="key">The config key</param>
		/// <param name="value">The value to write</param>
         /// <returns>Returns true if operation succeeded</returns>
		 bool WriteString(string key, string value);

		/// <summary>
		/// Read an integer value from config
		/// </summary>
		/// <param name="key">The config key</param>
		/// <param name="defaultValue">The default value if the element doesn't exist</param>
         /// <returns>Returns the requested value</returns>
		 Int32 ReadInt(string key, Int32 defaultValue = 0);

		/// <summary>
		/// Write an integer value to config
		/// </summary>
		/// <param name="key">The config key</param>
		/// <param name="value">The value to write</param>
         /// <returns>Returns true if operation succeeded</returns>
		 bool WriteInt(string key, Int32 value);

    }
}
