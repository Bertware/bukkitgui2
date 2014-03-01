using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Bukkitgui2.UI
{
    using Bukkitgui2.Properties;

    public partial class SplashScreen : Form
	{
		public SplashScreen()
		{
			InitializeComponent();

		    pictureBox1.Image = Resources.GUI_icon;

			Debug.WriteLine("Loading splashscreen");
			var thdSplashWork = new Thread(Application_Initialize) {IsBackground = false, Name = "Splashscreen_work_thread"};
			thdSplashWork.Start();
			Debug.WriteLine("Splashscreen worker thread started");
		}

		private void Application_Initialize()
		{
			//Most of the code goes in this routine, as this handles all shared resources
			Core.Share.Initialize();
            
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