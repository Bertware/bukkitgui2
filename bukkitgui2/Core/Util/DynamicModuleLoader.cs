// DynamicModuleLoader.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Net.Bertware.Bukkitgui2.Core.Util
{
	internal class DynamicModuleLoader
	{
		/// <summary>
		///     Get a list of all available classes, full name
		/// </summary>
		/// <returns></returns>
		internal static List<string> ListClasses(string @namespace)
		{
			List<string> classes = new List<string>();

			IEnumerable<Type> q = from t in Assembly.GetExecutingAssembly().GetTypes()
				where t.IsClass && t.Namespace == @namespace
				select t;
			q.ToList().ForEach(t => classes.Add(t.FullName));
			return classes;
		}

		/// <summary>
		///     Get a list of all available classes, full name
		/// </summary>
		/// <returns></returns>
		internal static List<string> ListClassesOfType(string @namespace, Type T)
		{
			List<string> classes = new List<string>();

			IEnumerable<Type> q = from t in Assembly.GetExecutingAssembly().GetTypes()
				where t.IsClass && t.Namespace == @namespace && (t == T || InheritsFromInterface(t, T))
				select t;
			q.ToList().ForEach(t => classes.Add(t.FullName));
			return classes;
		}

		/// <summary>
		///     Get a list of all available classes, full name
		/// </summary>
		/// <returns></returns>
		internal static List<string> ListClassesRecursive(string @namespace)
		{
			List<string> classes = new List<string>();

			IEnumerable<Type> q = from t in Assembly.GetExecutingAssembly().GetTypes()
				where t.IsClass && t.Namespace != null && t.Namespace.StartsWith(@namespace)
				select t;
			q.ToList().ForEach(t => classes.Add(t.FullName));
			return classes;
		}


		/// <summary>
		///     Get a list of all available classes, full name
		/// </summary>
		/// <returns></returns>
		internal static List<Type> ListClassesRecursiveOfType<T>(string @namespace)
		{
			List<Type> classes = new List<Type>();

			IEnumerable<Type> q = from t in Assembly.GetExecutingAssembly().GetTypes()
				where
					t.IsClass && t.Namespace != null && t.Namespace.StartsWith(@namespace) &&
					(t == typeof (T) || InheritsFromInterface(t, typeof (T)))
				select t;
			q.ToList().ForEach(classes.Add);
			return classes;
		}

		/// <summary>
		///     Get a list of class instances of all classes of a given type/interface in a given namespace
		/// </summary>
		/// <returns></returns>
		internal static List<T> GetClassesOfType<T>(string @namespace)
		{
			List<T> classes = new List<T>();

			Assembly thisAssembly = Assembly.GetExecutingAssembly();
			foreach (string entry in ListClasses(@namespace))
			{
				if (!(InheritsFromInterface(thisAssembly.GetType(entry), typeof (T)))) continue;
				T instance = (T) Activator.CreateInstance(thisAssembly.GetType(entry));
				classes.Add(instance);
			}

			return classes;
		}

		public static bool InheritsFromInterface(Type inheritor, Type @interface)
		{
			if (inheritor == @interface) return true;
			Type result = inheritor.GetInterface(@interface.FullName);
			return result != null;
		}
	}
}