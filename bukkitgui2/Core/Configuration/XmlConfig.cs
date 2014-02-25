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
    internal class XmlConfig : IConfig
    {
        private const string CteFileName = "config.xml";

        private string _filepath;

        private XmlDocument _xmldoc;

        private Dictionary<string, string> _cache;

        public XmlConfig()
        {
            this.isInitialized = false;
        }

        /// <summary>
        ///     Indicates wether this component is initialized and can be used
        /// </summary>
        public bool isInitialized { get; private set; }

        /// <summary>
        ///     Create or open needed files, create streams if needed, do everything what's needed before a Log() call can be made
        /// </summary>
        public void Initialize()
        {
            this.LoadFile();
            this.isInitialized = true;

            System.Windows.Forms.Application.ApplicationExit += this.HandleExit;
        }

        /// <summary>
        ///     Stop the logger, dispose used sources
        /// </summary>
        public void Dispose()
        {
            this.SaveCache();
        }

        private void HandleExit(object sender, EventArgs e)
        {
            this.Dispose(); //Will cause a save
        }

        /// <summary>
        ///     Load a config file
        /// </summary>
        /// <param name="location"></param>
        public void LoadFile(string location = "")
        {
            if (string.IsNullOrEmpty(location))
            {
                location = Share.FileLocation.Location(FileLocation.RequestFile.Config) + CteFileName;
            }

            this._filepath = location;

            if (!File.Exists(this._filepath))
            {
                DirectoryInfo dirInfo = new FileInfo(this._filepath).Directory;
                if (dirInfo != null)
                {
                    string parent = dirInfo.ToString();
                    Util.FsUtil.CreateDirectoryIfNotExists(parent);
                }

                FileStream fs = File.Create(this._filepath);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("<xml></xml>");
                sw.Close();
                fs.Close();
            }

            this._xmldoc = new XmlDocument();
            this._xmldoc.Load(this._filepath);

            this.LoadCache(); //everything's cached, we're ready to go
        }

        /// <summary>
        ///     Save a config file
        /// </summary>
        /// <param name="location"></param>
        public void SaveFile(string location = "")
        {
            if (string.IsNullOrEmpty(location))
            {
                location = Share.FileLocation.Location(FileLocation.RequestFile.Config) + CteFileName;
            }

            if (this._cache.Count == 0)
            {
                return;
            }

            this._filepath = location;
            this.SaveCache();
        }

        /// <summary>
        ///     Read a string value from config
        /// </summary>
        /// <param name="parent">The parent of the config key, to distinguish the origin of a config key</param>
        /// <param name="key">The config key</param>
        /// <param name="defaultValue">The default value if the element doesn't exist</param>
        /// <returns>Returns the requested value</returns>
        string IConfig.ReadString(string parent, string key, string defaultValue)
        {
            if (!this.isInitialized)
            {
                return defaultValue;
            }

            string id = parent + "_" + key;

            if (this._cache.ContainsKey(id))
            {
                return this._cache[id];
            }

            this._cache.Add(id, defaultValue);
            return defaultValue;
        }

        /// <summary>
        ///     Write a string value to config
        /// </summary>
        /// <param name="parent">The parent of the config key, to distinguish the origin of a config key</param>
        /// <param name="key">The config key</param>
        /// <param name="value">The value to write</param>
        /// <returns>Returns true if operation succeeded</returns>
        bool IConfig.WriteString(string parent, string key, string value)
        {
            if (!this.isInitialized)
            {
                return false;
            }

            string id = parent + "_" + key;

            if (this._cache.ContainsKey(id))
            {
                this._cache[id] = value;
            }
            else
            {
                this._cache.Add(id, value);
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
        Int32 IConfig.ReadInt(string parent, string key, Int32 defaultValue)
        {
            if (!this.isInitialized)
            {
                return defaultValue;
            }

            string id = parent + "_" + key;

            if (this._cache.ContainsKey(id))
            {
                return int.Parse(this._cache[id]);
            }

            this._cache.Add(id, defaultValue.ToString(CultureInfo.InvariantCulture));
            return defaultValue;
        }

        /// <summary>
        ///     Write an integer value to config
        /// </summary>
        /// <param name="parent">The parent of the config key, to distinguish the origin of a config key</param>
        /// <param name="key">The config key</param>
        /// <param name="value">The value to write</param>
        /// <returns>Returns true if operation succeeded</returns>
        bool IConfig.WriteInt(string parent, string key, Int32 value)
        {
            if (!this.isInitialized)
            {
                return false;
            }
            string id = parent + "_" + key;

            if (this._cache.ContainsKey(id))
            {
                this._cache[id] = value.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                this._cache.Add(id, value.ToString(CultureInfo.InvariantCulture));
            }

            return true;
        }

        /// <summary>
        ///     Load the XMLDocument to the cache dictionary
        /// </summary>
        private void LoadCache()
        {
            if (this._xmldoc == null)
            {
                return;
            }

            Dictionary<string, string> newcache = new Dictionary<string, string>();

            foreach (XmlElement entry in this._xmldoc.ChildNodes) //for each element, 
            {
                if (!(entry.Name == "xml" || entry.Name == "root"))
                {
                    newcache.Add(entry.Name, entry.Value);
                }
            }

            this._cache = newcache;
        }

        private void SaveCache()
        {
            if (this._cache == null)
            {
                return;
            }

            string newxml = "<xml>" + Environment.NewLine;

            foreach (var entry in this._cache) //for each element, 
            {
                newxml += "<" + entry.Key + ">" + entry.Value + "</" + entry.Key + ">" + Environment.NewLine;
            }
            newxml += "</xml>";
            this._xmldoc.LoadXml(newxml);
            this._xmldoc.Save(this._filepath);
        }
    }
}