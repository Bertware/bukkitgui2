// HeartbeatTrigger.cs in bukkitgui2/bukkitgui2
// Created 2014/08/23
// Last edited at 2014/08/23 11:51
// ©Bertware, visit http://bertware.net

using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Timers;
using Net.Bertware.Bukkitgui2.MinecraftInterop.OutputHandler;
using Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler;

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.Trigger
{
	internal class HeartbeatTrigger
	{
		private Timer _timerCheckHeartbeat;
		private int _interval = 10;

		/// <summary>
		///     Are we waiting for a heartbeat response?
		/// </summary>
		private bool _heartbeat_unanswered;

		public HeartbeatTrigger()
		{
			Name = "Heartbeat Crash Detection";
			Description =
				"This trigger will send a signal to the server every X seconds. If the server hasn't responded to this signal before the next heartbeat, this trigger goes off.";
			ParameterDescription =
				"The time in seconds between 2 heartbeats";
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
			return Regex.IsMatch(inputText, "^\\d+$");
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
			_interval = int.Parse(Parameters);

			_timerCheckHeartbeat = new Timer(_interval*1000);
			_timerCheckHeartbeat.Elapsed += check_trigger;
			MinecraftOutputHandler.PlayerListReceived += heartbeat_received;
			Enabled = true;
		}

		/// <summary>
		///     Got an answer, reset the "waiting for heartbeat" variable
		/// </summary>
		/// <param name="text"></param>
		/// <param name="outputParseResult"></param>
		/// <param name="playersDictionary"></param>
		private void heartbeat_received(string text, OutputParseResult outputParseResult,
			Dictionary<string, string> playersDictionary)
		{
			_heartbeat_unanswered = false;
		}

		public void Disable()
		{
			if (_timerCheckHeartbeat != null)
			{
				_timerCheckHeartbeat.Enabled = false;
				_timerCheckHeartbeat.Elapsed -= check_trigger;
				_timerCheckHeartbeat = null;
			}

			Enabled = false;
		}


		/// <summary>
		///     Check the current time, and see if the trigger should go off.
		/// </summary>
		private void check_trigger()
		{
			if (_heartbeat_unanswered) OnTaskerTriggerFired();

			ProcessHandler.SendInput("list"); //use the list command to recognize a responsive server
			_heartbeat_unanswered = true;
		}

		/// <summary>
		///     Check_time method with parameters for timer elapsed event args
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void check_trigger(object sender, ElapsedEventArgs e)
		{
			check_trigger();
		}
	}
}