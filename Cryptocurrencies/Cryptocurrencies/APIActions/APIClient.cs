using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace TestAPi
{
    internal class APIClient<T>
    {
        static HttpClient client = new HttpClient();
        static private string? responseBody;

        static public async Task<DataJSON<T>> GetGeneralAsync(string path = "https://api.coincap.io/v2/assets")
        {
            DataJSON<T>? data = null;
            //Uri siteUri = new Uri("https://api.coincap.io/v2/assets");
            HttpResponseMessage? response = null;
            try
            {
                response = await client.GetAsync(path);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Помилка при виконанні запиту: {ex.Message}");
                MessageBox.Show($"Стек виклику: {ex.StackTrace}");
            }

            if(response == null)
            {
                throw new ArgumentNullException($"responce is null");
            }
            if (response.IsSuccessStatusCode)
            {
                responseBody = await response.Content.ReadAsStringAsync();
                data = JsonSerializer.Deserialize<DataJSON<T>>(responseBody);
            }
            if (data == null)
            {
                throw new ArgumentNullException($"DataJSON<{typeof(T)}> data is null");
            }
            return data;
        }

        
    }
}
