namespace ReactApp1.Server.Models.ViewModels
{
    /// <summary>
    /// Temperature chart view model.
    /// </summary>
    public class TemperatureChartViewModel
    {
        /// <summary>
        /// Minimal temperature.
        /// </summary>
        public double MinimalTemperature { get; set; }

        /// <summary>
        /// Maximum temperature.
        /// </summary>
        public double MaximumTemperature { get; set; }

        /// <summary>
        /// Location information.
        /// </summary>
        public string? Location { get; set; }
    }
}
