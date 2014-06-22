// PerformanceMonitor.cs in bukkitgui2/bukkitgui2
// Created 2014/01/30
// Last edited at 2014/06/22 12:34
// ©Bertware, visit http://bertware.net

using System;
using System.Diagnostics;
using System.Globalization;
using System.Timers;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.Core.Util.Performance;
using Timer = System.Timers.Timer;

namespace Net.Bertware.Bukkitgui2.Controls.PerformanceMonitor
{
	public partial class PerformanceMonitor : UserControl
	{
		private Timer _tmrRefresh = new Timer(1000);
		private readonly MemoryCounter _totalRamCounter;
		private readonly MemoryCounter _guiRamCounter;
		private readonly MemoryCounter _serverRamCounter;

		public PerformanceMonitor()
		{
			InitializeComponent();
			_totalRamCounter = new MemoryCounter();
			_totalRamCounter.UpdateStats();
			_guiRamCounter = new MemoryCounter(Process.GetCurrentProcess().Id);
			_guiRamCounter.UpdateStats();
			_serverRamCounter = new MemoryCounter();
			_serverRamCounter.Disable();
		}

		private void PerformanceMonitor_Load(object sender, EventArgs e)
		{
			_tmrRefresh = new Timer(1000);
			_tmrRefresh.Elapsed += RefreshData;
		}

		private void PerformanceMonitor_VisibleChanged(object sender, EventArgs e)
		{
			if (_tmrRefresh != null) _tmrRefresh.Enabled = Visible; //Do not refresh if invisible
		}

		private void RefreshData(object sender, ElapsedEventArgs e)
		{
			if (InvokeRequired)
			{
				Invoke(new MethodInvoker(() => RefreshData(sender, e)));
			}
			else
			{
				ProgBarGuiRam.Value = _guiRamCounter.MemoryUsagePct;
				LblGuiRamUsageValue.Text = ConstructRamLabelText(_guiRamCounter);
				ProgBarTotalRam.Value = _totalRamCounter.MemoryUsagePct;
				LblTotalRamUsageValue.Text = ConstructRamLabelText(_totalRamCounter);
				ProgBarServerRam.Value = _serverRamCounter.MemoryUsagePct;
				LblServerRamUsageValue.Text = ConstructRamLabelText(_serverRamCounter);
			}
		}

		private static string ConstructRamLabelText(MemoryCounter counter)
		{
			return counter.MemoryUsageMb + "Mb (" + counter.MemoryUsagePct.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0') +
			       "%)";
		}
	}
}