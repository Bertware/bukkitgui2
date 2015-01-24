// Program.cs in bukkitgui2/JsonApiConnector
// Created 2014/02/05
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.IO;
using System.Reflection;
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
			// Load embedded DLLs
			AppDomain.CurrentDomain.AssemblyResolve += LoadDll;

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
			while (_connector.Api.IsListening())
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
				_connector.Api.SendConsoleCommand(input);
			}
		}

		private static void ScanStdIn()
		{
			while (ThreadsRunning)
			{
				string input = Console.In.ReadLine();
				_connector.Api.SendConsoleCommand(input);
			}
		}

		public static Assembly LoadDll(object sender, ResolveEventArgs args)
		{
			//Load embedded DLLs

            String resourceName = "Net.Bertware.JsonApiConnector." + new AssemblyName(args.Name).Name + ".dll";
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
	}
}