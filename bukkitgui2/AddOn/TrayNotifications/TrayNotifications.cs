using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Net.Bertware.Bukkitgui2.AddOn.TrayNotifications
{
	class TrayNotifications : IAddon
	{
		public string Name { get { return "Tray Notifications"; } }
		public bool HasTab { get { return false; }}
		public bool HasConfig { get { return true; } }
		public void Initialize()
		{
			ConfigPage = new TrayNotificationSettings();
		}

		public UserControl TabPage { get { return null; } }
		public UserControl ConfigPage { get; private set; }
	}
}
