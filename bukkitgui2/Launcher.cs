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
		public static void Run()
		{
			Application.Run(new MainForm());
		}
	}
}
