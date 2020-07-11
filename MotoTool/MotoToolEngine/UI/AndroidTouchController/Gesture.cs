
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Franco28Tool.Engine
{
    [ComVisible(false)]

    public partial class Gesture : MaterialForm
    {
        private readonly MaterialSkinManager MaterialSkinManager;
        private SettingsMng oConfigMng = new SettingsMng();
        private Point pos;
        public Point dest;
        public Point coordinates_1;
        public Point coordinates_2;
        public bool complete_flag;
        int resX = 0;
        int resY = 0;

        public Gesture()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            MaterialSkinManager = MaterialSkinManager.Instance;
            MaterialSkinManager.EnforceBackcolorOnAllComponents = true;
            MaterialSkinManager.AddFormToManage(this);
            InitializeComponent();
        }

        private void Gesture_Load(object sender, EventArgs e)
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
            timer1.Interval = 10;
            timer1.Start();
            Panel1.BackColor = Color.Red;
            TransparencyKey = Color.Red;
        }

        private static void MouseCheck()
        {
            var ge = new Gesture();
            ge.Label2.Text = Cursor.Position.X.ToString();
            ge.Label4.Text = Cursor.Position.Y.ToString();
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input keyevent KEYCODE_BACK");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input keyevent KEYCODE_HOME");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input keyevent KEYCODE_APP_SWITCH");
        }

        private void TimerT(object sender, EventArgs e)
        {
            int BorderWidth;
            BorderWidth = (int)((this.Width - this.ClientSize.Width) / (double)2);
            pos.X = Cursor.Position.X - this.Location.X - this.Panel1.Location.X - BorderWidth;
            pos.Y = Cursor.Position.Y - this.Location.Y - this.Panel1.Location.Y - (this.Height - this.ClientSize.Height - BorderWidth);

            if (pos.X > 0 && pos.X < Panel1.Width && pos.Y > 0 && pos.Y < Panel1.Height)
            {
                dest.X = pos.X / Panel1.Width * resX;
                dest.Y = pos.Y / Panel1.Height * resY;
                Label1.Text = pos.X.ToString();
                Label4.Text = pos.Y.ToString();
                Label2.Text = dest.X.ToString();
                Label3.Text = dest.Y.ToString();
            }
        }

        private void Changed(object sender, EventArgs e)
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

        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (complete_flag == true)
            {
                coordinates_2.X = dest.X;
                coordinates_2.Y = dest.Y;
                if (coordinates_1.X == coordinates_2.X & coordinates_1.Y == coordinates_2.Y)
                {
                    Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input tap " + coordinates_1.X.ToString() + " " + coordinates_1.Y.ToString());
                }
                else
                {
                    Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input swipe " + coordinates_1.X.ToString() + " " + coordinates_1.Y.ToString() + " " + coordinates_2.X.ToString() + " " + coordinates_2.Y.ToString());
                }
            }
        }

        private void Down(object sender, MouseEventArgs e)
        {
            // check if resolution selected
            if (this.ComboBox1.Text == "")
            {
                Interaction.MsgBox("Choose you're devices resolution");
                complete_flag = false;
            }
            else
            {
                // store mouse donwn coordinates
                coordinates_1.X = dest.X;
                coordinates_1.Y = dest.Y;
                complete_flag = true;
            }
        }

        private void CaputreChanged(object sender, EventArgs e)
        {
            complete_flag = false;
            coordinates_1.X = 0;
            coordinates_1.Y = 0;
            coordinates_2.X = 0;
            coordinates_2.Y = 0;
        }
    }
}
