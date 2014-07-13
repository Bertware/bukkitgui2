// LocalFileSystem.cs in bukkitgui2/bukkitgui2
// Created 2014/01/18
// Last edited at 2014/07/13 14:01
// ©Bertware, visit http://bertware.net

using System;
using System.IO;

namespace Net.Bertware.Bukkitgui2.Core.Filesystem.Local
{
	/// <summary>
	///     Local file system, just renames the existing methods to fit in the interface
	/// </summary>
	public class LocalFileSystem : IFilesystem
	{
		/// <summary>
		///     Private isInitialized variable to store the value that will be returned on the public get request
		/// </summary>
		private bool _isInitialized;

		/// <summary>
		///     True if this component is initialized and can be used
		/// </summary>
		public bool IsInitialized
		{
			get { return _isInitialized; }
		}

		/// <summary>
		///     Create or open needed files, create streams if needed, do everything what's needed before the code can be used
		/// </summary>
		public void Initialize()
		{
			_isInitialized = true;
		}

		/// <summary>
		///     Stop and clean up
		/// </summary>
		public void Dispose()
		{
		}

		public bool CreateDirectory(string dir)
		{
			Directory.CreateDirectory(dir);
			return true;
		}

		public bool DirectoryExists(string dir)
		{
			return Directory.Exists(dir);
		}

		public bool RemoveDirectory(string dir)
		{
			Directory.Delete(dir);
			return true;
		}

		public bool RenameDirectory(string dir, string newname)
		{
			Directory.Move(dir, newname);
			return true;
		}

		public String[] GetFilesInDirectory(string dir)
		{
			return Directory.GetFiles(dir);
		}

		public String[] GetSubDirectories(string dir)
		{
			return Directory.GetDirectories(dir);
		}

		public bool CreateFile(string file)
		{
			FileStream fs = File.Create(file);
			fs.Close();
			return true;
		}

		public bool CreateFile(string file, string content)
		{
			using (StreamWriter sw = File.CreateText(file))
			{
				sw.Write(content);
			}
			return true;
		}

		public bool FileExists(string file)
		{
			return File.Exists(file);
		}

		public bool RemoveFile(string file)
		{
			File.Delete(file);
			return true;
		}

		public bool RenameFile(string file, string newname)
		{
			File.Move(file, newname);
			return true;
		}

		public string GetFileContents(string file)
		{
			return File.ReadAllText(file);
		}

		public byte[] GetBinaryFileContents(string file)
		{
			return File.ReadAllBytes(file);
		}

		public FileInfo GetFileInfo(string file)
		{
			return new FileInfo(file);
		}

		public string GetLocalFilePath(string file)
		{
			return file;
		}
	}
}