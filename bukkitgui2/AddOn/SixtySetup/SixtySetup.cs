// SixtySetup.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/08/17 11:19
// ©Bertware, visit http://bertware.net

using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroMessageBox = MetroFramework.MetroMessageBox;

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
    public partial class SixtySetup : MetroForm
    {
        public SixtySetup()
        {
            InitializeComponent();
        }

        private void SixtySetup_Load(object sender, EventArgs e)
        {
            if (MetroMessageBox.Show(this, "Do you want to create a new server?" + Environment.NewLine +
                                           "Select YES in case you do not have a previous server you'd like to use." +
                                           Environment.NewLine +
                                           "Select NO in case you want to use the GUI with an existing server",
                "Create a new server?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) Close();
        }
    }
}