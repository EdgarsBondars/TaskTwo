using System;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Scheduler
{
    /// <summary>
    /// Schedules weather data retreival and saving job.
    /// </summary>
    public class DataRetreiveScheduler
    {
        private HttpClient _httpClient;

        /// <summary>
        /// Schedules weather data retreival and saving job.
        /// </summary>
        public DataRetreiveScheduler()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Schedules weather data retreival and saving job.
        /// </summary>
        [FunctionName("DataRetreivalScheduler")]
        public void Run([TimerTrigger("0 * * * * * ")]TimerInfo myTimer, ILogger log)
        {
            // TODO: move to appsetting or move move URL to some static class.
            _httpClient.PostAsync("https://localhost:7121/Weather/FetchWeather", null);
        }
    }
}
