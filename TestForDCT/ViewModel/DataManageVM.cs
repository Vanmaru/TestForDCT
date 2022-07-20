using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestForDCT.Model;

namespace TestForDCT.ViewModel
{
    public class DataManageVM : INotifyPropertyChanged
    {
        private List<CryptoCurrency> top10Currencies = DataHandler.GetTop10Currencies();
        public List<CryptoCurrency> Top10Currencies
        {
            get => top10Currencies;
            set
            {
                top10Currencies = value;
                NotifyPropertyChanged(nameof(Top10Currencies));
            }
        }
        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
