// IAction.cs in bukkitgui2/bukkitgui2
// Created 2014/08/10
// Last edited at 2014/08/17 11:19
// ©Bertware, visit http://bertware.net

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.Action
{
	public interface IAction
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
		///     Load an action by name and parameter
		/// </summary>
		/// <param name="parameters"></param>
		void Load(string parameters);

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