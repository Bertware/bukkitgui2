namespace Net.Bertware.Bukkitgui2.AddOn.SixtySetup
{
	partial class SixtySetupSettings
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
			this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
			this.label5 = new MetroFramework.Controls.MetroLabel();
			this.NumMaxRam = new System.Windows.Forms.NumericUpDown();
			this.TBMaxRam = new MetroFramework.Controls.MetroTrackBar();
			this.label4 = new MetroFramework.Controls.MetroLabel();
			this.NumMinRam = new System.Windows.Forms.NumericUpDown();
			this.TBMinRam = new MetroFramework.Controls.MetroTrackBar();
			this.txtServerName = new MetroFramework.Controls.MetroTextBox();
			this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
			this.btnDone = new MetroFramework.Controls.MetroButton();
			((System.ComponentModel.ISupportInitialize)(this.NumMaxRam)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NumMinRam)).BeginInit();
			this.SuspendLayout();
			// 
			// metroLabel1
			// 
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.Location = new System.Drawing.Point(3, 0);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new System.Drawing.Size(453, 76);
			this.metroLabel1.TabIndex = 7;
			this.metroLabel1.Text = "Below you can edit the ram limits. These can be changed later.\r\nThe default value" +
    "s should be good.\r\nAlso, you can enter a name for your server, which will be vis" +
    "ible in minecraft.\r\n";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(3, 137);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(139, 20);
			this.label5.TabIndex = 17;
			this.label5.Text = "Maximum Ram [Mb] :";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// NumMaxRam
			// 
			this.NumMaxRam.Location = new System.Drawing.Point(148, 137);
			this.NumMaxRam.Margin = new System.Windows.Forms.Padding(3, 12, 3, 12);
			this.NumMaxRam.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
			this.NumMaxRam.Name = "NumMaxRam";
			this.NumMaxRam.Size = new System.Drawing.Size(73, 20);
			this.NumMaxRam.TabIndex = 16;
			this.NumMaxRam.ValueChanged += new System.EventHandler(this.NumMaxRam_ValueChanged);
			// 
			// TBMaxRam
			// 
			this.TBMaxRam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TBMaxRam.BackColor = System.Drawing.Color.Transparent;
			this.TBMaxRam.LargeChange = 512;
			this.TBMaxRam.Location = new System.Drawing.Point(227, 128);
			this.TBMaxRam.Maximum = 4096;
			this.TBMaxRam.Name = "TBMaxRam";
			this.TBMaxRam.Size = new System.Drawing.Size(270, 45);
			this.TBMaxRam.SmallChange = 256;
			this.TBMaxRam.TabIndex = 15;
			this.TBMaxRam.ValueChanged += new System.EventHandler(this.TbMaxRamScroll);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(3, 86);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(139, 20);
			this.label4.TabIndex = 14;
			this.label4.Text = "Minimum Ram [Mb] :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// NumMinRam
			// 
			this.NumMinRam.Location = new System.Drawing.Point(148, 86);
			this.NumMinRam.Margin = new System.Windows.Forms.Padding(3, 12, 3, 12);
			this.NumMinRam.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
			this.NumMinRam.Name = "NumMinRam";
			this.NumMinRam.Size = new System.Drawing.Size(73, 20);
			this.NumMinRam.TabIndex = 13;
			this.NumMinRam.ValueChanged += new System.EventHandler(this.NumMinRam_ValueChanged);
			// 
			// TBMinRam
			// 
			this.TBMinRam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TBMinRam.BackColor = System.Drawing.Color.Transparent;
			this.TBMinRam.LargeChange = 512;
			this.TBMinRam.Location = new System.Drawing.Point(227, 77);
			this.TBMinRam.Maximum = 4096;
			this.TBMinRam.Name = "TBMinRam";
			this.TBMinRam.Size = new System.Drawing.Size(270, 45);
			this.TBMinRam.SmallChange = 256;
			this.TBMinRam.TabIndex = 12;
			this.TBMinRam.ValueChanged += new System.EventHandler(this.TbMinRamScroll);
			// 
			// txtServerName
			// 
			this.txtServerName.Lines = new string[] {
        "Minecraft! Powered by Bukkit & BukkitGui"};
			this.txtServerName.Location = new System.Drawing.Point(148, 179);
			this.txtServerName.MaxLength = 32767;
			this.txtServerName.Name = "txtServerName";
			this.txtServerName.PasswordChar = '\0';
			this.txtServerName.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtServerName.SelectedText = "";
			this.txtServerName.Size = new System.Drawing.Size(349, 23);
			this.txtServerName.TabIndex = 18;
			this.txtServerName.Text = "Minecraft! Powered by Bukkit & BukkitGui";
			this.txtServerName.UseSelectable = true;
			// 
			// metroLabel2
			// 
			this.metroLabel2.Location = new System.Drawing.Point(3, 182);
			this.metroLabel2.Name = "metroLabel2";
			this.metroLabel2.Size = new System.Drawing.Size(139, 20);
			this.metroLabel2.TabIndex = 19;
			this.metroLabel2.Text = "Server Name :";
			this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnDone
			// 
			this.btnDone.Location = new System.Drawing.Point(422, 224);
			this.btnDone.Name = "btnDone";
			this.btnDone.Size = new System.Drawing.Size(75, 23);
			this.btnDone.TabIndex = 20;
			this.btnDone.Text = "Done";
			this.btnDone.UseSelectable = true;
			this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
			// 
			// SixtySetupSettings
			// 
			this.Controls.Add(this.btnDone);
			this.Controls.Add(this.metroLabel2);
			this.Controls.Add(this.txtServerName);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.NumMaxRam);
			this.Controls.Add(this.TBMaxRam);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.NumMinRam);
			this.Controls.Add(this.TBMinRam);
			this.Controls.Add(this.metroLabel1);
			this.Name = "SixtySetupSettings";
			this.Size = new System.Drawing.Size(500, 250);
			((System.ComponentModel.ISupportInitialize)(this.NumMaxRam)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NumMinRam)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MetroFramework.Controls.MetroLabel metroLabel1;
		private MetroFramework.Controls.MetroLabel label5;
		private System.Windows.Forms.NumericUpDown NumMaxRam;
		private MetroFramework.Controls.MetroTrackBar TBMaxRam;
		private MetroFramework.Controls.MetroLabel label4;
		private System.Windows.Forms.NumericUpDown NumMinRam;
		private MetroFramework.Controls.MetroTrackBar TBMinRam;
		private MetroFramework.Controls.MetroTextBox txtServerName;
		private MetroFramework.Controls.MetroLabel metroLabel2;
		private MetroFramework.Controls.MetroButton btnDone;


	}
}
