// ServerStartedTrigger.cs in bukkitgui2/bukkitgui2
// Created 2014/08/14
// Last edited at 2014/08/14 12:43
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
		public event TaskerEventArgs TaskerTriggerEnabled;
		public event TaskerEventArgs TaskerTriggerDisabled;

		public string Name { get; protected set; }

		public string Description { get; protected set; }

		public string ParameterDescription { get; protected set; }

		public bool ValidateInput(string inputText)
		{
			// no parameters required, always valid
			return true;
		}

		public void Load(string name, string parameters)
		{
			if (Enabled)
			{
				Disable();
				Load(name, parameters);
				Enable();
			}
			else
			{
				Name = name;
				Parameters = parameters;
			}
		}

		public string Parameters { get; set; }

		public bool Enabled { get; protected set; }

		public void Enable()
		{
			ProcessHandler.ServerStarted += TaskerTriggerFired.Invoke;
			Enabled = true;
			TaskerTriggerEnabled.Invoke();
		}

		public void Disable()
		{
			ProcessHandler.ServerStarted -= TaskerTriggerFired.Invoke;
			Enabled = false;
			TaskerTriggerDisabled.Invoke();
		}
	}
}