using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
namespace YOYPLAYER 
{
    public partial class FileSelection : Form
    {
        Dictionary<string, string> Branch_AccessKey = new Dictionary<string, string>();
        internal static Dictionary<string, string> dict_commerces = new Dictionary<string, string>();
        internal static Dictionary<string, string> dict_branches = new Dictionary<string, string>();
        internal static Dictionary<string, string> dict_department = new Dictionary<string, string>();
        internal static readonly HttpClient client = new HttpClient();
        private SoundPlayer Player = new SoundPlayer();
       // MediaPly _mp = null;
        public  FileSelection()
        {
            InitializeComponent();
            this.Player.LoadCompleted += new AsyncCompletedEventHandler(Player_LoadCompleted);
            comboBox1.BringToFront();
            comboBox2.BringToFront();
            comboBox3.BringToFront();
            CustomFonts.LoadFonts();
            btnSubmit.Font = CustomFonts.GetMontserrat_Bold(btnSubmit.Font.Size);
            comboBox1.Font = CustomFonts.GetMontserrat_Regular(comboBox1.Font.Size);
            comboBox2.Font = CustomFonts.GetMontserrat_Regular(comboBox2.Font.Size);
            comboBox3.Font = CustomFonts.GetMontserrat_Regular(comboBox3.Font.Size);


        }

        private async void FileSelection_Load(object sender, System.EventArgs e)
        {
           await SecondRequest();
        }

        public async Task SecondRequest()
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Version", "1");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + YOYPLAYER.Properties.Settings.Default.Token);
            var responseString = await client.GetStringAsync("https://data-mng-yoy.azurewebsites.net/api/Access/Gets?id=" + YOYPLAYER.Properties.Settings.Default.UserName);

            // var responseString = await response.Content.ReadAsStringAsync();
            dict_branches.Clear();
            dict_commerces.Clear();
            dict_department.Clear();
            Branch_AccessKey.Clear();

            JToken token = JToken.Parse(responseString);
            string username = token.Value<string>("username"); //people[0].men  
            JArray array_commerces = (JArray)token.SelectToken("commerces");
            foreach (JToken commerces in array_commerces)
            {
                string id = commerces["id"].ToString();
                string name = commerces["name"].ToString();
                string logo = commerces["logo"].ToString();

                dict_commerces.Add(id, name);


                JArray array_branches = (JArray)commerces.SelectToken("branches");

                foreach (JToken branches in array_branches)
                {
                    string branch_id = branches["id"].ToString();
                    string branch_name = branches["name"].ToString();
                    string branch_key = branches["accessKey"].ToString();

                    // comboBox2.Items.Add(branch_name);

                    dict_branches.Add(branch_id, branch_name);
                    Branch_AccessKey.Add(branch_id, branch_key);
                }

                JArray array_departments = (JArray)commerces.SelectToken("departments");

                foreach (JToken department in array_departments)
                {
                    string department_id = department["id"].ToString();
                    string department_name = department["name"].ToString();

                    // comboBox3.Items.Add(department_name);
                    dict_department.Add(department_id, department_name);
                }

            }

            comboBox1.DataSource = new BindingSource(dict_commerces, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";

            comboBox2.DataSource = new BindingSource(dict_branches, null);
            comboBox2.DisplayMember = "Value";
            comboBox2.ValueMember = "Key";

            comboBox3.DataSource = new BindingSource(dict_department, null);
            comboBox3.DisplayMember = "Value";
            comboBox3.ValueMember = "Key";
            // var json = JsonConvert.DeserializeObject<List<commerces>>(responseString);

        }

