namespace Net.Bertware.Bukkitgui2.AddOn.PlayerList
{
	partial class PlayerListTab
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
			this.SlvPlayers = new Net.Bertware.Bukkitgui2.Controls.SortableListView.SortableListView();
			this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colDispName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colTimeJoined = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ContextPlayers = new MetroFramework.Controls.MetroContextMenu(this.components);
			this.ContextPlayersKick = new System.Windows.Forms.ToolStripMenuItem();
			this.ContextPlayersBan = new System.Windows.Forms.ToolStripMenuItem();
			this.ContextPlayersBanIp = new System.Windows.Forms.ToolStripMenuItem();
			this.ContextPlayersOp = new System.Windows.Forms.ToolStripMenuItem();
			this.ContextPlayersDeOp = new System.Windows.Forms.ToolStripMenuItem();
			this.ContextPlayers.SuspendLayout();
			this.SuspendLayout();
			// 
			// SlvPlayers
			// 
			this.SlvPlayers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colDispName,
            this.colIP,
            this.colTimeJoined,
            this.colLocation});
			this.SlvPlayers.ContextMenuStrip = this.ContextPlayers;
			this.SlvPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SlvPlayers.Location = new System.Drawing.Point(0, 0);
			this.SlvPlayers.Name = "SlvPlayers";
			this.SlvPlayers.Size = new System.Drawing.Size(800, 500);
			this.SlvPlayers.TabIndex = 0;
			this.SlvPlayers.UseCompatibleStateImageBehavior = false;
			this.SlvPlayers.View = System.Windows.Forms.View.Details;
			// 
			// colName
			// 
			this.colName.Text = "Name";
			this.colName.Width = 120;
			// 
			// colDispName
			// 
			this.colDispName.Text = "Display Name";
			this.colDispName.Width = 120;
			// 
			// colIP
			// 
			this.colIP.Text = "IP Address";
			this.colIP.Width = 120;
			// 
			// colTimeJoined
			// 
			this.colTimeJoined.Text = "Time";
			// 
			// colLocation
			// 
			this.colLocation.Text = "Location";
			this.colLocation.Width = 120;
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
			this.ContextPlayersKick.Name = "ContextPlayersKick";
			this.ContextPlayersKick.Size = new System.Drawing.Size(109, 22);
			this.ContextPlayersKick.Text = "Kick";
			this.ContextPlayersKick.Click += new System.EventHandler(this.ContextPlayersKick_Click);
			// 
			// ContextPlayersBan
			// 
			this.ContextPlayersBan.Name = "ContextPlayersBan";
			this.ContextPlayersBan.Size = new System.Drawing.Size(109, 22);
			this.ContextPlayersBan.Text = "Ban";
			this.ContextPlayersBan.Click += new System.EventHandler(this.ContextPlayersBan_Click);
			// 
			// ContextPlayersBanIp
			// 
			this.ContextPlayersBanIp.Name = "ContextPlayersBanIp";
			this.ContextPlayersBanIp.Size = new System.Drawing.Size(109, 22);
			this.ContextPlayersBanIp.Text = "Ban-ip";
			this.ContextPlayersBanIp.Click += new System.EventHandler(this.ContextPlayersBanIp_Click);
			// 
			// ContextPlayersOp
			// 
			this.ContextPlayersOp.Name = "ContextPlayersOp";
			this.ContextPlayersOp.Size = new System.Drawing.Size(109, 22);
			this.ContextPlayersOp.Text = "Op";
			this.ContextPlayersOp.Click += new System.EventHandler(this.ContextPlayersOp_Click);
			// 
			// ContextPlayersDeOp
			// 
			this.ContextPlayersDeOp.Name = "ContextPlayersDeOp";
			this.ContextPlayersDeOp.Size = new System.Drawing.Size(109, 22);
			this.ContextPlayersDeOp.Text = "De-op";
			this.ContextPlayersDeOp.Click += new System.EventHandler(this.ContextPlayersDeOp_Click);
			// 
			// PlayerListTab
			// 
			this.Controls.Add(this.SlvPlayers);
			this.Name = "PlayerListTab";
			this.Size = new System.Drawing.Size(800, 500);
			this.ContextPlayers.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

        private Controls.SortableListView.SortableListView SlvPlayers;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colIP;
		private System.Windows.Forms.ColumnHeader colDispName;
		private System.Windows.Forms.ColumnHeader colTimeJoined;
		private System.Windows.Forms.ColumnHeader colLocation;
		private MetroFramework.Controls.MetroContextMenu ContextPlayers;
		private System.Windows.Forms.ToolStripMenuItem ContextPlayersKick;
		private System.Windows.Forms.ToolStripMenuItem ContextPlayersBan;
		private System.Windows.Forms.ToolStripMenuItem ContextPlayersBanIp;
		private System.Windows.Forms.ToolStripMenuItem ContextPlayersOp;
		private System.Windows.Forms.ToolStripMenuItem ContextPlayersDeOp;
	}
}
