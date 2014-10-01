// IAction.cs in bukkitgui2/bukkitgui2
// Created 2014/08/10
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
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