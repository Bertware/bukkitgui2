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
			this.tabEditor = new System.Windows.Forms.TabPage();
			this.tabSettings = new System.Windows.Forms.TabPage();
			this.tabPlayerLists = new System.Windows.Forms.TabPage();
			this.serverSettingsControl1 = new Net.Bertware.Bukkitgui2.AddOn.Editor.ServerSettingsControl();
			this.TabCtrlSettings.SuspendLayout();
			this.tabSettings.SuspendLayout();
			this.SuspendLayout();
			// 
			// TabCtrlSettings
			// 
			this.TabCtrlSettings.Controls.Add(this.tabSettings);
			this.TabCtrlSettings.Controls.Add(this.tabPlayerLists);
			this.TabCtrlSettings.Controls.Add(this.tabEditor);
			this.TabCtrlSettings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TabCtrlSettings.Location = new System.Drawing.Point(0, 0);
			this.TabCtrlSettings.Name = "TabCtrlSettings";
			this.TabCtrlSettings.SelectedIndex = 0;
			this.TabCtrlSettings.Size = new System.Drawing.Size(800, 500);
			this.TabCtrlSettings.TabIndex = 2;
			this.TabCtrlSettings.UseSelectable = true;
			// 
			// tabEditor
			// 
			this.tabEditor.Location = new System.Drawing.Point(4, 38);
			this.tabEditor.Name = "tabEditor";
			this.tabEditor.Size = new System.Drawing.Size(792, 458);
			this.tabEditor.TabIndex = 1;
			this.tabEditor.Text = "Config Editor";
			// 
			// tabSettings
			// 
			this.tabSettings.Controls.Add(this.serverSettingsControl1);
			this.tabSettings.Location = new System.Drawing.Point(4, 38);
			this.tabSettings.Name = "tabSettings";
			this.tabSettings.Size = new System.Drawing.Size(792, 458);
			this.tabSettings.TabIndex = 0;
			this.tabSettings.Text = "Server Settings";
			// 
			// tabPlayerLists
			// 
			this.tabPlayerLists.Location = new System.Drawing.Point(4, 38);
			this.tabPlayerLists.Name = "tabPlayerLists";
			this.tabPlayerLists.Size = new System.Drawing.Size(792, 458);
			this.tabPlayerLists.TabIndex = 2;
			this.tabPlayerLists.Text = "White/black/op list";
			// 
			// serverSettingsControl1
			// 
			this.serverSettingsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.serverSettingsControl1.Location = new System.Drawing.Point(0, 0);
			this.serverSettingsControl1.Name = "serverSettingsControl1";
			this.serverSettingsControl1.Size = new System.Drawing.Size(792, 458);
			this.serverSettingsControl1.TabIndex = 4;
			this.serverSettingsControl1.UseSelectable = true;
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
		private TabPage tabPlayerLists;
		private ServerSettingsControl serverSettingsControl1;

	}
}
