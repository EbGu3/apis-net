using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Data
{
    public class StreamerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=localhost;Database=Streamer;User Id=sa;Password=eguerra;TrustServerCertificate=True");
        }

        public DbSet<Streamer>? Streamers    { get; set; }
        public DbSet<Video>? Videos          { get; set; }
    }
}
