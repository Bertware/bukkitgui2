using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bukkitgui2.Core.Util
{
	static class UtilIO
	{

		public static void CreateDirectoryIfNotExists(string directory)
		{
			if (System.IO.Directory.Exists(directory)) return;

			System.IO.Directory.CreateDirectory(directory);
		}
	}
}
