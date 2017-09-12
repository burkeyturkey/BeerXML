using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerXML.Models
{
    public class Equipment : RecordBase
    {
        [DataTag(true, Name = "Boil_Size")]
        public UnitsNet.Volume BoilSize { get; set; }

        [DataTag(true, Name = "Batch_Size")]
        public UnitsNet.Volume BatchSize { get; set; }

        [DataTag(false, Name = "Tun_Volume")]
        public UnitsNet.Volume TunVolume { get; set; }

        [DataTag(false, Name = "Tun_Weight")]
        public UnitsNet.Mass TunMass { get; set; }

        [DataTag(false, Name = "Tun_Specific_Heat")]
        public UnitsNet.SpecificEnergy TunSpecificHeat { get; set; }

        [DataTag(false, Name = "Top_Up_Water")]
        public UnitsNet.Volume TopUpWater { get; set; }

        [DataTag(false, Name = "Trub_Chiller_Loss")]
        public UnitsNet.Volume TrubChillerLoss { get; set; }

        [DataTag(false, Name = "Evap_Rate")]
        public UnitsNet.Volume EvaporationRate { get; set; }

        [DataTag(false, Name = "Boil_Time")]
        public UnitsNet.Duration BoilTime { get; set; }

        [DataTag(false, Name = "Calc_Boil_Volume")]
        public bool CalculatedBoilVolume { get; set; }

        [DataTag(false, Name = "Lauter_Deadspace")]
        public UnitsNet.Volume LauterDeadspace { get; set; }

        [DataTag(false, Name = "Top_Up_Kettle")]
        public UnitsNet.Volume TopUpKettle { get; set; }

        [DataTag(false, Name = "Hop_Utilization")]
        public UnitsNet.Ratio HopUtilization { get; set; }

        [DataTag(false)]
        public string Notes { get; set; }
    }
}
