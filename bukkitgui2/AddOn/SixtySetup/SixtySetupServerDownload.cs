// SixtySetupServerDownload.cs in bukkitgui2/bukkitgui2
// Created 2014/08/18
// Last edited at 2014/08/18 16:17
// ©Bertware, visit http://bertware.net

using System;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using Net.Bertware.Bukkitgui2.Core;
using Net.Bertware.Bukkitgui2.Core.Configuration;
using Net.Bertware.Bukkitgui2.MinecraftServers;
using Net.Bertware.Bukkitgui2.MinecraftServers.Servers;

namespace Net.Bertware.Bukkitgui2.AddOn.SixtySetup
{
    public partial class SixtySetupServerDownload : MetroUserControl
    {
        private readonly IMinecraftServer _server = new BukkitServer();

        public event EventHandler ServerDownloaded;

        protected virtual void OnServerDownloaded()
        {
			Config.SaveFile();
            EventHandler handler = ServerDownloaded;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public SixtySetupServerDownload()
        {
            InitializeComponent();
        }

        private void metroTileRecommendedBuild_Click(object sender, EventArgs e)
        {
            if (ShowVersionBox(_server.FetchRecommendedVersionUiString) == DialogResult.No) return;

            _server.DownloadRecommendedVersion(Share.AssemblyLocation + _server.Name.ToLower() + ".jar");
			Config.WriteString("Starter", "JarFile", Share.AssemblyLocation + _server.Name.ToLower() + ".jar");	
            OnServerDownloaded();
        }

        private void MetroTileBetaBuild_Click(object sender, EventArgs e)
        {
            if (ShowVersionBox(_server.FetchBetaVersionUiString) == DialogResult.No) return;

            _server.DownloadRecommendedVersion(Share.AssemblyLocation + _server.Name.ToLower() + "-beta.jar");
			Config.WriteString("Starter", "JarFile", Share.AssemblyLocation + _server.Name.ToLower() + "-beta.jar");
            OnServerDownloaded();
        }

        private void MetroTileDevBuild_Click(object sender, EventArgs e)
        {
            if (ShowVersionBox(_server.FetchDevVersionUiString) == DialogResult.No) return;

            _server.DownloadDevVersion(Share.AssemblyLocation + _server.Name.ToLower() + "-dev.jar");
			Config.WriteString("Starter", "JarFile", Share.AssemblyLocation + _server.Name.ToLower() + "-dev.jar");
            OnServerDownloaded();
        }

        private DialogResult ShowVersionBox(string version)
        {
            return MetroMessageBox.Show(FindForm(),
                "You are about to install " + _server.Name + ", version " + version + Environment.NewLine + "Proceed?",
                "Proceed?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}