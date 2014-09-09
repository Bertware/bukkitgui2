// Notifications.cs in bukkitgui2/bukkitgui2
// Created 2014/06/21
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Windows.Forms;
using MetroFramework.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using Net.Bertware.Bukkitgui2.Core;
using Net.Bertware.Bukkitgui2.Core.Configuration;
using Net.Bertware.Bukkitgui2.Core.Logging;
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

			if (!Config.ReadBool(CfgIdent, "enabled", false)) return;


			_icon = new NotifyIcon {Icon = Resources.bukkitgui_icon, Visible = true};

			_icon.DoubleClick += ShowMainForm;

			BalloonDuration = Config.ReadInt(CfgIdent, "duration", 500);


			_alwaysShowBalloons = Config.ReadBool(CfgIdent, "always", false);

			if (Config.ReadBool(CfgIdent, "status", false)) ProcessHandler.ServerStatusChanged += ShowStatusTray;
			if (Config.ReadBool(CfgIdent, "join", false)) MinecraftOutputHandler.PlayerJoin += ShowJoinTray;
			if (Config.ReadBool(CfgIdent, "leave", false)) MinecraftOutputHandler.PlayerLeave += ShowLeaveTray;
			if (Config.ReadBool(CfgIdent, "kick", false)) MinecraftOutputHandler.PlayerKick += ShowKickTray;
			if (Config.ReadBool(CfgIdent, "ban", false)) MinecraftOutputHandler.PlayerBan += ShowBanTray;

			if (Config.ReadBool(CfgIdent, "sound_error", false))
				MinecraftOutputHandler.SevereMessageReceived += SoundSevereMessage;
			if (Config.ReadBool(CfgIdent, "sound_warn", false))
				MinecraftOutputHandler.WarningMessageReceived += SoundWarningMessage;
			if (Config.ReadBool(CfgIdent, "sound_join", false)) MinecraftOutputHandler.PlayerJoin += SoundPlayerJoin;
			if (Config.ReadBool(CfgIdent, "sound_leave", false)) MinecraftOutputHandler.PlayerLeave += SoundPlayerLeave;
		}

		/// <summary>
		///     Play the severe message sound
		/// </summary>
		private void SoundSevereMessage(string text, OutputParseResult outputParseResult)
		{
			new Audio().Play(Resources.sound_severe, AudioPlayMode.Background);
		}

		/// <summary>
		///     Play the warning message sound
		/// </summary>
		private void SoundWarningMessage(string text, OutputParseResult outputParseResult)
		{
			new Audio().Play(Resources.sound_warning, AudioPlayMode.Background);
		}

		/// <summary>
		///     Play the player left sound
		/// </summary>
		private void SoundPlayerLeave(string text, OutputParseResult outputParseResult, IPlayerAction playerAction)
		{
			new Audio().Play(Resources.sound_disconnect, AudioPlayMode.Background);
		}

		/// <summary>
		///     Play the player joined sound
		/// </summary>
		/// <param name="text"></param>
		/// <param name="outputParseResult"></param>
		/// <param name="playerAction"></param>
		private void SoundPlayerJoin(string text, OutputParseResult outputParseResult, IPlayerAction playerAction)
		{
			new Audio().Play(Resources.sound_connect, AudioPlayMode.Background);
		}

		public void Dispose()
		{
			try
			{
				if (_icon != null)
				{
					_icon.Visible = false;
					_icon.Dispose();
				}

				ProcessHandler.ServerStatusChanged -= ShowStatusTray;
				MinecraftOutputHandler.PlayerJoin -= ShowJoinTray;
				MinecraftOutputHandler.PlayerLeave -= ShowLeaveTray;
				MinecraftOutputHandler.PlayerKick -= ShowKickTray;
				MinecraftOutputHandler.PlayerBan -= ShowBanTray;

				MinecraftOutputHandler.SevereMessageReceived -= SoundSevereMessage;
				MinecraftOutputHandler.WarningMessageReceived -= SoundWarningMessage;
				MinecraftOutputHandler.PlayerJoin -= SoundPlayerJoin;
				MinecraftOutputHandler.PlayerLeave -= SoundPlayerLeave;
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

			_icon.ShowBalloonTip(BalloonDuration, Locale.Tr("Server") + " " + state,
				Locale.Tr("The server is") + " " + state.ToString().ToLower(),
				ToolTipIcon.Info);
		}


		private void ShowJoinTray(string text, OutputParseResult outputParseResult,
			IPlayerAction playerAction)
		{
			if (!_alwaysShowBalloons && MainForm.Reference.Visible)
				return; // if visible and balloons shouldn't be shown always, don't show.

			_icon.ShowBalloonTip(BalloonDuration, playerAction.PlayerName + " " + Locale.Tr("joined the server"),
				outputParseResult.Message,
				ToolTipIcon.Info);
		}

		private void ShowLeaveTray(string text, OutputParseResult outputParseResult,
			IPlayerAction playerAction)
		{
			if (!_alwaysShowBalloons && MainForm.Reference.Visible)
				return; // if visible and balloons shouldn't be shown always, don't show.

			_icon.ShowBalloonTip(BalloonDuration, playerAction.PlayerName + " " + Locale.Tr("left the server"),
				outputParseResult.Message,
				ToolTipIcon.Info);
		}

		private void ShowKickTray(string text, OutputParseResult outputParseResult,
			IPlayerAction playerAction)
		{
			if (!_alwaysShowBalloons && MainForm.Reference.Visible)
				return; // if visible and balloons shouldn't be shown always, don't show.

			_icon.ShowBalloonTip(BalloonDuration,
				playerAction.PlayerName + " " + Locale.Tr("was kicked from the server"),
				outputParseResult.Message, ToolTipIcon.Warning);
		}

		private void ShowBanTray(string text, OutputParseResult outputParseResult,
			IPlayerAction playerAction)
		{
			if (!_alwaysShowBalloons && MainForm.Reference.Visible)
				return; // if visible and balloons shouldn't be shown always, don't show.

			_icon.ShowBalloonTip(BalloonDuration,
				playerAction.PlayerName + " " + Locale.Tr("was banned from the server"),
				outputParseResult.Message, ToolTipIcon.Warning);
		}


		public MetroUserControl TabPage
		{
			get { return null; }
		}

		public MetroUserControl ConfigPage { get; private set; }
	}
}