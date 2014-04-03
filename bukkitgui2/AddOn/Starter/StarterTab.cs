namespace Bukkitgui2.AddOn.Starter
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    using Bukkitgui2.Core;
    using Bukkitgui2.Core.Configuration;
    using Bukkitgui2.Core.Logging;
    using Bukkitgui2.MinecraftServers;

    public partial class StarterTab : UserControl, IAddonTab
    {
        private readonly Dictionary<string, IMinecraftServer> _servers;

        /// <summary>
        ///     The reference to the custom control used by some servers
        /// </summary>
        private UserControl _customControl;

        /// <summary>
        ///     True if initialization is finished and everything can handle user input
        /// </summary>
        private Boolean _ready;

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
            Logger.Log(LogLevel.Info, "StarterTab", "Loading UI");
            // Add all servers to the list
            this.CBServerType.Items.Clear();
            foreach (string servername in this._servers.Keys)
            {
                this.CBServerType.Items.Add(servername);
            }

            int selectedServer = Config.ReadInt("Starter", "ServerType", 0);

            // check if this server id exists
            if (selectedServer < this.CBServerType.Items.Count)
            {
                this.CBServerType.SelectedIndex = selectedServer;
            }
            else
            {
                this.CBServerType.SelectedIndex = 0;
            }
            this.LoadServer();
            //Selecting a server will enable/disable the available/unavailable features

            // Cache total amount of ram, set maximum values
            int totalMb = Convert.ToInt32(Core.Util.Performance.MemoryInfo.TotalMemoryMb());
            this.TBMaxRam.Maximum = totalMb;
            this.TBMinRam.Maximum = totalMb;
            this.NumMaxRam.Maximum = totalMb;
            this.NumMinRam.Maximum = totalMb;

            int minRamValue = Config.ReadInt("Starter", "MinRam", 128);
            int maxRamValue = Config.ReadInt("Starter", "MaxRam", 1024);

            // check for sub-zero values
            if (minRamValue < 0)
            {
                minRamValue = 0;
            }
            if (maxRamValue < 0)
            {
                maxRamValue = 0;
            }

            // value should be less than maximum value
            if (maxRamValue < this.NumMaxRam.Maximum)
            {
                this.NumMaxRam.Value = maxRamValue;
            }
            else
            {
                this.NumMaxRam.Value = 1024;
            }
            if (minRamValue < this.NumMinRam.Maximum)
            {
                this.NumMinRam.Value = minRamValue;
            }
            else
            {
                this.NumMaxRam.Value = 1024;
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
            if (JavaApi.IsInstalled(JavaVersion.Jre8X32))
            {
                this.CBJavaVersion.Items.Add("Java 8 - 32 bit");
            }
            if (JavaApi.IsInstalled(JavaVersion.Jre8X64))
            {
                this.CBJavaVersion.Items.Add("Java 8 - 64 bit");
            }

            int javaType = Config.ReadInt("Starter", "JavaVersion", 0);
            if (javaType < this.CBJavaVersion.Items.Count)
            {
                this.CBJavaVersion.SelectedIndex = javaType;
            }
            else
            {
                this.CBJavaVersion.SelectedIndex = 0;
            }

            this.TxtJarFile.Text = Config.ReadString("Starter", "JarFile", "");
            this.TxtOptArg.Text = Config.ReadString("Starter", "OptionalArguments", "");
            this.TxtOptFlag.Text = Config.ReadString("Starter", "OptionalFlags", "");

            Logger.Log(LogLevel.Info, "StarterTab", "UI Loaded");
            this._ready = true;
        }

        /// <summary>
        ///     Load all settings/buttons for a selected server
        /// </summary>
        private void LoadServer()
        {
            IMinecraftServer server = this.GetSelectedServer();
            Logger.Log(LogLevel.Info, "StarterTab", "Loading server: " + server.Name);

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

            Logger.Log(LogLevel.Info, "StarterTab", "Loaded server: " + server.Name);
        }

        /// <summary>
        ///     Get the IMinecraftServer object for the selected item
        /// </summary>
        /// <returns>The selected server (object)</returns>
        public IMinecraftServer GetSelectedServer()
        {
            string serverName = this.CBServerType.SelectedItem.ToString();
            return this._servers[serverName];
        }

        /// <summary>
        ///     Get the selected java version
        /// </summary>
        /// <returns>The selected java version as enum</returns>
        public JavaVersion GetSelectedJavaVersion()
        {
            string selectedText = this.CBJavaVersion.SelectedItem.ToString();
            if (Regex.IsMatch(selectedText, "(.*)6(.*)32"))
            {
                return JavaVersion.Jre6X32;
            }
            if (Regex.IsMatch(selectedText, "(.*)6(.*)64"))
            {
                return JavaVersion.Jre6X64;
            }
            if (Regex.IsMatch(selectedText, "(.*)7(.*)32"))
            {
                return JavaVersion.Jre7X32;
            }
            if (Regex.IsMatch(selectedText, "(.*)7(.*)64"))
            {
                return JavaVersion.Jre7X64;
            }
            if (Regex.IsMatch(selectedText, "(.*)8(.*)32"))
            {
                return JavaVersion.Jre8X32;
            }
            if (Regex.IsMatch(selectedText, "(.*)8(.*)64"))
            {
                return JavaVersion.Jre8X64;
            }
            return JavaVersion.Jre7X32;
        }

        /// <summary>
        ///     Launch the server, get all settings from
        /// </summary>
        public void DoServerLaunch()
        {
            IMinecraftServer server = this.GetSelectedServer();
            Starter starter = this.ParentAddon as Starter;

            Logger.Log(LogLevel.Info, "StarterTab", "starting server: " + server.Name);

            // We need access to a starter object (the parent)
            if (starter == null)
            {
                Logger.Log(LogLevel.Severe, "StarterTab", "Failed to start server", "No starter object found");
                return;
            }

            // If invalid input, stop
            if (!this.ValidateInput())
            {
                return;
            }

            if (!server.HasCustomAssembly)
            {
                starter.LaunchServer(
                    server,
                    this.GetSelectedJavaVersion(),
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
        ///     Validate the input. Return true if input is valid and server can be started.
        /// </summary>
        /// <returns>Returns true if all input is valid</returns>
        /// <remarks>Important checks: RAM less than 1024Mb on 32bit, java installed, valid .jar file</remarks>
        public Boolean ValidateInput()
        {
            return true;
        }

        public IAddon ParentAddon { get; set; }

        // UI events

        /// <summary>
        ///     Handle SelectedIndexChanged event for server type combobox, and load the new server type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbServerTypeSelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this._ready)
            {
                return; //if not initialized, don't detect changes
            }
            Config.WriteInt("Starter", "ServerType", this.CBServerType.SelectedIndex);
            this.LoadServer();
        }

        /// <summary>
        ///     Launch a new server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLaunch_Click(object sender, EventArgs e)
        {
            this.DoServerLaunch();
        }

        /// <summary>
        ///     Trackbar scrolled, also adjust numeric value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbMinRamScroll(object sender, EventArgs e)
        {
            if (!this._ready)
            {
                return; //if not initialized, don't detect changes
            }
            Config.WriteInt("Starter", "MinRam", this.TBMinRam.Value);
            this.NumMinRam.Value = this.TBMinRam.Value;
        }

        /// <summary>
        ///     Trackbar scrolled, also adjust numeric value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbMaxRamScroll(object sender, EventArgs e)
        {
            if (!this._ready)
            {
                return; //if not initialized, don't detect changes
            }
            Config.WriteInt("Starter", "MaxRam", this.TBMaxRam.Value);
            this.NumMaxRam.Value = this.TBMaxRam.Value;
        }

        /// <summary>
        ///     Numeric value changed, adjust trackbar and check if minimum value is smaller than the maximum value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumMinRam_ValueChanged(object sender, EventArgs e)
        {
            // If trackbar doesn't show the same amount, adjust trackbar
            if (this.TBMinRam.Value != this.NumMinRam.Value)
            {
                this.TBMinRam.Value = Convert.ToInt16(this.NumMinRam.Value);
            }

            if (!this._ready)
            {
                return; //if not initialized, don't detect changes
            }
            Config.WriteInt("Starter", "MinRam", Convert.ToInt16(this.NumMinRam.Value));

            // if minram goes higer than maxram, adjust maxram
            if (this.NumMinRam.Value > this.NumMaxRam.Value)
            {
                this.NumMaxRam.Value = this.NumMinRam.Value; // keep the value of the item we're changing
            }
        }

        /// <summary>
        ///     Numeric value changed, adjust trackbar and check if minimum value is smaller than the maximum value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumMaxRam_ValueChanged(object sender, EventArgs e)
        {
            if (this.TBMaxRam.Value != this.NumMaxRam.Value)
            {
                this.TBMaxRam.Value = Convert.ToInt16(this.NumMaxRam.Value);
            }

            if (!this._ready)
            {
                return; //if not initialized, don't detect changes
            }
            Config.WriteInt("Starter", "MaxRam", Convert.ToInt16(this.NumMaxRam.Value));

            if (this.NumMinRam.Value > this.NumMaxRam.Value)
            {
                this.NumMinRam.Value = this.NumMaxRam.Value; // keep the value of the item we're changing
            }
        }

        /// <summary>
        ///     Browse for a jar server file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            this.TxtJarFile.Text = dialog.FileName; //this will also trigger the save of this value
        }

        /// <summary>
        ///     Handle changed text for the jar file path. Save the new value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtJarFile_TextChanged(object sender, EventArgs e)
        {
            if (!this._ready)
            {
                return; //if not initialized, don't detect changes
            }
            Config.WriteString("Starter", "JarFile", this.TxtJarFile.Text);
        }

        /// <summary>
        ///     Handle changed text for the custom arguments. Save the new value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtOptArg_TextChanged(object sender, EventArgs e)
        {
            if (!this._ready)
            {
                return; //if not initialized, don't detect changes
            }
            Config.WriteString("Starter", "OptionalArguments", this.TxtOptArg.Text);
        }

        /// <summary>
        ///     Handle changed text for the custom flags. Save the new value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtOptFlag_TextChanged(object sender, EventArgs e)
        {
            if (!this._ready)
            {
                return; //if not initialized, don't detect changes
            }
            Config.WriteString("Starter", "OptionalFlags", this.TxtOptFlag.Text);
        }

        /// <summary>
        ///     Handle a change in the selected java version. Save the new value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbJavaVersionSelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this._ready)
            {
                return; //if not initialized, don't detect changes
            }
            Config.WriteInt("Starter", "JavaVersion", this.CBJavaVersion.SelectedIndex);
        }

        private void BtnDownloadRec_Click(object sender, EventArgs e)
        {
            if (this.TxtJarFile.Text == "")
            {
                this.TxtJarFile.Text = Share.AssemblyLocation; // set GUI location as server folder
            }
            this.GetSelectedServer().DownloadRecommendedVersion(this.TxtJarFile.Text);
        }

        private void BtnDownloadBeta_Click(object sender, EventArgs e)
        {
            if (this.TxtJarFile.Text == "")
            {
                this.TxtJarFile.Text = Share.AssemblyLocation; // set GUI location as server folder
            }
            this.GetSelectedServer().DownloadBetaVersion(this.TxtJarFile.Text);
        }

        private void BtnDownloadDev_Click(object sender, EventArgs e)
        {
            if (this.TxtJarFile.Text == "")
            {
                this.TxtJarFile.Text = Share.AssemblyLocation; // set GUI location as server folder
            }
            this.GetSelectedServer().DownloadDevVersion(this.TxtJarFile.Text);
        }
    }
}