
namespace Franco28Tool.Engine
{
    partial class DownloadUI
    {

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadUI));
            this.materialButton10 = new MaterialSkin.Controls.MaterialButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ProgressBar1 = new MaterialSkin.Controls.MaterialProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.console = new System.Windows.Forms.RichTextBox();
            this.labelPerc = new MaterialSkin.Controls.MaterialLabel();
            this.labelspeed = new MaterialSkin.Controls.MaterialLabel();
            this.labelfilesize = new MaterialSkin.Controls.MaterialLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialButton10
            // 
            this.materialButton10.AutoSize = false;
            this.materialButton10.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButton10.Depth = 0;
            this.materialButton10.DrawShadows = true;
            this.materialButton10.HighEmphasis = true;
            this.materialButton10.Icon = null;
            this.materialButton10.Location = new System.Drawing.Point(3, 6);
            this.materialButton10.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton10.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton10.Name = "materialButton10";
            this.materialButton10.Size = new System.Drawing.Size(70, 27);
            this.materialButton10.TabIndex = 124;
            this.materialButton10.Text = "Cancel ";
            this.materialButton10.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton10.UseAccentColor = true;
            this.materialButton10.UseVisualStyleBackColor = true;
            this.materialButton10.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelfilesize);
            this.panel1.Controls.Add(this.labelspeed);
            this.panel1.Controls.Add(this.labelPerc);
            this.panel1.Controls.Add(this.console);
            this.panel1.Controls.Add(this.ProgressBar1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.materialButton10);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(926, 112);
            this.panel1.TabIndex = 128;
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar1.BackColor = System.Drawing.Color.White;
            this.ProgressBar1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.ProgressBar1.Depth = 0;
            this.ProgressBar1.Location = new System.Drawing.Point(7, 97);
            this.ProgressBar1.MouseState = MaterialSkin.MouseState.HOVER;
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(907, 5);
            this.ProgressBar1.TabIndex = 131;
            this.ProgressBar1.Value = 1;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Image = ((System.Drawing.Image)(resources.GetObject("label7.Image")));
            this.label7.Location = new System.Drawing.Point(3, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 52);
            this.label7.TabIndex = 130;
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // console
            // 
            this.console.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.console.Location = new System.Drawing.Point(80, 6);
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.Size = new System.Drawing.Size(843, 60);
            this.console.TabIndex = 132;
            this.console.Text = "";
            // 
            // labelPerc
            // 
            this.labelPerc.BackColor = System.Drawing.Color.Transparent;
            this.labelPerc.Depth = 0;
            this.labelPerc.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelPerc.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            this.labelPerc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelPerc.HighEmphasis = true;
            this.labelPerc.Location = new System.Drawing.Point(79, 69);
            this.labelPerc.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelPerc.Name = "labelPerc";
            this.labelPerc.Size = new System.Drawing.Size(250, 25);
            this.labelPerc.TabIndex = 133;
            this.labelPerc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelPerc.UseAccent = true;
            // 
            // labelspeed
            // 
            this.labelspeed.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelspeed.BackColor = System.Drawing.Color.Transparent;
            this.labelspeed.Depth = 0;
            this.labelspeed.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelspeed.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            this.labelspeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelspeed.HighEmphasis = true;
            this.labelspeed.Location = new System.Drawing.Point(371, 69);
            this.labelspeed.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelspeed.Name = "labelspeed";
            this.labelspeed.Size = new System.Drawing.Size(250, 25);
            this.labelspeed.TabIndex = 134;
            this.labelspeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelspeed.UseAccent = true;
            // 
            // labelfilesize
            // 
            this.labelfilesize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelfilesize.BackColor = System.Drawing.Color.Transparent;
            this.labelfilesize.Depth = 0;
            this.labelfilesize.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelfilesize.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            this.labelfilesize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelfilesize.HighEmphasis = true;
            this.labelfilesize.Location = new System.Drawing.Point(664, 69);
            this.labelfilesize.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelfilesize.Name = "labelfilesize";
            this.labelfilesize.Size = new System.Drawing.Size(250, 25);
            this.labelfilesize.TabIndex = 135;
            this.labelfilesize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelfilesize.UseAccent = true;
            // 
            // DownloadUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(926, 112);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DownloadUI";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Download Engine";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.DownloadUI_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialButton materialButton10;
        private System.Windows.Forms.Panel panel1;
        public MaterialSkin.Controls.MaterialProgressBar ProgressBar1;
        public System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox console;
        private MaterialSkin.Controls.MaterialLabel labelPerc;
        private MaterialSkin.Controls.MaterialLabel labelspeed;
        private MaterialSkin.Controls.MaterialLabel labelfilesize;
    }
}
