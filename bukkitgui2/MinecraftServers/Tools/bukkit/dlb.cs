//dlb- dl.bukkit.org
//provides functionality to download bukkit, get latest versions and so on

//example output from http://dl.bukkit.org/api/1.0/downloads/projects/craftbukkit/view/build-2150/
//<root>
//<broken_reason/>
//<build_number>2150</build_number>
//<created>2012-04-05 11:14:24</created>
//<url>http://dl.bukkit.org/api/1.0/downloads/projects/craftbukkit/view/01028_1.2.5-R1.1/</url>
//<is_broken>False</is_broken>
//<html_url>http://dl.bukkit.org/downloads/craftbukkit/view/01028_1.2.5-R1.1/</html_url>
//<project>
// <name>CraftBukkit</name>
// <github_project_url>https://github.com/Bukkit/CraftBukkit</github_project_url>
// <url>http://dl.bukkit.org/api/1.0/downloads/projects/craftbukkit/</url>
// <html_url>http://dl.bukkit.org/downloads/craftbukkit/</html_url>
// <download_count>3215933</download_count><slug>craftbukkit</slug>
//</project>
//<version>1.2.5-R1.1</version>
//<file>
// <url>http://dl.bukkit.org/downloads/craftbukkit/get/01028_1.2.5-R1.1/craftbukkit-dev.jar</url>
// <checksum_md5>5ce4ab8b0bc31e6547eb47cef2507eeb</checksum_md5>
// <size>11102004</size>
//</file>
//<commit>
// <ref>caee2402f59d12df6338c3d95ce2ec411a8c55db</ref>
// <html_url>https://github.com/Bukkit/CraftBukkit/commit/caee2402f59d12df6338c3d95ce2ec411a8c55db</html_url>
//</commit>
//<target_filename>craftbukkit-dev.jar</target_filename>
//<download_count>16800</download_count>
//<channel>
//<filename_format>%(project_slug)s-dev.jar</filename_format>
//<url>http://dl.bukkit.org/api/1.0/downloads/channels/dev/</url>
//<priority>1000</priority><name>Development Build</name>
//<slug>dev</slug>
//</channel>
//</root>

namespace Net.Bertware.Bukkitgui2.MinecraftServers.Tools.bukkit
{
    using System;
    using System.Net;
    using System.Xml;

    using  Net.Bertware.Bukkitgui2.Core.Logging;

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
                webc.Headers.Add(HttpRequestHeader.UserAgent, Core.Util.Web.WebUtil.UserAgent);
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
                xml.Load(xmlString.ToLower());
                //for logging purposes
                this.Name = xml.GetElementsByTagName("Name")[0].InnerText;
                this.Build = Convert.ToUInt16(xml.GetElementsByTagName("build_number")[0].InnerText);
                this.FileSize = Convert.ToUInt64(xml.GetElementsByTagName("size")[0].InnerText);
                this.HtmlUrl = xml.GetElementsByTagName("html_url")[0].InnerText;
                this.TargetFilename = xml.GetElementsByTagName("target_filename")[0].InnerText;
                this.FileUrl = xml.GetElementsByTagName("url")[0].InnerText;
                this.Version = xml.GetElementsByTagName("version")[0].InnerText.ToUpper();

                if (this.FileUrl.StartsWith("http") == false)
                {
                    this.FileUrl = "http://dl.bukkit.org/" + this.FileUrl.Trim('/');
                }

                string strCreated = xml.GetElementsByTagName("created")[0].InnerText;
                //e.g. 2012-04-05 11:14:24
                string dtstring =
                    System.Text.RegularExpressions.Regex.Match(
                        strCreated,
                        "\\d{4}-\\d{2}-\\d{2}\\s\\d{2}:\\d{2}:\\d{2}").ToString();

                this.Created = DateTime.Parse(dtstring);
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Severe, "dlb", "Severe error while trying to create dlb object!", ex.Message);
            }
        }

        public DlbDownload()
        {
            this.Name = "Craftbukkit";
            this.Build = 0;
            this.FileSize = 0;
            this.HtmlUrl = "";
            this.TargetFilename = "craftbukkit.jar";
            this.FileUrl = "";
            this.Version = "";
            this.Created = new DateTime(0);
        }

        public DlbDownload(string name, string build)
        {
            this.Name = name;
            this.Build = Convert.ToUInt16(build);
            this.Version = "";
        }
    }
}