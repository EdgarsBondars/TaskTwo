using System.ComponentModel.DataAnnotations;

namespace ReactApp1.Server.Models
{
    /// <summary>
    /// Represents country data entity.
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Country id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Country name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Foreign key cities collection.
        /// </summary>
        public ICollection<City> Cities { get; set; }
    }
}
