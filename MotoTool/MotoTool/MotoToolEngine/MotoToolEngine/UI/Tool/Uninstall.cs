
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace Franco28Tool.Engine
{
    public partial class Uninstall : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private SettingsMng oConfigMng = new SettingsMng();
        private BackgroundWorker bw = new BackgroundWorker();

        public Uninstall()
        {
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

        private void YES_Click(object sender, EventArgs e)
        {
            try
            {
                if (bw.IsBusy != true)
                {
                    bw.RunWorkerAsync();
                }
                Dialogs.WarningDialog("CHECK: Please select yes on uninstaller box!", "Uninstall Warning: Please select yes on uninstaller box!");
                Process unins = Process.Start(@"C:\Program Files\MotoTool\unins000.exe");
                int id = unins.Id;
                Process tempProc = Process.GetProcessById(id);
                this.Visible = false;
                tempProc.WaitForExit();
                Application.Exit();
            }
            catch (Exception ex)
            {
                Logs.DebugErrorLogs(ex);
                Dialogs.ErrorDialog("Error: Uninstall", "Uninstall failed: {0} " + ex.Message);
            }
        }

        private void NO_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Uninstall_Load(object sender, EventArgs e)
        {
            this.label6.Text = "Do you want to Uninstall the Tool?";
            this.label5.Text = "This will remove all the Tool and saved file!";

            if (bw.IsBusy != true)
            {
                bw.RunWorkerAsync();
            }
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

        private void Uninstall_Closed(object sender, EventArgs e)
        {
            this.Dispose(Disposing);
            try
            {
                Process myprocess = new Process();
                string arg = @"/c taskkill /f";
                try
                {
                    foreach (Process p in Process.GetProcessesByName("MotoTool"))
                    {
                        arg += " /pid " + p.Id;
                    }
                    ProcessStartInfo process = new ProcessStartInfo("cmd");
                    process.UseShellExecute = false;
                    process.CreateNoWindow = true;
                    process.Verb = "runas";
                    process.Arguments = arg;
                    Process.Start(process);
                }
                catch (Exception er)
                {
                    Logs.DebugErrorLogs(er);
                    Dialogs.ErrorDialog("Error: Killing Process", "Killing process failed: {0} " + er.Message);
                }
                Application.ExitThread();
            }
            catch (Exception er)
            {
                Logs.DebugErrorLogs(er);
                Dialogs.ErrorDialog("Error: Exit Process", "Exit failed: {ToolUI} " + er.Message);
            }
        }
    }
}
