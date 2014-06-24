namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.TaskerDialog.TaskerUI
{
	partial class ActionPicker
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
			this.CbActionType = new System.Windows.Forms.ComboBox();
			this.panUserControl = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// CbActionType
			// 
			this.CbActionType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CbActionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CbActionType.FormattingEnabled = true;
			this.CbActionType.Location = new System.Drawing.Point(3, 3);
			this.CbActionType.Name = "CbActionType";
			this.CbActionType.Size = new System.Drawing.Size(369, 21);
			this.CbActionType.TabIndex = 5;
			// 
			// panUserControl
			// 
			this.panUserControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panUserControl.Location = new System.Drawing.Point(3, 30);
			this.panUserControl.Name = "panUserControl";
			this.panUserControl.Size = new System.Drawing.Size(369, 142);
			this.panUserControl.TabIndex = 4;
			// 
			// ActionPicker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.CbActionType);
			this.Controls.Add(this.panUserControl);
			this.Name = "ActionPicker";
			this.Size = new System.Drawing.Size(375, 175);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox CbActionType;
		private System.Windows.Forms.Panel panUserControl;
	}
}
