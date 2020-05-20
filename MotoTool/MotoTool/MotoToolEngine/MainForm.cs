
using AutoUpdaterDotNET;
using MaterialSkin;
using MaterialSkin.Controls;
using AndroidCtrl.ADB;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
using AndroidCtrl;
using AndroidCtrl.Fastboot;
using System.Collections.Generic;
using AndroidCtrl.Tools;
using System.Threading.Tasks;

namespace Franco28Tool.Engine
{
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
        IDDeviceState state = General.CheckDeviceState(ADB.Instance().DeviceID);

        public MainForm()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            InitializeComponent();
            oConfigMng.LoadConfig();
            oConfigMng.Config.ToolVersion = ToolVer;
            this.Text = "MotoTool v" + oConfigMng.Config.ToolVersion;
            cAppend("STARTING: Checking MotoTool updates.");
            cehck4updates();
            cAppend("STARTING: Loading tool... Please wait...");
            ADB.PATH_DIRECTORY = @"C:\adb\";
            Fastboot.PATH_DIRECTORY = @"C:\adb\";
            cAppend("STARTING: Settings adb & fastboot path... Please wait...");
            cAppend("STARTING: Checking MotoDrivers...");
            if (File.Exists(@"C:\Program Files (x86)\Motorola Mobility\Motorola Device Manager\uninstall.exe"))
            {
                if (File.Exists(@"C:\Program Files\MotoTool\MotorolaDeviceManager_2.5.4.exe"))
                {
                    string _batDir = string.Format(@"C:\Program Files\MotoTool\");
                    using (Process proc = new Process())
                    {
                        proc.StartInfo.WorkingDirectory = _batDir;
                        proc.StartInfo.FileName = "remove.bat";
                        proc.StartInfo.CreateNoWindow = false;
                        proc.Start();
                        proc.WaitForExit();
                        int ExitCode = proc.ExitCode;
                    }
                }
                cAppend("STARTING: Checking MotoDrivers... OK");
            }
            else
            {
                cAppend("STARTING: Checking MotoDrivers... ERROR");
                CheckMotoDrivers.MotoDrivers();
            }
            updateColorLoad();
            InitializeRAMCounter();
            InitialiseCPUCounter();
            updateTimer_Tick();
        }

        public void CheckandDeploy()
        {
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
        }

        public void cAppend(string message)
        {
            this.Invoke((Action)delegate
            {
                console.AppendText(string.Format("\n{0} : {1}", DateTime.Now, message));
                console.ScrollToCaret();
            });
        }

        private async void MainForm_LoadAsync(object sender, EventArgs e)
        {
            oConfigMng.LoadConfig();
            cAppend("STARTING: Deploying adb & fastboot...");
            await Task.Run(() => CheckandDeploy());
            await Task.Run(() => DeviceDetectionService());
            cAppend("STARTING: Deploying adb & fastboot... {OK}");
            oConfigMng.Config.ToolCompiled = Utils.GetLinkerDateTime(Assembly.GetEntryAssembly(), null).ToString();
            cAppend("STARTING: Checking MotoTool ver: " + ToolVer);
            if (oConfigMng.Config.ToolTheme == null || oConfigMng.Config.ToolTheme == "")
            {
                cAppend("STARTING: Setting first MotoTool Theme... {LIGHT}");
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE);
                oConfigMng.Config.ToolTheme = "light";
            }
            cAppend("STARTING: Checking saved device...");
            if (oConfigMng.Config.DeviceCodenmae == null || oConfigMng.Config.DeviceCodenmae == "")
            {
                cAppend("STARTING: Checking saved device... {NOT FOUND}");
                oConfigMng.Config.DeviceCodenmae = "";
            }
            else
            {
                cAppend("STARTING: Checking saved device... {" + oConfigMng.Config.DeviceCodenmae + "}");
            }
            cAppend("STARTING: Checking saved device carrier...");
            if (oConfigMng.Config.DeviceFirmware == null || oConfigMng.Config.DeviceFirmware == "")
            {
                cAppend("STARTING: Checking saved device carrier... {NOT FOUND}");
                oConfigMng.Config.DeviceFirmware = "";
            }
            else
            {
                cAppend("STARTING: Checking saved device carrier... {" + oConfigMng.Config.DeviceFirmware + "}");
            }
            cAppend("STARTING: Checking internet connection...");
            if (InternetCheck.ConnectToInternet() == true)
            {
                cAppend("STARTING: Checking internet connection... {OK}");
                oConfigMng.Config.ToolInternet = "online";
            }
            else
            {
                cAppend("STARTING: Checking internet connection... {ERROR}");
                oConfigMng.Config.ToolInternet = "offline";
            }
            cAppend("STARTING: Applying MotoTool settings...");
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
            if (oConfigMng.Config.Autosavelogs == null || oConfigMng.Config.Autosavelogs == "")
            {
                oConfigMng.Config.Autosavelogs = "true";
            }
            if (oConfigMng.Config.Autosavelogs == "true")
            {
                AutoSaveLogs = materialSwitchAutoSaveLogs.Checked;
                AutoSaveLogs = materialSwitchAutoSaveLogs.Checked = true;
            }
            else if (oConfigMng.Config.Autosavelogs == "false")
            {
                AutoSaveLogs = materialSwitchAutoSaveLogs.Checked = false;
            }
            cAppend("STARTING: Applying MotoTool settings... {OK}");
            oConfigMng.SaveConfig();
            cAppend("----------------------------------");
            cAppend("MotoTool was loaded!");
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
            Timer timer = new Timer();
            timer.Interval = (1 * 1000);
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

