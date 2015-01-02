// PlayerCountTrigger.cs in bukkitgui2/bukkitgui2
// Created 2014/09/07
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using Net.Bertware.Bukkitgui2.MinecraftInterop.PlayerHandler;

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.Trigger
{
    internal class PlayerCountTrigger : ITrigger
    {
        public PlayerCountTrigger()
        {
            Name = "Player count";
            Description =
                "Execute a task when a given amount of players is online (evaluated after every join or leave)";
            ParameterDescription = "The amount of players on which this trigger should run (0 to 9999)";
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
            // int
            int i;
            return int.TryParse(inputText, out i);
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
            PlayerHandler.PlayerListChanged += OnPlayerListChanged;
            Enabled = true;
        }

        public void Disable()
        {
            PlayerHandler.PlayerListChanged -= OnPlayerListChanged;
            Enabled = false;
        }

        private void OnPlayerListChanged()
        {
            if (PlayerHandler.GetOnlinePlayerCount() == int.Parse(Parameters)) OnTaskerTriggerFired();
        }
    }
}