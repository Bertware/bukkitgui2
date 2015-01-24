// JsonApiConnector.cs in bukkitgui2/JsonApiConnector
// Created 2014/02/05
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Linq;
using System.Reflection;

namespace JsonApiConnector
{
    internal class JsonApiConnector
    {
        // variables with default jsonapi settings
        private String _username = "admin";
        private String _password = "changeme";
        private String _salt = "";
        private String _host = "127.0.0.1";
        private UInt16 _port = 20059;
        private bool _filter;

        internal IJsonApi Api;

        public Boolean ShowConsole = true;
        private const char Splitter = '=';


        private static JsonApiConnector _reference;

        public delegate void OutputReceivedEventHandler(string text);

        /// <summary>
        ///     Raised when any output is received
        /// </summary>
        public event OutputReceivedEventHandler OutputReceived;

        protected virtual void OnOutputReceived(string text)
        {
            OutputReceivedEventHandler handler = OutputReceived;
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
            _reference = this;
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
                    String key = "";
                    String value = "";
                    if (args[i].Contains(Splitter))
                    {
                        key = args[i].Split(Splitter)[0];
                        value = args[i].Split(Splitter)[1];
                    }
                    else
                    {
                        key = args[i];
                    }

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
                        case "-filter":
                            _filter = true;
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
                        Api = new JsonApiV1(_username, _password, _salt, _host, _port, _filter);
                        break;
                    default:
                        Api = new JsonApiV2(_username, _password, _host, _port, _filter);
                        break;
                }
            }
        }

        /// <summary>
        ///     print a help message
        /// </summary>
        public static void PrintUsage()
        {
            Console.WriteLine();
            Console.WriteLine("JsonApi Connector " + Assembly.GetExecutingAssembly().GetName().Version);
            Console.WriteLine("Built for JsonApi Api v1/v2");
            Console.WriteLine();
            Console.WriteLine("Usage:");
            Console.WriteLine(Assembly.GetExecutingAssembly().GetName().Name +
                              " -u=<username> -p=<password> -s=<salt> -host=<ip or hostname> -port=<port> [-filter] [-api=<version>]");
            Console.WriteLine();
            Console.WriteLine("Username: JsonApi username as set in the jsonapi config");
            Console.WriteLine("Password: JsonApi password as set in the jsonapi config");
            Console.WriteLine("Salt: JsonApi salt as set in the jsonapi config (api v1 only)");
            Console.WriteLine("Ip/Hostname: Ip or hostname to the server running the jsonapi plugin");
            Console.WriteLine("Port: The port used by JsonApi, as set in the JsonApi config.");
            Console.WriteLine(
                "Filter: Optional. If set, JsonApi [command request] and 'remote user' output will be hidden");
            Console.WriteLine("Api: Optional. The api version to use. Default is 2");
            Console.WriteLine();
            Console.WriteLine(
                "Note: (Only for jsonapi v1) You need to forward the port, port+1 and port+2 for all functions to work (due to JsonApi requirements)");
            Console.WriteLine();
            Console.WriteLine("Press a key...");
            Console.ReadLine();
        }

        public void Connect()
        {
            Api.Connect();
        }

        public void Disconnect()
        {
            Api.Disconnect();
        }

        /// <summary>
        ///     Handle output from an API and forward it
        /// </summary>
        /// <param name="text">text output</param>
        public static void HandleOutput(string text)
        {
            _reference.OnOutputReceived(text);
        }
    }
}