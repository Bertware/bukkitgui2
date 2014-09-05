using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JsonApiConnector
{
	class JsonApiV2 : IJsonApi
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
	}
}
