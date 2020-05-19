
using AndroidCtrl.ADB;
using AndroidCtrl.Fastboot;
using Franco28Tool.Engine;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace MotoTool
{
    static class Program
    {

        [Serializable]
        public class MyException : Exception
        {
            public MyException() { }
            public MyException(string message) : base(message) { }
            public MyException(string message, Exception inner) : base(message, inner) { }
            protected MyException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }

        private static SettingsMng oConfigMng = new SettingsMng();

        [STAThread]
        static void Main()
        {
            StartTool.ToolMaintenance();
            string tr = "true";
            string fal = "false";
            try
            {
                if (StartTool.Maintenanceok == tr)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new ToolMaintenance());
                }
                if (StartTool.Maintenanceok == fal)
                {
                    Folders.create_main_folders();
                    Extract.ExtractAll();
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm());
                }
            }
            catch (MyException er)
            {
                Logs.DebugErrorLogs(er);
                Dialogs.ErrorDialog(@"FATAL ERROR: You can see logs on C:\adb\.settings\logs\", "Error: " + er);
                PanicKill();
            }
        }

        public static void PanicKill()
        {
            oConfigMng.SaveConfig();
            ADB.ConnectionMonitor.Stop();
            ADB.Stop();
            Fastboot.Dispose();
            ADB.Dispose();
            Application.ExitThread();
            Application.Exit();
        }
    }
}
