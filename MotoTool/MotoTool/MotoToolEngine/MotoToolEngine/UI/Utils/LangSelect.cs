
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Franco28Tool.Engine
{
    public partial class LangSelect : Form
    {
        private SettingsMng oConfigMng = new SettingsMng();

        public LangSelect()
        {
            InitializeComponent();
            this.label1.Text = LangEngine.seleclanguilabel;
        }

        private void LangSelect_Load(object sender, EventArgs e)
        {
            ThemeEngine();
            this.label1.Text = LangEngine.seleclanguilabel;
        }

        public void ThemeEngine()
        {
            oConfigMng.LoadConfig();

            if (oConfigMng.Config.ToolTheme == "Light")
            {
                panelChildForm.BackColor = Color.FromArgb(233, 245, 236);
                this.BackColor = Color.FromArgb(233, 245, 236);
                label1.ForeColor = Color.FromArgb(233, 245, 236);
                label2.ForeColor = Color.FromArgb(233, 245, 236);
                buttonClose.BackColor = Color.FromArgb(233, 245, 236);
                buttonClose.ForeColor = Color.FromArgb(233, 245, 236);
                panelLogo.BackColor = Color.FromArgb(0, 0, 200);
                panelLogo.ForeColor = Color.FromArgb(233, 245, 236);

                buttonBR.BackColor = Color.FromArgb(233, 245, 236);
                buttonBR.ForeColor = Color.FromArgb(23, 21, 21);
                buttonBR.FlatAppearance.MouseDownBackColor = Color.FromArgb(233, 200, 255);
                buttonBR.FlatAppearance.MouseOverBackColor = Color.FromArgb(233, 200, 255);
                buttonES.BackColor = Color.FromArgb(233, 245, 236);
                buttonES.ForeColor = Color.FromArgb(23, 21, 21);
                buttonES.FlatAppearance.MouseDownBackColor = Color.FromArgb(233, 200, 255);
                buttonES.FlatAppearance.MouseOverBackColor = Color.FromArgb(233, 200, 255);
                buttonEN.BackColor = Color.FromArgb(233, 245, 236);
                buttonEN.ForeColor = Color.FromArgb(23, 21, 21);
                buttonEN.FlatAppearance.MouseDownBackColor = Color.FromArgb(233, 200, 255);
                buttonEN.FlatAppearance.MouseOverBackColor = Color.FromArgb(233, 200, 255);
            }
        }

        public void visual_reLoad()
        {
            Dialogs.InfoDialog(oConfigMng.Config.ToolLang, LangEngine.seleclanguitoolrestart);
            string arguments = string.Empty;
            string[] args = Environment.GetCommandLineArgs();
            for (int i = 1; i < args.Length; i++) 
                arguments += args[i] + " ";
            this.Controls.Clear();
            this.Dispose();
            Application.Exit();
            System.Diagnostics.Process.Start(Application.ExecutablePath, arguments);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonEN_Click(object sender, EventArgs e)
        {
            LangEngine.ReadLang("en.xml", "en");
            oConfigMng.Config.ToolLang = "en";
            oConfigMng.SaveConfig();
            visual_reLoad();
        }

        private void buttonES_Click(object sender, EventArgs e)
        {
            LangEngine.ReadLang("es.xml", "es");
            oConfigMng.Config.ToolLang = "es";
            oConfigMng.SaveConfig();
            visual_reLoad();
        }

        private void buttonBR_Click(object sender, EventArgs e)
        {
            LangEngine.ReadLang("br.xml", "br");
            oConfigMng.Config.ToolLang = "br";
            oConfigMng.SaveConfig();
            visual_reLoad();
        }

        private void buttonRU_Click(object sender, EventArgs e)
        {
            LangEngine.ReadLang("ru.xml", "ru");
            oConfigMng.Config.ToolLang = "ru";
            oConfigMng.SaveConfig();
            visual_reLoad();
        }
    }
}
