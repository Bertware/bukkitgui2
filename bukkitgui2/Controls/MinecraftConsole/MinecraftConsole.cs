namespace Bukkitgui2.Controls.MinecraftConsole
{
    using System.Drawing;
    using System.Windows.Forms;

    using Bukkitgui2.MinecraftInterop.OutputHandler;

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

        public void ScrollDown()
        {
            this.Select(this.TextLength, 0);
            this.ScrollToCaret();
        }

        /// <summary>
        ///     The write output.
        /// </summary>
        /// <param name="type"> The message type. </param>
        /// <param name="text"> The message text. </param>
        public void WriteOutput(MessageType type, string text)
        {
            Color messageColor = this.MessageColorUnknown;
            switch (type)
            {
                case MessageType.Info:
                    messageColor = this.MessageColorInfo;
                    break;
                case MessageType.Warning:
                    messageColor = this.MessageColorWarning;
                    break;
                case MessageType.Severe:
                    messageColor = this.MessageColorSevere;
                    break;
                case MessageType.PlayerJoin:
                    messageColor = this.MessageColorPlayerAction;
                    break;
                case MessageType.PlayerLeave:
                    messageColor = this.MessageColorPlayerAction;
                    break;
                case MessageType.PlayerKick:
                    messageColor = this.MessageColorPlayerAction;
                    break;
                case MessageType.PlayerBan:
                    messageColor = this.MessageColorPlayerAction;
                    break;
                case MessageType.PlayerIpBan:
                    messageColor = this.MessageColorPlayerAction;
                    break;
            }

            this.SelectionStart = this.TextLength;
            this.SelectionColor = messageColor;
            this.SelectedText = text;
        }
    }
}