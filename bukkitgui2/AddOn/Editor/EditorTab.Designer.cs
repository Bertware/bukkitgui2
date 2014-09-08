using MetroFramework.Controls;
using Net.Bertware.Bukkitgui2.Core;

namespace Net.Bertware.Bukkitgui2.AddOn.Editor
{
    using System.Windows.Forms;

	partial class EditorTab : MetroUserControl
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
			this.whitelistControl = new Net.Bertware.Bukkitgui2.AddOn.Editor.WhitelistControl();
			this.tabOplist = new System.Windows.Forms.TabPage();
			this.opListControl = new Net.Bertware.Bukkitgui2.AddOn.Editor.OpListControl();
			this.tabBanlist = new System.Windows.Forms.TabPage();
			this.banListControl = new Net.Bertware.Bukkitgui2.AddOn.Editor.BanListControl();
			this.tabIpbanList = new System.Windows.Forms.TabPage();
			this.ipBanListControl = new Net.Bertware.Bukkitgui2.AddOn.Editor.IpBanListControl();
			this.tabEditor = new System.Windows.Forms.TabPage();
			this.TabCtrlSettings.SuspendLayout();
			this.tabSettings.SuspendLayout();
			this.tabWhitelist.SuspendLayout();
			this.tabOplist.SuspendLayout();
			this.tabBanlist.SuspendLayout();
			this.tabIpbanList.SuspendLayout();
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
			this.tabSettings.Text = Locale.Tr("Server Settings");
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
			this.tabWhitelist.Controls.Add(this.whitelistControl);
			this.tabWhitelist.Location = new System.Drawing.Point(4, 38);
			this.tabWhitelist.Name = "tabWhitelist";
			this.tabWhitelist.Size = new System.Drawing.Size(792, 458);
			this.tabWhitelist.TabIndex = 2;
			this.tabWhitelist.Text = Locale.Tr("Whitelist");
			// 
			// whitelistControl
			// 
			this.whitelistControl.BackColor = System.Drawing.Color.White;
			this.whitelistControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.whitelistControl.Location = new System.Drawing.Point(0, 0);
			this.whitelistControl.Name = "whitelistControl";
			this.whitelistControl.ParentAddon = null;
			this.whitelistControl.Size = new System.Drawing.Size(792, 458);
			this.whitelistControl.TabIndex = 1;
			// 
			// tabOplist
			// 
			this.tabOplist.Controls.Add(this.opListControl);
			this.tabOplist.Location = new System.Drawing.Point(4, 35);
			this.tabOplist.Name = "tabOplist";
			this.tabOplist.Size = new System.Drawing.Size(792, 461);
			this.tabOplist.TabIndex = 5;
			this.tabOplist.Text = Locale.Tr("Operators");
			// 
			// opListControl
			// 
			this.opListControl.BackColor = System.Drawing.Color.White;
			this.opListControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.opListControl.Location = new System.Drawing.Point(0, 0);
			this.opListControl.Name = "opListControl";
			this.opListControl.ParentAddon = null;
			this.opListControl.Size = new System.Drawing.Size(792, 461);
			this.opListControl.TabIndex = 1;
			// 
			// tabBanlist
			// 
			this.tabBanlist.Controls.Add(this.banListControl);
			this.tabBanlist.Location = new System.Drawing.Point(4, 35);
			this.tabBanlist.Name = "tabBanlist";
			this.tabBanlist.Size = new System.Drawing.Size(792, 461);
			this.tabBanlist.TabIndex = 3;
			this.tabBanlist.Text = Locale.Tr("Banlist");
			// 
			// banListControl
			// 
			this.banListControl.BackColor = System.Drawing.Color.White;
			this.banListControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.banListControl.Location = new System.Drawing.Point(0, 0);
			this.banListControl.Name = "banListControl";
			this.banListControl.ParentAddon = null;
			this.banListControl.Size = new System.Drawing.Size(792, 461);
			this.banListControl.TabIndex = 1;
			this.banListControl.UseSelectable = true;
			// 
			// tabIpbanList
			// 
			this.tabIpbanList.Controls.Add(this.ipBanListControl);
			this.tabIpbanList.Location = new System.Drawing.Point(4, 35);
			this.tabIpbanList.Name = "tabIpbanList";
			this.tabIpbanList.Size = new System.Drawing.Size(792, 461);
			this.tabIpbanList.TabIndex = 4;
			this.tabIpbanList.Text = Locale.Tr("Ipbanlist");
			// 
			// ipBanListControl
			// 
			this.ipBanListControl.BackColor = System.Drawing.Color.White;
			this.ipBanListControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ipBanListControl.Location = new System.Drawing.Point(0, 0);
			this.ipBanListControl.Name = "ipBanListControl";
			this.ipBanListControl.ParentAddon = null;
			this.ipBanListControl.Size = new System.Drawing.Size(792, 461);
			this.ipBanListControl.TabIndex = 1;
			this.ipBanListControl.UseSelectable = true;
			// 
			// tabEditor
			// 
			this.tabEditor.Location = new System.Drawing.Point(4, 35);
			this.tabEditor.Name = "tabEditor";
			this.tabEditor.Size = new System.Drawing.Size(792, 461);
			this.tabEditor.TabIndex = 1;
			this.tabEditor.Text = Locale.Tr("Config Editor");
			// 
			// EditorTab
			// 
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.TabCtrlSettings);
			this.Name = "EditorTab";
			this.Size = new System.Drawing.Size(800, 500);
			this.TabCtrlSettings.ResumeLayout(false);
			this.tabSettings.ResumeLayout(false);
			this.tabWhitelist.ResumeLayout(false);
			this.tabOplist.ResumeLayout(false);
			this.tabBanlist.ResumeLayout(false);
			this.tabIpbanList.ResumeLayout(false);
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
		private WhitelistControl whitelistControl;
		private BanListControl banListControl;
		private OpListControl opListControl;
		private IpBanListControl ipBanListControl;

	}
}
