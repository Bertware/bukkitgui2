// SplashScreen.cs in bukkitgui2/bukkitgui2
// Created 2014/08/18
// Last edited at 2014/08/18 15:37
// ©Bertware, visit http://bertware.net

using System;
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
			if (this.InvokeRequired)
			{
				this.Invoke((MethodInvoker) SafeFormClose);
			}
			else
			{
				this.Close();
			}
		}

	}
}