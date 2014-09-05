// JsonApiConnector.cs in bukkitgui2/JsonApiConnector
// Created 2014/02/05
// Last edited at 2014/05/17 19:43
// ©Bertware, visit http://bertware.net

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace JsonApiConnector
{
    internal class JsonApiConnector
    {
        private String _username;
        private String _password;
        private String _salt;
        private String _host;
        private UInt16 _port;

	    private IJsonApi api;

        public Boolean ShowConsole = true;
        private const char Splitter = '=';


	    private static JsonApiConnector reference;

        public delegate void OutputReceivedEventHandler(string text);

        /// <summary>
        ///     Raised when any output is received
        /// </summary>
        public event OutputReceivedEventHandler OutputReceived;

	    protected virtual void OnOutputReceived(string text)
	    {
		    var handler = OutputReceived;
		    if (handler != null) handler(text);
	    }

	    public JsonApiConnector(string[] args)
        {
            //Arguments:
            // -u=username
            // -p=password
			// -s=salt (if necessary)
            // -host=[ip or hostname]
            // -port=20060
			// -api=1 (to use old api, default is v2)
	        reference = this;
            LoadArguments(args);
        }

        private void LoadArguments(string[] args)
        {
	        int apiversion = 2;

            if (args.Length < 1 || args.Contains("-help") || args.Contains("/help") || args.Contains("-?") ||
                args.Contains("/?"))
            {
                PrintUsage();
                return;
            }


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
						case "-api=1":
		                    apiversion = 1;
		                    break;
                        default:
                            throw new ArgumentException();
                    }
                }
                catch (Exception)
                {
                    PrintUsage();
                }

	            switch (apiversion)
	            {
					case 1:
						api = new JsonApiV1(_username,_password,_salt,_host,_port);
			            break;
					default:
						api = new JsonApiV2(_username, _password, _host, _port);
			            break;
	            }
            }
        }

        public static void PrintUsage()
        {
            Console.WriteLine();
            Console.WriteLine("JsonApi Connector " + Assembly.GetExecutingAssembly().GetName().Version);
            Console.WriteLine("Built for JsonApi Api v1/v2");
            Console.WriteLine();
            Console.WriteLine("Usage:");
            Console.WriteLine(Assembly.GetExecutingAssembly().GetName().Name +
                              " -u=[username] -p=[password] -s=[salt] -host=[ip or hostname] -port=[port] -api=1");
            Console.WriteLine();
            Console.WriteLine("Username: JsonApi username as set in the jsonapi config");
            Console.WriteLine("Password: JsonApi password as set in the jsonapi config");
            Console.WriteLine("Salt: JsonApi salt as set in the jsonapi config (api v1 only)");
            Console.WriteLine("Ip/Hostname: Ip or hostname to the server running the jsonapi plugin");
            Console.WriteLine("Port: The port used by JsonApi, as set in the JsonApi config.");
			Console.WriteLine("Api: The api version to use. Default is 2");
            Console.WriteLine();
            Console.WriteLine(
                "Note: (Only for jsonapi v1) You need to forward the port, port+1 and port+2 for all functions to work (due to JsonApi requirements)");
            Console.WriteLine();
            Console.WriteLine("Press a key...");
            Console.ReadLine();
        }

        public void Connect()
        {

        }

        public void Disconnect()
        {

        }

	    public static void HandleOutput(string text)
	    {
			reference.OnOutputReceived(text);
	    }

    }
}