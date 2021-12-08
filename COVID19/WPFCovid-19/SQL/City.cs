using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCovid_19
{
    class City
    {
        public City(string CityName)
        {
            this.CityName = CityName;
        }
        public City()
        {
            Contagion = new HashSet<Contagion>();
            Recovered = new HashSet<Recovered>();
        }
        public int CityId { get; set; }
        [MaxLength(80)]
        public string CityName { get; set; }

        public virtual ICollection<Contagion> Contagion { get; set; }
        public virtual ICollection<Recovered> Recovered { get; set; }
    }
}
