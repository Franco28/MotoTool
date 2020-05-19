using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Franco28Tool.Engine
{
    public partial class MotoFlash : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private SettingsMng oConfigMng = new SettingsMng();

        public bool FlashAll { get; private set; }
        public bool FlashAllExceptModem { get; private set; }

        public MotoFlash()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            InitializeComponent();
        }

        private delegate void SetRefreshCallback();

        private void SetRefresh()
        {
            if (this.InvokeRequired)
            {
                SetRefreshCallback d = new SetRefreshCallback(SetRefresh);
                base.Invoke(d);
            }
            else
                base.Refresh();
        }

        public new void Refresh()
        {
            SetRefresh();
        }

        public void DeviceisConnected()
        {/*
            if (android.HasConnectedDevices)
            {
                serial = android.ConnectedDevices[0];
                device = android.GetConnectedDevice(serial);
                decimal temp = device.Battery.Temperature;
                ArrayList devicecheck = new ArrayList();
                devicecheck.Add(" Device: Online!");
                devicecheck.Add(" Device Codename: " + LoadDeviceServer.devicecodename);
                devicecheck.Add(" Mode: USB debugging");
                devicecheck.Add(" Serial Number: " + serial);
                devicecheck.Add("  -------------------------");
                devicecheck.Add(" Battery: " + device.Battery.Status.ToString() + " " + device.Battery.Level.ToString() + System.Environment.NewLine + "%");
                devicecheck.Add(" Battery Temperature: " + temp + System.Environment.NewLine + " °C");
                devicecheck.Add(" Battery Health: " + device.Battery.Health.ToString() + System.Environment.NewLine);
                listBoxDeviceStatus.DataSource = devicecheck;
                return;
            } */
        }

        private void reload()
        {
            this.Controls.Clear();
            this.Refresh();
            SetRefresh();
            InitializeComponent();
            Label.Text = "Moto Firmware Flash BETA";
            DeviceisConnected();
        }

        private void MotoFlash_Load(object sender, EventArgs e)
        {
            DeviceisConnected();
            oConfigMng.LoadConfig();

            if (oConfigMng.Config.ToolTheme == "light")
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            if (oConfigMng.Config.ToolTheme == "dark")
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            }
            if (oConfigMng.Config.DeviceCodenmae == "")
            {
                Label.Text = "Please connect your device, so MotoTool can check your device!";
                Dialogs.WarningDialog("MotoFlash", "Please connect your device, so MotoTool can check your device!");
                materialButtonDowngradeMoto.Enabled = false;
                materialButtonFlashMoto.Enabled = false;
                groupBox1.Enabled = false;
                return;
            }

            if (oConfigMng.Config.DeviceCodenmae != "beckham" &&
                oConfigMng.Config.DeviceCodenmae != "doha" &&
                oConfigMng.Config.DeviceCodenmae != "sanders" &&
                oConfigMng.Config.DeviceCodenmae != "potter" &&
                oConfigMng.Config.DeviceCodenmae != "ocean")
            {
                Label.Text = "MotoFlash: Device not compatible yet! Current device: " + oConfigMng.Config.DeviceCodenmae;
                materialButtonDowngradeMoto.Enabled = false;
                materialButtonFlashMoto.Enabled = false;
                groupBox1.Enabled = false;
                Dialogs.WarningDialog("MotoFlash: Device not compatible yet!", "Hey! im working to make compatible your device! device compatible for now: Beckham, Doha, Potter, Sanders and Ocean");
                return;
            }
            else
            {
                string firmwarepath = @"C:\\adb\\Firmware\\" + oConfigMng.Config.DeviceFirmware + oConfigMng.Config.DeviceFirmwareInfo;
                if (Directory.Exists(firmwarepath) && oConfigMng.Config.FirmwareExtracted == "1")
                {
                    if (oConfigMng.Config.DeviceFirmware == oConfigMng.Config.DeviceFirmware)
                    {
                        Directory.SetCurrentDirectory(firmwarepath);
                    }
                }
                else
                {
                    materialButtonDowngradeMoto.Enabled = false;
                    materialButtonFlashMoto.Enabled = false;
                    groupBox1.Enabled = false;
                    Dialogs.WarningDialog("Moto Flash", "Please download your firmware! - Device Channel: " + "{" + oConfigMng.Config.DeviceFirmware + "}");
                    return;
                }
            }
        }

        private void flash_Click(object sender, EventArgs e)
        {
            try
            {
                DeviceisConnected();
                if (materialSwitchFlashAll.Checked == false && materialSwitchFlashAllExceptModem.Checked == false)
                {
                    Dialogs.WarningDialog("Moto Flash", "Please select an option!");
                    return;
                }

                string firmwarepath = @"C:\\adb\\Firmware\\" + oConfigMng.Config.DeviceFirmware + oConfigMng.Config.DeviceFirmwareInfo;
                Thread.Sleep(3000);
                Label.Text = "Checking device connection...";
                /*
                if (android.HasConnectedDevices)
                {
                    try
                    {
                        Label.Text = "Checking device connection... OK!";
                        Directory.SetCurrentDirectory(firmwarepath);
                        Adb.FastbootExecuteCommand("adb.exe ", "reboot bootloader");
                        if (materialSwitchFlashAll.Checked == true)
                        {
                            Label.Text = "Detecting device...";
                            string devices = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.devices));
                            Label.Text = devices;
                            Logs.DebugLogs(devices);

                            if (oConfigMng.Config.DeviceCodenmae == "doha" && oConfigMng.Config.DeviceCodenmae == "ocean" && oConfigMng.Config.DeviceCodenmae == "evert")
                            {
                                string set_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.set_a));
                                Label.Text = set_a;
                                Logs.DebugLogs(set_a);
                            }

                            string getvar = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.getvar));
                            Label.Text = getvar;
                            Logs.DebugLogs(getvar);

                            string oem = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.oem));
                            Label.Text = oem;
                            Logs.DebugLogs(oem);

                            string gpt = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.gpt));
                            Label.Text = gpt;
                            Logs.DebugLogs(gpt);

                            string bootloader = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.bootloader));
                            Label.Text = bootloader;
                            Logs.DebugLogs(bootloader);

                            if (oConfigMng.Config.DeviceCodenmae == "sanders")
                            {
                                FirmwareFlashRead.ReadFirmwareFlashN(oConfigMng.Config.DeviceCodenmae);
                                string fsg_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.fsg_a));
                                Label.Text = fsg_a;
                                Logs.DebugLogs(fsg_a);

                                string modemst1 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.modemst1));
                                Label.Text = modemst1;
                                Logs.DebugLogs(modemst1);

                                string modemst2 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.modemst2));
                                Label.Text = modemst2;
                                Logs.DebugLogs(modemst2);

                                string bluetooth_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.bluetooth_a));
                                Label.Text = bluetooth_a;
                                Logs.DebugLogs(bluetooth_a);

                                string dsp_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.dsp_a));
                                Label.Text = dsp_a;
                                Logs.DebugLogs(dsp_a);

                                string logo_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.logo_a));
                                Label.Text = logo_a;
                                Logs.DebugLogs(logo_a);

                                string boot_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.boot_a));
                                Label.Text = boot_a;
                                Logs.DebugLogs(boot_a);

                                string system_a_0 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_0));
                                Label.Text = system_a_0;
                                Logs.DebugLogs(system_a_0);

                                string system_a_1 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_1));
                                Label.Text = system_a_1;
                                Logs.DebugLogs(system_a_1);

                                string system_a_2 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_2));
                                Label.Text = system_a_2;
                                Logs.DebugLogs(system_a_2);

                                string system_a_3 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_3));
                                Label.Text = system_a_3;
                                Logs.DebugLogs(system_a_3);

                                string system_a_4 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_4));
                                Label.Text = system_a_4;
                                Logs.DebugLogs(system_a_4);

                                string system_a_5 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_5));
                                Label.Text = system_a_5;
                                Logs.DebugLogs(system_a_5);

                                string system_a_6 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_6));
                                Label.Text = system_a_6;
                                Logs.DebugLogs(system_a_6);

                                string system_a_7 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_7));
                                Label.Text = system_a_7;
                                Logs.DebugLogs(system_a_7);

                                string system_a_8 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_8));
                                Label.Text = system_a_8;
                                Logs.DebugLogs(system_a_8);

                                string system_a_9 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_9));
                                Label.Text = system_a_9;
                                Logs.DebugLogs(system_a_9);

                                string system_a_10 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_10));
                                Label.Text = system_a_10;
                                Logs.DebugLogs(system_a_10);

                                string oem_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.oem_a));
                                Label.Text = oem_a;
                                Logs.DebugLogs(oem_a);
                            }
                            if (oConfigMng.Config.DeviceCodenmae == "potter")
                            {
                                FirmwareFlashRead.ReadFirmwareFlashN(oConfigMng.Config.DeviceCodenmae);
                                string fsg_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.fsg_a));
                                Label.Text = fsg_a;
                                Logs.DebugLogs(fsg_a);

                                string modemst1 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.modemst1));
                                Label.Text = modemst1;
                                Logs.DebugLogs(modemst1);

                                string modemst2 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.modemst2));
                                Label.Text = modemst2;
                                Logs.DebugLogs(modemst2);

                                string bluetooth_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.bluetooth_a));
                                Label.Text = bluetooth_a;
                                Logs.DebugLogs(bluetooth_a);

                                string dsp_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.dsp_a));
                                Label.Text = dsp_a;
                                Logs.DebugLogs(dsp_a);

                                string logo_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.logo_a));
                                Label.Text = logo_a;
                                Logs.DebugLogs(logo_a);

                                string boot_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.boot_a));
                                Label.Text = boot_a;
                                Logs.DebugLogs(boot_a);

                                string system_a_0 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_0));
                                Label.Text = system_a_0;
                                Logs.DebugLogs(system_a_0);

                                string system_a_1 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_1));
                                Label.Text = system_a_1;
                                Logs.DebugLogs(system_a_1);

                                string system_a_2 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_2));
                                Label.Text = system_a_2;
                                Logs.DebugLogs(system_a_2);

                                string system_a_3 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_3));
                                Label.Text = system_a_3;
                                Logs.DebugLogs(system_a_3);

                                string system_a_4 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_4));
                                Label.Text = system_a_4;
                                Logs.DebugLogs(system_a_4);

                                string system_a_5 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_5));
                                Label.Text = system_a_5;
                                Logs.DebugLogs(system_a_5);

                                string system_a_6 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_6));
                                Label.Text = system_a_6;
                                Logs.DebugLogs(system_a_6);

                                string system_a_7 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_7));
                                Label.Text = system_a_7;
                                Logs.DebugLogs(system_a_7);

                                string system_a_8 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_8));
                                Label.Text = system_a_8;
                                Logs.DebugLogs(system_a_8);

                                string oem_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.oem_a));
                                Label.Text = oem_a;
                                Logs.DebugLogs(oem_a);
                            }
                            if (oConfigMng.Config.DeviceCodenmae == "ocean")
                            {
                                FirmwareFlashRead.ReadFirmwareFlashAB(oConfigMng.Config.DeviceCodenmae);
                                string modem_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.modem_a));
                                Label.Text = modem_a;
                                Logs.DebugLogs(modem_a);

                                string modem_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.modem_b));
                                Label.Text = modem_b;
                                Logs.DebugLogs(modem_b);

                                string fsg_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.fsg_a));
                                Label.Text = fsg_a;
                                Logs.DebugLogs(fsg_a);

                                string fsg_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.fsg_b));
                                Label.Text = fsg_b;
                                Logs.DebugLogs(fsg_b);

                                string modemst1 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.modemst1));
                                Label.Text = modemst1;
                                Logs.DebugLogs(modemst1);

                                string modemst2 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.modemst2));
                                Label.Text = modemst2;
                                Logs.DebugLogs(modemst2);

                                string dsp_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.dsp_a));
                                Label.Text = dsp_a;
                                Logs.DebugLogs(dsp_a);

                                string dsp_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.dsp_b));
                                Label.Text = dsp_b;
                                Logs.DebugLogs(dsp_b);

                                string logo_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.logo_a));
                                Label.Text = logo_a;
                                Logs.DebugLogs(logo_a);

                                string logo_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.logo_b));
                                Label.Text = logo_b;
                                Logs.DebugLogs(logo_b);

                                string boot_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.boot_a));
                                Label.Text = boot_a;
                                Logs.DebugLogs(boot_a);

                                string boot_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.boot_b));
                                Label.Text = boot_b;
                                Logs.DebugLogs(boot_b);

                                string dtbo_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.dtbo_a));
                                Label.Text = dtbo_a;
                                Logs.DebugLogs(dtbo_a);

                                string dtbo_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.dtbo_b));
                                Label.Text = dtbo_b;
                                Logs.DebugLogs(dtbo_b);

                                string system_a_0 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_0));
                                Label.Text = system_a_0;
                                Logs.DebugLogs(system_a_0);

                                string system_a_1 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_1));
                                Label.Text = system_a_1;
                                Logs.DebugLogs(system_a_1);

                                string system_a_2 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_2));
                                Label.Text = system_a_2;
                                Logs.DebugLogs(system_a_2);

                                string system_a_3 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_3));
                                Label.Text = system_a_3;
                                Logs.DebugLogs(system_a_3);

                                string system_a_4 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_4));
                                Label.Text = system_a_4;
                                Logs.DebugLogs(system_a_4);

                                string system_a_5 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_5));
                                Label.Text = system_a_5;
                                Logs.DebugLogs(system_a_5);

                                string system_a_6 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_6));
                                Label.Text = system_a_6;
                                Logs.DebugLogs(system_a_6);

                                string system_a_7 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_7));
                                Label.Text = system_a_7;
                                Logs.DebugLogs(system_a_7);

                                string system_a_8 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_8));
                                Label.Text = system_a_8;
                                Logs.DebugLogs(system_a_8);

                                string system_a_9 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_9));
                                Label.Text = system_a_9;
                                Logs.DebugLogs(system_a_9);

                                string system_b_0 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_b_0));
                                Label.Text = system_b_0;
                                Logs.DebugLogs(system_b_0);

                                string system_b_1 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_b_1));
                                Label.Text = system_b_1;
                                Logs.DebugLogs(system_b_1);

                                string system_b_2 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_b_2));
                                Label.Text = system_b_2;
                                Logs.DebugLogs(system_b_2);

                                string vendor_a_0 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.vendor_a_0));
                                Label.Text = vendor_a_0;
                                Logs.DebugLogs(vendor_a_0);

                                string vendor_a_1 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.vendor_a_1));
                                Label.Text = vendor_a_1;
                                Logs.DebugLogs(vendor_a_1);

                                string vendor_b_0 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.vendor_b_0));
                                Label.Text = vendor_b_0;
                                Logs.DebugLogs(vendor_b_0);

                                string vendor_b_1 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.vendor_b_1));
                                Label.Text = vendor_b_1;
                                Logs.DebugLogs(vendor_b_1);

                                string oem_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.oem_a));
                                Label.Text = oem_a;
                                Logs.DebugLogs(oem_a);

                                string oem_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.oem_b));
                                Label.Text = oem_b;
                                Logs.DebugLogs(oem_b);
                            }
                            if (oConfigMng.Config.DeviceCodenmae == "doha")
                            {
                                FirmwareFlashRead.ReadFirmwareFlashAB(oConfigMng.Config.DeviceCodenmae);
                                string vbmeta_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.vbmeta_a));
                                Label.Text = vbmeta_a;
                                Logs.DebugLogs(vbmeta_a);

                                string vbmeta_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.vbmeta_b));
                                Label.Text = vbmeta_b;
                                Logs.DebugLogs(vbmeta_b);

                                string modem_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.modem_a));
                                Label.Text = modem_a;
                                Logs.DebugLogs(modem_a);

                                string modem_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.modem_b));
                                Label.Text = modem_b;
                                Logs.DebugLogs(modem_b);

                                string fsg_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.fsg_a));
                                Label.Text = fsg_a;
                                Logs.DebugLogs(fsg_a);

                                string fsg_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.fsg_b));
                                Label.Text = fsg_b;
                                Logs.DebugLogs(fsg_b);

                                string modemst1 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.modemst1));
                                Label.Text = modemst1;
                                Logs.DebugLogs(modemst1);

                                string modemst2 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.modemst2));
                                Label.Text = modemst2;
                                Logs.DebugLogs(modemst2);

                                string bluetooth_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.bluetooth_a));
                                Label.Text = bluetooth_a;
                                Logs.DebugLogs(bluetooth_a);

                                string bluetooth_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.bluetooth_b));
                                Label.Text = bluetooth_b;
                                Logs.DebugLogs(bluetooth_b);

                                string dsp_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.dsp_a));
                                Label.Text = dsp_a;
                                Logs.DebugLogs(dsp_a);

                                string dsp_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.dsp_b));
                                Label.Text = dsp_b;
                                Logs.DebugLogs(dsp_b);

                                string logo_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.logo_a));
                                Label.Text = logo_a;
                                Logs.DebugLogs(logo_a);

                                string logo_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.logo_b));
                                Label.Text = logo_b;
                                Logs.DebugLogs(logo_b);

                                string boot_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.boot_a));
                                Label.Text = boot_a;
                                Logs.DebugLogs(boot_a);

                                string boot_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.boot_b));
                                Label.Text = boot_b;
                                Logs.DebugLogs(boot_b);

                                string dtbo_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.dtbo_a));
                                Label.Text = dtbo_a;
                                Logs.DebugLogs(dtbo_a);

                                string dtbo_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.dtbo_b));
                                Label.Text = dtbo_b;
                                Logs.DebugLogs(dtbo_b);

                                string system_a_0 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_0));
                                Label.Text = system_a_0;
                                Logs.DebugLogs(system_a_0);

                                string system_a_1 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_1));
                                Label.Text = system_a_1;
                                Logs.DebugLogs(system_a_1);

                                string system_a_2 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_2));
                                Label.Text = system_a_2;
                                Logs.DebugLogs(system_a_2);

                                string system_a_3 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_3));
                                Label.Text = system_a_3;
                                Logs.DebugLogs(system_a_3);

                                string system_a_4 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_4));
                                Label.Text = system_a_4;
                                Logs.DebugLogs(system_a_4);

                                string system_a_5 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_5));
                                Label.Text = system_a_5;
                                Logs.DebugLogs(system_a_5);

                                string system_b_0 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_b_0));
                                Label.Text = system_b_0;
                                Logs.DebugLogs(system_b_0);

                                string system_b_1 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_b_1));
                                Label.Text = system_b_1;
                                Logs.DebugLogs(system_b_1);

                                string oem_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.oem_a));
                                Label.Text = oem_a;
                                Logs.DebugLogs(oem_a);

                                string oem_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.oem_b));
                                Label.Text = oem_b;
                                Logs.DebugLogs(oem_b);

                                string vendor_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.vendor_a));
                                Label.Text = vendor_a;
                                Logs.DebugLogs(vendor_a);

                                string vendor_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.vendor_b));
                                Label.Text = vendor_b;
                                Logs.DebugLogs(vendor_b);

                            }
                            if (oConfigMng.Config.DeviceCodenmae == "beckham")
                            {
                                FirmwareFlashRead.ReadFirmwareFlashAB(oConfigMng.Config.DeviceCodenmae);
                                string modem_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.modem_a));
                                Label.Text = modem_a;
                                Logs.DebugLogs(modem_a);

                                string fsg_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.fsg_a));
                                Label.Text = fsg_a;
                                Logs.DebugLogs(fsg_a);

                                string modemst1 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.modemst1));
                                Label.Text = modemst1;
                                Logs.DebugLogs(modemst1);

                                string modemst2 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.modemst2));
                                Label.Text = modemst2;
                                Logs.DebugLogs(modemst2);

                                string bluetooth_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.bluetooth_a));
                                Label.Text = bluetooth_a;
                                Logs.DebugLogs(bluetooth_a);

                                string dsp_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.dsp_a));
                                Label.Text = dsp_a;
                                Logs.DebugLogs(dsp_a);

                                string logo_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.logo_a));
                                Label.Text = logo_a;
                                Logs.DebugLogs(logo_a);

                                string boot_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.boot_a));
                                Label.Text = boot_a;
                                Logs.DebugLogs(boot_a);

                                string system_a_0 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_0));
                                Label.Text = system_a_0;
                                Logs.DebugLogs(system_a_0);

                                string system_a_1 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_1));
                                Label.Text = system_a_1;
                                Logs.DebugLogs(system_a_1);

                                string system_a_2 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_2));
                                Label.Text = system_a_2;
                                Logs.DebugLogs(system_a_2);

                                string system_a_3 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_3));
                                Label.Text = system_a_3;
                                Logs.DebugLogs(system_a_3);

                                string system_a_4 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_4));
                                Label.Text = system_a_4;
                                Logs.DebugLogs(system_a_4);

                                string system_a_5 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_5));
                                Label.Text = system_a_5;
                                Logs.DebugLogs(system_a_5);

                                string system_b_0 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_b_0));
                                Label.Text = system_b_0;
                                Logs.DebugLogs(system_b_0);

                                string oem_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.oem_a));
                                Label.Text = oem_a;
                                Logs.DebugLogs(oem_a);

                                string oem_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.oem_b));
                                Label.Text = oem_b;
                                Logs.DebugLogs(oem_b);

                                string vendor_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.vendor_a));
                                Label.Text = vendor_a;
                                Logs.DebugLogs(vendor_a);

                                string vendor_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.vendor_b));
                                Label.Text = vendor_b;
                                Logs.DebugLogs(vendor_b);
                            }
                            string erasecarrier = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.erasecarrier));
                            Label.Text = erasecarrier;
                            Logs.DebugLogs(erasecarrier);
                            string eraseuserdata = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.eraseuserdata));
                            Label.Text = eraseuserdata;
                            Logs.DebugLogs(eraseuserdata);
                            string eraseddr = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.eraseddr));
                            Label.Text = eraseddr;
                            Logs.DebugLogs(eraseddr);
                            string oemclear = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.oemclear));
                            Label.Text = oemclear;
                            Logs.DebugLogs(oemclear);
                            string reboot = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.reboot));
                            Label.Text = reboot;
                            Logs.DebugLogs(reboot);

                            Dialogs.InfoDialog("FIRMWARE Installed!", "FIRMWARE: " + oConfigMng.Config.DeviceFirmwareInfo + " installed!");
                        }

                        // no modem
                        if (materialSwitchFlashAllExceptModem.Checked == true)
                        {
                            Label.Text = "Detecting device...";
                            string devices = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.devices));
                            Label.Text = devices;
                            Logs.DebugLogs(devices);

                            if (oConfigMng.Config.DeviceCodenmae == "doha" && oConfigMng.Config.DeviceCodenmae == "ocean" && oConfigMng.Config.DeviceCodenmae == "evert")
                            {
                                string set_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.set_a));
                                Label.Text = set_a;
                                Logs.DebugLogs(set_a);
                            }

                            string getvar = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.getvar));
                            Label.Text = getvar;
                            Logs.DebugLogs(getvar);

                            string oem = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.oem));
                            Label.Text = oem;
                            Logs.DebugLogs(oem);

                            string gpt = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.gpt));
                            Label.Text = gpt;
                            Logs.DebugLogs(gpt);

                            string bootloader = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.bootloader));
                            Label.Text = bootloader;
                            Logs.DebugLogs(bootloader);

                            if (oConfigMng.Config.DeviceCodenmae == "sanders")
                            {
                                FirmwareFlashRead.ReadFirmwareFlashN(oConfigMng.Config.DeviceCodenmae);

                                string bluetooth_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.bluetooth_a));
                                Label.Text = bluetooth_a;
                                Logs.DebugLogs(bluetooth_a);

                                string dsp_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.dsp_a));
                                Label.Text = dsp_a;
                                Logs.DebugLogs(dsp_a);

                                string logo_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.logo_a));
                                Label.Text = logo_a;
                                Logs.DebugLogs(logo_a);

                                string boot_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.boot_a));
                                Label.Text = boot_a;
                                Logs.DebugLogs(boot_a);

                                string system_a_0 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_0));
                                Label.Text = system_a_0;
                                Logs.DebugLogs(system_a_0);

                                string system_a_1 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_1));
                                Label.Text = system_a_1;
                                Logs.DebugLogs(system_a_1);

                                string system_a_2 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_2));
                                Label.Text = system_a_2;
                                Logs.DebugLogs(system_a_2);

                                string system_a_3 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_3));
                                Label.Text = system_a_3;
                                Logs.DebugLogs(system_a_3);

                                string system_a_4 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_4));
                                Label.Text = system_a_4;
                                Logs.DebugLogs(system_a_4);

                                string system_a_5 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_5));
                                Label.Text = system_a_5;
                                Logs.DebugLogs(system_a_5);

                                string system_a_6 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_6));
                                Label.Text = system_a_6;
                                Logs.DebugLogs(system_a_6);

                                string system_a_7 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_7));
                                Label.Text = system_a_7;
                                Logs.DebugLogs(system_a_7);

                                string system_a_8 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_8));
                                Label.Text = system_a_8;
                                Logs.DebugLogs(system_a_8);

                                string system_a_9 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_9));
                                Label.Text = system_a_9;
                                Logs.DebugLogs(system_a_9);

                                string system_a_10 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_10));
                                Label.Text = system_a_10;
                                Logs.DebugLogs(system_a_10);

                                string oem_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.oem_a));
                                Label.Text = oem_a;
                                Logs.DebugLogs(oem_a);
                            }
                            if (oConfigMng.Config.DeviceCodenmae == "potter")
                            {
                                FirmwareFlashRead.ReadFirmwareFlashN(oConfigMng.Config.DeviceCodenmae);
                                string bluetooth_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.bluetooth_a));
                                Label.Text = bluetooth_a;
                                Logs.DebugLogs(bluetooth_a);

                                string dsp_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.dsp_a));
                                Label.Text = dsp_a;
                                Logs.DebugLogs(dsp_a);

                                string logo_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.logo_a));
                                Label.Text = logo_a;
                                Logs.DebugLogs(logo_a);

                                string boot_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.boot_a));
                                Label.Text = boot_a;
                                Logs.DebugLogs(boot_a);

                                string system_a_0 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_0));
                                Label.Text = system_a_0;
                                Logs.DebugLogs(system_a_0);

                                string system_a_1 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_1));
                                Label.Text = system_a_1;
                                Logs.DebugLogs(system_a_1);

                                string system_a_2 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_2));
                                Label.Text = system_a_2;
                                Logs.DebugLogs(system_a_2);

                                string system_a_3 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_3));
                                Label.Text = system_a_3;
                                Logs.DebugLogs(system_a_3);

                                string system_a_4 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_4));
                                Label.Text = system_a_4;
                                Logs.DebugLogs(system_a_4);

                                string system_a_5 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_5));
                                Label.Text = system_a_5;
                                Logs.DebugLogs(system_a_5);

                                string system_a_6 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_6));
                                Label.Text = system_a_6;
                                Logs.DebugLogs(system_a_6);

                                string system_a_7 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_7));
                                Label.Text = system_a_7;
                                Logs.DebugLogs(system_a_7);

                                string system_a_8 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_8));
                                Label.Text = system_a_8;
                                Logs.DebugLogs(system_a_8);

                                string oem_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.oem_a));
                                Label.Text = oem_a;
                                Logs.DebugLogs(oem_a);
                            }
                            if (oConfigMng.Config.DeviceCodenmae == "ocean")
                            {
                                FirmwareFlashRead.ReadFirmwareFlashAB(oConfigMng.Config.DeviceCodenmae);
                                string dsp_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.dsp_a));
                                Label.Text = dsp_a;
                                Logs.DebugLogs(dsp_a);

                                string dsp_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.dsp_b));
                                Label.Text = dsp_b;
                                Logs.DebugLogs(dsp_b);

                                string logo_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.logo_a));
                                Label.Text = logo_a;
                                Logs.DebugLogs(logo_a);

                                string logo_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.logo_b));
                                Label.Text = logo_b;
                                Logs.DebugLogs(logo_b);

                                string boot_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.boot_a));
                                Label.Text = boot_a;
                                Logs.DebugLogs(boot_a);

                                string boot_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.boot_b));
                                Label.Text = boot_b;
                                Logs.DebugLogs(boot_b);

                                string dtbo_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.dtbo_a));
                                Label.Text = dtbo_a;
                                Logs.DebugLogs(dtbo_a);

                                string dtbo_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.dtbo_b));
                                Label.Text = dtbo_b;
                                Logs.DebugLogs(dtbo_b);

                                string system_a_0 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_0));
                                Label.Text = system_a_0;
                                Logs.DebugLogs(system_a_0);

                                string system_a_1 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_1));
                                Label.Text = system_a_1;
                                Logs.DebugLogs(system_a_1);

                                string system_a_2 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_2));
                                Label.Text = system_a_2;
                                Logs.DebugLogs(system_a_2);

                                string system_a_3 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_3));
                                Label.Text = system_a_3;
                                Logs.DebugLogs(system_a_3);

                                string system_a_4 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_4));
                                Label.Text = system_a_4;
                                Logs.DebugLogs(system_a_4);

                                string system_a_5 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_5));
                                Label.Text = system_a_5;
                                Logs.DebugLogs(system_a_5);

                                string system_a_6 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_6));
                                Label.Text = system_a_6;
                                Logs.DebugLogs(system_a_6);

                                string system_a_7 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_7));
                                Label.Text = system_a_7;
                                Logs.DebugLogs(system_a_7);

                                string system_a_8 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_8));
                                Label.Text = system_a_8;
                                Logs.DebugLogs(system_a_8);

                                string system_a_9 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_9));
                                Label.Text = system_a_9;
                                Logs.DebugLogs(system_a_9);

                                string system_b_0 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_b_0));
                                Label.Text = system_b_0;
                                Logs.DebugLogs(system_b_0);

                                string system_b_1 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_b_1));
                                Label.Text = system_b_1;
                                Logs.DebugLogs(system_b_1);

                                string system_b_2 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_b_2));
                                Label.Text = system_b_2;
                                Logs.DebugLogs(system_b_2);

                                string vendor_a_0 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.vendor_a_0));
                                Label.Text = vendor_a_0;
                                Logs.DebugLogs(vendor_a_0);

                                string vendor_a_1 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.vendor_a_1));
                                Label.Text = vendor_a_1;
                                Logs.DebugLogs(vendor_a_1);

                                string vendor_b_0 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.vendor_b_0));
                                Label.Text = vendor_b_0;
                                Logs.DebugLogs(vendor_b_0);

                                string vendor_b_1 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.vendor_b_1));
                                Label.Text = vendor_b_1;
                                Logs.DebugLogs(vendor_b_1);

                                string oem_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.oem_a));
                                Label.Text = oem_a;
                                Logs.DebugLogs(oem_a);

                                string oem_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.oem_b));
                                Label.Text = oem_b;
                                Logs.DebugLogs(oem_b);
                            }
                            if (oConfigMng.Config.DeviceCodenmae == "doha")
                            {
                                FirmwareFlashRead.ReadFirmwareFlashAB(oConfigMng.Config.DeviceCodenmae);
                                string vbmeta_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.vbmeta_a));
                                Label.Text = vbmeta_a;
                                Logs.DebugLogs(vbmeta_a);

                                string vbmeta_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.vbmeta_b));
                                Label.Text = vbmeta_b;
                                Logs.DebugLogs(vbmeta_b);

                                string bluetooth_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.bluetooth_a));
                                Label.Text = bluetooth_a;
                                Logs.DebugLogs(bluetooth_a);

                                string bluetooth_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.bluetooth_b));
                                Label.Text = bluetooth_b;
                                Logs.DebugLogs(bluetooth_b);

                                string dsp_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.dsp_a));
                                Label.Text = dsp_a;
                                Logs.DebugLogs(dsp_a);

                                string dsp_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.dsp_b));
                                Label.Text = dsp_b;
                                Logs.DebugLogs(dsp_b);

                                string logo_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.logo_a));
                                Label.Text = logo_a;
                                Logs.DebugLogs(logo_a);

                                string logo_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.logo_b));
                                Label.Text = logo_b;
                                Logs.DebugLogs(logo_b);

                                string boot_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.boot_a));
                                Label.Text = boot_a;
                                Logs.DebugLogs(boot_a);

                                string boot_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.boot_b));
                                Label.Text = boot_b;
                                Logs.DebugLogs(boot_b);

                                string dtbo_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.dtbo_a));
                                Label.Text = dtbo_a;
                                Logs.DebugLogs(dtbo_a);

                                string dtbo_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.dtbo_b));
                                Label.Text = dtbo_b;
                                Logs.DebugLogs(dtbo_b);

                                string system_a_0 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_0));
                                Label.Text = system_a_0;
                                Logs.DebugLogs(system_a_0);

                                string system_a_1 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_1));
                                Label.Text = system_a_1;
                                Logs.DebugLogs(system_a_1);

                                string system_a_2 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_2));
                                Label.Text = system_a_2;
                                Logs.DebugLogs(system_a_2);

                                string system_a_3 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_3));
                                Label.Text = system_a_3;
                                Logs.DebugLogs(system_a_3);

                                string system_a_4 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_4));
                                Label.Text = system_a_4;
                                Logs.DebugLogs(system_a_4);

                                string system_a_5 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_5));
                                Label.Text = system_a_5;
                                Logs.DebugLogs(system_a_5);

                                string system_b_0 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_b_0));
                                Label.Text = system_b_0;
                                Logs.DebugLogs(system_b_0);

                                string system_b_1 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_b_1));
                                Label.Text = system_b_1;
                                Logs.DebugLogs(system_b_1);

                                string oem_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.oem_a));
                                Label.Text = oem_a;
                                Logs.DebugLogs(oem_a);

                                string oem_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.oem_b));
                                Label.Text = oem_b;
                                Logs.DebugLogs(oem_b);

                                string vendor_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.vendor_a));
                                Label.Text = vendor_a;
                                Logs.DebugLogs(vendor_a);

                                string vendor_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.vendor_b));
                                Label.Text = vendor_b;
                                Logs.DebugLogs(vendor_b);
                            }
                            if (oConfigMng.Config.DeviceCodenmae == "beckham")
                            {
                                FirmwareFlashRead.ReadFirmwareFlashAB(oConfigMng.Config.DeviceCodenmae);
                                string bluetooth_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.bluetooth_a));
                                Label.Text = bluetooth_a;
                                Logs.DebugLogs(bluetooth_a);

                                string dsp_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.dsp_a));
                                Label.Text = dsp_a;
                                Logs.DebugLogs(dsp_a);

                                string logo_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.logo_a));
                                Label.Text = logo_a;
                                Logs.DebugLogs(logo_a);

                                string boot_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.boot_a));
                                Label.Text = boot_a;
                                Logs.DebugLogs(boot_a);

                                string system_a_0 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_0));
                                Label.Text = system_a_0;
                                Logs.DebugLogs(system_a_0);

                                string system_a_1 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_1));
                                Label.Text = system_a_1;
                                Logs.DebugLogs(system_a_1);

                                string system_a_2 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_2));
                                Label.Text = system_a_2;
                                Logs.DebugLogs(system_a_2);

                                string system_a_3 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_3));
                                Label.Text = system_a_3;
                                Logs.DebugLogs(system_a_3);

                                string system_a_4 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_4));
                                Label.Text = system_a_4;
                                Logs.DebugLogs(system_a_4);

                                string system_a_5 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_a_5));
                                Label.Text = system_a_5;
                                Logs.DebugLogs(system_a_5);

                                string system_b_0 = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.system_b_0));
                                Label.Text = system_b_0;
                                Logs.DebugLogs(system_b_0);

                                string oem_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.oem_a));
                                Label.Text = oem_a;
                                Logs.DebugLogs(oem_a);

                                string oem_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.oem_b));
                                Label.Text = oem_b;
                                Logs.DebugLogs(oem_b);

                                string vendor_a = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.vendor_a));
                                Label.Text = vendor_a;
                                Logs.DebugLogs(vendor_a);

                                string vendor_b = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.vendor_b));
                                Label.Text = vendor_b;
                                Logs.DebugLogs(vendor_b);
                            }
                            string erasecarrier = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.erasecarrier));
                            Label.Text = erasecarrier;
                            Logs.DebugLogs(erasecarrier);
                            string eraseuserdata = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.eraseuserdata));
                            Label.Text = eraseuserdata;
                            Logs.DebugLogs(eraseuserdata);
                            string eraseddr = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.eraseddr));
                            Label.Text = eraseddr;
                            Logs.DebugLogs(eraseddr);
                            string oemclear = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.oemclear));
                            Label.Text = oemclear;
                            Logs.DebugLogs(oemclear);
                            string reboot = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot " + FirmwareFlashRead.reboot));
                            Label.Text = reboot;
                            Logs.DebugLogs(reboot);
                            Dialogs.InfoDialog("FIRMWARE Installed!", "FIRMWARE: " + oConfigMng.Config.DeviceFirmwareInfo + " installed!");
                        }
                    }
                    catch (Exception er)
                    {
                        Logs.DebugErrorLogs(er);
                        Dialogs.WarningDialog("Moto Flash: ERROR", er.Message);
                    }
                }
                else
                {
                    Label.Text = "Please connect your device...";
                    Dialogs.WarningDialog("Moto Flash", "Please plug your device! Remember to plug your phone on Fastboot Mode!");
                    reload();
                } */
            }
            catch (Exception er)
            {
                Logs.DebugErrorLogs(er);
                Dialogs.ErrorDialog("ERROR: Moto Flash", "Error: " + er);
                return;
            }
            
        }

        private void downgradeBTN_Click(object sender, EventArgs e)
        {
            Dialogs.InfoDialog("Downgrade Mode", "Hey! this is not ready yet! soon will be working...");
        }

        private void materialSwitchFlashAll_CheckedChanged(object sender, EventArgs e)
        {
            FlashAll = materialSwitchFlashAll.Checked;
        }

        private void materialSwitchFlashAllExceptModem_CheckedChanged(object sender, EventArgs e)
        {
            FlashAllExceptModem = materialSwitchFlashAllExceptModem.Checked;
        }
    }
}
