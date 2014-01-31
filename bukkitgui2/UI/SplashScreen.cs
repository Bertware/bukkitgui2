using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace bukkitgui2.UI
{
	public partial class SplashScreen : Form
	{
		public SplashScreen()
		{
			InitializeComponent();
			Debug.WriteLine("Loading splashscreen");
			var thdSplashWork = new Thread(Application_Initialize) {IsBackground = false, Name = "Splashscreen_work_thread"};
			thdSplashWork.Start();
			Debug.WriteLine("Splashscreen worker thread started");
		}

		private void Application_Initialize()
		{
			//Most of the code goes in this routine, as this handles all shared resources
			Core.Share.Initialize();

			Thread.Sleep(1000);
			CloseForm();
		}

		private void CloseForm()
		{
			if (InvokeRequired)
			{
				Invoke(new MethodInvoker(CloseForm));
			}
			else
			{
				Debug.WriteLine("Splashscreen finished work");
				Close();
			}
		}
	}
}