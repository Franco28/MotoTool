
using AndroidCtrl;
using AndroidCtrl.ADB;
using AndroidCtrl.Fastboot;
using AndroidCtrl.Tools;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Franco28Tool.Engine
{
    public partial class MotoFlashVisual : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private SettingsMng oConfigMng = new SettingsMng();
        private int AppIndex;
        public Form activeForm = null;
        IDDeviceState state = General.CheckDeviceState(ADB.Instance().DeviceID);

        #region MotoDebloatVar
        public bool AmazonShopp { get; private set; }
        public bool MotoVoiceNormal { get; private set; }
        public bool GooglePlayMovies { get; private set; }
        public bool GoogleInputmethod { get; private set; }
        public bool GoogleTalkback { get; private set; }
        public bool GoogleChrome { get; private set; }
        public bool GoogleDocs { get; private set; }
        public bool GoogleMusic { get; private set; }
        public bool GoogleDuo { get; private set; }
        public bool GoogleTranslate { get; private set; }
        public bool GoogleYouTube { get; private set; }
        public bool MotoPRIP { get; private set; }
        public bool MotoOTA { get; private set; }
        public bool MotoPhotoEditor { get; private set; }
        public bool MotoARStickers { get; private set; }
        public bool MotoHelp { get; private set; }
        public bool MotoCamera { get; private set; }
        public bool MotoFaceUnlock { get; private set; }
        public bool MotoModsStore { get; private set; }
        public bool MotoVoice { get; private set; }
        public bool MotoAppBox { get; private set; }
        public bool GoogleArCore { get; private set; }
        public bool GoogleLens { get; private set; }
        public bool MotoNotifications { get; private set; }
        #endregion MotoDebloatVar

        public MotoFlashVisual()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            InitializeComponent();
            TextBox2.AllowDrop = true;
            TextBox2.DragEnter += new DragEventHandler(TextBox2_DragEnter);
            TextBox2.DragDrop += new DragEventHandler(TextBox2_DragDrop);
        }

        public void cAppend(string message)
        {
            this.Invoke((Action)delegate
            {
                consoleMFTT.AppendText(string.Format("\n{0} : {1}", DateTime.Now, message));
                consoleMFTT.ScrollToCaret();
            });
        }

        public void cAppendDebloat(string message)
        {
            this.Invoke((Action)delegate
            {
                consoleDebloat.AppendText(string.Format("\n{0} : {1}", DateTime.Now, message));
                consoleDebloat.ScrollToCaret();
            });
        }

        private async void MotoFlashVisual_Load(object sender, EventArgs e)
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
            cAppend("STARTING FLASH TOOL: Starting DeviceDetectionService...");
            cAppendDebloat("STARTING FLASH TOOL: Starting DeviceDetectionService...");
            await Task.Run(() => DeviceDetectionService());
            cAppend("STARTING FLASH TOOL: Starting DeviceDetectionService... {OK}");
            cAppendDebloat("STARTING FLASH TOOL: Starting DeviceDetectionService... {OK}");
        }

        private void SetDeviceList()
        {
            string active = String.Empty;

            List<DataModelDevicesItem> adbDevices = ADB.Devices();
            List<DataModelDevicesItem> fastbootDevices = Fastboot.Devices();

            foreach (DataModelDevicesItem device in adbDevices)
            {
                this.Invoke((Action)delegate
                {
                    cAppend("Device: Online! - ADB");
                    cAppend("Device Codename: " + LoadDeviceServer.devicecodename);
                    cAppend("Mode: " + state);
                    cAppendDebloat("Device: Online! - ADB");
                    cAppendDebloat("Device Codename: " + LoadDeviceServer.devicecodename);
                    cAppendDebloat("Mode: " + state);
                });
            }
            foreach (DataModelDevicesItem device in fastbootDevices)
            {
                this.Invoke((Action)delegate
                {
                    cAppend("Device: Online! - FASTBOOT");
                    cAppend("Device Codename: " + LoadDeviceServer.devicecodename);
                    cAppend("Mode: " + state);
                    cAppendDebloat("Device: Online! - FASTBOOT");
                    cAppendDebloat("Device Codename: " + LoadDeviceServer.devicecodename);
                    cAppendDebloat("Mode: " + state);
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

        private void MaterialButtonClose_Click(object sender, EventArgs e)
        {
            oConfigMng.LoadConfig();
            if (oConfigMng.Config.Autosavelogs == "true")
            {
                cAppend("EXIT: Saving FlashTool logs...");
                cAppendDebloat("EXIT: Saving FlashTool logs...");
                try
                {
                    string filePath = @"C:\adb\.settings\Logs\FlashToolMoveFilesToTWRP.txt";
                    string filePath2 = @"C:\adb\.settings\Logs\FlashToolDebloat.txt";
                    cAppend("EXIT: Saving FlashTool logs... {OK}");
                    cAppendDebloat("EXIT: Saving FlashTool logs... {OK}");
                    consoleMFTT.SaveFile(filePath, RichTextBoxStreamType.PlainText);
                    consoleDebloat.SaveFile(filePath2, RichTextBoxStreamType.PlainText);
                }
                catch (Exception ex)
                {
                    Logs.DebugErrorLogs(ex);
                    cAppend("EXIT: Saving FlashTool logs... {ERROR}");
                    cAppendDebloat("EXIT: Saving FlashTool logs... {ERROR}");
                    Dialogs.ErrorDialog("An error has occured while attempting to save the output...", ex.ToString());
                }
            }
            this.Dispose();
        }

        #region MotoFlash
        public void openChildFormMotoFlash(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMotoFlash.Controls.Add(childForm);
            panelMotoFlash.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void materialButtonMotoFlash_Click(object sender, EventArgs e)
        {
            openChildFormMotoFlash(new MotoFlash());
        }
        #endregion MotoFlash

        #region MotoDebloat

        public void openChildFormDebloatOthers(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Top;
            tabPage2.Controls.Add(childForm);
            tabPage2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public void increase()
        {
            AppIndex++;
            if (AppIndex > 25)
                AppIndex = 0;
        }

        public void dincrease()
        {
            AppIndex--;
            if (AppIndex > 25)
                AppIndex = 0;
        }

        public async void RemoveApp(string appname)
        {
            if (AppIndex == 0)
            {
                cAppendDebloat("MOTO DEBLOAT: Please select an app!");
                Dialogs.WarningDialog("Moto Debloat", "Please select an app!");
                Invalidate();
            }
            else
            {
                if (IDDeviceState.DEVICE == state)
                {
                    await Task.Run(() => DeviceDetectionService());
                    cAppend("MOTO DEBLOAT: Waiting for device...");
                    await Task.Run(() => ADB.WaitForDevice());
                    cAppendDebloat("MOTO DEBLOAT: Removing app: " + appname + "...");
                    await Task.Run(() => ADB.Instance().Execute("shell pm uninstall -k --user 0 " + appname));
                    cAppendDebloat("MOTO DEBLOAT: Removing app: " + appname + " {OK}");
                } 
                else
                {
                    cAppendDebloat("MOTO DEBLOAT: Your device is in the wrong state. " + state);
                    Strings.MSGBOXBootloaderWarning();
                    Invalidate();
                } 
            }
            Invalidate();
        }

        private void materialSwitchAmazonShop_CheckedChanged(object sender, EventArgs e)
        {
            AmazonShopp = materialSwitchAmazonShop.Checked;
            if (materialSwitchAmazonShop.Checked == true)
            {
                increase();
                RemoveApp("com.amazon.mShop.android.shopping");
                RemoveApp("com.amazon.appmanager");
            }
            else
            {
                dincrease();
                cAppendDebloat("MOTO DEBLOAT UNSELECTED APP: Amazon Shop");
            }
        }

        private void materialSwitchGooglePlayMovies_CheckedChanged(object sender, EventArgs e)
        {
            GooglePlayMovies = materialSwitchGooglePlayMovies.Checked;
            if (materialSwitchGooglePlayMovies.Checked == true)
            {
                increase();
                RemoveApp("com.google.android.music");
            }
            else
            {
                dincrease();
                cAppendDebloat("MOTO DEBLOAT UNSELECTED APP: Google Play Movies");
            }
        }

        private void materialSwitchGoogleInputmethod_CheckedChanged(object sender, EventArgs e)
        {
            GoogleInputmethod = materialSwitchGoogleInputmethod.Checked;
            if (materialSwitchGoogleInputmethod.Checked == true)
            {
                increase();
                RemoveApp("com.google.android.inputmethod.korean");
                RemoveApp("com.google.android.apps.inputmethod.zhuyin");
                RemoveApp("com.google.android.inputmethod.pinyin");
                RemoveApp("com.google.android.inputmethod.japanese");
                RemoveApp("com.google.android.inputmethod.latin");
            }
            else
            {
                dincrease();
                cAppendDebloat("MOTO DEBLOAT UNSELECTED APP: Google Input method (korean, zhuyin, pinyin, japanese and latin)");
            }
        }

        private void materialSwitchGoogleTalkback_CheckedChanged(object sender, EventArgs e)
        {
            GoogleTalkback = materialSwitchGoogleTalkback.Checked;
            if (materialSwitchGoogleTalkback.Checked == true)
            {
                increase();
                RemoveApp("com.google.android.marvin.talkback");
            }
            else
            {
                dincrease();
                cAppendDebloat("MOTO DEBLOAT UNSELECTED APP: Google Talkback");
            }
        }

        private void materialSwitchGoogleChrome_CheckedChanged(object sender, EventArgs e)
        {
            GoogleChrome = materialSwitchGoogleChrome.Checked;
            if (materialSwitchGoogleChrome.Checked == true)
            {
                increase();
                RemoveApp("com.android.chrome");
            }
            else
            {
                dincrease();
                cAppendDebloat("MOTO DEBLOAT UNSELECTED APP: Google Chrome");
            }
        }

        private void materialSwitchGoogleDocs_CheckedChanged(object sender, EventArgs e)
        {
            GoogleDocs = materialSwitchGoogleDocs.Checked;
            if (materialSwitchGoogleDocs.Checked == true)
            {
                increase();
                RemoveApp("com.google.android.apps.docs");
            }
            else
            {
                dincrease();
                cAppendDebloat("MOTO DEBLOAT UNSELECTED APP: Google Docs and Google Drive");
            }
        }

        private void materialSwitchGoogleArCore_CheckedChanged(object sender, EventArgs e)
        {
            GoogleArCore = materialSwitchGoogleArCore.Checked;
            if (materialSwitchGoogleArCore.Checked == true)
            {
                increase();
                RemoveApp("com.google.ar.core");
            }
            else
            {
                dincrease();
                cAppendDebloat("MOTO DEBLOAT UNSELECTED APP: Google ArCore");
            }
        }

        private void materialSwitchGoogleLens_CheckedChanged(object sender, EventArgs e)
        {
            GoogleLens = materialSwitchGoogleLens.Checked;
            if (materialSwitchGoogleLens.Checked == true)
            {
                increase();
                RemoveApp("com.google.ar.lens");
            }
            else
            {
                dincrease();
                cAppendDebloat("MOTO DEBLOAT UNSELECTED APP: Google Lens");
            }
        }

        private void materialSwitchGoogleMusic_CheckedChanged(object sender, EventArgs e)
        {
            GoogleMusic = materialSwitchGoogleMusic.Checked;
            if (materialSwitchGoogleMusic.Checked == true)
            {
                increase();
                RemoveApp("com.google.android.music");
            }
            else
            {
                dincrease();
                cAppendDebloat("MOTO DEBLOAT UNSELECTED APP: Google Music");
            }
        }

        private void materialSwitchGoogleDuo_CheckedChanged(object sender, EventArgs e)
        {
            GoogleDuo = materialSwitchGoogleDuo.Checked;
            if (materialSwitchGoogleDuo.Checked == true)
            {
                increase();
                RemoveApp("com.google.android.apps.tachyon");
            }
            else
            {
                dincrease();
                cAppendDebloat("MOTO DEBLOAT UNSELECTED APP: Google Duo");
            }
        }

        private void materialSwitchGoogleTranslate_CheckedChanged(object sender, EventArgs e)
        {
            GoogleTranslate = materialSwitchGoogleTranslate.Checked;
            if (materialSwitchGoogleTranslate.Checked == true)
            {
                increase();
                RemoveApp("com.google.android.apps.translate");
            }
            else
            {
                dincrease();
                cAppendDebloat("MOTO DEBLOAT UNSELECTED APP: Google Translate");
            }
        }

        private void materialSwitchGoogleYouTube_CheckedChanged(object sender, EventArgs e)
        {
            GoogleYouTube = materialSwitchGoogleYouTube.Checked;
            if (materialSwitchGoogleYouTube.Checked == true)
            {
                increase();
                RemoveApp("com.google.android.youtube");
            }
            else
            {
                dincrease();
                cAppendDebloat("MOTO DEBLOAT UNSELECTED APP: Google YouTube");
            }
        }

        private void materialSwitchMotoPRIP_CheckedChanged(object sender, EventArgs e)
        {
            MotoPRIP = materialSwitchMotoPRIP.Checked;
            if (materialSwitchMotoPRIP.Checked == true)
            {
                increase();
                RemoveApp("com.google.android.youtube");
            }
            else
            {
                dincrease();
                cAppendDebloat("MOTO DEBLOAT UNSELECTED APP: Moto PRIP");
            }
        }

        private void materialSwitchMotoOTA_CheckedChanged(object sender, EventArgs e)
        {
            MotoOTA = materialSwitchMotoOTA.Checked;
            if (materialSwitchMotoOTA.Checked == true)
            {
                increase();
                RemoveApp("com.motorola.ccc.ota");
            }
            else
            {
                dincrease();
                cAppendDebloat("MOTO DEBLOAT UNSELECTED APP: Moto OTA");
            }
        }

        private void materialSwitchMotoPhotoEditor_CheckedChanged(object sender, EventArgs e)
        {
            MotoPhotoEditor = materialSwitchMotoPhotoEditor.Checked;
            if (materialSwitchMotoPhotoEditor.Checked == true)
            {
                increase();
                RemoveApp("com.motorola.photoeditor");
            }
            else
            {
                dincrease();
                cAppendDebloat("MOTO DEBLOAT UNSELECTED APP: Moto Photo Editor");
            }
        }

        private void materialSwitchMotoARStickers_CheckedChanged(object sender, EventArgs e)
        {
            MotoARStickers = materialSwitchMotoARStickers.Checked;
            if (materialSwitchMotoARStickers.Checked == true)
            {
                increase();
                RemoveApp("com.motorola.arselfie");
            }
            else
            {
                dincrease();
                cAppendDebloat("MOTO DEBLOAT UNSELECTED APP: Moto AR Stickers");
            }
        }

        private void materialSwitchMotoVoiceNormal_CheckedChanged(object sender, EventArgs e)
        {
            MotoVoiceNormal = materialSwitchMotoVoiceNormal.Checked;
            if (materialSwitchMotoVoiceNormal.Checked == true)
            {
                increase();
                RemoveApp("com.motorola.audiomonitor");
            }
            else
            {
                dincrease();
                cAppendDebloat("MOTO DEBLOAT UNSELECTED APP: Moto Voice");
            }
        }

        private void materialSwitchMotoHelp_CheckedChanged(object sender, EventArgs e)
        {
            MotoHelp = materialSwitchMotoHelp.Checked;
            if (materialSwitchMotoHelp.Checked == true)
            {
                increase();
                RemoveApp("com.motorola.genie");
            }
            else
            {
                dincrease();
                cAppendDebloat("MOTO DEBLOAT UNSELECTED APP: Moto Help");
            }
        }

        private void materialSwitchMotoCamera_CheckedChanged(object sender, EventArgs e)
        {
            MotoCamera = materialSwitchMotoCamera.Checked;
            if (materialSwitchMotoCamera.Checked == true)
            {
                increase();
                RemoveApp("com.motorola.camera2");
            }
            else
            {
                dincrease();
                cAppendDebloat("MOTO DEBLOAT UNSELECTED APP: Moto Camera");
            }
        }

        private void materialSwitchMotoAppBox_CheckedChanged(object sender, EventArgs e)
        {
            MotoAppBox = materialSwitchMotoAppBox.Checked;
            if (materialSwitchMotoAppBox.Checked == true)
            {
                increase();
                RemoveApp("com.motorola.brapps");
            }
            else
            {
                dincrease();
                cAppendDebloat("MOTO DEBLOAT UNSELECTED APP: Moto App Box");
            }
        }

        private void materialSwitchMotoFaceUnlock_CheckedChanged(object sender, EventArgs e)
        {
            MotoFaceUnlock = materialSwitchMotoFaceUnlock.Checked;
            if (materialSwitchMotoFaceUnlock.Checked == true)
            {
                increase();
                RemoveApp("com.motorola.faceunlock");
            }
            else
            {
                dincrease();
                cAppendDebloat("MOTO DEBLOAT UNSELECTED APP: Moto Face Unlock");
            }
        }

        private void materialSwitchMotoModsStore_CheckedChanged(object sender, EventArgs e)
        {
            MotoModsStore = materialSwitchMotoModsStore.Checked;
            if (materialSwitchMotoModsStore.Checked == true)
            {
                increase();
                RemoveApp("com.motorola.modstore");
            }
            else
            {
                dincrease();
                cAppendDebloat("MOTO DEBLOAT UNSELECTED APP: Moto Mods Store");
            }
        }

        private void materialSwitchMotoNotifications_CheckedChanged(object sender, EventArgs e)
        {
            MotoNotifications = materialSwitchMotoNotifications.Checked;
            if (materialSwitchMotoNotifications.Checked == true)
            {
                increase();
                RemoveApp("com.motorola.ccc.notification");
            }
            else
            {
                dincrease();
                cAppendDebloat("MOTO DEBLOAT UNSELECTED APP: Moto Notifications");
            }
        }

        private void materialSwitchMotoVoice_CheckedChanged(object sender, EventArgs e)
        {
            MotoVoice = materialSwitchMotoVoice.Checked;
            if (materialSwitchMotoVoice.Checked == true)
            {
                increase();
                RemoveApp("com.motorola.voiceauthtrustagent");
            }
            else
            {
                dincrease();
                cAppendDebloat("MOTO DEBLOAT UNSELECTED APP: Moto Voice");
            }
        }

        private void materialButtonDebloatOthers_Click(object sender, EventArgs e)
        {
            openChildFormDebloatOthers(new DebloatOthers());
        }
        #endregion MotoDebloat

        #region MoveFilesToTWRP
        private void TextBox2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private async void TextBox2_DragDrop(object sender, DragEventArgs e)
        {
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string s = "";

            foreach (string File in FileList)
                s = s + " " + File;
            TextBox2.Text = s;

            if (IDDeviceState.RECOVERY == state)
            {
                cAppend("Copying " + " " + s + " " + " to /sdcard...");
                await Task.Run(() => ADB.Instance().Push(s, "/sdcard"));
                Dialogs.InfoDialog("Move Files: Info", "File copied" + " " + s + " " + " into /sdcard!");
            }
            else
            {
                Thread.Sleep(1000);
                cAppend("MOVE FILES TO TWRP: Your device is in the wrong state. Please put your device in recovery mode.\n");
                Dialogs.WarningDialog("Move Files: " + s, "Please plug your device on booted TWRP!");
                Invalidate();
            } 
        }
        #endregion MoveFilesToTWRP
    }
}