
using AutoUpdaterDotNET;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
using System.Collections.Generic;
using System.Threading.Tasks;
using AndroidCtrl.Fastboot;
using AndroidCtrl.Tools;
using System.Linq;
using System.Globalization;
using System.Resources;
using System.Runtime.InteropServices;
using MaterialSkin.Controls;
using MaterialSkin;
using log4net;
using AndroidCtrl;
using AndroidCtrl.ADB;
using System.Windows.Controls;

namespace Franco28Tool.Engine
{
    [ComVisible(false)]

    public partial class MainForm : MaterialForm
    {
        [System.ComponentModel.Browsable(false)]
        private readonly MaterialSkinManager materialSkinManager;
        private PerformanceCounter ramCounter;
        private PerformanceCounter cpuCounter;
        private SettingsMng oConfigMng = new SettingsMng();
        string ToolVer = Assembly.GetEntryAssembly().GetName().Version.ToString();
        public Form activeForm = null;
        ArrayList devicecheck = new ArrayList();
        Timer timer = new Timer();
        public CultureInfo cul;
        public ResourceManager res_man;
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private int colorSchemeIndex;
        Timer timerupdates = new Timer();
        IDDeviceState state = General.CheckDeviceState(ADB.Instance().DeviceID);

        public void cAppend(string message)
        {
            this.Invoke((Action)delegate
            {
                console.AppendText(string.Format("\n{0} : {1}", DateTime.Now, message));
                console.ScrollToCaret();
            });
        }

        public MainForm()
        {            
            oConfigMng.LoadConfig();
            res_man = new ResourceManager("Franco28Tool.Engine.Resources.lang.Res", typeof(MainForm).Assembly);
            if (oConfigMng.Config.ToolLang == null || oConfigMng.Config.ToolLang == "")
            {
                _log.Info("Setting MotoTool default language");
                oConfigMng.Config.ToolLang = "en";
                cul = CultureInfo.CreateSpecificCulture("en");
            }
            if (oConfigMng.Config.ToolLang == "en")
            {
                _log.Info("Setting en language");
                cul = CultureInfo.CreateSpecificCulture("en");
            }
            if (oConfigMng.Config.ToolLang == "es")
            {
                _log.Info("Setting es language");
                cul = CultureInfo.CreateSpecificCulture("es");
            }
            _log.Debug("Setting MotoTool...");
            oConfigMng.Config.ToolVersion = ToolVer;
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            _log.Debug("Checking main title: " + "MotoTool v" + oConfigMng.Config.ToolVersion + " - " + oConfigMng.Config.ToolLang);
            this.Text = "MotoTool v" + oConfigMng.Config.ToolVersion + " - " + oConfigMng.Config.ToolLang;
            InitializeComponent();
            disablemainbtns();

            #region translates
            materialLabel24.Text = res_man.GetString("HOMESTRING", cul);
            listBoxDeviceStatus.Items.Add(res_man.GetString("LabelDevice", cul) + " " + res_man.GetString("DeviceOffline", cul) + "!");
            listBoxDeviceStatus.Items.Add(res_man.GetString("DeviceMode", cul) + " ---");
            materialLabel12.Text = res_man.GetString("OTHERSSTRING", cul);
            tabPageHOME.Text = res_man.GetString("HOMESTRING", cul);
            tabPageSettings.Text = res_man.GetString("SETTINGSSTRING", cul);
            tabPageFIRMWARE.Text = res_man.GetString("FIRMWARESTRING", cul);
            materialLabel25.Text = res_man.GetString("FIRMWARESTRING", cul);
            materialLabel38.Text = res_man.GetString("LabelFirmwareDownloadCard", cul);
            materialLabel14.Text = res_man.GetString("LabelFirmwareDownloadCardText", cul);
            materialButtonFirmwareCard.Text = res_man.GetString("LabelFirmwareDownloadCardBTN", cul);
            materialLabel9.Text = res_man.GetString("LabelFlashToolCard", cul);
            materialLabel7.Text = res_man.GetString("LabelFlashToolCardText", cul);
            materialButtonFlashTool.Text = res_man.GetString("LabelFlashToolCardBTN", cul);
            materialLabel27.Text = res_man.GetString("LabelToolSettings", cul);
            tabPage11.Text = res_man.GetString("LabelToolSettings", cul);
            tabPage10.Text = res_man.GetString("LabelToolSettingsTheme", cul);
            materialLabel1.Text = res_man.GetString("LabelToolSettingsTheme", cul);
            materialButtonChangeTheme.Text = res_man.GetString("LabelChangeThemeBTN", cul);
            materialLabel4.Text = res_man.GetString("LabelToolSystemColors", cul);
            materialSwitchDrawerUseColors.Text = res_man.GetString("LabelToolSystemColorsDrawerUseColors", cul);
            materialSwitchDrawerHighlightWithAccent.Text = res_man.GetString("LabelToolSystemColorsDrawerHWA", cul);
            materialSwitchDrawerBackgroundWithAccent.Text = res_man.GetString("LabelToolSystemColorsDrawerBWA", cul);
            materialSwitchDrawerShowIconsWhenHidden.Text = res_man.GetString("LabelToolSystemColorsDrawerDIWH", cul);
            MaterialButtonChangeColor.Text = res_man.GetString("ThemeBTNChangeColors", cul);
            materialLabel13.Text = res_man.GetString("LabelSettingsToolDevices", cul);
            materialLabel2.Text = res_man.GetString("LabelSettingsToolFolders", cul);
            materialLabel16.Text = res_man.GetString("LabelSettingsToolRDF", cul);
            materialButtonCheckUpdates.Text = res_man.GetString("LabelSettingsToolCUBTN", cul);
            materialButtonUninstall.Text = res_man.GetString("LabelSettingsToolUNSBTN", cul);
            materialButtonCMD.Text = res_man.GetString("LabelSettingsToolSCMDBTN", cul); ;
            materialButtonChangeLang.Text = res_man.GetString("LabelSettingsToolCLBTN", cul);
            materialButtonOpenADBFolder.Text = res_man.GetString("LabelSettingsToolOTFBTN", cul);
            materialButtonclearallfolders.Text = res_man.GetString("LabelSettingsToolCAFBTN", cul);
            materialButtonOpenFirmwareFolder.Text = res_man.GetString("LabelSettingsToolOFFBTN", cul);
            materialButtonReport.Text = res_man.GetString("LabelSettingsToolRPBTN", cul);
            materialButtonContact.Text = res_man.GetString("LabelSettingsToolCBTN", cul);
            materialButtonHelp.Text = res_man.GetString("LabelSettingsToolHBTN", cul);
            materialButtonAddNewDevice.Text = res_man.GetString("LabelSettingsToolANDBTN", cul);
            materialButtonRemoveToolDeviceData.Text = res_man.GetString("LabelSettingsToolRTSDDBTN", cul);
            materialButtonAddNewDeviceManual.Text = res_man.GetString("LabelSettingsToolANDMBTN", cul);
            materialButtonRANDFOAND.Text = res_man.GetString("LabelSettingsToolQANDFOAND", cul);
            #endregion translates

            oConfigMng.Config.ToolCompiled = Utils.GetLinkerDateTime(Assembly.GetEntryAssembly(), null).ToString();
            InitializeRAMCounter();
            InitialiseCPUCounter();
            _log.Info("STARTING: Checking MotoTool updates");
            cAppend(res_man.GetString("STARTINGCheckMotoUpdateString", cul));
            cehck4updates();
            _log.Info("STARTING: Loading tool... Please wait...");
            cAppend(res_man.GetString("STARTINGLoadingMotoToolString", cul));
            _log.Info("STARTING: Checking MotoDrivers...");
            cAppend(res_man.GetString("STARTINGCheckingMotoDrivers", cul));
            if (File.Exists(@"C:\Program Files (x86)\Motorola Mobility\Motorola Device Manager\uninstall.exe"))
            {
                if (File.Exists(Folders.MotoToolPath() + @"\MotorolaDeviceManager_2.5.4.exe"))
                {
                    if (File.Exists(Folders.MotoToolPath() + @"\remove.bat"))
                    {
                        using (Process proc = new Process())
                        {
                            proc.StartInfo.WorkingDirectory = Folders.MotoToolPath();
                            proc.StartInfo.FileName = "remove.bat";
                            proc.StartInfo.CreateNoWindow = false;
                            proc.Start();
                            proc.WaitForExit();
                            int ExitCode = proc.ExitCode;
                        }
                    } else { }
                }
                _log.Info("STARTING: Checking MotoDrivers... {OK}");
                cAppend(res_man.GetString("STARTINGCheckingMotoDrivers", cul) + " {OK}");
            }
            else
            {
                _log.Info("STARTING: Checking MotoDrivers... {ERROR}");
                cAppend(res_man.GetString("STARTINGCheckingMotoDrivers", cul) + " {ERROR}");
                CheckMotoDrivers.MotoDrivers();
            }
            updateColorLoad();
            oConfigMng.SaveConfig();
        }

