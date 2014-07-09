// ServerStopDialog.cs in bukkitgui2/bukkitgui2
// Created 2014/06/17
// Last edited at 2014/06/22 12:34
// ©Bertware, visit http://bertware.net

using System;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.AddOn.Starter;
using Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler;

namespace Net.Bertware.Bukkitgui2.UI
{
    public partial class ServerStopDialog : Form
    {
        public ServerStopDialog()
        {
            InitializeComponent();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ServerStopDialog_Load(object sender, EventArgs e)
        {
            if (ProcessHandler.CurrentState == ServerState.Stopped)
            {
                DialogResult = DialogResult.OK;
                Close();
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
            Starter.KillServer();
        }
    }
}