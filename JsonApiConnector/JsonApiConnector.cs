// JsonApiConnector.cs in bukkitgui2/JsonApiConnector
// Created 2014/02/05
// Last edited at 2014/05/17 19:43
// ©Bertware, visit http://bertware.net

using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Jayrock.Json;
using Jayrock.Json.Conversion;

namespace JsonApiConnector
{
	internal class JsonApiConnector
	{
		private String _username;
		private String _password;
		private String _salt;
		private String _host;
		private UInt16 _port;

		private Boolean _listening;

		public Boolean ShowConsole = true;
		private const char Splitter = '=';
		private const string ErrPrefix = "!!! ERROR: ";


		public delegate void OutputReceivedEventHandler(string text);

		/// <summary>
		///     Raised when any output is received
		/// </summary>
		public event OutputReceivedEventHandler OutputReceived;

		public JsonApiConnector(string[] args)
		{
			//Arguments:
			// -u=username
			// -p=password
			// -host=[ip or hostname]
			// -port=20060

			LoadArguments(args);
		}

		private void LoadArguments(string[] args)
		{
			for (byte i = 0; i < args.Length; i++)
			{
				try
				{
					String key = args[i].Split(Splitter)[0];
					String value = args[i].Split(Splitter)[1];
					switch (key)
					{
						case "-u":
							_username = value;
							break;
						case "-p":
							_password = value;
							break;
						case "-s":
							_salt = value;
							break;
						case "-host":
							_host = value;
							break;
						case "-port":
							_port = Convert.ToUInt16(value);
							break;
						case "-background":
							ShowConsole = false;
							break;
						default:
							throw new ArgumentException();
					}
				}
				catch (Exception)
				{
					const string usage =
						"Usage: JsonApiConnector.exe -u=[username] -p=[password] -s=[salt] -host=[ip or hostname] -port=[port]";
					OutputReceived(usage);
				}
			}
		}

		public void Connect()
		{
			_listening = true;
			Thread t = new Thread(ReadConsoleStream) {Name = "ReadConsoleStream", IsBackground = true};
			t.Start();
		}

		public void DisConnect()
		{
			_listening = false;
		}

		private void ReadConsoleStream()
		{
			Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			try
			{
				sock.Connect(_host, _port + 1);
			}
			catch (Exception connectException)
			{
				OutputReceived(ErrPrefix + "Couldn't connect to JsonApi stream:" + connectException.Message);
			}

			if (sock.Connected)
			{
				string key = CreateKey("console");
				NetworkStream stream = new NetworkStream(sock);
				StreamWriter sw = new StreamWriter(stream);
				sw.WriteLine("/api/subscribe?source=console&key=" + key);
				sw.Flush();
				StreamReader sr = new StreamReader(stream);


				while (_listening && sock.Connected && stream.CanRead)
				{
					string l = "";
					try
					{
						while (_listening && sock.Connected && stream.CanRead && sr.EndOfStream)
						{
							Thread.Sleep(100);
						}
						if (_listening && sock.Connected) l = sr.ReadLine();
					}
					catch (Exception readex)
					{
						Debug.WriteLine("exception at run_connection_receive, while reading from networkstream " + readex.Message);
						//don't flag as critical error
					}

					if (!string.IsNullOrEmpty(l) && l.Contains("{") & l.Contains(":") & l.Contains("}"))
					{
						l = new JsonApiStreamResult(l).Line;
						if (!l.Contains("[API Call]")) OutputReceived(l.TrimEnd(Environment.NewLine.ToCharArray()));
					}

					Thread.Sleep(10);
				}
			}
			OutputReceived(ErrPrefix + "Disconnected");
			if (sock.Connected) sock.Close();
			_listening = false;
		}

		public void SendConsoleCommand(string command)
		{
			new WebClient().DownloadString("http://" + _host + ":" + _port + "/api/call?method=runConsoleCommand&args=%5B%22" +
			                               command + "%22%5D&key=" + CreateKey("runConsoleCommand"));
		}

		private readonly HashAlgorithm _hashAlgorithm = SHA256.Create();

		internal string CreateKey(string method)
		{
			var data = Encoding.ASCII.GetBytes(_username + method + _password + _salt);
			var hash = _hashAlgorithm.ComputeHash(data);

			var result = new char[hash.Length*2];

			for (int i = 0; i < hash.Length; ++i)
			{
				byte b = (byte) (hash[i] >> 4);
				result[i*2] = (char) (b > 9 ? b + 0x57 : b + 0x30);

				b = (byte) (hash[i] & 0xF);
				result[i*2 + 1] = (char) (b > 9 ? b + 0x57 : b + 0x30);
			}

			return new string(result);
		}

		public Boolean IsListening()
		{
			return _listening;
		}
	}

	public class JsonApiStreamResult
	{
		public string Result;
		public string Source;
		public string Time = "";

		public string Line = "";

		public JsonApiStreamResult(string text)
		{
			//JsonObject obj = JsonConvert.Import(text);
			JsonObject resultJsonObject = JsonConvert.Import(typeof (JsonObject), text) as JsonObject;

			if (resultJsonObject == null) return;

			Result = resultJsonObject["result"].ToString();
			Source = resultJsonObject["source"].ToString();

			if (Result != "success") return;

			JsonObject outputJsonObject =
				JsonConvert.Import(typeof (JsonObject), resultJsonObject["success"].ToString()) as JsonObject;

			if (outputJsonObject == null) return;

			Time = outputJsonObject["time"].ToString();
			Line = outputJsonObject["line"].ToString();
		}
	}
}