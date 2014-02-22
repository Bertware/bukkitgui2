using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Windows.Forms;

namespace Bukkitgui2.AddOn.Starter
{
    using Bukkitgui2.MinecraftServers;

    public partial class StarterTab : UserControl, IAddonTab
    {

        private readonly Dictionary<string, IMinecraftServer> _servers;
	    private UserControl customControl;

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
			CBJavaVersion.Items.Clear();
	        if (JavaApi.IsInstalled(JavaVersion.Jre6X32)) CBJavaVersion.Items.Add("Java 6 - 32 bit");
			if (JavaApi.IsInstalled(JavaVersion.Jre6X64)) CBJavaVersion.Items.Add("Java 6 - 64 bit");
			if (JavaApi.IsInstalled(JavaVersion.Jre7X32)) CBJavaVersion.Items.Add("Java 7 - 32 bit");
			if (JavaApi.IsInstalled(JavaVersion.Jre7X64)) CBJavaVersion.Items.Add("Java 7 - 64 bit");
	        CBJavaVersion.SelectedIndex = 0;

	        IMinecraftServer server = GetSelectedServer();

            PBServerLogo.Image = server.Logo;
            LLblSite.Text = "Site: " + server.Site;

            BtnDownloadRec.Enabled = server.CanDownloadRecommendedVersion;
            BtnDownloadBeta.Enabled = server.CanDownloadBetaVersion;
            BtnDownloadDev.Enabled = server.CanDownloadDevVersion;

			CBJavaVersion.Enabled = !server.HasCustomAssembly;
			NumMaxRam.Enabled = !server.HasCustomAssembly;
			NumMinRam.Enabled = !server.HasCustomAssembly;
			TBMaxRam.Enabled = !server.HasCustomAssembly;
			TBMinRam.Enabled = !server.HasCustomAssembly;
	        TxtOptArg.Enabled = !server.HasCustomAssembly;
			TxtOptFlag.Enabled = !server.HasCustomAssembly;
			TxtJarFile.Enabled = !server.HasCustomAssembly;

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

	        if (server.HasCustomSettingsControl)
	        {
		        customControl = server.CustomSettingsControl;
		        GBCustomSettings.Controls.Clear();
		        GBCustomSettings.Controls.Add(customControl);
		        GBCustomSettings.Controls[0].Dock = DockStyle.Fill;
	        }
	        else
	        {
				customControl = null;
				GBCustomSettings.Controls.Clear();
	        }
        }

	    private IMinecraftServer GetSelectedServer()
	    {
			string serverName = CBServerType.SelectedItem.ToString();
			return _servers[serverName];
	    }

        private void CbServerTypeSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadServer();
        }

		private void BtnLaunch_Click(object sender, EventArgs e)
		{
			DoServerLaunch();
		}

	    private void DoServerLaunch()
	    {
			IMinecraftServer server = GetSelectedServer();
		    Starter starter = ParentAddon as Starter;
			
			if (starter == null) return;

		    if (!server.HasCustomAssembly)
		    {
				starter.LaunchServer(server,JavaVersion.Jre7X32, TxtJarFile.Text,Convert.ToUInt32(NumMinRam.Value),Convert.ToUInt32(NumMaxRam.Value),TxtOptArg.Text,TxtOptFlag.Text);
		    }
		    else
		    {
			   starter.LaunchServer(server,server.CustomAssembly,customControl);
		    }
	    }

	    public IAddon ParentAddon { get; set; }
    }
}
