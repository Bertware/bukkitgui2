// ServerStopDialog.cs in bukkitgui2/bukkitgui2
// Created 2014/06/17
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using Net.Bertware.Bukkitgui2.AddOn.Starter;
using Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler;

namespace Net.Bertware.Bukkitgui2.UI
{
    public partial class ServerStopDialog : MetroForm
    {
        public ServerStopDialog()
        {
            InitializeComponent();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
	        Close();
        }

        private void ServerStopDialog_Load(object sender, EventArgs e)
        {
            if (ProcessHandler.CurrentState == ServerState.Stopped)
            {
                DialogResult = DialogResult.OK;
                Close();
            }

            if (ProcessHandler.Server.IsLocal)
            {
                ProcessHandler.StopServer();
            }
            else
            {
                ProcessHandler.StopServerProcess();
            }
            
            ProcessHandler.ServerStopped += Return;
        }

        private void Return()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(Return));
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnKill_Click(object sender, EventArgs e)
        {
            ProcessHandler.KillServer();
        }
    }
}