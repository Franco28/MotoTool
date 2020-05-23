
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.IO;

namespace Franco28Tool.Engine
{
    public partial class ToolMaintenance : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private SettingsMng oConfigMng = new SettingsMng();

        public ToolMaintenance()
        {
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            InitializeComponent();
        }

        private void ToolMaintenance_Load(object sender, EventArgs e)
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

        private void contact_Click(object sender, EventArgs e)
        {
            if (InternetCheck.ConnectToInternet() == true)
            {
                if (File.Exists(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe") & File.Exists(@"C:\Program Files\Google\Chrome\Application\chrome.exe") == true)
                {
                    BrowserCheck.StartBrowser("MicrosoftEdge.exe", "https://beckhamtool.000webhostapp.com/");
                }
                else
                {
                    BrowserCheck.StartBrowser("Chrome.exe", "https://beckhamtool.000webhostapp.com/");
                }
            }
            else
            {
                Dialogs.ErrorDialog("Error: Network Lost", "Please check your internet connection!");
            }
        }
    }
}
