// ServerStartingTrigger.cs in bukkitgui2/bukkitgui2
// Created 2014/08/14
// ©Bertware, visit http://bertware.net

using Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler;

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.Trigger
{
	internal class ServerStartingTrigger : ITrigger
	{
		public ServerStartingTrigger()
		{
			Name = "Server starting";
			Description = "Execute a task when the server is starting";
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
			ProcessHandler.ServerStarting += OnTaskerTriggerFired;
			Enabled = true;
		}

		public void Disable()
		{
			ProcessHandler.ServerStarting -= OnTaskerTriggerFired;
			Enabled = false;
		}
	}
}