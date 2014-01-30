using System.Windows.Forms;

namespace bukkitgui2.AddOn
{
	interface IAddon
	{
		/// <summary>
		/// The addon name, ideally this name is the same as used in the tabpage
		/// </summary>
		string name {get;}

		/// <summary>
		/// Initialize all functions and the tabcontrol
		/// </summary>
		void Initialize();

		/// <summary>
		/// The tab control for this addon
		/// </summary>
		/// <returns>Returns the tabpage</returns>
		TabPage Tabpage		
		{
			get;
		}

	}
}
