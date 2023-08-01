using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrencies.APIActions
{
    // all url for API
    public class GeneralConst
    {
        static public string СryptocurrencyURL = "https://api.coincap.io/v2/assets";
        static public string СurrencyURL = "https://api.coincap.io/v2/rates";
        static public string ExchangeURL = "https://api.coincap.io/v2/assets/bitcoin/markets";
        static public string ExchangeDataURL = "https://api.coincap.io/v2/markets";
        static public string ExchangeInfoURL = "https://api.coincap.io/v2/exchanges";
        static public string HistoryURL = "https://api.coincap.io/v2/rates";
        static public string ExchangeCoinGeckoURL = "https://api.coingecko.com/api/v3/exchanges";
    }
}
