namespace Net.Bertware.Bukkitgui2.AddOn.Editor
{
    using System.Windows.Forms;

	partial class WhitelistControl : UserControl
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
			this.btnAdd = new MetroFramework.Controls.MetroButton();
			this.btnEdit = new MetroFramework.Controls.MetroButton();
			this.slvList = new Net.Bertware.Bukkitgui2.Controls.SortableListView.SortableListView();
			this.ColSetting = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnRemove = new MetroFramework.Controls.MetroButton();
			this.SuspendLayout();
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Location = new System.Drawing.Point(682, 374);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 7;
			this.btnAdd.Text = "&Add";
			this.btnAdd.UseSelectable = true;
			// 
			// btnEdit
			// 
			this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEdit.Location = new System.Drawing.Point(601, 374);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(75, 23);
			this.btnEdit.TabIndex = 6;
			this.btnEdit.Text = "&Edit";
			this.btnEdit.UseSelectable = true;
			// 
			// slvList
			// 
			this.slvList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.slvList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColSetting,
            this.ColValue});
			this.slvList.FullRowSelect = true;
			this.slvList.Location = new System.Drawing.Point(3, 3);
			this.slvList.Name = "slvList";
			this.slvList.Size = new System.Drawing.Size(754, 365);
			this.slvList.TabIndex = 5;
			this.slvList.UseCompatibleStateImageBehavior = false;
			this.slvList.View = System.Windows.Forms.View.Details;
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
			// btnRemove
			// 
			this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRemove.Location = new System.Drawing.Point(520, 374);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(75, 23);
			this.btnRemove.TabIndex = 8;
			this.btnRemove.Text = "&Remove";
			this.btnRemove.UseSelectable = true;
			// 
			// EditorTab
			// 
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.slvList);
			this.Name = "EditorTab";
			this.Size = new System.Drawing.Size(760, 400);
			this.ResumeLayout(false);

		}

		#endregion

		private MetroFramework.Controls.MetroButton btnAdd;
		private MetroFramework.Controls.MetroButton btnEdit;
		private Controls.SortableListView.SortableListView slvList;
		private ColumnHeader ColSetting;
		private ColumnHeader ColValue;
		private MetroFramework.Controls.MetroButton btnRemove;


	}
}
