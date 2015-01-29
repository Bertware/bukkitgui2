// ServerStartedTrigger.cs in bukkitgui2/bukkitgui2
// Created 2014/08/14
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.Trigger
{
    internal class TaskExecutedTrigger : ITrigger
    {
        public TaskExecutedTrigger()
        {
            Name = "Task executed";
            Description = "Execute a task after another task has been exuted";
            ParameterDescription = "The name of the task, after which this task should run";
        }

        public event TaskerEventArgs TaskerTriggerFired;


        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public string ParameterDescription { get; protected set; }

        public bool ValidateInput(string inputText)
        {
            // no parameters required, always valid
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
            Tasker.Reference.TaskExecuted += OnTaskerTriggerFired;
            Enabled = true;
        }

        public void Disable()
        {
            Tasker.Reference.TaskExecuted -= OnTaskerTriggerFired;
            Enabled = false;
        }

        protected virtual void OnTaskerTriggerFired(object sender, EventArgs e)
        {
            if (!Enabled || !(sender is Task) || !Equals(Parameters.ToLower(), ((Task) sender).Name.ToLower())) return;

            TaskerEventArgs handler = TaskerTriggerFired;
            if (handler != null) handler();
        }
    }
}