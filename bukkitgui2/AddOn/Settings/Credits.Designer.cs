namespace Net.Bertware.Bukkitgui2.AddOn.Settings
{
	partial class Credits
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Credits));
			this.lblCredits = new MetroFramework.Controls.MetroLabel();
			this.SuspendLayout();
			// 
			// lblCredits
			// 
			this.lblCredits.AutoSize = true;
			this.lblCredits.Location = new System.Drawing.Point(3, 0);
			this.lblCredits.Name = "lblCredits";
			this.lblCredits.Size = new System.Drawing.Size(466, 228);
			this.lblCredits.TabIndex = 0;
			this.lblCredits.Text = resources.GetString("lblCredits.Text");
			// 
			// Credits
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lblCredits);
			this.Name = "Credits";
			this.Size = new System.Drawing.Size(560, 490);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MetroFramework.Controls.MetroLabel lblCredits;
	}
}
