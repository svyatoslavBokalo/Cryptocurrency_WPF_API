using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAPi.APIClasses
{
    public class Currency : INotifyPropertyChanged
    {
        private string _id;
        private string _symbol;
        private string _currencySymbol;
        private string _type;
        private string _rateUsd;

        public event PropertyChangedEventHandler PropertyChanged;

        public string id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(id));
                }
            }
        }

        public string symbol
        {
            get { return _symbol; }
            set
            {
                if (_symbol != value)
                {
                    _symbol = value;
                    OnPropertyChanged(nameof(symbol));
                }
            }
        }

        public string currencySymbol
        {
            get { return _currencySymbol; }
            set
            {
                if (_currencySymbol != value)
                {
                    _currencySymbol = value;
                    OnPropertyChanged(nameof(currencySymbol));
                }
            }
        }

        public string type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    OnPropertyChanged(nameof(type));
                }
            }
        }

        public string rateUsd
        {
            get { return _rateUsd; }
            set
            {
                if (_rateUsd != value)
                {
                    _rateUsd = value;
                    OnPropertyChanged(nameof(rateUsd));
                }
            }
        }

        public Currency()
        {
            // Конструктор за замовчуванням
        }

        public Currency(string id, string symbol, string currencySymbol, string type, string rateUsd)
        {
            this.id = id;
            this.symbol = symbol;
            this.currencySymbol = currencySymbol;
            this.type = type;
            this.rateUsd = rateUsd;
        }

        public override string ToString()
        {
            return $"Id: {id}\n" +
                   $"Symbol: {symbol}\n" +
                   $"CurrencySymbol: {currencySymbol}\n" +
                   $"Type: {type}\n" +
                   $"RateUsd: {rateUsd}";
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
