using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace BeerXML.Models
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ListNameAttribute : Attribute
    {
        public string Name { get; set; }
        public ListNameAttribute(string name)
        {
            Name = name;
        }

        public static string GetEnumName(object value, Type type)
        {
            if (!type.GetTypeInfo().IsEnum) throw new ArgumentException("Type must be an enum");
            return GetListName(type.GetFields().Single(f => (f.GetValue(null)) == value));
        }

        public static object GetEnumValue(string name, Type type)
        {
            if (!type.GetTypeInfo().IsEnum) throw new ArgumentException("Type must be an enum");
            return (type.GetFields().Single(f => GetListName(f).Equals(name)).GetValue(null));
        }

        public static string GetListName(FieldInfo fieldInfo)
        {
            return HasListNameAttribute(fieldInfo) ? GetListNameAttribute(fieldInfo).Name : fieldInfo.Name;
        }

        public static bool HasListNameAttribute(FieldInfo fieldInfo)
        {
            return fieldInfo.GetCustomAttributes<ListNameAttribute>(true).Count() == 1;
        }

        public static ListNameAttribute GetListNameAttribute(FieldInfo fieldInfo)
        {
            return fieldInfo.GetCustomAttributes<ListNameAttribute>(true).Single();
        }
    }
}
