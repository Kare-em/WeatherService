using System;
using TMPro;
using UnityEngine;

namespace Weather
{
    public class WeatherView : MonoBehaviour
    {
        [SerializeField] private string _apiKey;
        [SerializeField] private string _apiUrl;
        [SerializeField] private string _city;
        
        [SerializeField] private TMP_Text _weather;
        [SerializeField] private TMP_Text _error;

        private void Start()
        {
            UpdateWeather();
        }

        private void UpdateWeather()
        {
            var service = new WeatherService(_apiKey,
                _apiUrl);

            try
            {
                var data = service.GetWeatherData(_city);
                _weather.text = $"Город: {_city}\n";
                _weather.text += $"Температура: {data.Main.Temp}°C\n";
                _weather.text += $"Ощущается как: {data.Main.FeelsLike}°C\n";
                _weather.text += $"Ветер: {data.Wind.Speed} м/c";
            }
            catch (Exception ex)
            {
                _error.text = $"Ошибка при получении данных о погоде: {ex.Message}";
            }
        }
    }
}