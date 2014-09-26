using MetroFramework.Controls;

namespace Net.Bertware.Bukkitgui2.AddOn.Backup
{
	partial class BackupDialog
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
			this.components = new System.ComponentModel.Container();
			this.Label3 = new MetroFramework.Controls.MetroLabel();
			this.Label2 = new MetroFramework.Controls.MetroLabel();
			this.TxtName = new MetroFramework.Controls.MetroTextBox();
			this.Label1 = new MetroFramework.Controls.MetroLabel();
			this.TxtDestination = new MetroFramework.Controls.MetroTextBox();
			this.BtnBrowseDestination = new MetroFramework.Controls.MetroButton();
			this.TxtFolders = new MetroFramework.Controls.MetroTextBox();
			this.ChkCompression = new MetroFramework.Controls.MetroCheckBox();
			this.BtnBrowseSourceFolders = new MetroFramework.Controls.MetroButton();
			this.BtnCancel = new MetroFramework.Controls.MetroButton();
			this.BtnOk = new MetroFramework.Controls.MetroButton();
			this.ErrProv = new System.Windows.Forms.ErrorProvider(this.components);
			((System.ComponentModel.ISupportInitialize)(this.ErrProv)).BeginInit();
			this.SuspendLayout();
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(23, 143);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(145, 19);
			this.Label3.TabIndex = 22;
			this.Label3.Text = "Folder to store backup:";
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(23, 57);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(91, 19);
			this.Label2.TabIndex = 21;
			this.Label2.Text = "Backup name:";
			// 
			// TxtName
			// 
			this.TxtName.Lines = new string[0];
			this.TxtName.Location = new System.Drawing.Point(120, 57);
			this.TxtName.MaxLength = 32767;
			this.TxtName.Name = "TxtName";
			this.TxtName.PasswordChar = '\0';
			this.TxtName.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.TxtName.SelectedText = "";
			this.TxtName.Size = new System.Drawing.Size(240, 20);
			this.TxtName.TabIndex = 20;
			this.TxtName.UseSelectable = true;
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(23, 88);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(204, 19);
			this.Label1.TabIndex = 19;
			this.Label1.Text = "Folders to backup, separated by ;";
			// 
			// TxtDestination
			// 
			this.TxtDestination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TxtDestination.Lines = new string[0];
			this.TxtDestination.Location = new System.Drawing.Point(23, 165);
			this.TxtDestination.MaxLength = 32767;
			this.TxtDestination.Name = "TxtDestination";
			this.TxtDestination.PasswordChar = '\0';
			this.TxtDestination.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.TxtDestination.SelectedText = "";
			this.TxtDestination.Size = new System.Drawing.Size(326, 20);
			this.TxtDestination.TabIndex = 18;
			this.TxtDestination.UseSelectable = true;
			// 
			// BtnBrowseDestination
			// 
			this.BtnBrowseDestination.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnBrowseDestination.Location = new System.Drawing.Point(355, 162);
			this.BtnBrowseDestination.Name = "BtnBrowseDestination";
			this.BtnBrowseDestination.Size = new System.Drawing.Size(69, 23);
			this.BtnBrowseDestination.TabIndex = 17;
			this.BtnBrowseDestination.Text = "Browse...";
			this.BtnBrowseDestination.UseSelectable = true;
			this.BtnBrowseDestination.Click += new System.EventHandler(this.BtnBrowseDestination_Click);
			// 
			// TxtFolders
			// 
			this.TxtFolders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TxtFolders.Lines = new string[0];
			this.TxtFolders.Location = new System.Drawing.Point(23, 110);
			this.TxtFolders.MaxLength = 32767;
			this.TxtFolders.Name = "TxtFolders";
			this.TxtFolders.PasswordChar = '\0';
			this.TxtFolders.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.TxtFolders.SelectedText = "";
			this.TxtFolders.Size = new System.Drawing.Size(326, 20);
			this.TxtFolders.TabIndex = 16;
			this.TxtFolders.UseSelectable = true;
			// 
			// ChkCompression
			// 
			this.ChkCompression.AutoSize = true;
			this.ChkCompression.Location = new System.Drawing.Point(23, 191);
			this.ChkCompression.Name = "ChkCompression";
			this.ChkCompression.Size = new System.Drawing.Size(232, 15);
			this.ChkCompression.TabIndex = 15;
			this.ChkCompression.Text = "Compress backup to reduce disk usage.";
			this.ChkCompression.UseSelectable = true;
			// 
			// BtnBrowseSourceFolders
			// 
			this.BtnBrowseSourceFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnBrowseSourceFolders.Location = new System.Drawing.Point(355, 108);
			this.BtnBrowseSourceFolders.Name = "BtnBrowseSourceFolders";
			this.BtnBrowseSourceFolders.Size = new System.Drawing.Size(69, 23);
			this.BtnBrowseSourceFolders.TabIndex = 14;
			this.BtnBrowseSourceFolders.Text = "Browse...";
			this.BtnBrowseSourceFolders.UseSelectable = true;
			this.BtnBrowseSourceFolders.Click += new System.EventHandler(this.BtnBrowseSourceFolders_Click);
			// 
			// BtnCancel
			// 
			this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnCancel.Location = new System.Drawing.Point(268, 210);
			this.BtnCancel.Name = "BtnCancel";
			this.BtnCancel.Size = new System.Drawing.Size(75, 23);
			this.BtnCancel.TabIndex = 13;
			this.BtnCancel.Text = "Cancel";
			this.BtnCancel.UseSelectable = true;
			this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// BtnOk
			// 
			this.BtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnOk.Location = new System.Drawing.Point(349, 210);
			this.BtnOk.Name = "BtnOk";
			this.BtnOk.Size = new System.Drawing.Size(75, 23);
			this.BtnOk.TabIndex = 12;
			this.BtnOk.Text = "Ok";
			this.BtnOk.UseSelectable = true;
			this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
			// 
			// ErrProv
			// 
			this.ErrProv.ContainerControl = this;
			// 
			// BackupDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(447, 255);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.TxtName);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.TxtDestination);
			this.Controls.Add(this.BtnBrowseDestination);
			this.Controls.Add(this.TxtFolders);
			this.Controls.Add(this.ChkCompression);
			this.Controls.Add(this.BtnBrowseSourceFolders);
			this.Controls.Add(this.BtnCancel);
			this.Controls.Add(this.BtnOk);
			this.Name = "BackupDialog";
			this.Resizable = false;
			this.Text = "Edit backup..";
			((System.ComponentModel.ISupportInitialize)(this.ErrProv)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal MetroLabel Label3;
		internal MetroLabel Label2;
		internal MetroTextBox TxtName;
		internal MetroLabel Label1;
		internal MetroTextBox TxtDestination;
		internal MetroButton BtnBrowseDestination;
		internal MetroTextBox TxtFolders;
		internal MetroCheckBox ChkCompression;
		internal MetroButton BtnBrowseSourceFolders;
		internal MetroButton BtnCancel;
		internal MetroButton BtnOk;
		internal System.Windows.Forms.ErrorProvider ErrProv;
	}
}