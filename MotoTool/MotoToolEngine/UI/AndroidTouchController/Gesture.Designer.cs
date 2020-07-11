namespace Franco28Tool.Engine
{
    partial class Gesture
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gesture));
            this.Button3 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Button3
            // 
            this.Button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button3.AutoSize = true;
            this.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Button3.Image = global::Franco28Tool.Engine.Properties.Resources.apps;
            this.Button3.Location = new System.Drawing.Point(377, 289);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(58, 56);
            this.Button3.TabIndex = 23;
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // Button2
            // 
            this.Button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button2.AutoSize = true;
            this.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Button2.Image = global::Franco28Tool.Engine.Properties.Resources.home;
            this.Button2.Location = new System.Drawing.Point(184, 289);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(59, 56);
            this.Button2.TabIndex = 22;
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Button1
            // 
            this.Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button1.AutoSize = true;
            this.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Button1.Image = global::Franco28Tool.Engine.Properties.Resources.back;
            this.Button1.Location = new System.Drawing.Point(15, 289);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(59, 56);
            this.Button1.TabIndex = 21;
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // ComboBox1
            // 
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.Items.AddRange(new object[] {
            "1440x2560",
            "1080x1920",
            "800x1280",
            "768x1280",
            "720x1280",
            "720x1200"});
            this.ComboBox1.Location = new System.Drawing.Point(72, 73);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(363, 21);
            this.ComboBox1.TabIndex = 20;
            this.ComboBox1.SelectedIndexChanged += new System.EventHandler(this.Changed);
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(3, 73);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(63, 13);
            this.Label7.TabIndex = 19;
            this.Label7.Text = "Resolution: ";
            // 
            // Panel1
            // 
            this.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel1.BackColor = System.Drawing.Color.Red;
            this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel1.Location = new System.Drawing.Point(13, 100);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(422, 183);
            this.Panel1.TabIndex = 18;
            this.Panel1.MouseCaptureChanged += new System.EventHandler(this.CaputreChanged);
            this.Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Down);
            this.Panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseUp);
            // 
            // Label5
            // 
            this.Label5.AccessibleName = "y-loc";
            this.Label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(337, 289);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(13, 13);
            this.Label5.TabIndex = 17;
            this.Label5.Text = "0";
            // 
            // Label6
            // 
            this.Label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(291, 289);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(40, 13);
            this.Label6.TabIndex = 16;
            this.Label6.Text = "Status:";
            // 
            // Label3
            // 
            this.Label3.AccessibleName = "y-loc";
            this.Label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(148, 327);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(13, 13);
            this.Label3.TabIndex = 15;
            this.Label3.Text = "0";
            // 
            // Label4
            // 
            this.Label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(105, 327);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(37, 13);
            this.Label4.TabIndex = 14;
            this.Label4.Text = "Y pos:";
            // 
            // Label2
            // 
            this.Label2.AccessibleName = "x-loc";
            this.Label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(148, 289);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(13, 13);
            this.Label2.TabIndex = 13;
            this.Label2.Text = "0";
            // 
            // Label1
            // 
            this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(105, 289);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(37, 13);
            this.Label1.TabIndex = 12;
            this.Label1.Text = "X pos:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.TimerT);
            // 
            // Gesture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 349);
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.ComboBox1);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Gesture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gesture";
            this.Load += new System.EventHandler(this.Gesture_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button Button3;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.ComboBox ComboBox1;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Timer timer1;
    }
}