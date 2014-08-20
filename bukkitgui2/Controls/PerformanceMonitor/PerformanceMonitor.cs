// PerformanceMonitor.cs in bukkitgui2/bukkitgui2
// Created 2014/01/30
// Last edited at 2014/08/17 11:19
// ©Bertware, visit http://bertware.net

using System;
using System.Diagnostics;
using System.Globalization;
using System.Timers;
using System.Windows.Forms;
using MetroFramework.Controls;
using Net.Bertware.Bukkitgui2.Core.Util.Performance;
using Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler;
using Timer = System.Timers.Timer;

namespace Net.Bertware.Bukkitgui2.Controls.PerformanceMonitor
{
    public partial class PerformanceMonitor : MetroUserControl
    {
        private Timer _tmrRefresh = new Timer(1000);
        private readonly MemoryCounter _totalRamCounter;
        private readonly MemoryCounter _guiRamCounter;
        private MemoryCounter _serverRamCounter;

        private readonly CpuCounter _totalCpuCounter;
        private readonly CpuCounter _guiCpuCounter;
        private CpuCounter _serverCpuCounter;

        public PerformanceMonitor()
        {
            InitializeComponent();

            // do not draw in design mode!
            if (DesignMode) return;

            _totalRamCounter = new MemoryCounter();
            _totalRamCounter.UpdateStats();
            _guiRamCounter = new MemoryCounter(Process.GetCurrentProcess().Id);
            _guiRamCounter.UpdateStats();
            _serverRamCounter = new MemoryCounter();
            _serverRamCounter.Disable();
            _totalCpuCounter = new CpuCounter();
            _totalCpuCounter.UpdateStats();
            _guiCpuCounter = new CpuCounter(Process.GetCurrentProcess().Id);
            _guiCpuCounter.UpdateStats();
            _serverCpuCounter = new CpuCounter();
            _serverCpuCounter.Disable();
            ProcessHandler.ServerStarted += StartServerChecks;
            ProcessHandler.ServerStopped += StopServerChecks;
        }

        private void StartServerChecks()
        {
            _serverRamCounter = new MemoryCounter(ProcessHandler.ServerProcess.Id);
            _serverRamCounter.UpdateStats();
            _serverCpuCounter = new CpuCounter(ProcessHandler.ServerProcess.Id);
            _serverCpuCounter.UpdateStats();
        }

        private void StopServerChecks()
        {
            _serverCpuCounter.Disable();
            _serverRamCounter.Disable();
        }

        private void PerformanceMonitor_Load(object sender, EventArgs e)
        {
            // do not draw in design mode!
            if (DesignMode) return;

            _tmrRefresh = new Timer(1000);
            _tmrRefresh.Elapsed += RefreshData;
        }

        private void PerformanceMonitor_VisibleChanged(object sender, EventArgs e)
        {
            // do not draw in design mode!
            if (DesignMode)
            {
                _tmrRefresh.Enabled = false;
                return;
            }

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
                ProgBarGuiCpu.Value = _guiCpuCounter.CpuUsage;
                lblGuiCpuUsageValue.Text = ConstructCpuLabelText(_guiCpuCounter);
                ProgBarTotalCpu.Value = _totalCpuCounter.CpuUsage;
                lblTotalCpuUsageValue.Text = ConstructCpuLabelText(_totalCpuCounter);
                ProgBarServerCpu.Value = _serverCpuCounter.CpuUsage;
                lblServerCpuUsageValue.Text = ConstructCpuLabelText(_serverCpuCounter);
            }
        }

        private static string ConstructRamLabelText(MemoryCounter counter)
        {
            return counter.MemoryUsageMb + "Mb (" +
                   counter.MemoryUsagePct.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0') +
                   "%)";
        }

        private static string ConstructCpuLabelText(CpuCounter counter)
        {
            return counter.CpuUsage + "%";
        }
    }
}