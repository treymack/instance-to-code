using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheProject
{
    public static class Instance
    {
        public static string ToCode(object instance)
        {
            var sb = new StringBuilder();
            BuildCode(sb, instance);
            return sb.ToString();
        }

        private static void BuildCode(StringBuilder sb, object instance)
        {
            if (instance == null)
            {
                sb.Append("null");
                return;
            }

            var instanceType = instance.GetType();

            if (instanceType.IsEnum)
            {
                sb.Append(instanceType.FullName).Append(".").Append(instance);
                return;
            }

            if (instanceType.Equals(typeof(string)))
            {
                sb.Append("\"").Append(instance).Append("\"");
                return;
            }

            if (instanceType.IsValueType)
            {
                sb.Append(instance);
                return;
            }

            sb.Append(String.Format("new {0}(){1}{{{1}", instanceType.FullName.Replace("+", "."), Environment.NewLine));
            var properties = TypeDescriptor.GetProperties(instance);
            foreach (PropertyDescriptor property in properties)
            {
                var propertyType = property.PropertyType;
                if (typeof(IList).IsAssignableFrom(propertyType))
                {

                }
                else
                {
                    sb.Append(property.Name).Append(" = ");
                    BuildCode(sb, property.GetValue(instance));
                    sb.Append(",").Append(Environment.NewLine);
                }
            }
            sb.Append("}");
        }
    }
}
