
namespace Franco28Tool.Engine
{
    partial class NotiPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotiPanel));
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new MaterialSkin.Controls.MaterialLabel();
            this.offline = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Image = ((System.Drawing.Image)(resources.GetObject("label7.Image")));
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 159);
            this.label7.TabIndex = 106;
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Depth = 0;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label2.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(89, 0);
            this.label2.MouseState = MaterialSkin.MouseState.HOVER;
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(845, 159);
            this.label2.TabIndex = 127;
            this.label2.Text = "NotiPanel";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // offline
            // 
            this.offline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.offline.AutoSize = false;
            this.offline.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.offline.Cursor = System.Windows.Forms.Cursors.Hand;
            this.offline.Depth = 0;
            this.offline.DrawShadows = true;
            this.offline.ForeColor = System.Drawing.Color.Red;
            this.offline.HighEmphasis = false;
            this.offline.Icon = null;
            this.offline.Location = new System.Drawing.Point(733, 84);
            this.offline.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.offline.MouseState = MaterialSkin.MouseState.HOVER;
            this.offline.Name = "offline";
            this.offline.Size = new System.Drawing.Size(188, 49);
            this.offline.TabIndex = 128;
            this.offline.Text = "Change to offline";
            this.offline.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.offline.UseAccentColor = false;
            this.offline.UseVisualStyleBackColor = true;
            this.offline.Click += new System.EventHandler(this.offline_Click);
            // 
            // NotiPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(934, 159);
            this.ControlBox = false;
            this.Controls.Add(this.offline);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.DrawerWidth = 0;
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NotiPanel";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.NotiPanel_Load);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label label7;
        public MaterialSkin.Controls.MaterialLabel label2;
        private MaterialSkin.Controls.MaterialButton offline;
    }
}
