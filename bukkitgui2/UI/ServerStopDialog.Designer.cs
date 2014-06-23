namespace Net.Bertware.Bukkitgui2.UI
{
	partial class ServerStopDialog
	{
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblInfo = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.progBar = new System.Windows.Forms.ProgressBar();
			this.btnKill = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblInfo
			// 
			this.lblInfo.AutoSize = true;
			this.lblInfo.Location = new System.Drawing.Point(12, 9);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(134, 13);
			this.lblInfo.TabIndex = 0;
			this.lblInfo.Text = "Waiting for server to stop...";
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(251, 54);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// progBar
			// 
			this.progBar.Location = new System.Drawing.Point(12, 25);
			this.progBar.Name = "progBar";
			this.progBar.Size = new System.Drawing.Size(314, 23);
			this.progBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.progBar.TabIndex = 2;
			// 
			// btnKill
			// 
			this.btnKill.Location = new System.Drawing.Point(170, 54);
			this.btnKill.Name = "btnKill";
			this.btnKill.Size = new System.Drawing.Size(75, 23);
			this.btnKill.TabIndex = 3;
			this.btnKill.Text = "&Kill";
			this.btnKill.UseVisualStyleBackColor = true;
			this.btnKill.Click += new System.EventHandler(this.btnKill_Click);
			// 
			// ServerStopDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(338, 87);
			this.Controls.Add(this.btnKill);
			this.Controls.Add(this.progBar);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.lblInfo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "ServerStopDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "ServerStopDialog";
			this.Load += new System.EventHandler(this.ServerStopDialog_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblInfo;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ProgressBar progBar;
		private System.Windows.Forms.Button btnKill;
	}
}