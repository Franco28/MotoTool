
using System;
using System.Xml;

namespace Franco28Tool.Engine
{
    public class FirmwareFlashRead
    {
        public static string FlashReadPath = "C:\\Program Files\\MotoTool\\flash\\";
        public static string devices = "";
        public static string set_a = "";
        public static string getvar = "";
        public static string oem = "";
        public static string gpt = "";
        public static string preloader = "";
        public static string bootloader = "";
        public static string lk_a = "";
        public static string lk_b = "";
        public static string tee_a = "";
        public static string tee_b = "";
        public static string md1img_a = "";
        public static string md1img_b = "";
        public static string spmfw_a = "";
        public static string spmfw_b = "";
        public static string scp_a = "";
        public static string scp_b = "";
        public static string sspm_a = "";
        public static string sspm_b = "";
        public static string cam_vpu1_a = "";
        public static string cam_vpu1_b = "";
        public static string cam_vpu2_a = "";
        public static string cam_vpu2_b = "";
        public static string cam_vpu3_a = "";
        public static string cam_vpu3_b = "";
        public static string vbmeta_a = "";
        public static string vbmeta_b = "";
        public static string modem_a = "";
        public static string modem_b = "";
        public static string fsg_a = "";
        public static string fsg_b = "";
        public static string modemst1 = "";
        public static string modemst2 = "";
        public static string bluetooth_a = "";
        public static string bluetooth_b = "";
        public static string dsp_a = "";
        public static string dsp_b = "";
        public static string logo_a = "";
        public static string logo_b = "";
        public static string boot_a = "";
        public static string radio_a = "";
        public static string radio_b = "";
        public static string recovery_a = "";
        public static string recovery_b = "";
        public static string boot_b = "";
        public static string dtbo_a = "";
        public static string dtbo_b = "";
        public static string dtb_a = "";
        public static string dtb_b = "";

        public static string system_a_0 = "";
        public static string system_a_1 = "";
        public static string system_a_2 = "";
        public static string system_a_3 = "";
        public static string system_a_4 = "";
        public static string system_a_5 = "";
        public static string system_a_6 = "";
        public static string system_a_7 = "";
        public static string system_a_8 = "";
        public static string system_a_9 = "";
        public static string system_a_10 = "";
        public static string system_a_11 = "";
        public static string system_a_12 = "";
        public static string system_a_13 = "";
        public static string system_a_14 = "";
        public static string system_a_15 = "";
        public static string system_b_0 = "";
        public static string system_b_1 = "";
        public static string system_b_2 = "";
        public static string oem_a = "";
        public static string oem_b = "";
        public static string vendor_a = "";
        public static string vendor_a_0 = "";
        public static string vendor_a_1 = "";
        public static string vendor_b = "";
        public static string vendor_b_0 = "";
        public static string vendor_b_1 = "";
        public static string erasecarrier = "";
        public static string eraseuserdata = "";
        public static string eraseddr = "";
        public static string oemclear = "";
        public static string reboot = "";

        public static XmlTextReader reader = null;

