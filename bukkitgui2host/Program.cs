// Program.cs in bukkitgui2/bukkitgui2host
// Created 2014/01/30
// Last edited at 2014/05/17 19:43
// ©Bertware, visit http://bertware.net

using System;
using System.Windows.Forms;

namespace bukkitgui2host
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}