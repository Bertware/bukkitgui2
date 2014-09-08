using Net.Bertware.Bukkitgui2.Core;

namespace Net.Bertware.Bukkitgui2.AddOn.Console
{
	partial class EmulatorInput
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
			this.txtLog = new MetroFramework.Controls.MetroTextBox();
			this.btnEmulate = new MetroFramework.Controls.MetroButton();
			this.SuspendLayout();
			// 
			// txtLog
			// 
			this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtLog.Lines = new string[] {
        "metroTextBox1"};
			this.txtLog.Location = new System.Drawing.Point(23, 63);
			this.txtLog.MaxLength = 32767;
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.PasswordChar = '\0';
			this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtLog.SelectedText = "";
			this.txtLog.Size = new System.Drawing.Size(804, 445);
			this.txtLog.TabIndex = 0;
			this.txtLog.Text = Locale.Tr("metroTextBox1");
			this.txtLog.UseSelectable = true;
			// 
			// btnEmulate
			// 
			this.btnEmulate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEmulate.Location = new System.Drawing.Point(752, 514);
			this.btnEmulate.Name = "btnEmulate";
			this.btnEmulate.Size = new System.Drawing.Size(75, 23);
			this.btnEmulate.TabIndex = 1;
			this.btnEmulate.Text = Locale.Tr("Emulate!");
			this.btnEmulate.UseSelectable = true;
			this.btnEmulate.Click += new System.EventHandler(this.btnEmulate_Click);
			// 
			// EmulatorInput
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(850, 560);
			this.Controls.Add(this.btnEmulate);
			this.Controls.Add(this.txtLog);
			this.Name = "EmulatorInput";
			this.Text = Locale.Tr("Emulator");
			this.ResumeLayout(false);

		}

		#endregion

		private MetroFramework.Controls.MetroTextBox txtLog;
		private MetroFramework.Controls.MetroButton btnEmulate;
	}
}
