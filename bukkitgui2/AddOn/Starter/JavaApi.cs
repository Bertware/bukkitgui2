namespace Bukkitgui2.AddOn.Starter
{
    using System;
    using System.IO;

    internal static class JavaApi
    {
        private static Boolean _initialized;

        private static string _jre6X32 = "";

        private static string _jre6X64 = "";

        private static string _jre7X32 = "";

        private static string _jre7X64 = "";

        /// <summary>
        ///     Initialize the class, check available versions and paths
        /// </summary>
        public static void Initialize()
        {
            // TODO: BETTER API, REGISTRY SEARCH
            _initialized = true;
            if (File.Exists(ProgramFilesx86() + "\\Java\\jre6\\bin\\java.exe"))
            {
                _jre6X32 = ProgramFilesx86() + "\\Java\\jre6\\bin\\java.exe";
            }
            if (File.Exists(ProgramFiles() + "\\Java\\jre6\\bin\\java.exe"))
            {
                _jre6X64 = ProgramFiles() + "\\Java\\jre6\\bin\\java.exe";
            }
            if (File.Exists(ProgramFilesx86() + "\\Java\\jre7\\bin\\java.exe"))
            {
                _jre7X32 = ProgramFilesx86() + "\\Java\\jre7\\bin\\java.exe";
            }
            if (File.Exists(ProgramFiles() + "\\Java\\jre7\\bin\\java.exe"))
            {
                _jre7X64 = ProgramFiles() + "\\Java\\jre7\\bin\\java.exe";
            }
        }

        /// <summary>
        /// Returns true if a given version if installed
        /// </summary>
        /// <param name="jreVersion">The java version to check</param>
        /// <returns></returns>
        public static Boolean IsInstalled(JavaVersion jreVersion)
        {
            if (!_initialized)
            {
                Initialize();
            }
            switch (jreVersion)
            {
                case JavaVersion.Jre6X32:
                    return !string.IsNullOrEmpty(_jre6X32);
                case JavaVersion.Jre6X64:
                    return !string.IsNullOrEmpty(_jre6X64);
                case JavaVersion.Jre7X32:
                    return !string.IsNullOrEmpty(_jre7X32);
                case JavaVersion.Jre7X64:
                    return !string.IsNullOrEmpty(_jre7X64);
                default:
                    return false;
            }
        }

        /// <summary>
        /// Get the absolute location of an installed java version
        /// </summary>
        /// <param name="jreVersion">The java version to retrieve</param>
        /// <returns>Returns the absolute path to java.exe</returns>
        public static string GetJavaPath(JavaVersion jreVersion)
        {
            if (!_initialized)
            {
                Initialize();
            }
            switch (jreVersion)
            {
                case JavaVersion.Jre6X32:
                    return _jre6X32;
                case JavaVersion.Jre6X64:
                    return _jre6X64;
                case JavaVersion.Jre7X32:
                    return _jre7X32;
                case JavaVersion.Jre7X64:
                    return _jre7X64;
                default:
                    return null;
            }
        }

        private static string ProgramFilesx86()
        {
            if (8 == IntPtr.Size
                || (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))))
            {
                return Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            }

            return Environment.GetEnvironmentVariable("ProgramFiles");
        }

        private static string ProgramFiles()
        {
            return Environment.GetEnvironmentVariable("ProgramFiles");
        }
    }

    public enum JavaVersion
    {
        Jre6X32,

        Jre6X64,

        Jre7X32,

        Jre7X64
    }
}