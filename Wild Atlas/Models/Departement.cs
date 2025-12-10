using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wild_Atlas.Models
{
    public class Departement
    {
        public string Code { get; set; }
        public string Nom { get; set; }
        public string GadmId { get; set; }
        public override string ToString()
        => Nom;
    }
}
