using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerXML.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DataTagAttribute : Attribute
    {
        public string Name { get; set; }//only necessary if the property name won't be the same as the xml element name
        public bool Required { get; set; }
        public object Unit { get; set; }//only necessary if the default beerxml unit is not correct and the type is a UnitsNet unit

        public DataTagAttribute(bool required)
        {
            Required = required;
            Unit = null;
        }
    }
}
