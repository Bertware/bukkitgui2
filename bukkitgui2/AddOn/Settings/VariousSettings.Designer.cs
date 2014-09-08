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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VariousSettings));
			this.chkSaveInServerDir = new MetroFramework.Controls.MetroCheckBox();
			this.btnCustomFolder = new MetroFramework.Controls.MetroButton();
			this.lblCustomDirExplanation = new MetroFramework.Controls.MetroLabel();
			this.CbLanguage = new MetroFramework.Controls.MetroComboBox();
			this.lblLanguage = new MetroFramework.Controls.MetroLabel();
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
			this.btnCustomFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCustomFolder.Location = new System.Drawing.Point(3, 81);
			this.btnCustomFolder.Name = "btnCustomFolder";
			this.btnCustomFolder.Size = new System.Drawing.Size(554, 23);
			this.btnCustomFolder.TabIndex = 1;
			this.btnCustomFolder.Text = "Create shortcut for custom folder";
			this.btnCustomFolder.UseSelectable = true;
			this.btnCustomFolder.Click += new System.EventHandler(this.btnCustomFolder_Click);
			// 
			// lblCustomDirExplanation
			// 
			this.lblCustomDirExplanation.Location = new System.Drawing.Point(3, 21);
			this.lblCustomDirExplanation.Name = "lblCustomDirExplanation";
			this.lblCustomDirExplanation.Size = new System.Drawing.Size(554, 57);
			this.lblCustomDirExplanation.TabIndex = 2;
			this.lblCustomDirExplanation.Text = resources.GetString("lblCustomDirExplanation.Text");
			// 
			// CbLanguage
			// 
			this.CbLanguage.FormattingEnabled = true;
			this.CbLanguage.ItemHeight = 23;
			this.CbLanguage.Items.AddRange(new object[] {
            "English"});
			this.CbLanguage.Location = new System.Drawing.Point(132, 129);
			this.CbLanguage.Name = "CbLanguage";
			this.CbLanguage.Size = new System.Drawing.Size(425, 29);
			this.CbLanguage.TabIndex = 3;
			this.CbLanguage.UseSelectable = true;
			// 
			// lblLanguage
			// 
			this.lblLanguage.Location = new System.Drawing.Point(3, 129);
			this.lblLanguage.Name = "lblLanguage";
			this.lblLanguage.Size = new System.Drawing.Size(123, 29);
			this.lblLanguage.TabIndex = 4;
			this.lblLanguage.Text = "Change language";
			this.lblLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// VariousSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lblLanguage);
			this.Controls.Add(this.CbLanguage);
			this.Controls.Add(this.lblCustomDirExplanation);
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
		private MetroFramework.Controls.MetroLabel lblCustomDirExplanation;
		private MetroFramework.Controls.MetroComboBox CbLanguage;
		private MetroFramework.Controls.MetroLabel lblLanguage;

	}
}
