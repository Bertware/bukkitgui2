// MemoryCounter.cs in bukkitgui2/bukkitgui2
// Created 2014/05/24
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Diagnostics;
using System.Timers;
using Microsoft.VisualBasic.Devices;
using Net.Bertware.Bukkitgui2.Core.Logging;

namespace Net.Bertware.Bukkitgui2.Core.Util.Performance
{
    /// <summary>
    ///     Provide information over total, used, available memory
    /// </summary>
    public class MemoryCounter
    {
        private const int Interval = 500;
        public int Pid { get; private set; }
        private Int32 _value;
        private readonly Int32 _totalMemoryMb = TotalMemoryMb();
        private Timer _updateTimer;

        public MemoryCounter()
        {
            Initialize();
        }

        public MemoryCounter(int pid)
        {
            Pid = pid;
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
            try
            {
                if (Pid == 0)
                {
                    _value = _totalMemoryMb - ToMb(new Computer().Info.AvailablePhysicalMemory);
                }
                else
                {
                    _value = ToMb(Process.GetProcessById(Pid).WorkingSet64);
                }
            }
            catch (Exception exception)
            {
                Logger.Log(LogLevel.Warning, "MemoryCounter", "Error while measuring RAM usage", exception.Message);
            }
        }

        public Int64 MemoryUsageMb
        {
            get { return _value; }
        }

        public int MemoryUsagePct
        {
            get { return (100*_value/_totalMemoryMb); }
        }

        public void Enable()
        {
            if (_updateTimer != null) _updateTimer.Enabled = true;
        }

        public void Disable()
        {
            _value = 0;
            if (_updateTimer != null) _updateTimer.Enabled = false;
        }

        public static Int64 TotalMemory()
        {
            return Convert.ToInt64(new Computer().Info.TotalPhysicalMemory);
        }

        public static Int32 TotalMemoryMb()
        {
            return Convert.ToInt32(TotalMemory()/1048576);
        }

        public static Int32 ToMb(string bytesStr)
        {
            Int64 bytes;
            Int64.TryParse(bytesStr, out bytes);
            return ToMb(bytes);
        }

        public static Int32 ToMb(Int64 bytes)
        {
            return Convert.ToInt32(bytes/1048576);
        }

        public static Int32 ToMb(UInt64 bytes)
        {
            return Convert.ToInt32(bytes/1048576);
        }
    }
}