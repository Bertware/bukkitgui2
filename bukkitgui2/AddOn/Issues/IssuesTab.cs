// IssuesTab.cs in bukkitgui2/bukkitgui2
// Created 2014/08/31
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

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
                    outputParseResult.Message
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
    }
}