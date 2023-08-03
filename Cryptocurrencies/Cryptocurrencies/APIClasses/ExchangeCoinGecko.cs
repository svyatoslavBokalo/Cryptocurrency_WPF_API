using System;
using System.ComponentModel;

namespace TestAPi.APIClasses
{
    public class ExchangeCoinGecko : INotifyPropertyChanged
    {
        private string? _id;
        private string? _name;
        private int? _year_established;
        private string? _country;
        private string? _description;
        private string? _url;
        private string? _image;
        private bool? _has_trading_incentive;
        private int? _trust_score;
        private int? _trust_score_rank;
        private double? _trade_volume_24h_btc;
        private double? _trade_volume_24h_btc_normalized;

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

        public int? year_established
        {
            get { return _year_established; }
            set
            {
                if (_year_established != value)
                {
                    _year_established = value;
                    OnPropertyChanged(nameof(year_established));
                }
            }
        }

        public string country
        {
            get { return _country; }
            set
            {
                if (_country != value)
                {
                    _country = value;
                    OnPropertyChanged(nameof(country));
                }
            }
        }

        public string description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(nameof(description));
                }
            }
        }

        public string url
        {
            get { return _url; }
            set
            {
                if (_url != value)
                {
                    _url = value;
                    OnPropertyChanged(nameof(url));
                }
            }
        }

        public string image
        {
            get { return _image; }
            set
            {
                if (_image != value)
                {
                    _image = value;
                    OnPropertyChanged(nameof(image));
                }
            }
        }

        public bool? has_trading_incentive
        {
            get { return _has_trading_incentive; }
            set
            {
                if (_has_trading_incentive != value)
                {
                    _has_trading_incentive = value;
                    OnPropertyChanged(nameof(has_trading_incentive));
                }
            }
        }

        public int? trust_score
        {
            get { return _trust_score; }
            set
            {
                if (_trust_score != value)
                {
                    _trust_score = value;
                    OnPropertyChanged(nameof(trust_score));
                }
            }
        }

        public int? trust_score_rank
        {
            get { return _trust_score_rank; }
            set
            {
                if (_trust_score_rank != value)
                {
                    _trust_score_rank = value;
                    OnPropertyChanged(nameof(trust_score_rank));
                }
            }
        }

        public double? trade_volume_24h_btc
        {
            get { return _trade_volume_24h_btc; }
            set
            {
                if (_trade_volume_24h_btc != value)
                {
                    _trade_volume_24h_btc = value;
                    OnPropertyChanged(nameof(trade_volume_24h_btc));
                }
            }
        }

        public double? trade_volume_24h_btc_normalized
        {
            get { return _trade_volume_24h_btc_normalized; }
            set
            {
                if (_trade_volume_24h_btc_normalized != value)
                {
                    _trade_volume_24h_btc_normalized = value;
                    OnPropertyChanged(nameof(trade_volume_24h_btc_normalized));
                }
            }
        }

        public ExchangeCoinGecko()
        {
            // Default constructor
        }

        public ExchangeCoinGecko(string id, string name, int year_established, string country, string description,
            string url, string image, bool has_trading_incentive, int trust_score, int trust_score_rank,
            double trade_volume_24h_btc, double trade_volume_24h_btc_normalized)
        {
            this.id = id;
            this.name = name;
            this.year_established = year_established;
            this.country = country;
            this.description = description;
            this.url = url;
            this.image = image;
            this.has_trading_incentive = has_trading_incentive;
            this.trust_score = trust_score;
            this.trust_score_rank = trust_score_rank;
            this.trade_volume_24h_btc = trade_volume_24h_btc;
            this.trade_volume_24h_btc_normalized = trade_volume_24h_btc_normalized;
        }

        public override string ToString()
        {
            return $"Id: {id}\n" +
                   $"Name: {name}\n" +
                   $"Year Established: {year_established}\n" +
                   $"Country: {country}\n" +
                   $"Description: {description}\n" +
                   $"Url: {url}\n" +
                   $"Image: {image}\n" +
                   $"Has Trading Incentive: {has_trading_incentive}\n" +
                   $"Trust Score: {trust_score}\n" +
                   $"Trust Score Rank: {trust_score_rank}\n" +
                   $"Trade Volume 24h BTC: {trade_volume_24h_btc}\n" +
                   $"Trade Volume 24h BTC Normalized: {trade_volume_24h_btc_normalized}";
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
