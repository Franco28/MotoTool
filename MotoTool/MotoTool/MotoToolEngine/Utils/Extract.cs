
using System;
using System.IO;
using System.Reflection;

namespace Franco28Tool.Engine
{
    public class Extract
    {
        public static void ExtractAll()
        {
            try
            {
                if (!File.Exists("C:\\adb\\adb.exe"))
                {
                    Stream adb1 = Assembly.GetExecutingAssembly().GetManifestResourceStream("Franco28Tool.Engine.Resources.adb.adb.exe");
                    FileStream adb = new FileStream("adb.exe", FileMode.CreateNew);
                    for (int i = 0; i < adb1.Length; i++)
                        adb.WriteByte((byte)adb1.ReadByte());
                    adb.Close();
                }

                if (!File.Exists("C:\\adb\\fastboot.exe"))
                {
                    Stream fastboot1 = Assembly.GetExecutingAssembly().GetManifestResourceStream("Franco28Tool.Engine.Resources.adb.fastboot.exe");
                    FileStream fastboot = new FileStream("fastboot.exe", FileMode.CreateNew);
                    for (int i = 0; i < fastboot1.Length; i++)
                        fastboot.WriteByte((byte)fastboot1.ReadByte());
                    fastboot.Close();
                }

                if (!File.Exists("C:\\adb\\AdbWinUsbApi.dll"))
                {
                    Stream AdbWinUsbApi1 = Assembly.GetExecutingAssembly().GetManifestResourceStream("Franco28Tool.Engine.Resources.adb.AdbWinUsbApi.dll");
                    FileStream AdbWinUsbApi = new FileStream("AdbWinUsbApi.dll", FileMode.CreateNew);
                    for (int i = 0; i < AdbWinUsbApi1.Length; i++)
                        AdbWinUsbApi.WriteByte((byte)AdbWinUsbApi1.ReadByte());
                    AdbWinUsbApi.Close();
                }

                if (!File.Exists("C:\\adb\\AdbWinApi.dll"))
                {
                    Stream AdbWinApi1 = Assembly.GetExecutingAssembly().GetManifestResourceStream("Franco28Tool.Engine.Resources.adb.AdbWinApi.dll");
                    FileStream AdbWinApi = new FileStream("AdbWinApi.dll", FileMode.CreateNew);
                    for (int i = 0; i < AdbWinApi1.Length; i++)
                        AdbWinApi.WriteByte((byte)AdbWinApi1.ReadByte());
                    AdbWinApi.Close();
                }

                if (!File.Exists("C:\\adb\\libwinpthread-1.dll"))
                {
                    Stream libwinpthread1 = Assembly.GetExecutingAssembly().GetManifestResourceStream("Franco28Tool.Engine.Resources.adb.libwinpthread-1.dll");
                    FileStream libwinpthread = new FileStream("libwinpthread-1.dll", FileMode.CreateNew);
                    for (int i = 0; i < libwinpthread1.Length; i++)
                        libwinpthread.WriteByte((byte)libwinpthread1.ReadByte());
                    libwinpthread.Close();
                }

                if (!File.Exists("C:\\adb\\source.properties"))
                {
                    Stream source1 = Assembly.GetExecutingAssembly().GetManifestResourceStream("Franco28Tool.Engine.Resources.adb.source.properties");
                    FileStream source = new FileStream("source.properties", FileMode.CreateNew);
                    for (int i = 0; i < source1.Length; i++)
                        source.WriteByte((byte)source1.ReadByte());
                    source.Close();
                }
            }
            catch (Exception er)
            {
                Logs.DebugErrorLogs(er);
                Dialogs.ErrorDialog(@"FATAL ERROR EXTRACTING ADB-FASTBOOT:", "Error: " + er);
            }
        }
    }
}
