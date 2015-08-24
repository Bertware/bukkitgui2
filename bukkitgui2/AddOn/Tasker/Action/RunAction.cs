// ShellCommandAction.cs in bukkitgui2/bukkitgui2
// Created 2014/08/10
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System.Diagnostics;

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.Action
{
	internal class RunAction : IAction
	{
		public RunAction()
		{
			Name = "Run";
			Description = "Run an executable file";
			ParameterDescription =
				"The file to execute";
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
					WindowStyle = ProcessWindowStyle.Normal,
					FileName = Parameters,
				}
			};
			process.Start();
			OnTaskerActionExecuteFinished();
		}
	}
}