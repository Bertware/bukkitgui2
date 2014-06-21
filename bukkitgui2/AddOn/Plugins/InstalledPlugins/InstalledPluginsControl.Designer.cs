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
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.btnRemove = new System.Windows.Forms.Button();
			this.slvPlugins = new Net.Bertware.Bukkitgui2.Controls.SortableListView.SortableListView();
			this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colLatestVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colInstalled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColAuthor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.Location = new System.Drawing.Point(540, 414);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 7;
			this.button3.Text = "Info";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(621, 414);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 6;
			this.button2.Text = "Versions";
			this.button2.UseVisualStyleBackColor = true;
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
			// ColAuthor
			// 
			this.ColAuthor.Text = "Author(s)";
			this.ColAuthor.Width = 100;
			// 
			// InstalledPluginsControl
			// 
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.slvPlugins);
			this.Name = "InstalledPluginsControl";
			this.Size = new System.Drawing.Size(780, 440);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
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
