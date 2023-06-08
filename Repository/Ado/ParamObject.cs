using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Ado
{
   public class ParamObject
    {
        public string ParamName { get; set; } = string.Empty;
        public object ParamValue { get; set; } = null;
    }
}
