namespace Net.Bertware.Bukkitgui2.AddOn.Plugins.InstalledPlugins
{
	partial class InstalledPluginsControl
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
			this.btnInfo = new System.Windows.Forms.Button();
			this.btnVersions = new System.Windows.Forms.Button();
			this.btnRemove = new System.Windows.Forms.Button();
			this.slvPlugins = new Net.Bertware.Bukkitgui2.Controls.SortableListView.SortableListView();
			this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColAuthor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colLatestVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colInstalled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// btnInfo
			// 
			this.btnInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnInfo.Location = new System.Drawing.Point(540, 414);
			this.btnInfo.Name = "btnInfo";
			this.btnInfo.Size = new System.Drawing.Size(75, 23);
			this.btnInfo.TabIndex = 7;
			this.btnInfo.Text = "Info";
			this.btnInfo.UseVisualStyleBackColor = true;
			// 
			// btnVersions
			// 
			this.btnVersions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnVersions.Location = new System.Drawing.Point(621, 414);
			this.btnVersions.Name = "btnVersions";
			this.btnVersions.Size = new System.Drawing.Size(75, 23);
			this.btnVersions.TabIndex = 6;
			this.btnVersions.Text = "Versions";
			this.btnVersions.UseVisualStyleBackColor = true;
			this.btnVersions.Click += new System.EventHandler(this.btnVersions_Click);
			// 
			// btnRemove
			// 
			this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRemove.Location = new System.Drawing.Point(702, 414);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(75, 23);
			this.btnRemove.TabIndex = 5;
			this.btnRemove.Text = "Remove";
			this.btnRemove.UseVisualStyleBackColor = true;
			// 
			// slvPlugins
			// 
			this.slvPlugins.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.slvPlugins.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colDescription,
            this.ColAuthor,
            this.colVersion,
            this.colLatestVersion,
            this.colInstalled});
			this.slvPlugins.FullRowSelect = true;
			this.slvPlugins.Location = new System.Drawing.Point(3, 3);
			this.slvPlugins.Name = "slvPlugins";
			this.slvPlugins.Size = new System.Drawing.Size(774, 405);
			this.slvPlugins.TabIndex = 4;
			this.slvPlugins.UseCompatibleStateImageBehavior = false;
			this.slvPlugins.View = System.Windows.Forms.View.Details;
			// 
			// colName
			// 
			this.colName.Text = "Name";
			this.colName.Width = 120;
			// 
			// colDescription
			// 
			this.colDescription.Text = "Description";
			this.colDescription.Width = 220;
			// 
			// ColAuthor
			// 
			this.ColAuthor.Text = "Author(s)";
			this.ColAuthor.Width = 100;
			// 
			// colVersion
			// 
			this.colVersion.Text = "Version";
			this.colVersion.Width = 90;
			// 
			// colLatestVersion
			// 
			this.colLatestVersion.Text = "Latest version";
			this.colLatestVersion.Width = 90;
			// 
			// colInstalled
			// 
			this.colInstalled.Text = "Installed";
			this.colInstalled.Width = 90;
			// 
			// InstalledPluginsControl
			// 
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.btnInfo);
			this.Controls.Add(this.btnVersions);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.slvPlugins);
			this.Name = "InstalledPluginsControl";
			this.Size = new System.Drawing.Size(780, 440);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnInfo;
		private System.Windows.Forms.Button btnVersions;
		private System.Windows.Forms.Button btnRemove;
		private Controls.SortableListView.SortableListView slvPlugins;
		private System.Windows.Forms.ColumnHeader colName;
		private System.Windows.Forms.ColumnHeader colDescription;
		private System.Windows.Forms.ColumnHeader ColAuthor;
		private System.Windows.Forms.ColumnHeader colVersion;
		private System.Windows.Forms.ColumnHeader colLatestVersion;
		private System.Windows.Forms.ColumnHeader colInstalled;
	}
}
