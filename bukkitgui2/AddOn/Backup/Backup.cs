// Backup.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2015/08/01 12:56
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using MetroFramework;
using MetroFramework.Controls;
using Net.Bertware.Bukkitgui2.Core.FileLocation;
using Net.Bertware.Bukkitgui2.Core.Logging;
using Net.Bertware.Bukkitgui2.Core.Util;

namespace Net.Bertware.Bukkitgui2.AddOn.Backup
{
	public class Backup : IAddon
	{
		public static Backup Reference;

		public Backup()
		{
			Reference = this;
			Name = "Backup";
			Priority = 0;
			HasTab = true;
			TabPage = new BackupTab();
			HasConfig = false;
			ConfigPage = null;
		}

		/// <summary>
		///     The addon name, ideally this name is the same as used in the tabpage
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		///     The addon priority. Default: 0
		/// </summary>
		public int Priority { get; private set; }

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
			try
			{
				Backups = new Dictionary<string, BackupDefenition>();
				if (!File.Exists(_backupXmlPath))
					File.WriteAllText(_backupXmlPath, "<backups></backups>");
				_backupXml = new XmlDocument();
				_backupXml.Load(_backupXmlPath);
				LoadAllBackups();
			}
			catch (XmlException xmlException)
			{
				// xml file could be faulty
				Logger.Log(LogLevel.Warning, "Backup", "Failed to load backups from XML file. File might be corrupted",
					xmlException.Message);
			}
			catch (Exception exception)
			{
				Logger.Log(LogLevel.Warning, "Backup", "Failed to initialize backup manager", exception.Message);
			}
		}

		public void Dispose()
		{
			// nothing to do
		}

		public Dictionary<string, BackupDefenition> Backups { get; private set; }


		/// <summary>
		///     The tab control for this addon
		/// </summary>
		/// <returns>Returns the tabpage</returns>
		public MetroUserControl TabPage { get; private set; }

		public MetroUserControl ConfigPage { get; private set; }

		private readonly string _backupXmlPath = Fl.SafeLocation(RequestFile.Config) + "/backups.xml";

		private XmlDocument _backupXml;
		public event BackupsLoadedEventHandler BackupsLoaded;

		public delegate void BackupsLoadedEventHandler();

		public bool Loaded
		{
			get { return Backups != null; }
		}

		public void LoadAllBackups()
		{
			try
			{
				Backups = new Dictionary<string, BackupDefenition>();
				Logger.Log(LogLevel.Info, "Backupmanager", "Loading backups...");
				XmlElement rootElement = (XmlElement) _backupXml.GetElementsByTagName("backups")[0];
				XmlNodeList elements = rootElement.GetElementsByTagName("backup");
				if (elements.Count > 0)
				{
					for (int i = 0; i < elements.Count; i++)
					{
						Logger.Log(LogLevel.Info, "Backupmanager",
							"Parsing backup " + i + 1 + " out of " + elements.Count);
						XmlElement xmle = (XmlElement) elements[i];
						BackupDefenition backup = BackupDefenition.LoadXml(xmle);
						if (!Backups.ContainsKey(backup.Name))
						{
							Backups.Add(backup.Name, backup);
						}
						else
						{
							Logger.Log(LogLevel.Warning, "Backupmanager", "Backup not loaded due to duplicate name!");
						}
					}
				}
				Logger.Log(LogLevel.Info, "Backupmanager", "Loaded backups: " + Backups.Count + " backups loaded");
				if (BackupsLoaded != null)
				{
					BackupsLoaded();
				}
			}
			catch (Exception exception)
			{
				Logger.Log(LogLevel.Severe, "Backupmanager", "Failed to load backups!", exception.Message);
			}
		}

		public void ReloadAllBackups()
		{
			Logger.Log(LogLevel.Info, "Backupmanager", "Reloading _backups...", "BackupManager");
			LoadAllBackups();
		}

		public bool AddBackupToXml(BackupDefenition bs)
		{
			if (bs == null) return false;
			if (Backups.ContainsKey(bs.Name))
			{
				MetroMessageBox.Show(Application.OpenForms[0],
					"Couldn't save backup! You already defined another backup with this name:" + bs.Name,
					"Couldn't save backup", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			if (string.IsNullOrEmpty(bs.Name))
			{
				MetroMessageBox.Show(Application.OpenForms[0],
					"Couldn't save backup! You didn't enter a name for this backup!",
					"Couldn't save backup", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			try
			{
				string content = "<backup name=\"" + bs.Name + "\">" +
				                 "	<folders>" + StringUtil.ListToCsv(bs.Folders, ';') + "</folders>" +
				                 "	<destination>" + bs.TargetDirectory + "</destination>" +
				                 "	<compression>" + bs.Compression.ToString().ToLower() + "</compression>" +
				                 "</backup>";
				_backupXml.FirstChild.InnerXml += content;

				_backupXml.Save(_backupXmlPath);

				Backups.Add(bs.Name, bs);
				if (BackupsLoaded != null)
				{
					BackupsLoaded();
				}
			}
			catch (Exception ex)
			{
				Logger.Log(LogLevel.Severe, "Backupmanager", "Severe error in addBackup! " + ex.Message);
				return false;
			}
			return true;
		}

		public void SaveBackup(BackupDefenition oldBackup, BackupDefenition newBackup)
		{
			Logger.Log(LogLevel.Info, "Backupmanager",
				"Updating backup: " + oldBackup.Name + " - Will be replaced by its updated version");
			DeleteBackup(oldBackup);
			AddBackupToXml(newBackup);
			if (BackupsLoaded != null)
			{
				BackupsLoaded();
			}
		}

		public void DeleteBackup(BackupDefenition bs)
		{
			if (bs == null) return;

			try
			{
				if (Backups.ContainsKey(bs.Name)) Backups.Remove(bs.Name);
				foreach (XmlElement xmlElement in _backupXml.ChildNodes)
				{
					if (xmlElement.GetAttribute("name").Equals(bs.Name)) _backupXml.RemoveChild(xmlElement);
				}
				_backupXml.Save(_backupXmlPath);
			}
			catch (Exception ex)
			{
				Logger.Log(LogLevel.Severe, "Backupmanager", "Severe error in deleteBackup(bs)!", ex.Message);
			}
			if (BackupsLoaded != null)
			{
				BackupsLoaded();
			}
		}

		public void DeleteBackup(string name)
		{
			if (string.IsNullOrEmpty(name)) return;
			DeleteBackup(GetBackupByName(name));
		}

		public BackupDefenition GetBackupByName(string name)
		{
			if (string.IsNullOrEmpty(name)) return null;
			if (!Backups.ContainsKey(name)) return null;
			return Backups[name];
		}
	}
}
