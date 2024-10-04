using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain
{
    public class Video : BaseDomainModel
    {
        public Video ()
        {
            Actors = new HashSet<Actor>();
        }

        public string? Name                 { get; set; }

        #region LlaveForaneaAStreamer
        /// <summary>
        /// Entity Framework te obliga a que cuando es una 
        /// llave foranea <NOMBRE_TABLA_SINGULAR><ID>
        /// </summary>
        public int StreamerId               { get; set; }

        /// <summary>
        /// Clase que representa a la identidad
        /// Indicarle este puede ser sobreesicrta 
        /// por una clase derivada
        /// </summary>
        public virtual Streamer? Streamer    { get; set; }
        #endregion
    
        public virtual ICollection<Actor>? Actors { get; set; }
    
        // Para relacionar para director
        public virtual Director Director { get; set; }
    }
}
