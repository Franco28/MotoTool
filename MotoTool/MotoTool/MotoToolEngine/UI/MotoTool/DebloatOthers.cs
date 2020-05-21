
using AndroidCtrl;
using AndroidCtrl.ADB;
using AndroidCtrl.Fastboot;
using AndroidCtrl.Tools;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Franco28Tool.Engine
{
    public partial class DebloatOthers : MaterialForm
    {

        private SettingsMng oConfigMng = new SettingsMng();
        private readonly MaterialSkinManager materialSkinManager;
        IDDeviceState state = General.CheckDeviceState(ADB.Instance().DeviceID);

        public DebloatOthers()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            InitializeComponent();
        }

        public void cAppendDebloat(string message)
        {
            this.Invoke((Action)delegate
            {
                console.AppendText(string.Format("\n{0} : {1}", DateTime.Now, message));
                console.ScrollToCaret();
            });
        }

        private void DebloatOthers_Load(object sender, EventArgs e)
        {
            oConfigMng.LoadConfig();

            if (oConfigMng.Config.ToolTheme == "light")
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            if (oConfigMng.Config.ToolTheme == "dark")
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            }
            textBox3.Text = "Please, write the app package like this: -com.google.android.apps.translate-";
        }

        private void SetDeviceList()
        {
            string active = String.Empty;

            List<DataModelDevicesItem> adbDevices = ADB.Devices();
            List<DataModelDevicesItem> fastbootDevices = Fastboot.Devices();

            foreach (DataModelDevicesItem device in adbDevices)
            {
                this.Invoke((Action)delegate
                {
                    cAppendDebloat("Device: Online! - ADB");
                    cAppendDebloat("Device Codename: " + LoadDeviceServer.devicecodename);
                    cAppendDebloat("Mode: " + state);
                });
            }
            foreach (DataModelDevicesItem device in fastbootDevices)
            {
                this.Invoke((Action)delegate
                {
                    cAppendDebloat("Device: Online! - FASTBOOT");
                    cAppendDebloat("Device Codename: " + LoadDeviceServer.devicecodename);
                    cAppendDebloat("Mode: " + state);
                });
            }
            ADB.SelectDevice();
            Fastboot.SelectDevice();
        }

        private void DeviceDetectionService()
        {
            ADB.Start();
            Fastboot.Instance();

            if (Fastboot.ConnectionMonitor.Start())
            {
                Fastboot.ConnectionMonitor.Callback += ConnectionMonitorCallback;

                if (ADB.IsStarted)
                {
                    SetDeviceList();

                    if (ADB.ConnectionMonitor.Start())
                    {
                        ADB.ConnectionMonitor.Callback += ConnectionMonitorCallback;
                    }
                }
            }
        }

        public void ConnectionMonitorCallback(object sender, ConnectionMonitorArgs e)
        {
            this.Invoke((Action)delegate
            {
                SetDeviceList();
            });
        }

        private async void debloatrom_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                if (IDDeviceState.DEVICE == state)
                {
                    await Task.Run(() => DeviceDetectionService());
                    cAppendDebloat("MOTO DEBLOAT: Waiting for device...");
                    await Task.Run(() => ADB.WaitForDevice());
                    cAppendDebloat("MOTO DEBLOAT: Removing app: " + textBox1.Text + "...");
                    await Task.Run(() => ADB.Instance().Execute("shell pm uninstall -k --user 0 " + textBox1.Text));
                    cAppendDebloat("MOTO DEBLOAT: Removing app: " + textBox1.Text + " {OK}");
                }
                else
                {
                    Thread.Sleep(1000);
                    Strings.MSGBOXBootloaderWarning();
                    cAppendDebloat("MOTO DEBLOAT: Please, write the app package like this: -com.google.android.apps.translate -");
                    textBox3.Text = "Please, write the app package like this: -com.google.android.apps.translate-";
                }
            }
            else
            {
                Dialogs.WarningDialog("Moto Debloater", "The box can't be empty!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
