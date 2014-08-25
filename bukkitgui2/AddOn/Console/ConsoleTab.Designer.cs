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
			this.components = new System.ComponentModel.Container();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.SlvPlayers = new Net.Bertware.Bukkitgui2.Controls.SortableListView.SortableListView();
			this.ColPlayers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ContextPlayers = new MetroFramework.Controls.MetroContextMenu(this.components);
			this.ContextPlayersKick = new System.Windows.Forms.ToolStripMenuItem();
			this.ContextPlayersBan = new System.Windows.Forms.ToolStripMenuItem();
			this.ContextPlayersBanIp = new System.Windows.Forms.ToolStripMenuItem();
			this.ContextPlayersOp = new System.Windows.Forms.ToolStripMenuItem();
			this.ContextPlayersDeOp = new System.Windows.Forms.ToolStripMenuItem();
			this.CIConsoleInput = new Net.Bertware.Bukkitgui2.Controls.ConsoleInput.ConsoleInput();
			this.MCCOut = new Net.Bertware.Bukkitgui2.Controls.MinecraftConsole.MinecraftConsole();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.performanceMonitor = new Net.Bertware.Bukkitgui2.Controls.PerformanceMonitor.PerformanceMonitor();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.quickButtons = new Net.Bertware.Bukkitgui2.Controls.QuickButtons.QuickButtons();
			this.metroStyleExtender = new MetroFramework.Components.MetroStyleExtender(this.components);
			this.groupBox1.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.ContextPlayers.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.metroStyleExtender.SetApplyMetroTheme(this.groupBox1, true);
			this.groupBox1.BackColor = System.Drawing.Color.Transparent;
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
			this.splitContainer1.Panel1.Controls.Add(this.SlvPlayers);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.CIConsoleInput);
			this.splitContainer1.Panel2.Controls.Add(this.MCCOut);
			this.splitContainer1.Size = new System.Drawing.Size(788, 352);
			this.splitContainer1.SplitterDistance = 160;
			this.splitContainer1.TabIndex = 1;
			// 
			// SlvPlayers
			// 
			this.SlvPlayers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColPlayers});
			this.SlvPlayers.ContextMenuStrip = this.ContextPlayers;
			this.SlvPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SlvPlayers.Location = new System.Drawing.Point(0, 0);
			this.SlvPlayers.Name = "SlvPlayers";
			this.SlvPlayers.Size = new System.Drawing.Size(160, 352);
			this.SlvPlayers.TabIndex = 0;
			this.SlvPlayers.UseCompatibleStateImageBehavior = false;
			this.SlvPlayers.View = System.Windows.Forms.View.Details;
			// 
			// ColPlayers
			// 
			this.ColPlayers.Text = "Players";
			this.ColPlayers.Width = 146;
			// 
			// ContextPlayers
			// 
			this.ContextPlayers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextPlayersKick,
            this.ContextPlayersBan,
            this.ContextPlayersBanIp,
            this.ContextPlayersOp,
            this.ContextPlayersDeOp});
			this.ContextPlayers.Name = "ContextPlayers";
			this.ContextPlayers.Size = new System.Drawing.Size(110, 114);
			// 
			// ContextPlayersKick
			// 
			this.ContextPlayersKick.Image = global::Net.Bertware.Bukkitgui2.Properties.Resources.icon_minus_64;
			this.ContextPlayersKick.Name = "ContextPlayersKick";
			this.ContextPlayersKick.Size = new System.Drawing.Size(109, 22);
			this.ContextPlayersKick.Text = "Kick";
			this.ContextPlayersKick.Click += new System.EventHandler(this.ContextPlayersKick_Click);
			// 
			// ContextPlayersBan
			// 
			this.ContextPlayersBan.Image = global::Net.Bertware.Bukkitgui2.Properties.Resources.icon_cancel_64;
			this.ContextPlayersBan.Name = "ContextPlayersBan";
			this.ContextPlayersBan.Size = new System.Drawing.Size(109, 22);
			this.ContextPlayersBan.Text = "Ban";
			this.ContextPlayersBan.Click += new System.EventHandler(this.ContextPlayersBan_Click);
			// 
			// ContextPlayersBanIp
			// 
			this.ContextPlayersBanIp.Image = global::Net.Bertware.Bukkitgui2.Properties.Resources.icon_cancel_64;
			this.ContextPlayersBanIp.Name = "ContextPlayersBanIp";
			this.ContextPlayersBanIp.Size = new System.Drawing.Size(109, 22);
			this.ContextPlayersBanIp.Text = "Ban-ip";
			this.ContextPlayersBanIp.Click += new System.EventHandler(this.ContextPlayersBanIp_Click);
			// 
			// ContextPlayersOp
			// 
			this.ContextPlayersOp.Image = global::Net.Bertware.Bukkitgui2.Properties.Resources.icon_up_circular_64;
			this.ContextPlayersOp.Name = "ContextPlayersOp";
			this.ContextPlayersOp.Size = new System.Drawing.Size(109, 22);
			this.ContextPlayersOp.Text = "Op";
			this.ContextPlayersOp.Click += new System.EventHandler(this.ContextPlayersOp_Click);
			// 
			// ContextPlayersDeOp
			// 
			this.ContextPlayersDeOp.Image = global::Net.Bertware.Bukkitgui2.Properties.Resources.icon_down_circular_64;
			this.ContextPlayersDeOp.Name = "ContextPlayersDeOp";
			this.ContextPlayersDeOp.Size = new System.Drawing.Size(109, 22);
			this.ContextPlayersDeOp.Text = "De-op";
			this.ContextPlayersDeOp.Click += new System.EventHandler(this.ContextPlayersDeOp_Click);
			// 
			// CIConsoleInput
			// 
			this.CIConsoleInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CIConsoleInput.AutoCompletion = true;
			this.CIConsoleInput.Lines = new string[0];
			this.CIConsoleInput.Location = new System.Drawing.Point(0, 332);
			this.CIConsoleInput.MaxLength = 32767;
			this.CIConsoleInput.Name = "CIConsoleInput";
			this.CIConsoleInput.PasswordChar = '\0';
			this.CIConsoleInput.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.CIConsoleInput.SelectedText = "";
			this.CIConsoleInput.Size = new System.Drawing.Size(624, 20);
			this.CIConsoleInput.TabIndex = 1;
			this.CIConsoleInput.UseSelectable = true;
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
			this.metroStyleExtender.SetApplyMetroTheme(this.groupBox2, true);
			this.groupBox2.BackColor = System.Drawing.Color.Transparent;
			this.groupBox2.Controls.Add(this.performanceMonitor);
			this.groupBox2.Location = new System.Drawing.Point(170, 380);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(624, 117);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Performance";
			// 
			// performanceMonitor
			// 
			this.performanceMonitor.BackColor = System.Drawing.Color.White;
			this.performanceMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.performanceMonitor.Location = new System.Drawing.Point(3, 16);
			this.performanceMonitor.Name = "performanceMonitor";
			this.performanceMonitor.Size = new System.Drawing.Size(618, 98);
			this.performanceMonitor.TabIndex = 0;
			this.performanceMonitor.UseSelectable = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.metroStyleExtender.SetApplyMetroTheme(this.groupBox3, true);
			this.groupBox3.BackColor = System.Drawing.Color.Transparent;
			this.groupBox3.Controls.Add(this.quickButtons);
			this.groupBox3.Location = new System.Drawing.Point(7, 380);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(157, 117);
			this.groupBox3.TabIndex = 5;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Quick Actions";
			// 
			// quickButtons
			// 
			this.quickButtons.Dock = System.Windows.Forms.DockStyle.Fill;
			this.quickButtons.Location = new System.Drawing.Point(3, 16);
			this.quickButtons.Name = "quickButtons";
			this.quickButtons.Size = new System.Drawing.Size(151, 98);
			this.quickButtons.TabIndex = 0;
			this.quickButtons.UseSelectable = true;
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
			this.splitContainer1.ResumeLayout(false);
			this.ContextPlayers.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        internal Net.Bertware.Bukkitgui2.Controls.MinecraftConsole.MinecraftConsole MCCOut;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private Controls.ConsoleInput.ConsoleInput CIConsoleInput;
        internal QuickButtons quickButtons;
        private Controls.PerformanceMonitor.PerformanceMonitor performanceMonitor;
		private Controls.SortableListView.SortableListView SlvPlayers;
		private System.Windows.Forms.ColumnHeader ColPlayers;
		private MetroFramework.Components.MetroStyleExtender metroStyleExtender;
		private MetroFramework.Controls.MetroContextMenu ContextPlayers;
		private System.Windows.Forms.ToolStripMenuItem ContextPlayersKick;
		private System.Windows.Forms.ToolStripMenuItem ContextPlayersBan;
		private System.Windows.Forms.ToolStripMenuItem ContextPlayersBanIp;
		private System.Windows.Forms.ToolStripMenuItem ContextPlayersOp;
		private System.Windows.Forms.ToolStripMenuItem ContextPlayersDeOp;


     }
}
