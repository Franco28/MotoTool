
using System;
using System.Xml;

namespace Franco28Tool.Engine
{
    public class LangEngine
    {
        public static string LangFilePath = "C:\\Program Files\\MotoTool\\lang\\";
        public static XmlTextReader reader = null;

        public static string btnfolder = "";
        public static string btnadbfolder = "";
        public static string btnclearfolder = "";
        public static string btndownloads = "";
        public static string btnfolderpath = "";
        public static string btnmovefilestotwrp = "";
        public static string btnunins = "";
        public static string btncheck4updates = "";
        public static string btnrefreshtool = "";
        public static string btnhelp = "";
        public static string btnexit = "";
        public static string btnunlock = "";
        public static string btnlock = "";
        public static string otherslabel = "";
        public static string rebotlabel = "";
        public static string langselect = "";
        public static string btndownloadtwrppermanent = "";

        public static string dstatus = "";
        public static string toolwaitdownload = "";
        public static string freeram = "";
        public static string foldersize = "";
        public static string username = "";
        public static string rtabyeapf = "";
        public static string internetchecktitle = "";
        public static string internetcheck = "";
        public static string internetcheckfiles = "";
        public static string dchannel = "";
        public static string dnotcompatibletitle = "";
        public static string dnotcompatiblebody = "";
        public static string readfirmware = "";

        public static string debloatothershelp = "";
        public static string debloatothers = "";
        public static string debloatothersbox = "";

        public static string deviceconnectedlistbox = "";
        public static string devicecodenamelistbox = "";
        public static string connectmodelistbox = "";
        public static string deviceseriallistbox = "";
        public static string batterylistbox = "";
        public static string batterytemplistbox = "";
        public static string batteryhealthlistbox = "";
        public static string devicerememberlistbox = "";
        public static string deviceconnectedlistboxoff = "";
        public static string devicecodenamelistboxoff = "";
        public static string connectmodelistboxoff = "";
        public static string deviceseriallistboxoff = "";
        public static string batterylistboxoff = "";
        public static string batteryhealthlistboxoff = "";
        public static string batterytemplistboxoff = "";
        public static string toolwbatteryhealthlistboxoffaitdownload = ""; 

        public static string newtoolupdate = "";
        public static string newtoolupdate2 = "";
        public static string noupdatebody = "";
        public static string noupdatetitle = "";
        public static string updateerrortitle = "";
        public static string updateerrorbody = "";

        public static string themeenginetitle = "";
        public static string themeenginedarkbody = "";
        public static string themeenginelightbody = "";

        public static string errorstartingadb = "";
        public static string errorreadingout = "";

        public static string bootloaderreadmetitle = "";
        public static string bootloaderreadme = "";
        public static string lockbootloadertitle = "";
        public static string lockbootloaderbody1 = "";
        public static string lockbootloaderbody2 = "";
        public static string lockbootloaderbody3 = "";
        public static string lockingbl = "";
        public static string lockingblok = "";
        public static string lockblcancel = "";

        public static string checkingdeviceconnection = "";
        public static string checkingdeviceconnectionok = "";
        public static string devicerebooting = "";
        public static string connectdevice = "";
        public static string connectdevicemototool = "";
        public static string connecttotwrp = "";
        public static string motoflashplug = "";
        public static string interneconnectionok = "";
        public static string interneconnectionoff = "";
        public static string flashtwrppermanent = "";
        public static string flashtwrpab = "";
        public static string twrpnotsupport = "";
        public static string twrpbooting = "";

        public static string blankflashnotsupport = "";
        public static string blankflashcheck = "";

        public static string cantfindlogo = "";
        public static string logomissing = "";

        public static string motodrivers = "";
        public static string motodriversinstall = "";

        public static string clearfolderstitle = "";
        public static string clearfoldersbody = "";
        public static string openfoldererror = "";
        public static string createfoldererror = "";
        public static string clearfolderswarns2 = "";

        public static string MSGBOXServerNetworkLosttitle = "";
        public static string MSGBOXServerNetworkLost = "";
        public static string MSGBOXFileCorruptedtitle = "";
        public static string MSGBOXFileCorruptedbody = "";
        public static string MSGBOXBootloaderWarning = "";
        public static string MSGBOXFirmwareMissingtitle = "";
        public static string MSGBOXFirmwareMissingbody = "";
        public static string MsgBoxResultFirmwareInfo = "";

