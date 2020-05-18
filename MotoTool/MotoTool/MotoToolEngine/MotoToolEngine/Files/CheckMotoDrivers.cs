
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Franco28Tool.Engine
{
    public class CheckMotoDrivers
    {
        public static void MotoDrivers()
        {
            Dialogs.ErrorDialog("Error: Motrola Drivers", "Error on loading Motorola drivers... Now Tool will install it!");
            Process process = new Process();
            ProcessStartInfo processStartInfo = new ProcessStartInfo(@"C:\Program Files\MotoTool\MotorolaDeviceManager_2.5.4.exe");
            process.StartInfo = processStartInfo;
            Dialogs.WarningDialog("Motrola Drivers: Warning", "Please install the following drivers! MotoTool will be closed!");
            if (!process.Start())
            {
                try
                {
                    Process myprocess = new Process();
                    string arg = @"/c taskkill /f";
                    try
                    {
                        foreach (Process p in Process.GetProcessesByName("adb.exe"))
                        {
                            arg += " /pid " + p.Id;
                        }
                        ProcessStartInfo process2 = new ProcessStartInfo("cmd");
                        process2.UseShellExecute = false;
                        process2.CreateNoWindow = true;
                        process2.Verb = "runas";
                        process2.Arguments = arg;
                        Process.Start(process2);
                    }
                    catch (Exception er)
                    {
                        Logs.DebugErrorLogs(er);
                        Dialogs.ErrorDialog("Error: Killing Process {0}", "Killing process failed: {ADB} " + er.Message);
                    }
                    process.WaitForExit();
                    Application.Restart();
                }
                catch (Exception er)
                {
                    Logs.DebugErrorLogs(er);
                    Dialogs.ErrorDialog("Error: Exit Process", "Exit failed: {MotoToolUI} " + er.Message);
                }
            }
        }        
    }
}
