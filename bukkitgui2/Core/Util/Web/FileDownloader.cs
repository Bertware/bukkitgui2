namespace Bukkitgui2.Core.Util.Web
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Net;
    using System.Threading;
    using System.Windows.Forms;

    using Bukkitgui2.Core.Logging;

    public partial class FileDownloader : Form
    {
        /// <summary>
        ///     Dictionary containing URLs of files to download and their target locations
        /// </summary>
        private readonly Dictionary<string, string> _files;

        /// <summary>
        ///     Dictionary containing URLs of files to download and their controls
        /// </summary>
        private readonly Dictionary<string, FileDownloadProgressBar> _downloads;

        public FileDownloader()
        {
            this.InitializeComponent();
            this.Size= new Size(500,50);
            this._files = new Dictionary<string, string>();
            this._downloads = new Dictionary<string, FileDownloadProgressBar>();
        }

        /// <summary>
        /// Add a files to the list of files to be downloaded
        /// </summary>
        /// <param name="url">the URL to download the file from</param>
        /// <param name="targetlocation">the target location to save the file to</param>
        /// <returns></returns>
        public Boolean AddFile(string url, string targetlocation)
        {
            this._files.Add(url, targetlocation);
            this.Size = new Size(this.Size.Width, this.Size.Height + 50); // make room for new control

            // create new control
            FileDownloadProgressBar control = new FileDownloadProgressBar
                                                  {
                                                      Location =
                                                          new Point(0, _files.Count * 50 - 50)
                                                  };
            control.CreateDownload(url, targetlocation);
            this._downloads.Add(url, control);
            this.Controls.Add(control);

            return true;
        }

        /// <summary>
        /// Start the download of the files
        /// </summary>
        public void StartDownload()
        {
            Logger.Log(LogLevel.Info, "FileDownloader", "Starting " + _downloads.Count + " download(s)");
            foreach (FileDownloadProgressBar control in this._downloads.Values)
            {
                control.DownloadCompleted += this.HandleDownloadFinished;
                control.StartDownload();
            } 
        }


        private int _finishedDownloads;

        private void HandleDownloadFinished(object sender, DownloadDataCompletedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() => this.HandleDownloadFinished(sender, e)));
            }
            else
            {
                this._finishedDownloads++;
                if (this._finishedDownloads == this._files.Count)
                {
                    this.Close();
                }
            }
        }
    }
}