        private void timer_Tick(object sender, EventArgs e)
        {
            oConfigMng.LoadConfig();
            labelFreeRam.Text = "      Free RAM: " + Convert.ToInt64(ramCounter.NextValue()).ToString() + " MB";
            labelCPUusage.Text = "      CPU: " + Convert.ToInt64(cpuCounter.NextValue()).ToString() + "%";
            labelFreeSpace.Text = @"      Folder Size: C:\adb: " + Folders.GetDirectorySize(@"C:\adb") + " MB";
            labelUserName.Text = "      User: " + Environment.UserName;
            TextBoxDebug.Text = "Remember to always Backup your efs and persist folders! How? Click me!";
            if (oConfigMng.Config.DeviceCodenmae == "" || oConfigMng.Config.DeviceFirmware == "")
            {
                TextBoxDebugInfo.Text = "Device Channel: ---";
                materialButtonBlankFlash.Enabled = false;
                materialButtonFlashLogo.Enabled = false;
                materialButtonFlashTWRP.Enabled = false;
                materialButtonBootTWRP.Enabled = false;
            }
            else
            {
                this.Text = "MotoTool v" + oConfigMng.Config.ToolVersion + " - " + oConfigMng.Config.DeviceCodenmae;
                TextBoxDebugInfo.Text = "Device Channel: " + oConfigMng.Config.DeviceFirmware;
                materialButtonBlankFlash.Enabled = true;
                materialButtonFlashLogo.Enabled = true;
                materialButtonFlashTWRP.Enabled = true;
                materialButtonBootTWRP.Enabled = true;
                if (oConfigMng.Config.DeviceCodenmae == oConfigMng.Config.DeviceCodenmae)
                {
                    LoadDeviceServer.CheckDevice(oConfigMng.Config.DeviceCodenmae + ".xml", oConfigMng.Config.DeviceCodenmae);
                }
                Firmwares.CreateFirmwareFolder();
            }
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

        public async void canceltoolload()
        {
            cAppend("MotoTool: DEVICE NOT COMPATIBLE: " + oConfigMng.Config.DeviceCodenmae + "Device " + oConfigMng.Config.DeviceCodenmae + " is not compatible. This MotoTool works with: " + " \nBeckham, Doha, Lake, Evert, Potter, Sanders, River, Ocean, Lima, Sofiar, Sofia");
            await Task.Run(() => Dialogs.WarningDialog("MotoTool: DEVICE NOT COMPATIBLE: " + oConfigMng.Config.DeviceCodenmae, "Device " + oConfigMng.Config.DeviceCodenmae + " is not compatible. This MotoTool works with: " + " \nBeckham, Doha, Lake, Evert, Potter, Sanders, River, Ocean, Lima, Sofiar, Sofia"));
            KillWhenExit();
        }

        public void DeviceCompatible()
        {
            oConfigMng.LoadConfig();
            if (oConfigMng.Config.DeviceCodenmae == "")
            {
                TextBoxDebug.Text = "Please connect your device, so MotoTool can check your device!";
            }
            if (oConfigMng.Config.DeviceCodenmae != "beckham" ||
                oConfigMng.Config.DeviceCodenmae != "doha" ||
                oConfigMng.Config.DeviceCodenmae != "evert" ||
                oConfigMng.Config.DeviceCodenmae != "lake" ||
                oConfigMng.Config.DeviceCodenmae != "lima" ||
                oConfigMng.Config.DeviceCodenmae != "river" ||
                oConfigMng.Config.DeviceCodenmae != "potter" ||
                oConfigMng.Config.DeviceCodenmae != "ocean" ||
                oConfigMng.Config.DeviceCodenmae != "sanders" ||
                oConfigMng.Config.DeviceCodenmae != "sofiar" ||
                oConfigMng.Config.DeviceCodenmae == "sofia" ||
                oConfigMng.Config.DeviceCodenmae == "ginkgo")
            {
                canceltoolload();
            }
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
                    GetProp();
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
                    GetProp();
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

        public async void GetProp()
        {
            oConfigMng.LoadConfig();
            if (oConfigMng.Config.DeviceFirmware == "" || oConfigMng.Config.DeviceCodenmae == "")
            {
                cAppend("Device Info: Getting device codename and carrier...");
                if (IDDeviceState.UNKNOWN == state)
                {
                    cAppend("Device Info: Waiting for device...");
                    await Task.Run(() => ADB.WaitForDevice());
                    cAppend("Device Info: Getting device codename and carrier...");
                    List<String> getdevicecodename = await Task.Run(() => ADB.Instance().Execute("shell /system/bin/getprop ro.product.device"));
                    List<String> getcarrier = await Task.Run(() => ADB.Instance().Execute("shell /system/bin/getprop ro.carrier"));
                    getdevicecodename.ToString();
                    getcarrier.ToString();
                    var result = String.Join("", getdevicecodename.ToArray());
                    var result2 = String.Join("", getcarrier.ToArray());
                    oConfigMng.Config.DeviceCodenmae = result;
                    oConfigMng.Config.DeviceFirmware = result2;
                }
                else
                {
                    cAppend("Device Info: Your device is in the wrong state. Please connect your device.\n");
                }
                oConfigMng.SaveConfig();
                DeviceCompatible();
            }
            else
            {
                cAppend("Device Info: Device already added. \n Device: " + oConfigMng.Config.DeviceCodenmae + "\n Device carrier: " + oConfigMng.Config.DeviceFirmware);
            }
        }

        private void AutoUpdater_ApplicationExitEvent()
        {
            Text = @"Closing application...";
            Thread.Sleep(2000);
            Application.Exit();
        }

        private void cehck4updates()
        {
            System.Timers.Timer timer = new System.Timers.Timer
            {
                Interval = 1 * 30 * 100,
                SynchronizingObject = this
            };
            timer.Elapsed += delegate
            {
                AutoUpdater.Start("https://mototoolengine.000webhostapp.com/MotoTool/Update.xml");
            };
            timer.Start();
        }

        private void AutoUpdaterOnCheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            AutoUpdater.ApplicationExitEvent += AutoUpdater_ApplicationExitEvent;
            AutoUpdater.DownloadPath = Environment.CurrentDirectory;
            if (args != null)
            {
                if (args.IsUpdateAvailable)
                {
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
                        Dialogs.ErrorDialog(exception.Message, exception.GetType().ToString());
                        Application.Restart();
                    }
                }
                else
                {
                    Dialogs.InfoDialog("No update available", "There is no update available please try again later, or Tool will let you know!");
                    Application.Restart();
                }
            }
            else
            {
                Dialogs.ErrorDialog("Update check failed", "There is a problem reaching update server please check your internet connection and try again later.");
                Application.Restart();
            }
        }

