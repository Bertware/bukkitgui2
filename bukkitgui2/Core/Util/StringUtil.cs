// StringUtil.cs in bukkitgui2/bukkitgui2
// Created 2014/08/06
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;

namespace Net.Bertware.Bukkitgui2.Core.Util
{
	internal class StringUtil
	{
		public static string ListToCsv(IEnumerable<object> list, char separator = ',')
		{
			if (list == null) return "";
			string result = "";
			foreach (Object obj in list)
			{
				result += obj + separator.ToString() + ' ';
			}
			result = result.Substring(0, result.Length - 2); //remove the last ", "
			return result;
		}

		public static string ListToCsv<T>(List<T> list, char separator = ',')
		{
			if (list == null || list.Count < 1) return "";
			string result = "";
			foreach (Object obj in list)
			{
				result += obj + separator.ToString() + ' ';
			}
			result = result.Substring(0, result.Length - 2); //remove the last ", "
			return result;
		}
	}
}