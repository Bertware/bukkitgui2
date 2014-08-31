// ServerCpuUsageTrigger.cs in bukkitgui2/bukkitgui2
// Created 2014/08/21
// ©Bertware, visit http://bertware.net

using System.Timers;
using Net.Bertware.Bukkitgui2.Core.Util.Performance;

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.Trigger
{
	internal class ServerCpuUsageTrigger : ITrigger
	{
		/// <summary>
		///     The minimum value which can be entered. prevents tasks that trigger too much
		/// </summary>
		private const int Minvalue = 5;

		/// <summary>
		///     Timer interval in milliseconds
		/// </summary>
		private const int TimerInterval = 500;

		private Timer _timerCheckTrigger;

		private int _triggervalue = 100;

		public ServerCpuUsageTrigger()
		{
			Name = "Server Cpu Usage";
			Description = "Execute a task when the server cpu usage goes above a certain percentage.";
			ParameterDescription =
				"The percentage [" + Minvalue + "-100] above which value this task will trigger. ";
		}

		public event TaskerEventArgs TaskerTriggerFired;

		protected virtual void OnTaskerTriggerFired()
		{
			TaskerEventArgs handler = TaskerTriggerFired;
			if (handler != null) handler();
		}


		public string Name { get; protected set; }

		public string Description { get; protected set; }

		public string ParameterDescription { get; protected set; }

		public bool ValidateInput(string inputText)
		{
			int i;
			if (!int.TryParse(inputText, out i)) return false;
			if (i < 5 || i > 100) return false;
			return true;
		}

		public void Load(string parameters)
		{
			if (Enabled)
			{
				Disable();
				Load(parameters);
				Enable();
			}
			else
			{
				Parameters = parameters;
			}
		}

		public string Parameters { get; set; }

		public bool Enabled { get; protected set; }

		public void Enable()
		{
			_timerCheckTrigger = new Timer(TimerInterval);
			_timerCheckTrigger.Elapsed += timer_elapsed;
			_triggervalue = int.Parse(Parameters);
			Enabled = true;
		}

		public void Disable()
		{
			if (_timerCheckTrigger != null)
			{
				_timerCheckTrigger.Enabled = false;
				_timerCheckTrigger.Elapsed -= timer_elapsed;
				_timerCheckTrigger = null;
			}

			Enabled = false;
		}


		/// <summary>
		///     Check the current usage, and see if the trigger should go off.
		/// </summary>
		private void check_usage()
		{
			if (PerformanceMonitorDataSource.ServerCpuCounter.CpuUsage >= _triggervalue) OnTaskerTriggerFired();
		}

		/// <summary>
		///     handle timer elapse
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timer_elapsed(object sender, ElapsedEventArgs e)
		{
			check_usage();
		}
	}
}