        public async void MainForm_LoadAsync(object sender, EventArgs e)
        {
            oConfigMng.LoadConfig();
            _log.Debug("STARTING: Checking MotoTool ver: " + ToolVer);
            cAppend(res_man.GetString("STARTINGCheckingMotoToolVer", cul) + ToolVer);
            if (oConfigMng.Config.ToolTheme == null || oConfigMng.Config.ToolTheme == "")
            {
                _log.Info("STARTING: Setting first MotoTool Theme... {DARK}");
                cAppend(res_man.GetString("STARTINGSettingFMotoToolTheme", cul));
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE);
                oConfigMng.Config.ToolTheme = "dark";
            }
            _log.Info("STARTING: Checking saved device...");
            cAppend(res_man.GetString("STARTINGCheckingSavedDevice", cul));
            if (oConfigMng.Config.DeviceCodenmae == null || oConfigMng.Config.DeviceCodenmae == "")
            {
                _log.Info("STARTING: Checking saved device... {NOT FOUND}");
                cAppend(res_man.GetString("STARTINGCheckingSavedDeviceNOT", cul));
                oConfigMng.Config.DeviceCodenmae = "";
            }
            else
            {
                _log.Info("STARTING: Checking saved device... {OK} - {" + oConfigMng.Config.DeviceCodenmae + "}");
                cAppend(res_man.GetString("STARTINGCheckingSavedDevice", cul) + " {OK} " + " {" + oConfigMng.Config.DeviceCodenmae + "}");
            }
            _log.Info("STARTING: Checking saved device carrier...");
            cAppend(res_man.GetString("STARTINGCheckingSavedDeviceCarrier", cul));
            if (oConfigMng.Config.DeviceFirmware == null || oConfigMng.Config.DeviceFirmware == "")
            {
                _log.Info("STARTING: Checking saved device carrier... {NOT FOUND}");
                cAppend(res_man.GetString("STARTINGCheckingSavedDeviceCarrierNOT", cul));
                oConfigMng.Config.DeviceFirmware = "";
            }
            else
            {
                _log.Info("STARTING: Checking saved device carrier... {OK} - {" + oConfigMng.Config.DeviceFirmware + "}");
                cAppend(res_man.GetString("STARTINGCheckingSavedDeviceCarrier", cul) + " {OK} " + " {" + oConfigMng.Config.DeviceFirmware + "}");
            }
            _log.Info("STARTING: Checking internet connection...");
            cAppend(res_man.GetString("STARTINGCheckingInternetConnection", cul));
            if (InternetCheck.ConnectToInternet() == true)
            {
                _log.Info("STARTING: Checking internet connection... {OK}");
                cAppend(res_man.GetString("STARTINGCheckingInternetConnection", cul) + " {OK} ");
                oConfigMng.Config.ToolInternet = "online";
            }
            else
            {
                _log.Error("STARTING: Checking internet connection... {ERROR}");
                cAppend(res_man.GetString("STARTINGCheckingInternetConnection", cul) + " {ERROR} ");
                oConfigMng.Config.ToolInternet = "offline";
            }
            _log.Info("STARTING: Applying MotoTool settings...");
            cAppend(res_man.GetString("STARTINGApplyMTSettings", cul));
            if (oConfigMng.Config.DrawerUseColors == null || oConfigMng.Config.DrawerUseColors == "")
            {
                oConfigMng.Config.DrawerUseColors = "false";
            }
            if (oConfigMng.Config.DrawerHighlightWithAccent == null || oConfigMng.Config.DrawerHighlightWithAccent == "")
            {
                oConfigMng.Config.DrawerHighlightWithAccent = "true";
            }
            if (oConfigMng.Config.DrawerBackgroundWithAccent == null || oConfigMng.Config.DrawerBackgroundWithAccent == "")
            {
                oConfigMng.Config.DrawerBackgroundWithAccent = "false";
            }
            if (oConfigMng.Config.DrawerShowIconsWhenHidden == null || oConfigMng.Config.DrawerShowIconsWhenHidden == "")
            {
                oConfigMng.Config.DrawerShowIconsWhenHidden = "true";
            }
            oConfigMng.SaveConfig();
            _log.Info("STARTING: Applying MotoTool settings... {OK}");
            cAppend(res_man.GetString("STARTINGApplyMTSettings", cul) + " {OK} ");
            await Task.Run(() => CheckAndDeploy());
            cAppend("-------------------------------------------------");
            _log.Info("MotoTool v " + ToolVer + res_man.GetString("STARTINGFinishLoad", cul));
            cAppend("MotoTool v " + ToolVer + res_man.GetString("STARTINGFinishLoad", cul));
            ReadInfoMSG();
            updateTimer_Tick();
            //Get app GUID
            //string assyGuid = Assembly.GetExecutingAssembly().GetCustomAttribute<GuidAttribute>().Value.ToUpper();
            //cAppend(assyGuid);
        }

        public void CheckAndDeploy()
        {
            oConfigMng.Config.ADBPath = Folders.MotoToolPath() + @"\platform-tools\";
            oConfigMng.SaveConfig();
            try
            {
                _log.Debug(res_man.GetString("STARTINGDeployingADBFASTBOOT", cul));
                cAppend(res_man.GetString("STARTINGDeployingADBFASTBOOT", cul));

                ADB.PATH_DIRECTORY = oConfigMng.Config.ADBPath;
                Fastboot.PATH_DIRECTORY = oConfigMng.Config.ADBPath;
                if (ADB.IntegrityCheck() == false)
                {
                    Deploy.ADB();
                }
                if (Fastboot.IntegrityCheck() == false)
                {
                    Deploy.Fastboot();
                }
                if (ADB.IsStarted)
                {
                    ADB.Stop();
                    ADB.Stop(true);
                }
                else
                {
                    ADB.Start();
                }
                DeviceDetectionService();
                _log.Debug("STARTING: Deploying adb & fastboot, please wait until this finish... {OK}");
                cAppend(res_man.GetString("STARTINGDeployingADBFASTBOOT", cul) + " {OK} ");
            }
            catch (Exception er)
            {
                Logs.DebugErrorLogs(er);
                Dialogs.ErrorDialog(res_man.GetString("STARTINGDeployingADBFASTBOOT", cul), "ERROR: starting adb services");
            }
        }

        public void ReadInfoMSG()
        {
            ReadMSGInfo.ReadInfo();
            string tr = "true";
            if (ReadMSGInfo.showmsg == tr)
            {
                if (oConfigMng.Config.ToolLang == "en")
                {
                    cAppend(ReadMSGInfo.msgen);
                }
                if (oConfigMng.Config.ToolLang == "es")
                {
                    cAppend(ReadMSGInfo.msges);
                }
            }
        }

        private void InitialiseCPUCounter()
        {
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total", true);
        }

        private void InitializeRAMCounter()
        {
            ramCounter = new PerformanceCounter("Memory", "Available MBytes", true);
        }

        private void updateTimer_Tick()
        {
            timer.Interval = (1 * 500);
            timer.Tick += new EventHandler(timer_Tick);
            AvoidFlick();
            timer.Start();
        }

        public void AvoidFlick()
        {
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
        }

        public void disablemainbtns()
        {
            materialButtonBlankFlash.Enabled = false;
            materialButtonFlashLogo.Enabled = false;
            materialButtonFlashTWRP.Enabled = false;
            materialButtonBootTWRP.Enabled = false;
            materialButtonRebootBootloader.Enabled = false;
            materialButtonRebootRecovery.Enabled = false;
            materialButtonBlankFlash.Enabled = false;
            materialButtonFlashLogo.Enabled = false;
            materialButtonUnlock.Enabled = false;
            materialButtonLock.Enabled = false;
        }

        public void enablemainbtns()
        {
            materialButtonBlankFlash.Enabled = true;
            materialButtonFlashLogo.Enabled = true;
            materialButtonFlashTWRP.Enabled = true;
            materialButtonBootTWRP.Enabled = true;
            materialButtonRebootBootloader.Enabled = true;
            materialButtonRebootRecovery.Enabled = true;
            materialButtonBlankFlash.Enabled = true;
            materialButtonFlashLogo.Enabled = true;
            materialButtonUnlock.Enabled = true;
            materialButtonLock.Enabled = true;
        }

