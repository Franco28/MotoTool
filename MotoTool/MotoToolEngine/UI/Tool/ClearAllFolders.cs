
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Franco28Tool.Engine
{
    [ComVisible(false)]
    public partial class ClearAllFolders : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private SettingsMng oConfigMng = new SettingsMng();
        private BackgroundWorker bw = new BackgroundWorker();

        public ClearAllFolders()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            System.Media.SystemSounds.Asterisk.Play();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            InitializeComponent();
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        }

        private void ClearAllFolders_Load(object sender, EventArgs e)
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
            this.label5.Text = "This will remove all files from C:\\adb\\ folder!";
            label6.Text = "Do you want to clear all the folders? You will remove all files except for the important ones. Folder Size: " + Folders.GetDirectorySize(@"C:\adb") + "MB";
            if (bw.IsBusy != true)
            {
                bw.RunWorkerAsync();
            }
        }

        private void NO_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void YES_Click(object sender, EventArgs e)
        {
            Folders.ClearFolders();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            try
            {
                for (int i = 1; (i <= 10); i++)
                {
                    if ((worker.CancellationPending == true))
                    {
                        e.Cancel = true;
                        break;
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(300);
                        worker.ReportProgress((i * 10));
                    }
                }
            }
            catch (Exception er)
            {
                Logs.DebugErrorLogs(er);
                Dialogs.ErrorDialog("MotoTool Error", er.Message);
            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 10)
            {
                this.labelblue.Text = " ";
                this.labelred.Text = " ";
            }
            if (e.ProgressPercentage == 20)
            {
                this.labelblue.Text = ". ";
                this.labelred.Text = ". ";
            }
            if (e.ProgressPercentage == 30)
            {
                this.labelblue.Text = ". . ";
                this.labelred.Text = ". . ";
            }
            if (e.ProgressPercentage == 40)
            {
                this.labelblue.Text = ". . .";
                this.labelred.Text = ". . .";
            }
            if (e.ProgressPercentage == 50)
            {
                this.labelblue.Text = " ";
                this.labelred.Text = " ";
            }
            if (e.ProgressPercentage == 60)
            {
                this.labelblue.Text = ". ";
                this.labelred.Text = ". ";
            }
            if (e.ProgressPercentage == 70)
            {
                this.labelblue.Text = ". .";
                this.labelred.Text = ". . ";
            }
            if (e.ProgressPercentage == 80)
            {
                this.labelblue.Text = ". . .";
                this.labelred.Text = ". . .";
            }
            if (e.ProgressPercentage == 90)
            {
                this.labelblue.Text = " ";
                this.labelred.Text = " ";
            }
            if (e.ProgressPercentage == 100)
            {
                this.labelblue.Text = ". ";
                this.labelred.Text = ". ";
            }
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (bw.IsBusy != true)
            {
                bw.RunWorkerAsync();
            }
        }

        private void labelblue_Click(object sender, EventArgs e)
        {

        }
    }
}
