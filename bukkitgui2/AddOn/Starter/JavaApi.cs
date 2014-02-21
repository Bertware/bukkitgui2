using System;
using System.IO;

namespace Bukkitgui2.AddOn.Starter
{
	internal static class JavaApi
	{
		private static Boolean _initialized;
		private static string _jre6X32 = "";
		private static string _jre6X64 = "";
		private static string _jre7X32 = "";
		private static string _jre7X64 = "";

		/// <summary>
		///     Initialize the class, check available versions and paths
		/// </summary>
		public static void Initialize()
		{
			// TODO: BETTER API, REGISTRY SEARCH, MULTIPLE DISCS, CUSTOM LOCATIONS
			_initialized = true;
			if (File.Exists("C:\\Program Files (x86)\\Java\\jre6\\bin\\java.exe"))
				_jre6X32 = "C:\\Program Files (x86)\\Java\\jre6\\bin\\java.exe";
			if (File.Exists("C:\\Program Files\\Java\\jre6\\bin\\java.exe"))
				_jre6X64 = "C:\\Program Files\\Java\\jre6\\bin\\java.exe";
			if (File.Exists("C:\\Program Files (x86)\\Java\\jre7\\bin\\java.exe"))
				_jre7X32 = "C:\\Program Files (x86)\\Java\\jre7\\bin\\java.exe";
			if (File.Exists("C:\\Program Files\\Java\\jre7\\bin\\java.exe"))
				_jre7X64 = "C:\\Program Files\\Java\\jre7\\bin\\java.exe";
		}

		public static Boolean IsInstalled(JavaVersion jreVersion)
		{
			if (!_initialized) Initialize();
			switch (jreVersion)
			{
				case JavaVersion.Jre6X32:
					return !string.IsNullOrEmpty(_jre6X32);
				case JavaVersion.Jre6X64:
					return !string.IsNullOrEmpty(_jre6X64);
				case JavaVersion.Jre7X32:
					return !string.IsNullOrEmpty(_jre7X32);
				case JavaVersion.Jre7X64:
					return !string.IsNullOrEmpty(_jre7X64);
				default:
					return false;
			}
		}

		public static string GetJavaPath(JavaVersion jreVersion)
		{
			if (!_initialized) Initialize();
			switch (jreVersion)
			{
				case JavaVersion.Jre6X32:
					return _jre6X32;
				case JavaVersion.Jre6X64:
					return _jre6X64;
				case JavaVersion.Jre7X32:
					return _jre7X32;
				case JavaVersion.Jre7X64:
					return _jre7X64;
				default:
					return null;
			}
		}
	}

	internal enum JavaVersion
	{
		Jre6X32,
		Jre6X64,
		Jre7X32,
		Jre7X64
	}
}