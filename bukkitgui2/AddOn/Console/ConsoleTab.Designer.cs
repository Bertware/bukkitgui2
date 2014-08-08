using  Net.Bertware.Bukkitgui2.Controls.QuickButtons;

namespace Net.Bertware.Bukkitgui2.AddOn.Console
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.SLVPlayers = new Net.Bertware.Bukkitgui2.Controls.SortableListView.SortableListView();
			this.ColPlayers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.CIConsoleInput = new Net.Bertware.Bukkitgui2.Controls.ConsoleInput.ConsoleInput();
			this.MCCOut = new Net.Bertware.Bukkitgui2.Controls.MinecraftConsole.MinecraftConsole();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.performanceMonitor1 = new Net.Bertware.Bukkitgui2.Controls.PerformanceMonitor.PerformanceMonitor();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.quickButtons1 = new Net.Bertware.Bukkitgui2.Controls.QuickButtons.QuickButtons();
			this.groupBox1.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.splitContainer1);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(794, 371);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Server management";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 16);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.SLVPlayers);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.CIConsoleInput);
			this.splitContainer1.Panel2.Controls.Add(this.MCCOut);
			this.splitContainer1.Size = new System.Drawing.Size(788, 352);
			this.splitContainer1.SplitterDistance = 160;
			this.splitContainer1.TabIndex = 1;
			// 
			// SLVPlayers
			// 
			this.SLVPlayers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColPlayers});
			this.SLVPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SLVPlayers.Location = new System.Drawing.Point(0, 0);
			this.SLVPlayers.Name = "SLVPlayers";
			this.SLVPlayers.Size = new System.Drawing.Size(160, 352);
			this.SLVPlayers.TabIndex = 0;
			this.SLVPlayers.UseCompatibleStateImageBehavior = false;
			this.SLVPlayers.View = System.Windows.Forms.View.Details;
			// 
			// ColPlayers
			// 
			this.ColPlayers.Text = "Players";
			this.ColPlayers.Width = 146;
			// 
			// CIConsoleInput
			// 
			this.CIConsoleInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CIConsoleInput.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.CIConsoleInput.AutoCompletion = true;
			this.CIConsoleInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.CIConsoleInput.Location = new System.Drawing.Point(0, 332);
			this.CIConsoleInput.Name = "CIConsoleInput";
			this.CIConsoleInput.Size = new System.Drawing.Size(624, 20);
			this.CIConsoleInput.TabIndex = 1;
			// 
			// MCCOut
			// 
			this.MCCOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MCCOut.Autoscroll = true;
			this.MCCOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.MCCOut.Location = new System.Drawing.Point(0, 0);
			this.MCCOut.MessageColorInfo = System.Drawing.Color.Blue;
			this.MCCOut.MessageColorPlayerAction = System.Drawing.Color.DarkGreen;
			this.MCCOut.MessageColorPlayerTag = System.Drawing.Color.DarkGreen;
			this.MCCOut.MessageColorPluginTag = System.Drawing.Color.Black;
			this.MCCOut.MessageColorSevere = System.Drawing.Color.DarkRed;
			this.MCCOut.MessageColorUnknown = System.Drawing.Color.Black;
			this.MCCOut.MessageColorWarning = System.Drawing.Color.DarkOrange;
			this.MCCOut.Name = "MCCOut";
			this.MCCOut.ShowDate = false;
			this.MCCOut.ShowTime = true;
			this.MCCOut.Size = new System.Drawing.Size(624, 326);
			this.MCCOut.TabIndex = 0;
			this.MCCOut.Text = "";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.performanceMonitor1);
			this.groupBox2.Location = new System.Drawing.Point(170, 380);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(624, 117);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Performance";
			// 
			// performanceMonitor1
			// 
			this.performanceMonitor1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.performanceMonitor1.Location = new System.Drawing.Point(3, 16);
			this.performanceMonitor1.Name = "performanceMonitor1";
			this.performanceMonitor1.Size = new System.Drawing.Size(618, 98);
			this.performanceMonitor1.TabIndex = 0;
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox3.Controls.Add(this.quickButtons1);
			this.groupBox3.Location = new System.Drawing.Point(7, 380);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(157, 117);
			this.groupBox3.TabIndex = 5;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Quick Actions";
			// 
			// quickButtons1
			// 
			this.quickButtons1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.quickButtons1.Location = new System.Drawing.Point(3, 16);
			this.quickButtons1.Name = "quickButtons1";
			this.quickButtons1.Size = new System.Drawing.Size(151, 98);
			this.quickButtons1.TabIndex = 0;
			// 
			// ConsoleTab
			// 
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "ConsoleTab";
			this.Size = new System.Drawing.Size(800, 500);
			this.groupBox1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private Net.Bertware.Bukkitgui2.Controls.MinecraftConsole.MinecraftConsole MCCOut;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private Controls.ConsoleInput.ConsoleInput CIConsoleInput;
        private QuickButtons quickButtons1;
        private Controls.PerformanceMonitor.PerformanceMonitor performanceMonitor1;
		private Controls.SortableListView.SortableListView SLVPlayers;
		private System.Windows.Forms.ColumnHeader ColPlayers;


     }
}
