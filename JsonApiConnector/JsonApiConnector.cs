using System;

namespace JsonApiConnector
{


	internal class JsonApiConnector
	{

		private String _username;
		private String _password;
		private String _host;
		private UInt16 _port;
		public Boolean Console=true;
		private const char Splitter = '=';


		public delegate void OutputReceivedEventHandler(string text);
		/// <summary>
		/// Raised when any output is received
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
						case "-host":
							_host = value;
							break;
						case "-port":
							_port = Convert.ToUInt16(value);
							break;
						case "-background":
							Console =false;
							break;

					}

				}
				catch (Exception e)
				{
					Console.WriteLine("!!! Err: can't parse arguments: " + e.Message);
				}
			}
		}

		public void SendConsoleCommand(string command)
		{
			OutputReceived("Command issued: " + command);
		}
	}
}


