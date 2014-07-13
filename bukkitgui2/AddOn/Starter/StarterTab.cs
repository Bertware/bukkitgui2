// StarterTab.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/07/13 14:01
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.Core;
using Net.Bertware.Bukkitgui2.Core.Configuration;
using Net.Bertware.Bukkitgui2.Core.Logging;
using Net.Bertware.Bukkitgui2.Core.Util.Performance;
using Net.Bertware.Bukkitgui2.MinecraftServers;

namespace Net.Bertware.Bukkitgui2.AddOn.Starter
{
	public partial class StarterTab : UserControl, IAddonTab
	{
		private readonly Dictionary<string, IMinecraftServer> _servers;

		public IAddon ParentAddon { get; set; }

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
			InitializeComponent();
			_servers = MinecraftServerLoader.GetAvailableServers();

			LoadUi();
		}

		/// <summary>
		///     Add content and settings to the UI
		/// </summary>
		private void LoadUi()
		{
			Logger.Log(LogLevel.Info, "StarterTab", "Loading UI");
			// Add all servers to the list
			CBServerType.Items.Clear();
			foreach (string servername in _servers.Keys)
			{
				CBServerType.Items.Add(servername);
			}

			int selectedServer = Config.ReadInt("Starter", "ServerType", 0);

			// check if this server id exists
			if (selectedServer < CBServerType.Items.Count)
			{
				CBServerType.SelectedIndex = selectedServer;
			}
			else
			{
				if (CBServerType.Items.Count > 0) CBServerType.SelectedIndex = 0;
			}
			LoadServer();
			//Selecting a server will enable/disable the available/unavailable features

			// Cache total amount of ram, set maximum values
			int totalMb = Convert.ToInt32(MemoryCounter.TotalMemoryMb());
			TBMaxRam.Maximum = totalMb;
			TBMinRam.Maximum = totalMb;
			NumMaxRam.Maximum = totalMb;
			NumMinRam.Maximum = totalMb;

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
			if (maxRamValue < NumMaxRam.Maximum)
			{
				NumMaxRam.Value = maxRamValue;
			}
			else
			{
				NumMaxRam.Value = 1024;
			}
			if (minRamValue < NumMinRam.Maximum)
			{
				NumMinRam.Value = minRamValue;
			}
			else
			{
				NumMaxRam.Value = 1024;
			}

			// Add options for installed java versions
			CBJavaVersion.Items.Clear();
			if (JavaApi.IsInstalled(JavaVersion.Jre6X32))
			{
				CBJavaVersion.Items.Add("Java 6 - 32 bit");
			}
			if (JavaApi.IsInstalled(JavaVersion.Jre6X64))
			{
				CBJavaVersion.Items.Add("Java 6 - 64 bit");
			}
			if (JavaApi.IsInstalled(JavaVersion.Jre7X32))
			{
				CBJavaVersion.Items.Add("Java 7 - 32 bit");
			}
			if (JavaApi.IsInstalled(JavaVersion.Jre7X64))
			{
				CBJavaVersion.Items.Add("Java 7 - 64 bit");
			}
			if (JavaApi.IsInstalled(JavaVersion.Jre8X32))
			{
				CBJavaVersion.Items.Add("Java 8 - 32 bit");
			}
			if (JavaApi.IsInstalled(JavaVersion.Jre8X64))
			{
				CBJavaVersion.Items.Add("Java 8 - 64 bit");
			}

			int javaType = Config.ReadInt("Starter", "JavaVersion", 0);
			if (javaType < CBJavaVersion.Items.Count)
			{
				CBJavaVersion.SelectedIndex = javaType;
			}
			else
			{
				if (CBJavaVersion.Items.Count > 0) CBJavaVersion.SelectedIndex = 0;
			}

			TxtJarFile.Text = Config.ReadString("Starter", "JarFile", "");
			TxtOptArg.Text = Config.ReadString("Starter", "OptionalArguments", "");
			TxtOptFlag.Text = Config.ReadString("Starter", "OptionalFlags", "");

			Logger.Log(LogLevel.Info, "StarterTab", "UI Loaded");
			_ready = true;
		}

