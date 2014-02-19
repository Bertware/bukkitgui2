using System.Windows.Forms;

namespace Bukkitgui2.AddOn
{
	interface IAddon
	{
        /// <summary>
        /// The addon name, ideally this name is the same as used in the tabpage
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Initialize all functions and the tabcontrol
        /// </summary>
        void Initialize();

        /// <summary>
        /// The tab control for this addon
        /// </summary>
        /// <returns>Returns the tabpage</returns>
        UserControl Tabpage
        {
            get;
        }


	}
}
