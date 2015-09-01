using MetroFramework.Controls;
using Net.Bertware.Bukkitgui2.Core;

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
			this.components = new System.ComponentModel.Container();
			this.btnUpdate = new MetroFramework.Controls.MetroButton();
			this.btnVersions = new MetroFramework.Controls.MetroButton();
			this.btnRemove = new MetroFramework.Controls.MetroButton();
			this.slvPlugins = new Net.Bertware.Bukkitgui2.Controls.SortableListView.SortableListView();
			this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColAuthor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colLatestVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colInstalled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnOpenFolder = new MetroFramework.Controls.MetroButton();
			this.CtxMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
			this.CBtnUpdate = new System.Windows.Forms.ToolStripMenuItem();
			this.CBtnShowVersions = new System.Windows.Forms.ToolStripMenuItem();
			this.CBtnViewWebsite = new System.Windows.Forms.ToolStripMenuItem();
			this.CBtnUninstall = new System.Windows.Forms.ToolStripMenuItem();
			this.CBtnRefreshList = new System.Windows.Forms.ToolStripMenuItem();
			this.CBtnOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
			this.CtxMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnUpdate
			// 
			this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUpdate.Enabled = false;
			this.btnUpdate.Location = new System.Drawing.Point(540, 414);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(75, 23);
			this.btnUpdate.TabIndex = 7;
			this.btnUpdate.Text = "Update";
			this.btnUpdate.UseSelectable = true;
			this.btnUpdate.Click += new System.EventHandler(this.UpdateSelectedPlugins);
			// 
			// btnVersions
			// 
			this.btnVersions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnVersions.Enabled = false;
			this.btnVersions.Location = new System.Drawing.Point(621, 414);
			this.btnVersions.Name = "btnVersions";
			this.btnVersions.Size = new System.Drawing.Size(75, 23);
			this.btnVersions.TabIndex = 6;
			this.btnVersions.Text = "Versions";
			this.btnVersions.UseSelectable = true;
			this.btnVersions.Click += new System.EventHandler(this.ShowVersions);
			// 
			// btnRemove
			// 
			this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRemove.Enabled = false;
			this.btnRemove.Location = new System.Drawing.Point(702, 414);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(75, 23);
			this.btnRemove.TabIndex = 5;
			this.btnRemove.Text = "Remove";
			this.btnRemove.UseSelectable = true;
			this.btnRemove.Click += new System.EventHandler(this.UninstallSelectedPlugins);
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
			this.slvPlugins.ContextMenuStrip = this.CtxMenu;
			this.slvPlugins.FullRowSelect = true;
			this.slvPlugins.Location = new System.Drawing.Point(3, 3);
			this.slvPlugins.Name = "slvPlugins";
			this.slvPlugins.Size = new System.Drawing.Size(774, 405);
			this.slvPlugins.TabIndex = 4;
			this.slvPlugins.UseCompatibleStateImageBehavior = false;
			this.slvPlugins.View = System.Windows.Forms.View.Details;
			this.slvPlugins.SelectedIndexChanged += new System.EventHandler(this.slvPlugins_SelectedIndexChanged);
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
			// btnOpenFolder
			// 
			this.btnOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOpenFolder.Location = new System.Drawing.Point(459, 414);
			this.btnOpenFolder.Name = "btnOpenFolder";
			this.btnOpenFolder.Size = new System.Drawing.Size(75, 23);
			this.btnOpenFolder.TabIndex = 8;
			this.btnOpenFolder.Text = "Open folder";
			this.btnOpenFolder.UseSelectable = true;
			this.btnOpenFolder.Click += new System.EventHandler(this.OpenPluginFolder);
			// 
			// CtxMenu
			// 
			this.CtxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CBtnUpdate,
            this.CBtnShowVersions,
            this.CBtnViewWebsite,
            this.CBtnUninstall,
            this.CBtnRefreshList,
            this.CBtnOpenFolder});
			this.CtxMenu.Name = "CtxMenu";
			this.CtxMenu.Size = new System.Drawing.Size(150, 136);
			// 
			// CBtnUpdate
			// 
			this.CBtnUpdate.Name = "CBtnUpdate";
			this.CBtnUpdate.Size = new System.Drawing.Size(149, 22);
			this.CBtnUpdate.Text = "Update";
			this.CBtnUpdate.Click += new System.EventHandler(this.UpdateSelectedPlugins);
			// 
			// CBtnShowVersions
			// 
			this.CBtnShowVersions.Name = "CBtnShowVersions";
			this.CBtnShowVersions.Size = new System.Drawing.Size(149, 22);
			this.CBtnShowVersions.Text = "Show versions";
			this.CBtnShowVersions.Click += new System.EventHandler(this.ShowVersions);
			// 
			// CBtnViewWebsite
			// 
			this.CBtnViewWebsite.Name = "CBtnViewWebsite";
			this.CBtnViewWebsite.Size = new System.Drawing.Size(149, 22);
			this.CBtnViewWebsite.Text = "View online";
			this.CBtnViewWebsite.Click += new System.EventHandler(this.ShowSelectedPluginsWebpage);
			// 
			// CBtnUninstall
			// 
			this.CBtnUninstall.Name = "CBtnUninstall";
			this.CBtnUninstall.Size = new System.Drawing.Size(149, 22);
			this.CBtnUninstall.Text = "Uninstall";
			this.CBtnUninstall.Click += new System.EventHandler(this.UninstallSelectedPlugins);
			// 
			// CBtnRefreshList
			// 
			this.CBtnRefreshList.Name = "CBtnRefreshList";
			this.CBtnRefreshList.Size = new System.Drawing.Size(149, 22);
			this.CBtnRefreshList.Text = "Refresh list";
			this.CBtnRefreshList.Click += new System.EventHandler(this.ReloadInstalledPlugins);
			// 
			// CBtnOpenFolder
			// 
			this.CBtnOpenFolder.Name = "CBtnOpenFolder";
			this.CBtnOpenFolder.Size = new System.Drawing.Size(149, 22);
			this.CBtnOpenFolder.Text = "Open folder";
			this.CBtnOpenFolder.Click += new System.EventHandler(this.OpenPluginFolder);
			// 
			// InstalledPluginsControl
			// 
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.btnOpenFolder);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.btnVersions);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.slvPlugins);
			this.Name = "InstalledPluginsControl";
			this.Size = new System.Drawing.Size(780, 440);
			this.CtxMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private MetroButton btnUpdate;
		private MetroButton btnVersions;
		private MetroButton btnRemove;
		private Controls.SortableListView.SortableListView slvPlugins;
		private System.Windows.Forms.ColumnHeader colName;
		private System.Windows.Forms.ColumnHeader colDescription;
		private System.Windows.Forms.ColumnHeader ColAuthor;
		private System.Windows.Forms.ColumnHeader colVersion;
		private System.Windows.Forms.ColumnHeader colLatestVersion;
		private System.Windows.Forms.ColumnHeader colInstalled;
		private MetroButton btnOpenFolder;
		private MetroContextMenu CtxMenu;
		private System.Windows.Forms.ToolStripMenuItem CBtnUpdate;
		private System.Windows.Forms.ToolStripMenuItem CBtnShowVersions;
		private System.Windows.Forms.ToolStripMenuItem CBtnViewWebsite;
		private System.Windows.Forms.ToolStripMenuItem CBtnUninstall;
		private System.Windows.Forms.ToolStripMenuItem CBtnRefreshList;
		private System.Windows.Forms.ToolStripMenuItem CBtnOpenFolder;
	}
}
