// Program.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/08/19 13:22
// ©Bertware, visit http://bertware.net

using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Net.Bertware.Bukkitgui2
{
	internal static class Program
	{
		/// <summary>
		///     The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main(string[] argStrings)
		{
			// Load embedded DLLs
			AppDomain.CurrentDomain.AssemblyResolve += LoadDll;

			// Load app
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			UiLauncher.Run();
			Application.Run();
		}

		public static Assembly LoadDll(object sender, ResolveEventArgs args)
		{
			//Load embedded DLLs

			String resourceName = "Net.Bertware.Bukkitgui2.Resources.Dll." + new AssemblyName(args.Name).Name + ".dll";

			using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
			{
				if (stream == null || stream.Length < 1)
				{
					return null;
				}
				Byte[] assemblyData = new Byte[stream.Length];
				stream.Read(assemblyData, 0, assemblyData.Length);

				return Assembly.Load(assemblyData);
			}
		}

		internal static void ExtractDll(string name)
		{
			String resourceName = "Net.Bertware.Bukkitgui2.Resources.Dll." + name + ".dll";

			using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
			{
				if (stream == null || stream.Length < 1)
				{
					return;
				}
				Byte[] assemblyData = new Byte[stream.Length];
				stream.Read(assemblyData, 0, assemblyData.Length);

				using (FileStream fs = File.Create(name + ".dll"))
				{
					fs.Write(assemblyData, 0, assemblyData.Length);
				}
			}
		}
	}
}