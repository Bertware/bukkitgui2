// CpuCounter.cs in bukkitgui2/bukkitgui2
// Created 2014/07/13
// Last edited at 2014/08/17 11:19
// ©Bertware, visit http://bertware.net

using System;
using System.Diagnostics;
using System.Timers;
using Net.Bertware.Bukkitgui2.Core.Logging;

namespace Net.Bertware.Bukkitgui2.Core.Util.Performance
{
	/// <summary>
	///     Provide information over total, used, available memory
	/// </summary>
	internal class CpuCounter
	{
		private const int Interval = 333;
		private readonly int _pid;
		private Int32 _value;
		private static readonly int Cores = Convert.ToInt16(Wmi.GetprocessorInfo(Wmi.ProcessorProp.NumberOfLogicalProcessors));
		private Timer _updateTimer;

		private PerformanceCounter _counter;

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
			try
			{
				if (_pid == 0)
				{
					_counter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
				}
				else
				{
					_counter = new PerformanceCounter("Process", "% Processor Time", Process.GetProcessById(_pid).ProcessName);
				}


				_updateTimer = new Timer(Interval) {AutoReset = true};
				_updateTimer.Elapsed += OnTimerElapsed;
				_updateTimer.Start();
			}
			catch (Exception exception)
			{
				Logger.Log(LogLevel.Severe, "CpuCounter", "Failed to initialize CpuCounter", exception.Message);
			}
		}

		private void OnTimerElapsed(object sender, ElapsedEventArgs e)
		{
			UpdateStats();
		}

		public void UpdateStats()
		{
			try
			{
				if (_pid != 0 && Process.GetProcessById(_pid).HasExited)
				{
					_value = 0;
					Disable();
					return;
				}
				_value = Convert.ToInt16(_counter.NextValue());
				if (_pid != 0) _value = _value/Cores;
			}
			catch (Exception exception)
			{
				Logger.Log(LogLevel.Warning, "CpuCounter", "Failed to update CpuCounter values", exception.Message);
			}
		}

		public int CpuUsage
		{
			get
			{
				if (_value > 100) return 100;
				return _value;
			}
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