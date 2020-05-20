
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Franco28Tool.Engine
{
    public partial class TWRPBackup : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private SettingsMng oConfigMng = new SettingsMng();

        public TWRPBackup()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            InitializeComponent();
        }

        private void showImage1()
        {
            var imgtemp = new Bitmap(Franco28Tool.Engine.Properties.Resources.bk1);
            pictureBox1.Image = imgtemp;
        }

        private void showImage2()
        {
            var imgtemp = new Bitmap(Franco28Tool.Engine.Properties.Resources.rt2);
            pictureBox2.Image = imgtemp;
        }

        private void showImage3()
        {
            var imgtemp = new Bitmap(Franco28Tool.Engine.Properties.Resources.rt1);
            pictureBox3.Image = imgtemp;
        }

        private void TWRPBackup_Load(object sender, EventArgs e)
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
            materialLabel38.Text =
                "1. Boot your device into TWRP \n " +
                "2. Go to backup option and select Persist and EFS \n " +
                "3. Then slide it and it's done!";
            showImage1();
            showImage2();
            showImage3();
        }

        private void materialButtonClosecard_Click(object sender, EventArgs e)
        {
            materialCardBackup.Dispose();
        }
    }
}
