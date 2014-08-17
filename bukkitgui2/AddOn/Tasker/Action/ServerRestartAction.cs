// ServerRestartAction.cs in bukkitgui2/bukkitgui2
// Created 2014/08/13
// Last edited at 2014/08/17 11:19
// ©Bertware, visit http://bertware.net

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.Action
{
	internal class ServerRestartAction : IAction
	{
		public ServerRestartAction()
		{
			Name = "Restart server";
			Description = "Restart the server gracefully";
			ParameterDescription =
				"No parameters are required";
		}

		public event TaskerEventArgs TaskerActionExecuteStarted;

		protected virtual void OnTaskerActionExecuteStarted()
		{
			TaskerEventArgs handler = TaskerActionExecuteStarted;
			if (handler != null) handler();
		}

		public event TaskerEventArgs TaskerActionExecuteFinished;

		protected virtual void OnTaskerActionExecuteFinished()
		{
			TaskerEventArgs handler = TaskerActionExecuteFinished;
			if (handler != null) handler();
		}

		public string Name { get; protected set; }

		public string Description { get; protected set; }

		public string ParameterDescription { get; protected set; }

		public void Load(string parameters)
		{
			Parameters = parameters;
		}

		public bool ValidateInput(string inputText)
		{
			return true;
		}

		public string Parameters { get; set; }

		public void Execute()
		{
			OnTaskerActionExecuteStarted();
			Starter.Starter.RestartServer();
			OnTaskerActionExecuteFinished();
		}
	}
}