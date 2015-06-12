// IMinecraftServer.cs in bukkitgui2/bukkitgui2
// Created 2014/02/02
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Drawing;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.MinecraftInterop.OutputHandler;
using Net.Bertware.Bukkitgui2.MinecraftInterop.OutputHandler.PlayerActions;
using Net.Bertware.Bukkitgui2.MinecraftServers.Tools;

namespace Net.Bertware.Bukkitgui2.MinecraftServers
{
	public interface IMinecraftServer
	{
		// ========================================== //
		// Info
		// ========================================== //

		/// <summary>
		///     The name of this server type
		/// </summary>
		string Name { get; }

		/// <summary>
		///     The site of this server
		/// </summary>
		string Site { get; }

		/// <summary>
		///     The logo of this server
		/// </summary>
		Image Logo { get; }

		/// <summary>
		///     True if this server supports plugins
		/// </summary>
		Boolean SupportsPlugins { get; }

		/// <summary>
		///     True if this server is ran locally (vs. on a remote host)
		/// </summary>
		Boolean IsLocal { get; }


		// ========================================== //
		// Process Handling
		// ========================================== //

		/// <summary>
		///     Prepare a server launc, e.g. unpack resources, load config, ...
		/// </summary>
		/// <returns></returns>
		void PrepareLaunch();

		/// <summary>
		///     Returns true if this server needs a custom assembly (No java)
		/// </summary>
		Boolean HasCustomAssembly { get; }

		/// <summary>
		///     The custom assembly to be used. Can be set in PrepareLaunch()
		/// </summary>
		string CustomAssembly { get; }

		/// <summary>
		///     Get the launch parameters
		/// </summary>
		/// <param name="defaultParameters">The user defined parameters in the start tab</param>
		/// <returns>The complete parameter string</returns>
		/// <remarks>
		///     NOTE: in case of a custom assembly, default parameters aren't available, and this routine should return ALL
		///     needed parameters
		/// </remarks>
		string GetLaunchParameters(string defaultParameters = "");

		/// <summary>
		///     Get the launch flags
		/// </summary>
		/// <param name="defaultFlags">The user defined flags in the start tab</param>
		/// <returns>the complete flag string</returns>
		/// <remarks>
		///     NOTE: in case of a custom assembly, default flags aren't available, and this routine should return ALL needed
		///     flags
		/// </remarks>
		string GetLaunchFlags(string defaultFlags = "");

		/// <summary>
		///     Returns true if this server has custom settings to be entered
		/// </summary>
		bool HasCustomSettingsControl { get; }

		/// <summary>
		///     Custom settings that will be shown in the designated groupbox on the starter tab. e.g. for remote connection
		///     settings
		/// </summary>
		UserControl CustomSettingsControl { get; }

		// ========================================== //
		// Output handling
		// ========================================== //

		/// <summary>
		///     Parse the provided text
		/// </summary>
		/// <param name="text">The text to parse</param>
		/// <returns>OutputParseResult containing all info about this text</returns>
		OutputParseResult ParseOutput(string text);

		/// <summary>
		///     Substract the real message from output text, without the timestamps etc. This method should remove the timestamp
		///     and fix formatting
		/// </summary>
		/// <param name="text">The text to parse</param>
		/// <returns>Message of the provided text</returns>
		string ParseMessage(string text);

		/// <summary>
		///     Get the type of the provided text
		/// </summary>
		/// <param name="text">The text to parse</param>
		/// <returns>MessageType of the provided text</returns>
		MessageType ParseMessageType(string text);

		/// <summary>
		///     Parse a player join action string into an object
		/// </summary>
		/// <param name="text">The string to alter</param>
		/// <returns>The string without the timestamp</returns>
		string RemoveTimeStamp(string text);

		/// <summary>
		///     Filter the text from faulty characters etc
		/// </summary>
		/// <param name="text">The text to filter</param>
		/// <returns>The filtered text</returns>
		string FilterText(string text);

		/// <summary>
		///     Parse a player join action string into an object
		/// </summary>
		/// <param name="text">The output string to parse</param>
		/// <returns>The player action object for this action</returns>
		PlayerActionJoin ParsePlayerJoin(string text);

