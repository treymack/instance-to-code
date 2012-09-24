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
            BuildCode(sb, instance, new Indent());
            return sb.ToString();
        }

        private static void BuildCode(StringBuilder sb, object instance, Indent indent)
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

            sb.AppendLine(String.Format("new {0}()", instanceType.FullName.Replace("+", ".")));
            sb.AppendLine("{");
            var properties = TypeDescriptor.GetProperties(instance);
            indent.Increase();
            foreach (PropertyDescriptor property in properties)
            {
                var propertyType = property.PropertyType;
                if (typeof(IList).IsAssignableFrom(propertyType))
                {
                    var listType = propertyType.GenericTypeArguments[0];
                    sb.Append(property.Name).Append(" = new List<")
                        .Append(listType.FullName).AppendLine(">")
                        .AppendLine("{");

                    var list = (IList)property.GetValue(instance);
                    foreach (var thisInstance in list)
                    {
                        sb.AppendLine("{");
                        indent.Increase();

                        BuildCode(sb, thisInstance, indent);
                        sb.AppendLine();

                        indent.Decrease();
                        sb.AppendLine("},");
                    }

                    sb.AppendLine("},");
                }
                else
                {
                    sb.Append(property.Name).Append(" = ");
                    BuildCode(sb, property.GetValue(instance), indent);
                    sb.AppendLine(",");
                }
            }
            indent.Decrease();
            sb.Append("}");
        }

        public class Indent
        {
            public string Current { get; set; }

            public Indent()
            {
                Current = "";
            }

            public void Increase()
            {
                Current += "    ";
            }

            public void Decrease()
            {
                Current = Current.Substring(4);
            }
        }
    }

    public static class IndentExtensions
    {
        public static StringBuilder Indent(this StringBuilder sb, Instance.Indent indent)
        {
            sb.Append(indent.Current);
            return sb;
        }
    }
}
