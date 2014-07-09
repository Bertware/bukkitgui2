// BukkitServer.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/06/23 12:33
// ©Bertware, visit http://bertware.net

using System.Diagnostics;
using System.Drawing;
using System.IO;
using Net.Bertware.Bukkitgui2.AddOn.Starter;
using Net.Bertware.Bukkitgui2.Core.Util.Web;
using Net.Bertware.Bukkitgui2.MinecraftServers.Tools;
using Net.Bertware.Bukkitgui2.MinecraftServers.Tools.bukkit;
using Net.Bertware.Bukkitgui2.Properties;

namespace Net.Bertware.Bukkitgui2.MinecraftServers.Servers
{
    internal class BukkitServer : MinecraftServerBase
    {
        public override string Name
        {
            get { return "Bukkit"; }
        }

        public override string Site
        {
            get { return "http://bukkit.org"; }
        }

        public override Image Logo
        {
            get { return Resources.bukkit_logo; }
        }

        public override bool CanFetchRecommendedVersion
        {
            get { return true; }
        }

        public override bool CanFetchBetaVersion
        {
            get { return true; }
        }

        public override bool CanFetchDevVersion
        {
            get { return true; }
        }

        public override bool CanDownloadRecommendedVersion
        {
            get { return true; }
        }

        public override bool CanDownloadBetaVersion
        {
            get { return true; }
        }

        public override bool CanDownloadDevVersion
        {
            get { return true; }
        }

        public override bool CanGetCurrentVersion
        {
            get { return true; }
        }

        public override bool SupportsPlugins
        {
            get { return true; }
        }

        public override string GetLaunchFlags(string defaultFlags = "")
        {
            return "-nojline" + defaultFlags;
        }

        public override bool DownloadDevVersion(string targetfile)
        {
            string source = Dlb.GetlatestVersionInfo(Dlb.BukkitVersionType.Dev).FileUrl;
            WebUtil.DownloadFile(source, targetfile, true);
            return true;
        }

        public override bool DownloadBetaVersion(string targetfile)
        {
            string source = Dlb.GetlatestVersionInfo(Dlb.BukkitVersionType.Beta).FileUrl;
            WebUtil.DownloadFile(source, targetfile, true);
            return true;
        }

        public override bool DownloadRecommendedVersion(string targetfile)
        {
            string source = Dlb.GetlatestVersionInfo(Dlb.BukkitVersionType.Rb).FileUrl;
            WebUtil.DownloadFile(source, targetfile, true);
            return true;
        }

        private DlbDownload _lastDevDownload;

        public override string FetchDevVersion
        {
            get
            {
                if (_lastDevDownload == null) _lastDevDownload = Dlb.GetlatestVersionInfo(Dlb.BukkitVersionType.Dev);
                return _lastDevDownload.Version;
            }
        }

        private DlbDownload _lastBetaDownload;

        public override string FetchBetaVersion
        {
            get
            {
                if (_lastBetaDownload == null) _lastBetaDownload = Dlb.GetlatestVersionInfo(Dlb.BukkitVersionType.Beta);
                return _lastBetaDownload.Version;
            }
        }

        private DlbDownload _lastRecommendedDownload;

        public override string FetchRecommendedVersion
        {
            get
            {
                if (_lastRecommendedDownload == null)
                    _lastRecommendedDownload = Dlb.GetlatestVersionInfo(Dlb.BukkitVersionType.Rb);
                return _lastRecommendedDownload.Version;
            }
        }


        public MinecraftServerVersion GetCurrentVersionObject(string file)
        {
            string versionString;
            string java = Starter.GetSelectedJavaPath();
            Process p = new Process
            {
                StartInfo = new ProcessStartInfo(java)
                {
                    RedirectStandardOutput = true,
                    Arguments = " -Xincgc -XmX32M -jar " + file + " -v",
                    CreateNoWindow = true
                }
            };
            p.Start();

            using (StreamReader sr = new StreamReader(p.StandardOutput.BaseStream))
            {
                versionString = sr.ReadToEnd();
            }

            return new MinecraftServerVersion(versionString);
        }
    }
}