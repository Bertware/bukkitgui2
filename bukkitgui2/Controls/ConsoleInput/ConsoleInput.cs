using System;
using System.Windows.Forms;

namespace Bukkitgui2.Controls.ConsoleInput
{
	internal class ConsoleInput : TextBox
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
						if (AutoCompleteCustomSource != null)
						{
							AutoCompleteCustomSource.Add(Text);
						}
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
			if (AutoCompleteCustomSource != null)
			{
				AutoCompleteCustomSource.Clear();
			}
		}
	}
}