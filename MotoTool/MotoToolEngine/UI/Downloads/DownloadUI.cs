
using System;
using System.ComponentModel;
using System.Net;
using System.IO;
using System.Diagnostics;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using log4net;
using System.Reflection;

namespace Franco28Tool.Engine
{
    [ComVisible(false)]
    public partial class DownloadUI : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        public WebClient webClient;
        public Stopwatch sw = new Stopwatch();
        private SettingsMng oConfigMng = new SettingsMng();
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public DownloadUI()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            InitializeComponent();
            materialButton23.Enabled = false;
        }

        public void KillAsync()
        {
            _log.Debug("Web client canceled");
            webClient.CancelAsync();
        }

        public void closeform()
        {
            oConfigMng.LoadConfig();
            if (this.webClient != null)
            {
                KillAsync();
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

        private void DownloadUI_Load(object sender, EventArgs e)
        {
            oConfigMng.LoadConfig();
            _log.Info("Download UI starting");
            labelspeed.Text = "{0} kb/s";
            labelPerc.Text = "0%";
            labelfilesize.Text = "{0} MB's / {1} MB's";
            ProgressBar1.Value = 0;

            if (oConfigMng.Config.ToolTheme == "light")
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            if (oConfigMng.Config.ToolTheme == "dark")
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            }

            cAppend("Downloading " + DownloadsMng.filename);
            _log.Info("Downloading " + DownloadsMng.filename);
            DownloadsMng.SAVEPath = DownloadsMng.SAVEPathname;
            DownloadFile(DownloadsMng.DOWNLOADPath, DownloadsMng.SAVEPath);
        }

        public void DownloadFile(string urlAddress, string location)
        {
            if (InternetCheck.ConnectToInternet() == true)
            {
                using (webClient = new WebClient())
                {
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                    Uri URL = urlAddress.StartsWith("https://", StringComparison.OrdinalIgnoreCase) ? new Uri(urlAddress) : new Uri("https://" + urlAddress);
                    try
                    {
                        sw.Start();
                        _log.Debug("Downloading from: " + URL + " to:" + location);
                        webClient.DownloadFileAsync(URL, location);
                    }
                    catch (Exception ex)
                    {
                        Logs.DebugErrorLogs(ex);
                        Dialogs.ErrorDialog("Download error", ex.Message);
                    }
                }
            }
            else
            {
                _log.Error("Download failed, please check your internet connection!");
                Dialogs.ErrorDialog("Download failed", "Please check your internet connection!");
            }
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            labelspeed.Text = string.Format("{0} kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00"));
            labelPerc.Text = e.ProgressPercentage.ToString() + "%";
            labelfilesize.Text = string.Format("{0} MB's / {1} MB's",
                (e.BytesReceived / 1024d / 1024d).ToString("0.00"),
                (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00"));
            ProgressBar1.Value = e.ProgressPercentage;
            try
            {
                oConfigMng.LoadConfig();
                if (DownloadsMng.filename == oConfigMng.Config.DeviceFirmwareInfo)
                {
                    oConfigMng.Config.DownloadFileSizeFirmware = e.TotalBytesToReceive.ToString();
                    oConfigMng.SaveConfig();
                }
                if (DownloadsMng.filename == oConfigMng.Config.DeviceTWPRInfo)
                {
                    oConfigMng.Config.DownloadFileSizeTWRP = e.TotalBytesToReceive.ToString();
                    oConfigMng.SaveConfig();
                }
                if (DownloadsMng.filename == oConfigMng.Config.DownloadFileSizeTWRPPermanent)
                {
                    oConfigMng.Config.DownloadFileSizeTWRPPermanent = e.TotalBytesToReceive.ToString();
                    oConfigMng.SaveConfig();
                }
                if (DownloadsMng.filename == oConfigMng.Config.DeviceBlankFlash)
                {
                    oConfigMng.Config.DownloadFileSizeBlankFlash = e.TotalBytesToReceive.ToString();
                    oConfigMng.SaveConfig();
                }
            }
            catch (Exception er)
            {
                Logs.DebugErrorLogs(er);
                Dialogs.ErrorDialog("ERROR: Saving file sizes", "Error: " + er);
                return;
            }
        }

        public void Completed(object sender, AsyncCompletedEventArgs e)
        {
            // Here if its cancelled by the button, this will show a messagge
            if (e.Cancelled == true)
            {
                _log.Info("Download has been canceled: " + DownloadsMng.filename);
                cAppend("Download has been canceled: " + DownloadsMng.filename);
                materialButton10.Enabled = false;
                materialButton23.Enabled = true;
                Dialogs.InfoDialog(DownloadsMng.filename, "Download has been canceled");
                KillAsync();
                return;
            }

            sw.Reset();
            ProgressBar1.Value = 0;

            try
            {
                _log.Info("Checking file extension");
                if (Path.GetExtension(DownloadsMng.SAVEPathname).Equals(".zip"))
                {
                    // Check TWRP Installer
                    try
                    {
                        _log.Info("is a zip file!");
                        string partialName = "twrp";
                        DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(@"C:\MotoTool\TWRP\");
                        FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles("*" + partialName + "*.*");

                        foreach (FileInfo foundFile in filesInDir)
                        {
                            _log.Info("is a zip file TWRP!");
                            string fullName = foundFile.FullName;
                            if (fullName == DownloadsMng.SAVEPathname)
                            {
                                _log.Info(DownloadsMng.filename + " Info" + "\nDownload complete, " + DownloadsMng.filename + "is located at: " + Environment.NewLine + "'" + DownloadsMng.SAVEPath + "'.");
                                cAppend(DownloadsMng.filename + " Info" + "\nDownload complete, " + DownloadsMng.filename + "is located at: " + Environment.NewLine + "'" + DownloadsMng.SAVEPath + "'.");
                                Dialogs.InfoDialog(DownloadsMng.filename + " Info", "Download complete, " + DownloadsMng.filename + "is located at: " + Environment.NewLine + "'" + DownloadsMng.SAVEPath + "'.");
                                closeform();
                                this.Dispose();
                                return;
                            }
                        }
                    }
                    catch (Exception er)
                    {
                        Logs.DebugErrorLogs(er);
                        Dialogs.ErrorDialog("ERROR: Verify TWRP INSTALLER", "Error: " + er);
                    }

                    // If its zip file, show this general messagge
                    _log.Info(DownloadsMng.filename + " Info" + "\nDownload complete, " + DownloadsMng.filename + "is located at: " + Environment.NewLine + "'" + DownloadsMng.SAVEPath + "'.");
                    cAppend(DownloadsMng.filename + " Info" + "\nDownload complete, " + DownloadsMng.filename + "is located at: " + Environment.NewLine + "'" + DownloadsMng.SAVEPath + "'.");
                    Dialogs.InfoDialog(DownloadsMng.filename + " Info", "Download complete, " + DownloadsMng.filename + "is located at: " + Environment.NewLine + "'" + DownloadsMng.SAVEPath + "'.");
                    this.Hide();

                    // here if xml reader firmware exctrated equals to 0, this will extract the downloaded zip!
                    try
                    {
                        _log.Info("Checking if is a firmware and was extracted");
                        if (oConfigMng.Config.FirmwareExtracted == "0")
                        {
                            _log.Info("Checking if is a firmware and was extracted... {OK}");
                            DirectoryInfo di = Directory.CreateDirectory(DownloadsMng.filename);
                            var unzip = new UnzipUI();
                            unzip.textBox_FilePath.Text = DownloadsMng.SAVEPathname;
                            unzip.textBox_ExtractionFolder.Text = DownloadsMng.filepath + DownloadsMng.filename;
                            unzip.Text = "Unzip: " + DownloadsMng.filename;
                            if (unzip.textBox_FilePath.Text != string.Empty && unzip.textBox_ExtractionFolder.Text != string.Empty)
                            {
                                unzip.extractFile.RunWorkerAsync();
                                _log.Debug("Unzip: " + DownloadsMng.filename);
                            }
                            else
                            {
                                Strings.MsgBoxUnzippyAlert();
                            }
                            unzip.Show();
                            if (File.Exists(DownloadsMng.SAVEPathname))
                            {
                                _log.Debug("Removing file");
                                File.Delete(DownloadsMng.SAVEPathname);
                            }
                            closeform();
                            this.Dispose();
                            return;
                        }
                    }
                    catch (Exception er)
                    {
                        Logs.DebugErrorLogs(er);
                        Dialogs.ErrorDialog("ERROR: Unzip File", "Error: " + er);
                    }
                    closeform();
                    this.Dispose();
                    return;
                }
                else
                {
                    oConfigMng.LoadConfig();
                    _log.Info(DownloadsMng.filename + " Info" + "\nDownload complete, " + DownloadsMng.filename + "is located at: " + Environment.NewLine + "'" + DownloadsMng.SAVEPath + "'.");
                    cAppend(DownloadsMng.filename + " Info" + "\nDownload complete, " + DownloadsMng.filename + "is located at: " + Environment.NewLine + "'" + DownloadsMng.SAVEPath + "'.");
                    if (this.webClient != null)
                    {
                        KillAsync();
                    }
                    Dialogs.InfoDialog(DownloadsMng.filename + " Info", "Download complete, " + DownloadsMng.filename + "is located at: " + Environment.NewLine + "'" + DownloadsMng.SAVEPath + "'.");
                    this.Dispose();
                    return;
                }
            }
            catch (Exception er)
            {
                Logs.DebugErrorLogs(er);
                Dialogs.ErrorDialog("ERROR: Verify ZIP files", "Error: " + er);
                return;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            closeform();
        }

        private void materialButton23_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
