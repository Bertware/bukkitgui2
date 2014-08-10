using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.Trigger
{


	interface ITrigger
	{

		event TaskerEventArgs TaskerTriggerFired;
		event TaskerEventArgs TaskerTriggerEnabled;
		event TaskerEventArgs TaskerTriggerDisabled;

		/// <summary>
		/// Name of the trigger
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Description of the trigger
		/// </summary>
		string Description { get; }
		/// <summary>
		/// Description of the trigger parameters
		/// </summary>
		string ParameterDescription { get; }
		/// <summary>
		/// Validate parameter input
		/// </summary>
		/// <param name="inputText">The input to validate</param>
		/// <returns>Returns True if valid</returns>
		bool ValidateInput(string inputText);

		/// <summary>
		/// The saved parameters for an instance of this trigger
		/// </summary>
		string Parameters { get; set; }
		/// <summary>
		/// If this trigger instance is enabled
		/// </summary>
		bool Enabled { get; }

		/// <summary>
		/// Enable this trigger
		/// </summary>
		void Enable();

		/// <summary>
		/// Disable this trigger
		/// </summary>
		void Disable();
	}
}
