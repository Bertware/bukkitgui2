using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using Bukkitgui2.Core;
using Bukkitgui2.Core.Logging;
using Bukkitgui2.MinecraftServers;

namespace Bukkitgui2.MinecraftInterop.ProcessHandler
{
	/// <summary>
	///     The server handler for a local server. As soon as the StartServer() routine is called, this class will take over
	///     and run the server + send output.
	///     Events will trigger all further required actions
	/// </summary>
	internal static class ProcessHandler
	{
		public static Process ServerProcess { get; private set; }
		public static IMinecraftServer Server { get; private set; }
		public static Boolean IsRunning { get; private set; }

		public delegate void ServerStatusEvent();

		/// <summary>
		///     This event is raised before the server is going to start
		/// </summary>
		public static event ServerStatusEvent ServerStarting;

		private static void RaiseServerStarting()
		{
			ServerStatusEvent handler = ServerStarting;
			if (handler != null)
			{
				handler();
			}
		}

		/// <summary>
		///     This event is raised after the server has been started
		/// </summary>
		public static event ServerStatusEvent ServerStarted;

		private static void RaiseServerStarted()
		{
			ServerStatusEvent handler = ServerStarted;
			if (handler != null)
			{
				handler();
			}
		}

		/// <summary>
		///     This event is raised when the server starts to shutdown
		/// </summary>
		public static event ServerStatusEvent ServerStopping;

		private static void RaiseServerStopping()
		{
			ServerStatusEvent handler = ServerStopping;
			if (handler != null)
			{
				handler();
			}
		}

		/// <summary>
		///     This event is raised after the server has stopped
		/// </summary>
		public static event ServerStatusEvent ServerStopped;

		private static void RaiseServerStopped()
		{
			ServerStatusEvent handler = ServerStopped;
			if (handler != null)
			{
				handler();
			}
		}

		/// <summary>
		///     This event is raised if the server stopped, while the usual output ("stopping the server") wasn't detected. Could
		///     be a crash!
		/// </summary>
		public static event ServerStatusEvent UnexpectedServerStop;

		private static void RaiseUnexpectedServerStop()
		{
			ServerStatusEvent handler = UnexpectedServerStop;
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
		public static Boolean StartServer(string executable, string parameters, IMinecraftServer server, string serverDir = "")
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
					}
			};
			ServerProcess.EnableRaisingEvents = true;
			ServerProcess.Start();
			ServerProcess.Exited += HandleStop;

			StartThreads();

			IsRunning = true;
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
			ServerProcess.Exited -= HandleStop;
			StopThreads();
			IsRunning = false;
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
					OutputHandler.MinecraftOutputHandler.HandleOutput(Server, output);
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
					OutputHandler.MinecraftOutputHandler.HandleOutput(Server, output);
				}
			}
		}

		public static Boolean SendInput(string text)
		{
			ServerProcess.StandardInput.WriteLine(text);
			return true;
		}
	}
}