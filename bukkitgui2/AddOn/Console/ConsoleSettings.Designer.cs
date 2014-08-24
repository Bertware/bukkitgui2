using MetroFramework.Controls;
using Net.Bertware.Bukkitgui2.Controls;

namespace Net.Bertware.Bukkitgui2.AddOn.Console
{
	partial class ConsoleSettings
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
			this.chkTime = new Net.Bertware.Bukkitgui2.Controls.SettingsCheckbox();
			this.chkDate = new Net.Bertware.Bukkitgui2.Controls.SettingsCheckbox();
			this.CpInfo = new Net.Bertware.Bukkitgui2.Controls.ColorPicker.ColorPicker();
			this.gbColors = new System.Windows.Forms.GroupBox();
			this.label4 = new MetroFramework.Controls.MetroLabel();
			this.cpPlayer = new Net.Bertware.Bukkitgui2.Controls.ColorPicker.ColorPicker();
			this.label3 = new MetroFramework.Controls.MetroLabel();
			this.cpSevere = new Net.Bertware.Bukkitgui2.Controls.ColorPicker.ColorPicker();
			this.label2 = new MetroFramework.Controls.MetroLabel();
			this.cpWarn = new Net.Bertware.Bukkitgui2.Controls.ColorPicker.ColorPicker();
			this.label1 = new MetroFramework.Controls.MetroLabel();
			this.gbColors.SuspendLayout();
			this.SuspendLayout();
			// 
			// chkTime
			// 
			this.chkTime.AutoSize = true;
			this.chkTime.Location = new System.Drawing.Point(3, 3);
			this.chkTime.Name = "chkTime";
			this.chkTime.Size = new System.Drawing.Size(82, 15);
			this.chkTime.TabIndex = 0;
			this.chkTime.Text = "Show &Time";
			this.chkTime.UseSelectable = true;
			// 
			// chkDate
			// 
			this.chkDate.AutoSize = true;
			this.chkDate.Location = new System.Drawing.Point(3, 26);
			this.chkDate.Name = "chkDate";
			this.chkDate.Size = new System.Drawing.Size(79, 15);
			this.chkDate.TabIndex = 1;
			this.chkDate.Text = "Show &Date";
			this.chkDate.UseSelectable = true;
			// 
			// CpInfo
			// 
			this.CpInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.CpInfo.Color = System.Drawing.Color.Empty;
			this.CpInfo.Location = new System.Drawing.Point(127, 18);
			this.CpInfo.Name = "CpInfo";
			this.CpInfo.Size = new System.Drawing.Size(76, 20);
			this.CpInfo.TabIndex = 3;
			this.CpInfo.ColorChanged += new Net.Bertware.Bukkitgui2.Controls.ColorPicker.ColorPicker.ColorChangedEventHandler(this.CpInfo_ColorChanged);
			// 
			// gbColors
			// 
			this.gbColors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbColors.BackColor = System.Drawing.Color.Transparent;
			this.gbColors.Controls.Add(this.label4);
			this.gbColors.Controls.Add(this.cpPlayer);
			this.gbColors.Controls.Add(this.label3);
			this.gbColors.Controls.Add(this.cpSevere);
			this.gbColors.Controls.Add(this.label2);
			this.gbColors.Controls.Add(this.cpWarn);
			this.gbColors.Controls.Add(this.label1);
			this.gbColors.Controls.Add(this.CpInfo);
			this.gbColors.Location = new System.Drawing.Point(3, 49);
			this.gbColors.Name = "gbColors";
			this.gbColors.Size = new System.Drawing.Size(554, 155);
			this.gbColors.TabIndex = 4;
			this.gbColors.TabStop = false;
			this.gbColors.Text = "Colors";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 99);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(105, 19);
			this.label4.TabIndex = 10;
			this.label4.Text = "player messages";
			// 
			// cpPlayer
			// 
			this.cpPlayer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.cpPlayer.Color = System.Drawing.Color.Empty;
			this.cpPlayer.Location = new System.Drawing.Point(127, 99);
			this.cpPlayer.Name = "cpPlayer";
			this.cpPlayer.Size = new System.Drawing.Size(76, 20);
			this.cpPlayer.TabIndex = 9;
			this.cpPlayer.ColorChanged += new Net.Bertware.Bukkitgui2.Controls.ColorPicker.ColorPicker.ColorChangedEventHandler(this.cpPlayer_ColorChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 73);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(106, 19);
			this.label3.TabIndex = 8;
			this.label3.Text = "severe messages";
			// 
			// cpSevere
			// 
			this.cpSevere.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.cpSevere.Color = System.Drawing.Color.Empty;
			this.cpSevere.Location = new System.Drawing.Point(127, 72);
			this.cpSevere.Name = "cpSevere";
			this.cpSevere.Size = new System.Drawing.Size(76, 20);
			this.cpSevere.TabIndex = 7;
			this.cpSevere.ColorChanged += new Net.Bertware.Bukkitgui2.Controls.ColorPicker.ColorPicker.ColorChangedEventHandler(this.cpSevere_ColorChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 47);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(115, 19);
			this.label2.TabIndex = 6;
			this.label2.Text = "warning messages";
			// 
			// cpWarn
			// 
			this.cpWarn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.cpWarn.Color = System.Drawing.Color.Empty;
			this.cpWarn.Location = new System.Drawing.Point(127, 47);
			this.cpWarn.Name = "cpWarn";
			this.cpWarn.Size = new System.Drawing.Size(76, 20);
			this.cpWarn.TabIndex = 5;
			this.cpWarn.ColorChanged += new Net.Bertware.Bukkitgui2.Controls.ColorPicker.ColorPicker.ColorChangedEventHandler(this.cpWarn_ColorChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(91, 19);
			this.label1.TabIndex = 4;
			this.label1.Text = "info messages";
			// 
			// ConsoleSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.gbColors);
			this.Controls.Add(this.chkDate);
			this.Controls.Add(this.chkTime);
			this.Name = "ConsoleSettings";
			this.Size = new System.Drawing.Size(560, 490);
			this.gbColors.ResumeLayout(false);
			this.gbColors.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private SettingsCheckbox chkTime;
		private SettingsCheckbox chkDate;
		private Controls.ColorPicker.ColorPicker CpInfo;
		private System.Windows.Forms.GroupBox gbColors;
		private MetroLabel label2;
		private Controls.ColorPicker.ColorPicker cpWarn;
		private MetroLabel label1;
		private MetroLabel label4;
		private Controls.ColorPicker.ColorPicker cpPlayer;
		private MetroLabel label3;
		private Controls.ColorPicker.ColorPicker cpSevere;

	}
}
