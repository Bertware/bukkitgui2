using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using bukkitgui2.Core.FileLocation;

namespace bukkitgui2.Core.Locale
{
	internal class XmlLocale : ILocale
	{
		private const string XmlHead="<xml type=\"locale\" lang=\"en-US\">";
		private const string XmlTail = "</xml>";

		private string _filepath;
		private XmlDocument _xmldoc;
		private Dictionary<string, string> _cache;

		/// <summary>
		///     Returns the current language of the translator
		/// </summary>
		string ILocale.CurrentLanguage
		{
			get { return "en-US"; }
		}

		/// <summary>
		///     Indicates wether this component is initialized and can be used
		/// </summary>
		public bool IsInitialized { get; private set; }

		/// <summary>
		///     Initialize everything, create cache
		/// </summary>
		public void Initialize()
		{
			string location = Share.Config.ReadString("Locale", "File",Share.FileLocation.Location(RequestFile.Config) + "/default.xml");

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
				sw.WriteLine(XmlHead+XmlTail);
				sw.Close();
				fs.Close();
			}

			_xmldoc = new XmlDocument();
			_xmldoc.Load(_filepath);

			LoadCache(); //everything's cached, we're ready to go
			IsInitialized = true;
		}

		/// <summary>
		///     Dispose resources and cache
		/// </summary>
		public void Dispose()
		{
			this.SaveCache();
		}

		/// <summary>
		///     Translate a string
		/// </summary>
		/// <param name="original">The original text</param>
		/// <returns></returns>
		public string Tr(string original)
		{
			if (!IsInitialized) return original;
			if (_cache == null) return original;

			if (_cache.ContainsKey(original))
			{
				return _cache[original];
			}

			_cache.Add(original,original);
			return original;
		}

		/// <summary>
		///     Translate a string
		/// </summary>
		/// <param name="original">The original text</param>
		/// <param name="p1">replacement value of parameter %1</param>
		/// <param name="p2">replacement value of parameter %2</param>
		/// <param name="p3">replacement value of parameter %3</param>
		/// <param name="p4">replacement value of parameter %4</param>
		/// <returns></returns>
		public string Tr(string original, string p1, string p2 = "", string p3 = "", string p4 = "")
		{
			if (!IsInitialized) return SetParam(original,p1,p2,p3,p4);
			if (_cache == null) return SetParam(original, p1, p2, p3, p4);

			if (_cache.ContainsKey(original))
			{
				return SetParam(_cache[original], p1, p2, p3, p4);
			}

			_cache.Add(original, original);
			return SetParam(original, p1, p2, p3, p4);
		}

		private static string SetParam(string original, string p1, string p2 = "", string p3 = "", string p4 = "")
		{
			return original.Replace("%1", p1).Replace("%2", p2).Replace("%3", p3).Replace("%4", p4);
		}

		/// <summary>
		/// Load the XMLDocument to the cache dictionary
		/// </summary>
		private void LoadCache()
		{

			if (_xmldoc == null) return;

			Dictionary<string, string> newcache = new Dictionary<string, string>();


			foreach (XmlElement entry in _xmldoc.ChildNodes) //for each element, 
			{
				if (entry.Name == "text") newcache.Add(entry.GetAttribute("original"), entry.Value);
			}

			_cache = newcache;

		}

		private void SaveCache()
		{
			if (_cache == null) return;

			string newxml = XmlHead + Environment.NewLine;

			foreach (var entry in _cache) //for each element, 
			{
				newxml += "<text original=\"" + entry.Key + "\">" + entry.Value + "</text>" + Environment.NewLine;
			}
			newxml += XmlTail;
			_xmldoc.LoadXml(newxml);
			_xmldoc.Save(_filepath);
		}
	}
}