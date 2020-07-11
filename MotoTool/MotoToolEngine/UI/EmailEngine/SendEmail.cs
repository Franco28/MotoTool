
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using System.Net.Mail;
using System.Runtime.InteropServices;
using log4net;
using System.Reflection;

namespace Franco28Tool.Engine
{
    [ComVisible(false)]

    public partial class SendEmail : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private SettingsMng oConfigMng = new SettingsMng();
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public SendEmail()
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

        private void SendEmailcs_Load(object sender, EventArgs e)
        {
            _log.Info("Request new firmware: Hey! complete all form. Here you can request: \n- New firmware updates \n- New firmwares \n- New device");
            cAppend("Request new firmware: Hey! complete all form. Here you can request: \n- New firmware updates \n- New firmwares \n- New device");
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
   
        protected void btnSent_Click(object sender, EventArgs e)
        {
            if (textBoxCodename.Text != string.Empty || textBoxChannel.Text != string.Empty || textBoxFirmware.Text != string.Empty || textBoxEmail.Text != string.Empty)
            {
                sendMailToAdmin(textBoxFirmware.Text, textBoxChannel.Text, textBoxCodename.Text, textBoxEmail.Text);
            }
            else
            {
                cAppend("Request new firmware: The boxes can't be empty!");
                Dialogs.WarningDialog("Send firmware request", "The boxes can't be empty!");
            }
        }

        protected void sendMailToAdmin(string firmware, string channel, string codename, string email)
        {
            try
            {
                _log.Debug("Sending new firmware request... ");
                cAppend("Sending new firmware request... ");
                MailMessage myMsg = new MailMessage();
                myMsg.From = new MailAddress("mototool28@gmail.com");
                myMsg.To.Add("mototool28@gmail.com");
                myMsg.Subject = "New Firmware Request ";
                myMsg.Body = "New Firmware Request Information\n\nFirmware: " + firmware + "\nDevice Channel: " + channel + "\nDevice Codename: " + codename + "\nUser Email: " + email;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("mototool28@gmail.com", "password :)");
                smtp.EnableSsl = true;
                smtp.Send(myMsg);
                _log.Debug("Sending new firmware request... {OK}");
                cAppend("Sending new firmware request... {OK}");
            }
            catch (Exception er)
            {
                cAppend("Sending new firmware request... {ERROR}");
                Dialogs.ErrorDialog("Cant send your request", "ERROR: " + er);
            }
        }

        protected void sendMailToAdmin2(string channel, string codename, string email, string devicecompletename)
        {
            try
            {
                cAppend("Sending new device request...");
                cAppend("Sending new device request... ");
                MailMessage myMsg = new MailMessage();
                myMsg.From = new MailAddress("mototool28@gmail.com");
                myMsg.To.Add("mototool28@gmail.com");
                myMsg.Subject = "New Device Request ";
                myMsg.Body = "New Device Request Information\n\nDevice Name: " + devicecompletename + "\nDevice Codename: " + codename + "\nDevice Channel: " + channel +  "\nUser Email: " + email;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("mototool28@gmail.com", "password :)");
                smtp.EnableSsl = true;
                smtp.Send(myMsg);
                cAppend("Sending new device request... {OK}");
                cAppend("Sending new device request... {OK}");
            }
            catch (Exception er)
            {
                cAppend("Sending new device request... {ERROR}");
                Dialogs.ErrorDialog("Cant send your request", "ERROR: " + er);
            }
        }

        protected void materialButton1_Click(object sender, EventArgs e)
        {
            if (textBoxDeviceCompleteName.Text != string.Empty || textBoxCodename.Text != string.Empty || textBoxChannel.Text != string.Empty || textBoxEmail.Text != string.Empty)
            {
                sendMailToAdmin2(textBoxChannel.Text, textBoxCodename.Text, textBoxEmail.Text, textBoxDeviceCompleteName.Text);
            }
            else
            {
                Dialogs.WarningDialog("Send device request", "The boxes can't be empty!");
            }
        }
    }
}
