namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.TaskerUI
{
	partial class ActionSelector
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
			this.components = new System.ComponentModel.Container();
			this.gbAction = new System.Windows.Forms.GroupBox();
			this.lblActionDescription = new System.Windows.Forms.Label();
			this.btnDeleteAction = new System.Windows.Forms.Button();
			this.lblActionParam = new System.Windows.Forms.Label();
			this.cbAction = new System.Windows.Forms.ComboBox();
			this.txtActionParameters = new System.Windows.Forms.TextBox();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.gbAction.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// gbAction
			// 
			this.gbAction.Controls.Add(this.lblActionDescription);
			this.gbAction.Controls.Add(this.btnDeleteAction);
			this.gbAction.Controls.Add(this.lblActionParam);
			this.gbAction.Controls.Add(this.cbAction);
			this.gbAction.Controls.Add(this.txtActionParameters);
			this.gbAction.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbAction.Location = new System.Drawing.Point(0, 0);
			this.gbAction.Name = "gbAction";
			this.gbAction.Size = new System.Drawing.Size(480, 175);
			this.gbAction.TabIndex = 1;
			this.gbAction.TabStop = false;
			this.gbAction.Text = "Action 1";
			// 
			// lblActionDescription
			// 
			this.lblActionDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblActionDescription.Location = new System.Drawing.Point(6, 82);
			this.lblActionDescription.Name = "lblActionDescription";
			this.lblActionDescription.Size = new System.Drawing.Size(468, 61);
			this.lblActionDescription.TabIndex = 7;
			// 
			// btnDeleteAction
			// 
			this.btnDeleteAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDeleteAction.Location = new System.Drawing.Point(399, 146);
			this.btnDeleteAction.Name = "btnDeleteAction";
			this.btnDeleteAction.Size = new System.Drawing.Size(75, 23);
			this.btnDeleteAction.TabIndex = 7;
			this.btnDeleteAction.Text = "&Delete";
			this.btnDeleteAction.UseVisualStyleBackColor = true;
			// 
			// lblActionParam
			// 
			this.lblActionParam.AutoSize = true;
			this.lblActionParam.Location = new System.Drawing.Point(6, 43);
			this.lblActionParam.Name = "lblActionParam";
			this.lblActionParam.Size = new System.Drawing.Size(63, 13);
			this.lblActionParam.TabIndex = 6;
			this.lblActionParam.Text = "Parameters:";
			// 
			// cbAction
			// 
			this.cbAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbAction.FormattingEnabled = true;
			this.cbAction.Location = new System.Drawing.Point(6, 19);
			this.cbAction.Name = "cbAction";
			this.cbAction.Size = new System.Drawing.Size(468, 21);
			this.cbAction.TabIndex = 4;
			this.cbAction.SelectedIndexChanged += this.cbaction_SelectedIndexChanged;
			// 
			// txtActionParameters
			// 
			this.txtActionParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtActionParameters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.errorProvider.SetIconPadding(this.txtActionParameters, -16);
			this.txtActionParameters.Location = new System.Drawing.Point(6, 59);
			this.txtActionParameters.Name = "txtActionParameters";
			this.txtActionParameters.Size = new System.Drawing.Size(468, 20);
			this.txtActionParameters.TabIndex = 5;
			this.txtActionParameters.TextChanged += txtactionParam_TextChanged;
			// 
			// errorProvider
			// 
			this.errorProvider.ContainerControl = this;
			// 
			// ActionSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gbAction);
			this.Name = "ActionSelector";
			this.Size = new System.Drawing.Size(480, 175);
			this.gbAction.ResumeLayout(false);
			this.gbAction.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbAction;
		private System.Windows.Forms.Label lblActionDescription;
		private System.Windows.Forms.Button btnDeleteAction;
		private System.Windows.Forms.Label lblActionParam;
		private System.Windows.Forms.ComboBox cbAction;
		private System.Windows.Forms.TextBox txtActionParameters;
		private System.Windows.Forms.ErrorProvider errorProvider;
	}
}
