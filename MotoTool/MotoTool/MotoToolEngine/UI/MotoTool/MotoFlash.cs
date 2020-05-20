
using AndroidCtrl;
using AndroidCtrl.ADB;
using AndroidCtrl.Fastboot;
using AndroidCtrl.Tools;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Franco28Tool.Engine
{
    public partial class MotoFlash : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private SettingsMng oConfigMng = new SettingsMng();
        ArrayList devicecheck = new ArrayList();
        IDDeviceState state = General.CheckDeviceState(ADB.Instance().DeviceID);

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
            string active = String.Empty;
            
            this.Invoke((Action)delegate
            {
                devicecheck.Clear();
            });

            List<DataModelDevicesItem> adbDevices = ADB.Devices();
            List<DataModelDevicesItem> fastbootDevices = Fastboot.Devices();

            foreach (DataModelDevicesItem device in adbDevices)
            {
                this.Invoke((Action)delegate
                {
                    cAppend("Device adb connected!");
                    devicecheck.Add(" Device: Online! - ADB");
                    devicecheck.Add(" Device Codename: " + LoadDeviceServer.devicecodename);
                    devicecheck.Add(" Mode: " + state);
                    listBoxDeviceStatus.DataSource = devicecheck;
                });
            }
            foreach (DataModelDevicesItem device in fastbootDevices)
            {
                this.Invoke((Action)delegate
                {
                    cAppend("Device fastboot connected!");
                    devicecheck.Add(" Device: Online! - FASTBOOT");
                    devicecheck.Add(" Device Codename: " + LoadDeviceServer.devicecodename);
                    devicecheck.Add(" Mode: " + state);
                    listBoxDeviceStatus.DataSource = devicecheck;
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

        private async void MotoFlash_Load(object sender, EventArgs e)
        {
            oConfigMng.LoadConfig();
            cAppend("STARTING MOTO FLASH: Detecting device...");
            await Task.Run(() => DeviceDetectionService());
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
                cAppend("STARTING MOTO FLASH: Please connect your device, so MotoTool can check your device!");
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
                cAppend("STARTING MOTO FLASH: Device not compatible yet! Current device: " + oConfigMng.Config.DeviceCodenmae);
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

        public async void FFlash(string command)
        {
            List<String> devices = await Task.Run(() => Fastboot.Instance().Execute("fastboot " + command)); ;
            devices.ToString();
            var devices1 = String.Join("", devices.ToArray());
            cAppend("MOTO FLASH: Flashing... {" + devices1 + "}");
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

                string firmwarepath = @"C:\\adb\\Firmware\\" + oConfigMng.Config.DeviceFirmware + oConfigMng.Config.DeviceFirmwareInfo;
                Thread.Sleep(3000);

                if (state == IDDeviceState.FASTBOOT || state == IDDeviceState.BOOTLOADER)
                {
                    try
                    {
                        cAppend("MOTO FLASH: Settings firmware path: " + firmwarepath);
                        Directory.SetCurrentDirectory(firmwarepath);
                        cAppend("MOTO FLASH: Waiting for device...");
                        await Task.Run(() => ADB.WaitForDevice());
                        cAppend("MOTO FLASH: Rebooting into bootloader mode.");
                        await Task.Run(() => ADB.Instance().Reboot(IDBoot.BOOTLOADER));
                        if (materialSwitchFlashAll.Checked == true)
                        {
                            cAppend("Device Info: Waiting for device...");
                            await Task.Run(() => ADB.WaitForDevice());

                            if (oConfigMng.Config.DeviceCodenmae == "doha" && oConfigMng.Config.DeviceCodenmae == "ocean" && oConfigMng.Config.DeviceCodenmae == "evert")
                            {
                                FFlash(FirmwareFlashRead.set_a);
                            }

                            FFlash(FirmwareFlashRead.getvar);
                            FFlash(FirmwareFlashRead.oem);
                            FFlash(FirmwareFlashRead.gpt);
                            FFlash(FirmwareFlashRead.bootloader);

                            if (oConfigMng.Config.DeviceCodenmae == "sanders")
                            {
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
                    Dialogs.WarningDialog("Moto Flash", "Please plug your device! Remember to plug your phone on Fastboot Mode!");
                } 
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

        private void materialButtonExit_Click(object sender, EventArgs e)
        {
            if (oConfigMng.Config.Autosavelogs == "true")
            {
                cAppend("EXIT: Saving MotoFlash logs...");
                try
                {
                    string filePath = @"C:\adb\.settings\Logs\MotoFlash.txt";
                    cAppend("EXIT: Saving MotoFlash logs... {OK}");
                    consoleMotoFlash.SaveFile(filePath, RichTextBoxStreamType.PlainText);
                }
                catch (Exception ex)
                {
                    Logs.DebugErrorLogs(ex);
                    cAppend("EXIT: Saving MotoFlash logs... {ERROR}");
                    Dialogs.ErrorDialog("An error has occured while attempting to save the output...", ex.ToString());
                }
            }
            this.Dispose();
        }
    }
}
