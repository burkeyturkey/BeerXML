using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerXML.Models
{
    public abstract class RecordBase
    {
        [DataTag(true)]
        public string Name { get; set; }

        [DataTag(true)]
        public int Version { get; set; }
    }
}
