// PerformanceMonitorDataSource.cs in bukkitgui2/bukkitgui2
// Created 2014/08/21
// Last edited at 2014/08/21 22:08
// ©Bertware, visit http://bertware.net

using System.Diagnostics;
using Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler;

namespace Net.Bertware.Bukkitgui2.Core.Util.Performance
{
	public static class PerformanceMonitorDataSource
	{
		private static readonly MemoryCounter _TotalRamCounter = new MemoryCounter();

		/// <summary>
		///     Ram usage counter for the total ram usage
		/// </summary>
		public static MemoryCounter TotalRamCounter
		{
			get
			{
				if (!_initialized) Initialize();
				return _TotalRamCounter;
			}
		}

		private static readonly MemoryCounter _GuiRamCounter = new MemoryCounter(Process.GetCurrentProcess().Id);

		/// <summary>
		///     Ram usage counter for ram usage by GUI
		/// </summary>
		public static MemoryCounter GuiRamCounter
		{
			get
			{
				if (!_initialized) Initialize();
				return _GuiRamCounter;
			}
		}

		private static MemoryCounter _serverRamCounter;

		/// <summary>
		///     Ram usage counter for ram usage by the server
		/// </summary>
		public static MemoryCounter ServerRamCounter
		{
			get
			{
				if (!_initialized) Initialize();
				return _serverRamCounter;
			}
		}

		private static readonly CpuCounter _TotalCpuCounter = new CpuCounter();

		/// <summary>
		///     CPU usage counter for toital cpu usage
		/// </summary>
		public static CpuCounter TotalCpuCounter
		{
			get
			{
				if (!_initialized) Initialize();
				return _TotalCpuCounter;
			}
		}

		private static readonly CpuCounter _GuiCpuCounter = new CpuCounter(Process.GetCurrentProcess().Id);

		/// <summary>
		///     CPU usage counter for cpu usage by GUI
		/// </summary>
		public static CpuCounter GuiCpuCounter
		{
			get
			{
				if (!_initialized) Initialize();
				return _GuiCpuCounter;
			}
		}

		private static CpuCounter _serverCpuCounter;

		/// <summary>
		///     CPU usage counter for cpu usage by the server
		/// </summary>
		public static CpuCounter ServerCpuCounter
		{
			get
			{
				if (!_initialized) Initialize();
				return _serverCpuCounter;
			}
		}


		private static bool _initialized;

		public static void Initialize()
		{
			if (_initialized) return;

			_serverRamCounter = new MemoryCounter();
			_serverRamCounter.Disable();

			_serverCpuCounter = new CpuCounter();
			_serverCpuCounter.Disable();

			ProcessHandler.ServerStarted += StartServerChecks;
			ProcessHandler.ServerStopped += StopServerChecks;

			_initialized = true;
		}

		private static void StartServerChecks()
		{
			_serverRamCounter = new MemoryCounter(ProcessHandler.ServerProcess.Id);
			_serverRamCounter.UpdateStats();
			_serverCpuCounter = new CpuCounter(ProcessHandler.ServerProcess.Id);
			_serverCpuCounter.UpdateStats();
		}

		private static void StopServerChecks()
		{
			_serverCpuCounter.Disable();
			_serverRamCounter.Disable();
		}
	}
}