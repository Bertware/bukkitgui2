using System.Windows.Forms;
using MetroFramework.Controls;
using Net.Bertware.Bukkitgui2.Core;

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.TaskerUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskEditor));
            this.gbTrigger = new System.Windows.Forms.GroupBox();
            this.lblTriggerDescription = new MetroFramework.Controls.MetroLabel();
            this.label2 = new MetroFramework.Controls.MetroLabel();
            this.txtTriggerParam = new MetroFramework.Controls.MetroTextBox();
            this.cbTrigger = new MetroFramework.Controls.MetroComboBox();
            this.gbAction = new System.Windows.Forms.GroupBox();
            this.actionPanel = new System.Windows.Forms.Panel();
            this.btnNewAction = new MetroFramework.Controls.MetroButton();
            this.txtName = new MetroFramework.Controls.MetroTextBox();
            this.lblName = new MetroFramework.Controls.MetroLabel();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.chkEnable = new MetroFramework.Controls.MetroCheckBox();
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
            this.gbTrigger.Location = new System.Drawing.Point(23, 85);
            this.gbTrigger.Name = "gbTrigger";
            this.gbTrigger.Size = new System.Drawing.Size(469, 170);
            this.gbTrigger.TabIndex = 0;
            this.gbTrigger.TabStop = false;
            this.gbTrigger.Text = "Trigger";
            // 
            // lblTriggerDescription
            // 
            this.lblTriggerDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTriggerDescription.Location = new System.Drawing.Point(6, 96);
            this.lblTriggerDescription.Name = "lblTriggerDescription";
            this.lblTriggerDescription.Size = new System.Drawing.Size(457, 58);
            this.lblTriggerDescription.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Parameters:";
            // 
            // txtTriggerParam
            // 
            this.txtTriggerParam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.errorProvider.SetIconPadding(this.txtTriggerParam, -16);
            this.txtTriggerParam.Lines = new string[0];
            this.txtTriggerParam.Location = new System.Drawing.Point(6, 73);
            this.txtTriggerParam.MaxLength = 32767;
            this.txtTriggerParam.Name = "txtTriggerParam";
            this.txtTriggerParam.PasswordChar = '\0';
            this.txtTriggerParam.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTriggerParam.SelectedText = "";
            this.txtTriggerParam.Size = new System.Drawing.Size(457, 20);
            this.txtTriggerParam.TabIndex = 1;
            this.txtTriggerParam.UseSelectable = true;
            this.txtTriggerParam.TextChanged += new System.EventHandler(this.txtTriggerParam_TextChanged);
            // 
            // cbTrigger
            // 
            this.cbTrigger.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTrigger.FormattingEnabled = true;
            this.cbTrigger.ItemHeight = 23;
            this.cbTrigger.Location = new System.Drawing.Point(6, 19);
            this.cbTrigger.Name = "cbTrigger";
            this.cbTrigger.Size = new System.Drawing.Size(457, 29);
            this.cbTrigger.TabIndex = 0;
            this.cbTrigger.UseSelectable = true;
            this.cbTrigger.SelectedIndexChanged += new System.EventHandler(this.cbTrigger_SelectedIndexChanged);
            // 
            // gbAction
            // 
            this.gbAction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAction.Controls.Add(this.actionPanel);
            this.gbAction.Controls.Add(this.btnNewAction);
            this.gbAction.Location = new System.Drawing.Point(23, 261);
            this.gbAction.Name = "gbAction";
            this.gbAction.Size = new System.Drawing.Size(469, 279);
            this.gbAction.TabIndex = 1;
            this.gbAction.TabStop = false;
            this.gbAction.Text = "Action";
            // 
            // actionPanel
            // 
            this.actionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actionPanel.AutoScroll = true;
            this.actionPanel.Location = new System.Drawing.Point(0, 48);
            this.actionPanel.Name = "actionPanel";
            this.actionPanel.Size = new System.Drawing.Size(469, 225);
            this.actionPanel.TabIndex = 7;
            // 
            // btnNewAction
            // 
            this.btnNewAction.Location = new System.Drawing.Point(6, 19);
            this.btnNewAction.Name = "btnNewAction";
            this.btnNewAction.Size = new System.Drawing.Size(75, 23);
            this.btnNewAction.TabIndex = 6;
            this.btnNewAction.Text = "&Add action";
            this.btnNewAction.UseSelectable = true;
            this.btnNewAction.Click += new System.EventHandler(this.btnNewaction_Click);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Lines = new string[0];
            this.txtName.Location = new System.Drawing.Point(75, 59);
            this.txtName.MaxLength = 32767;
            this.txtName.Name = "txtName";
            this.txtName.PasswordChar = '\0';
            this.txtName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtName.SelectedText = "";
            this.txtName.Size = new System.Drawing.Size(336, 20);
            this.txtName.TabIndex = 2;
            this.txtName.UseSelectable = true;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(21, 60);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(48, 19);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name:";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(417, 546);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(336, 546);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseSelectable = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkEnable
            // 
            this.chkEnable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkEnable.Checked = true;
            this.chkEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnable.Location = new System.Drawing.Point(417, 59);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(75, 20);
            this.chkEnable.TabIndex = 6;
            this.chkEnable.Text = "Enable";
            this.chkEnable.UseSelectable = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // TaskEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 580);
            this.Controls.Add(this.chkEnable);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.gbAction);
            this.Controls.Add(this.gbTrigger);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaskEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Edit Task..";
            this.TopMost = true;
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
        private MetroTextBox txtName;
        private MetroLabel lblName;
        private MetroButton btnSave;
        private MetroButton btnCancel;
        private MetroComboBox cbTrigger;
        private MetroButton btnNewAction;
        private MetroLabel lblTriggerDescription;
        private MetroLabel label2;
        private MetroTextBox txtTriggerParam;
        private MetroCheckBox chkEnable;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private Panel actionPanel;
    }
}
