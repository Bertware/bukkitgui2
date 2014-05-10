using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.UI;

namespace Net.Bertware.Bukkitgui2
{
	internal static class Program
	{
		/// <summary>
		///     The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			// Load embedded DLLs
			AppDomain.CurrentDomain.AssemblyResolve += LoadDll;
			// Load app
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}

		public static Assembly LoadDll(object sender, ResolveEventArgs args)
		{
			//Load embedded DLLs

			String resourceName = "Net.Bertware.Bukkitgui2." + new AssemblyName(args.Name).Name + ".dll";
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

		//=======================================================
		//Service provided by Telerik (www.telerik.com)
		//Conversion powered by NRefactory.
		//Twitter: @telerik
		//Facebook: facebook.com/telerik
		//=======================================================
	}
}