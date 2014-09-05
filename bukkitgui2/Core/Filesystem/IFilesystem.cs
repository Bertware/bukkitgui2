// IFilesystem.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.IO;

namespace Net.Bertware.Bukkitgui2.Core.Filesystem
{
	/// <summary>
	///     Universal interface for both local as FTP/SFTP/.. filesystems
	///     Only to be used for plugin manager etc.. Config, GUI files, ... are all stored locally and use the .NET methods
	/// </summary>
	public interface IFilesystem
	{
		/// <summary>
		///     check if this object is initialized yet
		/// </summary>
		/// <returns></returns>
		Boolean IsInitialized { get; }

		/// <summary>
		///     Initialize this filesystem handler
		/// </summary>
		void Initialize();

		/// <summary>
		///     Dispose this object
		/// </summary>
		void Dispose();

		/// <summary>
		///     Create a directory if it doesn't exist
		/// </summary>
		/// <param name="dir">directory path</param>
		/// <returns>Returns true if succesful</returns>
		Boolean CreateDirectory(String dir);

		/// <summary>
		///     Check if a directory exists
		/// </summary>
		/// <param name="dir">directory path</param>
		/// <returns>Returns true if the directory exists</returns>
		Boolean DirectoryExists(String dir);

		/// <summary>
		///     Remove a directory
		/// </summary>
		/// <param name="dir">directory path</param>
		/// <returns>Returns true if succesful</returns>
		Boolean RemoveDirectory(String dir);

		/// <summary>
		///     Rename a directory
		/// </summary>
		/// <param name="dir">directory path</param>
		/// <param name="newname">new directory name</param>
		/// <returns>Returns true if succesful</returns>
		Boolean RenameDirectory(String dir, String newname);

		/// <summary>
		///     Get a list of all files in a directory
		/// </summary>
		/// <param name="dir">the directory to index</param>
		/// <returns>List of all filenames in the directory</returns>
		String[] GetFilesInDirectory(String dir);

		/// <summary>
		///     Get a list of all subdirectories in a directory
		/// </summary>
		/// <param name="dir">the directory to index</param>
		/// <returns>List of all subdirectories in the directory</returns>
		String[] GetSubDirectories(String dir);

		/// <summary>
		///     Create a file if it doesn't exist
		/// </summary>
		/// <param name="file">file path</param>
		/// <returns>Returns true if succesful</returns>
		Boolean CreateFile(String file);

		/// <summary>
		///     Create a file if it doesn't exist, and set the contents
		/// </summary>
		/// <param name="file">file path</param>
		/// <param name="content">The content of the file</param>
		/// <returns>Returns true if succesful</returns>
		Boolean CreateFile(String file, String content);

		/// <summary>
		///     check if a file exists
		/// </summary>
		/// <param name="file">file path</param>
		/// <returns>Returns true if the file exists</returns>
		Boolean FileExists(String file);

		/// <summary>
		///     Remove a file
		/// </summary>
		/// <param name="file">file path</param>
		/// <returns>Returns true if succesful</returns>
		Boolean RemoveFile(String file);

		/// <summary>
		///     Rename a file
		/// </summary>
		/// <param name="file">file path</param>
		/// <param name="newname">The new file name</param>
		/// <returns>Returns true if succesful</returns>
		Boolean RenameFile(String file, String newname);

		/// <summary>
		///     Get the text contents of a file. Might require a download if file is online.
		/// </summary>
		/// <param name="file">file path</param>
		/// <returns>The string contents of the file</returns>
		String GetFileContents(String file);

		/// <summary>
		///     Get the binary contents of a file. Might require a download if file is online.
		/// </summary>
		/// <param name="file">file path</param>
		/// <returns>The binary contents of the file</returns>
		Byte[] GetBinaryFileContents(String file);

		/// <summary>
		///     Get info about a file. Might require a download if file is online.
		/// </summary>
		/// <param name="file">file path</param>
		/// <returns>Fileinfo object</returns>
		FileInfo GetFileInfo(String file);

		/// <summary>
		///     Get the path to a file on this computer. Files not on this computer will be downloaded first.
		/// </summary>
		/// <param name="file">file path</param>
		/// <returns>The file path on this computer</returns>
		String GetLocalFilePath(string file);
	}
}