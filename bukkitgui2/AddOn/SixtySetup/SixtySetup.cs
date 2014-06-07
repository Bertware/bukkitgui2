// SixtySetup.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/06/07 20:24
// ©Bertware, visit http://bertware.net

using System.Windows.Forms;

namespace Net.Bertware.Bukkitgui2.AddOn.SixtySetup
{
	/// <summary>
	///     A user friendly installer for any minecraft server which should get the minimalist job done under 60 seconds
	///     (download time not included)
	/// </summary>
	/// <remarks>
	///     SixtySetup should install any minecraft server easily.
	///     Create folder, download selected server
	///     Install plugins if available. Top 20 plugins or custom lists to be used as recommended plugin, full plugin support
	///     by implementing the default plugin manager
	///     Set the start settings
	///     Remote servers not supported since the lack of support for running a command on the remote console without SSH
	///     access (this would be too much access to ask from users)
	/// </remarks>
	public partial class SixtySetup : Form
	{
		public SixtySetup()
		{
			InitializeComponent();
		}
	}
}