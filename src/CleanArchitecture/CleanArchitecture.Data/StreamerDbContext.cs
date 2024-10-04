using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Data
{
    public class StreamerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=localhost;Database=Streamer;User Id=sa;Password=eguerra;TrustServerCertificate=True")
                .LogTo
                (
                    Console.WriteLine, 
                    new[] { 
                        DbLoggerCategory.Database.Command.Name 
                    }, 
                    Microsoft.Extensions.Logging.LogLevel.Information
                )
                .EnableSensitiveDataLogging();
        }

        public DbSet<Streamer>? Streamers    { get; set; }
        public DbSet<Video>? Videos          { get; set; }
    }
}
