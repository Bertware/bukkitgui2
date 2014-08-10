// IAction.cs in bukkitgui2/bukkitgui2
// Created 2014/08/10
// Last edited at 2014/08/10 20:23
// ©Bertware, visit http://bertware.net

using System;
using Net.Bertware.Bukkitgui2.AddOn.Tasker.Trigger;

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.Action
{
	internal interface IAction
	{
		event TaskerEventArgs TaskerActionExecuteStarted;
		event TaskerEventArgs TaskerActionExecuteFinished;

		/// <summary>
		///     Name of the action
		/// </summary>
		string Name { get; }

		/// <summary>
		///     Description of the action
		/// </summary>
		string Description { get; }

		/// <summary>
		///     Description of the action parameters
		/// </summary>
		string ParameterDescription { get; }

		/// <summary>
		///     Validate parameter input
		/// </summary>
		/// <param name="inputText">The input to validate</param>
		/// <returns>Returns True if valid</returns>
		bool ValidateInput(string inputText);

		/// <summary>
		///     The saved parameters for an instance of this action
		/// </summary>
		string Parameters { get; set; }


		/// <summary>
		///     Enable this action
		/// </summary>
		void Execute();


	}
}