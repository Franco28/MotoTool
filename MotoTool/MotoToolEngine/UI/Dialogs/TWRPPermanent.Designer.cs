namespace Franco28Tool.Engine
{
    partial class TWRPPermanent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TWRPPermanent));
            this.recoverylabel = new System.Windows.Forms.Label();
            this.cancel = new MaterialSkin.Controls.MaterialButton();
            this.download = new MaterialSkin.Controls.MaterialButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // recoverylabel
            // 
            this.recoverylabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.recoverylabel.BackColor = System.Drawing.Color.Transparent;
            this.recoverylabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recoverylabel.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recoverylabel.ForeColor = System.Drawing.Color.Black;
            this.recoverylabel.Image = ((System.Drawing.Image)(resources.GetObject("recoverylabel.Image")));
            this.recoverylabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.recoverylabel.Location = new System.Drawing.Point(2, 65);
            this.recoverylabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.recoverylabel.Name = "recoverylabel";
            this.recoverylabel.Size = new System.Drawing.Size(60, 85);
            this.recoverylabel.TabIndex = 61;
            this.recoverylabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cancel
            // 
            this.cancel.AutoSize = false;
            this.cancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancel.Depth = 0;
            this.cancel.DrawShadows = true;
            this.cancel.HighEmphasis = true;
            this.cancel.Icon = null;
            this.cancel.Location = new System.Drawing.Point(654, 156);
            this.cancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(168, 39);
            this.cancel.TabIndex = 125;
            this.cancel.Text = "Cancel ";
            this.cancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.cancel.UseAccentColor = true;
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.OK_Click);
            // 
            // download
            // 
            this.download.AutoSize = false;
            this.download.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.download.Cursor = System.Windows.Forms.Cursors.Hand;
            this.download.Depth = 0;
            this.download.DrawShadows = true;
            this.download.HighEmphasis = true;
            this.download.Icon = null;
            this.download.Location = new System.Drawing.Point(472, 156);
            this.download.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.download.MouseState = MaterialSkin.MouseState.HOVER;
            this.download.Name = "download";
            this.download.Size = new System.Drawing.Size(168, 39);
            this.download.TabIndex = 126;
            this.download.Text = "Download";
            this.download.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.download.UseAccentColor = false;
            this.download.UseVisualStyleBackColor = true;
            this.download.Click += new System.EventHandler(this.download_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(67, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(755, 85);
            this.label1.TabIndex = 803;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TWRPPermanent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(834, 205);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.download);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.recoverylabel);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TWRPPermanent";
            this.ShowIcon = false;
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.exit);
            this.Load += new System.EventHandler(this.TWRPPermanent_Load);
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Label recoverylabel;
        private MaterialSkin.Controls.MaterialButton cancel;
        private MaterialSkin.Controls.MaterialButton download;
        public System.Windows.Forms.Label label1;
    }
}