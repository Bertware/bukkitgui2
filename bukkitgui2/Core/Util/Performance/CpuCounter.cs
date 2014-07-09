// CpuCounter.cs in bukkitgui2/bukkitgui2
// Created 2014/07/09
// Last edited at 2014/07/09 18:18
// ©Bertware, visit http://bertware.net

using System;
using System.Diagnostics;
using System.Timers;

namespace Net.Bertware.Bukkitgui2.Core.Util.Performance
{
    /// <summary>
    ///     Provide information over total, used, available memory
    /// </summary>
    internal class CpuCounter
    {
        private const int Interval = 500;
        private readonly int _pid;
        private Int32 _value;
        private readonly int _cores = int.Parse(Wmi.GetprocessorInfo(Wmi.ProcessorProp.NumberOfCores));
        private Timer _updateTimer;

        private Int64 _prevTotalTimePerCore;
        private Int64 _prevTime;

        public CpuCounter()
        {
            Initialize();
        }

        public CpuCounter(int pid)
        {
            _pid = pid;
            Initialize();
        }

        private void Initialize()
        {
            _updateTimer = new Timer(Interval) {AutoReset = true};
            _updateTimer.Elapsed += OnTimerElapsed;
            _updateTimer.Start();
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            UpdateStats();
        }

        public void UpdateStats()
        {
            Process p = Process.GetProcessById(_pid);
            if (!p.Responding || p.HasExited)
            {
                _value = 0;
                return;
            }

            Int64 time = DateTime.Now.Ticks;
            Int64 currentTotalTimePerCore = p.TotalProcessorTime.Ticks/_cores;

            _value = Convert.ToInt16((100*(currentTotalTimePerCore - _prevTotalTimePerCore))/(time - _prevTime));

            _prevTime = time;
            _prevTotalTimePerCore = currentTotalTimePerCore;
        }

        public Int64 CpuUsage
        {
            get { return _value; }
        }


        public void Enable()
        {
            if (_updateTimer != null) _updateTimer.Enabled = true;
        }

        public void Disable()
        {
            if (_updateTimer != null) _updateTimer.Enabled = false;
        }
    }
}