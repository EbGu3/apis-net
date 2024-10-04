using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain
{
    public class Streamer : BaseDomainModel
    {
        public string? Name                 { get; set; }
        public string? Url                  { get; set; }

        /// <summary>
        /// ICollection<Video> es una interfaz que representa una colección de objetos
        /// Transformarlo en un List o un HastSet
        /// </summary>
        public ICollection<Video>? Videos   { get; set; }
    }
}
