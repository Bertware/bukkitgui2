namespace Net.Bertware.Bukkitgui2.AddOn.Tasker
{
	partial class TaskerTab
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
			this.btnNew = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnTest = new System.Windows.Forms.Button();
			this.sortableListView1 = new Net.Bertware.Bukkitgui2.Controls.SortableListView.SortableListView();
			this.ColName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColTrigger = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColTriggerSettings = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColAction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColActionSettings = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colEnable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// btnNew
			// 
			this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNew.Location = new System.Drawing.Point(722, 474);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(75, 23);
			this.btnNew.TabIndex = 1;
			this.btnNew.Text = "&New task";
			this.btnNew.UseVisualStyleBackColor = true;
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelete.Location = new System.Drawing.Point(641, 474);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 2;
			this.btnDelete.Text = "&Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			// 
			// btnTest
			// 
			this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnTest.Location = new System.Drawing.Point(560, 474);
			this.btnTest.Name = "btnTest";
			this.btnTest.Size = new System.Drawing.Size(75, 23);
			this.btnTest.TabIndex = 3;
			this.btnTest.Text = "&Test";
			this.btnTest.UseVisualStyleBackColor = true;
			// 
			// sortableListView1
			// 
			this.sortableListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.sortableListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColName,
            this.ColTrigger,
            this.ColTriggerSettings,
            this.ColAction,
            this.ColActionSettings,
            this.colEnable});
			this.sortableListView1.Location = new System.Drawing.Point(3, 3);
			this.sortableListView1.Name = "sortableListView1";
			this.sortableListView1.Size = new System.Drawing.Size(794, 465);
			this.sortableListView1.TabIndex = 0;
			this.sortableListView1.UseCompatibleStateImageBehavior = false;
			this.sortableListView1.View = System.Windows.Forms.View.Details;
			// 
			// ColName
			// 
			this.ColName.Text = "Name";
			this.ColName.Width = 120;
			// 
			// ColTrigger
			// 
			this.ColTrigger.Text = "Trigger";
			this.ColTrigger.Width = 120;
			// 
			// ColTriggerSettings
			// 
			this.ColTriggerSettings.Text = "Trigger Settings";
			this.ColTriggerSettings.Width = 120;
			// 
			// ColAction
			// 
			this.ColAction.Text = "Action";
			this.ColAction.Width = 120;
			// 
			// ColActionSettings
			// 
			this.ColActionSettings.Text = "ActionSettings";
			this.ColActionSettings.Width = 120;
			// 
			// colEnable
			// 
			this.colEnable.Text = "Enabled";
			// 
			// TaskerTab
			// 
			this.Controls.Add(this.btnTest);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnNew);
			this.Controls.Add(this.sortableListView1);
			this.Name = "TaskerTab";
			this.Size = new System.Drawing.Size(800, 500);
			this.ResumeLayout(false);

		}

		#endregion

		private Controls.SortableListView.SortableListView sortableListView1;
		private System.Windows.Forms.ColumnHeader ColName;
		private System.Windows.Forms.ColumnHeader ColTrigger;
		private System.Windows.Forms.ColumnHeader ColTriggerSettings;
		private System.Windows.Forms.ColumnHeader ColAction;
		private System.Windows.Forms.ColumnHeader ColActionSettings;
		private System.Windows.Forms.ColumnHeader colEnable;
		private System.Windows.Forms.Button btnNew;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnTest;
	}
}
