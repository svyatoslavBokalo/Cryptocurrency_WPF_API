using System;
using System.ComponentModel;

namespace Cryptocurrencies.APIClasses
{
    public class History : INotifyPropertyChanged
    {
        private string _priceUsd;
        private long _time;
        private string _date;

        public event PropertyChangedEventHandler PropertyChanged;

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

        public long time
        {
            get { return _time; }
            set
            {
                if (_time != value)
                {
                    _time = value;
                    OnPropertyChanged(nameof(time));
                    UpdateDate();
                }
            }
        }

        public string date
        {
            get { return _date; }
            set
            {
                if (_date != value)
                {
                    _date = value;
                    OnPropertyChanged(nameof(date));
                }
            }
        }

        public History()
        {
            // Конструктор за замовчуванням
        }

        public History(string priceUsd, long time, string date)
        {
            this.priceUsd = priceUsd;
            this.time = time;
            this.date = date;
        }

        public override string ToString()
        {
            return $"PriceUsd: {priceUsd}\n" +
                   $"Time: {time}\n" +
                   $"Date: {date}";
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateDate()
        {
            var unixTime = DateTimeOffset.FromUnixTimeMilliseconds(time);
            date = unixTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
        }
    }
}