        public void openChildFormWarningNoti(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Top;
            panelDownload.Controls.Add(childForm);
            panelDownload.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public void openChildFormFirmware(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            _log.Debug("Starting firmware form");
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelFimrware.Controls.Add(childForm);
            panelFimrware.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public void openChildFormFlashTool(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            _log.Debug("Starting flash tool form");
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelFlashTool.Controls.Add(childForm);
            panelFlashTool.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            oConfigMng.LoadConfig();
            labelFreeRam.Text = "      " + res_man.GetString("LabelFreeRAM", cul) + " " + Convert.ToInt64(ramCounter.NextValue()).ToString() + " MB";
            labelCPUusage.Text = "      CPU: " + Convert.ToInt64(cpuCounter.NextValue()).ToString() + "%";
            labelFreeSpace.Text = "      " + res_man.GetString("LabelFreeSize", cul) + @" C:\MotoTool: " + Folders.GetDirectorySize(@"C:\MotoTool") + " MB";
            labelUserName.Text = "      " + res_man.GetString("LabelUser", cul) + " " + Environment.UserName;
            TextBoxDebug.Text = res_man.GetString("LabelInfoDebug", cul);
            if (oConfigMng.Config.DeviceCodenmae == "" || oConfigMng.Config.DeviceFirmware == "")
            {
                TextBoxDebugInfo.Text = res_man.GetString("LabelChannel", cul) + " ---";
                TextBoxDebugInfo2.Text = res_man.GetString("LabelDevice", cul) + " ---";
                disablemainbtns();
            }           
            else
            {
                this.Text = "MotoTool v" + oConfigMng.Config.ToolVersion + " - " + oConfigMng.Config.ToolLang + " - " + oConfigMng.Config.DeviceCodenmae + " - " + oConfigMng.Config.DeviceFirmware;
                TextBoxDebugInfo.Text = res_man.GetString("LabelChannel", cul) + " " + oConfigMng.Config.DeviceFirmware;
                TextBoxDebugInfo2.Text = res_man.GetString("LabelDevice", cul) + " " + oConfigMng.Config.DeviceCodenmae;
                enablemainbtns();
                DeviceCompatible();
            }
        }

        public void canceltoolload()
        {
            timer.Stop();
            _log.Debug(res_man.GetString("StopMonitor", cul));
            cAppend(res_man.GetString("StopMonitor", cul));
            _log.Error(res_man.GetString("DeviceNotCompatible", cul) + " " + oConfigMng.Config.DeviceCodenmae + "\n " + res_man.GetString("LabelDevice", cul) + oConfigMng.Config.DeviceCodenmae + " " + res_man.GetString("DeviceNotCompatible2", cul) + "  " + " \nBeckham, Doha, Lake, Evert, Potter, Sanders, River, Ocean, Lima, Sofiar, Sofia, Kane_Sprout, Hannan and Ahannan");
            cAppend(res_man.GetString("DeviceNotCompatible", cul) + " " + oConfigMng.Config.DeviceCodenmae + "\n " + res_man.GetString("LabelDevice", cul) + oConfigMng.Config.DeviceCodenmae + " " + res_man.GetString("DeviceNotCompatible2", cul) + "  " + " \nBeckham, Doha, Lake, Evert, Potter, Sanders, River, Ocean, Lima, Sofiar, Sofia, Kane_Sprout, Hannan and Ahannan");
            Dialogs.WarningDialog(res_man.GetString("DeviceNotCompatible", cul) + " " + oConfigMng.Config.DeviceCodenmae, "\n " + res_man.GetString("LabelDevice", cul) + oConfigMng.Config.DeviceCodenmae + " " + res_man.GetString("DeviceNotCompatible2", cul) + "  " + " \nBeckham, Doha, Lake, Evert, Potter, Sanders, River, Ocean, Lima, Sofiar, Sofia, Kane_Sprout, Hannan and Ahannan");
            oConfigMng.Config.DeviceCodenmae = "";
            oConfigMng.Config.DeviceFirmware = "";
            oConfigMng.SaveConfig();
            Application.ExitThread();
            KillWhenExit();
        }

        public void DeviceCompatible()
        {
            _log.Info("Checking device compatibility...");
            cAppend("Checking device compatibility...");
            oConfigMng.LoadConfig();
            string dc = oConfigMng.Config.DeviceCodenmae;
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
                dc.Contains("hannah") == true ||
                dc.Contains("ahannah") == true)
            {
                _log.Debug("Checking device compatibility... {OK} " + dc.ToString());
                cAppend("Checking device compatibility... {OK} " + dc.ToString());
            }
            else
            {
                _log.Error("Checking device compatibility... {ERROR} " + dc.ToString());
                cAppend("Checking device compatibility... {ERROR} " + dc.ToString());
                canceltoolload();
                return;
            }
        }

        #region deviceconnectionmonitor

        public void DeviceConnected(string adborfastbootmsg)
        {
            try
            {
                _log.Info("Device: " + adborfastbootmsg + " connected!");
                cAppend(res_man.GetString("LabelDevice", cul) + " " + adborfastbootmsg + " " + res_man.GetString("Connected", cul));
                devicecheck.Add(" " + res_man.GetString("LabelDevice", cul) + " " + res_man.GetString("DeviceOnline", cul) + " - " + adborfastbootmsg);
                devicecheck.Add(" " + res_man.GetString("DeviceMode", cul) + state);
                listBoxDeviceStatus.DataSource = devicecheck;
                GetProp();

                _log.Info("Connecting to server device... " + oConfigMng.Config.DeviceCodenmae);
                cAppend(res_man.GetString("ConnectingToServer", cul)  + " " + oConfigMng.Config.DeviceCodenmae);
                if (oConfigMng.Config.DeviceCodenmae == "" && oConfigMng.Config.DeviceCodenmae == "")
                {
                    return;
                } 
                else
                {
                    LoadDeviceServer.CheckDevice(oConfigMng.Config.DeviceCodenmae + ".xml", oConfigMng.Config.DeviceCodenmae);
                    _log.Info("Connecting to server device... " + oConfigMng.Config.DeviceCodenmae + " {OK}");
                    cAppend(res_man.GetString("ConnectingToServer", cul) + " " + oConfigMng.Config.DeviceCodenmae + " {OK}");
                }
            }
            catch (Exception er)
            {
                Logs.DebugErrorLogs(er);
                cAppend(res_man.GetString("ConnectingToServer", cul) + " " + oConfigMng.Config.DeviceCodenmae + " {ERROR} " + er.ToString());
            }
        }

        private void SetDeviceList()
        {
            this.Invoke((Action)delegate
            {
                // Here we refresh our combobox
                listBoxDeviceStatus.Items.Clear();
                listBoxDeviceStatus.Items.Add("Device: Offline!");
                listBoxDeviceStatus.Items.Add("Mode: ---");
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
                    listBoxDeviceStatus.Items.Add(device);
                    DeviceConnected(device.ToString());
                });
            }
            foreach (DataModelDevicesItem device in fastbootDevices)
            {
                this.Invoke((Action)delegate
                {
                    listBoxDeviceStatus.Items.Add(device);
                    DeviceConnected(device.ToString());
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
                if (state == IDDeviceState.UNKNOWN)
                {
                    state = IDDeviceState.DEVICE;
                    DeviceConnected(state.ToString());
                }
                SetDeviceList();
            });
        }

        private void SelectDeviceInstance(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxDeviceStatus.Items.Count != 0)
            {
                DataModelDevicesItem device = (DataModelDevicesItem)listBoxDeviceStatus.SelectedItem;

                // This will select the given device in the Fastboot and ADB class
                Fastboot.SelectDevice(device.Serial);
                ADB.SelectDevice(device.Serial);
            }
        }

        /* // Callback for both (ADB/Fastboot)
         private void Added(object sender, MonitorAddedEventArgs e)
         {
             this.Invoke((Action)delegate
             {
                 // Do what u want with the "IDeviceInfo[] e.Devices.ToArray()"
                 // The "sender" is a "string" and returns "adb" or "fastboot"
                 devicecheck.Clear();
                 Fastboot.Instance();
                 ADB.Instance(e.ToString());
                 ADB.Select();
                 Fastboot.Select();
                 if (state == DeviceState.UNKNOWN)
                 {
                     state = DeviceState.DEVICE;
                     DeviceConnected(state.ToString());
                 }
             });
         }

         private void Changed(object sender, MonitorChangedEventArgs e)
         {
             this.Invoke((Action)delegate
             {
                 // Do what u want with the "IDeviceInfo[] e.Devices.ToArray()"
                 // The "sender" is a "string" and returns "adb" or "fastboot"
                 devicecheck.Clear();
                 Fastboot.Instance();
                 ADB.Instance(e.ToString());
                 ADB.Select();
                 Fastboot.Select();
                 if (state == DeviceState.UNKNOWN)
                 {
                     state = DeviceState.DEVICE;
                     DeviceConnected(state.ToString());
                 }
             });
         }

         private void Removed(object sender, MonitorRemovedEventArgs e)
         {
             this.Invoke((Action)delegate
             {
                 // Do what u want with the "IDeviceInfo[] e.Devices.ToArray()"
                 // The "sender" is a "string" and returns "adb" or "fastboot"
                 devicecheck.Clear();
                 Dialogs.InfoDialog("Device Monitor", "Your device was unploged!");
             });
         } */

