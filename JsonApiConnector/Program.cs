using System;
using System.Threading;

namespace JsonApiConnector
{
	/// <summary>
	///     Emulate a local server (standardin,standardout) by connecting to a remote Jsonapi server
	/// </summary>
	internal class Program
	{

		private static JsonApiConnector _connector;
		public static Boolean ThreadsRunning = true;

		private static void Main(string[] args)
		{
			_connector = new JsonApiConnector(args);
			_connector.OutputReceived += TextReceived;

			if (_connector.Console)
			{
				Thread t = new Thread(ScanInput) {Name = "thd_ScanInput", IsBackground = true};
				t.Start();
			} else {
				Thread t = new Thread(ScanStdIn) { Name = "thd_ScanStdIn", IsBackground = true };
				t.Start();
			}
			
		}

		private static void TextReceived(string text)
		{
			Console.Out.WriteLine(text);
		}

		private static void ScanInput()
		{
			while (ThreadsRunning)
			{
				string input = Console.In.ReadLine();
				_connector.SendConsoleCommand(input);
			}
		}

		private static void ScanStdIn()
		{
			while (ThreadsRunning)
			{
				string input = Console.In.ReadLine();
				_connector.SendConsoleCommand(input);
			}

		}

	}

}