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
			this.TabCtrlAddons = new System.Windows.Forms.TabControl();
			this.StatusStripMain = new System.Windows.Forms.StatusStrip();
			this.LblToolsMainServerState = new System.Windows.Forms.ToolStripStatusLabel();
			this.MenuToolsMainServerAction = new System.Windows.Forms.ToolStripDropDownButton();
			this.ToolStripBtnReload = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripBtnRestart = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripBtnStartStop = new System.Windows.Forms.ToolStripMenuItem();
			this.LblToolsMainServerOutput = new System.Windows.Forms.ToolStripStatusLabel();
			this.ProgBarToolsMain = new System.Windows.Forms.ToolStripProgressBar();
			this.LblToolsMainGUIState = new System.Windows.Forms.ToolStripStatusLabel();
			this.StatusStripMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// TabCtrlAddons
			// 
			this.TabCtrlAddons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TabCtrlAddons.Location = new System.Drawing.Point(0, 0);
			this.TabCtrlAddons.Name = "TabCtrlAddons";
			this.TabCtrlAddons.SelectedIndex = 0;
			this.TabCtrlAddons.Size = new System.Drawing.Size(884, 537);
			this.TabCtrlAddons.TabIndex = 0;
			// 
			// StatusStripMain
			// 
			this.StatusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LblToolsMainServerState,
            this.MenuToolsMainServerAction,
            this.LblToolsMainServerOutput,
            this.ProgBarToolsMain,
            this.LblToolsMainGUIState});
			this.StatusStripMain.Location = new System.Drawing.Point(0, 540);
			this.StatusStripMain.Name = "StatusStripMain";
			this.StatusStripMain.Size = new System.Drawing.Size(884, 22);
			this.StatusStripMain.TabIndex = 1;
			this.StatusStripMain.Text = "statusStrip1";
			// 
			// LblToolsMainServerState
			// 
			this.LblToolsMainServerState.AutoSize = false;
			this.LblToolsMainServerState.Name = "LblToolsMainServerState";
			this.LblToolsMainServerState.Size = new System.Drawing.Size(105, 17);
			this.LblToolsMainServerState.Text = "Server not running";
			this.LblToolsMainServerState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LblToolsMainServerState.ToolTipText = "Server state (starting/stopping/running/error)";
			// 
			// MenuToolsMainServerAction
			// 
			this.MenuToolsMainServerAction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.MenuToolsMainServerAction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripBtnReload,
            this.ToolStripBtnRestart,
            this.ToolStripBtnStartStop});
			this.MenuToolsMainServerAction.Image = global::Net.Bertware.Bukkitgui2.Properties.Resources.vanilla_logo;
			this.MenuToolsMainServerAction.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MenuToolsMainServerAction.Name = "MenuToolsMainServerAction";
			this.MenuToolsMainServerAction.Size = new System.Drawing.Size(29, 20);
			this.MenuToolsMainServerAction.Text = "Server Actions";
			this.MenuToolsMainServerAction.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
			this.MenuToolsMainServerAction.ToolTipText = "Quick server actions";
			// 
			// ToolStripBtnReload
			// 
			this.ToolStripBtnReload.Name = "ToolStripBtnReload";
			this.ToolStripBtnReload.Size = new System.Drawing.Size(110, 22);
			this.ToolStripBtnReload.Text = "Reload";
			// 
			// ToolStripBtnRestart
			// 
			this.ToolStripBtnRestart.Name = "ToolStripBtnRestart";
			this.ToolStripBtnRestart.Size = new System.Drawing.Size(110, 22);
			this.ToolStripBtnRestart.Text = "Restart";
			// 
			// ToolStripBtnStartStop
			// 
			this.ToolStripBtnStartStop.Name = "ToolStripBtnStartStop";
			this.ToolStripBtnStartStop.Size = new System.Drawing.Size(110, 22);
			this.ToolStripBtnStartStop.Text = "Start";
			this.ToolStripBtnStartStop.Click += new System.EventHandler(this.ToolStripBtnStartStop_Click);
			// 
			// LblToolsMainServerOutput
			// 
			this.LblToolsMainServerOutput.AutoSize = false;
			this.LblToolsMainServerOutput.Name = "LblToolsMainServerOutput";
			this.LblToolsMainServerOutput.Size = new System.Drawing.Size(550, 17);
			this.LblToolsMainServerOutput.Text = "Last output";
			this.LblToolsMainServerOutput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LblToolsMainServerOutput.ToolTipText = "Last server output";
			// 
			// ProgBarToolsMain
			// 
			this.ProgBarToolsMain.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.ProgBarToolsMain.Name = "ProgBarToolsMain";
			this.ProgBarToolsMain.Size = new System.Drawing.Size(100, 16);
			this.ProgBarToolsMain.ToolTipText = "Progress on current operation";
			// 
			// LblToolsMainGUIState
			// 
			this.LblToolsMainGUIState.AutoSize = false;
			this.LblToolsMainGUIState.Name = "LblToolsMainGUIState";
			this.LblToolsMainGUIState.Size = new System.Drawing.Size(26, 17);
			this.LblToolsMainGUIState.Text = "Idle";
			this.LblToolsMainGUIState.ToolTipText = "GUI state (idle/action)";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(884, 562);
			this.Controls.Add(this.StatusStripMain);
			this.Controls.Add(this.TabCtrlAddons);
			this.Name = "MainForm";
			this.Text = "Mainform";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.StatusStripMain.ResumeLayout(false);
			this.StatusStripMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TabCtrlAddons;
        private System.Windows.Forms.StatusStrip StatusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel LblToolsMainServerState;
        private System.Windows.Forms.ToolStripDropDownButton MenuToolsMainServerAction;
        private System.Windows.Forms.ToolStripMenuItem ToolStripBtnReload;
        private System.Windows.Forms.ToolStripMenuItem ToolStripBtnRestart;
        private System.Windows.Forms.ToolStripMenuItem ToolStripBtnStartStop;
        private System.Windows.Forms.ToolStripStatusLabel LblToolsMainServerOutput;
        private System.Windows.Forms.ToolStripStatusLabel LblToolsMainGUIState;
        private System.Windows.Forms.ToolStripProgressBar ProgBarToolsMain;
    }
}