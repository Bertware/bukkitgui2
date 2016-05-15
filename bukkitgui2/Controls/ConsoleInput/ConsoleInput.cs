// ConsoleInput.cs in bukkitgui2/bukkitgui2
// Created 2014/02/21
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MetroFramework.Controls;
using Net.Bertware.Bukkitgui2.AddOn.PlayerList;
using Net.Bertware.Bukkitgui2.MinecraftInterop.OutputHandler;
using Net.Bertware.Bukkitgui2.MinecraftInterop.PlayerHandler;
using Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler;

namespace Net.Bertware.Bukkitgui2.Controls.ConsoleInput
{
	internal class ConsoleInput : MetroTextBox
	{
		/// <summary>
		///     Eventhandler for CommandSent
		/// </summary>
		/// <param name="text"></param>
		public delegate void CommandSentEventHandler(string text);

		/// <summary>
		///     Ran when a command is sent
		/// </summary>
		public event CommandSentEventHandler CommandSent;

		private readonly Dictionary<int, string> _commandHistory = new Dictionary<int, string>();
		private int _commandHistoryBrowseId;

		protected virtual void OnCommandSent(string s)
		{
			var handler = CommandSent;
			if (handler != null) handler(s);
		}


		/// <summary>
		///     Add event handlers on creation
		/// </summary>
		public ConsoleInput()
		{
			KeyUp += HandleKeyUp;
			ProcessHandler.ServerStarted += ProcessHandler_ServerStarted;
		}


		/// <summary>
		///     Gain focus on server start
		/// </summary>
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
		///     Override default key handling to catch tab keys, and run autocompletion upon tab press.
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="keyData"></param>
		/// <returns></returns>
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			switch (keyData) // early tab key detection, since otherwise the control will lose focus
			{
				case Keys.Tab:
					AutoComplete();
					return true;
				case Keys.Up:
					HistoryGoUp();
					return true;
				case Keys.Down:
					HistoryGoDown();
					return true;
			}
			if (ContextMenu != null) ResetContextMenu();
			return base.ProcessCmdKey(ref msg, keyData);
		}

		private void HistoryGoDown()
		{
			if (!_commandHistory.ContainsKey(_commandHistoryBrowseId + 1))
			{
				if (_commandHistory.ContainsKey(_commandHistoryBrowseId))
				{
					Text = "";
					_commandHistoryBrowseId++; // move to unexistent empty space
				}
				return;
			}
			_commandHistoryBrowseId++;
			Text = _commandHistory[_commandHistoryBrowseId];
			Select(Text.Length, 0);
		}

		private void HistoryGoUp()
		{
			if (!_commandHistory.ContainsKey(_commandHistoryBrowseId - 1))
			{
				if (_commandHistory.ContainsKey(_commandHistoryBrowseId))
				{
					Text = "";
					_commandHistoryBrowseId--; // move to unexistent empty space
				}
				return;
			}
			_commandHistoryBrowseId--;
			Text = _commandHistory[_commandHistoryBrowseId];
			Select(Text.Length, 0);
		}

		/// <summary>
		///     Handle a keypress
		/// </summary>
		/// <param name="sender">event sender</param>
		/// <param name="e">event parameters</param>
		private void HandleKeyUp(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.S:
					if (e.Control)
					{
						Text = "say " + Text;
						SubmitCommand();
					}
					e.SuppressKeyPress = true;
					e.Handled = true;
					break;
				case Keys.Return:
					SubmitCommand();
					e.SuppressKeyPress = true;
					e.Handled = true;
					break;
			}
		}

		/// <summary>
		///     Raise the commandsent event and reset the text
		/// </summary>
		private void SubmitCommand()
		{
			if (string.IsNullOrEmpty(Text)) return;
			var handler = CommandSent;
			if (handler != null) handler(Text);
			// add to history
			_commandHistoryBrowseId = _commandHistory.Count - 1;
			_commandHistory.Add(_commandHistoryBrowseId, Text);
			_commandHistoryBrowseId++;
			Text = "";
		}
		
		public delegate IEnumerable<String> AutoCompleteSourceDelegate();
		private readonly List<AutoCompleteSourceDelegate> _sources = new List<AutoCompleteSourceDelegate>(); 
		public void AddAutocompleteSource(AutoCompleteSourceDelegate d)
		{
			_sources.Add(d);	
		}

		private List<string> getAutoCompleteContent()
		{
			List<String> content = new List<string>();
			foreach (AutoCompleteSourceDelegate source in _sources)
			{
				foreach (string s in source())
				{
					content.Add(s);
				}
			}
			content.Sort();
			return content;
		} 

		/// <summary>
		///     Auto complete a player name or command (if there's 1 option) or show a list of possibilities
		/// </summary>
		private void AutoComplete()
		{
			if (string.IsNullOrEmpty(Text)) return;

			string text = (Text.Contains(' ')) ? Text.Split(' ').Last() : Text;

			string result = "";
			ContextMenu options = null;

			foreach (string command in getAutoCompleteContent())
			{
				if (!command.StartsWith(text)) continue;

				if (options != null) // third or later hit, append list
				{
					options.MenuItems.Add(command, AutoCompleteFromContextMenu);
				}
				else if (!string.IsNullOrEmpty(result)) // this is our second hit, create a list
				{
					options = new ContextMenu();
					options.MenuItems.Add(result, AutoCompleteFromContextMenu);
					options.MenuItems.Add(command, AutoCompleteFromContextMenu);
					result = null; // for detection later
				}
				else // nothing found yet
				{
					result = command;
				}
			}

			if (!string.IsNullOrEmpty(result))
			{
				Text = Text.Substring(0, Text.Length - text.Length) + result;
				Select(Text.Length, 0);
				return; // we're done, auto complete name
			}

			if (options != null)
			{
				ContextMenu = options;
				ContextMenu.Show(this, new Point(0, Height));
				ContextMenu.Collapse += ((sender, args) => ResetContextMenu());
			}
		}

		/// <summary>
		///     Auto complete a command or name from the context menu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AutoCompleteFromContextMenu(object sender, EventArgs e)
		{
			if (!(sender is MenuItem)) return;
			MenuItem item = (MenuItem) sender;

			if (string.IsNullOrEmpty(Text))
			{
				Text = item.Text;
				Select(Text.Length, 0);
				return;
			}

			string text = (Text.Contains(' ')) ? Text.Split(' ').Last() : Text;
			Text = Text.Substring(0, Text.Length - text.Length) + item.Text;
			Select(Text.Length, 0);
			ResetContextMenu();
		}

		/// <summary>
		///     Reset the context menu
		/// </summary>
		private void ResetContextMenu()
		{
			if (ContextMenu != null) ContextMenu.Dispose();
			ContextMenu = null;
		}
	}
}