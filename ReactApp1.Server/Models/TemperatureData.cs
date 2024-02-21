using System.ComponentModel.DataAnnotations;

namespace ReactApp1.Server.Models
{
    /// <summary>
    /// Represents temperature data entity.
    /// </summary>
    public class TemperatureData
    {
        /// <summary>
        /// Temperature data id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Temperature.
        /// </summary>
        public double Temperature { get; set; }

        /// <summary>
        /// City id.
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// City data.
        /// </summary>
        public City City { get; set; }

        /// <summary>
        /// Date timestamp.
        /// </summary>
        public DateTime TimeStamp { get; set; } = DateTime.Now;
    }
}
