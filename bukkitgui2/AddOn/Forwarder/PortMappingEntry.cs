using System;

namespace Net.Bertware.Bukkitgui2.AddOn.Forwarder
{
	public class PortMappingEntry
	{
		public uint Port;
		public string Ip;
		public string Name;

		public UPnP.Protocol Protocol;

		public PortMappingEntry()
		{
		}

		public PortMappingEntry(uint port, string ip, string name, UPnP.Protocol protocol)
		{
			try
			{
				Port = port;
				Ip = ip;
				Name = name;
				Protocol = protocol;
			}
			catch (Exception)
			{
				throw new InvalidCastException("Couldn't create portmapping entry");
			}
		}

		public PortMappingEntry(uint port, string ip, string name, string protocol)
		{
			try
			{
				Port = port;
				Ip = ip;
				Name = name;
				if (protocol.ToLower().Contains("udp"))
					Protocol = UPnP.Protocol.UDP;
				else
					Protocol = UPnP.Protocol.TCP;
			}
			catch (Exception)
			{
				throw new InvalidCastException("Couldn't create portmapping entry");
			}
		}

		public void AddToMapping()
		{
			UPnP.ApplyForward(this);	
		}

		public void RemoveFromMapping()
		{
			UPnP.Remove(Convert.ToInt32(this.Port),this.Protocol);
		}
	}
}