		/// <summary>
		///     Parse a player leave action string into an object
		/// </summary>
		/// <param name="text">The output string to parse</param>
		/// <returns>The player action object for this action</returns>
		PlayerActionLeave ParsePlayerLeave(string text);

		/// <summary>
		///     Parse a player kick action string into an object
		/// </summary>
		/// <param name="text">The output string to parse</param>
		/// <returns>The player action object for this action</returns>
		PlayerActionKick ParsePlayerActionKick(string text);

		/// <summary>
		///     Parse a player ban action string into an object
		/// </summary>
		/// <param name="text">The output string to parse</param>
		/// <returns>The player action object for this action</returns>
		PlayerActionBan ParsePlayerActionBan(string text);

		/// <summary>
		///     Parse a player ip ban action string into an object
		/// </summary>
		/// <param name="text">The output string to parse</param>
		/// <returns>The player action object for this action</returns>
		PlayerActionIpBan ParsePlayerActionIpBan(string text);


		// ========================================== //
		// Download & Update
		// ========================================== //

		/// <summary>
		///     True if the latest available stable version number can be retrieved from the internet
		/// </summary>
		Boolean CanFetchRecommendedVersion { get; }

		/// <summary>
		///     True if the latest available beta version number can be retrieved from the internet
		/// </summary>
		Boolean CanFetchBetaVersion { get; }

		/// <summary>
		///     True if the latest available development version number can be retrieved from the internet
		/// </summary>
		Boolean CanFetchDevVersion { get; }

		/// <summary>
		///     True if the latest available stable version can be downloaded from the internet
		/// </summary>
		Boolean CanDownloadRecommendedVersion { get; }

		/// <summary>
		///     True if the latest available beta version can be downloaded from the internet
		/// </summary>
		Boolean CanDownloadBetaVersion { get; }

		/// <summary>
		///     True if the latest available development version can be downloaded from the internet
		/// </summary>
		Boolean CanDownloadDevVersion { get; }

		/// <summary>
		///     True if the current version can be retrieved
		/// </summary>
		Boolean CanGetCurrentVersion { get; }

		/// <summary>
		///     Get the latest stable version number, either build number or version. Used for auto-update
		/// </summary>
		string FetchRecommendedVersion { get; }

		/// <summary>
		///     Get the latest beta version number, either build number or version. Used for auto-update
		/// </summary>
		string FetchBetaVersion { get; }

		/// <summary>
		///     Get the latest development version number, either build number or version. Used for auto-update
		/// </summary>
		string FetchDevVersion { get; }


		/// <summary>
		///     Get the latest stable version string for UI purpose
		/// </summary>
		string FetchRecommendedVersionUiString { get; }

		/// <summary>
		///     Get the latest beta version string for UI purpose
		/// </summary>
		string FetchBetaVersionUiString { get; }

		/// <summary>
		///     Get the latest development version string for UI purpose
		/// </summary>
		string FetchDevVersionUiString { get; }

		/// <summary>
		///     Download the latest stable version
		/// </summary>
		/// <param name="targetfile">Location where the file should be saved</param>
		/// <returns>True if successful</returns>
		Boolean DownloadRecommendedVersion(string targetfile);

		/// <summary>
		///     Download the latest beta version
		/// </summary>
		/// <param name="targetfile">Location where the file should be saved</param>
		/// <returns>True if successful</returns>
		Boolean DownloadBetaVersion(string targetfile);

		/// <summary>
		///     Download the latest development version
		/// </summary>
		/// <param name="targetfile">Location where the file should be saved</param>
		/// <returns>True if successful</returns>
		Boolean DownloadDevVersion(string targetfile);

		/// <summary>
		///     Get the MinecraftServerObject for this file
		/// </summary>
		/// <param name="file">The file to load</param>
		/// <returns>MinecraftServerVersion object or null</returns>
		/// <remarks>This method should be used to get the version and UI version</remarks>
		MinecraftServerVersion GetCurrentVersionObject(string file);

		/// <summary>
		///     Get the version of this server file
		/// </summary>
		/// <param name="file">The path to the server file to check</param>
		/// <returns></returns>
		string GetCurrentVersion(string file);

		/// <summary>
		///     Get the version of this server file
		/// </summary>
		/// <param name="file">The path to the server file to check</param>
		/// <returns></returns>
		string GetCurrentVersionUiString(string file);
	}
}