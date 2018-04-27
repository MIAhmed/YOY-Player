﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YOYPLAYER
{
    public partial class YOY_Player : Form
    {


        string strEmailCaption = "Correo Electrónico";
        string strPasswordCaption = "Contraseña";
        static bool isLoginUser = false;
        //internal static readonly HttpClient client = new HttpClient();
        //internal static string UserName = "";
        //internal static string Password = "";
        //internal static string token = "";

        public YOY_Player()
        {

            InitializeComponent();
            CustomFonts.LoadFonts();
            //string image_outputDir = Directory.GetCurrentDirectory();
            //Bitmap bitmap = new Bitmap(image_outputDir + "\\Resources\\bg-input-placeholder.png");
            //SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            btnSubmit.Font = CustomFonts.GetMontserrat_Bold(btnSubmit.Font.Size);
            //this.BackColor = Color.Transparent;
            txtEmail.Text = strEmailCaption;
            txtPassword.Text = strPasswordCaption;

            txtEmail.Font = CustomFonts.GetMontserrat_Regular(txtEmail.Font.Size);
            txtPassword.Font = CustomFonts.GetMontserrat_Regular(txtPassword.Font.Size);
            //lbl_help.Font = CustomFonts.GetMontserrat_Medium(lbl_help.Font.Size);
            lbl_help.Font = new Font(CustomFonts.GetMontserrat_Medium(lbl_help.Font.Size), lbl_help.Font.Style);
            //Clipboard.SetDataObject(bitmap);
            //DataFormats.Format format = DataFormats.GetFormat(DataFormats.Bitmap);
            //txtEmail.Paste(format);

            //txtEmail.GotFocus +=new EventHandler(RemoveText);
            //txtEmail.LostFocus += new EventHandler(AddText);
        }


        public void RemoveText(object sender, EventArgs e)
        {
            txtEmail.Text = "";
        }

        public void AddText(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtEmail.Text))
                txtEmail.Text = "User Name";
        }


        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var UserName = txtEmail.Text.Trim();
                var Password = txtPassword.Text.Trim();
                YOYPLAYER.Properties.Settings.Default.UserName = UserName;
                YOYPLAYER.Properties.Settings.Default.Password = Password;

                btnSubmit.Enabled = false;
                lbl_help.Text = "Loading......";
                await FirstRequest();

                btnSubmit.Enabled = true;

                if (isLoginUser)
                {
                    FileSelection f2 = new FileSelection(); //this is the change, code for redirect
                    this.Hide();
                    var result = f2.ShowDialog();
                    if (result != DialogResult.Cancel)
                        this.Close();
                }
                else
                {
                    MessageBox.Show("INVALID USER NAME OR PASSWORD");
                    lbl_help.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                lbl_help.Text = "";
            }
        }

        public static async Task FirstRequest()
        {

            var values = new Dictionary<string, string>
            {
               { "grant_type", "password" },
               { "username",   YOYPLAYER.Properties.Settings.Default.UserName },
               { "password",   YOYPLAYER.Properties.Settings.Default.Password }
            };

            var content = new FormUrlEncodedContent(values);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.PostAsync("https://data-mng-yoy.azurewebsites.net/token", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();

                    var json = JsonConvert.DeserializeObject<ResponseData>(responseString);
                    YOYPLAYER.Properties.Settings.Default.Token = json.access_token;
                    YOYPLAYER.Properties.Settings.Default.Save();
                    isLoginUser = true;
                }

            }

        }



        private void YOY_Player_Load(object sender, EventArgs e)
        {
            //txtEmail.Text = "User Name";
            //txtPassword.Text = "Password";
        }

        private void YOY_Player_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == strEmailCaption)
            {
                txtEmail.Text = "";
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = strEmailCaption;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() == "")
            {
                txtPassword.Text = strPasswordCaption;
                txtPassword.PasswordChar = '\0';
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == strPasswordCaption)
            {
                txtPassword.Text = "";
                txtPassword.PasswordChar = '*';
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class ResponseData
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string username { get; set; }
    }

    public class FileInfo
    {
        public string FileType { get; set; }
        public string FileName { get; set; }
        public DateTime NextSync { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
