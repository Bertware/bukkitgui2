using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/// SixtySetup should install any minecraft server easily.
/// Create folder, download selected server
/// Install plugins if available. Top 20 plugins or custom lists to be used as recommended plugin, full plugin support by implementing the default plugin manager
/// Set the start settings
/// Remote servers not supported since the lack of support for running a command on the remote console without SSH access (this would be too much access to ask from users)
namespace bukkitgui2.AddOn.SixtySetup
{
	/// <summary>
	/// A user friendly installer for any minecraft server which should get the minimalist job done under 60 seconds (download time not included)
	/// </summary>
	public partial class SixtySetup : Form
	{
		public SixtySetup()
		{
			InitializeComponent();
		}


	}
}
