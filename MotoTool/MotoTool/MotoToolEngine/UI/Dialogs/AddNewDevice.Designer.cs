namespace Franco28Tool.Engine
{
    partial class AddNewDevice
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
            this.materialLabel13 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.textBoxCodename = new System.Windows.Forms.TextBox();
            this.textBoxChannel = new System.Windows.Forms.TextBox();
            this.materialButtonAdd = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // console
            // 
            this.console.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.console.Location = new System.Drawing.Point(12, 72);
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.Size = new System.Drawing.Size(618, 127);
            this.console.TabIndex = 133;
            this.console.Text = "";
            // 
            // materialLabel13
            // 
            this.materialLabel13.AutoSize = true;
            this.materialLabel13.Depth = 0;
            this.materialLabel13.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel13.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel13.HighEmphasis = true;
            this.materialLabel13.Location = new System.Drawing.Point(12, 214);
            this.materialLabel13.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel13.Name = "materialLabel13";
            this.materialLabel13.Size = new System.Drawing.Size(162, 24);
            this.materialLabel13.TabIndex = 134;
            this.materialLabel13.Text = "Device Codename";
            this.materialLabel13.UseAccent = true;
            // 
            // materialLabel1
            // 
            this.materialLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel1.HighEmphasis = true;
            this.materialLabel1.Location = new System.Drawing.Point(400, 214);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(139, 24);
            this.materialLabel1.TabIndex = 135;
            this.materialLabel1.Text = "Device Channel";
            this.materialLabel1.UseAccent = true;
            // 
            // textBoxCodename
            // 
            this.textBoxCodename.BackColor = System.Drawing.Color.White;
            this.textBoxCodename.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCodename.ForeColor = System.Drawing.Color.Black;
            this.textBoxCodename.Location = new System.Drawing.Point(12, 256);
            this.textBoxCodename.Multiline = true;
            this.textBoxCodename.Name = "textBoxCodename";
            this.textBoxCodename.Size = new System.Drawing.Size(226, 34);
            this.textBoxCodename.TabIndex = 136;
            // 
            // textBoxChannel
            // 
            this.textBoxChannel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxChannel.BackColor = System.Drawing.Color.White;
            this.textBoxChannel.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxChannel.ForeColor = System.Drawing.Color.Black;
            this.textBoxChannel.Location = new System.Drawing.Point(404, 256);
            this.textBoxChannel.Multiline = true;
            this.textBoxChannel.Name = "textBoxChannel";
            this.textBoxChannel.Size = new System.Drawing.Size(226, 34);
            this.textBoxChannel.TabIndex = 137;
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
            this.materialButtonAdd.Location = new System.Drawing.Point(245, 255);
            this.materialButtonAdd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonAdd.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonAdd.Name = "materialButtonAdd";
            this.materialButtonAdd.Size = new System.Drawing.Size(152, 36);
            this.materialButtonAdd.TabIndex = 138;
            this.materialButtonAdd.Text = "ADD";
            this.materialButtonAdd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonAdd.UseAccentColor = true;
            this.materialButtonAdd.UseVisualStyleBackColor = true;
            this.materialButtonAdd.Click += new System.EventHandler(this.materialButtonAdd_Click);
            // 
            // AddNewDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(642, 301);
            this.Controls.Add(this.materialButtonAdd);
            this.Controls.Add(this.textBoxChannel);
            this.Controls.Add(this.textBoxCodename);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.materialLabel13);
            this.Controls.Add(this.console);
            this.MaximizeBox = false;
            this.Name = "AddNewDevice";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add new device";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.exit);
            this.Load += new System.EventHandler(this.AddNewDevice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox console;
        private MaterialSkin.Controls.MaterialLabel materialLabel13;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.TextBox textBoxCodename;
        private System.Windows.Forms.TextBox textBoxChannel;
        private MaterialSkin.Controls.MaterialButton materialButtonAdd;
    }
}