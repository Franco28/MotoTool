
namespace Franco28Tool.Engine
{
    partial class MotoFlash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MotoFlash));
            this.panelMain = new System.Windows.Forms.Panel();
            this.progressBar_Total = new MaterialSkin.Controls.MaterialProgressBar();
            this.materialButtonExit = new MaterialSkin.Controls.MaterialButton();
            this.listBoxDeviceStatus = new System.Windows.Forms.ListBox();
            this.consoleMotoFlash = new System.Windows.Forms.RichTextBox();
            this.materialButtonDowngradeMoto = new MaterialSkin.Controls.MaterialButton();
            this.labelDebugLogo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.materialSwitchFlashAll = new MaterialSkin.Controls.MaterialSwitch();
            this.materialSwitchFlashAllExceptModem = new MaterialSkin.Controls.MaterialSwitch();
            this.materialButtonFlashMoto = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.panelMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.AutoSize = true;
            this.panelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.progressBar_Total);
            this.panelMain.Controls.Add(this.materialButtonExit);
            this.panelMain.Controls.Add(this.listBoxDeviceStatus);
            this.panelMain.Controls.Add(this.consoleMotoFlash);
            this.panelMain.Controls.Add(this.materialButtonDowngradeMoto);
            this.panelMain.Controls.Add(this.labelDebugLogo);
            this.panelMain.Controls.Add(this.groupBox1);
            this.panelMain.Controls.Add(this.materialButtonFlashMoto);
            this.panelMain.Controls.Add(this.materialLabel9);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(995, 413);
            this.panelMain.TabIndex = 0;
            // 
            // progressBar_Total
            // 
            this.progressBar_Total.BackColor = System.Drawing.Color.White;
            this.progressBar_Total.Depth = 0;
            this.progressBar_Total.Location = new System.Drawing.Point(57, 244);
            this.progressBar_Total.MouseState = MaterialSkin.MouseState.HOVER;
            this.progressBar_Total.Name = "progressBar_Total";
            this.progressBar_Total.Size = new System.Drawing.Size(926, 5);
            this.progressBar_Total.TabIndex = 132;
            this.progressBar_Total.Value = 1;
            // 
            // materialButtonExit
            // 
            this.materialButtonExit.AutoSize = false;
            this.materialButtonExit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonExit.Depth = 0;
            this.materialButtonExit.DrawShadows = true;
            this.materialButtonExit.HighEmphasis = false;
            this.materialButtonExit.Icon = ((System.Drawing.Image)(resources.GetObject("materialButtonExit.Icon")));
            this.materialButtonExit.Location = new System.Drawing.Point(7, 3);
            this.materialButtonExit.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonExit.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonExit.Name = "materialButtonExit";
            this.materialButtonExit.Size = new System.Drawing.Size(39, 30);
            this.materialButtonExit.TabIndex = 131;
            this.materialButtonExit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonExit.UseAccentColor = true;
            this.materialButtonExit.UseVisualStyleBackColor = true;
            this.materialButtonExit.Click += new System.EventHandler(this.materialButtonExit_Click);
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
            " Mode: ---"});
            this.listBoxDeviceStatus.Location = new System.Drawing.Point(57, 42);
            this.listBoxDeviceStatus.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listBoxDeviceStatus.MultiColumn = true;
            this.listBoxDeviceStatus.Name = "listBoxDeviceStatus";
            this.listBoxDeviceStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBoxDeviceStatus.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxDeviceStatus.Size = new System.Drawing.Size(926, 52);
            this.listBoxDeviceStatus.TabIndex = 91;
            // 
            // consoleMotoFlash
            // 
            this.consoleMotoFlash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consoleMotoFlash.Location = new System.Drawing.Point(57, 100);
            this.consoleMotoFlash.Name = "consoleMotoFlash";
            this.consoleMotoFlash.ReadOnly = true;
            this.consoleMotoFlash.Size = new System.Drawing.Size(926, 138);
            this.consoleMotoFlash.TabIndex = 90;
            this.consoleMotoFlash.Text = "";
            // 
            // materialButtonDowngradeMoto
            // 
            this.materialButtonDowngradeMoto.AutoSize = false;
            this.materialButtonDowngradeMoto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonDowngradeMoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonDowngradeMoto.Depth = 0;
            this.materialButtonDowngradeMoto.DrawShadows = true;
            this.materialButtonDowngradeMoto.HighEmphasis = true;
            this.materialButtonDowngradeMoto.Icon = null;
            this.materialButtonDowngradeMoto.Location = new System.Drawing.Point(7, 362);
            this.materialButtonDowngradeMoto.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonDowngradeMoto.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonDowngradeMoto.Name = "materialButtonDowngradeMoto";
            this.materialButtonDowngradeMoto.Size = new System.Drawing.Size(158, 36);
            this.materialButtonDowngradeMoto.TabIndex = 89;
            this.materialButtonDowngradeMoto.Text = "Downgrade Moto";
            this.materialButtonDowngradeMoto.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonDowngradeMoto.UseAccentColor = true;
            this.materialButtonDowngradeMoto.UseVisualStyleBackColor = true;
            this.materialButtonDowngradeMoto.Click += new System.EventHandler(this.downgradeBTN_Click);
            // 
            // labelDebugLogo
            // 
            this.labelDebugLogo.BackColor = System.Drawing.Color.White;
            this.labelDebugLogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelDebugLogo.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelDebugLogo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelDebugLogo.Image = ((System.Drawing.Image)(resources.GetObject("labelDebugLogo.Image")));
            this.labelDebugLogo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelDebugLogo.Location = new System.Drawing.Point(3, 36);
            this.labelDebugLogo.Name = "labelDebugLogo";
            this.labelDebugLogo.Size = new System.Drawing.Size(48, 202);
            this.labelDebugLogo.TabIndex = 88;
            this.labelDebugLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.materialSwitchFlashAll);
            this.groupBox1.Controls.Add(this.materialSwitchFlashAllExceptModem);
            this.groupBox1.Location = new System.Drawing.Point(172, 277);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(811, 97);
            this.groupBox1.TabIndex = 87;
            this.groupBox1.TabStop = false;
            // 
            // materialSwitchFlashAll
            // 
            this.materialSwitchFlashAll.AutoSize = true;
            this.materialSwitchFlashAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialSwitchFlashAll.Depth = 0;
            this.materialSwitchFlashAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialSwitchFlashAll.Location = new System.Drawing.Point(3, 16);
            this.materialSwitchFlashAll.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitchFlashAll.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitchFlashAll.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitchFlashAll.Name = "materialSwitchFlashAll";
            this.materialSwitchFlashAll.Ripple = true;
            this.materialSwitchFlashAll.Size = new System.Drawing.Size(119, 37);
            this.materialSwitchFlashAll.TabIndex = 71;
            this.materialSwitchFlashAll.Text = "Flash All";
            this.materialSwitchFlashAll.UseVisualStyleBackColor = true;
            this.materialSwitchFlashAll.CheckedChanged += new System.EventHandler(this.materialSwitchFlashAll_CheckedChanged);
            // 
            // materialSwitchFlashAllExceptModem
            // 
            this.materialSwitchFlashAllExceptModem.AutoSize = true;
            this.materialSwitchFlashAllExceptModem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialSwitchFlashAllExceptModem.Depth = 0;
            this.materialSwitchFlashAllExceptModem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialSwitchFlashAllExceptModem.Location = new System.Drawing.Point(3, 53);
            this.materialSwitchFlashAllExceptModem.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitchFlashAllExceptModem.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitchFlashAllExceptModem.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitchFlashAllExceptModem.Name = "materialSwitchFlashAllExceptModem";
            this.materialSwitchFlashAllExceptModem.Ripple = true;
            this.materialSwitchFlashAllExceptModem.Size = new System.Drawing.Size(228, 37);
            this.materialSwitchFlashAllExceptModem.TabIndex = 72;
            this.materialSwitchFlashAllExceptModem.Text = "Flash All Except Modem";
            this.materialSwitchFlashAllExceptModem.UseVisualStyleBackColor = true;
            this.materialSwitchFlashAllExceptModem.CheckedChanged += new System.EventHandler(this.materialSwitchFlashAllExceptModem_CheckedChanged);
            // 
            // materialButtonFlashMoto
            // 
            this.materialButtonFlashMoto.AutoSize = false;
            this.materialButtonFlashMoto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonFlashMoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonFlashMoto.Depth = 0;
            this.materialButtonFlashMoto.DrawShadows = true;
            this.materialButtonFlashMoto.HighEmphasis = true;
            this.materialButtonFlashMoto.Icon = null;
            this.materialButtonFlashMoto.Location = new System.Drawing.Point(4, 277);
            this.materialButtonFlashMoto.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonFlashMoto.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonFlashMoto.Name = "materialButtonFlashMoto";
            this.materialButtonFlashMoto.Size = new System.Drawing.Size(158, 36);
            this.materialButtonFlashMoto.TabIndex = 86;
            this.materialButtonFlashMoto.Text = "Flash Moto";
            this.materialButtonFlashMoto.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonFlashMoto.UseAccentColor = false;
            this.materialButtonFlashMoto.UseVisualStyleBackColor = true;
            this.materialButtonFlashMoto.Click += new System.EventHandler(this.flash_Click);
            // 
            // materialLabel9
            // 
            this.materialLabel9.AutoSize = true;
            this.materialLabel9.Depth = 0;
            this.materialLabel9.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel9.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel9.HighEmphasis = true;
            this.materialLabel9.Location = new System.Drawing.Point(53, 5);
            this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel9.Name = "materialLabel9";
            this.materialLabel9.Size = new System.Drawing.Size(101, 24);
            this.materialLabel9.TabIndex = 83;
            this.materialLabel9.Text = "Moto Flash";
            this.materialLabel9.UseAccent = true;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // MotoFlash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(995, 413);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "MotoFlash";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MotoFlash_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private MaterialSkin.Controls.MaterialButton materialButtonDowngradeMoto;
        internal System.Windows.Forms.Label labelDebugLogo;
        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialSwitch materialSwitchFlashAll;
        private MaterialSkin.Controls.MaterialSwitch materialSwitchFlashAllExceptModem;
        private MaterialSkin.Controls.MaterialButton materialButtonFlashMoto;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private System.Windows.Forms.RichTextBox consoleMotoFlash;
        private System.Windows.Forms.ListBox listBoxDeviceStatus;
        private MaterialSkin.Controls.MaterialButton materialButtonExit;
        private MaterialSkin.Controls.MaterialProgressBar progressBar_Total;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}
