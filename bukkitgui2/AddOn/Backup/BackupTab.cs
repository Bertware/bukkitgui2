using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bukkitgui2.AddOn.Backup
{
	public partial class BackupTab : UserControl, IAddonTab
	{
		public BackupTab()
		{
			InitializeComponent();
		}

		public IAddon ParentAddon { get; set; }
	}
}
