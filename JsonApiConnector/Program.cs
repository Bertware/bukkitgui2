// Program.cs in bukkitgui2/JsonApiConnector
// Created 2014/02/05
// Last edited at 2014/05/17 19:43
// ©Bertware, visit http://bertware.net

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
			Thread t;
			if (_connector.ShowConsole)
			{
				t = new Thread(ScanInput) {Name = "thd_ScanInput", IsBackground = true};
				t.Start();
			}
			else
			{
				t = new Thread(ScanStdIn) {Name = "thd_ScanStdIn", IsBackground = true};
				t.Start();
			}
			_connector.Connect();
			while (_connector.IsListening())
			{
				Thread.Sleep(10);
			}
		}

		private static void TextReceived(string text)
		{
			Console.Out.WriteLine(text);
			//Console.WriteLine(text);
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