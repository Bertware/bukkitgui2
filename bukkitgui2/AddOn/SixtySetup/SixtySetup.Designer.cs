namespace Net.Bertware.Bukkitgui2.AddOn.SixtySetup
{
	partial class SixtySetup
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
			this.pContainer = new MetroFramework.Controls.MetroPanel();
			this.SuspendLayout();
			// 
			// pContainer
			// 
			this.pContainer.HorizontalScrollbarBarColor = true;
			this.pContainer.HorizontalScrollbarHighlightOnWheel = false;
			this.pContainer.HorizontalScrollbarSize = 10;
			this.pContainer.Location = new System.Drawing.Point(23, 63);
			this.pContainer.Name = "pContainer";
			this.pContainer.Size = new System.Drawing.Size(445, 238);
			this.pContainer.TabIndex = 0;
			this.pContainer.VerticalScrollbarBarColor = true;
			this.pContainer.VerticalScrollbarHighlightOnWheel = false;
			this.pContainer.VerticalScrollbarSize = 10;
			// 
			// SixtySetup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(491, 324);
			this.Controls.Add(this.pContainer);
			this.Name = "SixtySetup";
			this.Resizable = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "SixtySetup";
			this.Load += new System.EventHandler(this.SixtySetup_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private MetroFramework.Controls.MetroPanel pContainer;

	}
}