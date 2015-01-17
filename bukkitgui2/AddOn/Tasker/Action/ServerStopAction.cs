// ServerStopAction.cs in bukkitgui2/bukkitgui2
// Created 2014/08/13
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler;

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker.Action
{
    internal class ServerStopAction : IAction
    {
        public ServerStopAction()
        {
            Name = "Stop Server";
            Description = "Stop the server gracefully";
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
            if (ProcessHandler.IsRunning) ProcessHandler.StopServer();
            OnTaskerActionExecuteFinished();
        }
    }
}