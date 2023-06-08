using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanSales.POS.Models
{
    public class s_invmeasures
    {
        public int imeasurid { get; set; }
        public int invid { get; set; }
        public int custid { get; set; }
        public string rsphd { get; set; }
        public string rclyd { get; set; }
        public string raxisd { get; set; }
        public string lsphd { get; set; }
        public string lclyd { get; set; }
        public string laxisd { get; set; }
        public string rsphr { get; set; }
        public string rclyr { get; set; }
        public string raxisr { get; set; }
        public string lsphr { get; set; }
        public string lclyr { get; set; }
        public string laxisr { get; set; }
        public string ipc { get; set; }
        public string note { get; set; }
    }
}
