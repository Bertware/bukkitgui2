namespace Bukkitgui2.MinecraftServers.Servers
{
	/// <summary>
	/// Default vanilla server. All parsing code is already in the server base
	/// </summary>
	class VanillaServer : MinecraftServerBase
	{
		public override string Name
		{
			get { return "Vanilla"; }
		}

		public override string Site
		{
			get
			{
				return "http://minecraft.net";
			}
		}
	}
}
