using System.Windows.Forms;
using MetroFramework.Controls;

namespace Net.Bertware.Bukkitgui2.AddOn.Forwarder
{
	partial class ForwarderTab
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
			this.CBProtocol = new MetroFramework.Controls.MetroComboBox();
			this.lblIp = new MetroFramework.Controls.MetroLabel();
			this.lblDescription = new MetroFramework.Controls.MetroLabel();
			this.lblPort = new MetroFramework.Controls.MetroLabel();
			this.BtnRefresh = new MetroFramework.Controls.MetroButton();
			this.BtnAdd = new MetroFramework.Controls.MetroButton();
			this.NumPort = new System.Windows.Forms.NumericUpDown();
			this.TxtIp = new MetroFramework.Controls.MetroTextBox();
			this.TxtName = new MetroFramework.Controls.MetroTextBox();
			this.slvPortMappings = new Net.Bertware.Bukkitgui2.Controls.SortableListView.SortableListView();
			this.ColName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColProtocol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			((System.ComponentModel.ISupportInitialize)(this.NumPort)).BeginInit();
			this.SuspendLayout();
			// 
			// CBProtocol
			// 
			this.CBProtocol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CBProtocol.FormattingEnabled = true;
			this.CBProtocol.ItemHeight = 23;
			this.CBProtocol.Items.AddRange(new object[] {
            "tcp",
            "udp"});
			this.CBProtocol.Location = new System.Drawing.Point(517, 468);
			this.CBProtocol.Name = "CBProtocol";
			this.CBProtocol.Size = new System.Drawing.Size(49, 29);
			this.CBProtocol.TabIndex = 22;
			this.CBProtocol.UseSelectable = true;
			// 
			// lblIp
			// 
			this.lblIp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblIp.AutoSize = true;
			this.lblIp.Location = new System.Drawing.Point(233, 478);
			this.lblIp.Name = "lblIp";
			this.lblIp.Size = new System.Drawing.Size(23, 19);
			this.lblIp.TabIndex = 21;
			this.lblIp.Text = "IP:";
			// 
			// lblDescription
			// 
			this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblDescription.AutoSize = true;
			this.lblDescription.Location = new System.Drawing.Point(3, 478);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(77, 19);
			this.lblDescription.TabIndex = 20;
			this.lblDescription.Text = "Description:";
			// 
			// lblPort
			// 
			this.lblPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPort.AutoSize = true;
			this.lblPort.Location = new System.Drawing.Point(392, 478);
			this.lblPort.Name = "lblPort";
			this.lblPort.Size = new System.Drawing.Size(37, 19);
			this.lblPort.TabIndex = 19;
			this.lblPort.Text = "Port:";
			// 
			// BtnRefresh
			// 
			this.BtnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnRefresh.Location = new System.Drawing.Point(722, 474);
			this.BtnRefresh.Name = "BtnRefresh";
			this.BtnRefresh.Size = new System.Drawing.Size(75, 23);
			this.BtnRefresh.TabIndex = 17;
			this.BtnRefresh.Text = "Refresh";
			this.BtnRefresh.UseSelectable = true;
			// 
			// BtnAdd
			// 
			this.BtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnAdd.Location = new System.Drawing.Point(641, 474);
			this.BtnAdd.Name = "BtnAdd";
			this.BtnAdd.Size = new System.Drawing.Size(75, 23);
			this.BtnAdd.TabIndex = 16;
			this.BtnAdd.Text = "Add";
			this.BtnAdd.UseSelectable = true;
			this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
			// 
			// NumPort
			// 
			this.NumPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.NumPort.Location = new System.Drawing.Point(435, 477);
			this.NumPort.Maximum = new decimal(new int[] {
            65532,
            0,
            0,
            0});
			this.NumPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.NumPort.Name = "NumPort";
			this.NumPort.Size = new System.Drawing.Size(76, 20);
			this.NumPort.TabIndex = 15;
			this.NumPort.Value = new decimal(new int[] {
            25565,
            0,
            0,
            0});
			// 
			// TxtIp
			// 
			this.TxtIp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.TxtIp.Lines = new string[0];
			this.TxtIp.Location = new System.Drawing.Point(262, 477);
			this.TxtIp.MaxLength = 32767;
			this.TxtIp.Name = "TxtIp";
			this.TxtIp.PasswordChar = '\0';
			this.TxtIp.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.TxtIp.SelectedText = "";
			this.TxtIp.Size = new System.Drawing.Size(124, 20);
			this.TxtIp.TabIndex = 14;
			this.TxtIp.UseSelectable = true;
			// 
			// TxtName
			// 
			this.TxtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TxtName.Lines = new string[] {
        "Minecraft-server"};
			this.TxtName.Location = new System.Drawing.Point(86, 477);
			this.TxtName.MaxLength = 32767;
			this.TxtName.Name = "TxtName";
			this.TxtName.PasswordChar = '\0';
			this.TxtName.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.TxtName.SelectedText = "";
			this.TxtName.Size = new System.Drawing.Size(141, 20);
			this.TxtName.TabIndex = 13;
			this.TxtName.Text = "Minecraft-server";
			this.TxtName.UseSelectable = true;
			// 
			// slvPortMappings
			// 
			this.slvPortMappings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.slvPortMappings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColName,
            this.ColIP,
            this.ColPort,
            this.ColProtocol});
			this.slvPortMappings.FullRowSelect = true;
			this.slvPortMappings.Location = new System.Drawing.Point(3, 3);
			this.slvPortMappings.Name = "slvPortMappings";
			this.slvPortMappings.Size = new System.Drawing.Size(794, 459);
			this.slvPortMappings.TabIndex = 24;
			this.slvPortMappings.UseCompatibleStateImageBehavior = false;
			this.slvPortMappings.View = System.Windows.Forms.View.Details;
			// 
			// ColName
			// 
			this.ColName.Text = "Description";
			this.ColName.Width = 240;
			// 
			// ColIP
			// 
			this.ColIP.Text = "IP";
			this.ColIP.Width = 120;
			// 
			// ColPort
			// 
			this.ColPort.Text = "Port";
			this.ColPort.Width = 120;
			// 
			// ColProtocol
			// 
			this.ColProtocol.Text = "Protocol";
			// 
			// ForwarderTab
			// 
			this.Controls.Add(this.slvPortMappings);
			this.Controls.Add(this.CBProtocol);
			this.Controls.Add(this.lblIp);
			this.Controls.Add(this.lblDescription);
			this.Controls.Add(this.lblPort);
			this.Controls.Add(this.BtnRefresh);
			this.Controls.Add(this.BtnAdd);
			this.Controls.Add(this.NumPort);
			this.Controls.Add(this.TxtIp);
			this.Controls.Add(this.TxtName);
			this.Name = "ForwarderTab";
			this.Size = new System.Drawing.Size(800, 500);
			((System.ComponentModel.ISupportInitialize)(this.NumPort)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal MetroComboBox CBProtocol;
		internal MetroLabel lblIp;
		internal MetroLabel lblDescription;
		internal MetroLabel lblPort;
		internal MetroButton BtnRefresh;
		internal MetroButton BtnAdd;
		internal System.Windows.Forms.NumericUpDown NumPort;
		internal MetroTextBox TxtIp;
		internal MetroTextBox TxtName;
		internal System.Windows.Forms.ColumnHeader ColName;
		internal System.Windows.Forms.ColumnHeader ColIP;
		internal System.Windows.Forms.ColumnHeader ColPort;
		internal System.Windows.Forms.ColumnHeader ColProtocol;
		private Controls.SortableListView.SortableListView slvPortMappings;
	}
}
