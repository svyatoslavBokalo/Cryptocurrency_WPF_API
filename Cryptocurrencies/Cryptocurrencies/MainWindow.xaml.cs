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

namespace Cryptocurrencies
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NavigateToHomePage();
        }

        private void NavigateToHomePage()
        {
            MainContentFrame.Navigate(new Uri("Pages/HomePage.xaml", UriKind.Relative));
        }

        private void NavigateToSecondPage_DetailInfo()
        {
            MainContentFrame.Navigate(new Uri("Pages/ShowDetail_SecondPage.xaml", UriKind.Relative));
        }

        private void bt_1_Click(object sender, RoutedEventArgs e)
        {
            NavigateToHomePage();
        }

        private void bt_2_Click(object sender, RoutedEventArgs e)
        {
            NavigateToSecondPage_DetailInfo();
        }
    }
}
