namespace Net.Bertware.Bukkitgui2.Controls.QuickButtons
{
	partial class QuickButtons
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
			this.btnStartStop = new System.Windows.Forms.Button();
			this.btnRestart = new System.Windows.Forms.Button();
			this.btnCustom = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnStartStop
			// 
			this.btnStartStop.Location = new System.Drawing.Point(3, 3);
			this.btnStartStop.Name = "btnStartStop";
			this.btnStartStop.Size = new System.Drawing.Size(144, 23);
			this.btnStartStop.TabIndex = 0;
			this.btnStartStop.Text = "Start";
			this.btnStartStop.UseVisualStyleBackColor = true;
			this.btnStartStop.Click += new System.EventHandler(this.BtnStartStopClick);
			// 
			// btnRestart
			// 
			this.btnRestart.Location = new System.Drawing.Point(3, 32);
			this.btnRestart.Name = "btnRestart";
			this.btnRestart.Size = new System.Drawing.Size(144, 23);
			this.btnRestart.TabIndex = 1;
			this.btnRestart.Text = "Restart";
			this.btnRestart.UseVisualStyleBackColor = true;
			// 
			// btnCustom
			// 
			this.btnCustom.Location = new System.Drawing.Point(3, 61);
			this.btnCustom.Name = "btnCustom";
			this.btnCustom.Size = new System.Drawing.Size(144, 23);
			this.btnCustom.TabIndex = 2;
			this.btnCustom.Text = "Custom";
			this.btnCustom.UseVisualStyleBackColor = true;
			this.btnCustom.Click += new System.EventHandler(this.btnCustom_Click);
			// 
			// QuickButtons
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnCustom);
			this.Controls.Add(this.btnRestart);
			this.Controls.Add(this.btnStartStop);
			this.Name = "QuickButtons";
			this.Size = new System.Drawing.Size(150, 89);
			this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnCustom;

    }
}
