// ConsoleTab.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/05/24 12:16
// ©Bertware, visit http://bertware.net

using System;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.MinecraftInterop.OutputHandler;
using Net.Bertware.Bukkitgui2.MinecraftInterop.PlayerHandler;
using Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler;

namespace Net.Bertware.Bukkitgui2.AddOn.Console
{
	public partial class ConsoleTab : UserControl, IAddonTab
	{
		public ConsoleTab()
		{
			InitializeComponent();
			MinecraftOutputHandler.OutputParsed += PrintOutput;
			ProcessHandler.ServerStarting += HandleServerStart;
			ProcessHandler.ServerStopped += HandleServerStop;
			CIConsoleInput.CommandSent += HandleCommandSent;
			PlayerHandler.PlayerListAddition += HandlePlayerAddition;
			PlayerHandler.PlayerListDeletion += HandlePlayerDeletion;
		}

		/// <summary>
		///     Remove a player from the listview
		/// </summary>
		/// <param name="player"></param>
		private void HandlePlayerDeletion(Player player)
		{
			SLVPlayers.Items.RemoveByKey(player.Name);
		}

		/// <summary>
		///     Add a player to the listview
		/// </summary>
		/// <param name="player"></param>
		private void HandlePlayerAddition(Player player)
		{
			String[] text = {player.Name, player.Ip};
			ListViewItem lvi = new ListViewItem(text) {Tag = player.Name, Name = player.Name};
			AddListViewItem(lvi);
		}

		/// <summary>
		///     Add an item to the listview, thread-safe
		/// </summary>
		/// <param name="item">the item to add</param>
		private void AddListViewItem(ListViewItem item)
		{
			if (InvokeRequired)
			{
				Invoke((MethodInvoker) (() => AddListViewItem(item)));
			}
			else
			{
				SLVPlayers.Items.Add(item);
			}
		}

		public IAddon ParentAddon { get; set; }

		/// <summary>
		///     Handle starting server, prepare UI and display text
		/// </summary>
		private void HandleServerStart()
		{
			SLVPlayers.Items.Clear();
			MCCOut.Clear();
			CIConsoleInput.ClearAutoCompletionHistory();
			MCCOut.WriteOutput(MessageType.Info, "[GUI] Starting a new server");
		}

		/// <summary>
		///     Handle stopped server, clear UI.
		/// </summary>
		private void HandleServerStop()
		{
			SLVPlayers.Items.Clear();
			CIConsoleInput.ClearAutoCompletionHistory();
			MCCOut.WriteOutput(MessageType.Info, "[GUI] The server has stopped");
		}

		/// <summary>
		///     Print output to the console
		/// </summary>
		/// <param name="text"></param>
		/// <param name="outputParseResult"></param>
		private void PrintOutput(string text, OutputParseResult outputParseResult)
		{
			MCCOut.WriteOutput(outputParseResult.Type, outputParseResult.Message);
		}

		/// <summary>
		///     Handle a commandsent event from the textbox and redirect it to the server
		/// </summary>
		/// <param name="text"></param>
		private void HandleCommandSent(string text)
		{
			if (ProcessHandler.IsRunning)
			{
				ProcessHandler.SendInput(text);
			}
		}
	}
}