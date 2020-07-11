
using System;
using System.Xml;

namespace Franco28Tool.Engine
{
    public class ReadMSGInfo
    {
        public static string xmlUrl = "https://raw.githubusercontent.com/Franco28/MotoTool/master/Server/Info.xml";
        public static string showmsg = "";
        public static string msgen = "";
        public static string msges = "";

        public static XmlTextReader reader = null;

        public static void ReadInfo()
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
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "info"))
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
                                            case "showmsg":
                                                showmsg = reader.Value;
                                                break;
                                            case "msgen":
                                                msgen = reader.Value;
                                                break;
                                            case "msges":
                                                msges = reader.Value;
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
                    return;
                }
            }
            else
            {
                Strings.MSGBOXServerNetworkLost();
                return;
            }
        }
    }
}
