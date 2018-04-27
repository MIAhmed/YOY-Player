namespace YOYPLAYER
{
    partial class frmMain
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSubmit2 = new System.Windows.Forms.PictureBox();
            this.btnSubmit1 = new System.Windows.Forms.PictureBox();
            this.btnSubmit3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_first = new System.Windows.Forms.TextBox();
            this.txt_second = new System.Windows.Forms.TextBox();
            this.txt_third = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSubmit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSubmit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSubmit3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::YOYPLAYER.Properties.Resources.mainpage_top_logo;
            this.pictureBox1.Location = new System.Drawing.Point(69, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(155, 155);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnSubmit2
            // 
            this.btnSubmit2.BackColor = System.Drawing.Color.Transparent;
            this.btnSubmit2.BackgroundImage = global::YOYPLAYER.Properties.Resources.bg_button;
            this.btnSubmit2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSubmit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnSubmit2.Location = new System.Drawing.Point(44, 432);
            this.btnSubmit2.Name = "btnSubmit2";
            this.btnSubmit2.Size = new System.Drawing.Size(211, 42);
            this.btnSubmit2.TabIndex = 13;
            this.btnSubmit2.TabStop = false;
            this.btnSubmit2.Text = "VER BITACORA";
            this.btnSubmit2.Click += new System.EventHandler(this.btnSubmit2_Click);
            // 
            // btnSubmit1
            // 
            this.btnSubmit1.BackColor = System.Drawing.Color.Transparent;
            this.btnSubmit1.BackgroundImage = global::YOYPLAYER.Properties.Resources.bg_button;
            this.btnSubmit1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSubmit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnSubmit1.Location = new System.Drawing.Point(44, 366);
            this.btnSubmit1.Name = "btnSubmit1";
            this.btnSubmit1.Size = new System.Drawing.Size(211, 42);
            this.btnSubmit1.TabIndex = 12;
            this.btnSubmit1.TabStop = false;
            this.btnSubmit1.Text = "CAMBIAR  USUARIO";
            this.btnSubmit1.Click += new System.EventHandler(this.btnSubmit1_Click);
            // 
            // btnSubmit3
            // 
            this.btnSubmit3.BackColor = System.Drawing.Color.Transparent;
            this.btnSubmit3.BackgroundImage = global::YOYPLAYER.Properties.Resources.bg_button;
            this.btnSubmit3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSubmit3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnSubmit3.Location = new System.Drawing.Point(44, 298);
            this.btnSubmit3.Name = "btnSubmit3";
            this.btnSubmit3.Size = new System.Drawing.Size(211, 42);
            this.btnSubmit3.TabIndex = 16;
            this.btnSubmit3.TabStop = false;
            this.btnSubmit3.Text = "CAMBIAR UBICACION";
            this.btnSubmit3.Click += new System.EventHandler(this.btnSubmit3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Image = global::YOYPLAYER.Properties.Resources.bg_default;
            this.label1.Location = new System.Drawing.Point(45, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 25);
            this.label1.TabIndex = 19;
            this.label1.Text = "App Status:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Image = global::YOYPLAYER.Properties.Resources.bg_default;
            this.label2.Location = new System.Drawing.Point(183, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 25);
            this.label2.TabIndex = 20;
            this.label2.Text = "Activo";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Image = global::YOYPLAYER.Properties.Resources.bg_default;
            this.label3.Location = new System.Drawing.Point(12, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 26);
            this.label3.TabIndex = 21;
            this.label3.Text = "Subway:Los Yoses-Caja";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_first
            // 
            this.txt_first.BackColor = System.Drawing.Color.White;
            this.txt_first.BackgroundImage = global::YOYPLAYER.Properties.Resources.bg_input_placeholder1;
            this.txt_first.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txt_first.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_first.Enabled = false;
            this.txt_first.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F, System.Drawing.FontStyle.Bold);
            this.txt_first.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txt_first.Location = new System.Drawing.Point(51, 310);
            this.txt_first.Name = "txt_first";
            this.txt_first.ReadOnly = true;
            this.txt_first.Size = new System.Drawing.Size(199, 18);
            this.txt_first.TabIndex = 23;
            this.txt_first.Text = "CAMBIAR UBICACIÓN";
            this.txt_first.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_second
            // 
            this.txt_second.BackColor = System.Drawing.Color.White;
            this.txt_second.BackgroundImage = global::YOYPLAYER.Properties.Resources.bg_input_placeholder1;
            this.txt_second.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txt_second.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_second.Enabled = false;
            this.txt_second.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_second.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txt_second.Location = new System.Drawing.Point(51, 379);
            this.txt_second.Name = "txt_second";
            this.txt_second.Size = new System.Drawing.Size(199, 18);
            this.txt_second.TabIndex = 23;
            this.txt_second.Text = "CAMBIAR USUARIO";
            this.txt_second.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_third
            // 
            this.txt_third.BackColor = System.Drawing.Color.White;
            this.txt_third.BackgroundImage = global::YOYPLAYER.Properties.Resources.bg_input_placeholder1;
            this.txt_third.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txt_third.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_third.Enabled = false;
            this.txt_third.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F, System.Drawing.FontStyle.Bold);
            this.txt_third.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txt_third.Location = new System.Drawing.Point(51, 445);
            this.txt_third.Name = "txt_third";
            this.txt_third.Size = new System.Drawing.Size(199, 18);
            this.txt_third.TabIndex = 23;
            this.txt_third.Text = "VER BITÁCORA";
            this.txt_third.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::YOYPLAYER.Properties.Resources.bg_default;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(293, 521);
            this.Controls.Add(this.txt_third);
            this.Controls.Add(this.txt_second);
            this.Controls.Add(this.txt_first);
            this.Controls.Add(this.btnSubmit3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSubmit2);
            this.Controls.Add(this.btnSubmit1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YOY Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSubmit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSubmit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSubmit3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;

        //private System.Windows.Forms.Button btnSubmit1;
        //private System.Windows.Forms.Button btnSubmit2;
        //private System.Windows.Forms.Button btnSubmit3;
        private System.Windows.Forms.PictureBox btnSubmit1;
        private System.Windows.Forms.PictureBox btnSubmit2;
        private System.Windows.Forms.PictureBox btnSubmit3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_first;
        private System.Windows.Forms.TextBox txt_second;
        private System.Windows.Forms.TextBox txt_third;
    }
}

