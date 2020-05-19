
using Franco28Tool.Engine;
using System;
using System.Xml;

namespace MotoTool
{
    public class StartTool
    {

        public static string xmlUrl = "https://mototoolengine.000webhostapp.com/MotoTool/Maintenance.xml";
        public static string Maintenanceok = "";
        public static XmlTextReader reader = null;

        public static void ToolMaintenance()
        {
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
                        Dialogs.ErrorDialog("Starting MotoTool server: ERROR", ex.Message);
                        Logs.DebugErrorLogs(ex);
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
