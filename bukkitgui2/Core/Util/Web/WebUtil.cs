using System;
using bukkitgui2.Core;

namespace bukkitgui2.Core.Util.Web
{
	static class WebUtil
	{
		public const string Mail = "contact@bertware.net";
		public static readonly string UserAgent = "Bertware 1.3/"  + Share.AssemblyName + " " + Share.AssemblyVersion + "/" + Mail;

		static string RetrieveString(string url)
		{
			throw new NotImplementedException();
		}

		static void DownloadFile(string url, string targetlocation, Boolean showUi)
		{
			FileDownloader fileDownloadDialog = new FileDownloader();
			fileDownloadDialog.AddFile(url, targetlocation);
			fileDownloadDialog.StartDownload();
		}
	}
}
