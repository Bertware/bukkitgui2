using MetroFramework.Controls;
using Net.Bertware.Bukkitgui2.Core;

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
			this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
			this.ToolStripBtn.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
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
			this.TabCtrlAddons.Size = new System.Drawing.Size(882, 472);
			this.TabCtrlAddons.TabIndex = 0;
			this.TabCtrlAddons.UseSelectable = true;
			// 
			// LblToolsMainServerState
			// 
			this.LblToolsMainServerState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.LblToolsMainServerState.ContextMenuStrip = this.ToolStripBtn;
			this.LblToolsMainServerState.Location = new System.Drawing.Point(0, 538);
			this.LblToolsMainServerState.Name = "LblToolsMainServerState";
			this.LblToolsMainServerState.Size = new System.Drawing.Size(144, 20);
			this.LblToolsMainServerState.TabIndex = 1;
			this.LblToolsMainServerState.Text = "Server stopped";
			// 
			// ToolStripBtn
			// 
			this.ToolStripBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.ToolStripBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
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
			this.LblToolsMainServerOutput.Location = new System.Drawing.Point(172, 538);
			this.LblToolsMainServerOutput.Name = "LblToolsMainServerOutput";
			this.LblToolsMainServerOutput.Size = new System.Drawing.Size(503, 20);
			this.LblToolsMainServerOutput.TabIndex = 2;
			this.LblToolsMainServerOutput.Text = "No output to show";
			// 
			// SpinServerState
			// 
			this.SpinServerState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.SpinServerState.Location = new System.Drawing.Point(150, 541);
			this.SpinServerState.Maximum = 100;
			this.SpinServerState.Name = "SpinServerState";
			this.SpinServerState.Size = new System.Drawing.Size(16, 16);
			this.SpinServerState.Speed = 2F;
			this.SpinServerState.Spinning = false;
			this.SpinServerState.TabIndex = 4;
			this.SpinServerState.UseSelectable = true;
			this.SpinServerState.UseStyleColors = true;
			this.SpinServerState.Value = 100;
			// 
			// metroStyleManager
			// 
			this.metroStyleManager.Owner = this;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(880, 560);
			this.Controls.Add(this.SpinServerState);
			this.Controls.Add(this.LblToolsMainServerOutput);
			this.Controls.Add(this.LblToolsMainServerState);
			this.Controls.Add(this.TabCtrlAddons);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(880, 560);
			this.Name = "MainForm";
			this.Text = "BukkitGui";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.ToolStripBtn.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
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
		private MetroFramework.Components.MetroStyleManager metroStyleManager;
    }
}
