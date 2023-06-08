using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emax.Core.Reflection
{
    public class CustomPropertyInfo
    {
        
        public string PropertyName { get; set; }

        public Type PropertyType { get; set; }

        public string PropertyTypeName { get { return PropertyType.Name; } }

        public object Value { get; set; }

        public string SqlValue { get
            {
                string value;
                if(PropertyType == typeof(string) || PropertyType == typeof(DateTime))
                {
                    value = " '" + this.Value.ToString() + "' ";
                }
                else
                {
                    value = this.Value.ToString();
                }
                return value;
            } }

        public string SqlFilter
        {
            get { return PropertyName + " = " + SqlValue ; }
        }
    }
}
