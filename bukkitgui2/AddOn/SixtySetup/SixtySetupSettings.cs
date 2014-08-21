// SixtySetupServerDownload.cs in bukkitgui2/bukkitgui2
// Created 2014/08/18
// Last edited at 2014/08/18 16:17
// ©Bertware, visit http://bertware.net

using System;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using Net.Bertware.Bukkitgui2.Core;
using Net.Bertware.Bukkitgui2.Core.Configuration;
using Net.Bertware.Bukkitgui2.MinecraftServers;
using Net.Bertware.Bukkitgui2.MinecraftServers.Servers;

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
    }
}