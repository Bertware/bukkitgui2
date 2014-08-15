// Tasker.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/08/13 19:56
// ©Bertware, visit http://bertware.net

using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.Core.FileLocation;
using Net.Bertware.Bukkitgui2.Core.Logging;

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker
{
	public delegate void TaskerEventArgs();

	public class Tasker : IAddon
	{
		public Dictionary<string, Task> Tasks { get; private set; }
		private readonly string _configfile = Fl.SafeLocation(RequestFile.Config) + "tasklist";
		/// <summary>
		///     The addon name, ideally this name is the same as used in the tabpage
		/// </summary>
		public string Name
		{
			get { return "Tasker"; }
		}

		/// <summary>
		///     True if this addon has a tab page
		/// </summary>
		public bool HasTab
		{
			get { return true; }
		}

		/// <summary>
		///     True if this addon has a config field
		/// </summary>
		public bool HasConfig
		{
			get { return false; }
		}

		/// <summary>
		///     Initialize all functions and the tabcontrol
		/// </summary>
		public void Initialize()
		{
			TabPage = new TaskerTab {Text = Name, ParentAddon = this};
			ConfigPage = null;
			LoadTasks();
		}

		private void LoadTasks()
		{
			Logger.Log(LogLevel.Info, "Tasker", "Loading tasks...", _configfile);
			
			Tasks = new Dictionary<string, Task>();
			if (!File.Exists(_configfile)) File.Create(_configfile).Close();
			using (StreamReader sr = File.OpenText(_configfile))
			{
				while (!sr.EndOfStream)
				{
					Task t = new Task(sr.ReadLine());
					Logger.Log(LogLevel.Info, "Tasker", "Parsed task", t.ToString());
					Tasks.Add(t.Name,t);
					t.Initialize();
				}
			}
		}

		public void Dispose()
		{
			// nothing to do
		}

		/// <summary>
		///     The tab control for this addon
		/// </summary>
		/// <returns>Returns the tabpage</returns>
		public UserControl TabPage { get; private set; }

		public UserControl ConfigPage { get; private set; }

		public bool CanDisable
		{
			get { return true; }
		}
	}
}