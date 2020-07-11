
using AndroidCtrl;
using AndroidCtrl.ADB;
using AndroidCtrl.Fastboot;
using AndroidCtrl.Tools;
using log4net;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Franco28Tool.Engine
{
    [ComVisible(false)]
    public partial class DebloatOthers : MaterialForm
    {

        private SettingsMng oConfigMng = new SettingsMng();
        private readonly MaterialSkinManager materialSkinManager;
        IDDeviceState state = General.CheckDeviceState(ADB.Instance().DeviceID);
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

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
            cAppendDebloat("MOTO DEBLOAT: Please, write the app package like this: -com.google.android.apps.translate-");
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
            this.Invoke((Action)delegate
            {
                // Here we refresh our combobox
                cAppendDebloat("Device: --- " );
                cAppendDebloat("Device Codename: ---");
                cAppendDebloat("Mode: ---");
            });

            // This will get the currently connected ADB devices
            List<DataModelDevicesItem> adbDevices = ADB.Devices();

            // This will get the currently connected Fastboot devices
            List<DataModelDevicesItem> fastbootDevices = Fastboot.Devices();

            foreach (DataModelDevicesItem device in adbDevices)
            {
                this.Invoke((Action)delegate
                {
                    // here goes the add command ;)
                    cAppendDebloat("Device: Online! - " + device);
                    cAppendDebloat("Device Codename: " + LoadDeviceServer.devicecodename);
                    cAppendDebloat("Mode: " + state);
                });
            }
            foreach (DataModelDevicesItem device in fastbootDevices)
            {
                this.Invoke((Action)delegate
                {
                    cAppendDebloat("Device: Online! - " + device);
                    cAppendDebloat("Device Codename: " + LoadDeviceServer.devicecodename);
                    cAppendDebloat("Mode: " + state);
                });
            } 
        }

        private void DeviceDetectionService()
        {
            ADB.Start();

            // Here we initiate the BASE Fastboot instance
            Fastboot.Instance();

            //This will starte a thread which checks every 10 sec for connected devices and call the given callback
            if (Fastboot.ConnectionMonitor.Start())
            {
                //Here we define our callback function which will be raised if a device connects or disconnects
                Fastboot.ConnectionMonitor.Callback += ConnectionMonitorCallback;

                // Here we check if ADB is running and initiate the BASE ADB instance (IsStarted() will everytime check if the BASE ADB class exists, if not it will create it)
                if (ADB.IsStarted)
                {
                    //Here we check for connected devices
                    SetDeviceList();

                    //This will starte a thread which checks every 10 sec for connected devices and call the given callback
                    if (ADB.ConnectionMonitor.Start())
                    {
                        //Here we define our callback function which will be raised if a device connects or disconnects
                        ADB.ConnectionMonitor.Callback += ConnectionMonitorCallback;
                    }
                }
            }
        }

        public void ConnectionMonitorCallback(object sender, ConnectionMonitorArgs e)
        {
            this.Invoke((Action)delegate
            {
                // Do what u want with the "List<DataModelDevicesItem> e.Devices"
                // The "sender" is a "string" and returns "adb" or "fastboot"
                SetDeviceList();
                if (state == IDDeviceState.UNKNOWN)
                {
                    state = IDDeviceState.DEVICE;
                }
            });
        }       

        private async void debloatrom_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                if (IDDeviceState.DEVICE == state)
                {
                    await Task.Run(() => DeviceDetectionService());
                    cAppendDebloat("MOTO DEBLOAT: Removing app: " + textBox1.Text + "...");
                    await Task.Run(() => ADB.Instance().ShellCmd(" pm uninstall -k --user 0 " + textBox1.Text));
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
