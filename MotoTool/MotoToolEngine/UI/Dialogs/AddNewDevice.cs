
using log4net;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Franco28Tool.Engine
{
    [ComVisible(false)]
    public partial class AddNewDevice : MaterialForm
    {
        private SettingsMng oConfigMng = new SettingsMng();
        private readonly MaterialSkinManager MaterialSkinManager;
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public AddNewDevice()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            MaterialSkinManager = MaterialSkinManager.Instance;
            MaterialSkinManager.EnforceBackcolorOnAllComponents = true;
            MaterialSkinManager.AddFormToManage(this);
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

        public void DeviceCompatible()
        {
            oConfigMng.LoadConfig();
            string dc = textBoxCodename.Text;
            if (dc.Contains("doha") == true ||
                dc.Contains("evert") == true ||
                dc.Contains("lake") == true ||
                dc.Contains("lima") == true ||
                dc.Contains("river") == true ||
                dc.Contains("potter") == true ||
                dc.Contains("ocean") == true ||
                dc.Contains("sanders") == true ||
                dc.Contains("sofiar") == true ||
                dc.Contains("sofia") == true ||
                dc.Contains("beckham") == true ||
                dc.Contains("kane_sprout") == true ||
                dc.ToString().Contains("hannah") == true ||
                dc.ToString().Contains("ahannah") == true)
            {
                _log.Debug("Added new device codename: " + oConfigMng.Config.DeviceCodenmae + " {OK}");
                _log.Debug("Added new device channel: " + oConfigMng.Config.DeviceFirmware + " {OK}");
                oConfigMng.Config.DeviceCodenmae = textBoxCodename.Text.ToLower().Trim();
                oConfigMng.Config.DeviceFirmware = textBoxChannel.Text.ToUpper().Trim();
                cAppend("Added new device codename: " + oConfigMng.Config.DeviceCodenmae + " {OK}");
                cAppend("Added new device channel: " + oConfigMng.Config.DeviceFirmware + " {OK}");
                oConfigMng.SaveConfig();
                Dialogs.InfoDialog("Device " + textBoxCodename.Text, "Added new device: " + textBoxCodename.Text);
                return;
            }
            else
            {
                oConfigMng.Config.DeviceCodenmae = "";
                oConfigMng.Config.DeviceFirmware = "";
                _log.Warn("Device " + textBoxCodename.Text + ", Not compatible!");
                Dialogs.ErrorDialog("Device " + textBoxCodename.Text, "Not compatible!");
                cAppend("Added new device codename: " + textBoxCodename.Text + " {ERROR} ");
                cAppend("Added new device channel: " + textBoxChannel.Text + " {ERROR} ");
                oConfigMng.SaveConfig();
            }
        }

        private void AddNewDevice_Load(object sender, EventArgs e)
        {
            oConfigMng.LoadConfig();
            _log.Info("Add new device with device channel...");
            cAppend("Add new device with device channel...");
            if (oConfigMng.Config.ToolTheme == "light")
            {
                MaterialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            if (oConfigMng.Config.ToolTheme == "dark")
            {
                MaterialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            }
        }

        private void materialButtonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxCodename.Text != string.Empty || textBoxChannel.Text != string.Empty)
            {
                try
                {
                    DeviceCompatible();
                }
                catch (Exception er)
                {
                    Dialogs.ErrorDialog("ERROR adding new device", er.ToString());
                    _log.Error("ERROR adding new device " + oConfigMng.Config.DeviceCodenmae + " " + oConfigMng.Config.DeviceFirmware);
                    cAppend("Added new device codename: " + oConfigMng.Config.DeviceCodenmae + " {ERROR} " + er);
                    cAppend("Added new device channel: " + oConfigMng.Config.DeviceFirmware + " {ERROR} " + er);
                    return;
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
            oConfigMng.SaveConfig();
        }
    }
}
