// ProcessHandler.cs in bukkitgui2/bukkitgui2
// Created 2014/02/05
// Last edited at 2014/07/13 14:01
// ©Bertware, visit http://bertware.net

using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using Net.Bertware.Bukkitgui2.Core;
using Net.Bertware.Bukkitgui2.Core.Logging;
using Net.Bertware.Bukkitgui2.MinecraftInterop.OutputHandler;
using Net.Bertware.Bukkitgui2.MinecraftServers;

namespace Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler
{
	/// <summary>
	///     The server handler for a local server. As soon as the StartServer() routine is called, this class will take over
	///     and run the server + send output.
	///     Events will trigger all further required actions
	/// </summary>
	internal static class ProcessHandler
	{
		/// <summary>
		///     The Process object for the current server process
		/// </summary>
		public static Process ServerProcess { get; private set; }

		/// <summary>
		///     The IMinecraftserver object for the current running server. Used for parsing output.
		/// </summary>
		public static IMinecraftServer Server { get; private set; }

		/// <summary>
		///     Is the current running right now?
		/// </summary>
		public static Boolean IsRunning
		{
			get { return (CurrentState != ServerState.Stopped); }
		}

		public static TimeSpan Uptime
		{
			get { return (DateTime.Now.Subtract(ServerProcess.StartTime)); }
		}

		/// <summary>
		///     The current state of the server, private object
		/// </summary>
		private static ServerState _currentState;

		/// <summary>
		///     The current state of the server, raises event when changed
		/// </summary>
		public static ServerState CurrentState
		{
			get { return _currentState; }
			private set
			{
				_currentState = value;
				RaiseServerStatusChanged();
			}
		}

		/// <summary>
		///     Mark the server as stopping, in case this has been detected by an addon
		/// </summary>
		public static void MarkServerAsStopping()
		{
			if (CurrentState == ServerState.Running || CurrentState == ServerState.Starting)
				CurrentState = ServerState.Stopping;
		}

		/// <summary>
		///     Delegate for status changes (running/starting/stopping/..) with their own event without need for parameters
		/// </summary>
		public delegate void ErrorOutputReceivedHandler(String output);

		/// <summary>
		///     This event is raised before the server is going to start
		/// </summary>
		public static event ErrorOutputReceivedHandler ErrorOutputReceived;

		private static void RaiseErrorOutputReceived(string output)
		{
			ErrorOutputReceivedHandler handler = ErrorOutputReceived;
			if (handler != null)
			{
				handler(output);
			}
		}

		/// <summary>
		///     Delegate for status changes (running/starting/stopping/..) with a global event which passes on the current state
		/// </summary>
		public delegate void ServerStatusEvent(ServerState currentState);

		/// <summary>
		///     Delegate for status changes (running/starting/stopping/..) with their own event without need for parameters
		/// </summary>
		public delegate void SpecificServerStatusEvent();


		/// <summary>
		///     This event is raised before the server is going to start
		/// </summary>
		public static event ServerStatusEvent ServerStatusChanged;

		private static void RaiseServerStatusChanged()
		{
			ServerStatusEvent handler = ServerStatusChanged;
			if (handler != null)
			{
				handler(CurrentState);
			}
		}

		/// <summary>
		///     This event is raised before the server is going to start
		/// </summary>
		public static event SpecificServerStatusEvent ServerStarting;

		private static void RaiseServerStarting()
		{
			CurrentState = ServerState.Starting;
			RaiseServerStatusChanged();
			SpecificServerStatusEvent handler = ServerStarting;
			if (handler != null)
			{
				handler();
			}
		}

		/// <summary>
		///     This event is raised after the server has been started
		/// </summary>
		public static event SpecificServerStatusEvent ServerStarted;

		private static void RaiseServerStarted()
		{
			CurrentState = ServerState.Running;
			RaiseServerStatusChanged();
			SpecificServerStatusEvent handler = ServerStarted;
			if (handler != null)
			{
				handler();
			}
		}

		/// <summary>
		///     This event is raised when the server starts to shutdown
		/// </summary>
		public static event SpecificServerStatusEvent ServerStopping;

		private static void RaiseServerStopping()
		{
			CurrentState = ServerState.Stopping;
			RaiseServerStatusChanged();
			SpecificServerStatusEvent handler = ServerStopping;
			if (handler != null)
			{
				handler();
			}
		}

		/// <summary>
		///     This event is raised after the server has stopped
		/// </summary>
		public static event SpecificServerStatusEvent ServerStopped;

		private static void RaiseServerStopped()
		{
			CurrentState = ServerState.Stopped;
			RaiseServerStatusChanged();
			SpecificServerStatusEvent handler = ServerStopped;
			if (handler != null)
			{
				handler();
			}
		}

		/// <summary>
		///     This event is raised if the server stopped, while the usual output ("stopping the server") wasn't detected. Could
		///     be a crash!
		/// </summary>
		public static event SpecificServerStatusEvent UnexpectedServerStop;

		private static void RaiseUnexpectedServerStop()
		{
			SpecificServerStatusEvent handler = UnexpectedServerStop;
			CurrentState = ServerState.Stopped;
			RaiseServerStatusChanged();
			if (handler != null)
			{
				handler();
			}
		}

