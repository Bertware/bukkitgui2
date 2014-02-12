namespace Bukkitgui2.AddOn.Console
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
            this.minecraftConsole1 = new Bukkitgui2.Controls.MinecraftConsole.MinecraftConsole();
            this.performanceMonitor1 = new Bukkitgui2.Controls.PerformanceMonitor.PerformanceMonitor();
            this.quickButtons1 = new Bukkitgui2.AddOn.Console.QuickButtons.QuickButtons();
            this.SuspendLayout();
            // 
            // minecraftConsole1
            // 
            this.minecraftConsole1.Location = new System.Drawing.Point(469, 206);
            this.minecraftConsole1.Name = "minecraftConsole1";
            this.minecraftConsole1.Size = new System.Drawing.Size(328, 148);
            this.minecraftConsole1.TabIndex = 0;
            this.minecraftConsole1.Text = "";
            // 
            // performanceMonitor1
            // 
            this.performanceMonitor1.Location = new System.Drawing.Point(297, 480);
            this.performanceMonitor1.Name = "performanceMonitor1";
            this.performanceMonitor1.Size = new System.Drawing.Size(600, 117);
            this.performanceMonitor1.TabIndex = 1;
            // 
            // quickButtons1
            // 
            this.quickButtons1.Location = new System.Drawing.Point(3, 480);
            this.quickButtons1.Name = "quickButtons1";
            this.quickButtons1.Size = new System.Drawing.Size(288, 117);
            this.quickButtons1.TabIndex = 2;
            // 
            // ConsoleTab
            // 
            this.Controls.Add(this.quickButtons1);
            this.Controls.Add(this.performanceMonitor1);
            this.Controls.Add(this.minecraftConsole1);
            this.Name = "ConsoleTab";
            this.Size = new System.Drawing.Size(900, 600);
            this.ResumeLayout(false);

        }

        #endregion

        private Bukkitgui2.Controls.MinecraftConsole.MinecraftConsole minecraftConsole1;
        private Bukkitgui2.Controls.PerformanceMonitor.PerformanceMonitor performanceMonitor1;
        private Bukkitgui2.AddOn.Console.QuickButtons.QuickButtons quickButtons1;

     }
}
