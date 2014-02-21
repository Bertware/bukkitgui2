using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Bukkitgui2.AddOn
{
	public interface IAddonTab
	{
		IAddon ParentAddon { get; set; }
	}
}
