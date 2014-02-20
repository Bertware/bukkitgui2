namespace Bukkitgui2.AddOn.Starter
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumMaxRam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBMaxRam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMinRam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBMinRam)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBServerLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.BtnLaunch);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.TxtOptFlag);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.TxtOptArg);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.NumMaxRam);
            this.groupBox1.Controls.Add(this.TBMaxRam);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.NumMinRam);
            this.groupBox1.Controls.Add(this.TBMinRam);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CBJavaVersion);
            this.groupBox1.Controls.Add(this.TxtJarFile);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CBServerType);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 284);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server";
            // 
            // BtnLaunch
            // 
            this.BtnLaunch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnLaunch.Location = new System.Drawing.Point(152, 255);
            this.BtnLaunch.Name = "BtnLaunch";
            this.BtnLaunch.Size = new System.Drawing.Size(326, 23);
            this.BtnLaunch.TabIndex = 16;
            this.BtnLaunch.Text = "Launch Server";
            this.BtnLaunch.UseVisualStyleBackColor = true;
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
            this.TxtOptFlag.Location = new System.Drawing.Point(152, 221);
            this.TxtOptFlag.Name = "TxtOptFlag";
            this.TxtOptFlag.Size = new System.Drawing.Size(326, 20);
            this.TxtOptFlag.TabIndex = 14;
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
            this.TxtOptArg.Location = new System.Drawing.Point(152, 195);
            this.TxtOptArg.Name = "TxtOptArg";
            this.TxtOptArg.Size = new System.Drawing.Size(326, 20);
            this.TxtOptArg.TabIndex = 12;
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
            this.NumMaxRam.Location = new System.Drawing.Point(152, 160);
            this.NumMaxRam.Margin = new System.Windows.Forms.Padding(3, 12, 3, 12);
            this.NumMaxRam.Name = "NumMaxRam";
            this.NumMaxRam.Size = new System.Drawing.Size(73, 20);
            this.NumMaxRam.TabIndex = 10;
            // 
            // TBMaxRam
            // 
            this.TBMaxRam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBMaxRam.Location = new System.Drawing.Point(231, 151);
            this.TBMaxRam.Name = "TBMaxRam";
            this.TBMaxRam.Size = new System.Drawing.Size(247, 45);
            this.TBMaxRam.TabIndex = 9;
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
            this.NumMinRam.Location = new System.Drawing.Point(152, 109);
            this.NumMinRam.Margin = new System.Windows.Forms.Padding(3, 12, 3, 12);
            this.NumMinRam.Name = "NumMinRam";
            this.NumMinRam.Size = new System.Drawing.Size(73, 20);
            this.NumMinRam.TabIndex = 7;
            // 
            // TBMinRam
            // 
            this.TBMinRam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBMinRam.Location = new System.Drawing.Point(231, 100);
            this.TBMinRam.Name = "TBMinRam";
            this.TBMinRam.Size = new System.Drawing.Size(247, 45);
            this.TBMinRam.TabIndex = 6;
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
            // 
            // TxtJarFile
            // 
            this.TxtJarFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtJarFile.Location = new System.Drawing.Point(152, 74);
            this.TxtJarFile.Name = "TxtJarFile";
            this.TxtJarFile.Size = new System.Drawing.Size(326, 20);
            this.TxtJarFile.TabIndex = 2;
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
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.LLblSite);
            this.groupBox2.Controls.Add(this.LblCurrentVer);
            this.groupBox2.Controls.Add(this.btnGetCurrentBuild);
            this.groupBox2.Controls.Add(this.LblLatestDevValue);
            this.groupBox2.Controls.Add(this.LblLatestBetaValue);
            this.groupBox2.Controls.Add(this.LblLatestRecommendedValue);
            this.groupBox2.Controls.Add(this.LblLatestBeta);
            this.groupBox2.Controls.Add(this.LblLatestDevelopment);
            this.groupBox2.Controls.Add(this.LblLatestRecommended);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.CBUpdateBranch);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.CBUpdateBehaviour);
            this.groupBox2.Controls.Add(this.BtnDownloadDev);
            this.groupBox2.Controls.Add(this.BtnDownloadBeta);
            this.groupBox2.Controls.Add(this.BtnDownloadRec);
            this.groupBox2.Controls.Add(this.PBServerLogo);
            this.groupBox2.Location = new System.Drawing.Point(493, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(304, 432);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Maintainance";
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
            this.LblCurrentVer.Text = "Current version:";
            // 
            // btnGetCurrentBuild
            // 
            this.btnGetCurrentBuild.Location = new System.Drawing.Point(6, 152);
            this.btnGetCurrentBuild.Name = "btnGetCurrentBuild";
            this.btnGetCurrentBuild.Size = new System.Drawing.Size(150, 23);
            this.btnGetCurrentBuild.TabIndex = 15;
            this.btnGetCurrentBuild.Text = "Get current build";
            this.btnGetCurrentBuild.UseVisualStyleBackColor = true;
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
            // 
            // BtnDownloadDev
            // 
            this.BtnDownloadDev.Location = new System.Drawing.Point(6, 239);
            this.BtnDownloadDev.Name = "BtnDownloadDev";
            this.BtnDownloadDev.Size = new System.Drawing.Size(292, 23);
            this.BtnDownloadDev.TabIndex = 4;
            this.BtnDownloadDev.Text = "Download Latest Development build";
            this.BtnDownloadDev.UseVisualStyleBackColor = true;
            // 
            // BtnDownloadBeta
            // 
            this.BtnDownloadBeta.Location = new System.Drawing.Point(6, 210);
            this.BtnDownloadBeta.Name = "BtnDownloadBeta";
            this.BtnDownloadBeta.Size = new System.Drawing.Size(292, 23);
            this.BtnDownloadBeta.TabIndex = 3;
            this.BtnDownloadBeta.Text = "Download Latest Beta build";
            this.BtnDownloadBeta.UseVisualStyleBackColor = true;
            // 
            // BtnDownloadRec
            // 
            this.BtnDownloadRec.Location = new System.Drawing.Point(6, 181);
            this.BtnDownloadRec.Name = "BtnDownloadRec";
            this.BtnDownloadRec.Size = new System.Drawing.Size(292, 23);
            this.BtnDownloadRec.TabIndex = 2;
            this.BtnDownloadRec.Text = "Download Latest Recommended build";
            this.BtnDownloadRec.UseVisualStyleBackColor = true;
            // 
            // PBServerLogo
            // 
            this.PBServerLogo.ErrorImage = global::Bukkitgui2.Properties.Resources.vanilla_logo;
            this.PBServerLogo.Image = global::Bukkitgui2.Properties.Resources.vanilla_logo;
            this.PBServerLogo.InitialImage = global::Bukkitgui2.Properties.Resources.vanilla_logo;
            this.PBServerLogo.Location = new System.Drawing.Point(6, 18);
            this.PBServerLogo.Name = "PBServerLogo";
            this.PBServerLogo.Size = new System.Drawing.Size(128, 128);
            this.PBServerLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBServerLogo.TabIndex = 0;
            this.PBServerLogo.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Location = new System.Drawing.Point(3, 293);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(484, 142);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Server specific settings";
            // 
            // StarterTab
            // 
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "StarterTab";
            this.Size = new System.Drawing.Size(800, 500);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumMaxRam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBMaxRam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMinRam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBMinRam)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBServerLogo)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBServerType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
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
	}
}
