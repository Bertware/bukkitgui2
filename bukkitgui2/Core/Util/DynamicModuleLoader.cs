namespace Net.Bertware.Bukkitgui2.Core.Util
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    internal class DynamicModuleLoader
    {
        /// <summary>
        ///     Get a list of all available classes, full name
        /// </summary>
        /// <returns></returns>
        internal static List<string> ListClasses(string @namespace)
        {
            List<string> classes = new List<string>();

            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == @namespace
                    select t;
            q.ToList().ForEach(t => classes.Add(t.FullName));
            return classes;
        }
    }
}