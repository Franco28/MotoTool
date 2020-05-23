
using System;
using System.IO;

namespace Franco28Tool.Engine
{
    public class Logs
    {
        public static void DebugErrorLogs(Exception er)
        {
            string filePath = @"C:\adb\.settings\Logs\error.txt";
            Exception ex = er;
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("-----------------------------------------------------------------------------");
                writer.WriteLine("Date : " + DateTime.Now.ToString());
                writer.WriteLine();

                while (ex != null)
                {
                    writer.WriteLine(ex.GetType().FullName);
                    writer.WriteLine("Message : " + ex.Message);
                    writer.WriteLine("StackTrace : " + ex.StackTrace);
                    ex = ex.InnerException;
                }
            }
        }
    }
}
