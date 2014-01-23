namespace bukkitgui2.AddOn.Console
{
	partial class ConsoleTab
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.PerformanceMonitor = new bukkitgui2.Controls.PerformanceMonitor.PerformanceMonitor();
            this.MCConsole = new bukkitgui2.Controls.MinecraftConsole.MinecraftConsole();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.MCConsole);
            this.groupBox1.Controls.Add(this.splitter1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(894, 424);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server console";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(3, 16);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(213, 405);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // PerformanceMonitor
            // 
            this.PerformanceMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PerformanceMonitor.Location = new System.Drawing.Point(214, 433);
            this.PerformanceMonitor.Name = "PerformanceMonitor";
            this.PerformanceMonitor.Size = new System.Drawing.Size(686, 164);
            this.PerformanceMonitor.TabIndex = 1;
            // 
            // MCConsole
            // 
            this.MCConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MCConsole.Location = new System.Drawing.Point(222, 16);
            this.MCConsole.Name = "MCConsole";
            this.MCConsole.Size = new System.Drawing.Size(666, 362);
            this.MCConsole.TabIndex = 1;
            this.MCConsole.Text = "";
            // 
            // ConsoleTab
            // 
            this.Controls.Add(this.PerformanceMonitor);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConsoleTab";
            this.Size = new System.Drawing.Size(900, 600);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.PerformanceMonitor.PerformanceMonitor PerformanceMonitor;
        private Controls.MinecraftConsole.MinecraftConsole MCConsole;
        private System.Windows.Forms.Splitter splitter1;

    }
}
