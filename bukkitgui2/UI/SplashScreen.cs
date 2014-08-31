// SplashScreen.cs in bukkitgui2/bukkitgui2
// Created 2014/08/18
// ©Bertware, visit http://bertware.net

using System.Windows.Forms;
using MetroFramework.Forms;

namespace Net.Bertware.Bukkitgui2.UI
{
	public partial class SplashScreen : MetroForm
	{
		public static SplashScreen Reference;

		public SplashScreen()
		{
			Reference = this;
			InitializeComponent();
		}

		public void SafeFormClose()
		{
			if (InvokeRequired)
			{
				Invoke((MethodInvoker) SafeFormClose);
			}
			else
			{
				Close();
			}
		}
	}
}