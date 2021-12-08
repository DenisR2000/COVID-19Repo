using COVIDManager;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPFCovid_19
{
    public class ViewModelCOVID19 : INotifyPropertyChanged
    {

        public ViewModelCOVID19()
        {
            COVIDApi api = new COVIDApi();
            ShowVodeo = "Visible";
            //using (CovidContext db = new CovidContext())
            //{
            //    List<City> cityes = GetCiyes();
            //    db.City.AddRange(cityes);
            //    db.SaveChanges();
            //}
            //MessageBox.Show("Save");
        }
        private DelegateCommand sortByTotalConfirmedInCountry;
        public DelegateCommand SortByTotalConfirmedInCountry
        {
            get
            {
                return sortByTotalConfirmedInCountry ?? (sortByTotalConfirmedInCountry = new DelegateCommand(obj =>
                {
                    GetInfo();
                    int a, b;
                    Task.Factory.StartNew(() =>
                    {
                        if (GridTotalConfirmd != null)
                        {
                            for (int i = 0; i < GridTotalConfirmd.Count; i++)
                            {
                                for (int j = 0; j < GridTotalConfirmd.Count; j++)
                                {
                                    if (!int.TryParse(GridTotalConfirmd[i].TotalConfirmedInCountry.ToString(), out a))
                                        continue;
                                    if (!int.TryParse(GridTotalConfirmd[j].TotalConfirmedInCountry.ToString(), out b))
                                        continue;
                                    if (a < b)
                                        (GridTotalConfirmd[i], GridTotalConfirmd[j]) = (GridTotalConfirmd[j], GridTotalConfirmd[i]);
                                }
                            }
                        }
                        else { MessageBox.Show("Click button Confirmed"); }
                    });
                }));
            }
        }

        private List<COVID> GetInfo()
        {
            NetvorkManager netvorkManager = new NetvorkManager();

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

        private List<COVID> gridTotalConfirmd;
        public List<COVID> GridTotalConfirmd
        {
            get => gridTotalConfirmd;
            set
            {
                gridTotalConfirmd = value;
                OnPropertyChanged();
            }
        }
        private List<COVID> gridStatisticsInCountry;
        public List<COVID> GridStatisticsInCountry
        {
            get => gridStatisticsInCountry;
            set
            {
                gridStatisticsInCountry = value;
                OnPropertyChanged();
            }
        }

        private DelegateCommand itemSelectionChanged;
        public DelegateCommand ItemSelectionChanged
        {
            get
            {
                return itemSelectionChanged ?? (itemSelectionChanged = new DelegateCommand(obj =>
                {
                    OnItemSelectionChanged(obj);
                }));
            }
        }
        private DelegateCommand doubleClic;
        public DelegateCommand DoubleClic
        {
            get
            {
                return doubleClic ?? (doubleClic = new DelegateCommand(obj =>
                {
                    OnDoubleClickChanged(obj);
                }));
            }
        }
        private void OnDoubleClickChanged(object obj)
        {

            if (obj is COVID _obj)
            {
                var ItemName = _obj.NewConfirmedInCountry;
                using (FileStream fs = new FileStream("Statistics.txt", FileMode.Create, FileAccess.Write))
                {
                    using (var sw = new StreamWriter(fs, Encoding.Default))
                    {
                        sw.WriteLine($"{_obj.Country}\n{_obj.TotalConfirmedInCountry}\n{_obj.NewConfirmedInCountry}");
                    }
                    MessageBox.Show("Highlighted row has been saved to file.");
                    fs.Close();
                }
            }
        }

        private void OnItemSelectionChanged(object obj)
        {

            if (obj is COVID _obj)
            {
                var ItemName = _obj.Country;
                MessageBox.Show(ItemName.ToString());
            }
        }
        //Visible
        private string showVideo;
        public string ShowVodeo
        {
            get => showVideo;
            set
            {
                showVideo = value;     
                OnPropertyChanged();
            }
        }

        private DelegateCommand showStatisticsInSityes;

        public DelegateCommand ShowStatisticsCommand
        {
            get
            {
                return showStatisticsInSityes ?? (showStatisticsInSityes = new DelegateCommand(obj =>
                {
                    Task.Factory.StartNew(() => 
                    {
                        ShowVodeo = "Hidden";
                        GridStatisticsInCountry = GetInfo();
                    });
                   
                }));
            }
        }

        private DelegateCommand showStatisticsConformdCommand;
        public DelegateCommand ShowStatisticsConformdCommand
        {
            get
            {
                return showStatisticsConformdCommand ?? (showStatisticsConformdCommand = new DelegateCommand(obj => 
                {

                    List<COVID> statistics = new List<COVID>();
                    statistics.Clear();
                    COVIDApi covidapi = new COVIDApi();
                    Task.Factory.StartNew(() => 
                    {
                        foreach (COVID covid in covidapi.GetCitysStatistics())
                        {
                            statistics.Add(new COVID(covid.Country, covid.NewConfirmedInCountry, covid.TotalConfirmedInCountry, covid.NewDeathsInCountry, covid.TotalDeathsInCountry, covid.NewRecoveredInCountry, covid.TotalRecoveredInCountry, covid.Date));
                        }
                    });
                    GridTotalConfirmd = statistics;
                }));
            }
        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
