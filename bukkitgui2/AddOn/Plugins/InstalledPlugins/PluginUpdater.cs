// PluginUpdater.cs in bukkitgui2/bukkitgui2
// Created 2014/08/22
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using MetroFramework.Forms;
using Net.Bertware.Bukkitgui2.AddOn.Plugins.Bukget.api3;
using Net.Bertware.Bukkitgui2.Core.Logging;
using Net.Bertware.Bukkitgui2.Core.Util;
using T = Net.Bertware.Bukkitgui2.Core.Locale;

namespace Net.Bertware.Bukkitgui2.AddOn.Plugins.InstalledPlugins
{
    public partial class PluginUpdater : MetroForm
    {
        /// <summary>
        ///     The list of plugins to update
        /// </summary>
        /// <remarks></remarks>
        public List<InstalledPlugin> InstalledPlugins;

        /// <summary>
        ///     Dictionarry that links every plugin to a bukget object.
        /// </summary>
        /// <remarks></remarks>
        private IDictionary<InstalledPlugin, BukgetPlugin> _pluginLinkDictionary;


        /// <summary>
        ///     Immediatly update the plugins when the form is loaded.
        /// </summary>
        /// <remarks></remarks>
        public bool UpdateOnLoad = false;


        public PluginUpdater()
        {
            Load += PluginUpdater_Load;
            // This call is required by the designer.
            InitializeComponent();
            InstalledPlugins = new List<InstalledPlugin>();
            // Add any initialization after the InitializeComponent() call.
        }


        public PluginUpdater(InstalledPlugin plugin)
        {
            Load += PluginUpdater_Load;
            // This call is required by the designer.
            InitializeComponent();
            InstalledPlugins = new List<InstalledPlugin> {plugin};
            // Add any initialization after the InitializeComponent() call.
        }


        public PluginUpdater(List<InstalledPlugin> plugins)
        {
            Load += PluginUpdater_Load;
            // This call is required by the designer.
            InitializeComponent();
            InstalledPlugins = new List<InstalledPlugin>();
            foreach (InstalledPlugin entry in plugins)
            {
                InstalledPlugins.Add(entry);
            }
            // Add any initialization after the InitializeComponent() call.
        }


        public PluginUpdater(IEnumerable<InstalledPlugin> plugins)
        {
            Load += PluginUpdater_Load;
            // This call is required by the designer.
            InitializeComponent();
            InstalledPlugins = new List<InstalledPlugin>();
            foreach (InstalledPlugin entry in plugins)
            {
                InstalledPlugins.Add(entry);
            }
            // Add any initialization after the InitializeComponent() call.
        }

        /// <summary>
        ///     Init the form + start  async load of data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void PluginUpdater_Load(Object sender, EventArgs e)
        {
            if (InstalledPlugins == null || InstalledPlugins.Count < 1)
                return;
            if (UpdateOnLoad)
            {
                BtnUpdate.Enabled = false;
                SlvPlugins.Enabled = false;
                BtnClose.Enabled = false;
                ChkCheckAll.Enabled = false;
                ChkForce.Enabled = false;
                CBBukkitBuild.Enabled = false;
            }
            Thread t = new Thread(LoadAsync) {IsBackground = true,Name="PluginUpdater_LoadAsync"};
            t.SetApartmentState(ApartmentState.MTA);
            t.Start();
        }

