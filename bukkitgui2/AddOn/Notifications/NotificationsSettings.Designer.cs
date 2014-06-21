namespace Net.Bertware.Bukkitgui2.AddOn.Notifications
{
	partial class NotificationSettings
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
			this.chkEnable = new System.Windows.Forms.CheckBox();
			this.chkAlways = new System.Windows.Forms.CheckBox();
			this.chkOnStatusChange = new System.Windows.Forms.CheckBox();
			this.chkOnPlayerJoin = new System.Windows.Forms.CheckBox();
			this.chkOnPlayerLeave = new System.Windows.Forms.CheckBox();
			this.chkOnPlayerBan = new System.Windows.Forms.CheckBox();
			this.chkOnPlayerKick = new System.Windows.Forms.CheckBox();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.gbBalloons = new System.Windows.Forms.GroupBox();
			this.gbBalloons.SuspendLayout();
			this.SuspendLayout();
			// 
			// chkEnable
			// 
			this.chkEnable.AutoSize = true;
			this.chkEnable.Location = new System.Drawing.Point(3, 3);
			this.chkEnable.Name = "chkEnable";
			this.chkEnable.Size = new System.Drawing.Size(102, 17);
			this.chkEnable.TabIndex = 0;
			this.chkEnable.Text = "Enable tray icon";
			this.chkEnable.UseVisualStyleBackColor = true;
			this.chkEnable.CheckedChanged += new System.EventHandler(this.chkEnable_CheckedChanged);
			// 
			// chkAlways
			// 
			this.chkAlways.AutoSize = true;
			this.chkAlways.Location = new System.Drawing.Point(6, 19);
			this.chkAlways.Name = "chkAlways";
			this.chkAlways.Size = new System.Drawing.Size(129, 17);
			this.chkAlways.TabIndex = 1;
			this.chkAlways.Text = "Always show balloons";
			this.toolTip.SetToolTip(this.chkAlways, "Show balloons, even if the GUI isn\'t minimized\r\n");
			this.chkAlways.UseVisualStyleBackColor = true;
			this.chkAlways.CheckedChanged += new System.EventHandler(this.chkAlways_CheckedChanged);
			// 
			// chkOnStatusChange
			// 
			this.chkOnStatusChange.AutoSize = true;
			this.chkOnStatusChange.Location = new System.Drawing.Point(6, 42);
			this.chkOnStatusChange.Name = "chkOnStatusChange";
			this.chkOnStatusChange.Size = new System.Drawing.Size(207, 17);
			this.chkOnStatusChange.TabIndex = 2;
			this.chkOnStatusChange.Text = "Show balloon on server status change";
			this.toolTip.SetToolTip(this.chkOnStatusChange, "Show a balloon when the server starts, is started, is stopping or stopped");
			this.chkOnStatusChange.UseVisualStyleBackColor = true;
			this.chkOnStatusChange.CheckedChanged += new System.EventHandler(this.chkOnStatusChange_CheckedChanged);
			// 
			// chkOnPlayerJoin
			// 
			this.chkOnPlayerJoin.AutoSize = true;
			this.chkOnPlayerJoin.Location = new System.Drawing.Point(6, 65);
			this.chkOnPlayerJoin.Name = "chkOnPlayerJoin";
			this.chkOnPlayerJoin.Size = new System.Drawing.Size(155, 17);
			this.chkOnPlayerJoin.TabIndex = 3;
			this.chkOnPlayerJoin.Text = "Show balloon on player join";
			this.chkOnPlayerJoin.UseVisualStyleBackColor = true;
			this.chkOnPlayerJoin.CheckedChanged += new System.EventHandler(this.chkOnPlayerJoin_CheckedChanged);
			// 
			// chkOnPlayerLeave
			// 
			this.chkOnPlayerLeave.AutoSize = true;
			this.chkOnPlayerLeave.Location = new System.Drawing.Point(6, 88);
			this.chkOnPlayerLeave.Name = "chkOnPlayerLeave";
			this.chkOnPlayerLeave.Size = new System.Drawing.Size(165, 17);
			this.chkOnPlayerLeave.TabIndex = 4;
			this.chkOnPlayerLeave.Text = "Show balloon on player leave";
			this.chkOnPlayerLeave.UseVisualStyleBackColor = true;
			this.chkOnPlayerLeave.CheckedChanged += new System.EventHandler(this.chkOnPlayerLeave_CheckedChanged);
			// 
			// chkOnPlayerBan
			// 
			this.chkOnPlayerBan.AutoSize = true;
			this.chkOnPlayerBan.Location = new System.Drawing.Point(6, 134);
			this.chkOnPlayerBan.Name = "chkOnPlayerBan";
			this.chkOnPlayerBan.Size = new System.Drawing.Size(157, 17);
			this.chkOnPlayerBan.TabIndex = 6;
			this.chkOnPlayerBan.Text = "Show balloon on player ban";
			this.chkOnPlayerBan.UseVisualStyleBackColor = true;
			this.chkOnPlayerBan.CheckedChanged += new System.EventHandler(this.chkOnPlayerBan_CheckedChanged);
			// 
			// chkOnPlayerKick
			// 
			this.chkOnPlayerKick.AutoSize = true;
			this.chkOnPlayerKick.Location = new System.Drawing.Point(6, 111);
			this.chkOnPlayerKick.Name = "chkOnPlayerKick";
			this.chkOnPlayerKick.Size = new System.Drawing.Size(159, 17);
			this.chkOnPlayerKick.TabIndex = 5;
			this.chkOnPlayerKick.Text = "Show balloon on player kick";
			this.chkOnPlayerKick.UseVisualStyleBackColor = true;
			this.chkOnPlayerKick.CheckedChanged += new System.EventHandler(this.chkOnPlayerKick_CheckedChanged);
			// 
			// gbBalloons
			// 
			this.gbBalloons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbBalloons.Controls.Add(this.chkAlways);
			this.gbBalloons.Controls.Add(this.chkOnPlayerBan);
			this.gbBalloons.Controls.Add(this.chkOnStatusChange);
			this.gbBalloons.Controls.Add(this.chkOnPlayerKick);
			this.gbBalloons.Controls.Add(this.chkOnPlayerJoin);
			this.gbBalloons.Controls.Add(this.chkOnPlayerLeave);
			this.gbBalloons.Location = new System.Drawing.Point(3, 26);
			this.gbBalloons.Name = "gbBalloons";
			this.gbBalloons.Size = new System.Drawing.Size(554, 166);
			this.gbBalloons.TabIndex = 7;
			this.gbBalloons.TabStop = false;
			this.gbBalloons.Text = "Balloon settings";
			// 
			// NotificationSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gbBalloons);
			this.Controls.Add(this.chkEnable);
			this.Name = "NotificationSettings";
			this.Size = new System.Drawing.Size(560, 490);
			this.gbBalloons.ResumeLayout(false);
			this.gbBalloons.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox chkEnable;
		private System.Windows.Forms.CheckBox chkAlways;
		private System.Windows.Forms.CheckBox chkOnStatusChange;
		private System.Windows.Forms.CheckBox chkOnPlayerJoin;
		private System.Windows.Forms.CheckBox chkOnPlayerLeave;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.CheckBox chkOnPlayerBan;
		private System.Windows.Forms.CheckBox chkOnPlayerKick;
		private System.Windows.Forms.GroupBox gbBalloons;
	}
}
