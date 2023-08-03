using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
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
using System.Diagnostics;
using Cryptocurrencies.APIActions;
using Cryptocurrencies.APIClasses;
using TestAPi.APIClasses;

namespace Cryptocurrencies.Pages
{
    /// <summary>
    /// Interaction logic for ShowDetail_SecondPage.xaml
    /// </summary>
    public partial class ShowDetail_SecondPage : Page
    {
        ObservableCollection<Cryptocurrency> cryptocurrencies = new ObservableCollection<Cryptocurrency>();
        ObservableCollection<ExchangeCoinGecko> exchanges = new ObservableCollection<ExchangeCoinGecko>();
        public ShowDetail_SecondPage()
        {
            InitializeComponent();
            GetCryptocurrency();
            GetExchange();
        }

        private async Task GetCryptocurrency(string name = "bitcoin")
        {
            cryptocurrencies = new ObservableCollection<Cryptocurrency>();
            cryptocurrencies = await ActionsOfData.Search(name);
            LVDetail.ItemsSource = cryptocurrencies;
        }

        private async Task GetExchange()
        {
            exchanges = new ObservableCollection<ExchangeCoinGecko>();
            int count = 0;
            if (!int.TryParse(CountInput.Text, out count))
            {
                MessageBox.Show("please input integer");
            }
            if (count < 0)
            {
                MessageBox.Show("integer must be more than 0");
            }
            exchanges = await ActionsOfData.GetDataCoinGecko<ExchangeCoinGecko>(GeneralConst.ExchangeCoinGeckoURL, count);
            LVExchanges.ItemsSource = exchanges;
            AddButton(ref GVinLVExchanges, exchanges);
        }
        private void AddButton(ref GridView gridView, ObservableCollection<ExchangeCoinGecko> this_exchanges)
        {
            /*
             * it's for add button to gridview
             */
            GridViewColumn buttonColumn = new GridViewColumn
            {
                Header = "Actions",
                Width = 50
            };

            FrameworkElementFactory buttonFactory = new FrameworkElementFactory(typeof(Button));
            buttonFactory.SetValue(Button.ContentProperty, "Click");
            buttonFactory.AddHandler(Button.ClickEvent, new RoutedEventHandler(Button_Click));

            DataTemplate buttonTemplate = new DataTemplate();
            buttonTemplate.VisualTree = buttonFactory;

            buttonColumn.CellTemplate = buttonTemplate;
            gridView.Columns.Add(buttonColumn);
        }


        //це для того щоб додати кнопку до GridView з певною подією.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Код обробки події кнопки
            Button button = (Button)sender;
            GridViewRowPresenter rowPresenter = FindVisualParent<GridViewRowPresenter>(button);
            if (rowPresenter != null)
            {
                ExchangeCoinGecko item = (ExchangeCoinGecko)rowPresenter.DataContext;
                Process.Start(new ProcessStartInfo(item.url) { UseShellExecute = true });
            }
        }
        private T FindVisualParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);
            if (parentObject == null)
                return null;
            if (parentObject is T parent)
                return parent;
            else
                return FindVisualParent<T>(parentObject);
        }

        private void bt_search_Click(object sender, RoutedEventArgs e)
        {
            string name = tb_forSearch.Text;
            GetCryptocurrency(name).Wait();
        }

        private void BT_count_Click(object sender, RoutedEventArgs e)
        {
            GetExchange().Wait();
        }
    }
}
