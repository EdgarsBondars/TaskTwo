using Microsoft.AspNetCore.Mvc;
using ReactApp1.Server.Logic;
using ReactApp1.Server.Models.ViewModels;

namespace ReactApp1.Server.Controllers
{
    /// <summary>
    /// Controller for handling weather-related operations.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherLogic _weatherLogic;

        /// <summary>
        /// Controller for handling weather-related operations.
        /// </summary>
        /// <param name="weatherLogic">The weather logic service.</param>
        public WeatherController(IWeatherLogic weatherLogic)
        {
            _weatherLogic = weatherLogic;
        }

        /// <summary>
        /// Endpoint for fetching weather data from a third-party service.
        /// </summary>
        [HttpPost("FetchWeather")]
        public async Task FetchWeather()
        {
            await _weatherLogic.FetchDataFromThirdPartyService();
        }

        /// <summary>
        /// Endpoint for retrieving weather data for cities.
        /// </summary>
        /// <returns>A list of temperature chart view models representing city weather data.</returns>
        [HttpGet("GetCityWeatherData")]
        public List<TemperatureChartViewModel> GetCityWeatherData()
        {
            return _weatherLogic.GetCityWeatherData();
        }

        /// <summary>
        /// Endpoint for retrieving weather data for countries.
        /// </summary>
        /// <returns>A list of temperature chart view models representing country weather data.</returns>
        [HttpGet("GetCountryWeatherData")]
        public List<TemperatureChartViewModel> GetCountryWeatherData()
        {
            return _weatherLogic.GetCountryWeatherData();
        }
    }
}
