
namespace Franco28Tool.Engine
{
    public class Strings
    {

        public static string DeviceServerErrorTitle = "Device Server: Error";

        public static void MSGBOXServerNetworkLost()
        {
            Dialogs.ErrorDialog("Device Server: Network Lost", "Can't connect to server! Please check your internet connection!");
        }

        public static void MSGBOXFileCorrupted()
        {
            Dialogs.WarningDialog("Files Engine: File Corrupted", @"File is corrupted \: Downloading again!");
        }

        public static void MSGBOXBootloaderWarning()
        {
            Dialogs.WarningDialog("Bootloader: Warning!", "Device doesn't found, Please plug the phone and check if developer (adb) options are enabled!");
        }

        public static void MSGBOXFirmwareMissing()
        {
            Dialogs.WarningDialog("Files Engine: Firmware Missing", "Opss can't find Firmware...");
        }
      
        public static void MsgBoxResultFirmwareInfo()
        {
            Dialogs.InfoDialog("Firmware Info", "Firmware it's already downloaded! Now the firmware will be extracted it!");
        }

        public static void MsgBoxUnzippyAlert()
        {
            Dialogs.InfoDialog("Unzip Engine", @"Please choose a zip file and extraction folder first!");
        }
    }
}
