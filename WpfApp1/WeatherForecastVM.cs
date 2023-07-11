using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp1
{
    public class WeatherForecastVM : INotifyPropertyChanged
    {
        private string cityName;
        public string CityName
        {
            get { return cityName; }
            set
            {
                if (cityName != value)
                {
                    cityName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string temperature;
        public string Temperature
        {
            get { return temperature; }
            set
            {
                if (temperature != value)
                {
                    temperature = value;
                    OnPropertyChanged();
                }
            }
        }

        private string humidity;
        public string Humidity
        {
            get { return humidity; }
            set
            {
                if (humidity != value)
                {
                    humidity = value;
                    OnPropertyChanged();
                }
            }
        }

        private string condition;
        public string Condition
        {
            get { return condition; }
            set
            {
                if (condition != value)
                {
                    condition = value;
                    OnPropertyChanged();
                }
            }
        }

        private string forecastText;
        public string ForecastText
        {
            get { return forecastText; }
            set
            {
                if (forecastText != value)
                {
                    forecastText = value;
                    OnPropertyChanged();
                }
            }
        }

        private string windMph;
        public string WindMph
        {
            get { return windMph; }
            set
            {
                if (windMph != value)
                {
                    windMph = value;
                    OnPropertyChanged();
                }
            }
        }

        private string localTime;
        public string LocalTime
        {
            get { return localTime; }
            set
            {
                if (localTime != value)
                {
                    localTime = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void UpdateForecastText(string text)
        {
            ForecastText = text;
        }
    }
}