// ShellCommandAction.cs in bukkitgui2/bukkitgui2
// Created 2014/08/10
// Last edited at 2014/08/10 20:33
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
			TaskerActionExecuteFinished.Invoke();
		}
	}
}