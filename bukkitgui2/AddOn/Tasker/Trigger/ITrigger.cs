// ITrigger.cs in bukkitgui2/bukkitgui2
// Created 2014/08/10
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.Trigger
{
	public interface ITrigger
	{
		event TaskerEventArgs TaskerTriggerFired;

		/// <summary>
		///     Name of the trigger
		/// </summary>
		string Name { get; }

		/// <summary>
		///     Description of the trigger
		/// </summary>
		string Description { get; }

		/// <summary>
		///     Description of the trigger parameters
		/// </summary>
		string ParameterDescription { get; }

		/// <summary>
		///     Validate parameter input
		/// </summary>
		/// <param name="inputText">The input to validate</param>
		/// <returns>Returns True if valid</returns>
		bool ValidateInput(string inputText);

		/// <summary>
		///     Load a trigger by name and parameter
		/// </summary>
		/// <param name="parameters"></param>
		void Load(string parameters);

		/// <summary>
		///     The saved parameters for an instance of this trigger
		/// </summary>
		string Parameters { get; set; }

		/// <summary>
		///     If this trigger instance is enabled
		/// </summary>
		bool Enabled { get; }

		/// <summary>
		///     Enable this trigger
		/// </summary>
		void Enable();

		/// <summary>
		///     Disable this trigger
		/// </summary>
		void Disable();
	}
}