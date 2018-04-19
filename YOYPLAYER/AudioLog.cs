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
            List<FileInfo> info = new List<FileInfo>();
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+"\\" + "log.txt";
            if (File.Exists(path))
            {
  
               var temp= File.ReadAllLines(path);
                
                foreach (string s in temp)
                {
                    FileInfo file_log = new FileInfo();
                    var result = s.Split('|');
                    file_log.FileType = result[0].Replace("FileType:", "");
                    file_log.FileName = result[1].Replace("FileName:", "");
                    file_log.NextSync = DateTime.Parse(result[2].Replace("NextSync:", "")).ToUniversalTime();
                    file_log.RequestDate= DateTime.Parse(result[3].Replace("RequestDate:", "")).ToUniversalTime();
                    info.Add(file_log);
                }

                dataGridView1.DataSource = info;
            }
        }
    }
}