        /// <summary>
        ///     Load all plugin data async.
        /// </summary>
        /// <remarks></remarks>
        private void LoadAsync()
        {
            try
            {
                if (InstalledPlugins == null)
                    return;

                _pluginLinkDictionary = new Dictionary<InstalledPlugin, BukgetPlugin>();

                for (UInt16 i = 0; i <= InstalledPlugins.Count - 1; i++)
                {
                    InstalledPlugin plugin = InstalledPlugins[i];
                    if (plugin != null && plugin.Name != null)
                    {
                        SetStatus(T.Tr("Loading plugin data:") + plugin.Name + "(" + i + 1 + "/" +
                                  InstalledPlugins.Count + ")");
                        Logger.Log(LogLevel.Info, "PluginUpdater",
                            "Loading plugin data:" + plugin.Name + "(" + i + 1 + "/" + InstalledPlugins.Count + ")");
                        if (_pluginLinkDictionary.ContainsKey(plugin) == false)
                        {
                            _pluginLinkDictionary.Add(plugin, BukgetPlugin.CreateFromNamespace(plugin.Mainspace));
                            Logger.Log(LogLevel.Info, "PluginUpdater",
                                "Added plugin data:" + plugin.Name + "(" + i + 1 + "/" + InstalledPlugins.Count + ")");
                        }
                        else
                        {
                            Logger.Log(LogLevel.Info, "PluginUpdater",
                                "Discarded plugin data:" + plugin.Name + "(" + i + 1 + "/" + InstalledPlugins.Count +
                                ")");
                        }

                        double tmpp = Math.Round((double) (100*((i + 1)/InstalledPlugins.Count)));
                        if (tmpp > 100)
                            tmpp = 100;
                        SetProgress(Convert.ToByte(tmpp));
                    }
                }
                Logger.Log(LogLevel.Info, "PluginUpdater", "Loaded plugin data (" + InstalledPlugins.Count + ")");
                LoadUi();
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Severe, "PluginUpdater", "Severe exception in LoadAsync routine!", ex.Message);
            }
        }

