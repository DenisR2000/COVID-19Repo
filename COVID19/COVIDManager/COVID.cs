using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace COVIDManager
{
    public class COVID : INotifyPropertyChanged
    {
        public COVID()
        {

        }
        public COVID(string Country)
        {
            this.Country = Country;
        }
        public COVID(string Country, int NewConfirmedInCountry, int TotalConfirmedInCountry, 
                                                        int NewDeathsInCountry,
                                                        int TotalDeathsInCountry, 
                                                        int NewRecoveredInCountry, 
                                                        int TotalRecoveredInCountry, 
                                                        DateTimeOffset Date)
        {
            this.Country = Country;
            this.NewConfirmedInCountry = NewConfirmedInCountry;
            this.TotalConfirmedInCountry = TotalConfirmedInCountry;
            this.NewDeathsInCountry = NewDeathsInCountry;
            this.TotalDeathsInCountry = TotalDeathsInCountry;
            this.NewRecoveredInCountry = NewRecoveredInCountry;
            this.TotalRecoveredInCountry = TotalRecoveredInCountry;
            this.Date = Date;
        }

        private string country { get; set; }
        private int newConfirmedInCountry { get; set; }
        private int totalConfirmedInCountry { get; set; }
        private int newDeathsInCountry { get; set; }
        private int totalDeathsInCountry { get; set; }
        private int newRecoveredInCountry { get; set; }
        private int totalRecoveredInCountry { get; set; }
        private DateTimeOffset date { get; set; }
        public string Country 
        { get => country; 
            set
            {
                country = value;
                OnPropertyChanged();
            }
        }
        public int NewConfirmedInCountry
        { 
            get => newConfirmedInCountry;
            set
            {
                newConfirmedInCountry = value;
                OnPropertyChanged();
            }
        }
        public int TotalConfirmedInCountry 
        {
            get => totalConfirmedInCountry;
            set
            {
                totalConfirmedInCountry = value;
                OnPropertyChanged();
            }
        }
        public int NewDeathsInCountry
        {
            get => newDeathsInCountry;
            set
            {
                newDeathsInCountry = value;
                OnPropertyChanged();
            }
        }
        public int TotalDeathsInCountry { get => totalDeathsInCountry; set { totalDeathsInCountry = value; OnPropertyChanged(); } }
        public int NewRecoveredInCountry { get => newRecoveredInCountry; set { newRecoveredInCountry = value; OnPropertyChanged(); } }
        public int TotalRecoveredInCountry { get => totalRecoveredInCountry; set { totalRecoveredInCountry = value;OnPropertyChanged(); } }
        public DateTimeOffset Date { get => date; set { date = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
