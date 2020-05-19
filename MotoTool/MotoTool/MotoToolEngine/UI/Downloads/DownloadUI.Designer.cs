
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
            this.label7 = new System.Windows.Forms.Label();
            this.ProgressBar1 = new MaterialSkin.Controls.MaterialProgressBar();
            this.materialButton10 = new MaterialSkin.Controls.MaterialButton();
            this.labelDownloaded = new MaterialSkin.Controls.MaterialLabel();
            this.labelSpeed = new MaterialSkin.Controls.MaterialLabel();
            this.labelPerc = new MaterialSkin.Controls.MaterialLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labeltitle = new MaterialSkin.Controls.MaterialLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Image = ((System.Drawing.Image)(resources.GetObject("label7.Image")));
            this.label7.Location = new System.Drawing.Point(2, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 41);
            this.label7.TabIndex = 113;
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar1.BackColor = System.Drawing.Color.White;
            this.ProgressBar1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.ProgressBar1.Depth = 0;
            this.ProgressBar1.Location = new System.Drawing.Point(47, 140);
            this.ProgressBar1.MouseState = MaterialSkin.MouseState.HOVER;
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(837, 5);
            this.ProgressBar1.TabIndex = 121;
            this.ProgressBar1.Value = 1;
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
            // labelDownloaded
            // 
            this.labelDownloaded.Depth = 0;
            this.labelDownloaded.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelDownloaded.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelDownloaded.Location = new System.Drawing.Point(6, 69);
            this.labelDownloaded.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelDownloaded.Name = "labelDownloaded";
            this.labelDownloaded.Size = new System.Drawing.Size(509, 38);
            this.labelDownloaded.TabIndex = 125;
            this.labelDownloaded.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSpeed
            // 
            this.labelSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSpeed.Depth = 0;
            this.labelSpeed.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelSpeed.Location = new System.Drawing.Point(537, 69);
            this.labelSpeed.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(432, 38);
            this.labelSpeed.TabIndex = 126;
            this.labelSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPerc
            // 
            this.labelPerc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPerc.Depth = 0;
            this.labelPerc.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelPerc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelPerc.Location = new System.Drawing.Point(890, 119);
            this.labelPerc.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelPerc.Name = "labelPerc";
            this.labelPerc.Size = new System.Drawing.Size(79, 35);
            this.labelPerc.TabIndex = 127;
            this.labelPerc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labeltitle);
            this.panel1.Controls.Add(this.materialButton10);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(974, 66);
            this.panel1.TabIndex = 128;
            // 
            // labeltitle
            // 
            this.labeltitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labeltitle.Depth = 0;
            this.labeltitle.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labeltitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labeltitle.Location = new System.Drawing.Point(74, 6);
            this.labeltitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.labeltitle.Name = "labeltitle";
            this.labeltitle.Size = new System.Drawing.Size(895, 49);
            this.labeltitle.TabIndex = 129;
            // 
            // DownloadUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(974, 157);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelPerc);
            this.Controls.Add(this.labelSpeed);
            this.Controls.Add(this.labelDownloaded);
            this.Controls.Add(this.ProgressBar1);
            this.Controls.Add(this.label7);
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
            this.Closed += new System.EventHandler(this.DownloadUI_Close);
            this.Load += new System.EventHandler(this.DownloadUI_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label label7;
        public MaterialSkin.Controls.MaterialProgressBar ProgressBar1;
        private MaterialSkin.Controls.MaterialButton materialButton10;
        private MaterialSkin.Controls.MaterialLabel labelDownloaded;
        private MaterialSkin.Controls.MaterialLabel labelSpeed;
        private MaterialSkin.Controls.MaterialLabel labelPerc;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialLabel labeltitle;
    }
}
