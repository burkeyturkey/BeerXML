using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BeerXML.Models;

namespace BeerXML.Utilities
{
    public class BeerXMLElement
    {
        public enum Types
        {
            Record,
            RecordSet,
            Percentage,
            List,
            Text,
            Boolean,
            Integer,
            FloatingPoint,
            Date//not standard, but they use it...
        }

        public DataTagAttribute DataTagAttribute { get { return PropertyInfo.GetCustomAttributes<DataTagAttribute>(true).Single(); } }
        public string ElementName { get { return (string.IsNullOrEmpty(DataTagAttribute.Name) ? PropertyInfo.Name : DataTagAttribute.Name).ToUpper(); } }
        public bool Required { get { return DataTagAttribute.Required; } }
        public Types Type
        {
            get
            {
                if (typeof(RecordBase).IsAssignableFrom(PropertyInfo.PropertyType)) return Types.Record;
                if (typeof(System.Collections.IList).IsAssignableFrom(PropertyInfo.PropertyType))
                {
                    List<Type> genericTypes = PropertyInfo.PropertyType.GenericTypeArguments.ToList();
                    if (genericTypes.Count == 1 && typeof(RecordBase).IsAssignableFrom(genericTypes[0])) return Types.RecordSet;
                }
                if (PropertyInfo.PropertyType.GetTypeInfo().IsEnum) return Types.List;
                if (typeof(string).IsAssignableFrom(PropertyInfo.PropertyType)) return Types.Text;
                if (typeof(bool).IsAssignableFrom(PropertyInfo.PropertyType)) return Types.Boolean;
                if (typeof(int).IsAssignableFrom(PropertyInfo.PropertyType)) return Types.Integer;
                if (typeof(double).IsAssignableFrom(PropertyInfo.PropertyType)) return Types.FloatingPoint;
                if (typeof(DateTime).IsAssignableFrom(PropertyInfo.PropertyType)) return Types.Date;
                if (typeof(UnitsNet.Ratio).IsAssignableFrom(PropertyInfo.PropertyType) && DataTagAttribute.Unit == null) return Types.Percentage;
                if (PropertyInfo.IsBeerXMLProperty()) return Types.FloatingPoint;

                return Types.Text;//or maybe throw an exception?
            }
        }

        public PropertyInfo PropertyInfo { get; set; }
        

        public BeerXMLElement(PropertyInfo propertyInfo)
        {
            if (!propertyInfo.IsBeerXMLProperty()) throw new ArgumentException("propertyInfo must be a member of a RecordBase object and have a single DataTagAttribute");
            PropertyInfo = propertyInfo;
        }

    }

    public static class BeerXMLElementUtilities
    {
        public static List<BeerXMLElement> GetBeerXMLElements(this RecordBase recordBase)
        {
            return recordBase.GetType().GetProperties().Where(p => p.IsBeerXMLProperty()).Select(p => new BeerXMLElement(p)).ToList();
        }

        public static bool IsBeerXMLProperty(this PropertyInfo propertyInfo)
        {
            if (!typeof(RecordBase).IsAssignableFrom(propertyInfo.DeclaringType)) return false;
            IEnumerable<DataTagAttribute> dataTagAttributes = propertyInfo.GetCustomAttributes<DataTagAttribute>(true);
            return dataTagAttributes.Count() == 1; 
        }
    }
}
