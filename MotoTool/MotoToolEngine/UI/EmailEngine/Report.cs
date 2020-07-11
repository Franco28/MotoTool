
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net.Mime;
using System.IO;
using System.Collections;
using System.Runtime.InteropServices;
using log4net;
using System.Reflection;

namespace Franco28Tool.Engine
{
    [ComVisible(false)]

    public partial class Report : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private SettingsMng oConfigMng = new SettingsMng();
        bool hasAttachment = false;
        string[] aryAttachments;
        ArrayList alAttachments;
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Report()
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
            _log.Info("MotoTool report, here you can send me if you find any bug, or you want to contact me!");
            cAppend("MotoTool report, here you can send me if you find any bug, or you want to contact me!");
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
                _log.Debug("Sending new report... ");
                cAppend("Sending new report... ");
                MailMessage myMsg = new MailMessage();
                myMsg.From = new MailAddress("mototool28@gmail.com");
                myMsg.To.Add("mototool28@gmail.com");
                myMsg.Subject = "New MotoTool Report";
                myMsg.Body = msg + "\nUser Email : " + email;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("mototool28@gmail.com", "password :)");
                smtp.EnableSsl = true;

                if (hasAttachment)
                {
                    for (int i = 0; i < aryAttachments.Length; i++)
                    {

                        Attachment fileAttach = new Attachment(aryAttachments[i], MediaTypeNames.Application.Octet);
                        ContentDisposition disposition = fileAttach.ContentDisposition;
                        disposition.CreationDate = File.GetCreationTime(txtAttach.Text);
                        disposition.ModificationDate = File.GetLastWriteTime(txtAttach.Text);
                        disposition.ReadDate = File.GetLastAccessTime(txtAttach.Text);
                        myMsg.Attachments.Add(fileAttach);
                    }
                }
                smtp.Send(myMsg);
                _log.Debug("Sending new report...  {OK}");
                cAppend("Sending new report... {OK}");
            }
            catch (Exception er)
            {
                Dialogs.ErrorDialog("Cant send your report", "ERROR: " + er);
            }
        }

        protected void materialButtonSend_Click(object sender, EventArgs e)
        {
            if (textBoxMSG.Text != string.Empty || textBoxEmail.Text != string.Empty)
            {
                sendMailToAdmin(textBoxMSG.Text, textBoxEmail.Text);
            }
            else
            {
                Dialogs.WarningDialog("Send report", "The boxes can't be empty!");
            }
        }

        private void materialButtonAttachFiles_Click(object sender, EventArgs e)
        {
            _log.Debug("Attach files");
            txtAttach.Text = "";
            oFD1.InitialDirectory = "C:\\";
            oFD1.Title = "Attach Files";
            oFD1.Filter = "Text Files|*.txt|All Files|*.*";
            oFD1.Multiselect = true;
            DialogResult ofdResults = oFD1.ShowDialog();
            try
            {
                if (ofdResults == DialogResult.Cancel)
                {
                    _log.Debug("Attachment, false");
                    hasAttachment = false;
                    return;
                }
                else 
                {
                    int numOfFiles = oFD1.FileNames.Length;
                    int counter = 0;
                    string[] arr = oFD1.FileNames;
                    alAttachments = new ArrayList();
                    txtAttach.Text = string.Empty;
                    alAttachments.AddRange(arr);
                    aryAttachments = new string[numOfFiles];
                    foreach (string s in oFD1.FileNames)
                    {
                        aryAttachments[counter] = s;
                        txtAttach.Text += s + "; \n";
                        _log.Debug("Attaching files: " + s);
                        counter++;
                    }
                    hasAttachment = true;
                    _log.Debug("Attachment, true");
                }
            }
            catch (Exception ex)
            {
                Logs.DebugErrorLogs(ex);
                Dialogs.ErrorDialog("Attaching files", "ERROR: " + ex.Message);
            }
        }
    }
}
