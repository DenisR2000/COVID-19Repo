using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;

namespace COVIDManager
{
    public class COVIDApi
    {
        NetvorkManager netvorkManager;
        public COVIDApi()
        {
            netvorkManager = new NetvorkManager();
        }

        public List<COVID> GetStatistics()
        {
            string url = "https://api.covid19api.com/summary";

            List<COVID> statistics = new List<COVID>();

            string json = netvorkManager.GetJson(url);

            JObject covidSearch = JObject.Parse(json);

            List<JToken> resultsInCountry = covidSearch["Countries"].Children().ToList();
            List<JToken> resultsGlob = covidSearch.Children().ToList();
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
