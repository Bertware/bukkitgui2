// Program.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Net.Bertware.Bukkitgui2
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [MTAThread]
        private static void Main(string[] argStrings)
        {
            // Load embedded DLLs
            AppDomain.CurrentDomain.AssemblyResolve += LoadDll;

            // Load app
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                Application.Run(new UiLauncher());
            }
            catch (Exception exception)
            {
                MessageBox.Show("The application encountered an unexpected error!" + Environment.NewLine +
                                "Please contact the developer with following information:" + Environment.NewLine +
                                "Exception: " + exception.Message + Environment.NewLine +
                                "Details:" + exception.StackTrace,
                    "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static Assembly LoadDll(object sender, ResolveEventArgs args)
        {
            //Load embedded DLLs

            String resourceName = "Net.Bertware.Bukkitgui2.Resources.Dll." + new AssemblyName(args.Name).Name + ".dll";

            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                if (stream == null || stream.Length < 1)
                {
                    return null;
                }
                Byte[] assemblyData = new Byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);

                return Assembly.Load(assemblyData);
            }
        }

        internal static void ExtractDll(string name)
        {
            String resourceName = "Net.Bertware.Bukkitgui2.Resources.Dll." + name + ".dll";

            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                if (stream == null || stream.Length < 1)
                {
                    return;
                }
                Byte[] assemblyData = new Byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);

                using (FileStream fs = File.Create(name + ".dll"))
                {
                    fs.Write(assemblyData, 0, assemblyData.Length);
                }
            }
        }
    }
}