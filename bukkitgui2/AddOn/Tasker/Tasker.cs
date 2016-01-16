// Tasker.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using Net.Bertware.Bukkitgui2.Core.FileLocation;
using Net.Bertware.Bukkitgui2.Core.Logging;

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker
{
    public delegate void TaskerEventArgs();

    public class Tasker : IAddon
    {
        public event EventHandler TaskListAltered;
        public event EventHandler TaskExecuted;
        public static Tasker Reference { get; private set; }
        public static Dictionary<string, Task> Tasks;
        private static readonly string _Configfile = Fl.SafeLocation(RequestFile.Config) + "tasklist";

        public Tasker()
        {
            Reference = this;
            Name = "Tasker";
            HasTab = true;
            HasConfig = false;
        }

        /// <summary>
        ///     The addon name, ideally this name is the same as used in the tabpage
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        ///     True if this addon has a tab page
        /// </summary>
        public bool HasTab { get; private set; }

        /// <summary>
        ///     True if this addon has a config field
        /// </summary>
        public bool HasConfig { get; private set; }

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
            Logger.Log(LogLevel.Info, "Tasker", "Loading tasks...", _Configfile);

            Tasks = new Dictionary<string, Task>();
            if (!File.Exists(_Configfile)) File.Create(_Configfile).Close();
            using (StreamReader sr = File.OpenText(_Configfile))
            {
                while (!sr.EndOfStream)
                {
	                try
	                {
		                Task t = new Task(sr.ReadLine());
		                Logger.Log(LogLevel.Info, "Tasker", "Parsed task", t.ToString());
		                Tasks.Add(t.Name, t);
	                }
	                catch (Exception ex)
	                {
						Logger.Log(LogLevel.Warning, "Tasker", "Failed to parse task", ex.Message);
	                }

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
            // events are fired by delete & add operations
        }

        /// <summary>
        ///     Add a new task
        /// </summary>
        /// <param name="task">the task to add</param>
        public void AddTask(Task task)
        {
            task.Enable();
            task.TaskExecuted += OnTaskExecuted;
            if (Tasks != null && !Tasks.ContainsKey(task.Name)) Tasks.Add(task.Name, task);
            OnTaskListAltered();
            SaveConfig();
        }


        /// <summary>
        ///     Delete a task
        /// </summary>
        /// <param name="task">the task to delete</param>
        public void DeleteTask(Task task)
        {
	        if (task == null) return;

            task.Disable();
            task.TaskExecuted -= OnTaskExecuted;

            if (Tasks != null && Tasks.ContainsKey(task.Name)) Tasks.Remove(task.Name);

            task.Dispose(); // make sure it's removed
			OnTaskListAltered();// list changed, invoke event
            SaveConfig();
        }

        /// <summary>
        ///     Save all tasks to config file.
        /// </summary>
        private static void SaveConfig()
        {
	        try
	        {


		        Logger.Log(LogLevel.Info, "Tasker", "Saving tasks...", _Configfile);

		        if (!File.Exists(_Configfile)) File.Create(_Configfile).Close();

		        using (StreamWriter sw = File.CreateText(_Configfile))
		        {
			        foreach (KeyValuePair<string, Task> pair in Tasks)
			        {
				        sw.WriteLine(pair.Value.Serialize());
				        Logger.Log(LogLevel.Info, "Tasker", "Saved task", pair.Value.ToString());
			        }
		        }
		        Logger.Log(LogLevel.Info, "Tasker", "Saved all tasks");
	        }
	        catch (Exception e)
	        {
				Logger.Log(LogLevel.Severe, "Tasker", "Failed to save tasks", e.Message);
		        MetroMessageBox.Show(Form.ActiveForm,
			        "The task settings could not be saved for an unknown reason", "Tasks not saved", MessageBoxButtons.OK,
			        MessageBoxIcon.Error);

	        }
        }

        public void Dispose()
        {
            SaveConfig();
        }

        /// <summary>
        ///     The tab control for this addon
        /// </summary>
        /// <returns>Returns the tabpage</returns>
        public MetroUserControl TabPage { get; private set; }

        public MetroUserControl ConfigPage { get; private set; }

        public bool CanDisable
        {
            get { return true; }
        }

        protected virtual void OnTaskExecuted(object sender, EventArgs e)
        {
            var handler = TaskExecuted;
            if (handler != null) handler(sender, e);
        }

        protected virtual void OnTaskListAltered()
        {
            var handler = TaskListAltered;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}