// JsonApiV2.cs in bukkitgui2/JsonApiConnector
// Created 2014/09/05
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Threading;

namespace JsonApiConnector
{
	internal class JsonApiV2 : IJsonApi
	{
		// TODO: implement API2
		// http://mcjsonapi.com/#JSONAPI-Key-Format

		private readonly String _username;
		private readonly String _password;
		private readonly String _host;
		private readonly UInt16 _port;

		private bool _listening;
		private const string ErrPrefix = "!!! ERROR: ";

		public JsonApiV2(string username, string password, string host, ushort port)
		{
			_username = username;
			_password = password;
			_host = host;
			_port = port;
		}

		public void ReadConsoleStream()
		{
			throw new NotImplementedException();
		}

		public void SendConsoleCommand(string command)
		{
			throw new NotImplementedException();
		}

		public string CreateKey(string method)
		{
			throw new NotImplementedException();
		}

		public bool IsListening()
		{
			throw new NotImplementedException();
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