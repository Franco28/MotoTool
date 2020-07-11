
using AndroidCtrl;
using AndroidCtrl.ADB;
using AndroidCtrl.Fastboot;
using AndroidCtrl.Tools;
using log4net;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Franco28Tool.Engine
{
    [ComVisible(false)]

    public partial class MotoFlash : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private SettingsMng oConfigMng = new SettingsMng();
        ArrayList devicecheck = new ArrayList();
        IDDeviceState state = General.CheckDeviceState(ADB.Instance().DeviceID);
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public bool FlashAll { get; private set; }
        public bool FlashAllExceptModem { get; private set; }
        public bool WorkerReportsProgress { get; private set; }

        public MotoFlash()
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
                consoleMotoFlash.AppendText(string.Format("\n{0} : {1}", DateTime.Now, message));
                consoleMotoFlash.ScrollToCaret();
            });
        }

        private void SetDeviceList()
        {
            this.Invoke((Action)delegate
            {
                // Here we refresh our combobox
                _log.Info("MOTO FLASH: ---!");
                devicecheck.Add(" Device: ---");
                devicecheck.Add(" Mode: --- ");
                listBoxDeviceStatus.DataSource = devicecheck;
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
                    _log.Info("MOTO FLASH: Device adb connected!");
                    cAppend("Device adb connected!");
                    devicecheck.Add(" Device: Online! - ADB");
                    devicecheck.Add(" Mode: " + state);
                    listBoxDeviceStatus.DataSource = devicecheck;
                });
            }
            foreach (DataModelDevicesItem device in fastbootDevices)
            {
                this.Invoke((Action)delegate
                {
                    _log.Info("MOTO FLASH: Device fastboot connected!");
                    cAppend("Device fastboot connected!");
                    devicecheck.Add(" Device: Online! - FASTBOOT");
                    devicecheck.Add(" Mode: " + state);
                    listBoxDeviceStatus.DataSource = devicecheck;
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

        private async void MotoFlash_Load(object sender, EventArgs e)
        {
            oConfigMng.LoadConfig();
            _log.Debug("STARTING MOTO FLASH: Starting DeviceDetectionService...");
            cAppend("STARTING MOTO FLASH: Starting DeviceDetectionService...");
            await Task.Run(() => DeviceDetectionService());
            _log.Info("STARTING MOTO FLASH: Starting DeviceDetectionService... {OK}");
            cAppend("STARTING MOTO FLASH: Starting DeviceDetectionService... {OK}");
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
                _log.Warn("STARTING MOTO FLASH: Please connect your device, so MotoTool can check your device!");
                cAppend("STARTING MOTO FLASH: Please connect your device, so MotoTool can check your device!");
                Dialogs.WarningDialog("MotoFlash", "Please connect your device, so MotoTool can check your device!");
                materialButtonDowngradeMoto.Enabled = false;
                materialButtonFlashMoto.Enabled = false;
                groupBox1.Enabled = false;
                return;
            }

            string dc = oConfigMng.Config.DeviceCodenmae;
            if (dc.ToString().Contains("doha") == true ||
                dc.ToString().Contains("sofiar") == true ||
                dc.ToString().Contains("ocean") == true ||
                dc.ToString().Contains("beckham") == true ||
                dc.ToString().Contains("sanders") == true ||
                dc.ToString().Contains("potter") == true ||
                dc.ToString().Contains("kane_sprout") == true ||
                dc.ToString().Contains("hannah") == true ||
                dc.ToString().Contains("ahannah") == true)
            {
                string firmwarepath = @"C:\\MotoTool\\Firmware\\" + oConfigMng.Config.DeviceFirmware + @"\\" + oConfigMng.Config.DeviceFirmwareInfo;
                if (Directory.Exists(firmwarepath) || oConfigMng.Config.FirmwareExtracted == "1")
                {
                    _log.Info("STARTING MOTO FLASH: Setting firmware path: " + firmwarepath);
                    cAppend("STARTING MOTO FLASH: Setting firmware path: " + firmwarepath);
                    Directory.SetCurrentDirectory(firmwarepath);
                    _log.Info("STARTING MOTO FLASH: Setting firmware path: " + firmwarepath + " {OK}");
                    cAppend("STARTING MOTO FLASH: Setting firmware path: " + firmwarepath + " {OK}");
                }
                else
                {
                    _log.Warn("STARTING MOTO FLASH: Please download your firmware! - Device Channel: " + "{ " + oConfigMng.Config.DeviceFirmware + "}");
                    cAppend("STARTING MOTO FLASH: Please download your firmware! - Device Channel: " + "{ " + oConfigMng.Config.DeviceFirmware + "}");
                    materialButtonDowngradeMoto.Enabled = false;
                    materialButtonFlashMoto.Enabled = false;
                    groupBox1.Enabled = false;
                    Dialogs.WarningDialog("Moto Flash", "Please download your firmware! - Device Channel: " + "{" + oConfigMng.Config.DeviceFirmware + "}");
                    return;
                }
            } 
            else
            {
                _log.Warn("STARTING MOTO FLASH: Device not compatible yet! Current device: " + oConfigMng.Config.DeviceCodenmae);
                cAppend("STARTING MOTO FLASH: Device not compatible yet! Current device: " + oConfigMng.Config.DeviceCodenmae);
                materialButtonDowngradeMoto.Enabled = false;
                materialButtonFlashMoto.Enabled = false;
                groupBox1.Enabled = false;
                Dialogs.WarningDialog("MotoFlash: Device not compatible yet!", "Hey! im working to make compatible your device! device compatible for now: Beckham, Doha, Potter, Sanders, Ocean and Sofiar");
                return;
            }
        }

        public async void FFlash(string command)
        {
            List <String> devices = (List<string>)await Task.Run(() => Fastboot.Instance().Execute(command));
            devices.ToString();
            var devices1 = String.Join("", devices.ToArray());
            _log.Debug("MOTO FLASH: Flashing... {" + devices1 + "}");
            cAppend("MOTO FLASH: Flashing... {" + devices1 + "}");
            if (backgroundWorker == null)
            {
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void Calculate(int i)
        {
            double pow = Math.Pow(i, i);
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            WorkerReportsProgress = true;
            var backgroundWorker = sender as BackgroundWorker;
            for (int j = 0; j < 100000; j++)
            {
                Calculate(j);
                backgroundWorker.ReportProgress((j * 100) / 100000);
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar_Total.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar_Total.Value = 100;
        }

        private async void flash_Click(object sender, EventArgs e)
        {
            try
            {
                if (materialSwitchFlashAll.Checked == false && materialSwitchFlashAllExceptModem.Checked == false)
                {                    
                    cAppend("MOTO FLASH: Please select an option!");
                    Dialogs.WarningDialog("Moto Flash", "Please select an option!");
                    return;
                }

                string firmwarepath = @"C:\\MotoTool\\Firmware\\" + oConfigMng.Config.DeviceFirmware + @"\\" + oConfigMng.Config.DeviceFirmwareInfo;
                Thread.Sleep(3000);

                if (state == IDDeviceState.FASTBOOT || state == IDDeviceState.BOOTLOADER)
                {
                    try
                    {
                        _log.Info("MOTO FLASH: Settings firmware path: " + firmwarepath);
                        cAppend("MOTO FLASH: Settings firmware path: " + firmwarepath);
                        Directory.SetCurrentDirectory(firmwarepath);
                        _log.Info("MOTO FLASH: Rebooting into bootloader mode");
                        cAppend("MOTO FLASH: Rebooting into bootloader mode");
                        await Task.Run(() => ADB.Instance().Reboot(IDBoot.BOOTLOADER));
                        if (materialSwitchFlashAll.Checked == true)
                        {
                            string dc = oConfigMng.Config.DeviceCodenmae;
                            if (dc.ToString().Contains("doha") == true ||
                                dc.ToString().Contains("sofiar") == true ||
                                dc.ToString().Contains("ocean") == true ||
                                dc.ToString().Contains("evert") == true ||
                                dc.ToString().Contains("kane_sprout") == true)
                            {
                                FirmwareFlashRead.ReadFirmwareFlashAB(oConfigMng.Config.DeviceCodenmae);
                                FFlash(FirmwareFlashRead.set_a);
                            }
                            else
                            {
                                FirmwareFlashRead.ReadFirmwareFlashN(oConfigMng.Config.DeviceCodenmae);
                            }

                            FFlash(FirmwareFlashRead.getvar);
                            FFlash(FirmwareFlashRead.oem);
                            FFlash(FirmwareFlashRead.gpt);
                            FFlash(FirmwareFlashRead.bootloader);

                            if (oConfigMng.Config.DeviceCodenmae == "sanders")
                            {
                                FirmwareFlashRead.ReadFirmwareFlashN(oConfigMng.Config.DeviceCodenmae);
                                FFlash(FirmwareFlashRead.fsg_a);
                                FFlash(FirmwareFlashRead.modemst1);
                                FFlash(FirmwareFlashRead.modemst2);
                                FFlash(FirmwareFlashRead.bluetooth_a);
                                FFlash(FirmwareFlashRead.dsp_a);
                                FFlash(FirmwareFlashRead.logo_a);
                                FFlash(FirmwareFlashRead.boot_a);
                                FFlash(FirmwareFlashRead.system_a_0);
                                FFlash(FirmwareFlashRead.system_a_1);
                                FFlash(FirmwareFlashRead.system_a_2);
                                FFlash(FirmwareFlashRead.system_a_3); 
                                FFlash(FirmwareFlashRead.system_a_4);
                                FFlash(FirmwareFlashRead.system_a_5);
                                FFlash(FirmwareFlashRead.system_a_6);
                                FFlash(FirmwareFlashRead.system_a_7);
                                FFlash(FirmwareFlashRead.system_a_8);
                                FFlash(FirmwareFlashRead.system_a_9);
                                FFlash(FirmwareFlashRead.system_a_10);
                                FFlash(FirmwareFlashRead.oem_a);
                            }
                            if (oConfigMng.Config.DeviceCodenmae == "potter")
                            {
                                FirmwareFlashRead.ReadFirmwareFlashN(oConfigMng.Config.DeviceCodenmae);
                                FFlash(FirmwareFlashRead.fsg_a);
                                FFlash(FirmwareFlashRead.modemst1);
                                FFlash(FirmwareFlashRead.modemst2);
                                FFlash(FirmwareFlashRead.bluetooth_a);
                                FFlash(FirmwareFlashRead.dsp_a);
                                FFlash(FirmwareFlashRead.logo_a);
                                FFlash(FirmwareFlashRead.boot_a);
                                FFlash(FirmwareFlashRead.system_a_0);
                                FFlash(FirmwareFlashRead.system_a_1);
                                FFlash(FirmwareFlashRead.system_a_2);
                                FFlash(FirmwareFlashRead.system_a_3);
                                FFlash(FirmwareFlashRead.system_a_4);
                                FFlash(FirmwareFlashRead.system_a_5);
                                FFlash(FirmwareFlashRead.system_a_6);
                                FFlash(FirmwareFlashRead.system_a_7);
                                FFlash(FirmwareFlashRead.system_a_8);
                                FFlash(FirmwareFlashRead.oem_a);
                            }
                            if (oConfigMng.Config.DeviceCodenmae == "ocean")
                            {
                                FirmwareFlashRead.ReadFirmwareFlashAB(oConfigMng.Config.DeviceCodenmae);
                                FFlash(FirmwareFlashRead.modem_a);
                                FFlash(FirmwareFlashRead.modem_b);
                                FFlash(FirmwareFlashRead.fsg_a);
                                FFlash(FirmwareFlashRead.fsg_b);
                                FFlash(FirmwareFlashRead.modemst1);
                                FFlash(FirmwareFlashRead.modemst2);
                                FFlash(FirmwareFlashRead.dsp_a);
                                FFlash(FirmwareFlashRead.dsp_b);
                                FFlash(FirmwareFlashRead.logo_a);
                                FFlash(FirmwareFlashRead.logo_b);
                                FFlash(FirmwareFlashRead.boot_a);
                                FFlash(FirmwareFlashRead.boot_b);
                                FFlash(FirmwareFlashRead.dtbo_a);
                                FFlash(FirmwareFlashRead.dtbo_b);
                                FFlash(FirmwareFlashRead.system_a_0);
                                FFlash(FirmwareFlashRead.system_a_1);
                                FFlash(FirmwareFlashRead.system_a_2);
                                FFlash(FirmwareFlashRead.system_a_3);
                                FFlash(FirmwareFlashRead.system_a_4);
                                FFlash(FirmwareFlashRead.system_a_5);
                                FFlash(FirmwareFlashRead.system_a_6);
                                FFlash(FirmwareFlashRead.system_a_7);
                                FFlash(FirmwareFlashRead.system_a_8);
                                FFlash(FirmwareFlashRead.system_a_9);
                                FFlash(FirmwareFlashRead.system_b_0);
                                FFlash(FirmwareFlashRead.system_b_1);
                                FFlash(FirmwareFlashRead.system_b_2);
                                FFlash(FirmwareFlashRead.vendor_a_0);
                                FFlash(FirmwareFlashRead.vendor_a_1);
                                FFlash(FirmwareFlashRead.vendor_b_0);
                                FFlash(FirmwareFlashRead.vendor_b_1);
                                FFlash(FirmwareFlashRead.oem_a);
                                FFlash(FirmwareFlashRead.oem_b);
                            }
                            if (oConfigMng.Config.DeviceCodenmae == "sofiar")
                            {
                                FirmwareFlashRead.ReadFirmwareFlashAB(oConfigMng.Config.DeviceCodenmae);
                                FFlash(FirmwareFlashRead.vbmeta_a);
                                FFlash(FirmwareFlashRead.vbmeta_b);
                                FFlash(FirmwareFlashRead.radio_a);
                                FFlash(FirmwareFlashRead.radio_b);
                                FFlash(FirmwareFlashRead.bluetooth_a);
                                FFlash(FirmwareFlashRead.bluetooth_b);
                                FFlash(FirmwareFlashRead.dsp_a);
                                FFlash(FirmwareFlashRead.dsp_b);
                                FFlash(FirmwareFlashRead.logo_a);
                                FFlash(FirmwareFlashRead.logo_b);
                                FFlash(FirmwareFlashRead.boot_a);
                                FFlash(FirmwareFlashRead.boot_b);
                                FFlash(FirmwareFlashRead.dtbo_a);
                                FFlash(FirmwareFlashRead.dtbo_b);
                                FFlash(FirmwareFlashRead.recovery_a);
                                FFlash(FirmwareFlashRead.recovery_b);
                                FFlash(FirmwareFlashRead.system_a_0);
                                FFlash(FirmwareFlashRead.system_a_1);
                                FFlash(FirmwareFlashRead.system_a_2);
                                FFlash(FirmwareFlashRead.system_a_3);
                                FFlash(FirmwareFlashRead.system_a_4);
                                FFlash(FirmwareFlashRead.system_a_5);
                                FFlash(FirmwareFlashRead.system_a_6);
                                FFlash(FirmwareFlashRead.system_a_7);
                                FFlash(FirmwareFlashRead.system_a_8);
                                FFlash(FirmwareFlashRead.system_a_9);
                                FFlash(FirmwareFlashRead.system_a_10);
                                FFlash(FirmwareFlashRead.system_a_11);
                                FFlash(FirmwareFlashRead.system_a_12);
                                FFlash(FirmwareFlashRead.system_a_13);
                                FFlash(FirmwareFlashRead.system_a_14);
                            }
                            if (oConfigMng.Config.DeviceCodenmae == "doha")
                            {
                                FirmwareFlashRead.ReadFirmwareFlashAB(oConfigMng.Config.DeviceCodenmae);
                                FFlash(FirmwareFlashRead.vbmeta_a);
                                FFlash(FirmwareFlashRead.vbmeta_b);
                                FFlash(FirmwareFlashRead.modem_a);
                                FFlash(FirmwareFlashRead.modem_b);
                                FFlash(FirmwareFlashRead.fsg_a);
                                FFlash(FirmwareFlashRead.fsg_b);
                                FFlash(FirmwareFlashRead.modemst1);
                                FFlash(FirmwareFlashRead.modemst2);
                                FFlash(FirmwareFlashRead.bluetooth_a);
                                FFlash(FirmwareFlashRead.bluetooth_b);
                                FFlash(FirmwareFlashRead.dsp_a);
                                FFlash(FirmwareFlashRead.dsp_b);
                                FFlash(FirmwareFlashRead.logo_a);
                                FFlash(FirmwareFlashRead.logo_b);
                                FFlash(FirmwareFlashRead.boot_a);
                                FFlash(FirmwareFlashRead.boot_b);
                                FFlash(FirmwareFlashRead.dtbo_a);
                                FFlash(FirmwareFlashRead.dtbo_b);
                                FFlash(FirmwareFlashRead.system_a_0);
                                FFlash(FirmwareFlashRead.system_a_1);
                                FFlash(FirmwareFlashRead.system_a_2);
                                FFlash(FirmwareFlashRead.system_a_3);
                                FFlash(FirmwareFlashRead.system_a_4);
                                FFlash(FirmwareFlashRead.system_a_5);
                                FFlash(FirmwareFlashRead.system_b_0);
                                FFlash(FirmwareFlashRead.system_b_1);
                                FFlash(FirmwareFlashRead.oem_a);
                                FFlash(FirmwareFlashRead.oem_b);
                                FFlash(FirmwareFlashRead.vendor_a);
                                FFlash(FirmwareFlashRead.vendor_b);
                            }
                            if (oConfigMng.Config.DeviceCodenmae == "beckham")
                            {
                                FirmwareFlashRead.ReadFirmwareFlashAB(oConfigMng.Config.DeviceCodenmae);
                                FFlash(FirmwareFlashRead.modem_a);
                                FFlash(FirmwareFlashRead.fsg_a);
                                FFlash(FirmwareFlashRead.modemst1);
                                FFlash(FirmwareFlashRead.modemst2);
                                FFlash(FirmwareFlashRead.bluetooth_a);
                                FFlash(FirmwareFlashRead.dsp_a);
                                FFlash(FirmwareFlashRead.logo_a);
                                FFlash(FirmwareFlashRead.boot_a);
                                FFlash(FirmwareFlashRead.system_a_0);
                                FFlash(FirmwareFlashRead.system_a_1);
                                FFlash(FirmwareFlashRead.system_a_2);
                                FFlash(FirmwareFlashRead.system_a_3);
                                FFlash(FirmwareFlashRead.system_a_4);
                                FFlash(FirmwareFlashRead.system_a_5);
                                FFlash(FirmwareFlashRead.system_b_0);
                                FFlash(FirmwareFlashRead.oem_a);
                                FFlash(FirmwareFlashRead.oem_b);
                                FFlash(FirmwareFlashRead.vendor_a);
                                FFlash(FirmwareFlashRead.vendor_b);
                            }

                            if (oConfigMng.Config.DeviceCodenmae == "kane_sprout")
                            {
                                FirmwareFlashRead.ReadFirmwareFlashAB(oConfigMng.Config.DeviceCodenmae);
                                FFlash(FirmwareFlashRead.pit);
                                FFlash(FirmwareFlashRead.fwbl1);
                                FFlash(FirmwareFlashRead.ldfw_a);
                                FFlash(FirmwareFlashRead.ldfw_b);
                                FFlash(FirmwareFlashRead.keystorage_a);
                                FFlash(FirmwareFlashRead.keystorage_b);
                                FFlash(FirmwareFlashRead.bootloader_b);
                                FFlash(FirmwareFlashRead.modem_a);
                                FFlash(FirmwareFlashRead.modem_b);
                                FFlash(FirmwareFlashRead.vbmeta_a);
                                FFlash(FirmwareFlashRead.vbmeta_b);
                                FFlash(FirmwareFlashRead.oem_a);
                                FFlash(FirmwareFlashRead.oem_b);
                                FFlash(FirmwareFlashRead.logo_a);
                                FFlash(FirmwareFlashRead.logo_b);
                                FFlash(FirmwareFlashRead.dtbo_a);
                                FFlash(FirmwareFlashRead.dtbo_b);
                                FFlash(FirmwareFlashRead.boot_a);
                                FFlash(FirmwareFlashRead.boot_b);
                                FFlash(FirmwareFlashRead.system_a_0);
                                FFlash(FirmwareFlashRead.system_a_1);
                                FFlash(FirmwareFlashRead.system_a_10);
                                FFlash(FirmwareFlashRead.system_a_2);
                                FFlash(FirmwareFlashRead.system_a_3);
                                FFlash(FirmwareFlashRead.system_a_4);
                                FFlash(FirmwareFlashRead.system_a_5);
                                FFlash(FirmwareFlashRead.system_a_6);
                                FFlash(FirmwareFlashRead.system_a_7);
                                FFlash(FirmwareFlashRead.system_a_8);
                                FFlash(FirmwareFlashRead.system_a_9);
                                FFlash(FirmwareFlashRead.system_b_0);
                                FFlash(FirmwareFlashRead.system_b_1);
                                FFlash(FirmwareFlashRead.system_b_2);
                                FFlash(FirmwareFlashRead.vendor_a);
                                FFlash(FirmwareFlashRead.vendor_b);
                            }

                            if (oConfigMng.Config.DeviceCodenmae == "hannah" || oConfigMng.Config.DeviceCodenmae == "ahannah")
                            {
                                FirmwareFlashRead.ReadFirmwareFlashN(oConfigMng.Config.DeviceCodenmae);
                                FFlash(FirmwareFlashRead.modem_a);
                                FFlash(FirmwareFlashRead.fsg_a);
                                FFlash(FirmwareFlashRead.modemst1);
                                FFlash(FirmwareFlashRead.modemst2);
                                FFlash(FirmwareFlashRead.dsp_a);
                                FFlash(FirmwareFlashRead.logo_a);
                                FFlash(FirmwareFlashRead.boot_a);
                                FFlash(FirmwareFlashRead.recovery_a);
                                FFlash(FirmwareFlashRead.system_a_0);
                                FFlash(FirmwareFlashRead.system_a_1);
                                FFlash(FirmwareFlashRead.system_a_2);
                                FFlash(FirmwareFlashRead.system_a_3);
                                FFlash(FirmwareFlashRead.system_a_4);
                                FFlash(FirmwareFlashRead.vendor_a);
                                FFlash(FirmwareFlashRead.oem_a);
                            }
                            
                            FFlash(FirmwareFlashRead.erasecarrier);
                            FFlash(FirmwareFlashRead.eraseuserdata);
                            FFlash(FirmwareFlashRead.eraseddr);
                            FFlash(FirmwareFlashRead.oemclear);
                            FFlash(FirmwareFlashRead.reboot);
                            Dialogs.InfoDialog("FIRMWARE Installed!", "FIRMWARE: " + oConfigMng.Config.DeviceFirmwareInfo + " installed!");
                        }

                        // no modem
                        if (materialSwitchFlashAllExceptModem.Checked == true)
                        {
                            _log.Warn("Moto Flash: Flash No Modem: This option is not ready yet...");
                            cAppend("Moto Flash: Flash No Modem: This option is not ready yet...");
                            Dialogs.WarningDialog("Moto Flash: Flash No Modem", "This option is not ready yet...");
                            materialSwitchFlashAllExceptModem.Checked = false;
                            return;
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
                    _log.Warn("Moto Flash: Please plug your device! Remember to plug your phone on Fastboot Mode!");
                    Dialogs.WarningDialog("Moto Flash", "Please plug your device! Remember to plug your phone on Fastboot Mode!");
                } 
            }
            catch (Exception er)
            {
                Logs.DebugErrorLogs(er);
                _log.Error("MOTO FLASH ERROR: " + er);
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
            if (materialSwitchFlashAll.Checked == true)
            {
                FlashAllExceptModem = materialSwitchFlashAllExceptModem.Checked = false;
                materialSwitchFlashAllExceptModem.Checked = false;
            }
        }

        private void materialSwitchFlashAllExceptModem_CheckedChanged(object sender, EventArgs e)
        {
            FlashAllExceptModem = materialSwitchFlashAllExceptModem.Checked;
            if (materialSwitchFlashAllExceptModem.Checked == true)
            {
                FlashAll = materialSwitchFlashAll.Checked = false;
                materialSwitchFlashAll.Checked = false;
            }
        }

        private void materialButtonExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
