// ForwarderTab.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using Microsoft.VisualBasic;
using Net.Bertware.Bukkitgui2.Core;
using Net.Bertware.Bukkitgui2.Core.Logging;

namespace Net.Bertware.Bukkitgui2.AddOn.Forwarder
{
	public partial class ForwarderTab : MetroUserControl, IAddonTab
	{
		public ForwarderTab()
		{
			InitializeComponent();
			MappingUpdateReceived += Displaymapping;
			PortForwardApplied += UpdateMappingAsync;
			Load += PortForwarder_Load;
		}

		public IAddon ParentAddon { get; set; }


		public event MappingUpdateReceivedEventHandler MappingUpdateReceived;

		public delegate void MappingUpdateReceivedEventHandler(List<PortMappingEntry> mapping);

		public event PortForwardAppliedEventHandler PortForwardApplied;

		public delegate void PortForwardAppliedEventHandler();

		public UPnP LastMapping;

		private void PortForwarder_Load(object sender, EventArgs e)
		{
			if (!available())
			{
				MetroMessageBox.Show(Application.OpenForms[0],
					Locale.Tr("Port forwarding isn't available") + Constants.vbCrLf +
					Locale.Tr("Your network device (router) doesn't support UPnP"),
					Locale.Tr("Port forwarding unavailable"), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			TxtIp.Text = UPnP.LocalIp();
			CBProtocol.SelectedIndex = 0;

			UpdateMappingAsync();
		}


		private void UpdateMappingAsync()
		{
			if (InvokeRequired)
			{
				Invoke((MethodInvoker) (UpdateMappingAsync));
			}
			else
			{
				BtnAdd.Enabled = false;
				BtnRefresh.Enabled = false;
				Thread t = new Thread((() => GetMaps()));
				t.Start();

				// this.lblStatus.Text = "Loading info. This could take a while...";
			}
		}

		private void Displaymapping(List<PortMappingEntry> mapping)
		{
			if (InvokeRequired)
			{
				Invoke((MethodInvoker) (() => Displaymapping(mapping)));
			}
			else
			{
				slvPortMappings.Items.Clear();
				foreach (PortMappingEntry entry in mapping)
				{
					string[] content =
					{
						entry.Name,
						entry.Ip,
						entry.Port.ToString(),
						entry.Protocol.ToString()
					};
					ListViewItem lvi = new ListViewItem(content
						) {Tag = entry.Port};
					slvPortMappings.Items.Add(lvi);
				}
				BtnAdd.Enabled = true;
				BtnRefresh.Enabled = true;
				Cursor = Cursors.Default;
				// this.lblStatus.Text = "idle";
			}
		}


		private void BtnAdd_Click(object sender, EventArgs e)
		{
			UPnP.Protocol protocol;
			if (CBProtocol.SelectedIndex == 1)
				protocol = UPnP.Protocol.UDP;
			else
				protocol = UPnP.Protocol.TCP;
			if (!Regex.IsMatch(TxtIp.Text, "(\\d{1,3}\\.){3}\\d{1,3}"))
			{
				MetroMessageBox.Show(Application.OpenForms[0],
					Locale.Tr("The IP address you entered is invalid. It should be something like for example 192.168.1.2"),
					Locale.Tr("Invalid inpunt"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			Forward(TxtName.Text, Convert.ToInt16(NumPort.Value), TxtIp.Text, protocol);
		}

		private bool available()
		{
			return new UPnP().UPnPEnabled;
		}

		private bool Forward(string name, int port, string ip, UPnP.Protocol protocol = UPnP.Protocol.TCP, bool @async = true)
		{
			try
			{
				Cursor = Cursors.WaitCursor;
				// lblStatus.Text = "adding port forward...";
				if (LastMapping == null)
					LastMapping = new UPnP();
				if (LastMapping.Exists(port, protocol))
				{
					MetroMessageBox.Show(Application.OpenForms[0], Locale.Tr("This port is aLocale.Tready forwarded"), Locale.Tr("Port aLocale.Tready in use"),
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);
					return false;
					//aLocale.Tready in use
				}
				if (!@async)
				{
					LastMapping.Add(ip, port, protocol, name);
				}
				else
				{
					Thread t = new Thread((() => ApplyForward(new PortForwardInfo(name, port, ip, protocol))));
					t.Start();
				}
				return true;
			}
			catch (Exception ex)
			{
				Logger.Log(LogLevel.Warning, "PortForwarder", "Couldn't forward ports", ex.InnerException.Message);
				MessageBox.Show(
					Locale.Tr("This port couldn't be forwarded. Something went wrong while communicating with your router"),
					Locale.Tr("Can't forward"), MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		private bool Forward(string name, int portStart, int portEnd, string ip)
		{
			bool success = true;
			int port = portStart;
			while (port < portEnd)
			{
				success = success & Forward(name, port, ip);
				port++;
			}
			return success;
		}

		private List<PortMappingEntry> GetMaps()
		{
			try
			{
				UPnP pnp = new UPnP();
				LastMapping = pnp;

				List<PortMappingEntry> mapping = pnp.GetMapping();
				if (MappingUpdateReceived != null)
				{
					MappingUpdateReceived(mapping);
				}
				return mapping;
			}
			catch (Exception ex)
			{
				Logger.Log(LogLevel.Warning, "PortForwarder", "Error while loading mapping: " + ex.Message);
				if (MappingUpdateReceived != null)
				{
					MappingUpdateReceived(new List<PortMappingEntry>());
				}
				return new List<PortMappingEntry>();
			}
		}

		private void ApplyForward(PortForwardInfo fwi)
		{
			try
			{
				LastMapping.Add(fwi.Ip, fwi.Port, fwi.Protocol, fwi.Name);
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