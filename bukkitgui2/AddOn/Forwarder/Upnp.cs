// Upnp.cs in bukkitgui2/bukkitgui2
// Created 2014/09/09
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using NATUPNPLib;
using Net.Bertware.Bukkitgui2.Core.Logging;

public class UPnP : IDisposable
{
	private readonly UPnPNAT _upnpnat;
	private IStaticPortMappingCollection _staticMapping;

	private IDynamicPortMappingCollection _dynamicMapping;
	private bool _staticEnabled = true;

	private bool _dynamicEnabled = true;

	/// <summary>
	///     The different supported protocols
	/// </summary>
	/// <remarks></remarks>
	public enum Protocol
	{
		/// <summary>
		///     Transmission Control Protocol
		/// </summary>
		/// <remarks></remarks>
		TCP,

		/// <summary>
		///     User Datagram Protocol
		/// </summary>
		/// <remarks></remarks>
		UDP
	}

	/// <summary>
	///     Returns if UPnP is enabled.
	/// </summary>
	/// <value></value>
	/// <returns></returns>
	/// <remarks></remarks>
	public bool UPnPEnabled
	{
		get { return _staticEnabled || _dynamicEnabled; }
	}

	/// <summary>
	///     The UPnP Managed Class
	/// </summary>
	/// <remarks></remarks>
	public UPnP()
	{
		//Create the new NAT Class
		_upnpnat = new UPnPNAT();

		//generate the static mappings
		GetStaticMappings();
		GetDynamicMappings();
	}

	/// <summary>
	///     Returns all static port mappings
	/// </summary>
	/// <remarks></remarks>
	private void GetStaticMappings()
	{
		try
		{
			_staticMapping = _upnpnat.StaticPortMappingCollection;
		}
		catch (NotImplementedException)
		{
			_staticEnabled = false;
		}
	}

	/// <summary>
	///     Returns all dynamic port mappings
	/// </summary>
	/// <remarks></remarks>
	private void GetDynamicMappings()
	{
		try
		{
			_dynamicMapping = _upnpnat.DynamicPortMappingCollection;
		}
		catch (NotImplementedException)
		{
			_dynamicEnabled = false;
		}
	}

	/// <summary>
	///     Adds a port mapping to the UPnP enabled device.
	/// </summary>
	/// <param name="localIp">The local IP address to map to.</param>
	/// <param name="port">The port to forward.</param>
	/// <param name="prot">The protocol of the port [TCP/UDP]</param>
	/// <param name="desc">A small description of the port.</param>
	/// <exception cref="ApplicationException">This exception is thrown when UPnP is disabled.</exception>
	/// <exception cref="ObjectDisposedException">This exception is thrown when this class has been disposed.</exception>
	/// <exception cref="ArgumentException">This exception is thrown when any of the supplied arguments are invalid.</exception>
	/// <remarks></remarks>
	public void Add(string localIp, int port, Protocol prot, string desc)
	{
		// Begin utilizing
		if (Exists(port, prot))
			throw new ArgumentException("This mapping aLocale.Tready exists!", "Port;Protocol");

		// Check
		if (!IsPrivateIp(localIp))
			throw new ArgumentException("This is not a local IP address!", "localIp");

		// Final check!
		if (!_staticEnabled)
			throw new ApplicationException("UPnP is not enabled, or there was an error with UPnP Initialization.");

		// Okay, continue on
		_staticMapping.Add(port, prot.ToString(), port, localIp, true, desc);
	}

	/// <summary>
	///     Removes a port mapping from the UPnP enabled device.
	/// </summary>
	/// <param name="port">The port to remove.</param>
	/// <param name="protocol">The protocol of the port [TCP/UDP]</param>
	/// <exception cref="ApplicationException">This exception is thrown when UPnP is disabled.</exception>
	/// <exception cref="ObjectDisposedException">This exception is thrown when this class has been disposed.</exception>
	/// <exception cref="ArgumentException">This exception is thrown when the port [or protocol] is invalid.</exception>
	/// <remarks></remarks>
	public void Remove(int port, Protocol protocol)
	{
		// Begin utilizing
		if (!Exists(port, protocol))
			throw new ArgumentException("This mapping doesn't exist!", "Port;Protocol");

		// Final check!
		if (!_staticEnabled)
			throw new ApplicationException("UPnP is not enabled, or there was an error with UPnP Initialization.");

		// Okay, continue on
		_staticMapping.Remove(port, protocol.ToString());
	}

