// IJsonApi.cs in bukkitgui2/JsonApiConnector
// Created 2014/09/05
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;

namespace JsonApiConnector
{
	internal interface IJsonApi
	{
		void Connect();

		void Disconnect();

		void ReadConsoleStream();

		void SendConsoleCommand(string command);

		string CreateKey(string method);

		Boolean IsListening();
	}
}