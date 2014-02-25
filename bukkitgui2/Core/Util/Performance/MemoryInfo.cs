using Microsoft.VisualBasic.Devices;

namespace Bukkitgui2.Core.Util.Performance
{
    using System;

    /// <summary>
    /// Provide information over total, used, available memory
    /// </summary>
    static class MemoryInfo
    {

        public static Int64 TotalMemory()
        {
            return Convert.ToInt64(new Computer().Info.TotalPhysicalMemory);
        }

        public static Int64 TotalMemoryMb()
        {
            return Convert.ToInt64(TotalMemory() / 1048576);
        }


    }
}
