using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain
{
    public class Streamer
    {
        [Key]
        public int Id           { get; set; }
        public string? Name     { get; set; }
        public string? Url      { get; set; }
    }
}
