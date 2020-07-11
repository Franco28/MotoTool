
using log4net;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Franco28Tool.Engine
{
    [ComVisible(false)]
    public partial class Firmwares : MaterialForm
    {
        public Form activeForm = null;
        private readonly MaterialSkinManager materialSkinManager;
        private static SettingsMng oConfigMng = new SettingsMng();
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Firmwares()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            InitializeComponent();
            materialButtonFirmwareServer.Enabled = false;
            materialButtonAMXBR.Enabled = false;
            materialButtonAMXLA.Enabled = false;
            materialButtonAMXM.Enabled = false;
            materialButtonAMZ.Enabled = false;
            materialButtonAMXCL.Enabled = false;
            materialButtonAMXPE.Enabled = false;
            materialButtonAMXCO.Enabled = false;
            materialButtonRETRU.Enabled = false;
            materialButtonRETAIL.Enabled = false;
            materialButtonRETAPAC.Enabled = false;
            materialButtonRETAR.Enabled = false;
            materialButtonRETIN.Enabled = false;
            materialButtonRETBR.Enabled = false;
            materialButtonRETCA.Enabled = false;
            materialButtonRETEU.Enabled = false;
            materialButtonRETUS.Enabled = false;
            materialButtonRETLA.Enabled = false;
            materialButtonRETUS.Enabled = false;
            materialButtonRETGB.Enabled = false;
            materialButtonRETCL.Enabled = false;
            materialButtonRETLA1ST.Enabled = false;
            materialButtonRETMX.Enabled = false;
            materialButtonTEFBR.Enabled = false;
            materialButtonTEFCL.Enabled = false;
            materialButtonTEFCO.Enabled = false;
            materialButtonTEFPE.Enabled = false;
            materialButtonTEFMX.Enabled = false;
            materialButtonTEFES.Enabled = false;
            materialButtonATTMX.Enabled = false;
            materialButtonBWACA.Enabled = false;
            materialButtonDTEU.Enabled = false;
            materialButtonNIIPE.Enabled = false;
            materialButtonOPENCL.Enabled = false;
            materialButtonOPENMX.Enabled = false;
            materialButtonSprint.Enabled = false;
            materialButtonTIGCO.Enabled = false;
            materialButtonTIMBR.Enabled = false;
            materialButtonUSC.Enabled = false;
            materialButtonOPENLA.Enabled = false;
            materialButtonOPENPE.Enabled = false;
            materialButtonEEGB.Enabled = false;
            materialButtonORAEU.Enabled = false;
            materialButtonPLUSPL.Enabled = false;
            materialButtonTIGCA.Enabled = false;
            materialButtonWOMCL.Enabled = false;
            materialButtonENTCL.Enabled = false;
            materialButtonLRA.Enabled = false;
            materialButtonCC.Enabled = false;
            materialButtonTMO.Enabled = false;
        }

        public void cAppend(string message)
        {
            this.Invoke((Action)delegate
            {
                console.AppendText(string.Format("\n{0} : {1}", DateTime.Now, message));
                console.ScrollToCaret();
            });
        }

        private void Firmwares_Load(object sender, EventArgs e)
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
            _log.Info("FIRMWARE STARTING: Checking internet connection...");
            cAppend("FIRMWARE STARTING: Checking internet connection...");
            if (InternetCheck.ConnectToInternet() == true)
            {
                _log.Info("FIRMWARE STARTING: Checking internet connection... {OK}");
                cAppend("FIRMWARE STARTING: Checking internet connection... {OK}");
                label2.Text = " Internet Connection: Online";
            }
            else
            {
                _log.Error("FIRMWARE STARTING: Checking internet connection...");
                cAppend("FIRMWARE STARTING: Checking internet connection... {ERROR}");
                label2.Text = " Internet Connection: Offline";
            }

            if (oConfigMng.Config.DeviceCodenmae == "")
            {
                _log.Info("FIRMWARE STARTING: Please connect your device, so MotoTool can read firmwares!");
                cAppend("FIRMWARE STARTING: Please connect your device, so MotoTool can read firmwares!");
                Dialogs.WarningDialog("Device Check", "Please connect your device, so MotoTool can read firmwares!");
                return;
            }

            if (oConfigMng.Config.DeviceCodenmae == oConfigMng.Config.DeviceCodenmae)
            {
                LoadDeviceServer.CheckDevice(oConfigMng.Config.DeviceCodenmae + ".xml", oConfigMng.Config.DeviceCodenmae);
                string tr = "true";
                _log.Info("FIRMWARE STARTING: Checking server...");
                cAppend("FIRMWARE STARTING: Checking server...");
                if (LoadDeviceServer.fserverMaintenance == tr)
                {
                    _log.Warn("FIRMWARE STARTING: Firmware server is on maintenance! Please this will be back soon...");
                    cAppend("FIRMWARE STARTING: Firmware server is on maintenance! Please this will be back soon...");
                    Dialogs.WarningDialog("Firmware server is on maintenance", "Please this will be back soon...");
                    return;
                } 
                else
                {
                    materialButtonFirmwareServer.Enabled = true;
                    _log.Info("FIRMWARE STARTING: Checking server...  {OK}");
                    cAppend("FIRMWARE STARTING: Checking server... {OK}");
                }
            }

            _log.Info("FIRMWARE STARTING: Checking device info... ");
            cAppend("FIRMWARE STARTING: Checking device info... ");
            if (oConfigMng.Config.DeviceCodenmae == "lima")
            {
                materialButtonRETAIL.Enabled = true;
                materialButtonRETAPAC.Enabled = true;
                materialButtonRETAR.Enabled = true;
                materialButtonRETIN.Enabled = true;
                materialButtonRETBR.Enabled = true;
                materialButtonRETCA.Enabled = true;
                materialButtonRETEU.Enabled = true;
                materialButtonRETLA.Enabled = true;
                materialButtonRETGB.Enabled = true;
                materialButtonRETCL.Enabled = true;
                materialButtonTEFBR.Enabled = true;
                materialButtonOPENCL.Enabled = true;
                materialButtonOPENMX.Enabled = true;
                materialButtonOPENLA.Enabled = true;
                materialButtonOPENPE.Enabled = true;
                materialButtonEEGB.Enabled = true;
            }
            if (oConfigMng.Config.DeviceCodenmae == "sofiar")
            {
                materialButtonAMXLA.Enabled = true;
                materialButtonAMXCL.Enabled = true;
                materialButtonAMXCO.Enabled = true;
                materialButtonATTMX.Enabled = true;
                materialButtonOPENMX.Enabled = true;
                materialButtonRETLA.Enabled = true;
                materialButtonRETAR.Enabled = true;
                materialButtonRETEU.Enabled = true;
            }
            if (oConfigMng.Config.DeviceCodenmae == "kane_sprout")
            {
                materialButtonRETLA.Enabled = true;
            }
            if (oConfigMng.Config.DeviceCodenmae == "beckham")
            {
                materialButtonAMXBR.Enabled = true;
                materialButtonAMXLA.Enabled = true;
                materialButtonAMXM.Enabled = true;
                materialButtonAMZ.Enabled = true;
                materialButtonRETAIL.Enabled = true;
                materialButtonRETAPAC.Enabled = true;
                materialButtonRETAR.Enabled = true;
                materialButtonRETBR.Enabled = true;
                materialButtonRETCA.Enabled = true;
                materialButtonRETEU.Enabled = true;
                materialButtonRETUS.Enabled = true;
                materialButtonRETLA.Enabled = true;
                materialButtonTEFBR.Enabled = true;
                materialButtonTEFCL.Enabled = true;
                materialButtonTEFCO.Enabled = true;
                materialButtonTEFPE.Enabled = true;
                materialButtonATTMX.Enabled = true;
                materialButtonBWACA.Enabled = true;
                materialButtonDTEU.Enabled = true;
                materialButtonNIIPE.Enabled = true;
                materialButtonOPENCL.Enabled = true;
                materialButtonOPENMX.Enabled = true;
                materialButtonSprint.Enabled = true;
                materialButtonTIGCO.Enabled = true;
                materialButtonTIMBR.Enabled = true;
                materialButtonUSC.Enabled = true;
            }
            if (oConfigMng.Config.DeviceCodenmae == "doha")
            {
                materialButtonAMXBR.Enabled = true;
                materialButtonAMXLA.Enabled = true;
                materialButtonAMXM.Enabled = true;
                materialButtonAMXCL.Enabled = true;
                materialButtonAMXPE.Enabled = true;
                materialButtonRETIN.Enabled = true;
                materialButtonRETRU.Enabled = true;
                materialButtonRETAIL.Enabled = true;
                materialButtonRETAPAC.Enabled = true;
                materialButtonRETAR.Enabled = true;
                materialButtonRETBR.Enabled = true;
                materialButtonRETEU.Enabled = true;
                materialButtonTEFMX.Enabled = true;
                materialButtonORAEU.Enabled = true;
                materialButtonPLUSPL.Enabled = true;
                materialButtonTIGCA.Enabled = true;
                materialButtonATTMX.Enabled = true;
                materialButtonOPENCL.Enabled = true;
                materialButtonOPENMX.Enabled = true;
            }
            if (oConfigMng.Config.DeviceCodenmae == "evert" &&
                oConfigMng.Config.DeviceCodenmae == "potter" &&
                oConfigMng.Config.DeviceCodenmae == "lake")
            {
                materialButtonAMXBR.Enabled = true;
                materialButtonAMXLA.Enabled = true;
                materialButtonAMXM.Enabled = true;
                materialButtonAMXCL.Enabled = true;
                materialButtonAMXPE.Enabled = true;
                materialButtonAMXCO.Enabled = true;
                materialButtonTEFBR.Enabled = true;
                materialButtonTEFCO.Enabled = true;
                materialButtonTEFMX.Enabled = true;
                materialButtonTEFES.Enabled = true;

                if (oConfigMng.Config.DeviceCodenmae == "evert")
                {
                    materialButtonRETUS.Enabled = true;
                    materialButtonRETGB.Enabled = true;
                    materialButtonRETIN.Enabled = true;
                    materialButtonRETAIL.Enabled = true;
                    materialButtonRETAPAC.Enabled = true;
                    materialButtonRETAR.Enabled = true;
                    materialButtonRETBR.Enabled = true;
                    materialButtonRETEU.Enabled = true;
                    materialButtonRETLA.Enabled = true;
                    materialButtonRETLA1ST.Enabled = true;
                    materialButtonWOMCL.Enabled = true;
                    materialButtonTIMBR.Enabled = true;
                    materialButtonTIGCO.Enabled = true;
                    materialButtonENTCL.Enabled = true;
                }
                if (oConfigMng.Config.DeviceCodenmae == "potter")
                {
                    materialButtonRETUS.Enabled = true;
                    materialButtonRETGB.Enabled = true;
                    materialButtonRETIN.Enabled = true;
                    materialButtonRETAIL.Enabled = true;
                    materialButtonRETAPAC.Enabled = true;
                    materialButtonRETAR.Enabled = true;
                    materialButtonRETBR.Enabled = true;
                    materialButtonRETEU.Enabled = true;
                    materialButtonRETLA.Enabled = true;
                    materialButtonRETLA1ST.Enabled = true;
                    materialButtonRETMX.Enabled = true;
                    materialButtonTIMBR.Enabled = true;
                    materialButtonTIGCO.Enabled = true;
                }
                if (oConfigMng.Config.DeviceCodenmae == "lake")
                {
                    materialButtonRETGB.Enabled = true;
                    materialButtonRETAIL.Enabled = true;
                    materialButtonRETAPAC.Enabled = true;
                    materialButtonRETAR.Enabled = true;
                    materialButtonRETBR.Enabled = true;
                    materialButtonRETEU.Enabled = true;
                    materialButtonRETLA.Enabled = true;
                    materialButtonRETRU.Enabled = true;
                    materialButtonTEFBR.Enabled = true;
                    materialButtonTEFCO.Enabled = true;
                    materialButtonTEFMX.Enabled = true;
                    materialButtonEEGB.Enabled = true;
                    materialButtonORAEU.Enabled = true;
                    materialButtonTMO.Enabled = true;
                    materialButtonENTCL.Enabled = true;
                    materialButtonTIMBR.Enabled = true;
                    materialButtonWOMCL.Enabled = true;
                    materialButtonTIGCO.Enabled = true;
                }
            }
            if (oConfigMng.Config.DeviceCodenmae == "river")
            {
                materialButtonAMXBR.Enabled = true;
                materialButtonAMZ.Enabled = true;
                materialButtonRETGB.Enabled = true;
                materialButtonRETAIL.Enabled = true;
                materialButtonRETAPAC.Enabled = true;
                materialButtonRETAR.Enabled = true;
                materialButtonRETBR.Enabled = true;
                materialButtonRETEU.Enabled = true;
                materialButtonRETLA.Enabled = true;
                materialButtonRETRU.Enabled = true;
                materialButtonRETUS.Enabled = true;
                materialButtonRETIN.Enabled = true;
                materialButtonTEFBR.Enabled = true;
                materialButtonTEFCO.Enabled = true;
                materialButtonTEFPE.Enabled = true;
                materialButtonOPENCL.Enabled = true;
                materialButtonOPENMX.Enabled = true;
                materialButtonTIMBR.Enabled = true;
                materialButtonNIIPE.Enabled = true;
                materialButtonTIGCO.Enabled = true;
            }
            if (oConfigMng.Config.DeviceCodenmae == "sanders")
            {
                materialButtonAMXBR.Enabled = true;
                materialButtonRETGB.Enabled = true;
                materialButtonRETAIL.Enabled = true;
                materialButtonRETAPAC.Enabled = true;
                materialButtonRETAR.Enabled = true;
                materialButtonRETBR.Enabled = true;
                materialButtonRETLA.Enabled = true;
                materialButtonRETRU.Enabled = true;
                materialButtonRETUS.Enabled = true;
                materialButtonRETIN.Enabled = true;
                materialButtonTEFBR.Enabled = true;
                materialButtonOPENMX.Enabled = true;
                materialButtonTIMBR.Enabled = true;
            }
            if (oConfigMng.Config.DeviceCodenmae == "hannah" || oConfigMng.Config.DeviceCodenmae == "ahannah")
            {
                materialButtonRETAIL.Enabled = true;
                materialButtonRETIN.Enabled = true;
                if (oConfigMng.Config.DeviceCodenmae == "ahannah")
                {
                    materialButtonRETAPAC.Enabled = true;
                }
            }
            _log.Info("FIRMWARE STARTING: Checking device info... {" + oConfigMng.Config.DeviceCodenmae + "}");
            cAppend("FIRMWARE STARTING: Checking device info... {" + oConfigMng.Config.DeviceCodenmae + "}");
        }

        public void CreateFirmwareFolder()
        {
            oConfigMng.LoadConfig();

            if (oConfigMng.Config.DeviceFirmware == "")
            {
                return;
            }
            if (oConfigMng.Config.DeviceFirmware == oConfigMng.Config.DeviceFirmware)
            {
                _log.Debug(@"Creating firmware folder: C:\\MotoTool\\Firmware\\" + oConfigMng.Config.DeviceFirmware);
                cAppend(@"Creating firmware folder: C:\\MotoTool\\Firmware\\" + oConfigMng.Config.DeviceFirmware);
                MotoFirmware.CreateFolders(@"C:\\MotoTool\\Firmware\\" + oConfigMng.Config.DeviceFirmware);
                _log.Debug(@"Setting firmware folder: C:\\MotoTool\\Firmware\\" + oConfigMng.Config.DeviceFirmware);
                cAppend(@"Setting firmware folder: C:\\MotoTool\\Firmware\\" + oConfigMng.Config.DeviceFirmware);
                Directory.SetCurrentDirectory(@"C:\\MotoTool\\Firmware\\" + oConfigMng.Config.DeviceFirmware);
            }
        }
        
        private void materialButtonFirmwareServer_Click(object sender, EventArgs e)
        {
            oConfigMng.LoadConfig();
            _log.Info("FIRMWARE: Opening " + oConfigMng.Config.DeviceFirmware + " firmware server...");
            cAppend("FIRMWARE: Opening " + oConfigMng.Config.DeviceFirmware + " firmware server...");
            if (oConfigMng.Config.DeviceFirmware == oConfigMng.Config.DeviceFirmware)
            {
                MotoFirmware.FirmwareServer(oConfigMng.Config.DeviceCodenmae + "/official/", oConfigMng.Config.DeviceFirmware);
                _log.Info("FIRMWARE: Opening " + oConfigMng.Config.DeviceFirmware + " firmware server... {OK}");
                cAppend("FIRMWARE: Opening " + oConfigMng.Config.DeviceFirmware + " firmware server... {OK}");
            }
        }

        public void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDownload.Controls.Add(childForm);
            panelDownload.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public void downloadstart()
        {
            oConfigMng.LoadConfig();
            string firmwarepath = @"C:\\MotoTool\\Firmware\\" + oConfigMng.Config.DeviceFirmware + @"\\" + DownloadsMng.filename;
            string firmwarezip = DownloadsMng.filepathname;
            var dld = new DownloadUI();
            try
            {
                oConfigMng.LoadConfig();
                string vIn = oConfigMng.Config.DownloadFileSizeFirmware;
                _log.Debug("FIRMWARE DOWNLOAD: Checking firmware files...");
                cAppend("FIRMWARE DOWNLOAD: Checking firmware files...");
                if (File.Exists(firmwarezip) && oConfigMng.Config.FirmwareExtracted == "0" && vIn != "")
                {
                    long length = new FileInfo(firmwarezip).Length;
                    long vOut = Convert.ToInt64(vIn);
                    if (length == vOut)
                    {
                        _log.Info("FIRMWARE DOWNLOAD: Firmware already exist, now it will be exctracted");
                        cAppend("FIRMWARE DOWNLOAD: Firmware already exist, now it will be exctracted");
                        DirectoryInfo di = Directory.CreateDirectory(DownloadsMng.filename);
                        var unzip = new UnzipUI();
                        unzip.textBox_FilePath.Text = DownloadsMng.SAVEPathname;
                        unzip.textBox_ExtractionFolder.Text = firmwarepath;
                        unzip.Text = "Unzip: " + DownloadsMng.filename;
                        _log.Debug("FIRMWARE DOWNLOAD EXTRACTING: Firmware " + DownloadsMng.filename);
                        cAppend("FIRMWARE DOWNLOAD EXTRACTING: Firmware " + DownloadsMng.filename);
                        if (unzip.textBox_FilePath.Text != string.Empty && unzip.textBox_ExtractionFolder.Text != string.Empty)
                        {
                            unzip.extractFile.RunWorkerAsync();
                        }
                        else
                        {
                            Strings.MsgBoxUnzippyAlert();
                        }
                        unzip.Show();
                        return;
                    }
                    else
                    {
                        Strings.MSGBOXFileCorrupted();
                        oConfigMng.Config.DownloadFileSizeFirmware = "0";
                        _log.Warn(@"FIRMWARE DOWNLOAD: File is corrupted \:  " + DownloadsMng.SAVEPathname);
                        cAppend(@"FIRMWARE DOWNLOAD: File is corrupted \:  " + DownloadsMng.SAVEPathname);
                        File.Delete(DownloadsMng.SAVEPathname);
                        oConfigMng.Config.DeviceFirmwareInfo = DownloadsMng.filename;
                        oConfigMng.Config.FirmwareExtracted = "0";
                        oConfigMng.SaveConfig();
                        openChildForm(dld);
                        return;
                    }
                }
                else if (oConfigMng.Config.FirmwareExtracted == "1")
                {
                    _log.Info("FIRMWARE DOWNLOAD: Firmware already " + DownloadsMng.SAVEPathname);
                    cAppend("FIRMWARE DOWNLOAD: Firmware already " + DownloadsMng.SAVEPathname);
                    return;
                }
            }
            catch (Exception er)
            {
                Logs.DebugErrorLogs(er);
                _log.Error("ERROR: Verifying file - " + er);
                Dialogs.ErrorDialog("ERROR: Verifying file", "Error: " + er);
                return;
            }

            if (Directory.Exists(firmwarepath))
            {
                DirectoryInfo files = new DirectoryInfo(firmwarepath + @"\");
                if (!File.Exists(files + "*.img") || !File.Exists("*.bin"))
                {
                    _log.Warn("Can't find firmware images on folder! firmware will be downloaded again! \nFirmware: " + DownloadsMng.filename);
                    cAppend("Can't find firmware images on folder! firmware will be downloaded again! \nFirmware: " + DownloadsMng.filename);
                    Dialogs.ErrorDialog(DownloadsMng.filename, "Can't find firmware images on folder! firmware will be downloaded again! \nFirmware: " + DownloadsMng.filename);
                    openChildForm(dld);
                    return;
                }
                _log.Info("Firmware already downloaded! \nFirmware: " + DownloadsMng.filename);
                cAppend("Firmware already downloaded! \nFirmware: " + DownloadsMng.filename);
                Dialogs.InfoDialog(DownloadsMng.filename, "Firmware already downloaded! \nFirmware: " + DownloadsMng.filename);
                return;
            }
            else
            {
                CreateFirmwareFolder();
                oConfigMng.Config.DeviceFirmwareInfo = DownloadsMng.filename;
                oConfigMng.Config.FirmwareExtracted = "0";
                oConfigMng.SaveConfig();
                openChildForm(dld);
            }
        }

        public void DCSelected()
        {
            if (activeForm != null)
            {
                activeForm.Dispose();                
            }
            if (oConfigMng.Config.DeviceCodenmae == "")
            {
                _log.Info("FIRMWARES: Please connect your device to read firmwares!");
                cAppend("Please connect your device to read firmwares!");
                Dialogs.WarningDialog("Device Check", "Please connect your device to read firmwares!");
                return;
            }
            if (oConfigMng.Config.DeviceCodenmae == oConfigMng.Config.DeviceCodenmae)
            {
                _log.Info("Loading device...");
                cAppend("Loading device...");
                LoadDeviceServer.CheckDevice(oConfigMng.Config.DeviceCodenmae + ".xml", oConfigMng.Config.DeviceCodenmae);
                cAppend("Loading device... {OK}");
                _log.Info("Loading device... {OK}");
                string tr = "true";
                var main = new ToolMaintenance();
                if (LoadDeviceServer.fserverMaintenance == tr)
                {
                    _log.Info("Firmware is on maintenance!");
                    cAppend("Firmware is on maintenance!");
                    openChildForm(main);
                }
                _log.Info("Selected Device Channel: {" + oConfigMng.Config.DeviceFirmware + "}" + "\nDownloading " + oConfigMng.Config.DeviceFirmware + " Firmware");
                cAppend("Selected Device Channel: {" + oConfigMng.Config.DeviceFirmware + "}" + "\nDownloading " + oConfigMng.Config.DeviceFirmware + " Firmware");
                Dialogs.InfoDialog("Device Channel", "Selected Device Channel: {" + oConfigMng.Config.DeviceFirmware + "}" + "\nDownloading " + oConfigMng.Config.DeviceFirmware + " Firmware");
                oConfigMng.Config.FirmwareExtracted = "0";
                oConfigMng.SaveConfig();
                downloadstart();
            }
        }

        public void DCSelectedAM()
        {
            oConfigMng.LoadConfig();
            DownloadsMng.TOOLDOWNLOAD(LoadDeviceServer.amserver, oConfigMng.Config.DeviceFirmware + ".xml", oConfigMng.Config.DeviceFirmware);
            _log.Info("Device channel selected: " + oConfigMng.Config.DeviceFirmware);
            cAppend("Device channel selected: " + oConfigMng.Config.DeviceFirmware);
            DCSelected();
        }

        private void materialButtonAMXM_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "AMXM";
            oConfigMng.SaveConfig();
            DCSelectedAM();
        }

        private void materialButtonAMXCO_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "AMXCO";
            oConfigMng.SaveConfig();
            DCSelectedAM();
        }

        private void materialButtonAMZ_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "AMZ";
            oConfigMng.SaveConfig();
            DCSelectedAM();
        }

        private void materialButtonAMXCL_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "AMXCL";
            oConfigMng.SaveConfig();
            DCSelectedAM();
        }

        private void materialButtonAMXPE_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "AMXPE";
            oConfigMng.SaveConfig();
            DCSelectedAM();
        }

        private void materialButtonAMXLA_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "AMXLA";
            oConfigMng.SaveConfig();
            DCSelectedAM();
        }

        private void materialButtonAMXBR_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "AMXBR";
            oConfigMng.SaveConfig();
            DCSelectedAM();
        }

        public void DCSelectedRET()
        {
            oConfigMng.LoadConfig();
            DownloadsMng.TOOLDOWNLOAD(LoadDeviceServer.retserver, oConfigMng.Config.DeviceFirmware + ".xml", oConfigMng.Config.DeviceFirmware);
            _log.Info("Device channel selected: " + oConfigMng.Config.DeviceFirmware);
            cAppend("Device channel selected: " + oConfigMng.Config.DeviceFirmware);
            DCSelected();
        }

        private void materialButtonRETLA1ST_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "RETLA1ST";
            oConfigMng.SaveConfig();
            DCSelectedRET();
        }

        private void materialButtonRETRU_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "RETRU";
            oConfigMng.SaveConfig();
            DCSelectedRET();
        }

        private void materialButtonRETCL_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "RETCL";
            oConfigMng.SaveConfig();
            DCSelectedRET();
        }

        private void materialButtonRETGB_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "RETGB";
            oConfigMng.SaveConfig();
            DCSelectedRET();
        }

        private void materialButtonRETIN_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "RETIN";
            oConfigMng.SaveConfig();
            DCSelectedRET();
        }

        private void materialButtonRETUS_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "RETUS";
            oConfigMng.SaveConfig();
            DCSelectedRET();
        }

        private void materialButtonRETMX_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "RETMX";
            oConfigMng.SaveConfig();
            DCSelectedRET();
        }

        private void materialButtonRETEU_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "RETEU";
            oConfigMng.SaveConfig();
            DCSelectedRET();
        }

        private void materialButtonRETLA_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "RETLA";
            oConfigMng.SaveConfig();
            DCSelectedRET();
        }

        private void materialButtonRETAR_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "RETAR";
            oConfigMng.SaveConfig();
            DCSelectedRET();
        }

        private void materialButtonRETCA_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "RETCA";
            oConfigMng.SaveConfig();
            DCSelectedRET();
        }

        private void materialButtonRETAPAC_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "RETAPAC";
            oConfigMng.SaveConfig();
            DCSelectedRET();
        }

        private void materialButtonRETBR_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "RETBR";
            oConfigMng.SaveConfig();
            DCSelectedRET();
        }

        private void materialButtonRETAIL_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "RETAIL";
            oConfigMng.SaveConfig();
            DCSelectedRET();
        }

        public void DCSelectedTEF()
        {
            oConfigMng.LoadConfig();
            DownloadsMng.TOOLDOWNLOAD(LoadDeviceServer.tefserver, oConfigMng.Config.DeviceFirmware + ".xml", oConfigMng.Config.DeviceFirmware);
            _log.Info("Device channel selected: " + oConfigMng.Config.DeviceFirmware);
            cAppend("Device channel selected: " + oConfigMng.Config.DeviceFirmware);
            DCSelected();
        }

        private void materialButtonTEFMX_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "TEFMX";
            oConfigMng.SaveConfig();
            DCSelectedTEF();
        }

        private void materialButtonTEFES_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "TEFES";
            oConfigMng.SaveConfig();
            DCSelectedTEF();
        }

        private void materialButtonTEFCO_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "TEFCO";
            oConfigMng.SaveConfig();
            DCSelectedTEF();
        }

        private void materialButtonTEFCL_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "TEFCL";
            oConfigMng.SaveConfig();
            DCSelectedTEF();
        }

        private void materialButtonTEFPE_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "TEFPE";
            oConfigMng.SaveConfig();
            DCSelectedTEF();
        }

        private void materialButtonTEFBR_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "TEFBR";
            oConfigMng.SaveConfig();
            DCSelectedTEF();
        }

        public void DCSelectedOTHERS()
        {
            oConfigMng.LoadConfig();
            DownloadsMng.TOOLDOWNLOAD(LoadDeviceServer.othersserver, oConfigMng.Config.DeviceFirmware + ".xml", oConfigMng.Config.DeviceFirmware);
            _log.Info("Device channel selected: " + oConfigMng.Config.DeviceFirmware);
            cAppend("Device channel selected: " + oConfigMng.Config.DeviceFirmware);
            DCSelected();
        }

        private void materialButtonCC_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "CC";
            oConfigMng.SaveConfig();
            DCSelectedOTHERS();
        }

        private void materialButtonEEGB_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "EEGB";
            oConfigMng.SaveConfig();
            DCSelectedOTHERS();
        }

        private void materialButtonWOMCL_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "WOMCL";
            oConfigMng.SaveConfig();
            DCSelectedOTHERS();
        }

        private void materialButtonPLUSPL_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "PLUSPL";
            oConfigMng.SaveConfig();
            DCSelectedOTHERS();
        }

        private void materialButtonOPENPE_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "OPENPE";
            oConfigMng.SaveConfig();
            DCSelectedOTHERS();
        }

        private void materialButtonOPENLA_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "OPENLA";
            oConfigMng.SaveConfig();
            DCSelectedOTHERS();
        }

        private void materialButtonSprint_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "Sprint";
            oConfigMng.SaveConfig();
            DCSelectedOTHERS();
        }

        private void materialButtonTIMBR_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "TIMBR";
            oConfigMng.SaveConfig();
            DCSelectedOTHERS();
        }

        private void materialButtonUSC_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "USC";
            oConfigMng.SaveConfig();
            DCSelectedOTHERS();
        }

        private void materialButtonTIGCO_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "TIGCO";
            oConfigMng.SaveConfig();
            DCSelectedOTHERS();
        }

        private void materialButtonTMO_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "TMO";
            oConfigMng.SaveConfig();
            DCSelectedOTHERS();
        }

        private void materialButtonLRA_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "LRA";
            oConfigMng.SaveConfig();
            DCSelectedOTHERS();
        }

        private void materialButtonENTCL_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "ENTCL";
            oConfigMng.SaveConfig();
            DCSelectedOTHERS();
        }

        private void materialButtonTIGCA_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "TIGCA";
            oConfigMng.SaveConfig();
            DCSelectedOTHERS();
        }

        private void materialButtonOPENMX_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "OPENMX";
            oConfigMng.SaveConfig();
            DCSelectedOTHERS();
        }

        private void materialButtonORAEU_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "ORAEU";
            oConfigMng.SaveConfig();
            DCSelectedOTHERS();
        }

        private void materialButtonDTEU_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "DTEU";
            oConfigMng.SaveConfig();
            DCSelectedOTHERS();
        }

        private void materialButtonOPENCL_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "OPENCL";
            oConfigMng.SaveConfig();
            DCSelectedOTHERS();
        }

        private void materialButtonBWACA_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "BWACA";
            oConfigMng.SaveConfig();
            DCSelectedOTHERS();
        }

        private void materialButtonNIIPE_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "NIIPE";
            oConfigMng.SaveConfig();
            DCSelectedOTHERS();
        }

        private void materialButtonATTMX_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.DeviceFirmware = "ATTMX";
            oConfigMng.SaveConfig();
            DCSelectedOTHERS();
        }

        private void MaterialButtonClose_Click(object sender, EventArgs e)
        {
            var download = new DownloadUI();
            if (download.webClient != null)
            {
                download.webClient.CancelAsync();
                download.Dispose();
                this.Dispose();
            }
            else
            {
                download.Dispose();
                this.Dispose();
            }
        }
    }
}