using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerXML.Models
{
    public class Misc : RecordBase
    {
        public enum Types
        {
            Spice,
            Fining,
            Water,
            Agent,
            Herb,
            Flavor,
            Other
        }

        public enum Uses
        {
            Boil,
            Mash,
            Primary,
            Secondary,
            Bottling
        }

        [DataTag(true)]
        public Types Type { get; set; }

        [DataTag(true)]
        public Uses Use { get; set; }

        [DataTag(true)]
        public UnitsNet.Duration Time { get; set; }

        [DataTag(true)]
        public double Amount { get; set; }

        [DataTag(false, Name = "Amount_Is_Weight")]
        public bool AmountIsWeight { get; set; }

        public UnitsNet.Volume AmountAsVolume
        {
            get
            {
                if (AmountIsWeight) throw new InvalidCastException("Amount is stored as a mass, not a volume");
                return UnitsNet.Volume.FromLiters(Amount);
            }
            set
            {
                Amount = value.Liters;
                AmountIsWeight = false;
            }
        }

        public UnitsNet.Mass AmountAsMass
        {
            get
            {
                if (!AmountIsWeight) throw new InvalidCastException("Amount is stored as a volume, not a mass");
                return UnitsNet.Mass.FromKilograms(Amount);
            }
            set
            {
                Amount = value.Kilograms;
                AmountIsWeight = true;
            }
        }

        [DataTag(false, Name = "Use_For")]
        public string UseFor { get; set; }

        [DataTag(false)]
        public string Notes { get; set; }

    }
}
