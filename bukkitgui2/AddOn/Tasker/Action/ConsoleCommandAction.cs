// ConsoleCommandAction.cs in bukkitgui2/bukkitgui2
// Created 2014/08/10
// Last edited at 2014/08/10 20:31
// ©Bertware, visit http://bertware.net

using Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler;

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.Action
{
	internal class ConsoleCommandAction : IAction
	{
		public ConsoleCommandAction()
		{
			Name = "ConsoleCommand";
			Description = "Send a command to the console, if the server is running";
			ParameterDescription =
				"The command to send";
		}

		public event TaskerEventArgs TaskerActionExecuteStarted;

		public event TaskerEventArgs TaskerActionExecuteFinished;

		public string Name { get; protected set; }

		public string Description { get; protected set; }

		public string ParameterDescription { get; protected set; }

		public bool ValidateInput(string inputText)
		{
			return true;
		}

		public string Parameters { get; set; }

		public void Execute()
		{
			TaskerActionExecuteStarted.Invoke();
			ProcessHandler.SendInput(Parameters);
			TaskerActionExecuteFinished.Invoke();
		}
	}
}