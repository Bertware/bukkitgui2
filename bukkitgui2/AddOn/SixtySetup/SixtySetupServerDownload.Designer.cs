namespace Net.Bertware.Bukkitgui2.AddOn.SixtySetup
{
	partial class SixtySetupServerDownload
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SixtySetupServerDownload));
			this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
			this.MetroTileBetaBuild = new MetroFramework.Controls.MetroTile();
			this.MetroTileDevBuild = new MetroFramework.Controls.MetroTile();
			this.metroTileRecommendedBuild = new MetroFramework.Controls.MetroTile();
			this.SuspendLayout();
			// 
			// metroLabel1
			// 
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.Location = new System.Drawing.Point(3, 0);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new System.Drawing.Size(425, 95);
			this.metroLabel1.TabIndex = 7;
			this.metroLabel1.Text = resources.GetString("metroLabel1.Text");
			// 
			// MetroTileBetaBuild
			// 
			this.MetroTileBetaBuild.ActiveControl = null;
			this.MetroTileBetaBuild.Location = new System.Drawing.Point(137, 117);
			this.MetroTileBetaBuild.Name = "MetroTileBetaBuild";
			this.MetroTileBetaBuild.Size = new System.Drawing.Size(128, 128);
			this.MetroTileBetaBuild.Style = MetroFramework.MetroColorStyle.Orange;
			this.MetroTileBetaBuild.TabIndex = 6;
			this.MetroTileBetaBuild.Text = "Beta \r\nBuild";
			this.MetroTileBetaBuild.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
			this.MetroTileBetaBuild.UseSelectable = true;
			this.MetroTileBetaBuild.Click += new System.EventHandler(this.MetroTileBetaBuild_Click);
			// 
			// MetroTileDevBuild
			// 
			this.MetroTileDevBuild.ActiveControl = null;
			this.MetroTileDevBuild.Location = new System.Drawing.Point(271, 117);
			this.MetroTileDevBuild.Name = "MetroTileDevBuild";
			this.MetroTileDevBuild.Size = new System.Drawing.Size(128, 128);
			this.MetroTileDevBuild.Style = MetroFramework.MetroColorStyle.Red;
			this.MetroTileDevBuild.TabIndex = 5;
			this.MetroTileDevBuild.Text = "Development \r\nBuild";
			this.MetroTileDevBuild.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
			this.MetroTileDevBuild.UseSelectable = true;
			this.MetroTileDevBuild.Click += new System.EventHandler(this.MetroTileDevBuild_Click);
			// 
			// metroTileRecommendedBuild
			// 
			this.metroTileRecommendedBuild.ActiveControl = null;
			this.metroTileRecommendedBuild.Location = new System.Drawing.Point(3, 117);
			this.metroTileRecommendedBuild.Name = "metroTileRecommendedBuild";
			this.metroTileRecommendedBuild.Size = new System.Drawing.Size(128, 128);
			this.metroTileRecommendedBuild.Style = MetroFramework.MetroColorStyle.Green;
			this.metroTileRecommendedBuild.TabIndex = 4;
			this.metroTileRecommendedBuild.Text = "Recommended \r\nBuild";
			this.metroTileRecommendedBuild.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
			this.metroTileRecommendedBuild.UseSelectable = true;
			this.metroTileRecommendedBuild.Click += new System.EventHandler(this.metroTileRecommendedBuild_Click);
			// 
			// SixtySetupServerDownload
			// 
			this.Controls.Add(this.metroLabel1);
			this.Controls.Add(this.MetroTileBetaBuild);
			this.Controls.Add(this.MetroTileDevBuild);
			this.Controls.Add(this.metroTileRecommendedBuild);
			this.Name = "SixtySetupServerDownload";
			this.Size = new System.Drawing.Size(500, 250);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MetroFramework.Controls.MetroLabel metroLabel1;
		private MetroFramework.Controls.MetroTile MetroTileBetaBuild;
		private MetroFramework.Controls.MetroTile MetroTileDevBuild;
		private MetroFramework.Controls.MetroTile metroTileRecommendedBuild;

	}
}
