namespace Franco28Tool.Engine
{
    partial class SendEmail
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
            this.materialButtonAdd = new MaterialSkin.Controls.MaterialButton();
            this.textBoxChannel = new System.Windows.Forms.TextBox();
            this.textBoxFirmware = new System.Windows.Forms.TextBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel13 = new MaterialSkin.Controls.MaterialLabel();
            this.console = new System.Windows.Forms.RichTextBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.textBoxCodename = new System.Windows.Forms.TextBox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.textBoxDeviceCompleteName = new System.Windows.Forms.TextBox();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // materialButtonAdd
            // 
            this.materialButtonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.materialButtonAdd.AutoSize = false;
            this.materialButtonAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonAdd.Depth = 0;
            this.materialButtonAdd.DrawShadows = true;
            this.materialButtonAdd.HighEmphasis = true;
            this.materialButtonAdd.Icon = null;
            this.materialButtonAdd.Location = new System.Drawing.Point(562, 507);
            this.materialButtonAdd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonAdd.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonAdd.Name = "materialButtonAdd";
            this.materialButtonAdd.Size = new System.Drawing.Size(207, 36);
            this.materialButtonAdd.TabIndex = 144;
            this.materialButtonAdd.Text = "Send Firmware request";
            this.materialButtonAdd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonAdd.UseAccentColor = true;
            this.materialButtonAdd.UseVisualStyleBackColor = true;
            this.materialButtonAdd.Click += new System.EventHandler(this.btnSent_Click);
            // 
            // textBoxChannel
            // 
            this.textBoxChannel.BackColor = System.Drawing.Color.White;
            this.textBoxChannel.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxChannel.ForeColor = System.Drawing.Color.Black;
            this.textBoxChannel.Location = new System.Drawing.Point(11, 330);
            this.textBoxChannel.Multiline = true;
            this.textBoxChannel.Name = "textBoxChannel";
            this.textBoxChannel.Size = new System.Drawing.Size(758, 36);
            this.textBoxChannel.TabIndex = 143;
            // 
            // textBoxFirmware
            // 
            this.textBoxFirmware.BackColor = System.Drawing.Color.White;
            this.textBoxFirmware.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFirmware.ForeColor = System.Drawing.Color.Black;
            this.textBoxFirmware.Location = new System.Drawing.Point(12, 266);
            this.textBoxFirmware.Multiline = true;
            this.textBoxFirmware.Name = "textBoxFirmware";
            this.textBoxFirmware.Size = new System.Drawing.Size(757, 34);
            this.textBoxFirmware.TabIndex = 142;
            // 
            // materialLabel1
            // 
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel1.HighEmphasis = true;
            this.materialLabel1.Location = new System.Drawing.Point(11, 303);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(758, 24);
            this.materialLabel1.TabIndex = 141;
            this.materialLabel1.Text = "Device Channel - for ex: RETAR";
            this.materialLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.materialLabel1.UseAccent = true;
            // 
            // materialLabel13
            // 
            this.materialLabel13.Depth = 0;
            this.materialLabel13.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel13.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel13.HighEmphasis = true;
            this.materialLabel13.Location = new System.Drawing.Point(12, 239);
            this.materialLabel13.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel13.Name = "materialLabel13";
            this.materialLabel13.Size = new System.Drawing.Size(757, 24);
            this.materialLabel13.TabIndex = 140;
            this.materialLabel13.Text = "Firmware - for ex: XT2019-2_DOHA_RETAR_9.0_PPIS29.65-51-3";
            this.materialLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.materialLabel13.UseAccent = true;
            // 
            // console
            // 
            this.console.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.console.Location = new System.Drawing.Point(11, 68);
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.Size = new System.Drawing.Size(766, 104);
            this.console.TabIndex = 139;
            this.console.Text = "";
            // 
            // materialLabel2
            // 
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel2.HighEmphasis = true;
            this.materialLabel2.Location = new System.Drawing.Point(11, 369);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(758, 24);
            this.materialLabel2.TabIndex = 145;
            this.materialLabel2.Text = "Device Codename - for ex: DOHA";
            this.materialLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.materialLabel2.UseAccent = true;
            // 
            // textBoxCodename
            // 
            this.textBoxCodename.BackColor = System.Drawing.Color.White;
            this.textBoxCodename.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCodename.ForeColor = System.Drawing.Color.Black;
            this.textBoxCodename.Location = new System.Drawing.Point(11, 396);
            this.textBoxCodename.Multiline = true;
            this.textBoxCodename.Name = "textBoxCodename";
            this.textBoxCodename.Size = new System.Drawing.Size(758, 36);
            this.textBoxCodename.TabIndex = 146;
            // 
            // materialLabel3
            // 
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel3.HighEmphasis = true;
            this.materialLabel3.Location = new System.Drawing.Point(11, 175);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(759, 24);
            this.materialLabel3.TabIndex = 147;
            this.materialLabel3.Text = "Email";
            this.materialLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.materialLabel3.UseAccent = true;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.BackColor = System.Drawing.Color.White;
            this.textBoxEmail.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEmail.ForeColor = System.Drawing.Color.Black;
            this.textBoxEmail.Location = new System.Drawing.Point(12, 202);
            this.textBoxEmail.Multiline = true;
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(757, 34);
            this.textBoxEmail.TabIndex = 148;
            // 
            // materialButton1
            // 
            this.materialButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.materialButton1.AutoSize = false;
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButton1.Depth = 0;
            this.materialButton1.DrawShadows = true;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(11, 506);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.Size = new System.Drawing.Size(214, 36);
            this.materialButton1.TabIndex = 149;
            this.materialButton1.Text = "send new device request";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = true;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // textBoxDeviceCompleteName
            // 
            this.textBoxDeviceCompleteName.BackColor = System.Drawing.Color.White;
            this.textBoxDeviceCompleteName.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDeviceCompleteName.ForeColor = System.Drawing.Color.Black;
            this.textBoxDeviceCompleteName.Location = new System.Drawing.Point(12, 462);
            this.textBoxDeviceCompleteName.Multiline = true;
            this.textBoxDeviceCompleteName.Name = "textBoxDeviceCompleteName";
            this.textBoxDeviceCompleteName.Size = new System.Drawing.Size(758, 36);
            this.textBoxDeviceCompleteName.TabIndex = 151;
            // 
            // materialLabel4
            // 
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel4.HighEmphasis = true;
            this.materialLabel4.Location = new System.Drawing.Point(11, 435);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(758, 24);
            this.materialLabel4.TabIndex = 150;
            this.materialLabel4.Text = "Device Complete Name - for ex: Moto G8 Plus";
            this.materialLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.materialLabel4.UseAccent = true;
            // 
            // materialLabel5
            // 
            this.materialLabel5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            this.materialLabel5.HighEmphasis = true;
            this.materialLabel5.Location = new System.Drawing.Point(232, 507);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(323, 41);
            this.materialLabel5.TabIndex = 152;
            this.materialLabel5.Text = "Please, don\'t select the two options, just select one";
            this.materialLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.materialLabel5.UseAccent = true;
            // 
            // SendEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 557);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.textBoxDeviceCompleteName);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.materialButton1);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.textBoxCodename);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialButtonAdd);
            this.Controls.Add(this.textBoxChannel);
            this.Controls.Add(this.textBoxFirmware);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.materialLabel13);
            this.Controls.Add(this.console);
            this.MaximizeBox = false;
            this.Name = "SendEmail";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Send Request";
            this.Load += new System.EventHandler(this.SendEmailcs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton materialButtonAdd;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel13;
        private System.Windows.Forms.RichTextBox console;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        protected internal System.Windows.Forms.TextBox textBoxChannel;
        protected internal System.Windows.Forms.TextBox textBoxFirmware;
        protected internal System.Windows.Forms.TextBox textBoxCodename;
        protected internal System.Windows.Forms.TextBox textBoxEmail;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        protected internal System.Windows.Forms.TextBox textBoxDeviceCompleteName;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
    }
}