using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Franco28Tool.Engine
{
    public partial class DebloatOthers : MaterialForm
    {

        private SettingsMng oConfigMng = new SettingsMng();
        private readonly MaterialSkinManager materialSkinManager;

        public DebloatOthers()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            InitializeComponent();
        }


        private void DebloatOthers_Load(object sender, EventArgs e)
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
            textBox3.Text = "Please, write the app package like this: -com.google.android.apps.translate-";
        }

        private void debloatrom_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
              /*  if (android.HasConnectedDevices)
                {
                    var builder = new StringBuilder("Debloat Apps Report:\n\n");
                    textBox3.Text = "Detecting device...";
                    Thread.Sleep(3000);
                    string devicesdetect = RegawMOD.Android.Fastboot.ExecuteFastbootCommand(RegawMOD.Android.Fastboot.FormFastbootCommand("fastboot devices"));
                    builder.AppendFormat(" -Task {Detect} " + devicesdetect);
                    textBox3.Text = "Detecting device..." + devicesdetect;
                    TextBox2.Text = "Removing App: " + textBox1.Text;
                    string debloatingapp = RegawMOD.Android.Adb.ExecuteAdbCommand(RegawMOD.Android.Adb.FormAdbCommand("shell pm uninstall -k --user 0 " + textBox1.Text));
                    builder.AppendFormat(" -Task {Debloat} " + debloatingapp);
                    TextBox2.Text = "Removing  App: " + textBox1.Text +  " OK!";
                    builder.AppendFormat(" - App debloated: " + textBox1.Text + "Operation completed sucessfully.\n");
                    var batchOperationResults = builder.ToString();
                    var mresult = MaterialMessageBox.Show(batchOperationResults, "Debloat App Operation");
                }
                else
                {
                    Strings.MSGBOXBootloaderWarning();
                    textBox3.Text = "Please, write the app package like this: -com.google.android.apps.translate-";
                } */
            }
            else
            {
                Dialogs.WarningDialog("Moto Debloater", "The box can't be empty!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
