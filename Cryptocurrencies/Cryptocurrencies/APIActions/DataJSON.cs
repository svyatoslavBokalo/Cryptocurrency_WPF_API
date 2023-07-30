using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAPi
{
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
