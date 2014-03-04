namespace Bukkitgui2.MinecraftServers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Bukkitgui2.Core.Logging;

    using Microsoft.VisualBasic.Logging;

    internal static class MinecraftServerLoader
    {
        /// <summary>
        ///     Get a list of all available server types
        /// </summary>
        /// <returns></returns>
        internal static Dictionary<string, IMinecraftServer> GetAvailableServers()
        {
            Dictionary<string, IMinecraftServer> servers = new Dictionary<string, IMinecraftServer>();

            foreach (string entry in ListClasses())
            {
                IMinecraftServer server =
                    Activator.CreateInstance(Assembly.GetExecutingAssembly().GetType(entry)) as IMinecraftServer;

                if (server == null)
                {
                    continue; //if not loaded, go on
                }

                if (!servers.ContainsKey(server.Name))
                {
                    servers.Add(server.Name, server);
                }
                else
                {
                    Core.Share.Logger.Log(
                        Core.Logging.LogLevel.Severe,
                        "MinecraftServerLoader",
                        "Can't add server to dictionary, duplicate name!",
                        server.Name);
                }
            }
            return servers;
        }

        /// <summary>
        ///     Get a list of all available server classes, full name
        /// </summary>
        /// <returns></returns>
        internal static List<string> ListClasses()
        {
            const string @Namespace = "Bukkitgui2.MinecraftServers.Servers";
            List<string> classes = new List<string>();

            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == @Namespace
                    select t;
            q.ToList().ForEach(t => classes.Add(t.FullName));
            return classes;
        }
    }
}