// BackupAction.cs in bukkitgui2/bukkitgui2
// Created 2014/09/13
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.Action
{
    internal class BackupAction : IAction
    {
        public BackupAction()
        {
            Name = "Backup";
            Description = "Create a backup";
            ParameterDescription =
                "The name of the backup." + Environment.NewLine + "(Backup has to be set-up in backup manager first)";
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
            if (string.IsNullOrEmpty(inputText)) return false;
            return (Backup.Backup.Reference.GetBackupByName(Parameters) != null);
        }

        public string Parameters { get; set; }

        public void Execute()
        {
            OnTaskerActionExecuteStarted();

            if (Backup.Backup.Reference.GetBackupByName(Parameters) != null) return;
            Backup.Backup.Reference.GetBackupByName(Parameters).Execute();

            OnTaskerActionExecuteFinished();
        }
    }
}