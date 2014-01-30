using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bukkitgui2.Core.Configuration
{
    class XmlConfig : IConfig
    {

        private bool _isInitialized = false;

        /// <summary>
		/// Indicates wether this component is initialized and can be used
		/// </summary>
        bool IConfig.isInitialized
        {
            get { return _isInitialized; }
        }

		/// <summary>
		/// Create or open needed files, create streams if needed, do everything what's needed before a Log() call can be made
		/// </summary>
        void IConfig.Initialize()
         { 
         }

		/// <summary>
		/// Stop the logger, dispose used sources
		/// </summary>
        void IConfig.Dispose()
         { 
         }

		/// <summary>
		/// Load a config file
		/// </summary>
		/// <param name="location"></param>
        void IConfig.LoadFile(string location )
         { 
         }

		/// <summary>
		/// Save a config file
		/// </summary>
		/// <param name="location"></param>
        void IConfig.SaveFile(string location )
         { 
         }
		
		/// <summary>
		/// Read a string value from config
		/// </summary>
		/// <param name="key">The config key</param>
		/// <param name="defaultValue">The default value if the element doesn't exist</param>
        /// <returns>Returns the requested value</returns>
        string IConfig.ReadString(string parent, string key, string defaultValue)
         {
             return "";
         }

		/// <summary>
		/// Write a string value to config
		/// </summary>
		/// <param name="key">The config key</param>
		/// <param name="value">The value to write</param>
		/// <returns>Returns true if operation succeeded</returns>
        bool IConfig.WriteString(string parent, string key, string value)
         {
             return true;
        }

		/// <summary>
		/// Read an integer value from config
		/// </summary>
		/// <param name="key">The config key</param>
		/// <param name="defaultValue">The default value if the element doesn't exist</param>
        /// <returns>Returns the requested value</returns>
        Int32 IConfig.ReadInt(string parent, string key, Int32 defaultValue )
         {
             return 0;
         }

		/// <summary>
		/// Write an integer value to config
		/// </summary>
		/// <param name="key">The config key</param>
		/// <param name="value">The value to write</param>
        /// <returns>Returns true if operation succeeded</returns>
        bool IConfig.WriteInt(string parent, string key, Int32 value)
         {
             return true;
         }
    }
}