		/// <summary>
		///     Load all settings/buttons for a selected server
		/// </summary>
		private void LoadServer()
		{
			IMinecraftServer server = GetSelectedServer();
			if (server == null) return;

			Logger.Log(LogLevel.Info, "StarterTab", "Loading server: " + server.Name);

			PBServerLogo.Image = server.Logo;
			LLblSite.Text = "Site: " + server.Site;

			// Enable buttons as needed
			BtnDownloadRec.Enabled = server.CanDownloadRecommendedVersion;
			BtnDownloadBeta.Enabled = server.CanDownloadBetaVersion;
			BtnDownloadDev.Enabled = server.CanDownloadDevVersion;

			// If this server doesn't use a custom assembly, use the java settings
			CBJavaVersion.Enabled = !server.HasCustomAssembly;
			NumMaxRam.Enabled = !server.HasCustomAssembly;
			NumMinRam.Enabled = !server.HasCustomAssembly;
			TBMaxRam.Enabled = !server.HasCustomAssembly;
			TBMinRam.Enabled = !server.HasCustomAssembly;
			TxtOptArg.Enabled = !server.HasCustomAssembly;
			TxtOptFlag.Enabled = !server.HasCustomAssembly;
			TxtJarFile.Enabled = !server.HasCustomAssembly;

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

			CBUpdateBehaviour.Items.Clear();
			CBUpdateBehaviour.Items.Add("Don't check for updates");
			CBUpdateBehaviour.SelectedIndex = 0;

			if (notifyRb || notifyBeta || notifyDev)
			{
				CBUpdateBehaviour.Items.Add("Check for updates and notify me");
			}
			if (updateRb || updateBeta || updateDev)
			{
				CBUpdateBehaviour.Items.Add("Check for updates and auto update");
			}

			CBUpdateBranch.Items.Clear();

			if (updateRb)
			{
				CBUpdateBranch.Items.Add("Recommended builds");
			}
			if (updateBeta)
			{
				CBUpdateBranch.Items.Add("Beta builds");
			}
			if (updateDev)
			{
				CBUpdateBranch.Items.Add("Development builds");
			}

			// If there is a custom settings control, load it
			if (server.HasCustomSettingsControl)
			{
				_customControl = server.CustomSettingsControl;
				GBCustomSettings.Controls.Clear();
				GBCustomSettings.Controls.Add(_customControl);
				GBCustomSettings.Controls[0].Dock = DockStyle.Fill;
			}
			else
			{
				_customControl = null;
				GBCustomSettings.Controls.Clear();
			}

			Logger.Log(LogLevel.Info, "StarterTab", "Loaded server: " + server.Name);
		}

		/// <summary>
		///     Get the IMinecraftServer object for the selected item
		/// </summary>
		/// <returns>The selected server (object)</returns>
		public IMinecraftServer GetSelectedServer()
		{
			if (CBServerType.SelectedItem == null) return null;
			string serverName = CBServerType.SelectedItem.ToString();
			return _servers[serverName];
		}

