using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCovid_19
{
    class Contagion
    {
        public int Id { get; set; }
        public int NewConfirmedInCountry { get; set; }
        public int TotalConfirmedInCountry { get; set; }
        public int NewDeathsInCountry { get; set; }
        public int TotalDeathsInCountry { get; set; }
        public DateTimeOffset Date { get; set; }
        public int? CityId { get; set; }
        public virtual City City { get; set; }
    }
}
