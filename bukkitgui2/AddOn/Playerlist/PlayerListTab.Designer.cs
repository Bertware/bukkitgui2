namespace Bukkitgui2.AddOn.PlayerList
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
            this.sortableListView1 = new Bukkitgui2.Controls.SortableListView.SortableListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // sortableListView1
            // 
            this.sortableListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colIP});
            this.sortableListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sortableListView1.Location = new System.Drawing.Point(0, 0);
            this.sortableListView1.Name = "sortableListView1";
            this.sortableListView1.Size = new System.Drawing.Size(800, 500);
            this.sortableListView1.TabIndex = 0;
            this.sortableListView1.UseCompatibleStateImageBehavior = false;
            this.sortableListView1.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            // 
            // colIP
            // 
            this.colIP.Text = "IP Address";
            // 
            // PlayerListTab
            // 
            this.Controls.Add(this.sortableListView1);
            this.Name = "PlayerListTab";
            this.Size = new System.Drawing.Size(800, 500);
            this.ResumeLayout(false);

		}

		#endregion

        private Controls.SortableListView.SortableListView sortableListView1;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colIP;
	}
}
