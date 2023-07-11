using System;
using System.Windows;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private WeatherForecast weatherForecast;
        private WeatherForecastVM weatherForecastVM;

        public MainWindow()
        {
            InitializeComponent();
            weatherForecast = new WeatherForecast();
            weatherForecastVM = (WeatherForecastVM)DataContext;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string city = weatherForecastVM.CityName;
            WeatherData weatherData = weatherForecast.GetWeatherData(city);

            // Обновление свойств ViewModel с полученными данными о погоде
            weatherForecastVM.Temperature = weatherData.Current.Temp_c.ToString();
            weatherForecastVM.Humidity = weatherData.Current.Humidity.ToString();
            weatherForecastVM.WindMph = weatherData.Current.Wind_mph.ToString();
            weatherForecastVM.LocalTime = weatherData.Location.Localtime;
            weatherForecastVM.Condition = weatherData.Current.Condition.Text;

            // Обновление текста прогноза погоды во ViewModel
            string forecastText = $"Прогноз погоды для города {city}:";
            weatherForecastVM.UpdateForecastText(forecastText);
        }
    }
}