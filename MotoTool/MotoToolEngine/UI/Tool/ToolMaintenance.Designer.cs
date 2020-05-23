namespace Franco28Tool.Engine
{
    partial class ToolMaintenance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolMaintenance));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.materialButtonUnlock = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 64);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(866, 397);
            this.pictureBox1.TabIndex = 65;
            this.pictureBox1.TabStop = false;
            // 
            // materialButtonUnlock
            // 
            this.materialButtonUnlock.AutoSize = false;
            this.materialButtonUnlock.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonUnlock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonUnlock.Depth = 0;
            this.materialButtonUnlock.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.materialButtonUnlock.DrawShadows = true;
            this.materialButtonUnlock.HighEmphasis = false;
            this.materialButtonUnlock.Icon = null;
            this.materialButtonUnlock.Location = new System.Drawing.Point(0, 475);
            this.materialButtonUnlock.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonUnlock.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonUnlock.Name = "materialButtonUnlock";
            this.materialButtonUnlock.Size = new System.Drawing.Size(866, 47);
            this.materialButtonUnlock.TabIndex = 67;
            this.materialButtonUnlock.Text = "Contact";
            this.materialButtonUnlock.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonUnlock.UseAccentColor = false;
            this.materialButtonUnlock.UseVisualStyleBackColor = true;
            this.materialButtonUnlock.Click += new System.EventHandler(this.contact_Click);
            // 
            // ToolMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(866, 522);
            this.Controls.Add(this.materialButtonUnlock);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ToolMaintenance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MotoTool is on maintenance";
            this.Load += new System.EventHandler(this.ToolMaintenance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialButton materialButtonUnlock;
    }
}