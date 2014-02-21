using System;

namespace Bukkitgui2.MinecraftInterop.ProcessHandler
{
	/// <summary>
	/// Static class to store the current processHandler
	/// </summary>
	internal static class ProcessHandlerState
	{
		public static MinecraftServers.IMinecraftServer CurrentServer;
		public static Boolean IsRunning = false;
		public static IProcessHandler ProcessHandler ;
	}
}