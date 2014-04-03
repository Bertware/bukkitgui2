namespace Bukkitgui2.Core.Util.Web
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Windows.Forms;

    using Bukkitgui2.Core.FileLocation;
    using Bukkitgui2.Core.Logging;

    using Timer = System.Windows.Forms.Timer;

    /// <summary>
    ///     control to download a file async, while showing a progressbar with details
    /// </summary>
    public partial class FileDownloadProgressBar : UserControl
    {
        private readonly string _tmp = DefaultFileLocation.Location(RequestFile.Temp)  + "download\\";

        private const int TmrInterval = 250;
        
        private WebClient _webc;

        private string _filename;

        private int _percent;

        private int _totalKb;

        private string _url;

        private string _targetlocation;

        private string _tmplocation;

        public event DownloadDataCompletedEventHandler DownloadCompleted;

        private Timer _tmrUpdateUi;

        /// <summary>
        ///     Create a new instance
        /// </summary>
        public FileDownloadProgressBar()
        {
            this.InitializeComponent();
            if (!Directory.Exists(_tmp)) Directory.CreateDirectory(_tmp);
        }

        /// <summary>
        ///     Create a new download
        /// </summary>
        /// <param name="url">Url to download from</param>
        /// <param name="targetlocation">targetlocation to save the file</param>
        public void CreateDownload(string url, string targetlocation)
        {
            this._webc = new WebClient();
            this._url = url;

            this._filename = Regex.Match(this._url, "\\/[^\\\\\\/]+$").Value.Substring(1);

            //if not ending on extension, add file name
            if (!Regex.IsMatch(targetlocation, "\\w\\.\\{2,5}$")) targetlocation += "\\" + _filename; 

            this._targetlocation = targetlocation;
            
            this._tmplocation = this._tmp + this._filename;
        }

        /// <summary>
        ///     Start the download
        /// </summary>
        public void StartDownload()
        {

            this._webc.Headers.Add(HttpRequestHeader.UserAgent,WebUtil.UserAgent);
            this._webc.DownloadProgressChanged += this.UpdateStats;
            this._webc.DownloadDataCompleted += this.Finished;
            Logger.Log(LogLevel.Info, "FileDownloadProgressBar", "Starting download", _url);

            Thread t = new Thread(() => _webc.DownloadFileAsync(new Uri(this._url), this._tmplocation));
            t.Start();
            Logger.Log(LogLevel.Info, "FileDownloadProgressBar", "Started download", _url);
            this._tmrUpdateUi = new Timer { Interval = TmrInterval };
            this._tmrUpdateUi.Tick += this.UpdateUi;
            this._tmrUpdateUi.Start();
        }

        /// <summary>
        ///     Cancel the download
        /// </summary>
        public void Cancel()
        {
            this._webc.CancelAsync();
            File.Delete(this._tmplocation);
            DownloadDataCompletedEventHandler handler = this.DownloadCompleted;
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
        private void Finished(object sender, DownloadDataCompletedEventArgs e)
        {
            Logger.Log(LogLevel.Info,"FileDownloadProgressBar","Download finished!",_url);
            // Move to the correct location
            if (File.Exists(this._targetlocation))
            {
                File.Delete(this._targetlocation);
            }
            File.Move(this._tmplocation, this._targetlocation);

            DownloadDataCompletedEventHandler handler = this.DownloadCompleted;
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
            this._e = e;
        }

        /// <summary>
        ///     Update the UI every 500ms using a timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="timerElapsedEventArgs"></param>
        private void UpdateUi(object sender, EventArgs timerElapsedEventArgs)
        {
            if (_e == null) {

                this.SetInfoText("Initiating download: " + this._filename);
                return; // no data yet
            }

            this._totalKb = (int)(this._e.TotalBytesToReceive / 1024);

            int downloadedKb = (int)(this._e.BytesReceived / 1024);
            this._percent = _e.ProgressPercentage;

            // this is updated every 500ms. Therefore, deltaKb is half the download speed per second
            int deltaKb1 = this._receivedKbHist1 - this._receivedKbHist2;
            int deltaKb2 = downloadedKb - this._receivedKbHist1;

            // calculate the average. We would have to divide by 2, but since we need to 
            // mulitply both values by 2 to get the speed per second, we can simplify this.
            int downloadSpeed = ((deltaKb1 + deltaKb2) / 2) * ( 1000 / TmrInterval);

            this._receivedKbHist2 = this._receivedKbHist1;
            this._receivedKbHist1 = downloadedKb;

            this.SetInfoText("Downloading: " + this._filename + " : " + downloadedKb + "/" + this._totalKb + "Kb @ "
                                + downloadSpeed + "kbps");

            this.SetPercentage(this._percent);
        }

        private void SetInfoText(String text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() => this.SetInfoText(text)));
            }
            else
            {
                this.lblInfo.Text = text;
            }
        }

        private void SetPercentage(int percentage)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() => this.SetPercentage(percentage)));
            }
            else
            {
                this.lblPercent.Text = percentage + "%";
                this.PbProgress.Style = ProgressBarStyle.Continuous;
                this.PbProgress.Value = percentage;
            }
        }

    }
}