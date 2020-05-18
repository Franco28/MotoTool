
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace Franco28Tool.Engine
{
    public partial class TWRPPermanent : MaterialForm
    {
        private SettingsMng oConfigMng = new SettingsMng();
        private readonly MaterialSkinManager materialSkinManager;
        public Form activeForm = null;

        public TWRPPermanent()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            SystemSounds.Asterisk.Play();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            InitializeComponent();
            download.Enabled = false;
        }

        private void TWRPPermanent_Load(object sender, EventArgs e)
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

            if (oConfigMng.Config.DeviceCodenmae == oConfigMng.Config.DeviceCodenmae)
            {
                LoadDeviceServer.CheckDevice(oConfigMng.Config.DeviceCodenmae + ".xml", oConfigMng.Config.DeviceCodenmae);
            }
            string fileName = @"C:\adb\TWRP\" + LoadDeviceServer.twrpinstallername;
            if (File.Exists(fileName))
            {
                DownloadsMng.TOOLDOWNLOAD(oConfigMng.Config.DeviceCodenmae, "/TWRPINSTALLER.xml", "TWRP");
                label1.Text = "Hey! "+ LoadDeviceServer.twrpinstallername + " its already downloaded, first you need to boot TWRP and then flash it!";
                cancel.Text = "OK";
                return;
            }
            else
            {
                download.Enabled = true;
            }
        }

        public void openChildForm2(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.Controls.Add(childForm);
            this.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public void downloadcall(string xmlname, string xmlpath)
        {
            var call = new DownloadUI();
            DownloadsMng.TOOLDOWNLOAD(oConfigMng.Config.DeviceCodenmae, xmlname, xmlpath);
            oConfigMng.Config.DeviceTWPRInfo = DownloadsMng.filename;
            oConfigMng.SaveConfig();
            openChildForm2(call);
        }

        private void download_Click(object sender, EventArgs e)
        {
            if (oConfigMng.Config.DeviceCodenmae == oConfigMng.Config.DeviceCodenmae)
            {
                LoadDeviceServer.CheckDevice(oConfigMng.Config.DeviceCodenmae + ".xml", oConfigMng.Config.DeviceCodenmae);
            }
            string fileName = @"C:\adb\TWRP\" + LoadDeviceServer.twrpinstallername;
            if (!File.Exists(fileName))
            {
                download.Enabled = true;
                downloadcall("/TWRPINSTALLER.xml", "TWRP");
                return;
            }
            else
            {
                DownloadsMng.TOOLDOWNLOAD(oConfigMng.Config.DeviceCodenmae, "/TWRPINSTALLER.xml", "TWRP");
                Dialogs.InfoDialog("TWRP Permanent", @"The file its already download at: " + DownloadsMng.SAVEPathname);
                return;
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            var download = new DownloadUI();
            if (download.webClient != null)
            {
                download.ProgressBar1.Hide();
                download.webClient.CancelAsync();
                download.closeform();
                this.Dispose();
            }
            else
            {
                this.Dispose();
            }
        }

        private void exit(object sender, FormClosedEventArgs e)
        {
            var download = new DownloadUI();
            if (download.webClient != null)
            {
                download.ProgressBar1.Hide();
                download.webClient.CancelAsync();
                download.closeform();
                this.Dispose();
            }
            else
            {
                this.Dispose();
            }
        }
    }
}
