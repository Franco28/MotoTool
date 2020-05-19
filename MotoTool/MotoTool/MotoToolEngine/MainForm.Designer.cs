using System.Windows.Forms;
using MaterialSkin.Controls;

namespace Franco28Tool.Engine
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuIconList = new System.Windows.Forms.ImageList(this.components);
            this.panelChild = new System.Windows.Forms.Panel();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPageHOME = new System.Windows.Forms.TabPage();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelDownload = new System.Windows.Forms.Panel();
            this.console = new System.Windows.Forms.RichTextBox();
            this.materialLabel24 = new MaterialSkin.Controls.MaterialLabel();
            this.listBoxDeviceStatus = new System.Windows.Forms.ListBox();
            this.materialLabel12 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel11 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialButtonFlashLogo = new MaterialSkin.Controls.MaterialButton();
            this.materialButtonBlankFlash = new MaterialSkin.Controls.MaterialButton();
            this.materialButtonRebootRecovery = new MaterialSkin.Controls.MaterialButton();
            this.materialButtonRebootBootloader = new MaterialSkin.Controls.MaterialButton();
            this.materialButtonBootTWRP = new MaterialSkin.Controls.MaterialButton();
            this.materialButtonFlashTWRP = new MaterialSkin.Controls.MaterialButton();
            this.materialButtonLock = new MaterialSkin.Controls.MaterialButton();
            this.materialButtonUnlock = new MaterialSkin.Controls.MaterialButton();
            this.panelDebug = new System.Windows.Forms.Panel();
            this.TextBoxDebug = new MaterialSkin.Controls.MaterialLabel();
            this.TextBoxDebugInfo = new MaterialSkin.Controls.MaterialLabel();
            this.labelFreeSpace = new System.Windows.Forms.Label();
            this.labelCPUusage = new System.Windows.Forms.Label();
            this.labelFreeRam = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.tabPageFIRMWARE = new System.Windows.Forms.TabPage();
            this.panelFimrware = new System.Windows.Forms.Panel();
            this.materialCardMotoToolFirmwares = new MaterialSkin.Controls.MaterialCard();
            this.materialButtonFirmwareCard = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel14 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel38 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel25 = new MaterialSkin.Controls.MaterialLabel();
            this.tabPageFlashTool = new System.Windows.Forms.TabPage();
            this.panelFlashTool = new System.Windows.Forms.Panel();
            this.materialCardFlashTool = new MaterialSkin.Controls.MaterialCard();
            this.materialButtonFlashTool = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel26 = new MaterialSkin.Controls.MaterialLabel();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.materialTabSelector2 = new MaterialSkin.Controls.MaterialTabSelector();
            this.materialTabControl3 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.materialLabel15 = new MaterialSkin.Controls.MaterialLabel();
            this.materialSwitchAutoSaveLogs = new MaterialSkin.Controls.MaterialSwitch();
            this.materialButtonRemoveToolDeviceData = new MaterialSkin.Controls.MaterialButton();
            this.materialButtonAddNewDevice = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel13 = new MaterialSkin.Controls.MaterialLabel();
            this.materialButtonOpenFirmwareFolder = new MaterialSkin.Controls.MaterialButton();
            this.materialButtonOpenADBFolder = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialButtonclearallfolders = new MaterialSkin.Controls.MaterialButton();
            this.materialButtonHelp = new MaterialSkin.Controls.MaterialButton();
            this.materialButtonUninstall = new MaterialSkin.Controls.MaterialButton();
            this.materialButtonCMD = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.materialButtonCheckUpdates = new MaterialSkin.Controls.MaterialButton();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.MaterialButtonChangeColor = new MaterialSkin.Controls.MaterialButton();
            this.materialSwitchDrawerShowIconsWhenHidden = new MaterialSkin.Controls.MaterialSwitch();
            this.materialSwitchDrawerUseColors = new MaterialSkin.Controls.MaterialSwitch();
            this.materialSwitchDrawerBackgroundWithAccent = new MaterialSkin.Controls.MaterialSwitch();
            this.materialButtonChangeTheme = new MaterialSkin.Controls.MaterialButton();
            this.materialSwitchDrawerHighlightWithAccent = new MaterialSkin.Controls.MaterialSwitch();
            this.materialLabel27 = new MaterialSkin.Controls.MaterialLabel();
            this.panelChild.SuspendLayout();
            this.materialTabControl1.SuspendLayout();
            this.tabPageHOME.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelDownload.SuspendLayout();
            this.panelDebug.SuspendLayout();
            this.tabPageFIRMWARE.SuspendLayout();
            this.panelFimrware.SuspendLayout();
            this.materialCardMotoToolFirmwares.SuspendLayout();
            this.tabPageFlashTool.SuspendLayout();
            this.panelFlashTool.SuspendLayout();
            this.materialCardFlashTool.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.materialTabControl3.SuspendLayout();
            this.tabPage11.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuIconList
            // 
            this.menuIconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("menuIconList.ImageStream")));
            this.menuIconList.TransparentColor = System.Drawing.Color.Transparent;
            this.menuIconList.Images.SetKeyName(0, "round_assessment_white_24dp.png");
            this.menuIconList.Images.SetKeyName(1, "round_build_white_24dp.png");
            this.menuIconList.Images.SetKeyName(2, "iconfinder_Grid_1031514.png");
            this.menuIconList.Images.SetKeyName(3, "iconfinder_settings_115801.png");
            this.menuIconList.Images.SetKeyName(4, "iconfinder_ic_round_download_5760405.png");
            // 
            // panelChild
            // 
            this.panelChild.Controls.Add(this.materialTabControl1);
            this.panelChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChild.Location = new System.Drawing.Point(3, 64);
            this.panelChild.Name = "panelChild";
            this.panelChild.Size = new System.Drawing.Size(1023, 555);
            this.panelChild.TabIndex = 1;
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPageHOME);
            this.materialTabControl1.Controls.Add(this.tabPageFIRMWARE);
            this.materialTabControl1.Controls.Add(this.tabPageFlashTool);
            this.materialTabControl1.Controls.Add(this.tabPageSettings);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl1.ImageList = this.menuIconList;
            this.materialTabControl1.ItemSize = new System.Drawing.Size(80, 27);
            this.materialTabControl1.Location = new System.Drawing.Point(0, 0);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(1023, 555);
            this.materialTabControl1.TabIndex = 19;
            // 
            // tabPageHOME
            // 
            this.tabPageHOME.BackColor = System.Drawing.Color.White;
            this.tabPageHOME.Controls.Add(this.panelMain);
            this.tabPageHOME.Controls.Add(this.panelDebug);
            this.tabPageHOME.ImageKey = "iconfinder_Grid_1031514.png";
            this.tabPageHOME.Location = new System.Drawing.Point(4, 31);
            this.tabPageHOME.Name = "tabPageHOME";
            this.tabPageHOME.Size = new System.Drawing.Size(1015, 520);
            this.tabPageHOME.TabIndex = 0;
            this.tabPageHOME.Text = "Home";
            // 
            // panelMain
            // 
            this.panelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMain.Controls.Add(this.panelDownload);
            this.panelMain.Controls.Add(this.materialLabel12);
            this.panelMain.Controls.Add(this.materialLabel11);
            this.panelMain.Controls.Add(this.materialLabel5);
            this.panelMain.Controls.Add(this.materialLabel3);
            this.panelMain.Controls.Add(this.materialButtonFlashLogo);
            this.panelMain.Controls.Add(this.materialButtonBlankFlash);
            this.panelMain.Controls.Add(this.materialButtonRebootRecovery);
            this.panelMain.Controls.Add(this.materialButtonRebootBootloader);
            this.panelMain.Controls.Add(this.materialButtonBootTWRP);
            this.panelMain.Controls.Add(this.materialButtonFlashTWRP);
            this.panelMain.Controls.Add(this.materialButtonLock);
            this.panelMain.Controls.Add(this.materialButtonUnlock);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1015, 414);
            this.panelMain.TabIndex = 66;
            // 
            // panelDownload
            // 
            this.panelDownload.Controls.Add(this.console);
            this.panelDownload.Controls.Add(this.materialLabel24);
            this.panelDownload.Controls.Add(this.listBoxDeviceStatus);
            this.panelDownload.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDownload.Location = new System.Drawing.Point(0, 0);
            this.panelDownload.Name = "panelDownload";
            this.panelDownload.Size = new System.Drawing.Size(1015, 225);
            this.panelDownload.TabIndex = 78;
            // 
            // console
            // 
            this.console.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.console.Location = new System.Drawing.Point(3, 70);
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.Size = new System.Drawing.Size(1009, 148);
            this.console.TabIndex = 58;
            this.console.Text = "";
            // 
            // materialLabel24
            // 
            this.materialLabel24.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel24.AutoSize = true;
            this.materialLabel24.Depth = 0;
            this.materialLabel24.Font = new System.Drawing.Font("Roboto", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel24.FontType = MaterialSkin.MaterialSkinManager.fontType.H3;
            this.materialLabel24.Location = new System.Drawing.Point(14, 9);
            this.materialLabel24.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel24.Name = "materialLabel24";
            this.materialLabel24.Size = new System.Drawing.Size(129, 58);
            this.materialLabel24.TabIndex = 56;
            this.materialLabel24.Text = "Home";
            // 
            // listBoxDeviceStatus
            // 
            this.listBoxDeviceStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxDeviceStatus.BackColor = System.Drawing.Color.White;
            this.listBoxDeviceStatus.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxDeviceStatus.ForeColor = System.Drawing.Color.Black;
            this.listBoxDeviceStatus.FormattingEnabled = true;
            this.listBoxDeviceStatus.ItemHeight = 16;
            this.listBoxDeviceStatus.Items.AddRange(new object[] {
            " Device: Offline!",
            " Device Codename: ---",
            " Mode: ---"});
            this.listBoxDeviceStatus.Location = new System.Drawing.Point(148, 3);
            this.listBoxDeviceStatus.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listBoxDeviceStatus.MultiColumn = true;
            this.listBoxDeviceStatus.Name = "listBoxDeviceStatus";
            this.listBoxDeviceStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBoxDeviceStatus.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxDeviceStatus.Size = new System.Drawing.Size(864, 68);
            this.listBoxDeviceStatus.TabIndex = 55;
            // 
            // materialLabel12
            // 
            this.materialLabel12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel12.AutoSize = true;
            this.materialLabel12.Depth = 0;
            this.materialLabel12.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel12.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel12.HighEmphasis = true;
            this.materialLabel12.Location = new System.Drawing.Point(826, 245);
            this.materialLabel12.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel12.Name = "materialLabel12";
            this.materialLabel12.Size = new System.Drawing.Size(61, 24);
            this.materialLabel12.TabIndex = 77;
            this.materialLabel12.Text = "Others";
            this.materialLabel12.UseAccent = true;
            // 
            // materialLabel11
            // 
            this.materialLabel11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel11.AutoSize = true;
            this.materialLabel11.Depth = 0;
            this.materialLabel11.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel11.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel11.HighEmphasis = true;
            this.materialLabel11.Location = new System.Drawing.Point(578, 245);
            this.materialLabel11.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel11.Name = "materialLabel11";
            this.materialLabel11.Size = new System.Drawing.Size(64, 24);
            this.materialLabel11.TabIndex = 76;
            this.materialLabel11.Text = "Reboot";
            this.materialLabel11.UseAccent = true;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel5.HighEmphasis = true;
            this.materialLabel5.Location = new System.Drawing.Point(272, 245);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(83, 24);
            this.materialLabel5.TabIndex = 75;
            this.materialLabel5.Text = "Recovery";
            this.materialLabel5.UseAccent = true;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel3.HighEmphasis = true;
            this.materialLabel3.Location = new System.Drawing.Point(20, 245);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(99, 24);
            this.materialLabel3.TabIndex = 74;
            this.materialLabel3.Text = "Bootloader";
            this.materialLabel3.UseAccent = true;
            // 
            // materialButtonFlashLogo
            // 
            this.materialButtonFlashLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.materialButtonFlashLogo.AutoSize = false;
            this.materialButtonFlashLogo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonFlashLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonFlashLogo.Depth = 0;
            this.materialButtonFlashLogo.DrawShadows = true;
            this.materialButtonFlashLogo.HighEmphasis = false;
            this.materialButtonFlashLogo.Icon = global::Franco28Tool.Engine.Properties.Resources.File_Types_IMG_icon;
            this.materialButtonFlashLogo.Location = new System.Drawing.Point(830, 352);
            this.materialButtonFlashLogo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonFlashLogo.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonFlashLogo.Name = "materialButtonFlashLogo";
            this.materialButtonFlashLogo.Size = new System.Drawing.Size(168, 36);
            this.materialButtonFlashLogo.TabIndex = 73;
            this.materialButtonFlashLogo.Text = "Flash Logo";
            this.materialButtonFlashLogo.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonFlashLogo.UseAccentColor = false;
            this.materialButtonFlashLogo.UseVisualStyleBackColor = true;
            this.materialButtonFlashLogo.Click += new System.EventHandler(this.materialButtonFlashLogo_Click);
            // 
            // materialButtonBlankFlash
            // 
            this.materialButtonBlankFlash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.materialButtonBlankFlash.AutoSize = false;
            this.materialButtonBlankFlash.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonBlankFlash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonBlankFlash.Depth = 0;
            this.materialButtonBlankFlash.DrawShadows = true;
            this.materialButtonBlankFlash.HighEmphasis = false;
            this.materialButtonBlankFlash.Icon = global::Franco28Tool.Engine.Properties.Resources.hdd;
            this.materialButtonBlankFlash.Location = new System.Drawing.Point(830, 284);
            this.materialButtonBlankFlash.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonBlankFlash.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonBlankFlash.Name = "materialButtonBlankFlash";
            this.materialButtonBlankFlash.Size = new System.Drawing.Size(168, 36);
            this.materialButtonBlankFlash.TabIndex = 72;
            this.materialButtonBlankFlash.Text = "Blankflash";
            this.materialButtonBlankFlash.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonBlankFlash.UseAccentColor = false;
            this.materialButtonBlankFlash.UseVisualStyleBackColor = true;
            this.materialButtonBlankFlash.Click += new System.EventHandler(this.materialButtonBlankFlash_Click);
            // 
            // materialButtonRebootRecovery
            // 
            this.materialButtonRebootRecovery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.materialButtonRebootRecovery.AutoSize = false;
            this.materialButtonRebootRecovery.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonRebootRecovery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonRebootRecovery.Depth = 0;
            this.materialButtonRebootRecovery.DrawShadows = true;
            this.materialButtonRebootRecovery.HighEmphasis = false;
            this.materialButtonRebootRecovery.Icon = global::Franco28Tool.Engine.Properties.Resources.Apps_reboot_icon;
            this.materialButtonRebootRecovery.Location = new System.Drawing.Point(582, 352);
            this.materialButtonRebootRecovery.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonRebootRecovery.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonRebootRecovery.Name = "materialButtonRebootRecovery";
            this.materialButtonRebootRecovery.Size = new System.Drawing.Size(168, 36);
            this.materialButtonRebootRecovery.TabIndex = 71;
            this.materialButtonRebootRecovery.Text = "Recovery";
            this.materialButtonRebootRecovery.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonRebootRecovery.UseAccentColor = false;
            this.materialButtonRebootRecovery.UseVisualStyleBackColor = true;
            this.materialButtonRebootRecovery.Click += new System.EventHandler(this.materialButtonRebootRecovery_Click);
            // 
            // materialButtonRebootBootloader
            // 
            this.materialButtonRebootBootloader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.materialButtonRebootBootloader.AutoSize = false;
            this.materialButtonRebootBootloader.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonRebootBootloader.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonRebootBootloader.Depth = 0;
            this.materialButtonRebootBootloader.DrawShadows = true;
            this.materialButtonRebootBootloader.HighEmphasis = false;
            this.materialButtonRebootBootloader.Icon = global::Franco28Tool.Engine.Properties.Resources.system_reboot_icon;
            this.materialButtonRebootBootloader.Location = new System.Drawing.Point(582, 284);
            this.materialButtonRebootBootloader.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonRebootBootloader.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonRebootBootloader.Name = "materialButtonRebootBootloader";
            this.materialButtonRebootBootloader.Size = new System.Drawing.Size(168, 36);
            this.materialButtonRebootBootloader.TabIndex = 70;
            this.materialButtonRebootBootloader.Text = "Bootloader";
            this.materialButtonRebootBootloader.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonRebootBootloader.UseAccentColor = false;
            this.materialButtonRebootBootloader.UseVisualStyleBackColor = true;
            this.materialButtonRebootBootloader.Click += new System.EventHandler(this.materialButtonRebootBootloader_Click);
            // 
            // materialButtonBootTWRP
            // 
            this.materialButtonBootTWRP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.materialButtonBootTWRP.AutoSize = false;
            this.materialButtonBootTWRP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonBootTWRP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonBootTWRP.Depth = 0;
            this.materialButtonBootTWRP.DrawShadows = true;
            this.materialButtonBootTWRP.HighEmphasis = false;
            this.materialButtonBootTWRP.Icon = global::Franco28Tool.Engine.Properties.Resources.htc_one_flash_icon;
            this.materialButtonBootTWRP.Location = new System.Drawing.Point(276, 352);
            this.materialButtonBootTWRP.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonBootTWRP.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonBootTWRP.Name = "materialButtonBootTWRP";
            this.materialButtonBootTWRP.Size = new System.Drawing.Size(168, 36);
            this.materialButtonBootTWRP.TabIndex = 69;
            this.materialButtonBootTWRP.Text = "BOOT TWRP";
            this.materialButtonBootTWRP.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonBootTWRP.UseAccentColor = false;
            this.materialButtonBootTWRP.UseVisualStyleBackColor = true;
            this.materialButtonBootTWRP.Click += new System.EventHandler(this.materialButtonBootTWRP_Click);
            // 
            // materialButtonFlashTWRP
            // 
            this.materialButtonFlashTWRP.AutoSize = false;
            this.materialButtonFlashTWRP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonFlashTWRP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonFlashTWRP.Depth = 0;
            this.materialButtonFlashTWRP.DrawShadows = true;
            this.materialButtonFlashTWRP.HighEmphasis = false;
            this.materialButtonFlashTWRP.Icon = global::Franco28Tool.Engine.Properties.Resources.flash;
            this.materialButtonFlashTWRP.Location = new System.Drawing.Point(276, 284);
            this.materialButtonFlashTWRP.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonFlashTWRP.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonFlashTWRP.Name = "materialButtonFlashTWRP";
            this.materialButtonFlashTWRP.Size = new System.Drawing.Size(168, 36);
            this.materialButtonFlashTWRP.TabIndex = 68;
            this.materialButtonFlashTWRP.Text = "Flash TWRP";
            this.materialButtonFlashTWRP.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonFlashTWRP.UseAccentColor = false;
            this.materialButtonFlashTWRP.UseVisualStyleBackColor = true;
            this.materialButtonFlashTWRP.Click += new System.EventHandler(this.materialButtonFlashTWRP_Click);
            // 
            // materialButtonLock
            // 
            this.materialButtonLock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.materialButtonLock.AutoSize = false;
            this.materialButtonLock.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonLock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonLock.Depth = 0;
            this.materialButtonLock.DrawShadows = true;
            this.materialButtonLock.HighEmphasis = false;
            this.materialButtonLock.Icon = global::Franco28Tool.Engine.Properties.Resources.lock_icon;
            this.materialButtonLock.Location = new System.Drawing.Point(24, 352);
            this.materialButtonLock.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonLock.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonLock.Name = "materialButtonLock";
            this.materialButtonLock.Size = new System.Drawing.Size(168, 36);
            this.materialButtonLock.TabIndex = 67;
            this.materialButtonLock.Text = "Lock";
            this.materialButtonLock.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonLock.UseAccentColor = false;
            this.materialButtonLock.UseVisualStyleBackColor = true;
            this.materialButtonLock.Click += new System.EventHandler(this.materialButtonLock_ClickAsync);
            // 
            // materialButtonUnlock
            // 
            this.materialButtonUnlock.AutoSize = false;
            this.materialButtonUnlock.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonUnlock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonUnlock.Depth = 0;
            this.materialButtonUnlock.DrawShadows = true;
            this.materialButtonUnlock.HighEmphasis = false;
            this.materialButtonUnlock.Icon = global::Franco28Tool.Engine.Properties.Resources.unlock_icon;
            this.materialButtonUnlock.Location = new System.Drawing.Point(24, 284);
            this.materialButtonUnlock.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonUnlock.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonUnlock.Name = "materialButtonUnlock";
            this.materialButtonUnlock.Size = new System.Drawing.Size(168, 36);
            this.materialButtonUnlock.TabIndex = 66;
            this.materialButtonUnlock.Text = "Unlock";
            this.materialButtonUnlock.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonUnlock.UseAccentColor = false;
            this.materialButtonUnlock.UseVisualStyleBackColor = true;
            this.materialButtonUnlock.Click += new System.EventHandler(this.materialButtonUnlock_Click);
            // 
            // panelDebug
            // 
            this.panelDebug.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelDebug.BackColor = System.Drawing.Color.White;
            this.panelDebug.Controls.Add(this.TextBoxDebug);
            this.panelDebug.Controls.Add(this.TextBoxDebugInfo);
            this.panelDebug.Controls.Add(this.labelFreeSpace);
            this.panelDebug.Controls.Add(this.labelCPUusage);
            this.panelDebug.Controls.Add(this.labelFreeRam);
            this.panelDebug.Controls.Add(this.labelUserName);
            this.panelDebug.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDebug.Location = new System.Drawing.Point(0, 414);
            this.panelDebug.Name = "panelDebug";
            this.panelDebug.Size = new System.Drawing.Size(1015, 106);
            this.panelDebug.TabIndex = 55;
            // 
            // TextBoxDebug
            // 
            this.TextBoxDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxDebug.Depth = 0;
            this.TextBoxDebug.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TextBoxDebug.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            this.TextBoxDebug.Location = new System.Drawing.Point(536, 66);
            this.TextBoxDebug.MouseState = MaterialSkin.MouseState.HOVER;
            this.TextBoxDebug.Name = "TextBoxDebug";
            this.TextBoxDebug.Size = new System.Drawing.Size(476, 36);
            this.TextBoxDebug.TabIndex = 80;
            // 
            // TextBoxDebugInfo
            // 
            this.TextBoxDebugInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxDebugInfo.Depth = 0;
            this.TextBoxDebugInfo.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TextBoxDebugInfo.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            this.TextBoxDebugInfo.Location = new System.Drawing.Point(536, 6);
            this.TextBoxDebugInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.TextBoxDebugInfo.Name = "TextBoxDebugInfo";
            this.TextBoxDebugInfo.Size = new System.Drawing.Size(476, 36);
            this.TextBoxDebugInfo.TabIndex = 79;
            this.TextBoxDebugInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelFreeSpace
            // 
            this.labelFreeSpace.BackColor = System.Drawing.Color.White;
            this.labelFreeSpace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelFreeSpace.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFreeSpace.ForeColor = System.Drawing.Color.Black;
            this.labelFreeSpace.Image = ((System.Drawing.Image)(resources.GetObject("labelFreeSpace.Image")));
            this.labelFreeSpace.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelFreeSpace.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelFreeSpace.Location = new System.Drawing.Point(5, 66);
            this.labelFreeSpace.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFreeSpace.Name = "labelFreeSpace";
            this.labelFreeSpace.Size = new System.Drawing.Size(526, 36);
            this.labelFreeSpace.TabIndex = 48;
            this.labelFreeSpace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCPUusage
            // 
            this.labelCPUusage.BackColor = System.Drawing.Color.White;
            this.labelCPUusage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelCPUusage.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCPUusage.ForeColor = System.Drawing.Color.Black;
            this.labelCPUusage.Image = ((System.Drawing.Image)(resources.GetObject("labelCPUusage.Image")));
            this.labelCPUusage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelCPUusage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCPUusage.Location = new System.Drawing.Point(213, 6);
            this.labelCPUusage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCPUusage.Name = "labelCPUusage";
            this.labelCPUusage.Size = new System.Drawing.Size(141, 36);
            this.labelCPUusage.TabIndex = 50;
            this.labelCPUusage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelFreeRam
            // 
            this.labelFreeRam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelFreeRam.BackColor = System.Drawing.Color.White;
            this.labelFreeRam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelFreeRam.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFreeRam.ForeColor = System.Drawing.Color.Black;
            this.labelFreeRam.Image = ((System.Drawing.Image)(resources.GetObject("labelFreeRam.Image")));
            this.labelFreeRam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelFreeRam.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelFreeRam.Location = new System.Drawing.Point(5, 6);
            this.labelFreeRam.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFreeRam.Name = "labelFreeRam";
            this.labelFreeRam.Size = new System.Drawing.Size(204, 36);
            this.labelFreeRam.TabIndex = 47;
            this.labelFreeRam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelUserName
            // 
            this.labelUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelUserName.BackColor = System.Drawing.Color.White;
            this.labelUserName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelUserName.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserName.ForeColor = System.Drawing.Color.Black;
            this.labelUserName.Image = ((System.Drawing.Image)(resources.GetObject("labelUserName.Image")));
            this.labelUserName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelUserName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelUserName.Location = new System.Drawing.Point(358, 6);
            this.labelUserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(173, 36);
            this.labelUserName.TabIndex = 49;
            this.labelUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPageFIRMWARE
            // 
            this.tabPageFIRMWARE.BackColor = System.Drawing.Color.White;
            this.tabPageFIRMWARE.Controls.Add(this.panelFimrware);
            this.tabPageFIRMWARE.ImageKey = "iconfinder_ic_round_download_5760405.png";
            this.tabPageFIRMWARE.Location = new System.Drawing.Point(4, 31);
            this.tabPageFIRMWARE.Name = "tabPageFIRMWARE";
            this.tabPageFIRMWARE.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFIRMWARE.Size = new System.Drawing.Size(1015, 520);
            this.tabPageFIRMWARE.TabIndex = 6;
            this.tabPageFIRMWARE.Text = "Download Firmware";
            // 
            // panelFimrware
            // 
            this.panelFimrware.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelFimrware.Controls.Add(this.materialCardMotoToolFirmwares);
            this.panelFimrware.Controls.Add(this.materialLabel25);
            this.panelFimrware.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFimrware.Location = new System.Drawing.Point(3, 3);
            this.panelFimrware.Name = "panelFimrware";
            this.panelFimrware.Size = new System.Drawing.Size(1009, 514);
            this.panelFimrware.TabIndex = 67;
            // 
            // materialCardMotoToolFirmwares
            // 
            this.materialCardMotoToolFirmwares.AutoSize = true;
            this.materialCardMotoToolFirmwares.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCardMotoToolFirmwares.Controls.Add(this.materialButtonFirmwareCard);
            this.materialCardMotoToolFirmwares.Controls.Add(this.materialLabel14);
            this.materialCardMotoToolFirmwares.Controls.Add(this.materialLabel10);
            this.materialCardMotoToolFirmwares.Controls.Add(this.materialLabel38);
            this.materialCardMotoToolFirmwares.Depth = 0;
            this.materialCardMotoToolFirmwares.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCardMotoToolFirmwares.Location = new System.Drawing.Point(110, 99);
            this.materialCardMotoToolFirmwares.Margin = new System.Windows.Forms.Padding(7);
            this.materialCardMotoToolFirmwares.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCardMotoToolFirmwares.Name = "materialCardMotoToolFirmwares";
            this.materialCardMotoToolFirmwares.Padding = new System.Windows.Forms.Padding(14);
            this.materialCardMotoToolFirmwares.Size = new System.Drawing.Size(794, 322);
            this.materialCardMotoToolFirmwares.TabIndex = 68;
            // 
            // materialButtonFirmwareCard
            // 
            this.materialButtonFirmwareCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.materialButtonFirmwareCard.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonFirmwareCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonFirmwareCard.Depth = 0;
            this.materialButtonFirmwareCard.DrawShadows = true;
            this.materialButtonFirmwareCard.HighEmphasis = true;
            this.materialButtonFirmwareCard.Icon = null;
            this.materialButtonFirmwareCard.Location = new System.Drawing.Point(701, 266);
            this.materialButtonFirmwareCard.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonFirmwareCard.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonFirmwareCard.Name = "materialButtonFirmwareCard";
            this.materialButtonFirmwareCard.Size = new System.Drawing.Size(76, 36);
            this.materialButtonFirmwareCard.TabIndex = 1;
            this.materialButtonFirmwareCard.Text = "Deploy";
            this.materialButtonFirmwareCard.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.materialButtonFirmwareCard.UseAccentColor = false;
            this.materialButtonFirmwareCard.UseVisualStyleBackColor = true;
            this.materialButtonFirmwareCard.Click += new System.EventHandler(this.materialButtonFirmwareCard_Click);
            // 
            // materialLabel14
            // 
            this.materialLabel14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel14.Depth = 0;
            this.materialLabel14.Font = new System.Drawing.Font("Roboto", 34F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel14.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            this.materialLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel14.Location = new System.Drawing.Point(14, 148);
            this.materialLabel14.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel14.Name = "materialLabel14";
            this.materialLabel14.Size = new System.Drawing.Size(763, 45);
            this.materialLabel14.TabIndex = 62;
            this.materialLabel14.Text = "Click me to deploy menu downloads";
            this.materialLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel10
            // 
            this.materialLabel10.AutoSize = true;
            this.materialLabel10.Depth = 0;
            this.materialLabel10.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel10.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel10.HighEmphasis = true;
            this.materialLabel10.Location = new System.Drawing.Point(17, 14);
            this.materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel10.Name = "materialLabel10";
            this.materialLabel10.Size = new System.Drawing.Size(186, 24);
            this.materialLabel10.TabIndex = 0;
            this.materialLabel10.Text = "MotoTool Firmwares";
            // 
            // materialLabel38
            // 
            this.materialLabel38.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel38.Depth = 0;
            this.materialLabel38.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel38.Location = new System.Drawing.Point(17, 52);
            this.materialLabel38.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel38.Name = "materialLabel38";
            this.materialLabel38.Size = new System.Drawing.Size(760, 96);
            this.materialLabel38.TabIndex = 2;
            this.materialLabel38.Text = "Here you will be able to download the firmware that you want for your device!";
            // 
            // materialLabel25
            // 
            this.materialLabel25.AutoSize = true;
            this.materialLabel25.Depth = 0;
            this.materialLabel25.Font = new System.Drawing.Font("Roboto", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel25.FontType = MaterialSkin.MaterialSkinManager.fontType.H3;
            this.materialLabel25.Location = new System.Drawing.Point(14, 9);
            this.materialLabel25.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel25.Name = "materialLabel25";
            this.materialLabel25.Size = new System.Drawing.Size(450, 58);
            this.materialLabel25.TabIndex = 61;
            this.materialLabel25.Text = "Firmware Downloads";
            // 
            // tabPageFlashTool
            // 
            this.tabPageFlashTool.BackColor = System.Drawing.Color.White;
            this.tabPageFlashTool.Controls.Add(this.panelFlashTool);
            this.tabPageFlashTool.ImageKey = "round_build_white_24dp.png";
            this.tabPageFlashTool.Location = new System.Drawing.Point(4, 31);
            this.tabPageFlashTool.Name = "tabPageFlashTool";
            this.tabPageFlashTool.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFlashTool.Size = new System.Drawing.Size(1015, 520);
            this.tabPageFlashTool.TabIndex = 1;
            this.tabPageFlashTool.Text = "Flash Tool";
            // 
            // panelFlashTool
            // 
            this.panelFlashTool.Controls.Add(this.materialCardFlashTool);
            this.panelFlashTool.Controls.Add(this.materialLabel26);
            this.panelFlashTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFlashTool.Location = new System.Drawing.Point(3, 3);
            this.panelFlashTool.Name = "panelFlashTool";
            this.panelFlashTool.Size = new System.Drawing.Size(1009, 514);
            this.panelFlashTool.TabIndex = 0;
            // 
            // materialCardFlashTool
            // 
            this.materialCardFlashTool.AutoSize = true;
            this.materialCardFlashTool.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialCardFlashTool.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCardFlashTool.Controls.Add(this.materialButtonFlashTool);
            this.materialCardFlashTool.Controls.Add(this.materialLabel7);
            this.materialCardFlashTool.Controls.Add(this.materialLabel8);
            this.materialCardFlashTool.Controls.Add(this.materialLabel9);
            this.materialCardFlashTool.Depth = 0;
            this.materialCardFlashTool.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCardFlashTool.Location = new System.Drawing.Point(110, 99);
            this.materialCardFlashTool.Margin = new System.Windows.Forms.Padding(7);
            this.materialCardFlashTool.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCardFlashTool.Name = "materialCardFlashTool";
            this.materialCardFlashTool.Padding = new System.Windows.Forms.Padding(14);
            this.materialCardFlashTool.Size = new System.Drawing.Size(794, 322);
            this.materialCardFlashTool.TabIndex = 70;
            // 
            // materialButtonFlashTool
            // 
            this.materialButtonFlashTool.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.materialButtonFlashTool.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonFlashTool.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonFlashTool.Depth = 0;
            this.materialButtonFlashTool.DrawShadows = true;
            this.materialButtonFlashTool.HighEmphasis = true;
            this.materialButtonFlashTool.Icon = null;
            this.materialButtonFlashTool.Location = new System.Drawing.Point(701, 266);
            this.materialButtonFlashTool.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonFlashTool.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonFlashTool.Name = "materialButtonFlashTool";
            this.materialButtonFlashTool.Size = new System.Drawing.Size(76, 36);
            this.materialButtonFlashTool.TabIndex = 1;
            this.materialButtonFlashTool.Text = "Deploy";
            this.materialButtonFlashTool.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.materialButtonFlashTool.UseAccentColor = false;
            this.materialButtonFlashTool.UseVisualStyleBackColor = true;
            this.materialButtonFlashTool.Click += new System.EventHandler(this.materialButtonFlashTool_Click);
            // 
            // materialLabel7
            // 
            this.materialLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 34F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel7.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(14, 148);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(763, 45);
            this.materialLabel7.TabIndex = 62;
            this.materialLabel7.Text = "Click me to deploy menu Flash Tool";
            this.materialLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel8.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel8.HighEmphasis = true;
            this.materialLabel8.Location = new System.Drawing.Point(17, 14);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(184, 24);
            this.materialLabel8.TabIndex = 0;
            this.materialLabel8.Text = "MotoTool Flash Tool";
            // 
            // materialLabel9
            // 
            this.materialLabel9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel9.Depth = 0;
            this.materialLabel9.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel9.Location = new System.Drawing.Point(17, 52);
            this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel9.Name = "materialLabel9";
            this.materialLabel9.Size = new System.Drawing.Size(760, 96);
            this.materialLabel9.TabIndex = 2;
            this.materialLabel9.Text = "Here you will be able to flash any firmware, debloat any ROM and move files to TW" +
    "RP!";
            // 
            // materialLabel26
            // 
            this.materialLabel26.AutoSize = true;
            this.materialLabel26.Depth = 0;
            this.materialLabel26.Font = new System.Drawing.Font("Roboto", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel26.FontType = MaterialSkin.MaterialSkinManager.fontType.H3;
            this.materialLabel26.Location = new System.Drawing.Point(14, 9);
            this.materialLabel26.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel26.Name = "materialLabel26";
            this.materialLabel26.Size = new System.Drawing.Size(224, 58);
            this.materialLabel26.TabIndex = 69;
            this.materialLabel26.Text = "Flash Tool";
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.BackColor = System.Drawing.Color.White;
            this.tabPageSettings.Controls.Add(this.materialTabSelector2);
            this.tabPageSettings.Controls.Add(this.materialTabControl3);
            this.tabPageSettings.Controls.Add(this.materialLabel27);
            this.tabPageSettings.ImageKey = "iconfinder_settings_115801.png";
            this.tabPageSettings.Location = new System.Drawing.Point(4, 31);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(1015, 520);
            this.tabPageSettings.TabIndex = 2;
            this.tabPageSettings.Text = "Settings";
            // 
            // materialTabSelector2
            // 
            this.materialTabSelector2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialTabSelector2.BaseTabControl = this.materialTabControl3;
            this.materialTabSelector2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialTabSelector2.Depth = 0;
            this.materialTabSelector2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTabSelector2.Location = new System.Drawing.Point(0, 76);
            this.materialTabSelector2.Margin = new System.Windows.Forms.Padding(0);
            this.materialTabSelector2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector2.Name = "materialTabSelector2";
            this.materialTabSelector2.Size = new System.Drawing.Size(1016, 38);
            this.materialTabSelector2.TabIndex = 72;
            this.materialTabSelector2.Text = "materialTabSelector2";
            // 
            // materialTabControl3
            // 
            this.materialTabControl3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialTabControl3.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.materialTabControl3.Controls.Add(this.tabPage11);
            this.materialTabControl3.Controls.Add(this.tabPage10);
            this.materialTabControl3.Depth = 0;
            this.materialTabControl3.Location = new System.Drawing.Point(3, 114);
            this.materialTabControl3.Margin = new System.Windows.Forms.Padding(0);
            this.materialTabControl3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl3.Name = "materialTabControl3";
            this.materialTabControl3.SelectedIndex = 0;
            this.materialTabControl3.Size = new System.Drawing.Size(1013, 403);
            this.materialTabControl3.TabIndex = 71;
            // 
            // tabPage11
            // 
            this.tabPage11.BackColor = System.Drawing.Color.White;
            this.tabPage11.Controls.Add(this.materialLabel15);
            this.tabPage11.Controls.Add(this.materialSwitchAutoSaveLogs);
            this.tabPage11.Controls.Add(this.materialButtonRemoveToolDeviceData);
            this.tabPage11.Controls.Add(this.materialButtonAddNewDevice);
            this.tabPage11.Controls.Add(this.materialLabel13);
            this.tabPage11.Controls.Add(this.materialButtonOpenFirmwareFolder);
            this.tabPage11.Controls.Add(this.materialButtonOpenADBFolder);
            this.tabPage11.Controls.Add(this.materialLabel2);
            this.tabPage11.Controls.Add(this.materialButtonclearallfolders);
            this.tabPage11.Controls.Add(this.materialButtonHelp);
            this.tabPage11.Controls.Add(this.materialButtonUninstall);
            this.tabPage11.Controls.Add(this.materialButtonCMD);
            this.tabPage11.Controls.Add(this.materialLabel6);
            this.tabPage11.Controls.Add(this.materialButtonCheckUpdates);
            this.tabPage11.Location = new System.Drawing.Point(4, 25);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage11.Size = new System.Drawing.Size(1005, 374);
            this.tabPage11.TabIndex = 1;
            this.tabPage11.Text = "Tool Settings";
            // 
            // materialLabel15
            // 
            this.materialLabel15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel15.AutoSize = true;
            this.materialLabel15.Depth = 0;
            this.materialLabel15.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel15.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel15.HighEmphasis = true;
            this.materialLabel15.Location = new System.Drawing.Point(548, 191);
            this.materialLabel15.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel15.Name = "materialLabel15";
            this.materialLabel15.Size = new System.Drawing.Size(88, 24);
            this.materialLabel15.TabIndex = 67;
            this.materialLabel15.Text = "Tool Logs";
            this.materialLabel15.UseAccent = true;
            // 
            // materialSwitchAutoSaveLogs
            // 
            this.materialSwitchAutoSaveLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.materialSwitchAutoSaveLogs.AutoSize = true;
            this.materialSwitchAutoSaveLogs.Checked = true;
            this.materialSwitchAutoSaveLogs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.materialSwitchAutoSaveLogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialSwitchAutoSaveLogs.Depth = 0;
            this.materialSwitchAutoSaveLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialSwitchAutoSaveLogs.Location = new System.Drawing.Point(552, 221);
            this.materialSwitchAutoSaveLogs.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitchAutoSaveLogs.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitchAutoSaveLogs.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitchAutoSaveLogs.Name = "materialSwitchAutoSaveLogs";
            this.materialSwitchAutoSaveLogs.Ripple = true;
            this.materialSwitchAutoSaveLogs.Size = new System.Drawing.Size(236, 37);
            this.materialSwitchAutoSaveLogs.TabIndex = 66;
            this.materialSwitchAutoSaveLogs.Text = "Logs - Autosave tool logs";
            this.materialSwitchAutoSaveLogs.UseVisualStyleBackColor = true;
            this.materialSwitchAutoSaveLogs.CheckedChanged += new System.EventHandler(this.materialSwitchAutoSaveLogs_CheckedChanged);
            // 
            // materialButtonRemoveToolDeviceData
            // 
            this.materialButtonRemoveToolDeviceData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.materialButtonRemoveToolDeviceData.AutoSize = false;
            this.materialButtonRemoveToolDeviceData.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonRemoveToolDeviceData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonRemoveToolDeviceData.Depth = 0;
            this.materialButtonRemoveToolDeviceData.DrawShadows = true;
            this.materialButtonRemoveToolDeviceData.HighEmphasis = false;
            this.materialButtonRemoveToolDeviceData.Icon = ((System.Drawing.Image)(resources.GetObject("materialButtonRemoveToolDeviceData.Icon")));
            this.materialButtonRemoveToolDeviceData.Location = new System.Drawing.Point(552, 92);
            this.materialButtonRemoveToolDeviceData.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonRemoveToolDeviceData.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonRemoveToolDeviceData.Name = "materialButtonRemoveToolDeviceData";
            this.materialButtonRemoveToolDeviceData.Size = new System.Drawing.Size(290, 36);
            this.materialButtonRemoveToolDeviceData.TabIndex = 19;
            this.materialButtonRemoveToolDeviceData.Text = "Remove Tool saved device data";
            this.materialButtonRemoveToolDeviceData.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonRemoveToolDeviceData.UseAccentColor = false;
            this.materialButtonRemoveToolDeviceData.UseVisualStyleBackColor = true;
            this.materialButtonRemoveToolDeviceData.Click += new System.EventHandler(this.materialButtonRemoveToolDeviceData_Click);
            // 
            // materialButtonAddNewDevice
            // 
            this.materialButtonAddNewDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.materialButtonAddNewDevice.AutoSize = false;
            this.materialButtonAddNewDevice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonAddNewDevice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonAddNewDevice.Depth = 0;
            this.materialButtonAddNewDevice.DrawShadows = true;
            this.materialButtonAddNewDevice.HighEmphasis = false;
            this.materialButtonAddNewDevice.Icon = ((System.Drawing.Image)(resources.GetObject("materialButtonAddNewDevice.Icon")));
            this.materialButtonAddNewDevice.Location = new System.Drawing.Point(552, 44);
            this.materialButtonAddNewDevice.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonAddNewDevice.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonAddNewDevice.Name = "materialButtonAddNewDevice";
            this.materialButtonAddNewDevice.Size = new System.Drawing.Size(290, 36);
            this.materialButtonAddNewDevice.TabIndex = 18;
            this.materialButtonAddNewDevice.Text = "Add new device";
            this.materialButtonAddNewDevice.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonAddNewDevice.UseAccentColor = false;
            this.materialButtonAddNewDevice.UseVisualStyleBackColor = true;
            this.materialButtonAddNewDevice.Click += new System.EventHandler(this.materialButtonAddNewDevice_Click);
            // 
            // materialLabel13
            // 
            this.materialLabel13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel13.AutoSize = true;
            this.materialLabel13.Depth = 0;
            this.materialLabel13.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel13.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel13.HighEmphasis = true;
            this.materialLabel13.Location = new System.Drawing.Point(548, 14);
            this.materialLabel13.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel13.Name = "materialLabel13";
            this.materialLabel13.Size = new System.Drawing.Size(115, 24);
            this.materialLabel13.TabIndex = 17;
            this.materialLabel13.Text = "Tool Devices";
            this.materialLabel13.UseAccent = true;
            // 
            // materialButtonOpenFirmwareFolder
            // 
            this.materialButtonOpenFirmwareFolder.AutoSize = false;
            this.materialButtonOpenFirmwareFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonOpenFirmwareFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonOpenFirmwareFolder.Depth = 0;
            this.materialButtonOpenFirmwareFolder.DrawShadows = true;
            this.materialButtonOpenFirmwareFolder.HighEmphasis = false;
            this.materialButtonOpenFirmwareFolder.Icon = ((System.Drawing.Image)(resources.GetObject("materialButtonOpenFirmwareFolder.Icon")));
            this.materialButtonOpenFirmwareFolder.Location = new System.Drawing.Point(17, 269);
            this.materialButtonOpenFirmwareFolder.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonOpenFirmwareFolder.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonOpenFirmwareFolder.Name = "materialButtonOpenFirmwareFolder";
            this.materialButtonOpenFirmwareFolder.Size = new System.Drawing.Size(214, 36);
            this.materialButtonOpenFirmwareFolder.TabIndex = 16;
            this.materialButtonOpenFirmwareFolder.Text = "Open Firmware Folder";
            this.materialButtonOpenFirmwareFolder.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonOpenFirmwareFolder.UseAccentColor = false;
            this.materialButtonOpenFirmwareFolder.UseVisualStyleBackColor = true;
            this.materialButtonOpenFirmwareFolder.Click += new System.EventHandler(this.materialButtonOpenFirmwareFolder_Click);
            // 
            // materialButtonOpenADBFolder
            // 
            this.materialButtonOpenADBFolder.AutoSize = false;
            this.materialButtonOpenADBFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonOpenADBFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonOpenADBFolder.Depth = 0;
            this.materialButtonOpenADBFolder.DrawShadows = true;
            this.materialButtonOpenADBFolder.HighEmphasis = false;
            this.materialButtonOpenADBFolder.Icon = ((System.Drawing.Image)(resources.GetObject("materialButtonOpenADBFolder.Icon")));
            this.materialButtonOpenADBFolder.Location = new System.Drawing.Point(17, 221);
            this.materialButtonOpenADBFolder.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonOpenADBFolder.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonOpenADBFolder.Name = "materialButtonOpenADBFolder";
            this.materialButtonOpenADBFolder.Size = new System.Drawing.Size(214, 36);
            this.materialButtonOpenADBFolder.TabIndex = 15;
            this.materialButtonOpenADBFolder.Text = "Open Tool Folder";
            this.materialButtonOpenADBFolder.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonOpenADBFolder.UseAccentColor = false;
            this.materialButtonOpenADBFolder.UseVisualStyleBackColor = true;
            this.materialButtonOpenADBFolder.Click += new System.EventHandler(this.materialButtonOpenADBFolder_Click);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel2.HighEmphasis = true;
            this.materialLabel2.Location = new System.Drawing.Point(17, 191);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(111, 24);
            this.materialLabel2.TabIndex = 14;
            this.materialLabel2.Text = "Tool Folders";
            this.materialLabel2.UseAccent = true;
            // 
            // materialButtonclearallfolders
            // 
            this.materialButtonclearallfolders.AutoSize = false;
            this.materialButtonclearallfolders.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonclearallfolders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonclearallfolders.Depth = 0;
            this.materialButtonclearallfolders.DrawShadows = true;
            this.materialButtonclearallfolders.HighEmphasis = false;
            this.materialButtonclearallfolders.Icon = global::Franco28Tool.Engine.Properties.Resources.folder;
            this.materialButtonclearallfolders.Location = new System.Drawing.Point(239, 221);
            this.materialButtonclearallfolders.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonclearallfolders.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonclearallfolders.Name = "materialButtonclearallfolders";
            this.materialButtonclearallfolders.Size = new System.Drawing.Size(214, 36);
            this.materialButtonclearallfolders.TabIndex = 13;
            this.materialButtonclearallfolders.Text = "Clear all folders";
            this.materialButtonclearallfolders.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonclearallfolders.UseAccentColor = false;
            this.materialButtonclearallfolders.UseVisualStyleBackColor = true;
            this.materialButtonclearallfolders.Click += new System.EventHandler(this.materialButtonclearallfolders_Click);
            // 
            // materialButtonHelp
            // 
            this.materialButtonHelp.AutoSize = false;
            this.materialButtonHelp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonHelp.Depth = 0;
            this.materialButtonHelp.DrawShadows = true;
            this.materialButtonHelp.HighEmphasis = false;
            this.materialButtonHelp.Icon = global::Franco28Tool.Engine.Properties.Resources.icons8_info_64__1_;
            this.materialButtonHelp.Location = new System.Drawing.Point(206, 92);
            this.materialButtonHelp.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonHelp.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonHelp.Name = "materialButtonHelp";
            this.materialButtonHelp.Size = new System.Drawing.Size(181, 36);
            this.materialButtonHelp.TabIndex = 12;
            this.materialButtonHelp.Text = "HELP";
            this.materialButtonHelp.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonHelp.UseAccentColor = false;
            this.materialButtonHelp.UseVisualStyleBackColor = true;
            this.materialButtonHelp.Click += new System.EventHandler(this.materialButtonHelp_Click);
            // 
            // materialButtonUninstall
            // 
            this.materialButtonUninstall.AutoSize = false;
            this.materialButtonUninstall.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonUninstall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonUninstall.Depth = 0;
            this.materialButtonUninstall.DrawShadows = true;
            this.materialButtonUninstall.HighEmphasis = false;
            this.materialButtonUninstall.Icon = global::Franco28Tool.Engine.Properties.Resources.unins;
            this.materialButtonUninstall.Location = new System.Drawing.Point(206, 44);
            this.materialButtonUninstall.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonUninstall.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonUninstall.Name = "materialButtonUninstall";
            this.materialButtonUninstall.Size = new System.Drawing.Size(181, 36);
            this.materialButtonUninstall.TabIndex = 11;
            this.materialButtonUninstall.Text = "Uninstall";
            this.materialButtonUninstall.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonUninstall.UseAccentColor = false;
            this.materialButtonUninstall.UseVisualStyleBackColor = true;
            this.materialButtonUninstall.Click += new System.EventHandler(this.materialButtonUninstall_Click);
            // 
            // materialButtonCMD
            // 
            this.materialButtonCMD.AutoSize = false;
            this.materialButtonCMD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonCMD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonCMD.Depth = 0;
            this.materialButtonCMD.DrawShadows = true;
            this.materialButtonCMD.HighEmphasis = false;
            this.materialButtonCMD.Icon = global::Franco28Tool.Engine.Properties.Resources.icons8_consola_16;
            this.materialButtonCMD.Location = new System.Drawing.Point(17, 92);
            this.materialButtonCMD.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonCMD.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonCMD.Name = "materialButtonCMD";
            this.materialButtonCMD.Size = new System.Drawing.Size(181, 36);
            this.materialButtonCMD.TabIndex = 10;
            this.materialButtonCMD.Text = "start CMD";
            this.materialButtonCMD.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonCMD.UseAccentColor = false;
            this.materialButtonCMD.UseVisualStyleBackColor = true;
            this.materialButtonCMD.Click += new System.EventHandler(this.materialButtonCMD_Click);
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel6.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel6.HighEmphasis = true;
            this.materialLabel6.Location = new System.Drawing.Point(17, 14);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(101, 24);
            this.materialLabel6.TabIndex = 9;
            this.materialLabel6.Text = "Tool Extras";
            this.materialLabel6.UseAccent = true;
            // 
            // materialButtonCheckUpdates
            // 
            this.materialButtonCheckUpdates.AutoSize = false;
            this.materialButtonCheckUpdates.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonCheckUpdates.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonCheckUpdates.Depth = 0;
            this.materialButtonCheckUpdates.DrawShadows = true;
            this.materialButtonCheckUpdates.HighEmphasis = false;
            this.materialButtonCheckUpdates.Icon = ((System.Drawing.Image)(resources.GetObject("materialButtonCheckUpdates.Icon")));
            this.materialButtonCheckUpdates.Location = new System.Drawing.Point(17, 44);
            this.materialButtonCheckUpdates.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonCheckUpdates.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonCheckUpdates.Name = "materialButtonCheckUpdates";
            this.materialButtonCheckUpdates.Size = new System.Drawing.Size(181, 36);
            this.materialButtonCheckUpdates.TabIndex = 8;
            this.materialButtonCheckUpdates.Text = "Check Updates";
            this.materialButtonCheckUpdates.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonCheckUpdates.UseAccentColor = false;
            this.materialButtonCheckUpdates.UseVisualStyleBackColor = true;
            this.materialButtonCheckUpdates.Click += new System.EventHandler(this.materialButtonCheckUpdates_Click);
            // 
            // tabPage10
            // 
            this.tabPage10.BackColor = System.Drawing.Color.White;
            this.tabPage10.Controls.Add(this.materialLabel4);
            this.tabPage10.Controls.Add(this.materialLabel1);
            this.tabPage10.Controls.Add(this.MaterialButtonChangeColor);
            this.tabPage10.Controls.Add(this.materialSwitchDrawerShowIconsWhenHidden);
            this.tabPage10.Controls.Add(this.materialSwitchDrawerUseColors);
            this.tabPage10.Controls.Add(this.materialSwitchDrawerBackgroundWithAccent);
            this.tabPage10.Controls.Add(this.materialButtonChangeTheme);
            this.tabPage10.Controls.Add(this.materialSwitchDrawerHighlightWithAccent);
            this.tabPage10.Location = new System.Drawing.Point(4, 25);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(1005, 374);
            this.tabPage10.TabIndex = 0;
            this.tabPage10.Text = "Tool Theme";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel4.HighEmphasis = true;
            this.materialLabel4.Location = new System.Drawing.Point(13, 96);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(174, 24);
            this.materialLabel4.TabIndex = 71;
            this.materialLabel4.Text = "Tool System Colors";
            this.materialLabel4.UseAccent = true;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel1.HighEmphasis = true;
            this.materialLabel1.Location = new System.Drawing.Point(13, 14);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(107, 24);
            this.materialLabel1.TabIndex = 4;
            this.materialLabel1.Text = "Tool Theme";
            this.materialLabel1.UseAccent = true;
            // 
            // MaterialButtonChangeColor
            // 
            this.MaterialButtonChangeColor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MaterialButtonChangeColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MaterialButtonChangeColor.Depth = 0;
            this.MaterialButtonChangeColor.DrawShadows = true;
            this.MaterialButtonChangeColor.HighEmphasis = true;
            this.MaterialButtonChangeColor.Icon = null;
            this.MaterialButtonChangeColor.Location = new System.Drawing.Point(17, 126);
            this.MaterialButtonChangeColor.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaterialButtonChangeColor.MouseState = MaterialSkin.MouseState.HOVER;
            this.MaterialButtonChangeColor.Name = "MaterialButtonChangeColor";
            this.MaterialButtonChangeColor.Size = new System.Drawing.Size(140, 36);
            this.MaterialButtonChangeColor.TabIndex = 64;
            this.MaterialButtonChangeColor.Text = "Change Colors";
            this.MaterialButtonChangeColor.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.MaterialButtonChangeColor.UseAccentColor = false;
            this.MaterialButtonChangeColor.UseVisualStyleBackColor = true;
            this.MaterialButtonChangeColor.Click += new System.EventHandler(this.MaterialButtonChangeColor_Click);
            // 
            // materialSwitchDrawerShowIconsWhenHidden
            // 
            this.materialSwitchDrawerShowIconsWhenHidden.AutoSize = true;
            this.materialSwitchDrawerShowIconsWhenHidden.Checked = true;
            this.materialSwitchDrawerShowIconsWhenHidden.CheckState = System.Windows.Forms.CheckState.Checked;
            this.materialSwitchDrawerShowIconsWhenHidden.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialSwitchDrawerShowIconsWhenHidden.Depth = 0;
            this.materialSwitchDrawerShowIconsWhenHidden.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialSwitchDrawerShowIconsWhenHidden.Location = new System.Drawing.Point(17, 283);
            this.materialSwitchDrawerShowIconsWhenHidden.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitchDrawerShowIconsWhenHidden.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitchDrawerShowIconsWhenHidden.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitchDrawerShowIconsWhenHidden.Name = "materialSwitchDrawerShowIconsWhenHidden";
            this.materialSwitchDrawerShowIconsWhenHidden.Ripple = true;
            this.materialSwitchDrawerShowIconsWhenHidden.Size = new System.Drawing.Size(309, 37);
            this.materialSwitchDrawerShowIconsWhenHidden.TabIndex = 70;
            this.materialSwitchDrawerShowIconsWhenHidden.Text = "Drawer - Display Icons when hidden";
            this.materialSwitchDrawerShowIconsWhenHidden.UseVisualStyleBackColor = true;
            this.materialSwitchDrawerShowIconsWhenHidden.CheckedChanged += new System.EventHandler(this.materialSwitchDrawerShowIconsWhenHidden_CheckedChanged);
            // 
            // materialSwitchDrawerUseColors
            // 
            this.materialSwitchDrawerUseColors.AutoSize = true;
            this.materialSwitchDrawerUseColors.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialSwitchDrawerUseColors.Depth = 0;
            this.materialSwitchDrawerUseColors.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialSwitchDrawerUseColors.Location = new System.Drawing.Point(17, 173);
            this.materialSwitchDrawerUseColors.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitchDrawerUseColors.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitchDrawerUseColors.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitchDrawerUseColors.Name = "materialSwitchDrawerUseColors";
            this.materialSwitchDrawerUseColors.Ripple = true;
            this.materialSwitchDrawerUseColors.Size = new System.Drawing.Size(193, 37);
            this.materialSwitchDrawerUseColors.TabIndex = 65;
            this.materialSwitchDrawerUseColors.Text = "Drawer - Use colors";
            this.materialSwitchDrawerUseColors.UseVisualStyleBackColor = true;
            this.materialSwitchDrawerUseColors.CheckedChanged += new System.EventHandler(this.materialSwitchDrawerUseColors_CheckedChanged);
            // 
            // materialSwitchDrawerBackgroundWithAccent
            // 
            this.materialSwitchDrawerBackgroundWithAccent.AutoSize = true;
            this.materialSwitchDrawerBackgroundWithAccent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialSwitchDrawerBackgroundWithAccent.Depth = 0;
            this.materialSwitchDrawerBackgroundWithAccent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialSwitchDrawerBackgroundWithAccent.Location = new System.Drawing.Point(17, 246);
            this.materialSwitchDrawerBackgroundWithAccent.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitchDrawerBackgroundWithAccent.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitchDrawerBackgroundWithAccent.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitchDrawerBackgroundWithAccent.Name = "materialSwitchDrawerBackgroundWithAccent";
            this.materialSwitchDrawerBackgroundWithAccent.Ripple = true;
            this.materialSwitchDrawerBackgroundWithAccent.Size = new System.Drawing.Size(291, 37);
            this.materialSwitchDrawerBackgroundWithAccent.TabIndex = 67;
            this.materialSwitchDrawerBackgroundWithAccent.Text = "Drawer - Background with Accent";
            this.materialSwitchDrawerBackgroundWithAccent.UseVisualStyleBackColor = true;
            this.materialSwitchDrawerBackgroundWithAccent.CheckedChanged += new System.EventHandler(this.MaterialSwitchDrawerBackgroundWithAccent_CheckedChanged);
            // 
            // materialButtonChangeTheme
            // 
            this.materialButtonChangeTheme.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonChangeTheme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonChangeTheme.Depth = 0;
            this.materialButtonChangeTheme.DrawShadows = true;
            this.materialButtonChangeTheme.HighEmphasis = true;
            this.materialButtonChangeTheme.Icon = null;
            this.materialButtonChangeTheme.Location = new System.Drawing.Point(17, 44);
            this.materialButtonChangeTheme.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonChangeTheme.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonChangeTheme.Name = "materialButtonChangeTheme";
            this.materialButtonChangeTheme.Size = new System.Drawing.Size(133, 36);
            this.materialButtonChangeTheme.TabIndex = 63;
            this.materialButtonChangeTheme.Text = "Change Theme";
            this.materialButtonChangeTheme.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonChangeTheme.UseAccentColor = true;
            this.materialButtonChangeTheme.UseVisualStyleBackColor = true;
            this.materialButtonChangeTheme.Click += new System.EventHandler(this.materialButtonChangeTheme_Click);
            // 
            // materialSwitchDrawerHighlightWithAccent
            // 
            this.materialSwitchDrawerHighlightWithAccent.AutoSize = true;
            this.materialSwitchDrawerHighlightWithAccent.Checked = true;
            this.materialSwitchDrawerHighlightWithAccent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.materialSwitchDrawerHighlightWithAccent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialSwitchDrawerHighlightWithAccent.Depth = 0;
            this.materialSwitchDrawerHighlightWithAccent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialSwitchDrawerHighlightWithAccent.Location = new System.Drawing.Point(17, 210);
            this.materialSwitchDrawerHighlightWithAccent.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitchDrawerHighlightWithAccent.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitchDrawerHighlightWithAccent.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitchDrawerHighlightWithAccent.Name = "materialSwitchDrawerHighlightWithAccent";
            this.materialSwitchDrawerHighlightWithAccent.Ripple = true;
            this.materialSwitchDrawerHighlightWithAccent.Size = new System.Drawing.Size(270, 37);
            this.materialSwitchDrawerHighlightWithAccent.TabIndex = 66;
            this.materialSwitchDrawerHighlightWithAccent.Text = "Drawer - Highlight with Accent";
            this.materialSwitchDrawerHighlightWithAccent.UseVisualStyleBackColor = true;
            this.materialSwitchDrawerHighlightWithAccent.CheckedChanged += new System.EventHandler(this.MaterialSwitchDrawerHighlightWithAccent_CheckedChanged);
            // 
            // materialLabel27
            // 
            this.materialLabel27.AutoSize = true;
            this.materialLabel27.Depth = 0;
            this.materialLabel27.Font = new System.Drawing.Font("Roboto", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel27.FontType = MaterialSkin.MaterialSkinManager.fontType.H3;
            this.materialLabel27.Location = new System.Drawing.Point(14, 9);
            this.materialLabel27.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel27.Name = "materialLabel27";
            this.materialLabel27.Size = new System.Drawing.Size(283, 58);
            this.materialLabel27.TabIndex = 62;
            this.materialLabel27.Text = "Tool Settings";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1029, 622);
            this.Controls.Add(this.panelChild);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.materialTabControl1;
            this.DrawerWidth = 220;
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(3, 64, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.exit);
            this.Load += new System.EventHandler(this.MainForm_LoadAsync);
            this.panelChild.ResumeLayout(false);
            this.materialTabControl1.ResumeLayout(false);
            this.tabPageHOME.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelDownload.ResumeLayout(false);
            this.panelDownload.PerformLayout();
            this.panelDebug.ResumeLayout(false);
            this.tabPageFIRMWARE.ResumeLayout(false);
            this.panelFimrware.ResumeLayout(false);
            this.panelFimrware.PerformLayout();
            this.materialCardMotoToolFirmwares.ResumeLayout(false);
            this.materialCardMotoToolFirmwares.PerformLayout();
            this.tabPageFlashTool.ResumeLayout(false);
            this.panelFlashTool.ResumeLayout(false);
            this.panelFlashTool.PerformLayout();
            this.materialCardFlashTool.ResumeLayout(false);
            this.materialCardFlashTool.PerformLayout();
            this.tabPageSettings.ResumeLayout(false);
            this.tabPageSettings.PerformLayout();
            this.materialTabControl3.ResumeLayout(false);
            this.tabPage11.ResumeLayout(false);
            this.tabPage11.PerformLayout();
            this.tabPage10.ResumeLayout(false);
            this.tabPage10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private ImageList menuIconList;
        private Panel panelChild;
        private MaterialTabControl materialTabControl1;
        private TabPage tabPageHOME;
        public Panel panelDebug;
        internal Label labelFreeSpace;
        internal Label labelCPUusage;
        internal Label labelFreeRam;
        internal Label labelUserName;
        private TabPage tabPageFIRMWARE;
        private TabPage tabPageFlashTool;
        private TabPage tabPageSettings;
        private MaterialTabSelector materialTabSelector2;
        private MaterialTabControl materialTabControl3;
        private TabPage tabPage10;
        private MaterialLabel materialLabel1;
        private MaterialButton MaterialButtonChangeColor;
        private MaterialSwitch materialSwitchDrawerShowIconsWhenHidden;
        private MaterialSwitch materialSwitchDrawerUseColors;
        private MaterialSwitch materialSwitchDrawerBackgroundWithAccent;
        private MaterialButton materialButtonChangeTheme;
        private MaterialSwitch materialSwitchDrawerHighlightWithAccent;
        private TabPage tabPage11;
        private MaterialButton materialButtonUninstall;
        private MaterialButton materialButtonCMD;
        private MaterialLabel materialLabel6;
        private MaterialButton materialButtonCheckUpdates;
        private MaterialLabel materialLabel27;
        private MaterialButton materialButtonHelp;
        private Panel panelMain;
        private ListBox listBoxDeviceStatus;
        private MaterialLabel materialLabel12;
        private MaterialLabel materialLabel11;
        private MaterialLabel materialLabel5;
        private MaterialLabel materialLabel3;
        private MaterialButton materialButtonFlashLogo;
        private MaterialButton materialButtonBlankFlash;
        private MaterialButton materialButtonRebootRecovery;
        private MaterialButton materialButtonRebootBootloader;
        private MaterialButton materialButtonBootTWRP;
        private MaterialButton materialButtonFlashTWRP;
        private MaterialButton materialButtonLock;
        private MaterialButton materialButtonUnlock;
        private Panel panelFimrware;
        private MaterialLabel materialLabel25;
        private MaterialButton materialButtonclearallfolders;
        private MaterialLabel materialLabel2;
        private MaterialButton materialButtonOpenADBFolder;
        private MaterialButton materialButtonOpenFirmwareFolder;
        private MaterialLabel materialLabel4;
        private MaterialCard materialCardMotoToolFirmwares;
        private MaterialButton materialButtonFirmwareCard;
        private MaterialLabel materialLabel14;
        private MaterialLabel materialLabel10;
        private MaterialLabel materialLabel38;
        private Panel panelFlashTool;
        private MaterialCard materialCardFlashTool;
        private MaterialButton materialButtonFlashTool;
        private MaterialLabel materialLabel7;
        private MaterialLabel materialLabel8;
        private MaterialLabel materialLabel9;
        private MaterialLabel materialLabel26;
        private Panel panelDownload;
        private MaterialLabel TextBoxDebugInfo;
        private MaterialLabel TextBoxDebug;
        private MaterialLabel materialLabel24;
        private MaterialLabel materialLabel13;
        private MaterialButton materialButtonAddNewDevice;
        private MaterialButton materialButtonRemoveToolDeviceData;
        private RichTextBox console;
        private MaterialLabel materialLabel15;
        private MaterialSwitch materialSwitchAutoSaveLogs;
    }
}