        public static string downloadUIdownloading = "";
        public static string downloadUIdownloadcancel = "";
        public static string downloadUIdownloadcomplete = "";
        public static string downloadUIfilelocate = "";

        public static string firmwareselected = "";
        public static string firmwarechannel = "";
        public static string firmwarealreadydownloaded = "";
        public static string firmwareerror = "";

        public static string movetotwrpdrag = "";
        public static string movetotwrpfilestitle = "";
        public static string movetotwrpcopy = "";
        public static string movetotwrpcopy1 = "";
        public static string movetotwrpfilescopy = "";
        public static string movetotwrpfilescopy1 = "";

        public static string motoflashdevicenotcompatibletitle = "";
        public static string motoflashdevicenotcompatible = "";
        public static string motoflashdownload = "";
        public static string motoflashselectoption = "";
        public static string motoflashdetect = "";
        public static string motoflashinstalled = "";
        public static string motoflashdowngrade = "";

        public static string clearfolderswarn = "";
        public static string clearfolderscont = "";
        public static string clearyesbtn = "";

        public static string help = "";
        public static string helpsource = "";
        public static string helphowto = "";
        public static string helpcontact = "";
        public static string helpsourceinf = "";
        public static string uninstallwarn = "";
        public static string uninscont = "";
        public static string helpcoy = "";
        public static string helptoolcompiled = "";
        public static string helptoolversion = "";

        public static string seleclanguilabel;
        public static string seleclanguitoolrestart;

        public static string unzipuifilepath = "";
        public static string unzipuifildest = "";
        public static string unzipuifileextract = "";
        public static string unzipuiprogressindi = "";
        public static string unzipuiprogresstotal = "";
        public static string unzipuifilesize = "";
        public static string unzipuiprogress = "";
        public static string unzipexctractok = "";

