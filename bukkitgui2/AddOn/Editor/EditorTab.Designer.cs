namespace Net.Bertware.Bukkitgui2.AddOn.Editor
{
    using System.Windows.Forms;

    partial class EditorTab: UserControl
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
			this.TabCtrlSettings = new MetroFramework.Controls.MetroTabControl();
			this.tabSettings = new System.Windows.Forms.TabPage();
			this.serverSettingsControl = new Net.Bertware.Bukkitgui2.AddOn.Editor.ServerSettingsControl();
			this.tabWhitelist = new System.Windows.Forms.TabPage();
			this.tabEditor = new System.Windows.Forms.TabPage();
			this.tabBanlist = new System.Windows.Forms.TabPage();
			this.tabIpbanList = new System.Windows.Forms.TabPage();
			this.tabOplist = new System.Windows.Forms.TabPage();
			this.TabCtrlSettings.SuspendLayout();
			this.tabSettings.SuspendLayout();
			this.SuspendLayout();
			// 
			// TabCtrlSettings
			// 
			this.TabCtrlSettings.Controls.Add(this.tabSettings);
			this.TabCtrlSettings.Controls.Add(this.tabWhitelist);
			this.TabCtrlSettings.Controls.Add(this.tabOplist);
			this.TabCtrlSettings.Controls.Add(this.tabBanlist);
			this.TabCtrlSettings.Controls.Add(this.tabIpbanList);
			this.TabCtrlSettings.Controls.Add(this.tabEditor);
			this.TabCtrlSettings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TabCtrlSettings.Location = new System.Drawing.Point(0, 0);
			this.TabCtrlSettings.Name = "TabCtrlSettings";
			this.TabCtrlSettings.SelectedIndex = 0;
			this.TabCtrlSettings.Size = new System.Drawing.Size(800, 500);
			this.TabCtrlSettings.TabIndex = 2;
			this.TabCtrlSettings.UseSelectable = true;
			// 
			// tabSettings
			// 
			this.tabSettings.Controls.Add(this.serverSettingsControl);
			this.tabSettings.Location = new System.Drawing.Point(4, 38);
			this.tabSettings.Name = "tabSettings";
			this.tabSettings.Size = new System.Drawing.Size(792, 458);
			this.tabSettings.TabIndex = 0;
			this.tabSettings.Text = "Server Settings";
			// 
			// serverSettingsControl
			// 
			this.serverSettingsControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.serverSettingsControl.Location = new System.Drawing.Point(0, 0);
			this.serverSettingsControl.Name = "serverSettingsControl";
			this.serverSettingsControl.Size = new System.Drawing.Size(792, 458);
			this.serverSettingsControl.TabIndex = 4;
			this.serverSettingsControl.UseSelectable = true;
			// 
			// tabWhitelist
			// 
			this.tabWhitelist.Location = new System.Drawing.Point(4, 38);
			this.tabWhitelist.Name = "tabWhitelist";
			this.tabWhitelist.Size = new System.Drawing.Size(792, 458);
			this.tabWhitelist.TabIndex = 2;
			this.tabWhitelist.Text = "Whitelist";
			// 
			// tabEditor
			// 
			this.tabEditor.Location = new System.Drawing.Point(4, 38);
			this.tabEditor.Name = "tabEditor";
			this.tabEditor.Size = new System.Drawing.Size(792, 458);
			this.tabEditor.TabIndex = 1;
			this.tabEditor.Text = "Config Editor";
			// 
			// tabBanlist
			// 
			this.tabBanlist.Location = new System.Drawing.Point(4, 38);
			this.tabBanlist.Name = "tabBanlist";
			this.tabBanlist.Size = new System.Drawing.Size(792, 458);
			this.tabBanlist.TabIndex = 3;
			this.tabBanlist.Text = "Banlist";
			// 
			// tabIpbanList
			// 
			this.tabIpbanList.Location = new System.Drawing.Point(4, 38);
			this.tabIpbanList.Name = "tabIpbanList";
			this.tabIpbanList.Size = new System.Drawing.Size(792, 458);
			this.tabIpbanList.TabIndex = 4;
			this.tabIpbanList.Text = "Ipbanlist";
			// 
			// tabOplist
			// 
			this.tabOplist.Location = new System.Drawing.Point(4, 38);
			this.tabOplist.Name = "tabOplist";
			this.tabOplist.Size = new System.Drawing.Size(792, 458);
			this.tabOplist.TabIndex = 5;
			this.tabOplist.Text = "Operators";
			// 
			// EditorTab
			// 
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.TabCtrlSettings);
			this.Name = "EditorTab";
			this.Size = new System.Drawing.Size(800, 500);
			this.TabCtrlSettings.ResumeLayout(false);
			this.tabSettings.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private MetroFramework.Controls.MetroTabControl TabCtrlSettings;
		private TabPage tabSettings;
		private TabPage tabEditor;
		private TabPage tabWhitelist;
		private ServerSettingsControl serverSettingsControl;
		private TabPage tabBanlist;
		private TabPage tabIpbanList;
		private TabPage tabOplist;

	}
}
