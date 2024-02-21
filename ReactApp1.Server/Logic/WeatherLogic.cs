using Newtonsoft.Json;
using ReactApp1.Server.Models;
using ReactApp1.Server.Models.External;
using ReactApp1.Server.Models.ViewModels;

namespace ReactApp1.Server.Logic
{
    /// <summary>
    /// Weather related logic.
    /// </summary>
    public class WeatherLogic : IWeatherLogic
    {
        private readonly MyDbContext _context;

        /// <summary>
        /// Weather related logic.
        /// </summary>
        /// <param name="context">The database context.</param>
        public WeatherLogic(MyDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Fetches weather data from a third-party service and saves it to database.
        /// </summary>
        public async Task FetchDataFromThirdPartyService()
        {
            var cities = _context.Cities.ToList();

            foreach (City city in cities)
            {
                var weatherData = await GetWeatherDataFromThirdParty(city);

                if (weatherData == null)
                {
                    continue;
                }

                _context.TemperatureData.Add(weatherData);
            }

            _context.SaveChanges();
        }

        /// <summary>
        /// Gets weather data for all cities in database.
        /// </summary>
        /// <returns>A list of temperature chart view models representing city weather data.</returns>
        public List<TemperatureChartViewModel> GetCityWeatherData()
        {
            var cities = _context.Cities.ToList();
            if (cities.Count == 0)
            {
                return new List<TemperatureChartViewModel>();
            }

            var cityWeathers = new List<TemperatureChartViewModel>();
            foreach (City city in cities)
            {
                cityWeathers.Add(new TemperatureChartViewModel()
                {
                    Location = city.Name,
                    MaximumTemperature = _context.TemperatureData.Where(c => c.CityId == city.Id).Max(x => x.Temperature),
                    MinimalTemperature = _context.TemperatureData.Where(c => c.CityId == city.Id).Min(x => x.Temperature)
                });
            }

            return cityWeathers;
        }

        /// <summary>
        /// Gets weather data for all countries in database.
        /// </summary>
        /// <returns>A list of temperature chart view models representing country weather data.</returns>
        public List<TemperatureChartViewModel> GetCountryWeatherData()
        {
            var countries = _context.Countries.ToList();
            var countryWeathers = new List<TemperatureChartViewModel>();

            foreach (Country country in countries)
            {
                var cityIds = _context.Cities.Where(c => c.CountryId == country.Id).Select(c => c.Id);

                countryWeathers.Add(new TemperatureChartViewModel()
                {
                    Location = country.Name,
                    MaximumTemperature = _context.TemperatureData
                        .Where(wdm => cityIds.Contains(wdm.CityId))
                            .Max(x => x.Temperature),
                    MinimalTemperature = _context.TemperatureData
                        .Where(wdm => cityIds.Contains(wdm.CityId))
                            .Min(x => x.Temperature)
                });
            }

            return countryWeathers;
        }

        /// <summary>
        /// Retrieves weather data from a third-party service for a specific city.
        /// </summary>
        /// <param name="city">The city for which to get weather data.</param>
        /// <returns>The temperature data for the specified city.</returns>
        private async Task<TemperatureData?> GetWeatherDataFromThirdParty(City city)
        {
            // TODO: move to appsetting or to some static class.
            string apiUrl = $"https://api.open-meteo.com/v1/forecast?latitude={city.Latitude}&longitude={city.Longitude}&current=temperature_2m";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var deserializedObject = JsonConvert.DeserializeObject<WeatherData>(jsonResponse);

                        if (deserializedObject == null)
                        {
                            return null;
                        }

                        return new TemperatureData()
                        {
                            City = city,
                            Temperature = deserializedObject.Current.Temperature_2m,
                        };
                    }
                    else
                    {
                        Console.WriteLine($"Failed to fetch data. Status code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    throw;
                }

                return null;
            }
        }
    }
}
