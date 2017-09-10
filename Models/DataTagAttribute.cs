using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerXML.Models
{
    public enum DataTagFormat {RecordSet, Record, Percentage, List, Text, Boolean, Integer, FloatingPoint }

    [AttributeUsage(AttributeTargets.Property)]
    public class DataTagAttribute : Attribute
    {
        public string Name { get; set; }
        public bool Required { get; set; }
        public UnitsNet.QuantityType QuantityType { get; set; }

        public DataTagAttribute(bool required)
        {
            Required = required;
            QuantityType = UnitsNet.QuantityType.Undefined;
        }
    }
}