		/// <summary>
		///     True if threads should continue running
		/// </summary>
		private static Boolean _runThreads;

		/// <summary>
		///     Thread for reading standardout
		/// </summary>
		private static Thread _thdReadStdOut;

		/// <summary>
		///     Thread for reading standardin
		/// </summary>
		private static Thread _thdReadStdErr;

		/// <summary>
		///     Start a process, start the threads to read the output and send the output to the correct outputhandler
		/// </summary>
		/// <param name="executable">The executable to run</param>
		/// <param name="parameters">The parameters for the executable</param>
		/// <param name="server">The server that is being ran</param>
		/// <param name="serverDir">The directory that should be used as root for the minecraft server</param>
		/// <returns></returns>
		public static Boolean StartServer(string executable, string parameters, IMinecraftServer server,
			string serverDir = "")
		{
			if (string.IsNullOrEmpty(executable)) return false;

			Server = server;

			FileInfo exeFileInfo = new FileInfo(executable);

			RaiseServerStarting();

			if (string.IsNullOrEmpty(serverDir))
			{
				serverDir = Environment.CurrentDirectory;
				FileInfo guiFileInfo = new FileInfo(Share.AssemblyFullName);
				if (guiFileInfo.Directory != null) serverDir = guiFileInfo.Directory.FullName;
			}

			ServerProcess = new Process
			{
				StartInfo =
					new ProcessStartInfo
					{
						FileName = exeFileInfo.FullName,
						Arguments = parameters,
						CreateNoWindow = true,
						WindowStyle = ProcessWindowStyle.Hidden,
						ErrorDialog = false,
						UseShellExecute = false,
						WorkingDirectory = serverDir,
						StandardErrorEncoding = Encoding.Unicode,
						StandardOutputEncoding = Encoding.Unicode,
						RedirectStandardInput = true,
						RedirectStandardOutput = true,
						RedirectStandardError = true
					},
				EnableRaisingEvents = true
			};
			ServerProcess.Start();
			ServerProcess.Exited += HandleStop;

			StartThreads();

			RaiseServerStarted();
			return true;
		}

		/// <summary>
		///     Stop the server
		/// </summary>
		public static void StopServer()
		{
			RaiseServerStopping();
			SendInput("stop");
		}

		private static void HandleStop(object sender, EventArgs e)
		{
			if (CurrentState != ServerState.Stopping) RaiseUnexpectedServerStop();
			ServerProcess.Exited -= HandleStop;
			StopThreads();
			RaiseServerStopped();
		}

		/// <summary>
		///     Start the output reading threads
		/// </summary>
		private static void StartThreads()
		{
			_thdReadStdOut = new Thread(ReadStdOut) {IsBackground = true, Name = "_thdReadStdOut"};
			_thdReadStdErr = new Thread(ReadStdErr) {IsBackground = true, Name = "_thdReadStdOut"};
			_runThreads = true;
			_thdReadStdOut.Start();
			_thdReadStdErr.Start();
		}

		/// <summary>
		///     Stop the output reading threads
		/// </summary>
		private static void StopThreads()
		{
			_runThreads = false;
		}

		/// <summary>
		///     Read output from the standard output stream. Call this method async!
		/// </summary>
		private static void ReadStdOut()
		{
			using (StreamReader streamReader = new StreamReader(ServerProcess.StandardOutput.BaseStream))
			{
				while (_runThreads)
				{
					string output = streamReader.ReadLine();
					if (string.IsNullOrEmpty(output)) continue;

					Logger.Log(LogLevel.Debug, "LocalProcessHandler", "StdOut output: " + output);
					MinecraftOutputHandler.HandleOutput(Server, output, false);
				}

				//This should be false if we're stopping the server, so this is strange
				if (_runThreads) RaiseUnexpectedServerStop();
			}
		}

		/// <summary>
		///     Read output from the standard error stream. Call this method async!
		/// </summary>
		private static void ReadStdErr()
		{
			using (StreamReader streamReader = new StreamReader(ServerProcess.StandardError.BaseStream))
			{
				while (_runThreads)
				{
					string output = streamReader.ReadLine();
					if (string.IsNullOrEmpty(output)) continue;

					Logger.Log(LogLevel.Debug, "LocalProcessHandler", "StdErr output: " + output);
					RaiseErrorOutputReceived(output);
					MinecraftOutputHandler.HandleOutput(Server, output, true);
				}
			}
		}

		public static Boolean SendInput(string text)
		{
			ServerProcess.StandardInput.WriteLine(text);
			return true;
		}
	}

	/// <summary>
	///     State of the server (stopped, running, stopping or starting)
	/// </summary>
	public enum ServerState
	{
		/// <summary>
		///     The server is stopped
		/// </summary>
		Stopped,

		/// <summary>
		///     The server is starting
		/// </summary>
		Starting,

		/// <summary>
		///     The server is running
		/// </summary>
		Running,

		/// <summary>
		///     The server is shutting down
		/// </summary>
		Stopping
	}
}