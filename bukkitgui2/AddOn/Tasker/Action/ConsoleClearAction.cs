// ConsoleClearAction.cs in bukkitgui2/bukkitgui2
// Created 2014/08/24
// ©Bertware, visit http://bertware.net

using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.AddOn.Console;

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.Action
{
	internal class ConsoleClearAction : IAction
	{
		public ConsoleClearAction()
		{
			Name = "Clear console";
			Description = "Clear the console in the main tab";
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

			if (ConsoleTab.Reference.InvokeRequired)
			{
				ConsoleTab.Reference.Invoke((MethodInvoker) ConsoleTab.Reference.MCCOut.Clear);
			}
			else
			{
				ConsoleTab.Reference.MCCOut.Clear();
			}

			OnTaskerActionExecuteFinished();
		}
	}
}