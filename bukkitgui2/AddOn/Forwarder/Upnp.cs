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
using System.Threading;
using System.Windows.Forms;
using MetroFramework;
using NATUPNPLib;
using Net.Bertware.Bukkitgui2.Core;
using Net.Bertware.Bukkitgui2.Core.Logging;

namespace Net.Bertware.Bukkitgui2.AddOn.Forwarder
{
    public class UPnP : IDisposable
    {
        private readonly UPnPNAT _upnpnat;
        private static UPnP _lastInstance;

        private IStaticPortMappingCollection _staticMapping;

        private bool _staticEnabled = true;


        public static event MappingUpdateReceivedEventHandler MappingUpdateReceived;

        public delegate void MappingUpdateReceivedEventHandler(List<PortMappingEntry> mapping);

        public static event PortForwardAppliedEventHandler PortForwardApplied;

        public delegate void PortForwardAppliedEventHandler();

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
        public static bool UpnpEnabled
        {
            get
            {
                if (_lastInstance == null) _lastInstance = new UPnP();
                return _lastInstance._staticEnabled;
            }
        }

        /// <summary>
        ///     The UPnP Managed Class
        /// </summary>
        /// <remarks></remarks>
        public UPnP()
        {
            _lastInstance = this;
            //Create the new NAT Class
            _upnpnat = new UPnPNAT();

            //generate the static mappings
            GetStaticMappings();
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
                if (_staticMapping == null) _staticEnabled = false;
            }
            catch (Exception)
            {
                _staticEnabled = false;
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
        private void Add(string localIp, uint port, Protocol prot, string desc)
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
            _staticMapping.Add(Convert.ToInt32(port), prot.ToString(), Convert.ToInt32(port), localIp, true, desc);
        }

        /// <summary>
        ///     Adds a port mapping to the UPnP enabled device.
        /// </summary>
        /// <param name="entry">The PortMappingEntry to add</param>
        /// <exception cref="ApplicationException">This exception is thrown when UPnP is disabled.</exception>
        /// <exception cref="ObjectDisposedException">This exception is thrown when this class has been disposed.</exception>
        /// <exception cref="ArgumentException">This exception is thrown when any of the supplied arguments are invalid.</exception>
        /// <remarks></remarks>
        public void Add(PortMappingEntry entry)
        {
            Add(entry.Ip, entry.Port, entry.Protocol, entry.Name);
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
        public static void Remove(int port, Protocol protocol)
        {
            if (_lastInstance == null) _lastInstance = new UPnP();


            if (!UpnpEnabled)
                throw new ApplicationException("UPnP is not enabled, or there was an error with UPnP Initialization.");

            // Begin utilizing
            if (!_lastInstance.Exists(port, protocol))
                throw new ArgumentException("This mapping doesn't exist!", "Port;Protocol");

            // Okay, continue on
            _lastInstance._staticMapping.Remove(port, protocol.ToString());
            GetMapping(); //refresh
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
                    throw new ApplicationException(
                        "UPnP is not enabled, or there was an error with UPnP Initialization.");

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
            try
            {


                int quad1 = Convert.ToInt32(checkIp.Substring(0, checkIp.IndexOf('.')));
                int quad2 =
                    Convert.ToInt32(checkIp.Substring(checkIp.IndexOf('.') + 1).Substring(0, checkIp.IndexOf('.')));
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
            }
            catch (Exception exception)
            {
                // if something goes wrong, log, and return false
                Logger.Log(LogLevel.Warning, "Upnp","Could not evaluate IP address",exception.Message);
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
        ///     Get a list of all ports in use
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static void GetMapping()
        {
            Thread t = new Thread(GetMappingJob) {Name = "UPnP_GetMappingJob"};
            t.SetApartmentState(ApartmentState.MTA);
            t.Start();
        }

        private static void GetMappingJob()
        {
            try
            {
                if (_lastInstance == null) _lastInstance = new UPnP();

                // Return list
                List<PortMappingEntry> l = new List<PortMappingEntry>();

                // Loop through all the data after a check
                if (!UpnpEnabled || !_lastInstance._staticEnabled || _lastInstance._staticMapping == null) return;

                foreach (IStaticPortMapping mapping in _lastInstance._staticMapping)
                {
                    try
                    {
                        l.Add(new PortMappingEntry(Convert.ToUInt32(mapping.InternalPort), mapping.InternalClient,
                            mapping.Description,
                            mapping.Protocol));
                    }
                    catch (Exception ex)
                    {
                        Logger.Log(LogLevel.Warning, "uPnP", "Couldn't load mapping: " + ex.Message);
                    }
                }

                MappingUpdateReceivedEventHandler handler = MappingUpdateReceived;
                if (handler != null)
                {
                    handler.Invoke(l);
                }
            }
            catch (Exception exception)
            {
                Logger.Log(LogLevel.Warning, "UPnP", "Couldn't get upnp mapping! Probably UPnP is disabled",
                    exception.Message);
                if (_lastInstance != null) _lastInstance._staticEnabled = false; // remember that upnp is disabled
            }
            // No return value, use the event to get the list!
        }

        public static bool Forward(string name, uint port, string ip, Protocol protocol = Protocol.TCP,
            bool @async = true)
        {
            try
            {
                // lblStatus.Text = "adding port forward...";
                if (_lastInstance == null) _lastInstance = new UPnP();

                if (_lastInstance.Exists(port, protocol))
                {
                    MetroMessageBox.Show(Application.OpenForms[0], Locale.Tr("This port is aleady forwarded"),
                        Locale.Tr("Port already in use"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                    //aLocale.Tready in use
                }
                if (!@async)
                {
                    _lastInstance.Add(ip, port, protocol, name);
                }
                else
                {
                    Thread t = new Thread((() => Forward(new PortMappingEntry(port, ip, name, protocol))))
                    {
                        Name = "Foward_" + port
                    };
                    t.SetApartmentState(ApartmentState.MTA);
                    t.Start();
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Warning, "PortForwarder", "Couldn't forward ports", ex.InnerException.Message);
                MetroMessageBox.Show(Application.OpenForms[0],
                    Locale.Tr(
                        "This port couldn't be forwarded. Something went wrong while communicating with your router"),
                    Locale.Tr("Can't forward"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static void Forward(PortMappingEntry fwi)
        {
            try
            {
                _lastInstance.Add(fwi);
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Warning, "PortForwarder", "Error while loading mapping: " + ex.Message);
            }
            if (PortForwardApplied != null)
            {
                PortForwardApplied();
            }
        }
    }
}