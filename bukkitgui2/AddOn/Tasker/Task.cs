// Task.cs in bukkitgui2/bukkitgui2
// Created 2014/08/13
// Last edited at 2014/08/17 11:19
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using Net.Bertware.Bukkitgui2.AddOn.Tasker.Action;
using Net.Bertware.Bukkitgui2.AddOn.Tasker.Trigger;
using Net.Bertware.Bukkitgui2.Core.Util;

namespace Net.Bertware.Bukkitgui2.AddOn.Tasker
{
	public class Task
	{
		public static readonly List<ITrigger> AllTriggers =
			DynamicModuleLoader.GetClassesOfType<ITrigger>("Net.Bertware.Bukkitgui2.AddOn.Tasker.Trigger");

		public static readonly List<IAction> AllActions =
			DynamicModuleLoader.GetClassesOfType<IAction>("Net.Bertware.Bukkitgui2.AddOn.Tasker.Action");

		public string Name { get; private set; }
		public bool Enabled { get; private set; }
		public ITrigger Trigger { get; private set; }
		public List<IAction> Actions { get; private set; }

		public event EventHandler TaskExecuting;

		protected virtual void OnTaskExecuting()
		{
			EventHandler handler = TaskExecuting;
			if (handler != null) handler(this, EventArgs.Empty);
		}

		public event EventHandler TaskExecuted;

		protected virtual void OnTaskExecuted()
		{
			EventHandler handler = TaskExecuted;
			if (handler != null) handler(this, EventArgs.Empty);
		}

		public Task()
		{
			Name = "";
			Enabled = false;
		}

		public Task(string serializedData)
		{
			Deserialize(serializedData);
		}

		public Task(string name, bool enabled, ITrigger trigger, List<IAction> actions)
		{
			Name = name;
			Enabled = enabled;
			Trigger = trigger;
			Actions = actions;
		}

		public void Initialize()
		{
			if (Trigger == null) return;
			if (Actions == null) return;

			Trigger.TaskerTriggerFired += ExecuteActions;
			if (Enabled) Trigger.Enable();
		}

		public void Dispose()
		{
			Trigger.TaskerTriggerFired -= ExecuteActions;
			Trigger = null;
			Actions = null;
		}

		public void Enable()
		{
			Trigger.Enable();
			Enabled = true;
		}

		public void Disable()
		{
			Trigger.Disable();
			Enabled = false;
		}

		private void ExecuteActions()
		{
			OnTaskExecuting();
			foreach (IAction action in Actions)
			{
				action.Execute();
			}
			OnTaskExecuted();
		}

		public string Serialize()
		{
			string triggerSerial = "TRG::" + Trigger.Name + "::" + Trigger.Parameters + ":;";
			string actionSerial = "";
			foreach (IAction action in Actions)
			{
				actionSerial += "ACT::" + action.Name + "::" + action.Parameters + ":;";
			}
			return "TASK::" + Name + "::" + Enabled + ":;" + triggerSerial + actionSerial;
		}

		public Task Deserialize(string data)
		{
			Actions = new List<IAction>();
			string[] partedData = data.Split(new[] {":;"}, StringSplitOptions.RemoveEmptyEntries);
			foreach (string s in partedData)
			{
				string[] dataFragments = s.Split(new[] {"::"}, StringSplitOptions.None);
				switch (dataFragments[0])
				{
					case "TASK":
						Name = dataFragments[1];
						Enabled = bool.Parse(dataFragments[2]);
						break;
					case "TRG":
						foreach (ITrigger t in AllTriggers)
						{
							if (!t.Name.Equals(dataFragments[1])) continue;

							ITrigger trigger = (ITrigger) Activator.CreateInstance(t.GetType());
							trigger.Load(dataFragments[2]);
							Trigger = trigger;
							break; // we're done, we got the trigger. There can only be one trigger!
						}
						break;
					case "ACT":
						foreach (IAction a in AllActions)
						{
							if (!a.Name.Equals(dataFragments[1])) continue;

							IAction action = (IAction) Activator.CreateInstance(a.GetType());
							action.Load(dataFragments[2]);
							Actions.Add(action);
							break; // we're done, we got the trigger. There can only be one trigger!
						}
						break;
				}
			}
			return this;
		}

		public override string ToString()
		{
			return "Task:" + Name + ":Trigger:" + Trigger.Name + ":Actions:" + Actions.Count;
		}
	}
}