
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Globalization;
using System.Resources;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Franco28Tool.Engine
{
    [ComVisible(false)]

    public partial class LangSelect : MaterialForm
    {
        public MaterialSkinManager materialSkinManager;
        private SettingsMng oConfigMng = new SettingsMng();
        public CultureInfo cul;
        public ResourceManager res_man;

        public LangSelect()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            InitializeComponent();
        }

        public void cAppend(string message)
        {
            this.Invoke((Action)delegate
            {
                console.AppendText(string.Format("\n{0} : {1}", DateTime.Now, message));
                console.ScrollToCaret();
            });
        }

        private async void materialButtonES_Click(object sender, EventArgs e)
        {
            cAppend("Ajustando idioma español... por favor espere...");
            await Task.Run(() =>
            {
                if (oConfigMng.Config.ToolLang == "es")
                {
                    cAppend("You already have ES as your main lang!");
                    Dialogs.InfoDialog("MotoTool Lang", "You already have ES as your main lang!");
                    return;
                }
                else
                {
                    oConfigMng.LoadConfig();
                    res_man = new ResourceManager("Franco28Tool.Engine.Resources.lang.Res", typeof(MainForm).Assembly);
                    oConfigMng.Config.ToolLang = "es";
                    cul = CultureInfo.CreateSpecificCulture("es");
                    oConfigMng.SaveConfig();
                    Application.ExitThread();
                    new Thread(() => new MainForm().ShowDialog()).Start();
                    Thread.Sleep(2000);
                    this.Dispose();
                }
            });
        }

        private async void materialButtonEnglish_Click(object sender, EventArgs e)
        {
            cAppend("Setting english language... please wait...");
            await Task.Run(() =>
            {
                if (oConfigMng.Config.ToolLang == "en")
                {
                    cAppend("You already have EN as your main lang!");
                    Dialogs.InfoDialog("MotoTool Lang", "You already have EN as your main lang!");
                    return;
                }
                else
                {
                    oConfigMng.LoadConfig();
                    res_man = new ResourceManager("Franco28Tool.Engine.Resources.lang.Res", typeof(MainForm).Assembly);
                    oConfigMng.Config.ToolLang = "en";
                    cul = CultureInfo.CreateSpecificCulture("en");
                    oConfigMng.SaveConfig();
                    Thread.Sleep(2000);
                    Application.ExitThread();
                    new Thread(() => new MainForm().ShowDialog()).Start();
                    this.Dispose();
                }
            });
        }

        private void cancel(object sender, EventArgs e)
        {
            Application.ExitThread();
            new Thread(() => new MainForm().ShowDialog()).Start();
            this.Dispose();
        }

        private void LangSelect_Load(object sender, EventArgs e)
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
            cAppend("Please select your language");
        }
    }
}