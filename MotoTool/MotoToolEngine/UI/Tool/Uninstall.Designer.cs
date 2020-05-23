
namespace Franco28Tool.Engine
{
    partial class Uninstall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Uninstall));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.MaterialButtonYES = new MaterialSkin.Controls.MaterialButton();
            this.materialButtonNO = new MaterialSkin.Controls.MaterialButton();
            this.label5 = new System.Windows.Forms.Label();
            this.warnlabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelred = new System.Windows.Forms.Label();
            this.labelblue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MaterialButtonYES
            // 
            this.MaterialButtonYES.AutoSize = false;
            this.MaterialButtonYES.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MaterialButtonYES.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MaterialButtonYES.Depth = 0;
            this.MaterialButtonYES.DrawShadows = true;
            this.MaterialButtonYES.HighEmphasis = true;
            this.MaterialButtonYES.Icon = null;
            this.MaterialButtonYES.Location = new System.Drawing.Point(88, 259);
            this.MaterialButtonYES.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaterialButtonYES.MouseState = MaterialSkin.MouseState.HOVER;
            this.MaterialButtonYES.Name = "MaterialButtonYES";
            this.MaterialButtonYES.Size = new System.Drawing.Size(115, 36);
            this.MaterialButtonYES.TabIndex = 86;
            this.MaterialButtonYES.Text = "YES";
            this.MaterialButtonYES.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.MaterialButtonYES.UseAccentColor = false;
            this.MaterialButtonYES.UseVisualStyleBackColor = true;
            this.MaterialButtonYES.Click += new System.EventHandler(this.YES_Click);
            // 
            // materialButtonNO
            // 
            this.materialButtonNO.AutoSize = false;
            this.materialButtonNO.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonNO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonNO.Depth = 0;
            this.materialButtonNO.DrawShadows = true;
            this.materialButtonNO.HighEmphasis = true;
            this.materialButtonNO.Icon = null;
            this.materialButtonNO.Location = new System.Drawing.Point(476, 259);
            this.materialButtonNO.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonNO.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonNO.Name = "materialButtonNO";
            this.materialButtonNO.Size = new System.Drawing.Size(115, 36);
            this.materialButtonNO.TabIndex = 85;
            this.materialButtonNO.Text = "NO";
            this.materialButtonNO.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonNO.UseAccentColor = true;
            this.materialButtonNO.UseVisualStyleBackColor = true;
            this.materialButtonNO.Click += new System.EventHandler(this.NO_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(86, 65);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(505, 40);
            this.label5.TabIndex = 84;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // warnlabel
            // 
            this.warnlabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.warnlabel.BackColor = System.Drawing.Color.White;
            this.warnlabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.warnlabel.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warnlabel.ForeColor = System.Drawing.Color.Black;
            this.warnlabel.Image = ((System.Drawing.Image)(resources.GetObject("warnlabel.Image")));
            this.warnlabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.warnlabel.Location = new System.Drawing.Point(1, 65);
            this.warnlabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.warnlabel.Name = "warnlabel";
            this.warnlabel.Size = new System.Drawing.Size(81, 234);
            this.warnlabel.TabIndex = 80;
            this.warnlabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(83, 105);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(508, 113);
            this.label6.TabIndex = 81;
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelred
            // 
            this.labelred.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelred.BackColor = System.Drawing.Color.White;
            this.labelred.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelred.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelred.ForeColor = System.Drawing.Color.Black;
            this.labelred.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelred.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelred.Location = new System.Drawing.Point(476, 211);
            this.labelred.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelred.Name = "labelred";
            this.labelred.Size = new System.Drawing.Size(115, 36);
            this.labelred.TabIndex = 83;
            this.labelred.Text = "...";
            this.labelred.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelblue
            // 
            this.labelblue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelblue.BackColor = System.Drawing.Color.White;
            this.labelblue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelblue.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelblue.ForeColor = System.Drawing.Color.Black;
            this.labelblue.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelblue.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelblue.Location = new System.Drawing.Point(88, 218);
            this.labelblue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelblue.Name = "labelblue";
            this.labelblue.Size = new System.Drawing.Size(115, 29);
            this.labelblue.TabIndex = 82;
            this.labelblue.Text = "...";
            this.labelblue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Uninstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(602, 308);
            this.Controls.Add(this.MaterialButtonYES);
            this.Controls.Add(this.materialButtonNO);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.warnlabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelred);
            this.Controls.Add(this.labelblue);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Uninstall";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Uninstall";
            this.TopMost = true;
            this.Closed += new System.EventHandler(this.Uninstall_Closed);
            this.Load += new System.EventHandler(this.Uninstall_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private MaterialSkin.Controls.MaterialButton MaterialButtonYES;
        private MaterialSkin.Controls.MaterialButton materialButtonNO;
        public System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label warnlabel;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label labelred;
        public System.Windows.Forms.Label labelblue;
    }
}
