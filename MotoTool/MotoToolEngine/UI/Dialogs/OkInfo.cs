
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Franco28Tool.Engine
{
    public partial class OkInfo : MaterialForm
    { 
        private readonly MaterialSkinManager materialSkinManager;
        private SettingsMng oConfigMng = new SettingsMng();

        public OkInfo()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            SystemSounds.Asterisk.Play();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            InitializeComponent();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void OkInfo_Load(object sender, EventArgs e)
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
            Graphics gfx = this.label1.CreateGraphics();
            Font stringFont = new Font("Roboto Medium", 20, FontStyle.Bold);
            SizeF stringSize = new SizeF();
            stringSize = gfx.MeasureString(this.label1.Text, stringFont);
            this.label1.Size = new Size((int)stringSize.Width, (int)stringSize.Height);
            this.label1.TextAlign = ContentAlignment.MiddleLeft;
        }
    }
}
