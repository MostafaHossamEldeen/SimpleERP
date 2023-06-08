using Repository.Ado;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emax.Dal.Ado
{
 
    [Serializable]
    public class ExceptionAnalyse 
    {

        
        public ExceptionAnalyse(
         Exception ex)
        {
            AnalyseEx(ex);
        }
        public ExceptionAnalyse(
       string ex)
        {
            storedExecuteResulte = new StoredExecuteResulte();
            storedExecuteResulte.errormsg=AnalyseEx(ex);
        }
        public ExceptionAnalyse(
      Exception ex,string storedname)
        {
            storedExecuteResulte = new StoredExecuteResulte();
            storedExecuteResulte.errormsg= AnalyseEx(ex,storedname);
            
        }
        public StoredExecuteResulte  storedExecuteResulte { get; set; }
        string AnalyseEx(Exception ex, string storedname="")
        {

            string exmessage = $"The DELETE statement conflicted with the REFERENCE constraint";
            if (ex.Message != null && ex.Message.Length != 0)
            {

                string msg = ex.Message;
                if (msg.Contains(exmessage))
                {
                    //string resmsg=msg.Replace(exmessage, "");
                    string resmsg = "لا يمكن حذف كود مستخدم باحدي الحركات";
                    return resmsg;// GetFieldName(resmsg);
                }
                else
                {
                    return msg;
                }

            }
            else
            {
                return string.Empty;
            }
        }
        string AnalyseEx(string ex, string storedname = "")
        {

            string exmessage = $"The DELETE statement conflicted with the REFERENCE constraint";
            if (ex != null && ex.Length != 0)
            {

                string msg = ex;
                if (msg.Contains(exmessage))
                {
                    //string resmsg = msg.Replace(exmessage, "");
                    string resmsg = "لا يمكن حذف كود مستخدم باحدي الحركات";
                    return resmsg;// GetFieldName(resmsg);
                }
                else
                {
                    return msg;
                }

            }
            else
            {
                return string.Empty;
            }
        }
        string GetFieldName(string fieldname)
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(@"C:/Users/PC/source/repos/VanSales/Emax.Vansales.Service/App_Data/tb1");
            var selectedrow = dataSet.Tables[0].AsEnumerable().Where(i => i.Field<string>("fieldname") == fieldname).SingleOrDefault();
            if (selectedrow!=null && selectedrow.Field<string>("fieldvalue").Length!=0)
            {
                return selectedrow.Field<string>("fieldvalue");
            }
            else
            {
                return fieldname;
            }
        }
    }
}
