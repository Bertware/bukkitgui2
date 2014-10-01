// ServerOutputRegexTrigger.cs in bukkitgui2/bukkitgui2
// Created 2014/09/07
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MetroFramework;
using Net.Bertware.Bukkitgui2.Core.Logging;
using Net.Bertware.Bukkitgui2.MinecraftInterop.OutputHandler;

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.Trigger
{
    internal class ServerOutputRegexTrigger : ITrigger
    {
        public ServerOutputRegexTrigger()
        {
            Name = "Server output (Regular expression - regex)";
            Description = "Execute a task when (part of) the server output matches the parameter regex";
            ParameterDescription = "The regex, which (part of) the server output should match";
        }

        public event TaskerEventArgs TaskerTriggerFired;

        protected virtual void OnTaskerTriggerFired()
        {
            TaskerEventArgs handler = TaskerTriggerFired;
            if (handler != null) handler();
        }


        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public string ParameterDescription { get; protected set; }

        public bool ValidateInput(string inputText)
        {
            // any regex 
            return true;
        }

        public void Load(string parameters)
        {
            if (Enabled)
            {
                Disable();
                Load(parameters);
                Enable();
            }
            else
            {
                Parameters = parameters;
            }
        }

        public string Parameters { get; set; }

        public bool Enabled { get; protected set; }

        public void Enable()
        {
            MinecraftOutputHandler.OutputParsed += OnOutputReceived;
            Enabled = true;
        }

        public void Disable()
        {
            MinecraftOutputHandler.OutputParsed -= OnOutputReceived;
            Enabled = false;
        }

        private void OnOutputReceived(string s, OutputParseResult result)
        {
            try
            {
                if (Regex.IsMatch(result.Message, Parameters)) OnTaskerTriggerFired();
            }
            catch (Exception exception)
            {
                Disable(); // prevent spam of this error on server start
                MetroMessageBox.Show(Application.OpenForms[0],
                    "Failed to execute regex trigger!" + Environment.NewLine + "Following regex caused issues: " +
                    Parameters +
                    Environment.NewLine + "The trigger will now be disabled. Edit the task to enable it again.",
                    "Regex trigger failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Log(LogLevel.Warning, "Regex trigger failed, check regex!", exception.Message);
            }
        }
    }
}