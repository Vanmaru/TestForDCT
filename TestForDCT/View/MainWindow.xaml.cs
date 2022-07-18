using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestForDCT.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<string> styles = new List<string> { "Light", "Dark" };
            styleBox.SelectionChanged += ThemeChange;
            styleBox.ItemsSource = styles;
            styleBox.SelectedItem = "Dark";
        }
        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            string style = styleBox.SelectedItem as string;
            // define the path to the resource file
            Uri uri = new($"Themes\\{style}.xaml", UriKind.Relative);
            //  load resource dictionary
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            // clear the collection of application resources
            Application.Current.Resources.Clear();
            // add the loaded resource dictionary
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
    }
}