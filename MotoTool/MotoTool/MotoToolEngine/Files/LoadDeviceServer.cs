
using System;
using System.Xml;

namespace Franco28Tool.Engine
{
    public class LoadDeviceServer
    {
        public static string FirmwareServerPath = "https://mototoolengine.000webhostapp.com/MotoTool/Devices/";
        public static string amserver = "";
        public static string retserver = "";
        public static string othersserver = "";
        public static string tefserver = "";
        public static string devicecodename = "";
        public static string twrpname = "";
        public static string twrpinstallername = "";
        public static string unbrickname = "";
        public static string fserverMaintenance = "";
        public static XmlTextReader reader = null;

        public static void CheckDevice(string device, string readdevice)
        {
            if (InternetCheck.ConnectToInternet() == true)
            {
                if (InternetCheck.CheckServerRed(FirmwareServerPath + device) == false)
                {
                    try
                    {
                        reader = new XmlTextReader(FirmwareServerPath + device);
                        reader.MoveToContent();
                        string elementName = "";
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == readdevice))
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
                                            case "amserver":
                                                amserver = reader.Value;
                                                break;
                                            case "retserver":
                                                retserver = reader.Value;
                                                break;
                                            case "othersserver":
                                                othersserver = reader.Value;
                                                break;
                                            case "tefserver":
                                                tefserver = reader.Value;
                                                break;
                                            case "fserverMaintenance":
                                                fserverMaintenance = reader.Value;
                                                break;
                                            case "devicecodename":
                                                devicecodename = reader.Value;
                                                break;
                                            case "twrpname":
                                                twrpname = reader.Value;
                                                break;
                                            case "twrpinstallername":
                                                twrpinstallername = reader.Value;
                                                break;
                                            case "blankflashname":
                                                unbrickname = reader.Value;
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
                        Dialogs.ErrorDialog(Strings.DeviceServerErrorTitle, ex.Message);
                    }
                    finally
                    {
                        if (reader != null)
                            reader.Close();
                    }
                }
                else
                {
                    Dialogs.ErrorDialog("SERVER IS DOWN", "Please MotoTool will be back when server returns back!");
                }
            }
            else
            {
                Strings.MSGBOXServerNetworkLost();
            }
        }
    }
}
