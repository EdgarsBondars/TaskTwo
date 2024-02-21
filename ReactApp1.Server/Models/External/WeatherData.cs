namespace ReactApp1.Server.Models.External
{
    /// <summary>
    /// GENERATED: Used for mapping from external dto.
    /// </summary>
    public class WeatherData
    {
        public int Id { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int CurrentDataId { get; set; }

        public CurrentData Current { get; set; }

        public City City { get; set; }
    }
}
