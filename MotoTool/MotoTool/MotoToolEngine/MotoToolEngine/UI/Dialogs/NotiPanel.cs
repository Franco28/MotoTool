
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace Franco28Tool.Engine
{
    public partial class NotiPanel : MaterialForm
    {
        private SettingsMng oConfigMng = new SettingsMng();
        private readonly MaterialSkinManager materialSkinManager;

        public NotiPanel()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            InitializeComponent();
            offline.Hide();
            offline.Visible = false;
        }

        private void NotiPanel_Load(object sender, EventArgs e)
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

            if (InternetCheck.ConnectToInternet() == false)
            {
                offline.Show();
                offline.Visible = true;
            }
            else
            {
                offline.Hide();
                offline.Visible = false;
            }
        }

        private void offline_Click(object sender, EventArgs e)
        {
            oConfigMng.Config.ToolInternet = "Offline";
            oConfigMng.SaveConfig();
            this.Dispose();
            Application.Restart();
        }
    }
}
