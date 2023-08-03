using Cryptocurrencies.APIActions;
using Cryptocurrencies.APIClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Cryptocurrencies.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private ObservableCollection<Cryptocurrency>? crypto;
        public ObservableCollection<Cryptocurrency> Crypto
        {
            get { return crypto; }
            set { crypto = value; }
        }

        public HomePage()
        {
            InitializeComponent();
            Crypto = new ObservableCollection<Cryptocurrency>();
            Run();
        }

        private async void Run(int count = 10)
        {
            Crypto = new ObservableCollection<Cryptocurrency>();
            Crypto = await ActionsOfData.GetDataFromCoinCap<Cryptocurrency>(GeneralConst.СryptocurrencyURL, count);
            LVCryptocurrency.ItemsSource = Crypto;
        }

        private void BT_count_Click_1(object sender, RoutedEventArgs e)
        {
            int count = 0;
            if (!int.TryParse(CountInput.Text, out count))
            {
                MessageBox.Show("input an integer between 1 and 100");
            }

            Run(count);
        }
    }
}
