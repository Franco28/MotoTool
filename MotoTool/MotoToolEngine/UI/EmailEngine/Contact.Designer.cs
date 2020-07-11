namespace Franco28Tool.Engine
{
    partial class Contact
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
            this.console = new System.Windows.Forms.RichTextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialButtonSend = new MaterialSkin.Controls.MaterialButton();
            this.textBoxMSG = new System.Windows.Forms.TextBox();
            this.materialLabel13 = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // console
            // 
            this.console.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.console.Location = new System.Drawing.Point(5, 68);
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.Size = new System.Drawing.Size(795, 78);
            this.console.TabIndex = 163;
            this.console.Text = "";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.BackColor = System.Drawing.Color.White;
            this.textBoxEmail.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEmail.ForeColor = System.Drawing.Color.Black;
            this.textBoxEmail.Location = new System.Drawing.Point(5, 176);
            this.textBoxEmail.Multiline = true;
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(795, 34);
            this.textBoxEmail.TabIndex = 162;
            // 
            // materialLabel3
            // 
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel3.HighEmphasis = true;
            this.materialLabel3.Location = new System.Drawing.Point(6, 149);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(794, 24);
            this.materialLabel3.TabIndex = 161;
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
            this.materialButtonSend.Location = new System.Drawing.Point(6, 432);
            this.materialButtonSend.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonSend.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonSend.Name = "materialButtonSend";
            this.materialButtonSend.Size = new System.Drawing.Size(794, 36);
            this.materialButtonSend.TabIndex = 160;
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
            this.textBoxMSG.Location = new System.Drawing.Point(6, 240);
            this.textBoxMSG.Multiline = true;
            this.textBoxMSG.Name = "textBoxMSG";
            this.textBoxMSG.Size = new System.Drawing.Size(794, 178);
            this.textBoxMSG.TabIndex = 159;
            // 
            // materialLabel13
            // 
            this.materialLabel13.Depth = 0;
            this.materialLabel13.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel13.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel13.HighEmphasis = true;
            this.materialLabel13.Location = new System.Drawing.Point(6, 213);
            this.materialLabel13.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel13.Name = "materialLabel13";
            this.materialLabel13.Size = new System.Drawing.Size(794, 24);
            this.materialLabel13.TabIndex = 158;
            this.materialLabel13.Text = "Your message";
            this.materialLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.materialLabel13.UseAccent = true;
            // 
            // Contact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 483);
            this.Controls.Add(this.console);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialButtonSend);
            this.Controls.Add(this.textBoxMSG);
            this.Controls.Add(this.materialLabel13);
            this.MaximizeBox = false;
            this.Name = "Contact";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MotoTool Contact";
            this.Load += new System.EventHandler(this.Contact_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox console;
        protected internal System.Windows.Forms.TextBox textBoxEmail;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialButton materialButtonSend;
        protected internal System.Windows.Forms.TextBox textBoxMSG;
        private MaterialSkin.Controls.MaterialLabel materialLabel13;
    }
}