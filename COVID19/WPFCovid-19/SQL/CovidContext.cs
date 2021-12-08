using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCovid_19
{
    class CovidContext :DbContext
    {
        public CovidContext() : base("name=CovidStat")
        {

        }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Contagion> Contagion { get; set; }
        public virtual DbSet<Recovered> Recovered { get; set; }
    }
}
