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
			this.ProgBarServerRam = new MetroProgressBar();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.LblServerRamUsageValue = new System.Windows.Forms.Label();
			this.LblGuiRamUsageValue = new System.Windows.Forms.Label();
			this.ProgBarGuiRam = new MetroProgressBar();
			this.LblTotalRamUsageValue = new System.Windows.Forms.Label();
			this.ProgBarTotalRam = new MetroProgressBar();
			this.lblTotalCpuUsageValue = new System.Windows.Forms.Label();
			this.ProgBarTotalCpu = new MetroProgressBar();
			this.lblGuiCpuUsageValue = new System.Windows.Forms.Label();
			this.ProgBarGuiCpu = new MetroProgressBar();
			this.lblServerCpuUsageValue = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.ProgBarServerCpu = new MetroProgressBar();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// ProgBarServerRam
			// 
			this.ProgBarServerRam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ProgBarServerRam.Location = new System.Drawing.Point(171, 18);
			this.ProgBarServerRam.MarqueeAnimationSpeed = 0;
			this.ProgBarServerRam.Name = "ProgBarServerRam";
			this.ProgBarServerRam.Size = new System.Drawing.Size(97, 15);
			this.ProgBarServerRam.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(75, 15);
			this.label1.TabIndex = 2;
			this.label1.Text = "RAM usage";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(3, 18);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 15);
			this.label2.TabIndex = 3;
			this.label2.Text = "Server:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(3, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(75, 15);
			this.label3.TabIndex = 4;
			this.label3.Text = "Total:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(3, 33);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(75, 15);
			this.label4.TabIndex = 5;
			this.label4.Text = "GUI:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// LblServerRamUsageValue
			// 
			this.LblServerRamUsageValue.Location = new System.Drawing.Point(84, 18);
			this.LblServerRamUsageValue.Name = "LblServerRamUsageValue";
			this.LblServerRamUsageValue.Size = new System.Drawing.Size(75, 15);
			this.LblServerRamUsageValue.TabIndex = 6;
			this.LblServerRamUsageValue.Text = "16000 (100%)";
			this.LblServerRamUsageValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// LblGuiRamUsageValue
			// 
			this.LblGuiRamUsageValue.Location = new System.Drawing.Point(84, 33);
			this.LblGuiRamUsageValue.Name = "LblGuiRamUsageValue";
			this.LblGuiRamUsageValue.Size = new System.Drawing.Size(75, 15);
			this.LblGuiRamUsageValue.TabIndex = 8;
			this.LblGuiRamUsageValue.Text = "16000 (100%)";
			this.LblGuiRamUsageValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ProgBarGuiRam
			// 
			this.ProgBarGuiRam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ProgBarGuiRam.Location = new System.Drawing.Point(171, 33);
			this.ProgBarGuiRam.MarqueeAnimationSpeed = 0;
			this.ProgBarGuiRam.Name = "ProgBarGuiRam";
			this.ProgBarGuiRam.Size = new System.Drawing.Size(97, 15);
			this.ProgBarGuiRam.TabIndex = 7;
			// 
			// LblTotalRamUsageValue
			// 
			this.LblTotalRamUsageValue.Location = new System.Drawing.Point(84, 48);
			this.LblTotalRamUsageValue.Name = "LblTotalRamUsageValue";
			this.LblTotalRamUsageValue.Size = new System.Drawing.Size(75, 15);
			this.LblTotalRamUsageValue.TabIndex = 10;
			this.LblTotalRamUsageValue.Text = "16000 (100%)";
			this.LblTotalRamUsageValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ProgBarTotalRam
			// 
			this.ProgBarTotalRam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ProgBarTotalRam.Location = new System.Drawing.Point(171, 48);
			this.ProgBarTotalRam.MarqueeAnimationSpeed = 0;
			this.ProgBarTotalRam.Name = "ProgBarTotalRam";
			this.ProgBarTotalRam.Size = new System.Drawing.Size(97, 15);
			this.ProgBarTotalRam.TabIndex = 9;
			// 
			// lblTotalCpuUsageValue
			// 
			this.lblTotalCpuUsageValue.Location = new System.Drawing.Point(87, 48);
			this.lblTotalCpuUsageValue.Name = "lblTotalCpuUsageValue";
			this.lblTotalCpuUsageValue.Size = new System.Drawing.Size(39, 15);
			this.lblTotalCpuUsageValue.TabIndex = 20;
			this.lblTotalCpuUsageValue.Text = "100%";
			this.lblTotalCpuUsageValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ProgBarTotalCpu
			// 
			this.ProgBarTotalCpu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ProgBarTotalCpu.Location = new System.Drawing.Point(132, 48);
			this.ProgBarTotalCpu.MarqueeAnimationSpeed = 0;
			this.ProgBarTotalCpu.Name = "ProgBarTotalCpu";
			this.ProgBarTotalCpu.Size = new System.Drawing.Size(148, 15);
			this.ProgBarTotalCpu.TabIndex = 19;
			// 
			// lblGuiCpuUsageValue
			// 
			this.lblGuiCpuUsageValue.Location = new System.Drawing.Point(87, 33);
			this.lblGuiCpuUsageValue.Name = "lblGuiCpuUsageValue";
			this.lblGuiCpuUsageValue.Size = new System.Drawing.Size(39, 15);
			this.lblGuiCpuUsageValue.TabIndex = 18;
			this.lblGuiCpuUsageValue.Text = "100%";
			this.lblGuiCpuUsageValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ProgBarGuiCpu
			// 
			this.ProgBarGuiCpu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ProgBarGuiCpu.Location = new System.Drawing.Point(132, 33);
			this.ProgBarGuiCpu.MarqueeAnimationSpeed = 0;
			this.ProgBarGuiCpu.Name = "ProgBarGuiCpu";
			this.ProgBarGuiCpu.Size = new System.Drawing.Size(148, 15);
			this.ProgBarGuiCpu.TabIndex = 17;
			// 
			// lblServerCpuUsageValue
			// 
			this.lblServerCpuUsageValue.Location = new System.Drawing.Point(87, 18);
			this.lblServerCpuUsageValue.Name = "lblServerCpuUsageValue";
			this.lblServerCpuUsageValue.Size = new System.Drawing.Size(39, 15);
			this.lblServerCpuUsageValue.TabIndex = 16;
			this.lblServerCpuUsageValue.Text = "100%";
			this.lblServerCpuUsageValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(6, 33);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(75, 15);
			this.label11.TabIndex = 15;
			this.label11.Text = "GUI:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(6, 48);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(75, 15);
			this.label12.TabIndex = 14;
			this.label12.Text = "Total:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(6, 18);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(75, 15);
			this.label13.TabIndex = 13;
			this.label13.Text = "Server:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(6, 3);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(75, 15);
			this.label14.TabIndex = 12;
			this.label14.Text = "CPU Usage";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ProgBarServerCpu
			// 
			this.ProgBarServerCpu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ProgBarServerCpu.Location = new System.Drawing.Point(132, 18);
			this.ProgBarServerCpu.MarqueeAnimationSpeed = 0;
			this.ProgBarServerCpu.Name = "ProgBarServerCpu";
			this.ProgBarServerCpu.Size = new System.Drawing.Size(148, 15);
			this.ProgBarServerCpu.TabIndex = 11;
			// 
			// panel1
			// 
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
			this.panel1.Size = new System.Drawing.Size(271, 100);
			this.panel1.TabIndex = 21;
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
			this.panel2.Location = new System.Drawing.Point(277, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(283, 100);
			this.panel2.TabIndex = 22;
			// 
			// PerformanceMonitor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblServerRamUsageValue;
        private System.Windows.Forms.Label LblGuiRamUsageValue;
        private MetroProgressBar ProgBarGuiRam;
        private System.Windows.Forms.Label LblTotalRamUsageValue;
        private MetroProgressBar ProgBarTotalRam;
        private System.Windows.Forms.Label lblTotalCpuUsageValue;
        private MetroProgressBar ProgBarTotalCpu;
        private System.Windows.Forms.Label lblGuiCpuUsageValue;
        private MetroProgressBar ProgBarGuiCpu;
        private System.Windows.Forms.Label lblServerCpuUsageValue;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private MetroProgressBar ProgBarServerCpu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;

    }
}

