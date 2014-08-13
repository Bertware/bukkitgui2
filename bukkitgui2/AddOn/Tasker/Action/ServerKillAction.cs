// ServerKillAction.cs in bukkitgui2/bukkitgui2
// Created 2014/08/13
// Last edited at 2014/08/13 19:56
// ©Bertware, visit http://bertware.net

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.Action
{
	internal class ServerKillAction : IAction
	{
		public ServerKillAction()
		{
			Name = "Kill Server";
			Description =
				"Kill the current server instance. Warning! May corrupt data, use at own risk. Only to be used in case of a crashed server.";
			ParameterDescription =
				"No parameters are required";
		}

		public event TaskerEventArgs TaskerActionExecuteStarted;

		public event TaskerEventArgs TaskerActionExecuteFinished;

		public string Name { get; protected set; }

		public string Description { get; protected set; }

		public string ParameterDescription { get; protected set; }

		public void Load(string name, string parameters)
		{
			Name = name;
			Parameters = parameters;
		}

		public bool ValidateInput(string inputText)
		{
			return true;
		}

		public string Parameters { get; set; }

		public void Execute()
		{
			TaskerActionExecuteStarted.Invoke();
			Starter.Starter.KillServer();
			TaskerActionExecuteFinished.Invoke();
		}
	}
}