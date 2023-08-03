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
using Cryptocurrencies.APIActions;
using Cryptocurrencies.APIClasses;

namespace Cryptocurrencies.APIActions
{
    static public class ActionsOfData
    {
        //for sorting data that depends on the type that we use
        static public ObservableCollection<T> Sorting<T>(ObservableCollection<T> lst, string nameOfProperty = "name")
        {
            PropertyInfo[] properties = typeof(T).GetProperties();

            PropertyInfo sortingProperty = properties.FirstOrDefault(p => p.Name == nameOfProperty);

            ObservableCollection<T> sortedList = new ObservableCollection<T>(
                lst.OrderBy(item => sortingProperty.GetValue(item)));
            return sortedList;
        }

        static public async Task<ObservableCollection<Cryptocurrency>> Search(string name = "bitcoin")
        {
            Task<DataJSON<Cryptocurrency>> data = APIClient<DataJSON<Cryptocurrency>>.GetGeneralAsync(GeneralConst.СryptocurrencyURL);
            if (data != null)
            {
                var info = await data;
                if (info != null && info.data != null)
                {
                    Cryptocurrency? searchItem = info.data.FirstOrDefault(el => el.name.ToLower() == name.ToLower());

                    ObservableCollection<Cryptocurrency> result = new ObservableCollection<Cryptocurrency>();
                    result.Add(searchItem);
                    return result;
                }
            }
            return null;
        }

        //this method for getting data 
        static public async Task<ObservableCollection<T>> GetDataFromCoinCap<T>(string url, int count = 10)
        {
            //Task<DataJSON<T>> data = APIClient<T>.GetGeneralCoinCapAsync(url);
            Task<DataJSON<T>> data = APIClient<DataJSON<T>>.GetGeneralAsync(url);
            if (data != null)
            {
                DataJSON<T> result = await data;
                if (result != null && result.data != null)
                {
                    ObservableCollection<T> items = new ObservableCollection<T>();

                    if (count > 0 && count <= result.data.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            items.Add(result.data[i]);
                        }
                    }
                    else
                    {
                        if (result.data.Count > 10)
                        {
                            for (int i = 0; i < 10; i++)
                            {
                                items.Add(result.data[i]);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < result.data.Count; i++)
                            {
                                items.Add(result.data[i]);
                            }
                        }
                    }

                    return items;
                }
            }

            return null;
        }

        static public async Task<ObservableCollection<T>> GetDataCoinGecko<T>(string url, int count = 10)
        {
            //Task<T[]>? data = APIClient<T>.GetGeneralCoinGeckoAsync(url);
            Task<T[]>? data = APIClient<T[]>.GetGeneralAsync(url);
            if (data != null)
            {
                var result = await data;
                if (result != null)
                {
                    ObservableCollection<T> items = new ObservableCollection<T>();

                    if (count > 0 && count < result.Count())
                    {
                        for (int i = 0; i < count; i++)
                        {
                            items.Add(result[i]);
                        }
                    }
                    else
                    {
                        if (result.Count() > 10)
                        {
                            for (int i = 0; i < 10; i++)
                            {
                                items.Add(result[i]);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < result.Count(); i++)
                            {
                                items.Add(result[i]);
                            }
                        }
                    }

                    return items;
                }
            }

            return null;
        }

        //this method to change list view depend on what is type will use
        static public void ChangeListView<T>(ref ListView lstView)
        {
            GridView gridView = new GridView();
            PropertyInfo[] mas = typeof(T).GetProperties();

            foreach(PropertyInfo el in mas)
            {
                gridView.Columns.Add(new GridViewColumn
                {
                    DisplayMemberBinding = new Binding(el.Name),
                    Header = el.Name,
                    Width = 100
                });
            }
            lstView.View = gridView;

        }
    }
}
