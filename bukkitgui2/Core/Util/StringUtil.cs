// StringUtil.cs in bukkitgui2/bukkitgui2
// Created 2014/08/06
// Last edited at 2014/08/17 11:19
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;

namespace Net.Bertware.Bukkitgui2.Core.Util
{
	internal class StringUtil
	{
		public static string ListToCsv(IEnumerable<object> list)
		{
			if (list == null) return "";
			string result = "";
			foreach (Object obj in list)
			{
				result += obj + ", ";
			}
			result = result.Substring(0, result.Length - 2); //remove the last ", "
			return result;
		}

		public static string ListToCsv<T>(List<T> list)
		{
			if (list == null || list.Count < 1) return "";
			string result = "";
			foreach (Object obj in list)
			{
				result += obj + ", ";
			}
			result = result.Substring(0, result.Length - 2); //remove the last ", "
			return result;
		}
	}
}