using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
namespace ReadWriteJsonFile
{
    public class Setting
    {
        public DBSetting dBSetting { get; set; }
        public WeighingMachineSetting weighingMachineSetting { get; set; }
        public string Parity { get; set; } = "Even";
    }
    public class DBSetting
    {
        public string DBServer { get; set; }
        public string DBName { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
    }
    public class WeighingMachineSetting
    {
        public string CommPort { get; set; }
        public string BaudRate { get; set; }
    }
}
