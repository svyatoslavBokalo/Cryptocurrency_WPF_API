using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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

namespace Cryptocurrencies.APIActions
{
    public class ActionsOfData
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


        //this method for getting data 
        static public async Task<ObservableCollection<T>> GetDataFromCoinCap<T>(string url, int count = 10)
        {
            Task<DataJSON<T>> data = APIClient<T>.GetGeneralCoinCapAsync(url);
            if (data != null)
            {
                var result = await data;
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
            Task<T[]>? data = APIClient<T>.GetGeneralCoinGeckoAsync(url);
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
            /*
             * it's for add button to gridview
             */
            //GridViewColumn buttonColumn = new GridViewColumn
            //{
            //    Header = "Actions",
            //    Width = 100
            //};

            //FrameworkElementFactory buttonFactory = new FrameworkElementFactory(typeof(Button));
            //buttonFactory.SetValue(Button.ContentProperty, "Click");
            //buttonFactory.AddHandler(Button.ClickEvent, new RoutedEventHandler(Button_Click));

            //DataTemplate buttonTemplate = new DataTemplate();
            //buttonTemplate.VisualTree = buttonFactory;

            //buttonColumn.CellTemplate = buttonTemplate;
            //gridView.Columns.Add(buttonColumn);

            lstView.View = gridView;

        }
        // це для того щоб додати кнопку до GridView з певною подією.

        //static private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    // Код обробки події кнопки
        //    // Ви можете отримати об'єкт, пов'язаний з рядком, використовуючи дані з елемента GridViewRowPresenter
        //    // Наприклад:
        //    Button button = (Button)sender;
        //    GridViewRowPresenter rowPresenter = FindVisualParent<GridViewRowPresenter>(button);
        //    if (rowPresenter != null)
        //    {
        //        Cryptocurrency item = (Cryptocurrency)rowPresenter.DataContext;
        //        // Виконайте потрібні дії з об'єктом Cryptocurrency
        //    }
        //}

        //private static T FindVisualParent<T>(DependencyObject child) where T : DependencyObject
        //{
        //    DependencyObject parentObject = VisualTreeHelper.GetParent(child);
        //    if (parentObject == null)
        //        return null;

        //    if (parentObject is T parent)
        //        return parent;
        //    else
        //        return FindVisualParent<T>(parentObject);
        //}
    }
}
