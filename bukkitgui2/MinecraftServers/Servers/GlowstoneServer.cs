// GlowstoneServer.cs in bukkitgui2/bukkitgui2
// Created 2014/09/08
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using Net.Bertware.Bukkitgui2.AddOn.Starter;
using Net.Bertware.Bukkitgui2.Core.Logging;
using Net.Bertware.Bukkitgui2.Core.Util.Web;
using Net.Bertware.Bukkitgui2.MinecraftServers.Tools;
using Net.Bertware.Bukkitgui2.Properties;

namespace Net.Bertware.Bukkitgui2.MinecraftServers.Servers
{
    public class GlowstoneServer : MinecraftServerBase
    {
        // TODO: Fix issue with jline (glowstone doesn't support -nojline)

        public GlowstoneServer()
        {
            Name = "Glowstone";
            Site = "http://www.glowstone.net/";
            Logo = Resources.glowstone_logo;

            CanDownloadRecommendedVersion = true;

            CanGetCurrentVersion = true;
            
            SupportsPlugins = true;
        }

        public override string GetLaunchFlags(string defaultFlags = "")
        {
            return defaultFlags + "--jline false";
        }

        public override string RemoveTimeStamp(string text)
        {
            //2014-01-01 00:00:00,000
            text = Regex.Replace(text, "^\\d{2}:\\d{2}:\\d{2}(,\\d{3}|)\\s*", "");
            text = text.Trim();
            return text;
        }

        public override bool DownloadRecommendedVersion(string targetfile)
        {
            const string source =
                "http://ci.chrisgward.com/job/Glowstone/lastStableBuild/artifact/build/libs/glowstone.jar";
            WebUtil.DownloadFile(source, targetfile, true, true);
            return true;
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

            Logger.Log(LogLevel.Info, "GlowstoneServer", "Starting process for version check",
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