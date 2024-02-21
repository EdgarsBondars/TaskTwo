using ReactApp1.Server.Models.ViewModels;

namespace ReactApp1.Server.Logic
{
    /// <summary>
    /// Weather related logic.
    /// </summary>
    public interface IWeatherLogic
    {
        /// <summary>
        /// Fetches weather data from a third-party service and saves it to database.
        /// </summary>
        Task FetchDataFromThirdPartyService();

        /// <summary>
        /// Gets weather data for all cities in database.
        /// </summary>
        /// <returns>A list of temperature chart view models representing city weather data.</returns>
        List<TemperatureChartViewModel> GetCityWeatherData();

        /// <summary>
        /// Gets weather data for all countries in database.
        /// </summary>
        /// <returns>A list of temperature chart view models representing country weather data.</returns>
        List<TemperatureChartViewModel> GetCountryWeatherData();
    }
}