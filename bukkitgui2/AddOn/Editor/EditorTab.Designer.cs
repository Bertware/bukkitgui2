namespace Net.Bertware.Bukkitgui2.AddOn.Editor
{
    using System.Windows.Forms;

    partial class EditorTab: UserControl
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
			this.sortableListView1 = new Net.Bertware.Bukkitgui2.Controls.SortableListView.SortableListView();
			this.gbSettings = new System.Windows.Forms.GroupBox();
			this.ColSetting = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.gbSettings.SuspendLayout();
			this.SuspendLayout();
			// 
			// sortableListView1
			// 
			this.sortableListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColSetting,
            this.ColValue});
			this.sortableListView1.Location = new System.Drawing.Point(6, 19);
			this.sortableListView1.Name = "sortableListView1";
			this.sortableListView1.Size = new System.Drawing.Size(772, 331);
			this.sortableListView1.TabIndex = 0;
			this.sortableListView1.UseCompatibleStateImageBehavior = false;
			this.sortableListView1.View = System.Windows.Forms.View.Details;
			// 
			// gbSettings
			// 
			this.gbSettings.BackColor = System.Drawing.Color.White;
			this.gbSettings.Controls.Add(this.sortableListView1);
			this.gbSettings.Location = new System.Drawing.Point(3, 3);
			this.gbSettings.Name = "gbSettings";
			this.gbSettings.Size = new System.Drawing.Size(784, 356);
			this.gbSettings.TabIndex = 1;
			this.gbSettings.TabStop = false;
			this.gbSettings.Text = "Server Settings";
			// 
			// ColSetting
			// 
			this.ColSetting.Text = "Setting";
			this.ColSetting.Width = 180;
			// 
			// ColValue
			// 
			this.ColValue.Text = "Value";
			this.ColValue.Width = 240;
			// 
			// EditorTab
			// 
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.gbSettings);
			this.Name = "EditorTab";
			this.Size = new System.Drawing.Size(800, 500);
			this.gbSettings.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private Controls.SortableListView.SortableListView sortableListView1;
		private ColumnHeader ColSetting;
		private ColumnHeader ColValue;
		private GroupBox gbSettings;
	}
}
