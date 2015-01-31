// ConsoleInput.cs in bukkitgui2/bukkitgui2
// Created 2014/02/21
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Linq;
using System.Windows.Forms;
using MetroFramework.Controls;
using Net.Bertware.Bukkitgui2.MinecraftInterop.PlayerHandler;
using Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler;

namespace Net.Bertware.Bukkitgui2.Controls.ConsoleInput
{
	internal class ConsoleInput : MetroTextBox
	{
		/// <summary>
		///     If autocompletion should be enabled or not
		/// </summary>
		public Boolean AutoCompletion { get; set; }

		/// <summary>
		///     Eventhandler for CommandSent
		/// </summary>
		/// <param name="text"></param>
		public delegate void CommandSentEventHandler(string text);

		/// <summary>
		///     Ran when a command is sent
		/// </summary>
		public event CommandSentEventHandler CommandSent;


		protected virtual void OnCommandSent(string s)
		{
			var handler = CommandSent;
			if (handler != null) handler(s);
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.Tab)
			{
				AutoCompleteName();
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		public ConsoleInput()
		{
			
			KeyPress += HandleKeyPress;
			CreateContextMenu();
			ProcessHandler.ServerStarted += ProcessHandler_ServerStarted;
		}

		private void ProcessHandler_ServerStarted()
		{
			if (InvokeRequired)
			{
				Invoke((MethodInvoker) ProcessHandler_ServerStarted);
			}
			else
			{
				Focus();
			}
		}

		/// <summary>
		///     Handle a keypress
		/// </summary>
		/// <param name="sender">event sender</param>
		/// <param name="e">event parameters</param>
		private void HandleKeyPress(object sender, KeyPressEventArgs e)
		{
			
			switch (e.KeyChar)
			{
				case '\r':
					e.Handled = true;
					SubmitCommand();
					break;
				case '\t':
					e.Handled = true;
					AutoCompleteName();
					break;
			}
		}

		private void SubmitCommand()
		{
			if (string.IsNullOrEmpty(Text)) return;
			var handler = CommandSent;
			if (handler != null) handler(Text);
			Text = "";
		}

		private void AutoCompleteName()
		{
			if (string.IsNullOrEmpty(this.Text)) return;

			string text = (this.Text.Contains(' ')) ? Text.Split(' ').Last() : this.Text;

			string result = "";
	
			foreach (Player p in PlayerHandler.GetOnlinePlayers())
			{
				if (p.Name.ToLower().StartsWith(text))
				{
					if (!string.IsNullOrEmpty(result)) return; // multiple options, auto complete only works if we're sure
					result = p.Name;
					
				}
			}
			
			if (Text.Contains(' '))
			{
				Text = Text.Substring(0, Text.Length - text.Length) + result;
			}
			else
			{
				Text = result;
			}
		}


		/// <summary>
		///     Clear the autocompletion history
		/// </summary>
		public void ClearAutoCompletionHistory()
		{
		}

		private void ToggleAutoCompletion(object sender, EventArgs e)
		{
			AutoCompletion = !AutoCompletion;
			ContextMenu.MenuItems[0].Checked = AutoCompletion;
		}

		private void CreateContextMenu()
		{
			MenuItem[] menuItem = new MenuItem[1];
			menuItem[0] = new MenuItem("Autocompletion", ToggleAutoCompletion)
			{
				Checked = AutoCompletion,
				Enabled = true
			};
			ContextMenu cm = new ContextMenu(menuItem);
			ContextMenu = cm;
		}
	}
}