	/// <summary>
	///     Checks to see if a port exists in the mapping.
	/// </summary>
	/// <param name="port">The port to check.</param>
	/// <param name="protocol">The protocol of the port [TCP/UDP]</param>
	/// <exception cref="ApplicationException">This exception is thrown when UPnP is disabled.</exception>
	/// <exception cref="ObjectDisposedException">This exception is thrown when this class has been disposed.</exception>
	/// <exception cref="ArgumentException">This exception is thrown when the port [or protocol] is invalid.</exception>
	/// <remarks></remarks>
	public bool Exists(long port, Protocol protocol)
	{
		try
		{
			// Final check!
			if (!_staticEnabled)
				throw new ApplicationException("UPnP is not enabled, or there was an error with UPnP Initialization.");

			Logger.Log(LogLevel.Info, "uPnP", "Checking if port is in use...");
			// Begin checking

			foreach (IStaticPortMapping mapping in _staticMapping)
			{
				// Compare
				if (mapping.ExternalPort == port && mapping.Protocol.ToLower().Equals(protocol.ToString().ToLower()))
					return true;
			}
			Logger.Log(LogLevel.Info, "uPnP", "ok: Port is not in use", port + ":" + protocol);
			//Nothing!
			return false;
		}
		catch (Exception ex)
		{
			Logger.Log(LogLevel.Warning, "uPnP", "Couldn't check if port mapping exists", ex.Message);
			throw new Exception("Couldn't check if mapping exists!", ex);
		}
	}

	/// <summary>
	///     Attempts to locate the local IP address of this computer.
	/// </summary>
	/// <returns>String</returns>
	/// <remarks></remarks>
	public static string LocalIp()
	{
		IPHostEntry ipList = Dns.GetHostEntry(Dns.GetHostName());
		foreach (IPAddress ipAddress in ipList.AddressList)
		{
			if ((ipAddress.AddressFamily == AddressFamily.InterNetwork) && IsPrivateIp(ipAddress.ToString()))
			{
				return ipAddress.ToString();
			}
		}
		return string.Empty;
	}

	/// <summary>
	///     Checks to see if an IP address is a local IP address.
	/// </summary>
	/// <param name="checkIp">The IP address to check.</param>
	/// <returns>Boolean</returns>
	/// <remarks></remarks>
	private static bool IsPrivateIp(string checkIp)
	{
		int quad1 = Convert.ToInt32(checkIp.Substring(0, checkIp.IndexOf('.')));
		int quad2 = Convert.ToInt32(checkIp.Substring(checkIp.IndexOf('.') + 1).Substring(0, checkIp.IndexOf('.')));
		switch (quad1)
		{
			case 10:
				return true;
			case 172:
				if (quad2 >= 16 & quad2 <= 31)
					return true;
				break;
			case 192:
				if (quad2 == 168)
					return true;
				break;
		}
		return false;
	}

	/// <summary>
	///     Disposes of the UPnP class
	/// </summary>
	/// <param name="disposing">True or False makes no difference.</param>
	/// <remarks></remarks>
	protected virtual void Dispose(bool disposing)
	{
		Marshal.ReleaseComObject(_staticMapping);
		Marshal.ReleaseComObject(_dynamicMapping);
		Marshal.ReleaseComObject(_upnpnat);
	}

	/// <summary>
	///     Dispose!
	/// </summary>
	/// <remarks></remarks>
	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	/// <summary>
	///     Prints out some debugging information to use.
	/// </summary>
	/// <returns></returns>
	/// <remarks></remarks>
	public List<PortMappingEntry> GetMapping()
	{
		// Return list
		List<PortMappingEntry> l = new List<PortMappingEntry>();

		// Loop through all the data after a check
		if (_staticEnabled)
		{
			foreach (IStaticPortMapping mapping in _staticMapping)
			{
				try
				{
					l.Add(new PortMappingEntry(Convert.ToUInt32(mapping.InternalPort), mapping.InternalClient, mapping.Description,
						mapping.Protocol));
				}
				catch (Exception ex)
				{
					Logger.Log(LogLevel.Warning, "uPnP", "Couldn't load mapping: " + ex.Message);
				}
			}
		}

		// Give it back
		return l;
	}
}

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
}