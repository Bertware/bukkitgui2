// Tasker.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/08/17 11:19
// ©Bertware, visit http://bertware.net

using System;
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
		public event EventHandler TaskListAltered;
		public static Tasker Reference { get; private set; }
		public static Dictionary<string, Task> Tasks;
		private static readonly string Configfile = Fl.SafeLocation(RequestFile.Config) + "tasklist";

		public Tasker()
		{
			Reference = this;
		}

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
			LoadTasks();
			TabPage = new TaskerTab {Text = Name, ParentAddon = this};
			ConfigPage = null;
		}

		private void LoadTasks()
		{
			Logger.Log(LogLevel.Info, "Tasker", "Loading tasks...", Configfile);

			Tasks = new Dictionary<string, Task>();
			if (!File.Exists(Configfile)) File.Create(Configfile).Close();
			using (StreamReader sr = File.OpenText(Configfile))
			{
				while (!sr.EndOfStream)
				{
					Task t = new Task(sr.ReadLine());
					Logger.Log(LogLevel.Info, "Tasker", "Parsed task", t.ToString());
					Tasks.Add(t.Name, t);
					t.Initialize();
				}
			}
			Logger.Log(LogLevel.Info, "Tasker", "Loaded all tasks");
		}

		/// <summary>
		///     Save (update) a task
		/// </summary>
		/// <param name="oldTask"></param>
		/// <param name="newTask"></param>
		public void SaveTask(Task oldTask, Task newTask)
		{
			DeleteTask(oldTask);
			AddTask(newTask);
			// events already fired by delete & add operations
		}

		/// <summary>
		///     Add a new task
		/// </summary>
		/// <param name="task">the task to add</param>
		public void AddTask(Task task)
		{
			if (Tasks != null && !Tasks.ContainsKey(task.Name)) Tasks.Add(task.Name, task);
			TaskListAltered.Invoke(Reference, EventArgs.Empty); // list changed, invoke event
			SaveConfig();
		}

		/// <summary>
		///     Delete a task
		/// </summary>
		/// <param name="task">the task to delete</param>
		public void DeleteTask(Task task)
		{
			if (Tasks != null && Tasks.ContainsKey(task.Name)) Tasks.Remove(task.Name);
			TaskListAltered.Invoke(Reference, EventArgs.Empty); // list changed, invoke event
			SaveConfig();
		}

		/// <summary>
		///     Save all tasks to config file.
		/// </summary>
		private static void SaveConfig()
		{
			Logger.Log(LogLevel.Info, "Tasker", "Saving tasks...", Configfile);

			if (!File.Exists(Configfile)) File.Create(Configfile).Close();
			using (StreamWriter sw = File.CreateText(Configfile))
			{
				foreach (KeyValuePair<string, Task> pair in Tasks)
				{
					sw.WriteLine(pair.Value.Serialize());
					Logger.Log(LogLevel.Info, "Tasker", "Saved task", pair.Value.ToString());
				}
			}
			Logger.Log(LogLevel.Info, "Tasker", "Saved all tasks");
		}

		public void Dispose()
		{
			SaveConfig();
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