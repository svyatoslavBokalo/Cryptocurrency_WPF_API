using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrencies.APIActions
{
    //class which we use for getting data from API
    internal class DataJSON<T>
    {
        
        public List<T> data { get; set; }
        public decimal timestamp { get; set; }

        public override string? ToString()
        {
            string res = "";
            foreach(T el in data)
            {
                res += el.ToString() + "\n";
            }
            return res;
        }
    }
}
