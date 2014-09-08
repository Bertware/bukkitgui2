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
			this.lblNotAvailableYet = new MetroFramework.Controls.MetroLabel();
			this.SuspendLayout();
			// 
			// lblNotAvailableYet
			// 
			this.lblNotAvailableYet.AutoSize = true;
			this.lblNotAvailableYet.Location = new System.Drawing.Point(3, 0);
			this.lblNotAvailableYet.Name = "lblNotAvailableYet";
			this.lblNotAvailableYet.Size = new System.Drawing.Size(428, 19);
			this.lblNotAvailableYet.TabIndex = 0;
			this.lblNotAvailableYet.Text = Locale.Tr("Backups aren\'t available at this time, and will be added in a later release");
			// 
			// BackupTab
			// 
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.lblNotAvailableYet);
			this.Name = "BackupTab";
			this.Size = new System.Drawing.Size(800, 500);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MetroFramework.Controls.MetroLabel lblNotAvailableYet;

	}
}
