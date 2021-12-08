using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace COVIDManager
{
    public class COVIDApi
    {
        NetvorkManager netvorkManager;
        public COVIDApi()
        {
            netvorkManager = new NetvorkManager();
        }
        public List<TotalStatistics>GetGlodalStatistics()
        {
            string url = "https://api.covid19api.com/summary";

            List<TotalStatistics> totalstat = new List<TotalStatistics>();
            try
            {
                string json = netvorkManager.GetJson(url);

                JObject covidSearch = JObject.Parse(json);

                List<JToken> resultsInCountry = covidSearch["Global"].Children().ToList();

                foreach (JToken result in resultsInCountry)
                {
                    totalstat.Add(new TotalStatistics
                    {
                        NewConfirmedInWorld = Convert.ToInt32(result["NewConfirmed"])
                    });
                }
            }
            catch(Exception ex) {  }
            
            return totalstat;
        }


        public List<COVID> GetCitysStatistics()
        {
            string url = "https://api.covid19api.com/summary";

            List<COVID> statistics = new List<COVID>();

            string json = netvorkManager.GetJson(url);

            JObject covidSearch = JObject.Parse(json);

            List<JToken> resultsInCountry = covidSearch["Countries"].Children().ToList();
            
            foreach (JToken result in resultsInCountry)
            {
                statistics.Add(new COVID
                {
                    Country = result["Country"].ToString(),
                    NewConfirmedInCountry = Convert.ToInt32(result["NewConfirmed"]),
                    TotalConfirmedInCountry = Convert.ToInt32(result["TotalConfirmed"]),
                    NewDeathsInCountry = Convert.ToInt32(result["NewDeaths"]),
                    TotalDeathsInCountry = Convert.ToInt32(result["TotalDeaths"]),
                    NewRecoveredInCountry = Convert.ToInt32(result["NewRecovered"]),
                    TotalRecoveredInCountry = Convert.ToInt32(result["TotalRecovered"]),
                    Date = Convert.ToDateTime(result["Date"])
                });
            }
            return statistics;
        }
      
    }
}
