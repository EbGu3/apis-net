namespace CleanArchitecture.Domain
{
    public class Video
    {
        public long Id          { get; set; }
        public string? Name     { get; set; }
        public int StreamerId   { get; set; }

        /// <summary>
        /// Clase que representa a la identidad
        /// Indicarle este puede ser sobreesicrta 
        /// por una clase derivada
        /// </summary>
        public virtual Streamer? Streamer { get; set; }
    }
}
