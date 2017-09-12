using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerXML.Models
{
    public class Yeast : RecordBase
    {
        public enum Types
        {
            Ale,
            Lager,
            Wheat,
            Wine,
            Champagne
        }

        public enum Forms
        {
            Liquid,
            Dry,
            Slant,
            Culture
        }

        public enum FlocculationTypes
        {
            Low,
            Medium,
            High,
            [ListName("Very High")]
            VeryHigh
        }

        [DataTag(true)]
        public Types Type { get; set; }

        [DataTag(true)]
        public Forms Form { get; set; }

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

        [DataTag(false)]
        public string Laboratory { get; set; }

        [DataTag(false, Name = "Product_ID")]
        public string ProductID { get; set; }

        [DataTag(false, Name = "Min_Temperature")]
        public UnitsNet.Temperature MinTemperature { get; set; }

        [DataTag(false, Name = "Max_Temperature")]
        public UnitsNet.Temperature MaxTemperature { get; set; }

        [DataTag(false)]
        public FlocculationTypes Flocculation { get; set; }

        [DataTag(false)]
        public UnitsNet.Ratio Attenuation { get; set; }

        [DataTag(false)]
        public string Notes { get; set; }

        [DataTag(false, Name = "Best_For")]
        public string BestFor { get; set; }

        [DataTag(false, Name = "Times_Cultured")]
        public int TimesCultured { get; set; }

        [DataTag(false, Name = "Max_Reuse")]
        public int MaxReuse { get; set; }

        [DataTag(false, Name = "Add_To_Secondary")]
        public bool AddToSecondary { get; set; }
    }
}
