
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Franco28Tool.Engine
{
   public class Folders
   {
        private SettingsMng oConfigMng = new SettingsMng();

        public static void OpenFolder(object folderpath)
        {
            string Proc = "Explorer.exe";
            string Args = ControlChars.Quote + Path.Combine(@"C:\" + folderpath) + ControlChars.Quote;
            Process.Start(Proc, Args);
        }

        public static void create_main_folders()
        {
            var paths = new[] {"C:\\adb\\", "C:\\adb\\TWRP", "C:\\adb\\Others", "C:\\adb\\.settings", "C:\\adb\\.settings\\Logs", "C:\\adb\\Firmware" };

            foreach (var path in paths)
            {
                if (Directory.Exists(path))
                {
                    Directory.SetCurrentDirectory(@"C:\adb");
                    continue;
                }
                else
                {
                    var di = Directory.CreateDirectory(path);
                }
            }
        }

        public static void ClearFolders()
        {
            var paths = new[] {"C:\\adb\\"};

                foreach (var path in paths)
                {

                    if (Directory.Exists(path))
                    {
                        Directory.Delete(path, true);
                    }
                }
            Dialogs.InfoDialog("Clear folders", "All Folders cleared! The app will restart!");
            Application.ExitThread();
            Application.Restart();
        }

        protected virtual bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return false;
        }

        public static long GetDirectorySize(string path)
        {
            string[] files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            long size = 0;
            foreach (string file in files)
            {
                FileInfo info = new FileInfo(file);
                size += info.Length;
            }
            size /= 1000000;
            return size;
        }
    }
}
