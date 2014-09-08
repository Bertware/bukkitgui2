// Locale.cs in bukkitgui2/bukkitgui2
// Created 2014/03/01
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Net.Bertware.Bukkitgui2.Core.Configuration;
using Net.Bertware.Bukkitgui2.Core.FileLocation;
using Net.Bertware.Bukkitgui2.Core.Util;

namespace Net.Bertware.Bukkitgui2.Core
{
	internal static class Locale
	{
		private const string XmlHead = "<xml type=\"locale\" lang=\"en-US\">";
		private const string XmlTail = "</xml>";

		private static string _filepath;
		private static XmlDocument _xmldoc;
		private static Dictionary<string, string> _cache;

		/// <summary>
		///     Returns the current language of the translator
		/// </summary>
		public static string CurrentLanguage
		{
			get { return "en-US"; }
		}

		/// <summary>
		///     Indicates wether this component is initialized and can be used
		/// </summary>
		public static bool IsInitialized { get; private set; }

		/// <summary>
		///     Initialize everything, create cache
		/// </summary>
		public static void Initialize()
		{
			string location = Config.ReadString("Locale", "File",
				Fl.Location(RequestFile.Config) + "\\default.xml");
			LoadFile(location);
			LoadCache(); //everything's cached, we're ready to go
			Application.ApplicationExit += ((sender, e) => Dispose());
			IsInitialized = true;
		}

		/// <summary>
		///     Dispose resources and cache
		/// </summary>
		public static void Dispose()
		{
			SaveCache();
		}

		/// <summary>
		///     Translate a string
		/// </summary>
		/// <param name="original">The original text</param>
		/// <returns></returns>
		public static string Tr(string original)
		{
			if (!IsInitialized) return original;
			if (_cache == null) return original;

			if (_cache.ContainsKey(original))
			{
				return _cache[original];
			}

			_cache.Add(original, original);
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
		public static string Tr(string original, string p1, string p2 = "", string p3 = "", string p4 = "")
		{
			if (!IsInitialized) return SetParam(original, p1, p2, p3, p4);
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

		private static void LoadFile(string file)
		{
			_filepath = file;
			if (!File.Exists(file))
			{
				DirectoryInfo dirInfo = new FileInfo(file).Directory;
				if (dirInfo != null)
				{
					string parent = dirInfo.ToString();
					FsUtil.CreateDirectoryIfNotExists(parent);
				}

				FileStream fs = File.Create(file);
				StreamWriter sw = new StreamWriter(fs);
				sw.WriteLine(XmlHead + XmlTail);
				sw.Close();
				fs.Close();
			}

			_xmldoc = new XmlDocument();
			_xmldoc.Load(file);
		}

		/// <summary>
		///     Load the XMLDocument to the cache dictionary
		/// </summary>
		private static void LoadCache()
		{
			if (_xmldoc == null) return;

			Dictionary<string, string> newcache = new Dictionary<string, string>();


			foreach (XmlElement entry in _xmldoc.ChildNodes) //for each element, 
			{
				if (entry.Name == "text")
					newcache.Add(entry.GetAttribute("original").Replace("&amp;", "&"), entry.Value.Replace("&amp;", "&"));
			}

			_cache = newcache;
		}

		private static void SaveCache()
		{
			if (_cache == null) return;

			string newxml = XmlHead + Environment.NewLine;

			foreach (KeyValuePair<string, string> entry in _cache) //for each element, 
			{
				newxml += "<text original=\"" + entry.Key.Replace("&", "&amp;") + "\">" + entry.Value.Replace("&", "&amp;") +
				          "</text>" + Environment.NewLine;
			}
			newxml += XmlTail;
			_xmldoc.LoadXml(newxml);
			_xmldoc.Save(_filepath);
		}
	}
}