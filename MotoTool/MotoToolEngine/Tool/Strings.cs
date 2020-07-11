
using System.Globalization;
using System.Resources;

namespace Franco28Tool.Engine
{
    public class Strings
    {
        public static string DeviceServerErrorTitle = "Device Server: Error";
        public static CultureInfo cul;
        public static ResourceManager res_man;
        private static SettingsMng oConfigMng = new SettingsMng();

        public static void LangEngine()
        {
            res_man = new ResourceManager("Franco28Tool.Engine.Resources.lang.Res", typeof(MainForm).Assembly);

            oConfigMng.LoadConfig();

            if (oConfigMng.Config.ToolLang == "en")
            {
                cul = CultureInfo.CreateSpecificCulture("en");
            }
            if (oConfigMng.Config.ToolLang == "es")
            {
                cul = CultureInfo.CreateSpecificCulture("es");
            }
        }

        public static void MSGBOXServerNetworkLost()
        {
            LangEngine();
            Dialogs.ErrorDialog("Device Server: Network Lost", "Can't connect to server! Please check your internet connection!");
        }

        public static void MSGBOXFileCorrupted()
        {
            LangEngine();
            Dialogs.WarningDialog("Files Engine: File Corrupted", @"File is corrupted \: Downloading again!");
        }

        public static void MSGBOXBootloaderWarning()
        {
            LangEngine();
            Dialogs.WarningDialog("Bootloader: Warning!", "Device doesn't found, Please plug the phone and check if developer (adb) options are enabled!");
        }

        public static void MsgBoxUnzippyAlert()
        {
            LangEngine();
            Dialogs.InfoDialog("Unzip Engine", @"Please choose a zip file and extraction folder first!");
        }
    }
}
