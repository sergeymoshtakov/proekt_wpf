using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;

namespace WpfApp1
{
    public class WeatherForecast
    {
        private const string myAPI = "716a2417b05f479ca6094104231107";

        public WeatherData GetWeatherData(string city)
        {
            string url = $"https://api.weatherapi.com/v1/forecast.json?key={myAPI}&q={city},UA&days=1";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();
                string json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(json);

                // Запись прогноза погоды в файл
                string forecastText = $"Прогноз погоды для города {city}:\n";
                forecastText += $"Температура: {weatherData.Current.Temp_c} °C\n";
                forecastText += $"Влажность: {weatherData.Current.Humidity}%\n";
                forecastText += $"Скорость ветра: {weatherData.Current.Wind_mph}\n";
                forecastText += $"Местное время: {weatherData.Location.Localtime}\n";
                forecastText += $"Состояние: {weatherData.Current.Condition.Text}\n";

                WriteForecastToFile(forecastText);

                return weatherData;
            }
        }

        private void WriteForecastToFile(string forecastText)
        {
            string filePath = "forecast.txt";

            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                writer.WriteLine(forecastText);
            }
        }
    }

    // Остальной код не изменился
    public class WeatherData
    {
        public CurrentWeather Current { get; set; }
        public CurrentWeather Location { get; set; }
    }

    public class CurrentWeather
    {
        public string Localtime { get; set; }
        public float Temp_c { get; set; }
        public float Wind_mph { get; set; }
        public int Humidity { get; set; }
        public Condition Condition { get; set; }
    }

    public class Condition
    {
        public string Text { get; set; }
        public string Icon { get; set; }
        public int Code { get; set; }
    }
}