        #endregion deviceconnectionmonitor

        public async void GetProp()
        {
            oConfigMng.LoadConfig();
            if (oConfigMng.Config.DeviceFirmware == "" || oConfigMng.Config.DeviceCodenmae == "")
            {
                if (IDDeviceState.DEVICE == state)
                {
                    _log.Info("Device Info: Getting device codename and carrier...");
                    cAppend(res_man.GetString("GetDeviceInfoCC", cul));
                    List<String> getdevicecodename = (List<string>)await Task.Run(() => ADB.Instance().ShellCmd("/system/bin/getprop ro.product.device"));
                    List<String> getcarrier = (List<string>)await Task.Run(() => ADB.Instance().ShellCmd("/system/bin/getprop ro.carrier"));
                    //getdevicecodename.ToString();
                    //getcarrier.ToString();
                    var result = String.Join("", getdevicecodename.ToArray());
                    var result2 = String.Join("", getcarrier.ToArray());
                    if (result == "" && result2 == "")
                    {
                        Dialogs.InfoDialog("Getting device info", "Hey! something went wrong, please re-connect your device!");
                        return;
                    }
                    else
                    {
                        oConfigMng.Config.DeviceCodenmae = result.ToString();
                        oConfigMng.Config.DeviceFirmware = result2.ToString();
                        _log.Info("Device Info: Device added: " + oConfigMng.Config.DeviceCodenmae + "\n " + res_man.GetString("LabelChannel", cul) + " " + oConfigMng.Config.DeviceFirmware);
                        cAppend(res_man.GetString("GetDeviceInfoCCAddedDevice", cul) + "  " + oConfigMng.Config.DeviceCodenmae + "\n " + res_man.GetString("LabelChannel", cul) + " " + oConfigMng.Config.DeviceFirmware);
                        oConfigMng.SaveConfig();
                        DeviceCompatible();
                        MainForm_LoadAsync(null, EventArgs.Empty);
                    }
                }
                else
                {
                    _log.Warn("Get Prop: Your device is in the wrong state. Please connect your device " + state);
                    cAppend("Get Prop: " + res_man.GetString("DeviceInfoWrongState", cul) + " " + state);
                }
            }
            else
            {
                _log.Info("Device Info: Device already added. \n Device: " + oConfigMng.Config.DeviceCodenmae + "\n Device carrier: " + oConfigMng.Config.DeviceFirmware);
                cAppend("Device Info: Device already added. \n Device: " + oConfigMng.Config.DeviceCodenmae + "\n Device carrier: " + oConfigMng.Config.DeviceFirmware);
            }
        }

        #region otaupdates

        private void AutoUpdater_ApplicationExitEvent()
        {
            _log.Debug("Updaes: Closing application...");
            Text = @"Closing application...";
            Thread.Sleep(2000);
            Application.Exit();
        }

        private void toolupdates(object sender, EventArgs e)
        {
            AutoUpdater.Start("https://raw.githubusercontent.com/Franco28/MotoTool/master/Server/Update.xml");
        }

        private void cehck4updates()
        {
            timerupdates.Interval = (1 * 30 * 100);
            timerupdates.Tick += new EventHandler(toolupdates);
            AvoidFlick();
            timerupdates.Start();
        }

