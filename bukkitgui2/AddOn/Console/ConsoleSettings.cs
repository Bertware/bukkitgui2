// ConsoleSettings.cs in bukkitgui2/bukkitgui2
// Created 2014/05/24
// Last edited at 2014/08/17 11:19
// ©Bertware, visit http://bertware.net

using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Controls;
using Net.Bertware.Bukkitgui2.Core.Configuration;

namespace Net.Bertware.Bukkitgui2.AddOn.Console
{
	public partial class ConsoleSettings : MetroUserControl
    {
        public ConsoleSettings()
        {
            InitializeComponent();

            CpInfo.Color = Color.FromArgb(Config.ReadInt("console", "color_info", Color.Blue.ToArgb()));
            cpPlayer.Color = Color.FromArgb(Config.ReadInt("console", "color_playeraction", Color.DarkGreen.ToArgb()));
            cpSevere.Color = Color.FromArgb(Config.ReadInt("console", "color_severe", Color.DarkRed.ToArgb()));
            cpWarn.Color = Color.FromArgb(Config.ReadInt("console", "color_warning", Color.DarkOrange.ToArgb()));
            chkDate.Link("console", "date", false);
            chkTime.Link("console", "time", true);
        }

        private void CpInfo_ColorChanged(Color color)
        {
            Config.WriteInt("console", "color_info", CpInfo.Color.ToArgb());
        }

        private void cpWarn_ColorChanged(Color color)
        {
            Config.WriteInt("console", "color_warning", cpWarn.Color.ToArgb());
        }

        private void cpSevere_ColorChanged(Color color)
        {
            Config.WriteInt("console", "color_severe", cpSevere.Color.ToArgb());
        }

        private void cpPlayer_ColorChanged(Color color)
        {
            Config.WriteInt("console", "color_playeraction", cpPlayer.Color.ToArgb());
        }
    }
}