// Starter.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using MetroFramework.Controls;
using Net.Bertware.Bukkitgui2.Core.Configuration;
using Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler;
using Net.Bertware.Bukkitgui2.MinecraftServers;

namespace Net.Bertware.Bukkitgui2.AddOn.Starter
{
    internal class Starter : IAddon
    {
        private StarterTab _tab;

        /// <summary>
        ///     The addon name, ideally this name is the same as used in the tabpage
        /// </summary>
        public string Name
        {
            get { return "Starter"; }
        }

        /// <summary>
        ///     True if this addon has a tab page
        /// </summary>
        public bool HasTab
        {
            get { return true; }
        }

        /// <summary>
        ///     True if this addon has a config field
        /// </summary>
        public bool HasConfig
        {
            get { return false; }
        }

        /// <summary>
        ///     Initialize all functions and the tabcontrol
        /// </summary>
        public void Initialize()
        {
            _tab = new StarterTab {Text = Name, ParentAddon = this};
            AddonManager.AddonsReady += OnLoad;
        }

        private void OnLoad()
        {
            if (Environment.GetCommandLineArgs().Contains("-startserver") || Config.ReadBool("console","autostart",false))
            {
                StartServer();
            }
        }

        public void Dispose()
        {
            // nothing to do
        }

        /// <summary>
        ///     The tab control for this addon
        /// </summary>
        /// <returns>Returns the tabpage</returns>
        public MetroUserControl TabPage
        {
            get { return _tab; }
        }

        public MetroUserControl ConfigPage
        {
            get { return null; }
        }

        public bool CanDisable
        {
            get { return false; }
        }

        private static Starter GetInstance()
        {
            return (Starter) AddonManager.GetRequiredAddon(RequiredAddon.Starter);
        }

        /// <summary>
        ///     Launch a new server using the settings in the tabpage. Will validate, shows popup if errors occur.
        /// </summary>
        public static void StartServer()
        {
            ((StarterTab) GetInstance().TabPage).DoServerLaunch();
        }

        /// <summary>
        ///     Launch a new server using the settings in the tabpage. Will validate, shows popup if errors occur.
        ///     Important! Since this is for automated starts, all update checks will be skipped. Update checks are only executed
        ///     for manual starts
        /// </summary>
        public static void StartServerAutomated()
        {
            ProcessHandler.ServerStopped -= StartServerAutomated;
            ((StarterTab) GetInstance().TabPage).DoServerLaunch(true);
        }

        /// <summary>
        ///     Restart the server
        /// </summary>
        public static void RestartServer()
        {
            if (ProcessHandler.IsRunning)
            {
                StopServer();
                ProcessHandler.ServerStopped += StartServerAutomated;
            }
        }

        /// <summary>
        ///     Reload the server
        /// </summary>
        public static void ReloadServer()
        {
            ProcessHandler.SendInput("reload");
        }

        /// <summary>
        ///     Stop the server
        /// </summary>
        public static void StopServer()
        {
            ProcessHandler.StopServer();
        }

        /// <summary>
        ///     kill the server process
        /// </summary>
        public static void KillServer()
        {
            if (!ProcessHandler.ServerProcess.HasExited) ProcessHandler.ServerProcess.Kill();
        }

        /// <summary>
        ///     Kill all java processes
        /// </summary>
        public static void KillAllJava()
        {
            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName.Equals("java")) process.Kill();
            }
        }

        /// <summary>
        ///     Get the selected java path.
        /// </summary>
        /// <returns></returns>
        public static string GetSelectedJavaPath()
        {
            return ((StarterTab) GetInstance().TabPage).GetSelectedJavaPath();
        }

        /// <summary>
        ///     Get the path for the .jar file.
        /// </summary>
        /// <returns></returns>
        public static string GetSelectedServerPath()
        {
            return ((StarterTab) GetInstance().TabPage).GetSelectedServerPath();
        }

        /// <summary>
        ///     Get the custom settings control, for server types who require this.
        /// </summary>
        /// <returns></returns>
        public static Control GetCustomSettingsControl()
        {
            return ((StarterTab) GetInstance().TabPage).GetCustomSettingsControl();
        }

        /// <summary>
        ///     Launch a new server
        /// </summary>
        /// <param name="server">the server type that will be executed</param>
        /// <param name="javaVersion">the java version to use</param>
        /// <param name="jarFile">the jar file to run</param>
        /// <param name="minMem">the minimum amount of memory to set</param>
        /// <param name="maxMem">the maximum amount of memory to set</param>
        /// <param name="defaultParameters">the parameters entered by the user (optional)</param>
        /// <param name="defaultFlags">the flags entered by the user (optional)</param>
        /// <param name="automated">
        ///     If this is an automated launch. Automated launches won't check for server updates and limit
        ///     popups.
        /// </param>
        public void LaunchServer(IMinecraftServer server, JavaVersion javaVersion, string jarFile, UInt32 minMem,
            UInt32 maxMem, string defaultParameters = "", string defaultFlags = "", Boolean automated = false)
        {
            server.PrepareLaunch();
            string parameters = server.GetLaunchParameters(defaultParameters);
            string flags = server.GetLaunchFlags(defaultFlags);
            string argument = parameters + " -Xms" + minMem + "M -Xmx" + maxMem + "M -jar \"" + jarFile + "\" " + flags;
            string executable = JavaApi.GetJavaPath(javaVersion);

            ProcessHandler.StartServer(executable, argument, server);
        }

        /// <summary>
        ///     Launch a new server
        /// </summary>
        /// <param name="server">the server type that will be executed</param>
        /// <param name="customSettingsControl">The custom settings control that is filled out</param>
        public void LaunchServer(IMinecraftServer server, UserControl customSettingsControl)
        {
            server.PrepareLaunch();
            string parameters = server.GetLaunchParameters();
            string executable = server.CustomAssembly;
            ProcessHandler.StartServer(executable, parameters, server);
        }
    }
}