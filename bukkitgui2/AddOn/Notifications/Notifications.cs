// Notifications.cs in bukkitgui2/bukkitgui2
// Created 2014/06/21
// Last edited at 2014/07/13 14:01
// ©Bertware, visit http://bertware.net

using System;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.Core.Configuration;
using Net.Bertware.Bukkitgui2.Core.Logging;
using Net.Bertware.Bukkitgui2.Core.Translation;
using Net.Bertware.Bukkitgui2.MinecraftInterop.OutputHandler;
using Net.Bertware.Bukkitgui2.MinecraftInterop.OutputHandler.PlayerActions;
using Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler;
using Net.Bertware.Bukkitgui2.Properties;
using Net.Bertware.Bukkitgui2.UI;

namespace Net.Bertware.Bukkitgui2.AddOn.Notifications
{
	internal class Notifications : IAddon
	{
		public const string CfgIdent = "notifications";
		private NotifyIcon _icon;
		private Boolean _alwaysShowBalloons;

		public string Name
		{
			get { return "Notifications"; }
		}

		public bool HasTab
		{
			get { return false; }
		}

		public bool HasConfig
		{
			get { return true; }
		}

		public int BalloonDuration { get; set; }

		public void Initialize()
		{
			ConfigPage = new NotificationSettings();

			if (!Config.ReadBool(CfgIdent, "enable", false)) return;


			_icon = new NotifyIcon {Icon = Resources.GUI_icon, Visible = true};

			_icon.DoubleClick += ShowMainForm;

			BalloonDuration = Config.ReadInt(CfgIdent, "duration", 500);


			_alwaysShowBalloons = Config.ReadBool(CfgIdent, "always", false);

			if (Config.ReadBool(CfgIdent, "status", false)) ProcessHandler.ServerStatusChanged += ShowStatusTray;
			if (Config.ReadBool(CfgIdent, "join", false)) MinecraftOutputHandler.PlayerJoin += ShowJoinTray;
			if (Config.ReadBool(CfgIdent, "leave", false)) MinecraftOutputHandler.PlayerLeave += ShowLeaveTray;
			if (Config.ReadBool(CfgIdent, "kick", false)) MinecraftOutputHandler.PlayerKick += ShowKickTray;
			if (Config.ReadBool(CfgIdent, "ban", false)) MinecraftOutputHandler.PlayerBan += ShowBanTray;
		}

		public void Dispose()
		{
			try
			{
				_icon.Visible = false;
				_icon.Dispose();
				ProcessHandler.ServerStatusChanged -= ShowStatusTray;
				MinecraftOutputHandler.PlayerJoin -= ShowJoinTray;
				MinecraftOutputHandler.PlayerLeave -= ShowLeaveTray;
				MinecraftOutputHandler.PlayerKick -= ShowKickTray;
				MinecraftOutputHandler.PlayerBan -= ShowBanTray;
			}
			catch (Exception exception)
			{
				Logger.Log(LogLevel.Warning, "notifications", "Failed to dispose addon", exception.Message);
			}
		}

		private void ShowMainForm(object sender, EventArgs e)
		{
			MainForm.Reference.ShowForm();
		}

		private void ShowStatusTray(ServerState state)
		{
			if (!_alwaysShowBalloons && MainForm.Reference.Visible)
				return; // if visible and balloons shouldn't be shown always, don't show.

			_icon.ShowBalloonTip(BalloonDuration, Translator.Tr("Server") + " " + state,
				Translator.Tr("The server is") + " " + state.ToString().ToLower(),
				ToolTipIcon.Info);
		}


		private void ShowJoinTray(string text, OutputParseResult outputParseResult,
			IPlayerAction playerAction)
		{
			if (!_alwaysShowBalloons && MainForm.Reference.Visible)
				return; // if visible and balloons shouldn't be shown always, don't show.

			_icon.ShowBalloonTip(BalloonDuration, playerAction.PlayerName + " " + Translator.Tr("joined the server"),
				outputParseResult.Message,
				ToolTipIcon.Info);
		}

		private void ShowLeaveTray(string text, OutputParseResult outputParseResult,
			IPlayerAction playerAction)
		{
			if (!_alwaysShowBalloons && MainForm.Reference.Visible)
				return; // if visible and balloons shouldn't be shown always, don't show.

			_icon.ShowBalloonTip(BalloonDuration, playerAction.PlayerName + " " + Translator.Tr("left the server"),
				outputParseResult.Message,
				ToolTipIcon.Info);
		}

		private void ShowKickTray(string text, OutputParseResult outputParseResult,
			IPlayerAction playerAction)
		{
			if (!_alwaysShowBalloons && MainForm.Reference.Visible)
				return; // if visible and balloons shouldn't be shown always, don't show.

			_icon.ShowBalloonTip(BalloonDuration,
				playerAction.PlayerName + " " + Translator.Tr("was kicked from the server"),
				outputParseResult.Message, ToolTipIcon.Warning);
		}

		private void ShowBanTray(string text, OutputParseResult outputParseResult,
			IPlayerAction playerAction)
		{
			if (!_alwaysShowBalloons && MainForm.Reference.Visible)
				return; // if visible and balloons shouldn't be shown always, don't show.

			_icon.ShowBalloonTip(BalloonDuration,
				playerAction.PlayerName + " " + Translator.Tr("was banned from the server"),
				outputParseResult.Message, ToolTipIcon.Warning);
		}


		public UserControl TabPage
		{
			get { return null; }
		}

		public UserControl ConfigPage { get; private set; }
	}
}