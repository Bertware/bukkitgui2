using Bukkitgui2.Core.FileLocation;

namespace Bukkitgui2.Core.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Xml;

    /// <summary>
    ///     XML config support, config is cached during runtime
    /// </summary>
    static internal class Config
    {
        private const string CteFileName = "config.xml";

        private static string _filepath;

        private static XmlDocument _xmldoc;

        private static Dictionary<string, string> _cache;


        /// <summary>
        ///     Indicates wether this component is initialized and can be used
        /// </summary>
		public static bool IsInitialized { get; private set; }

        /// <summary>
        ///     Create or open needed files, create streams if needed, do everything what's needed before a Log() call can be made
        /// </summary>
		public static void Initialize()
        {
            LoadFile();
            IsInitialized = true;

            System.Windows.Forms.Application.ApplicationExit += HandleExit;
        }

        /// <summary>
        ///     Stop the logger, dispose used sources
        /// </summary>
        public static void Dispose()
        {
            SaveCache();
        }

        private static void HandleExit(object sender, EventArgs e)
        {
            Dispose(); //Will cause a save
        }

        /// <summary>
        ///     Load a config file
        /// </summary>
        /// <param name="location"></param>
		public static void LoadFile(string location = "")
        {
            if (string.IsNullOrEmpty(location))
            {
                location = DefaultFileLocation.Location(FileLocation.RequestFile.Config) + CteFileName;
            }

            _filepath = location;

            if (!File.Exists(_filepath))
            {
                DirectoryInfo dirInfo = new FileInfo(_filepath).Directory;
                if (dirInfo != null)
                {
                    string parent = dirInfo.ToString();
                    Util.FsUtil.CreateDirectoryIfNotExists(parent);
                }

                FileStream fs = File.Create(_filepath);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("<xml></xml>");
                sw.Close();
                fs.Close();
            }

            _xmldoc = new XmlDocument();
            _xmldoc.Load(_filepath);

            LoadCache(); //everything's cached, we're ready to go
        }

        /// <summary>
        ///     Save a config file
        /// </summary>
        /// <param name="location"></param>
		public static void SaveFile(string location = "")
        {
            if (string.IsNullOrEmpty(location))
            {
				location = DefaultFileLocation.Location(FileLocation.RequestFile.Config) + CteFileName;
            }

            if (_cache.Count == 0)
            {
                return;
            }

            _filepath = location;
            SaveCache();
        }

        /// <summary>
        ///     Read a string value from config
        /// </summary>
        /// <param name="parent">The parent of the config key, to distinguish the origin of a config key</param>
        /// <param name="key">The config key</param>
        /// <param name="defaultValue">The default value if the element doesn't exist</param>
        /// <returns>Returns the requested value</returns>
		public static string ReadString(string parent, string key, string defaultValue)
        {
            if (!IsInitialized)
            {
                return defaultValue;
            }

            string id = parent + "_" + key;

            if (_cache.ContainsKey(id))
            {
                return _cache[id];
            }

            _cache.Add(id, defaultValue);
            return defaultValue;
        }

        /// <summary>
        ///     Write a string value to config
        /// </summary>
        /// <param name="parent">The parent of the config key, to distinguish the origin of a config key</param>
        /// <param name="key">The config key</param>
        /// <param name="value">The value to write</param>
        /// <returns>Returns true if operation succeeded</returns>
		public static bool WriteString(string parent, string key, string value)
        {
            if (!IsInitialized)
            {
                return false;
            }

            string id = parent + "_" + key;

            if (_cache.ContainsKey(id))
            {
                _cache[id] = value;
            }
            else
            {
                _cache.Add(id, value);
            }

            return true;
        }

        /// <summary>
        ///     Read an integer value from config
        /// </summary>
        /// <param name="parent">The parent of the config key, to distinguish the origin of a config key</param>
        /// <param name="key">The config key</param>
        /// <param name="defaultValue">The default value if the element doesn't exist</param>
        /// <returns>Returns the requested value</returns>
		public static Int32 ReadInt(string parent, string key, Int32 defaultValue)
        {
            if (!IsInitialized)
            {
                return defaultValue;
            }

            string id = parent + "_" + key;

            if (_cache.ContainsKey(id))
            {
                return int.Parse(_cache[id]);
            }

            _cache.Add(id, defaultValue.ToString(CultureInfo.InvariantCulture));
            return defaultValue;
        }

        /// <summary>
        ///     Write an integer value to config
        /// </summary>
        /// <param name="parent">The parent of the config key, to distinguish the origin of a config key</param>
        /// <param name="key">The config key</param>
        /// <param name="value">The value to write</param>
        /// <returns>Returns true if operation succeeded</returns>
        public static bool WriteInt(string parent, string key, Int32 value)
        {
            if (!IsInitialized)
            {
                return false;
            }
            string id = parent + "_" + key;

            if (_cache.ContainsKey(id))
            {
                _cache[id] = value.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                _cache.Add(id, value.ToString(CultureInfo.InvariantCulture));
            }

            return true;
        }

        /// <summary>
        ///     Load the XMLDocument to the cache dictionary
        /// </summary>
		private static void LoadCache()
        {
            if (_xmldoc == null)
            {
                return;
            }

            Dictionary<string, string> newcache = new Dictionary<string, string>();

            foreach (XmlElement entry in _xmldoc.ChildNodes) //for each element, 
            {
                if (!(entry.Name == "xml" || entry.Name == "root"))
                {
                    newcache.Add(entry.Name, entry.Value);
                }
            }

            _cache = newcache;
        }

		private static void SaveCache()
        {
            if (_cache == null)
            {
                return;
            }

            string newxml = "<xml>" + Environment.NewLine;

            foreach (var entry in _cache) //for each element, 
            {
                newxml += "<" + entry.Key + ">" + entry.Value + "</" + entry.Key + ">" + Environment.NewLine;
            }
            newxml += "</xml>";
            _xmldoc.LoadXml(newxml);
            _xmldoc.Save(_filepath);
        }
    }
}