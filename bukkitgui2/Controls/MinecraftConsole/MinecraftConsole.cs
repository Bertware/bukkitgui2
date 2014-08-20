// MinecraftConsole.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// Last edited at 2014/08/17 11:19
// ©Bertware, visit http://bertware.net

using System;
using System.Drawing;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.MinecraftInterop.OutputHandler;

namespace Net.Bertware.Bukkitgui2.Controls.MinecraftConsole
{
    /// <summary>
    ///     RichTextBox which has markup for Minecraft server output
    /// </summary>
    public class MinecraftConsole : RichTextBox
    {
        /// <summary>
        ///     Gets or sets the message color for informative text.
        /// </summary>
        public Color MessageColorInfo { get; set; }

        /// <summary>
        ///     Gets or sets the message color for text describing a player action (join, disconnect, ...).
        /// </summary>
        public Color MessageColorPlayerAction { get; set; }

        /// <summary>
        ///     Gets or sets the message color for player names.
        /// </summary>
        public Color MessageColorPlayerTag { get; set; }

        /// <summary>
        ///     Gets or sets the message color for plugin tags.
        /// </summary>
        public Color MessageColorPluginTag { get; set; }

        /// <summary>
        ///     Gets or sets the message color for text containeing severe errors.
        /// </summary>
        public Color MessageColorSevere { get; set; }

        /// <summary>
        ///     Gets or sets the message color for unknown or other text typess.
        /// </summary>
        public Color MessageColorUnknown { get; set; }

        /// <summary>
        ///     Gets or sets the message color for text containing warnings.
        /// </summary>
        public Color MessageColorWarning { get; set; }

        /// <summary>
        ///     Wether or not the date should be shown before each message
        /// </summary>
        public Boolean ShowDate { get; set; }

        /// <summary>
        ///     Wether or not the time should be shown before each message
        /// </summary>
        public Boolean ShowTime { get; set; }

        /// <summary>
        ///     Autoscroll down or not
        /// </summary>
        public Boolean Autoscroll { get; set; }

        public MinecraftConsole()
        {
            MessageColorInfo = Color.Blue;
            MessageColorPlayerAction = Color.DarkGreen;
            MessageColorSevere = Color.DarkRed;
            MessageColorWarning = Color.DarkOrange;
            CreateContextMenu();
            Autoscroll = true;
        }

        public void ScrollDown()
        {
            Select(TextLength, 0);
            ScrollToCaret();
        }

        /// <summary>
        ///     Writes text to the Console Control
        /// </summary>
        /// <param name="type"> The message type. </param>
        /// <param name="text"> The message text. </param>
        public void WriteOutput(MessageType type, string text)
        {
            //suport for calls from other threads
            if (InvokeRequired)
            {
                Invoke((MethodInvoker) (() => WriteOutput(type, text)));
            }
            else
            {
                Color messageColor = MessageColorUnknown;
                switch (type)
                {
                    case MessageType.Info:
                        messageColor = MessageColorInfo;
                        break;
                    case MessageType.JavaStatus:
                    case MessageType.Warning:
                        messageColor = MessageColorWarning;
                        break;
                    case MessageType.Severe:
                    case MessageType.JavaStackTrace:

                        messageColor = MessageColorSevere;
                        break;
                    case MessageType.PlayerJoin:
                    case MessageType.PlayerLeave:
                    case MessageType.PlayerKick:
                    case MessageType.PlayerBan:
                    case MessageType.PlayerIpBan:
                        messageColor = MessageColorPlayerAction;
                        break;
                }

                text = AddTimeStamp(text);

                SelectionStart = TextLength;
                SelectionColor = messageColor;
                SelectedText = text + '\r' + '\n';
                if (Autoscroll) Scrolldown();
            }
        }

        /// <summary>
        ///     Add a timestamp before a text message
        /// </summary>
        /// <param name="text">the text to alter</param>
        /// <returns></returns>
        private string AddTimeStamp(string text)
        {
            if (ShowTime) text = DateTime.Now.ToLongTimeString() + ' ' + text;
            if (ShowDate) text = DateTime.Now.ToShortDateString() + ' ' + text;
            return text;
        }

        /// <summary>
        ///     Scroll to the bottom of the text
        /// </summary>
        private void Scrolldown()
        {
            SelectionStart = TextLength;
            ScrollToCaret();
        }


        private void CreateContextMenu()
        {
            MenuItem[] menuItem = new MenuItem[1];
            menuItem[0] = new MenuItem("Autoscroll", ToggleAutoScroll) {Checked = Autoscroll, Enabled = true};
            ContextMenu cm = new ContextMenu(menuItem);
            ContextMenu = cm;
        }

        private void ToggleAutoScroll(object sender, EventArgs e)
        {
            Autoscroll = !Autoscroll;
            ContextMenu.MenuItems[0].Checked = Autoscroll;
        }
    }
}