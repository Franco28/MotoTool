
using System.Diagnostics;

namespace Franco28Tool.Engine
{
    public class BrowserCheck
    {
        public static void StartBrowser(string Proc, string Args)
        {
            if (System.IO.File.Exists(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe") == true)
                Process.Start(Proc, Args);
            else if (System.IO.File.Exists(@"C:\Program Files\Google\Chrome\Application\chrome.exe") == true)
                Process.Start(Proc, Args);
            else if (System.IO.File.Exists(@"C:\Program Files\Google\Chrome\Application\MicrosoftEdge.exe") == false)
                Process.Start(Proc, Args);
            else if (System.IO.File.Exists(@"C:\Program Files (x86)\Google\Chrome\Application\MicrosoftEdge.exe") == false)
                Process.Start(Proc, Args);
        }
    }
}
