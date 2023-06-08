using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emax.Core.ADO
{
    public class JoinTableInfo
    {
        public JoinTableInfo() { }
        public JoinTableInfo(string joinTableName, string parentFields, string selectFields)
        {
            this.JoinTableName = joinTableName;
            this.ParentFields = parentFields.Split(';');
            this.ChildFields = this.ParentFields;
            this.SelectFields = selectFields.Split(';');
        }
        public JoinTableInfo(string joinTableName, string parentFields, string childFields, string selectFields)
        {
            this.JoinTableName = joinTableName;
            this.ParentFields = parentFields.Split(';');
            this.ChildFields = childFields.Split(';');
            this.SelectFields = selectFields.Split(';');
        }
        public string JoinTableName { get; set; }
        public string[] ChildFields { get; set; }
        public string[] ParentFields { get; set; }
        public string[] SelectFields { get; set; }
    }
}
