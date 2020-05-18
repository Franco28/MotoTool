
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.ComponentModel;
using System.IO;

namespace Franco28Tool.Engine
{
    public partial class UnzipUI : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        public BackgroundWorker extractFile;
        private long fileSize;    //the size of the zip file
        private long extractedSizeTotal;    //the bytes total extracted
        private long compressedSize;    //the size of a single compressed file
        private string compressedFileName;    //the name of the file being extracted
        private SettingsMng oConfigMng = new SettingsMng();

        public UnzipUI()
        {
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            InitializeComponent();
            this.label4.Text = "Destination: ";
            this.label2.Text = "Extracting File: ";
            this.label3.Text = "Individual: ";
            this.label8.Text = "Total: ";
            this.label9.Text = "Progress";
            this.label5.Text = "File Path: ";
            this.label1.Text = "File Size: ";

            //Set the maximum vaue to int.MaxValue, thus, it could be more accurate
            progressBar_Individual.Maximum = int.MaxValue;
            progressBar_Total.Maximum = int.MaxValue;

            extractFile = new BackgroundWorker();
            extractFile.DoWork += ExtractFile_DoWork;
            extractFile.ProgressChanged += ExtractFile_ProgressChanged;
            extractFile.RunWorkerCompleted += ExtractFile_RunWorkerCompleted;
            extractFile.WorkerReportsProgress = true;
            extractFile.WorkerSupportsCancellation = true;
        }

        private void ExtractFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Set the maximum vaue to int.MaxValue because the process is completed
            progressBar_Individual.Value = int.MaxValue;
            progressBar_Total.Value = int.MaxValue;
            Dialogs.InfoDialog("INFO: Unzip", "The zip has been extracted well!");
            oConfigMng.Config.FirmwareExtracted = "1";
            oConfigMng.SaveConfig();
            this.Dispose();
        }

        private void ExtractFile_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            textBox_ExtractFile.Text = compressedFileName;

            progressBar_Individual.Value = e.ProgressPercentage;

            //calculate the totalPercent
            long totalPercent = ((long)e.ProgressPercentage * compressedSize + extractedSizeTotal * int.MaxValue) / fileSize;
            if (totalPercent > int.MaxValue)
                totalPercent = int.MaxValue;
            progressBar_Total.Value = (int)totalPercent;

            double totalBytescompressed = double.Parse(compressedSize.ToString());
            double totalBytesextracted = double.Parse(extractedSizeTotal.ToString());
            double percentage = totalBytescompressed + totalBytesextracted;

            label6.Text = percentage + " Bytes";
        }

        public void ExtractFile_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string fileName = textBox_FilePath.Text;
                string extractPath = textBox_ExtractionFolder.Text;

                //get the size of the zip file
                FileInfo fileInfo = new FileInfo(fileName);
                fileSize = fileInfo.Length;
                using (Ionic.Zip.ZipFile zipFile = Ionic.Zip.ZipFile.Read(fileName))
                {
                    //reset the bytes total extracted to 0
                    extractedSizeTotal = 0;
                    int fileAmount = zipFile.Count;
                    int fileIndex = 0;
                    zipFile.ExtractProgress += Zip_ExtractProgress;
                    foreach (Ionic.Zip.ZipEntry ZipEntry in zipFile)
                    {

                        if (fileInfo.Exists)
                        {
                            ZipEntry.Extract(extractPath, Ionic.Zip.ExtractExistingFileAction.OverwriteSilently);
                        }

                        fileIndex++;
                        compressedFileName = "(" + fileIndex.ToString() + "/" + fileAmount + "): " + ZipEntry.FileName;
                        //get the size of a single compressed file
                        compressedSize = ZipEntry.CompressedSize;
                        ZipEntry.Extract(extractPath, Ionic.Zip.ExtractExistingFileAction.OverwriteSilently);
                        //calculate the bytes total extracted
                        extractedSizeTotal += compressedSize;
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.DebugErrorLogs(ex);
                Dialogs.ErrorDialog("ERROR: UNZIP", ex.ToString());
            }
        }

        private void Zip_ExtractProgress(object sender, Ionic.Zip.ExtractProgressEventArgs e)
        {
            if (e.TotalBytesToTransfer > 0)
            {
                long percent = e.BytesTransferred * int.MaxValue / e.TotalBytesToTransfer;
                //Console.WriteLine("Indivual: " + percent);
                extractFile.ReportProgress((int)percent);
            }
        }

        public void UnzipUI_Closed(object sender, EventArgs e)
        {
            try
            {
                extractFile.CancelAsync();
                extractFile.Dispose();
                this.Dispose(Disposing);
            }
            catch (Exception er)
            {
                Logs.DebugErrorLogs(er);
                Dialogs.ErrorDialog("Error: Exit Process", "Exit failed: {UnzipUI} " + er.Message);
            }
        }      
    }
}
