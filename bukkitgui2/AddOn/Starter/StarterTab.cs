using System.Text.RegularExpressions;
using Bukkitgui2.Core.Logging;

namespace Bukkitgui2.AddOn.Starter
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    using Core;
    using MinecraftServers;

    public partial class StarterTab : UserControl, IAddonTab
    {
        private readonly Dictionary<string, IMinecraftServer> _servers;

        private UserControl _customControl;
	    private readonly ILogger _logger = Share.Logger;

        public StarterTab()
        {
            this.InitializeComponent();
            this._servers = MinecraftServerLoader.GetAvailableServers();

            this.LoadUi();
        }

        /// <summary>
        ///     Add content and settings to the UI
        /// </summary>
        private void LoadUi()
        {
			_logger.Log(LogLevel.Info, "StarterTab","Loading UI");
            // Add all servers to the list
            this.CBServerType.Items.Clear();
            foreach (string servername in this._servers.Keys)
            {
                this.CBServerType.Items.Add(servername);
            }
            this.CBServerType.SelectedIndex = 0;
                //Selecting a server will enable/disable the available/unavailable features

            // Cache total amount of ram, set maximum values
            int totalMb = Convert.ToInt32(Core.Util.Performance.MemoryInfo.TotalMemoryMb());
            this.TBMaxRam.Maximum = totalMb;
            this.TBMinRam.Maximum = totalMb;
            this.NumMaxRam.Maximum = totalMb;
            this.NumMinRam.Maximum = totalMb;

            if (this.NumMaxRam.Maximum > 1024)
            {
                this.NumMaxRam.Value = 1024; // We expect a value that is higher, but check for safety
            }
            if (this.NumMinRam.Maximum > 128)
            {
                this.NumMinRam.Value = 128; // We expect a value that is higher, but check for safety
            }

			// Add options for installed java versions
			this.CBJavaVersion.Items.Clear();
			if (JavaApi.IsInstalled(JavaVersion.Jre6X32))
			{
				this.CBJavaVersion.Items.Add("Java 6 - 32 bit");
			}
			if (JavaApi.IsInstalled(JavaVersion.Jre6X64))
			{
				this.CBJavaVersion.Items.Add("Java 6 - 64 bit");
			}
			if (JavaApi.IsInstalled(JavaVersion.Jre7X32))
			{
				this.CBJavaVersion.Items.Add("Java 7 - 32 bit");
			}
			if (JavaApi.IsInstalled(JavaVersion.Jre7X64))
			{
				this.CBJavaVersion.Items.Add("Java 7 - 64 bit");
			}
			this.CBJavaVersion.SelectedIndex = 0;
			_logger.Log(LogLevel.Info, "StarterTab", "UI Loaded");
        }

        /// <summary>
        ///     Load all settings/buttons for a selected server
        /// </summary>
        private void LoadServer()
        {

            IMinecraftServer server = this.GetSelectedServer();
			_logger.Log(LogLevel.Info, "StarterTab", "Loading server: " + server.Name);

            this.PBServerLogo.Image = server.Logo;
            this.LLblSite.Text = "Site: " + server.Site;

			// Enable buttons as needed
            this.BtnDownloadRec.Enabled = server.CanDownloadRecommendedVersion;
            this.BtnDownloadBeta.Enabled = server.CanDownloadBetaVersion;
            this.BtnDownloadDev.Enabled = server.CanDownloadDevVersion;

			// If this server doesn't use a custom assembly, use the java settings
            this.CBJavaVersion.Enabled = !server.HasCustomAssembly;
            this.NumMaxRam.Enabled = !server.HasCustomAssembly;
            this.NumMinRam.Enabled = !server.HasCustomAssembly;
            this.TBMaxRam.Enabled = !server.HasCustomAssembly;
            this.TBMinRam.Enabled = !server.HasCustomAssembly;
            this.TxtOptArg.Enabled = !server.HasCustomAssembly;
            this.TxtOptFlag.Enabled = !server.HasCustomAssembly;
            this.TxtJarFile.Enabled = !server.HasCustomAssembly;

			//Enable possible update settings
			//Notify needs getting the current and the latest version
            Boolean notifyRb = server.CanGetCurrentVersion && server.CanFetchRecommendedVersion;

            Boolean notifyBeta = server.CanGetCurrentVersion && server.CanFetchBetaVersion;

            Boolean notifyDev = server.CanGetCurrentVersion && server.CanFetchDevVersion;

			// Updating also needs the possibility to download
            Boolean updateRb = server.CanGetCurrentVersion && server.CanDownloadRecommendedVersion
                               && server.CanFetchRecommendedVersion;

            Boolean updateBeta = server.CanGetCurrentVersion && server.CanDownloadBetaVersion
                                 && server.CanFetchBetaVersion;

            Boolean updateDev = server.CanGetCurrentVersion && server.CanDownloadDevVersion && server.CanFetchDevVersion;

            this.CBUpdateBehaviour.Items.Clear();
            this.CBUpdateBehaviour.Items.Add("Don't check for updates");
            this.CBUpdateBehaviour.SelectedIndex = 0;

            if (notifyRb || notifyBeta || notifyDev)
            {
                this.CBUpdateBehaviour.Items.Add("Check for updates and notify me");
            }
            if (updateRb || updateBeta || updateDev)
            {
                this.CBUpdateBehaviour.Items.Add("Check for updates and auto update");
            }

            this.CBUpdateBranch.Items.Clear();

            if (updateRb)
            {
                this.CBUpdateBranch.Items.Add("Recommended builds");
            }
            if (updateBeta)
            {
                this.CBUpdateBranch.Items.Add("Beta builds");
            }
            if (updateDev)
            {
                this.CBUpdateBranch.Items.Add("Development builds");
            }

			// If there is a custom settings control, load it
            if (server.HasCustomSettingsControl)
            {
                this._customControl = server.CustomSettingsControl;
                this.GBCustomSettings.Controls.Clear();
                this.GBCustomSettings.Controls.Add(this._customControl);
                this.GBCustomSettings.Controls[0].Dock = DockStyle.Fill;
            }
            else
            {
                this._customControl = null;
                this.GBCustomSettings.Controls.Clear();
            }

			_logger.Log(LogLevel.Info, "StarterTab", "Loaded server: " + server.Name);
        }

		/// <summary>
		/// Get the IMinecraftServer object for the selected item
		/// </summary>
		/// <returns>The selected server (object)</returns>
        private IMinecraftServer GetSelectedServer()
        {
            string serverName = this.CBServerType.SelectedItem.ToString();
            return this._servers[serverName];
        }

		/// <summary>
		/// Get the selected java version
		/// </summary>
		/// <returns>The selected java version as enum</returns>
	    private JavaVersion GetSelectedJavaVersion()
	    {
		    string selectedText = CBJavaVersion.SelectedItem.ToString();
		    if (Regex.IsMatch(selectedText,"(.*)6(.*)32")) return JavaVersion.Jre6X32;
			if (Regex.IsMatch(selectedText, "(.*)6(.*)64")) return JavaVersion.Jre6X64;
			if (Regex.IsMatch(selectedText, "(.*)7(.*)32")) return JavaVersion.Jre7X32;
			if (Regex.IsMatch(selectedText, "(.*)7(.*)64")) return JavaVersion.Jre7X64;
		    return JavaVersion.Jre7X32;
	    }

		/// <summary>
		/// Launch the server, get all settings from 
		/// </summary>
        private void DoServerLaunch()
        {
            IMinecraftServer server = this.GetSelectedServer();
            Starter starter = this.ParentAddon as Starter;

			_logger.Log(LogLevel.Info, "StarterTab", "starting server: " + server.Name);

			// We need access to a starter object (the parent)
            if (starter == null)
            {
				_logger.Log(LogLevel.Severe, "StarterTab", "Failed to start server","No starter object found");
                return;
            }

			// If invalid input, stop
			if (!ValidateInput()) return;

            if (!server.HasCustomAssembly)
            {
                starter.LaunchServer(
                    server,
                    GetSelectedJavaVersion(),
                    this.TxtJarFile.Text,
                    Convert.ToUInt32(this.NumMinRam.Value),
                    Convert.ToUInt32(this.NumMaxRam.Value),
                    this.TxtOptArg.Text,
                    this.TxtOptFlag.Text);
            }
            else
            {
                starter.LaunchServer(server, server.CustomAssembly, this._customControl);
            }
        }

		/// <summary>
		/// Validate the input. Return true if input is valid and server can be started.
		/// </summary>
		/// <returns>Returns true if all input is valid</returns>
		/// <remarks>Important checks: RAM less than 1024Mb on 32bit, java installed, valid .jar file</remarks>
	    public Boolean ValidateInput()
	    {
		    return true;
	    }

        public IAddon ParentAddon { get; set; }

        // UI events

		private void CbServerTypeSelectedIndexChanged(object sender, EventArgs e)
		{
			this.LoadServer();
		}

		private void BtnLaunch_Click(object sender, EventArgs e)
		{
			this.DoServerLaunch();
		}

        private void TbMinRamScroll(object sender, EventArgs e)
        {
            this.NumMinRam.Value = this.TBMinRam.Value;
        }

        private void TbMaxRamScroll(object sender, EventArgs e)
        {
            this.NumMaxRam.Value = this.TBMaxRam.Value;
        }

        private void NumMinRam_ValueChanged(object sender, EventArgs e)
        {
            if (this.TBMinRam.Value != this.NumMinRam.Value)
            {
                this.TBMinRam.Value = Convert.ToInt16(this.NumMinRam.Value);
            }
            if (this.NumMinRam.Value > this.NumMaxRam.Value)
            {
                this.NumMaxRam.Value = this.NumMinRam.Value; // keep the value of the item we're changing
            }
        }

        private void NumMaxRam_ValueChanged(object sender, EventArgs e)
        {
            if (this.TBMaxRam.Value != this.NumMaxRam.Value)
            {
                this.TBMaxRam.Value = Convert.ToInt16(this.NumMaxRam.Value);
            }
            if (this.NumMinRam.Value > this.NumMaxRam.Value)
            {
                this.NumMinRam.Value = this.NumMaxRam.Value; // keep the value of the item we're changing
            }
        }

        private void BtnBrowseJarFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
                                        {
                                            Title = "Select server file",
                                            InitialDirectory = Share.AssemblyLocation,
                                            Filter = ("Java .jar files |*.jar"),
                                            CheckFileExists = true,
                                            Multiselect = false
                                        };
            dialog.ShowDialog();
            this.TxtJarFile.Text = dialog.FileName;
        }
    }
}