        public static void ReadLang(string langxml, string lang)
        {
            try
            {
                reader = new XmlTextReader(LangFilePath + langxml);
                reader.MoveToContent();
                string elementName = "";
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == lang))
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
                                    case "btnfolder":
                                        btnfolder = reader.Value;
                                        break;
                                    case "btnadbfolder":
                                        btnadbfolder = reader.Value;
                                        break;
                                    case "btnclearfolder":
                                        btnclearfolder = reader.Value;
                                        break;
                                    case "btndownloads":
                                        btndownloads = reader.Value;
                                        break;
                                    case "btnfolderpath":
                                        btnfolderpath = reader.Value;
                                        break;
                                    case "btnmovefilestotwrp":
                                        btnmovefilestotwrp = reader.Value;
                                        break;
                                    case "btnunins":
                                        btnunins = reader.Value;
                                        break;
                                    case "btncheck4updates":
                                        btncheck4updates = reader.Value;
                                        break;
                                    case "btnrefreshtool":
                                        btnrefreshtool = reader.Value;
                                        break;
                                    case "btnhelp":
                                        btnhelp = reader.Value;
                                        break;
                                    case "btnexit":
                                        btnexit = reader.Value;
                                        break;
                                    case "btnunlock":
                                        btnunlock = reader.Value;
                                        break;
                                    case "btnlock":
                                        btnlock = reader.Value;
                                        break;
                                    case "otherslabel":
                                        otherslabel = reader.Value;
                                        break;
                                    case "btndownloadtwrppermanent":
                                        btndownloadtwrppermanent = reader.Value;
                                        break;
                                    case "rebotlabel":
                                        rebotlabel = reader.Value;
                                        break;
                                    case "langselect":
                                        langselect = reader.Value;
                                        break;
                                    case "dstatus":
                                        dstatus = reader.Value;
                                        break;
                                    case "toolwaitdownload":
                                        toolwaitdownload = reader.Value;
                                        break;
                                    case "freeram":
                                        freeram = reader.Value;
                                        break;
                                    case "foldersize":
                                        foldersize = reader.Value;
                                        break;
                                    case "username":
                                        username = reader.Value;
                                        break;
                                    case "rtabyeapf":
                                        rtabyeapf = reader.Value;
                                        break;
                                    case "internetchecktitle":
                                        internetchecktitle = reader.Value;
                                        break;
                                    case "internetcheck":
                                        internetcheck = reader.Value;
                                        break;
                                    case "internetcheckfiles":
                                        internetcheckfiles = reader.Value;
                                        break;
                                    case "dchannel":
                                        dchannel = reader.Value;
                                        break;
                                    case "dnotcompatibletitle":
                                        dnotcompatibletitle = reader.Value;
                                        break;
                                    case "dnotcompatiblebody":
                                        dnotcompatiblebody = reader.Value;
                                        break;
                                    case "deviceconnectedlistbox":
                                        deviceconnectedlistbox = reader.Value;
                                        break;
                                    case "devicecodenamelistbox":
                                        devicecodenamelistbox = reader.Value;
                                        break;
                                    case "connectmodelistbox":
                                        connectmodelistbox = reader.Value;
                                        break;
                                    case "deviceseriallistbox":
                                        deviceseriallistbox = reader.Value;
                                        break;
                                    case "batterylistbox":
                                        batterylistbox = reader.Value;
                                        break;
                                    case "batterytemplistbox":
                                        batterytemplistbox = reader.Value;
                                        break;
                                    case "batteryhealthlistbox":
                                        batteryhealthlistbox = reader.Value;
                                        break;
                                    case "devicerememberlistbox":
                                        devicerememberlistbox = reader.Value;
                                        break;
                                    case "deviceconnectedlistboxoff":
                                        deviceconnectedlistboxoff = reader.Value;
                                        break;
                                    case "devicecodenamelistboxoff":
                                        devicecodenamelistboxoff = reader.Value;
                                        break;
                                    case "connectmodelistboxoff":
                                        connectmodelistboxoff = reader.Value;
                                        break;
                                    case "deviceseriallistboxoff":
                                        deviceseriallistboxoff = reader.Value;
                                        break;
                                    case "batterylistboxoff":
                                        batterylistboxoff = reader.Value;
                                        break;
                                    case "batterytemplistboxoff":
                                        batterytemplistboxoff = reader.Value;
                                        break;
                                    case "batteryhealthlistboxoff":
                                        batteryhealthlistboxoff = reader.Value;
                                        break;
                                    case "newtoolupdate":
                                        newtoolupdate = reader.Value;
                                        break;
                                    case "newtoolupdate2":
                                        newtoolupdate2 = reader.Value;
                                        break;
                                    case "noupdatetitle":
                                        noupdatetitle = reader.Value;
                                        break;
                                    case "noupdatebody":
                                        noupdatebody = reader.Value;
                                        break;
                                    case "updateerrortitle":
                                        updateerrortitle = reader.Value;
                                        break;
                                    case "themeenginetitle":
                                        themeenginetitle = reader.Value;
                                        break;
                                    case "themeenginedarkbody":
                                        themeenginedarkbody = reader.Value;
                                        break;
                                    case "themeenginelightbody":
                                        themeenginelightbody = reader.Value;
                                        break;
                                    case "errorstartingadb":
                                        errorstartingadb = reader.Value;
                                        break;
                                    case "errorreadingout":
                                        errorreadingout = reader.Value;
                                        break;
                                    case "bootloaderreadmetitle":
                                        bootloaderreadmetitle = reader.Value;
                                        break;
                                    case "bootloaderreadme":
                                        bootloaderreadme = reader.Value;
                                        break;
                                    case "lockbootloadertitle":
                                        lockbootloadertitle = reader.Value;
                                        break;
                                    case "lockbootloaderbody1":
                                        lockbootloaderbody1 = reader.Value;
                                        break;
                                    case "lockbootloaderbody2":
                                        lockbootloaderbody2 = reader.Value;
                                        break;
                                    case "lockbootloaderbody3":
                                        lockbootloaderbody3 = reader.Value;
                                        break;
                                    case "lockingbl":
                                        lockingbl = reader.Value;
                                        break;
                                    case "lockingblok":
                                        lockingblok = reader.Value;
                                        break;
                                    case "lockblcancel":
                                        lockblcancel = reader.Value;
                                        break;
                                    case "checkingdeviceconnection":
                                        checkingdeviceconnection = reader.Value;
                                        break;
                                    case "checkingdeviceconnectionok":
                                        checkingdeviceconnectionok = reader.Value;
                                        break;
                                    case "devicerebooting":
                                        devicerebooting = reader.Value;
                                        break;
                                    case "connectdevice":
                                        connectdevice = reader.Value;
                                        break;
                                    case "connectdevicemototool":
                                        connectdevicemototool = reader.Value;
                                        break;
                                    case "connecttotwrp":
                                        connecttotwrp = reader.Value;
                                        break;
                                    case "motoflashplug":
                                        motoflashplug = reader.Value;
                                        break;
                                    case "interneconnectionoff":
                                        interneconnectionoff = reader.Value;
                                        break;
                                    case "interneconnectionok":
                                        interneconnectionok = reader.Value;
                                        break;
                                    case "readfirmware":
                                        readfirmware = reader.Value;
                                        break;
                                    case "debloatothersbox":
                                        debloatothersbox = reader.Value;
                                        break;
                                    case "debloatothershelp":
                                        debloatothershelp = reader.Value;
                                        break;
                                    case "debloatothers":
                                        debloatothers = reader.Value;
                                        break;
                                    case "flashtwrppermanent":
                                        flashtwrppermanent = reader.Value;
                                        break;
                                    case "flashtwrpab":
                                        flashtwrpab = reader.Value;
                                        break;
                                    case "twrpnotsupport":
                                        twrpnotsupport = reader.Value;
                                        break;
                                    case "twrpbooting":
                                        twrpbooting = reader.Value;
                                        break;
                                    case "blankflashnotsupport":
                                        blankflashnotsupport = reader.Value;
                                        break;
                                    case "blankflashcheck":
                                        blankflashcheck = reader.Value;
                                        break;
                                    case "cantfindlogo":
                                        cantfindlogo = reader.Value;
                                        break;
                                    case "logomissing":
                                        logomissing = reader.Value;
                                        break;
                                    case "motodrivers":
                                        motodrivers = reader.Value;
                                        break;
                                    case "motodriversinstall":
                                        motodriversinstall = reader.Value;
                                        break;
                                    case "clearfolderstitle":
                                        clearfolderstitle = reader.Value;
                                        break;
                                    case "clearfoldersbody":
                                        clearfoldersbody = reader.Value;
                                        break;
                                    case "openfoldererror":
                                        openfoldererror = reader.Value;
                                        break;
                                    case "createfoldererror":
                                        createfoldererror = reader.Value;
                                        break;
                                    case "clearfolderswarns2":
                                        clearfolderswarns2 = reader.Value;
                                        break;
                                    case "MSGBOXServerNetworkLosttitle":
                                        MSGBOXServerNetworkLosttitle = reader.Value;
                                        break;
                                    case "MSGBOXServerNetworkLost":
                                        MSGBOXServerNetworkLost = reader.Value;
                                        break;
                                    case "MSGBOXFileCorruptedtitle":
                                        MSGBOXFileCorruptedtitle = reader.Value;
                                        break;
                                    case "MSGBOXFileCorruptedbody":
                                        MSGBOXFileCorruptedbody = reader.Value;
                                        break;
                                    case "MSGBOXBootloaderWarning":
                                        MSGBOXBootloaderWarning = reader.Value;
                                        break;
                                    case "MSGBOXFirmwareMissingtitle":
                                        MSGBOXFirmwareMissingtitle = reader.Value;
                                        break;
                                    case "MSGBOXFirmwareMissingbody":
                                        MSGBOXFirmwareMissingbody = reader.Value;
                                        break;
                                    case "MsgBoxResultFirmwareInfo":
                                        MsgBoxResultFirmwareInfo = reader.Value;
                                        break;
                                    case "downloadUIdownloading":
                                        downloadUIdownloading = reader.Value;
                                        break;
                                    case "downloadUIdownloadcancel":
                                        downloadUIdownloadcancel = reader.Value;
                                        break;
                                    case "downloadUIdownloadcomplete":
                                        downloadUIdownloadcomplete = reader.Value;
                                        break;
                                    case "downloadUIfilelocate":
                                        downloadUIfilelocate = reader.Value;
                                        break;
                                    case "firmwareselected":
                                        firmwareselected = reader.Value;
                                        break;
                                    case "firmwarechannel":
                                        firmwarechannel = reader.Value;
                                        break;
                                    case "firmwarealreadydownloaded":
                                        firmwarealreadydownloaded = reader.Value;
                                        break;
                                    case "firmwareerror":
                                        firmwareerror = reader.Value;
                                        break;
                                    case "movetotwrpdrag":
                                        movetotwrpdrag = reader.Value;
                                        break;
                                    case "movetotwrpfilestitle":
                                        movetotwrpfilestitle = reader.Value;
                                        break;
                                    case "movetotwrpcopy":
                                        movetotwrpcopy = reader.Value;
                                        break;
                                    case "movetotwrpcopy1":
                                        movetotwrpcopy1 = reader.Value;
                                        break;
                                    case "movetotwrpfilescopy":
                                        movetotwrpfilescopy = reader.Value;
                                        break;
                                    case "movetotwrpfilescopy1":
                                        movetotwrpfilescopy1 = reader.Value;
                                        break;
                                    case "motoflashdevicenotcompatibletitle":
                                        motoflashdevicenotcompatibletitle = reader.Value;
                                        break;
                                    case "motoflashdevicenotcompatible":
                                        motoflashdevicenotcompatible = reader.Value;
                                        break;
                                    case "motoflashdownload":
                                        motoflashdownload = reader.Value;
                                        break;
                                    case "motoflashselectoption":
                                        motoflashselectoption = reader.Value;
                                        break;
                                    case "motoflashdetect":
                                        motoflashdetect = reader.Value;
                                        break;
                                    case "motoflashinstalled":
                                        motoflashinstalled = reader.Value;
                                        break;
                                    case "motoflashdowngrade":
                                        motoflashdowngrade = reader.Value;
                                        break;
                                    case "clearfolderswarn":
                                        clearfolderswarn = reader.Value;
                                        break;
                                    case "clearfolderscont":
                                        clearfolderscont = reader.Value;
                                        break;
                                    case "clearyesbtn":
                                        clearyesbtn = reader.Value;
                                        break;
                                    case "help":
                                        help = reader.Value;
                                        break;
                                    case "helpsource":
                                        helpsource = reader.Value;
                                        break;
                                    case "helphowto":
                                        helphowto = reader.Value;
                                        break;
                                    case "helpcontact":
                                        helpcontact = reader.Value;
                                        break;
                                    case "helpsourceinf":
                                        helpsourceinf = reader.Value;
                                        break;
                                    case "helpcoy":
                                        helpcoy = reader.Value;
                                        break;
                                    case "helptoolcompiled":
                                        helptoolcompiled = reader.Value;
                                        break;
                                    case "helptoolversion":
                                        helptoolversion = reader.Value;
                                        break;
                                    case "uninstallwarn":
                                        uninstallwarn = reader.Value;
                                        break;
                                    case "uninscont":
                                        uninscont = reader.Value;
                                        break;
                                    case "seleclanguilabel":
                                        seleclanguilabel = reader.Value;
                                        break;
                                    case "seleclanguitoolrestart":
                                        seleclanguitoolrestart = reader.Value;
                                        break;
                                    case "unzipuifilepath":
                                        unzipuifilepath = reader.Value;
                                        break;
                                    case "unzipuifildest":
                                        unzipuifildest = reader.Value;
                                        break;
                                    case "unzipuifileextract":
                                        unzipuifileextract = reader.Value;
                                        break;
                                    case "unzipuiprogressindi":
                                        unzipuiprogressindi = reader.Value;
                                        break;
                                    case "unzipuiprogresstotal":
                                        unzipuiprogresstotal = reader.Value;
                                        break;
                                    case "unzipuifilesize":
                                        unzipuifilesize = reader.Value;
                                        break;
                                    case "unzipuiprogress":
                                        unzipuiprogress = reader.Value;
                                        break;
                                    case "unzipexctractok":
                                        unzipexctractok = reader.Value;
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Dialogs.ErrorDialog("MotoTool Lang Engine", ex.Message);
                Logs.DebugErrorLogs(ex);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
    }
}
