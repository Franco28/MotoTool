
using System.Collections.Generic;
using System.IO;

namespace Franco28Tool.Engine
{
    public static class ResourceFolderManager
    {
        private static readonly DirectoryInfo TOOL_DRIVERS_DIRECTORY;
        private static Dictionary<string, DirectoryInfo> controlledFolders;

        static ResourceFolderManager()
        {
            TOOL_DRIVERS_DIRECTORY = new DirectoryInfo("C:\\");
            controlledFolders = new Dictionary<string, DirectoryInfo>();

            if (!TOOL_DRIVERS_DIRECTORY.Exists)
                TOOL_DRIVERS_DIRECTORY.Create();

            foreach (DirectoryInfo d in TOOL_DRIVERS_DIRECTORY.GetDirectories("*", SearchOption.TopDirectoryOnly))
                controlledFolders.Add(d.Name, d);
        }

        public static DirectoryInfo GetRegisteredFolder(string folder)
        {
            return (controlledFolders.ContainsKey(folder) ? controlledFolders[folder] : null);
        }

        public static string GetRegisteredFolderPath(string folder)
        {
            return (controlledFolders.ContainsKey(folder) ? controlledFolders[folder].FullName : null);
        }

        public static bool Register(string name)
        {
            if (controlledFolders.ContainsKey(name))
                return false;

            controlledFolders.Add(name, new DirectoryInfo(TOOL_DRIVERS_DIRECTORY + name));

            if (!controlledFolders[name].Exists)
                controlledFolders[name].Create();

            return true;
        }

        public static bool Unregister(string name)
        {
            if (!controlledFolders.ContainsKey(name))
                return false;

            try { controlledFolders[name].Delete(true); }
            catch { return false; }

            return controlledFolders.Remove(name);
        }
    }
}
