
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

        [STAThread]
        static void Main()
        {
            string ToolVer = Assembly.GetEntryAssembly().GetName().Version.ToString();
            StartTool.ToolMaintenance();
            string tr = "TRUE";
            string fal = "FALSE";
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
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm());
                }
            }
            catch (MyException er)
            {
                Logs.DebugErrorLogs(er);
                Dialogs.ErrorDialog(@"FATAL ERROR: You can see logs on C:\adb\.settings\logs\", "Error: " + er);
                Folders.OpenFolder(@"adb\.settings\logs");
                Application.ExitThread();
            }
        }
    }
}
