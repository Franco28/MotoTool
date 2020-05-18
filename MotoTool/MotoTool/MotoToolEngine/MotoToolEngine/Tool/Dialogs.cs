
using System;
using System.Threading;
using System.Windows.Forms;

namespace Franco28Tool.Engine
{
    public class Dialogs
    {

        public static void TWRPPermanent(string titlemsg, string textmsg)
        {
            try
            {
                var twrp = new TWRPPermanent();
                twrp.Text = titlemsg;
                twrp.label1.Text = textmsg;
                twrp.ShowDialog();
            }
            catch (Exception er)
            {
                Logs.DebugErrorLogs(er);
                MessageBox.Show("Error on loading Tool dialogs ERROR:" + er,
                    "MotoTool dialogs error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
        }

        public static void ErrorDialog(string titlemsg, string textmsg)
        {
            try
            {
                var error = new OkError();
                error.Text = titlemsg;
                error.label1.Text = textmsg;
                error.ShowDialog();
            }
            catch (Exception er)
            {
                Logs.DebugErrorLogs(er);
                MessageBox.Show("Error on loading Tool dialogs ERROR:" + er,
                    "MotoTool dialogs error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
        }

        public static void InfoDialog(string titlemsg, string textmsg)
        {
            try
            {
                var info = new OkInfo();
                info.Text = titlemsg;
                info.label1.Text = textmsg;
                info.ShowDialog();
            }
            catch (Exception er)
            {
                Logs.DebugErrorLogs(er);
                MessageBox.Show("Error on loading Tool dialogs ERROR:" + er,
                    "MotoTool dialogs error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
        }

        public static void WarningDialog(string titlemsg, string textmsg)
        {
            try
            {
                var warn = new OkWarn();
                warn.Text = titlemsg;
                warn.label1.Text = textmsg;
                warn.ShowDialog();
            }
            catch (Exception er)
            {
                Logs.DebugErrorLogs(er);
                MessageBox.Show("Error on loading Tool dialogs ERROR:" + er,
                    "MotoTool dialogs error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
        }
    }
}
