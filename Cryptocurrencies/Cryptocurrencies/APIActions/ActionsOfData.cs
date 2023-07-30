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
using TestAPi.APIClasses;

namespace TestAPi
{
    public class ActionsOfData
    {
        static public ObservableCollection<T> Sorting<T>(ObservableCollection<T> lst, string nameOfProperty = "name")
        {
            // Отримуємо масив PropertyInfo для типу T
            PropertyInfo[] properties = typeof(T).GetProperties();

            // Вибираємо властивість, за якою ми хочемо сортувати (наприклад, Name)
            PropertyInfo sortingProperty = properties.FirstOrDefault(p => p.Name == nameOfProperty);

            // Сортуємо lst за вибраною властивістю
            ObservableCollection<T> sortedList = new ObservableCollection<T>(
                lst.OrderBy(item => sortingProperty.GetValue(item)));
            return sortedList;
        }

        static public async Task<ObservableCollection<T>> GetData<T>(string url, int count = 10)
        {
            Task<DataJSON<T>> data = APIClient<T>.GetGeneralAsync(url);
            if (data != null)
            {
                var result = await data;
                if (result != null && result.data != null)
                {
                    ObservableCollection<T> items = new ObservableCollection<T>();

                    if (count > 0 && count < result.data.Count)
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

            // Додайте колонку з кнопкою
            GridViewColumn buttonColumn = new GridViewColumn
            {
                Header = "Actions",
                Width = 100
            };

            FrameworkElementFactory buttonFactory = new FrameworkElementFactory(typeof(Button));
            buttonFactory.SetValue(Button.ContentProperty, "Click");
            buttonFactory.AddHandler(Button.ClickEvent, new RoutedEventHandler(Button_Click));

            DataTemplate buttonTemplate = new DataTemplate();
            buttonTemplate.VisualTree = buttonFactory;

            buttonColumn.CellTemplate = buttonTemplate;
            gridView.Columns.Add(buttonColumn);

            lstView.View = gridView;

        }

        static private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Код обробки події кнопки
            // Ви можете отримати об'єкт, пов'язаний з рядком, використовуючи дані з елемента GridViewRowPresenter
            // Наприклад:
            Button button = (Button)sender;
            GridViewRowPresenter rowPresenter = FindVisualParent<GridViewRowPresenter>(button);
            if (rowPresenter != null)
            {
                Cryptocurrency item = (Cryptocurrency)rowPresenter.DataContext;
                // Виконайте потрібні дії з об'єктом Cryptocurrency
            }
        }

        private static T FindVisualParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);
            if (parentObject == null)
                return null;

            if (parentObject is T parent)
                return parent;
            else
                return FindVisualParent<T>(parentObject);
        }
    }
}
