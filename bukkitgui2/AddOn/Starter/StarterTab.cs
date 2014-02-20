using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bukkitgui2.AddOn.Starter
{
    using Bukkitgui2.MinecraftServers;

    public partial class StarterTab : UserControl, IAddonTab
    {

        private readonly Dictionary<string, IMinecraftServer> _servers;

        public StarterTab()
        {
            InitializeComponent();
            this._servers = MinecraftServerLoader.GetAvailableServers();

            this.LoadUi();

        }

        /// <summary>
        /// Add content and settings to the UI
        /// </summary>
        private void LoadUi()
        {
            CBServerType.Items.Clear();
            foreach (string servername in _servers.Keys)
            {
                CBServerType.Items.Add(servername);
            }
            CBServerType.SelectedIndex = 0;
        }

        /// <summary>
        /// Load all settings/buttons for a selected server
        /// </summary>
        private void LoadServer()
        {

            string serverName = CBServerType.SelectedItem.ToString();

            IMinecraftServer server = _servers[serverName];

            PBServerLogo.Image = server.Logo;
            LLblSite.Text = "Site: " + server.Site;

            BtnDownloadRec.Enabled = server.CanDownloadRecommendedVersion;
            BtnDownloadBeta.Enabled = server.CanDownloadBetaVersion;
            BtnDownloadDev.Enabled = server.CanDownloadDevVersion;

            Boolean notifyRb = server.CanGetCurrentVersion && server.CanFetchRecommendedVersion;

            Boolean notifyBeta = server.CanGetCurrentVersion && server.CanFetchBetaVersion;

            Boolean notifyDev = server.CanGetCurrentVersion && server.CanFetchDevVersion;


            Boolean updateRb = server.CanGetCurrentVersion && server.CanDownloadRecommendedVersion
                               && server.CanFetchRecommendedVersion;

            Boolean updateBeta = server.CanGetCurrentVersion && server.CanDownloadBetaVersion
                               && server.CanFetchBetaVersion;

            Boolean updateDev = server.CanGetCurrentVersion && server.CanDownloadDevVersion
                               && server.CanFetchDevVersion;

            CBUpdateBehaviour.Items.Clear();
            CBUpdateBehaviour.Items.Add("Don't check for updates");
            CBUpdateBehaviour.SelectedIndex = 0;

            if (notifyRb || notifyBeta || notifyDev) CBUpdateBehaviour.Items.Add("Check for updates and notify me");
            if (updateRb || updateBeta || updateDev) CBUpdateBehaviour.Items.Add("Check for updates and auto update");

            CBUpdateBranch.Items.Clear();

            if (updateRb) CBUpdateBranch.Items.Add("Recommended builds");
            if (updateBeta) CBUpdateBranch.Items.Add("Beta builds");
            if (updateDev) CBUpdateBranch.Items.Add("Development builds");


        }

        private void CbServerTypeSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadServer();
        }

	}
}
