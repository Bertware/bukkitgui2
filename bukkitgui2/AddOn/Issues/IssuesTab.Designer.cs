using Net.Bertware.Bukkitgui2.Core;

namespace Net.Bertware.Bukkitgui2.AddOn.Issues
{
	partial class IssuesTab
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
			this.slvIssues = new Net.Bertware.Bukkitgui2.Controls.SortableListView.SortableListView();
			this.ColId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lblInfo = new MetroFramework.Controls.MetroLabel();
			this.SuspendLayout();
			// 
			// slvIssues
			// 
			this.slvIssues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.slvIssues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColId,
            this.ColType,
            this.ColTime,
            this.ColMessage});
			this.slvIssues.Location = new System.Drawing.Point(3, 22);
			this.slvIssues.Name = "slvIssues";
			this.slvIssues.Size = new System.Drawing.Size(794, 475);
			this.slvIssues.TabIndex = 0;
			this.slvIssues.UseCompatibleStateImageBehavior = false;
			this.slvIssues.View = System.Windows.Forms.View.Details;
			// 
			// ColId
			// 
			this.ColId.Text = Locale.Tr("Id");
			// 
			// ColType
			// 
			this.ColType.Text = Locale.Tr("Type");
			this.ColType.Width = 90;
			// 
			// ColTime
			// 
			this.ColTime.Text = Locale.Tr("Time");
			this.ColTime.Width = 90;
			// 
			// ColMessage
			// 
			this.ColMessage.Text = Locale.Tr("Message");
			this.ColMessage.Width = 480;
			// 
			// lblInfo
			// 
			this.lblInfo.AutoSize = true;
			this.lblInfo.Location = new System.Drawing.Point(3, 0);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(660, 19);
			this.lblInfo.TabIndex = 1;
			this.lblInfo.Text =
				Locale.Tr(
					"Below you can find all warning and error messages, created by the server. Auto-fixing is not available right now.");
			// 
			// IssuesTab
			// 
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.lblInfo);
			this.Controls.Add(this.slvIssues);
			this.Name = "IssuesTab";
			this.Size = new System.Drawing.Size(800, 500);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Controls.SortableListView.SortableListView slvIssues;
		private System.Windows.Forms.ColumnHeader ColId;
		private System.Windows.Forms.ColumnHeader ColType;
		private System.Windows.Forms.ColumnHeader ColTime;
		private System.Windows.Forms.ColumnHeader ColMessage;
		private MetroFramework.Controls.MetroLabel lblInfo;

	}
}
