namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.TaskerDialog.TaskerUI
{
	partial class TaskEditor
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
			this.components = new System.ComponentModel.Container();
			this.gbTrigger = new System.Windows.Forms.GroupBox();
			this.lblTriggerDescription = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtTriggerParam = new System.Windows.Forms.TextBox();
			this.cbTrigger = new System.Windows.Forms.ComboBox();
			this.gbAction = new System.Windows.Forms.GroupBox();
			this.btnNewAction = new System.Windows.Forms.Button();
			this.txtName = new System.Windows.Forms.TextBox();
			this.lblName = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.chkEnable = new System.Windows.Forms.CheckBox();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.gbTrigger.SuspendLayout();
			this.gbAction.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// gbTrigger
			// 
			this.gbTrigger.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbTrigger.Controls.Add(this.lblTriggerDescription);
			this.gbTrigger.Controls.Add(this.label2);
			this.gbTrigger.Controls.Add(this.txtTriggerParam);
			this.gbTrigger.Controls.Add(this.cbTrigger);
			this.gbTrigger.Location = new System.Drawing.Point(12, 32);
			this.gbTrigger.Name = "gbTrigger";
			this.gbTrigger.Size = new System.Drawing.Size(494, 148);
			this.gbTrigger.TabIndex = 0;
			this.gbTrigger.TabStop = false;
			this.gbTrigger.Text = "Trigger";
			// 
			// lblTriggerDescription
			// 
			this.lblTriggerDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblTriggerDescription.Location = new System.Drawing.Point(6, 82);
			this.lblTriggerDescription.Name = "lblTriggerDescription";
			this.lblTriggerDescription.Size = new System.Drawing.Size(482, 63);
			this.lblTriggerDescription.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Parameters:";
			// 
			// txtTriggerParam
			// 
			this.txtTriggerParam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTriggerParam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.errorProvider.SetIconPadding(this.txtTriggerParam, -16);
			this.txtTriggerParam.Location = new System.Drawing.Point(6, 59);
			this.txtTriggerParam.Name = "txtTriggerParam";
			this.txtTriggerParam.Size = new System.Drawing.Size(482, 20);
			this.txtTriggerParam.TabIndex = 1;
			this.txtTriggerParam.TextChanged += new System.EventHandler(this.txtTriggerParam_TextChanged);
			// 
			// cbTrigger
			// 
			this.cbTrigger.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbTrigger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTrigger.FormattingEnabled = true;
			this.cbTrigger.Location = new System.Drawing.Point(6, 19);
			this.cbTrigger.Name = "cbTrigger";
			this.cbTrigger.Size = new System.Drawing.Size(482, 21);
			this.cbTrigger.TabIndex = 0;
			this.cbTrigger.SelectedIndexChanged += new System.EventHandler(this.cbTrigger_SelectedIndexChanged);
			// 
			// gbAction
			// 
			this.gbAction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbAction.Controls.Add(this.btnNewAction);
			this.gbAction.Location = new System.Drawing.Point(12, 186);
			this.gbAction.Name = "gbAction";
			this.gbAction.Size = new System.Drawing.Size(494, 54);
			this.gbAction.TabIndex = 1;
			this.gbAction.TabStop = false;
			this.gbAction.Text = "Action";
			// 
			// btnNewAction
			// 
			this.btnNewAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNewAction.Location = new System.Drawing.Point(9, 19);
			this.btnNewAction.Name = "btnNewAction";
			this.btnNewAction.Size = new System.Drawing.Size(75, 23);
			this.btnNewAction.TabIndex = 6;
			this.btnNewAction.Text = "&Add action";
			this.btnNewAction.UseVisualStyleBackColor = true;
			this.btnNewAction.Click += new System.EventHandler(this.btnNewaction_Click);
			// 
			// txtName
			// 
			this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtName.Location = new System.Drawing.Point(53, 6);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(367, 20);
			this.txtName.TabIndex = 2;
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(9, 9);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(38, 13);
			this.lblName.TabIndex = 3;
			this.lblName.Text = "Name:";
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(431, 245);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 4;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(350, 245);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// chkEnable
			// 
			this.chkEnable.Location = new System.Drawing.Point(426, 8);
			this.chkEnable.Name = "chkEnable";
			this.chkEnable.Size = new System.Drawing.Size(80, 17);
			this.chkEnable.TabIndex = 6;
			this.chkEnable.Text = "Enable";
			this.chkEnable.UseVisualStyleBackColor = true;
			// 
			// errorProvider
			// 
			this.errorProvider.ContainerControl = this;
			// 
			// TaskEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(518, 280);
			this.Controls.Add(this.chkEnable);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.gbAction);
			this.Controls.Add(this.gbTrigger);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "TaskEditor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Task..";
			this.gbTrigger.ResumeLayout(false);
			this.gbTrigger.PerformLayout();
			this.gbAction.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox gbTrigger;
		private System.Windows.Forms.GroupBox gbAction;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ComboBox cbTrigger;
		private System.Windows.Forms.Button btnNewAction;
		private System.Windows.Forms.Label lblTriggerDescription;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtTriggerParam;
		private System.Windows.Forms.CheckBox chkEnable;
		private System.Windows.Forms.ErrorProvider errorProvider;
	}
}