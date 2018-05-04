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
        internal static List<Commerces> lst_commerces = new List<Commerces>();
        internal static List<Branches> lst_branches = new List<Branches>();
        internal static List<departments> lst_department = new List<departments>();
        //Dictionary<string, string> Branch_AccessKey = new Dictionary<string, string>();
        //internal static Dictionary<string, string> dict_commerces = new Dictionary<string, string>();
        //internal static Dictionary<string, string> dict_branches = new Dictionary<string, string>();
        //internal static Dictionary<string, string> dict_department = new Dictionary<string, string>();
        internal static readonly HttpClient client = new HttpClient();
        private SoundPlayer Player = new SoundPlayer();
        // MediaPly _mp = null;
        public FileSelection()
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


        public async Task SecondRequest()
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Version", "1");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + YOYPLAYER.Properties.Settings.Default.Token);
            var responseString = await client.GetStringAsync("https://data-mng-yoy.azurewebsites.net/api/Access/Gets?id=" + YOYPLAYER.Properties.Settings.Default.UserName);

            // var responseString = await response.Content.ReadAsStringAsync();
            //dict_branches.Clear();
            //dict_commerces.Clear();
            //dict_department.Clear();
            //Branch_AccessKey.Clear();
            lst_branches.Clear();
            lst_commerces.Clear();
            lst_department.Clear();
            JToken token = JToken.Parse(responseString);
            string username = token.Value<string>("username"); //people[0].men  
            JArray array_commerces = (JArray)token.SelectToken("commerces");
            //adding default values
            Commerces com = new Commerces();
            com.id = "0";
            com.name = "Commercio";
            lst_commerces.Add(com);

            Branches bran = new Branches();
            bran.id = "0";
            bran.name = "Local";
            lst_branches.Add(bran);

            departments depart = new departments();
            depart.id = "0";
            depart.name = "Departamento";
            lst_department.Add(depart);

            bindingSource1.DataSource = lst_branches;
            comboBox2.DataSource = bindingSource1.DataSource;
            comboBox2.DisplayMember = "name";
            comboBox2.ValueMember = "id";

            bindingSource1.DataSource = lst_department;
            comboBox3.DataSource = bindingSource1.DataSource;
            comboBox3.DisplayMember = "name";
            comboBox3.ValueMember = "id";


            foreach (JToken commerces in array_commerces)
            {
                //string id = commerces["id"].ToString();
                //string name = commerces["name"].ToString();
                //string logo = commerces["logo"].ToString();

                Commerces c = new Commerces();
                c.id = commerces["id"].ToString();
                c.name = commerces["name"].ToString();
                c.logo = commerces["logo"].ToString();

                //dict_commerces.Add(id, name);
                lst_commerces.Add(c);

                JArray array_branches = (JArray)commerces.SelectToken("branches");

                foreach (JToken branches in array_branches)
                {
                    //string branch_id = branches["id"].ToString();
                    //string branch_name = branches["name"].ToString();
                    //string branch_key = branches["accessKey"].ToString();
                    Branches b = new Branches();
                    b.id = branches["id"].ToString();
                    b.name = branches["name"].ToString();
                    b.accessKey = branches["accessKey"].ToString();
                    b.commerce_id = c.id;
                    // comboBox2.Items.Add(branch_name);

                    //dict_branches.Add(branch_id, branch_name);
                    //Branch_AccessKey.Add(branch_id, branch_key);
                    lst_branches.Add(b);

                    JArray array_departments = (JArray)commerces.SelectToken("departments");

                    foreach (JToken department in array_departments)
                    {
                        //string department_id = department["id"].ToString();
                        //string department_name = department["name"].ToString();
                        departments d = new departments();
                        d.id = department["id"].ToString();
                        d.name = department["name"].ToString();
                        d.Branche_id = b.id;
                        // comboBox3.Items.Add(department_name);
                        //dict_department.Add(department_id, department_name);
                        lst_department.Add(d);
                    }
                }



            }

            bindingSource1.DataSource = lst_commerces;
            comboBox1.DataSource = bindingSource1.DataSource;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";


            //comboBox2.DataSource = new BindingSource(dict_branches, null);
            //comboBox2.DisplayMember = "Value";
            //comboBox2.ValueMember = "Key";

            //comboBox3.DataSource = new BindingSource(dict_department, null);
            //comboBox3.DisplayMember = "Value";
            //comboBox3.ValueMember = "Key";

            // var json = JsonConvert.DeserializeObject<List<commerces>>(responseString);

        }

        public async Task ThirdRequest()
        {
            var key = lst_branches.Where(x => x.id == comboBox2.SelectedValue.ToString()).Select(y => y.accessKey).FirstOrDefault();
           //var key = lst_branches.Select(x => x.accessKey).Where(x => x.id == comboBox2.SelectedValue.ToString());
            //YOY_Player.client.DefaultRequestHeaders.Accept.Clear();
            //YOY_Player.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //YOY_Player.client.DefaultRequestHeaders.Add("Version", "1");
            //YOY_Player.client.DefaultRequestHeaders.Add("Authorization", "Bearer " + YOY_Player.token);
            //var responseString = await client.GetStringAsync(string.Format("https://data-mng-yoy.azurewebsites.net/api/File/Get?id={0}&key={1}&branchId={2}&dptId={3}", YOYPLAYER.Properties.Settings.Default.UserName, Branch_AccessKey[comboBox2.SelectedValue.ToString()], comboBox2.SelectedValue, comboBox3.SelectedValue));
            var responseString = await client.GetStringAsync(string.Format("https://data-mng-yoy.azurewebsites.net/api/File/Get?id={0}&key={1}&branchId={2}&dptId={3}", YOYPLAYER.Properties.Settings.Default.UserName, key, comboBox2.SelectedValue, comboBox3.SelectedValue));
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

            if(!string.IsNullOrEmpty(fileName))
            {
                
                    //delete previous files
                    var list = Directory.GetFiles(YOYPLAYER.Properties.Settings.Default.DirectoryName, "*.wav");
                    foreach (var item in list)
                    {
                        System.IO.File.Delete(item);
                    }
            }

            using (var request = new HttpRequestMessage(HttpMethod.Get, string.Format("https://data-mng-yoy.azurewebsites.net/api/ContentStream/Get?userId={0}&key={1}&id={2}&downloadType=1", YOYPLAYER.Properties.Settings.Default.UserName, key, fileId)))
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


            _log.LogWrite(string.Format("UserName :{0} | FileType:{1} |  FileName:{2} |  NextSync:{3}  |  RequestDate:{4}", YOYPLAYER.Properties.Settings.Default.UserName, mimeType, fileName, DateTime.Parse(nextSync).ToUniversalTime(), DateTime.Parse(requestDate).ToUniversalTime()));



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
            try { await SecondRequest(); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex==0 || comboBox2.SelectedIndex==0 || comboBox3.SelectedIndex==0)
            {
                MessageBox.Show("Options must be selected....");
                return;
            }
            btnSubmit.Enabled = false;
            // //label1.Text = "Playing......";
            try
            { await ThirdRequest(); }
            catch (Exception ex)
            {
                btnSubmit.Enabled = true;
                MessageBox.Show("Ha ocurrido un error, inténtalo de nuevo");
                return;

            }

            //Start Playing Audio

            //MediaPlayer.MediaPly obj = new MediaPlayer.MediaPly();
            //obj.LoadFile(YOYPLAYER.Properties.Settings.Default.FileName, null);

            try
            {
                // Replace this file name with a valid file name.
                this.Player.SoundLocation = YOYPLAYER.Properties.Settings.Default.FileName;
                this.Player.LoadAsync();

                frmMain f2 = new frmMain(); //this is the change, code for redirect
                this.Hide();
                var result = f2.ShowDialog();
                if (result != DialogResult.Cancel)
                    this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar el sonido");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != 0)
            {
                var branch_id = comboBox2.SelectedValue.ToString();
                var temp = lst_department.Where(x => x.Branche_id == branch_id).ToList();
                temp.Insert(0, new departments() { id = "0", name = "Departamento" });
                bindingSource1.DataSource = temp;
                comboBox3.DataSource = bindingSource1.DataSource;
                comboBox3.DisplayMember = "name";
                comboBox3.ValueMember = "id";

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != 0)
            {


                var commerce_id = comboBox1.SelectedValue.ToString();
                var temp = lst_branches.Where(x => x.commerce_id == commerce_id).ToList();
                temp.Insert(0, new Branches() { id = "0", name = "Local" });
                bindingSource1.DataSource = temp;
                comboBox2.DataSource = bindingSource1.DataSource;
                comboBox2.DisplayMember = "name";
                comboBox2.ValueMember = "id";

            }

        }

        private void FileSelection_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            YOY_Player obj = new YOY_Player(true,false);
            this.Hide();
            obj.ShowDialog();
            

        }
    }
}
