// ServerUptimeTrigger.cs in bukkitgui2/bukkitgui2
// Created 2014/08/10
// Last edited at 2014/08/17 11:19
// ©Bertware, visit http://bertware.net

using System;
using System.Text.RegularExpressions;
using System.Timers;
using Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler;

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.Trigger
{
	internal class ServerUptimeTrigger : ITrigger
	{
		public ServerUptimeTrigger()
		{
			Name = "ServerUptime";
			Description = "Execute a task after the given uptime. Precision: +- 2.5 seconds.";
			ParameterDescription =
				"The time after which this task should execute, in HH:MM:SS format.";
		}

		public event TaskerEventArgs TaskerTriggerFired;


		public string Name { get; protected set; }

		public string Description { get; protected set; }

		public string ParameterDescription { get; protected set; }

		public bool ValidateInput(string inputText)
		{
			return Regex.IsMatch(inputText, "^(\\d{2}:\\d{2}:\\d{2})$");
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
			_time = TimeSpan.Parse(Parameters);

			_timerCheckCurrentTime = new Timer(_time.TotalMilliseconds);
			_timerCheckCurrentTime.Elapsed += raise_trigger_fired;

			// only start counting when the server is running
			ProcessHandler.ServerStarted += _timerCheckCurrentTime.Start;
			ProcessHandler.ServerStopped += _timerCheckCurrentTime.Stop;
		}

		public void Disable()
		{
			if (_timerCheckCurrentTime != null)
			{
				_timerCheckCurrentTime.Enabled = false;
				ProcessHandler.ServerStarted -= _timerCheckCurrentTime.Start;
				ProcessHandler.ServerStopped -= _timerCheckCurrentTime.Stop;
			}

			Enabled = false;
		}


		private Timer _timerCheckCurrentTime;
		private TimeSpan _time;

		/// <summary>
		///     The timer has elapsed, raise event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void raise_trigger_fired(object sender, ElapsedEventArgs e)
		{
			TaskerTriggerFired.Invoke();
		}
	}
}