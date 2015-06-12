// PortMappingEntry.cs in bukkitgui2/bukkitgui2
// Created 2014/09/13
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

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
			UPnP.Forward(this);
		}

		public void RemoveFromMapping()
		{
			UPnP.Remove(Convert.ToInt32(Port), Protocol);
		}
	}
}