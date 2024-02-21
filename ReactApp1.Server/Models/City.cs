using System.ComponentModel.DataAnnotations;

namespace ReactApp1.Server.Models
{
    /// <summary>
    /// Represents city data entity.
    /// </summary>
    public class City
    {
        /// <summary>
        /// City id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// City name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// City coordinates - latitude.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// City coordinates - longitude.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Foreign key - country id.
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// Foreign key - country id.
        /// </summary>
        public virtual Country Country { get; set; }
    }
}
