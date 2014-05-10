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
			if (this.InvokeRequired)
			{
				this.Invoke(new MethodInvoker(() => RefreshData(sender, e)));
			}
			else
			{
				ProgBarGuiRam.Value = _guiRamCounter.MemoryUsagePct;
				LblGuiRamUsageValue.Text = constructRamLabelText(_guiRamCounter);
				ProgBarTotalRam.Value = _totalRamCounter.MemoryUsagePct;
				LblTotalRamUsageValue.Text = constructRamLabelText(_totalRamCounter);
				ProgBarServerRam.Value = _serverRamCounter.MemoryUsagePct;
				LblServerRamUsageValue.Text = constructRamLabelText(_serverRamCounter);
			}
		}

		private string constructRamLabelText(MemoryCounter counter)
		{
			return counter.MemoryUsageMb + "Mb (" + counter.MemoryUsagePct.ToString(CultureInfo.InvariantCulture).PadLeft(2,'0') + "%)";
		}
	}
}