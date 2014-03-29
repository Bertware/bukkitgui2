using System.Windows.Forms;
using Bukkitgui2.MinecraftInterop.OutputHandler;
using Bukkitgui2.MinecraftInterop.ProcessHandler;

namespace Bukkitgui2.AddOn.Console
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
		}

		public IAddon ParentAddon { get; set; }

		private void HandleServerStart()
		{
			SLVPlayers.Items.Clear();
			MCCOut.Clear();
			CIConsoleInput.ClearAutoCompletionHistory();
			MCCOut.WriteOutput(MessageType.Info, "[GUI] Starting a new server");
		}

		private void HandleServerStop()
		{
			SLVPlayers.Items.Clear();
			CIConsoleInput.ClearAutoCompletionHistory();
			MCCOut.WriteOutput(MessageType.Info, "[GUI] The server has stopped");
		}

		private void PrintOutput(string text, OutputParseResult outputParseResult)
		{
			MCCOut.WriteOutput(outputParseResult.Type, outputParseResult.Message);
		}

		private void HandleCommandSent(string text)
		{
			if (ProcessHandler.IsRunning)
			{
				ProcessHandler.SendInput(text);
			}
		}
	}
}