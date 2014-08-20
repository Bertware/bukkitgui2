// TaskButtonPressedTrigger.cs in bukkitgui2/bukkitgui2
// Created 2014/08/18
// Last edited at 2014/08/18 11:44
// ©Bertware, visit http://bertware.net

using System;
using Net.Bertware.Bukkitgui2.AddOn.Console;

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.Trigger
{
    internal class TaskButtonPressedTrigger : ITrigger
    {
        public TaskButtonPressedTrigger()
        {
            Name = "Task button pressed";
            Description = "Execute a task when the task button on the main tab is pressed";
            ParameterDescription = "No parameters are required";
        }

        public event TaskerEventArgs TaskerTriggerFired;

        // signature is compatible with EventHandler to simplify hooking the source event to this method.
        private void OnTaskerTriggerFired(object sender, EventArgs e)
        {
            TaskerEventArgs handler = TaskerTriggerFired;
            if (handler != null) handler();
        }


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
            ConsoleTab.Reference.quickButtons.TaskButtonPressed += OnTaskerTriggerFired;
            Enabled = true;
        }

        public void Disable()
        {
            ConsoleTab.Reference.quickButtons.TaskButtonPressed -= OnTaskerTriggerFired;
            Enabled = false;
        }
    }
}