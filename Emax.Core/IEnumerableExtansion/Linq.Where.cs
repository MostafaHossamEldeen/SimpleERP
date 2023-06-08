using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Emax.Core.IEnumerableExtansion
{
    public static partial class Linq
    {
		public static TEntity SingleOrDefault<TEntity>(this IEnumerable<TEntity> entities,IEnumerable<KeyValuePair<string,string>> keys) where TEntity:class
        {
			if(keys !=null && keys.Any())
            {
              //  var converter = TypeDescriptor.GetConverter(propertyType); // 1
                var parameter = Expression.Parameter(typeof(TEntity), "e");
                Expression expression=Expression.Equal(Expression.Constant(1), Expression.Constant(1));
				foreach(var pair in keys)
                {
                    var property = Expression.PropertyOrField(parameter, pair.Key);
                    var tyepConverter = TypeDescriptor.GetConverter(((PropertyInfo)property.Member).PropertyType);
                    expression = Expression.And(expression, Expression.Equal(property, Expression.Constant(tyepConverter.ConvertFrom( pair.Value))));
                }

                return entities.SingleOrDefault(Expression.Lambda<Func<TEntity, bool>>(expression, parameter).Compile());
            }
            return null;
        }


    }
}
