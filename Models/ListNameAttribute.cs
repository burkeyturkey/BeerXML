using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
