// SettingsCheckbox.cs in bukkitgui2/bukkitgui2
// Created 2014/07/13
// Last edited at 2014/08/17 11:19
// ©Bertware, visit http://bertware.net

using System;
using MetroFramework.Controls;
using Net.Bertware.Bukkitgui2.Core.Configuration;

namespace Net.Bertware.Bukkitgui2.Controls
{
    internal class SettingsCheckbox : MetroCheckBox
    {
        private string _ident, _key;
        private Boolean _defaultvalue;

        /// <summary>
        ///     Link this checkbox to a settings value to automaticly load and save settings
        /// </summary>
        /// <param name="ident"></param>
        /// <param name="key"></param>
        /// <param name="defaultvalue"></param>
        public void Link(string ident, string key, Boolean defaultvalue)
        {
            _ident = ident;
            _key = key;
            _defaultvalue = defaultvalue;
            Checked = Config.ReadBool(_ident, _key, _defaultvalue);
            CheckedChanged += OnCheckedChange;
        }

        public void Unlink()
        {
            CheckedChanged -= OnCheckedChange;
        }

        private void OnCheckedChange(object sender, EventArgs e)
        {
            Config.WriteBool(_ident, _key, Checked);
        }
    }
}