using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO.Ports;
namespace ReadWriteJsonFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists("Setting.json"))
                {
                    StreamReader sr = new StreamReader("Setting.json");
                    string fileData = sr.ReadToEnd();
                    Setting setting = JsonConvert.DeserializeObject<Setting>(fileData);
                    txtDbServer.Text = setting.dBSetting.DBServer;
                    Parity p = (Parity)Enum.Parse(typeof(Parity), setting.Parity);
                    sr.Close();
                    sr.Dispose();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Setting setting = new Setting
                {
                    dBSetting = new DBSetting { DBName = "Test", DBServer = "MyServer", UserId = "admin", Password = "amit" },
                    weighingMachineSetting = new WeighingMachineSetting { BaudRate = "2000", CommPort = "Comm2" }
                };
                string jsonData = JsonConvert.SerializeObject(setting, Formatting.Indented);
                StreamWriter sw = new StreamWriter("Setting.json");
                sw.Write(jsonData);
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }
    }
}
