using System.Windows.Forms;
using MetroFramework.Controls;

namespace Net.Bertware.Bukkitgui2.AddOn.Plugins.InstalledPlugins
{
	partial class PluginUpdater
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
			this.ColPlugName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColPlugCurVer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColPlugNewVer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColPlugNewBukkit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ChkCheckAll = new MetroFramework.Controls.MetroCheckBox();
			this.LblBukkitBuild = new MetroFramework.Controls.MetroLabel();
			this.ChkForce = new MetroFramework.Controls.MetroCheckBox();
			this.BtnClose = new MetroFramework.Controls.MetroButton();
			this.BtnUpdate = new MetroFramework.Controls.MetroButton();
			this.CBBukkitBuild = new MetroFramework.Controls.MetroComboBox();
			this.lblStatus = new MetroFramework.Controls.MetroLabel();
			this.ProgBar = new MetroFramework.Controls.MetroProgressBar();
			this.SlvPlugins = new Net.Bertware.Bukkitgui2.Controls.SortableListView.SortableListView();
			this.SuspendLayout();
			// 
			// ColPlugName
			// 
			this.ColPlugName.Text = "Plugin";
			this.ColPlugName.Width = 294;
			// 
			// ColPlugCurVer
			// 
			this.ColPlugCurVer.Text = "Current Version";
			this.ColPlugCurVer.Width = 95;
			// 
			// ColPlugNewVer
			// 
			this.ColPlugNewVer.Text = "New version";
			this.ColPlugNewVer.Width = 81;
			// 
			// ColPlugNewBukkit
			// 
			this.ColPlugNewBukkit.Text = "Bukkit Version";
			this.ColPlugNewBukkit.Width = 111;
			// 
			// ChkCheckAll
			// 
			this.ChkCheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ChkCheckAll.AutoSize = true;
			this.ChkCheckAll.Location = new System.Drawing.Point(23, 443);
			this.ChkCheckAll.Name = "ChkCheckAll";
			this.ChkCheckAll.Size = new System.Drawing.Size(71, 15);
			this.ChkCheckAll.TabIndex = 15;
			this.ChkCheckAll.Text = "Check all";
			this.ChkCheckAll.UseSelectable = true;
			this.ChkCheckAll.CheckedChanged += new System.EventHandler(this.ChkCheckAll_CheckedChanged);
			// 
			// LblBukkitBuild
			// 
			this.LblBukkitBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.LblBukkitBuild.Enabled = false;
			this.LblBukkitBuild.Location = new System.Drawing.Point(351, 443);
			this.LblBukkitBuild.Name = "LblBukkitBuild";
			this.LblBukkitBuild.Size = new System.Drawing.Size(170, 29);
			this.LblBukkitBuild.TabIndex = 14;
			this.LblBukkitBuild.Text = "Update for bukkit build:";
			this.LblBukkitBuild.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.LblBukkitBuild.Visible = false;
			// 
			// ChkForce
			// 
			this.ChkForce.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ChkForce.AutoSize = true;
			this.ChkForce.Enabled = false;
			this.ChkForce.Location = new System.Drawing.Point(23, 464);
			this.ChkForce.Name = "ChkForce";
			this.ChkForce.Size = new System.Drawing.Size(200, 15);
			this.ChkForce.TabIndex = 13;
			this.ChkForce.Text = "Force update if already up to date";
			this.ChkForce.UseSelectable = true;
			this.ChkForce.Visible = false;
			// 
			// BtnClose
			// 
			this.BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnClose.Location = new System.Drawing.Point(649, 478);
			this.BtnClose.Name = "BtnClose";
			this.BtnClose.Size = new System.Drawing.Size(75, 23);
			this.BtnClose.TabIndex = 12;
			this.BtnClose.Text = "Close";
			this.BtnClose.UseSelectable = true;
			this.BtnClose.Click += new System.EventHandler(this.CloseThisForm);
			// 
			// BtnUpdate
			// 
			this.BtnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnUpdate.Location = new System.Drawing.Point(730, 478);
			this.BtnUpdate.Name = "BtnUpdate";
			this.BtnUpdate.Size = new System.Drawing.Size(75, 23);
			this.BtnUpdate.TabIndex = 11;
			this.BtnUpdate.Text = "Update!";
			this.BtnUpdate.UseSelectable = true;
			this.BtnUpdate.Click += new System.EventHandler(this.Plugins_Update);
			// 
			// CBBukkitBuild
			// 
			this.CBBukkitBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CBBukkitBuild.Enabled = false;
			this.CBBukkitBuild.FormattingEnabled = true;
			this.CBBukkitBuild.ItemHeight = 23;
			this.CBBukkitBuild.Location = new System.Drawing.Point(527, 443);
			this.CBBukkitBuild.Name = "CBBukkitBuild";
			this.CBBukkitBuild.Size = new System.Drawing.Size(278, 29);
			this.CBBukkitBuild.TabIndex = 10;
			this.CBBukkitBuild.UseSelectable = true;
			this.CBBukkitBuild.Visible = false;
			// 
			// lblStatus
			// 
			this.lblStatus.AutoSize = true;
			this.lblStatus.Location = new System.Drawing.Point(23, 60);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(71, 19);
			this.lblStatus.TabIndex = 9;
			this.lblStatus.Text = "Status: Idle";
			// 
			// ProgBar
			// 
			this.ProgBar.Location = new System.Drawing.Point(23, 82);
			this.ProgBar.Name = "ProgBar";
			this.ProgBar.Size = new System.Drawing.Size(782, 23);
			this.ProgBar.TabIndex = 16;
			// 
			// SlvPlugins
			// 
			this.SlvPlugins.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SlvPlugins.CheckBoxes = true;
			this.SlvPlugins.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColPlugName, this.ColPlugCurVer, this.ColPlugNewVer, this.ColPlugNewBukkit });
			this.SlvPlugins.Location = new System.Drawing.Point(23, 111);
			this.SlvPlugins.Name = "SlvPlugins";
			this.SlvPlugins.Size = new System.Drawing.Size(782, 326);
			this.SlvPlugins.TabIndex = 17;
			this.SlvPlugins.UseCompatibleStateImageBehavior = false;
			this.SlvPlugins.View = System.Windows.Forms.View.Details;
			// 
			// PluginUpdater
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(828, 524);
			this.Controls.Add(this.SlvPlugins);
			this.Controls.Add(this.ProgBar);
			this.Controls.Add(this.ChkCheckAll);
			this.Controls.Add(this.LblBukkitBuild);
			this.Controls.Add(this.ChkForce);
			this.Controls.Add(this.BtnClose);
			this.Controls.Add(this.BtnUpdate);
			this.Controls.Add(this.CBBukkitBuild);
			this.Controls.Add(this.lblStatus);
			this.Name = "PluginUpdater";
			this.Text = "PluginUpdater";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.ColumnHeader ColPlugName;
		internal System.Windows.Forms.ColumnHeader ColPlugCurVer;
		internal System.Windows.Forms.ColumnHeader ColPlugNewVer;
		internal System.Windows.Forms.ColumnHeader ColPlugNewBukkit;
		internal MetroCheckBox ChkCheckAll;
		internal MetroLabel LblBukkitBuild;
		internal MetroCheckBox ChkForce;
		internal MetroButton BtnClose;
		internal MetroButton BtnUpdate;
		internal MetroComboBox CBBukkitBuild;
		internal MetroLabel lblStatus;
		private MetroFramework.Controls.MetroProgressBar ProgBar;
		private Controls.SortableListView.SortableListView SlvPlugins;
	}
}