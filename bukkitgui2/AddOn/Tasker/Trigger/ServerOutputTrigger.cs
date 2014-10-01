// ServerOutputTrigger.cs in bukkitgui2/bukkitgui2
// Created 2014/09/07
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using Net.Bertware.Bukkitgui2.MinecraftInterop.OutputHandler;

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.Trigger
{
    internal class ServerOutputTrigger : ITrigger
    {
        public ServerOutputTrigger()
        {
            Name = "Server output";
            Description = "Execute a task when the server output contains the parameter text";
            ParameterDescription = "the text which the server output should contain. Case insensitive.";
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
            // any text
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
            MinecraftOutputHandler.OutputParsed += OnOutputReceived;
            Enabled = true;
        }

        public void Disable()
        {
            MinecraftOutputHandler.OutputParsed -= OnOutputReceived;
            Enabled = false;
        }

        private void OnOutputReceived(string s, OutputParseResult result)
        {
            if (result.Message.ToLower().Contains(result.Message.ToLower())) OnTaskerTriggerFired();
        }
    }
}