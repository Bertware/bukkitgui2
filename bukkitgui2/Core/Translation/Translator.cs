// Translator.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/06/07 20:24
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

namespace Net.Bertware.Bukkitgui2.Core.Translation
{
	/// <summary>
	///     XML Translator support, Translator is cached during runtime
	/// </summary>
	internal static class Translator
	{
		private const string CteFileName = "translator.xml";

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

			MainForm form = (MainForm)Control.FromHandle(Share.MainFormHandle);
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
		///     Load a Translator file
		/// </summary>
		/// <param name="location"></param>
		public static void LoadFile(string location = "")
		{
			if (string.IsNullOrEmpty(location))
			{
				location = DefaultFileLocation.SafeLocation(RequestFile.Language) + CteFileName;
			}

			_filepath = location;


			Logger.Log(LogLevel.Info, "Translator", "Loading file", _filepath);

			if (!File.Exists(_filepath))
			{
				Logger.Log(LogLevel.Info, "Translator", "Creating Translator file");
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
		///     Save a Translator file
		/// </summary>
		/// <param name="location"></param>
		public static void SaveFile(string location = "")
		{
			if (string.IsNullOrEmpty(location))
			{
				location = DefaultFileLocation.Location(RequestFile.Language) + CteFileName;
			}

			if (_cache.Count == 0)
			{
				Logger.Log(LogLevel.Debug, "Translator", "Didn't save file: nothing to save");
				return;
			}

			_filepath = location;

			Logger.Log(LogLevel.Info, "Translator", "Saving file", _filepath);

			SaveCache();
		}

		/// <summary>
		///     Read a string value from Translator
		/// </summary>
		/// <param name="text">The text to translate</param>
		/// <returns>Returns the requested value</returns>
		public static string Tr(string text)
		{
			if (!IsInitialized)
			{
				return text;
			}

			if (_cache.ContainsKey(text))
			{
				string value = _cache[text];
				Logger.Log(LogLevel.Info, "Translator", "Read value", text + ":" + value);
				return value;
			}

			_cache.Add(text, text);
			Logger.Log(LogLevel.Info, "Translator", "Added value", text);
			return text;
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

			Logger.Log(LogLevel.Info, "Translator", "Loading cache");
			XmlElement xmle = _xmldoc.DocumentElement;

			foreach (XmlElement entry in xmle.ChildNodes) //for each element, 
			{
				if (!(entry.Name == "xml" || entry.Name == "root"))
				{
					newcache.Add(entry.Name, entry.InnerText);
				}
			}

			Logger.Log(LogLevel.Info, "Translator", "Loaded cache: " + newcache.Count + " entries loaded");

			_cache = newcache;
		}
		/// <summary>
		/// Save the cache to file
		/// </summary>
		private static void SaveCache()
		{
			if (_cache == null)
			{
				return;
			}


			Logger.Log(LogLevel.Info, "Translator", "Saving cache");

			string newxml = "<xml>" + Environment.NewLine;

			foreach (KeyValuePair<string, string> entry in _cache) //for each element, 
			{
				newxml += "<" + entry.Key + ">" + entry.Value + "</" + entry.Key + ">" + Environment.NewLine;
			}
			newxml += "</xml>";
			_xmldoc.LoadXml(newxml);
			_xmldoc.Save(_filepath);
			Logger.Log(LogLevel.Info, "Translator", "Saved cache");
		}
	}
}