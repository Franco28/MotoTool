namespace Franco28Tool.Engine
{
    partial class LangSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LangSelect));
            this.materialButtonES = new MaterialSkin.Controls.MaterialButton();
            this.materialButtonEnglish = new MaterialSkin.Controls.MaterialButton();
            this.console = new System.Windows.Forms.RichTextBox();
            this.materialButtonChangeTheme = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // materialButtonES
            // 
            this.materialButtonES.AutoSize = false;
            this.materialButtonES.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonES.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonES.Depth = 0;
            this.materialButtonES.DrawShadows = true;
            this.materialButtonES.HighEmphasis = true;
            this.materialButtonES.Icon = global::Franco28Tool.Engine.Properties.Resources.Spain_icon;
            this.materialButtonES.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.materialButtonES.Location = new System.Drawing.Point(13, 180);
            this.materialButtonES.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonES.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonES.Name = "materialButtonES";
            this.materialButtonES.Size = new System.Drawing.Size(117, 36);
            this.materialButtonES.TabIndex = 66;
            this.materialButtonES.Text = "Spanish";
            this.materialButtonES.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonES.UseAccentColor = false;
            this.materialButtonES.UseVisualStyleBackColor = true;
            this.materialButtonES.Click += new System.EventHandler(this.materialButtonES_Click);
            // 
            // materialButtonEnglish
            // 
            this.materialButtonEnglish.AutoSize = false;
            this.materialButtonEnglish.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonEnglish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonEnglish.Depth = 0;
            this.materialButtonEnglish.DrawShadows = true;
            this.materialButtonEnglish.HighEmphasis = true;
            this.materialButtonEnglish.Icon = ((System.Drawing.Image)(resources.GetObject("materialButtonEnglish.Icon")));
            this.materialButtonEnglish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.materialButtonEnglish.Location = new System.Drawing.Point(13, 132);
            this.materialButtonEnglish.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonEnglish.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonEnglish.Name = "materialButtonEnglish";
            this.materialButtonEnglish.Size = new System.Drawing.Size(117, 36);
            this.materialButtonEnglish.TabIndex = 67;
            this.materialButtonEnglish.Text = "English";
            this.materialButtonEnglish.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonEnglish.UseAccentColor = false;
            this.materialButtonEnglish.UseVisualStyleBackColor = true;
            this.materialButtonEnglish.Click += new System.EventHandler(this.materialButtonEnglish_Click);
            // 
            // console
            // 
            this.console.Dock = System.Windows.Forms.DockStyle.Top;
            this.console.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.console.Location = new System.Drawing.Point(0, 0);
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.Size = new System.Drawing.Size(533, 123);
            this.console.TabIndex = 68;
            this.console.Text = "";
            // 
            // materialButtonChangeTheme
            // 
            this.materialButtonChangeTheme.AutoSize = false;
            this.materialButtonChangeTheme.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonChangeTheme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButtonChangeTheme.Depth = 0;
            this.materialButtonChangeTheme.DrawShadows = true;
            this.materialButtonChangeTheme.HighEmphasis = true;
            this.materialButtonChangeTheme.Icon = null;
            this.materialButtonChangeTheme.Location = new System.Drawing.Point(350, 132);
            this.materialButtonChangeTheme.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonChangeTheme.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonChangeTheme.Name = "materialButtonChangeTheme";
            this.materialButtonChangeTheme.Size = new System.Drawing.Size(170, 36);
            this.materialButtonChangeTheme.TabIndex = 69;
            this.materialButtonChangeTheme.Text = "Cancel";
            this.materialButtonChangeTheme.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonChangeTheme.UseAccentColor = true;
            this.materialButtonChangeTheme.UseVisualStyleBackColor = true;
            this.materialButtonChangeTheme.Click += new System.EventHandler(this.cancel);
            // 
            // LangSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 221);
            this.Controls.Add(this.materialButtonChangeTheme);
            this.Controls.Add(this.console);
            this.Controls.Add(this.materialButtonEnglish);
            this.Controls.Add(this.materialButtonES);
            this.MaximizeBox = false;
            this.Name = "LangSelect";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lang Select";
            this.Load += new System.EventHandler(this.LangSelect_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton materialButtonES;
        private MaterialSkin.Controls.MaterialButton materialButtonEnglish;
        private System.Windows.Forms.RichTextBox console;
        private MaterialSkin.Controls.MaterialButton materialButtonChangeTheme;
    }
}