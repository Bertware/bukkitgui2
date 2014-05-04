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
			this.slvPlayers = new Net.Bertware.Bukkitgui2.Controls.SortableListView.SortableListView();
			this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colDispName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colTimeJoined = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// slvPlayers
			// 
			this.slvPlayers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colDispName,
            this.colIP,
            this.colTimeJoined,
            this.colLocation});
			this.slvPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.slvPlayers.Location = new System.Drawing.Point(0, 0);
			this.slvPlayers.Name = "slvPlayers";
			this.slvPlayers.Size = new System.Drawing.Size(800, 500);
			this.slvPlayers.TabIndex = 0;
			this.slvPlayers.UseCompatibleStateImageBehavior = false;
			this.slvPlayers.View = System.Windows.Forms.View.Details;
			// 
			// colName
			// 
			this.colName.Text = "Name";
			this.colName.Width = 120;
			// 
			// colIP
			// 
			this.colIP.Text = "IP Address";
			this.colIP.Width = 120;
			// 
			// colDispName
			// 
			this.colDispName.Text = "Display Name";
			this.colDispName.Width = 120;
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
			// PlayerListTab
			// 
			this.Controls.Add(this.slvPlayers);
			this.Name = "PlayerListTab";
			this.Size = new System.Drawing.Size(800, 500);
			this.ResumeLayout(false);

		}

		#endregion

        private Controls.SortableListView.SortableListView slvPlayers;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colIP;
		private System.Windows.Forms.ColumnHeader colDispName;
		private System.Windows.Forms.ColumnHeader colTimeJoined;
		private System.Windows.Forms.ColumnHeader colLocation;
	}
}
