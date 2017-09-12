using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace BeerXML.Models
{
    public class Fermentable : RecordBase
    {
        public enum Types
        {
            Grain,
            Sugar,
            Extract,
            [ListName("Dry Extract")]
            DryExtract,
            Adjunct
        }
        

        [DataTag(true)]
        public Types Type { get; set; }

        [DataTag(true)]
        public UnitsNet.Mass Amount { get; set; }

        [DataTag(true)]
        public UnitsNet.Ratio Yield { get; set; }

        [DataTag(true)]
        public double Color { get; set; }

        [DataTag(true, Name = "ADD_AFTER_BOIL")]
        public bool AddAfterBoil { get; set; }

        [DataTag(false)]
        public string Origin { get; set; }

        [DataTag(false)]
        public string Supplier { get; set; }

        [DataTag(false)]
        public string Notes { get; set; }

        [DataTag(false, Name = "Coarse_Fine_Diff")]
        public UnitsNet.Ratio CoarseFineDifference { get; set; }

        [DataTag(false)]
        public UnitsNet.Ratio Moisture { get; set; }

        [DataTag(false, Name = "Diastatic_Power")]
        public double DiastaticPower { get; set; }

        [DataTag(false)]
        public UnitsNet.Ratio Protein { get; set; }

        [DataTag(false, Name = "Max_In_Batch")]
        public UnitsNet.Ratio MaxInBatch { get; set; }

        [DataTag(false, Name = "Recommend_Mash")]
        public bool RecommendMash { get; set; }

        [DataTag(false, Name = "IBU_GAL_PER_LB")]
        public double IBUGallonsPerPound { get; set; }
    }
}
