using MetroFramework.Controls;

namespace Net.Bertware.Bukkitgui2.UI
{
    partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.TabCtrlAddons = new MetroFramework.Controls.MetroTabControl();
			this.LblToolsMainServerState = new MetroFramework.Controls.MetroLabel();
			this.ToolStripBtn = new MetroFramework.Controls.MetroContextMenu(this.components);
			this.ToolStripBtnStartStop = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripBtnRestart = new System.Windows.Forms.ToolStripMenuItem();
			this.metroStyleExtender = new MetroFramework.Components.MetroStyleExtender(this.components);
			this.LblToolsMainServerOutput = new MetroFramework.Controls.MetroLabel();
			this.SpinServerState = new MetroFramework.Controls.MetroProgressSpinner();
			this.ToolStripBtn.SuspendLayout();
			this.SuspendLayout();
			// 
			// TabCtrlAddons
			// 
			this.TabCtrlAddons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TabCtrlAddons.Location = new System.Drawing.Point(0, 63);
			this.TabCtrlAddons.Margin = new System.Windows.Forms.Padding(0);
			this.TabCtrlAddons.Name = "TabCtrlAddons";
			this.TabCtrlAddons.Size = new System.Drawing.Size(886, 474);
			this.TabCtrlAddons.TabIndex = 0;
			this.TabCtrlAddons.UseSelectable = true;
			// 
			// LblToolsMainServerState
			// 
			this.LblToolsMainServerState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.LblToolsMainServerState.ContextMenuStrip = this.ToolStripBtn;
			this.LblToolsMainServerState.Location = new System.Drawing.Point(0, 537);
			this.LblToolsMainServerState.Name = "LblToolsMainServerState";
			this.LblToolsMainServerState.Size = new System.Drawing.Size(144, 23);
			this.LblToolsMainServerState.TabIndex = 1;
			this.LblToolsMainServerState.Text = "Server stopped";
			// 
			// ToolStripBtn
			// 
			this.ToolStripBtn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripBtnStartStop,
            this.ToolStripBtnRestart});
			this.ToolStripBtn.Name = "ToolStripBtn";
			this.ToolStripBtn.Size = new System.Drawing.Size(111, 48);
			// 
			// ToolStripBtnStartStop
			// 
			this.ToolStripBtnStartStop.Name = "ToolStripBtnStartStop";
			this.ToolStripBtnStartStop.Size = new System.Drawing.Size(110, 22);
			this.ToolStripBtnStartStop.Text = "Start";
			this.ToolStripBtnStartStop.Click += new System.EventHandler(this.ToolStripBtnStartStop_Click);
			// 
			// ToolStripBtnRestart
			// 
			this.ToolStripBtnRestart.Name = "ToolStripBtnRestart";
			this.ToolStripBtnRestart.Size = new System.Drawing.Size(110, 22);
			this.ToolStripBtnRestart.Text = "Restart";
			this.ToolStripBtnRestart.Click += new System.EventHandler(this.ToolStripBtnRestart_Click);
			// 
			// LblToolsMainServerOutput
			// 
			this.LblToolsMainServerOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LblToolsMainServerOutput.Location = new System.Drawing.Point(172, 537);
			this.LblToolsMainServerOutput.Name = "LblToolsMainServerOutput";
			this.LblToolsMainServerOutput.Size = new System.Drawing.Size(689, 23);
			this.LblToolsMainServerOutput.TabIndex = 2;
			this.LblToolsMainServerOutput.Text = "No output to show";
			// 
			// SpinServerState
			// 
			this.SpinServerState.Location = new System.Drawing.Point(150, 540);
			this.SpinServerState.Maximum = 100;
			this.SpinServerState.Name = "SpinServerState";
			this.SpinServerState.Size = new System.Drawing.Size(16, 16);
			this.SpinServerState.Speed = 2F;
			this.SpinServerState.Spinning = false;
			this.SpinServerState.TabIndex = 4;
			this.SpinServerState.UseSelectable = true;
			this.SpinServerState.Value = 100;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(884, 562);
			this.Controls.Add(this.SpinServerState);
			this.Controls.Add(this.LblToolsMainServerOutput);
			this.Controls.Add(this.LblToolsMainServerState);
			this.Controls.Add(this.TabCtrlAddons);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "BukkitGui";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.ToolStripBtn.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

		private MetroTabControl TabCtrlAddons;
		private MetroLabel LblToolsMainServerState;
		private MetroFramework.Components.MetroStyleExtender metroStyleExtender;
		private MetroLabel LblToolsMainServerOutput;
		private MetroContextMenu ToolStripBtn;
		private System.Windows.Forms.ToolStripMenuItem ToolStripBtnStartStop;
		private System.Windows.Forms.ToolStripMenuItem ToolStripBtnRestart;
		private MetroProgressSpinner SpinServerState;
    }
}