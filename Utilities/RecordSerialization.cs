using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerXML.Models;
using System.Xml;
using System.Reflection;

namespace BeerXML.Utilities
{
    public static class RecordSerialization
    {
        public static void Serialize(this XmlWriter xmlWriter, RecordBase recordBase)
        {

        }

        public static void Deserialize(this XmlReader xmlReader, RecordBase recordBase)
        {//should be starting after someone just popped off the single reocrdbase element
            List<BeerXMLElement> beerXMLElements = recordBase.GetBeerXMLElements();
            while(!xmlReader.EOF)
            {
                if(xmlReader.NodeType == XmlNodeType.Element)
                {
                    IEnumerable<BeerXMLElement> matchingBeerXMLElements = beerXMLElements.Where(e => string.Equals(e.ElementName, xmlReader.LocalName));
                    if (matchingBeerXMLElements.Count() == 1)
                    {
                        recordBase.SetValue(matchingBeerXMLElements.Single(), xmlReader);
                    } else
                    {
                        xmlReader.ReadOuterXml();//bypass the entire element and sub-element because we didnt recognize it
                    }
                }
                else if (xmlReader.NodeType == XmlNodeType.EndElement)
                {
                    xmlReader.Read();//pop off the end element
                    break;
                } else
                {
                    xmlReader.Read();//pop off unknown element, probably white space
                }
            }

        }

        public static void Serialize<T>(this XmlWriter xmlWriter, List<T> recordBaseList)
        {

        }

        public static void Deserialize<T>(this XmlReader xmlReader, List<T> recordBaseList)
            where T : RecordBase, new()
        {//should be starting after someone just popped off th eplural start element
            recordBaseList.Clear();
            while(!xmlReader.EOF)
            {
                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    if (string.Equals(typeof(T).Name.ToUpper(), xmlReader.LocalName))
                    {
                        T newRecordBase = new T();
                        xmlReader.Read();//pop off the recordbase start element
                        xmlReader.Deserialize(newRecordBase);//will pop off the end of the single recordbase element
                        recordBaseList.Add(newRecordBase);
                    } else
                    {
                        xmlReader.ReadOuterXml();//read through the unknown elemnt and
                    }
                } else if(xmlReader.NodeType == XmlNodeType.EndElement)
                {
                    xmlReader.Read();//pop off the plural end element
                    break;
                } else
                {
                    xmlReader.Read();//pop off unknown element, probably whitespace
                }
                
            }
        }

        public static void SetValue(this RecordBase recordBase, BeerXMLElement beerXMLElement, XmlReader xmlReader)
        {
            object value;
            switch(beerXMLElement.Type)
            {
                case BeerXMLElement.Types.Record:
                    value = Activator.CreateInstance(beerXMLElement.PropertyInfo.PropertyType);
                    beerXMLElement.PropertyInfo.SetValue(recordBase, value);
                    xmlReader.Read();//pop off the Recordbase element
                    xmlReader.Deserialize(value as RecordBase);
                    break;
                case BeerXMLElement.Types.RecordSet:
                    value = Activator.CreateInstance(beerXMLElement.PropertyInfo.PropertyType);
                    beerXMLElement.PropertyInfo.SetValue(recordBase, value);
                    xmlReader.Read();//pop off the plural start element
                    MethodInfo deserializationMethod = typeof(RecordSerialization).GetMethods().Single(mi => mi.Name.Equals("Deserialize") && mi.ContainsGenericParameters);
                    deserializationMethod.MakeGenericMethod(beerXMLElement.PropertyInfo.PropertyType.GenericTypeArguments[0]).Invoke(null, new object[] { xmlReader, value });
                    break;
                case BeerXMLElement.Types.Text:
                    value = xmlReader.ReadElementContentAsString();
                    beerXMLElement.PropertyInfo.SetValue(recordBase, value);
                    break;
                case BeerXMLElement.Types.Boolean:
                    value = Boolean.Parse(xmlReader.ReadElementContentAsString());
                    beerXMLElement.PropertyInfo.SetValue(recordBase, value);
                    break;
                case BeerXMLElement.Types.Integer:
                    value = xmlReader.ReadElementContentAsLong();
                    beerXMLElement.PropertyInfo.SetValue(recordBase,Convert.ChangeType(value,beerXMLElement.PropertyInfo.PropertyType));
                    break;
                case BeerXMLElement.Types.List:
                    string stringValue = xmlReader.ReadElementContentAsString();
                    value = ListNameAttribute.GetEnumValue(stringValue, beerXMLElement.PropertyInfo.PropertyType);
                    beerXMLElement.PropertyInfo.SetValue(recordBase, value);
                    break;
                case BeerXMLElement.Types.Percentage:
                    value = UnitsNet.Ratio.FromPercent(xmlReader.ReadElementContentAsDouble());
                    beerXMLElement.PropertyInfo.SetValue(recordBase, value);
                    break;
                case BeerXMLElement.Types.Date:
                    value = DateTime.Parse(xmlReader.ReadElementContentAsString());
                    beerXMLElement.PropertyInfo.SetValue(recordBase, value);
                    break;
                case BeerXMLElement.Types.FloatingPoint:
                    double numericValue = xmlReader.ReadElementContentAsDouble();
                    if (beerXMLElement.PropertyInfo.PropertyType.IsUnitStruct())
                    {
                        value = beerXMLElement.PropertyInfo.PropertyType.GetUnitStruct(numericValue, beerXMLElement.DataTagAttribute.Unit);
                    } else
                    {
                        value = Convert.ChangeType(numericValue, beerXMLElement.PropertyInfo.PropertyType);
                    }
                    beerXMLElement.PropertyInfo.SetValue(recordBase, value);
                    break;

                default:
                    value = null;
                    break;
            }
            
        }

    }
}
