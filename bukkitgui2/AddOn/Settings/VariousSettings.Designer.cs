namespace Net.Bertware.Bukkitgui2.AddOn.Settings
{
	partial class VariousSettings
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
			this.chkSaveInServerDir = new MetroFramework.Controls.MetroCheckBox();
			this.btnCustomFolder = new MetroFramework.Controls.MetroButton();
			this.SuspendLayout();
			// 
			// chkSaveInServerDir
			// 
			this.chkSaveInServerDir.AutoSize = true;
			this.chkSaveInServerDir.Location = new System.Drawing.Point(3, 3);
			this.chkSaveInServerDir.Name = "chkSaveInServerDir";
			this.chkSaveInServerDir.Size = new System.Drawing.Size(170, 15);
			this.chkSaveInServerDir.TabIndex = 0;
			this.chkSaveInServerDir.Text = "Save all files in the server dir";
			this.chkSaveInServerDir.UseSelectable = true;
			this.chkSaveInServerDir.CheckedChanged += new System.EventHandler(this.chkSaveInServerDir_CheckedChanged);
			// 
			// btnCustomFolder
			// 
			this.btnCustomFolder.Location = new System.Drawing.Point(3, 24);
			this.btnCustomFolder.Name = "btnCustomFolder";
			this.btnCustomFolder.Size = new System.Drawing.Size(170, 23);
			this.btnCustomFolder.TabIndex = 1;
			this.btnCustomFolder.Text = "Use custom folder";
			this.btnCustomFolder.UseSelectable = true;
			this.btnCustomFolder.Click += new System.EventHandler(this.btnCustomFolder_Click);
			// 
			// VariousSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnCustomFolder);
			this.Controls.Add(this.chkSaveInServerDir);
			this.Name = "VariousSettings";
			this.Size = new System.Drawing.Size(560, 490);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MetroFramework.Controls.MetroCheckBox chkSaveInServerDir;
		private MetroFramework.Controls.MetroButton btnCustomFolder;

	}
}
