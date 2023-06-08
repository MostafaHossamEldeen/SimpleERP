using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Ado
{
    public class StoredExecuteResulte
    {
        public Dictionary<string,object> outputparams { get; set; }=null;
        public int errorid { get; set; } = 0;
        public string errormsg { get; set; } = string.Empty;
        public bool Success { get; set; } = true;
        public DataTable  dataTable = null;
        public DataTableCollection dataTables = null;
    }
}
