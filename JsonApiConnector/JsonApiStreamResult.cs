// JsonApiStreamResult.cs in bukkitgui2/JsonApiConnector
// Created 2014/09/05
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using Jayrock.Json;
using Jayrock.Json.Conversion;

namespace Net.Bertware.JsonApiConnector
{
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