using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wild_Atlas.Models
{
    public class SearchResult
    {
        public string Name { get; set; }
        public string ScientificName { get; set; }
        public string ImageLink { get; set; }
        public double ProbabilitySearchValue { get; set; } // A voir plus tard si utile. 
    }
}
