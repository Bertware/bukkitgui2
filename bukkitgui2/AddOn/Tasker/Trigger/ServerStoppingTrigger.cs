// ServerStoppingTrigger.cs in bukkitgui2/bukkitgui2
// Created 2014/08/14
// Last edited at 2014/08/17 11:19
// ©Bertware, visit http://bertware.net

using Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler;

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.Trigger
{
    internal class ServerStoppingTrigger : ITrigger
    {
        public ServerStoppingTrigger()
        {
            Name = "Server stopping";
            Description = "Execute a task when the server is stopping";
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
            ProcessHandler.ServerStopping += OnTaskerTriggerFired;
            Enabled = true;
        }

        public void Disable()
        {
            ProcessHandler.ServerStopping -= OnTaskerTriggerFired;
            Enabled = false;
        }
    }
}