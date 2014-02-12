using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using Bukkitgui2.Core;
using Bukkitgui2.MinecraftServers;

namespace Bukkitgui2.MinecraftInterop.ProcessHandler
{
	class LocalProcessHandler : IProcessHandler
	{
		public Process ServerProcess { get; private set; }
		public IMinecraftServer Server { get; private set; }


		public event EventHandler ServerStarting;
		public event EventHandler ServerStarted;
		public event EventHandler ServerStopping;
		public event EventHandler ServerStopped;
		public event EventHandler UnexpectedServerStop;

		private Boolean _runThreads;
		private Thread _thdReadStdOut;
		private Thread _thdReadStdErr;

		public LocalProcessHandler(Thread thdReadStdErr)
		{
			_thdReadStdErr = thdReadStdErr;
		}


		public Boolean StartServer(string executable, string parameters, IMinecraftServer server )
		{
			if (string.IsNullOrEmpty(executable)) return false;

			Server = server;

			ServerStarting(this, EventArgs.Empty);

			FileInfo fileInfo = new FileInfo(executable);

			string serverDir = Share.AssemblyFullName;
			if (fileInfo.Directory != null)	serverDir = fileInfo.Directory.FullName;

			ServerProcess = new Process
			{
				StartInfo =
					new ProcessStartInfo
					{
						FileName = fileInfo.FullName,
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
			
			StartThreads();

			ServerStarted(this, EventArgs.Empty);
			return true;
		}

		public void StopServer()
		{
			ServerStopping(this, EventArgs.Empty);
		
			StopThreads();

			ServerStopped(this, EventArgs.Empty);
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
					if (!string.IsNullOrEmpty(output)) OutputHandler.MinecraftOutputHandler.HandleOutput(Server,output);
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
					if (!string.IsNullOrEmpty(output)) OutputHandler.MinecraftOutputHandler.HandleOutput(Server, output);
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
