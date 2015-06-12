// IssuesTab.cs in bukkitgui2/bukkitgui2
// Created 2014/08/31
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MetroFramework.Controls;
using Net.Bertware.Bukkitgui2.AddOn.Console;
using Net.Bertware.Bukkitgui2.MinecraftInterop.OutputHandler;
using Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler;

namespace Net.Bertware.Bukkitgui2.AddOn.Issues
{
	public partial class IssuesTab : MetroUserControl, IAddonTab
	{
		public IssuesTab()
		{
			InitializeComponent();
			MinecraftOutputHandler.WarningMessageReceived += HandleMessage;
			MinecraftOutputHandler.SevereMessageReceived += HandleMessage;
			MinecraftOutputHandler.JavaStackStraceMessageReceived += HandleMessage;
			ProcessHandler.ServerStarted += ClearList;
		}

		private void ClearList()
		{
			if (InvokeRequired)
			{
				Invoke((MethodInvoker) (ClearList));
			}
			else
			{
				slvIssues.Items.Clear();
			}
		}

		private void HandleMessage(string text, OutputParseResult outputParseResult)
		{
			if (InvokeRequired)
			{
				Invoke((MethodInvoker) (() => HandleMessage(text, outputParseResult)));
			}
			else
			{
				string[] content =
				{
					(slvIssues.Items.Count + 1).ToString(),
					outputParseResult.Type.ToString(),
					outputParseResult.Time.ToLongTimeString(),
					Regex.Replace(outputParseResult.Message, "^\\[(warn|warning|severe|error)\\]\\s?", "", RegexOptions.IgnoreCase)
				};
				ListViewItem lvi = new ListViewItem(content) {Tag = outputParseResult};
				switch (outputParseResult.Type)
				{
					case MessageType.Warning:
						lvi.ForeColor = ConsoleTab.Reference.MCCOut.MessageColorWarning;
						break;
					default:
						lvi.ForeColor = ConsoleTab.Reference.MCCOut.MessageColorSevere;
						break;
				}

				slvIssues.Items.Add(lvi);
			}
		}

		public IAddon ParentAddon { get; set; }

		private void btnCopy_Click(object sender, EventArgs e)
		{
			if (slvIssues.SelectedItems.Count < 1) return;
			Clipboard.SetText(slvIssues.SelectedItems[0].SubItems[1].Text + ": " + slvIssues.SelectedItems[0].SubItems[3].Text);
		}

		private void slvIssues_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool selected = (slvIssues.SelectedItems.Count > 0);
			btnCopy.Enabled = selected;
			btnLookup.Enabled = selected;
		}

		private void btnLookup_Click(object sender, EventArgs e)
		{
			if (slvIssues.SelectedItems.Count < 1) return;
			Process.Start("https://www.google.com/search?ie=utf-8&oe=utf-8&q=" + slvIssues.SelectedItems[0].SubItems[3].Text);
		}
	}
}