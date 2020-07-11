
using AndroidCtrl.ADB;
using AndroidCtrl.Fastboot;
using Franco28Tool.Engine;
using log4net;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace MotoTool
{
    static class Program
    {
        private static SettingsMng oConfigMng = new SettingsMng();
        public static string xmlUrl = "https://raw.githubusercontent.com/Franco28/MotoTool/master/Server/Maintenance.xml";
        public static string Maintenanceok = "";
        public static XmlTextReader reader = null;
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

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

        public static void ToolMaintenance()
        {
            _log.Debug("Loading MotoTool server...");
            if (InternetCheck.ConnectToInternet() == true)
            {
                if (InternetCheck.CheckServerRed(xmlUrl) == false)
                {
                    try
                    {
                        reader = new XmlTextReader(xmlUrl);
                        reader.MoveToContent();
                        string elementName = "";
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Maintenance"))
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Element)
                                {
                                    elementName = reader.Name;
                                }
                                else
                                {
                                    if ((reader.NodeType == XmlNodeType.Text) && (reader.HasValue))
                                    {
                                        switch (elementName)
                                        {
                                            case "Maintenanceok":
                                                Maintenanceok = reader.Value;
                                                break;
                                        }
                                    }
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        Logs.DebugErrorLogs(ex);
                        _log.Error("Loading MotoTool server...");
                        Dialogs.ErrorDialog("Starting MotoTool server: ERROR", ex.Message);
                        return;
                    }
                    finally
                    {
                        if (reader != null)
                            reader.Close();
                    }
                }
                else
                {
                    _log.Warn("Server is down... Please MotoTool will be back when server returns back!");
                    Dialogs.ErrorDialog("SERVER IS DOWN", "Please MotoTool will be back when server returns back!");
                    return;
                }
            }
            else
            {
                _log.Warn("Network lost...");
                Strings.MSGBOXServerNetworkLost();
                return;
            }
        }

        [STAThread]
        static void Main()
        {
            _log.Info("Loading MotoTool...");
            ToolMaintenance();
            string tr = "true";
            string fal = "false";
            try
            {
                if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
                {
                    MessageBox.Show(
                        "There seems to be another instance of the toolkit running. Please make sure it is not running in the background.",
                        "Another Instance is running", (MessageBoxButtons)System.Windows.MessageBoxButton.OK, (MessageBoxIcon)System.Windows.MessageBoxImage.Error);
                    PanicKill();
                }
                _log.Debug("Creating main folders...");
                Folders.create_main_folders();
                if (Maintenanceok == tr)
                {
                    _log.Info("MotoTool is on Maintenance");
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new ToolMaintenance());
                }
                if (Maintenanceok == fal)
                {
                    try
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        _log.Info("MotoTool is starting main form");
                        Application.Run(new MainForm());
                    }
                    catch (MyException er)
                    {
                        Logs.DebugErrorLogs(er);
                        _log.Error("FATAL ERROR: " + er);
                        Dialogs.ErrorDialog(@"FATAL ERROR: You can see logs on C:\MotoTool\.settings\logs\", "Error: " + er);
                        _log.Info("Calling panic kill...");
                        PanicKill();
                        return;
                    }
                }
            }
            catch (MyException er)
            {
                Logs.DebugErrorLogs(er);
                _log.Error("FATAL ERROR: " + er);
                Dialogs.ErrorDialog(@"FATAL ERROR: You can see logs on C:\MotoTool\.settings\logs\", "Error: " + er);
                _log.Info("Calling panic kill...");
                PanicKill();
                return;
            }
        }

        public static void PanicKill()
        {
            _log.Info("Calling panic kill... {OK}");
            Application.ExitThread();
            oConfigMng.SaveConfig();
            ADB.Stop();
            ADB.Stop(true);
            Fastboot.ForceStop();
            Fastboot.Dispose();
            Application.Exit();
        }
    }
}