// ServerUptimeTrigger.cs in bukkitgui2/bukkitgui2
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
using Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler;

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.Trigger
{
    internal class ServerUptimeTrigger : ITrigger
    {
        public ServerUptimeTrigger()
        {
            Name = "Elapese server uptime";
            Description = "Execute a task after the given uptime. Precision: +- 2.5 seconds.";
            ParameterDescription =
                "The time after which this task should execute, in HH:MM:SS format.";
        }

        public event TaskerEventArgs TaskerTriggerFired;


        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public string ParameterDescription { get; protected set; }

		public string Parameters { get; set; }

		public bool Enabled { get; protected set; }

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

        public void Enable()
        {
	        Enabled = true;

            _time = TimeSpan.Parse(Parameters);

            _timerCheckCurrentTime = new Timer(_time.TotalMilliseconds) {Enabled = false};
            _timerCheckCurrentTime.Elapsed += OnTaskerTriggerFired;

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


        protected virtual void OnTaskerTriggerFired(object sender = null, ElapsedEventArgs e = null)
        {
            if (!Enabled || !ProcessHandler.IsRunning) return;

            var handler = TaskerTriggerFired;
            if (handler != null) handler();
        }
    }
}