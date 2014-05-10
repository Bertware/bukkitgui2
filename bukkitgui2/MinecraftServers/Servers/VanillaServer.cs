using Net.Bertware.Bukkitgui2.Core.Util.Web;

namespace Net.Bertware.Bukkitgui2.MinecraftServers.Servers
{
	/// <summary>
	///     Default vanilla server. All parsing code is already in the server base
	/// </summary>
	internal class VanillaServer : MinecraftServerBase
	{
		public override string Name
		{
			get { return "Vanilla"; }
		}

		public override string Site
		{
			get { return "http://minecraft.net"; }
		}

		public override bool CanDownloadRecommendedVersion
		{
			get { return true; }
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