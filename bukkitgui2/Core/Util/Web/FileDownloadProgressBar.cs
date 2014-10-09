// FileDownloadProgressBar.cs in bukkitgui2/bukkitgui2
// Created 2014/04/06
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.Core.FileLocation;
using Net.Bertware.Bukkitgui2.Core.Logging;
using Timer = System.Windows.Forms.Timer;

namespace Net.Bertware.Bukkitgui2.Core.Util.Web
{
    /// <summary>
    ///     control to download a file async, while showing a progressbar with details
    /// </summary>
    public partial class FileDownloadProgressBar
    {
        private readonly string _tmp = Fl.Location(RequestFile.Temp) + "download\\";

        private const int TmrInterval = 250;

        private WebClient _webc;

        public string Filename { get; private set; }

        private int _percent;

        private int _totalKb;

        public string Url { get; private set; }

        public string Targetlocation { get; private set; }

        private string _tmplocation;

        public event AsyncCompletedEventHandler DownloadCompleted;

        private Timer _tmrUpdateUi;

        /// <summary>
        ///     Create a new instance
        /// </summary>
        public FileDownloadProgressBar()
        {
            InitializeComponent();
            if (!Directory.Exists(_tmp)) Directory.CreateDirectory(_tmp);
        }

        /// <summary>
        ///     Create a new download
        /// </summary>
        /// <param name="url">Url to download from</param>
        /// <param name="targetlocation">targetlocation to save the file</param>
        public bool CreateDownload(string url, string targetlocation)
        {
            //if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(targetlocation)) return false;
            _webc = new WebClient();
            Url = url;

            Filename = Regex.Match(Url, "\\/[^\\\\\\/]+$").Value.Substring(1);

            if (Regex.IsMatch(targetlocation, "\\w\\.\\{2,5}$"))
            {
                Filename = Regex.Match(targetlocation, "\\/[^\\\\\\/]+$").Value.Substring(1);
                targetlocation = Regex.Replace(targetlocation, "[^\\\\/]\\.\\{2,5}$", "");
            }


            Targetlocation = targetlocation;

            _tmplocation = _tmp + Filename;
            return true;
        }

        /// <summary>
        ///     Start the download
        /// </summary>
        public void StartDownload()
        {
            _webc.Headers.Add(HttpRequestHeader.UserAgent, WebUtil.UserAgent);
            _webc.DownloadProgressChanged += UpdateStats;
            _webc.DownloadFileCompleted += Finished;
            Logger.Log(LogLevel.Info, "FileDownloadProgressBar", "Starting download", Url);

            Thread t = new Thread(() => _webc.DownloadFileAsync(new Uri(Url), _tmplocation))
            {
                Name = "DownloadProgressBar"
            };
            t.Start();
            Logger.Log(LogLevel.Info, "FileDownloadProgressBar", "Started download", Url);
            _tmrUpdateUi = new Timer {Interval = TmrInterval};
            _tmrUpdateUi.Tick += UpdateUi;
            _tmrUpdateUi.Start();
        }

        /// <summary>
        ///     Cancel the download
        /// </summary>
        public void Cancel()
        {
            _webc.CancelAsync();
            File.Delete(_tmplocation);
            AsyncCompletedEventHandler handler = DownloadCompleted;
            if (handler != null)
            {
                handler(null, null);
            }
        }

        /// <summary>
        ///     Handle finished download, move file from temporary to target location
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Finished(object sender, AsyncCompletedEventArgs e)
        {
            Logger.Log(LogLevel.Info, "FileDownloadProgressBar", "Download finished!", Url);
            // Move to the correct location
            if (File.Exists(Targetlocation))
            {
                File.Delete(Targetlocation);
            }
            File.Move(_tmplocation, Targetlocation);

            AsyncCompletedEventHandler handler = DownloadCompleted;
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        /// <summary>
        ///     For calculating the speed, 500ms ago
        /// </summary>
        private int _receivedKbHist1;

        /// <summary>
        ///     For calculating the speed, received kb 1 second ago
        /// </summary>
        private int _receivedKbHist2;

        private DownloadProgressChangedEventArgs _e;

        /// <summary>
        ///     Handle DownloadProgressChanged, and save the eventargs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateStats(object sender, DownloadProgressChangedEventArgs e)
        {
            _e = e;
        }

        /// <summary>
        ///     Update the UI every 500ms using a timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="timerElapsedEventArgs"></param>
        private void UpdateUi(object sender, EventArgs timerElapsedEventArgs)
        {
            if (_e == null)
            {
                SetInfoText("Initiating download: " + Filename);
                return; // no data yet
            }

            _totalKb = (int) (_e.TotalBytesToReceive/1024);

            int downloadedKb = (int) (_e.BytesReceived/1024);
            _percent = _e.ProgressPercentage;

            // this is updated every 500ms. Therefore, deltaKb is half the download speed per second
            int deltaKb1 = _receivedKbHist1 - _receivedKbHist2;
            int deltaKb2 = downloadedKb - _receivedKbHist1;

            // calculate the average. We would have to divide by 2, but since we need to 
            // mulitply both values by 2 to get the speed per second, we can simplify this.
            int downloadSpeed = ((deltaKb1 + deltaKb2)/2)*(1000/TmrInterval);

            _receivedKbHist2 = _receivedKbHist1;
            _receivedKbHist1 = downloadedKb;

            SetInfoText("Downloading: " + Filename + " : " + downloadedKb + "/" + _totalKb + "Kb @ "
                        + downloadSpeed + "kbps");

            SetPercentage(_percent);
        }

        private void SetInfoText(String text)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker) (() => SetInfoText(text)));
            }
            else
            {
                lblInfo.Text = text;
            }
        }

        private void SetPercentage(int percentage)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker) (() => SetPercentage(percentage)));
            }
            else
            {
                lblPercent.Text = percentage + "%";
                PbProgress.ProgressBarStyle = ProgressBarStyle.Continuous;
                PbProgress.Value = percentage;
            }
        }
    }
}