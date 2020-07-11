
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Reflection;
using log4net;

namespace Franco28Tool.Engine
{
    [ComVisible(false)]
    public partial class Contact : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private SettingsMng oConfigMng = new SettingsMng();
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Contact()
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

        private void Contact_Load(object sender, EventArgs e)
        {
            _log.Info("MotoTool report, here you can send me a message and ill respond you on with your email!");
            cAppend("MotoTool report, here you can send me a message and ill respond you on with your email!");
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

        protected void sendMailToAdmin(string msg, string email)
        {
            try
            {
                _log.Debug("Sending new message... ");
                cAppend("Sending new message... ");
                MailMessage myMsg = new MailMessage();
                myMsg.From = new MailAddress("mototool28@gmail.com");
                myMsg.To.Add("mototool28@gmail.com");
                myMsg.Subject = "New MotoTool Message";
                myMsg.Body = msg + "\nUser Email : " + email;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("mototool28@gmail.com", "password :)");
                smtp.EnableSsl = true;

                smtp.Send(myMsg);
                _log.Debug("Sending new message... {OK}");
                cAppend("Sending new message... {OK}");
            }
            catch (Exception er)
            {
                Dialogs.ErrorDialog("Cant send your message", "ERROR: " + er);
            }
        }

        private void materialButtonSend_Click(object sender, EventArgs e)
        {
            if (textBoxMSG.Text != string.Empty || textBoxEmail.Text != string.Empty)
            {
                sendMailToAdmin(textBoxMSG.Text, textBoxEmail.Text);
            }
            else
            {
                Dialogs.WarningDialog("Send message", "The boxes can't be empty!");
            }
        }
    }
}
