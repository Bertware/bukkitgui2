// ConsoleInput.cs in bukkitgui2/bukkitgui2
// Created 2014/02/21
// Last edited at 2014/08/17 11:19
// ©Bertware, visit http://bertware.net

using System;
using System.Windows.Forms;
using MetroFramework.Controls;
using Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler;

namespace Net.Bertware.Bukkitgui2.Controls.ConsoleInput
{
    internal class ConsoleInput : MetroTextBox
    {
        /// <summary>
        ///     If autocompletion should be enabled or not
        /// </summary>
        public Boolean AutoCompletion { get; set; }

        /// <summary>
        ///     Eventhandler for CommandSent
        /// </summary>
        /// <param name="text"></param>
        public delegate void CommandSentEventHandler(string text);

        /// <summary>
        ///     Ran when a command is sent
        /// </summary>
        public event CommandSentEventHandler CommandSent;

        public ConsoleInput()
        {
            KeyPress += HandleKeyPress;
            CreateContextMenu();
            ProcessHandler.ServerStarted += ProcessHandler_ServerStarted;
        }

        private void ProcessHandler_ServerStarted()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker) ProcessHandler_ServerStarted);
            }
            else
            {
                Focus();
            }
        }

        /// <summary>
        ///     Handle a keypress
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event parameters</param>
        private void HandleKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                CommandSentEventHandler handler = CommandSent;
                if (handler != null)
                {
                    handler(Text);
                    if (AutoCompletion)
                    {
                        //if (AutoCompleteCustomSource != null)
                        //{
                        //	AutoCompleteCustomSource.Add(Text);
                        //}
                    }
                }
                Text = "";
                e.Handled = true;
            }
        }

        /// <summary>
        ///     Clear the autocompletion history
        /// </summary>
        public void ClearAutoCompletionHistory()
        {
            //if (AutoCompleteCustomSource != null)
            //{
            //	AutoCompleteCustomSource.Clear();
            //}
        }

        private void CreateContextMenu()
        {
            MenuItem[] menuItem = new MenuItem[1];
            menuItem[0] = new MenuItem("Autocompletion", ToggleAutoCompletion)
            {
                Checked = AutoCompletion,
                Enabled = true
            };
            ContextMenu cm = new ContextMenu(menuItem);
            ContextMenu = cm;
        }

        private void ToggleAutoCompletion(object sender, EventArgs e)
        {
            AutoCompletion = !AutoCompletion;
            ContextMenu.MenuItems[0].Checked = AutoCompletion;
        }
    }
}