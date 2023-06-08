using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emax.Core.ADO
{
    public class QueryData
    {
        public string QyeryString { get; set; }
        public string TableName { get; set; }
        public string[] SelectionFields { get; set; }
        public string FilterString { get; set; }

        public List<JoinTableInfo> JoinTables { get; set; }
        public IEnumerable<KeyValuePair<string, object>> FilterPairs { get; set; }

        public QyeryDataResult GetQueryString()
        {
            QyeryDataResult qyeryDataResult = new QyeryDataResult();
            if (!string.IsNullOrEmpty(this.QyeryString))
            {
                qyeryDataResult.Qyery = this.QyeryString;
            }
            else
            {


                StringBuilder queryBuilder = new StringBuilder("SELECT ");
                
                if (this.SelectionFields != null && this.SelectionFields.Any())
                {
                    foreach (var field in this.SelectionFields)
                    {
                        if (field.Contains('.'))
                        {
                            var temp = field.Split('.');
                            queryBuilder.Append($"[{temp[0].Trim()}].[{temp[1].Trim()}] , ");
                        }
                        else
                        {
                            queryBuilder.Append($"[{field.Trim()}] , ");
                        }
                       
                    }
                    queryBuilder.Remove(queryBuilder.Length - 2, 2);

                    queryBuilder.Append($" FROM [{this.TableName.Trim()}] ");

                    if (this.JoinTables != null && this.JoinTables.Any())
                    {
                        foreach (var table in this.JoinTables)
                        {
                            if (table.ParentFields == null || table.ChildFields == null || table.ParentFields.Count() == 0 || table.ChildFields.Count() == 0)
                            {
                                throw new Exception("Error: no join fields exist, at least one pair of join fields must exist. ");
                            }
                            if (table.ParentFields.Count() != table.ChildFields.Count())
                            {
                                throw new Exception("Error: matching parent fields and child fields count");
                            }

                            queryBuilder.Append($" LEFT OUTER JOIN [{table.JoinTableName}] ");
                            queryBuilder.Append($" ON [{this.TableName}].[{table.ChildFields[0]}] = [{table.JoinTableName}].[{table.ParentFields[0]}] ");
                            if (table.ParentFields.Count() > 1)
                            {
                                for (int i = 1; i < table.ParentFields.Count(); i++)
                                {
                                    queryBuilder.Append($" AND [{this.TableName}].[{table.ChildFields[i]}] = [{table.JoinTableName}].[{table.ParentFields[i]}] ");

                                }
                            }

                        }
                    }
                }
                else
                {
                    throw new Exception("Not enough information to generate 'Select SQL Command'");
                }


                if (this.FilterPairs != null && this.FilterPairs.Any())
                {
                    List<SqlParameter> sqlParameters = new List<SqlParameter>();

                    foreach (var pair in this.FilterPairs)
                    {
                        sqlParameters.Add(new SqlParameter(pair.Key, pair.Value));

                    }
                    qyeryDataResult.Parameters = sqlParameters;

                }
                else if (!string.IsNullOrEmpty(this.FilterString))
                {
                    queryBuilder.Append($" WHERE {this.FilterString}");
                }
                qyeryDataResult.Qyery = queryBuilder.ToString();
            }





            return qyeryDataResult;
        }


    }
    public class QyeryDataResult
    {
        public string Qyery { get; set; }
        public List<SqlParameter> Parameters { get; set; }
    }
}
