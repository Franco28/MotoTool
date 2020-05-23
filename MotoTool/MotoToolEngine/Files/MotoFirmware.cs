
using System;
using System.IO;

namespace Franco28Tool.Engine
{
    public class MotoFirmware
    {

        static string firmwarelink = "https://mirrors.lolinet.com/firmware/moto/";

        public static void FirmwareServer(string device, string fchannel)
        {
            if (File.Exists(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe") & File.Exists(@"C:\Program Files\Google\Chrome\Application\chrome.exe") == true)
            {
                BrowserCheck.StartBrowser("MicrosoftEdge.exe", firmwarelink + device + fchannel);
            }
            else
            {
                BrowserCheck.StartBrowser("Chrome.exe", firmwarelink + device + fchannel);
            }
        }

        public static void CreateFolders(string Foldername)
        {
            var paths = new[] { Foldername };

            foreach (var path in paths)
            {
                try
                {
                    if (Directory.Exists(path))
                    {
                        Directory.SetCurrentDirectory(@"C:\adb");
                        continue;
                    }

                    var di = Directory.CreateDirectory(path);
                }
                catch (Exception er)
                {
                    Logs.DebugErrorLogs(er);
                    Dialogs.ErrorDialog("ERROR: Creating Folders", "Error: " + er);
                    return;
                }
            }
        }

        public static void OpenFirmwareFolder(string firmchannel)
        {
            try
            {
                Folders.OpenFolder(@"adb\Firmware\"+firmchannel);
            }
            catch (Exception er)
            {
                Logs.DebugErrorLogs(er);
                Dialogs.ErrorDialog("ERROR: Open Folder", "Error: " + er);
                return;
            }
        }

        public static bool ZipFiles(string firmwarecodename)
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\adb\Firmware\"+firmwarecodename);
            return di.GetFiles("*.zip").Length > 0;
        }
    }
}
