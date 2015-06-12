// Share.cs in bukkitgui2/bukkitgui2
// Created 2014/01/18
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.IO;
using System.Reflection;
using Net.Bertware.Bukkitgui2.Core.Configuration;
using Net.Bertware.Bukkitgui2.Core.FileLocation;
using Net.Bertware.Bukkitgui2.Core.Filesystem;
using Net.Bertware.Bukkitgui2.Core.Filesystem.Local;
using Net.Bertware.Bukkitgui2.Core.Logging;

namespace Net.Bertware.Bukkitgui2.Core
{
	internal static class Share
	{
		public static IFilesystem ServerFileSystem;
		public static IntPtr MainFormHandle;


		/// <summary>
		///     Assembly name
		/// </summary>
		public static readonly string AssemblyName = Assembly.GetExecutingAssembly().GetName().Name;

		/// <summary>
		///     Assembly copyright
		/// </summary>
		public static readonly string AssemblyCopyRight =
			((AssemblyCopyrightAttribute)
				Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyCopyrightAttribute), false)[0])
				.Copyright;

		/// <summary>
		///     Assembly copyright
		/// </summary>
		public static readonly string AssemblyCompany =
			((AssemblyCompanyAttribute)
				Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyCompanyAttribute), false)[0])
				.Company;

		/// <summary>
		///     Assembly version
		/// </summary>
		public static readonly Version AssemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;

		/// <summary>
		///     Assembly fullname
		/// </summary>
		public static readonly string AssemblyFullName = Assembly.GetExecutingAssembly().GetName().FullName;

		/// <summary>
		///     Directory containing the assembly.
		/// </summary>
		public static readonly string AssemblyLocation = new FileInfo(AssemblyFullName).DirectoryName + "\\";


		public static bool Is64Bit
		{
			get
			{
				return (8 == IntPtr.Size
				        || (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))));
			}
		}

		public static void Initialize()
		{
			Fl.Initialize();
			Logger.Initialize();
			Config.Initialize();
			Locale.Initialize();


			//The filesystem to use (Only for server actions! e.g. logging and config are handled through the normal filesystem
			//This can be changed later on
			//e.g. when FTP connection settings are read from config or user presses connect button
			ServerFileSystem = new LocalFileSystem();
		}
	}
}