// ServerStartedTrigger.cs in bukkitgui2/bukkitgui2
// Created 2014/08/14
// Last edited at 2014/08/14 12:43
// ©Bertware, visit http://bertware.net

using Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler;

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.Trigger
{
	internal class UnexpectedServerStopTrigger : ITrigger
	{
		public UnexpectedServerStopTrigger()
		{
			Name = "Server unexpectedly exited";
			Description = "Execute a task when the server has exited unexpectedly";
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
			ProcessHandler.UnexpectedServerStop += TaskerTriggerFired.Invoke;
			Enabled = true;
			TaskerTriggerEnabled.Invoke();
		}

		public void Disable()
		{
			ProcessHandler.UnexpectedServerStop -= TaskerTriggerFired.Invoke;
			Enabled = false;
			TaskerTriggerDisabled.Invoke();
		}
	}
}