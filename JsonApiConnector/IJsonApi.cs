using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JsonApiConnector
{
	interface IJsonApi
	{
		
		void ReadConsoleStream();

		void SendConsoleCommand(string command);

		string CreateKey(string method);

		Boolean IsListening();
	}
}
