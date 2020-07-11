
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AndroidCtrl.ADB;

namespace Franco28Tool.Engine
{
    [ComVisible(false)]

    public partial class MainTouch : MaterialForm
    {
        private readonly MaterialSkinManager MaterialSkinManager;
        private SettingsMng oConfigMng = new SettingsMng();

        public MainTouch()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            MaterialSkinManager = MaterialSkinManager.Instance;
            MaterialSkinManager.EnforceBackcolorOnAllComponents = true;
            MaterialSkinManager.AddFormToManage(this);
            InitializeComponent();
        }

        private void MainTouch_Load(object sender, EventArgs e)
        {
            oConfigMng.LoadConfig();
            if (oConfigMng.Config.ToolTheme == "light")
            {
                MaterialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            if (oConfigMng.Config.ToolTheme == "dark")
            {
                MaterialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            }
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            var ge = new Gesture();
            ge.Show();
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe reboot");
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe reboot recovery");
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell su -c " + @"poweroff");
        }

        private void Powerbtn_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input keyevent KEYCODE_POWER");
        }

        private void Center_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input keyevent KEYCODE_DPAD_CENTER");
        }

        private void Home_Click(object sender, EventArgs e)
        {
            ADB.Instance("device ID").ShellCmd(string.Format("input keyevent KEYCODE_HOME"));
            //Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input keyevent KEYCODE_HOME");
        }

        private void Apps_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input keyevent KEYCODE_APP_SWITCH");
        }

        private void bLeft_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input keyevent KEYCODE_DPAD_LEFT");
        }

        private void Up_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input keyevent KEYCODE_DPAD_UP");
        }

        private void Down_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input keyevent KEYCODE_DPAD_DOWN");
        }

        private void Buttonslash_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input text '/'");
        }

        private void Buttonenter_Click(object sender, EventArgs e)
        {
           Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input keyevent KEYCODE_ENTER");
        }

        private void Buttoncomma_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input keyevent KEYCODE_COMMA");
        }

        private void Buttonback_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input keyevent KEYCODE_DEL");
        }

        private void Buttondot_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input keyevent KEYCODE_PERIOD");
        }

        private void Buttonspace_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input keyevent KEYCODE_SPACE");
        }

        private void bsym_Click(object sender, EventArgs e)
        {
            var s = new SpecialChars();
            s.Show();
            this.Dispose();
        }

        private void Buttonw_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe input keyevent KEYCODE_" + Buttonw.Text);
        }

        private void Buttone_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe input keyevent KEYCODE_" + Buttone.Text);
        }

        private void Buttonr_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe input keyevent KEYCODE_" + Buttonr.Text);
        }

        private void Buttonq_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe input keyevent KEYCODE_" + Buttonq.Text);
        }

        private void Buttona_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe input keyevent KEYCODE_" + Buttona.Text);
        }

        private void Buttonz_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe input keyevent KEYCODE_" + Buttonz.Text);
        }

        private void Buttonx_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe input keyevent KEYCODE_" + Buttonx.Text);
        }

        private void Buttons_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe input keyevent KEYCODE_" + Buttons.Text);
        }

        private void Buttont_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe input keyevent KEYCODE_" + Buttont.Text);
        }

        private void Buttony_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe input keyevent KEYCODE_" + Buttony.Text);
        }

        private void Buttonu_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe input keyevent KEYCODE_" + Buttonu.Text);
        }

        private void Buttoni_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe input keyevent KEYCODE_" + Buttoni.Text);
        }

        private void Buttono_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe input keyevent KEYCODE_" + Buttono.Text);
        }

        private void Buttonp_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe input keyevent KEYCODE_" + Buttonp.Text);
        }

        private void Buttonl_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe input keyevent KEYCODE_" + Buttonl.Text);
        }

        private void Buttonk_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe input keyevent KEYCODE_" + Buttonk.Text);
        }

        private void Buttond_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe input keyevent KEYCODE_" + Buttond.Text);
        }

        private void Buttonc_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe input keyevent KEYCODE_" + Buttonc.Text);
        }

        private void Buttonf_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe input keyevent KEYCODE_" + Buttonf.Text);
        }

        private void Buttonv_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe input keyevent KEYCODE_" + Buttonv.Text);
        }

        private void Buttong_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe input keyevent KEYCODE_" + Buttong.Text);
        }

        private void Buttonn_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe input keyevent KEYCODE_" + Buttonn.Text);
        }

        private void Buttonb_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe input keyevent KEYCODE_" + Buttonb.Text);
        }

        private void Buttonm_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe input keyevent KEYCODE_" + Buttonm.Text);
        }

        private void Buttonj_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe input keyevent KEYCODE_" + Buttonj.Text);
        }

        private void Buttonh_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe input keyevent KEYCODE_" + Buttonh.Text);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input keyevent KEYCODE_" + Button5.Text);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input keyevent KEYCODE_" + Button6.Text);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input keyevent KEYCODE_" + Button7.Text);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input keyevent KEYCODE_" + Button8.Text);
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input keyevent KEYCODE_" + Button9.Text);
        }

        private void Button0_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input keyevent KEYCODE_" + Button0.Text);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input keyevent KEYCODE_" + Button4.Text);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input keyevent KEYCODE_" + Button3.Text);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input keyevent KEYCODE_" + Button2.Text);
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            switch (ComboBox1.Text)
            {
                case "1440x2560":
                    Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input swipe 562 1800 1440 1800");
                    break;
                case "1080x1920":
                    Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input swipe 722 1390 1340 1390");
                    break;
                case "800x1280":
                    Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input swipe 400 900 740 900");
                    break;
                case "768x1280":
                    Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input swipe 300 900 720 900");
                    break;
                case "720x1280":
                    Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input swipe 359 907 660 907");
                    break;
                case "720x1200":
                    Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input swipe 360 850 660 850");
                    break;
                case null:
                    MessageBox.Show("Choose you're devices resolution", "");
                    break;
            }
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            switch (ComboBox1.Text)
            {
                case "1440x2560":
                    Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input swipe 562 1800 1440 1800");
                break;
                case "1080x1920":
                    Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input swipe 722 1390 1340 1390");
                    break;
                case "800x1280":
                    Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input swipe 400 900 740 900");
                    break;
                case "768x1280":
                    Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input swipe 300 900 720 900");
                    break;
                case "720x1280":
                    Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input swipe 359 907 660 907");
                    break;
                case "720x1200":
                    Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input swipe 360 850 660 850");
                    break;
                    case null:
                    MessageBox.Show("Choose you're devices resolution", "");
                    break;
            }
        }

        private void bRight_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input keyevent KEYCODE_DPAD_RIGHT");
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell su -c " + @"rm /data/system/*.key");
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell su -c " + @"rm /data/system/*.db");
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell su -c " + @"rm /data/system/*.db-shm");
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell su -c " + @"rm /data/system/*.db-wal");
        }

        private void adb_Click(object sender, EventArgs e)
        {
            Interaction.Shell(@"cmd.exe /k cd " + Folders.MotoToolPath() + @"\platform-tools && color 02 && title adb path");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input keyevent KEYCODE_" + Button1.Text);
        }

        private void Buttoncaps_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input keyevent KEYCODE_CAPS_LOCK");
        }

        private void GoBack_Click(object sender, EventArgs e)
        {
            ADB.Instance("device ID").ShellCmd(string.Format("input keyevent KEYCODE_BACK"));
            //Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input keyevent KEYCODE_BACK");
        }

        private new void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input text '" + TextBox1.Text + "'");
                TextBox1.Clear();
            }
        }
    }
}
