using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;

namespace bukkitgui2.Core.Configuration
{
    class XmlConfig : IConfig
    {
	    private const string CteFileName = "config.xml";
		private string _filepath;
		private XmlDocument _xmldoc;
		private Dictionary<string, string> _cache;

	    public XmlConfig()
	    {
		    isInitialized = false;
	    }


	    /// <summary>
	    /// Indicates wether this component is initialized and can be used
	    /// </summary>
	    public bool isInitialized { get; private set; }

	    /// <summary>
		/// Create or open needed files, create streams if needed, do everything what's needed before a Log() call can be made
		/// </summary>
        public void Initialize()
         {
			 LoadFile();
			 isInitialized = true;

			 System.Windows.Forms.Application.ApplicationExit += HandleExit;
         }

		/// <summary>
		/// Stop the logger, dispose used sources
		/// </summary>
        public void Dispose()
         {
			this.SaveCache();
         }

		private void HandleExit(object sender, EventArgs e)
		{
			this.Dispose();
		}

		/// <summary>
		/// Load a config file
		/// </summary>
		/// <param name="location"></param>
        public void LoadFile(string location = "" )
         {
			 if (string.IsNullOrEmpty(location)) location = Share.FileLocation.Location(FileLocation.RequestFile.Config) + CteFileName;

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
		/// Save a config file
		/// </summary>
		/// <param name="location"></param>
        public void SaveFile(string location = "")
        {
			if (string.IsNullOrEmpty(location)) location = Share.FileLocation.Location(FileLocation.RequestFile.Config) + CteFileName;

			if (_cache.Count == 0) return;
			
			_filepath = location;
			SaveCache();
		}
		
		/// <summary>
		/// Read a string value from config
		/// </summary>
		/// <param name="parent">The parent of the config key, to distinguish the origin of a config key</param>
		/// <param name="key">The config key</param>
		/// <param name="defaultValue">The default value if the element doesn't exist</param>
        /// <returns>Returns the requested value</returns>
        string IConfig.ReadString(string parent, string key, string defaultValue)
         {
			if (!isInitialized) return defaultValue;

			string id = parent + "_" + key ;
          
			if (_cache.ContainsKey(id)) return _cache[id];

			_cache.Add(id, defaultValue);
			return defaultValue;

         }

		/// <summary>
		/// Write a string value to config
		/// </summary>
		/// <param name="parent">The parent of the config key, to distinguish the origin of a config key</param>
		/// <param name="key">The config key</param>
		/// <param name="value">The value to write</param>
		/// <returns>Returns true if operation succeeded</returns>
        bool IConfig.WriteString(string parent, string key, string value)
         {
			 if (!isInitialized) return false;

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
		/// Read an integer value from config
		/// </summary>
		/// <param name="parent">The parent of the config key, to distinguish the origin of a config key</param>
		/// <param name="key">The config key</param>
		/// <param name="defaultValue">The default value if the element doesn't exist</param>
        /// <returns>Returns the requested value</returns>
        Int32 IConfig.ReadInt(string parent, string key, Int32 defaultValue )
         {
			 if (!isInitialized) return defaultValue;

			 string id = parent + "_" + key;

			 if (_cache.ContainsKey(id)) return int.Parse(_cache[id]);

			 _cache.Add(id, defaultValue.ToString());
			 return defaultValue;

         }

	    /// <summary>
	    /// Write an integer value to config
	    /// </summary>
	    /// <param name="parent">The parent of the config key, to distinguish the origin of a config key</param>
	    /// <param name="key">The config key</param>
	    /// <param name="value">The value to write</param>
	    /// <returns>Returns true if operation succeeded</returns>
	    bool IConfig.WriteInt(string parent, string key, Int32 value)
         {
			if (!isInitialized) return false;
			string id = parent + "_" + key;

			if (_cache.ContainsKey(id))
			{
				_cache[id] = value.ToString();
			}
			else
			{
				_cache.Add(id, value.ToString());
			}


			return true;
         }

		/// <summary>
		/// Load the XMLDocument to the cache dictionary
		/// </summary>
		private void LoadCache()
		{

			if (_xmldoc == null) return;

			Dictionary<string,string> newcache = new Dictionary<string,string>();


			foreach (XmlElement entry in _xmldoc.ChildNodes) //for each element, 
			{
				 if (!(entry.Name == "xml" || entry.Name=="root")) newcache.Add(entry.Name,entry.Value);
			}

			_cache = newcache;

		}

		private void SaveCache()
		{
			if (_cache == null) return;

			string newxml = "<xml>" + Environment.NewLine;

			foreach (var entry in _cache) //for each element, 
			{
				newxml += "<" + entry.Key + ">" + entry.Value + "</" + entry.Key + ">" + Environment.NewLine;
			}
				newxml +="</xml>";
			_xmldoc.LoadXml(newxml);
			_xmldoc.Save(_filepath);
		}
    }
}
