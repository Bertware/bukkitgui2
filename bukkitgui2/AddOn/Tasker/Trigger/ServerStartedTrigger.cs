// ServerStartedTrigger.cs in bukkitgui2/bukkitgui2
// Created 2014/08/14
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler;

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.Trigger
{
    internal class ServerStartedTrigger : ITrigger
    {
        public ServerStartedTrigger()
        {
            Name = "Server Started";
            Description = "Execute a task when the server started";
            ParameterDescription = "No parameters are required";
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
            ProcessHandler.ServerStarted += OnTaskerTriggerFired;
            Enabled = true;
        }

        public void Disable()
        {
            ProcessHandler.ServerStarted -= OnTaskerTriggerFired;
            Enabled = false;
        }
    }
}