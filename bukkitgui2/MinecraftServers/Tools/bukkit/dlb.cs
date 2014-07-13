// dlb.cs in bukkitgui2/bukkitgui2
// Created 2014/02/21
// Last edited at 2014/07/13 14:01
// ©Bertware, visit http://bertware.net

using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml;
using Net.Bertware.Bukkitgui2.Core.Logging;
using Net.Bertware.Bukkitgui2.Core.Util.Web;

namespace Net.Bertware.Bukkitgui2.MinecraftServers.Tools.bukkit
{
	internal static class Dlb
	{
		public enum BukkitVersionType
		{
			Dev,
			//development build
			Rb,
			//recommended build
			Beta
			//beta build
		}

		/// <summary>
		///     Get the file info about the latest version.
		/// </summary>
		/// <param name="version">The version to get info about (recommended/beta/dev)</param>
		/// <returns>Returns a dlb_download item, based upon the received XML</returns>
		public static DlbDownload GetlatestVersionInfo(BukkitVersionType version)
		{
			string xml = GetWebContents(ConstructUrl(version));
			//get xml
			DlbDownload dlbd = new DlbDownload(xml);
			//create dlb_download from xml
			return dlbd;
			//return result
		}

		/// <summary>
		///     Get the file info about a specified bukkit build
		/// </summary>
		/// <param name="build">The build number. Between 1325 and the current build</param>
		/// <returns>a dlb_download item, containing all the info</returns>
		/// <remarks></remarks>
		public static DlbDownload GetBuildInfo(UInt16 build)
		{
			if (build < 1325)
			{
				build = 1325;
			}
			return new DlbDownload(GetWebContents(ConstructUrl(build)));
		}

		private static string ConstructUrl(BukkitVersionType version)
		{
			return "http://dl.bukkit.org/api/1.0/downloads/projects/craftbukkit/view/latest-" + version + "/";
			//build URL for dlb api - http://dl.bukkit.org/about/
		}

		private static string ConstructUrl(UInt16 build)
		{
			return "http://dl.bukkit.org/api/1.0/downloads/projects/craftbukkit/view/build-" + build + "/";
			//build URL for dlb api - http://dl.bukkit.org/about/
		}

		private static string GetWebContents(string url)
		{
			try
			{
				WebClient webc = new WebClient();
				//new webclient
				webc.Headers.Add(HttpRequestHeader.UserAgent, WebUtil.UserAgent);
				//get header collection from serverinteraction module
				webc.Headers.Add(HttpRequestHeader.Accept, "application/xml");
				//make sure received data is in XML format
				return webc.DownloadString(url);
				//return result
			}
			catch (Exception ex)
			{
				Logger.Log(LogLevel.Severe, "dlb", "Could not download data from " + url, ex.Message);
				return null;
			}
		}
	}

	public class DlbDownload
	{
		public string Name;

		public UInt64 FileSize;

		public UInt16 Build;

		public DateTime Created;

		public string HtmlUrl;

		public string TargetFilename;

		public string FileUrl;

		public string Version;

		public DlbDownload(string xmlString)
		{
			try
			{
				if (xmlString == null || string.IsNullOrEmpty(xmlString) || xmlString.Contains("<") == false
				    || xmlString.Contains(">") == false)
				{
					Logger.Log(
						LogLevel.Warning,
						"dlb",
						"Could not create dlb_download object, xml invalid. Xml:" + xmlString);
					return;
				}

				XmlDocument xml = new XmlDocument();
				//use fxml to parse the xml quickly
				xml.LoadXml(xmlString.ToLower());
				//for logging purposes
				Name = xml.GetElementsByTagName("name")[0].InnerText;
				Build = Convert.ToUInt16(xml.GetElementsByTagName("build_number")[0].InnerText);
				FileSize = Convert.ToUInt64(xml.GetElementsByTagName("size")[0].InnerText);
				HtmlUrl = xml.GetElementsByTagName("html_url")[0].InnerText;
				TargetFilename = xml.GetElementsByTagName("target_filename")[0].InnerText;
				FileUrl = ((XmlElement) (xml.GetElementsByTagName("file")[0])).GetElementsByTagName("url")[0].InnerText;
				Version = xml.GetElementsByTagName("version")[0].InnerText.ToUpper();

				if (FileUrl.StartsWith("http") == false)
				{
					FileUrl = "http://dl.bukkit.org/" + FileUrl.Trim('/');
				}

				string strCreated = xml.GetElementsByTagName("created")[0].InnerText;
				//e.g. 2012-04-05 11:14:24
				string dtstring =
					Regex.Match(
						strCreated,
						"\\d{4}-\\d{2}-\\d{2}\\s\\d{2}:\\d{2}:\\d{2}").ToString();

				Created = DateTime.Parse(dtstring);
			}
			catch (Exception ex)
			{
				Logger.Log(LogLevel.Severe, "dlb", "Severe error while trying to create dlb object!", ex.Message);
			}
		}

		public DlbDownload()
		{
			Name = "Craftbukkit";
			Build = 0;
			FileSize = 0;
			HtmlUrl = "";
			TargetFilename = "craftbukkit.jar";
			FileUrl = "";
			Version = "";
			Created = new DateTime(0);
		}

		public DlbDownload(string name, string build)
		{
			Name = name;
			Build = Convert.ToUInt16(build);
			Version = "";
		}
	}
}