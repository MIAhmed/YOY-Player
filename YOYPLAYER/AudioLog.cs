using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YOYPLAYER
{
    public partial class AudioLog : Form
    {
        public AudioLog()
        {
            InitializeComponent();
        }

        private void AudioLog_Load(object sender, EventArgs e)
        {
            try
            {
                List<FileInfo> info = new List<FileInfo>();
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + "log.txt";
                if (File.Exists(path))
                {

                    var temp = File.ReadAllLines(path);

                    foreach (string s in temp)
                    {
                        FileInfo file_log = new FileInfo();
                        var result = s.Split('|');
                        file_log.UserName = result[0].Replace("UserName:", "");
                        file_log.FileType = result[1].Replace("FileType:", "");
                        file_log.FileName = result[2].Replace("FileName:", "");
                        file_log.NextSync = DateTime.Parse(result[3].Replace("NextSync:", "")).ToUniversalTime();
                        file_log.RequestDate = DateTime.Parse(result[4].Replace("RequestDate:", "")).ToUniversalTime();
                        info.Add(file_log);
                    }

                    dataGridView1.DataSource = info;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error, inténtalo de nuevo");
            }

        }
    }
}
