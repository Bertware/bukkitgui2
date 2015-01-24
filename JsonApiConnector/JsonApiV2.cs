// JsonApiV2.cs in bukkitgui2/JsonApiConnector
// Created 2014/09/05
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace JsonApiConnector
{
    internal class JsonApiV2 : IJsonApi
    {
        // TODO: implement API2 completely
        // http://mcjsonapi.com/#JSONAPI-Key-Format

        private readonly String _username;
        private readonly String _password;
        private readonly String _host;
        private readonly UInt16 _port;
        private readonly bool _filter;

        private bool _listening;
        private const string ErrPrefix = "[CRITICAL][JSONAPI CONNECTOR]";
        private const string LogPrefix = "[INFO][JSONAPI CONNECTOR]";

        public JsonApiV2(string username, string password, string host, ushort port, bool filter = false)
        {
            _username = username;
            _password = password;
            _host = host;
            _port = port;
            _filter = filter;
        }

        public void ReadConsoleStream()
        {
            JsonApiConnector.HandleOutput(LogPrefix + "Connecting to the external server...");
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sock.Connect(_host, _port + 1);
            }
            catch (Exception connectException)
            {
                JsonApiConnector.HandleOutput(ErrPrefix + "Couldn't connect to JsonApi stream:" +
                                              connectException.Message);
            }

            if (sock.Connected)
            {
                NetworkStream stream = new NetworkStream(sock);
                StreamWriter sw = new StreamWriter(stream);
                string request = "/api/2/subscribe?json=" + CreateJsonPayload("console", null, true);
                sw.WriteLine(request);
                sw.Flush();
                StreamReader sr = new StreamReader(stream);
                JsonApiConnector.HandleOutput(LogPrefix + "Connected!");

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
                        Debug.WriteLine("exception at run_connection_receive, while reading from networkstream " +
                                        readex.Message);
                        //don't flag as critical error
                    }

                    if (!string.IsNullOrEmpty(l) && l.Contains("{") & l.Contains(":") & l.Contains("}"))
                    {
                        l = new JsonApiStreamResult(l).Line;
                        if (!_filter ||
                            !Regex.IsMatch(l,
                                "^[^\\]]*\\](:|\\s){0,2}\\[JSONAPI\\]\\s?\\[(api|stream) (call|request)\\]",
                                RegexOptions.IgnoreCase))
                            JsonApiConnector.HandleOutput(l.TrimEnd(Environment.NewLine.ToCharArray()));
                    }

                    Thread.Sleep(10);
                }
            }
            JsonApiConnector.HandleOutput(ErrPrefix + "Disconnected");
            if (sock.Connected) sock.Close();
            _listening = false;
        }


        public void SendConsoleCommand(string command)
        {
            new WebClient().DownloadString("http://" + _host + ":" + _port +
                                           "/api/2/call?json=" +
                                           CreateJsonPayload("server.run_command", new[] {command}));
        }

        private readonly HashAlgorithm _hashAlgorithm = SHA256.Create();

        public string CreateKey(string method)
        {
            byte[] data = Encoding.ASCII.GetBytes(_username + method + _password);

            // Hash (sha-256)
            byte[] hash = _hashAlgorithm.ComputeHash(data);

            char[] result = new char[hash.Length*2];

            for (int i = 0; i < hash.Length; ++i)
            {
                byte b = (byte) (hash[i] >> 4);
                result[i*2] = (char) (b > 9 ? b + 0x57 : b + 0x30);

                b = (byte) (hash[i] & 0xF);
                result[i*2 + 1] = (char) (b > 9 ? b + 0x57 : b + 0x30);
            }

            return new string(result);
        }

        private string CreateJsonPayload(string method, IEnumerable<string> args, bool consoleShowPrevious = false)
        {
            string json = "[{\"name\": \"" + method + "\",\"key\": \"" + CreateKey(method) + "\",\"username\": \"" +
                          _username +
                          "\",";

            if (args != null)
            {
                json += "\"arguments\": [";
                foreach (string s in args)
                {
                    int i;
                    if (int.TryParse(s, out i))
                    {
                        // int
                        json += s + " ";
                    }
                    else
                    {
                        // string
                        json += '"' + s + '"' + ' ';
                    }
                }
                json += "],";
            }

            if (consoleShowPrevious) json += "\"show_previous\": true";
            json += "}]";
            return json;
        }


        public Boolean IsListening()
        {
            return _listening;
        }

        public void Connect()
        {
            _listening = true;
            Thread t = new Thread(ReadConsoleStream) {Name = "ReadConsoleStream", IsBackground = true};
            t.Start();
        }

        public void Disconnect()
        {
            _listening = false;
        }
    }
}