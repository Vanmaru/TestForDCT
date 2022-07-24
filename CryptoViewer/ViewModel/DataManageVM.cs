using CryptoViewer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoViewer.ViewModel
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
        private List<CryptoCurrency> searchStory;
        public List<CryptoCurrency> SearchStory
        {
            get => searchStory;
            set
            {
                searchStory = value;
                NotifyPropertyChanged(nameof(searchStory));
            }
        }
        private CryptoCurrency selectedCurrency;
        public CryptoCurrency SelectedCurrency
        {
            get { return selectedCurrency; }
            set
            {
                selectedCurrency = value;
                NotifyPropertyChanged("SelectedPhone");
            }
        }
        public string CryptoName { get; set; }
        public string CryptoId { get; set; }
        public int CryptoRank { get; set; }
        public string CryptoSymbol { get; set; }
        public string CryptoExplorer { get; set; }
        public decimal CryptoChangePercent24Hr { get; set; }
        public decimal CryptoMarketCapUsd { get; set; }
        public decimal CryptoMaxSupply { get; set; }
        public decimal CryptoPriceUsd { get; set; }
        public decimal CryptoSupply { get; set; }
        public decimal CryptoVolumeUsd24Hr { get; set; }
        public decimal CryptoVwap24Hr { get; set; }
        //private RelayCommand findByName;
        //public RelayCommand FindByName
        //{
        //    get
        //    {
        //        return findByName ?? new RelayCommand(obj =>
        //        {
        //            Window wnd = obj as Window;
        //            CryptoCurrency resultStr = new();
        //            if (CryptoName == null || CryptoName.Replace(" ", "").Length == 0)
        //            {
        //                SetRedBlockControll(wnd, "NameBlock");
        //            }
        //            else
        //            {
        //                resultStr = DataHandler.GetByName(CryptoName);
        //                UpdateAllDataView();
        //                //ShowMessageToUser(resultStr);
        //                SetNullValuesToProperties();
        //                wnd.Close();
        //            }
        //        }
        //        );
        //    }
        //}
        #region Update Views
        private void SetNullValuesToProperties()
        {
            CryptoChangePercent24Hr = default;
            CryptoExplorer = default;
            CryptoId = default;
            CryptoMarketCapUsd = default;
            CryptoMaxSupply = default;
            CryptoName = default;
            CryptoPriceUsd = default;
            CryptoRank = default;
            CryptoSupply = default;
            CryptoSymbol = default;
            CryptoVolumeUsd24Hr = default;
            CryptoVwap24Hr = default;
        }
        private void UpdateAllDataView()
        {
            UpdateTop10CurrenciesView();
        }
        private void UpdateTop10CurrenciesView()
        {
            Top10Currencies = DataHandler.GetTop10Currencies();
            MainWindow.Top10CurrenciesView.ItemsSource = null;
            MainWindow.Top10CurrenciesView.Items.Clear();
            MainWindow.Top10CurrenciesView.ItemsSource = Top10Currencies;
            MainWindow.Top10CurrenciesView.Items.Refresh();
        }
        #endregion
        private void SetRedBlockControll(Window wnd, string v)
        {
            throw new NotImplementedException();
        }
        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = default)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
