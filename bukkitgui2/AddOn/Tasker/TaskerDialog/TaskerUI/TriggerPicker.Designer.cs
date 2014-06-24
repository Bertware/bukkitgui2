namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.TaskerDialog.TaskerUI
{
	partial class TriggerPicker
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
			this.CbTrigger = new System.Windows.Forms.ComboBox();
			this.panUserControl = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// CbTrigger
			// 
			this.CbTrigger.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CbTrigger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CbTrigger.FormattingEnabled = true;
			this.CbTrigger.Location = new System.Drawing.Point(3, 3);
			this.CbTrigger.Name = "CbTrigger";
			this.CbTrigger.Size = new System.Drawing.Size(369, 21);
			this.CbTrigger.TabIndex = 4;
			// 
			// panUserControl
			// 
			this.panUserControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panUserControl.Location = new System.Drawing.Point(3, 30);
			this.panUserControl.Name = "panUserControl";
			this.panUserControl.Size = new System.Drawing.Size(369, 142);
			this.panUserControl.TabIndex = 3;
			// 
			// TriggerPicker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.CbTrigger);
			this.Controls.Add(this.panUserControl);
			this.Name = "TriggerPicker";
			this.Size = new System.Drawing.Size(375, 175);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox CbTrigger;
		private System.Windows.Forms.Panel panUserControl;
	}
}
