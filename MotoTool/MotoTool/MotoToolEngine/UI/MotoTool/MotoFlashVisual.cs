using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Franco28Tool.Engine
{
    public partial class MotoFlashVisual : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private SettingsMng oConfigMng = new SettingsMng();
        private int AppIndex;
        public Form activeForm = null;

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

        private delegate void SetRefreshCallback();

        private void SetRefresh()
        {
            if (this.InvokeRequired)
            {
                SetRefreshCallback d = new SetRefreshCallback(SetRefresh);
                base.Invoke(d);
            }
            else
                base.Refresh();
        }

        public new void Refresh()
        {
            SetRefresh();
        }

        private void MotoFlashVisual_Load(object sender, EventArgs e)
        {
            SetRefresh();
            oConfigMng.LoadConfig();

            if (oConfigMng.Config.ToolTheme == "light")
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            if (oConfigMng.Config.ToolTheme == "dark")
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            }
        }

        public void ReLoad()
        {
            SetRefresh();
            this.Controls.Clear();
            InitializeComponent();
        }

        private void MaterialButtonClose_Click(object sender, EventArgs e)
        {
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
            materialCard1.Controls.Add(childForm);
            materialCard1.Tag = childForm;
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

        public void RemoveApp(string appname)
        {
            if (AppIndex == 0)
            {
                labelDebloat.Text = "Please select an app!";
                Dialogs.WarningDialog("Moto Debloat", "Please select an app!");
                labelDebloat.Text = "";
                Invalidate();
            }
            else
            { /*
                if (android.HasConnectedDevices)
                {
                    var builder = new StringBuilder("Debloat Apps Report:\n\n");
                    materialLabel2.Text = "Removing App";
                    labelDebloat.Text = appname;
                    materialLabelDebugDebloat.Text = "Detecting device...";
                    Thread.Sleep(3000);
                    string devicesdetect = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot devices"));
                    builder.AppendFormat(" -Task {Detect} " + devicesdetect);
                    materialLabelDebugDebloat.Text = "Detecting device..." + devicesdetect;
                    labelDebloat.Text = "Removing: " + appname + " - App: N°" + AppIndex;
                    string debloatingapp = RegawMOD.Android.Adb.ExecuteAdbCommand(RegawMOD.Android.Adb.FormAdbCommand("shell pm uninstall -k --user 0 " + appname));
                    builder.AppendFormat(" -Task {Debloat} " + debloatingapp);
                    labelDebloat.Text = "Removing: " + appname + " - App: N°" + AppIndex + " OK!";
                    builder.AppendFormat(" - App debloated: " + appname +  "Operation completed sucessfully.\n", AppIndex);
                    var batchOperationResults = builder.ToString();
                    var mresult = MaterialMessageBox.Show(batchOperationResults, "Debloat App Operation");
                } 
                else
                {
                    Strings.MSGBOXBootloaderWarning();
                    Invalidate();
                } */
            }
            labelDebloat.Text = "";
            materialLabel2.Text = "App";
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
                labelDebloat.Text = "Unselected App: Amazon Shop";
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
                labelDebloat.Text = "Unselected App: Google Play Movies";
            }
        }

        private void materialSwitchGoogleInputmethod_CheckedChanged(object sender, EventArgs e)
        {
            GoogleInputmethod = materialSwitchGoogleInputmethod.Checked;
            if (materialSwitchGooglePlayMovies.Checked == true)
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
                labelDebloat.Text = "Unselected App: Google Input method";
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
                labelDebloat.Text = "Unselected App: Google Talkback";
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
                labelDebloat.Text = "Unselected App: Google Chrome";
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
                labelDebloat.Text = "Unselected App: Google Docs";
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
                labelDebloat.Text = "Unselected App: Google ArCore";
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
                labelDebloat.Text = "Unselected App: Google Lens";
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
                labelDebloat.Text = "Unselected App: Google Music";
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
                labelDebloat.Text = "Unselected App: Google Duo";
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
                labelDebloat.Text = "Unselected App: Google Translate";
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
                labelDebloat.Text = "Unselected App: Google YouTube";
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
                labelDebloat.Text = "Unselected App: Moto PRIP";
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
                labelDebloat.Text = "Unselected App: Moto OTA";
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
                labelDebloat.Text = "Unselected App: Moto Photo Editor";
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
                labelDebloat.Text = "Unselected App: Moto AR Stickers";
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
                labelDebloat.Text = "Unselected App: Moto Voice";
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
                labelDebloat.Text = "Unselected App: Moto Help";
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
                labelDebloat.Text = "Unselected App: Moto Camera";
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
                labelDebloat.Text = "Unselected App: Moto App Box";
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
                labelDebloat.Text = "Unselected App: Moto Face Unlock";
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
                labelDebloat.Text = "Unselected App: Moto Mods Store";
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
                labelDebloat.Text = "Unselected App: Moto Notifications";
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
                labelDebloat.Text = "Unselected App: Moto Voice";
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

        private void TextBox2_DragDrop(object sender, DragEventArgs e)
        {
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string s = "";

            foreach (string File in FileList)
                s = s + " " + File;
            TextBox2.Text = s;

            FileDragLabel.Text = "Checking device connection...";
/*
            if (android.HasConnectedDevices)
            {
                FileDragLabel.Text = "Checking device connection... OK";
                FileDragLabel.Text = "Copying " + " " + s + " " + " to /sdcard...";
                device.PushFile(s, "/sdcard");
                Dialogs.InfoDialog("Move Files: Info", "File copied" + " " + s + " " + " into /sdcard!");
            }
            else
            {
                FileDragLabel.Text = "Please plug your device on booted TWRP!";
                Dialogs.WarningDialog("Move Files: " + s, "Please plug your device on booted TWRP!");
                Invalidate();
            } */
        }
        #endregion MoveFilesToTWRP
    }
}