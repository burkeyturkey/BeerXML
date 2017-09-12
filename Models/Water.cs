using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerXML.Models
{
    public class Water : RecordBase
    {
        [DataTag(true)]
        public UnitsNet.Volume Amount { get; set; }

        [DataTag(true, Unit = UnitsNet.Units.RatioUnit.PartPerMillion)]
        public double Calcium { get; set; }

        [DataTag(true, Unit = UnitsNet.Units.RatioUnit.PartPerMillion)]
        public double Bicarbonate { get; set; }

        [DataTag(true, Unit = UnitsNet.Units.RatioUnit.PartPerMillion)]
        public double Sulfate { get; set; }

        [DataTag(true, Unit = UnitsNet.Units.RatioUnit.PartPerMillion)]
        public double Chloride { get; set; }

        [DataTag(true, Unit = UnitsNet.Units.RatioUnit.PartPerMillion)]
        public double Sodium { get; set; }

        [DataTag(true, Unit = UnitsNet.Units.RatioUnit.PartPerMillion)]
        public double Magnesium { get; set; }

        [DataTag(false)]
        public double PH { get; set; }

        [DataTag(false)]
        public string Notes { get; set; }

    }
}
