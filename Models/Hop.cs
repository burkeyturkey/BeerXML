using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerXML.Models
{
    public class Hop : RecordBase
    {
        public enum Uses {
            Boil,
            [ListName("Dry Hop")]
            DryHop,
            Mash,
            [ListName("First Wort")]
            FirstWort,
            Aroma }

        public enum Types
        {
            Bittering,
            Aroma
        }

        public enum Forms
        {
            Pellet,
            Plug,
            Leaf
        }
        

        [DataTag(true, QuantityType = UnitsNet.QuantityType.Ratio)]
        public double Alpha { get; set; }

        [DataTag(true, QuantityType = UnitsNet.QuantityType.Mass)]
        public double Amount { get; set; }

        [DataTag(true)]
        public Uses Use { get; set; }

        [DataTag(true, QuantityType = UnitsNet.QuantityType.Duration)]
        public double Time { get; set; }

        [DataTag(false)]
        public string Notes { get; set; }

        [DataTag(false)]
        public Types Type { get; set; }

        [DataTag(false)]
        public Forms Form { get; set; }

        [DataTag(false, QuantityType = UnitsNet.QuantityType.Ratio)]
        public double Beta { get; set; }

        [DataTag(false, QuantityType = UnitsNet.QuantityType.Ratio)]
        public double HSI { get; set; }

        [DataTag(false)]
        public string Origin { get; set; }

        [DataTag(false)]
        public string Substitutes { get; set; }

        [DataTag(false, QuantityType = UnitsNet.QuantityType.Ratio)]
        public double Humulene { get; set; }

        [DataTag(false, QuantityType = UnitsNet.QuantityType.Ratio)]
        public double Caryophyllene { get; set; }

        [DataTag(false, QuantityType = UnitsNet.QuantityType.Ratio)]
        public double Cohumulone { get; set; }

        [DataTag(false, QuantityType = UnitsNet.QuantityType.Ratio)]
        public double Myrcene { get; set; }
    }
}
