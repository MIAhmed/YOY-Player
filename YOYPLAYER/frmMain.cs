using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YOYPLAYER
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            CustomFonts.LoadFonts();
            txt_first.Font = CustomFonts.GetMontserrat_Bold(txt_first.Font.Size);
            txt_second.Font = CustomFonts.GetMontserrat_Bold(txt_second.Font.Size);
            txt_third.Font = CustomFonts.GetMontserrat_Bold(txt_third.Font.Size);
            label1.Font = new Font(CustomFonts.GetMontserrat_Medium(label1.Font.Size), label1.Font.Style);
            label2.Font = new Font(CustomFonts.GetMontserrat_Medium(label2.Font.Size), label2.Font.Style);
            label3.Font = new Font(CustomFonts.GetMontserrat_Medium(label3.Font.Size), label3.Font.Style);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnSubmit3_Click(object sender, EventArgs e)
        {
            FileSelection f2 = new FileSelection(); //this is the change, code for redirect
            this.Hide();
            var result = f2.ShowDialog();
            if (result != DialogResult.Cancel)
                this.Close();
        }

        private void btnSubmit1_Click(object sender, EventArgs e)
        {
            YOY_Player f2 = new YOY_Player(false,true); //this is the change, code for redirect
            this.Hide();
            var result = f2.ShowDialog();
            if (result != DialogResult.Cancel)
                this.Close();
        }

        private void btnSubmit2_Click(object sender, EventArgs e)
        {
            AudioLog f2 = new AudioLog(); //this is the change, code for redirect
            var result = f2.ShowDialog();
            if (result != DialogResult.Cancel)
                this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.ExitThread();
            //Environment.Exit(0);
            e.Cancel = true;
            YOY_Player obj = new YOY_Player(true,false);
            this.Hide();
            obj.ShowDialog();
            
        }

        private void txt_first_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
