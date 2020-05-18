

using System;
using System.Xml;

namespace Franco28Tool.Engine
{
    public class DownloadsMng
    {
        public static string DOWNLOADPath = "";
        public static string downloadUrl = "";
        public static string filename = "";
        public static string filepath = "";
        public static string filepathname = "";
        public static string SAVEPath = "";
        public static string SAVEPathname = "";
        public static string xmlUrl = "https://mototoolengine.000webhostapp.com/MotoTool/Devices/";
        public static XmlTextReader reader = null;

        public static void TOOLDOWNLOAD(string serverpath, string serverpath2, string fchannelname)
        {
            if (InternetCheck.ConnectToInternet() == true)
            {
                try
                {
                    reader = new XmlTextReader(xmlUrl + serverpath + serverpath2);
                    reader.MoveToContent();
                    string elementName = "";
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == fchannelname))
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
                                        case "url":
                                            downloadUrl = reader.Value;
                                            DOWNLOADPath = downloadUrl;
                                            break;
                                        case "name":
                                            filename = reader.Value;
                                            break;
                                        case "filepath":
                                            filepath = reader.Value;
                                            SAVEPath = filepath;
                                            break;
                                        case "filepathname":
                                            filepathname = reader.Value;
                                            SAVEPathname = filepathname;
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
                    Dialogs.ErrorDialog("Download Error", ex.Message);
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                }
            }
            else
            {
                Dialogs.ErrorDialog("Network Lost", "Network lost... Please check your internet connection!");
            }
        }
    }
}
