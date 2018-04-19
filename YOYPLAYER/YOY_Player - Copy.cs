using Newtonsoft.Json;
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

        //internal static readonly HttpClient client = new HttpClient();
        //internal static string UserName = "";
        //internal static string Password = "";
        //internal static string token = "";

        public YOY_Player()
        {
            InitializeComponent();
            //string image_outputDir = Directory.GetCurrentDirectory();
            //Bitmap bitmap = new Bitmap(image_outputDir + "\\Resources\\bg-input-placeholder.png");


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
            var UserName = txtEmail.Text.Trim();
            var Password = txtPassword.Text.Trim();
            YOYPLAYER.Properties.Settings.Default.UserName = UserName;
            YOYPLAYER.Properties.Settings.Default.Password = Password;

            if (UserName == "yupi@test.com" && Password == "asdf123")
            {
                btnSubmit.Enabled = false;
                label1.Text = "Loading......";
                await FirstRequest();

                btnSubmit.Enabled = true;
                FileSelection f2 = new FileSelection(); //this is the change, code for redirect
                var result = f2.ShowDialog();
                if (result != DialogResult.Cancel)
                    this.Close();
                //SecondRequest().GetAwaiter().GetResult();
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
                var responseString = await response.Content.ReadAsStringAsync();

                var json = JsonConvert.DeserializeObject<ResponseData>(responseString);
                YOYPLAYER.Properties.Settings.Default.Token = json.access_token;
                YOYPLAYER.Properties.Settings.Default.Save();
            }



        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {

        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {

        }

        private void YOY_Player_Load(object sender, EventArgs e)
        {
            //txtEmail.Text = "User Name";
            //txtPassword.Text = "Password";
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