        public void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChild.Controls.Add(childForm);
            panelChild.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public void openChildFormFirmware(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
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
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelFlashTool.Controls.Add(childForm);
            panelFlashTool.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public void downloadcall(string xmlname, string xmlpath)
        {
            var call = new DownloadUI();
            DownloadsMng.TOOLDOWNLOAD(oConfigMng.Config.DeviceCodenmae, xmlname, xmlpath);
            openChildFormWarningNoti(call);
        }

        public void qBootExecuteCommand()
        {
            cAppend("BLANKFLASH CMD: Executing BLANKFLASH FILES...");
            string _batDir = string.Format(@"C:\adb\Others\" + LoadDeviceServer.unbrickname);
            using (Process proc = new Process())
            {
                proc.StartInfo.WorkingDirectory = _batDir;
                proc.StartInfo.FileName = "blank-flash.bat";
                proc.StartInfo.CreateNoWindow = false;
                proc.Start();
                proc.WaitForExit();
                int ExitCode = proc.ExitCode;
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
                cAppend("TOOL THEME: Changed to {DARK}");
                oConfigMng.Config.ToolTheme = "dark";
            }

            if (materialSkinManager.Theme == MaterialSkinManager.Themes.LIGHT)
            {
                cAppend("TOOL THEME: Changed to {LIGHT}");
                oConfigMng.Config.ToolTheme = "light";
            }
            oConfigMng.SaveConfig();
            updateColor();
        }

        private int colorSchemeIndex;

        public bool AutoSaveLogs { get; private set; }

        public void updateColorLoad()
        {
            oConfigMng.LoadConfig();

            if (oConfigMng.Config.ToolTheme == "light")
            {
                cAppend("STARTING: Loading MotoTool Theme... {LIGHT}");
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            if (oConfigMng.Config.ToolTheme == "dark")
            {
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
            if (colorSchemeIndex > 2)
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
                    cAppend("TOOL THEME COLOR: Changed to {Blue Color}");
                    oConfigMng.Config.ToolThemeBlueColor = "true";
                    oConfigMng.Config.ToolThemeIndigoColor = "false";
                    oConfigMng.Config.ToolThemeGreenColor = "false";
                    oConfigMng.SaveConfig();
                    break;
                case 1:
                    materialSkinManager.ColorScheme = new ColorScheme(
                        Primary.Green600,
                        Primary.Green700,
                        Primary.Green200,
                        Accent.Red100,
                        TextShade.WHITE);
                    cAppend("TOOL THEME COLOR: Changed to {Green Color}");
                    oConfigMng.Config.ToolThemeBlueColor = "false";
                    oConfigMng.Config.ToolThemeIndigoColor = "false";
                    oConfigMng.Config.ToolThemeGreenColor = "true";
                    oConfigMng.SaveConfig();
                    break;
                case 2:
                    materialSkinManager.ColorScheme = new ColorScheme(
                        Primary.BlueGrey800,
                        Primary.BlueGrey900,
                        Primary.BlueGrey500,
                        Accent.LightBlue200,
                        TextShade.WHITE);
                    cAppend("TOOL THEME COLOR: Changed to {Indigo Color}");
                    oConfigMng.Config.ToolThemeBlueColor = "false";
                    oConfigMng.Config.ToolThemeIndigoColor = "true";
                    oConfigMng.Config.ToolThemeGreenColor = "false";
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
                cAppend("TOOL SETTINGS: Drawer Use Colors changed to {ENABLED}");
                oConfigMng.Config.DrawerUseColors = "true";
            }
            else
            {
                cAppend("TOOL SETTINGS: Drawer Use Colors changed to {DISABLED}");
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
                cAppend("TOOL SETTINGS: Drawer Highlight With Accent changed to {ENABLED}");
                oConfigMng.Config.DrawerHighlightWithAccent = "true";
            }
            else
            {
                cAppend("TOOL SETTINGS: Drawer Highlight With Accent changed to {DISABLED}");
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
                cAppend("TOOL SETTINGS: Drawer Background With Accent changed to {ENABLED}");
                oConfigMng.Config.DrawerBackgroundWithAccent = "true";
            }
            else
            {
                cAppend("TOOL SETTINGS: Drawer Background With Accent changed to {DISABLED}");
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
                cAppend("TOOL SETTINGS: Drawer Show Icons When Hidden changed to {ENABLED}");
                oConfigMng.Config.DrawerShowIconsWhenHidden = "true";
            }
            else
            {
                cAppend("TOOL SETTINGS: Drawer Show Icons When Hidden changed to {DISABLED}");
                oConfigMng.Config.DrawerShowIconsWhenHidden = "false";
            }
            oConfigMng.SaveConfig();
            Invalidate();
        }

        #endregion ToolTheme

        private void materialButtonUnlock_Click(object sender, EventArgs e)
        {
            Dialogs.WarningDialog("Bootloader: README PLEASE!", "To Unlock Moto Bootloader: Sign in on the following page. Follow the guide on the page. The Tool will open a CMD Console where drivers are allocated. Here you must enter the commands lines!");

            if (File.Exists(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe") & File.Exists(@"C:\Program Files\Google\Chrome\Application\chrome.exe") == true)
            {
                BrowserCheck.StartBrowser("MicrosoftEdge.exe", "https://motorola-global-portal.custhelp.com/app/standalone/bootloader/unlock-your-device-b");
            }
            else
            {
                BrowserCheck.StartBrowser("Chrome.exe", "https://motorola-global-portal.custhelp.com/app/standalone/bootloader/unlock-your-device-b");
            }
            Directory.SetCurrentDirectory(@"C:\\adb\\");
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.FileName = "cmd.exe";
            process.StartInfo = startInfo;
            process.Start();
            cAppend("CMD UNLOCK: Started CMD!");
        }

        private async void materialButtonLock_ClickAsync(object sender, EventArgs e)
        {
            var result = MessageBox.Show("1°: Do you want to Lock the bootloader? This will erase all your data!", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Dialogs.WarningDialog("Bootloader: Warning!", "Try to not UNPLUG THE DEVICE during the process!");
                cAppend("UNLOCK BOOTLOADER: Waiting for device...");
                if (IDDeviceState.BOOTLOADER == state)
                {
                    cAppend("UNLOCK BOOTLOADER: Locking bootloader... {1}");
                    Thread.Sleep(1000);
                    await Task.Run(() => Fastboot.Instance().Execute("oem lock"));
                    Thread.Sleep(500);
                    var result2 = MessageBox.Show("2°: Are you sure that you want to Lock the bootloader? This will erase all your data!", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result2 == DialogResult.Yes)
                    {
                        if (IDDeviceState.BOOTLOADER == state)
                        {
                            Thread.Sleep(1000);
                            cAppend("UNLOCK BOOTLOADER: Locking bootloader... {2}");
                            Thread.Sleep(1000);
                            Fastboot.Instance().Execute("oem lock");
                            cAppend("UNLOCK BOOTLOADER: Locking bootloader... {1 & 2 OK}");
                            Thread.Sleep(1000);
                            cAppend("UNLOCK BOOTLOADER: Rebooting...");
                            await Task.Run(() => Fastboot.Instance().Reboot(IDBoot.REBOOT));
                        }
                        else
                        {
                            Thread.Sleep(1000);
                            Strings.MSGBOXBootloaderWarning();
                            cAppend("UNLOCK BOOTLOADER: Your device is in the wrong state. Please put your device in the bootloader mode.\n");
                        }
                    }
                    else
                    {
                        Dialogs.WarningDialog("Bootloader", "Lock Bootloader canceled...");
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    Thread.Sleep(1000);
                    Strings.MSGBOXBootloaderWarning();
                    cAppend("UNLOCK BOOTLOADER: Your device is in the wrong state. Please put your device in the bootloader mode.\n");
                }
            }
        }

        private async void materialButtonFlashTWRP_Click(object sender, EventArgs e)
        {
            string fileName = @"C:\adb\TWRP\" + LoadDeviceServer.twrpname;
            if (oConfigMng.Config.DeviceCodenmae == "doha" ||
                oConfigMng.Config.DeviceCodenmae == "river" ||
                oConfigMng.Config.DeviceCodenmae == "beckham" ||
                oConfigMng.Config.DeviceCodenmae == "ocean")
            {
                cAppend("FLASH TWRP: Hey! This option is not for A/B devices!, but you can download TWRP installer and flash it! first you need to boot TWRP!");
                Dialogs.TWRPPermanent("FLASH: TWRP", "Hey! This option is not for A/B devices!, but you can download TWRP installer and flash it! first you need to boot TWRP!");
                return;
            }
            if (oConfigMng.Config.DeviceCodenmae == "evert" ||
                oConfigMng.Config.DeviceCodenmae == "lake" ||
                oConfigMng.Config.DeviceCodenmae == "lima" ||
                oConfigMng.Config.DeviceCodenmae == "sofiar" ||
                oConfigMng.Config.DeviceCodenmae == "sofia")
            {
                cAppend("FLASH TWRP: Hey! This option is not for A/B devices!, check the Boot option!");
                Dialogs.InfoDialog("FLASH: TWRP", "Hey! This option is not for A/B devices!, check the Boot option!");
                return;
            }
            if (oConfigMng.Config.DeviceCodenmae == "")
            {
                cAppend("FLASH TWRP: Please connect your device, so MotoTool can check your device!");
                Dialogs.WarningDialog("FLASH: TWRP", "Please connect your device, so MotoTool can check your device!");
                return;
            }
            if (oConfigMng.Config.DeviceCodenmae == oConfigMng.Config.DeviceCodenmae)
            {
                cAppend("FLASH TWRP: Loading server for... {" + oConfigMng.Config.DeviceCodenmae + "}");
                LoadDeviceServer.CheckDevice(oConfigMng.Config.DeviceCodenmae + ".xml", oConfigMng.Config.DeviceCodenmae);
            }
            if (!File.Exists(fileName))
            {
                cAppend("FLASH TWRP: Downloading TWRP for... {" + oConfigMng.Config.DeviceCodenmae + "}" + " TWRP: " + fileName);
                downloadcall("/TWRP.xml", "TWRP");
                return;
            }
            else
            {
                if (state == IDDeviceState.UNKNOWN)
                {
                    cAppend("FLASH TWRP: Waiting for device...");
                    await Task.Run(() => ADB.WaitForDevice());
                    cAppend("FLASH TWRP: Rebooting into bootloader mode.");
                    await Task.Run(() => ADB.Instance().Reboot(IDBoot.BOOTLOADER));
                }
                if (state == IDDeviceState.FASTBOOT || state == IDDeviceState.BOOTLOADER)
                {
                    cAppend("FLASH TWRP: Flashing TWRP...");
                    await Task.Run(() => Fastboot.Instance().Flash(IDDevicePartition.RECOVERY, LoadDeviceServer.twrpname));
                    cAppend("FLASH TWRP: Done flashing TWRP.\n");
                }
                else
                {
                    Thread.Sleep(1000);
                    Strings.MSGBOXBootloaderWarning();
                    cAppend("FLASH TWRP: Your device is in the wrong state. Please put your device in bootloader mode. " + state);
                }
            }
        }

        private async void materialButtonBootTWRP_Click(object sender, EventArgs e)
        {
            if (oConfigMng.Config.DeviceCodenmae == "lima" || oConfigMng.Config.DeviceCodenmae == "sofiar" || oConfigMng.Config.DeviceCodenmae == "sofia")
            {
                cAppend("BOOT TWRP: Hey this device doesn't have twrp yet! :(");
                Dialogs.InfoDialog("BOOT: TWRP", "Hey this device doesn't have twrp yet! :(");
                return;
            }
            if (oConfigMng.Config.DeviceCodenmae == "")
            {
                cAppend("BOOT TWRP: Please connect your device, so MotoTool can check your device!");
                Dialogs.WarningDialog("BOOT: TWRP", "Please connect your device, so MotoTool can check your device!");
                return;
            }
            if (oConfigMng.Config.DeviceCodenmae == oConfigMng.Config.DeviceCodenmae)
            {
                cAppend("BOOT TWRP: Loading server for... {" + oConfigMng.Config.DeviceCodenmae + "}");
                LoadDeviceServer.CheckDevice(oConfigMng.Config.DeviceCodenmae + ".xml", oConfigMng.Config.DeviceCodenmae);
            }
            string fileName = @"C:\adb\TWRP\" + LoadDeviceServer.twrpname;
            if (!File.Exists(fileName))
            {
                cAppend("BOOT TWRP: Downloading TWRP for... {" + oConfigMng.Config.DeviceCodenmae + "}" + " TWRP: " + fileName);
                downloadcall("/TWRP.xml", "TWRP");
                return;
            }
            else
            {
                if (state == IDDeviceState.FASTBOOT || state == IDDeviceState.BOOTLOADER)
                {
                    cAppend("BOOT TWRP: Waiting for device...");
                    await Task.Run(() => ADB.WaitForDevice());
                    cAppend("BOOT TWRP: Rebooting into bootloader mode.");
                    await Task.Run(() => ADB.Instance().Reboot(IDBoot.BOOTLOADER));
                    cAppend("BOOT TWRP: Botting TWRP...");
                    await Task.Run(() => Fastboot.Instance().Flash(IDDevicePartition.BOOT, LoadDeviceServer.twrpname));
                    cAppend("BOOT TWRP: Done booted TWRP.\n");
                }
                else
                {
                    Thread.Sleep(1000);
                    Strings.MSGBOXBootloaderWarning();
                    cAppend("FLASH TWRP: Your device is in the wrong state. Please put your device in bootloader mode. " + state);
                }
            }
        }

        private async void materialButtonRebootBootloader_Click(object sender, EventArgs e)
        {
            if (IDDeviceState.DEVICE == state)
            {
                cAppend("REBOOT BOOTLOADER: Waiting for device...");
                await Task.Run(() => ADB.WaitForDevice());
                cAppend("REBOOT BOOTLOADER: Rebooting into bootloader mode.");
                await Task.Run(() => ADB.Instance().Reboot(IDBoot.BOOTLOADER));
            }
            else
            {
                Thread.Sleep(1000);
                Strings.MSGBOXBootloaderWarning();
                cAppend("REBOOT BOOTLOADER: Your device is in the wrong state. " + state);
            }
        }

        private async void materialButtonRebootRecovery_Click(object sender, EventArgs e)
        {
            if (IDDeviceState.DEVICE == state)
            {
                cAppend("REBOOT RECOVERY: Waiting for device...");
                await Task.Run(() => ADB.WaitForDevice());
                cAppend("REBOOT RECOVERY: Rebooting into recovery mode.");
                await Task.Run(() => ADB.Instance().Reboot(IDBoot.RECOVERY));
            }
            else
            {
                Thread.Sleep(1000);
                Strings.MSGBOXBootloaderWarning();
                cAppend("REBOOT RECOVERY: Your device is in the wrong state.\n");
            }
        }

        private async void materialButtonBlankFlash_Click(object sender, EventArgs e)
        {
            if (oConfigMng.Config.DeviceCodenmae == "lima" ||
                oConfigMng.Config.DeviceCodenmae == "potter" ||
                oConfigMng.Config.DeviceCodenmae == "sanders" ||
                oConfigMng.Config.DeviceCodenmae == "sofiar" ||
                oConfigMng.Config.DeviceCodenmae == "sofia")
            {
                cAppend("BLANKFLASH: " + oConfigMng.Config.DeviceCodenmae + " Hey this device doesn't have blankflash yet! :(. If you know about an existing blankflash you can contact me and i'll add it!");
                Dialogs.InfoDialog("BLANKFLASH: " + oConfigMng.Config.DeviceCodenmae, "Hey this device doesn't have blankflash yet! :(. If you know about an existing blankflash you can contact me and i'll add it!");
                return;
            }
            if (oConfigMng.Config.DeviceCodenmae == "")
            {
                cAppend("BLANKFLASH: " + oConfigMng.Config.DeviceCodenmae + "Please connect your device, so MotoTool can check your device!");
                Dialogs.WarningDialog("BLANKFLASH: " + oConfigMng.Config.DeviceCodenmae, "Please connect your device, so MotoTool can check your device!");
                return;
            }
            if (oConfigMng.Config.DeviceCodenmae == oConfigMng.Config.DeviceCodenmae)
            {
                cAppend("BLANKFLASH: Loading device server for... {" + oConfigMng.Config.DeviceCodenmae + "}");
                LoadDeviceServer.CheckDevice(oConfigMng.Config.DeviceCodenmae + ".xml", oConfigMng.Config.DeviceCodenmae);
            }
            string blankflashfilepath = @"C:\adb\Others\" + LoadDeviceServer.unbrickname;
            if (!File.Exists(blankflashfilepath) &&
                !Directory.Exists(@"C:\adb\Others\" + oConfigMng.Config.DeviceBlankFlash))
            {
                cAppend("BLANKFLASH: Downloading BLANKFLASH for... {" + oConfigMng.Config.DeviceCodenmae + "}" + " BLANKFLASH: " + oConfigMng.Config.DeviceBlankFlash);
                downloadcall("/BLANKFLASH.xml", "BLANKFLASH");
                oConfigMng.Config.DeviceBlankFlash = LoadDeviceServer.unbrickname;
                oConfigMng.SaveConfig();
                return;
            }
            else
            {
                Thread.Sleep(1000);
                cAppend("Blankflash info: " + oConfigMng.Config.DeviceBlankFlash);
                cAppend("Botting into Bootloader mode...");
                Directory.SetCurrentDirectory(@"C:\adb\Others\" + oConfigMng.Config.DeviceBlankFlash);
                await Task.Run(() => qBootExecuteCommand());
                cAppend("Botting into Bootloader mode... OK");
                Thread.Sleep(1000);
                Dialogs.InfoDialog("BlankFlash", "Please, check if your device has booted up into Bootloader mode!");
            }
        }

        private async void materialButtonFlashLogo_Click(object sender, EventArgs e)
        {
            string logopath = @"C:\adb\" + oConfigMng.Config.DeviceFirmware + oConfigMng.Config.DeviceFirmwareInfo;
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
                if (state == IDDeviceState.DEVICE || state == IDDeviceState.RECOVERY || state == IDDeviceState.FASTBOOT)
                {
                    cAppend("FLASH LOGO: Waiting for device...");
                    await Task.Run(() => ADB.WaitForDevice());
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
                    cAppend("FLASH LOGO: Your device is in the wrong state. Please put your device in bootloader mode. " + state);
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
            Directory.SetCurrentDirectory(@"C:\\adb\\");
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
                Folders.OpenFolder(@"adb");
            }
            catch (Exception er)
            {
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
            cAppend("ADD NEW DEVICE: Clearing old device info...");
            oConfigMng.LoadConfig();
            oConfigMng.Config.DeviceCodenmae = "";
            oConfigMng.Config.DeviceFirmware = "";
            cAppend("ADD NEW DEVICE: Clearing old device info... {OK}");
            oConfigMng.SaveConfig();
            GetProp();
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

        private void materialSwitchAutoSaveLogs_CheckedChanged(object sender, EventArgs e)
        {
            AutoSaveLogs = materialSwitchAutoSaveLogs.Checked;
            oConfigMng.LoadConfig();
            if (AutoSaveLogs = materialSwitchAutoSaveLogs.Checked == true)
            {
                cAppend("AUTOSAVELOGS: Enabled");
                oConfigMng.Config.Autosavelogs = "true";
            }
            else
            {
                cAppend("AUTOSAVELOGS: Disabled");
                oConfigMng.Config.Autosavelogs = "false";
            }
            cAppend("AUTOSAVELOGS: Settings saved!");
            oConfigMng.SaveConfig();
            Invalidate();
        }

        private void exit(object sender, FormClosedEventArgs e)
        {
            KillWhenExit();
        }

        public void KillWhenExit()
        {
            cAppend("EXIT: Stopping adb, fastboot and callback monitor...");
            ADB.ConnectionMonitor.Stop();
            ADB.ConnectionMonitor.Callback -= ConnectionMonitorCallback;
            ADB.Stop();
            Fastboot.Dispose();
            ADB.Dispose();
            oConfigMng.LoadConfig();
            cAppend("EXIT: Stopping adb, fastboot and callback monitor... {OK}");
            if (oConfigMng.Config.Autosavelogs == "true")
            {
                cAppend("EXIT: Saving MotoTool logs...");
                try
                {
                    string filePath = @"C:\adb\.settings\Logs\ToolLogs.txt";
                    cAppend("EXIT: Saving MotoTool logs... {OK}");
                    console.SaveFile(filePath, RichTextBoxStreamType.PlainText);
                }
                catch (Exception ex)
                {
                    Logs.DebugErrorLogs(ex);
                    cAppend("EXIT: Saving MotoTool logs... {ERROR}");
                    Dialogs.ErrorDialog("An error has occured while attempting to save the output...", ex.ToString());
                }
            }
            oConfigMng.SaveConfig();
            Application.ExitThread();
            Application.Exit();
            base.Dispose(Disposing);
        }
    }
}