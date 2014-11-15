// PerformanceMonitor.cs in bukkitgui2/bukkitgui2
// Created 2014/01/30
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
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

        public PerformanceMonitor()
        {
            InitializeComponent();
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
                ProgBarGuiRam.Value = PerformanceMonitorDataSource.GuiRamCounter.MemoryUsagePct;
                LblGuiRamUsageValue.Text = ConstructRamLabelText(PerformanceMonitorDataSource.GuiRamCounter);
                ProgBarTotalRam.Value = PerformanceMonitorDataSource.TotalRamCounter.MemoryUsagePct;
                LblTotalRamUsageValue.Text = ConstructRamLabelText(PerformanceMonitorDataSource.TotalRamCounter);
                ProgBarServerRam.Value = PerformanceMonitorDataSource.ServerRamCounter.MemoryUsagePct;
                LblServerRamUsageValue.Text = ConstructRamLabelText(PerformanceMonitorDataSource.ServerRamCounter);
                ProgBarGuiCpu.Value = PerformanceMonitorDataSource.GuiCpuCounter.CpuUsage;
                lblGuiCpuUsageValue.Text = ConstructCpuLabelText(PerformanceMonitorDataSource.GuiCpuCounter);
                ProgBarTotalCpu.Value = PerformanceMonitorDataSource.TotalCpuCounter.CpuUsage;
                lblTotalCpuUsageValue.Text = ConstructCpuLabelText(PerformanceMonitorDataSource.TotalCpuCounter);
                ProgBarServerCpu.Value = PerformanceMonitorDataSource.ServerCpuCounter.CpuUsage;
                lblServerCpuUsageValue.Text = ConstructCpuLabelText(PerformanceMonitorDataSource.ServerCpuCounter);

                TimeSpan uptime = ProcessHandler.Uptime;
                LblUptimeValue.Text = uptime.Hours.ToString().PadLeft(2, '0') + ":" +
                                      uptime.Minutes.ToString().PadLeft(2, '0') + ":" +
                                      uptime.Seconds.ToString().PadLeft(2, '0');
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