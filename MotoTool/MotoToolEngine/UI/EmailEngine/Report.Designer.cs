namespace Franco28Tool.Engine
{
    partial class Report
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
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialButtonSend = new MaterialSkin.Controls.MaterialButton();
            this.textBoxMSG = new System.Windows.Forms.TextBox();
            this.materialLabel13 = new MaterialSkin.Controls.MaterialLabel();
            this.console = new System.Windows.Forms.RichTextBox();
            this.oFD1 = new System.Windows.Forms.OpenFileDialog();
            this.materialButtonAttachFiles = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.txtAttach = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.BackColor = System.Drawing.Color.White;
            this.textBoxEmail.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEmail.ForeColor = System.Drawing.Color.Black;
            this.textBoxEmail.Location = new System.Drawing.Point(12, 148);
            this.textBoxEmail.Multiline = true;
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(775, 34);
            this.textBoxEmail.TabIndex = 153;
            // 
            // materialLabel3
            // 
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel3.HighEmphasis = true;
            this.materialLabel3.Location = new System.Drawing.Point(13, 121);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(774, 24);
            this.materialLabel3.TabIndex = 152;
            this.materialLabel3.Text = "Email";
            this.materialLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.materialLabel3.UseAccent = true;
            // 
            // materialButtonSend
            // 
            this.materialButtonSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.materialButtonSend.AutoSize = false;
            this.materialButtonSend.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonSend.Depth = 0;
            this.materialButtonSend.DrawShadows = true;
            this.materialButtonSend.HighEmphasis = true;
            this.materialButtonSend.Icon = null;
            this.materialButtonSend.Location = new System.Drawing.Point(12, 522);
            this.materialButtonSend.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonSend.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonSend.Name = "materialButtonSend";
            this.materialButtonSend.Size = new System.Drawing.Size(776, 36);
            this.materialButtonSend.TabIndex = 151;
            this.materialButtonSend.Text = "Send";
            this.materialButtonSend.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonSend.UseAccentColor = true;
            this.materialButtonSend.UseVisualStyleBackColor = true;
            this.materialButtonSend.Click += new System.EventHandler(this.materialButtonSend_Click);
            // 
            // textBoxMSG
            // 
            this.textBoxMSG.BackColor = System.Drawing.Color.White;
            this.textBoxMSG.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMSG.ForeColor = System.Drawing.Color.Black;
            this.textBoxMSG.Location = new System.Drawing.Point(13, 212);
            this.textBoxMSG.Multiline = true;
            this.textBoxMSG.Name = "textBoxMSG";
            this.textBoxMSG.Size = new System.Drawing.Size(775, 178);
            this.textBoxMSG.TabIndex = 150;
            // 
            // materialLabel13
            // 
            this.materialLabel13.Depth = 0;
            this.materialLabel13.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel13.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel13.HighEmphasis = true;
            this.materialLabel13.Location = new System.Drawing.Point(13, 185);
            this.materialLabel13.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel13.Name = "materialLabel13";
            this.materialLabel13.Size = new System.Drawing.Size(774, 24);
            this.materialLabel13.TabIndex = 149;
            this.materialLabel13.Text = "Your message";
            this.materialLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.materialLabel13.UseAccent = true;
            // 
            // console
            // 
            this.console.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.console.Location = new System.Drawing.Point(12, 67);
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.Size = new System.Drawing.Size(776, 51);
            this.console.TabIndex = 154;
            this.console.Text = "";
            // 
            // oFD1
            // 
            this.oFD1.FilterIndex = 2;
            // 
            // materialButtonAttachFiles
            // 
            this.materialButtonAttachFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.materialButtonAttachFiles.AutoSize = false;
            this.materialButtonAttachFiles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonAttachFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonAttachFiles.Depth = 0;
            this.materialButtonAttachFiles.DrawShadows = true;
            this.materialButtonAttachFiles.HighEmphasis = true;
            this.materialButtonAttachFiles.Icon = null;
            this.materialButtonAttachFiles.Location = new System.Drawing.Point(17, 423);
            this.materialButtonAttachFiles.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonAttachFiles.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonAttachFiles.Name = "materialButtonAttachFiles";
            this.materialButtonAttachFiles.Size = new System.Drawing.Size(235, 34);
            this.materialButtonAttachFiles.TabIndex = 155;
            this.materialButtonAttachFiles.Text = "Attach files";
            this.materialButtonAttachFiles.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonAttachFiles.UseAccentColor = true;
            this.materialButtonAttachFiles.UseVisualStyleBackColor = true;
            this.materialButtonAttachFiles.Click += new System.EventHandler(this.materialButtonAttachFiles_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel1.HighEmphasis = true;
            this.materialLabel1.Location = new System.Drawing.Point(12, 393);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(775, 24);
            this.materialLabel1.TabIndex = 156;
            this.materialLabel1.Text = "Here you can add: images, txt files, etc";
            this.materialLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.materialLabel1.UseAccent = true;
            // 
            // txtAttach
            // 
            this.txtAttach.BackColor = System.Drawing.Color.White;
            this.txtAttach.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtAttach.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAttach.ForeColor = System.Drawing.Color.Black;
            this.txtAttach.Location = new System.Drawing.Point(13, 466);
            this.txtAttach.Multiline = true;
            this.txtAttach.Name = "txtAttach";
            this.txtAttach.ReadOnly = true;
            this.txtAttach.Size = new System.Drawing.Size(774, 47);
            this.txtAttach.TabIndex = 157;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 573);
            this.Controls.Add(this.txtAttach);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.materialButtonAttachFiles);
            this.Controls.Add(this.console);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialButtonSend);
            this.Controls.Add(this.textBoxMSG);
            this.Controls.Add(this.materialLabel13);
            this.MaximizeBox = false;
            this.Name = "Report";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MotoTool Report";
            this.Load += new System.EventHandler(this.Contact_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected internal System.Windows.Forms.TextBox textBoxEmail;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialButton materialButtonSend;
        protected internal System.Windows.Forms.TextBox textBoxMSG;
        private MaterialSkin.Controls.MaterialLabel materialLabel13;
        private System.Windows.Forms.RichTextBox console;
        private System.Windows.Forms.OpenFileDialog oFD1;
        private MaterialSkin.Controls.MaterialButton materialButtonAttachFiles;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        protected internal System.Windows.Forms.TextBox txtAttach;
    }
}