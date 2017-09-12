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
        

        [DataTag(true)]
        public UnitsNet.Ratio Alpha { get; set; }

        [DataTag(true)]
        public UnitsNet.Mass Amount { get; set; }

        [DataTag(true)]
        public Uses Use { get; set; }

        [DataTag(true)]
        public UnitsNet.Duration Time { get; set; }

        [DataTag(false)]
        public string Notes { get; set; }

        [DataTag(false)]
        public Types Type { get; set; }

        [DataTag(false)]
        public Forms Form { get; set; }

        [DataTag(false)]
        public UnitsNet.Ratio Beta { get; set; }

        [DataTag(false)]
        public UnitsNet.Ratio HSI { get; set; }

        [DataTag(false)]
        public string Origin { get; set; }

        [DataTag(false)]
        public string Substitutes { get; set; }

        [DataTag(false)]
        public UnitsNet.Ratio Humulene { get; set; }

        [DataTag(false)]
        public UnitsNet.Ratio Caryophyllene { get; set; }

        [DataTag(false)]
        public UnitsNet.Ratio Cohumulone { get; set; }

        [DataTag(false)]
        public UnitsNet.Ratio Myrcene { get; set; }
    }
}
