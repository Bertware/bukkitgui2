using System.Windows.Forms;
using MetroFramework.Controls;

namespace Net.Bertware.Bukkitgui2.Controls.PerformanceMonitor
{
	partial class PerformanceMonitor
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
			this.ProgBarServerRam = new MetroFramework.Controls.MetroProgressBar();
			this.label1 = new MetroFramework.Controls.MetroLabel();
			this.label2 = new MetroFramework.Controls.MetroLabel();
			this.label3 = new MetroFramework.Controls.MetroLabel();
			this.label4 = new MetroFramework.Controls.MetroLabel();
			this.LblServerRamUsageValue = new MetroFramework.Controls.MetroLabel();
			this.LblGuiRamUsageValue = new MetroFramework.Controls.MetroLabel();
			this.ProgBarGuiRam = new MetroFramework.Controls.MetroProgressBar();
			this.LblTotalRamUsageValue = new MetroFramework.Controls.MetroLabel();
			this.ProgBarTotalRam = new MetroFramework.Controls.MetroProgressBar();
			this.lblTotalCpuUsageValue = new MetroFramework.Controls.MetroLabel();
			this.ProgBarTotalCpu = new MetroFramework.Controls.MetroProgressBar();
			this.lblGuiCpuUsageValue = new MetroFramework.Controls.MetroLabel();
			this.ProgBarGuiCpu = new MetroFramework.Controls.MetroProgressBar();
			this.lblServerCpuUsageValue = new MetroFramework.Controls.MetroLabel();
			this.label11 = new MetroFramework.Controls.MetroLabel();
			this.label12 = new MetroFramework.Controls.MetroLabel();
			this.label13 = new MetroFramework.Controls.MetroLabel();
			this.label14 = new MetroFramework.Controls.MetroLabel();
			this.ProgBarServerCpu = new MetroFramework.Controls.MetroProgressBar();
			this.panel1 = new MetroPanel();
			this.LblUptimeValue = new MetroFramework.Controls.MetroLabel();
			this.LblUptimeText = new MetroFramework.Controls.MetroLabel();
			this.panel2 = new MetroPanel();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// ProgBarServerRam
			// 
			this.ProgBarServerRam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ProgBarServerRam.Location = new System.Drawing.Point(203, 25);
			this.ProgBarServerRam.MarqueeAnimationSpeed = 0;
			this.ProgBarServerRam.Name = "ProgBarServerRam";
			this.ProgBarServerRam.Size = new System.Drawing.Size(100, 15);
			this.ProgBarServerRam.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(300, 19);
			this.label1.TabIndex = 2;
			this.label1.Text = "RAM usage";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(0, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 19);
			this.label2.TabIndex = 3;
			this.label2.Text = "Server:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(0, 59);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(75, 19);
			this.label3.TabIndex = 4;
			this.label3.Text = "Total:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(0, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(75, 19);
			this.label4.TabIndex = 5;
			this.label4.Text = "GUI:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// LblServerRamUsageValue
			// 
			this.LblServerRamUsageValue.Location = new System.Drawing.Point(85, 21);
			this.LblServerRamUsageValue.Name = "LblServerRamUsageValue";
			this.LblServerRamUsageValue.Size = new System.Drawing.Size(113, 19);
			this.LblServerRamUsageValue.TabIndex = 6;
			this.LblServerRamUsageValue.Text = "16000 (100%)";
			this.LblServerRamUsageValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// LblGuiRamUsageValue
			// 
			this.LblGuiRamUsageValue.Location = new System.Drawing.Point(84, 40);
			this.LblGuiRamUsageValue.Name = "LblGuiRamUsageValue";
			this.LblGuiRamUsageValue.Size = new System.Drawing.Size(113, 19);
			this.LblGuiRamUsageValue.TabIndex = 8;
			this.LblGuiRamUsageValue.Text = "16000 (100%)";
			this.LblGuiRamUsageValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ProgBarGuiRam
			// 
			this.ProgBarGuiRam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ProgBarGuiRam.Location = new System.Drawing.Point(203, 44);
			this.ProgBarGuiRam.MarqueeAnimationSpeed = 0;
			this.ProgBarGuiRam.Name = "ProgBarGuiRam";
			this.ProgBarGuiRam.Size = new System.Drawing.Size(100, 15);
			this.ProgBarGuiRam.TabIndex = 7;
			// 
			// LblTotalRamUsageValue
			// 
			this.LblTotalRamUsageValue.Location = new System.Drawing.Point(85, 59);
			this.LblTotalRamUsageValue.Name = "LblTotalRamUsageValue";
			this.LblTotalRamUsageValue.Size = new System.Drawing.Size(113, 19);
			this.LblTotalRamUsageValue.TabIndex = 10;
			this.LblTotalRamUsageValue.Text = "16000 (100%)";
			this.LblTotalRamUsageValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ProgBarTotalRam
			// 
			this.ProgBarTotalRam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ProgBarTotalRam.Location = new System.Drawing.Point(203, 63);
			this.ProgBarTotalRam.MarqueeAnimationSpeed = 0;
			this.ProgBarTotalRam.Name = "ProgBarTotalRam";
			this.ProgBarTotalRam.Size = new System.Drawing.Size(100, 15);
			this.ProgBarTotalRam.TabIndex = 9;
			// 
			// lblTotalCpuUsageValue
			// 
			this.lblTotalCpuUsageValue.Location = new System.Drawing.Point(85, 63);
			this.lblTotalCpuUsageValue.Name = "lblTotalCpuUsageValue";
			this.lblTotalCpuUsageValue.Size = new System.Drawing.Size(52, 15);
			this.lblTotalCpuUsageValue.TabIndex = 20;
			this.lblTotalCpuUsageValue.Text = "100%";
			this.lblTotalCpuUsageValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ProgBarTotalCpu
			// 
			this.ProgBarTotalCpu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ProgBarTotalCpu.Location = new System.Drawing.Point(143, 63);
			this.ProgBarTotalCpu.MarqueeAnimationSpeed = 0;
			this.ProgBarTotalCpu.Name = "ProgBarTotalCpu";
			this.ProgBarTotalCpu.Size = new System.Drawing.Size(100, 15);
			this.ProgBarTotalCpu.TabIndex = 19;
			// 
			// lblGuiCpuUsageValue
			// 
			this.lblGuiCpuUsageValue.Location = new System.Drawing.Point(85, 44);
			this.lblGuiCpuUsageValue.Name = "lblGuiCpuUsageValue";
			this.lblGuiCpuUsageValue.Size = new System.Drawing.Size(52, 15);
			this.lblGuiCpuUsageValue.TabIndex = 18;
			this.lblGuiCpuUsageValue.Text = "100%";
			this.lblGuiCpuUsageValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ProgBarGuiCpu
			// 
			this.ProgBarGuiCpu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ProgBarGuiCpu.Location = new System.Drawing.Point(143, 44);
			this.ProgBarGuiCpu.MarqueeAnimationSpeed = 0;
			this.ProgBarGuiCpu.Name = "ProgBarGuiCpu";
			this.ProgBarGuiCpu.Size = new System.Drawing.Size(100, 15);
			this.ProgBarGuiCpu.TabIndex = 17;
			// 
			// lblServerCpuUsageValue
			// 
			this.lblServerCpuUsageValue.Location = new System.Drawing.Point(85, 25);
			this.lblServerCpuUsageValue.Name = "lblServerCpuUsageValue";
			this.lblServerCpuUsageValue.Size = new System.Drawing.Size(52, 18);
			this.lblServerCpuUsageValue.TabIndex = 16;
			this.lblServerCpuUsageValue.Text = "100%";
			this.lblServerCpuUsageValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(4, 44);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(75, 15);
			this.label11.TabIndex = 15;
			this.label11.Text = "GUI:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(4, 63);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(75, 15);
			this.label12.TabIndex = 14;
			this.label12.Text = "Total:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(4, 25);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(75, 18);
			this.label13.TabIndex = 13;
			this.label13.Text = "Server:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(6, 3);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(237, 19);
			this.label14.TabIndex = 12;
			this.label14.Text = "CPU Usage";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ProgBarServerCpu
			// 
			this.ProgBarServerCpu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ProgBarServerCpu.Location = new System.Drawing.Point(143, 25);
			this.ProgBarServerCpu.MarqueeAnimationSpeed = 0;
			this.ProgBarServerCpu.Name = "ProgBarServerCpu";
			this.ProgBarServerCpu.Size = new System.Drawing.Size(100, 15);
			this.ProgBarServerCpu.TabIndex = 11;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.LblUptimeValue);
			this.panel1.Controls.Add(this.LblUptimeText);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.ProgBarServerRam);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.LblServerRamUsageValue);
			this.panel1.Controls.Add(this.ProgBarGuiRam);
			this.panel1.Controls.Add(this.LblGuiRamUsageValue);
			this.panel1.Controls.Add(this.ProgBarTotalRam);
			this.panel1.Controls.Add(this.LblTotalRamUsageValue);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(306, 100);
			this.panel1.TabIndex = 21;
			// 
			// LblUptimeValue
			// 
			this.LblUptimeValue.Location = new System.Drawing.Point(81, 78);
			this.LblUptimeValue.Name = "LblUptimeValue";
			this.LblUptimeValue.Size = new System.Drawing.Size(113, 19);
			this.LblUptimeValue.TabIndex = 12;
			this.LblUptimeValue.Text = "00:00:00";
			this.LblUptimeValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// LblUptimeText
			// 
			this.LblUptimeText.Location = new System.Drawing.Point(0, 78);
			this.LblUptimeText.Name = "LblUptimeText";
			this.LblUptimeText.Size = new System.Drawing.Size(75, 19);
			this.LblUptimeText.TabIndex = 11;
			this.LblUptimeText.Text = "Uptime:";
			this.LblUptimeText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.label14);
			this.panel2.Controls.Add(this.lblTotalCpuUsageValue);
			this.panel2.Controls.Add(this.ProgBarServerCpu);
			this.panel2.Controls.Add(this.ProgBarTotalCpu);
			this.panel2.Controls.Add(this.label13);
			this.panel2.Controls.Add(this.lblGuiCpuUsageValue);
			this.panel2.Controls.Add(this.label12);
			this.panel2.Controls.Add(this.ProgBarGuiCpu);
			this.panel2.Controls.Add(this.label11);
			this.panel2.Controls.Add(this.lblServerCpuUsageValue);
			this.panel2.Location = new System.Drawing.Point(312, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(248, 100);
			this.panel2.TabIndex = 22;
			// 
			// PerformanceMonitor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "PerformanceMonitor";
			this.Size = new System.Drawing.Size(560, 100);
			this.Load += new System.EventHandler(this.PerformanceMonitor_Load);
			this.VisibleChanged += new System.EventHandler(this.PerformanceMonitor_VisibleChanged);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

        private MetroProgressBar ProgBarServerRam;
        private MetroLabel label1;
        private MetroLabel label2;
        private MetroLabel label3;
        private MetroLabel label4;
        private MetroLabel LblServerRamUsageValue;
        private MetroLabel LblGuiRamUsageValue;
        private MetroProgressBar ProgBarGuiRam;
        private MetroLabel LblTotalRamUsageValue;
        private MetroProgressBar ProgBarTotalRam;
        private MetroLabel lblTotalCpuUsageValue;
        private MetroProgressBar ProgBarTotalCpu;
        private MetroLabel lblGuiCpuUsageValue;
        private MetroProgressBar ProgBarGuiCpu;
        private MetroLabel lblServerCpuUsageValue;
        private MetroLabel label11;
        private MetroLabel label12;
        private MetroLabel label13;
        private MetroLabel label14;
        private MetroProgressBar ProgBarServerCpu;
        private MetroPanel panel1;
		private MetroPanel panel2;
		private MetroLabel LblUptimeValue;
		private MetroLabel LblUptimeText;

    }
}

