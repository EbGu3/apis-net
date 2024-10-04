using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain
{
    public class Streamer
    {
        [Key]
        public int Id                       { get; set; }
        public string? Name                 { get; set; }
        public string? Url                  { get; set; }

        /// <summary>
        /// ICollection<Video> es una interfaz que representa una colección de objetos
        /// Transformarlo en un List o un HastSet
        /// </summary>
        public ICollection<Video>? Videos   { get; set; }
    }
}
