// MinecraftServerVersion.cs in bukkitgui2/bukkitgui2
// Created 2014/06/23
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Text.RegularExpressions;

namespace Net.Bertware.Bukkitgui2.MinecraftServers.Tools
{
    public class MinecraftServerVersion
    {
        public int Build { get; private set; }
        public string MinecraftVersion { get; private set; }
        public string ServerVersion { get; private set; }

        public MinecraftServerVersion(string versionString)
        {
            Build = ParseVersionString(versionString);
            MinecraftVersion = ParseVersionStringMinecraftVersion(versionString);
            ServerVersion = ParseVersionStringServerVersion(versionString);
        }

        /// <summary>
        ///     parse a version string (jenkins etc)
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        private static int ParseVersionString(string text)
        {
            // -b120, #1200, b548jnks, ...
            const string pattern = "((#|b|b-)\\d{3,5}(jnks)?)";
            Match match = Regex.Match(text, pattern);
            char[] chars =
            {
                '#',
                'b',
                'j',
                'n',
                'k',
                's',
                '-'
            };

            if (string.IsNullOrEmpty(match.Value))
                return 0;
            return Convert.ToInt32(match.Value.Trim(chars));
        }

        /// <summary>
        ///     parse a bukkit version (console output)
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        private static string ParseVersionStringServerVersion(string text)
        {
            const string pattern = "(\\d.\\d.\\d|\\d.\\d)(\\-R\\d|)";
            Match match = Regex.Match(text, pattern);
            if (string.IsNullOrEmpty(match.Value))
                return "unknown";
            return match.Value;
        }

        /// <summary>
        ///     parse an MC version. Can be in the same version string as the bukkit version
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        private static string ParseVersionStringMinecraftVersion(string text)
        {
            const string pattern = "(MC|Minecraft Version): ((\\d.){1,2}\\d)";
            Match match = Regex.Match(text, pattern,RegexOptions.IgnoreCase);
            if (string.IsNullOrEmpty(match.Value))
                return "unknown";

            return match.Value;
        }

        public override string ToString()
        {
            return ServerVersion + " (" + MinecraftVersion + ")";
        }
    }
}