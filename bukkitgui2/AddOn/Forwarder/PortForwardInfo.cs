namespace Net.Bertware.Bukkitgui2.AddOn.Forwarder
{
	internal class PortForwardInfo
	{
		public string Name;
		public int Port;
		public string Ip;

		public UPnP.Protocol Protocol = UPnP.Protocol.TCP;

		public PortForwardInfo(string name, int port, string ip, UPnP.Protocol protocol = UPnP.Protocol.TCP)
		{
			Name = name;
			Port = port;
			Ip = ip;
			Protocol = protocol;
		}
	}
}