        private void AutoUpdaterOnCheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            AutoUpdater.ApplicationExitEvent += AutoUpdater_ApplicationExitEvent;
            AutoUpdater.DownloadPath = Environment.CurrentDirectory;
            if (args != null)
            {
                if (args.IsUpdateAvailable)
                {
                    _log.Info("Cheking tool updates... NEW UPDATE! " + args.CurrentVersion);
                    cAppend("Cheking tool updates... NEW UPDATE! " + args.CurrentVersion);
                    this.Text = "New MotoTool Update " + args.CurrentVersion + ", please update now!";
                    AutoUpdater.ShowUpdateForm(args);
                    try
                    {
                        if (AutoUpdater.DownloadUpdate(args))
                        {
                            Application.Exit();
                        }
                    }
                    catch (Exception exception)
                    {
                        Logs.DebugErrorLogs(exception);
                        args = null;
                        timerupdates.Stop();
                        Dialogs.ErrorDialog(exception.Message, exception.GetType().ToString());
                    }
                }
                else
                {
                    args = null;
                    timerupdates.Stop();
                    _log.Info("No update available: There is no update available please try again later, or Tool will let you know!");
                    Dialogs.InfoDialog("No update available", "There is no update available please try again later, or Tool will let you know!");
                }
            }
            else
            {
                args = null;
                timerupdates.Stop();
                _log.Info("Update check failed: There is a problem reaching update server please check your internet connection and try again later");
                Dialogs.ErrorDialog("Update check failed", "There is a problem reaching update server please check your internet connection and try again later");
            }
        }

        #endregion otaupdates

        public void downloadcall(string xmlname, string xmlpath)
        {
            var call = new DownloadUI();
            _log.Debug("Calling download");
            DownloadsMng.TOOLDOWNLOAD(oConfigMng.Config.DeviceCodenmae, xmlname, xmlpath);
            openChildFormWarningNoti(call);
        }

        public void qBootExecuteCommand()
        {
            _log.Debug("BLANKFLASH CMD: Executing BLANKFLASH FILES...");
            cAppend("BLANKFLASH CMD: Executing BLANKFLASH FILES...");
            string _batDir = string.Format(@"C:\MotoTool\Others\" + LoadDeviceServer.unbrickname);
            using (Process proc = new Process())
            {
                proc.StartInfo.WorkingDirectory = _batDir;
                proc.StartInfo.FileName = "blank-flash.bat";
                proc.StartInfo.CreateNoWindow = false;
                proc.Start();
                proc.WaitForExit();
                int ExitCode = proc.ExitCode;
                _log.Debug("BLANKFLASH CMD: Executing BLANKFLASH FILES... {OK}");
                cAppend("BLANKFLASH CMD: Executing BLANKFLASH FILES... {OK}");
            }
        }

        #region ToolTheme
        private void materialButtonChangeTheme_Click(object sender, EventArgs e)
        {
            oConfigMng.LoadConfig();

            materialSkinManager.Theme = materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? MaterialSkinManager.Themes.LIGHT : MaterialSkinManager.Themes.DARK;

            if (materialSkinManager.Theme == MaterialSkinManager.Themes.DARK)
            {
                _log.Debug("TOOL THEME: Changed to... {DARK}");
                cAppend("TOOL THEME: Changed to... {DARK}");
                oConfigMng.Config.ToolTheme = "dark";
            }

            if (materialSkinManager.Theme == MaterialSkinManager.Themes.LIGHT)
            {
                _log.Debug("TOOL THEME: Changed to... {LIGHT}");
                cAppend("TOOL THEME: Changed to... {LIGHT}");
                oConfigMng.Config.ToolTheme = "light";
            }
            oConfigMng.SaveConfig();
            updateColor();
        }

        public void updateColorLoad()
        {
            oConfigMng.LoadConfig();

            if (oConfigMng.Config.ToolTheme == "light")
            {
                _log.Debug("STARTING: Loading MotoTool Theme... {LIGHT}");
                cAppend("STARTING: Loading MotoTool Theme... {LIGHT}");
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            if (oConfigMng.Config.ToolTheme == "dark")
            {
                _log.Debug("STARTING: Loading MotoTool Theme... {DARK}");
                cAppend("STARTING: Loading MotoTool Theme... {DARK}");
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            }
            if (oConfigMng.Config.ToolThemeBlueColor == "true")
            {
                colorSchemeIndex = 0;
            }
            if (oConfigMng.Config.ToolThemeGreenColor == "true")
            {
                colorSchemeIndex = 1;
            }
            if (oConfigMng.Config.ToolThemeIndigoColor == "true")
            {
                colorSchemeIndex = 2;
            }
            if (oConfigMng.Config.ThemeMainColor == "true")
            {
                colorSchemeIndex = 3;
            }
            if (oConfigMng.Config.DrawerUseColors == "true")
            {
                DrawerUseColors = materialSwitchDrawerUseColors.Checked;
                DrawerUseColors = materialSwitchDrawerUseColors.Checked = true;
            }
            if (oConfigMng.Config.DrawerHighlightWithAccent == "false")
            {
                DrawerHighlightWithAccent = materialSwitchDrawerHighlightWithAccent.Checked;
                DrawerHighlightWithAccent = materialSwitchDrawerHighlightWithAccent.Checked = false;
            }
            if (oConfigMng.Config.DrawerBackgroundWithAccent == "true")
            {
                DrawerBackgroundWithAccent = materialSwitchDrawerBackgroundWithAccent.Checked;
                DrawerBackgroundWithAccent = materialSwitchDrawerBackgroundWithAccent.Checked = true;
            }
            if (oConfigMng.Config.DrawerShowIconsWhenHidden == "false")
            {
                DrawerShowIconsWhenHidden = materialSwitchDrawerShowIconsWhenHidden.Checked;
                DrawerShowIconsWhenHidden = materialSwitchDrawerShowIconsWhenHidden.Checked = false;
            }
            updateColor();
        }

        private void MaterialButtonChangeColor_Click(object sender, EventArgs e)
        {
            colorSchemeIndex++;
            if (colorSchemeIndex > 3)
                colorSchemeIndex = 0;
            updateColor();
        }

        private void updateColor()
        {
            switch (colorSchemeIndex)
            {
                case 0:
                    materialSkinManager.ColorScheme = new ColorScheme(
                        materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? Primary.Teal500 : Primary.Indigo500,
                        materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? Primary.Teal700 : Primary.Indigo700,
                        materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? Primary.Teal200 : Primary.Indigo100,
                        Accent.Pink200,
                        TextShade.WHITE);
                    _log.Debug("TOOL THEME COLOR: Changed to... {Blue Color}");
                    cAppend("TOOL THEME COLOR: Changed to {Blue Color}");
                    oConfigMng.Config.ToolThemeBlueColor = "true";
                    oConfigMng.Config.ToolThemeIndigoColor = "false";
                    oConfigMng.Config.ToolThemeGreenColor = "false";
                    oConfigMng.Config.ThemeMainColor = "false";
                    oConfigMng.SaveConfig();
                    break;
                case 1:
                    materialSkinManager.ColorScheme = new ColorScheme(
                        Primary.Green600,
                        Primary.Green700,
                        Primary.Green200,
                        Accent.Red100,
                        TextShade.WHITE);
                    _log.Debug("TOOL THEME COLOR: Changed to... {Green Color}");
                    cAppend("TOOL THEME COLOR: Changed to... {Green Color}");
                    oConfigMng.Config.ToolThemeBlueColor = "false";
                    oConfigMng.Config.ToolThemeIndigoColor = "false";
                    oConfigMng.Config.ToolThemeGreenColor = "true";
                    oConfigMng.Config.ThemeMainColor = "false";
                    oConfigMng.SaveConfig();
                    break;
                case 2:
                    materialSkinManager.ColorScheme = new ColorScheme(
                        Primary.BlueGrey800,
                        Primary.BlueGrey900,
                        Primary.BlueGrey500,
                        Accent.LightBlue200,
                        TextShade.WHITE);
                    _log.Debug("TOOL THEME COLOR: Changed to... {Indigo Color}");
                    cAppend("TOOL THEME COLOR: Changed to {Indigo Color}");
                    oConfigMng.Config.ToolThemeBlueColor = "false";
                    oConfigMng.Config.ToolThemeIndigoColor = "true";
                    oConfigMng.Config.ToolThemeGreenColor = "false";
                    oConfigMng.Config.ThemeMainColor = "false";
                    oConfigMng.SaveConfig();
                    break;
                case 3:
                    materialSkinManager.ColorScheme = new ColorScheme(
                        Primary.Indigo500, 
                        Primary.Indigo700, 
                        Primary.Indigo100, 
                        Accent.Pink200, 
                        TextShade.WHITE);
                    _log.Debug("TOOL THEME COLOR: Changed to... {Main Color}");
                    cAppend("TOOL THEME COLOR: Changed to {Main Color}");
                    oConfigMng.Config.ToolThemeBlueColor = "false";
                    oConfigMng.Config.ToolThemeIndigoColor = "false";
                    oConfigMng.Config.ToolThemeGreenColor = "false";
                    oConfigMng.Config.ThemeMainColor = "true";
                    oConfigMng.SaveConfig();
                    break;
            }
            Invalidate();
        }

        private void materialSwitchDrawerUseColors_CheckedChanged(object sender, EventArgs e)
        {
            DrawerUseColors = materialSwitchDrawerUseColors.Checked;
            oConfigMng.LoadConfig();
            if (DrawerUseColors = materialSwitchDrawerUseColors.Checked == true)
            {
                _log.Debug("TOOL SETTINGS: Drawer Use Colors changed to... {ENABLED}");
                cAppend("TOOL SETTINGS: Drawer Use Colors changed to... {ENABLED}");
                oConfigMng.Config.DrawerUseColors = "true";
            }
            else
            {
                _log.Debug("TOOL SETTINGS: Drawer Use Colors changed to... {DISABLED}");
                cAppend("TOOL SETTINGS: Drawer Use Colors changed to... {DISABLED}");
                oConfigMng.Config.DrawerUseColors = "false";
            }
            oConfigMng.SaveConfig();
            Invalidate();
        }

        private void MaterialSwitchDrawerHighlightWithAccent_CheckedChanged(object sender, EventArgs e)
        {
            DrawerHighlightWithAccent = materialSwitchDrawerHighlightWithAccent.Checked;
            oConfigMng.LoadConfig();
            if (DrawerHighlightWithAccent = materialSwitchDrawerHighlightWithAccent.Checked == true)
            {
                _log.Debug("TOOL SETTINGS: Drawer Highlight With Accent changed to... {ENABLED}");
                cAppend("TOOL SETTINGS: Drawer Highlight With Accent changed to... {ENABLED}");
                oConfigMng.Config.DrawerHighlightWithAccent = "true";
            }
            else
            {
                _log.Debug("TOOL SETTINGS: Drawer Highlight With Accent changed to... {DISABLED}");
                cAppend("TOOL SETTINGS: Drawer Highlight With Accent changed to... {DISABLED}");
                oConfigMng.Config.DrawerHighlightWithAccent = "false";
            }
            oConfigMng.SaveConfig();
            Invalidate();
        }

        private void MaterialSwitchDrawerBackgroundWithAccent_CheckedChanged(object sender, EventArgs e)
        {
            DrawerBackgroundWithAccent = materialSwitchDrawerBackgroundWithAccent.Checked;
            oConfigMng.LoadConfig();
            if (DrawerBackgroundWithAccent = materialSwitchDrawerBackgroundWithAccent.Checked == true)
            {
                _log.Debug("TOOL SETTINGS: Drawer Background With Accent changed to... {ENABLED}");
                cAppend("TOOL SETTINGS: Drawer Background With Accent changed to... {ENABLED}");
                oConfigMng.Config.DrawerBackgroundWithAccent = "true";
            }
            else
            {
                _log.Debug("TOOL SETTINGS: Drawer Background With Accent changed to... {DISABLED}");
                cAppend("TOOL SETTINGS: Drawer Background With Accent changed to... {DISABLED}");
                oConfigMng.Config.DrawerBackgroundWithAccent = "false";
            }
            oConfigMng.SaveConfig();
            Invalidate();
        }

        private void materialSwitchDrawerShowIconsWhenHidden_CheckedChanged(object sender, EventArgs e)
        {
            DrawerShowIconsWhenHidden = materialSwitchDrawerShowIconsWhenHidden.Checked;
            oConfigMng.LoadConfig();
            if (DrawerShowIconsWhenHidden = materialSwitchDrawerShowIconsWhenHidden.Checked == true)
            {
                _log.Debug("TOOL SETTINGS: Drawer Show Icons When Hidden changed to... {ENABLED}");
                cAppend("TOOL SETTINGS: Drawer Show Icons When Hidden changed to... {ENABLED}");
                oConfigMng.Config.DrawerShowIconsWhenHidden = "true";
            }
            else
            {
                _log.Debug("TOOL SETTINGS: Drawer Show Icons When Hidden changed to... {DISABLED}");
                cAppend("TOOL SETTINGS: Drawer Show Icons When Hidden changed to... {DISABLED}");
                oConfigMng.Config.DrawerShowIconsWhenHidden = "false";
            }
            oConfigMng.SaveConfig();
            Invalidate();
        }

        #endregion ToolTheme

        private void materialButtonUnlock_Click(object sender, EventArgs e)
        {
            var unlock = new UnlockBootloader();
            unlock.Show();
        }

        private async void materialButtonLock_ClickAsync(object sender, EventArgs e)
        {
            var result = MessageBox.Show(res_man.GetString("LabelLockBootloader", cul), res_man.GetString("LabelWarning", cul), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Dialogs.WarningDialog("Bootloader: " + res_man.GetString("LabelWarning", cul), res_man.GetString("LabelLockBootloaderWarning", cul));
                _log.Debug("LOCK BOOTLOADER: Waiting for device...");
                cAppend(res_man.GetString("LabelLockBootloaderWFD", cul));
                if (IDDeviceState.BOOTLOADER == state)
                {
                    _log.Info("LOCK BOOTLOADER: Locking bootloader... {1}");
                    cAppend(res_man.GetString("LabelLockBL1", cul) + " {1}");
                    Thread.Sleep(1000);
                    await Task.Run(() => Fastboot.Instance().Execute("oem lock"));
                    Thread.Sleep(500);
                    var result2 = MessageBox.Show(res_man.GetString("LabelLockBootloader2", cul), res_man.GetString("LabelWarning", cul), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result2 == DialogResult.Yes)
                    {
                        if (IDDeviceState.BOOTLOADER == state)
                        {
                            Thread.Sleep(1000);
                            _log.Info("LOCK BOOTLOADER: Locking bootloader... {2}");
                            cAppend(res_man.GetString("LabelLockBL1", cul) + " {2}");
                            Thread.Sleep(1000);
                            Fastboot.Instance().Execute("oem lock");
                            _log.Info("LOCK BOOTLOADER: Locking bootloader... {1 & 2}");
                            cAppend(res_man.GetString("LabelLockBL1", cul) + " {1 & 2 OK}");
                            Thread.Sleep(1000);
                            _log.Info("LOCK BOOTLOADER: Rebooting...");
                            cAppend(res_man.GetString("LabelLockBootloaderReboot", cul));
                            await Task.Run(() => ADB.Instance().Reboot(IDBoot.REBOOT));
                        }
                        else
                        {
                            Thread.Sleep(1000);
                            Strings.MSGBOXBootloaderWarning();
                            _log.Warn("LOCK BOOTLOADER: Your device is in the wrong state. Please put your device in the bootloader mode - " + state);
                            cAppend(res_man.GetString("LabelLockBLWrong", cul));
                        }
                    }
                }
                else
                {
                    Thread.Sleep(1000);
                    Strings.MSGBOXBootloaderWarning();
                    _log.Warn("LOCK BOOTLOADER: Your device is in the wrong state. Please put your device in the bootloader mode - " + state);
                    cAppend(res_man.GetString("LabelLockBLWrong", cul));
                }
            }
        }

        private async void materialButtonFlashTWRP_Click(object sender, EventArgs e)
        {
            oConfigMng.LoadConfig();
            string dc = oConfigMng.Config.DeviceCodenmae;
            if (dc.ToString().Contains("doha") == true ||
                dc.ToString().Contains("river") == true ||
                dc.ToString().Contains("ocean") == true ||
                dc.ToString().Contains("beckham") == true)
            {
                _log.Info("FLASH TWRP: Hey! This option is not for A/B devices!, but you can download TWRP installer and flash it! first you need to boot TWRP!");
                cAppend("FLASH TWRP: Hey! This option is not for A/B devices!, but you can download TWRP installer and flash it! first you need to boot TWRP!");
                Dialogs.TWRPPermanent("FLASH: TWRP", "Hey! This option is not for A/B devices!, but you can download TWRP installer and flash it! first you need to boot TWRP!");
                return;
            }

            if (dc.ToString().Contains("evert") == true ||
                dc.ToString().Contains("lake") == true ||
                dc.ToString().Contains("lima") == true ||
                dc.ToString().Contains("sofiar") == true ||
                dc.ToString().Contains("sofia") == true ||
                dc.ToString().Contains("kane_sprout") == true)
            {
                _log.Info("FLASH TWRP: Hey! This option is not for A/B devices!, check the Boot option!");
                cAppend("FLASH TWRP: Hey! This option is not for A/B devices!, check the Boot option!");
                Dialogs.InfoDialog("FLASH: TWRP", "Hey! This option is not for A/B devices!, check the Boot option!");
                return;
            }

            if (oConfigMng.Config.DeviceCodenmae == "")
            {
                _log.Warn("FLASH TWRP: Please connect your device, so MotoTool can check your device!");
                cAppend("FLASH TWRP: Please connect your device, so MotoTool can check your device!");
                Dialogs.WarningDialog("FLASH: TWRP", "Please connect your device, so MotoTool can check your device!");
                return;
            }

            _log.Debug("FLASH TWRP: Loading server for... {" + oConfigMng.Config.DeviceCodenmae + "}");
            cAppend("FLASH TWRP: Loading server for... {" + oConfigMng.Config.DeviceCodenmae + "}");
            LoadDeviceServer.CheckDevice(oConfigMng.Config.DeviceCodenmae + ".xml", oConfigMng.Config.DeviceCodenmae);
            string fileName = @"C:\MotoTool\TWRP\" + LoadDeviceServer.twrpname;

            if (!File.Exists(fileName))
            {
                _log.Debug("FLASH TWRP: Downloading TWRP for... {" + oConfigMng.Config.DeviceCodenmae + "}" + " TWRP: " + fileName);
                cAppend("FLASH TWRP: Downloading TWRP for... {" + oConfigMng.Config.DeviceCodenmae + "}" + " TWRP: " + fileName);
                downloadcall("/TWRP.xml", "TWRP");
                oConfigMng.Config.DeviceTWPRPermanentInfo = LoadDeviceServer.twrpname;
                oConfigMng.SaveConfig();
                return;
            }
            else
            {
                _log.Debug("Checking if file is corrupt...");
                long length = new FileInfo(fileName).Length;
                string vIn = oConfigMng.Config.DownloadFileSizeTWRPPermanent;
                long vOut = Convert.ToInt64(vIn);

                if (length != vOut)
                {
                    _log.Error("FLASH TWRP: TWRP it's corrupeted, downloading again for... {" + oConfigMng.Config.DeviceCodenmae + "}" + " TWRP: " + fileName);
                    Strings.MSGBOXFileCorrupted();
                    cAppend("FLASH TWRP: TWRP it's corrupeted, downloading again for... {" + oConfigMng.Config.DeviceCodenmae + "}" + " TWRP: " + fileName);
                    downloadcall("/TWRP.xml", "TWRP");
                    oConfigMng.Config.DeviceTWPRPermanentInfo = LoadDeviceServer.twrpname;
                    oConfigMng.SaveConfig();
                    return;
                }

                if (state == IDDeviceState.DEVICE)
                {
                    _log.Debug("FLASH TWRP: Rebooting into bootloader mode");
                    cAppend("FLASH TWRP: Rebooting into bootloader mode");
                    await Task.Run(() => ADB.Instance().Reboot(IDBoot.BOOTLOADER));
                }
                else
                {
                    Thread.Sleep(1000);
                    Strings.MSGBOXBootloaderWarning();
                    _log.Warn("FLASH TWRP: Your device is in the wrong state. Please put your device in bootloader mode - " + state);
                    cAppend("FLASH TWRP: " + res_man.GetString("DeviceInfoWrongStateBootloader", cul) + " " + state);
                }
                if (state == IDDeviceState.FASTBOOT || state == IDDeviceState.BOOTLOADER)
                {
                    _log.Info("FLASH TWRP: Flashing TWRP...");
                    cAppend("FLASH TWRP: Flashing TWRP...");
                    await Task.Run(() => Fastboot.Instance().Flash(IDDevicePartition.RECOVERY, LoadDeviceServer.twrpname));
                    _log.Info("FLASH TWRP: Done flashing TWRP");
                    cAppend("FLASH TWRP: Done flashing TWRP");
                }
                else
                {
                    Thread.Sleep(1000);
                    Strings.MSGBOXBootloaderWarning();
                    _log.Warn("FLASH TWRP: Your device is in the wrong state. Please put your device in bootloader mode - " + state);
                    cAppend("FLASH TWRP: " + res_man.GetString("DeviceInfoWrongStateBootloader", cul) + " - " + state);
                }
            }
        }

        private async void materialButtonBootTWRP_Click(object sender, EventArgs e)
        {
            oConfigMng.LoadConfig();
            string dc = oConfigMng.Config.DeviceCodenmae;
            if (dc.ToString().Contains("lima") == true ||
                dc.ToString().Contains("sofiar") == true ||
                dc.ToString().Contains("sofia") == true)
            {
                _log.Info("BOOT TWRP: Hey this device doesn't have twrp yet! :(");
                cAppend("BOOT TWRP: Hey this device doesn't have twrp yet! :(");
                Dialogs.InfoDialog("BOOT: TWRP", "Hey this device doesn't have twrp yet! :(");
                return;
            }

            if (oConfigMng.Config.DeviceCodenmae == "")
            {
                _log.Info("BOOT TWRP: Please connect your device, so MotoTool can check your device!");
                cAppend("BOOT TWRP: Please connect your device, so MotoTool can check your device!");
                Dialogs.WarningDialog("BOOT: TWRP", "Please connect your device, so MotoTool can check your device!");
                return;
            }

            _log.Debug("BOOT TWRP: Loading server for... {" + oConfigMng.Config.DeviceCodenmae + "}");
            cAppend("BOOT TWRP: Loading server for... {" + oConfigMng.Config.DeviceCodenmae + "}");
            LoadDeviceServer.CheckDevice(oConfigMng.Config.DeviceCodenmae + ".xml", oConfigMng.Config.DeviceCodenmae);
            string fileName = @"C:\MotoTool\TWRP\" + LoadDeviceServer.twrpname;

            if (!File.Exists(fileName))
            {
                _log.Info("BOOT TWRP: Downloading TWRP for... {" + oConfigMng.Config.DeviceCodenmae + "}" + " TWRP: " + fileName);
                cAppend("BOOT TWRP: Downloading TWRP for... {" + oConfigMng.Config.DeviceCodenmae + "}" + " TWRP: " + fileName);
                downloadcall("/TWRP.xml", "TWRP");
                oConfigMng.Config.DeviceTWPRInfo = LoadDeviceServer.twrpname;
                oConfigMng.SaveConfig();
                return;
            }
            else
            {
                _log.Debug("Checking if file is corrupt...");
                long length = new FileInfo(fileName).Length;
                string vIn = oConfigMng.Config.DownloadFileSizeTWRP;
                long vOut = Convert.ToInt64(vIn);

                if (length != vOut)
                {
                    _log.Error("BOOT TWRP: TWRP it's corrupeted, downloading again for... {" + oConfigMng.Config.DeviceCodenmae + "}" + " TWRP: " + fileName);
                    Strings.MSGBOXFileCorrupted();
                    cAppend("BOOT TWRP: TWRP it's corrupeted, downloading again for... {" + oConfigMng.Config.DeviceCodenmae + "}" + " TWRP: " + fileName);
                    downloadcall("/TWRP.xml", "TWRP");
                    oConfigMng.Config.DeviceTWPRInfo = LoadDeviceServer.twrpname;
                    oConfigMng.SaveConfig();
                    return;
                }
                if (state == IDDeviceState.DEVICE)
                {
                    _log.Info("BOOT TWRP: Rebooting into bootloader mode");
                    cAppend("BOOT TWRP: Rebooting into bootloader mode");
                    await Task.Run(() => ADB.Instance().Reboot(IDBoot.BOOTLOADER));
                }
                else
                {
                    Thread.Sleep(1000);
                    Strings.MSGBOXBootloaderWarning();
                    _log.Warn("BOOT TWRP: Your device is in the wrong state. Please put your device in bootloader mode - " + state);
                    cAppend("BOOT TWRP: " + res_man.GetString("DeviceInfoWrongStateBootloader", cul) + " - " + state);
                }
                if (state == IDDeviceState.FASTBOOT || state == IDDeviceState.BOOTLOADER)
                {
                    _log.Info("BOOT TWRP: Booting TWRP...");
                    cAppend("BOOT TWRP: Booting TWRP...");
                    await Task.Run(() => Fastboot.Instance().Boot(LoadDeviceServer.twrpname));
                    _log.Info("BOOT TWRP: Done! TWRP was booted");
                    cAppend("BOOT TWRP: Done! TWRP was booted");
                }
                else
                {
                    Thread.Sleep(1000);
                    _log.Warn("BOOT TWRP: Your device is in the wrong state. Please put your device in bootloader mode - " + state);
                    Strings.MSGBOXBootloaderWarning();
                    cAppend("BOOT TWRP: " + res_man.GetString("DeviceInfoWrongStateBootloader", cul) + " " + state);
                }
            }
        }

        private async void materialButtonRebootBootloader_Click(object sender, EventArgs e)
        {
            if (IDDeviceState.DEVICE == state)
            {
                _log.Info("REBOOT BOOTLOADER: Rebooting into bootloader mode");
                cAppend("REBOOT BOOTLOADER: Rebooting into bootloader mode");
                await Task.Run(() => ADB.Instance().Reboot(IDBoot.BOOTLOADER));
            }
            else
            {
                Thread.Sleep(1000);
                Strings.MSGBOXBootloaderWarning();
                _log.Warn("REBOOT BOOTLOADER: Your device is in the wrong state. Please connect your device - " + state);
                cAppend("REBOOT BOOTLOADER: " + res_man.GetString("DeviceInfoWrongState", cul) + " - " + state);
            }
        }

        private async void materialButtonRebootRecovery_Click(object sender, EventArgs e)
        {
            if (IDDeviceState.DEVICE == state)
            {
                _log.Info("REBOOT RECOVERY: Rebooting into recovery mode");
                cAppend("REBOOT RECOVERY: Rebooting into recovery mode");
                await Task.Run(() => ADB.Instance().Reboot(IDBoot.RECOVERY));
            }
            else
            {
                Thread.Sleep(1000);
                Strings.MSGBOXBootloaderWarning();
                _log.Warn("REBOOT RECOVERY: Your device is in the wrong state. Please connect your device - " + state);
                cAppend("REBOOT RECOVERY: " + res_man.GetString("DeviceInfoWrongState", cul) + " - " + state);
            }
        }

        private async void materialButtonBlankFlash_Click(object sender, EventArgs e)
        {
            oConfigMng.LoadConfig();
            string dc = oConfigMng.Config.DeviceCodenmae;
            if (dc.ToString().Contains("lima") == true ||
                dc.ToString().Contains("sofiar") == true ||
                dc.ToString().Contains("sofia") == true ||
                dc.ToString().Contains("potter") == true ||
                dc.ToString().Contains("sanders") == true ||
                dc.ToString().Contains("kane_sprout") == true ||
                dc.ToString().Contains("hannah") == true ||
                dc.ToString().Contains("ahannah") == true)
            {
                _log.Info("BLANKFLASH: " + oConfigMng.Config.DeviceCodenmae + " Hey this device doesn't have blankflash yet! :(. If you know about an existing blankflash you can contact me and i'll add it!");
                cAppend("BLANKFLASH: " + oConfigMng.Config.DeviceCodenmae + " Hey this device doesn't have blankflash yet! :(. If you know about an existing blankflash you can contact me and i'll add it!");
                Dialogs.InfoDialog("BLANKFLASH: " + oConfigMng.Config.DeviceCodenmae, "Hey this device doesn't have blankflash yet! :(. If you know about an existing blankflash you can contact me and i'll add it!");
                return;
            }

            if (oConfigMng.Config.DeviceCodenmae == "")
            {
                _log.Info("BLANKFLASH: " + oConfigMng.Config.DeviceCodenmae + "Please connect your device, so MotoTool can check your device!");
                cAppend("BLANKFLASH: " + oConfigMng.Config.DeviceCodenmae + "Please connect your device, so MotoTool can check your device!");
                Dialogs.WarningDialog("BLANKFLASH: " + oConfigMng.Config.DeviceCodenmae, "Please connect your device, so MotoTool can check your device!");
                return;
            }

            _log.Debug("BLANKFLASH: Loading device server for... {" + oConfigMng.Config.DeviceCodenmae + "}");
            cAppend("BLANKFLASH: Loading device server for... {" + oConfigMng.Config.DeviceCodenmae + "}");
            LoadDeviceServer.CheckDevice(oConfigMng.Config.DeviceCodenmae + ".xml", oConfigMng.Config.DeviceCodenmae);
            string blankflashfilepath = @"C:\MotoTool\Others\" + LoadDeviceServer.unbrickname;
            if (!File.Exists(blankflashfilepath) &&
                !Directory.Exists(@"C:\MotoTool\Others\" + oConfigMng.Config.DeviceBlankFlash))
            {
                cAppend("BLANKFLASH: Downloading BLANKFLASH for... {" + oConfigMng.Config.DeviceCodenmae + "}" + " BLANKFLASH: " + oConfigMng.Config.DeviceBlankFlash);
                downloadcall("/BLANKFLASH.xml", "BLANKFLASH");
                oConfigMng.Config.DeviceBlankFlash = LoadDeviceServer.unbrickname;
                oConfigMng.SaveConfig();
                return;
            }
            else
            {
                long length = new FileInfo(blankflashfilepath).Length;
                string vIn = oConfigMng.Config.DownloadFileSizeBlankFlash;
                long vOut = Convert.ToInt64(vIn);

                if (length != vOut)
                {
                    Strings.MSGBOXFileCorrupted();
                    cAppend("Blankflash: Blankflash it's corrupeted, downloading again for... {" + oConfigMng.Config.DeviceCodenmae + "}" + " Blankflash: " + blankflashfilepath);
                    downloadcall("/BLANKFLASH.xml", "BLANKFLASH");
                    oConfigMng.Config.DeviceBlankFlash = LoadDeviceServer.unbrickname;
                    oConfigMng.SaveConfig();
                    return;
                }
                Thread.Sleep(1000);
                cAppend("Blankflash info: " + oConfigMng.Config.DeviceBlankFlash);
                cAppend("Botting into Bootloader mode...");
                Directory.SetCurrentDirectory(@"C:\MotoTool\Others\" + oConfigMng.Config.DeviceBlankFlash);
                await Task.Run(() => qBootExecuteCommand());
                cAppend("Botting into Bootloader mode... OK");
                Thread.Sleep(1000);
                Dialogs.InfoDialog("BlankFlash", "Please, check if your device has booted up into Bootloader mode!");
            }
        }

        private async void materialButtonFlashLogo_Click(object sender, EventArgs e)
        {
            string logopath = @"C:\MotoTool\" + oConfigMng.Config.DeviceFirmware + oConfigMng.Config.DeviceFirmwareInfo;
            if (oConfigMng.Config.DeviceCodenmae == "")
            {
                cAppend("FLASH LOGO: Please connect your device, so MotoTool can check your device!");
                Dialogs.WarningDialog("FLASH: LOGO", "Please connect your device, so MotoTool can check your device!");
                return;
            }
            if (!File.Exists(logopath))
            {
                cAppend("FLASH LOGO: Can't find logo image... " + "\nDevice: " + oConfigMng.Config.DeviceCodenmae + "\nFirmware: " + oConfigMng.Config.DeviceFirmware);
                Dialogs.ErrorDialog("LOGO: Missing", "Can't find logo image... " + "\nDevice: " + oConfigMng.Config.DeviceCodenmae + "\nFirmware: " + oConfigMng.Config.DeviceFirmware);
            }
            else
            {
                if (state == IDDeviceState.DEVICE || state == IDDeviceState.FASTBOOT || state == IDDeviceState.BOOTLOADER)
                {
                    cAppend("FLASH LOGO: Rebooting into bootloader mode.");
                    await Task.Run(() => ADB.Instance().Reboot(IDBoot.BOOTLOADER));
                    cAppend("FLASH LOGO: Flashing LOGO...");
                    await Task.Run(() => Fastboot.Instance().Execute("flash logo" + logopath + "logo.bin"));
                    cAppend("FLASH LOGO: Done flashing LOGO.\n");
                }
                else
                {
                    Thread.Sleep(1000);
                    Strings.MSGBOXBootloaderWarning();
                    cAppend("FLASH LOGO: " + res_man.GetString("DeviceInfoWrongStateBootloader", cul) + " " + state);
                }
            }
        }

        private void HowToBackupEfsAndPersist(object sender, EventArgs e)
        {
            var bk = new TWRPBackup();
            bk.ShowDialog();
        }

        private void materialButtonCheckUpdates_Click(object sender, EventArgs e)
        {
            AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;
        }

        private void materialButtonCMD_Click(object sender, EventArgs e)
        {
            cAppend("CMD: Started!");
            Directory.SetCurrentDirectory(@"C:\\MotoTool\\");
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.FileName = "cmd.exe";
            process.StartInfo = startInfo;
            process.Start();
        }

        private void materialButtonUninstall_Click(object sender, EventArgs e)
        {
            var unins = new Uninstall();
            unins.ShowDialog();
        }

        private void materialButtonChangeLang_Click(object sender, EventArgs e)
        {
            new Thread(() => new LangSelect().ShowDialog()).Start();
            Application.ExitThread();
            this.Dispose();
        }

        private void materialButtonHelp_Click(object sender, EventArgs e)
        {
            var help = new Help();
            help.ShowDialog();
        }

        private void materialButtonOpenFirmwareFolder_Click(object sender, EventArgs e)
        {
            if (oConfigMng.Config.DeviceFirmware == "---")
            {
                return;
            }
            if (oConfigMng.Config.DeviceFirmware == oConfigMng.Config.DeviceFirmware)
            {
                MotoFirmware.OpenFirmwareFolder(oConfigMng.Config.DeviceFirmware);
            }
        }

        private void materialButtonFirmwareCard_Click(object sender, EventArgs e)
        {
            openChildFormFirmware(new Firmwares());
        }

        private void materialButtonFlashTool_Click(object sender, EventArgs e)
        {
            openChildFormFlashTool(new MotoFlashVisual());
        }

        private void materialButtonOpenADBFolder_Click(object sender, EventArgs e)
        {
            try
            {
                Folders.OpenFolder(@"");
            }
            catch (Exception er)
            {
                _log.Error("ERROR: Open Folder " + "Error: " + er);
                Logs.DebugErrorLogs(er);
                Dialogs.ErrorDialog("ERROR: Open Folder", "Error: " + er);
            }
        }

        private void materialButtonclearallfolders_Click(object sender, EventArgs e)
        {
            var clear = new ClearAllFolders();
            clear.ShowDialog();
        }

        private void materialButtonAddNewDevice_Click(object sender, EventArgs e)
        {
            _log.Info("ADD NEW DEVICE: Clearing old device info...");
            cAppend("ADD NEW DEVICE: Clearing old device info...");
            oConfigMng.LoadConfig();
            oConfigMng.Config.DeviceCodenmae = "";
            oConfigMng.Config.DeviceFirmware = "";
            cAppend("ADD NEW DEVICE: Clearing old device info... {OK}");
            _log.Info("ADD NEW DEVICE: Clearing old device info... {OK}");
            oConfigMng.SaveConfig();
            GetProp();
        }

        private void materialButtonAddNewDeviceManual_Click(object sender, EventArgs e)
        {
            var andm = new AddNewDevice();
            andm.ShowDialog();
        }

        private void materialButtonRemoveToolDeviceData_Click(object sender, EventArgs e)
        {
            cAppend("REMOVE DEVICE DATA: Clearing old device info...");
            oConfigMng.LoadConfig();
            oConfigMng.Config.DeviceCodenmae = "";
            oConfigMng.Config.DeviceFirmwareInfo = "";
            oConfigMng.Config.DeviceTWPRInfo = "";
            oConfigMng.Config.DeviceBlankFlash = "";
            oConfigMng.Config.FirmwareExtracted = "";
            oConfigMng.Config.DeviceFirmware = "";
            oConfigMng.SaveConfig();
            cAppend("REMOVE DEVICE DATA: Clearing old device info... {OK}");
            Dialogs.InfoDialog("MotoTool: Device data", "All device data removed!");
        }

        private void materialButtonRANDFOAND_Click(object sender, EventArgs e)
        {
            if (InternetCheck.ConnectToInternet() == true)
            {
                var send = new SendEmail();
                send.Show();
            }
            else
            {
                Strings.MSGBOXServerNetworkLost();
                return;
            }
        }

        private void materialButtonContact_Click(object sender, EventArgs e)
        {
            if (InternetCheck.ConnectToInternet() == true)
            {
                var con = new Contact();
                con.Show();
            }
            else
            {
                Strings.MSGBOXServerNetworkLost();
                return;
            }
        }

        private void materialButtonReport_Click(object sender, EventArgs e)
        {
            if (InternetCheck.ConnectToInternet() == true)
            {
                var rep = new Report();
                rep.Show();
            }
            else
            {
                Strings.MSGBOXServerNetworkLost();
                return;
            }
        }

        private void materialButtonControlYDScreen_Click(object sender, EventArgs e)
        {
            try
            {
                Dialogs.InfoDialog("Android Gestures", "Hey! this is a experimental Tool! so don't expect much!");
                var stc = new MainTouch();
                stc.Show();
            }
            catch (Exception er)
            {
                Logs.DebugErrorLogs(er);
                Dialogs.ErrorDialog("Android Touch Controller", "Can´t start android touch controller");
            }
        }

        private void exit(object sender, FormClosedEventArgs e)
        {
            KillWhenExit();
        }

        public void KillWhenExit()
        {
            _log.Debug(res_man.GetString("EXITStopADB", cul));
            cAppend(res_man.GetString("EXITStopADB", cul));
            oConfigMng.SaveConfig();
            timer.Stop();
            ADB.Stop();
            ADB.Stop(true);
            Fastboot.ForceStop();
            Fastboot.Dispose();
            _log.Debug(res_man.GetString("EXITStopADB", cul) + " {OK}");
            cAppend(res_man.GetString("EXITStopADB", cul) + " {OK}");
            var MotoToolProcesses = Process.GetProcesses().Where(pr => pr.ProcessName == "MotoTool");
            foreach (var process in MotoToolProcesses)
            {
                process.Kill();
            }
            Application.Exit();
        }      
    }
}