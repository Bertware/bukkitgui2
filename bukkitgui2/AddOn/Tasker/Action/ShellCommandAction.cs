// ShellCommandAction.cs in bukkitgui2/bukkitgui2
// Created 2014/08/10
// Last edited at 2014/08/16 12:24
// ©Bertware, visit http://bertware.net

using System.Diagnostics;

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.Action
{
	internal class ShellCommandAction : IAction
	{
		public ShellCommandAction()
		{
			Name = "ShellCommand";
			Description = "Send a command to the windows shell (cmd)";
			ParameterDescription =
				"The command to send";
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
			Process process = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					WindowStyle = ProcessWindowStyle.Hidden,
					FileName = "cmd.exe",
					Arguments = Parameters
				}
			};
			process.Start();
			OnTaskerActionExecuteFinished();
		}
	}
}