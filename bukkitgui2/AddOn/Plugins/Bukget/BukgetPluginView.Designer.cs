namespace Net.Bertware.Bukkitgui2.AddOn.Plugins.Bukget
{
	partial class BukgetPluginView
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
			this.gbGeneral = new System.Windows.Forms.GroupBox();
			this.lblPluginDetail = new System.Windows.Forms.Label();
			this.gbVersions = new System.Windows.Forms.GroupBox();
			this.btnInstall = new System.Windows.Forms.Button();
			this.BtnClose = new System.Windows.Forms.Button();
			this.slvVersions = new Net.Bertware.Bukkitgui2.Controls.SortableListView.SortableListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.gbGeneral.SuspendLayout();
			this.gbVersions.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbGeneral
			// 
			this.gbGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbGeneral.Controls.Add(this.lblPluginDetail);
			this.gbGeneral.Location = new System.Drawing.Point(12, 12);
			this.gbGeneral.Name = "gbGeneral";
			this.gbGeneral.Size = new System.Drawing.Size(760, 278);
			this.gbGeneral.TabIndex = 0;
			this.gbGeneral.TabStop = false;
			this.gbGeneral.Text = "General";
			// 
			// lblPluginDetail
			// 
			this.lblPluginDetail.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblPluginDetail.Location = new System.Drawing.Point(3, 16);
			this.lblPluginDetail.Name = "lblPluginDetail";
			this.lblPluginDetail.Size = new System.Drawing.Size(754, 259);
			this.lblPluginDetail.TabIndex = 0;
			this.lblPluginDetail.Text = "Plugin details";
			// 
			// gbVersions
			// 
			this.gbVersions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbVersions.Controls.Add(this.BtnClose);
			this.gbVersions.Controls.Add(this.btnInstall);
			this.gbVersions.Controls.Add(this.slvVersions);
			this.gbVersions.Location = new System.Drawing.Point(12, 296);
			this.gbVersions.Name = "gbVersions";
			this.gbVersions.Size = new System.Drawing.Size(760, 254);
			this.gbVersions.TabIndex = 1;
			this.gbVersions.TabStop = false;
			this.gbVersions.Text = "Versions";
			// 
			// btnInstall
			// 
			this.btnInstall.Location = new System.Drawing.Point(598, 225);
			this.btnInstall.Name = "btnInstall";
			this.btnInstall.Size = new System.Drawing.Size(75, 23);
			this.btnInstall.TabIndex = 1;
			this.btnInstall.Text = "&Install";
			this.btnInstall.UseVisualStyleBackColor = true;
			this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
			// 
			// BtnClose
			// 
			this.BtnClose.Location = new System.Drawing.Point(679, 225);
			this.BtnClose.Name = "BtnClose";
			this.BtnClose.Size = new System.Drawing.Size(75, 23);
			this.BtnClose.TabIndex = 2;
			this.BtnClose.Text = "&Close";
			this.BtnClose.UseVisualStyleBackColor = true;
			this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
			// 
			// slvVersions
			// 
			this.slvVersions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.slvVersions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
			this.slvVersions.FullRowSelect = true;
			this.slvVersions.Location = new System.Drawing.Point(6, 19);
			this.slvVersions.Name = "slvVersions";
			this.slvVersions.Size = new System.Drawing.Size(748, 200);
			this.slvVersions.TabIndex = 0;
			this.slvVersions.UseCompatibleStateImageBehavior = false;
			this.slvVersions.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Version";
			this.columnHeader1.Width = 120;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Filename";
			this.columnHeader2.Width = 180;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Game builds";
			this.columnHeader3.Width = 180;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Release date";
			this.columnHeader4.Width = 80;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Type";
			this.columnHeader5.Width = 80;
			// 
			// BukgetPluginView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 562);
			this.Controls.Add(this.gbVersions);
			this.Controls.Add(this.gbGeneral);
			this.Name = "BukgetPluginView";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "BukgetPluginView";
			this.gbGeneral.ResumeLayout(false);
			this.gbVersions.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbGeneral;
		private System.Windows.Forms.GroupBox gbVersions;
		private System.Windows.Forms.Button btnInstall;
		private Controls.SortableListView.SortableListView slvVersions;
		private System.Windows.Forms.Label lblPluginDetail;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.Button BtnClose;
	}
}