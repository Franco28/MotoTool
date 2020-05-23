
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.IO;
using System.Windows.Forms;

namespace Franco28Tool.Engine
{
    public partial class Help : MaterialForm
    {
        private SettingsMng oConfigMng = new SettingsMng();
        private readonly MaterialSkinManager materialSkinManager;

        public Help()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            InitializeComponent();
        }

        private void Help_Load(object sender, EventArgs e)
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
            labeltitle.Text = " Help";
            label4.Text = "© 2019 - 2020 Franco28: A simple IT student - Argentina";
            if (oConfigMng.Config.ToolCompiled == oConfigMng.Config.ToolCompiled)
            {
                label2.Text = "MotoTool Compiled: " + oConfigMng.Config.ToolCompiled;
            }
            if (oConfigMng.Config.ToolVersion == oConfigMng.Config.ToolVersion)
            { 
                label3.Text = "MotoTool Version: " + " v" + oConfigMng.Config.ToolVersion;
            }
        }

        private void contact_Click(object sender, EventArgs e)
        {
            if (InternetCheck.ConnectToInternet() == true)
            {
                if (File.Exists(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe") & File.Exists(@"C:\Program Files\Google\Chrome\Application\chrome.exe") == true)
                {
                    BrowserCheck.StartBrowser("MicrosoftEdge.exe", "https://t.me/francom28");
                }
                else
                {
                    BrowserCheck.StartBrowser("Chrome.exe", "https://t.me/francom28");
                }
            }
            else
            {
                Dialogs.ErrorDialog("Error: "+ LangEngine.internetchecktitle, LangEngine.internetcheck);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MaterialMessageBox.Show(@"Now this is private :/", "MotoTool Source");
        }

        private void howtouseit_Click(object sender, EventArgs e)
        {
            if (InternetCheck.ConnectToInternet() == true)
            {
                if (File.Exists(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe") & File.Exists(@"C:\Program Files\Google\Chrome\Application\chrome.exe") == true)
                {
                    BrowserCheck.StartBrowser("MicrosoftEdge.exe", "https://github.com/Franco28/MotoTool#getting-started-read-all-please");
                }
                else
                {
                    BrowserCheck.StartBrowser("Chrome.exe", "https://github.com/Franco28/MotoTool#getting-started-read-all-please");
                }
            }
            else
            {
                Dialogs.ErrorDialog("Error: " + LangEngine.internetchecktitle, LangEngine.internetcheck);
            }
        }

        private void Help_Disposed(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.Refresh();
            base.Dispose(Disposing);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
