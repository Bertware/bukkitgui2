using MetroFramework.Controls;
using Net.Bertware.Bukkitgui2.Controls;

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
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.gbBalloons = new System.Windows.Forms.GroupBox();
			this.gbSound = new System.Windows.Forms.GroupBox();
			this.label1 = new MetroFramework.Controls.MetroLabel();
			this.btnReload = new MetroFramework.Controls.MetroButton();
			this.chkSoundOnError = new Net.Bertware.Bukkitgui2.Controls.SettingsCheckbox();
			this.chkSoundOnWarning = new Net.Bertware.Bukkitgui2.Controls.SettingsCheckbox();
			this.chkSoundOnLeave = new Net.Bertware.Bukkitgui2.Controls.SettingsCheckbox();
			this.chkSoundOnJoin = new Net.Bertware.Bukkitgui2.Controls.SettingsCheckbox();
			this.chkAlways = new Net.Bertware.Bukkitgui2.Controls.SettingsCheckbox();
			this.chkOnPlayerBan = new Net.Bertware.Bukkitgui2.Controls.SettingsCheckbox();
			this.chkOnStatusChange = new Net.Bertware.Bukkitgui2.Controls.SettingsCheckbox();
			this.chkOnPlayerKick = new Net.Bertware.Bukkitgui2.Controls.SettingsCheckbox();
			this.chkOnPlayerJoin = new Net.Bertware.Bukkitgui2.Controls.SettingsCheckbox();
			this.chkOnPlayerLeave = new Net.Bertware.Bukkitgui2.Controls.SettingsCheckbox();
			this.chkEnable = new Net.Bertware.Bukkitgui2.Controls.SettingsCheckbox();
			this.gbBalloons.SuspendLayout();
			this.gbSound.SuspendLayout();
			this.SuspendLayout();
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
			// gbSound
			// 
			this.gbSound.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbSound.Controls.Add(this.chkSoundOnError);
			this.gbSound.Controls.Add(this.chkSoundOnWarning);
			this.gbSound.Controls.Add(this.chkSoundOnLeave);
			this.gbSound.Controls.Add(this.chkSoundOnJoin);
			this.gbSound.Location = new System.Drawing.Point(3, 198);
			this.gbSound.Name = "gbSound";
			this.gbSound.Size = new System.Drawing.Size(554, 173);
			this.gbSound.TabIndex = 8;
			this.gbSound.TabStop = false;
			this.gbSound.Text = "Sounds";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(253, 1);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(304, 19);
			this.label1.TabIndex = 9;
			this.label1.Text = "All settings will take effect after the next GUI restart";
			// 
			// btnReload
			// 
			this.btnReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnReload.Location = new System.Drawing.Point(482, 464);
			this.btnReload.Name = "btnReload";
			this.btnReload.Size = new System.Drawing.Size(75, 23);
			this.btnReload.TabIndex = 10;
			this.btnReload.Text = "Apply";
			this.btnReload.UseSelectable = true;
			this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
			// 
			// chkSoundOnError
			// 
			this.chkSoundOnError.AutoSize = true;
			this.chkSoundOnError.Location = new System.Drawing.Point(6, 82);
			this.chkSoundOnError.Name = "chkSoundOnError";
			this.chkSoundOnError.Size = new System.Drawing.Size(212, 15);
			this.chkSoundOnError.TabIndex = 10;
			this.chkSoundOnError.Text = "Play sound when an error comes up";
			this.chkSoundOnError.UseSelectable = true;
			// 
			// chkSoundOnWarning
			// 
			this.chkSoundOnWarning.AutoSize = true;
			this.chkSoundOnWarning.Location = new System.Drawing.Point(6, 61);
			this.chkSoundOnWarning.Name = "chkSoundOnWarning";
			this.chkSoundOnWarning.Size = new System.Drawing.Size(223, 15);
			this.chkSoundOnWarning.TabIndex = 9;
			this.chkSoundOnWarning.Text = "Play sound when a warning comes up";
			this.chkSoundOnWarning.UseSelectable = true;
			// 
			// chkSoundOnLeave
			// 
			this.chkSoundOnLeave.AutoSize = true;
			this.chkSoundOnLeave.Location = new System.Drawing.Point(6, 40);
			this.chkSoundOnLeave.Name = "chkSoundOnLeave";
			this.chkSoundOnLeave.Size = new System.Drawing.Size(156, 15);
			this.chkSoundOnLeave.TabIndex = 8;
			this.chkSoundOnLeave.Text = "Play sound on player join";
			this.chkSoundOnLeave.UseSelectable = true;
			// 
			// chkSoundOnJoin
			// 
			this.chkSoundOnJoin.AutoSize = true;
			this.chkSoundOnJoin.Location = new System.Drawing.Point(6, 19);
			this.chkSoundOnJoin.Name = "chkSoundOnJoin";
			this.chkSoundOnJoin.Size = new System.Drawing.Size(157, 15);
			this.chkSoundOnJoin.TabIndex = 7;
			this.chkSoundOnJoin.Text = "Play sound on player kick";
			this.chkSoundOnJoin.UseSelectable = true;
			// 
			// chkAlways
			// 
			this.chkAlways.AutoSize = true;
			this.chkAlways.Location = new System.Drawing.Point(6, 19);
			this.chkAlways.Name = "chkAlways";
			this.chkAlways.Size = new System.Drawing.Size(139, 15);
			this.chkAlways.TabIndex = 1;
			this.chkAlways.Text = "Always show balloons";
			this.toolTip.SetToolTip(this.chkAlways, "Show balloons, even if the GUI isn\'t minimized\r\n");
			this.chkAlways.UseSelectable = true;
			// 
			// chkOnPlayerBan
			// 
			this.chkOnPlayerBan.AutoSize = true;
			this.chkOnPlayerBan.Location = new System.Drawing.Point(6, 134);
			this.chkOnPlayerBan.Name = "chkOnPlayerBan";
			this.chkOnPlayerBan.Size = new System.Drawing.Size(170, 15);
			this.chkOnPlayerBan.TabIndex = 6;
			this.chkOnPlayerBan.Text = "Show balloon on player ban";
			this.chkOnPlayerBan.UseSelectable = true;
			// 
			// chkOnStatusChange
			// 
			this.chkOnStatusChange.AutoSize = true;
			this.chkOnStatusChange.Location = new System.Drawing.Point(6, 42);
			this.chkOnStatusChange.Name = "chkOnStatusChange";
			this.chkOnStatusChange.Size = new System.Drawing.Size(222, 15);
			this.chkOnStatusChange.TabIndex = 2;
			this.chkOnStatusChange.Text = "Show balloon on server status change";
			this.toolTip.SetToolTip(this.chkOnStatusChange, "Show a balloon when the server starts, is started, is stopping or stopped");
			this.chkOnStatusChange.UseSelectable = true;
			// 
			// chkOnPlayerKick
			// 
			this.chkOnPlayerKick.AutoSize = true;
			this.chkOnPlayerKick.Location = new System.Drawing.Point(6, 111);
			this.chkOnPlayerKick.Name = "chkOnPlayerKick";
			this.chkOnPlayerKick.Size = new System.Drawing.Size(171, 15);
			this.chkOnPlayerKick.TabIndex = 5;
			this.chkOnPlayerKick.Text = "Show balloon on player kick";
			this.chkOnPlayerKick.UseSelectable = true;
			// 
			// chkOnPlayerJoin
			// 
			this.chkOnPlayerJoin.AutoSize = true;
			this.chkOnPlayerJoin.Location = new System.Drawing.Point(6, 65);
			this.chkOnPlayerJoin.Name = "chkOnPlayerJoin";
			this.chkOnPlayerJoin.Size = new System.Drawing.Size(170, 15);
			this.chkOnPlayerJoin.TabIndex = 3;
			this.chkOnPlayerJoin.Text = "Show balloon on player join";
			this.chkOnPlayerJoin.UseSelectable = true;
			// 
			// chkOnPlayerLeave
			// 
			this.chkOnPlayerLeave.AutoSize = true;
			this.chkOnPlayerLeave.Location = new System.Drawing.Point(6, 88);
			this.chkOnPlayerLeave.Name = "chkOnPlayerLeave";
			this.chkOnPlayerLeave.Size = new System.Drawing.Size(177, 15);
			this.chkOnPlayerLeave.TabIndex = 4;
			this.chkOnPlayerLeave.Text = "Show balloon on player leave";
			this.chkOnPlayerLeave.UseSelectable = true;
			// 
			// chkEnable
			// 
			this.chkEnable.AutoSize = true;
			this.chkEnable.Location = new System.Drawing.Point(3, 5);
			this.chkEnable.Name = "chkEnable";
			this.chkEnable.Size = new System.Drawing.Size(107, 15);
			this.chkEnable.TabIndex = 0;
			this.chkEnable.Text = "Enable tray icon";
			this.chkEnable.UseSelectable = true;
			this.chkEnable.CheckedChanged += new System.EventHandler(this.chkEnable_CheckedChanged);
			// 
			// NotificationSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.btnReload);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.gbSound);
			this.Controls.Add(this.gbBalloons);
			this.Controls.Add(this.chkEnable);
			this.Name = "NotificationSettings";
			this.Size = new System.Drawing.Size(560, 490);
			this.gbBalloons.ResumeLayout(false);
			this.gbBalloons.PerformLayout();
			this.gbSound.ResumeLayout(false);
			this.gbSound.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private SettingsCheckbox chkEnable;
		private SettingsCheckbox chkAlways;
		private SettingsCheckbox chkOnStatusChange;
		private SettingsCheckbox chkOnPlayerJoin;
		private SettingsCheckbox chkOnPlayerLeave;
		private System.Windows.Forms.ToolTip toolTip;
		private SettingsCheckbox chkOnPlayerBan;
		private SettingsCheckbox chkOnPlayerKick;
		private System.Windows.Forms.GroupBox gbBalloons;
		private System.Windows.Forms.GroupBox gbSound;
		private MetroLabel label1;
		private SettingsCheckbox chkSoundOnError;
		private SettingsCheckbox chkSoundOnWarning;
		private SettingsCheckbox chkSoundOnLeave;
		private SettingsCheckbox chkSoundOnJoin;
		private MetroButton btnReload;
	}
}
