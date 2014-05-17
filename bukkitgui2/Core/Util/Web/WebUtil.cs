// WebUtil.cs in bukkitgui2/bukkitgui2
// Created 2014/02/02
// Last edited at 2014/05/17 19:43
// ©Bertware, visit http://bertware.net

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