        /// <summary>
        ///     Load the user interface with the listview items, once all data is loaded.
        /// </summary>
        /// <remarks></remarks>
        private void LoadUi()
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke((MethodInvoker) LoadUi);
                }
                else
                {
                    if (_pluginLinkDictionary == null)
                        return;
                    SetStatus(T.Tr("Loading plugin data to screen..."));
                    Logger.Log(LogLevel.Info, "PluginUpdater", "Loading UI data (" + _pluginLinkDictionary.Count + ")");
                    foreach (KeyValuePair<InstalledPlugin, BukgetPlugin> entry in _pluginLinkDictionary)
                    {
                        try
                        {
                            ListViewItem lvi;
                            if (entry.Value == null)
                            {
                                string[] content =
                                {
                                    entry.Key.Name,
                                    entry.Key.Version,
                                    T.Tr("No data available"),
                                    T.Tr("No data available")
                                };
                                lvi = new ListViewItem(content) {BackColor = Color.LightGray, Tag = "FALSE"};
                            }
                            else
                            {
                                if (entry.Value.VersionsList == null || entry.Value.VersionsList.Count < 1)
                                {
                                    string[] content =
                                    {
                                        entry.Key.Name,
                                        entry.Key.Version,
                                        T.Tr("No downloads available"),
                                        T.Tr("No downloads available")
                                    };
                                    lvi = new ListViewItem(content) {BackColor = Color.LightGray, Tag = "FALSE"};
                                }
                                else
                                {
                                    string[] content =
                                    {
                                        entry.Key.Name,
                                        entry.Key.Version,
                                        entry.Value.VersionsList[0].VersionNumber,
                                        StringUtil.ListToCsv(entry.Value.VersionsList[0].CompatibleBuilds)
                                    };
                                    lvi = new ListViewItem(content) {Tag = "TRUE"};
                                    if (CheckVersion(entry.Key.Version, entry.Value.VersionsList[0].VersionNumber) == 1)
                                    {
                                        lvi.Checked = true;
                                    }
                                    else
                                    {
                                        lvi.Checked = false;
                                    }
                                }
                            }
                            SlvPlugins.Items.Add(lvi);
                        }
                        catch (Exception ex)
                        {
                            if (entry.Key != null && entry.Key.Name != null)
                            {
                                Logger.Log(LogLevel.Warning, "PluginUpdater", "Couldn't load plugin:" + entry.Key.Name,
                                    ex.Message);
                            }
                            else
                            {
                                Logger.Log(LogLevel.Warning, "PluginUpdater", "Couldn't load plugin", ex.Message);
                            }
                        }
                    }
                    SetStatus(T.Tr("Idle"));
                }
                if (UpdateOnLoad)
                    Plugins_Update();
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Severe, "PluginUpdater", "Severe exception in LoadUI routine!", ex.Message);
            }
        }

        /// <summary>
        ///     Close the form, prevent cross thread exceptions.
        /// </summary>
        /// <remarks></remarks>
        private void CloseThisForm(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker) CloseThisForm);
            }
            else
            {
                Close();
            }
        }

        private void SetStatus(string text)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker) (() => SetStatus(text)));
            }
            else
            {
                lblStatus.Text = T.Tr("Status:") + " " + text;
            }
        }

        private void SetProgress(byte progress)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker) (() => SetProgress(progress)));
            }
            else
            {
                ProgBar.Value = progress;
            }
        }

        /// <summary>
        ///     Update each plugin, if it's checked
        /// </summary>
        /// <remarks></remarks>
        private void Plugins_Update(object sender, EventArgs e)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke((MethodInvoker) (Plugins_Update));
                }
                else
                {
                    Logger.Log(LogLevel.Info, "PluginUpdater", "Starting plugins update");
                    if (SlvPlugins.CheckedItems.Count < 1)
                        return;
                    UInt16 i = 1;
                    foreach (ListViewItem item in SlvPlugins.CheckedItems)
                    {
                        if (item.Tag != null && Equals(item.Tag.ToString(), "TRUE"))
                        {
                            foreach (KeyValuePair<InstalledPlugin, BukgetPlugin> pair in _pluginLinkDictionary)
                            {
                                try
                                {
                                    if (pair.Key.Name == item.SubItems[0].Text)
                                    {
                                        if (pair.Value == null || pair.Value.VersionsList == null ||
                                            pair.Value.VersionsList[0] == null)
                                            continue;
                                        if (this != null && !(Disposing | IsDisposed) &&
                                            !(lblStatus.IsDisposed | lblStatus.Disposing))
                                            SetStatus(T.Tr("Updating plugin") + " " + pair.Key.Name + " " +
                                                      T.Tr("to version") + " " +
                                                      pair.Value.VersionsList[0].VersionNumber + " (" + i + "/" +
                                                      SlvPlugins.CheckedItems.Count + ")")
                                                ;
                                        Logger.Log(LogLevel.Info, "PluginUpdater", "Updating plugin:" + pair.Key.Name);
                                        BukgetPluginInstaller.Install(pair.Value.VersionsList[0], pair.Key.Path, false,
                                            false);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Logger.Log(LogLevel.Warning, "PluginUpdater",
                                        "Exception in Update routine for " + pair.Key.Name, ex.Message);
                                }
                            }
                        }
                        else
                        {
                            if (this != null && !(Disposing | IsDisposed) &&
                                !(lblStatus.IsDisposed | lblStatus.Disposing))
                                SetStatus(T.Tr("Skipping plugin") + " " + item.SubItems[0].Text + " - " +
                                          T.Tr("cannot update") + "(" + i +
                                          1 + " / " + _pluginLinkDictionary.Count + ")");
                            Logger.Log(LogLevel.Info, "PluginUpdater", "Skipping plugin:" + item.SubItems[0].Text);
                        }
                        double tmpp = Math.Round((double) ((100*(i + 1))/_pluginLinkDictionary.Count));
                        if (tmpp > 100)
                            tmpp = 100;
                        SetProgress(Convert.ToByte(tmpp));
                        i++;
                    }

                    if (this != null && !(Disposing | IsDisposed) && !(lblStatus.IsDisposed | lblStatus.Disposing))
                        SetStatus(T.Tr("Idle"));

                    if (this != null && BtnClose != null && !(Disposing | IsDisposed) &&
                        !(BtnClose.Disposing | BtnClose.IsDisposed))
                        BtnClose.Enabled = true;

                    InstalledPluginManager.RefreshAllInstalledPluginsAsync();

                    if (this != null && !(Disposing | IsDisposed))
                        Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(T.Tr("Something went wrong while updating. Please check if all plugins are updated."),
                    T.Tr("Something went wrong"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Log(LogLevel.Warning, "PluginUpdater", "Severe exception in Update routine!", ex.Message);
            }
        }

        private void ChkCheckAll_CheckedChanged(Object sender, EventArgs e)
        {
            if (ChkCheckAll.Checked)
            {
                foreach (ListViewItem item in SlvPlugins.Items)
                {
                    item.Checked = true;
                }
            }
            else
            {
                foreach (ListViewItem item in SlvPlugins.Items)
                {
                    item.Checked = false;
                }
            }
        }


        /// <summary>
        ///     Check which from 2 versions is newer. returns -1 if old version is newer, 0 if equal, 1 if new version is newer
        /// </summary>
        /// <param name="oldversion">the old version, x.x, x.x.x or x.x.x.x format</param>
        /// <param name="newversion">the new version, x.x, x.x.x or x.x.x.x format</param>
        /// <returns>-1 if old version is newer, 0 if equal, 1 if new version is newer</returns>
        /// <remarks>This function can handle version numbers with parts up to 65535</remarks>
        public int CheckVersion(string oldversion, string newversion)
        {
            try
            {
                Logger.Log(LogLevel.Info, "Common", "Comparing versions: " + oldversion + " - " + newversion);

                if (oldversion == null || string.IsNullOrEmpty(oldversion) || newversion == null ||
                    string.IsNullOrEmpty(newversion))
                {
                    Logger.Log(LogLevel.Warning, "Common", "Invalid version supplied!");
                    return 0;
                }
                oldversion = oldversion.Replace("-", ".");
                newversion = newversion.Replace("-", ".");
                oldversion = Regex.Replace(oldversion, "[a-zA-z]*\\s*", "");
                newversion = Regex.Replace(newversion, "[a-zA-z]*\\s*", "");

                foreach (char c in oldversion)
                {
                    if ((char.IsPunctuation(c) == false & char.IsNumber(c) == false))
                    {
                        Logger.Log(LogLevel.Warning, "Common", "Invalid version supplied!", "oldversion:" + oldversion);
                        return 1;
                    }
                }

                foreach (char c in newversion)
                {
                    if ((char.IsPunctuation(c) == false & char.IsNumber(c) == false))
                    {
                        Logger.Log(LogLevel.Warning, "Common", "Invalid version supplied!", "newversion:" + newversion);
                        return 1;
                    }
                }

                if (!oldversion.Contains("."))
                    oldversion += ".0.0.0";
                switch (oldversion.Split('.').Length)
                {
                    case 2:
                        oldversion += ".0.0";
                        break;
                    case 3:
                        oldversion += ".0";
                        break;
                }
                if (oldversion.StartsWith("."))
                    oldversion = "0" + oldversion;

                if (!newversion.Contains("."))
                    newversion += ".0.0.0";
                switch (newversion.Split('.').Length)
                {
                    case 2:
                        newversion += ".0.0";
                        break;
                    case 3:
                        newversion += ".0";
                        break;
                }
                if (newversion.StartsWith("."))
                    newversion = "0" + newversion;

                Logger.Log(LogLevel.Info, "Common", "Normalized versions: " + oldversion + " - " + newversion);

                Version ov = new Version(oldversion);
                Version nv = new Version(newversion);
                int res = nv.CompareTo(ov);
                Logger.Log(LogLevel.Info, "Common", "Result of version compare:" + res);
                return res;
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Warning, "Common", "Couldn't compare versions!", ex.Message);
                return 0;
            }
        }

        private void CloseThisForm()
        {
        }

        private void Plugins_Update()
        {
        }
    }
}