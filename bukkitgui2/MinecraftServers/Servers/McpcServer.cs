// McpcServer.cs in bukkitgui2/bukkitgui2
// Created 2014/02/02
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using Net.Bertware.Bukkitgui2.Properties;

namespace Net.Bertware.Bukkitgui2.MinecraftServers.Servers
{
    internal class McpcServer : MinecraftServerBase
    {
        public McpcServer()
        {
            Name = "MCPC+ (Cauldron)";
            Site = "http://www.mcportcentral.co.za/";
            Logo = Resources.mcpc_cauldron_logo;

            CanDownloadRecommendedVersion = false;

            //default value for boolean is false, so all other features are disabled by default
        }
    }
}