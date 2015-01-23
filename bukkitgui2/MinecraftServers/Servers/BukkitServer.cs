// BukkitServer.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using Net.Bertware.Bukkitgui2.AddOn.Starter;
using Net.Bertware.Bukkitgui2.Core.Logging;
using Net.Bertware.Bukkitgui2.Core.Util.Web;
using Net.Bertware.Bukkitgui2.MinecraftServers.Tools;
using Net.Bertware.Bukkitgui2.MinecraftServers.Tools.Bukkit;
using Net.Bertware.Bukkitgui2.Properties;

namespace Net.Bertware.Bukkitgui2.MinecraftServers.Servers
{
    public class BukkitServer : MinecraftServerBase
    {
        public BukkitServer()
        {
            Name = "Bukkit";
            Site = "http://bukkit.org";
            Logo = Resources.bukkit_logo;

            CanFetchBetaVersion = true;
            CanFetchDevVersion = true;
            CanFetchRecommendedVersion = true;
            CanDownloadBetaVersion = true;
            CanDownloadDevVersion = true;
            CanDownloadRecommendedVersion = true;

            CanGetCurrentVersion = true;

            SupportsPlugins = true;
        }


        public override string GetLaunchFlags(string defaultFlags = "")
        {
            return "-nojline" + defaultFlags;
        }

        public override bool DownloadDevVersion(string targetfile)
        {
            string source = Dlb.GetlatestVersionInfo(Dlb.BukkitVersionType.Dev).FileUrl;
            WebUtil.DownloadFile(source, targetfile, true, true);
            return true;
        }

        public override bool DownloadBetaVersion(string targetfile)
        {
            string source = Dlb.GetlatestVersionInfo(Dlb.BukkitVersionType.Beta).FileUrl;
            WebUtil.DownloadFile(source, targetfile, true, true);
            return true;
        }

        public override bool DownloadRecommendedVersion(string targetfile)
        {
            string source = Dlb.GetlatestVersionInfo(Dlb.BukkitVersionType.Rb).FileUrl;
            WebUtil.DownloadFile(source, targetfile, true, true);
            return true;
        }

        public override string FetchDevVersion
        {
            get
            {
                // results are cached in dlb class
                return Dlb.GetlatestVersionInfo(Dlb.BukkitVersionType.Dev).Build.ToString(CultureInfo.InvariantCulture);
            }
        }


        public override string FetchBetaVersion
        {
            get
            {
                // results are cached in dlb class
                return Dlb.GetlatestVersionInfo(Dlb.BukkitVersionType.Beta).Build.ToString(CultureInfo.InvariantCulture);
            }
        }

        public override string FetchRecommendedVersion
        {
            get
            {
                // results are cached in dlb class
                return Dlb.GetlatestVersionInfo(Dlb.BukkitVersionType.Rb).Build.ToString(CultureInfo.InvariantCulture);
            }
        }


        public override string FetchBetaVersionUiString
        {
            get
            {
                return "#" + Dlb.GetlatestVersionInfo(Dlb.BukkitVersionType.Beta).Build + " (" +
                       Dlb.GetlatestVersionInfo(Dlb.BukkitVersionType.Beta).Version + ")";
            }
        }

        public override string FetchDevVersionUiString
        {
            get
            {
                return "#" + Dlb.GetlatestVersionInfo(Dlb.BukkitVersionType.Dev).Build + " (" +
                       Dlb.GetlatestVersionInfo(Dlb.BukkitVersionType.Dev).Version + ")";
            }
        }

        public override string FetchRecommendedVersionUiString
        {
            get
            {
                // #0000 (1.0.0-R1.0)
                return "#" + Dlb.GetlatestVersionInfo(Dlb.BukkitVersionType.Rb).Build + " (" +
                       Dlb.GetlatestVersionInfo(Dlb.BukkitVersionType.Rb).Version + ")";
            }
        }

        public override MinecraftServerVersion GetCurrentVersionObject(string file)
        {
            string versionString;
            string java = Starter.GetSelectedJavaPath();
            Process p = new Process
            {
                StartInfo = new ProcessStartInfo(java)
                {
                    RedirectStandardOutput = true,
                    Arguments = " -Xmx32M -jar \"" + file + "\" -v",
                    CreateNoWindow = true,
                    UseShellExecute = false
                }
            };

            Logger.Log(LogLevel.Info, "BukkitServer", "Starting process for version check",
                "\"" + p.StartInfo.FileName + "\"" + p.StartInfo.Arguments);

            p.Start();

            using (StreamReader sr = new StreamReader(p.StandardOutput.BaseStream))
            {
                for (int i = 0; i < 8; i++)
                {
                    int peek = sr.Peek();
                    if (peek > 0) continue;
                    Thread.Sleep(250);
                }

                versionString = sr.ReadToEnd();
            }

            return new MinecraftServerVersion(versionString);
        }
    }
}