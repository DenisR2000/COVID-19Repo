using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCovid_19
{
    class Recovered
    {
        public int Id { get; set; } 
        public int NewRecoveredInCountry { get; set; }
        public int TotalRecoveredInCountry { get; set; }
        public int? CityId { get; set; }
        public virtual City City { get; set; }
    }
}
