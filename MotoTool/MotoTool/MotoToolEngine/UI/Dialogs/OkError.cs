
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Media;
using System.Windows.Forms;

namespace Franco28Tool.Engine
{
    public partial class OkError : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private SettingsMng oConfigMng = new SettingsMng();

        public OkError()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            SystemSounds.Hand.Play();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            InitializeComponent();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void OkError_Load(object sender, EventArgs e)
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
        }
    }
}
