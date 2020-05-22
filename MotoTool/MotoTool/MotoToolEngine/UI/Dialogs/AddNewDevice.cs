
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace Franco28Tool.Engine
{
    public partial class AddNewDevice : MaterialForm
    {
        private SettingsMng oConfigMng = new SettingsMng();
        private readonly MaterialSkinManager materialSkinManager;

        public AddNewDevice()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            InitializeComponent();
        }

        public void cAppend(string message)
        {
            this.Invoke((Action)delegate
            {
                console.AppendText(string.Format("\n{0} : {1}", DateTime.Now, message));
                console.ScrollToCaret();
            });
        }

        private void AddNewDevice_Load(object sender, EventArgs e)
        {
            oConfigMng.LoadConfig();
            cAppend("Add new device with device channel...");
            if (oConfigMng.Config.ToolTheme == "light")
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            if (oConfigMng.Config.ToolTheme == "dark")
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            }
        }

        private void materialButtonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxCodename.Text != string.Empty || textBoxChannel.Text != string.Empty)
            {
                try
                {
                    oConfigMng.LoadConfig();
                    oConfigMng.Config.DeviceCodenmae = textBoxCodename.Text.ToLower().Trim();
                    oConfigMng.Config.DeviceFirmware = textBoxChannel.Text.ToUpper().Trim();
                    cAppend("Added new device codename: " + oConfigMng.Config.DeviceCodenmae);
                    cAppend("Added new device channel: " + oConfigMng.Config.DeviceFirmware);
                    oConfigMng.SaveConfig();
                    cAppend("Added new device codename: " + oConfigMng.Config.DeviceCodenmae + " {OK}");
                    cAppend("Added new device channel: " + oConfigMng.Config.DeviceFirmware + " {OK}");
                }
                catch (Exception er)
                {
                    Dialogs.ErrorDialog("ERROR adding new device", er.ToString());
                    cAppend("Added new device codename: " + oConfigMng.Config.DeviceCodenmae + " {ERROR} " + er);
                    cAppend("Added new device channel: " + oConfigMng.Config.DeviceFirmware + " {ERROR} " + er);
                }
            }
            else
            {
                cAppend("Add New Device: The boxes can't be empty!");
                Dialogs.WarningDialog("Add New Device", "The boxes can't be empty!");
            }
        }

        private void exit(object sender, FormClosedEventArgs e)
        {
            oConfigMng.LoadConfig();
            if (oConfigMng.Config.Autosavelogs == "true")
            {
                cAppend("EXIT: Saving New Device logs...");
                try
                {
                    string filePath = @"C:\adb\.settings\Logs\NewDeviceLogs.txt";
                    cAppend("EXIT: Saving New Device logs... {OK}");
                    console.SaveFile(filePath, RichTextBoxStreamType.PlainText);
                }
                catch (Exception ex)
                {
                    Logs.DebugErrorLogs(ex);
                    cAppend("EXIT: Saving New Device logs... {ERROR}");
                    Dialogs.ErrorDialog("An error has occured while attempting to save the output...", ex.ToString());
                }
            }
        }
    }
}
