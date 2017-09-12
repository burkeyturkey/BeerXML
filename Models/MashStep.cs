using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerXML.Models
{
    public class MashStep : RecordBase
    {

        public enum Types
        {
            Infusion,
            Temperature,
            Decoction
        }

        [DataTag(true)]
        public Types Type { get; set; }

        [DataTag(false, Name = "Infuse_Amount")]
        public UnitsNet.Volume InfuseAmount { get; set; }
    
        [DataTag(true, Name = "Step_Temp")]
        public UnitsNet.Temperature StepTemp { get; set; }

        [DataTag(true, Name = "Step_Time")]
        public UnitsNet.Duration StepTime { get; set; }

        [DataTag(false,Name = "Ramp_Time")]
        public UnitsNet.Duration RampTime { get; set; }

        [DataTag(false, Name = "End_Temp")]
        public UnitsNet.Temperature EndTemp { get; set; }
    }
}
