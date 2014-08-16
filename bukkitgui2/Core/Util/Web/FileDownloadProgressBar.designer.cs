using MetroFramework.Controls;

namespace Net.Bertware.Bukkitgui2.Core.Util.Web
{ 
using System.Windows.Forms;

/// <summary>
    ///     control to download a file async, while showing a progressbar with details
    /// </summary>
    public partial class FileDownloadProgressBar : UserControl
    {
		private Label lblInfo;
		private MetroProgressBar PbProgress;
		private Label lblPercent;


		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}
private void InitializeComponent()
		{
			this.lblInfo = new System.Windows.Forms.Label();
			this.PbProgress = new MetroProgressBar();
			this.lblPercent = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblInfo
			// 
			this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblInfo.Location = new System.Drawing.Point(3, 0);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(351, 21);
			this.lblInfo.TabIndex = 0;
			this.lblInfo.Text = "Starting download...";
			this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PbProgress
			// 
			this.PbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.PbProgress.Location = new System.Drawing.Point(3, 24);
			this.PbProgress.MarqueeAnimationSpeed = 10;
			this.PbProgress.Name = "PbProgress";
			this.PbProgress.Size = new System.Drawing.Size(394, 23);
			this.PbProgress.ProgressBarStyle = ProgressBarStyle.Continuous;
			this.PbProgress.TabIndex = 1;
			// 
			// lblPercent
			// 
			this.lblPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPercent.Location = new System.Drawing.Point(360, 0);
			this.lblPercent.Name = "lblPercent";
			this.lblPercent.Size = new System.Drawing.Size(37, 21);
			this.lblPercent.TabIndex = 2;
			this.lblPercent.Text = "100%";
			this.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FileDownloadProgressBar
			// 
			this.Controls.Add(this.lblPercent);
			this.Controls.Add(this.PbProgress);
			this.Controls.Add(this.lblInfo);
			this.Name = "FileDownloadProgressBar";
			this.Size = new System.Drawing.Size(400, 50);
			this.ResumeLayout(false);

		}
	}}