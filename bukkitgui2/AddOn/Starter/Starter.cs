using System;
using System.Reflection;
using System.Windows.Forms;
using Bukkitgui2.MinecraftInterop.ProcessHandler;
using Bukkitgui2.MinecraftServers;

namespace Bukkitgui2.AddOn.Starter
{
	internal class Starter : IAddon
	{
		private UserControl _tab;


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
		}

		/// <summary>
		///     The tab control for this addon
		/// </summary>
		/// <returns>Returns the tabpage</returns>
		public UserControl TabPage
		{
			get { return _tab; }
		}

		public UserControl ConfigPage
		{
			get { return null; }
		}

		/// <summary>
		///     Launch a new server using the settings in the tabpage. Will validate, shows popup if errors occur.
		/// </summary>
		public void LaunchServerFromTab()
		{
			((StarterTab) TabPage).DoServerLaunch();
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
		public void LaunchServer(IMinecraftServer server, JavaVersion javaVersion, string jarFile, UInt32 minMem,
			UInt32 maxMem, string defaultParameters = "", string defaultFlags = "")
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
		/// <param name="customAssembly">the custom assembly that will be executed, absolute path recommended</param>
		/// <param name="customSettingsControl">The custom settings control that is filled out</param>
		public void LaunchServer(IMinecraftServer server, Assembly customAssembly, UserControl customSettingsControl)
		{
		}
	}
}