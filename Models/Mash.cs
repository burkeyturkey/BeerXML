using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerXML.Models
{
    public class Mash : RecordBase
    {
        [DataTag(true)]
        public UnitsNet.Temperature Grain_Temp { get; set; }

        [DataTag(true, Name = "Mash_Steps")]
        public List<MashStep> MashSteps { get; set; }

        [DataTag(false)]
        public string Notes { get; set; }

        [DataTag(false, Name = "Tun_Temp")]
        public UnitsNet.Temperature TunTemp { get; set; }

        [DataTag(false, Name = "Sparge_Temp")]
        public UnitsNet.Temperature SpargeTemp { get; set; }

        [DataTag(false)]
        public double PH { get; set; }

        [DataTag(false)]
        public UnitsNet.Mass TunMass { get; set; }

        [DataTag(false, Name = "Tun_Specific_Heat", Unit = UnitsNet.Units.SpecificEnergyUnit.CaloriePerGram)]
        public UnitsNet.SpecificEnergy TunSpecificHeat { get; set; }

        [DataTag(false, Name = "Equip_Adjust")]
        public bool EquipmentAdjust { get; set; }
    }
}
