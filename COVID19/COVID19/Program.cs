using COVIDManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace COVID19
{
    class Program
    {
        static void Main(string[] args)
        {
            COVIDApi result = new COVIDApi();
           
            foreach (var counrys in result.GetGlodalStatistics())
            {
                Console.WriteLine($"Global:\t{counrys.NewConfirmedInWorld}");
            }

            Console.ReadKey();
        }
    }
}
