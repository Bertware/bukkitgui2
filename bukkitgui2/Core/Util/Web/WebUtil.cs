using System;

namespace Net.Bertware.Bukkitgui2.Core.Util.Web
{
	internal static class WebUtil
	{
		public const string Mail = "contact@bertware.net";

		public static readonly string UserAgent = "Bertware 1.3/" + Share.AssemblyName + " " + Share.AssemblyVersion + "/" +
		                                          Mail;

		private static string RetrieveString(string url)
		{
			throw new NotImplementedException();
		}

		private static void DownloadFile(string url, string targetlocation, Boolean showUi)
		{
			FileDownloader fileDownloadDialog = new FileDownloader();
			fileDownloadDialog.AddFile(url, targetlocation);
			fileDownloadDialog.StartDownload();
		}
	}
}