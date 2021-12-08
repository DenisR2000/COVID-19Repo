using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace COVIDManager
{
    public class TotalStatistics : INotifyPropertyChanged
    {
        public TotalStatistics()
        {

        }
        public TotalStatistics(int NewConfirmedInWorld, int TotalConfirmedInWorld, 
                                                int NewDeathsInWorld,
                                                int TotalDeathsInWorld,
                                                int NewRecoveredInWorld,
                                                int TotalRecoveredInWorld)
        {
            this.NewConfirmedInWorld = NewConfirmedInWorld;
            this.TotalConfirmedInWorld = TotalConfirmedInWorld;
            this.NewDeathsInWorld = NewDeathsInWorld;
            this.TotalDeathsInWorld = TotalDeathsInWorld;
            this.NewRecoveredInWorld = NewRecoveredInWorld;
            this.TotalRecoveredInWorld = TotalRecoveredInWorld;
        }
        public int NewConfirmedInWorld { get; set; }
        public int TotalConfirmedInWorld { get; set; }
        public int NewDeathsInWorld { get; set; }
        public int TotalDeathsInWorld { get; set; }
        public int NewRecoveredInWorld { get; set; }
        public int TotalRecoveredInWorld { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
