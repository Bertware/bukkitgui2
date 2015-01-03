using MetroFramework.Controls;
using Net.Bertware.Bukkitgui2.Core;

namespace Net.Bertware.Bukkitgui2.UI
{
	partial class ServerStopDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerStopDialog));
			this.btnCancel = new MetroFramework.Controls.MetroButton();
			this.progBar = new MetroFramework.Controls.MetroProgressBar();
			this.btnKill = new MetroFramework.Controls.MetroButton();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(240, 92);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseSelectable = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// progBar
			// 
			this.progBar.Location = new System.Drawing.Point(23, 63);
			this.progBar.MarqueeAnimationSpeed = 10;
			this.progBar.Name = "progBar";
			this.progBar.ProgressBarStyle = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.progBar.Size = new System.Drawing.Size(292, 23);
			this.progBar.TabIndex = 2;
			this.progBar.Value = 5;
			// 
			// btnKill
			// 
			this.btnKill.Location = new System.Drawing.Point(159, 92);
			this.btnKill.Name = "btnKill";
			this.btnKill.Size = new System.Drawing.Size(75, 23);
			this.btnKill.TabIndex = 3;
			this.btnKill.Text = "&Kill";
			this.btnKill.UseSelectable = true;
			this.btnKill.Click += new System.EventHandler(this.btnKill_Click);
			// 
			// ServerStopDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(338, 132);
			this.Controls.Add(this.btnKill);
			this.Controls.Add(this.progBar);
			this.Controls.Add(this.btnCancel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ServerStopDialog";
			this.Resizable = false;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Stopping Server...";
			this.Load += new System.EventHandler(this.ServerStopDialog_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private MetroButton btnCancel;
		private MetroProgressBar progBar;
		private MetroButton btnKill;
	}
}
