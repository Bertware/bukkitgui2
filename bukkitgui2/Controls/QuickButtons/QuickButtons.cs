namespace Net.Bertware.Bukkitgui2.Controls.QuickButtons
{
    using System;
    using System.Windows.Forms;

    using Net.Bertware.Bukkitgui2.AddOn;
    using Net.Bertware.Bukkitgui2.AddOn.Starter;
    using Net.Bertware.Bukkitgui2.Core;
    using Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler;
    using Net.Bertware.Bukkitgui2.UI;

    public partial class QuickButtons : UserControl
    {
        public QuickButtons()
        {
            this.InitializeComponent();
            ProcessHandler.ServerStarting += this.HandleServerStarting;
            ProcessHandler.ServerStarted += this.HandleServerStarted;
            ProcessHandler.ServerStopped += this.HandleServerStopped;
            ProcessHandler.ServerStopping += this.HandleServerStopping;
        }

        private void HandleServerStarting()
        {
            //suport for calls from other threads
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(this.HandleServerStarting));
            }
            else
            {
                this.btnStartStop.Enabled = false;
                this.btnStartStop.Text = Locale.Tr("Starting...");
            }
        }

        private void HandleServerStarted()
        {
            //suport for calls from other threads
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(this.HandleServerStarted));
            }
            else
            {
                this.btnStartStop.Enabled = true;
                this.btnStartStop.Text = Locale.Tr("Stop");
            }
        }

        private void HandleServerStopping()
        {
            //suport for calls from other threads
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(this.HandleServerStopping));
            }
            else
            {
                this.btnStartStop.Enabled = false;
                this.btnStartStop.Text = Locale.Tr("Stopping...");
            }
        }

        private void HandleServerStopped()
        {
            //suport for calls from other threads
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(this.HandleServerStopped));
            }
            else
            {
                this.btnStartStop.Enabled = true;
                this.btnStartStop.Text = Locale.Tr("Start");
            }
        }

        private void BtnStartStopClick(object sender, EventArgs e)
        {
            //suport for calls from other threads
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() => this.BtnStartStopClick(sender, e)));
            }
            else
            {
                if (ProcessHandler.IsRunning)
                {
                    ProcessHandler.StopServer();
                }
                else
                {
                    if (!(this.ParentForm is MainForm))
                    {
                        return; //check if the parent form is a mainform
                    }
                    MainForm parentForm = (MainForm)this.ParentForm;
                    Starter starter = (Starter)parentForm.GetRequiredAddon(RequiredAddon.Starter);
                        // Get the starter addon
                    starter.LaunchServerFromTab(); // Launch with tab settings
                }
            }
        }
    }
}