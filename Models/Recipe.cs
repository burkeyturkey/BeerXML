using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerXML.Models
{
    public class Recipe
    {
        public enum Types
        {
            Extract,
            [ListName("Partial Mash")]
            PartialMash,
            [ListName("All Grain")]
            AllGrain
        }

        [DataTag(true)]
        public Types Type { get; set; }

        [DataTag(true)]
        public Style Style { get; set; }

        [DataTag(true)]
        public Equipment Equipment { get; set; }

        [DataTag(true)]
        public string Brewer { get; set; }

        [DataTag(false, Name = "Asst_Brewer")]
        public string AsstBrewer { get; set; }

        [DataTag(true, Name = "Batch_Size", QuantityType = UnitsNet.QuantityType.Volume)]
        public double BatchSize { get; set; }

        [DataTag(true, Name = "Boil_Size", QuantityType = UnitsNet.QuantityType.Volume)]
        public double BoilSize { get; set; }

        [DataTag(true, Name = "Boil_Time", QuantityType = UnitsNet.QuantityType.Duration)]
        public double BoilTime { get; set; }

        [DataTag(false, QuantityType = UnitsNet.QuantityType.Ratio)]
        public double Efficiency { get; set; }

        [DataTag(true)]
        public List<Hop> Hops { get; set; }

        [DataTag(true)]
        public List<Fermentable> Fermentables { get; set; }

        [DataTag(true)]
        public List<Misc> Miscs { get; set; }

        [DataTag(true)]
        public List<Yeast> Yeasts { get; set; }

        [DataTag(true)]
        public List<Water> Waters { get; set; }

        [DataTag(true)]
        public Mash Mash { get; set; }

        [DataTag(false)]
        public string Notes { get; set; }

        [DataTag(false, Name = "Taste_Notes")]
        public string TasteNotes { get; set; }

        [DataTag(false, Name = "Taste_Rating")]
        public double TasteRating { get; set; }

        [DataTag(false, Name = "OG", QuantityType = UnitsNet.QuantityType.SpecificWeight)]
        public double OriginalGravity { get; set; }

        [DataTag(false, Name = "FG", QuantityType = UnitsNet.QuantityType.SpecificWeight)]
        public double FinalGravity { get; set; }

        [DataTag(false, Name = "Fermentation_Stages")]
        public int FermentationStages { get; set; }

        [DataTag(false, Name = "Primary_Age", QuantityType = UnitsNet.QuantityType.Duration)]
        public double PrimaryAge { get; set; }

        [DataTag(false, Name = "Primary_Temp", QuantityType = UnitsNet.QuantityType.Temperature)]
        public double PrimaryTemp { get; set; }

        [DataTag(false, Name = "Secondary_Age", QuantityType = UnitsNet.QuantityType.Duration)]
        public double SecondaryAge { get; set; }

        [DataTag(false, Name = "Secondary_Temp", QuantityType = UnitsNet.QuantityType.Temperature)]
        public double SecondaryTemp { get; set; }

        [DataTag(false, Name = "Tertiary_Age", QuantityType = UnitsNet.QuantityType.Duration)]
        public double TertiaryAge { get; set; }

        [DataTag(false, Name = "Tertiary_Temp", QuantityType = UnitsNet.QuantityType.Temperature)]
        public double TertiaryTemp { get; set; }

        [DataTag(false, Name = "Age_Temp", QuantityType = UnitsNet.QuantityType.Duration)]
        public double BottleAge { get; set; }

        [DataTag(false, Name = "Temp", QuantityType = UnitsNet.QuantityType.Temperature)]
        public double BottleTemp { get; set; }

        [DataTag(false, Name = "Date")]
        public DateTime DateBrewed { get; set; }

        [DataTag(false)]
        public double Carbonation { get; set; }

        [DataTag(false, Name = "Forced_Carbonation")]
        public bool ForcedCarbonation { get; set; }

        [DataTag(false, Name = "Priming_Sugar_Name")]
        public string PrimingSugarName { get; set; }

        [DataTag(false, Name = "Carbonation_Temp", QuantityType = UnitsNet.QuantityType.Temperature)]
        public double CarbonationTemp { get; set; }

        [DataTag(false, Name = "Priming_Sugar_Equiv")]
        public double PrimingSugarEquiv { get; set; }

        [DataTag(false, Name = "Keg_Priming_Factor")]
        public double KegPrimingFactor { get; set; }
    }
}
