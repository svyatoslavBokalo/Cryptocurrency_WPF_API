using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAPi.APIClasses
{
    public class ExchangeInfo : INotifyPropertyChanged
    {
        private string _exchangeId;
        private string _name;
        private string _rank;
        private decimal _percentTotalVolume;
        private decimal _volumeUsd;
        private int _tradingPairs;
        private bool _socket;
        private string _exchangeUrl;
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

        public string name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(name));
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

        public decimal percentTotalVolume
        {
            get { return _percentTotalVolume; }
            set
            {
                if (_percentTotalVolume != value)
                {
                    _percentTotalVolume = value;
                    OnPropertyChanged(nameof(percentTotalVolume));
                }
            }
        }

        public decimal volumeUsd
        {
            get { return _volumeUsd; }
            set
            {
                if (_volumeUsd != value)
                {
                    _volumeUsd = value;
                    OnPropertyChanged(nameof(volumeUsd));
                }
            }
        }

        public int tradingPairs
        {
            get { return _tradingPairs; }
            set
            {
                if (_tradingPairs != value)
                {
                    _tradingPairs = value;
                    OnPropertyChanged(nameof(tradingPairs));
                }
            }
        }

        public bool socket
        {
            get { return _socket; }
            set
            {
                if (_socket != value)
                {
                    _socket = value;
                    OnPropertyChanged(nameof(socket));
                }
            }
        }

        public string exchangeUrl
        {
            get { return _exchangeUrl; }
            set
            {
                if (_exchangeUrl != value)
                {
                    _exchangeUrl = value;
                    OnPropertyChanged(nameof(exchangeUrl));
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

        public ExchangeInfo()
        {
            // Конструктор за замовчуванням
        }

        public ExchangeInfo(string exchangeId, string name, string rank, decimal percentTotalVolume, decimal volumeUsd, int tradingPairs, bool socket, string exchangeUrl, long updated)
        {
            this.exchangeId = exchangeId;
            this.name = name;
            this.rank = rank;
            this.percentTotalVolume = percentTotalVolume;
            this.volumeUsd = volumeUsd;
            this.tradingPairs = tradingPairs;
            this.socket = socket;
            this.exchangeUrl = exchangeUrl;
            this.updated = updated;
        }

        public override string ToString()
        {
            return $"ExchangeId: {exchangeId}\n" +
                   $"Name: {name}\n" +
                   $"Rank: {rank}\n" +
                   $"PercentTotalVolume: {percentTotalVolume}\n" +
                   $"VolumeUsd: {volumeUsd}\n" +
                   $"TradingPairs: {tradingPairs}\n" +
                   $"Socket: {socket}\n" +
                   $"ExchangeUrl: {exchangeUrl}\n" +
                   $"Updated: {updated}";
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
