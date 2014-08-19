namespace Net.Bertware.Bukkitgui2.UI
{
	partial class SplashScreen
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
			this.lblSplash = new MetroFramework.Controls.MetroLabel();
			this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
			this.Spinner = new MetroFramework.Controls.MetroProgressSpinner();
			this.SuspendLayout();
			// 
			// lblSplash
			// 
			this.lblSplash.AutoSize = true;
			this.lblSplash.Location = new System.Drawing.Point(93, 108);
			this.lblSplash.Name = "lblSplash";
			this.lblSplash.Size = new System.Drawing.Size(265, 19);
			this.lblSplash.TabIndex = 1;
			this.lblSplash.Text = "Please wait while the application is loading...";
			this.lblSplash.UseWaitCursor = true;
			// 
			// metroLabel1
			// 
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.Location = new System.Drawing.Point(93, 63);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new System.Drawing.Size(201, 38);
			this.metroLabel1.TabIndex = 2;
			this.metroLabel1.Text = "Bukkitgui v2\r\nCopyright ©Bertware 2011-2014";
			this.metroLabel1.UseWaitCursor = true;
			// 
			// Spinner
			// 
			this.Spinner.Location = new System.Drawing.Point(23, 63);
			this.Spinner.Maximum = 100;
			this.Spinner.Name = "Spinner";
			this.Spinner.Size = new System.Drawing.Size(64, 64);
			this.Spinner.TabIndex = 3;
			this.Spinner.UseSelectable = true;
			this.Spinner.UseWaitCursor = true;
			this.Spinner.Value = -1;
			// 
			// SplashScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(483, 145);
			this.Controls.Add(this.Spinner);
			this.Controls.Add(this.metroLabel1);
			this.Controls.Add(this.lblSplash);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Movable = false;
			this.Name = "SplashScreen";
			this.Resizable = false;
			this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Style = MetroFramework.MetroColorStyle.Default;
			this.Text = "BukkitGUI · Starting...";
			this.TopMost = true;
			this.UseWaitCursor = true;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MetroFramework.Controls.MetroLabel lblSplash;
		private MetroFramework.Controls.MetroLabel metroLabel1;
		private MetroFramework.Controls.MetroProgressSpinner Spinner;
	}
}