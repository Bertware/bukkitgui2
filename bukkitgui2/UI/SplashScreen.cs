using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace bukkitgui2.UI
{
	public partial class SplashScreen : Form
	{
		public SplashScreen()
		{
			InitializeComponent();
            Debug.WriteLine("Loading splashscreen");
            Thread Splashscreen_work_thread = new Thread(Application_Initialize);
            Splashscreen_work_thread.IsBackground = false;
            Splashscreen_work_thread.Name = "Splashscreen_work_thread";
            Splashscreen_work_thread.Start();
            Debug.WriteLine("Splashscreen worker thread started");
		}

        void Application_Initialize()
        {
            //Most of the code goes in this routine, as this handles all shared resources
			Core.Share.initialize();

            Thread.Sleep(1000);
            CloseForm();
        }

        void CloseForm()
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate() { CloseForm(); }));
            }
            else
            {
                Debug.WriteLine("Splashscreen finished work");
                this.Close();
            }

        }
	}
}