		/// <summary>
		///     Get the selected java version
		/// </summary>
		/// <returns>The selected java version as enum</returns>
		public JavaVersion GetSelectedJavaVersion()
		{
			string selectedText = CBJavaVersion.SelectedItem.ToString();
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
			IMinecraftServer server = GetSelectedServer();
			Starter starter = ParentAddon as Starter;

			Logger.Log(LogLevel.Info, "StarterTab", "starting server: " + server.Name);

			// We need access to a starter object (the parent)
			if (starter == null)
			{
				Logger.Log(LogLevel.Severe, "StarterTab", "Failed to start server", "No starter object found");
				return;
			}

			// If invalid input, stop
			if (!ValidateInput())
			{
				return;
			}

			if (!server.HasCustomAssembly)
			{
				starter.LaunchServer(
					server,
					GetSelectedJavaVersion(),
					TxtJarFile.Text,
					Convert.ToUInt32(NumMinRam.Value),
					Convert.ToUInt32(NumMaxRam.Value),
					TxtOptArg.Text,
					TxtOptFlag.Text);
			}
			else
			{
				starter.LaunchServer(server, server.CustomAssembly, _customControl);
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


		// UI events

		/// <summary>
		///     Handle SelectedIndexChanged event for server type combobox, and load the new server type
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CbServerTypeSelectedIndexChanged(object sender, EventArgs e)
		{
			if (!_ready)
			{
				return; //if not initialized, don't detect changes
			}
			Config.WriteInt("Starter", "ServerType", CBServerType.SelectedIndex);
			LoadServer();
		}

		/// <summary>
		///     Launch a new server
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnLaunch_Click(object sender, EventArgs e)
		{
			DoServerLaunch();
		}

		/// <summary>
		///     Trackbar scrolled, also adjust numeric value
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TbMinRamScroll(object sender, EventArgs e)
		{
			if (!_ready)
			{
				return; //if not initialized, don't detect changes
			}
			Config.WriteInt("Starter", "MinRam", TBMinRam.Value);
			NumMinRam.Value = TBMinRam.Value;
		}

		/// <summary>
		///     Trackbar scrolled, also adjust numeric value
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TbMaxRamScroll(object sender, EventArgs e)
		{
			if (!_ready)
			{
				return; //if not initialized, don't detect changes
			}
			Config.WriteInt("Starter", "MaxRam", TBMaxRam.Value);
			NumMaxRam.Value = TBMaxRam.Value;
		}

		/// <summary>
		///     Numeric value changed, adjust trackbar and check if minimum value is smaller than the maximum value
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NumMinRam_ValueChanged(object sender, EventArgs e)
		{
			// If trackbar doesn't show the same amount, adjust trackbar
			if (TBMinRam.Value != NumMinRam.Value)
			{
				TBMinRam.Value = Convert.ToInt16(NumMinRam.Value);
			}

			if (!_ready)
			{
				return; //if not initialized, don't detect changes
			}
			Config.WriteInt("Starter", "MinRam", Convert.ToInt16(NumMinRam.Value));

			// if minram goes higer than maxram, adjust maxram
			if (NumMinRam.Value > NumMaxRam.Value)
			{
				NumMaxRam.Value = NumMinRam.Value; // keep the value of the item we're changing
			}
		}

		/// <summary>
		///     Numeric value changed, adjust trackbar and check if minimum value is smaller than the maximum value
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NumMaxRam_ValueChanged(object sender, EventArgs e)
		{
			if (TBMaxRam.Value != NumMaxRam.Value)
			{
				TBMaxRam.Value = Convert.ToInt16(NumMaxRam.Value);
			}

			if (!_ready)
			{
				return; //if not initialized, don't detect changes
			}
			Config.WriteInt("Starter", "MaxRam", Convert.ToInt16(NumMaxRam.Value));

			if (NumMinRam.Value > NumMaxRam.Value)
			{
				NumMinRam.Value = NumMaxRam.Value; // keep the value of the item we're changing
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
			TxtJarFile.Text = dialog.FileName; //this will also trigger the save of this value
		}

		/// <summary>
		///     Handle changed text for the jar file path. Save the new value.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TxtJarFile_TextChanged(object sender, EventArgs e)
		{
			if (!_ready)
			{
				return; //if not initialized, don't detect changes
			}
			Config.WriteString("Starter", "JarFile", TxtJarFile.Text);
		}

		/// <summary>
		///     Handle changed text for the custom arguments. Save the new value.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TxtOptArg_TextChanged(object sender, EventArgs e)
		{
			if (!_ready)
			{
				return; //if not initialized, don't detect changes
			}
			Config.WriteString("Starter", "OptionalArguments", TxtOptArg.Text);
		}

		/// <summary>
		///     Handle changed text for the custom flags. Save the new value.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TxtOptFlag_TextChanged(object sender, EventArgs e)
		{
			if (!_ready)
			{
				return; //if not initialized, don't detect changes
			}
			Config.WriteString("Starter", "OptionalFlags", TxtOptFlag.Text);
		}

		/// <summary>
		///     Handle a change in the selected java version. Save the new value.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CbJavaVersionSelectedIndexChanged(object sender, EventArgs e)
		{
			if (!_ready)
			{
				return; //if not initialized, don't detect changes
			}
			Config.WriteInt("Starter", "JavaVersion", CBJavaVersion.SelectedIndex);
		}

		private void BtnDownloadRec_Click(object sender, EventArgs e)
		{
			if (TxtJarFile.Text == "")
			{
				TxtJarFile.Text = Share.AssemblyLocation; // set GUI location as server folder
			}
			GetSelectedServer().DownloadRecommendedVersion(TxtJarFile.Text);
		}

		private void BtnDownloadBeta_Click(object sender, EventArgs e)
		{
			if (TxtJarFile.Text == "")
			{
				TxtJarFile.Text = Share.AssemblyLocation; // set GUI location as server folder
			}
			GetSelectedServer().DownloadBetaVersion(TxtJarFile.Text);
		}

		private void BtnDownloadDev_Click(object sender, EventArgs e)
		{
			if (TxtJarFile.Text == "")
			{
				TxtJarFile.Text = Share.AssemblyLocation; // set GUI location as server folder
			}
			GetSelectedServer().DownloadDevVersion(TxtJarFile.Text);
		}

		/// <summary>
		///     Get the path of the selected java instance
		/// </summary>
		/// <returns></returns>
		public string GetSelectedJavaPath()
		{
			return JavaApi.GetJavaPath(GetSelectedJavaVersion());
		}

		/// <summary>
		///     Get the path of the jar file
		/// </summary>
		/// <returns></returns>
		public string GetSelectedServerPath()
		{
			return TxtJarFile.Text;
		}
	}
}