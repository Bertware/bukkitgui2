namespace Net.Bertware.Bukkitgui2.AddOn.Starter
{
	partial class StarterTab
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
			this.GBServer = new System.Windows.Forms.GroupBox();
			this.BtnBrowseJarFile = new System.Windows.Forms.Button();
			this.BtnLaunch = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.TxtOptFlag = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.TxtOptArg = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.NumMaxRam = new System.Windows.Forms.NumericUpDown();
			this.TBMaxRam = new System.Windows.Forms.TrackBar();
			this.label4 = new System.Windows.Forms.Label();
			this.NumMinRam = new System.Windows.Forms.NumericUpDown();
			this.TBMinRam = new System.Windows.Forms.TrackBar();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.CBJavaVersion = new System.Windows.Forms.ComboBox();
			this.TxtJarFile = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.CBServerType = new System.Windows.Forms.ComboBox();
			this.GBMaintainance = new System.Windows.Forms.GroupBox();
			this.LLblSite = new System.Windows.Forms.LinkLabel();
			this.LblCurrentVer = new System.Windows.Forms.Label();
			this.btnGetCurrentBuild = new System.Windows.Forms.Button();
			this.LblLatestDevValue = new System.Windows.Forms.Label();
			this.LblLatestBetaValue = new System.Windows.Forms.Label();
			this.LblLatestRecommendedValue = new System.Windows.Forms.Label();
			this.LblLatestBeta = new System.Windows.Forms.Label();
			this.LblLatestDevelopment = new System.Windows.Forms.Label();
			this.LblLatestRecommended = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.CBUpdateBranch = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.CBUpdateBehaviour = new System.Windows.Forms.ComboBox();
			this.BtnDownloadDev = new System.Windows.Forms.Button();
			this.BtnDownloadBeta = new System.Windows.Forms.Button();
			this.BtnDownloadRec = new System.Windows.Forms.Button();
			this.PBServerLogo = new System.Windows.Forms.PictureBox();
			this.GBCustomSettings = new System.Windows.Forms.GroupBox();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.GBServer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NumMaxRam)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TBMaxRam)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NumMinRam)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TBMinRam)).BeginInit();
			this.GBMaintainance.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PBServerLogo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// GBServer
			// 
			this.GBServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.GBServer.Controls.Add(this.BtnBrowseJarFile);
			this.GBServer.Controls.Add(this.BtnLaunch);
			this.GBServer.Controls.Add(this.label7);
			this.GBServer.Controls.Add(this.TxtOptFlag);
			this.GBServer.Controls.Add(this.label6);
			this.GBServer.Controls.Add(this.TxtOptArg);
			this.GBServer.Controls.Add(this.label5);
			this.GBServer.Controls.Add(this.NumMaxRam);
			this.GBServer.Controls.Add(this.TBMaxRam);
			this.GBServer.Controls.Add(this.label4);
			this.GBServer.Controls.Add(this.NumMinRam);
			this.GBServer.Controls.Add(this.TBMinRam);
			this.GBServer.Controls.Add(this.label3);
			this.GBServer.Controls.Add(this.label2);
			this.GBServer.Controls.Add(this.CBJavaVersion);
			this.GBServer.Controls.Add(this.TxtJarFile);
			this.GBServer.Controls.Add(this.label1);
			this.GBServer.Controls.Add(this.CBServerType);
			this.GBServer.Location = new System.Drawing.Point(3, 3);
			this.GBServer.Name = "GBServer";
			this.GBServer.Size = new System.Drawing.Size(484, 284);
			this.GBServer.TabIndex = 0;
			this.GBServer.TabStop = false;
			this.GBServer.Text = "Server";
			// 
			// BtnBrowseJarFile
			// 
			this.BtnBrowseJarFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnBrowseJarFile.Location = new System.Drawing.Point(448, 74);
			this.BtnBrowseJarFile.Name = "BtnBrowseJarFile";
			this.BtnBrowseJarFile.Size = new System.Drawing.Size(30, 20);
			this.BtnBrowseJarFile.TabIndex = 17;
			this.BtnBrowseJarFile.Text = "...";
			this.BtnBrowseJarFile.UseVisualStyleBackColor = true;
			this.BtnBrowseJarFile.Click += new System.EventHandler(this.BtnBrowseJarFile_Click);
			// 
			// BtnLaunch
			// 
			this.BtnLaunch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.errorProvider.SetIconAlignment(this.BtnLaunch, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
			this.BtnLaunch.Location = new System.Drawing.Point(152, 255);
			this.BtnLaunch.Name = "BtnLaunch";
			this.BtnLaunch.Size = new System.Drawing.Size(326, 23);
			this.BtnLaunch.TabIndex = 16;
			this.BtnLaunch.Text = "Launch Server";
			this.BtnLaunch.UseVisualStyleBackColor = true;
			this.BtnLaunch.Click += new System.EventHandler(this.BtnLaunch_Click);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(7, 221);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(139, 20);
			this.label7.TabIndex = 15;
			this.label7.Text = "Optional flags:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// TxtOptFlag
			// 
			this.TxtOptFlag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.errorProvider.SetIconAlignment(this.TxtOptFlag, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
			this.TxtOptFlag.Location = new System.Drawing.Point(152, 221);
			this.TxtOptFlag.Name = "TxtOptFlag";
			this.TxtOptFlag.Size = new System.Drawing.Size(326, 20);
			this.TxtOptFlag.TabIndex = 14;
			this.TxtOptFlag.TextChanged += new System.EventHandler(this.TxtOptFlag_TextChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(7, 195);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(139, 20);
			this.label6.TabIndex = 13;
			this.label6.Text = "Optional arguments:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// TxtOptArg
			// 
			this.TxtOptArg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.errorProvider.SetIconAlignment(this.TxtOptArg, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
			this.TxtOptArg.Location = new System.Drawing.Point(152, 195);
			this.TxtOptArg.Name = "TxtOptArg";
			this.TxtOptArg.Size = new System.Drawing.Size(326, 20);
			this.TxtOptArg.TabIndex = 12;
			this.TxtOptArg.TextChanged += new System.EventHandler(this.TxtOptArg_TextChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(7, 160);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(139, 20);
			this.label5.TabIndex = 11;
			this.label5.Text = "Maximum Ram [Mb] :";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// NumMaxRam
			// 
			this.errorProvider.SetIconAlignment(this.NumMaxRam, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
			this.NumMaxRam.Location = new System.Drawing.Point(152, 160);
			this.NumMaxRam.Margin = new System.Windows.Forms.Padding(3, 12, 3, 12);
			this.NumMaxRam.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
			this.NumMaxRam.Name = "NumMaxRam";
			this.NumMaxRam.Size = new System.Drawing.Size(73, 20);
			this.NumMaxRam.TabIndex = 10;
			this.NumMaxRam.ValueChanged += new System.EventHandler(this.NumMaxRam_ValueChanged);
			// 
			// TBMaxRam
			// 
			this.TBMaxRam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.errorProvider.SetIconAlignment(this.TBMaxRam, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
			this.TBMaxRam.LargeChange = 512;
			this.TBMaxRam.Location = new System.Drawing.Point(231, 151);
			this.TBMaxRam.Maximum = 4096;
			this.TBMaxRam.Name = "TBMaxRam";
			this.TBMaxRam.Size = new System.Drawing.Size(247, 45);
			this.TBMaxRam.SmallChange = 256;
			this.TBMaxRam.TabIndex = 9;
			this.TBMaxRam.TickFrequency = 512;
			this.TBMaxRam.Scroll += new System.EventHandler(this.TbMaxRamScroll);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(7, 109);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(139, 20);
			this.label4.TabIndex = 8;
			this.label4.Text = "Minimum Ram [Mb] :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// NumMinRam
			// 
			this.errorProvider.SetIconAlignment(this.NumMinRam, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
			this.NumMinRam.Location = new System.Drawing.Point(152, 109);
			this.NumMinRam.Margin = new System.Windows.Forms.Padding(3, 12, 3, 12);
			this.NumMinRam.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
			this.NumMinRam.Name = "NumMinRam";
			this.NumMinRam.Size = new System.Drawing.Size(73, 20);
			this.NumMinRam.TabIndex = 7;
			this.NumMinRam.ValueChanged += new System.EventHandler(this.NumMinRam_ValueChanged);
			// 
			// TBMinRam
			// 
			this.TBMinRam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.errorProvider.SetIconAlignment(this.TBMinRam, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
			this.TBMinRam.LargeChange = 512;
			this.TBMinRam.Location = new System.Drawing.Point(231, 100);
			this.TBMinRam.Maximum = 4096;
			this.TBMinRam.Name = "TBMinRam";
			this.TBMinRam.Size = new System.Drawing.Size(247, 45);
			this.TBMinRam.SmallChange = 256;
			this.TBMinRam.TabIndex = 6;
			this.TBMinRam.TickFrequency = 512;
			this.TBMinRam.Scroll += new System.EventHandler(this.TbMinRamScroll);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(7, 74);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(139, 20);
			this.label3.TabIndex = 5;
			this.label3.Text = "Jar file:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(7, 47);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(139, 21);
			this.label2.TabIndex = 4;
			this.label2.Text = "Java version:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// CBJavaVersion
			// 
			this.CBJavaVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CBJavaVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CBJavaVersion.FormattingEnabled = true;
			this.CBJavaVersion.Location = new System.Drawing.Point(152, 47);
			this.CBJavaVersion.Name = "CBJavaVersion";
			this.CBJavaVersion.Size = new System.Drawing.Size(326, 21);
			this.CBJavaVersion.TabIndex = 3;
			this.CBJavaVersion.SelectedIndexChanged += new System.EventHandler(this.CbJavaVersionSelectedIndexChanged);
			// 
			// TxtJarFile
			// 
			this.TxtJarFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.errorProvider.SetIconAlignment(this.TxtJarFile, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
			this.TxtJarFile.Location = new System.Drawing.Point(152, 74);
			this.TxtJarFile.Name = "TxtJarFile";
			this.TxtJarFile.Size = new System.Drawing.Size(290, 20);
			this.TxtJarFile.TabIndex = 2;
			this.TxtJarFile.TextChanged += new System.EventHandler(this.TxtJarFile_TextChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(139, 21);
			this.label1.TabIndex = 1;
			this.label1.Text = "Server type:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// CBServerType
			// 
			this.CBServerType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CBServerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CBServerType.FormattingEnabled = true;
			this.CBServerType.Location = new System.Drawing.Point(152, 20);
			this.CBServerType.Name = "CBServerType";
			this.CBServerType.Size = new System.Drawing.Size(326, 21);
			this.CBServerType.TabIndex = 0;
			this.CBServerType.SelectedIndexChanged += new System.EventHandler(this.CbServerTypeSelectedIndexChanged);
			// 
			// GBMaintainance
			// 
			this.GBMaintainance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.GBMaintainance.Controls.Add(this.LLblSite);
			this.GBMaintainance.Controls.Add(this.LblCurrentVer);
			this.GBMaintainance.Controls.Add(this.btnGetCurrentBuild);
			this.GBMaintainance.Controls.Add(this.LblLatestDevValue);
			this.GBMaintainance.Controls.Add(this.LblLatestBetaValue);
			this.GBMaintainance.Controls.Add(this.LblLatestRecommendedValue);
			this.GBMaintainance.Controls.Add(this.LblLatestBeta);
			this.GBMaintainance.Controls.Add(this.LblLatestDevelopment);
			this.GBMaintainance.Controls.Add(this.LblLatestRecommended);
			this.GBMaintainance.Controls.Add(this.label9);
			this.GBMaintainance.Controls.Add(this.CBUpdateBranch);
			this.GBMaintainance.Controls.Add(this.label8);
			this.GBMaintainance.Controls.Add(this.CBUpdateBehaviour);
			this.GBMaintainance.Controls.Add(this.BtnDownloadDev);
			this.GBMaintainance.Controls.Add(this.BtnDownloadBeta);
			this.GBMaintainance.Controls.Add(this.BtnDownloadRec);
			this.GBMaintainance.Controls.Add(this.PBServerLogo);
			this.GBMaintainance.Location = new System.Drawing.Point(493, 3);
			this.GBMaintainance.Name = "GBMaintainance";
			this.GBMaintainance.Size = new System.Drawing.Size(304, 432);
			this.GBMaintainance.TabIndex = 1;
			this.GBMaintainance.TabStop = false;
			this.GBMaintainance.Text = "Maintainance";
			// 
			// LLblSite
			// 
			this.LLblSite.AutoSize = true;
			this.LLblSite.Location = new System.Drawing.Point(6, 416);
			this.LLblSite.Name = "LLblSite";
			this.LLblSite.Size = new System.Drawing.Size(28, 13);
			this.LLblSite.TabIndex = 1;
			this.LLblSite.TabStop = true;
			this.LLblSite.Text = "Site:";
			// 
			// LblCurrentVer
			// 
			this.LblCurrentVer.Location = new System.Drawing.Point(162, 157);
			this.LblCurrentVer.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.LblCurrentVer.Name = "LblCurrentVer";
			this.LblCurrentVer.Size = new System.Drawing.Size(136, 13);
			this.LblCurrentVer.TabIndex = 16;
			this.LblCurrentVer.Text = "Version:";
			// 
			// btnGetCurrentBuild
			// 
			this.btnGetCurrentBuild.Location = new System.Drawing.Point(6, 152);
			this.btnGetCurrentBuild.Name = "btnGetCurrentBuild";
			this.btnGetCurrentBuild.Size = new System.Drawing.Size(150, 23);
			this.btnGetCurrentBuild.TabIndex = 15;
			this.btnGetCurrentBuild.Text = "Get current build";
			this.btnGetCurrentBuild.UseVisualStyleBackColor = true;
			this.btnGetCurrentBuild.Click += new System.EventHandler(this.btnGetCurrentBuild_Click);
			// 
			// LblLatestDevValue
			// 
			this.LblLatestDevValue.Location = new System.Drawing.Point(140, 109);
			this.LblLatestDevValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.LblLatestDevValue.Name = "LblLatestDevValue";
			this.LblLatestDevValue.Size = new System.Drawing.Size(158, 13);
			this.LblLatestDevValue.TabIndex = 14;
			this.LblLatestDevValue.Text = "#0000 (MC 1.0.0)";
			// 
			// LblLatestBetaValue
			// 
			this.LblLatestBetaValue.Location = new System.Drawing.Point(140, 74);
			this.LblLatestBetaValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.LblLatestBetaValue.Name = "LblLatestBetaValue";
			this.LblLatestBetaValue.Size = new System.Drawing.Size(158, 13);
			this.LblLatestBetaValue.TabIndex = 13;
			this.LblLatestBetaValue.Text = "#0000 (MC 1.0.0)";
			// 
			// LblLatestRecommendedValue
			// 
			this.LblLatestRecommendedValue.Location = new System.Drawing.Point(140, 38);
			this.LblLatestRecommendedValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.LblLatestRecommendedValue.Name = "LblLatestRecommendedValue";
			this.LblLatestRecommendedValue.Size = new System.Drawing.Size(158, 13);
			this.LblLatestRecommendedValue.TabIndex = 12;
			this.LblLatestRecommendedValue.Text = "#0000 (MC 1.0.0)";
			// 
			// LblLatestBeta
			// 
			this.LblLatestBeta.Location = new System.Drawing.Point(140, 56);
			this.LblLatestBeta.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.LblLatestBeta.Name = "LblLatestBeta";
			this.LblLatestBeta.Size = new System.Drawing.Size(158, 13);
			this.LblLatestBeta.TabIndex = 11;
			this.LblLatestBeta.Text = "Latest beta build:";
			// 
			// LblLatestDevelopment
			// 
			this.LblLatestDevelopment.Location = new System.Drawing.Point(140, 92);
			this.LblLatestDevelopment.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.LblLatestDevelopment.Name = "LblLatestDevelopment";
			this.LblLatestDevelopment.Size = new System.Drawing.Size(158, 13);
			this.LblLatestDevelopment.TabIndex = 10;
			this.LblLatestDevelopment.Text = "Latest development build:";
			// 
			// LblLatestRecommended
			// 
			this.LblLatestRecommended.Location = new System.Drawing.Point(140, 20);
			this.LblLatestRecommended.Name = "LblLatestRecommended";
			this.LblLatestRecommended.Size = new System.Drawing.Size(158, 13);
			this.LblLatestRecommended.TabIndex = 9;
			this.LblLatestRecommended.Text = "Latest recommended build:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(6, 330);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(104, 13);
			this.label9.TabIndex = 8;
			this.label9.Text = "Auto update branch:\r\n";
			// 
			// CBUpdateBranch
			// 
			this.CBUpdateBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CBUpdateBranch.FormattingEnabled = true;
			this.CBUpdateBranch.Location = new System.Drawing.Point(6, 346);
			this.CBUpdateBranch.Name = "CBUpdateBranch";
			this.CBUpdateBranch.Size = new System.Drawing.Size(292, 21);
			this.CBUpdateBranch.TabIndex = 7;
			this.CBUpdateBranch.SelectedIndexChanged += new System.EventHandler(this.CBUpdateBranch_SelectedIndexChanged);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(6, 290);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(118, 13);
			this.label8.TabIndex = 6;
			this.label8.Text = "Auto update behaviour:";
			// 
			// CBUpdateBehaviour
			// 
			this.CBUpdateBehaviour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CBUpdateBehaviour.FormattingEnabled = true;
			this.CBUpdateBehaviour.Location = new System.Drawing.Point(6, 306);
			this.CBUpdateBehaviour.Name = "CBUpdateBehaviour";
			this.CBUpdateBehaviour.Size = new System.Drawing.Size(292, 21);
			this.CBUpdateBehaviour.TabIndex = 5;
			this.CBUpdateBehaviour.SelectedIndexChanged += new System.EventHandler(this.CBUpdateBehaviour_SelectedIndexChanged);
			// 
			// BtnDownloadDev
			// 
			this.BtnDownloadDev.Location = new System.Drawing.Point(6, 239);
			this.BtnDownloadDev.Name = "BtnDownloadDev";
			this.BtnDownloadDev.Size = new System.Drawing.Size(292, 23);
			this.BtnDownloadDev.TabIndex = 4;
			this.BtnDownloadDev.Text = "Download Latest Development build";
			this.BtnDownloadDev.UseVisualStyleBackColor = true;
			this.BtnDownloadDev.Click += new System.EventHandler(this.BtnDownloadDev_Click);
			// 
			// BtnDownloadBeta
			// 
			this.BtnDownloadBeta.Location = new System.Drawing.Point(6, 210);
			this.BtnDownloadBeta.Name = "BtnDownloadBeta";
			this.BtnDownloadBeta.Size = new System.Drawing.Size(292, 23);
			this.BtnDownloadBeta.TabIndex = 3;
			this.BtnDownloadBeta.Text = "Download Latest Beta build";
			this.BtnDownloadBeta.UseVisualStyleBackColor = true;
			this.BtnDownloadBeta.Click += new System.EventHandler(this.BtnDownloadBeta_Click);
			// 
			// BtnDownloadRec
			// 
			this.BtnDownloadRec.Location = new System.Drawing.Point(6, 181);
			this.BtnDownloadRec.Name = "BtnDownloadRec";
			this.BtnDownloadRec.Size = new System.Drawing.Size(292, 23);
			this.BtnDownloadRec.TabIndex = 2;
			this.BtnDownloadRec.Text = "Download Latest Recommended build";
			this.BtnDownloadRec.UseVisualStyleBackColor = true;
			this.BtnDownloadRec.Click += new System.EventHandler(this.BtnDownloadRec_Click);
			// 
			// PBServerLogo
			// 
			this.PBServerLogo.ErrorImage = global::Net.Bertware.Bukkitgui2.Properties.Resources.vanilla_logo;
			this.PBServerLogo.Image = global::Net.Bertware.Bukkitgui2.Properties.Resources.vanilla_logo;
			this.PBServerLogo.InitialImage = global::Net.Bertware.Bukkitgui2.Properties.Resources.vanilla_logo;
			this.PBServerLogo.Location = new System.Drawing.Point(6, 18);
			this.PBServerLogo.Name = "PBServerLogo";
			this.PBServerLogo.Size = new System.Drawing.Size(128, 128);
			this.PBServerLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.PBServerLogo.TabIndex = 0;
			this.PBServerLogo.TabStop = false;
			// 
			// GBCustomSettings
			// 
			this.GBCustomSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.GBCustomSettings.Location = new System.Drawing.Point(3, 293);
			this.GBCustomSettings.Name = "GBCustomSettings";
			this.GBCustomSettings.Size = new System.Drawing.Size(484, 142);
			this.GBCustomSettings.TabIndex = 2;
			this.GBCustomSettings.TabStop = false;
			this.GBCustomSettings.Text = "Server specific settings";
			// 
			// errorProvider
			// 
			this.errorProvider.ContainerControl = this;
			// 
			// StarterTab
			// 
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.GBCustomSettings);
			this.Controls.Add(this.GBMaintainance);
			this.Controls.Add(this.GBServer);
			this.Name = "StarterTab";
			this.Size = new System.Drawing.Size(800, 500);
			this.GBServer.ResumeLayout(false);
			this.GBServer.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.NumMaxRam)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TBMaxRam)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NumMinRam)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TBMinRam)).EndInit();
			this.GBMaintainance.ResumeLayout(false);
			this.GBMaintainance.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PBServerLogo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.GroupBox GBServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBServerType;
        private System.Windows.Forms.GroupBox GBMaintainance;
        private System.Windows.Forms.GroupBox GBCustomSettings;
        private System.Windows.Forms.Button BtnLaunch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtOptFlag;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtOptArg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown NumMaxRam;
        private System.Windows.Forms.TrackBar TBMaxRam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NumMinRam;
        private System.Windows.Forms.TrackBar TBMinRam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CBJavaVersion;
        private System.Windows.Forms.TextBox TxtJarFile;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CBUpdateBranch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CBUpdateBehaviour;
        private System.Windows.Forms.Button BtnDownloadDev;
        private System.Windows.Forms.Button BtnDownloadBeta;
        private System.Windows.Forms.Button BtnDownloadRec;
        private System.Windows.Forms.LinkLabel LLblSite;
        private System.Windows.Forms.PictureBox PBServerLogo;
        private System.Windows.Forms.Label LblCurrentVer;
        private System.Windows.Forms.Button btnGetCurrentBuild;
        private System.Windows.Forms.Label LblLatestDevValue;
        private System.Windows.Forms.Label LblLatestBetaValue;
        private System.Windows.Forms.Label LblLatestRecommendedValue;
        private System.Windows.Forms.Label LblLatestBeta;
        private System.Windows.Forms.Label LblLatestDevelopment;
        private System.Windows.Forms.Label LblLatestRecommended;
        private System.Windows.Forms.Button BtnBrowseJarFile;
		private System.Windows.Forms.ErrorProvider errorProvider;
	}
}
