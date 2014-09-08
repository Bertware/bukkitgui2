using Net.Bertware.Bukkitgui2.Core;

namespace Net.Bertware.Bukkitgui2.AddOn.Settings
{
	partial class SettingsTab 
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
			this.TVSettings = new System.Windows.Forms.TreeView();
			this.gbSettings = new System.Windows.Forms.GroupBox();
			this.metroStyleExtender = new MetroFramework.Components.MetroStyleExtender(this.components);
			this.SuspendLayout();
			// 
			// TVSettings
			// 
			this.TVSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.metroStyleExtender.SetApplyMetroTheme(this.TVSettings, true);
			this.TVSettings.Location = new System.Drawing.Point(3, 3);
			this.TVSettings.Name = "TVSettings";
			this.TVSettings.Size = new System.Drawing.Size(221, 494);
			this.TVSettings.TabIndex = 0;
			this.TVSettings.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvSettingsAfterSelect);
			// 
			// gbSettings
			// 
			this.gbSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.metroStyleExtender.SetApplyMetroTheme(this.gbSettings, true);
			this.gbSettings.BackColor = System.Drawing.Color.Transparent;
			this.gbSettings.Location = new System.Drawing.Point(230, 3);
			this.gbSettings.Name = "gbSettings";
			this.gbSettings.Size = new System.Drawing.Size(567, 494);
			this.gbSettings.TabIndex = 1;
			this.gbSettings.TabStop = false;
			this.gbSettings.Text = Locale.Tr("Settings");
			// 
			// SettingsTab
			// 
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.gbSettings);
			this.Controls.Add(this.TVSettings);
			this.Name = "SettingsTab";
			this.Size = new System.Drawing.Size(800, 500);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView TVSettings;
		private System.Windows.Forms.GroupBox gbSettings;
		private MetroFramework.Components.MetroStyleExtender metroStyleExtender;
	}
}
