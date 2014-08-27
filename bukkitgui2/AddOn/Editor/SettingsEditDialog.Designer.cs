namespace Net.Bertware.Bukkitgui2.AddOn.Editor
{
	partial class SettingsEditDialog
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtSetting = new MetroFramework.Controls.MetroTextBox();
			this.txtValue = new MetroFramework.Controls.MetroTextBox();
			this.btnSave = new MetroFramework.Controls.MetroButton();
			this.btnCancel = new MetroFramework.Controls.MetroButton();
			this.lblSetting = new MetroFramework.Controls.MetroLabel();
			this.lblValue = new MetroFramework.Controls.MetroLabel();
			this.SuspendLayout();
			// 
			// txtSetting
			// 
			this.txtSetting.Lines = new string[0];
			this.txtSetting.Location = new System.Drawing.Point(99, 63);
			this.txtSetting.MaxLength = 32767;
			this.txtSetting.Name = "txtSetting";
			this.txtSetting.PasswordChar = '\0';
			this.txtSetting.ReadOnly = true;
			this.txtSetting.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtSetting.SelectedText = "";
			this.txtSetting.Size = new System.Drawing.Size(358, 23);
			this.txtSetting.TabIndex = 0;
			this.txtSetting.UseSelectable = true;
			// 
			// txtValue
			// 
			this.txtValue.Lines = new string[0];
			this.txtValue.Location = new System.Drawing.Point(99, 92);
			this.txtValue.MaxLength = 32767;
			this.txtValue.Name = "txtValue";
			this.txtValue.PasswordChar = '\0';
			this.txtValue.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtValue.SelectedText = "";
			this.txtValue.Size = new System.Drawing.Size(358, 23);
			this.txtValue.TabIndex = 1;
			this.txtValue.UseSelectable = true;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(382, 121);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 2;
			this.btnSave.Text = "&Save";
			this.btnSave.UseSelectable = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(301, 121);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseSelectable = true;
			// 
			// lblSetting
			// 
			this.lblSetting.Location = new System.Drawing.Point(23, 63);
			this.lblSetting.Name = "lblSetting";
			this.lblSetting.Size = new System.Drawing.Size(70, 23);
			this.lblSetting.TabIndex = 4;
			this.lblSetting.Text = "Setting:";
			this.lblSetting.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblValue
			// 
			this.lblValue.Location = new System.Drawing.Point(23, 92);
			this.lblValue.Name = "lblValue";
			this.lblValue.Size = new System.Drawing.Size(70, 23);
			this.lblValue.TabIndex = 5;
			this.lblValue.Text = "Value:";
			this.lblValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// SettingsEditDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(480, 167);
			this.ControlBox = false;
			this.Controls.Add(this.lblValue);
			this.Controls.Add(this.lblSetting);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.txtValue);
			this.Controls.Add(this.txtSetting);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingsEditDialog";
			this.Resizable = false;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit setting";
			this.ResumeLayout(false);

		}

		#endregion

		private MetroFramework.Controls.MetroTextBox txtSetting;
		private MetroFramework.Controls.MetroTextBox txtValue;
		private MetroFramework.Controls.MetroButton btnSave;
		private MetroFramework.Controls.MetroButton btnCancel;
		private MetroFramework.Controls.MetroLabel lblSetting;
		private MetroFramework.Controls.MetroLabel lblValue;
	}
}