        public async Task ThirdRequest()
        {

            //YOY_Player.client.DefaultRequestHeaders.Accept.Clear();
            //YOY_Player.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //YOY_Player.client.DefaultRequestHeaders.Add("Version", "1");
            //YOY_Player.client.DefaultRequestHeaders.Add("Authorization", "Bearer " + YOY_Player.token);
            var responseString = await client.GetStringAsync(string.Format("https://data-mng-yoy.azurewebsites.net/api/File/Get?id={0}&key={1}&branchId={2}&dptId={3}", YOYPLAYER.Properties.Settings.Default.UserName, Branch_AccessKey[comboBox2.SelectedValue.ToString()], comboBox2.SelectedValue, comboBox3.SelectedValue));
            //var responseString = await YOY_Player.client.GetStringAsync("https://data-mng-yoy.azurewebsites.net/api/File/Get?id=yupi@test.com&key=BUQGCDzpgrJEQkCJ6Bff3F69mdQLh5rdJEqTf7B+zCA=&branchId=f4bb0d9c-0c45-435a-a597-19b9f88e1e3c&dptId=cde80be1-687c-4036-9c44-dc91d0420eff");
            // var responseString = await response.Content.ReadAsStringAsync();

            JToken token = JToken.Parse(responseString);
            string mimeType = token.Value<string>("mimeType"); 
            string fileName = token.Value<string>("fileName");
            string fileId = token.Value<string>("fileId");
            string nextSync = token.Value<string>("nextSync");
            string requestDate = token.Value<string>("requestDate");

            LogWriter _log = new LogWriter();
            //start downloading file

            //  var response_String = await YOY_Player.client.GetStreamAsync("https://data-mng-yoy.azurewebsites.net/api/ContentStream/Get?userId=yupi@test.com&key=BUQGCDzpgrJEQkCJ6Bff3F69mdQLh5rdJEqTf7B+zCA=&id=1TB2nlfQrdhWqTypBsANV-SZMnos3CBD6&downloadType=1");
            //JToken token1 = JToken.Parse(response_String);

            if (!Directory.Exists(YOYPLAYER.Properties.Settings.Default.DirectoryName))
            {
                Directory.CreateDirectory(YOYPLAYER.Properties.Settings.Default.DirectoryName);
            }

            using (var request = new HttpRequestMessage(HttpMethod.Get, string.Format("https://data-mng-yoy.azurewebsites.net/api/ContentStream/Get?userId={0}&key={1}&id={2}&downloadType=1", YOYPLAYER.Properties.Settings.Default.UserName, Branch_AccessKey[comboBox2.SelectedValue.ToString()],fileId)))
            {
                using (
                    Stream contentStream = await (await client.SendAsync(request)).Content.ReadAsStreamAsync(),
                    stream = new FileStream(YOYPLAYER.Properties.Settings.Default.DirectoryName + "\\" + fileName, FileMode.Create, FileAccess.Write, FileShare.None, (int)contentStream.Length, true))
                {
                    await contentStream.CopyToAsync(stream);
                }
            }


            if (File.Exists(YOYPLAYER.Properties.Settings.Default.DirectoryName + "\\" + fileName))
            {
                YOYPLAYER.Properties.Settings.Default.FileName = YOYPLAYER.Properties.Settings.Default.DirectoryName + "\\" + fileName;

            }
            

            _log.LogWrite(string.Format("FileType:{0} |  FileName:{1} |  NextSync:{2}  |  RequestDate:{3}",mimeType,fileName, DateTime.Parse(nextSync).ToUniversalTime(),DateTime.Parse(requestDate).ToUniversalTime()));

            

        }


        // This is the event handler for the LoadCompleted event.
        void Player_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (Player.IsLoadCompleted)
            {
                try
                {
                    this.Player.PlayLooping();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error playing sound");
                }
            }
        }

        private async void FileSelection_Load_1(object sender, EventArgs e)
        {
            await SecondRequest();
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            btnSubmit.Enabled = false;
            // //label1.Text = "Playing......";
            await ThirdRequest();
            //Start Playing Audio

            //MediaPlayer.MediaPly obj = new MediaPlayer.MediaPly();
            //obj.LoadFile(YOYPLAYER.Properties.Settings.Default.FileName, null);

            try
            {
                // Replace this file name with a valid file name.
                this.Player.SoundLocation = YOYPLAYER.Properties.Settings.Default.FileName;
                this.Player.LoadAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading sound");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
