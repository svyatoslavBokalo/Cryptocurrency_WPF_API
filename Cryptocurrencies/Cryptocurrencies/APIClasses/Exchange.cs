using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAPi.APIClasses
{
    public class Exchange : INotifyPropertyChanged
    {
        private string _exchangeId;
        private string _baseId;
        private string _quoteId;
        private string _baseSymbol;
        private string _quoteSymbol;
        private string _volumeUsd24Hr;
        private string _priceUsd;
        private string _volumePercent;

        public event PropertyChangedEventHandler PropertyChanged;

        public string exchangeId
        {
            get { return _exchangeId; }
            set
            {
                if (_exchangeId != value)
                {
                    _exchangeId = value;
                    OnPropertyChanged(nameof(exchangeId));
                }
            }
        }

        public string baseId
        {
            get { return _baseId; }
            set
            {
                if (_baseId != value)
                {
                    _baseId = value;
                    OnPropertyChanged(nameof(baseId));
                }
            }
        }

        public string quoteId
        {
            get { return _quoteId; }
            set
            {
                if (_quoteId != value)
                {
                    _quoteId = value;
                    OnPropertyChanged(nameof(quoteId));
                }
            }
        }

        public string baseSymbol
        {
            get { return _baseSymbol; }
            set
            {
                if (_baseSymbol != value)
                {
                    _baseSymbol = value;
                    OnPropertyChanged(nameof(baseSymbol));
                }
            }
        }

        public string quoteSymbol
        {
            get { return _quoteSymbol; }
            set
            {
                if (_quoteSymbol != value)
                {
                    _quoteSymbol = value;
                    OnPropertyChanged(nameof(quoteSymbol));
                }
            }
        }

        public string volumeUsd24Hr
        {
            get { return _volumeUsd24Hr; }
            set
            {
                if (_volumeUsd24Hr != value)
                {
                    _volumeUsd24Hr = value;
                    OnPropertyChanged(nameof(volumeUsd24Hr));
                }
            }
        }

        public string priceUsd
        {
            get { return _priceUsd; }
            set
            {
                if (_priceUsd != value)
                {
                    _priceUsd = value;
                    OnPropertyChanged(nameof(priceUsd));
                }
            }
        }

        public string volumePercent
        {
            get { return _volumePercent; }
            set
            {
                if (_volumePercent != value)
                {
                    _volumePercent = value;
                    OnPropertyChanged(nameof(volumePercent));
                }
            }
        }

        public Exchange()
        {
            // Конструктор за замовчуванням
        }

        public Exchange(string exchangeId, string baseId, string quoteId, string baseSymbol, string quoteSymbol, string volumeUsd24Hr, string priceUsd, string volumePercent)
        {
            this.exchangeId = exchangeId;
            this.baseId = baseId;
            this.quoteId = quoteId;
            this.baseSymbol = baseSymbol;
            this.quoteSymbol = quoteSymbol;
            this.volumeUsd24Hr = volumeUsd24Hr;
            this.priceUsd = priceUsd;
            this.volumePercent = volumePercent;
        }

        public override string ToString()
        {
            return $"ExchangeId: {exchangeId}\n" +
                   $"BaseId: {baseId}\n" +
                   $"QuoteId: {quoteId}\n" +
                   $"BaseSymbol: {baseSymbol}\n" +
                   $"QuoteSymbol: {quoteSymbol}\n" +
                   $"VolumeUsd24Hr: {volumeUsd24Hr}\n" +
                   $"PriceUsd: {priceUsd}\n" +
                   $"VolumePercent: {volumePercent}";
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
