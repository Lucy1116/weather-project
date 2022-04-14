using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InterviewProject.Models;
using InterviewProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InterviewProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherLocationController : ControllerBase
    {
        private readonly ILogger<WeatherLocationController> _logger;

        public WeatherLocationController(ILogger<WeatherLocationController> logger)
        {
            _logger = logger;
        }

        [Route("location-search/{city}")]
        [HttpGet]
        public async Task<List<Location>> GetLocations(string city)
        {
            List<Location> locations = new List<Location>();
            MetaWeatherService metaService = new MetaWeatherService();
            try
            {
                locations = await metaService.GetLocations(city);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
            };

            return locations;
        }

        [Route("location-weather/{woeid:int}")]
        [HttpGet]
        public async Task<List<ConsolidatedWeather>> GetWeather(int woeid)
        {
            List<ConsolidatedWeather> weatherForecasts = new List<ConsolidatedWeather>();
            MetaWeatherService metaService = new MetaWeatherService();
            try
            {
                weatherForecasts = await metaService.GetWeather(woeid);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
            };

            return weatherForecasts;
        }
    }
}
