
using System;

namespace Franco28Tool.Engine
{

    [Serializable()]

    public class Settings
    {

        private System.String m_oThemeDarkLight;
        private System.String m_oThemeMainColor;
        private System.String m_oToolThemeGreenColor;
        private System.String m_oToolThemeBlueColor;
        private System.String m_oToolThemeIndigoColor;
        private System.String m_oDrawerUseColors;
        private System.String m_oAutoSaveLogs;
        private System.String m_oDrawerHighlightWithAccent;
        private System.String m_oDrawerBackgroundWithAccent;
        private System.String m_oDrawerShowIconsWhenHidden;
        private System.String m_oToolInternet;
        private System.String m_oToolMenuSide;
        private System.String m_oToolVersion;
        private System.String m_oToolCompiled;
        private System.String m_oToolLang;
        private System.String m_oFirmware;
        private System.String m_oFirmwareExtracted;
        private System.String m_oDeviceCodename;
        private System.String m_oDeviceBlankFlash;
        private System.String m_oDeviceFirmwareInfo;
        private System.String m_oDeviceTWPRInfo;
        private System.String m_oDeviceTWPRPermanentInfo;
        private System.String m_oDownloadFileSizeTWRP;
        private System.String m_oDownloadFileSizeTWRPPermanent;
        private System.String m_oDownloadFileSizeFirmware;
        private System.String m_oDownloadFileSizeBlankFlash;
        private System.String m_oADBPath;
        private System.String m_oUnlockKey;
        
        public System.String ThemeMainColor
        {
            get { return m_oThemeMainColor; }
            set { m_oThemeMainColor = value; }
        }

        public System.String UnlockKey
        {
            get { return m_oUnlockKey; }
            set { m_oUnlockKey = value; }
        }

        public System.String DownloadFileSizeBlankFlash
        {
            get { return m_oDownloadFileSizeBlankFlash; }
            set { m_oDownloadFileSizeBlankFlash = value; }
        }

        public System.String DownloadFileSizeTWRP
        {
            get { return m_oDownloadFileSizeTWRP; }
            set { m_oDownloadFileSizeTWRP = value; }
        }

        public System.String DownloadFileSizeTWRPPermanent
        {
            get { return m_oDownloadFileSizeTWRPPermanent; }
            set { m_oDownloadFileSizeTWRPPermanent = value; }
        }

        public System.String DownloadFileSizeFirmware
        {
            get { return m_oDownloadFileSizeFirmware; }
            set { m_oDownloadFileSizeFirmware = value; }
        }

        public System.String ADBPath
        {
            get { return m_oADBPath; }
            set { m_oADBPath = value; }
        }

        public System.String ToolLang
        {
            get { return m_oToolLang; }
            set { m_oToolLang = value; }
        }

        public System.String DeviceTWPRInfo
        {
            get { return m_oDeviceTWPRInfo; }
            set { m_oDeviceTWPRInfo = value; }
        }

        public System.String DeviceTWPRPermanentInfo
        {
            get { return m_oDeviceTWPRPermanentInfo; }
            set { m_oDeviceTWPRPermanentInfo = value; }
        }

        public System.String DeviceFirmwareInfo
        {
            get { return m_oDeviceFirmwareInfo; }
            set { m_oDeviceFirmwareInfo = value; }
        }

        public System.String DeviceBlankFlash
        {
            get { return m_oDeviceBlankFlash; }
            set { m_oDeviceBlankFlash = value; }
        }

        public System.String DeviceCodenmae
        {
            get { return m_oDeviceCodename; }
            set { m_oDeviceCodename = value; }
        }

        public System.String ToolCompiled
        {
            get { return m_oToolCompiled; }
            set { m_oToolCompiled = value; }
        }

        public System.String ToolVersion
        {
            get { return m_oToolVersion; }
            set { m_oToolVersion = value; }
        }

        public System.String ToolMenuSide
        {
            get { return m_oToolMenuSide; }
            set { m_oToolMenuSide = value; }
        }

        public System.String DeviceFirmware
        {
            get { return m_oFirmware; }
            set { m_oFirmware = value; }
        }

        public System.String ToolInternet
        {
            get { return m_oToolInternet; }
            set { m_oToolInternet = value; }
        }

        public System.String ToolTheme
        {
            get { return m_oThemeDarkLight; }
            set { m_oThemeDarkLight = value; }
        }

        public System.String ToolThemeGreenColor
        {
            get { return m_oToolThemeGreenColor; }
            set { m_oToolThemeGreenColor = value; }
        }

        public System.String ToolThemeBlueColor
        {
            get { return m_oToolThemeBlueColor; }
            set { m_oToolThemeBlueColor = value; }
        }

        public System.String ToolThemeIndigoColor
        {
            get { return m_oToolThemeIndigoColor; }
            set { m_oToolThemeIndigoColor = value; }
        }

        public System.String DrawerUseColors
        {
            get { return m_oDrawerUseColors; }
            set { m_oDrawerUseColors = value; }
        }

        public System.String DrawerHighlightWithAccent
        {
            get { return m_oDrawerHighlightWithAccent; }
            set { m_oDrawerHighlightWithAccent = value; }
        }

        public System.String DrawerBackgroundWithAccent
        {
            get { return m_oDrawerBackgroundWithAccent; }
            set { m_oDrawerBackgroundWithAccent = value; }
        }

        public System.String DrawerShowIconsWhenHidden
        {
            get { return m_oDrawerShowIconsWhenHidden; }
            set { m_oDrawerShowIconsWhenHidden = value; }
        }

        public System.String Autosavelogs
        {
            get { return m_oAutoSaveLogs; }
            set { m_oAutoSaveLogs = value; }
        }

        public System.String FirmwareExtracted
        {
            get { return m_oFirmwareExtracted; }
            set { m_oFirmwareExtracted = value; }
        }
    }
}
