using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emax.Core.Reflection
{
    public class CustomeTypeInfo
    {
        private Dictionary<string, CustomPropertyInfo>  customPropertiesDictionary ;

        public CustomeTypeInfo(object obj)
        {
            customPropertiesDictionary = new Dictionary<string, CustomPropertyInfo>();

            var objectType = obj.GetType();
            var originalPropertiesList = objectType.GetProperties();

            this.CustomPropertyInfos = new List<CustomPropertyInfo>();
            this.customPropertiesDictionary = new Dictionary<string, CustomPropertyInfo>();

            foreach (var p in originalPropertiesList)
            {
                CustomPropertyInfo property = new CustomPropertyInfo
                {
                    PropertyName = p.Name,
                    PropertyType = p.GetType(),
                    Value = p.GetValue(p)
                };
                this.CustomPropertyInfos.Add(property);
                this.customPropertiesDictionary.Add(property.PropertyName, property);
            }

            this.TypeName = objectType.Name;
            

        }
        public CustomPropertyInfo this[string key]
        {
            get
            {
                return this.customPropertiesDictionary[key];
            }
        }
        public string TypeName { get; set; }

        public List<CustomPropertyInfo> CustomPropertyInfos { get; set; }
    }
}
