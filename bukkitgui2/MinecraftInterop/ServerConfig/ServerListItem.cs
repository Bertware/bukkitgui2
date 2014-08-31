// ServerListItem.cs in bukkitgui2/bukkitgui2
// Created 2014/08/28
// ©Bertware, visit http://bertware.net

using Jayrock.Json;
using Jayrock.Json.Conversion;

namespace Net.Bertware.Bukkitgui2.MinecraftInterop.ServerConfig
{
	/// <summary>
	///     An item in a server list (Whitelist, Banlist, Ipbanlist or Oplist) for the Json file format introduced in minecraft
	///     1.7.9
	/// </summary>
	/// <remarks>
	///     Only for Minecraft 1.7.9+
	///     Some fields are for specific lists only.
	/// </remarks>
	public class ServerListItem
	{
		/// <summary>
		///     The name of the player this item applies to
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		///     The Ip this item applies to
		/// </summary>
		public string Ip { get; private set; }

		/// <summary>
		///     The Uuid of the player this item applies to
		/// </summary>
		public string Uuid { get; private set; }

		/// <summary>
		///     The permission level of an operator, only available for the ops file
		/// </summary>
		public int OpLevel { get; private set; }

		/// <summary>
		///     The date a player was banned, only available for a ban file
		/// </summary>
		public string Created { get; private set; }

		/// <summary>
		///     The instance who ordered this ban, only available for a ban file
		/// </summary>
		public string Source { get; private set; }

		/// <summary>
		///     The expiration for a ban, only available for a ban file
		/// </summary>
		public string Expires { get; private set; }

		/// <summary>
		///     The reason for a ban, only available for a ban file
		/// </summary>
		public string Reason { get; private set; }

		/// <summary>
		///     Create an item from json code
		/// </summary>
		/// <param name="jsonString">the json code to parse</param>
		public ServerListItem(string jsonString)
		{
			JsonObject jsonObject = JsonConvert.Import<JsonObject>(jsonString);
			if (jsonObject.Contains("name")) Name = jsonObject["name"].ToString();
			if (jsonObject.Contains("ip")) Ip = jsonObject["ip"].ToString();
			if (jsonObject.Contains("uuid")) Uuid = jsonObject["uuid"].ToString();
			if (jsonObject.Contains("level")) OpLevel = int.Parse(jsonObject["level"].ToString());
			if (jsonObject.Contains("created")) Created = jsonObject["created"].ToString();
			if (jsonObject.Contains("source")) Source = jsonObject["source"].ToString();
			if (jsonObject.Contains("expires")) Expires = jsonObject["expires"].ToString();
			if (jsonObject.Contains("reason")) Reason = jsonObject["reason"].ToString();
		}

		/// <summary>
		///     Create an item from json code
		/// </summary>
		/// <param name="jsonObject">the json object to parse</param>
		public ServerListItem(JsonObject jsonObject)
		{
			if (jsonObject.Contains("name")) Name = jsonObject["name"].ToString();
			if (jsonObject.Contains("ip")) Ip = jsonObject["ip"].ToString();
			if (jsonObject.Contains("uuid")) Uuid = jsonObject["uuid"].ToString();
			if (jsonObject.Contains("level")) OpLevel = int.Parse(jsonObject["level"].ToString());
			if (jsonObject.Contains("created")) Created = jsonObject["created"].ToString();
			if (jsonObject.Contains("source")) Source = jsonObject["source"].ToString();
			if (jsonObject.Contains("expires")) Expires = jsonObject["expires"].ToString();
			if (jsonObject.Contains("reason")) Reason = jsonObject["reason"].ToString();
		}
	}
}