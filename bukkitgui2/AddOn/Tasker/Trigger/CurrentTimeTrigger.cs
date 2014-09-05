// CurrentTimeTrigger.cs in bukkitgui2/bukkitgui2
// Created 2014/08/10
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Text.RegularExpressions;
using System.Timers;

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.Trigger
{
	internal class CurrentTimeTrigger : ITrigger
	{
		public CurrentTimeTrigger()
		{
			Name = "CurrentTime";
			Description = "Execute a task at the given time. Precision: +- 2.5 seconds.";
			ParameterDescription =
				"The time on which this task should execute, in HH:MM:SS format. Multiple times can be entered, separated by ; (e.g.: 01:00:00;13:00:00)";
		}

		public event TaskerEventArgs TaskerTriggerFired;


		public string Name { get; protected set; }

		public string Description { get; protected set; }

		public string ParameterDescription { get; protected set; }

		public bool ValidateInput(string inputText)
		{
			return Regex.IsMatch(inputText, "^((\\d{2}:\\d{2}:\\d{2})(;?))+$");
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
			Parameters = Parameters.Trim(';');
			string[] splittimes = Parameters.Split(';');
			_times = new TimeSpan[splittimes.Length];

			for (int i = 0; i < splittimes.Length; i++)
			{
				_times[i] = TimeSpan.Parse(splittimes[i]);
			}

			_timerCheckCurrentTime = new Timer(TimerInterval*1000);
			_timerCheckCurrentTime.Elapsed += check_time;

			Enabled = true;
		}

		public void Disable()
		{
			if (_timerCheckCurrentTime != null)
			{
				_timerCheckCurrentTime.Enabled = false;
				_timerCheckCurrentTime.Elapsed -= check_time;
				_timerCheckCurrentTime = null;
			}

			Enabled = false;
		}

		/// <summary>
		///     Timer interval in seconds
		/// </summary>
		private const int TimerInterval = 5;

		private Timer _timerCheckCurrentTime;
		private TimeSpan[] _times;

		/// <summary>
		///     Check the current time, and see if the trigger should go off.
		/// </summary>
		private void check_time()
		{
			foreach (TimeSpan time in _times)
			{
				if (Math.Abs(DateTime.Now.TimeOfDay.Subtract(time).Seconds) < TimerInterval)
					TaskerTriggerFired.Invoke();
			}
		}

		/// <summary>
		///     Check_time method with parameters for timer elapsed event args
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void check_time(object sender, ElapsedEventArgs e)
		{
			check_time();
		}
	}
}