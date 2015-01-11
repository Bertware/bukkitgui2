using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.UI;

namespace Net.Bertware.Bukkitgui2
{ 
	public static class Launcher
	{
		// run the mainform, we need to proxy it through this class since we need to load embedded dll's first
		public static void Run()
		{
			Application.Run(new MainForm());
		}
	}
}
