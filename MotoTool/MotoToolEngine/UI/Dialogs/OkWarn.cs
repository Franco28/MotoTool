
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Franco28Tool.Engine
{
    [ComVisible(false)]

    public partial class OkWarn : MaterialForm
    {
        private readonly MaterialSkinManager MaterialSkinManager;
        private SettingsMng oConfigMng = new SettingsMng();

        public OkWarn()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            SystemSounds.Exclamation.Play();
            MaterialSkinManager = MaterialSkinManager.Instance;
            MaterialSkinManager.EnforceBackcolorOnAllComponents = true;
            MaterialSkinManager.AddFormToManage(this);
            InitializeComponent();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void OkWarn_Load(object sender, EventArgs e)
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
    }
}
