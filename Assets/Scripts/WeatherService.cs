using Newtonsoft.Json;
using System;
using System.Net;

namespace Weather
{
    public class WeatherService
    {
        private readonly string _apiKey;
        private readonly string _apiUrl;

        public WeatherService(string apiKey, string apiUrl)
        {
            this._apiKey = apiKey;
            this._apiUrl = apiUrl;
        }

        public WeatherData GetWeatherData(string city)
        {
            try
            {
                using var webClient = new WebClient();
                var url = $"{_apiUrl}?q={city}&appid={_apiKey}&units=metric";
                var json = webClient.DownloadString(url);
                var data = JsonConvert.DeserializeObject<WeatherData>(json);
                return data;
            }
            catch (WebException ex)
            {
                // Обработка ошибок сети
                throw new Exception("Ошибка сети при получении данных о погоде", ex);
            }
            catch (JsonException ex)
            {
                // Обработка ошибок десериализации JSON
                throw new Exception("Ошибка десериализации данных о погоде", ex);
            }
        }
    }
}