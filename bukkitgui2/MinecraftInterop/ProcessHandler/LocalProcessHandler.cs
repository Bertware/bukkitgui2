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
	/// The server handler for a local server. As soon as the StartServer() routine is called, this class will take over and run the server + send output.
	/// Events will trigger all further required actions
	/// </summary>
	class LocalProcessHandler : IProcessHandler
	{
		private readonly ILogger _logger = Share.Logger;
		
		public Process ServerProcess { get; private set; }
		public IMinecraftServer Server { get; private set; }

		public event EventHandler ServerStarting;
		protected virtual void RaiseServerStarting(EventArgs e)
		{
			EventHandler handler = ServerStarting;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		public event EventHandler ServerStarted;
		protected virtual void RaiseServerStarted(EventArgs e)
		{
			EventHandler handler = ServerStarted;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		public event EventHandler ServerStopping;
		public event EventHandler ServerStopped;
		public event EventHandler UnexpectedServerStop;

		private Boolean _runThreads;
		private Thread _thdReadStdOut;
		private Thread _thdReadStdErr;

		/// <summary>
		/// Start a process, start the threads to read the output and send the output to the correct outputhandler
		/// </summary>
		/// <param name="executable">The executable to run</param>
		/// <param name="parameters">The parameters for the executable</param>
		/// <param name="server">The server that is being ran</param>
		/// <returns></returns>
		public Boolean StartServer(string executable, string parameters, IMinecraftServer server, string serverDir="" )
		{
			if (string.IsNullOrEmpty(executable)) return false;

			Server = server;
			FileInfo exeFileInfo = new FileInfo(executable);

			RaiseServerStarting(new EventArgs());

			if (string.IsNullOrEmpty(serverDir))
			{
				serverDir = Environment.CurrentDirectory;
				FileInfo guiFileInfo = new FileInfo(Share.AssemblyFullName);
				if (guiFileInfo.Directory != null)	serverDir = guiFileInfo.Directory.FullName;
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
						WorkingDirectory = serverDir ,
						StandardErrorEncoding = Encoding.UTF8,
						StandardOutputEncoding = Encoding.UTF8,
						RedirectStandardInput = true,
						RedirectStandardOutput = true,
						RedirectStandardError = true
					}
			};

			ServerProcess.Start();
			
			StartThreads();

			RaiseServerStarted(new EventArgs());
			return true;
		}

		public void StopServer()
		{
			ServerStopping(this, new EventArgs());
		
			StopThreads();

			ServerStopped(this, new EventArgs());
		}

		private void StartThreads()
		{
			_thdReadStdOut = new Thread(ReadStdOut){IsBackground = true,Name = "_thdReadStdOut"};
			_thdReadStdErr = new Thread(ReadStdErr) { IsBackground = true, Name = "_thdReadStdOut" };
			_runThreads = true;
			_thdReadStdOut.Start();
			_thdReadStdErr.Start();

		}

		private void StopThreads()
		{
			_runThreads = false;
		}

		private void ReadStdOut()
		{
			using (StreamReader streamReader = new StreamReader(ServerProcess.StandardOutput.BaseStream))
			{
				while (_runThreads)
				{
					string output = streamReader.ReadLine();
					if (string.IsNullOrEmpty(output)) continue;

					_logger.Log(LogLevel.Debug, "LocalProcessHandler", "StdOut output: " + output);
					OutputHandler.MinecraftOutputHandler.HandleOutput(Server,output);
				}
			}
		}

		private void ReadStdErr()
		{
			using (StreamReader streamReader = new StreamReader(ServerProcess.StandardError.BaseStream))
			{
				while (_runThreads)
				{
					string output = streamReader.ReadLine();
					if (string.IsNullOrEmpty(output)) continue;

					_logger.Log(LogLevel.Debug,"LocalProcessHandler","StdErr output: " + output);
					OutputHandler.MinecraftOutputHandler.HandleOutput(Server, output);
				}
			}
		}

		public Boolean SendInput(string text)
		{
			ServerProcess.StandardInput.WriteLine(text);
			return true;
		}


	}
}
