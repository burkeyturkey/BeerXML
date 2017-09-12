using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerXML.Models
{
    public class Style : RecordBase
    {
        public enum Types
        {
            Lager,
            Ale,
            Mead,
            Wheat,
            Mixed,
            Cider
        }

        [DataTag(true)]
        public Types Type { get; set; }

        [DataTag(true)]
        public string Category { get; set; }

        [DataTag(true, Name = "Category_Number")]
        public string CategoryNumber { get; set; }

        [DataTag(true, Name = "Style_Letter")]
        public string StyleLetter { get; set; }

        [DataTag(true, Name = "Style_Guide")]
        public string StyleGuide { get; set; }

        [DataTag(true, Name = "OG_Min", Unit = UnitsNet.Units.RatioUnit.DecimalFraction)]
        public UnitsNet.Ratio OriginalGravityMin { get; set; }

        [DataTag(true, Name = "OG_Max", Unit = UnitsNet.Units.RatioUnit.DecimalFraction)]
        public UnitsNet.Ratio OriginalGravityMax { get; set; }

        [DataTag(true, Name = "FG_Min", Unit = UnitsNet.Units.RatioUnit.DecimalFraction)]
        public UnitsNet.Ratio FinalGravityMin { get; set; }

        [DataTag(true, Name = "FG_Max", Unit = UnitsNet.Units.RatioUnit.DecimalFraction)]
        public UnitsNet.Ratio FinalGravityMax { get; set; }

        [DataTag(true, Name = "IBU_Min")]
        public double IBUMin { get; set; }

        [DataTag(true, Name = "IBU_Max")]
        public double IBUMax { get; set; }

        [DataTag(true, Name = "Color_Min")]
        public double ColorMin { get; set; }

        [DataTag(true, Name = "Color_Max")]
        public double ColorMax { get; set; }

        [DataTag(false, Name = "Carb_Min")]
        public double CarbMin { get; set; }

        [DataTag(false, Name = "Carb_Max")]
        public double CarbMax { get; set; }

        [DataTag(false, Name = "ABV_Min")]
        public UnitsNet.Ratio ABVMin { get; set; }

        [DataTag(false, Name = "ABV_Max")]
        public UnitsNet.Ratio ABVMax { get; set; }

        [DataTag(false)]
        public string Notes { get; set; }

        [DataTag(false)]
        public string Profile { get; set; }

        [DataTag(false)]
        public string Ingredients { get; set; }

        [DataTag(false)]
        public string Examples { get; set; }
    }
}
