// WebUtil.cs in bukkitgui2/bukkitgui2
// Created 2014/02/02
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.IO;
using System.Net;
using System.Text;
using Net.Bertware.Bukkitgui2.Core.Logging;

namespace Net.Bertware.Bukkitgui2.Core.Util.Web
{
    internal static class WebUtil
    {
        public const string Mail = "contact@bertware.net";

        public static readonly string UserAgent = "Bertware 1.3/" + Share.AssemblyName + " " + Share.AssemblyVersion +
                                                  "/" +
                                                  Mail;

        public static string RetrieveString(string url)
        {
            Uri uri = new Uri(url);
            try
            {
				HttpWebRequest webc = (HttpWebRequest) WebRequest.Create(uri);
                webc.Timeout = 1000*9;
                webc.UserAgent = UserAgent;
                Logger.Log(LogLevel.Info, "WebUtil", "Retrieving data from " + url);

				StreamReader readStream = new StreamReader(webc.GetResponse().GetResponseStream(), Encoding.UTF8);
                Logger.Log(LogLevel.Info, "WebUtil", "Retrieved data from " + url);
                return readStream.ReadToEnd();
            }
            catch (WebException webException)
            {
                Logger.Log(LogLevel.Warning, "WebUtil", "Couldn't retrieve data from " + url, webException.Message);
                return "";
            }
        }

        public static string GetGeoLocation(string ip)
        {
            return RetrieveString("http://geoip.bertware.net/?key=qXCsPUpvCvaQnWRv&ip=" + ip);
        }

        public static void DownloadFile(string url, string targetlocation, Boolean showUi, Boolean sync = false)
        {
            FileDownloader fileDownloadDialog = new FileDownloader();
            fileDownloadDialog.AddFile(url, targetlocation);
            if (!showUi)
            {
                fileDownloadDialog.StartDownload();
                return;
            }
            if (!sync)
            {
                fileDownloadDialog.Show();
            }
            else
            {
                fileDownloadDialog.ShowDialog();
            }
        }
    }
}