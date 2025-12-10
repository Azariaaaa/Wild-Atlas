using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wild_Atlas.Models
{
    public class SpeciesCheckResultModel
    {
        public Dictionary<int,int> YearObservations { get; set; }
        public string Trend { get; set; }
    }
}
