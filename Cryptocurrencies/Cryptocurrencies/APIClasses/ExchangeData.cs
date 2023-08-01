using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrencies.APIClasses
{
    public class ExchangeData : INotifyPropertyChanged
    {
        private string _exchangeId;
        private string _rank;
        private string _baseSymbol;
        private string _baseId;
        private string _quoteSymbol;
        private string _quoteId;
        private string _priceQuote;
        private string _priceUsd;
        private string _volumeUsd24Hr;
        private string _percentExchangeVolume;
        private string _tradesCount24Hr;
        private long _updated;

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

        public string rank
        {
            get { return _rank; }
            set
            {
                if (_rank != value)
                {
                    _rank = value;
                    OnPropertyChanged(nameof(rank));
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

        public string priceQuote
        {
            get { return _priceQuote; }
            set
            {
                if (_priceQuote != value)
                {
                    _priceQuote = value;
                    OnPropertyChanged(nameof(priceQuote));
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

        public string percentExchangeVolume
        {
            get { return _percentExchangeVolume; }
            set
            {
                if (_percentExchangeVolume != value)
                {
                    _percentExchangeVolume = value;
                    OnPropertyChanged(nameof(percentExchangeVolume));
                }
            }
        }

        public string tradesCount24Hr
        {
            get { return _tradesCount24Hr; }
            set
            {
                if (_tradesCount24Hr != value)
                {
                    _tradesCount24Hr = value;
                    OnPropertyChanged(nameof(tradesCount24Hr));
                }
            }
        }

        public long updated
        {
            get { return _updated; }
            set
            {
                if (_updated != value)
                {
                    _updated = value;
                    OnPropertyChanged(nameof(updated));
                }
            }
        }

        public ExchangeData()
        {
            // Конструктор за замовчуванням
        }

        public ExchangeData(string exchangeId, string rank, string baseSymbol, string baseId, string quoteSymbol, string quoteId, string priceQuote, string priceUsd, string volumeUsd24Hr, string percentExchangeVolume, string tradesCount24Hr, long updated)
        {
            this.exchangeId = exchangeId;
            this.rank = rank;
            this.baseSymbol = baseSymbol;
            this.baseId = baseId;
            this.quoteSymbol = quoteSymbol;
            this.quoteId = quoteId;
            this.priceQuote = priceQuote;
            this.priceUsd = priceUsd;
            this.volumeUsd24Hr = volumeUsd24Hr;
            this.percentExchangeVolume = percentExchangeVolume;
            this.tradesCount24Hr = tradesCount24Hr;
            this.updated = updated;
        }

        public override string ToString()
        {
            return $"ExchangeId: {exchangeId}\n" +
                   $"Rank: {rank}\n" +
                   $"BaseSymbol: {baseSymbol}\n" +
                   $"BaseId: {baseId}\n" +
                   $"QuoteSymbol: {quoteSymbol}\n" +
                   $"QuoteId: {quoteId}\n" +
                   $"PriceQuote: {priceQuote}\n" +
                   $"PriceUsd: {priceUsd}\n" +
                   $"VolumeUsd24Hr: {volumeUsd24Hr}\n" +
                   $"PercentExchangeVolume: {percentExchangeVolume}\n" +
                   $"TradesCount24Hr: {tradesCount24Hr}\n" +
                   $"Updated: {updated}";
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
