using System;
using System.Drawing;
using bukkitgui2.MinecraftInterop.OutputHandler;
using bukkitgui2.MinecraftInterop.OutputHandler.PlayerActions;

namespace bukkitgui2.MinecraftServers
{
	internal interface IMinecraftServer
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
		// Output handling
		// ========================================== //

		/// <summary>
		///     Parse the provided text
		/// </summary>
		/// <param name="text">The text to parse</param>
		/// <returns>MessageParseResult containing all info about this text</returns>
		MessageParseResult ParseOutput(string text);

		/// <summary>
		///     Get the type of the provided text
		/// </summary>
		/// <param name="text">The text to parse</param>
		/// <returns>MessageType of the provided text</returns>
		MessageType ParseMessageType(string text);

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

		// ========================================== //
		// Download & Update
		// ========================================== //

		/// <summary>
		///     True if the latest available stable version number can be retrieved from the internet
		/// </summary>
		Boolean CanFetchLatestVersion { get; }

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
		Boolean CanDownloadLatestVersion { get; }

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
		///     Get the latest stable version number
		/// </summary>
		string FetchLatestVersion { get; }

		/// <summary>
		///     Get the latest beta version number
		/// </summary>
		string FetchBetaVersion { get; }

		/// <summary>
		///     Get the latest development version number
		/// </summary>
		string FetchDevVersion { get; }

		/// <summary>
		///     Download the latest stable version
		/// </summary>
		/// <param name="targetfile">Location where the file should be saved</param>
		/// <returns>True if successful</returns>
		Boolean DownloadLatestVersion(string targetfile);

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
		///     Get the version of this server file
		/// </summary>
		/// <param name="file">The path to the server file to check</param>
		/// <returns></returns>
		string GetCurrentVersion(string file);
	}
}