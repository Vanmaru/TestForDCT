using CryptoViewer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using DataVis = System.Windows.Forms.DataVisualization;

namespace CryptoViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ListBox Top10CurrenciesView;
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new DataManageVM();
            Top10CurrenciesView = ViewTop10Currencies;
            List<string> styles = new List<string>() { "Light", "Dark" };
            styleBox.SelectionChanged += ThemeChange;
            styleBox.ItemsSource = styles;
            styleBox.SelectedItem = "Dark";
        }
        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            string style = styleBox.SelectedItem as string;
            // define the path to the resource file
            Uri uri = new Uri($"Themes\\{style}.xaml", UriKind.Relative);
            //  load resource dictionary
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            // clear the collection of application resources
            Application.Current.Resources.Clear();
            // add the loaded resource dictionary
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
    }
}