        public static void ReadFirmwareFlashAB(string devicecodename)
        {
            try
            {
                reader = new XmlTextReader(FlashReadPath + devicecodename + ".xml");
                reader.MoveToContent();
                string elementName = "";
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "flash" + devicecodename))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            elementName = reader.Name;
                        }
                        else
                        {
                            if ((reader.NodeType == XmlNodeType.Text) && (reader.HasValue))
                            {
                                switch (elementName)
                                {
                                    case "devices":
                                        devices = reader.Value;
                                        break;
                                    case "set_a":
                                        set_a = reader.Value;
                                        break;
                                    case "getvar":
                                        getvar = reader.Value;
                                        break;
                                    case "oem":
                                        oem = reader.Value;
                                        break;
                                    case "gpt":
                                        gpt = reader.Value;
                                        break;
                                    case "bootloader":
                                        bootloader = reader.Value;
                                        break;
                                    case "vbmeta_a":
                                        vbmeta_a = reader.Value;
                                        break;
                                    case "vbmeta_b":
                                        vbmeta_b = reader.Value;
                                        break;
                                    case "modem_a":
                                        modem_a = reader.Value;
                                        break;
                                    case "modem_b":
                                        modem_b = reader.Value;
                                        break;
                                    case "fsg_a":
                                        fsg_a = reader.Value;
                                        break;
                                    case "fsg_b":
                                        fsg_b = reader.Value;
                                        break;
                                    case "modemst1":
                                        modemst1 = reader.Value;
                                        break;
                                    case "modemst2":
                                        modemst2 = reader.Value;
                                        break;
                                    case "bluetooth_a":
                                        bluetooth_a = reader.Value;
                                        break;
                                    case "bluetooth_b":
                                        bluetooth_b = reader.Value;
                                        break;
                                    case "dsp_a":
                                        dsp_a = reader.Value;
                                        break;
                                    case "dsp_b":
                                        dsp_b = reader.Value;
                                        break;
                                    case "logo_a":
                                        logo_a = reader.Value;
                                        break;
                                    case "logo_b":
                                        logo_b = reader.Value;
                                        break;
                                    case "boot_a":
                                        boot_a = reader.Value;
                                        break;
                                    case "boot_b":
                                        boot_b = reader.Value;
                                        break;
                                    case "dtbo_a":
                                        dtbo_a = reader.Value;
                                        break;
                                    case "dtbo_b":
                                        dtbo_b = reader.Value;
                                        break;
                                    case "system_a_0":
                                        system_a_0 = reader.Value;
                                        break;
                                    case "system_a_1":
                                        system_a_1 = reader.Value;
                                        break;
                                    case "system_a_2":
                                        system_a_2 = reader.Value;
                                        break;
                                    case "system_a_3":
                                        system_a_3 = reader.Value;
                                        break;
                                    case "system_a_4":
                                        system_a_4 = reader.Value;
                                        break;
                                    case "system_a_5":
                                        system_a_5 = reader.Value;
                                        break;
                                    case "system_b_0":
                                        system_b_0 = reader.Value;
                                        break;
                                    case "system_b_1":
                                        system_b_1 = reader.Value;
                                        break;
                                    case "system_b_2":
                                        system_b_2 = reader.Value;
                                        break;
                                    case "oem_a":
                                        oem_a = reader.Value;
                                        break;
                                    case "oem_b":
                                        oem_b = reader.Value;
                                        break;
                                    case "vendor_a":
                                        vendor_a = reader.Value;
                                        break;
                                    case "vendor_a_0":
                                        vendor_a_0 = reader.Value;
                                        break;
                                    case "vendor_a_1":
                                        vendor_a_1 = reader.Value;
                                        break;
                                    case "vendor_b":
                                        vendor_b = reader.Value;
                                        break;
                                    case "vendor_b_0":
                                        vendor_b_0 = reader.Value;
                                        break;
                                    case "vendor_b_1":
                                        vendor_b_1 = reader.Value;
                                        break;
                                    case "erasecarrier":
                                        erasecarrier = reader.Value;
                                        break;
                                    case "eraseuserdata":
                                        eraseuserdata = reader.Value;
                                        break;
                                    case "eraseddr":
                                        eraseddr = reader.Value;
                                        break;
                                    case "oemclear":
                                        oemclear = reader.Value;
                                        break;
                                    case "reboot":
                                        reboot = reader.Value;
                                        break;
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Logs.DebugErrorLogs(ex);
                Dialogs.ErrorDialog("Firmware Read: ERROR", ex.Message);
                return;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        public static void ReadFirmwareFlashN(string devicecodename)
        {
            try
            {
                reader = new XmlTextReader(FlashReadPath + devicecodename + ".xml");
                reader.MoveToContent();
                string elementName = "";
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "flash" + devicecodename))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            elementName = reader.Name;
                        }
                        else
                        {
                            if ((reader.NodeType == XmlNodeType.Text) && (reader.HasValue))
                            {
                                switch (elementName)
                                {
                                    case "devices":
                                        devices = reader.Value;
                                        break;
                                    case "getvar":
                                        getvar = reader.Value;
                                        break;
                                    case "oem":
                                        oem = reader.Value;
                                        break;
                                    case "gpt":
                                        gpt = reader.Value;
                                        break;
                                    case "bootloader":
                                        bootloader = reader.Value;
                                        break;
                                    case "modem_a":
                                        modem_a = reader.Value;
                                        break;
                                    case "fsg_a":
                                        fsg_a = reader.Value;
                                        break;
                                    case "modemst1":
                                        modemst1 = reader.Value;
                                        break;
                                    case "modemst2":
                                        modemst2 = reader.Value;
                                        break;
                                    case "bluetooth_a":
                                        bluetooth_a = reader.Value;
                                        break;
                                    case "dsp_a":
                                        dsp_a = reader.Value;
                                        break;
                                    case "logo_a":
                                        logo_a = reader.Value;
                                        break;
                                    case "boot_a":
                                        boot_a = reader.Value;
                                        break;
                                    case "dtbo_a":
                                        dtbo_a = reader.Value;
                                        break;
                                    case "system_a_0":
                                        system_a_0 = reader.Value;
                                        break;
                                    case "system_a_1":
                                        system_a_1 = reader.Value;
                                        break;
                                    case "system_a_2":
                                        system_a_2 = reader.Value;
                                        break;
                                    case "system_a_3":
                                        system_a_3 = reader.Value;
                                        break;
                                    case "system_a_4":
                                        system_a_4 = reader.Value;
                                        break;
                                    case "system_a_5":
                                        system_a_5 = reader.Value;
                                        break;
                                    case "system_a_6":
                                        system_a_6 = reader.Value;
                                        break;
                                    case "system_a_7":
                                        system_a_7 = reader.Value;
                                        break;
                                    case "system_a_8":
                                        system_a_8 = reader.Value;
                                        break;
                                    case "system_a_9":
                                        system_a_9 = reader.Value;
                                        break;
                                    case "system_a_10":
                                        system_a_10 = reader.Value;
                                        break;
                                    case "oem_a":
                                        oem_a = reader.Value;
                                        break;
                                    case "erasecarrier":
                                        erasecarrier = reader.Value;
                                        break;
                                    case "eraseuserdata":
                                        eraseuserdata = reader.Value;
                                        break;
                                    case "eraseddr":
                                        eraseddr = reader.Value;
                                        break;
                                    case "oemclear":
                                        oemclear = reader.Value;
                                        break;
                                    case "reboot":
                                        reboot = reader.Value;
                                        break;
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Logs.DebugErrorLogs(ex);
                Dialogs.ErrorDialog("Firmware Read: ERROR", ex.Message);
                return;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
    }
}
