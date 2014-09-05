using Jayrock.Json;
using Jayrock.Json.Conversion;

namespace JsonApiConnector
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