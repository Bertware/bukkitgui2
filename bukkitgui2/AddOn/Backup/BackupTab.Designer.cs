using MetroFramework.Controls;
using Net.Bertware.Bukkitgui2.Core;

namespace Net.Bertware.Bukkitgui2.AddOn.Backup
{
	partial class BackupTab
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
			this.BtnBackupExecute = new MetroFramework.Controls.MetroButton();
			this.BtnBackupAdd = new MetroFramework.Controls.MetroButton();
			this.BtnBackupEdit = new MetroFramework.Controls.MetroButton();
			this.ColBackupName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColBackupFolders = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColBackupDestination = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColBackupCompression = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.BtnBackupRemove = new MetroFramework.Controls.MetroButton();
			this.SlvBackups = new Net.Bertware.Bukkitgui2.Controls.SortableListView.SortableListView();
			this.SuspendLayout();
			// 
			// BtnBackupExecute
			// 
			this.BtnBackupExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnBackupExecute.Location = new System.Drawing.Point(479, 474);
			this.BtnBackupExecute.Name = "BtnBackupExecute";
			this.BtnBackupExecute.Size = new System.Drawing.Size(75, 23);
			this.BtnBackupExecute.TabIndex = 16;
			this.BtnBackupExecute.Text = "Execute";
			this.BtnBackupExecute.UseSelectable = true;
			this.BtnBackupExecute.Click += new System.EventHandler(this.BtnBackupExecute_Click);
			// 
			// BtnBackupAdd
			// 
			this.BtnBackupAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnBackupAdd.Location = new System.Drawing.Point(560, 474);
			this.BtnBackupAdd.Name = "BtnBackupAdd";
			this.BtnBackupAdd.Size = new System.Drawing.Size(75, 23);
			this.BtnBackupAdd.TabIndex = 13;
			this.BtnBackupAdd.Text = "Add...";
			this.BtnBackupAdd.UseSelectable = true;
			this.BtnBackupAdd.Click += new System.EventHandler(this.BtnBackupAdd_Click);
			// 
			// BtnBackupEdit
			// 
			this.BtnBackupEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnBackupEdit.Location = new System.Drawing.Point(641, 474);
			this.BtnBackupEdit.Name = "BtnBackupEdit";
			this.BtnBackupEdit.Size = new System.Drawing.Size(75, 23);
			this.BtnBackupEdit.TabIndex = 14;
			this.BtnBackupEdit.Text = "Edit...";
			this.BtnBackupEdit.UseSelectable = true;
			this.BtnBackupEdit.Click += new System.EventHandler(this.BtnBackupEdit_Click);
			// 
			// ColBackupName
			// 
			this.ColBackupName.Text = "Name";
			this.ColBackupName.Width = 150;
			// 
			// ColBackupFolders
			// 
			this.ColBackupFolders.Text = "Folders";
			this.ColBackupFolders.Width = 280;
			// 
			// ColBackupDestination
			// 
			this.ColBackupDestination.Text = "Destination";
			this.ColBackupDestination.Width = 280;
			// 
			// ColBackupCompression
			// 
			this.ColBackupCompression.Text = "Compression";
			this.ColBackupCompression.Width = 80;
			// 
			// BtnBackupRemove
			// 
			this.BtnBackupRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnBackupRemove.Location = new System.Drawing.Point(722, 474);
			this.BtnBackupRemove.Name = "BtnBackupRemove";
			this.BtnBackupRemove.Size = new System.Drawing.Size(75, 23);
			this.BtnBackupRemove.TabIndex = 15;
			this.BtnBackupRemove.Text = "Remove";
			this.BtnBackupRemove.UseSelectable = true;
			this.BtnBackupRemove.Click += new System.EventHandler(this.BtnBackupRemove_Click);
			// 
			// SlvBackups
			// 
			this.SlvBackups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SlvBackups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColBackupName,
            this.ColBackupFolders,
            this.ColBackupDestination,
            this.ColBackupCompression});
			this.SlvBackups.FullRowSelect = true;
			this.SlvBackups.Location = new System.Drawing.Point(3, 3);
			this.SlvBackups.Name = "SlvBackups";
			this.SlvBackups.Size = new System.Drawing.Size(794, 465);
			this.SlvBackups.TabIndex = 17;
			this.SlvBackups.UseCompatibleStateImageBehavior = false;
			this.SlvBackups.View = System.Windows.Forms.View.Details;
			// 
			// BackupTab
			// 
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.SlvBackups);
			this.Controls.Add(this.BtnBackupExecute);
			this.Controls.Add(this.BtnBackupAdd);
			this.Controls.Add(this.BtnBackupEdit);
			this.Controls.Add(this.BtnBackupRemove);
			this.Name = "BackupTab";
			this.Size = new System.Drawing.Size(800, 500);
			this.ResumeLayout(false);

		}

		#endregion

		internal MetroButton BtnBackupExecute;
		internal MetroButton BtnBackupAdd;
		internal MetroButton BtnBackupEdit;
		internal System.Windows.Forms.ColumnHeader ColBackupName;
		internal System.Windows.Forms.ColumnHeader ColBackupFolders;
		internal System.Windows.Forms.ColumnHeader ColBackupDestination;
		internal System.Windows.Forms.ColumnHeader ColBackupCompression;
		internal MetroButton BtnBackupRemove;
		private Controls.SortableListView.SortableListView SlvBackups;


	}
}
