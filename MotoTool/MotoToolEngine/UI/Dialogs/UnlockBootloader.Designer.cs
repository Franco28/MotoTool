namespace Franco28Tool.Engine
{
    partial class UnlockBootloader
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
            this.textBoxUnlockKey = new System.Windows.Forms.TextBox();
            this.materialLabel13 = new MaterialSkin.Controls.MaterialLabel();
            this.console = new System.Windows.Forms.RichTextBox();
            this.materialButtonGetUnlockData = new MaterialSkin.Controls.MaterialButton();
            this.textBoxGetUnlockData = new System.Windows.Forms.TextBox();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialButtonUnlockBootlaoder = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // materialButtonAdd
            // 
            this.materialButtonAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.materialButtonAdd.AutoSize = false;
            this.materialButtonAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonAdd.Depth = 0;
            this.materialButtonAdd.DrawShadows = true;
            this.materialButtonAdd.HighEmphasis = true;
            this.materialButtonAdd.Icon = null;
            this.materialButtonAdd.Location = new System.Drawing.Point(11, 462);
            this.materialButtonAdd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonAdd.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonAdd.Name = "materialButtonAdd";
            this.materialButtonAdd.Size = new System.Drawing.Size(148, 36);
            this.materialButtonAdd.TabIndex = 143;
            this.materialButtonAdd.Text = "Add unlock key";
            this.materialButtonAdd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonAdd.UseAccentColor = true;
            this.materialButtonAdd.UseVisualStyleBackColor = true;
            this.materialButtonAdd.Click += new System.EventHandler(this.materialButtonAdd_Click);
            // 
            // textBoxUnlockKey
            // 
            this.textBoxUnlockKey.BackColor = System.Drawing.Color.White;
            this.textBoxUnlockKey.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUnlockKey.ForeColor = System.Drawing.Color.Black;
            this.textBoxUnlockKey.Location = new System.Drawing.Point(12, 419);
            this.textBoxUnlockKey.Multiline = true;
            this.textBoxUnlockKey.Name = "textBoxUnlockKey";
            this.textBoxUnlockKey.Size = new System.Drawing.Size(785, 34);
            this.textBoxUnlockKey.TabIndex = 141;
            // 
            // materialLabel13
            // 
            this.materialLabel13.Depth = 0;
            this.materialLabel13.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel13.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel13.HighEmphasis = true;
            this.materialLabel13.Location = new System.Drawing.Point(13, 392);
            this.materialLabel13.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel13.Name = "materialLabel13";
            this.materialLabel13.Size = new System.Drawing.Size(782, 24);
            this.materialLabel13.TabIndex = 139;
            this.materialLabel13.Text = "Please put your unlock key here";
            this.materialLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.materialLabel13.UseAccent = true;
            // 
            // console
            // 
            this.console.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.console.Location = new System.Drawing.Point(12, 70);
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.Size = new System.Drawing.Size(785, 138);
            this.console.TabIndex = 144;
            this.console.Text = "";
            // 
            // materialButtonGetUnlockData
            // 
            this.materialButtonGetUnlockData.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.materialButtonGetUnlockData.AutoSize = false;
            this.materialButtonGetUnlockData.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonGetUnlockData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonGetUnlockData.Depth = 0;
            this.materialButtonGetUnlockData.DrawShadows = true;
            this.materialButtonGetUnlockData.HighEmphasis = true;
            this.materialButtonGetUnlockData.Icon = null;
            this.materialButtonGetUnlockData.Location = new System.Drawing.Point(12, 278);
            this.materialButtonGetUnlockData.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonGetUnlockData.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonGetUnlockData.Name = "materialButtonGetUnlockData";
            this.materialButtonGetUnlockData.Size = new System.Drawing.Size(147, 36);
            this.materialButtonGetUnlockData.TabIndex = 145;
            this.materialButtonGetUnlockData.Text = "Get Unlock Data";
            this.materialButtonGetUnlockData.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonGetUnlockData.UseAccentColor = true;
            this.materialButtonGetUnlockData.UseVisualStyleBackColor = true;
            this.materialButtonGetUnlockData.Click += new System.EventHandler(this.materialButtonGetUnlockData_Click);
            // 
            // textBoxGetUnlockData
            // 
            this.textBoxGetUnlockData.BackColor = System.Drawing.Color.White;
            this.textBoxGetUnlockData.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGetUnlockData.ForeColor = System.Drawing.Color.Black;
            this.textBoxGetUnlockData.Location = new System.Drawing.Point(11, 214);
            this.textBoxGetUnlockData.Multiline = true;
            this.textBoxGetUnlockData.Name = "textBoxGetUnlockData";
            this.textBoxGetUnlockData.Size = new System.Drawing.Size(785, 55);
            this.textBoxGetUnlockData.TabIndex = 146;
            // 
            // materialButton1
            // 
            this.materialButton1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.materialButton1.AutoSize = false;
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButton1.Depth = 0;
            this.materialButton1.DrawShadows = true;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(11, 350);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.Size = new System.Drawing.Size(148, 36);
            this.materialButton1.TabIndex = 147;
            this.materialButton1.Text = "Go to moto page";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = true;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.materialButtonGetUnlockKey_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel1.HighEmphasis = true;
            this.materialLabel1.Location = new System.Drawing.Point(13, 320);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(782, 24);
            this.materialLabel1.TabIndex = 148;
            this.materialLabel1.Text = "When this finish, copy this code and past it on Moto Page";
            this.materialLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.materialLabel1.UseAccent = true;
            // 
            // materialButtonUnlockBootlaoder
            // 
            this.materialButtonUnlockBootlaoder.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.materialButtonUnlockBootlaoder.AutoSize = false;
            this.materialButtonUnlockBootlaoder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonUnlockBootlaoder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonUnlockBootlaoder.Depth = 0;
            this.materialButtonUnlockBootlaoder.DrawShadows = true;
            this.materialButtonUnlockBootlaoder.HighEmphasis = true;
            this.materialButtonUnlockBootlaoder.Icon = null;
            this.materialButtonUnlockBootlaoder.Location = new System.Drawing.Point(11, 520);
            this.materialButtonUnlockBootlaoder.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonUnlockBootlaoder.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonUnlockBootlaoder.Name = "materialButtonUnlockBootlaoder";
            this.materialButtonUnlockBootlaoder.Size = new System.Drawing.Size(786, 36);
            this.materialButtonUnlockBootlaoder.TabIndex = 149;
            this.materialButtonUnlockBootlaoder.Text = "Unlock Bootloader";
            this.materialButtonUnlockBootlaoder.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonUnlockBootlaoder.UseAccentColor = true;
            this.materialButtonUnlockBootlaoder.UseVisualStyleBackColor = true;
            this.materialButtonUnlockBootlaoder.Click += new System.EventHandler(this.materialButtonUnlockBootlaoder_Click);
            // 
            // UnlockBootloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 561);
            this.Controls.Add(this.materialButtonUnlockBootlaoder);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.materialButton1);
            this.Controls.Add(this.textBoxGetUnlockData);
            this.Controls.Add(this.materialButtonGetUnlockData);
            this.Controls.Add(this.console);
            this.Controls.Add(this.materialButtonAdd);
            this.Controls.Add(this.textBoxUnlockKey);
            this.Controls.Add(this.materialLabel13);
            this.MaximizeBox = false;
            this.Name = "UnlockBootloader";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unlock Bootloader";
            this.Load += new System.EventHandler(this.UnlockBootloader_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton materialButtonAdd;
        private System.Windows.Forms.TextBox textBoxUnlockKey;
        private MaterialSkin.Controls.MaterialLabel materialLabel13;
        private System.Windows.Forms.RichTextBox console;
        private MaterialSkin.Controls.MaterialButton materialButtonGetUnlockData;
        private System.Windows.Forms.TextBox textBoxGetUnlockData;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialButton materialButtonUnlockBootlaoder;
    }
}