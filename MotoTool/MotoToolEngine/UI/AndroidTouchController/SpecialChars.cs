
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Franco28Tool.Engine
{
    [ComVisible(false)]

    public partial class SpecialChars : MaterialForm
    {
        private readonly MaterialSkinManager MaterialSkinManager;
        private SettingsMng oConfigMng = new SettingsMng();
        
        public SpecialChars()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            MaterialSkinManager = MaterialSkinManager.Instance;
            MaterialSkinManager.EnforceBackcolorOnAllComponents = true;
            MaterialSkinManager.AddFormToManage(this);
            InitializeComponent();
        }

        private void SpecialChars_Load(object sender, EventArgs e)
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

        private void buttonslash_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input text '/'");
        }

        private void buttondot_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input text '.'");
        }

        private void buttoncoma_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input text ','");
        }

        private void buttonspace_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input text ' '");
        }

        private void buttonexcla_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input text '!'");
        }

        private void buttonwat_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input text '?'");
        }

        private void Buttonnet_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input text '#'");
        }

        private void buttondolar_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input text '$'");
        }

        private void buttonpro_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input text '%'");
        }

        private void buttonstar_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input keyevent KEYCODE_STAR");
        }

        private void buttoncudzy_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe '\""'");
        }

        private void buttonapos_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input keyevent KEYCODE_APOSTROPHE");
        }

        private void buttonbackslash_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"""\platform -tools\adb.exe"" shell input text '\'");
        }

        private void buttonunder_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input text '_'");
        }

        private void buttonminus_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input text '-'");
        }

        private void buttonequal_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input text '='");
        }

        private void buttonleftbra_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input text '('");
        }

        private void buttonrightbra_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input text ')'");
        }

        private void buttoncolon_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input text ':'");
        }

        private void buttonsemi_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input text ';'");
        }

        private void Buttonat_Click(object sender, EventArgs e)
        {
            Interaction.Shell(Folders.MotoToolPath() + @"\platform-tools\adb.exe shell input text '@'");
        }

        private void ABC_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
