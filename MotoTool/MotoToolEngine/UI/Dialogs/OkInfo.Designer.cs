
namespace Franco28Tool.Engine
{
    partial class OkInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OkInfo));
            this.recoverylabel = new System.Windows.Forms.Label();
            this.OK = new MaterialSkin.Controls.MaterialButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // recoverylabel
            // 
            this.recoverylabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.recoverylabel.BackColor = System.Drawing.Color.Transparent;
            this.recoverylabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recoverylabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recoverylabel.ForeColor = System.Drawing.Color.Black;
            this.recoverylabel.Image = ((System.Drawing.Image)(resources.GetObject("recoverylabel.Image")));
            this.recoverylabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.recoverylabel.Location = new System.Drawing.Point(3, 70);
            this.recoverylabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.recoverylabel.Name = "recoverylabel";
            this.recoverylabel.Size = new System.Drawing.Size(57, 118);
            this.recoverylabel.TabIndex = 53;
            this.recoverylabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // OK
            // 
            this.OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OK.AutoSize = false;
            this.OK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OK.BackColor = System.Drawing.Color.Transparent;
            this.OK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OK.Depth = 0;
            this.OK.DrawShadows = true;
            this.OK.HighEmphasis = true;
            this.OK.Icon = null;
            this.OK.Location = new System.Drawing.Point(345, 194);
            this.OK.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.OK.MouseState = MaterialSkin.MouseState.HOVER;
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(168, 36);
            this.OK.TabIndex = 59;
            this.OK.Text = "OK";
            this.OK.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.OK.UseAccentColor = false;
            this.OK.UseVisualStyleBackColor = false;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(65, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(448, 118);
            this.label1.TabIndex = 801;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(3, 193);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(336, 37);
            this.label2.TabIndex = 802;
            this.label2.Text = "If you see wrong text, resize me!";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // OkInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(518, 235);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.recoverylabel);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OkInfo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.OkInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialButton OK;
        internal System.Windows.Forms.Label recoverylabel;
        public System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
    }
}
