// Config.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/06/22 12:34
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Net.Bertware.Bukkitgui2.Core.FileLocation;
using Net.Bertware.Bukkitgui2.Core.Logging;
using Net.Bertware.Bukkitgui2.Core.Util;
using Net.Bertware.Bukkitgui2.UI;

namespace Net.Bertware.Bukkitgui2.Core.Configuration
{
    /// <summary>
    ///     XML config support, config is cached during runtime
    /// </summary>
    internal static class Config
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

            MainForm form = (MainForm) Control.FromHandle(Share.MainFormHandle);
            form.Closing += HandleExit;
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
                location = Fl.SafeLocation(RequestFile.Config) + CteFileName;
            }

            _filepath = location;


            Logger.Log(LogLevel.Info, "Config", "Loading file", _filepath);

            if (!File.Exists(_filepath))
            {
                Logger.Log(LogLevel.Info, "Config", "Creating config file");
                DirectoryInfo dirInfo = new FileInfo(_filepath).Directory;
                if (dirInfo != null)
                {
                    string parent = dirInfo.ToString();
                    FsUtil.CreateDirectoryIfNotExists(parent);
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
                location = Fl.Location(RequestFile.Config) + CteFileName;
            }

            if (_cache.Count == 0)
            {
                Logger.Log(LogLevel.Debug, "Config", "Didn't save file: nothing to save");
                return;
            }

            _filepath = location;

            Logger.Log(LogLevel.Info, "Config", "Saving file", _filepath);

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
            id = id.ToLower();

            if (_cache.ContainsKey(id))
            {
                string value = _cache[id];
                Logger.Log(LogLevel.Info, "Config", "Read value", id + ":" + value);
                return value;
            }

            _cache.Add(id, defaultValue);
            Logger.Log(LogLevel.Info, "Config", "Read value", id + ":" + defaultValue + " (default)");
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
            id = id.ToLower();

            Logger.Log(LogLevel.Info, "Config", "Saving value", id + ":" + value);

            if (_cache.ContainsKey(id))
            {
                _cache[id] = value;
            }
            else
            {
                _cache.Add(id, value);
            }
            Logger.Log(LogLevel.Info, "Config", "Saved value", id + ":" + value);
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
            id = id.ToLower();
            Logger.Log(LogLevel.Info, "Config", "Reading value", id);

            if (_cache.ContainsKey(id))
            {
                int value = int.Parse(_cache[id]);
                Logger.Log(LogLevel.Info, "Config", "Read value", id + ":" + value);
                return value;
            }

            _cache.Add(id, defaultValue.ToString(CultureInfo.InvariantCulture));
            Logger.Log(LogLevel.Info, "Config", "Read value", id + ":" + defaultValue + " (default)");
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
            id = id.ToLower();

            Logger.Log(LogLevel.Info, "Config", "Saving value", id + ":" + value);

            if (_cache.ContainsKey(id))
            {
                _cache[id] = value.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                _cache.Add(id, value.ToString(CultureInfo.InvariantCulture));
            }
            Logger.Log(LogLevel.Info, "Config", "Saved value", id + ":" + value);
            return true;
        }

        /// <summary>
        ///     Read a boolean value from config
        /// </summary>
        /// <param name="parent">The parent of the config key, to distinguish the origin of a config key</param>
        /// <param name="key">The config key</param>
        /// <param name="defaultValue">The default value if the element doesn't exist</param>
        /// <returns>Returns the requested value</returns>
        public static Boolean ReadBool(string parent, string key, Boolean defaultBooleanValue)
        {
            int defaultValue = 0;
            if (defaultBooleanValue) defaultValue = 1;

            if (!IsInitialized)
            {
                return defaultBooleanValue;
            }

            string id = parent + "_" + key;
            id = id.ToLower();
            Logger.Log(LogLevel.Info, "Config", "Reading value", id);

            if (_cache.ContainsKey(id))
            {
                int value = int.Parse(_cache[id]);
                Logger.Log(LogLevel.Info, "Config", "Read value", id + ":" + value);
                return (value == 1);
            }

            _cache.Add(id, defaultValue.ToString(CultureInfo.InvariantCulture));
            Logger.Log(LogLevel.Info, "Config", "Read value", id + ":" + defaultValue + " (default)");
            return defaultBooleanValue;
        }

        /// <summary>
        ///     Write a boolean value to config
        /// </summary>
        /// <param name="parent">The parent of the config key, to distinguish the origin of a config key</param>
        /// <param name="key">The config key</param>
        /// <param name="b">The boolean value to write</param>
        /// <returns>Returns true if operation succeeded</returns>
        public static bool WriteBool(string parent, string key, Boolean b)
        {
            int value = 0;
            if (b) value = 1;

            if (!IsInitialized)
            {
                return false;
            }
            string id = parent + "_" + key;
            id = id.ToLower();

            Logger.Log(LogLevel.Info, "Config", "Saving value", id + ":" + value);

            if (_cache.ContainsKey(id))
            {
                _cache[id] = value.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                _cache.Add(id, value.ToString(CultureInfo.InvariantCulture));
            }
            Logger.Log(LogLevel.Info, "Config", "Saved value", id + ":" + value);
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

            Logger.Log(LogLevel.Info, "Config", "Loading cache");
            XmlElement xmle = _xmldoc.DocumentElement;

            foreach (XmlElement entry in xmle.ChildNodes) //for each element, 
            {
                if (!(entry.Name == "xml" || entry.Name == "root"))
                {
                    newcache.Add(entry.Name, entry.InnerText);
                }
            }

            Logger.Log(LogLevel.Info, "Config", "Loaded cache: " + newcache.Count + " entries loaded");

            _cache = newcache;
        }

        private static void SaveCache()
        {
            if (_cache == null)
            {
                return;
            }


            Logger.Log(LogLevel.Info, "Config", "Saving cache");

            string newxml = "<xml>" + Environment.NewLine;

            foreach (KeyValuePair<string, string> entry in _cache) //for each element, 
            {
                newxml += "<" + entry.Key + ">" + entry.Value + "</" + entry.Key + ">" + Environment.NewLine;
            }
            newxml += "</xml>";
            _xmldoc.LoadXml(newxml);
            _xmldoc.Save(_filepath);
            Logger.Log(LogLevel.Info, "Config", "Saved cache");
        }
    }
}