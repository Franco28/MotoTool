
using System;
using System.ComponentModel;
using System.Net;
using System.IO;
using System.Diagnostics;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Windows.Forms;

namespace Franco28Tool.Engine
{
    public partial class DownloadUI : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        public WebClient webClient;
        public Stopwatch sw = new Stopwatch();
        private SettingsMng oConfigMng = new SettingsMng();

        public DownloadUI()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            InitializeComponent();
        }

        public void KillAsync()
        {
            webClient.Dispose();
            webClient.CancelAsync();
            return;
        }

        public void closeform()
        {
            if (this.webClient != null)
            {
                ProgressBar1.Hide();
                this.webClient.CancelAsync();
                KillAsync();
                this.Dispose();
            }
            else
            {
                this.Dispose();
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

            if (oConfigMng.Config.ToolTheme == "light")
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            if (oConfigMng.Config.ToolTheme == "dark")
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            }

            cAppend("Downloading " + DownloadsMng.filename);
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

                    sw.Start();

                    try
                    {
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
            oConfigMng.LoadConfig();
            oConfigMng.Config.DownloadFileSize = e.TotalBytesToReceive.ToString("");
            oConfigMng.SaveConfig();
        }

        public void Completed(object sender, AsyncCompletedEventArgs e)
        {
            sw.Reset();
            cAppend("Download completed!");
        
            ProgressBar1.Value = 0;

            // Here if its cancelled by the button, this will show a messagge and erase broken file
            if (e.Cancelled == true)
            {
                cAppend("Download has been canceled: " + DownloadsMng.filename);
                Dialogs.InfoDialog("Download has been canceled", DownloadsMng.filename);
                killandclose();
                return;
            }
            else
            {
                try
                {
                    if (Path.GetExtension(DownloadsMng.SAVEPathname).Equals(".zip"))
                    {
                        // Check TWRP Installer
                        try
                        {
                            string partialName = "twrp";
                            DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(@"C:\adb\TWRP\");
                            FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles("*" + partialName + "*.*");

                            foreach (FileInfo foundFile in filesInDir)
                            {
                                string fullName = foundFile.FullName;
                                if (fullName == DownloadsMng.SAVEPathname)
                                {
                                    cAppend(DownloadsMng.filename + " Info" + "\nDownload complete, " + DownloadsMng.filename + "is located at: " + Environment.NewLine + "'" + DownloadsMng.SAVEPath + "'.");
                                    Dialogs.InfoDialog(DownloadsMng.filename + " Info", "Download complete, " + DownloadsMng.filename + "is located at: " + Environment.NewLine + "'" + DownloadsMng.SAVEPath + "'.");
                                    closeform();
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
                        cAppend(DownloadsMng.filename + " Info" + "\nDownload complete, " + DownloadsMng.filename + "is located at: " + Environment.NewLine + "'" + DownloadsMng.SAVEPath + "'.");
                        Dialogs.InfoDialog(DownloadsMng.filename + " Info", "Download complete, " + DownloadsMng.filename + "is located at: " + Environment.NewLine + "'" + DownloadsMng.SAVEPath + "'.");
                        this.Hide();

                        // here if xml reader firmware exctrated equals to 0, this will extract the downloaded zip!
                        try
                        {
                            if (oConfigMng.Config.FirmwareExtracted == "0")
                            {
                                DirectoryInfo di = Directory.CreateDirectory(DownloadsMng.filename);
                                var unzip = new UnzipUI();
                                unzip.textBox_FilePath.Text = DownloadsMng.SAVEPathname;
                                unzip.textBox_ExtractionFolder.Text = DownloadsMng.filepath + DownloadsMng.filename;
                                unzip.Text = "Unzip: " + DownloadsMng.filename;
                                if (unzip.textBox_FilePath.Text != string.Empty && unzip.textBox_ExtractionFolder.Text != string.Empty)
                                    unzip.extractFile.RunWorkerAsync();
                                else
                                    Strings.MsgBoxUnzippyAlert();
                                unzip.Show();
                                if (File.Exists(DownloadsMng.SAVEPathname))
                                {
                                    File.Delete(DownloadsMng.SAVEPathname);
                                }
                                closeform();
                                return;
                            }
                        }
                        catch (Exception er)
                        {
                            Logs.DebugErrorLogs(er);
                            Dialogs.ErrorDialog("ERROR: Unzip File", "Error: " + er);
                        }
                        closeform();
                        return;
                    }
                    else
                    {
                        closeform();
                        return;
                    }
                }
                catch (Exception er)
                {
                    Logs.DebugErrorLogs(er);
                    Dialogs.ErrorDialog("ERROR: Verify ZIP files", "Error: " + er);
                }
            }
        }

        private void killandclose()
        {
            if (oConfigMng.Config.Autosavelogs == "true")
            {
                cAppend("EXIT: Saving Download logs...");
                try
                {
                    string filePath = @"C:\adb\.settings\Logs\DownloadLogs.txt";
                    cAppend("EXIT: Saving Download logs... {OK}");
                    console.SaveFile(filePath, RichTextBoxStreamType.PlainText);
                }
                catch (Exception ex)
                {
                    Logs.DebugErrorLogs(ex);
                    cAppend("EXIT: Saving Download logs... {ERROR}");
                    Dialogs.ErrorDialog("An error has occured while attempting to save the output...", ex.ToString());
                }
            }
            webClient.CancelAsync();
            webClient.Dispose();
            webClient.CancelAsync();
            webClient.Dispose();
            webClient.CancelAsync();
            webClient.Dispose();
            this.Dispose();
        }

        private void DownloadUI_Close(object sender, EventArgs e)
        {
            killandclose();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            killandclose();
        }
    }
}
