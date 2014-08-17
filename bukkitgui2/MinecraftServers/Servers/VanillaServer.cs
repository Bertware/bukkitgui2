// VanillaServer.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/08/17 11:19
// ©Bertware, visit http://bertware.net

using Net.Bertware.Bukkitgui2.Core.Util.Web;
using Net.Bertware.Bukkitgui2.Properties;

namespace Net.Bertware.Bukkitgui2.MinecraftServers.Servers
{
	/// <summary>
	///     Default vanilla server. All parsing code is already in the server base
	/// </summary>
	internal class VanillaServer : MinecraftServerBase
	{
		public VanillaServer()
		{
			Name = "Vanilla";
			Site = "http://minecraft.net";
			Logo = Resources.vanilla_logo;

			CanDownloadRecommendedVersion = true;
			//default value for boolean is false, so all other features are disabled by default
		}

		public override bool DownloadRecommendedVersion(string targetfile)
		{
			FileDownloader fileDownloadDialog = new FileDownloader();
			fileDownloadDialog.AddFile(
				"https://s3.amazonaws.com/Minecraft.Download/versions/1.7.5/minecraft_server.1.7.5.jar",
				targetfile);
			fileDownloadDialog.Show();
			fileDownloadDialog.StartDownload();
			return true;
		}

		public override string GetLaunchFlags(string defaultFlags = "")
		{
			return " nogui " + defaultFlags;
		}
	}
}