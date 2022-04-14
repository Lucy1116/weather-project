using InterviewProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace InterviewProject.Services
{
	public class MetaWeatherService
	{

        public async Task<List<Location>> GetLocations(string city)
        {
            List<Location> locations = new List<Location>();

            if (!string.IsNullOrEmpty(city))
            {
                string url = String.Format("https://www.metaweather.com/api/location/search/?query={0}", city);

                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(url);
                    var apiResponse = await response.Content.ReadAsStringAsync();

                    locations = JsonConvert.DeserializeObject<List<Location>>(apiResponse);

                }
            }
            return locations;
        }

        public async Task<List<ConsolidatedWeather>> GetWeather(int woeid)
        {
            List<ConsolidatedWeather> weatherForecasts = new List<ConsolidatedWeather>();
            if (woeid > 0)
            {
                string url = String.Format("https://www.metaweather.com/api/location/{0}/", woeid);
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(url);
                    var apiResponse = await response.Content.ReadAsStringAsync();

                    WeatherInfo weaterInfo = JsonConvert.DeserializeObject<WeatherInfo>(apiResponse);
                    weatherForecasts = weaterInfo?.Consolidated_Weather;
                }
            }

            return weatherForecasts;
        }
    }
}
