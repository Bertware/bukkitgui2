// SixtySetupSettings.cs in bukkitgui2/bukkitgui2
// Created 2014/08/21
// Last edited at 2014/08/22 11:55
// ©Bertware, visit http://bertware.net

using System;
using System.IO;
using MetroFramework.Controls;
using Net.Bertware.Bukkitgui2.Core.Configuration;
using Net.Bertware.Bukkitgui2.Core.Util.Performance;

namespace Net.Bertware.Bukkitgui2.AddOn.SixtySetup
{
	public partial class SixtySetupSettings : MetroUserControl
	{
		private bool _ready = false;

		public event EventHandler SetupComplete;

		protected virtual void OnSetupComplete()
		{
			EventHandler handler = SetupComplete;
			if (handler != null) handler(this, EventArgs.Empty);
		}

		public SixtySetupSettings()
		{
			InitializeComponent();
			// Cache total amount of ram, set maximum values
			int totalMb = Convert.ToInt32(MemoryCounter.TotalMemoryMb());
			TBMaxRam.Maximum = totalMb;
			TBMinRam.Maximum = totalMb;
			NumMaxRam.Maximum = totalMb;
			NumMinRam.Maximum = totalMb;

			_ready = true;

			NumMinRam.Value = 128; // 128mb default min ram
			
			NumMaxRam.Value = 1024; // 1gb default max ram
			if (totalMb < 2048) NumMaxRam.Value = 768; // 768mb for computers with fewer ram
		}

		/// <summary>
		///     Trackbar scrolled, also adjust numeric value
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TbMinRamScroll(object sender, EventArgs e)
		{
			if (!_ready)
			{
				return; //if not initialized, don't detect changes
			}
			Config.WriteInt("Starter", "MinRam", TBMinRam.Value);
			NumMinRam.Value = TBMinRam.Value;
		}

		/// <summary>
		///     Trackbar scrolled, also adjust numeric value
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TbMaxRamScroll(object sender, EventArgs e)
		{
			if (!_ready)
			{
				return; //if not initialized, don't detect changes
			}
			Config.WriteInt("Starter", "MaxRam", TBMaxRam.Value);
			NumMaxRam.Value = TBMaxRam.Value;
		}

		/// <summary>
		///     Numeric value changed, adjust trackbar and check if minimum value is smaller than the maximum value
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NumMinRam_ValueChanged(object sender, EventArgs e)
		{
			// If trackbar doesn't show the same amount, adjust trackbar
			if (TBMinRam.Value != NumMinRam.Value)
			{
				TBMinRam.Value = Convert.ToInt16(NumMinRam.Value);
			}

			if (!_ready)
			{
				return; //if not initialized, don't detect changes
			}
			Config.WriteInt("Starter", "MinRam", Convert.ToInt16(NumMinRam.Value));

			// if minram goes higer than maxram, adjust maxram
			if (NumMinRam.Value > NumMaxRam.Value)
			{
				NumMaxRam.Value = NumMinRam.Value; // keep the value of the item we're changing
			}
		}

		/// <summary>
		///     Numeric value changed, adjust trackbar and check if minimum value is smaller than the maximum value
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NumMaxRam_ValueChanged(object sender, EventArgs e)
		{
			if (TBMaxRam.Value != NumMaxRam.Value)
			{
				TBMaxRam.Value = Convert.ToInt16(NumMaxRam.Value);
			}

			if (!_ready)
			{
				return; //if not initialized, don't detect changes
			}
			Config.WriteInt("Starter", "MaxRam", Convert.ToInt16(NumMaxRam.Value));

			if (NumMinRam.Value > NumMaxRam.Value)
			{
				NumMinRam.Value = NumMaxRam.Value; // keep the value of the item we're changing
			}
		}

		private void btnDone_Click(object sender, EventArgs e)
		{
			Config.SaveFile();
			using (StreamWriter sw = File.CreateText("eula.txt"))
			{
				sw.WriteLine(
					"#By changing the setting below to TRUE you are indicating your agreement to our EULA (https://account.mojang.com/documents/minecraft_eula).");
				sw.WriteLine("eula=true");
			}
			using (StreamWriter sw = File.CreateText("server.properties"))
			{
				sw.WriteLine("motd=" + txtServerName.Text);
			}

			OnSetupComplete();
		}
	}
}