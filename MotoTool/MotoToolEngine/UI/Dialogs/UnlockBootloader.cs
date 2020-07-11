
using AndroidCtrl;
using AndroidCtrl.ADB;
using AndroidCtrl.Fastboot;
using AndroidCtrl.Tools;
using log4net;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Franco28Tool.Engine
{
    [ComVisible(false)]

    public partial class UnlockBootloader : MaterialForm
    {
        private SettingsMng oConfigMng = new SettingsMng();
        private readonly MaterialSkinManager MaterialSkinManager;
        IDDeviceState state = General.CheckDeviceState(ADB.Instance().DeviceID);
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public UnlockBootloader()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            MaterialSkinManager = MaterialSkinManager.Instance;
            MaterialSkinManager.EnforceBackcolorOnAllComponents = true;
            MaterialSkinManager.AddFormToManage(this);
            InitializeComponent();
        }

        private void UnlockBootloader_Load(object sender, EventArgs e)
        {
            _log.Info("STARTING: Unlock bootloader form");
            cAppend("To Unlock Moto Bootloader: Press button |GO TO MOTO PAGE| and sing in it. \nThen press |GET UNLOCK DATA|, and here MotoTool will dropp you the completed and oreder Unlock Data. \nThen that Unlock Data past it on Moto Page |6. Check if your device can be unlocked by pasting this string in the field below, and clicking “Can my device be unlocked?”|. \nThen press |UNLOCK BOOTLOADER|");
            oConfigMng.LoadConfig();
            if (oConfigMng.Config.ToolTheme == "light")
            {
                MaterialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            if (oConfigMng.Config.ToolTheme == "dark")
            {
                MaterialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            }
        }

        public void cAppend(string message)
        {
            this.Invoke((Action)delegate
            {
                console.AppendText(string.Format("\n{0} : {1}", DateTime.Now, message));
                console.ScrollToCaret();
            });
        }

        private async void materialButtonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxUnlockKey.Text != string.Empty)
            {
                try
                {
                    _log.Info("Adding unlock key");
                    if (IDDeviceState.DEVICE == state)
                    {
                        _log.Debug("Unlocking bootloader: Unlocking bootloader with unlock key... Please wait!");
                        cAppend("Unlocking bootloader: Unlocking bootloader with unlock key... Please wait!");
                        await Task.Run(() => Fastboot.Instance().Execute("oem unlock " + textBoxUnlockKey.Text));
                    }
                    else
                    {
                        _log.Warn("Device Info: Your device is in the wrong state. Please connect your device. " + state);
                        cAppend("Device Info: Your device is in the wrong state. Please connect your device. " + state);
                    }
                }
                catch (Exception er)
                {
                    Logs.DebugErrorLogs(er);
                    _log.Error("Added Unlock Key: " + oConfigMng.Config.UnlockKey + " {ERROR} " + er);
                    Dialogs.ErrorDialog("ERROR adding Unlock Key", er.ToString());
                    cAppend("Added Unlock Key: " + oConfigMng.Config.UnlockKey + " {ERROR} " + er);
                    return;
                }
            }
            else
            {
                cAppend("Unlock Key: The box can't be empty!");
                Dialogs.WarningDialog("Unlock Key", "The box can't be empty!");
            }
        }

        private void materialButtonGetUnlockKey_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe") & File.Exists(@"C:\Program Files\Google\Chrome\Application\chrome.exe") == true)
            {
                BrowserCheck.StartBrowser("MicrosoftEdge.exe", "https://motorola-global-portal.custhelp.com/app/standalone/bootloader/unlock-your-device-b");
            }
            else
            {
                BrowserCheck.StartBrowser("Chrome.exe", "https://motorola-global-portal.custhelp.com/app/standalone/bootloader/unlock-your-device-b");
            }
        }

        private async void materialButtonGetUnlockData_Click(object sender, EventArgs e)
        {
            _log.Info("Get unlock data");
            if (IDDeviceState.DEVICE == state)
            {
                _log.Debug("Unlocking bootloader: Getting device unlock data...");
                cAppend("Unlocking bootloader: Getting device unlock data...");
                List<String> getunlockdata = (List<string>)await Task.Run(() => Fastboot.Instance().Execute("oem get_unlock_data"));
                getunlockdata.ToString();
                var result = String.Join("", getunlockdata.ToArray());
                var newn = result.Replace(" (bootloader) ", string.Empty);
                textBoxGetUnlockData.Text = newn.Trim().Replace("(bootloader) ", string.Empty).ToString();
            }
            else
            {
                _log.Warn("Device Info: Your device is in the wrong state. Please connect your device. " + state);
                cAppend("Device Info: Your device is in the wrong state. Please connect your device. " + state);
            }
        }

        private async void materialButtonUnlockBootlaoder_Click(object sender, EventArgs e)
        {
            if (IDDeviceState.DEVICE == state)
            {
                _log.Debug("Unlocking bootloader: Unlocking bootloader... Please wait!");
                cAppend("Unlocking bootloader: Unlocking bootloader... Please wait!");
                await Task.Run(() => Fastboot.Instance().Execute("oem unlock"));
                await Task.Run(() => Fastboot.Instance().Execute("oem unlock"));
            }
            else
            {
                _log.Warn("Device Info: Your device is in the wrong state. Please connect your device. " + state);
                cAppend("Device Info: Your device is in the wrong state. Please connect your device. " + state);
            }
        }
    }
}
