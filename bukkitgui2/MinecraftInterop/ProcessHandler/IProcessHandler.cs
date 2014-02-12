using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Bukkitgui2.MinecraftServers;

namespace Bukkitgui2.MinecraftInterop.ProcessHandler
{
	interface IProcessHandler
	{
		Process ServerProcess { get; }
		IMinecraftServer Server { get; }

		event EventHandler ServerStarting;
		event EventHandler ServerStarted;
		event EventHandler ServerStopping;
		event EventHandler ServerStopped;
		event EventHandler UnexpectedServerStop;

		/// <summary>
		/// Start the server. The processHandler should do ALL the work including passing the output to the outputhandler
		/// </summary>
		/// <param name="executable">The executable file to run</param>
		/// <param name="parameters">The parameters for the executable file</param>
		/// <param name="server">The server object</param>
		Boolean StartServer(string executable, string parameters, IMinecraftServer server);

		void StopServer();

		Boolean SendInput(string text);

	}
}
