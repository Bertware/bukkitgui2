using MetroFramework.Controls;

namespace Net.Bertware.Bukkitgui2.AddOn.Updater
{
	partial class UpdaterSettings
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.GBOptionsInfoAbout = new System.Windows.Forms.GroupBox();
			this.BtnInfoAppUpdater = new MetroFramework.Controls.MetroButton();
			this.lblInfoAppLatest = new MetroFramework.Controls.MetroLabel();
			this.lblInfoAppCopyright = new MetroFramework.Controls.MetroLabel();
			this.lblInfoAppVersion = new MetroFramework.Controls.MetroLabel();
			this.lblInfoAppAuthors = new MetroFramework.Controls.MetroLabel();
			this.lblInfoAppName = new MetroFramework.Controls.MetroLabel();
			this.GBOptionsInfoAbout.SuspendLayout();
			this.SuspendLayout();
			// 
			// GBOptionsInfoAbout
			// 
			this.GBOptionsInfoAbout.Controls.Add(this.BtnInfoAppUpdater);
			this.GBOptionsInfoAbout.Controls.Add(this.lblInfoAppLatest);
			this.GBOptionsInfoAbout.Controls.Add(this.lblInfoAppCopyright);
			this.GBOptionsInfoAbout.Controls.Add(this.lblInfoAppVersion);
			this.GBOptionsInfoAbout.Controls.Add(this.lblInfoAppAuthors);
			this.GBOptionsInfoAbout.Controls.Add(this.lblInfoAppName);
			this.GBOptionsInfoAbout.Location = new System.Drawing.Point(3, 3);
			this.GBOptionsInfoAbout.Name = "GBOptionsInfoAbout";
			this.GBOptionsInfoAbout.Size = new System.Drawing.Size(554, 176);
			this.GBOptionsInfoAbout.TabIndex = 1;
			this.GBOptionsInfoAbout.TabStop = false;
			this.GBOptionsInfoAbout.Text = "About";
			// 
			// BtnInfoAppUpdater
			// 
			this.BtnInfoAppUpdater.Location = new System.Drawing.Point(6, 147);
			this.BtnInfoAppUpdater.Name = "BtnInfoAppUpdater";
			this.BtnInfoAppUpdater.Size = new System.Drawing.Size(542, 23);
			this.BtnInfoAppUpdater.TabIndex = 5;
			this.BtnInfoAppUpdater.Text = "Open Updater";
			this.BtnInfoAppUpdater.UseSelectable = true;
			this.BtnInfoAppUpdater.Click += new System.EventHandler(this.BtnInfoAppUpdater_Click);
			// 
			// lblInfoAppLatest
			// 
			this.lblInfoAppLatest.AutoSize = true;
			this.lblInfoAppLatest.Location = new System.Drawing.Point(6, 125);
			this.lblInfoAppLatest.Name = "lblInfoAppLatest";
			this.lblInfoAppLatest.Size = new System.Drawing.Size(90, 19);
			this.lblInfoAppLatest.TabIndex = 4;
			this.lblInfoAppLatest.Text = "Latest version:";
			// 
			// lblInfoAppCopyright
			// 
			this.lblInfoAppCopyright.AutoSize = true;
			this.lblInfoAppCopyright.Location = new System.Drawing.Point(6, 80);
			this.lblInfoAppCopyright.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
			this.lblInfoAppCopyright.Name = "lblInfoAppCopyright";
			this.lblInfoAppCopyright.Size = new System.Drawing.Size(70, 19);
			this.lblInfoAppCopyright.TabIndex = 3;
			this.lblInfoAppCopyright.Text = "Copyright:";
			// 
			// lblInfoAppVersion
			// 
			this.lblInfoAppVersion.AutoSize = true;
			this.lblInfoAppVersion.Location = new System.Drawing.Point(6, 59);
			this.lblInfoAppVersion.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
			this.lblInfoAppVersion.Name = "lblInfoAppVersion";
			this.lblInfoAppVersion.Size = new System.Drawing.Size(55, 19);
			this.lblInfoAppVersion.TabIndex = 2;
			this.lblInfoAppVersion.Text = "Version:";
			// 
			// lblInfoAppAuthors
			// 
			this.lblInfoAppAuthors.AutoSize = true;
			this.lblInfoAppAuthors.Location = new System.Drawing.Point(6, 38);
			this.lblInfoAppAuthors.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
			this.lblInfoAppAuthors.Name = "lblInfoAppAuthors";
			this.lblInfoAppAuthors.Size = new System.Drawing.Size(57, 19);
			this.lblInfoAppAuthors.TabIndex = 1;
			this.lblInfoAppAuthors.Text = "Authors:";
			// 
			// lblInfoAppName
			// 
			this.lblInfoAppName.AutoSize = true;
			this.lblInfoAppName.Location = new System.Drawing.Point(6, 17);
			this.lblInfoAppName.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
			this.lblInfoAppName.Name = "lblInfoAppName";
			this.lblInfoAppName.Size = new System.Drawing.Size(48, 19);
			this.lblInfoAppName.TabIndex = 0;
			this.lblInfoAppName.Text = "Name:";
			// 
			// UpdaterSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.GBOptionsInfoAbout);
			this.Name = "UpdaterSettings";
			this.Size = new System.Drawing.Size(560, 490);
			this.Load += new System.EventHandler(this.UpdaterSettings_Load);
			this.GBOptionsInfoAbout.ResumeLayout(false);
			this.GBOptionsInfoAbout.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		internal System.Windows.Forms.GroupBox GBOptionsInfoAbout;
		internal MetroButton BtnInfoAppUpdater;
		internal MetroLabel lblInfoAppLatest;
		internal MetroLabel lblInfoAppCopyright;
		internal MetroLabel lblInfoAppVersion;
		internal MetroLabel lblInfoAppAuthors;
		internal MetroLabel lblInfoAppName;
	}
}
