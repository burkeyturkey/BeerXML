using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using BeerXML.Utilities;

namespace BeerXML.Models
{
    public abstract class RecordBase : IXmlSerializable
    {
        [DataTag(true)]
        public string Name { get; set; }

        [DataTag(true)]
        public int Version { get; set; }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.Deserialize(this);
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.Serialize(this);
        }
    }
}
