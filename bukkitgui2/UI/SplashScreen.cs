// SplashScreen.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/05/24 12:16
// ©Bertware, visit http://bertware.net

using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.Core;
using Net.Bertware.Bukkitgui2.Properties;

namespace Net.Bertware.Bukkitgui2.UI
{
	public partial class SplashScreen : Form
	{
		public SplashScreen()
		{
			InitializeComponent();

			pictureBox1.Image = Resources.GUI_icon;

			Debug.WriteLine("Loading splashscreen");
			Thread thdSplashWork = new Thread(Application_Initialize) {IsBackground = false, Name = "Splashscreen_work_thread"};
			thdSplashWork.Start();
			Debug.WriteLine("Splashscreen worker thread started");
		}

		private void Application_Initialize()
		{
			//Most of the code goes in this routine, as this handles all shared resources
			Share.Initialize();

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