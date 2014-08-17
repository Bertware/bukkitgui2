using MetroFramework.Controls;

namespace Net.Bertware.Bukkitgui2.AddOn.Plugins
{
	partial class PluginsTab
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
			this.tabctrlPlugins = new MetroFramework.Controls.MetroTabControl();
			this.tabInstalled = new System.Windows.Forms.TabPage();
			this.installedCtrl = new Net.Bertware.Bukkitgui2.AddOn.Plugins.InstalledPlugins.InstalledPluginsControl();
			this.tabBukget = new System.Windows.Forms.TabPage();
			this.bukgetCtrl = new Net.Bertware.Bukkitgui2.AddOn.Plugins.Bukget.BukgetPluginsControl();
			this.tabctrlPlugins.SuspendLayout();
			this.tabInstalled.SuspendLayout();
			this.tabBukget.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabctrlPlugins
			// 
			this.tabctrlPlugins.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabctrlPlugins.Controls.Add(this.tabInstalled);
			this.tabctrlPlugins.Controls.Add(this.tabBukget);
			this.tabctrlPlugins.Location = new System.Drawing.Point(0, 0);
			this.tabctrlPlugins.Name = "tabctrlPlugins";
			this.tabctrlPlugins.SelectedIndex = 0;
			this.tabctrlPlugins.Size = new System.Drawing.Size(800, 500);
			this.tabctrlPlugins.TabIndex = 0;
			this.tabctrlPlugins.UseSelectable = true;
			// 
			// tabInstalled
			// 
			this.tabInstalled.Controls.Add(this.installedCtrl);
			this.tabInstalled.Location = new System.Drawing.Point(4, 38);
			this.tabInstalled.Name = "tabInstalled";
			this.tabInstalled.Padding = new System.Windows.Forms.Padding(3);
			this.tabInstalled.Size = new System.Drawing.Size(792, 458);
			this.tabInstalled.TabIndex = 0;
			this.tabInstalled.Text = "Installed plugins";
			this.tabInstalled.UseVisualStyleBackColor = true;
			// 
			// installedCtrl
			// 
			this.installedCtrl.BackColor = System.Drawing.Color.White;
			this.installedCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.installedCtrl.Location = new System.Drawing.Point(3, 3);
			this.installedCtrl.Name = "installedCtrl";
			this.installedCtrl.Size = new System.Drawing.Size(786, 452);
			this.installedCtrl.TabIndex = 0;
			// 
			// tabBukget
			// 
			this.tabBukget.Controls.Add(this.bukgetCtrl);
			this.tabBukget.Location = new System.Drawing.Point(4, 38);
			this.tabBukget.Name = "tabBukget";
			this.tabBukget.Padding = new System.Windows.Forms.Padding(3);
			this.tabBukget.Size = new System.Drawing.Size(792, 458);
			this.tabBukget.TabIndex = 1;
			this.tabBukget.Text = "Available plugins";
			this.tabBukget.UseVisualStyleBackColor = true;
			// 
			// bukgetCtrl
			// 
			this.bukgetCtrl.BackColor = System.Drawing.Color.White;
			this.bukgetCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.bukgetCtrl.Location = new System.Drawing.Point(3, 3);
			this.bukgetCtrl.Name = "bukgetCtrl";
			this.bukgetCtrl.Size = new System.Drawing.Size(786, 452);
			this.bukgetCtrl.TabIndex = 0;
			// 
			// PluginsTab
			// 
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.tabctrlPlugins);
			this.Name = "PluginsTab";
			this.Size = new System.Drawing.Size(800, 500);
			this.tabctrlPlugins.ResumeLayout(false);
			this.tabInstalled.ResumeLayout(false);
			this.tabBukget.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private MetroTabControl tabctrlPlugins;
		private System.Windows.Forms.TabPage tabInstalled;
		private InstalledPlugins.InstalledPluginsControl installedCtrl;
		private System.Windows.Forms.TabPage tabBukget;
		private Bukget.BukgetPluginsControl bukgetCtrl;
	}
}
