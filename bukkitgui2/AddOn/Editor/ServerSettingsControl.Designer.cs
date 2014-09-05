namespace Net.Bertware.Bukkitgui2.AddOn.Editor
{
	partial class ServerSettingsControl
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
			this.slvServerSettings = new Net.Bertware.Bukkitgui2.Controls.SortableListView.SortableListView();
			this.ColSetting = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnEdit = new MetroFramework.Controls.MetroButton();
			this.btnAdd = new MetroFramework.Controls.MetroButton();
			this.SuspendLayout();
			// 
			// slvServerSettings
			// 
			this.slvServerSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.slvServerSettings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColSetting,
            this.ColValue});
			this.slvServerSettings.FullRowSelect = true;
			this.slvServerSettings.Location = new System.Drawing.Point(3, 3);
			this.slvServerSettings.Name = "slvServerSettings";
			this.slvServerSettings.Size = new System.Drawing.Size(715, 373);
			this.slvServerSettings.TabIndex = 2;
			this.slvServerSettings.UseCompatibleStateImageBehavior = false;
			this.slvServerSettings.View = System.Windows.Forms.View.Details;
			this.slvServerSettings.DoubleClick += new System.EventHandler(this.slvServerSettings_DoubleClick);
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
			// btnEdit
			// 
			this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEdit.Location = new System.Drawing.Point(643, 382);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(75, 23);
			this.btnEdit.TabIndex = 3;
			this.btnEdit.Text = "&Edit";
			this.btnEdit.UseSelectable = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Location = new System.Drawing.Point(562, 382);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 4;
			this.btnAdd.Text = "&Add";
			this.btnAdd.UseSelectable = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// ServerSettingsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.slvServerSettings);
			this.Name = "ServerSettingsControl";
			this.Size = new System.Drawing.Size(721, 408);
			this.Load += new System.EventHandler(this.ServerSettingsControl_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private Controls.SortableListView.SortableListView slvServerSettings;
		private System.Windows.Forms.ColumnHeader ColSetting;
		private System.Windows.Forms.ColumnHeader ColValue;
		private MetroFramework.Controls.MetroButton btnEdit;
		private MetroFramework.Controls.MetroButton btnAdd;
	}
}
